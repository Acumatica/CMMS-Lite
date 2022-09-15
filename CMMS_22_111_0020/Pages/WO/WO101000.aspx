<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO101000.aspx.cs" Inherits="Page_WO101000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CMMSlite.WO.WOSetupMaint"
        PrimaryView="Preferences"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server"></asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab DataMember="Preferences" ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="General">
				<Template>
							<px:PXLayoutRule runat="server" ID="CstPXLayoutRule11" StartRow="True" ControlSize="SM" LabelsWidth="S" />
							<px:PXSelector runat="server" ID="CstPXSelector8" DataField="WONumberingID" AllowEdit="True" ></px:PXSelector>
							<px:PXSelector AllowEdit="True" runat="server" ID="CstPXSelector10" DataField="EquipNumberingID" ></px:PXSelector>
				</Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Approval">
				<Template>
				    <px:PXPanel runat="server">
				        <px:PXLayoutRule runat="server" LabelsWidth="S" ControlSize="XM" ></px:PXLayoutRule>
				        <px:PXCheckBox ID="chkRequestApproval" runat="server" AlignLeft="true" Checked="True" DataField="WORequestApproval" ></px:PXCheckBox>				        
                    </px:PXPanel>
                    <px:PXGrid ID="gridApproval" runat="server" DataSourceID="ds" SkinID="Details" Width="100%" >
                        <AutoSize Enabled="true" Container="Parent" MinHeight="200"></AutoSize>
					    <Levels>
						    <px:PXGridLevel DataMember="SetupApproval" DataKeyNames="ApprovalID">
							    <RowTemplate>
								    <px:PXLayoutRule runat="server" StartColumn="True"  LabelsWidth="M" ControlSize="XM" ></px:PXLayoutRule>

								    <px:PXSelector ID="edAssignmentMapID" runat="server" DataField="AssignmentMapID" TextField="Name" AllowEdit="True" ></px:PXSelector>
                                    <px:PXSelector ID="edAssignmentNotificationID" runat="server" DataField="AssignmentNotificationID" AllowEdit="True" ></px:PXSelector>
							    </RowTemplate>
							    <Columns>
								<px:PXGridColumn DataField="AssignmentMapID" Width="220" ></px:PXGridColumn>
                                    <px:PXGridColumn DataField="AssignmentNotificationID" Width="250px" RenderEditorText="True"  ></px:PXGridColumn></Columns>
						    </px:PXGridLevel>
					    </Levels>                        
					</px:PXGrid>
                </Template>
			</px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXTab>
</asp:Content>
