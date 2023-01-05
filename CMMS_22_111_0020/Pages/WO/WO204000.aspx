<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO204000.aspx.cs" Inherits="Page_WO204000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="CMMSlite.WO.WOEquipmentMaint" PrimaryView="Equipment">
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Equipment" Width="100%" Height="100px" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ControlSize="SM" LabelsWidth="S" runat="server" StartColumn="True" StartRow="True" />
            <px:PXSelector runat="server" ID="slEquipmentCD" DataField="EquipmentCD" />
            <px:PXDropDown runat="server" ID="ddStatus" DataField="Status" />
            <px:PXLayoutRule runat="server" ColumnSpan="2" />
            <px:PXTextEdit runat="server" ID="txtDescr" DataField="Descr" />
            <px:PXLayoutRule LabelsWidth="S" ControlSize="SM" runat="server" StartColumn="True" />
            <px:PXDropDown runat="server" ID="ddEquipmentType" DataField="EquipmentType" />
            <px:PXTextEdit runat="server" ID="txtPhysicalLocation" DataField="PhysicalLocation" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab DataMember="CurrentEquipment" ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
        <Items>
            <px:PXTabItem Text="General">
                <Template>
                    <px:PXLayoutRule runat="server" StartRow="True" />
                    <px:PXSelector runat="server" ID="nbrBranchID" DataField="BranchID" />
                    <px:PXTextEdit runat="server" ID="txtSerialNbr" DataField="SerialNbr" />
                    <px:PXTextEdit runat="server" ID="txtAssetID" DataField="AssetID" />
                    <px:PXSelector runat="server" ID="txtDepartmentID" DataField="DepartmentID" />
                    <px:PXDropDown runat="server" ID="ddCriticality" DataField="Criticality" />
                    <px:PXDateTimeEdit runat="server" ID="dtDateInstalled" DataField="DateInstalled" />
                    <px:PXSelector runat="server" ID="slSMEquipmentID" DataField="SMEquipmentID" />
                    <px:PXSelector runat="server" ID="slAMMachID" DataField="AMMachID" />
                    <px:PXSegmentMask runat="server" ID="slInventoryID" DataField="InventoryID" />
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="BOM">
                <Template>
                    <px:PXGrid SkinID="Details" Width="100%" SyncPosition="True" runat="server" ID="CstPXGrid24">
                        <Levels>
                            <px:PXGridLevel DataMember="BOM">
                                <Columns>
                                    <px:PXGridColumn CommitChanges="True" DataField="InventoryID" Width="70" />
                                    <px:PXGridColumn DataField="InventoryItem__Descr" Width="280" />
                                    <px:PXGridColumn CommitChanges="True" DataField="Quantity" Width="100" />
                                    <px:PXGridColumn CommitChanges="True" DataField="Criticality" Width="70" />
                                </Columns>
                                <RowTemplate>
                                    <px:PXSelector runat="server" ID="slInventoryID" DataField="InventoryID" AllowEdit="True" />
                                    <px:PXNumberEdit runat="server" ID="nbrQuantity" DataField="Quantity" />
                                    <px:PXDropDown runat="server" ID="ddCriticality" DataField="Criticality" />
                                </RowTemplate>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Enabled="True" MinHeight="200" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Schedules">
                <Template>
                    <px:PXGrid SkinID="Details" Width="100%" SyncPosition="True" runat="server" ID="CstPXGrid9">
                        <Levels>
                            <px:PXGridLevel DataMember="Schedules">
                                <Columns>
                                    <px:PXGridColumn CommitChanges="True" DataField="WorkOrderID" Width="70" />
                                    <px:PXGridColumn DataField="WOOrder__Descr" Width="280" />
                                    <px:PXGridColumn CommitChanges="True" DataField="LeadTimeDays" Width="70" />
                                    <px:PXGridColumn CommitChanges="True" DataField="FrequencyDays" Width="70" />
                                    <px:PXGridColumn CommitChanges="True" DataField="LastWODate" Width="90" />
                                    <px:PXGridColumn CommitChanges="True" DataField="NextWODate" Width="90" />
                                </Columns>
                                <RowTemplate>
                                    <px:PXSelector runat="server" ID="slWorkOrderID" DataField="WorkOrderID" AllowEdit="True" />
                                    <px:PXTextEdit runat="server" ID="txtDescr" DataField="WOOrder__Descr" Enabled="False" />
                                    <px:PXNumberEdit runat="server" ID="nbrLeadTimeDays" DataField="LeadTimeDays" />
                                    <px:PXNumberEdit runat="server" ID="nbrFrequencyDays" DataField="FrequencyDays" />
                                    <px:PXDateTimeEdit runat="server" ID="dtLastWODate" DataField="LastWODate" />
                                    <px:PXDateTimeEdit runat="server" ID="PXDatetimeEdit1" DataField="NextWODate" />
                                </RowTemplate>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Enabled="True" MinHeight="200" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Work Order History">
                <Template>
                    <px:PXGrid SkinID="Inquire" SyncPosition="True" Width="100%" runat="server" ID="grdWOHistory">
                        <Levels>
                            <px:PXGridLevel DataMember="WorkOrders">
                                <Columns>
                                    <px:PXGridColumn DataField="ScheduleDate" Width="90" />
                                    <px:PXGridColumn LinkCommand="WorkOrders" DataField="WorkOrderCD" Width="140" />
                                    <px:PXGridColumn DataField="WOClassID" Width="140" />
                                    <px:PXGridColumn DataField="Descr" Width="280" />
                                    <px:PXGridColumn DataField="Status" Width="70" />
                                    <px:PXGridColumn DataField="Priority" Width="70" />
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Enabled="True" MinHeight="200" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Failure Modes">
                <Template>
                    <px:PXGrid SkinID="Details" SyncPosition="True" Width="100%" runat="server" ID="grdWOFailure">
                        <Levels>
                            <px:PXGridLevel DataMember="FailureModes">
                                <Columns>
                                    <px:PXGridColumn CommitChanges="True" DataField="FailureModeID" Width="70" />
                                    <px:PXGridColumn DataField="WOFailureMode__Descr" Width="280" />
                                    <px:PXGridColumn Type="CheckBox" DataField="IsMitigated" Width="60" />
                                    <px:PXGridColumn DataField="MitigationDescription" Width="280" />
                                </Columns>
                                <RowTemplate>
                                    <px:PXSelector runat="server" ID="slFailureModeID" DataField="FailureModeID" AllowEdit="True" />
                                    <px:PXTextEdit runat="server" ID="txtWOFailDescr" DataField="WOFailureMode__Descr" Enabled="False" />
                                    <px:PXCheckBox runat="server" ID="chkIsMitigated" DataField="IsMitigated" />
                                    <px:PXTextEdit runat="server" ID="txtMitigationDescription" DataField="MitigationDescription" />
                                </RowTemplate>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Enabled="True" MinHeight="200" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
    </px:PXTab>
</asp:Content>