<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="WebUI.Admin.ManageOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:TextBox ID="txtBxSearchKey" runat="server" /></li>
        <li><asp:DropDownList ID="ddlSearchType" runat="server">
            <asp:ListItem Value="order_code" Text="Order Barcode"/>
            <asp:ListItem Value="cyl_code" Text="Cylinder Barcode"/>
            <asp:ListItem Value="set_code" Text="Set Code"/>
            <asp:ListItem Value="product_name" Text="Product Name"/>
        </asp:DropDownList></li>
        <li><asp:LinkButton ID="lnkSearch" runat="server" onclick="lnkSearch_Click">Search</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkAddOrder" runat="server" onclick="lnkAddOrder_Click">New Order</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkCancel" runat="server">Cancel Order</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <asp:GridView ID="gvOrders" runat="server" ViewStateMode="Enabled" Width="100%">
        <Columns>
            <asp:BoundField DataField="order_code" HeaderText="Order Code" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="set_code" HeaderText="Set Code" ItemStyle-HorizontalAlign="Center" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
                        <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

