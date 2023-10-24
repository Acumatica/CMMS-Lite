import { autoinject } from 'aurelia-framework';
import {
	ScreenBaseViewModel, createInstance, createCollection, graphInfo, commitChanges, BaseViewModel,
	PXFieldState
} from 'client-controls';

@graphInfo({ graphType: 'CMMS.WOClassMaint', primaryView: 'Classes' })
@autoinject
export class WO201000 extends ScreenBaseViewModel {
	Classes = createInstance(WOClass);
	Mapping = createCollection(CSAttributeGroup)
}

export class WOClass extends BaseViewModel {
	@commitChanges WOClassID: PXFieldState;
	Descr: PXFieldState;
}

export class CSAttributeGroup extends BaseViewModel {
	@commitChanges AttributeID: PXFieldState;
	Description: PXFieldState;
	SortOrder: PXFieldState;
	Required: PXFieldState;
	IsInternal: PXFieldState;
	ControlType: PXFieldState;
	DefaultValue: PXFieldState;
}

