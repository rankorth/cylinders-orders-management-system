<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewCylinderLog.aspx.cs" Inherits="WebUI.Admin.ViewCylinderLog" %>
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

<asp:HiddenField ID="hdCylinderId" runat="server" />
<table class="entry_table" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td class="entry_label" align="left">
            <asp:Literal ID="ltrCylNo" runat="server"></asp:Literal>
&nbsp;<asp:Label ID="lblCylNo" runat="server" /></td>
        <td class="entry_data" align="left">Color No: <asp:Label ID="lblColorNo" runat="server" /></td>
        <td class="entry_label" align="left">
            <asp:Literal ID="ltrBarcode" runat="server"></asp:Literal>
&nbsp;<asp:Label ID="lblCylCode" runat="server" /></td>
    </tr>
    <tr>
        <td class="entry_label" align="left">
            <asp:Literal ID="ltrCoreType" runat="server"></asp:Literal>
&nbsp;<asp:Label ID="lblCoreType" runat="server" /></td>
        <td class="entry_data" align="left">Diameter: <asp:Label ID="lblDiameter" runat="server" /></td>
        <td class="entry_label" align="left">
            <asp:Literal ID="ltrLength" runat="server"></asp:Literal>
&nbsp;<asp:Label ID="lblLength" runat="server" /></td>
    </tr>
</table>

    <asp:GridView ID="gvCylLogs" runat="server" ViewStateMode="Enabled" 
        Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="dept_name" HeaderText="Department" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="created_by" HeaderText="Performed By" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="start_time" HeaderText="Start Time" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="end_time" HeaderText="End Time" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="status" HeaderText="Description" 
                ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="remark" HeaderText="Remarks" 
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
