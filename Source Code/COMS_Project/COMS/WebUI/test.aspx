<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebUI.test" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="MenuPlaceHolder">
    <ul>
                        <li><a href="#">Save</a></li>
                        <li><a href="#">Edit</a></li>
                        <li><a href="#">Delete</a></li>
                        <li><a href="#">Search</a></li>
                    </ul>
</asp:Content>

<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="InputPlaceHolder">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
                    <tr><td class="entry_label">user name</td><td class="entry_data"></td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data">
                        <asp:TextBox ID="TextBox1" runat="server" Height="86px" TextMode="MultiLine"></asp:TextBox>
                        </td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data"></td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data"></td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data"></td></tr>
                    </table>
</asp:Content>


