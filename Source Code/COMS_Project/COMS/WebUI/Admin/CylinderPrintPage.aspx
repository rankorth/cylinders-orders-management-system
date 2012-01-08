<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CylinderPrintPage.aspx.cs" Inherits="WebUI.Admin.CylinderPrintPage" %>
<html>
<head id="Head1" runat="server">
    <title>COMS Cylinder Information</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            text-decoration: underline;
            font-size: medium;
        }
        .style3
        {
        }
        .style4
        {
            text-align: right;
            font-weight: bold;
        }
        .style5
        {
        }
        .style6
        {
            width: 139px;
            text-align: right;
            height: 23px;
            font-weight: bold;
        }
        .style7
        {
            height: 23px;
        }
        .style9
        {
            text-align: right;
            height: 4px;
        }
        .style19
        {
            width: 123px;
            text-align: right;
            font-weight: bold;
        }
        .style36
        {
            width: 967px;
            height: 249px;
        }
        .style37
        {
            text-align: center;
            font-weight: bold;
            width: 321px;
            height: 19px;
        }
        .style40
        {
            text-align: center;
            font-weight: bold;
            width: 321px;
            height: 44px;
        }
        #Text2
        {
            width: 350px;
            margin-left: 0px;
        }
        #Text3
        {
            width: 354px;
        }
        .style46
        {
            text-align: right;
            font-weight: bold;
            width: 139px;
        }
        .style47
        {
            font-size: medium;
        }
        .style49
        {
            text-align: center;
            font-weight: bold;
            width: 321px;
            height: 45px;
        }
        #print
        {
        }
        .style51
        {
            width: 322px;
        }
        .style52
        {
            width: 967px;
        }
        .style53
        {
            width: 321px;
        }
        .style54
        {
            width: 87px;
            text-align: right;
        }
        .style57
        {
            width: 40px;
            text-align: right;
        }
        .style59
        {
            width: 29px;
        }
        .style60
        {
            width: 29px;
            text-align: right;
        }
        .style61
        {
            text-align: right;
            font-weight: bold;
            width: 136px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="style1" colspan="2">
                    &nbsp;<span class="style47"> </span>
                <span class="style2"><strong>Production Progress Form</strong></span><span 
                        class="style47">&nbsp;
                </span>
                </td>
                <td colspan="4">
                    &nbsp;
                </td>
                <td colspan="2" rowspan="2">
                    <asp: Image ID="imgBarCode" runat="server" /></td>
            </tr>
            <tr>
                <td class="style3" colspan="6">
                    &nbsp;
                    &nbsp;
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                    Customer:</td>
                <td class="style7" colspan="7">
                <asp:Label ID="txtCustomer" runat="server" /></td>
            </tr>
            <tr>
                <td class="style9" colspan="8">
                </td>
            </tr>
            <tr>
                <td class="style46">
                    Production Name:
                </td>
                <td class="style5" colspan="7">
                <asp:Label ID="txtProductionName" runat="server" /></td>
            </tr>
            <tr>
                <td class="style46">
                    &nbsp;</td>
                <td class="style59">
                    &nbsp;</td>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style46">
                    Order Code: </td>
                <td class="style60" align="left">
                <asp:Label ID="txtOrderCode" runat="server" style="text-align: left" 
                        Width="100px" /></td>
                <td class="style19">
                    Type: </td>
                <td class="style57">
                <asp:Label ID="txtType" runat="server" style="text-align: left" Width="100px" /></td>
                <td class="style61">
                    &nbsp;Diameter: </td>
                <td class="style54">
                <asp:Label ID="txtDiameter" runat="server" 
                        style="text-align: left; margin-left: 0px" Width="100px" /></td>
                <td class="style46">
                    &nbsp;Length: </td>
                <td><asp:Label ID="txtLength" runat="server" /></td>
            </tr>
            <tr>
                <td class="style4" colspan="8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style46">
                    Area: </td>
                <td class="style60">
                    <asp:Label ID="txtArea" runat="server" style="text-align: left" Width="100px" /></td>
                <td class="style19">
                    Circumference: </td>
                <td class="style57">
                    <asp:Label ID="txtCircumference" runat="server" Width="100px" /></td>
                <td class="style61">
                    Keyhole: </td>
                <td class="style54">
                    <asp:Label ID="txtKeyhole" runat="server" Height="17px" 
                        style="text-align: left" Width="100px" /></td>
                <td class="style46">
                    Keyway: </td>
                <td><asp:Label ID="txtKeyway" runat="server" /></td>
            </tr>
        </table>
        <p></p>
        <table border="1" class="style36" style="width: 100%;">
        <tr>
        <td class="style37">
        
            Error</td>
        <td class="style37">
        
            Result</td>
        <td class="style37">
        
            Remarks</td>
        </tr>
        <tr>
        <td class="style40">
        
            &nbsp;</td>
        <td class="style40">
        
            &nbsp;</td>
        <td class="style40">
        
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style49">
        
            &nbsp;</td>
        <td class="style49">
        
            &nbsp;</td>
        <td class="style49">
        
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style49">
        
            &nbsp;</td>
        <td class="style49">
        
            &nbsp;</td>
        <td class="style49">
        
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style49">
        
            &nbsp;</td>
        <td class="style49">
        
            &nbsp;</td>
        <td class="style49">
        
            &nbsp;</td>
        </tr>
        <tr>
        <td class="style49">
        
            </td>
        <td class="style49">
        
            </td>
        <td class="style49">
        
            </td>
        </tr>
        </table>
    </div>
    </form>

        <table class="style52" style="width: 100%;">
        <tr>
        <td class="style53"></td>
            <td class="style51" align="center">
                <input id="print" type="button" value="Print" onclick="JavaScript:window.print(); return false;"/></td>
                <td class="style51"></td>
        </tr>
    </table>
</body>
</html>