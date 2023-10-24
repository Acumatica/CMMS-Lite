import {
	ScreenBaseViewModel,
	ActionState,
	createInstance,
	createCollection,
	graphInfo,
	localizable
} from 'client-controls';

import {
	WOOrder,
	WOLine,
	//WOLineItem,
	//WOLineLabor,
	//WOLineTool,
	//WOLineMeasure,
	//WOLineFailure,
	WOSchedule
} from './views';

@localizable
class TabHeaders {
	static Details = "Details";
}

@graphInfo({ graphType: 'CMMS.WOOrderEntry', primaryView: 'Document' })
export class WO301000 extends ScreenBaseViewModel {
	TabHeaders = TabHeaders;

	Document = createInstance(WOOrder);
	CurrentDocument = createInstance(WOOrder);


}

