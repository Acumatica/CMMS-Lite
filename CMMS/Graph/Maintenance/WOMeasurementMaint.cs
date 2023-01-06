using PX.Data;
using PX.Data.BQL.Fluent;

namespace CMMS
{
    public class WOMeasurementMaint : PXGraph<WOMeasurementMaint>
    {
        public PXCancel<WOMeasurement> Cancel;
        public PXSave<WOMeasurement>   Save;
            [PXViewName(Messages.ViewMeasurements)]
        public SelectFrom<WOMeasurement>.View Measurements;
    }
}
