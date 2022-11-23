<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO301000.aspx.cs" Inherits="Page_WO301000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="CMMSlite.WO.WOOrderEntry" PrimaryView="Document">
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Document" Width="100%">
        <Template>
            <px:PXLayoutRule runat="server" StartRow="True" />
            <px:PXDropDown runat="server" ID="CstPXDropDown22" DataField="WorkOrderType" CommitChanges="true" />
            <px:PXSelector runat="server" ID="CstPXSelector7" DataField="WorkOrderCD" />
            <px:PXDropDown runat="server" ID="CstPXDropDown5" DataField="Status" />
            <px:PXLabel runat="server" />
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit27" DataField="RequestDate" CommitChanges="true" />
            <px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit28" DataField="ScheduleDate" CommitChanges="true" />
            <px:PXLayoutRule runat="server" ID="CstLayoutRule12" ColumnSpan="2" />
            <px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="Descr" />
            <px:PXLayoutRule runat="server" ControlSize="XM" LabelsWidth="S" StartColumn="True" />
            <px:PXSelector runat="server" ID="CstPXSelector21" DataField="EquipmentID" />
            <px:PXSelector runat="server" CommitChanges="True" ID="CstPXSelector8" DataField="WOClassID" />
            <px:PXDropDown runat="server" ID="CstPXDropDown4" DataField="Priority" />
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
                    <px:PXSelector runat="server" ID="CstPXSelector29" DataField="OrigWorkOrderID"></px:PXSelector>
                    <px:PXLayoutRule runat="server" ControlSize="M" GroupCaption="Assigned To" LabelsWidth="SM" StartGroup="True" />
                    <px:PXSelector ID="edWorkgroupID" CommitChanges="true" runat="server" AutoRefresh="True" DataField="WorkgroupID" DataSourceID="ds" />
                    <px:PXSelector ID="edOwnerID" CommitChanges="true" runat="server" AutoRefresh="True" DataField="OwnerID" DataSourceID="ds" />
                      </Template>
                        <AutoSize Container="Window" Enabled="True"/>
                        </px:PXFormView>
                </Template>
            </px:PXTabItem>

            <px:PXTabItem Text="Operations" LoadOnDemand="true" RepaintOnDemand="false">
                <Template>
                    <px:PXGrid ID="gridOperations" runat="server" DataSourceID="ds" Style="z-index: 100" Height="200px" Width="100%" NoteIndicator="True" FilesIndicator="True"
                        SkinID="DetailsInTab" SyncPosition="True" SyncPositionWithGraph="True" MatrixMode="True">
                        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
                        <AutoCallBack Target="tab2" Command="Refresh"/>
                        <Levels>
                            <px:PXGridLevel DataMember="Transactions">
                                <Columns>
                                    <px:PXGridColumn DataField="EquipmentID" CommitChanges="True" Width="70" />
                                    <px:PXGridColumn DataField="WOEquipment__Descr" Width="280" />
                                    <px:PXGridColumn DataField="Descr" Width="400" />
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                    </px:PXGrid>

                    <px:PXTab ID="tab2" runat="server" Style="z-index: 100;" Width="100%" DataMember="CurrentDocument" SyncPosition="True">
                        <Items>
                            <px:PXTabItem Text="Labor" LoadOnDemand="false" RepaintOnDemand="false">
                                <Template>
                                    <px:PXGrid ID="gridLabor" runat="server" DataSourceID="ds" Style="z-index: 100" Width="100%" NoteIndicator="True" FilesIndicator="True"
                                        SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True" >
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150"/>
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
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True"  NoteIndicator="True" FilesIndicator="True">
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150"/>
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
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True"  NoteIndicator="True" FilesIndicator="True">
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150"/>
                                        <Levels>
                                            <px:PXGridLevel DataMember="LineTools">
                                                <Columns>
                                                    <px:PXGridColumn DataField="InventoryID" CommitChanges="True" Width="70" />
                                                    <px:PXGridColumn DataField="InventoryID_description" Width="280" />
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
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True"  NoteIndicator="True" FilesIndicator="True">
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150"/>
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
                                        Width="100%" SkinID="DetailsInTab" SyncPosition="True" MatrixMode="True"  NoteIndicator="True" FilesIndicator="True">
                                        <AutoSize Container="Parent" Enabled="True" MinHeight="150"/>
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
        </Items>
    </px:PXTab>
</asp:Content>