using PX.Data;
using PX.Data.EP;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.AM;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.TM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMMSlite.WO
{
    #region WOOrder
    /// <summary>
    /// The CMMS Work Order is the maintenance document for planning
    /// maintenance of plant equipment and facilities
    /// </summary>
#pragma warning disable CS0618 // Type or member is obsolete - Still required for setting up Approvals
    [PXEMailSource]
#pragma warning restore CS0618 // Type or member is obsolete
    [PXPrimaryGraph(typeof(WOOrderEntry))]
    [Serializable]
    [PXCacheName(Messages.DACWOOrder)]
    public class WOOrder : IBqlTable, IAssign
    {
        #region WorkOrderType
        [PXDBString(1, IsKey = true, IsFixed = true, InputMask = "")]
        [WorkOrderTypes.List]
        [PXDefault(WorkOrderTypes.Standard)]
        [PXUIField(DisplayName = Messages.FieldWorkOrderType)]
        public virtual string WorkOrderType { get; set; }
        public abstract class workOrderType : PX.Data.BQL.BqlString.Field<workOrderType> { }
        #endregion

        #region WorkOrderID
        [PXDBIdentity]
        public virtual int? WorkOrderID { get; set; }
        public abstract class workOrderID : PX.Data.BQL.BqlInt.Field<workOrderID> { }
        #endregion

        #region WorkOrderCD
        [PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXDefault]
        [AutoNumber(typeof(WOSetup.woNumberingID), typeof(AccessInfo.businessDate))]
        [PXSelector(
            typeof(Search<WOOrder.workOrderCD, Where<WOOrder.workOrderType, Equal<workOrderType.FromCurrent>>>),
            typeof(WOOrder.workOrderCD),
            typeof(WOOrder.descr),
            typeof(WOOrder.createdDateTime)
            )]
        [PXUIField(DisplayName = Messages.FieldWorkOrderID)]
        public virtual string WorkOrderCD { get; set; }
        public abstract class workOrderCD : PX.Data.BQL.BqlString.Field<workOrderCD> { }
        #endregion

        #region WOClassID
        [PXDBString(15, IsUnicode = true, InputMask = ">aaaaaaaaaaaaaaa")]
        [PXDefault]
        [PXForeignReference(typeof(Field<wOClassID>.IsRelatedTo<WOClass.wOClassID>))]
        [PXSelector(
            typeof(WOClass.wOClassID),
            typeof(WOClass.wOClassID),
            typeof(WOClass.descr),
            Filterable = true
            )]
        [PXUIField(DisplayName = Messages.FieldWOClassID)]
        public virtual string WOClassID { get; set; }
        public abstract class wOClassID : PX.Data.BQL.BqlString.Field<wOClassID> { }
        #endregion

        #region Hold
        [PXDBBool()]
        [PXDefault(true)]
        [PXUIField(DisplayName = Messages.FieldHold)]
        public virtual bool? Hold { get; set; }
        public abstract class hold : PX.Data.BQL.BqlBool.Field<hold> { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [Statuses.List]
        [PXDefault(Statuses.Hold)]
        [PXUIField(DisplayName = Messages.FieldStatus, Enabled = false)]
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

        #region Priority
        [PXDBString()]
        [Priorities.List]
        [PXDefault(Priorities.Normal)]
        [PXUIField(DisplayName = Messages.FieldPriority)]
        public virtual string Priority { get; set; }
        public abstract class priority : PX.Data.BQL.BqlString.Field<priority> { }
        #endregion

        #region OrigWorkOrderID
        [PXDBInt()]
        [PXSelector(
            typeof(WOOrder.workOrderCD),
            typeof(WOOrder.workOrderCD),
            typeof(WOOrder.descr),
            typeof(WOOrder.createdDateTime)
            )]
        [PXUIField(DisplayName = Messages.FieldOrigWorkOrderID)]
        public virtual int? OrigWorkOrderID { get; set; }
        public abstract class origWorkOrderID : PX.Data.BQL.BqlInt.Field<origWorkOrderID> { }
        #endregion

        #region LastLineNbr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? LastLineNbr { get; set; }
        public abstract class lastLineNbr : PX.Data.BQL.BqlInt.Field<lastLineNbr> { }
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
        [PXUIField(DisplayName = Messages.FieldEquipmentID)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region Descr
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = Messages.FieldDescr)]
        public virtual string Descr { get; set; }
        public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
        #endregion

        #region RequestDate
        [PXDBDate()]
        [PXDefault(typeof(AccessInfo.businessDate))]
        [PXUIField(DisplayName = Messages.FieldRequestDate)]
        public virtual DateTime? RequestDate { get; set; }
        public abstract class requestDate : PX.Data.BQL.BqlDateTime.Field<requestDate> { }
        #endregion

        #region ScheduleDate
        [PXDBDate()]
        [PXUIField(DisplayName = Messages.FieldScheduleDate)]
        public virtual DateTime? ScheduleDate { get; set; }
        public abstract class scheduleDate : PX.Data.BQL.BqlDateTime.Field<scheduleDate> { }
        #endregion

        #region OwnerID
        [Owner(typeof(workgroupID), DisplayName = Messages.FieldOwnerID)]
        [PXDefault(typeof(AccessInfo.contactID), PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual int? OwnerID { get; set; }
        public abstract class ownerID : PX.Data.BQL.BqlInt.Field<ownerID> { }
        #endregion

        #region WorkgroupID
        [PXDBInt()]
        [PXSelector(typeof(Search<EPCompanyTree.workGroupID>), SubstituteKey = typeof(EPCompanyTree.description))]
        [PXUIField(DisplayName = Messages.FieldWorkGroupID)]
        public virtual int? WorkgroupID { get; set; }
        public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
        #endregion

        #region Approved
        [PXDBBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual bool? Approved { get; set; }
        public abstract class approved : PX.Data.BQL.BqlBool.Field<approved> { }
        #endregion

        #region Rejected
        [PXBool()]
        [PXDefault(false, PersistingCheck = PXPersistingCheck.Nothing)]
        public virtual bool? Rejected { get; set; }
        public abstract class rejected : PX.Data.BQL.BqlBool.Field<rejected> { }
        #endregion

        #region RequestApproval
        [PXDBBool()]
        [PXUIField(Visible = false)]
        [PXDBDefault(typeof(WOSetup.wORequestApproval))]
        public virtual bool? RequestApproval { get; set; }
        public abstract class requestApproval : PX.Data.BQL.BqlBool.Field<requestApproval> { }
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

        #region IAssign Members
        int? PX.Data.EP.IAssign.WorkgroupID
        {
            get
            {
                return WorkgroupID;
            }
            set
            {
                WorkgroupID = value;
            }
        }

        int? PX.Data.EP.IAssign.OwnerID
        {
            get { return OwnerID; }
            set { OwnerID = value; }
        }
        #endregion

        #region Attributes
        public abstract class attributes : BqlAttributes.Field<attributes> { }
        [CRAttributesField(typeof(wOClassID))]
        public virtual string[] Attributes { get; set; }
        public virtual string ClassID
        {
            get { return WOClassID; }
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
                    Pair(InitialState, Messages.WOStatusInitialState),
                    Pair(Hold, Messages.WOStatusHold),
                    Pair(PendingApproval, Messages.WOStatusPendingApproval),
                    Pair(Approved, Messages.WOStatusApproved),
                    Pair(Rejected, Messages.WOStatusRejected),
                    Pair(PendingSchedule, Messages.WOStatusPendingSchedule),
                    Pair(Scheduled, Messages.WOStatusScheduled),
                    Pair(Open, Messages.WOStatusOpen),
                    Pair(Complete, Messages.WOStatusComplete),
                    })
                { }
            }

            public const string InitialState = "_";
            public const string Hold = "H";
            public const string PendingSchedule = "R";
            public const string Scheduled = "S";
            public const string Open = "O";
            public const string Complete = "C";

            public const string PendingApproval = "P";
            public const string Approved = "A";
            public const string Rejected = "V";   // V = VOIDED


            public class initialState : PX.Data.BQL.BqlString.Constant<initialState>
            {
                public initialState() : base(InitialState) { }
            }

            public class hold : PX.Data.BQL.BqlString.Constant<hold>
            {
                public hold() : base(Hold) { }
            }

            public class pendingApproval : PX.Data.BQL.BqlString.Constant<pendingApproval>
            {
                public pendingApproval() : base(PendingApproval) { }
            }

            public class approved : PX.Data.BQL.BqlString.Constant<approved>
            {
                public approved() : base(Approved) { }
            }

            public class rejected : PX.Data.BQL.BqlString.Constant<rejected>
            {
                public rejected() : base(Rejected) { }
            }

            public class pendingSchedule : PX.Data.BQL.BqlString.Constant<pendingSchedule>
            {
                public pendingSchedule() : base(PendingSchedule) { }
            }

            public class scheduled : PX.Data.BQL.BqlString.Constant<scheduled>
            {
                public scheduled() : base(Scheduled) { }
            }

            public class open : PX.Data.BQL.BqlString.Constant<open>
            {
                public open() : base(Open) { }
            }

            public class complete : PX.Data.BQL.BqlString.Constant<complete>
            {
                public complete() : base(Complete) { }
            }
        }
        #endregion

        #region Priorities
        public static class Priorities
        {
            public class ListAttribute : PXStringListAttribute
            {
                public ListAttribute() : base(
                    new[]
                    {
                    Pair(Critical, Messages.WOPriorityCritical),
                    Pair(Severe, Messages.WOPrioritySevere),
                    Pair(Urgent, Messages.WOPriorityUrgent),
                    Pair(Normal, Messages.WOPriorityNormal),
                    Pair(Low, Messages.WOPriorityLow),
                    })
                { }
            }

            public const string Critical = "A";
            public const string Severe = "B";
            public const string Urgent = "C";
            public const string Normal = "D";
            public const string Low = "E";

            public class critical : PX.Data.BQL.BqlString.Constant<critical>
            {
                public critical() : base(Critical) { }
            }

            public class severe : PX.Data.BQL.BqlString.Constant<severe>
            {
                public severe() : base(Severe) { }
            }

            public class urgent : PX.Data.BQL.BqlString.Constant<urgent>
            {
                public urgent() : base(Urgent) { }
            }

            public class normal : PX.Data.BQL.BqlString.Constant<normal>
            {
                public normal() : base(Normal) { }
            }

            public class low : PX.Data.BQL.BqlString.Constant<low>
            {
                public low() : base(Low) { }
            }
        }
        #endregion

    }
    #endregion

    #region Work Order Types
    public static class WorkOrderTypes
    {
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(
                new[]
                {
                    Pair(Standard, Messages.WOTypeStandard),
                    Pair(Template, Messages.WOTypeTemplate),
                })
            { }
        }

        public const string Standard = "S";
        public const string Template = "T";

        public class standard : PX.Data.BQL.BqlString.Constant<standard>
        {
            public standard() : base(Standard) { }
        }

        public class template : PX.Data.BQL.BqlString.Constant<template>
        {
            public template() : base(Template) { }
        }
    }
    #endregion
}
