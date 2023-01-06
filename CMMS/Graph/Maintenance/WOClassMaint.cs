using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.Descriptor;
using PX.Objects.CR;
using CS = PX.Objects.CS;

namespace CMMS
{
    public class WOClassMaint : PXGraph<WOClassMaint, WOClass>
    {
        [PXViewName(Messages.ViewClasses)]
        public SelectFrom<WOClass>.View Classes;

        [PXViewName(PX.Objects.CR.Messages.Attributes)]
        public CSAttributeGroupList<WOClass.wOClassID, WOOrder> Mapping;

    }
}
