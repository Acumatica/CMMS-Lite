<%@ Page Language="C#" MasterPageFile="~/MasterPages/ListView.master" AutoEventWireup="True" ValidateRequest="False" CodeFile="WO501000.aspx.cs" Inherits="Page_WO501000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/ListView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="CMMS.WODocumentReleaseProc" PrimaryView="Records"/>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phL" runat="Server">
	<px:PXGrid ID="grid" runat="server" Height="400px" Width="100%" Style="z-index: 100" AllowPaging="True" AllowSearch="True" AdjustPageSize="Auto" DataSourceID="ds" SkinID="PrimaryInquire" SyncPosition="True">
		<Levels>
			<px:PXGridLevel DataMember="Records">
				<Columns>
					<px:PXGridColumn runat="server" DataField="Selected" Type="CheckBox" TextAlign="Center" AllowCheckAll="True" CommitChanges="True"/>
					<px:PXGridColumn DataField="EquipmentID" />
					<px:PXGridColumn DataField="WorkOrderID" />
					<px:PXGridColumn DataField="LastWODate" />
					<px:PXGridColumn DataField="NextWODate" />
				</Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="200"/>
	</px:PXGrid>
</asp:Content>