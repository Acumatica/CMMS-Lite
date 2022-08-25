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
	<px:PXTab ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="General">
				<Template>
					<px:PXFormView DataMember="Preferences" DataSourceID="ds" runat="server" ID="CstFormView1" >
						<Template>
							<px:PXLayoutRule runat="server" ID="CstPXLayoutRule11" StartRow="True" ControlSize="SM" LabelsWidth="S" />
							<px:PXSelector runat="server" ID="CstPXSelector8" DataField="WONumberingID" AllowEdit="True" ></px:PXSelector>
							<px:PXSelector AllowEdit="True" runat="server" ID="CstPXSelector10" DataField="EquipNumberingID" ></px:PXSelector></Template></px:PXFormView></Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Approval">
				<Template>
					<px:PXFormView DataSourceID="ds" runat="server" ID="CstFormView3" DataMember="Preferences">
						<Template>
							<px:PXLayoutRule runat="server" ID="CstPXLayoutRule4" StartRow="True" ></px:PXLayoutRule>
							<px:PXCheckBox runat="server" ID="CstPXCheckBox7" DataField="WORequestApproval" /></Template>
						<AutoSize Enabled="True" ></AutoSize>
						<AutoSize MinHeight="30" ></AutoSize></px:PXFormView>
					<px:PXGrid Width="100%" DataSourceID="ds" runat="server" ID="CstPXGrid2">
						<Levels>
							<px:PXGridLevel DataMember="Approvals" >
								<Columns>
									<px:PXGridColumn DataField="IsActive" Width="60" ></px:PXGridColumn>
									<px:PXGridColumn DataField="AssignmentMapID" Width="220" ></px:PXGridColumn>
									<px:PXGridColumn DataField="AssignmentNotificationID" Width="280" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" />
						<AutoSize MinHeight="200" />
						<AutoSize MinWidth="200" /></px:PXGrid></Template>
			</px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXTab>
</asp:Content>
