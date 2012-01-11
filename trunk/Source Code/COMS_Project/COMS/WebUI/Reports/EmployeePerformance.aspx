<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="EmployeePerformance.aspx.cs" Inherits="WebUI.Reports.EmployeePerformance" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    Employee Performance Marks
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Employee Barcode
            </td>
            <td class="entry_data" colspan="3">
            <asp:TextBox ID="txtEmpBarcode" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Start Time
            </td>
            <td class="entry_data">
            <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
            <asp:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtStartDate">
            </asp:CalendarExtender>
            </td>
                 <td class="entry_label">
                     End Time</td>
            <td class="entry_data">
            <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
            <asp:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtEndDate">
            </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                &nbsp;</td>
            <td class="entry_data" colspan="3">
            <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <rsweb:ReportViewer ID="rvPerformance" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Reports\Report_Files\Performance.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
