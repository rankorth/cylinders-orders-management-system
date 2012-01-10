<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewQueue.aspx.cs" Inherits="WebUI.Admin.ViewQueue" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li>Workflow: <asp:DropDownList ID="ddlWorkflow" runat="server"/></li>
        <li><asp:LinkButton ID="lnkViewQueue" runat="server" onclick="lnkViewQueue_Click">View Queue</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkExportQueue" runat="server" 
                onclick="lnkExportQueue_Click">Export Queue</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">

<asp:Label ID="lblMsg" CssClass="errorMsg" runat="server" />
<asp:HiddenField ID="hdWorkflowName" runat="server" />

    <asp:GridView ID="gvOrders" runat="server" ViewStateMode="Enabled" Width="100%" 
        onrowdatabound="gvOrders_RowDataBound" OnRowCommand="gvOrders_RowCommand">
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
        </Columns>
    </asp:GridView>
</asp:Content>

