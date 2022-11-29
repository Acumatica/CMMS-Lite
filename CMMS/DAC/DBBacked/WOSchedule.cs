using PX.Data;
using PX.Data.BQL.Fluent;
using System;

namespace CMMSlite.WO
{
    [PXPrimaryGraph(typeof(WOEquipmentMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOSchedule)]
    public class WOSchedule : IBqlTable
    {
        #region EquipmentID
        [PXDBInt(IsKey = true)]
        [PXParent(typeof(SelectFrom<WOEquipment>.Where<WOEquipment.equipmentID.IsEqual<equipmentID.FromCurrent>>))]
        [PXDBDefault(typeof(WOEquipment.equipmentID))]
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region WorkOrderID
        [PXDBInt(IsKey = true)]
        [PXDefault()]
        [PXSelector(
            typeof(Search<WOOrder.workOrderID, Where<WOOrder.workOrderType, Equal<WorkOrderTypes.template>>>),
            typeof(WOOrder.workOrderCD),
            typeof(WOOrder.descr),
            typeof(WOOrder.createdDateTime),
            SubstituteKey = typeof(WOOrder.workOrderCD)
            )]
        [PXUIField(DisplayName = Messages.FieldWorkOrderID)]
        public virtual int? WorkOrderID { get; set; }
        public abstract class workOrderID : PX.Data.BQL.BqlInt.Field<workOrderID> { }
        #endregion

        #region FrequencyDays
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldFrequencyDays)]
        public virtual int? FrequencyDays { get; set; }
        public abstract class frequencyDays : PX.Data.BQL.BqlInt.Field<frequencyDays> { }
        #endregion

        #region LeadTimeDays
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldLeadTimeDays)]
        public virtual int? LeadTimeDays { get; set; }
        public abstract class leadTimeDays : PX.Data.BQL.BqlInt.Field<leadTimeDays> { }
        #endregion

        #region LastWODate
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldLastWODate)]
        public virtual DateTime? LastWODate { get; set; }
        public abstract class lastWODate : PX.Data.BQL.BqlDateTime.Field<lastWODate> { }
        #endregion

        #region NextWODate
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldNextWODate)]
        public virtual DateTime? NextWODate { get; set; }
        public abstract class nextWODate : PX.Data.BQL.BqlDateTime.Field<nextWODate> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region NoteID
        [PXNote()]
        public virtual Guid? NoteID { get; set; }
        public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }
        #endregion
    }

}