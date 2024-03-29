﻿using PX.Data;
using PX.Data.WorkflowAPI;
using PX.Objects.Common;
using PX.Objects.CS;

namespace CMMS
{
    using static BoundedTo<WOOrderEntry, WOOrder>;
    using static WOOrder;
    using State = WOOrder.Statuses;

    public class WOOrderEntry_ApprovalWorkflow : PXGraphExtension<WOOrderEntry_Workflow, WOOrderEntry>
    {
        public static bool IsActive() => true;

        #region Approval Settings
        private class WOApprovalSettings : IPrefetchable
        {
            private static WOApprovalSettings Current =>
                PXDatabase.GetSlot<WOApprovalSettings>(nameof(WOApprovalSettings), typeof(WOSetup), typeof(WOSetupApproval));

            public static bool IsActive => Current.requestApproval;
            private bool requestApproval;

            void IPrefetchable.Prefetch()
            {
                using (PXDataRecord setup = PXDatabase.SelectSingle<WOSetup>(new PXDataField<WOSetup.wORequestApproval>()))
                {
                    if (setup != null)
                        requestApproval = ((bool?)setup.GetBoolean(0) == true);
                }
            }

            private static bool RequestApproval()
            {
                using (PXDataRecord approval = PXDatabase.SelectSingle<WOSetupApproval>(
                    new PXDataField<WOSetupApproval.approvalID>()))
                {
                    if (approval != null)
                        return (int?)approval.GetInt32(0) != null;
                }
                return false;
            }
        }
        #endregion

        public const string ApproveActionName = "Approve";
        public const string RejectActionName = "Reject";

        private static bool ApprovalIsActive => PXAccess.FeatureInstalled<PX.Objects.CS.FeaturesSet.approvalWorkflow>() && WOApprovalSettings.IsActive;

        #region Override Configure - Show or Hide Approval Workflow
        [PXWorkflowDependsOnType(typeof(WOSetup), typeof(WOSetupApproval))]
        public override void Configure(PXScreenConfiguration config)
        {
            if (ApprovalIsActive)
                Configure(config.GetScreenConfigurationContext<WOOrderEntry, WOOrder>());
            else
                HideApproveAndRejectActions(config.GetScreenConfigurationContext<WOOrderEntry, WOOrder>());
        }
        #endregion

        #region HideApproveAndRejectActions
        protected virtual void HideApproveAndRejectActions(WorkflowContext<WOOrderEntry, WOOrder> context)
        {
            var approve = context.ActionDefinitions
                .CreateNew(ApproveActionName, a => a
                .WithCategory(PredefinedCategory.Actions)
                .PlaceAfter(g => g.putOnHold)
                .IsHiddenAlways());
            var reject = context.ActionDefinitions
                .CreateNew(RejectActionName, a => a
                .WithCategory(PredefinedCategory.Actions)
                .PlaceAfter(approve)
                .IsHiddenAlways());

            context.UpdateScreenConfigurationFor(screen =>
            {
                return screen
                    .WithActions(actions =>
                    {
                        actions.Add(approve);
                        actions.Add(reject);
                    });
            });
        }
        #endregion

        protected virtual void Configure(WorkflowContext<WOOrderEntry, WOOrder> context)
        {
            #region Conditions
            Condition Bql<T>() where T : IBqlUnary, new() => context.Conditions.FromBql<T>();
            Condition Existing(string name) => (Condition)context.Conditions.Get(name);
            var conditions = new
            {
                IsPendingApproval
                    = Bql<status.IsEqual<State.pendingApproval>>(),
                IsApproved
                    = Bql<approved.IsEqual<True>>(),
                IsRejected
                    = Bql<rejected.IsEqual<True>>(),

                IsOnHold
                    = Existing("IsOnHold"),
                ApprovalRequired
                    = Bql<requestApproval.IsEqual<True>>(),
            }.AutoNameConditions();
            #endregion

            #region Categories
            var approvalCategory = context.Categories.CreateNew(CommonActionCategories.ApprovalCategoryID,
                    category => category.DisplayName(CommonActionCategories.DisplayNames.Approval)
                    .PlaceAfter(CommonActionCategories.IntercompanyCategoryID));
            #endregion

            #region Actions
            var approve = context.ActionDefinitions
                .CreateNew(ApproveActionName, a => a
                .WithCategory(approvalCategory)
                .PlaceAfter(g => g.putOnHold)
                .MapEnableToSelect()
                .IsHiddenWhen(!conditions.IsPendingApproval)
                .WithFieldAssignments(fas =>
                {
                    fas.Add<approved>(true);
                }));
            var reject = context.ActionDefinitions
                .CreateNew(RejectActionName, a => a
                .WithCategory(approvalCategory)
                .PlaceAfter(approve)
                .MapEnableToSelect()
                .IsHiddenWhen(!conditions.IsPendingApproval)
                .WithFieldAssignments(fas =>
                {
                    fas.Add<rejected>(true);
                }));
            #endregion

            context.UpdateScreenConfigurationFor(screen =>
            {
                screen
                    .UpdateDefaultFlow(flow => flow
                        .WithFlowStates(states =>
                        {
                            states
                                .Add<State.pendingApproval>(flowState => flowState
                                    //.PlaceBefore(State.PendingSchedule)
                                    .WithActions(actions =>
                                    {
                                        actions.Add(g => g.putOnHold);
                                        actions.Add(approve, c => c
                                            .IsDuplicatedInToolbar()
                                            .WithConnotation(ActionConnotation.Success)
                                            );
                                        actions.Add(reject, c => c
                                            .IsDuplicatedInToolbar()
                                            .WithConnotation(ActionConnotation.Danger)
                                            );
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
                                        fields.AddAllFields<CSAnswers>(c => c.IsDisabled());
                                    }));
                            states
                                .Add<State.rejected>(flowState => flowState
                                    .WithActions(actions =>
                                    {
                                        actions.Add(g => g.putOnHold);
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
                                        fields.AddAllFields<CSAnswers>(c => c.IsDisabled());
                                    }));
                            //states
                            //    .Add<State.approved>(flowState => flowState
                            //        .WithActions(actions =>
                            //        {
                            //            actions.Add(g => g.putOnHold);
                            //            actions.Add(g => g.complete, c => c.IsDuplicatedInToolbar());
                            //        })
                            //        .WithFieldStates(fields =>
                            //        {
                            //            fields.AddAllFields<WOOrder>(c => c.IsDisabled());
                            //            fields.AddField<workOrderCD>();
                            //            fields.AddAllFields<WOLine>(c => c.IsDisabled());
                            //            fields.AddAllFields<WOLineItem>(c => c.IsDisabled());
                            //            fields.AddAllFields<WOLineLabor>(c => c.IsDisabled());
                            //            fields.AddAllFields<WOLineTool>(c => c.IsDisabled());
                            //            fields.AddAllFields<WOLineMeasure>(c => c.IsDisabled());
                            //            fields.AddAllFields<WOLineFailure>(c => c.IsDisabled());
                            //            fields.AddAllFields<CSAnswers>(c => c.IsDisabled());
                            //        }));
                        })
                        .WithTransitions(transitions =>
                        {
                            transitions
                                .UpdateGroupFrom(State.InitialState, ts =>
                                {
                                    ts.Add(t => t
                                        .To<State.rejected>()
                                        .IsTriggeredOn(g => g.initializeState)
                                        .When(conditions.IsRejected)
                                        .PlaceAfter(tr => tr.To<State.hold>()));
                                    //ts.Add(t => t
                                    //    .To<State.pendingSchedule>()
                                    //    .IsTriggeredOn(g => g.initializeState)
                                    //    .When(conditions.IsApproved)
                                    //    .PlaceAfter(tr => tr.To<State.rejected>()));
                                    ts.Add(t => t
                                        .To<State.pendingApproval>()
                                        .IsTriggeredOn(g => g.initializeState)
                                        .When(!conditions.IsApproved)
                                        .PlaceAfter(tr => tr.To<State.rejected>()));
                                });

                            transitions.UpdateGroupFrom<State.hold>(ts =>
                            {
                                //ts.Add(t => t
                                //    .To<State.pendingSchedule>()
                                //    .IsTriggeredOn(g => g.removeHold)
                                //    .When(!conditions.IsOnHold && conditions.IsApproved)
                                //    .PlaceBefore(tr => tr.To<State.open>()));
                                ts.Add(t => t
                                    .To<State.pendingApproval>()
                                    .IsTriggeredOn(g => g.removeHold)
                                    .When(!conditions.IsOnHold && !conditions.IsApproved)
                                    .PlaceBefore(tr => tr.To<State.pendingSchedule>())
                                );
                            });

                            transitions
                                .AddGroupFrom<State.pendingApproval>(ts =>
                                {
                                    ts.Add(t => t
                                         .To<State.pendingSchedule>()
                                        .IsTriggeredOn(approve)
                                        .When(conditions.IsApproved)
                                        );

                                    ts.Add(t => t
                                        .To<State.rejected>()
                                        .IsTriggeredOn(reject)
                                        .When(conditions.IsRejected)
                                        );

                                    ts.Add(t => t
                                        .To<State.hold>()
                                        .IsTriggeredOn(g => g.putOnHold)
                                        .When(conditions.IsOnHold)
                                        );
                                });

                            transitions
                                .AddGroupFrom<State.rejected>(ts =>
                                {
                                    ts.Add(t => t
                                        .To<State.hold>()
                                        .IsTriggeredOn(g => g.putOnHold)
                                        .When(conditions.IsOnHold)
                                        );
                                });

                            //transitions
                            //    .AddGroupFrom<State.approved>(ts =>
                            //    {
                            //        ts.Add(t => t
                            //            .To<State.hold>()
                            //            .IsTriggeredOn(g => g.putOnHold)
                            //            .When(conditions.IsOnHold)
                            //            );
                            //        ts.Add(t => t
                            //            .To<State.complete>()
                            //            .IsTriggeredOn(g => g.complete));
                            //    });
                        })
                        );

                screen
                    .WithActions(actions =>
                    {
                        actions.Add(approve);
                        actions.Add(reject);
                        //actions.Update(g => g.complete, c => c
                        //    .IsDisabledWhen(!conditions.IsApproved)
                        //    .IsHiddenWhen(!conditions.IsApproved)
                        //    );
                    });
                return screen;
            });
        }
    }
}