import {
	ScreenBaseViewModel,
	createInstance,
	createCollection,
	graphInfo,
	localizable
} from 'client-controls';

import {
	WOEquipment,
	WOEquipmentBOM,
	WOEquipmentFM,
	WOOrder,
	WOSchedule,
	WOSetup
} from './views';

@localizable
class TabHeaders {
	static General = "General";
	static BOM = "BOM";
	static Schedules = "Schedules";
	static WOHistory = "Work Order History";
	static FailureModes = "Failure Modes";
}

@graphInfo({ graphType: 'CMMS.WOEquipmentMaint', primaryView: 'Equipment' })
export class WO204000 extends ScreenBaseViewModel {
	TabHeaders = TabHeaders;

	Equipment = createInstance(WOEquipment);
	CurrentEquipment = createInstance(WOEquipment);
	Setup = createInstance(WOSetup);

	FailureModes = createCollection(WOEquipmentFM, {
		initNewRow: true,
		syncPosition: true
	});

	Schedules = createCollection(WOOrder, {
		initNewRow: true,
		syncPosition: true
	});

	WorkOrders = createCollection(WOSchedule, {
		initNewRow: true,
		syncPosition: true,
		columnsSettings: [
			{
				field: "WorkOrderCD",
				linkCommand: "WorkOrders"
			}
		]

	});

	BOM = createCollection(WOEquipmentBOM, {
		initNewRow: true,
		syncPosition: true
	});

}

