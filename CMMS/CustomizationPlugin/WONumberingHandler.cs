using Customization;
using PX.Data;
using PX.Objects.CN.Common.Descriptor;
using PX.Objects.CS;
using System;
using System.Drawing;
using System.Linq;

namespace CMMS
{
    public static class WONumberingHandler
    {
		// This method is executed after the customization was published and the website was restarted
		// It checks if the Numbering Sequence 'WORKORDID' exists, if not then it inserts them.
		public static void UpdateDatabase(CustomizationPlugin plugin)
		{
			plugin.WriteLog($"Work Order Numbering Handler running on Company \"{PXDatabase.Provider.GetCompanyDisplayName()}\"");

			Numbering numbering = PXDatabase.SelectRecords<Numbering>(new PXDataFieldValue<Numbering.numberingID>(Messages.CustomWorkSequence, PXComp.EQ)).FirstOrDefault();

			if (numbering == null)
			{
				InsertNumberingAndSequence(plugin, Messages.CustomWorkSequence, Messages.CustomTypeDescr);
				InsertNumberingAndSequence(plugin, Messages.TemplateCustomWorkSequence, Messages.TemplateCustomTypeDescr);
				InsertNumberingAndSequence(plugin, Messages.EquipmentNumberingID, Messages.EquipmentNumberingDescr);

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
				new PXDataFieldAssign<NumberingSequence.startNbr>("WO000000"),
				new PXDataFieldAssign<NumberingSequence.endNbr>("WO999999"),
				new PXDataFieldAssign<NumberingSequence.lastNbr>("WO000000"),
				new PXDataFieldAssign<NumberingSequence.warnNbr>("WO999899"),
				new PXDataFieldAssign<NumberingSequence.nbrStep>(1)
			);
		}
	}
}
