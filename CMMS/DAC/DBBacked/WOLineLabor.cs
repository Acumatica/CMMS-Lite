using PX.Data;
using System;
using static PX.Objects.FS.ListField_ReasonType;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOOrderEntry))]
    [Serializable]
    [PXCacheName(Messages.DACWOLineLabor)]
    public class WOLineLabor : PXBqlTable, IBqlTable
    {
        #region WorkOrderID
        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(WOLine.workOrderID))]
        [PXParent(
            typeof(Select<WOLine,
                    Where<WOLine.workOrderID, Equal<Current<WOLineLabor.workOrderID>>,
                        And<WOLine.lineNbr, Equal<Current<WOLineLabor.lineNbr>>>>>)
            )]
        public virtual int? WorkOrderID { get; set; }
        public abstract class workOrderID : PX.Data.BQL.BqlInt.Field<workOrderID> { }
        #endregion

        #region WOLineNbr
        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(WOLine.lineNbr))]
        public virtual int? WOLineNbr { get; set; }
        public abstract class wOLineNbr : PX.Data.BQL.BqlInt.Field<wOLineNbr> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(WOLine.lastLaborLineNbr))]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region LaborType
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [LaborTypes.List]
        [PXDefault(LaborTypes.General)]
        [PXUIField(DisplayName = Messages.FieldLaborType)]
        public virtual string LaborType { get; set; }
        public abstract class laborType : PX.Data.BQL.BqlString.Field<laborType> { }
        #endregion

        #region LaborHours
        [PXDBDecimal()]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = Messages.FieldLaborHours)]
        public virtual Decimal? LaborHours { get; set; }
        public abstract class laborHours : PX.Data.BQL.BqlDecimal.Field<laborHours> { }
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
        [PXNote]
        public virtual Guid? NoteID { get; set; }
        public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }
        #endregion

    }

    #region Labor Types
    public static class LaborTypes
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new[]
                {
                    Pair(General, Messages.LaborTypeGeneral),
                    Pair(Electrical, Messages.LaborTypeElectrical),
                    Pair(Mechanical, Messages.LaborTypeMechanical),
                    Pair(Plumbing, Messages.LaborTypePlumbing),
                    Pair(Janitorial, Messages.LaborTypeJanitorial),
                    Pair(Other, Messages.LaborTypeOther),
                })
            { }
        }

        public const string General = "G";
        public const string Electrical = "E";
        public const string Mechanical = "M";
        public const string Plumbing = "P";
        public const string Janitorial = "J";
        public const string Other = "O";

        public class general : PX.Data.BQL.BqlString.Constant<general>
        {
            public general() : base(General) { }
        }

        public class electrical : PX.Data.BQL.BqlString.Constant<electrical>
        {
            public electrical() : base(Electrical) { }
        }

        public class mechanical : PX.Data.BQL.BqlString.Constant<mechanical>
        {
            public mechanical() : base(Mechanical) { }
        }

        public class plumbing : PX.Data.BQL.BqlString.Constant<plumbing>
        {
            public plumbing() : base(Plumbing) { }
        }

        public class janitorial : PX.Data.BQL.BqlString.Constant<janitorial>
        {
            public janitorial() : base(Janitorial) { }
        }

        public class other : PX.Data.BQL.BqlString.Constant<other>
        {
            public other() : base(Other) { }
        }
    }
    #endregion

}
