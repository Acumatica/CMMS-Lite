using PX.Data;
using PX.Data.BQL.Fluent;
using System;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOEquipmentMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOSchedule)]
    public class WOSchedule : IBqlTable
    {
        #region Selected
        /// <summary>
        /// Indicates whether the record is selected for mass processing.
        /// </summary>
        public abstract class selected : PX.Data.BQL.BqlBool.Field<selected>
        {
        }
        [PXBool]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Selected")]
        public bool? Selected { get; set; }
        #endregion

        #region EquipmentID
        [PXDBInt(IsKey = true)]
        [PXSelector(
            typeof(WOEquipment.equipmentID),
            typeof(WOEquipment.equipmentCD),
            typeof(WOEquipment.descr),
            typeof(WOEquipment.inventoryID),
            typeof(WOEquipment.sMEquipmentID),
            typeof(WOEquipment.aMMachID),
            SubstituteKey = typeof(WOEquipment.equipmentCD),
            DescriptionField = typeof(WOEquipment.descr)
            )]
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

        #region MeterID1
        [PXDBInt]
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
        public virtual int? MeterID1 { get; set; }
        public abstract class meterID1 : PX.Data.BQL.BqlInt.Field<meterID1> { }
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
        [PXUIField(DisplayName = Messages.FieldNextWODate, Enabled = false)]
        [PXFormula(typeof(Switch<
            Case<Where<lastWODate, IsNotNull, And<frequencyDays, IsNotNull, And<Where<leadTimeDays, IsNull, Or<leadTimeDays, IsNotNull>>>>>,
                Sub<Add<lastWODate, frequencyDays>, leadTimeDays>>,
                Current<AccessInfo.businessDate>
            >))]
        public virtual DateTime? NextWODate { get; set; }
        public abstract class nextWODate : PX.Data.BQL.BqlDateTime.Field<nextWODate> { }
        #endregion

        #region FrequencyUnitsInt
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldFrequencyUnitsInt)]
        public virtual int? FrequencyUnitsInt { get; set; }
        public abstract class frequencyUnitsInt : PX.Data.BQL.BqlInt.Field<frequencyUnitsInt> { }
        #endregion

        #region LeadUnitsInt
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldLeadUnitsInt)]
        public virtual int? LeadUnitsInt { get; set; }
        public abstract class leadUnitsInt : PX.Data.BQL.BqlInt.Field<leadUnitsInt> { }
        #endregion

        #region LastValueInt
        [PXDBInt()]
        [PXUIField(DisplayName = Messages.FieldLastValueInt)]
        public virtual int? LastValueInt { get; set; }
        public abstract class lastValueInt : PX.Data.BQL.BqlInt.Field<lastValueInt> { }
        #endregion

        #region NextValueInt
        [PXDBInt()]
        [PXUIField(DisplayName = Messages.FieldNextValueInt, Enabled = false)]
        [PXFormula(typeof(Switch<
            Case<Where<lastValueInt, IsNotNull, And<frequencyUnitsInt, IsNotNull, And<Where<leadUnitsInt, IsNull, Or<leadUnitsInt, IsNotNull>>>>>,
                Sub<Add<lastValueInt, frequencyUnitsInt>, leadUnitsInt>>,
                lastValueInt
            >))]
        public virtual int? NextValueInt { get; set; }
        public abstract class nextValueInt : PX.Data.BQL.BqlInt.Field<nextValueInt> { }
        #endregion

        #region Meter1ValueInt
        [PXInt()]
        [PXUIField(DisplayName = Messages.FieldValueInt, Enabled = false)]
        [PXDBScalar(typeof(Search<WOMeter.valueInt, Where<WOMeter.meterID, Equal<meterID1>>>))]
        public virtual int? Meter1ValueInt { get; set; }
        public abstract class meter1ValueInt : PX.Data.BQL.BqlInt.Field<meter1ValueInt> { }
        #endregion

        #region MeterJoin
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXDefault(MeterJoinOption.MeterOr, PersistingCheck = PXPersistingCheck.Nothing)]
        [MeterJoinOption.List]
        [PXUIField(DisplayName = Messages.FieldMeterJoin)]
        public virtual string MeterJoin { get; set; }
        public abstract class meterJoin : PX.Data.BQL.BqlString.Field<meterJoin> { }
        #endregion

        #region MeterID2
        [PXDBInt]
        [PXSelector(
            //typeof(Search<WOMeter.meterID, Where<WOMeter.meterID, NotEqual<meterID1>>>),
            typeof(WOMeter.meterID),
            typeof(WOMeter.meterCD),
            typeof(WOMeter.descr),
            typeof(WOMeter.meterType),
            SubstituteKey = typeof(WOMeter.meterCD),
            DescriptionField = typeof(WOMeter.descr)
            )]
        [PXUIField(DisplayName = Messages.FieldWOMeterID)]
        public virtual int? MeterID2 { get; set; }
        public abstract class meterID2 : PX.Data.BQL.BqlInt.Field<meterID2> { }
        #endregion

        #region FrequencyDays2
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldFrequencyDays)]
        public virtual int? FrequencyDays2 { get; set; }
        public abstract class frequencyDays2 : PX.Data.BQL.BqlInt.Field<frequencyDays2> { }
        #endregion

        #region LeadTimeDays2
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldLeadTimeDays)]
        public virtual int? LeadTimeDays2 { get; set; }
        public abstract class leadTimeDays2 : PX.Data.BQL.BqlInt.Field<leadTimeDays2> { }
        #endregion

        #region LastWODate2
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldLastWODate)]
        public virtual DateTime? LastWODate2 { get; set; }
        public abstract class lastWODate2 : PX.Data.BQL.BqlDateTime.Field<lastWODate2> { }
        #endregion

        #region NextWODate2
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldNextWODate, Enabled = false)]
        [PXFormula(typeof(Switch<
            Case<Where<lastWODate2, IsNotNull, And<frequencyDays2, IsNotNull, And<Where<leadTimeDays2, IsNull, Or<leadTimeDays2, IsNotNull>>>>>,
                Sub<Add<lastWODate2, frequencyDays2>, leadTimeDays2>>,
                Current<AccessInfo.businessDate>
            >))]
        public virtual DateTime? NextWODate2 { get; set; }
        public abstract class nextWODate2 : PX.Data.BQL.BqlDateTime.Field<nextWODate2> { }
        #endregion

        #region FrequencyUnitsInt2
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldFrequencyUnitsInt)]
        public virtual int? FrequencyUnitsInt2 { get; set; }
        public abstract class frequencyUnitsInt2 : PX.Data.BQL.BqlInt.Field<frequencyUnitsInt2> { }
        #endregion

        #region LeadUnitsInt2
        [PXDBInt()]
        [PXDefault(0)]
        [PXUIField(DisplayName = Messages.FieldLeadUnitsInt)]
        public virtual int? LeadUnitsInt2 { get; set; }
        public abstract class leadUnitsInt2 : PX.Data.BQL.BqlInt.Field<leadUnitsInt2> { }
        #endregion

        #region LastValueInt2
        [PXDBInt()]
        [PXUIField(DisplayName = Messages.FieldLastValueInt)]
        public virtual int? LastValueInt2 { get; set; }
        public abstract class lastValueInt2 : PX.Data.BQL.BqlInt.Field<lastValueInt2> { }
        #endregion

        #region NextValueInt2
        [PXDBInt()]
        [PXUIField(DisplayName = Messages.FieldNextValueInt, Enabled = false)]
        [PXFormula(typeof(Switch<
            Case<Where<lastValueInt2, IsNotNull, And<frequencyUnitsInt2, IsNotNull, And<Where<leadUnitsInt2, IsNull, Or<leadUnitsInt2, IsNotNull>>>>>,
                Sub<Add<lastValueInt2, frequencyUnitsInt2>, leadUnitsInt2>>,
                lastValueInt2
            >))]
        public virtual int? NextValueInt2 { get; set; }
        public abstract class nextValueInt2 : PX.Data.BQL.BqlInt.Field<nextValueInt2> { }
        #endregion

        #region Meter2ValueInt
        [PXInt()]
        [PXUIField(DisplayName = Messages.FieldValueInt, Enabled = false)]
        [PXDBScalar(typeof(Search<WOMeter.valueInt, Where<WOMeter.meterID, Equal<meterID2>>>))]
        public virtual int? Meter2ValueInt { get; set; }
        public abstract class meter2ValueInt : PX.Data.BQL.BqlInt.Field<meter2ValueInt> { }
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

    #region Meter Join
    public static class MeterJoinOption
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new[]
                {
                    Pair(MeterAnd, Messages.MeterJoinAnd),
                    Pair(MeterOr, Messages.MeterJoinOr),
                })
            { }
        }

        public const string MeterAnd = "A";
        public const string MeterOr = "O";

        public class meterAnd : PX.Data.BQL.BqlString.Constant<meterAnd> { public meterAnd() : base(MeterAnd) { } }
        public class meterOr : PX.Data.BQL.BqlString.Constant<meterOr> { public meterOr() : base(MeterOr) { } }

    }
    #endregion

}