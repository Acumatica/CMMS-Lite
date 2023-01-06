using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;

namespace CMMS
{
    public class WOEquipmentMaint : PXGraph<WOEquipmentMaint, WOEquipment>
    {
        #region Views
        [PXViewName(Messages.ViewEquipment)]
        public SelectFrom<WOEquipment>.View Equipment;

        [PXViewName(Messages.ViewCurrentEquipment)]
        public SelectFrom<WOEquipment>
            .Where<WOEquipment.equipmentID.IsEqual<WOEquipment.equipmentID.FromCurrent>>
            .View CurrentEquipment;

        [PXViewName(Messages.ViewFailureModes)]
        public SelectFrom<WOEquipmentFM>
            .InnerJoin<WOFailureMode>.On<WOFailureMode.failureModeID.IsEqual<WOEquipmentFM.failureModeID>>
            .Where<WOEquipmentFM.equipmentID.IsEqual<WOEquipment.equipmentID.FromCurrent>>
            .View FailureModes;

        [PXViewName(Messages.ViewSchedules)]
        public SelectFrom<WOSchedule>
            .InnerJoin<WOOrder>
                .On<WOOrder.workOrderID.IsEqual<WOSchedule.workOrderID>
                    .And<WOOrder.workOrderType.IsEqual<WorkOrderTypes.template>>>
            .Where<WOSchedule.equipmentID.IsEqual<WOEquipment.equipmentID.FromCurrent>>
            .View Schedules;

        [PXViewName(Messages.ViewSWorkOrders)]
        public SelectFrom<WOOrder>
            .Where<WOOrder.equipmentID.IsEqual<WOEquipment.equipmentID.FromCurrent>
                .And<WOOrder.workOrderType.IsNotEqual<WorkOrderTypes.template>>>.OrderBy<Desc<WOOrder.scheduleDate>>
            .View.ReadOnly WorkOrders;

        [PXViewName(Messages.ViewBOM)]
        public SelectFrom<WOEquipmentBOM>
            .InnerJoin<InventoryItem>.On<InventoryItem.inventoryID.IsEqual<WOEquipmentBOM.inventoryID>>
            .Where<WOEquipmentBOM.equipmentID.IsEqual<WOEquipment.equipmentID.FromCurrent>>
            .View BOM;

        public PXSetup<WOSetup> Setup;
        #endregion

        #region Const
        public WOEquipmentMaint()
        {
            WOSetup setup = Setup.Current;
        }
        #endregion

        #region CacheAttached
        [PXDBInt(IsKey = true)]
        [PXParent(typeof(SelectFrom<WOEquipment>.Where<WOEquipment.equipmentID.IsEqual<WOSchedule.equipmentID.FromCurrent>>))]
        [PXDBDefault(typeof(WOEquipment.equipmentID))]
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        protected virtual void __(Events.CacheAttached<WOSchedule.equipmentID> e)
        {
        }
        #endregion
    }
}
