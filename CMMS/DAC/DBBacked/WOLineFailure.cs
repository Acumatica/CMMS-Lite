using System;
using PX.Data;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOOrderEntry))]
    [Serializable]
    [PXCacheName(Messages.DACWOLineFailureMode)]
    public class WOLineFailure : PXBqlTable, IBqlTable
    {
        #region WorkOrderID
        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(WOLine.workOrderID))]
        [PXParent(
            typeof(Select<WOLine,
                    Where<WOLine.workOrderID, Equal<Current<WOLineFailure.workOrderID>>,
                        And<WOLine.lineNbr, Equal<Current<WOLineFailure.lineNbr>>>>>)
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
        [PXLineNbr(typeof(WOLine.lastFailureLineNbr))]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region FailureModeID
        [PXDBInt()]
        [PXSelector(
            typeof(WOFailureMode.failureModeID),
            typeof(WOFailureMode.failureModeCD),
            typeof(WOFailureMode.descr),
            SubstituteKey = typeof(WOFailureMode.failureModeCD)
            )]
        [PXUIField(DisplayName = Messages.FieldFailureModeID)]
        public virtual int? FailureModeID { get; set; }
        public abstract class failureModeID : PX.Data.BQL.BqlInt.Field<failureModeID> { }
        #endregion

        #region Comment
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldComment)]
        public virtual string Comment { get; set; }
        public abstract class comment : PX.Data.BQL.BqlString.Field<comment> { }
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
}