using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;
using PX.Web.UI;
using System;

namespace CMMS
{
    [Serializable]
    public class WOMeterMaint : PXGraph<WOMeterMaint, WOMeter>
    {
        #region Views
        [PXViewName(Messages.ViewMeter)]
        public SelectFrom<WOMeter>.View Meter;

        [PXViewName(Messages.ViewCurrentMeter)]
        public SelectFrom<WOMeter>
            .Where<WOMeter.meterID.IsEqual<WOMeter.meterID.FromCurrent>>
            .View CurrentMeter;

        public PXSetup<WOSetup> Setup;
        #endregion

        #region Const
        public WOMeterMaint()
        {
            WOSetup setup = Setup.Current;
        }
        #endregion

        #region Event Handlers
        #region WOMeter_RowSelected
        protected virtual void _(Events.RowSelected<WOMeter> e)
        {
            WOMeter row = e.Row;

            if(row != null)
            {
                bool showInt = false;
                //bool showDate = false;
                
                if(row.MeterType == MeterTypes.Miles) { showInt = true; }
                //if(row.MeterType == MeterTypes.Days) { showDate = true; }

                PXUIFieldAttribute.SetVisible<WOMeter.valueInt>(e.Cache, row, showInt);
            }
        }
        #endregion
        #endregion
    }
}
