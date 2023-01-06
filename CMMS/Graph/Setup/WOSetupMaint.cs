using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMS
{
    public class WOSetupMaint : PXGraph<WOSetupMaint>
    {

        #region Buttons

        public PXSave<WOSetup> Save;
        public PXCancel<WOSetup> Cancel;

        #endregion

        #region Views

        [PXViewName(Messages.ViewPreferences)]
        public SelectFrom<WOSetup>.View Setup;

        [PXViewName(Messages.ViewSetupApproval)]
        public SelectFrom<WOSetupApproval>.View SetupApproval;

        #endregion

        #region Event Handlers
        protected virtual void _(Events.FieldUpdated<WOSetup, WOSetup.wORequestApproval> e)
        {
            foreach (WOSetupApproval setup in SetupApproval.Select())
            {
                setup.IsActive = e.Row.WORequestApproval;
                
                SetupApproval.Cache.Update(setup);
            }
        }
        #endregion

    }
}
