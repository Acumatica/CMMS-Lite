using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;

namespace CMMSlite.WO
{
    public class WOClassMaint : PXGraph<WOClassMaint, WOClass>
    {
        [PXViewName(Messages.ViewClasses)]
        public SelectFrom<WOClass>.View Classes;

        [PXViewName(PX.Objects.CR.Messages.Attributes)]
        public CSAttributeGroupList<WOClass.wOClassID, WOOrder> Mapping;

    }
}
