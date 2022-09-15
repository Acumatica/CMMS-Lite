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
        public PXSave<WOSetup> Save;
        public PXCancel<WOSetup> Cancel;

        [PXViewName(Messages.ViewPreferences)]
        public SelectFrom<WOSetup>.View Preferences;

        [PXViewName(Messages.ViewSetupApproval)]
        public SelectFrom<WOSetupApproval>.View SetupApproval;

        #region Event Handlers
        protected virtual void _(Events.FieldUpdated<WOSetup.wORequestApproval> e)
        {
            PXCache cache = this.Caches[typeof(WOSetupApproval)];
            foreach (WOSetupApproval setup in PXSelect<WOSetupApproval>.Select(this))
            {
                setup.IsActive = (bool?)e.NewValue;
                cache.Update(setup);
            }
        }
        #endregion

    }
}
