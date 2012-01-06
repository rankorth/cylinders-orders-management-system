<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DisplayOrder.aspx.cs" Inherits="WebUI.Admin.DisplayOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
<ul>
        <li><asp:LinkButton ID="lnkSearch" runat="server">Search</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkSave" runat="server" onclick="lnkSave_Click">Save</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkCancel" runat="server">Cancel</asp:LinkButton></li>
</ul>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InputPlaceHolder" runat="server">
<table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label" colspan="6" align="left"><asp:Label ID="lblMsg" CssClass="errorMsg" runat="server" /></td>
        </tr>
        <tr>
            <td class="entry_data"><asp:TextBox ID="txtCreateDate" runat="server" BorderWidth="1" /></td>
            <td class="entry_data" colspan="5" align="left">
                <asp:Image ID="imgBarCode" runat="server" />
                <asp:TextBox ID="txtBarCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="entry_label">1.Customer</td>
            <td class="entry_data" colspan="3"><asp:DropDownList ID="ddlCustomer" 
                    runat="server" onselectedindexchanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList></td>
             <td class="entry_label">Set Code</td>
            <td class="entry_data"><asp:TextBox ID="txtSetCode" runat="server" BorderWidth="1" /></td>
        </tr>
        <tr>
            <td class="entry_label">2.Contact Person</td>
            <td class="entry_data"><asp:TextBox ID="txtCustomerRep" runat="server" BorderWidth="1" /></td>
             <td class="entry_label">Cylinder Type</td>
            <td class="entry_data"><asp:TextBox ID="txtCylType" runat="server" BorderWidth="1" Width="40px" /></td>
             <td class="entry_label">Price Type</td>
            <td class="entry_data"><asp:TextBox ID="txtPriceType" runat="server" BorderWidth="1" /></td>
        </tr>
        <tr>
            <td class="entry_label">3.Product Name</td>
            <td class="entry_data" colspan="5"><asp:TextBox ID="txtProdName" runat="server" BorderWidth="1" Width="500px" /></td>
        </tr>
        <tr>
            <td class="entry_label">4.New Order <asp:RadioButton ID="rBtnOrderTypeNew" GroupName="rBtnOrderType" runat="server" /></td>
             <td class="entry_data">Re-Order <asp:RadioButton ID="rBtnOrderTypeReDo" GroupName="rBtnOrderType" runat="server" /></td>
             <td class="entry_label">Change File <asp:CheckBox ID="chkBxChangeFile" runat="server" /></td>
             <td class="entry_data">Redo: <asp:TextBox ID="txtRedoPct" runat="server" BorderWidth="1" MaxLength="3" Width="40px" />%</td>
             <td class="entry_label">Belongs To Set <asp:TextBox ID="txtBelongsToSet" runat="server" BorderWidth="1" /></td>
             <td class="entry_data">Old Core<asp:CheckBox ID="chkBxOldCore" runat="server" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2" rowspan="2">5.Product Specs (mm)</td>
             <td class="entry_label">Product Width</td>
            <td class="entry_data"><asp:TextBox ID="txtProdWidth" runat="server" BorderWidth="1" Text="1120" /></td>
             <td class="entry_label">Product Height</td>
            <td class="entry_data"><asp:TextBox ID="txtProdHeight" runat="server" BorderWidth="1" Text="980" /></td>
        </tr>
        <tr>
             <td class="entry_label">Width Stretch</td>
            <td class="entry_data"><asp:TextBox ID="txtWidthStretch" runat="server" BorderWidth="1" /></td>
             <td class="entry_label">Height Stretch</td>
            <td class="entry_data"><asp:TextBox ID="txtHeightStretch" runat="server" BorderWidth="1" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">6.Arrangement on Cyl.</td>
             <td class="entry_label">Length Dir. Repeats</td>
            <td class="entry_data"><asp:TextBox ID="txtLengthRepeats" runat="server" BorderWidth="1" Text="1" /></td>
             <td class="entry_label">Circum. Dir. Repeats</td>
            <td class="entry_data"><asp:TextBox ID="txtCircumRepeats" runat="server" BorderWidth="1" Text="1" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">7.Printing Web (mm)</td>
             <td class="entry_label">Web Print Width</td>
            <td class="entry_data"><asp:TextBox ID="txtWebPrintWidth" runat="server" BorderWidth="1" Text="1120" /></td>
             <td class="entry_label">Total Web Width</td>
            <td class="entry_data"><asp:TextBox ID="txtWebTotalWidth" runat="server" BorderWidth="1" Text="1145" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">8.Cylinder (mm)</td>
             <td class="entry_label">Cyl. Length</td>
            <td class="entry_data"><asp:TextBox ID="txtCylLength" runat="server" BorderWidth="1" Text="1220" /></td>
             <td class="entry_label">Cyl. Circumference</td>
            <td class="entry_data"><asp:TextBox ID="txtCylCircum" runat="server" BorderWidth="1" Text="980" /></td>
        </tr>
        <tr>
            <td class="entry_label" rowspan="2">9.Eye Mark <asp:CheckBox ID="chkBxEyeMark" runat="server"/></td>
             <td class="entry_label" colspan="2">Dimension (mm)</td>
             <td class="entry_label">Color</td>
             <td class="entry_label">EM Sign</td>
             <td class="entry_data">Location: 1-sided<asp:RadioButton ID="rBtnEMLoc1Side" GroupName="rBtnEMLoc" runat="server"/>  2-sided<asp:RadioButton ID="rBtnEMLoc2Side" GroupName="rBtnEMLoc" runat="server" /></td>
        </tr>
        <tr>
             <td class="entry_data">Height: <asp:TextBox ID="txtEMHeight" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="5" /></td>
             <td class="entry_data">Width: <asp:TextBox ID="txtEMWidth" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="10" /></td>
             <td class="entry_data"><asp:TextBox ID="txtEMColor" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="K" /></td>
             <td class="entry_data"><asp:TextBox ID="txtEMSign" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" /></td>
             <td class="entry_data">Top-Down (1/2)<asp:RadioButton ID="rBtnEMLocTopDown" GroupName="rBtnEMLoc" runat="server" />  Bottom<asp:RadioButton ID="rBtnEMLocBottom" GroupName="rBtnEMLoc" runat="server" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">10.Key Hole: Standard<asp:RadioButton ID="rBtnKeyHoleStd" GroupName="rBtnKeyHole" runat="server" /></td>
             <td class="entry_label">Other<asp:RadioButton ID="rBtnKeyHoleOther" GroupName="rBtnKeyHole" runat="server" /><asp:TextBox ID="txtKeyHoleOther" runat="server" BorderWidth="1" Width="120px" /></td>
             <td class="entry_data" colspan="3">Inner Dia:<asp:TextBox ID="txtKHInnerDia" Width="40px" runat="server" BorderWidth="1"/> Outer Dia:<asp:TextBox ID="txtKHOuterDia" Width="40px" runat="server" BorderWidth="1"/> Angle:<asp:TextBox ID="txtKHAngle" Width="40px" runat="server" BorderWidth="1"/> Keyway: <asp:TextBox ID="txtKHKeyway" Width="60px" runat="server" BorderWidth="1"/></td>
        </tr>
        <tr>
            <td class="entry_label">11. Color Count:</td>
             <td class="entry_data"><asp:TextBox ID="txtColorCount" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" /></td>
             <td class="entry_label">Cyl. Count: </td>
             <td class="entry_data"><asp:TextBox ID="txtCylCount" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" /></td>
             <td class="entry_label">12.Print Method: </td>
             <td class="entry_data">Surface<asp:RadioButton ID="rBtnMethodSurface" GroupName="rBtnMethod" runat="server"/> Reverse<asp:RadioButton ID="rBtnMethodReserve" GroupName="rBtnMethod" runat="server"/></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="6">1-2-3-4-5-6-7-8-9-10-11-12</td>
        </tr>
        <tr>
            <td class="entry_data" colspan="6"><asp:TextBox ID="txtColorList" runat="server" BorderWidth="1" Text="KCMYW" /></td>
        </tr>
        <tr>
            <td class="entry_label">13. Registration Mark:</td>
             <td class="entry_data" colspan="5">Standard<asp:RadioButton ID="rBtnRegMarkStd" GroupName="rBtnRegMark" runat="server"/> Other<asp:RadioButton ID="rBtnRegMarkOther" GroupName="rBtnRegMark" runat="server"/> <asp:TextBox ID="txtRegMarkOther" runat="server" BorderWidth="1" Width="120px" /></td>
        </tr>
        <tr>
            <td class="entry_label">14. Splitting Line:<asp:CheckBox ID="chkBxSplitLine" runat="server" /></td>
             <td class="entry_data">Size(mm):<asp:TextBox ID="txtSplitLineSize" runat="server" BorderWidth="1" Width="120px" /></td>
             <td class="entry_data">2-sided<asp:CheckBox ID="chkBxSplitLine2Side" runat="server"/></td>
             <td class="entry_data">Color:<asp:TextBox ID="txtSplitLineColor" runat="server" BorderWidth="1" Width="40px" /></td>
            <td class="entry_label">15. Customer Code:</td>
             <td class="entry_data"><asp:TextBox ID="txtCustCode" runat="server" BorderWidth="1" Width="120px" /></td>
        </tr>
        <tr>
            <td class="entry_label">16.Printing Material:</td>
            <td class="entry_data" colspan="4"><asp:DropDownList ID="ddlPrintMaterial" runat="server">
                <asp:ListItem Text="OPP" Value="OPP" />
                <asp:ListItem Text="PP" Value="PP" />
                <asp:ListItem Text="PA" Value="PA" />
                <asp:ListItem Text="PET" Value="PET" />
                <asp:ListItem Text="Paper" Value="PAPER" />
                <asp:ListItem Text="Wallpaper" Value="WALLPAPER" />
                <asp:ListItem Text="HDPE" Value="HDPE" />
                <asp:ListItem Text="LDPE" Value="LDPE" />
                <asp:ListItem Text="PVC" Value="PVC" />
                <asp:ListItem Text="Wood" Value="WOOD" />
                <asp:ListItem Text="Aluminium" Value="AL" />
                <asp:ListItem Text="Shrinking Film" Value="FILM" />
            </asp:DropDownList></td>
            <td class="entry_label">Other: <asp:TextBox ID="txtMaterialOther" runat="server" BorderWidth="1" Width="120px" /></td>
        </tr>
        <tr>
            <td class="entry_label">17.Result Based On:</td>
            <td class="entry_data" colspan="4">Graphic Proof<asp:RadioButton ID="rBtnResultGraphic" GroupName="rBtnResult" runat="server"/> Printing Sample<asp:RadioButton ID="rBtnResultSample" GroupName="rBtnResult" runat="server"/> Fingerprint<asp:RadioButton ID="rBtnResultFp" GroupName="rBtnResult" runat="server"/></td>
            <td class="entry_label">Other: <asp:TextBox ID="txtResultOther" runat="server" BorderWidth="1" Width="120px" /></td>
        </tr>
        <tr>
            <td class="entry_label">Image Orientation: </td>
            <td class="entry_data" colspan="5">
                <asp:RadioButton ID="rBtnOrientUp" GroupName="rBtnOrient" Text="Up" runat="server"/>
                <asp:RadioButton ID="rBtnOrientDown" GroupName="rBtnOrient" Text="Down" runat="server"/>
                <asp:RadioButton ID="rBtnOrientLeft" GroupName="rBtnOrient" Text="Left" runat="server"/>
                <asp:RadioButton ID="rBtnOrientRight" GroupName="rBtnOrient" Text="Right" runat="server"/>
                <asp:RadioButton ID="rBtnOrientOther" GroupName="rBtnOrient" Text="Other" runat="server"/> <asp:TextBox ID="txtOrientOther" runat="server" BorderWidth="1" Width="120px" /></td>
        </tr>
        <tr>
            <td class="entry_label">Receiving Staff:</td>
             <td class="entry_data"><asp:TextBox ID="txtCreatedBy" runat="server" BorderWidth="1" Width="120px" /></td>
             <td class="entry_label">Delivery Date:</td>
             <td class="entry_data"><asp:Calendar ID="calDeliveryDate" runat="server" /></td>
            <td class="entry_label">Priority:</td>
             <td class="entry_data"><asp:DropDownList ID="ddlPriority" runat="server">
                <asp:ListItem Text="MEDIUM" Value="MEDIUM" Selected="True"/>
                <asp:ListItem Text="HIGH" Value="HIGH"/>
                <asp:ListItem Text="LOW" Value="LOW"/>
             </asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

