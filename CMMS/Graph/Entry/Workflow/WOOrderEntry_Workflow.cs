using PX.Data;
using PX.Data.WorkflowAPI;
using PX.Objects.Common;
using System;
using System.Runtime.Serialization;

namespace CMMSlite.WO
{
    using static PX.Data.WorkflowAPI.BoundedTo<WOOrderEntry, WOOrder>;
    using static WOOrder;
    using State = WOOrder.Statuses;

    public class WOOrderEntry_Workflow : PXGraphExtension<WOOrderEntry>
    {

        public static bool IsActive() => true;

        //#region Define Constants
        //private const string
        //    _actionRemoveHold = "Remove Hold",
        //    _actionPutOnHold = "Hold",
        //    _actionComplete = "Complete",
        //    _actionOpen = "Open";
        //#endregion

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
            //var processingCategory = CommonActionCategories.Get(context).Processing;
            #endregion

            #region Conditions
            Condition Bql<T>() where T : IBqlUnary, new() => context.Conditions.FromBql<T>();

            var conditions = new
            {
                IsOnHold
                    = Bql<hold.IsEqual<True>>(),
                IsPendingSchedule
                    = Bql<status.IsEqual<State.pendingSchedule>>(),
                //IsScheduled
                //    = Bql<scheduleDate.IsNotNull>(),
                IsOpen
                    = Bql<status.IsEqual<State.open>>(),
            }.AutoNameConditions();
            #endregion

            #region Actions
            var putOnHold = context.ActionDefinitions
                .CreateExisting(g => g.putOnHold, a => a
                .WithCategory(PredefinedCategory.Actions)
                .PlaceAfter(g => g.Last)
                .IsDisabledWhen(conditions.IsOnHold)
                .IsHiddenWhen(conditions.IsOnHold)
                .WithFieldAssignments(fas =>
                {
                    fas.Add<hold>(true);
                    fas.Add<approved>(false);
                    fas.Add<rejected>(false);
                })
                );
            //var removeHold = context.ActionDefinitions
            //    .CreateExisting(g => g.removeHold, a => a
            //    .WithCategory(PredefinedCategory.Actions)
            //    .PlaceAfter(putOnHold)
            //    .IsDisabledWhen(!conditions.IsOnHold)
            //    .IsHiddenWhen(!conditions.IsOnHold)
            //    .WithFieldAssignments(fas => fas.Add<hold>(false))
            //    );
            var schedule = context.ActionDefinitions
                .CreateExisting(g => g.schedule, a => a
                .WithCategory(PredefinedCategory.Actions)
                //.PlaceAfter(removeHold)
                .PlaceAfter(g => g.removeHold)
                .IsDisabledWhen(!conditions.IsPendingSchedule)
                .IsHiddenWhen(!conditions.IsPendingSchedule)
                );
            var open = context.ActionDefinitions
                .CreateExisting(g => g.open, a => a
                .WithCategory(PredefinedCategory.Actions)
                .PlaceAfter(schedule)
                );
            var complete = context.ActionDefinitions
                .CreateExisting(g => g.complete, a => a
                .WithCategory(PredefinedCategory.Actions)
                .PlaceAfter(open)
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
                                        actions.Add(g => g.removeHold, a => a
                                        .IsDuplicatedInToolbar()
                                        .WithConnotation(ActionConnotation.Success)
                                        );
                                    })
                                    .WithFieldStates(fields =>
                                    {
                                        fields.AddAllFields<WOOrder>();
                                    })); 
                            
                            //states.Add<State.hold>(flowState => flowState
                            //    .WithActions(actions =>
                            //    {
                            //        actions.Add(removeHold, a => a
                            //        .IsDuplicatedInToolbar()
                            //        .WithConnotation(ActionConnotation.Success)
                            //        );
                            //    })
                            //    .WithFieldStates(fields =>
                            //    {
                            //        fields.AddAllFields<WOOrder>();
                            //    }));

                            // Pending Schedule State
                            states.Add<State.pendingSchedule>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(putOnHold);
                                    actions.Add(schedule, a => a
                                    .IsDuplicatedInToolbar()
                                    .WithConnotation(ActionConnotation.Success)
                                    );
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>(c => c.IsDisabled());
                                    fields.AddField<workOrderCD>();
                                    fields.AddField<status>();
                                    fields.AddAllFields<WOLine>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineItem>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineLabor>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineTool>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineMeasure>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineFailure>(c => c.IsDisabled());
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
                                    fields.AddAllFields<WOOrder>(c => c.IsDisabled());
                                    fields.AddField<workOrderCD>();
                                    fields.AddField<status>();
                                    fields.AddAllFields<WOLine>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineItem>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineLabor>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineTool>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineMeasure>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineFailure>(c => c.IsDisabled());
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
                                    fields.AddAllFields<WOOrder>(c => c.IsDisabled());
                                    fields.AddField<workOrderCD>();
                                    fields.AddField<status>();
                                    fields.AddAllFields<WOLine>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineItem>();
                                    fields.AddAllFields<WOLineLabor>();
                                    fields.AddAllFields<WOLineTool>();
                                    fields.AddAllFields<WOLineMeasure>();
                                    fields.AddAllFields<WOLineFailure>();
                                }));

                            // Complete State
                            states.Add<State.complete>(flowState => flowState
                                .WithActions(actions =>
                                {
                                    actions.Add(open);
                                })
                                .WithFieldStates(fields =>
                                {
                                    fields.AddAllFields<WOOrder>(c => c.IsDisabled());
                                    fields.AddField<workOrderCD>();
                                    fields.AddAllFields<WOLine>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineItem>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineLabor>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineTool>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineMeasure>(c => c.IsDisabled());
                                    fields.AddAllFields<WOLineFailure>(c => c.IsDisabled());
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
                                    .IsTriggeredOn(g => g.removeHold)
                                    //.WithFieldAssignments(fas => fas.Add<hold>(false))
                                    );
                            });

                            // Pending Schedule
                            transitions.AddGroupFrom(State.PendingSchedule, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.hold>()
                                    .IsTriggeredOn(putOnHold)
                                    );
                                ts.Add(t => t
                                    .To<State.scheduled>()
                                    .IsTriggeredOn(schedule)
                                    );
                            });

                            // Scheduled
                            transitions.AddGroupFrom(State.Scheduled, ts =>
                            {
                                ts.Add(t => t
                                    .To<State.hold>()
                                    .IsTriggeredOn(putOnHold)
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
                        action.Add(g => g.removeHold, f => f
                            .WithCategory(PredefinedCategory.Actions)
                            .WithFieldAssignments(fas =>
                            {
                                fas.Add<hold>(false);
                            })
                            .PlaceAfter(g => g.Last)
                            .IsDisabledWhen(!conditions.IsOnHold)
                            .IsHiddenWhen(!conditions.IsOnHold)
                        );

                        action.Add(putOnHold);
                        //action.Add(removeHold);
                        action.Add(schedule);
                        action.Add(open);
                        action.Add(complete);
                    });
                #endregion

                return screen;

            });
            #endregion

        }
        #endregion

    }
}