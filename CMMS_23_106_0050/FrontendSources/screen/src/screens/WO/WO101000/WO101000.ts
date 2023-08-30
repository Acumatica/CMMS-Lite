import {
	ScreenBaseViewModel,
	createInstance,
	createCollection,
	graphInfo,
	BaseViewModel,
	PXFieldState,
	localizable
} from 'client-controls';

@localizable
class TabHeaders {
	static Details = "Details";
	static ApprovalMaps = "Approval";
}

@graphInfo({ graphType: 'CMMS.WOSetupMaint', primaryView: 'Setup' })
export class WO101000 extends ScreenBaseViewModel {
	TabHeaders = TabHeaders;

	Setup = createInstance(WOSetup);

	SetupApproval = createCollection(WOSetupApproval, {
		initNewRow: true,
		syncPosition: true
	});
}

export class WOSetup extends BaseViewModel {
	WorkOrderNumberingID: PXFieldState;
	TemplateWorkOrderNumberingID: PXFieldState;
	EquipNumberingID: PXFieldState;
	WORequestApproval: PXFieldState;
}

export class WOSetupApproval extends BaseViewModel {
	AssignmentMapID: PXFieldState;
	AssignmentNotificationID: PXFieldState;
	IsActive: PXFieldState;
}

