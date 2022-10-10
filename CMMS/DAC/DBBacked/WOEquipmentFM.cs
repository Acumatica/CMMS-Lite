using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN;

namespace CMMSlite.WO
{
    [PXPrimaryGraph(typeof(WOEquipmentMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOEquipmentFM)]
    public class WOEquipmentFM : IBqlTable
    {
        #region EquipmentID
        [PXDBInt(IsKey = true)]
        [PXParent(typeof(SelectFrom<WOEquipment>.Where<WOEquipment.equipmentID.IsEqual<equipmentID.FromCurrent>>))]
        [PXDBDefault(typeof(WOEquipment.equipmentID))]
        [PXSelector(
            typeof(WOEquipment.equipmentID),
            typeof(WOEquipment.equipmentCD),
            typeof(WOEquipment.descr),
            typeof(WOEquipment.inventoryID),
            typeof(WOEquipment.sMEquipmentID),
            typeof(WOEquipment.aMMachID),
            SubstituteKey = typeof(WOEquipment.equipmentCD)
            )]
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region FailureModeID
        [PXDBInt(IsKey = true)]
        [PXDefault()]
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

        #region IsMitigated 
        [PXDBBool]
        [PXDefault(false)]
        [PXUIField(DisplayName = Messages.IsMitigated)]
        public virtual bool? IsMitigated { get; set; }
        public abstract class isMitigated : PX.Data.BQL.BqlBool.Field<isMitigated> { }

        #endregion

        #region MitigationDescription 
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.MitigationDescription)]
        public virtual string MitigationDescription { get; set; }
        public abstract class mitigationDescription : PX.Data.BQL.BqlString.Field<mitigationDescription> { }
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