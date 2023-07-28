import { autoinject } from 'aurelia-framework';
import {
	ScreenBaseViewModel, createInstance, createCollection, graphInfo, BaseViewModel,
	PXFieldState
} from 'client-controls';

@graphInfo({ graphType: 'CMMS.WOSetupMaint', primaryView: 'Setup' })
@autoinject
export class WO101000 extends ScreenBaseViewModel {
	Setup = createInstance(WOSetup);

	SetupApproval = createCollection(WOSetupApproval, {
		adjustPageSize: true, initNewRow: true, syncPosition: true,
		mergeToolbarWith: "ScreenToolbar"
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

