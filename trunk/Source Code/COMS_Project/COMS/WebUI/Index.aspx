<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebUI.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li>
            <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">Login</asp:LinkButton></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <br />&nbsp;<br />
    <br />
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td class="entry_label">
            User Name</td>
        <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtUserName" runat="server" MaxLength="50" 
                Width="336px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="entry_label">
            Password</td>
        <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtPassword" runat="server" MaxLength="50" 
                Width="336px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    &nbsp;<asp:Label ID="lblMessage" runat="server" Font-Bold="True" 
    ForeColor="Red"></asp:Label>
</asp:Content>
