<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebUI.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function clearTextBoxes() {
            document.getElementById("txtUserName").value = "";
            document.getElementById("txtPassword").value = "";
        }
    </script>
</head>
<body>
    <form id="formLogin" runat="server">
    <div>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="login" />
        <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="clearTextBoxes()" />
    </div>
    </form>
</body>
</html>
