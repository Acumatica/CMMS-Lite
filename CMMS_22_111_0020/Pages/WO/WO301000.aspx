<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO301000.aspx.cs" Inherits="Page_WO301000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="CMMS.WOOrderEntry" PrimaryView="Document">
        <CallbackCommands>
            <px:PXDSCallbackCommand DependOnGrid="gridOperations" Name="rowUp" Visible="False" />
            <px:PXDSCallbackCommand DependOnGrid="gridOperations" Name="rowDown" Visible="False" />
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Document" Width="100%">
        <Template>
            <px:PXLayoutRule runat="server" StartRow="True" />
            <px:PXDropDown runat="server" ID="ddWorkOrdertype" DataField="WorkOrderType" CommitChanges="true" />
            <px:PXSelector runat="server" ID="slWorkOrderCD" DataField="WorkOrderCD" />
            <px:PXDropDown runat="server" ID="ddStatus" DataField="Status" />
            <px:PXLabel runat="server" />
            <px:PXDateTimeEdit runat="server" ID="dtRequestDate" DataField="RequestDate" CommitChanges="true" />
            <px:PXDateTimeEdit runat="server" ID="dtScheduleDate" DataField="ScheduleDate" CommitChanges="true" />
            <px:PXLayoutRule runat="server" ColumnSpan="2" />
            <px:PXTextEdit runat="server" ID="txtDescr" DataField="Descr" />

            <px:PXLayoutRule runat="server" ControlSize="XM" LabelsWidth="S" StartColumn="True" />
            <px:PXSelector runat="server" ID="slEquipmentID" DataField="EquipmentID" />

            <px:PXSelector runat="server" CommitChanges="True" ID="slWOClassID" DataField="WOClassID" />
            <px:PXDropDown runat="server" ID="ddPriority" DataField="Priority" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab ID="tab1" runat="server" Style="z-index: 100;" Width="100%" DataMember="CurrentDocument" SyncPosition="True">
        <Items>
            <px:PXTabItem Text="Details">
                <Template>
                    <px:PXFormView ID="form2" runat="server" Style="z-index: 100" Width="100%" DataMember="CurrentDocument" CaptionVisible="False" SkinID="Transparent" DataSourceID="ds" MarkRequired="Dynamic">
                        <Template>
                            <px:PXLayoutRule ControlSize="M" LabelsWidth="SM" ID="PXLayoutRule1" runat="server" StartRow="True" />
                            <px:PXSelector runat="server" ID="slOrigWorkOrderID" DataField="OrigWorkOrderID" />
                            <px:PXSelector runat="server" ID="TemplateID" DataField="TemplateID" />
                            <px:PXLayoutRule runat="server" ControlSize="M" GroupCaption="Assigned To" LabelsWidth="SM" StartGroup="True" />
                            <px:PXSelector ID="edWorkgroupID" CommitChanges="true" runat="server" AutoRefresh="True" DataField="WorkgroupID" DataSourceID="ds" />
                            <px:PXSelector ID="edOwnerID" CommitChanges="true" runat="server" AutoRefresh="True" DataField="OwnerID" DataSourceID="ds" />
                        </Template>
                        <AutoSize Container="Window" Enabled="True" />
                    </px:PXFormView>
                </Template>
            </px:PXTabItem>

            <px:PXTabItem Text="Operations" LoadOnDemand="true" RepaintOnDemand="false">
                <Template>
                    <px:PXGrid ID="gridOperations" runat="server" DataSourceID="ds" Style="z-index: 100" Height="200px" Width="100%" NoteIndicator="True" FilesIndicator="True"
                        SkinID="DetailsInTab" SyncPosition="True" SyncPositionWithGraph="True" MatrixMode="True" KeepPosition="true">
                        <Mode InitNewRow="True" AllowFormEdit="False" AllowUpload="True" AllowDragRows="true" />
                        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
                        <AutoCallBack ActiveBehavior="True" Target="tab2" Command="Refresh">
                            <Behavior RepaintControlsIDs="tab2,gridLabor,gridMaterials,gridTools,gridMeasurements,gridFailure" />
                        </AutoCallBack>
                        <Levels>
                            <px:PXGridLevel DataMember="Transactions">
                                <Columns>
                                    <px:PXGridColumn DataField="Descr" Width="400" />
                                    <px:PXGridColumn CommitChanges="True" DataField="EquipmentID" Width="70" />
                                    <px:PXGridColumn DataField="WOEquipment__Descr" Width="280" />
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <ActionBar>
                            <Actions>
                                <FilterBar ToolBarVisible="Top" Order="0" GroupIndex="3" />
                            </Actions>
                            <CustomItems>
                                <px:PXToolBarButton CommandName="rowUp" CommandSourceID="ds" Tooltip="Move Row Up">
                                    <Images Normal="main@ArrowUp" />
                                </px:PXToolBarButton>
                                <px:PXToolBarButton CommandName="rowDown" CommandSourceID="ds" Tooltip="Move Row Down">
                                    <Images Normal="main@ArrowDown" />
                                </px:PXToolBarButton>
                            </CustomItems>
                        </ActionBar>
                    </px:PXGrid>

                    <px:PXTab ID="tab2" runat="server" Style="z-index: 100;" Width="100%" DataMember="CurrentDocument" SyncPosition="True">
                        <Items>
                            <px:PXTabItem Text="Labor" LoadOnDemand="false" RepaintOnDemand="false">
                                <Template>
                                    <px:PXGrid ID="gridLabor" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" NoteIndicator="True" FilesIndicator="True"
                                        SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True">
                                        <Mode InitNewRow="True" AllowFormEdit="False" AllowUpload="True" AllowDragRows="true" />
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150" />
                                        <Levels>
                                            <px:PXGridLevel DataMember="LineLabor">
                                                <Columns>
                                                    <px:PXGridColumn DataField="LaborType" Width="70" />
                                                    <px:PXGridColumn DataField="LaborHours" Width="100" />
                                                </Columns>
                                            </px:PXGridLevel>
                                        </Levels>
                                    </px:PXGrid>
                                </Template>
                            </px:PXTabItem>

                            <px:PXTabItem Text="Materials" LoadOnDemand="false" RepaintOnDemand="false">
                                <Template>
                                    <px:PXGrid ID="gridMaterials" runat="server" DataSourceID="ds" Style="z-index: 100"
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True" NoteIndicator="True" FilesIndicator="True">
                                        <Mode InitNewRow="True" AllowFormEdit="False" AllowUpload="True" AllowDragRows="true" />
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150" />
                                        <Levels>
                                            <px:PXGridLevel DataMember="LineItems">
                                                <Columns>
                                                    <px:PXGridColumn DataField="InventoryID" CommitChanges="True" Width="70" />
                                                    <px:PXGridColumn DataField="InventoryID_description" Width="280" />
                                                    <px:PXGridColumn DataField="Quantity" Width="100" />
                                                    <px:PXGridColumn DataField="InventoryItem__BaseUnit" Width="100" />
                                                </Columns>
                                            </px:PXGridLevel>
                                        </Levels>
                                    </px:PXGrid>
                                </Template>
                            </px:PXTabItem>

                            <px:PXTabItem Text="Tools" LoadOnDemand="false" RepaintOnDemand="false">
                                <Template>
                                    <px:PXGrid ID="gridTools" runat="server" DataSourceID="ds" Style="z-index: 100"
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True" NoteIndicator="True" FilesIndicator="True">
                                        <Mode InitNewRow="True" AllowFormEdit="False" AllowUpload="True" AllowDragRows="true" />
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150" />
                                        <Levels>
                                            <px:PXGridLevel DataMember="LineTools">
                                                <Columns>
                                                    <px:PXGridColumn DataField="EquipmentID" CommitChanges="True" Width="70" />
                                                    <px:PXGridColumn DataField="WOEquipment__Descr" Width="280" />
                                                    <px:PXGridColumn DataField="Quantity" Width="100" />
                                                    <px:PXGridColumn DataField="BaseUnit" Width="96" />
                                                </Columns>
                                            </px:PXGridLevel>
                                        </Levels>
                                    </px:PXGrid>
                                </Template>
                            </px:PXTabItem>

                            <px:PXTabItem Text="Measurements" LoadOnDemand="false" RepaintOnDemand="false">
                                <Template>
                                    <px:PXGrid ID="gridMeasurements" runat="server" DataSourceID="ds" Style="z-index: 100"
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True" NoteIndicator="True" FilesIndicator="True">
                                        <Mode InitNewRow="True" AllowFormEdit="False" AllowUpload="True" AllowDragRows="true" />
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150" />
                                        <Levels>
                                            <px:PXGridLevel DataMember="LineMeasurements">
                                                <Columns>
                                                    <px:PXGridColumn DataField="MeasurementID" Width="140" />
                                                    <px:PXGridColumn DataField="Value" Width="100" />
                                                </Columns>
                                            </px:PXGridLevel>
                                        </Levels>
                                    </px:PXGrid>
                                </Template>
                            </px:PXTabItem>

                            <px:PXTabItem Text="Failure Mode" LoadOnDemand="false" RepaintOnDemand="false">
                                <Template>
                                    <px:PXGrid ID="gridFailure" runat="server" DataSourceID="ds" Style="z-index: 100"
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True" NoteIndicator="True" FilesIndicator="True">
                                        <Mode InitNewRow="True" AllowFormEdit="False" AllowUpload="True" AllowDragRows="true" />
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150" />
                                        <Levels>
                                            <px:PXGridLevel DataMember="LineFailureModes">
                                                <Columns>
                                                    <px:PXGridColumn DataField="FailureModeID" CommitChanges="True" Width="140" />
                                                    <px:PXGridColumn DataField="Comment" Width="280" />
                                                </Columns>
                                            </px:PXGridLevel>
                                        </Levels>
                                    </px:PXGrid>
                                </Template>
                            </px:PXTabItem>
                        </Items>
                    </px:PXTab>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Attributes">
                <Template>
                    <px:PXGrid runat="server" ID="PXGridAnswers" Height="200px" SkinID="Inquire"
                        Width="100%" MatrixMode="True" DataSourceID="ds">
                        <AutoSize Enabled="True" MinHeight="200"></AutoSize>
                        <ActionBar>
                            <Actions>
                                <Search Enabled="False"></Search>
                            </Actions>
                        </ActionBar>
                        <Mode AllowAddNew="False" AllowDelete="False" AllowColMoving="False"></Mode>
                        <Levels>
                            <px:PXGridLevel DataMember="Answers">
                                <Columns>
                                    <px:PXGridColumn TextAlign="Left" DataField="AttributeID" TextField="AttributeID_description"
                                        Width="250px" AllowShowHide="False">
                                    </px:PXGridColumn>
                                    <px:PXGridColumn Type="CheckBox" TextAlign="Center" DataField="isRequired" Width="80px"></px:PXGridColumn>
                                    <px:PXGridColumn DataField="Value" Width="300px" AllowSort="False" AllowShowHide="False"></px:PXGridColumn>
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Approvals">
                <Template>
                    <px:PXGrid Caption="" SkinID="DetailsInTab" Width="100%" runat="server" ID="PXGrid1" DataSourceID="ds">
                        <Levels>
                            <px:PXGridLevel DataMember="Approval">
                                <Columns>
                                    <px:PXGridColumn DataField="ApproverEmployee__AcctName" Width="160" />
                                    <px:PXGridColumn DataField="ApproverEmployee__AcctCD" Width="160" />
                                    <px:PXGridColumn DataField="ApprovedByEmployee__AcctName" Width="100" />
                                    <px:PXGridColumn DataField="ApprovedByEmployee__AcctCD" Width="160" />
                                    <px:PXGridColumn DataField="ApproveDate" Width="90" />
                                    <px:PXGridColumn DataField="Status" Width="90" />
                                    <px:PXGridColumn DataField="Reason" Width="280" />
                                    <px:PXGridColumn DataField="WorkgroupID" Width="150" />
                                </Columns>
                                <RowTemplate>
                                    <px:PXDateTimeEdit runat="server" ID="dtApproveDate" DataField="ApproveDate" />
                                    <px:PXTextEdit runat="server" ID="txtApprovedByEmployeeAcctCD" DataField="ApprovedByEmployee__AcctCD" />
                                    <px:PXTextEdit runat="server" ID="txtApprovedByEmployeeAcctName" DataField="ApprovedByEmployee__AcctName" />
                                    <px:PXTextEdit runat="server" ID="txtApproverEmployeeAcct" DataField="ApproverEmployee__AcctCD" />
                                    <px:PXTextEdit runat="server" ID="txtApproverEmployeeAcctName" DataField="ApproverEmployee__AcctName" />
                                    <px:PXDropDown runat="server" ID="ddStatus" DataField="Status" />
                                    <px:PXSelector runat="server" ID="slWorkGroupID" DataField="WorkgroupID" />
                                    <px:PXTextEdit runat="server" ID="txtReason" DataField="Reason" />
                                </RowTemplate>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Container="Window" MinHeight="150" Enabled="True" />
                        <Mode AllowAddNew="False" AllowDelete="False" AllowUpdate="False" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>

            <px:PXTabItem Text="Related Work Orders">
                <Template>
                    <px:PXGrid Caption="" SkinID="DetailsInTab" Width="100%" runat="server" ID="gridRelatedWorkOrders" DataSourceID="ds">
                        <Levels>
                            <px:PXGridLevel DataMember="RelatedWorkOrders">
                                <Columns>
                                    <px:PXGridColumn DataField="workOrderType" />
                                    <px:PXGridColumn DataField="WorkOrderCD" />
                                    <px:PXGridColumn DataField="WOClassID" />
                                    <px:PXGridColumn DataField="Status" />
                                    <px:PXGridColumn DataField="Priority" />
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Container="Window" MinHeight="150" Enabled="True" />
                        <Mode AllowAddNew="False" AllowDelete="False" AllowUpdate="False" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="200" />
    </px:PXTab>
    <px:PXSmartPanel ID="panelScheduleDate" runat="server" Caption="Schedule" CaptionVisible="true" LoadOnDemand="true" Key="schedulefilter"
        AutoCallBack-Enabled="true" AutoCallBack-Target="formScheduleDate" AutoCallBack-Command="Refresh" CallBackMode-CommitChanges="True"
        CallBackMode-PostData="Page" AutoReload="True">
        <div style="padding: 5px">
            <px:PXFormView ID="formScheduleDate" runat="server" DataSourceID="ds" CaptionVisible="False" DataMember="schedulefilter">
                <ContentStyle BackColor="Transparent" BorderStyle="None" />
                <Template>
                    <px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="S" ControlSize="SM" />
                    <px:PXDateTimeEdit CommitChanges="True" ID="edScheduleDate" runat="server" DataField="ScheduleDate" />
                </Template>
            </px:PXFormView>
        </div>
        <px:PXPanel ID="panelScheduleButtons" runat="server" SkinID="Buttons">
            <px:PXButton ID="btnScheduleOk" runat="server" DialogResult="OK" Text="OK" CommandName="checkSchedule" CommandSourceID="ds" />
        </px:PXPanel>
    </px:PXSmartPanel>
    <px:PXSmartPanel ID="panelReason" runat="server" Caption="Enter Reason" CaptionVisible="true" LoadOnDemand="true" Key="ReasonApproveRejectParams"
        AutoCallBack-Enabled="true" AutoCallBack-Command="Refresh" CallBackMode-CommitChanges="True" Width="600px"
        CallBackMode-PostData="Page" AcceptButtonID="btnReasonOk" CancelButtonID="btnReasonCancel" AllowResize="False">
        <px:PXFormView ID="PXFormViewPanelReason" runat="server" DataSourceID="ds" CaptionVisible="False" DataMember="ReasonApproveRejectParams">
            <ContentStyle BackColor="Transparent" BorderStyle="None" Width="100%" Height="100%" CssClass="" />
            <Template>
                <px:PXLayoutRule ID="PXLayoutRulePanelReason" runat="server" StartColumn="True" />
                <px:PXPanel ID="PXPanelReason" runat="server" RenderStyle="Simple">
                    <px:PXLayoutRule ID="PXLayoutRuleReason" runat="server" StartColumn="True" SuppressLabel="True" />
                    <px:PXTextEdit ID="edReason" runat="server" DataField="Reason" TextMode="MultiLine" LabelWidth="0" Height="200px" Width="600px" CommitChanges="True" />
                </px:PXPanel>
                <px:PXPanel ID="PXPanelReasonButtons" runat="server" SkinID="Buttons">
                    <px:PXButton ID="btnReasonOk" runat="server" Text="OK" DialogResult="Yes" CommandSourceID="ds" />
                    <px:PXButton ID="btnReasonCancel" runat="server" Text="Cancel" DialogResult="No" CommandSourceID="ds" />
                </px:PXPanel>
            </Template>
        </px:PXFormView>
    </px:PXSmartPanel>
</asp:Content>
