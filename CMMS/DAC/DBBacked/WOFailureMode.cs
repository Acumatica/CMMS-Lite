using System;
using PX.Data;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOFailureModeMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOFailureMode)]
    public class WOFailureMode : PXBqlTable, IBqlTable
    {
        #region FailureModeID
        [PXDBIdentity]
        public virtual int? FailureModeID { get; set; }
        public abstract class failureModeID : PX.Data.BQL.BqlInt.Field<failureModeID> { }
        #endregion

        #region FailureModeCD
        [PXDBString(30, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldFailureModeID)]
        public virtual string FailureModeCD { get; set; }
        public abstract class failureModeCD : PX.Data.BQL.BqlString.Field<failureModeCD> { }
        #endregion

        #region Descr
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldDescr)]
        public virtual string Descr { get; set; }
        public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
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