<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO201000.aspx.cs" Inherits="Page_WO201000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/TabView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource EnableAttributes="True" ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CMMSlite.WO.WOClassMaint"
        PrimaryView="Classes"
        >
		<CallbackCommands>
			<px:PXDSCallbackCommand CommitChanges="True" Name="Save" ></px:PXDSCallbackCommand>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phF" Runat="Server">
    <px:PXTab ID="tab" runat="server" DataSourceID="ds" Height="559px" Style="z-index: 100" Width="100%" Caption="NCM Class">
        <Items>
            <px:PXTabItem Text="General Settings">
                <Template>

					<px:PXFormView Height="130px" ID="form" runat="server" DataSourceID="ds" DataMember="Classes" Width="100%" AllowAutoHide="false">
						<Template>
							<px:PXLayoutRule ControlSize="SM" LabelsWidth="S" ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
							<px:PXSelector runat="server" ID="CstPXSelector2" DataField="WOClassID" ></px:PXSelector>
							<px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="Descr" ></px:PXTextEdit></Template>
						<AutoSize Container="Window" Enabled="True" MinHeight="200" ></AutoSize>
					</px:PXFormView>

				</Template>
			</px:PXTabItem>
			<px:PXTabItem Text="Attributes">
			  <Template>
				<px:PXGrid runat="server" BorderWidth="0px" Height="150px" SkinID="Details" Width="100%" ID="AttributesGrid" 
							MatrixMode="True" DataSourceID="ds">
					<AutoSize Enabled="True" Container="Window" MinHeight="150" ></AutoSize>
					<Levels>
						<px:PXGridLevel DataMember="Mapping">
							<RowTemplate>
								<px:PXSelector runat="server" DataField="AttributeID" FilterByAllFields="True" AllowEdit="True" 
												CommitChanges="True" ID="edAttributeID" ></px:PXSelector></RowTemplate>
							<Columns>
								<px:PXGridColumn DataField="AttributeID" Width="81px" AutoCallBack="True" LinkCommand="ShowDetails" ></px:PXGridColumn>
								<px:PXGridColumn DataField="Description" Width="351px" AllowNull="False" ></px:PXGridColumn>
								<px:PXGridColumn DataField="SortOrder" TextAlign="Right" Width="81px" ></px:PXGridColumn>
								<px:PXGridColumn DataField="Required" Type="CheckBox" TextAlign="Center" AllowNull="False" ></px:PXGridColumn>
								<px:PXGridColumn DataField="CSAttribute__IsInternal" Type="CheckBox" TextAlign="Center" AllowNull="True" ></px:PXGridColumn>
								<px:PXGridColumn DataField="ControlType" Type="DropDownList" Width="81px" AllowNull="False" ></px:PXGridColumn>
								<px:PXGridColumn DataField="DefaultValue" RenderEditorText="False" Width="100px" AllowNull="True" ></px:PXGridColumn>
							</Columns>
						</px:PXGridLevel>
					</Levels>
				
				<Mode InitNewRow="True" /></px:PXGrid>
			  </Template>
			</px:PXTabItem>            
        </Items>
        <AutoSize Enabled="true" Container="Window" />
    </px:PXTab>
</asp:Content>