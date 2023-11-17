<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormTab.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="WO205000.aspx.cs" Inherits="Page_WO205000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormTab.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="CMMS.WOMeterMaint" PrimaryView="Meter">
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Meter" Width="100%" Height="70px" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ControlSize="SM" LabelsWidth="S" runat="server" StartColumn="True" StartRow="True" />
            <px:PXSelector runat="server" ID="slMeterCD" DataField="MeterCD" />
            <px:PXLayoutRule runat="server" ColumnSpan="2" />
            <px:PXTextEdit runat="server" ID="txtDescr" DataField="Descr" />
            <px:PXLayoutRule LabelsWidth="S" ControlSize="SM" runat="server" StartColumn="True" />
            <px:PXDropDown runat="server" ID="ddMeterType" DataField="MeterType" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXTab DataMember="CurrentMeter" ID="tab" runat="server" Width="100%" Height="150px" DataSourceID="ds" AllowAutoHide="false">
        <Items>
            <px:PXTabItem Text="General">
                <Template>
                    <px:PXLayoutRule runat="server" StartRow="True" />
                    <px:PXTextEdit runat="server" ID="txtFrequencyUnitsInt" DataField="FrequencyUnitsInt" CommitChanges="True" />
                    <px:PXTextEdit runat="server" ID="txtLeadUnitsInt" DataField="LeadUnitsInt" CommitChanges="True" />
                    <px:PXTextEdit runat="server" ID="txtLastValueInt" DataField="LastValueInt" CommitChanges="True" />
                    <px:PXTextEdit runat="server" ID="txtNextValueInt" DataField="NextValueInt" />
                    <px:PXDateTimeEdit runat="server" ID="dtLastValueDate" DataField="LastValueDate" CommitChanges="True" />
                    <px:PXDateTimeEdit runat="server" ID="dtNextValueDate" DataField="NextValueDate" />
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
    </px:PXTab>
</asp:Content>