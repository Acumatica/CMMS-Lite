using PX.Data;
using PX.Data.WorkflowAPI;
using PX.Objects.Common;

namespace CMMSlite.WO
{
    using static PX.Data.WorkflowAPI.BoundedTo<WOOrderEntry, WOOrder>;
    using static WOOrder;
    using State = WOOrder.Statuses;

    public class WOOrderEntry_Workflow : PXGraphExtension<WOOrderEntry>
    {

        public static bool IsActive() => true;

        #region Define Constants
        private const string
            _actionRemoveHold = "Remove Hold",
            _actionPutOnHold = "Hold",
            _actionComplete = "Complete",
            _actionOpen = "Open";
        #endregion

        #region Override Configure
        public override void Configure(PXScreenConfiguration config)
        {
            Configure(config.GetScreenConfigurationContext<WOOrderEntry, WOOrder>());
        }
        #endregion

        #region Configure the Workflow for This Screen
        protected virtual void Configure(WorkflowContext<WOOrderEntry, WOOrder> context)
        {

            #region Categories
            var processingCategory = CommonActionCategories.Get(context).Processing;
            #endregion

            #region Conditions
            Condition Bql<T>() where T : IBqlUnary, new() => context.Conditions.FromBql<T>();

            var conditions = new
            {
                IsOnHold
                    = Bql<hold.IsEqual<True>>(),
                IsScheduled
                    = Bql<scheduleDate.IsNotNull>(),
            }.AutoNameConditions();
            #endregion

            #region Actions
            var removeHold = context.ActionDefinitions
                .CreateNew(_actionRemoveHold, a => a
                .WithCategory(processingCategory)
                .PlaceAfter(g => g.Last)
                );
            var putOnHold = context.ActionDefinitions
                .CreateNew(_actionPutOnHold, a => a
                .WithCategory(processingCategory)
                .PlaceAfter(removeHold)
                );
            var complete = context.ActionDefinitions
                .CreateNew(_actionComplete, a => a
                .WithCategory(processingCategory)
                .PlaceAfter(putOnHold)
                .IsDisabledWhen(!conditions.IsScheduled)
                );
            var open = context.ActionDefinitions
                .CreateNew(_actionOpen, a => a
                .WithCategory(processingCategory)
                .PlaceAfter(complete)
                );
            #endregion


            #region Configure the Screen
            context.AddScreenConfigurationFor(screen =>
            {
                #region Define the Default Workflow
                screen
                    .StateIdentifierIs<status>()
                    .AddDefaultFlow(flow => flow
                        // Add States
                        .WithFlowStates(states =>
                        {
                            // Initial State
                            states.Add(State.InitialState, flowState => flowState.IsInitial(g => g.initializeState));

                            // Hold State
                            states.Add<State.hold>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(removeHold, a => a
                                    .IsDuplicatedInToolbar()
                                    .WithConnotation(ActionConnotation.Success)
                                    );
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>();
                                    fields.AddField<hold>(c => c.IsHidden());
                                }));

                            // Pending Schedule State
                            states.Add<State.pendingSchedule>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(putOnHold);
                                    actions.Add(g => g.schedule, a => a
                                    .IsDuplicatedInToolbar()
                                    .WithConnotation(ActionConnotation.Success)
                                    );
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>();
                                    fields.AddField<hold>(c => c.IsHidden());
                                }));

                            // Scheduled State
                            states.Add<State.scheduled>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(putOnHold);
                                    actions.Add(open, a => a
                                    .IsDuplicatedInToolbar()
                                    .WithConnotation(ActionConnotation.Success)
                                    );
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>();
                                    fields.AddField<hold>(c => c.IsHidden());
                                }));


                            // Open State
                            states.Add<State.open>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(putOnHold);
                                    actions.Add(complete, a => a
                                    .IsDuplicatedInToolbar()
                                    .WithConnotation(ActionConnotation.Success)
                                    );
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>();
                                    fields.AddField<hold>(c => c.IsHidden());
                                }));

                            // Complete State
                            states.Add<State.complete>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(open);
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>();
                                    fields.AddField<hold>(c => c.IsHidden());
                                }));
                        })

                        // Add Transitions
                        .WithTransitions(transitions =>
                        {
                            // Initial
                            transitions.AddGroupFrom(State.InitialState, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.hold>()
                                    .IsTriggeredOn(g => g.initializeState)
                                    .When(conditions.IsOnHold));
                            });

                            // Hold
                            transitions.AddGroupFrom(State.Hold, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.pendingSchedule>()
                                    .IsTriggeredOn(removeHold)
                                    .WithFieldAssignments(fas => fas.Add<hold>(false))
                                    );
                            });

                            // Pending Schedule
                            transitions.AddGroupFrom(State.PendingSchedule, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.hold>()
                                    .IsTriggeredOn(putOnHold)
                                    .WithFieldAssignments(fas => fas.Add<hold>(true))
                                    );
                                ts.Add(t => t
                                    .To<State.scheduled>()
                                    .IsTriggeredOn(g => g.schedule)
                                    );
                            });

                            // Scheduled
                            transitions.AddGroupFrom(State.Scheduled, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.hold>()
                                    .IsTriggeredOn(putOnHold)
                                    .WithFieldAssignments(fas => fas.Add<hold>(true))
                                    );
                                ts.Add(t => t
                                    .To<State.open>()
                                    .IsTriggeredOn(open)
                                    );
                            });

                            // Open
                            transitions.AddGroupFrom(State.Open, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.hold>()
                                    .IsTriggeredOn(putOnHold)
                                    .WithFieldAssignments(fas => fas.Add<hold>(true))
                                    );
                                ts.Add(t => t
                                    .To<State.complete>()
                                    .IsTriggeredOn(complete)
                                    );
                            });

                            // Complete
                            transitions.AddGroupFrom(State.Complete, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.open>()
                                    .IsTriggeredOn(open)
                                    );
                            });

                        }));
                #endregion

                #region Add Actions to the Menus
                screen
                    .WithActions(action =>
                    {
                        action.Add(removeHold);
                        action.Add(putOnHold);
                        action.Add(complete);
                        action.Add(open);
                        action.Add(g => g.schedule, a => a
                            .WithCategory(processingCategory)
                            .IsHiddenWhen(conditions.IsScheduled)
                            );
                    });
                #endregion

                return screen;

            });
            #endregion

        }
        #endregion

    }
}