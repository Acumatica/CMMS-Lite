using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMS
{
    public class WOFailureModeMaint : PXGraph<WOFailureModeMaint>
    {
        public PXCancel<WOFailureMode> Cancel;
        public PXSave<WOFailureMode> Save;
        [PXViewName(Messages.ViewFailureModes)]
        public SelectFrom<WOFailureMode>.View FailureModes;
    }
}