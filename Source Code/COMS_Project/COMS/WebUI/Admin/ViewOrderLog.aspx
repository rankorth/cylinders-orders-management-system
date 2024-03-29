﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewOrderLog.aspx.cs" Inherits="WebUI.Admin.ViewOrderLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:LinkButton ID="linkBack" runat="server" onclick="linkBack_Click">Back</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">

<asp:Label ID="lblMsg" CssClass="errorMsg" runat="server" />
<asp:HiddenField ID="hdOrderId" runat="server" />

<table class="entry_table" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td class="entry_label" align="left">
            <asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal>
            : <asp:Label ID="lblOrderCode" runat="server" /></td>
        <td class="entry_data" align="left">
            <asp:Literal ID="ltrProductName" runat="server"></asp:Literal>
            : <asp:Label ID="lblProductName" runat="server" /></td>
    </tr>
</table>

    <asp:GridView ID="gvOrderLogs" runat="server" ViewStateMode="Enabled" 
        Width="100%" onrowdatabound="gvOrderLogs_RowDataBound" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="dept_name" HeaderText="Department" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="updated_by" HeaderText="Performed By" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="updated_date" HeaderText="Time" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblOrderStatus" runat="server" />
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="related_cyl" HeaderText="Related Cylinders" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="remarks" HeaderText="Remarks" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
