<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Role.aspx.cs" Inherits="WebUI.Admin.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">Role Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li>
            <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click">Save</asp:LinkButton></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Role Name
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRoleName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="txtRoleName" runat="server" MaxLength="50" Width="336px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Active
            </td>
            <td class="entry_data">
                <asp:CheckBox ID="chkIsActive" runat="server" Text="Is This Role Active?" />
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Access Rights
            </td>
            <td class="entry_data">
                <br />
                <div style="width: 100%; height: 150px; overflow: scroll;">
                    <asp:GridView ID="gvAccess" runat="server" Width="566px" CellPadding="4" GridLines="None"
                        OnRowDataBound="gvAccess_RowDataBound" CssClass="grid" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="Access Rights Name" />
                            <asp:BoundField DataField="action" HeaderText="Allowed Actions" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hPageState" runat="server" Value="NEW" />
    <asp:HiddenField ID="hUpdateID" runat="server" Value="" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <asp:GridView ID="gvResult" runat="server" OnRowDataBound="gvResult_RowDataBound"
        ViewStateMode="Enabled" Width="100%" OnRowCommand="gvResult_RowCommand" CellPadding="4"
        GridLines="None" CssClass="grid" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False">edit</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Role Name" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
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
