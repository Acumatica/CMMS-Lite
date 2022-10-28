<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="True" ValidateRequest="False" CodeFile="WO101000.aspx.cs" Inherits="Page_WO101000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="CMMSlite.WO.WOSetupMaint" PrimaryView="Setup" Height="36px" />
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXTab ID="tab" runat="server" DataSourceID="ds" Height="150px" Style="z-index: 100" Width="100%" DataMember="Setup" SyncPosition="True">
        <Items>
            <px:PXTabItem Text="General Settings">
                <Template>
                    <px:PXLayoutRule runat="server" StartRow="True" LabelsWidth="M" />
                    <px:PXLayoutRule runat="server" GroupCaption="Work Order Process" />
                    <px:PXLayoutRule runat="server" ID="CstPXLayoutRule11" StartRow="True" ControlSize="SM" LabelsWidth="S" />
                    <px:PXSelector runat="server" ID="CstPXSelector8" DataField="WONumberingID" AllowEdit="True"></px:PXSelector>
                    <px:PXSelector AllowEdit="True" runat="server" ID="CstPXSelector10" DataField="EquipNumberingID"></px:PXSelector>
                    <px:PXLayoutRule runat="server" StartRow="True" LabelsWidth="M" />
                </Template>
            </px:PXTabItem>
            <px:PXTabItem Text="Approvals">
                <Template>
                    <px:PXPanel ID="PXPanel1" runat="server" DataMember="">
                        <px:PXLayoutRule runat="server" LabelsWidth="S" ControlSize="XM" />
                        <px:PXCheckBox ID="chkWORequestApproval" runat="server" AlignLeft="True" Checked="True" DataField="WORequestApproval" CommitChanges="True" />
                    </px:PXPanel>
                    <px:PXGrid ID="grdApproval" runat="server" Height="400px" Width="100%" Style="z-index: 100" AllowPaging="True" AdjustPageSize="Auto" DataSourceID="ds" SkinID="DetailsInTab" TabIndex="2500" SyncPosition="True">
                        <Levels>
                            <px:PXGridLevel DataKeyNames="ApprovalID" DataMember="SetupApproval">
                                <RowTemplate>
                                    <px:PXCheckBox ID="edIsActive" runat="server" DataField="IsActive" CommitChanges="True" />
                                    <px:PXSelector ID="edAssignmentMapID" runat="server" DataField="AssignmentMapID" CommitChanges="True" />
                                    <px:PXSelector ID="edAssignmentNotificationID" runat="server" DataField="AssignmentNotificationID" CommitChanges="True" />
                                </RowTemplate>
                                <Columns>
                                    <px:PXGridColumn DataField="IsActive" TextAlign="Center" Type="CheckBox" Width="60px" />
                                    <px:PXGridColumn DataField="AssignmentMapID" TextAlign="Right" />
                                    <px:PXGridColumn DataField="AssignmentNotificationID" Width="280px" />
                                </Columns>
                            </px:PXGridLevel>
                        </Levels>
                        <AutoSize Container="Window" Enabled="True" MinHeight="200" />
                    </px:PXGrid>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="200" />
    </px:PXTab>
</asp:Content>
