<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ErrorManagement.aspx.cs" Inherits="WebUI.Admin.ErrorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
<ul>
        <li><asp:LinkButton ID="lnkSave" runat="server">Save</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
<table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Role Name
            </td>
            <td class="entry_data">
                <asp:TextBox ID="txtAdadf" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Description
            </td>
            <td class="entry_data">
                <asp:TextBox ID="TextBox1" runat="server" Height="86px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>
