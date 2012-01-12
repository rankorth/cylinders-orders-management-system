<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewOrderLog.aspx.cs" Inherits="WebUI.Admin.ViewOrderLog" %>
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
        <td class="entry_label" align="left">Order Code: <asp:Label ID="lblOrderCode" runat="server" /></td>
        <td class="entry_data" align="left">Product Name: <asp:Label ID="lblProductName" runat="server" /></td>
    </tr>
</table>

    <asp:GridView ID="gvOrderLogs" runat="server" ViewStateMode="Enabled" 
        Width="100%" onrowdatabound="gvOrderLogs_RowDataBound">
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
    </asp:GridView>
</asp:Content>
