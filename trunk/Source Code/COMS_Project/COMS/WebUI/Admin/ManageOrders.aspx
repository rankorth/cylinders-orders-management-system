<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="WebUI.Admin.ManageOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li>Order Code: <asp:TextBox ID="txtBxOrderCode" runat="server"></asp:TextBox></li>
        <li><asp:LinkButton ID="lnkSearch" runat="server" onclick="lnkSearch_Click">Search</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkAddOrder" runat="server" onclick="lnkAddOrder_Click">New Order</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkCancel" runat="server">Cancel Order</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
                        <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

