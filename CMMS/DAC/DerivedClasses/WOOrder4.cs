using PX.Data;
using PX.Data.BQL;
using System;

namespace CMMS
{
    [Serializable]
    [PXHidden]
    public class WOOrder4 : WOOrder
    {
        #region WorkOrderType
        public new abstract class workOrderType : BqlString.Field<workOrderType>
        {
        }
        #endregion

        #region WorkerOrderID
        public new abstract class workOrderID : BqlInt.Field<workOrderID>
        {
        }
        #endregion

        #region WorkerOrderID
        public new abstract class origWorkOrderID : BqlInt.Field<origWorkOrderID>
        {
        }
        #endregion
    }
}
