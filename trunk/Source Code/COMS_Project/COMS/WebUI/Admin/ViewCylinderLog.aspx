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
        <td class="entry_label" align="left">Cyl No: <asp:Label ID="lblCylNo" runat="server" /></td>
        <td class="entry_data" align="left">Color No: <asp:Label ID="lblColorNo" runat="server" /></td>
        <td class="entry_label" align="left">Barcode: <asp:Label ID="lblCylCode" runat="server" /></td>
    </tr>
    <tr>
        <td class="entry_label" align="left">Core Type: <asp:Label ID="lblCoreType" runat="server" /></td>
        <td class="entry_data" align="left">Diameter: <asp:Label ID="lblDiameter" runat="server" /></td>
        <td class="entry_label" align="left">Length: <asp:Label ID="lblLength" runat="server" /></td>
    </tr>
</table>

    <asp:GridView ID="gvCylLogs" runat="server" ViewStateMode="Enabled" Width="100%">
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
    </asp:GridView>
</asp:Content>
