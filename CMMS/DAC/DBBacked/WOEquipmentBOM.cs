using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CS;
using PX.Objects.IN;

namespace CMMS
{
    [PXPrimaryGraph(typeof(WOEquipmentMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOEquipmentBOM)]
    public class WOEquipmentBOM : PXBqlTable, IBqlTable
    {
        #region EquipmentID
        [PXDBInt(IsKey = true)]
        [PXParent(typeof(SelectFrom<WOEquipment>.Where<WOEquipment.equipmentID.IsEqual<equipmentID.FromCurrent>>))]
        [PXDBDefault(typeof(WOEquipment.equipmentID))]
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region InventoryID
        [PXDBInt(IsKey = true)]
        [PXDefault()]
        [PXSelector(
            typeof(InventoryItem.inventoryID),
            typeof(InventoryItem.inventoryCD),
            typeof(InventoryItem.descr),
            SubstituteKey = typeof(InventoryItem.inventoryCD)
            )]
        [PXUIField(DisplayName = Messages.FieldInventoryID)]
        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region Quantity
        [PXDBDecimal()]
        [PXDefault(TypeCode.Decimal, "0.0")]
        [PXUIField(DisplayName = Messages.FieldQuantity)]
        public virtual Decimal? Quantity { get; set; }
        public abstract class quantity : PX.Data.BQL.BqlDecimal.Field<quantity> { }
        #endregion

        #region Criticality
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [EquipmentCriticality.List]
        [PXUIField(DisplayName = Messages.FieldCriticality)]
        public virtual string Criticality { get; set; }
        public abstract class criticality : PX.Data.BQL.BqlString.Field<criticality> { }
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