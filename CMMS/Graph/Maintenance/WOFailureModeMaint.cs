using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMSlite.WO
{
    public class WOFailureModeMaint : PXGraph<WOFailureModeMaint, WOFailureMode>
    {
        [PXViewName(Messages.ViewFailureModes)]
        public SelectFrom<WOFailureMode>.View FailureModes;
    }
}
