<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="RoleAssignment_Approval.aspx.cs" Inherits="WebUI.Admin.RoleAssignment_Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    Role Approval
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="MenuPlaceHolder">
    <ul>
        <li>
            <asp:LinkButton ID="lnkApprove" runat="server" onclick="lnkApprove_Click">Approve</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="lnkReject" runat="server" onclick="lnkReject_Click">Reject</asp:LinkButton></li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <asp:GridView ID="gvResults" runat="server" ViewStateMode="Enabled" Width="100%"
        AutoGenerateColumns="False" CellPadding="4" 
    DataKeyNames="Emp_Role_ref_ID" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkID" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Employee_Name" HeaderText="Employee" />
            <asp:BoundField DataField="Role_Name" HeaderText="Assigned Role" />
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
