<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StepList.aspx.cs" Inherits="WebUI.Reports.StepList" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    Step List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div style="vertical-align:middle;display:block;line-height:35px;">
    <asp:DropDownList 
        ID="ddlWorkflows" runat="server" Width="315px" AutoPostBack="True" 
            onselectedindexchanged="ddlWorkflows_SelectedIndexChanged" >
    </asp:DropDownList>
    &nbsp;
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <rsweb:ReportViewer ID="rvSteps" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Reports\Report_Files\Steps.rdlc">
        </LocalReport>
</rsweb:ReportViewer>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>
