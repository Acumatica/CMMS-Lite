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
	WOLineItem,
	WOLineLabor,
	WOLineTool,
	WOLineMeasure,
	WOLineFailure,
	CSAnswer,
	WOApproval,
	WOOrder4
} from './views';

@localizable
class TabHeaders {
	static Details = "Details";
	static Operations = "Operations";
	static Labor = "Labor";
	static Materials = "Materials";
	static Tools = "Tools";
	static Measurements = "Measurements";
	static FailureModes = "Failure Modes";
	static Attributes = "Attributes";
	static Approvals = "Approvals";
	static RelatedWO = "Related Work Orders";
}

@graphInfo({ graphType: 'CMMS.WOOrderEntry', primaryView: 'Document' })
export class WO301000 extends ScreenBaseViewModel {
	TabHeaders = TabHeaders;

	Document = createInstance(WOOrder);
	CurrentDocument = createInstance(WOOrder);

	Transactions = createCollection(WOLine, {
		initNewRow: true,
		syncPosition: true
	});



	LineItems = createCollection(WOLineItem, {
		initNewRow: true,
		syncPosition: true
	});

	LineLabor = createCollection(WOLineLabor, {
		initNewRow: true,
		syncPosition: true
	});

	LineTools = createCollection(WOLineTool, {
		initNewRow: true,
		syncPosition: true
	});

	LineMeasurements = createCollection(WOLineMeasure, {
		initNewRow: true,
		syncPosition: true
	});

	LineFailureModes = createCollection(WOLineFailure, {
		initNewRow: true,
		syncPosition: true
	});



	Answers = createCollection(CSAnswer);

	Approval = createCollection(
		WOApproval,
		{
			allowInsert: false,
			allowUpdate: false,
			allowDelete: false,
			columnsSettings: [
				{ field: "Status", allowUpdate: false },
				{ field: "Reason", allowUpdate: false },
			],
		}
	);

	RelatedWO = createCollection(WOOrder4);

}

