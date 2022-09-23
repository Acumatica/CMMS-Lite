using Customization;
using PX.Data;
using PX.Objects.CN.Common.Descriptor;
using PX.Objects.CS;
using System;
using System.Drawing;
using System.Linq;

namespace CMMS
{
    public static class WOCustomTypeNumberingHandler
    {
		// This method is executed after the customization was published and the website was restarted
		// It checks if the Numbering Sequence 'WORKORDID' exists, if not then it inserts them.
		public static void UpdateDatabase(CustomizationPlugin plugin)
		{
			plugin.WriteLog($"Work Order Numbering Handler running on Company \"{PXDatabase.Provider.GetCompanyDisplayName()}\"");

			Numbering numbering = PXDatabase.SelectRecords<Numbering>(new PXDataFieldValue<Numbering.numberingID>(CMMSlite.WO.Messages.CustomWorkSequence, PXComp.EQ)).FirstOrDefault();

			if (numbering == null)
			{
				InsertNumberingAndSequence(plugin, CMMSlite.WO.Messages.CustomWorkSequence, CMMSlite.WO.Messages.CustomTypeDescr);
			}
		}

		private static void InsertNumberingAndSequence(CustomizationPlugin plugin, string numberingID, string description)
		{
			plugin.WriteLog($"Inserting {numberingID} Numbering Sequence");

			WODatabase.InsertWithAudit<Numbering>
			(
				true,
				"SM204505", //PXContext.GetScreenID() returns null
				new PXDataFieldAssign<Numbering.numberingID>(numberingID),
				new PXDataFieldAssign<Numbering.descr>(description),
				new PXDataFieldAssign<Numbering.userNumbering>(false),
				new PXDataFieldAssign<Numbering.newSymbol>(Constants.NumberingSequence.NewSymbol)
			);

			WODatabase.InsertWithAudit<NumberingSequence>
			(
				false,
				"SM204505", //PXContext.GetScreenID() returns null
				new PXDataFieldAssign<NumberingSequence.numberingID>(numberingID),
				new PXDataFieldAssign<NumberingSequence.startDate>(new DateTime(1900, 1, 1)),
				new PXDataFieldAssign<NumberingSequence.startNbr>("000"),
				new PXDataFieldAssign<NumberingSequence.endNbr>("999"),
				new PXDataFieldAssign<NumberingSequence.lastNbr>("000"),
				new PXDataFieldAssign<NumberingSequence.warnNbr>("989"),
				new PXDataFieldAssign<NumberingSequence.nbrStep>(1)
			);
		}
	}
}
