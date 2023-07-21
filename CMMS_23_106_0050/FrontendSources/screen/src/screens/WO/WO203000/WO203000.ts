import { autoinject } from 'aurelia-framework';
import {
	ScreenBaseViewModel, createCollection, graphInfo, commitChanges, BaseViewModel,
	PXFieldState
} from 'client-controls';

@graphInfo({ graphType: 'CMMS.WOFailureModeMaint', primaryView: 'FailureModes' })
@autoinject
export class WO203000 extends ScreenBaseViewModel {
	FailureModes = createCollection(WOFailureMode, {
		adjustPageSize: true, initNewRow: true, syncPosition: true,
		quickFilterFields: ['FailureModeCD'], mergeToolbarWith: "ScreenToolbar"
		// columnsSettings: [ { field: 'Active', allowCheckAll: true }, { field: 'CuryID', textAlign: TextAlign.Right } ]
		// columnsSettings: [ { field: 'Type', captionImage: 'control@LocalMenu' }]
	});
}

export class WOFailureMode extends BaseViewModel {
	@commitChanges FailureModeCD: PXFieldState;
	Descr: PXFieldState;
}

