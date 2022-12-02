<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO202000.aspx.cs" Inherits="Page_WO202000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CMMSlite.WO.WOMeasurementMaint"
        PrimaryView="Measurements"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" Runat="Server">
	<px:PXGrid runat="server" ID="grdMeasurements" SkinID="Primary" Width="100%" >
		<Levels>
			<px:PXGridLevel DataMember="Measurements">
				<Columns>
					<px:PXGridColumn DataField="MeasurementCD" />
					<px:PXGridColumn DataField="Descr" />
				</Columns>
			</px:PXGridLevel>
		</Levels>
		<Mode/>
		<ActionBar>
			<CustomItems>
			</CustomItems>
		</ActionBar>
		<AutoSize Enabled="True" Container="Window"/>
	</px:PXGrid>
</asp:Content>