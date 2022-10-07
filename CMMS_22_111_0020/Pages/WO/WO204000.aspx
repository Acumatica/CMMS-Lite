<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO204000.aspx.cs" Inherits="Page_WO204000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CMMSlite.WO.WOEquipmentMaint"
        PrimaryView="Equipment"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Equipment" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXLayoutRule ControlSize="SM" LabelsWidth="S" runat="server" ID="CstPXLayoutRule6" StartColumn="True" ></px:PXLayoutRule>
			<px:PXSelector runat="server" ID="CstPXSelector1" DataField="EquipmentCD" ></px:PXSelector>
			<px:PXDropDown runat="server" ID="CstPXDropDown22" DataField="Status" />
			<px:PXLayoutRule runat="server" ID="CstLayoutRule8" ColumnSpan="2" ></px:PXLayoutRule>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit5" DataField="Descr" ></px:PXTextEdit>
			<px:PXLayoutRule LabelsWidth="S" ControlSize="SM" runat="server" ID="CstPXLayoutRule7" StartColumn="True" ></px:PXLayoutRule>
			<px:PXDropDown runat="server" ID="CstPXDropDown2" DataField="EquipmentType" ></px:PXDropDown>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit3" DataField="PhysicalLocation" ></px:PXTextEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab DataMember="CurrentEquipment" ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
		<Items>
			<px:PXTabItem Text="General">
				<Template>
					<px:PXLayoutRule runat="server" ID="CstPXLayoutRule12" StartRow="True" ></px:PXLayoutRule>
					<px:PXNumberEdit runat="server" ID="CstPXNumberEdit1" DataField="BranchID" />
					<px:PXSegmentMask runat="server" ID="CstPXSegmentMask18" DataField="InventoryID" ></px:PXSegmentMask>
					<px:PXTextEdit runat="server" ID="CstPXTextEdit19" DataField="SerialNbr" ></px:PXTextEdit>
					<px:PXTextEdit runat="server" ID="CstPXTextEdit14" DataField="AssetID" ></px:PXTextEdit>
					<px:PXTextEdit runat="server" ID="CstPXTextEdit17" DataField="DepartmentID" ></px:PXTextEdit>
					<px:PXDropDown runat="server" ID="CstPXDropDown23" DataField="Criticality" ></px:PXDropDown>
					<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit16" DataField="DateInstalled" ></px:PXDateTimeEdit>
					<px:PXSelector runat="server" ID="CstPXSelector20" DataField="SMEquipmentID" ></px:PXSelector>
					<px:PXSelector runat="server" ID="CstPXSelector13" DataField="AMMachID" ></px:PXSelector></Template>
			</px:PXTabItem>
			<px:PXTabItem Text="BOM">
				<Template>
					<px:PXGrid SkinID="Details" Width="100%" SyncPosition="True" runat="server" ID="CstPXGrid24">
						<Levels>
							<px:PXGridLevel DataMember="BOM" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="InventoryID" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="InventoryItem__Descr" Width="280" ></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="Quantity" Width="100"></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="Criticality" Width="70"></px:PXGridColumn></Columns>
									<%--<px:PXGridColumn DataField="Quantity" Width="100" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Criticality" Width="70" ></px:PXGridColumn></Columns>--%>
								<RowTemplate>
									<px:PXSelector runat="server" ID="CstPXSelector25" DataField="InventoryID" AllowEdit="True" /></RowTemplate></px:PXGridLevel></Levels>						<AutoSize Enabled="True" ></AutoSize>
						<AutoSize MinHeight="200" ></AutoSize></px:PXGrid></Template>
</px:PXTabItem>
			<px:PXTabItem Text="Schedules">
				<Template>
					<px:PXGrid SkinID="Details" Width="100%" SyncPosition="True" runat="server" ID="CstPXGrid9">
						<Levels>
							<px:PXGridLevel DataMember="Schedules" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="WorkOrderID" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="WOOrder__Descr" Width="280" ></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="LeadTimeDays" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="FrequencyDays" Width="70"></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="LastWODate" Width="90"></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="NextWODate" Width="90"></px:PXGridColumn></Columns>

									<%--<px:PXGridColumn DataField="LeadTimeDays" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="FrequencyDays" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="LastWODate" Width="90" ></px:PXGridColumn>
									<px:PXGridColumn  DataField="NextWODate" Width="90" ></px:PXGridColumn></Columns>--%>
								<RowTemplate>
									<px:PXSelector runat="server" ID="CstPXSelector26" DataField="WorkOrderID" AllowEdit="True" /></RowTemplate></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" ></AutoSize>
						<AutoSize MinHeight="200" ></AutoSize></px:PXGrid></Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Work Order History" >
				<Template>
					<px:PXGrid SkinID="Inquire" SyncPosition="True" Width="100%" runat="server" ID="CstPXGrid10">
						<Levels>
							<px:PXGridLevel DataMember="WorkOrders" >
								<Columns>
									<px:PXGridColumn DataField="WorkOrderCD" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="WOClassID" Width="140" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Descr" Width="280" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Status" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Priority" Width="70" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" ></AutoSize>
						<AutoSize MinHeight="200" ></AutoSize></px:PXGrid></Template></px:PXTabItem>
			<px:PXTabItem Text="Failure Modes" >
				<Template>
					<px:PXGrid SkinID="Details" SyncPosition="True" Width="100%" runat="server" ID="CstPXGrid11">
						<Levels>
							<px:PXGridLevel DataMember="FailureModes" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="FailureModeID" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="WOFailureMode__Descr" Width="280" ></px:PXGridColumn></Columns>
								<RowTemplate>
									<px:PXSelector runat="server" ID="CstPXSelector27" DataField="FailureModeID" AllowEdit="True" /></RowTemplate></px:PXGridLevel></Levels>
						<AutoSize Enabled="True" ></AutoSize>
						<AutoSize MinHeight="200" ></AutoSize></px:PXGrid></Template></px:PXTabItem></Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>