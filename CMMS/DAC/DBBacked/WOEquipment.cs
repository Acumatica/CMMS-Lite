using System;
using PX.Data;
using PX.Objects.CS;
using PX.Objects.IN;

namespace CMMSlite.WO
{
    [PXPrimaryGraph(typeof(WOEquipmentMaint))]
    [Serializable]
    [PXCacheName(Messages.DACWOEquipment)]
    public class WOEquipment : IBqlTable
    {
        #region EquipmentID
        [PXDBIdentity]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region EquipmentCD
        [PXDBString(30, IsKey = true,IsUnicode = true, InputMask = "")]
        [PXDefault]
        [AutoNumber(typeof(WOSetup.equipNumberingID), typeof(AccessInfo.businessDate))]

        // Old code
        //[PXSelector(
        //    typeof(WOEquipment.equipmentCD),
        //    typeof(WOEquipment.equipmentCD),
        //    typeof(WOEquipment.descr),
        //    typeof(WOEquipment.inventoryID),
        //    typeof(WOEquipment.sMEquipmentID),
        //    typeof(WOEquipment.aMMachID)
        //    )]

        // New code fixed one
        [PXSelector(typeof(Search<WOEquipment.equipmentCD>),
            typeof(WOEquipment.equipmentCD),
            typeof(WOEquipment.descr),
            typeof(WOEquipment.inventoryID),
            typeof(WOEquipment.sMEquipmentID),
            typeof(WOEquipment.aMMachID)
            )]
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        public virtual string EquipmentCD { get; set; }
        public abstract class equipmentCD : PX.Data.BQL.BqlString.Field<equipmentCD> { }
        #endregion

        #region EquipmentType
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXDefault(EquipmentTypes.Machine, PersistingCheck = PXPersistingCheck.Nothing)]
        [EquipmentTypes.List]
        [PXUIField(DisplayName = Messages.FieldEquipmentType)]
        public virtual string EquipmentType { get; set; }
        public abstract class equipmentType : PX.Data.BQL.BqlString.Field<equipmentType> { }
        #endregion

        #region Descr
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldDescr)]
        public virtual string Descr { get; set; }
        public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
        #endregion

        #region SerialNbr
        [PXDBString(30, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldSerialNbr)]
        public virtual string SerialNbr { get; set; }
        public abstract class serialNbr : PX.Data.BQL.BqlString.Field<serialNbr> { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [Statuses.List]
        [PXDefault(Statuses.Planned)]
        [PXUIField(DisplayName = Messages.FieldStatus)]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region BranchID
        [PXDBInt()]
        [PXDefault(typeof(AccessInfo.branchID))]
        [PXUIField(DisplayName = Messages.FieldBranchID)]
        public virtual int? BranchID { get; set; }
        public abstract class branchID : PX.Data.BQL.BqlInt.Field<branchID> { }
        #endregion

        #region DepartmentID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldDepartment)]
        public virtual string DepartmentID { get; set; }
        public abstract class departmentID : PX.Data.BQL.BqlString.Field<departmentID> { }
        #endregion

        #region AssetID
        [PXDBString(30, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldAssetID)]
        public virtual string AssetID { get; set; }
        public abstract class assetID : PX.Data.BQL.BqlString.Field<assetID> { }
        #endregion

        #region PhysicalLocation
        [PXDBString(30, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldPhysicalLocation)]
        public virtual string PhysicalLocation { get; set; }
        public abstract class physicalLocation : PX.Data.BQL.BqlString.Field<physicalLocation> { }
        #endregion

        #region DateInstalled
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldDateInstalled)]
        public virtual DateTime? DateInstalled { get; set; }
        public abstract class dateInstalled : PX.Data.BQL.BqlDateTime.Field<dateInstalled> { }
        #endregion

        #region Criticality
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [EquipmentCriticality.List]
        [PXUIField(DisplayName = Messages.FieldCriticality)]
        public virtual string Criticality { get; set; }
        public abstract class criticality : PX.Data.BQL.BqlString.Field<criticality> { }
        #endregion

        #region InventoryID
        [PXUIField(DisplayName = Messages.FieldInventoryID)]
        [AnyInventory(typeof(Search<InventoryItem.inventoryID, Where<Match<Current<AccessInfo.userName>>>>),
            typeof(InventoryItem.inventoryCD),
            typeof(InventoryItem.descr))]
        public virtual int? InventoryID { get; set; }
        public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
        #endregion

        #region SMEquipmentID
        [PXDBInt()]
        [PXSelector(
            typeof(PX.Objects.FS.FSEquipment.SMequipmentID),
            typeof(PX.Objects.FS.FSEquipment.refNbr),
            typeof(PX.Objects.FS.FSEquipment.descr),
            SubstituteKey = typeof(PX.Objects.FS.FSEquipment.refNbr),
            DescriptionField = typeof(PX.Objects.FS.FSEquipment.descr)
            )]
        [PXUIField(DisplayName = Messages.FieldSMEquipmentID)]
        public virtual int? SMEquipmentID { get; set; }
        public abstract class sMEquipmentID : PX.Data.BQL.BqlInt.Field<sMEquipmentID> { }
        #endregion

        #region AMMachID
        [PXDBString(30, IsUnicode = true, InputMask = "")]
        [PXSelector(
            typeof(PX.Objects.AM.AMMach.machID),
            typeof(PX.Objects.AM.AMMach.machID),
            typeof(PX.Objects.AM.AMMach.descr),
            DescriptionField = typeof(PX.Objects.AM.AMMach.descr)
            )]
        [PXUIField(DisplayName = Messages.FieldAMMachID)]
        public virtual string AMMachID { get; set; }
        public abstract class aMMachID : PX.Data.BQL.BqlString.Field<aMMachID> { }
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

    #region Equipment Types
    public static class EquipmentTypes
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new[]
                {
                    Pair(Machine, Messages.EquipTypeMachine),
                    Pair(Component, Messages.EquipTypeComponent),
                    Pair(Tool, Messages.EquipTypeTool),
                    Pair(Other, Messages.EquipTypeOther),
                })
            { }
        }

        public const string Machine = "M";
        public const string Component = "C";
        public const string Tool = "T";
        public const string Other = "O";

        public class machine : PX.Data.BQL.BqlString.Constant<machine>
        {
            public machine() : base(Machine) { }
        }

        public class component : PX.Data.BQL.BqlString.Constant<component>
        {
            public component() : base(Component) { }
        }

        public class tool : PX.Data.BQL.BqlString.Constant<component>
        {
            public tool() : base(Tool) { }
        }

        public class other : PX.Data.BQL.BqlString.Constant<other>
        {
            public other() : base(Other) { }
        }
    }
    #endregion

    #region Equipment Criticality
    public static class EquipmentCriticality
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
            new[]
            {
                    Pair(CriticalityA, Messages.EquipCritA),
                    Pair(CriticalityB, Messages.EquipCritB),
                    Pair(CriticalityC, Messages.EquipCritC),
                    Pair(CriticalityD, Messages.EquipCritD),
                    Pair(CriticalityE, Messages.EquipCritE),
                })
            { }
        }

        public const string CriticalityA = "A";
        public const string CriticalityB = "B";
        public const string CriticalityC = "C";
        public const string CriticalityD = "D";
        public const string CriticalityE = "E";

        public class criticalityA : PX.Data.BQL.BqlString.Constant<criticalityA>
        {
            public criticalityA() : base(CriticalityA) { }
        }

        public class criticalityB : PX.Data.BQL.BqlString.Constant<criticalityB>
        {
            public criticalityB() : base(CriticalityB) { }
        }

        public class criticalityC : PX.Data.BQL.BqlString.Constant<criticalityC>
        {
            public criticalityC() : base(CriticalityC) { }
        }

        public class criticalityD : PX.Data.BQL.BqlString.Constant<criticalityD>
        {
            public criticalityD() : base(CriticalityD) { }
        }

        public class criticalityE : PX.Data.BQL.BqlString.Constant<criticalityE>
        {
            public criticalityE() : base(CriticalityE) { }
        }

    }
    #endregion

    #region Statuses
    public static class Statuses
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new[]
                {
                    Pair(Planned, Messages.EquipStatusPlanned),
                    Pair(Active, Messages.EquipStatusActive),
                    Pair(Decomissioned, Messages.EquipStatusDecomissioned),
                })
            { }
        }

        public const string Planned = "P";
        public const string Active = "A";
        public const string Decomissioned = "D";

        public class planned : PX.Data.BQL.BqlString.Constant<planned>
        {
            public planned() : base(Planned) { }
        }

        public class active : PX.Data.BQL.BqlString.Constant<active>
        {
            public active() : base(Active) { }
        }

        public class decomissioned : PX.Data.BQL.BqlString.Constant<decomissioned>
        {
            public decomissioned() : base(Decomissioned) { }
        }

    }
    #endregion

}