<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO203000.aspx.cs" Inherits="Page_WO203000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CMMSlite.WO.WOFailureModeMaint"
        PrimaryView="FailureModes"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" Runat="Server">
	<px:PXGrid runat="server" ID="grdFailureModes" SkinID="Primary" Width="100%">
		<Levels>
			<px:PXGridLevel DataMember="FailureModes">
				<Columns>
					<px:PXGridColumn DataField="FailureModeCD"/>
					<px:PXGridColumn DataField="Descr"/>
					
				</Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="200" ></AutoSize>
	</px:PXGrid>
</asp:Content>
