using PX.Data;
using System;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOOrderEntry))]
    [Serializable]
    [PXCacheName(Messages.DACWOLine)]
    public class WOLine : IBqlTable
    {
        #region WorkOrderID
        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(WOOrder.workOrderID))]
        [PXParent(
            typeof(Select<WOOrder,
                    Where<WOOrder.workOrderID,
                    Equal<Current<WOLine.workOrderID>>>>)
            )]
        public virtual int? WorkOrderID { get; set; }
        public abstract class workOrderID : PX.Data.BQL.BqlInt.Field<workOrderID> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(WOOrder.lastLineNbr))]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region LastLaborLineNbr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? LastLaborLineNbr { get; set; }
        public abstract class lastLaborLineNbr : PX.Data.BQL.BqlInt.Field<lastLaborLineNbr> { }
        #endregion

        #region LastItemLineNbr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? LastItemLineNbr { get; set; }
        public abstract class lastItemLineNbr : PX.Data.BQL.BqlInt.Field<lastItemLineNbr> { }
        #endregion

        #region LastToolLineNbr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? LastToolLineNbr { get; set; }
        public abstract class lastToolLineNbr : PX.Data.BQL.BqlInt.Field<lastToolLineNbr> { }
        #endregion

        #region LastMeasureLineNbr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? LastMeasureLineNbr { get; set; }
        public abstract class lastMeasureLineNbr : PX.Data.BQL.BqlInt.Field<lastMeasureLineNbr> { }
        #endregion

        #region LastFailureLineNbr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? LastFailureLineNbr { get; set; }
        public abstract class lastFailureLineNbr : PX.Data.BQL.BqlInt.Field<lastFailureLineNbr> { }
        #endregion

        #region EquipmentID
        [PXDBInt()]
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
        [PXUIField(DisplayName = Messages.FieldEquipmentID, Visibility = PXUIVisibility.Visible)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region Descr
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldWOLineDescr)]
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
