<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO201000.aspx.cs" Inherits="Page_WO201000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

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
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" Width="100%" Caption="Work Order Class Summary" DataSourceID="ds" NoteIndicator="True"
        FilesIndicator="True" ActivityIndicator="True" ActivityField="NoteActivity" DataMember="Classes" DefaultControlID="edVendorClassID"
        TemplateContainer="">
        <Activity HighlightColor="" SelectedColor="" Width="" Height=""></Activity>
        <Template>
            <px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="SM" ControlSize="M" />
            <px:PXSelector ID="edWOClassID" runat="server" DataField="WOClassID" DataSourceID="ds" />
            <px:PXTextEdit ID="edDescr" runat="server" DataField="Descr" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
    <px:PXTab ID="tab" runat="server" DataSourceID="ds" Height="559px" Style="z-index: 100" Width="100%" Caption="NCM Class">
        <Items>
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