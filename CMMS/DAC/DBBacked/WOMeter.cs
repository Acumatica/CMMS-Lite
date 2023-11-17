using System;
using PX.Data;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.Objects.RQ;
using static CMMS.WOMeter;
using static CMMS.WOSchedule;
using static PX.Objects.FS.FSRouteDocument;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOMeterMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOMeter)]
    public class WOMeter : IBqlTable
    {
        #region Keys
        public class PK : PrimaryKeyOf<WOMeter>.By<meterCD>
        {
            public static WOMeter Find(PXGraph graph, string meterCD) => FindBy(graph, meterCD);
        }
        #endregion

        #region MeterID
        [PXDBIdentity]
        public virtual int? MeterID { get; set; }
        public abstract class meterID : PX.Data.BQL.BqlInt.Field<meterID> { }
        #endregion

        #region MeterCD
        [PXDBString(30, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXDefault]
        [AutoNumber(typeof(WOSetup.meterNumberingID), typeof(AccessInfo.businessDate))]
        [PXSelector(
            typeof(WOMeter.meterCD),
            typeof(WOMeter.meterCD),
            typeof(WOMeter.descr),
            typeof(WOMeter.meterType)
            )]
        [PXUIField(DisplayName = Messages.FieldWOMeterID)]
        public virtual string MeterCD { get; set; }
        public abstract class meterCD : PX.Data.BQL.BqlString.Field<meterCD> { }
        #endregion

        #region MeterType
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXDefault(MeterTypes.Days, PersistingCheck = PXPersistingCheck.Nothing)]
        [MeterTypes.List]
        [PXUIField(DisplayName = Messages.FieldMeterType)]
        public virtual string MeterType { get; set; }
        public abstract class meterType : PX.Data.BQL.BqlString.Field<meterType> { }
        #endregion

        #region Descr
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldDescr)]
        public virtual string Descr { get; set; }
        public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
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

        #region LastValueDate
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldLastValueDate)]
        public virtual DateTime? LastValueDate { get; set; }
        public abstract class lastValueDate : PX.Data.BQL.BqlDateTime.Field<lastValueDate> { }
        #endregion

        #region NextValueDate
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldNextValueDate, Enabled = false)]
        [PXFormula(typeof(Switch<
            Case<Where<lastValueDate, IsNotNull, And<frequencyUnitsInt, IsNotNull, And<Where<leadUnitsInt, IsNull, Or<leadUnitsInt, IsNotNull>>>>>,
                Sub<Add<lastValueDate, frequencyUnitsInt>, leadUnitsInt>>,
                Current<AccessInfo.businessDate>
            >))]
        public virtual DateTime? NextValueDate { get; set; }
        public abstract class nextValueDate : PX.Data.BQL.BqlDateTime.Field<nextValueDate> { }
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

    #region Meter Types
    public static class MeterTypes
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new[]
                {
                    Pair(Days, Messages.MeterTypeDays),
                    Pair(Miles, Messages.MeterTypeMiles),
                })
            { }
        }

        public const string Days = "DD";
        public const string Miles = "MI";

        public class days : PX.Data.BQL.BqlString.Constant<days> { public days() : base(Days) { } }
        public class miles : PX.Data.BQL.BqlString.Constant<miles> { public miles() : base(Miles) { } }

    }
    #endregion

}