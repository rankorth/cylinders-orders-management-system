<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DisplayOrder.aspx.cs" Inherits="WebUI.Admin.DisplayOrder" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:LinkButton ID="lnkSave" runat="server" onclick="lnkSave_Click" CausesValidation="true">Save</asp:LinkButton>
            <asp:ConfirmButtonExtender ID="lnkSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Do you want to save/update this order?" Enabled="True" TargetControlID="lnkSave">
            </asp:ConfirmButtonExtender>
        </li>
        <li><asp:LinkButton ID="lnkPrintBarcode" runat="server" CausesValidation="false">Print Barcode</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkStartProd" runat="server" onclick="lnkStartProd_Click" CausesValidation="false" >Start Production</asp:LinkButton>
            <asp:ConfirmButtonExtender ID="lnkStartProd_ConfirmButtonExtender" runat="server" 
                ConfirmText="Do you want to start production?" Enabled="True" TargetControlID="lnkStartProd">
            </asp:ConfirmButtonExtender>
        </li>
        <li><asp:LinkButton ID="lnkStopProd" runat="server" onclick="lnkStopProd_Click" CausesValidation="false" >Stop Production</asp:LinkButton>
            <asp:ConfirmButtonExtender ID="lnkStopProd_ConfirmButtonExtender" runat="server" 
                ConfirmText="Do you want to stop production?" Enabled="True" TargetControlID="lnkStopProd">
            </asp:ConfirmButtonExtender>
        </li>
        <li><asp:LinkButton ID="lnkDelete" runat="server" onclick="lnkDelete_Click" CausesValidation="false" >Delete Order</asp:LinkButton>
            <asp:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Do you want to delete this order?" Enabled="True" TargetControlID="lnkDelete">
            </asp:ConfirmButtonExtender>
        </li>
        <li><asp:LinkButton ID="lnkBack" runat="server" onclick="lnkBack_Click" CausesValidation="false" >Back</asp:LinkButton></li>
</ul>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InputPlaceHolder" runat="server">

<asp:HiddenField ID="hdOrderId" runat="server" />
<asp:HiddenField ID="hdOrderCode" runat="server" />

<table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label" colspan="6" align="left"><asp:Label ID="lblMsg" CssClass="errorMsg" runat="server" /></td>
        </tr>
        <tr>
            <td class="entry_data" style="width: 78px">Date: 
                <asp:TextBox ID="txtCreateDate" 
                    runat="server" BorderWidth="1" Width="80px" MaxLength="20" />
                <asp:CalendarExtender ID="txtCreateDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtCreateDate" 
                    DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy" 
                    TodaysDateFormat="dd/MM/yyyy">
                </asp:CalendarExtender>
            </td>
            <td class="entry_data" colspan="5" align="left">
                Status: <asp:DropDownList ID="ddlOrderStatus" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="entry_label" style="width: 78px">1.Customer</td>
            <td class="entry_data" colspan="3"><asp:DropDownList ID="ddlCustomer" 
                    runat="server" style="margin-bottom: 0px"></asp:DropDownList></td>
             <td class="entry_label" style="width: 80px">Set Code</td>
            <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtSetCode" runat="server" BorderWidth="1" 
                    MaxLength="10" Width="80px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtSetCode" SetFocusOnError="True" ForeColor="Red"/>
                    </td>
        </tr>
        <tr>
            <td class="entry_label" style="width: 78px">2.Contact Person</td>
            <td class="entry_data" style="width: 98px"><asp:TextBox ID="txtCustomerRep" runat="server" 
                    BorderWidth="1" MaxLength="50" Width="80px" /></td>
             <td class="entry_label" style="width: 70px">Cylinder Type</td>
            <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtCylType" 
                    runat="server" BorderWidth="1" Width="40px" MaxLength="50" /></td>
             <td class="entry_label" style="width: 80px">Price Type</td>
            <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtPriceType" runat="server" 
                    BorderWidth="1" MaxLength="10" Width="80px"/></td>
        </tr>
        <tr>
            <td class="entry_label" style="width: 78px">3.Product Name</td>
            <td class="entry_data" colspan="5"><asp:TextBox ID="txtProdName" runat="server" 
                    BorderWidth="1" Width="500px" MaxLength="255" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtProdName" SetFocusOnError="True" ForeColor="Red"/></td>
        </tr>
        <tr>
            <td class="entry_label" style="width: 78px">4.<asp:RadioButton ID="rBtnOrderTypeNew" GroupName="rBtnOrderType" runat="server" Text="New Order" TextAlign="Left"  Checked="true"/></td>
             <td class="entry_data" style="width: 98px"><asp:RadioButton ID="rBtnOrderTypeReDo" GroupName="rBtnOrderType" runat="server" Text="Re-Order" TextAlign="Left" /></td>
             <td class="entry_label" style="width: 70px"><asp:CheckBox ID="chkBxChangeFile" runat="server" Text="Change File" TextAlign="Left" /></td>
             <td class="entry_data" style="width: 101px">Redo: <asp:TextBox ID="txtRedoPct" runat="server" BorderWidth="1" MaxLength="3" Width="40px" />%</td>
             <td class="entry_label" style="width: 80px">Belongs To Set <asp:TextBox ID="txtBelongsToSet" 
                     runat="server" BorderWidth="1" MaxLength="10" Width="80px" /></td>
             <td class="entry_data" style="width: 80px">Core Type: <asp:DropDownList ID="ddlCoreType" runat="server"/></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2" rowspan="2">5.Product Specs (mm)</td>
             <td class="entry_label" style="width: 70px">Product Width</td>
            <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtProdWidth" runat="server" 
                    BorderWidth="1" Text="" MaxLength="7" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtProdWidth" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtProdWidth" runat="server" 
                    ControlToValidate="txtProdWidth" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 80px">Product Height</td>
            <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtProdHeight" runat="server" 
                    BorderWidth="1" Text="" MaxLength="7" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtProdHeight" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtProdHeight" runat="server" 
                    ControlToValidate="txtProdHeight" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
        </tr>
        <tr>
             <td class="entry_label" style="width: 70px">Width Stretch</td>
            <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtWidthStretch" runat="server" 
                    BorderWidth="1" MaxLength="6" Text="0" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtWidthStretch" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtWidthStretch" runat="server" 
                    ControlToValidate="txtWidthStretch" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 80px">Height Stretch</td>
            <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtHeightStretch" runat="server" 
                    BorderWidth="1" MaxLength="6" Text="0" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtHeightStretch" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtHeightStretch" runat="server" 
                    ControlToValidate="txtHeightStretch" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">6.Arrangement on Cyl.</td>
             <td class="entry_label" style="width: 70px">Length Dir. Repeats</td>
            <td class="entry_data" style="width: 101px">
                <asp:TextBox ID="txtLengthRepeats" runat="server" 
                    BorderWidth="1" Text="1" MaxLength="4" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtLengthRepeats" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtLengthRepeats" runat="server" 
                    ControlToValidate="txtLengthRepeats" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 80px">Circum. Dir. Repeats</td>
            <td class="entry_data" style="width: 80px">
                <asp:TextBox ID="txtCircumRepeats" runat="server" 
                    BorderWidth="1" Text="1" MaxLength="4" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtCircumRepeats" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtCircumRepeats" runat="server" 
                    ControlToValidate="txtCircumRepeats" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">7.Printing Web (mm)</td>
             <td class="entry_label" style="width: 70px">Web Print Width</td>
            <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtWebPrintWidth" runat="server" 
                    BorderWidth="1" Text="" MaxLength="7" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtWebPrintWidth" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtWebPrintWidth" runat="server" 
                    ControlToValidate="txtWebPrintWidth" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 80px">Total Web Width</td>
            <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtWebTotalWidth" runat="server" 
                    BorderWidth="1" Text="" MaxLength="7" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtWebTotalWidth" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtWebTotalWidth" runat="server" 
                    ControlToValidate="txtWebTotalWidth" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">8.Cylinder (mm)</td>
             <td class="entry_label" style="width: 70px">Cyl. Length</td>
            <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtCylLength" runat="server" 
                    BorderWidth="1" Text="" MaxLength="7" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtCylLength" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtCylLength" runat="server" 
                    ControlToValidate="txtCylLength" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 80px">Cyl. Circumference</td>
            <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtCylCircum" runat="server" 
                    BorderWidth="1" Text="" MaxLength="7" Width="60px" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtCylCircum" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtCylCircum" runat="server" 
                    ControlToValidate="txtCylCircum" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
        </tr>
        <tr>
            <td class="entry_label" rowspan="2" style="width: 78px">9.<asp:CheckBox ID="chkBxEyeMark" runat="server" Text="Eye Mark" TextAlign="Left"/></td>
             <td class="entry_label" colspan="2">Dimension (mm)</td>
             <td class="entry_label" style="width: 101px">Color</td>
             <td class="entry_label" style="width: 80px">EM Sign</td>
             <td class="entry_data" style="width: 80px">Location: 
                <asp:RadioButton ID="rBtnEMLoc1Side" GroupName="rBtnEMLoc" runat="server" Text="1-sided" TextAlign="Left" Checked="true"/>  
                <asp:RadioButton ID="rBtnEMLoc2Side" GroupName="rBtnEMLoc" runat="server" Text="2-sided" TextAlign="Left" />
            </td>
        </tr>
        <tr>
             <td class="entry_data" style="width: 98px">Height: <asp:TextBox ID="txtEMHeight" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" />
                <asp:RangeValidator ID="vldTxtEMHeight" runat="server" 
                    ControlToValidate="txtEMHeight" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_data" style="width: 70px">Width: <asp:TextBox ID="txtEMWidth" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" />
                <asp:RangeValidator ID="vldTxtEMWidth" runat="server" 
                    ControlToValidate="txtEMWidth" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtEMColor" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" /></td>
             <td class="entry_data" style="width: 80px"><asp:TextBox ID="txtEMSign" runat="server" BorderWidth="1" MaxLength="4" Width="40px" Text="" /></td>
             <td class="entry_data" style="width: 80px">
                <asp:RadioButton ID="rBtnEMLocTopDown" GroupName="rBtnEMLoc" runat="server" Text="Top-down (1/2)" TextAlign="Left" />  
                <asp:RadioButton ID="rBtnEMLocBottom" GroupName="rBtnEMLoc" runat="server" Text="Bottom" TextAlign="Left" />
            </td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">10.Key Hole: <asp:RadioButton ID="rBtnKeyHoleStd" GroupName="rBtnKeyHole" runat="server" Text="Standard" TextAlign="Left" Checked="true" /></td>
             <td class="entry_label" style="width: 70px"><asp:RadioButton ID="rBtnKeyHoleOther" GroupName="rBtnKeyHole" runat="server" Text="Other" TextAlign="Left" />
                 <asp:TextBox ID="txtKeyHoleOther" runat="server" BorderWidth="1" Width="80px" 
                     MaxLength="10" /></td>
            <td class="entry_data" colspan="3">
                Inner Dia:<asp:TextBox ID="txtKHInnerDia" Width="40px" runat="server" BorderWidth="1" MaxLength="4"/> 
                <asp:RangeValidator ID="vldTxtKHInnerDia" runat="server" 
                    ControlToValidate="txtKHInnerDia" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
                Outer Dia:<asp:TextBox ID="txtKHOuterDia" Width="40px" runat="server" BorderWidth="1" MaxLength="4"/> 
                <asp:RangeValidator ID="vldTxtKHOuterDia" runat="server" 
                    ControlToValidate="txtKHOuterDia" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
                Angle:<asp:TextBox ID="txtKHAngle" Width="40px" runat="server" BorderWidth="1" MaxLength="4"/>
                <asp:RangeValidator ID="vldTxtKHAngle" runat="server" 
                    ControlToValidate="txtKHAngle" ErrorMessage="*Must be number"  MaximumValue="99999" 
                    MinimumValue="0" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
                Keyway: <asp:TextBox ID="txtKHKeyway" Width="60px" runat="server" BorderWidth="1" MaxLength="9"/>
            </td>
        </tr>
        <tr>
            <td class="entry_label" style="width: 78px">11. Color Count:</td>
             <td class="entry_data" style="width: 98px"><asp:TextBox ID="txtColorCount" runat="server" 
                     BorderWidth="1" MaxLength="2" Width="40px" Text="" 
                     ontextchanged="txtColorCount_TextChanged" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtColorCount" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtColorCount" runat="server" 
                    ControlToValidate="txtColorCount" ErrorMessage="*Must be from 1 to 12"  MaximumValue="12" 
                    MinimumValue="1" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 70px">Cyl. Count: </td>
             <td class="entry_data" style="width: 101px"><asp:TextBox ID="txtCylCount" 
                     runat="server" BorderWidth="1" 
                     MaxLength="2" Width="40px" Text="" 
                     ontextchanged="txtCylCount_TextChanged" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtCylCount" SetFocusOnError="True" ForeColor="Red"/>
                <asp:RangeValidator ID="vldTxtCylCount" runat="server" 
                    ControlToValidate="txtCylCount" ErrorMessage="*Must be from 1 to 12"  MaximumValue="12" 
                    MinimumValue="1" Type="Double" SetFocusOnError="True" ForeColor="Red"/>
            </td>
             <td class="entry_label" style="width: 80px">12.Print Method: </td>
             <td class="entry_data" style="width: 80px">
                 <asp:RadioButton ID="rBtnMethodSurface" GroupName="rBtnMethod" runat="server" Text="Surface" TextAlign="Left" Checked="true"/> 
                 <asp:RadioButton ID="rBtnMethodReserve" GroupName="rBtnMethod" runat="server" Text="Reverse" TextAlign="Left"/>
             </td>
        </tr>
        <tr>
            <td class="entry_label" colspan="6">1-2-3-4-5-6-7-8-9-10-11-12</td>
        </tr>
        <tr>
            <td class="entry_data" colspan="6"><asp:TextBox ID="txtColorList" runat="server" 
                    BorderWidth="1" Text="KCMYW" MaxLength="12" Width="100px" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">13. Registration Mark:</td>
             <td class="entry_data" colspan="4">
                <asp:RadioButton ID="rBtnRegMarkStd" GroupName="rBtnRegMark" runat="server" Text="Standard" TextAlign="Left" Checked="true"/>
                <asp:RadioButton ID="rBtnRegMarkOther" GroupName="rBtnRegMark" runat="server" Text="Other" TextAlign="Left"/> 
                 <asp:TextBox ID="txtRegMarkOther" runat="server" BorderWidth="1" Width="80px" 
                     MaxLength="10" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">14.<asp:CheckBox ID="chkBxSplitLine" runat="server" Text="Splitting Line:" TextAlign="Left" /></td>
             <td class="entry_data" colspan="2">
                Size(mm):<asp:TextBox ID="txtSplitLineSize" runat="server" 
                     BorderWidth="1" Width="80px" MaxLength="9" />
                <asp:CheckBox ID="chkBxSplitLine2Side" runat="server" Text="2-sided" TextAlign="Left"/>
                Color:<asp:TextBox ID="txtSplitLineColor" runat="server" 
                     BorderWidth="1" Width="40px" MaxLength="2" />
             </td>
            <td class="entry_label" style="width: 80px">15. Customer Code:</td>
             <td class="entry_data" style="width: 80px">
                 <asp:TextBox ID="txtCustomerCode" runat="server" BorderWidth="1" Width="60px" Enabled="false" />
                 <asp:DropDownList ID="ddlCustomerCode" runat="server" Width="60px" Visible="false"/>
            </td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">16.Printing Material:</td>
            <td class="entry_data" colspan="2"><asp:DropDownList ID="ddlPrintMaterial" runat="server">
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
            <td class="entry_label">Other:</td>
            <td class="entry_data"><asp:TextBox ID="txtPrintMaterialOther" runat="server" 
                    BorderWidth="1" Width="80px" MaxLength="10" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">17.Result Based On:</td>
            <td class="entry_data" colspan="2">
                <asp:RadioButton ID="rBtnResultGraphic" GroupName="rBtnResult" runat="server" Text="Graphic Proof" TextAlign="Left" Checked="true"/> 
                <asp:RadioButton ID="rBtnResultSample" GroupName="rBtnResult" runat="server" Text="Printing Sample" TextAlign="Left"/> 
                <asp:RadioButton ID="rBtnResultFp" GroupName="rBtnResult" runat="server" Text="Fingerprint" TextAlign="Left"/>
            </td>
            <td class="entry_label">Other:</td>
            <td class="entry_label"><asp:TextBox ID="txtResultOther" runat="server" 
                    BorderWidth="1" Width="80px" MaxLength="20" /></td>
        </tr>
        <tr>
            <td class="entry_label" colspan="2">Image Orientation: </td>
            <td class="entry_data" colspan="4">
                <asp:RadioButton ID="rBtnOrientUp" GroupName="rBtnOrient" Text="Up" runat="server" TextAlign="Left" Checked="true"/>
                <asp:RadioButton ID="rBtnOrientDown" GroupName="rBtnOrient" Text="Down" runat="server" TextAlign="Left"/>
                <asp:RadioButton ID="rBtnOrientLeft" GroupName="rBtnOrient" Text="Left" runat="server" TextAlign="Left"/>
                <asp:RadioButton ID="rBtnOrientRight" GroupName="rBtnOrient" Text="Right" runat="server" TextAlign="Left"/>
                <asp:RadioButton ID="rBtnOrientOther" GroupName="rBtnOrient" Text="Other" runat="server" TextAlign="Left"/> 
                <asp:TextBox ID="txtOrientOther" runat="server" BorderWidth="1" Width="120px" 
                    MaxLength="10" /></td>
        </tr>
        <tr>
            <td class="entry_label" style="width: 78px">Receiving Staff:</td>
             <td class="entry_data" style="width: 98px"><asp:TextBox ID="txtCreatedBy" runat="server" 
                     BorderWidth="1" Width="120px" MaxLength="20" /></td>
             <td class="entry_label" style="width: 70px">Delivery Date:</td>
             <td class="entry_data" style="width: 101px">
                 <asp:TextBox ID="txtDeliveryDate" runat="server" BorderWidth="1" 
                     ReadOnly="false" Width="80px" MaxLength="20"></asp:TextBox>
                 <asp:CalendarExtender ID="txtDeliveryDate_CalendarExtender" runat="server" 
                     Enabled="True" TargetControlID="txtDeliveryDate" Format="dd/MM/yyyy" 
                     DaysModeTitleFormat="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy">
                 </asp:CalendarExtender>
                 <asp:RequiredFieldValidator ID="vldTxtDeliveryDate2" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txtDeliveryDate" SetFocusOnError="True" ForeColor="Red"/>
                 <asp:RegularExpressionValidator ID="vldTxtDeliveryDate1" runat="server" ErrorMessage="*Must be a date" 
                    ValidationExpression="\d{2}/\d{2}/\d{4}" ControlToValidate="txtDeliveryDate" SetFocusOnError="True" ForeColor="Red"/>
            </td>
            <td class="entry_label" style="width: 80px">Priority:</td>
             <td class="entry_data" style="width: 80px"><asp:DropDownList ID="ddlPriority" runat="server"/></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

