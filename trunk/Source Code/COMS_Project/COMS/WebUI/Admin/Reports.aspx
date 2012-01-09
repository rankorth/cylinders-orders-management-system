<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="WebUI.Admin.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    Reports
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="MenuPlaceHolder">
    <div style="vertical-align:middle;display:block;line-height:35px;">
    <asp:DropDownList 
        ID="ddlReports" runat="server" Width="315px" >
    </asp:DropDownList>
    &nbsp;
    <asp:Button ID="btnShowReports" runat="server" Height="25px" Text="Show" 
        Width="100px" onclick="btnShowReports_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>

