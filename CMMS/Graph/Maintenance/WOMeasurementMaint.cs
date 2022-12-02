using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMSlite.WO
{
    public class WOMeasurementMaint : PXGraph<WOMeasurementMaint, WOMeasurement>
    {
        [PXViewName(Messages.ViewMeasurements)]
        public SelectFrom<WOMeasurement>.View Measurements;
    }
}
