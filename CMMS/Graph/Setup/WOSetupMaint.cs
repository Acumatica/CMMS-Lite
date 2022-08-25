using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Objects;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMSlite.WO
{
    public class WOSetupMaint : PXGraph<WOSetupMaint>
    {
        [PXViewName(Messages.ViewPreferences)]
        public SelectFrom<WOSetup>.View Preferences;

        [PXViewName(Messages.ViewSetupApproval)]
        public SelectFrom<WOSetupApproval>.View Approvals;

        public PXSave<WOSetup> Save;
        public PXCancel<WOSetup> Cancel;

    }
}
