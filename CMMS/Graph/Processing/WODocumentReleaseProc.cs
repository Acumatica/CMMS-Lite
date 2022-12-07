using PX.Data;
using System.Collections.Generic;

namespace CMMSlite.WO
{
    [PX.Objects.GL.TableAndChartDashboardType]
    public class WODocumentReleaseProc : PXGraph<WODocumentReleaseProc>
    {

        #region Views
        public PXCancel<WOOrder> Cancel;

        [PXFilterable]
        public PXProcessing<WOOrder, Where<WOOrder.status, Equal<WOOrder.Statuses.open>>> Records;

        #endregion

        #region Constructor
        public WODocumentReleaseProc()
        {
            Records.SetProcessDelegate(CreateDocumentsProc);
        }
        #endregion

        #region Methods

        private static void CreateDocumentsProc(List<WOOrder> records)
        {
            bool errorOccured = false;

            foreach (WOOrder record in records)
            {
                try
                {
                    PXProcessing<WOOrder>.SetCurrentItem(record);

                    //Processing logic

                    PXProcessing<WOOrder>.SetProcessed();
                }
                catch(PXException e)
                {
                    errorOccured = true;
                    PXProcessing<WOOrder>.SetError(PXException.PreserveStack(e));
                }
            }

            if(errorOccured)
            {
                PXProcessing<WOOrder>.SetCurrentItem(null);

                throw new PXException("Some records where processed with errors");
            }
        }
        #endregion

    }
}
