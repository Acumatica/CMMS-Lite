using PX.Data;
using PX.Data.BQL;
using System;

namespace CMMS
{
    [Serializable]
    [PXHidden]
    public class WOOrder3 : WOOrder
    {
        #region WorkOrderType
        public new abstract class workOrderType : BqlString.Field<workOrderType>
        {
        }
        #endregion

        #region WorkerOrderID
        public new abstract class workOrderID : BqlString.Field<workOrderID>
        {
        }
        #endregion
    }
}
