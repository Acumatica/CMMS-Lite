import { autoinject } from 'aurelia-framework';
import {
	ScreenBaseViewModel, createCollection, graphInfo, commitChanges, BaseViewModel,
	PXFieldState
} from 'client-controls';

@graphInfo({ graphType: 'CMMS.WODocumentReleaseProc', primaryView: 'Records' })
@autoinject
export class WO501000 extends ScreenBaseViewModel
{
	Records = createCollection(WOSchedule);
		//adjustPageSize: true, initNewRow: true, syncPosition: true,
		//quickFilterFields: ['MeasurementCD', 'Descr'], mergeToolbarWith: "ScreenToolbar"  //experiment with mergeToolbarWith
		// columnsSettings: [ { field: 'Active', allowCheckAll: true }, { field: 'CuryID', textAlign: TextAlign.Right } ]
		// columnsSettings: [ { field: 'Type', captionImage: 'control@LocalMenu' }]
	//});
}

export class WOSchedule extends BaseViewModel {
	EquipmentID: PXFieldState;	
	WorkOrderID: PXFieldState;
	LastWODate: PXFieldState;
	NextWODate: PXFieldState;
}

