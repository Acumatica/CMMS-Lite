﻿using PX.Data;
using System;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOOrderEntry))]
    [Serializable]
    [PXCacheName(Messages.DACWOLineTool)]
    public class WOLineTool : IBqlTable
    {
        #region WorkOrderID
        [PXDBInt(IsKey = true)]
        [PXDBDefault(typeof(WOLine.workOrderID))]
        [PXParent(
            typeof(Select<WOLine,
                    Where<WOLine.workOrderID, Equal<Current<WOLineTool.workOrderID>>,
                        And<WOLine.lineNbr, Equal<Current<WOLineTool.lineNbr>>>>>)
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
        [PXLineNbr(typeof(WOLine.lastToolLineNbr))]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region EquipmentID
        [PXDBInt()]
        [PXSelector(
            typeof(Search<WOEquipment.equipmentID, Where<WOEquipment.equipmentType, Equal<EquipmentTypes.tool>>>),
            typeof(WOEquipment.equipmentCD),
            typeof(WOEquipment.descr),
            typeof(WOEquipment.sMEquipmentID),
            typeof(WOEquipment.aMMachID),
            typeof(WOEquipment.ePEquipmentID),
            typeof(WOEquipment.inventoryID),
            SubstituteKey = typeof(WOEquipment.equipmentCD),
            DescriptionField = typeof(WOEquipment.descr)
            )]
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region Quantity
        [PXDBDecimal()]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = Messages.FieldQuantity)]
        public virtual Decimal? Quantity { get; set; }
        public abstract class quantity : PX.Data.BQL.BqlDecimal.Field<quantity> { }
        #endregion

        #region BaseUnit
        [PXDBString(8, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldBaseUnit)]
        public virtual string BaseUnit { get; set; }
        public abstract class baseUnit : PX.Data.BQL.BqlString.Field<baseUnit> { }
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
