//using PX.Data;
//using PX.Data.WorkflowAPI;

//namespace CMMSlite.WO
//{
//    using static PX.Data.WorkflowAPI.BoundedTo<WOOrderEntry, WOOrder>;
//    using static WOOrder;
//    using State = WOOrder.Statuses;
//    using This = WOOrderEntry_ApprovalWorkflow;

//    public class WOOrderEntry_ApprovalWorkflow : PXGraphExtension<WOOrderEntry_Workflow, WOOrderEntry>
//    {
//        public static bool IsActive() => true;

//        private class WOApprovalSettings : IPrefetchable
//        {
//            private static WOApprovalSettings Current => PXDatabase.GetSlot<WOApprovalSettings>(nameof(WOApprovalSettings), typeof(WOSetup), typeof(WOSetupApproval));

//            public static bool IsActive => Current.OrderRequestApproval;

//            private bool OrderRequestApproval;

//            void IPrefetchable.Prefetch()
//            {
//                using (PXDataRecord wOSetup = PXDatabase.SelectSingle<WOSetup>(new PXDataField<WOSetup.wORequestApproval>()))
//                {
//                    if (wOSetup != null)
//                        OrderRequestApproval = (bool)wOSetup.GetBoolean(0);
//                }
//            }

//            private static bool RequestApproval(string orderType)
//            {
//                using (PXDataRecord WOApproval = PXDatabase.SelectSingle<WOSetupApproval>(
//                    new PXDataField<WOSetupApproval.approvalID>()))
//                {
//                    if (WOApproval != null)
//                        return (int?)WOApproval.GetInt32(0) != null;
//                }
//                return false;
//            }
//        }


//        public const string ApproveActionName = "Approve";
//        public const string RejectActionName = "Reject";

//        [PXWorkflowDependsOnType(typeof(WOSetup), typeof(WOSetupApproval))]
//        public override void Configure(PXScreenConfiguration config)
//        {
//            if (Base.Document.Current?.RequestApproval == true)
//                //if (true)
//                Configure(config.GetScreenConfigurationContext<WOOrderEntry, WOOrder>());
//            else
//                HideApproveAndRejectActions(config.GetScreenConfigurationContext<WOOrderEntry, WOOrder>());
//        }

//        protected virtual void HideApproveAndRejectActions(WorkflowContext<WOOrderEntry, WOOrder> context)
//        {
//            var approve = context.ActionDefinitions
//                .CreateNew(ApproveActionName, a => a
//                .WithCategory(PredefinedCategory.Actions)
//                .PlaceAfter(g => g.putOnHold)
//                .IsHiddenAlways());
//            var reject = context.ActionDefinitions
//                .CreateNew(RejectActionName, a => a
//                .WithCategory(PredefinedCategory.Actions)
//                .PlaceAfter(approve)
//                .IsHiddenAlways());

//            context.UpdateScreenConfigurationFor(screen =>
//            {
//                return screen
//                    .WithActions(actions =>
//                    {
//                        actions.Add(approve);
//                        actions.Add(reject);
//                    });
//            });
//        }


//        protected virtual void Configure(WorkflowContext<WOOrderEntry, WOOrder> context)
//        {
//            var approve = context.ActionDefinitions
//                .CreateNew(ApproveActionName, a => a
//                .WithCategory(PredefinedCategory.Actions)
//                .PlaceAfter(g => g.putOnHold)
//                );
//            var reject = context.ActionDefinitions
//                .CreateNew(RejectActionName, a => a
//                .WithCategory(PredefinedCategory.Actions)
//                .PlaceAfter(approve)
//                );

//            context.UpdateScreenConfigurationFor(screen =>
//            {
//                return screen
//                    .WithActions(actions =>
//                    {
//                        actions.Add(approve);
//                        actions.Add(reject);
//                    });
//            });
//        }
//    }
//}