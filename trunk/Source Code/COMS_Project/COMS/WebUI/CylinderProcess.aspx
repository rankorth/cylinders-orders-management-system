<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="CylinderProcess.aspx.cs" Inherits="WebUI.CylinderProcess" %>

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
        <asp:Panel ID="pnlCylinderBarCode" runat="server">
            &nbsp; Scan Cylinder Barcode to Start Process<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtScanCylinderCode" runat="server" BorderColor="black" MaxLength="50"
                Width="336px" AutoPostBack="True" 
                ontextchanged="txtScanCylinderCode_TextChanged"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="pnlPnlActionButtons" runat="server"  Visible="False">
            &nbsp; Select Actions
            <br />
            &nbsp;<asp:Button ID="btnProceed" runat="server" Text="Proceed" Width="175px" 
                onclick="ActionCommand" />
            &nbsp;<asp:Button ID="btnReject" runat="server" Text="Reject" Width="175px" 
                onclick="ActionCommand" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="175px" 
                onclick="ActionCommand" />
        </asp:Panel>
        <asp:Panel ID="pnlSelectSteps" runat="server"  Visible="False">
            &nbsp;Select Available Steps<br />
            &nbsp;<asp:ListBox ID="lstSteps" runat="server" CssClass="step_selection" Width="100%">
            </asp:ListBox>
            <br />
            <br />
            <asp:Button ID="btnStepOK" runat="server" Text="OK" Width="175px" 
                onclick="btnStepOK_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlCylinderCodeEnd" runat="server"  Visible="False">
            &nbsp; Scan Cylinder Barcode To End the Process<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtCylinderCodeToEnd" runat="server" 
    BorderColor="black" MaxLength="50"
                Width="336px" AutoPostBack="True" 
                ontextchanged="txtCylinderCodeToEnd_TextChanged"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="pnlEmployeeBarCode" runat="server"  Visible="False">
            &nbsp; Scan Employee Barcode<br />&nbsp;&nbsp;<asp:TextBox 
                ID="txtEmployeeBarCode" runat="server" 
    BorderColor="black" MaxLength="50"
                Width="336px" AutoPostBack="True" 
                ontextchanged="txtEmployeeBarCode_TextChanged"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="pnlErrorReason" runat="server" Visible="False">
            &nbsp; Select Rejected Reason<br />&nbsp;&nbsp;<asp:DropDownList ID="drpReasons" 
                runat="server" Height="16px" Width="338px">
            </asp:DropDownList>
            &nbsp;<asp:Button ID="btnSubmitErrorOK" runat="server" Text="OK" Width="101px" 
                onclick="btnSubmitErrorOK_Click" />
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Cylinder&nbsp; BarCode
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="tCylinderBarcode" runat="server" MaxLength="50"
                    Width="336px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Step Perform
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="tStep" runat="server" MaxLength="50" 
                    Width="336px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Description
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="tDesc" runat="server" MaxLength="50" 
                    Width="336px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Instruction
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="tInstruct" runat="server" MaxLength="50" Width="336px"
                    Height="107px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Notes
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="tNote" runat="server" MaxLength="50" Width="336px"
                    Height="106px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
