﻿using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.WorkflowAPI;
using PX.Objects.EP;
using PX.Objects.IN;
using System.Collections;

namespace CMMSlite.WO
{
    public class WOOrderEntry : PXGraph<WOOrderEntry, WOOrder>
    {
        [PXViewName(Messages.ViewDocument)]
        public SelectFrom<WOOrder>.View Document;

        [PXViewName(Messages.ViewCurrentDocument)]
        public SelectFrom<WOOrder>
            .Where<WOOrder.workOrderID.IsEqual<WOOrder.workOrderID.FromCurrent>>
            .View CurrentDocument;

        [PXViewName(Messages.ViewTransactions)]
        public SelectFrom<WOLine>
            .LeftJoin<WOEquipment>.On<WOEquipment.equipmentID.IsEqual<WOLine.equipmentID>>
            .Where<WOLine.workOrderID.IsEqual<WOOrder.workOrderID.FromCurrent>>
            .View Transactions;

        [PXViewName(Messages.ViewWOLineItems)]
        public SelectFrom<WOLineItem>
            .InnerJoin<InventoryItem>.On<InventoryItem.inventoryID.IsEqual<WOLineItem.inventoryID>>
            .Where<WOLineItem.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineItem.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineItems;

        [PXViewName(Messages.ViewWOLineLabor)]
        public SelectFrom<WOLineLabor>
            .Where<WOLineLabor.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineLabor.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineLabor;

        [PXViewName(Messages.ViewWOLineTools)]
        public SelectFrom<WOLineTool>
            .InnerJoin<InventoryItem>.On<InventoryItem.inventoryID.IsEqual<WOLineTool.inventoryID>>
            .Where<WOLineTool.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineTool.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineTools;

        [PXViewName(Messages.ViewWOLineMeasurements)]
        public SelectFrom<WOLineMeasure>
            .Where<WOLineMeasure.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineMeasure.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineMeasurements;

        [PXViewName(Messages.ViewWOLineFailureModes)]
        public SelectFrom<WOLineFailure>
            .Where<WOLineFailure.workOrderID.IsEqual<WOLine.workOrderID.FromCurrent>
                .And<WOLineFailure.wOLineNbr.IsEqual<WOLine.lineNbr.FromCurrent>>>
            .View LineFailureModes;

        public PXSetup<WOSetup> Setup;
        public SelectFrom<WOSetupApproval>.View SetupApproval;

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

        //[PXDBInt()]
        //[PXDefault(typeof(SSINItemPlan.customerID), PersistingCheck = PXPersistingCheck.Nothing)]
        //protected virtual void EPApproval_BAccountID_CacheAttached(PXCache sender)
        //{
        //}

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

        //[PXDBLong()]
        //[CurrencyInfo(typeof(WOOrder.curyInfoID))]
        //protected virtual void EPApproval_CuryInfoID_CacheAttached(PXCache sender)
        //{
        //}

        //[PXDBDecimal(4)]
        //[PXDefault(typeof(WOOrder.curyExtCost), PersistingCheck = PXPersistingCheck.Nothing)]
        //protected virtual void EPApproval_CuryTotalAmount_CacheAttached(PXCache sender)
        //{
        //}

        //[PXDBDecimal(4)]
        //[PXDefault(typeof(WOOrder.extCost), PersistingCheck = PXPersistingCheck.Nothing)]
        //protected virtual void EPApproval_TotalAmount_CacheAttached(PXCache sender)
        //{
        //}
        #endregion

        #region Constructor
        public WOOrderEntry()
        {
            WOSetup setup = Setup.Current;
        }
        #endregion

        public PXAutoAction<WOOrder> initializeState;

        //public PXAction<WOOrder> putOnHold;
        //[PXButton(CommitChanges = true), PXUIField(DisplayName = "Hold", MapEnableRights = PXCacheRights.Select)]
        //protected virtual IEnumerable PutOnHold(PXAdapter adapter) => adapter.Get<WOOrder>();

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

    }
}