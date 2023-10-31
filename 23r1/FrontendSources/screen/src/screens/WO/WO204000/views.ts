import {
BaseViewModel, PXFieldState, commitChanges, headerDescription
} from "client-controls";


export class WOEquipment extends BaseViewModel {
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
    @commitChanges InventoryID: PXFieldState;
    InventoryItem__Descr: PXFieldState;
    @commitChanges Quantity: PXFieldState;
    @commitChanges Criticality: PXFieldState;
}

export class WOSchedule extends BaseViewModel {
    @commitChanges WorkOrderID: PXFieldState;
    WOOrder__Descr: PXFieldState;
    @commitChanges FrequencyDays: PXFieldState;
    @commitChanges LeadTimeDays: PXFieldState;
    @commitChanges LastWODate: PXFieldState;
    @commitChanges NextWODate: PXFieldState;
}

export class WOOrder extends BaseViewModel {
    ScheduleDate: PXFieldState;
    WorkOrderType: PXFieldState;
    WorkOrderCD: PXFieldState;
    WOClassID: PXFieldState;
    Descr: PXFieldState;
    Status: PXFieldState;
    Priority: PXFieldState;
}

export class WOEquipmentFM extends BaseViewModel {
    @commitChanges FailureModeID: PXFieldState;
    WOFailureMode__Descr: PXFieldState;
    IsMitigated: PXFieldState;
    MitigationDescription: PXFieldState;
}
