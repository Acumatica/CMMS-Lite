using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMSlite.WO
{
    public class WOClassMaint : PXGraph<WOClassMaint, WOClass>
    {
        [PXViewName(Messages.ViewClasses)]
        public SelectFrom<WOClass>.View Classes;
    }
}
