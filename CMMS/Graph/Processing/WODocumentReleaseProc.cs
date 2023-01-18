using PX.Data;
using PX.Data.Maintenance.SM.DAC;
using System.Collections.Generic;

namespace CMMS
{
    [PX.Objects.GL.TableAndChartDashboardType]
    public class WODocumentReleaseProc : PXGraph<WODocumentReleaseProc>
    {

        #region Views
        public PXSetup<WOSetup> WOSetup;

        public PXCancel<WOSchedule> Cancel;

        [PXFilterable]
        public PXProcessingJoin<WOSchedule, 
            InnerJoin<WOOrder, On<WOOrder.workOrderType, Equal<WorkOrderTypes.template>, And<WOOrder.workOrderID, Equal<WOSchedule.workOrderID>>>>,
            // Need to pick up schedules that do not show a next WO Date in addition to those with a date now due
            Where2<
                Where2<
                    Where<WOSchedule.lastWODate, IsNull, 
                        And<WOSchedule.frequencyDays, IsNotNull, 
                            And<WOSchedule.frequencyDays, Greater<Zero>>>>, 
                    Or<Where<WOSchedule.nextWODate, LessEqual<Current<AccessInfo.businessDate>>>>>,
                And<Where<
                    NotExists<Select<
                        WOOrder,
                            Where<WOOrder.workOrderType, Equal<WorkOrderTypes.standard>,
                            And<WOOrder.equipmentID, Equal<WOSchedule.equipmentID>,
                            And<WOOrder.templateID, Equal<WOSchedule.workOrderID>,
                            And<WOOrder.status, NotIn3<WOOrder.Statuses.rejected, WOOrder.Statuses.complete>>>>>>>>>>>
            Records; // WOSchedule records should be for Type: Template work orders already

        #endregion

        #region Constructor
        public WODocumentReleaseProc()
        {
            WOSetup setup = WOSetup.Current;
            PXUIFieldAttribute.SetEnabled(Records.Cache, null, false);
            PXUIFieldAttribute.SetEnabled<WOSchedule.selected>(Records.Cache, null, true);

            Records.SetProcessDelegate(CreateDocumentsProc);
        }
        #endregion

        #region Methods

        private static void CreateDocumentsProc(List<WOSchedule> records)
        {
            WOOrder template, newOrder;

            bool errorOccured = false;

            WOOrderEntry graph = PXGraph.CreateInstance<WOOrderEntry>();

            foreach (WOSchedule record in records)
            {
                try
                {
                    PXProcessing<WOSchedule>.SetCurrentItem(record);

                    template = graph.Document.Search<WOOrder.workOrderID>(record.WorkOrderID);

                    if (template != null)
                    {
                        newOrder = graph.Document.Insert();

                        newOrder.EquipmentID = record.EquipmentID;  // The equipment holding the schedule
                        newOrder.TemplateID = template.WorkOrderID; // The PM work order that is attached to the equipment
                        newOrder.WOClassID = template.WOClassID;

                        newOrder = graph.Document.Update(newOrder);

                        //Grid records from template copied to standard
                        WOLine newLine;
                        WOLineLabor newLabor;
                        WOLineItem newLineItem;
                        WOLineTool newLineTool;
                        WOLineMeasure newLineMeasure;
                        //WOLineFailure newLineFailure;

                        foreach (WOLine line in PXSelectReadonly<WOLine, Where<WOLine.workOrderID, Equal<Required<WOLine.workOrderID>>>>.Select(graph, record.WorkOrderID))
                        {
                            newLine = graph.Transactions.Insert
                                (
                                    new WOLine()
                                    {
                                        EquipmentID = line.EquipmentID,
                                        Descr = line.Descr
                                    }
                                );

                            foreach (WOLineLabor labor in PXSelectReadonly<WOLineLabor, Where<WOLineLabor.workOrderID, Equal<Required<WOLineLabor.workOrderID>>, And<WOLineLabor.wOLineNbr, Equal<Required<WOLineLabor.wOLineNbr>>>>>.Select(graph, line.WorkOrderID, line.LineNbr))
                            {
                                newLabor = graph.LineLabor.Insert
                                    (
                                        new WOLineLabor()
                                        {
                                            LaborType = labor.LaborType,
                                            LaborHours = labor.LaborHours
                                        }
                                    );
                            }

                            foreach (WOLineItem lineItem in PXSelectReadonly<WOLineItem, Where<WOLineItem.workOrderID, Equal<Required<WOLineItem.workOrderID>>, And<WOLineItem.wOLineNbr, Equal<Required<WOLineItem.wOLineNbr>>>>>.Select(graph, line.WorkOrderID, line.LineNbr))
                            {
                                newLineItem = graph.LineItems.Insert
                                    (
                                        new WOLineItem()
                                        {
                                            InventoryID = lineItem.InventoryID,
                                            Quantity = lineItem.Quantity,
                                            BaseUnit = lineItem.BaseUnit
                                        }
                                    );
                            }

                            foreach (WOLineTool lineTool in PXSelectReadonly<WOLineTool, Where<WOLineTool.workOrderID, Equal<Required<WOLineTool.workOrderID>>, And<WOLineTool.wOLineNbr, Equal<Required<WOLineTool.wOLineNbr>>>>>.Select(graph, line.WorkOrderID, line.LineNbr))
                            {
                                newLineTool = graph.LineTools.Insert
                                    (
                                        new WOLineTool()
                                        {
                                            EquipmentID = lineTool.EquipmentID,
                                            Quantity = lineTool.Quantity,
                                            BaseUnit = lineTool.BaseUnit
                                        }
                                    );
                            }

                            foreach (WOLineMeasure lineMeasure in PXSelectReadonly<WOLineMeasure, Where<WOLineMeasure.workOrderID, Equal<Required<WOLineMeasure.workOrderID>>, And<WOLineMeasure.wOLineNbr, Equal<Required<WOLineMeasure.wOLineNbr>>>>>.Select(graph, line.WorkOrderID, line.LineNbr))
                            {
                                newLineMeasure = graph.LineMeasurements.Insert
                                    (
                                        new WOLineMeasure()
                                        {
                                            MeasurementID = lineMeasure.MeasurementID,
                                            // Do not copy the measurement value - At the Work Order level, these are identified at the time of work by the maintenance technician
                                            //Value = lineMeasure.Value
                                            Value = null
                                        }
                                    );
                            }

                            // Do not copy Failure Modes - At the Work Order level, these are identified at the time of work by the maintenance technician
                            //foreach (WOLineFailure lineFailure in PXSelectReadonly<WOLineFailure, Where<WOLineFailure.workOrderID, Equal<Required<WOLineFailure.workOrderID>>, And<WOLineFailure.wOLineNbr, Equal<Required<WOLineFailure.wOLineNbr>>>>>.Select(graph, line.WorkOrderID, line.LineNbr))
                            //{
                            //    newLineFailure = graph.LineFailureModes.Insert
                            //        (
                            //            new WOLineFailure()
                            //            {
                            //                FailureModeID = lineFailure.FailureModeID,
                            //                Comment = lineFailure.Comment
                            //            }
                            //        );
                            //}
                        }

                        graph.removeHold.Press();

                        graph.Actions.PressSave();
                    }

                    PXProcessing<WOSchedule>.SetProcessed();
                }
                catch (PXException e)
                {
                    errorOccured = true;
                    PXProcessing<WOSchedule>.SetError(PXException.PreserveStack(e));
                }
            }

            if (errorOccured)
            {
                PXProcessing<WOSchedule>.SetCurrentItem(null);

                throw new PXException(Messages.ErrorProcessedWithErrors);
            }
        }
        #endregion

        #region Overridden Properties

        public override bool IsDirty => false;

        #endregion

    }
}
