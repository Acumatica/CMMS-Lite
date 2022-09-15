using PX.Data;
using System.Collections.Generic;
using System.Linq;
using EP = PX.Objects.EP;

namespace CMMSlite.WO
{
    public class EPApprovalMapMaint_Extension : PXGraphExtension<EP.EPApprovalMapMaint>
    {
        public static bool IsActive() => true;

        #region Override GetEntityTypeScreens - Enable Approval Maps for New Screens
        public delegate IEnumerable<string> GetEntityTypeScreensDelegate();
        [PXOverride]
        public IEnumerable<string> GetEntityTypeScreens(GetEntityTypeScreensDelegate baseMethod)
        {
            IEnumerable<string> entities = baseMethod();
            List<string> list = new List<string>();

            foreach (string s in entities)
            {
                list.Add(s);
            }
            list.Add("WO301000"); // Work Order Entry

            return list;

        }
        #endregion

        #region EPRule_RowSelected - Override to Enable Approve/Reject Reasons for New Graphs 
        protected virtual void EPRule_RowSelected(PXCache sender, PXRowSelectedEventArgs e, PXRowSelected baseEvent)
        {
            // baseEvent will disable visibility of reason fields unless setup in Standard Acumatica
            baseEvent.Invoke(sender, e);

            EP.EPRule row = e.Row as EP.EPRule;
            if (row == null)
                return;

            // Add custom screens that should toggle the reason fields to visible
            bool isSupportedCustomType = new List<string>()
            {
                typeof(WOOrderEntry).FullName,
            }.Contains(Base.AssigmentMap.Current?.GraphType, new PX.Data.CompareIgnoreCase());

            if (isSupportedCustomType)
            {
                PXUIFieldAttribute.SetVisible<EP.EPRule.reasonForApprove>(Base.Nodes.Cache, Base.Nodes.Current, isSupportedCustomType && row.StepID != null);
                PXUIFieldAttribute.SetVisible<EP.EPRule.reasonForReject>(Base.Nodes.Cache, Base.Nodes.Current, isSupportedCustomType && row.StepID != null);
            }
        }
        #endregion

    }
}