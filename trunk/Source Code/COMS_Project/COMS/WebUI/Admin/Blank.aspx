<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Blank.aspx.cs" Inherits="WebUI.Admin.Blank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:Literal ID="ltrGuide" runat="server">Please select functions at the left panel</asp:Literal></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
<p>
- Use CrypTo to encrypt password under Login and Employee Mgmt
- Create Customer Mgmt module
- Create Printer Mgmt module
</p>
</asp:Content>
