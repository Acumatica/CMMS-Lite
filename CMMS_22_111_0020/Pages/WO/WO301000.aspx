<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO301000.aspx.cs" Inherits="Page_WO301000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CMMSlite.WO.WOOrderEntry"
        PrimaryView="Document"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Document" Width="100%" Height="185px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ControlSize="SM" LabelsWidth="S" ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule9" StartColumn="True" ></px:PXLayoutRule>
			<px:PXDropDown runat="server" ID="CstPXDropDown22" DataField="WorkOrderType" ></px:PXDropDown>
			<px:PXSelector runat="server" ID="CstPXSelector7" DataField="WorkOrderCD" ></px:PXSelector>
			<px:PXDropDown runat="server" ID="CstPXDropDown5" DataField="Status" ></px:PXDropDown>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit27" DataField="RequestDate" ></px:PXDateTimeEdit>
			<px:PXDateTimeEdit runat="server" ID="CstPXDateTimeEdit28" DataField="ScheduleDate" ></px:PXDateTimeEdit>
			<px:PXLayoutRule runat="server" ID="CstLayoutRule12" ColumnSpan="2" ></px:PXLayoutRule>
			<px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="Descr" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule10" StartColumn="True" ></px:PXLayoutRule>
			<px:PXDropDown runat="server" ID="CstPXDropDown4" DataField="Priority" ></px:PXDropDown>
			<px:PXSelector runat="server" ID="CstPXSelector8" DataField="WOClassID" ></px:PXSelector>
			<px:PXSelector runat="server" ID="CstPXSelector21" DataField="EquipmentID" ></px:PXSelector>
			<px:PXSelector runat="server" ID="CstPXSelector3" DataField="OwnerID" ></px:PXSelector>
			<px:PXSelector runat="server" ID="CstPXSelector6" DataField="WorkgroupID" ></px:PXSelector></Template>
	
		</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab DataMember="CurrentDocument" ID="tab" runat="server" Width="100%" DataSourceID="ds" AllowAutoHide="false">
		<Items>
							<px:PXTabItem Text="Details">
								<Template>
									<px:PXLayoutRule ControlSize="SM" LabelsWidth="S" runat="server" ID="CstPXLayoutRule24" StartRow="True" ></px:PXLayoutRule>
									<px:PXLayoutRule runat="server" ID="CstPXLayoutRule25" StartColumn="True" ></px:PXLayoutRule>
									<px:PXSelector runat="server" ID="CstPXSelector29" DataField="OrigWorkOrderID" ></px:PXSelector></Template></px:PXTabItem>
			<px:PXTabItem Text="General">
				<Template>
					<px:PXGrid Height="100px" SkinID="Details" SyncPosition="True" DataSourceID="ds" Width="100%" runat="server" ID="CstPXGrid13">
						<Levels>
							<px:PXGridLevel DataMember="Transactions" >
								<Columns>
									<px:PXGridColumn DataField="Descr" Width="400" ></px:PXGridColumn>
									<px:PXGridColumn CommitChanges="True" DataField="EquipmentID" Width="70" ></px:PXGridColumn>
									<px:PXGridColumn DataField="WOEquipment__Descr" Width="280" ></px:PXGridColumn></Columns>
								<RowTemplate>
									<px:PXSelector runat="server" ID="CstPXSelector23" DataField="EquipmentID" AllowEdit="True" ></px:PXSelector></RowTemplate></px:PXGridLevel></Levels>
						<Mode InitNewRow="True" ></Mode>
						<AutoCallBack ActiveBehavior="True" Target="CstPXGrid17" Command="Refresh" >
							<Behavior RepaintControlsIDs="CstPXGrid17,CstPXGrid18,CstPXGrid19,CstPXGrid20" ></Behavior></AutoCallBack>
						<AutoCallBack ActiveBehavior="True" ></AutoCallBack>
						<AutoCallBack Target="CstPXGrid17" ></AutoCallBack></px:PXGrid>
					<px:PXTab Width="100%" runat="server" ID="CstPXTab15">
						<Items>
							<px:PXTabItem Text="Labor">
								<Template>
									<px:PXGrid SkinID="Details" Width="100%" runat="server" ID="CstPXGrid30">
										<Levels>
											<px:PXGridLevel DataMember="LineLabor" >
												<Columns>
													<px:PXGridColumn DataField="LaborType" Width="70" ></px:PXGridColumn>
													<px:PXGridColumn DataField="LaborHours" Width="100" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
										<AutoSize Enabled="True" />
										<AutoSize MinHeight="100" /></px:PXGrid></Template></px:PXTabItem>
							<px:PXTabItem Text="Materials">
								<Template>
									<px:PXGrid SkinID="Details" SyncPosition="True" DataSourceID="ds" Width="100%" runat="server" ID="CstPXGrid17">
										<Levels>
											<px:PXGridLevel DataMember="LineItems" >
												<Columns>
													<px:PXGridColumn CommitChanges="True" DataField="InventoryID" Width="70" ></px:PXGridColumn>
													<px:PXGridColumn DataField="InventoryID_description" Width="280" ></px:PXGridColumn>
													<px:PXGridColumn DataField="Quantity" Width="100" ></px:PXGridColumn>
													<px:PXGridColumn DataField="BaseUnit" Width="96" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
										<AutoSize MinHeight="100" Enabled="True" ></AutoSize>
										<AutoSize MinHeight="200" ></AutoSize>
										<Mode InitNewRow="True" ></Mode></px:PXGrid></Template></px:PXTabItem>
							<px:PXTabItem Text="Tools">
								<Template>
									<px:PXGrid SkinID="Details" SyncPosition="True" DataSourceID="ds" Width="100%" runat="server" ID="CstPXGrid18">
										<Levels>
											<px:PXGridLevel DataMember="LineTools" >
												<Columns>
													<px:PXGridColumn DataField="InventoryID" Width="70" CommitChanges="True" ></px:PXGridColumn>
													<px:PXGridColumn DataField="InventoryID_description" Width="280" ></px:PXGridColumn>
													<px:PXGridColumn DataField="Quantity" Width="100" ></px:PXGridColumn>
													<px:PXGridColumn DataField="BaseUnit" Width="96" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
										<AutoSize MinHeight="100" Enabled="True" ></AutoSize>
										<AutoSize MinHeight="200" ></AutoSize>
										<Mode InitNewRow="True" ></Mode></px:PXGrid></Template></px:PXTabItem>
							<px:PXTabItem Text="Measurements">
								<Template>
									<px:PXGrid Width="100%" DataSourceID="ds" SkinID="Details" SyncPosition="True" runat="server" ID="CstPXGrid19">
										<Levels>
											<px:PXGridLevel DataMember="LineMeasurements" >
												<Columns>
													<px:PXGridColumn DataField="MeasurementID" Width="140" ></px:PXGridColumn>
													<px:PXGridColumn DataField="Value" Width="100" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
										<Mode InitNewRow="True" ></Mode>
										<AutoSize Enabled="True" ></AutoSize>
										<AutoSize MinHeight="100" ></AutoSize></px:PXGrid></Template></px:PXTabItem>
							<px:PXTabItem Text="Failure Modes" >
								<Template>
									<px:PXGrid Width="100%" SkinID="Details" SyncPosition="True" DataSourceID="ds" runat="server" ID="CstPXGrid20">
										<Levels>
											<px:PXGridLevel DataMember="LineFailureModes" >
												<Columns>
													<px:PXGridColumn CommitChanges="True" DataField="FailureModeID" Width="140" ></px:PXGridColumn>
													<px:PXGridColumn DataField="Comment" Width="280" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels>
										<Mode InitNewRow="True" ></Mode>
										<AutoSize Enabled="True" ></AutoSize>
										<AutoSize MinHeight="100" ></AutoSize></px:PXGrid></Template></px:PXTabItem></Items>
						<AutoSize MinHeight="100" ></AutoSize>
						<AutoSize Enabled="True" ></AutoSize></px:PXTab></Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Approval">
				<Template>
					<px:PXGrid SkinID="Inquire" runat="server" ID="CstPXGrid14">
						<Levels>
							<px:PXGridLevel ></px:PXGridLevel></Levels></px:PXGrid></Template>
			</px:PXTabItem>
		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
	</px:PXTab>
</asp:Content>