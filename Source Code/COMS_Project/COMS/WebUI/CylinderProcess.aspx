<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="CylinderProcess.aspx.cs" Inherits="WebUI.CylinderProcess" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    Update Cylinder Status</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <div class="update_cylinder">
        <br />
        <br />
        <asp:Panel ID="pnlCylinderBarCode" runat="server" 
            meta:resourcekey="pnlCylinderBarCodeResource1">
            &nbsp; Scan Cylinder Barcode to Start Process<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtScanCylinderCode" runat="server" BorderColor="Black" MaxLength="50"
                Width="336px" AutoPostBack="True" 
                ontextchanged="txtScanCylinderCode_TextChanged" 
                meta:resourcekey="txtScanCylinderCodeResource1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtScanCylinderCode" ErrorMessage="RequiredFieldValidator" 
                SetFocusOnError="True" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlPnlActionButtons" runat="server"  Visible="False" 
            meta:resourcekey="pnlPnlActionButtonsResource1">
            &nbsp; Select Actions
            <br />
            &nbsp;<asp:Button ID="btnProceed" runat="server" Text="Proceed" Width="175px" 
                onclick="ActionCommand" meta:resourcekey="btnProceedResource1" />
            &nbsp;<asp:Button ID="btnReject" runat="server" Text="Reject" Width="175px" 
                onclick="ActionCommand" meta:resourcekey="btnRejectResource1" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="175px" 
                onclick="ActionCommand" meta:resourcekey="btnCancelResource1" />
        </asp:Panel>
        <asp:Panel ID="pnlSelectSteps" runat="server"  Visible="False" 
            meta:resourcekey="pnlSelectStepsResource1">
            &nbsp;Select Available Steps<br />
            &nbsp;<asp:ListBox ID="lstSteps" runat="server" CssClass="step_selection" 
                Width="100%" meta:resourcekey="lstStepsResource1">
            </asp:ListBox>
            <br />
            <br />
            <asp:Button ID="btnStepOK" runat="server" Text="OK" Width="175px" 
                onclick="btnStepOK_Click" meta:resourcekey="btnStepOKResource1" />
            &nbsp;
            <asp:Button ID="btnCancelProcess" runat="server" 
                onclick="btnCancelProcess_Click" Text="Cancel Process" />
            &nbsp;&nbsp;&nbsp;
        </asp:Panel>
        <asp:Panel ID="pnlCylinderCodeEnd" runat="server"  Visible="False" 
            meta:resourcekey="pnlCylinderCodeEndResource1">
            &nbsp; Scan Cylinder Barcode To End the Process<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtCylinderCodeToEnd" runat="server" 
    BorderColor="Black" MaxLength="50"
                Width="336px" AutoPostBack="True" 
                ontextchanged="txtCylinderCodeToEnd_TextChanged" 
                meta:resourcekey="txtCylinderCodeToEndResource1"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="pnlEmployeeBarCode" runat="server"  Visible="False" 
            meta:resourcekey="pnlEmployeeBarCodeResource1">
            &nbsp;&nbsp; Damage Reasons<br /> &nbsp;
            <asp:DropDownList ID="drpDamageReason" runat="server" Height="16px" 
                meta:resourcekey="drpReasonsResource1" Width="338px">
            </asp:DropDownList>
            <br />
            &nbsp;<br /> &nbsp; Work Status<br /> &nbsp;&nbsp;<asp:DropDownList ID="drpWorkStatus" 
                runat="server" Height="16px" meta:resourcekey="drpReasonsResource1" 
                Width="338px">
                <asp:ListItem Selected="True">Completed</asp:ListItem>
                <asp:ListItem>Damage</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            &nbsp; Scan Employee Barcode To Complete Process<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtEmployeeBarCode" runat="server" 
    BorderColor="Black" MaxLength="50"
                Width="336px" AutoPostBack="True" 
                ontextchanged="txtEmployeeBarCode_TextChanged" 
                meta:resourcekey="txtEmployeeBarCodeResource1"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="pnlErrorReason" runat="server" Visible="False" 
            meta:resourcekey="pnlErrorReasonResource1">
            &nbsp; Select Rejected Reason
            <br />
            &nbsp;&nbsp;<asp:DropDownList ID="drpReasons" runat="server" Height="16px" 
                meta:resourcekey="drpReasonsResource1" Width="338px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp; Scan Employee Barcode To Report Previous Damage<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtEmployeeBarCodeToReport" runat="server" AutoPostBack="True" 
                BorderColor="Black" MaxLength="50" 
                meta:resourcekey="txtEmployeeBarCodeToReportResource1" 
                ontextchanged="txtEmployeeBarCodeToReport_TextChanged" Width="336px"></asp:TextBox>
            &nbsp;</asp:Panel>
            <br />
        &nbsp;<asp:Label ID="ErrorMessage" runat="server" Font-Bold="True" 
            ForeColor="Red" meta:resourcekey="ErrorMessageResource1"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Cylinder&nbsp; BarCode
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="Black" ID="tCylinderBarcode" runat="server" MaxLength="50"
                    Width="336px" meta:resourcekey="tCylinderBarcodeResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Step Perform
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="Black" ID="tStep" runat="server" MaxLength="50" 
                    Width="336px" meta:resourcekey="tStepResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Description
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="Black" ID="tDesc" runat="server" MaxLength="50" 
                    Width="336px" meta:resourcekey="tDescResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Instruction
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="Black" ID="tInstruct" runat="server" MaxLength="50" Width="336px"
                    Height="107px" TextMode="MultiLine" meta:resourcekey="tInstructResource1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Notes
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="Black" ID="tNote" runat="server" MaxLength="50" Width="336px"
                    Height="106px" TextMode="MultiLine" meta:resourcekey="tNoteResource1"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
