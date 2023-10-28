import {
    BaseViewModel, PXFieldState, commitChanges, headerDescription
} from "client-controls";

export class WOOrder extends BaseViewModel {
    @commitChanges WorkOrderType: PXFieldState;
    @commitChanges WorkOrderCD: PXFieldState;
    @commitChanges WOClassID: PXFieldState;
    OrigWorkOrderID: PXFieldState;
    TemplateID: PXFieldState;
    Status: PXFieldState;
    BranchID: PXFieldState;
    Priority: PXFieldState;
    LastLineNbr: PXFieldState;
    EquipmentID: PXFieldState;
    Descr: PXFieldState;
    @commitChanges OwnerID: PXFieldState;
    @commitChanges WorkGroupID: PXFieldState;
    Hold: PXFieldState;
    @commitChanges RequestDate: PXFieldState;
    @commitChanges ScheduleDate: PXFieldState;
    RequestApproval: PXFieldState;
    Approved: PXFieldState;
}

export class WOLine extends BaseViewModel {
    Descr: PXFieldState;
    @commitChanges EquipmentID: PXFieldState;
    WOEquipment__Descr: PXFieldState;
}

export class WOLineItem extends BaseViewModel {
    @commitChanges InventoryID: PXFieldState;
    SubItemID: PXFieldState;
    InventoryItem__Descr: PXFieldState;
    Quantity: PXFieldState;
    InventoryItem__BaseUnit: PXFieldState;
}

export class WOLineLabor extends BaseViewModel {
    LaborType: PXFieldState;
    LaborHours: PXFieldState;
}

export class WOLineTool extends BaseViewModel {
    @commitChanges EquipmentID: PXFieldState;
    WOEquipment__Descr: PXFieldState;
    Quantity: PXFieldState;
    BaseUnit: PXFieldState;
}

export class WOLineMeasure extends BaseViewModel {
    @commitChanges MeasurementID: PXFieldState;
    WOMeasurement__Descr: PXFieldState;
    Value: PXFieldState;
}

export class WOLineFailure extends BaseViewModel {
    @commitChanges FailureModeID: PXFieldState;
    WOFailureMode__Descr: PXFieldState;
    Comment: PXFieldState;
}

export class CSAnswer extends BaseViewModel {
    AttributeID: PXFieldState;
    isRequired: PXFieldState;
    Value: PXFieldState;
}

export class WOApproval extends BaseViewModel {
    ApproverEmployee__AcctName: PXFieldState;
    ApproverEmployee__AcctCD: PXFieldState;
    ApprovedByEmployee__AcctName: PXFieldState;
    ApprovedByEmployee__AcctCD: PXFieldState;
    ApproveDate: PXFieldState;
    Status: PXFieldState;
    Reason: PXFieldState;
    WorkgroupID: PXFieldState;
}

export class WOOrder4 extends BaseViewModel {
    @commitChanges WorkOrderType: PXFieldState;
    @commitChanges WorkOrderCD: PXFieldState;
    @commitChanges WOClassID: PXFieldState;
    OrigWorkOrderID: PXFieldState;
    TemplateID: PXFieldState;
    Status: PXFieldState;
    BranchID: PXFieldState;
    Priority: PXFieldState;
    LastLineNbr: PXFieldState;
    EquipmentID: PXFieldState;
    Descr: PXFieldState;
    @commitChanges OwnerID: PXFieldState;
    @commitChanges WorkGroupID: PXFieldState;
    Hold: PXFieldState;
    @commitChanges RequestDate: PXFieldState;
    @commitChanges ScheduleDate: PXFieldState;
    RequestApproval: PXFieldState;
    Approved: PXFieldState;
}
