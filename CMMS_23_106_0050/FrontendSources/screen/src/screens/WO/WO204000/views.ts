import {
BaseViewModel, PXFieldState, commitChanges, headerDescription
} from "client-controls";


export class WOEquipment extends BaseViewModel {
    EquipmentID: PXFieldState;
    @commitChanges EquipmentCD: PXFieldState;
    EquipmentType : PXFieldState;
    @commitChanges @headerDescription Descr: PXFieldState;
    SerialNbr: PXFieldState;
    @commitChanges Status: PXFieldState;
    BranchID: PXFieldState;
    DepartmentID: PXFieldState;
    AssetID: PXFieldState;
    PhysicalLocation: PXFieldState;
    DateInstalled: PXFieldState;
    Criticality: PXFieldState;
    InventoryID: PXFieldState;
    SMEquipmentID: PXFieldState;
    AMMachID: PXFieldState;
    EPEquipmentID: PXFieldState;
}

export class WOEquipmentBOM extends BaseViewModel {
    EquipmentID: PXFieldState;
    @commitChanges InventoryID: PXFieldState;
    InventoryItem__Descr: PXFieldState;
    @commitChanges Quantity: PXFieldState;
    @commitChanges Criticality: PXFieldState;
}

export class WOSchedule extends BaseViewModel {
    EquipmentID: PXFieldState;
    @commitChanges WorkOrderID: PXFieldState;
    @commitChanges WOOrder__Descr: PXFieldState;
    @commitChanges FrequencyDays: PXFieldState;
    @commitChanges LeadTimeDays: PXFieldState;
    @commitChanges LastWODate: PXFieldState;
    @commitChanges NextWODate: PXFieldState;
}

export class WOOrder extends BaseViewModel {
    WorkOrderID: PXFieldState;
    WorkOrderType: PXFieldState;
    WorkOrderCD: PXFieldState;
    WOClassID: PXFieldState;
    OrigWorkOrderID: PXFieldState;
    TemplateID: PXFieldState;
    Status: PXFieldState;
    BranchID: PXFieldState;
    Priority: PXFieldState;
    LastLineNbr: PXFieldState;
    EquipmentID: PXFieldState;
    Descr: PXFieldState;
    OwnerID: PXFieldState;
    WorkGroupID: PXFieldState;
    Hold: PXFieldState;
    RequestDate: PXFieldState;
    ScheduleDate: PXFieldState;
    RequestApproval: PXFieldState;
    Approved: PXFieldState;
}

export class WOEquipmentFM extends BaseViewModel {
    EquipmentID: PXFieldState;
    @commitChanges FailureModeID: PXFieldState;
    WOFailureMode__Descr: PXFieldState;
    IsMitigated: PXFieldState;
    MitigationDescription: PXFieldState;
}

export class WOSetup extends BaseViewModel {
    WONumberingID: PXFieldState;
    EquipNumberingID: PXFieldState;
    TemplateWorkOrderNumberingID: PXFieldState;
    WORequestApproval: PXFieldState;
    CreatedByID: PXFieldState;
    CreatedByScreenID: PXFieldState;
    CreatedDateTime: PXFieldState;
    LastModifiedByID: PXFieldState;
    LastModifiedByScreenID: PXFieldState;
    LastModifiedDateTime: PXFieldState;
    tstamp: PXFieldState;
    NoteID: PXFieldState;
}
