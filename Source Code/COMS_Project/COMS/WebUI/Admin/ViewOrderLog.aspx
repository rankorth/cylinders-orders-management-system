<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewOrderLog.aspx.cs" Inherits="WebUI.Admin.ViewOrderLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:LinkButton ID="linkBack" runat="server">Back</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">

<asp:Label ID="lblMsg" CssClass="errorMsg" runat="server" />

<asp:HiddenField ID="hdOrderId" runat="server" />
<asp:Label ID="lblOrderCode" runat="server" />
<asp:Label ID="lblProductName" runat="server" />

    <asp:GridView ID="gvOrderLogs" runat="server" ViewStateMode="Enabled" Width="100%">
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
            <asp:BoundField DataField="order_status" HeaderText="Description" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
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
