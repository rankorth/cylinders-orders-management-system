<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="template.aspx.cs" Inherits="WebUI.template" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/Site.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Header">
        <div class="logo"></div>
        <div class="header_title">Manufacturing & Management System</div>
    </div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 200px; vertical-align: top;">
                <div id="left_menu_panel">
                <div id="left_menu_title">Setup Menu</div>
                    <a class="module_menu" href="#">Workflow</a> <a class="module_menu" href="#">Roles</a>
                    <a class="module_menu" href="#">Access Rights</a>
                    <a class="module_menu" href="#">Logout</a>
                </div>
            </td>
            <td style="vertical-align: top; padding-left: 5px; width: auto;">
                <div class="menu_bar">
                    <div class="menu_bar_left">
                    </div>
                    <div class="menu_bar_right">
                    </div>
                    <ul>
                        <li><a href="#">Save</a></li>
                        <li><a href="#">Edit</a></li>
                        <li><a href="#">Delete</a></li>
                        <li><a href="#">Search</a></li>
                    </ul>
                </div>
                <div class="entry_panel">
                    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
                    <tr><td class="entry_label">user name</td><td class="entry_data"></td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data">
                        <asp:TextBox ID="TextBox1" runat="server" Height="86px" TextMode="MultiLine"></asp:TextBox>
                        </td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data"></td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data"></td></tr>
                    <tr><td class="entry_label"></td><td class="entry_data"></td></tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
