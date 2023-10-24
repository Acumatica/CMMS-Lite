import {
    BaseViewModel, PXFieldState, commitChanges, headerDescription
} from "client-controls";

export class WOOrder extends BaseViewModel {
    WorkOrderType: PXFieldState;
    @commitChanges WorkOrderCD: PXFieldState;
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

export class WOLine extends BaseViewModel {
    Descr: PXFieldState;
}

export class WOLineItem extends BaseViewModel {
    InventoryID: PXFieldState;
}

export class WOLineLabor extends BaseViewModel {
    LaborType: PXFieldState;
    LaborHours: PXFieldState;
}

export class WOLineTool extends BaseViewModel {
    EquipmentID: PXFieldState;
}

export class WOLineMeasure extends BaseViewModel {
    MeasurementID: PXFieldState;
}

export class WOLineFailure extends BaseViewModel {
    FailureModeID: PXFieldState;
}

export class WOSchedule extends BaseViewModel {
    WorkOrderID: PXFieldState;
}
