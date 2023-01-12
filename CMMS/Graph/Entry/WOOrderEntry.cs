using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.WorkflowAPI;
using PX.Objects.CR;
using PX.Objects.EP;
using PX.Objects.IN;
using System.Collections;
using System.Linq;


namespace CMMS
{
    public class WOOrderEntry : PXGraph<WOOrderEntry, WOOrder>
    {
        #region Views
        [PXViewName(Messages.ViewDocument)]
        public SelectFrom<WOOrder>.View Document;

        [PXViewName(Messages.ViewCurrentDocument)]
        public SelectFrom<WOOrder>
            .Where<WOOrder.workOrderID.IsEqual<WOOrder.workOrderID.FromCurrent>>
            .View CurrentDocument;

        [PXViewName(Messages.ViewTransactions)]
        [PXImport]
        public SelectFrom<WOLine>
            .LeftJoin<WOEquipment>.On<WOEquipment.equipmentID.IsEqual<WOLine.equipmentID>>
            .Where<WOLine.workOrderID.IsEqual<WOOrder.workOrderID.FromCurrent>>.OrderBy<WOLine.orderNbr.Asc>
            .View Transactions;

        [PXViewName(Messages.ViewWOLineItems)]
        [PXImport]
        public SelectFrom<WOLineItem>
            .InnerJoin<InventoryItem>.On<InventoryItem.inventoryID.IsEqual<WOLineItem.inventoryID>>
            .Where<WOLineItem.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineItem.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineItems;

        [PXViewName(Messages.ViewWOLineLabor)]
        [PXImport]
        public SelectFrom<WOLineLabor>
            .Where<WOLineLabor.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineLabor.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineLabor;

        [PXViewName(Messages.ViewWOLineTools)]
        [PXImport]
        public SelectFrom<WOLineTool>
            .InnerJoin<WOEquipment>.On<WOEquipment.equipmentID.IsEqual<WOLineTool.equipmentID>>
            .Where<WOLineTool.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineTool.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineTools;

        [PXViewName(Messages.ViewWOLineMeasurements)]
        [PXImport]
        public SelectFrom<WOLineMeasure>
            .Where<WOLineMeasure.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineMeasure.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineMeasurements;

        [PXViewName(Messages.ViewWOLineFailureModes)]
        [PXImport]
        public SelectFrom<WOLineFailure>
            .Where<WOLineFailure.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineFailure.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineFailureModes;

        [PXViewName("Related Work Orders")]
        public SelectFrom<WOOrder4>
            .Where<WOOrder4.origWorkOrderID.IsEqual<WOOrder.workOrderID.FromCurrent>>
            .View RelatedWorkOrders;

        [PXViewName("Schedule")]
        public PXSelect<WOSchedule, Where<WOSchedule.workOrderID, Equal<Current<WOOrder.templateID>>, And<WOSchedule.equipmentID, Equal<Current<WOOrder.equipmentID>>>>> CurrentSchedule;

        public PXSetup<WOSetup> Setup;
        public SelectFrom<WOSetupApproval>.View SetupApproval;

        [PXViewName(PX.Objects.CR.Messages.Answers)]
        public CRAttributeList<WOOrder> Answers;
        #endregion

        #region Hook to Standard Approval System
        [PXViewName(Messages.ViewApproval)]
        public EPApprovalAutomation<WOOrder, WOOrder.approved, WOOrder.rejected, WOOrder.hold, WOSetupApproval> Approval;
        #endregion

        #region EPApproval Cache Attached
        [PXDBDate()]
        [PXDefault(typeof(WOOrder.requestDate), PersistingCheck = PXPersistingCheck.Nothing)]
        protected virtual void EPApproval_DocDate_CacheAttached(PXCache sender)
        {
        }

        [PXDBInt()]
        [PXDefault(typeof(WOOrder.ownerID), PersistingCheck = PXPersistingCheck.Nothing)]
        protected virtual void EPApproval_DocumentOwnerID_CacheAttached(PXCache sender)
        {
        }

        [PXDBString(60, IsUnicode = true)]
        [PXDefault(typeof(WOOrder.descr), PersistingCheck = PXPersistingCheck.Nothing)]
        protected virtual void EPApproval_Descr_CacheAttached(PXCache sender)
        {
        }
        #endregion

        #region Constructor
        public WOOrderEntry()
        {
            WOSetup setup = Setup.Current;
        }
        #endregion

        #region Actions
        #region initializeState
        public PXAutoAction<WOOrder> initializeState;
        #endregion

        #region Hold Action
        public PXAction<WOOrder> putOnHold;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Hold", MapEnableRights = PXCacheRights.Select)]
        protected virtual IEnumerable PutOnHold(PXAdapter adapter) => adapter.Get<WOOrder>();
        #endregion

        #region RemoveHold Action
        public PXAction<WOOrder> removeHold;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Remove Hold", MapEnableRights = PXCacheRights.Select)]
        protected virtual IEnumerable RemoveHold(PXAdapter adapter) => adapter.Get<WOOrder>();
        #endregion

        #region Schedule Action
        public PXAction<WOOrder> schedule;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Schedule")]
        protected virtual IEnumerable Schedule(PXAdapter adapter)
        {
            WOOrder wo = Document.Current;
            if (wo?.ScheduleDate == null)
            {
                wo.ScheduleDate = Accessinfo.BusinessDate;
                Document.Update(wo);
                Save.Press();
            }

            return adapter.Get<WOOrder>();
        }
        #endregion

        #region Open Action
        public PXAction<WOOrder> open;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Open", MapEnableRights = PXCacheRights.Select)]
        protected virtual IEnumerable Open(PXAdapter adapter) => adapter.Get<WOOrder>();
        #endregion

        #region Complete Action
        public PXAction<WOOrder> complete;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Complete", MapEnableRights = PXCacheRights.Select, Visible = true)]
        protected virtual IEnumerable Complete(PXAdapter adapter) => adapter.Get<WOOrder>();
        #endregion

        #region RowUp
        public PXAction<WOOrder> rowUp;
        [PXButton(ImageKey = "ArrowUp", Tooltip = "Move Row Up")]
        [PXUIField(DisplayName = " ", MapEnableRights = PXCacheRights.Update)]
        protected IEnumerable RowUp(PXAdapter adapter)
        {

            SwapRows(Transactions.Current, true);

            return adapter.Get();
        }
        #endregion

        #region RowDown
        public PXAction<WOOrder> rowDown;
        [PXButton(ImageKey = "ArrowDown", Tooltip = "Move Row Down")]
        [PXUIField(DisplayName = " ", MapEnableRights = PXCacheRights.Update)]
        protected IEnumerable RowDown(PXAdapter adapter)
        {
            SwapRows(Transactions.Current, false);

            return adapter.Get();
        }
        #endregion

        #endregion

        #region Events
        protected virtual void __(Events.FieldDefaulting<WOLine.orderNbr> e)
        {
            if(e.Row is WOLine row)
            {
                //This is a terrible way to do it but it works for summit
                int highCount = 0;
                foreach(WOLine line in Transactions.Cache.Cached)
                {
                    if (line.Equals(row)) continue;
                    highCount = (line.OrderNbr ?? 0) >= highCount ? (line.OrderNbr ?? 0) : highCount;
                }
                e.NewValue = ++highCount;
            }
        }

        #endregion

        #region Methods
        private void SwapRows(WOLine line1, bool up)
        {
            WOLine toSwap = Transactions.Select().FirstOrDefault(x => x.Record.OrderNbr == (up == true ? line1.OrderNbr - 1 : line1.OrderNbr + 1));
            if(toSwap != null)
            {
                int? newLine1 = toSwap.OrderNbr;
                int? newToSwap = line1.OrderNbr;

                toSwap.OrderNbr = newToSwap;
                Transactions.Update(toSwap);

                line1.OrderNbr = newLine1;
                Transactions.Update(line1);
            }
        }

        #endregion
    }
}
