using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.WorkflowAPI;
using PX.Objects.CR;
using PX.Objects.EP;
using PX.Objects.IN;
using System;
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
            .InnerJoin<WOMeasurement>.On<WOMeasurement.measurementID.IsEqual<WOLineMeasure.measurementID>>
            .Where<WOLineMeasure.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineMeasure.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineMeasurements;

        [PXViewName(Messages.ViewWOLineFailureModes)]
        [PXImport]
        public SelectFrom<WOLineFailure>
            .InnerJoin<WOFailureMode>.On<WOFailureMode.failureModeID.IsEqual<WOLineFailure.failureModeID>>
            .Where<WOLineFailure.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineFailure.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineFailureModes;

        [PXViewName(Messages.ViewWORelatedWO)]
        public SelectFrom<WOOrder4>
            .Where<WOOrder4.origWorkOrderID.IsEqual<WOOrder.workOrderID.FromCurrent>>
            .View RelatedWorkOrders;

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

        #region Schedule
        #region Schedule Action
        public PXAction<WOOrder> schedule;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Schedule", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable Schedule(PXAdapter adapter)
        {
            WebDialogResult dialogResult = schedulefilter.AskExt(setScheduleStateFilter, true);

            if ((dialogResult == WebDialogResult.OK) &&
                schedulefilter.Current?.ScheduleDate != null)
            {
                WOOrder wo = Document.Current;
                wo.ScheduleDate = schedulefilter.Current?.ScheduleDate;
                Document.Update(wo);
                Save.Press();
            }

            return adapter.Get<WOOrder>();
        }
        #endregion

        #region WOScheduleDate_RowSelected
        protected virtual void _(Events.RowSelected<WOScheduleDate> e)
        {
            if (e.Row == null) return;
            WOScheduleDate row = e.Row as WOScheduleDate;

            checkSchedule.SetEnabled(schedulefilter.Current.ScheduleDate != null);

            e.Cache.IsDirty = false;
        }
        #endregion

        #region WOScheduleDate_ScheduleDate_FieldDefaulting
        protected virtual void _(Events.FieldDefaulting<WOScheduleDate.scheduleDate> e)
        {
            WOOrder row = Document.Current;
            if (row != null) { e.NewValue = row.ScheduleDate; }
            if (e.NewValue == null) { e.NewValue = Accessinfo.BusinessDate; }
        }
        #endregion

        #region setScheduleStateFilter
        private void setScheduleStateFilter(PXGraph aGraph, string ViewName)
        {
            schedulefilter.Cache.SetDefaultExt<WOScheduleDate.scheduleDate>(schedulefilter.Current);

            checkSchedule.SetEnabled(schedulefilter.Current.ScheduleDate != null);
        }
        #endregion

        #region checkSchedule Action
        public PXAction<WOOrder> checkSchedule;
        [PXUIField(DisplayName = "OK", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select)]
        [PXButton]
        public virtual IEnumerable CheckSchedule(PXAdapter adapter)
        {
            return adapter.Get();
        }
        #endregion

        #region WOScheduleDate
        [Serializable]
        [PXHidden]
        public class WOScheduleDate : PXBqlTable, IBqlTable
        {
            #region ScheduleDate
            [PXDate]
            [PXDefault()]
            [PXUIField(DisplayName = Messages.FieldScheduleDate, Required = true)]
            public virtual DateTime? ScheduleDate { get; set; }
            public abstract class scheduleDate : PX.Data.BQL.BqlDateTime.Field<scheduleDate> { }
            #endregion

        }
        #endregion

        public PXFilter<WOScheduleDate> schedulefilter;

        #endregion

        #region Open Action
        public PXAction<WOOrder> open;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Open", MapEnableRights = PXCacheRights.Select)]
        protected virtual IEnumerable Open(PXAdapter adapter) => adapter.Get<WOOrder>();
        #endregion

        #region Complete Action
        public PXAction<WOOrder> complete;
        [PXButton(CommitChanges = true), PXUIField(DisplayName = "Complete", MapEnableRights = PXCacheRights.Select, Visible = true)]
        protected virtual IEnumerable Complete(PXAdapter adapter)
        {
            WOOrder order = Document.Current;

            if(order.TemplateID != null)
            {
                WOEquipmentMaint graph = PXGraph.CreateInstance<WOEquipmentMaint>();
                graph.Equipment.Current = graph.Equipment.Search<WOEquipment.equipmentID>(order.EquipmentID);
                graph.Schedules.Current = graph.Schedules.Search<WOSchedule.equipmentID, WOSchedule.workOrderID>(order.EquipmentID, order.TemplateID);
                WOSchedule schedule = graph.Schedules.Current;
                if (schedule != null)
                {
                    schedule.LastWODate = Accessinfo.BusinessDate;
                    graph.Schedules.Update(schedule);
                    graph.Save.Press();
                }
            }

            return adapter.Get<WOOrder>();
        }
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
        #region WOLine_OrderNbr_FieldDefaulting
        protected virtual void __(Events.FieldDefaulting<WOLine.orderNbr> e)
        {
            if (e.Row is WOLine row)
            {
                //This is a terrible way to do it but it works for summit
                int highCount = 0;
                foreach (WOLine line in Transactions.Cache.Cached)
                {
                    if (line.Equals(row)) continue;
                    highCount = (line.OrderNbr ?? 0) >= highCount ? (line.OrderNbr ?? 0) : highCount;
                }
                e.NewValue = ++highCount;
            }
        }
        #endregion

        #region WOOrder_RowSelected
        protected virtual void _(Events.RowSelected<WOOrder> e)
        {
            WOOrder row = e.Row;
            if(row != null)
            {
                PXUIFieldAttribute.SetEnabled<WOOrder.scheduleDate>(e.Cache, row, false);
            }
        }
        #endregion

        #endregion

        #region Methods
        private void SwapRows(WOLine line1, bool up)
        {
            WOLine toSwap = Transactions.Select().FirstOrDefault(x => x.Record.OrderNbr == (up == true ? line1.OrderNbr - 1 : line1.OrderNbr + 1));
            if (toSwap != null)
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
