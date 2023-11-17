using System;
using PX.Common;
using PX.Data;

namespace CMMS
{
    [PXLocalizable(Messages.Prefix)]
    public static class Messages
    {
        public const string Prefix = "WO Error";

        #region Setup
        public const string CustomWorkSequence         = "WORKORDID";
        public const string TemplateCustomWorkSequence = "TMWRKORDID";
        public const string EquipmentNumberingID       = "WOEQUIPID";
        public const string MeterNumberingID           = "WOMETERID";
        
        public const string CustomTypeDescr         = "Sequence for Work Orders. **DO NOT ALTER**";
        public const string TemplateCustomTypeDescr = "Sequence for Template Work Orders. **DO NOT ALTER**";
        public const string EquipmentNumberingDescr = "Sequence for Equipment. **DO NOT ALTER**";
        public const string MeterNumberingDescr     = "Sequence for Meters. **DO NOT ALTER**";
        #endregion

        #region View Names
        public const string ViewDocument = "Work Orders";
        public const string ViewCurrentDocument = "Current Work Order";
        public const string ViewTransactions = "Work Order Lines";
        public const string ViewWOLineLabor = "WO Line Labor";
        public const string ViewWOLineItems = "WO Line Items";
        public const string ViewWOLineTools = "WO Line Tools";
        public const string ViewWOLineMeasurements = "WO Line Measurements";
        public const string ViewWOLineFailureModes = "WO Line Failure Modes";
        public const string ViewWORelatedWO = "Related Work Orders";
        public const string ViewApproval = "Approval";
        public const string ViewMapping = "Mapping";
        public const string ViewPreferences = "Preferences";
        public const string ViewSetupApproval = "Setup Approval";
        public const string ViewClasses = "Work Order Classes";
        public const string ViewMeasurements = "Measurements";
        public const string ViewFailureModes = "Failure Modes";
        public const string ViewEquipment = "Equipment";
        public const string ViewCurrentEquipment = "Current Equipment";
        public const string ViewSchedules = "Schedules";
        public const string ViewWorkOrders = "Work Orders";
        public const string ViewBOM = "Equipment Components";
        public const string ViewMeter = "Meter";
        public const string ViewCurrentMeter = "CurrentMeter";
        #endregion

        #region DAC Names
        public const string DACWOClass = "Work Order Class";
        public const string DACWOEquipment = "Work Order Equipment";
        public const string DACWOEquipmentBOM = "Equipment Bill of Materials";
        public const string DACWOEquipmentFM = "Equipment Failure Mode";
        public const string DACWOFailureMode = "Failure Mode";
        public const string DACWOLine = "Work Order Line";
        public const string DACWOLineFailureMode = "Work Order Line Failure Mode";
        public const string DACWOLineItem = "Work Order Line Item";
        public const string DACWOLineLabor = "Work Order Line Labor";
        public const string DACWOLineMeasurement = "Work Order Line Measurement";
        public const string DACWOLineTool = "Work Order Line Tool";
        public const string DACWOMeasurement = "Measurement";
        public const string DACWOMeter = "Meter";
        public const string DACWOOrder = "Work Order";
        public const string DACWOSchedule = "Equipment Schedule";
        public const string DACWOSetup = "Work Order Setup";
        public const string DACWOSetupApproval = "Work Order Setup Approval";
        #endregion

        #region Field Names
        public const string FieldNumberingID         = "WO Numbering ID";
        public const string TemplateFieldNumberingID = "Template WO Numbering ID";
        public const string FieldEquipNumberingID    = "Equipment Numbering ID";
        public const string FieldMeterNumberingID    = "Meter Numbering ID";
        public const string FieldHold                = "Hold";
        public const string FieldStatus              = "Status";
        public const string FieldDescr               = "Description";
        public const string FieldWOLineDescr         = "Instruction";
        public const string FieldInventoryID         = "Inventory ID";

        public const string FieldWorkOrderID = "Work Order ID";
        public const string FieldWorkOrderType = "Work Order Type";
        public const string FieldWOClassID = "Work Order Class";
        public const string FieldWOClass = "Class";
        public const string FieldBranchID = "Branch";
        public const string FieldPriority = "Priority";
        public const string FieldOrigWorkOrderID = "Related Work Order ID";
        public const string FieldTemplateID = "Template ID";
        public const string FieldEquipmentID = "Equipment ID";
        public const string FieldMachineID = "Machine ID";
        public const string FieldRequestDate = "Requested";
        public const string FieldScheduleDate = "Scheduled";
        public const string FieldOwnerID = "Owner";
        public const string FieldWorkGroupID = "Work Group";

        public const string FieldRequestApproval = "Approval Required";
        public const string FieldCreatedDateTime = "Created";
        public const string FieldLastModifiedDateTime = "Modified";

        public const string FieldApprovalID = "Approval ID";
        public const string FieldAssignmentMapID = "Approval Map";
        public const string FieldAssignmentNotificationID = "Pending Approval Notification";
        public const string FieldIsActive = "Active";

        public const string FieldEquipmentType = "Equipment Type";
        public const string FieldSerialNbr = "Serial Nbr.";
        public const string FieldDepartment = "Department";
        public const string FieldAssetID = "Asset ID";
        public const string FieldPhysicalLocation = "Physical Location";
        public const string FieldDateInstalled = "Date Installed";
        public const string FieldCriticality = "Criticality";
        public const string FieldSMEquipmentID = "FS Equipment ID";
        public const string FieldAMMachID = "Mfg Machine ID";
        public const string FieldEPEquipmentID = "Proj Equipment ID";

        public const string FieldFrequencyDays = "Frequency (Days)";
        public const string FieldLeadTimeDays = "Lead Time (Days)";
        public const string FieldLastWODate = "Last Completed Date";
        public const string FieldNextWODate = "Next Scheduled Date";

        public const string FieldFailureModeID = "Failure Mode";
        public const string FieldQuantity = "Qty.";

        public const string FieldLaborType = "Labor Type";
        public const string FieldLaborHours = "Hours";
        
        public const string FieldBaseUnit = "Base Unit";
        public const string FieldComment = "Comment";
        public const string FieldMeasurementID = "Measurement";
        public const string FieldValue = "Value";

        public const string IsMitigated = "Is Mitigated";
        public const string MitigationDescription = "Mitigation Description";
        
        public const string FieldWOMeterID         = "Meter ID";
        public const string FieldMeterType         = "Meter Type";
        public const string FieldFrequencyUnitsInt = "Frequency (Int)";
        public const string FieldLeadUnitsInt      = "Lead (Int)";
        public const string FieldLastValueInt      = "Last (Int)";
        public const string FieldNextValueInt      = "Next (Int)";

        public const string FieldLastValueDate = "Last Date";
        public const string FieldNextValueDate = "Next Date";
        #endregion

        #region Work Order Statuses
        public const string WOStatusInitialState = "Intial";
        public const string WOStatusHold = "Hold";
        public const string WOStatusPendingApproval = "Pending Approval";
        public const string WOStatusApproved = "Approved";
        public const string WOStatusRejected = "Rejected";
        public const string WOStatusPendingSchedule = "Pending Schedule";
        public const string WOStatusScheduled = "Scheduled";
        public const string WOStatusOpen = "Open";
        public const string WOStatusComplete = "Complete";
        #endregion

        #region Work Order Priorities
        public const string WOPriorityCritical = "Critical";
        public const string WOPrioritySevere = "Severe";
        public const string WOPriorityUrgent = "Urgent";
        public const string WOPriorityNormal = "Normal";
        public const string WOPriorityLow = "Low";
        #endregion

        #region Work Order Types
        public const string WOTypeStandard = "Standard";
        public const string WOTypeTemplate = "Template";
        #endregion

        #region Equipment Statuses
        public const string EquipStatusPlanned = "Planned";
        public const string EquipStatusActive = "Active";
        public const string EquipStatusDecomissioned = "Decomissioned";
        #endregion

        #region Equipment Types
        public const string EquipTypeMachine = "Machine";
        public const string EquipTypeComponent = "Component";
        public const string EquipTypeTool = "Tool";
        public const string EquipTypeOther = "Other";
        #endregion

        #region Labor Types
        public const string LaborTypeGeneral = "General Technician";
        public const string LaborTypeElectrical = "Electrical";
        public const string LaborTypeMechanical = "Mechanical";
        public const string LaborTypePlumbing = "Plumbing";
        public const string LaborTypeJanitorial = "Janitorial";
        public const string LaborTypeOther = "Other";
        #endregion

        #region Meter Types
        public const string MeterTypeDays = "Days";
        public const string MeterTypeMiles = "Miles";
        #endregion

        #region Equipment Criticality
        public const string EquipCritA = "A";
        public const string EquipCritB = "B";
        public const string EquipCritC = "C";
        public const string EquipCritD = "D";
        public const string EquipCritE = "E";
        #endregion

        #region Component Criticality
        public const  string CompCritA               = "A";
        public const  string CompCritB               = "B";
        public const  string CompCritC               = "C";
        public const  string CompCritD               = "D";
        public const  string CompCritE               = "E";


        #endregion

        #region Errors
        public const string ErrorProcessedWithErrors = "Some records where processed with errors";
        #endregion

        #region GetLocal
        public static string GetLocal(string message)
        {
            return PXLocalizer.Localize(message, typeof(Messages).FullName);
        }
        #endregion
    }
}
