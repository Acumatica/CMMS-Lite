using PX.Data;
using PX.Objects.CS;
using PX.Objects.EP;
using System;

namespace CMMSlite.WO
{
    [PXPrimaryGraph(typeof(WOSetupMaint))]
    [PXCacheName(Messages.DACWOSetup)]
    [Serializable]
    public class WOSetup : IBqlTable
    {
        #region WorkOrderNumberingID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXDefault(CMMSlite.WO.Messages.CustomWorkSequence)]
        [PXSelector(typeof(Numbering.numberingID), DescriptionField = typeof(Numbering.descr))]
        [PXUIField(DisplayName = Messages.FieldNumberingID)]
        public virtual string WONumberingID { get; set; }
        public abstract class woNumberingID : PX.Data.BQL.BqlString.Field<woNumberingID> { }
        #endregion

        #region TemplateWorkOrderNumberingID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXSelector(typeof(Numbering.numberingID), DescriptionField = typeof(Numbering.descr))]
        [PXDefault(CMMSlite.WO.Messages.TemplateCustomWorkSequence)]
        [PXUIField(DisplayName = Messages.TemplateFieldNumberingID)]
        public virtual string TemplateWorkOrderNumberingID { get; set; }
        public abstract class templateWorkOrderNumberingID : PX.Data.BQL.BqlString.Field<templateWorkOrderNumberingID> { }
        #endregion

        #region EquipNumberingID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXDefault(CMMSlite.WO.Messages.EquipmentNumberingID)]
        [PXSelector(typeof(Numbering.numberingID), DescriptionField = typeof(Numbering.descr))]
        [PXUIField(DisplayName = Messages.FieldEquipNumberingID)]
        public virtual string EquipNumberingID { get; set; }
        public abstract class equipNumberingID : PX.Data.BQL.BqlString.Field<equipNumberingID> { }
        #endregion

        #region WORequestApproval
        [EPRequireApproval]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Null)]
        [PXUIField(DisplayName = Messages.FieldRequestApproval)]
        public virtual bool? WORequestApproval { get; set; }
        public abstract class wORequestApproval : PX.Data.BQL.BqlBool.Field<wORequestApproval> { }
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
        [PXUIField(DisplayName = Messages.FieldCreatedDateTime)]
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
        [PXUIField(DisplayName = Messages.FieldLastModifiedDateTime)]
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