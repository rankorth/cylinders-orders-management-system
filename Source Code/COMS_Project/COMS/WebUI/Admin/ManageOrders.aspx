<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="WebUI.Admin.ManageOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
<%//Tin (9-Jan-2012) added to show search boxes at properly middle aligned. %>
    <div style="vertical-align:middle;display:block;line-height:35px;float:left;">
    <asp:TextBox ID="txtBxSearchKey" runat="server" />
    <asp:DropDownList ID="ddlSearchType" runat="server">
            <asp:ListItem Value="order_code" Text="Order Barcode"/>
            <asp:ListItem Value="cyl_code" Text="Cylinder Barcode"/>
            <asp:ListItem Value="set_code" Text="Set Code"/>
            <asp:ListItem Value="product_name" Text="Product Name"/>
        </asp:DropDownList>
    </div>
<ul>
        <li><asp:LinkButton ID="lnkSearch" runat="server" onclick="lnkSearch_Click">Search</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkAddOrder" runat="server" onclick="lnkAddOrder_Click">New Order</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OutputPlaceHolder" runat="server">

<asp:Label ID="lblMsg" CssClass="errorMsg" runat="server" />

    <asp:GridView ID="gvOrders" runat="server" ViewStateMode="Enabled" Width="100%" 
        onrowdatabound="gvOrders_RowDataBound" OnRowCommand="gvOrders_RowCommand" 
        style="text-align: center">
        <Columns>
            <asp:TemplateField HeaderText="Order Code" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkOrderCode" runat="server"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="product_name" HeaderText="Product Name" 
                ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="set_code" HeaderText="Set Code" 
                ItemStyle-HorizontalAlign="Center" >
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblOrderStatus" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Progress" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkViewLog" runat="server">view</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>            
			<asp:TemplateField HeaderText="Cylinders" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                 <asp:LinkButton ID="lnkCylinders" runat="server" >cylinders info</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:HiddenField ID="hOrderCode" runat="server" Value="" />
    <asp:GridView ID="gvCylinders" runat="server" onrowdatabound="gvCylinders_RowDataBound" 
        onrowcommand="gvCylinders_RowCommand" ViewStateMode="Enabled" Width="100%" EmptyDataText="No cylinder found.">
        <Columns>
            <asp:BoundField DataField="cyl_no" HeaderText="Cylinder No" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="barcode" HeaderText="Bar Code" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="color_no" HeaderText="Color No" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="core_type" HeaderText="Core Type" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="diameter" HeaderText="Diameter" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="length" HeaderText="Length" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Print Info" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                 <asp:LinkButton ID="lnkPrint" runat="server">print</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Progress" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                 <asp:LinkButton ID="lnkCylLog" runat="server">view</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

