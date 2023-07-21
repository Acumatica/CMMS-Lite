import { autoinject } from 'aurelia-framework';
import {
	ScreenBaseViewModel, createCollection, graphInfo, commitChanges, BaseViewModel,
	PXFieldState
} from 'client-controls';

@graphInfo({ graphType: 'CMMS.WOMeasurementMaint', primaryView: 'Measurements' })
@autoinject
export class WO202000 extends ScreenBaseViewModel {
	Measurements = createCollection(WOMeasurement, {
		adjustPageSize: true, initNewRow: true, syncPosition: true,
		quickFilterFields: ['MeasurementCD'], mergeToolbarWith: "ScreenToolbar"
		// columnsSettings: [ { field: 'Active', allowCheckAll: true }, { field: 'CuryID', textAlign: TextAlign.Right } ]
		// columnsSettings: [ { field: 'Type', captionImage: 'control@LocalMenu' }]
	});
}

export class WOMeasurement extends BaseViewModel {
	@commitChanges MeasurementCD: PXFieldState;
	Descr: PXFieldState;
}

