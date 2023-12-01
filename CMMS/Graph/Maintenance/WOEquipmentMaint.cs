using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;
using PX.Web.UI;
using System;

namespace CMMS
{
    [Serializable]
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
            .LeftJoin<WOMeter>
                .On<WOMeter.meterID.IsEqual<WOSchedule.meterID1>>
            .LeftJoin<WOMeter2>
                .On<WOMeter2.meterID.IsEqual<WOSchedule.meterID2>>
            .Where<WOSchedule.equipmentID.IsEqual<WOEquipment.equipmentID.FromCurrent>>
            .View Schedules;

        [PXViewName(Messages.ViewWorkOrders)]
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

        #region  Event Handlers
        #region WOSchedule_RowSelected
        protected virtual void _(Events.RowSelected<WOSchedule> e)
        {
            WOSchedule row = e.Row;

            if(row != null)
            {
                bool ShowMeter1Days = false;
                bool ShowMeter1Int = false;
                bool ShowMeter2Days = false;
                bool ShowMeter2Int = false;

                if (row.MeterID1 != null)
                {
                    WOMeter meter1 = SelectFrom<WOMeter>
                        .Where<WOMeter.meterID.IsEqual<@P.AsInt>>
                        .View.Select(this, row.MeterID1);
                    if (meter1.MeterType == MeterTypes.Days) ShowMeter1Days = true;
                    if (meter1.MeterType == MeterTypes.Miles) ShowMeter1Int = true;
                }

                if (row.MeterID2 != null)
                {
                    WOMeter meter2 = SelectFrom<WOMeter>
                        .Where<WOMeter.meterID.IsEqual<@P.AsInt>>
                        .View.Select(this, row.MeterID2);
                    if (meter2.MeterType == MeterTypes.Days) ShowMeter2Days = true;
                    if (meter2.MeterType == MeterTypes.Miles) ShowMeter2Int = true;
                }

                PXUIFieldAttribute.SetVisible<WOSchedule.frequencyUnitsInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.leadUnitsInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.lastValueInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.nextValueInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.frequencyDays>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.leadTimeDays>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.lastWODate>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.nextWODate>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.meter1ValueInt>(e.Cache, row, ShowMeter1Int);

                PXUIFieldAttribute.SetEnabled<WOSchedule.frequencyUnitsInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.leadUnitsInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.lastValueInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.nextValueInt>(e.Cache, row, ShowMeter1Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.frequencyDays>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.leadTimeDays>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.lastWODate>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.nextWODate>(e.Cache, row, ShowMeter1Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.meter1ValueInt>(e.Cache, row, ShowMeter1Int);

                PXUIFieldAttribute.SetVisible<WOSchedule.frequencyUnitsInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.leadUnitsInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.lastValueInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.nextValueInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetVisible<WOSchedule.frequencyDays2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.leadTimeDays2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.lastWODate2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.nextWODate2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetVisible<WOSchedule.meter2ValueInt>(e.Cache, row, ShowMeter2Int);

                PXUIFieldAttribute.SetEnabled<WOSchedule.frequencyUnitsInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.leadUnitsInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.lastValueInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.nextValueInt2>(e.Cache, row, ShowMeter2Int);
                PXUIFieldAttribute.SetEnabled<WOSchedule.frequencyDays2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.leadTimeDays2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.lastWODate2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.nextWODate2>(e.Cache, row, ShowMeter2Days);
                PXUIFieldAttribute.SetEnabled<WOSchedule.meter2ValueInt>(e.Cache, row, ShowMeter2Int);
            }

        }
        #endregion
        #endregion

        #region WOMeter2 Projection
        [PXHidden]
        [PXProjection(typeof(Select<WOMeter>))]
        public partial class WOMeter2 : IBqlTable
        {

            #region MeterID
            [PXDBInt(BqlField = typeof(WOMeter.meterID))]
            [PXSelector(
                //typeof(Search<WOMeter.meterID, Where<WOMeter.meterID, NotEqual<meterID2>>>),
                typeof(WOMeter.meterID),
                typeof(WOMeter.meterCD),
                typeof(WOMeter.descr),
                typeof(WOMeter.meterType),
                SubstituteKey = typeof(WOMeter.meterCD),
                DescriptionField = typeof(WOMeter.descr)
            )]
            [PXUIField(DisplayName = Messages.FieldWOMeterID)]
            public virtual int? MeterID { get; set; }
            public abstract class meterID : PX.Data.BQL.BqlInt.Field<meterID> { }
            #endregion

            #region Descr
            [PXDBString(255, IsUnicode = true, InputMask = "", BqlField = typeof(WOMeter.descr))]
            [PXUIField(DisplayName = Messages.FieldDescr)]
            public virtual string Descr { get; set; }
            public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
            #endregion

            #region ValueInt
            [PXDBInt(BqlField = typeof(WOMeter.valueInt))]
            [PXUIField(DisplayName = Messages.FieldValueInt)]
            public virtual int? ValueInt { get; set; }
            public abstract class valueInt : PX.Data.BQL.BqlInt.Field<valueInt> { }
            #endregion
        }
        #endregion
    }
}
