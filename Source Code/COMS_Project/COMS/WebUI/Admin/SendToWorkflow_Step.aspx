<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SendToWorkflow_Step.aspx.cs" Inherits="WebUI.Admin.SendToWorkflow_Step" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    Send to Workflow / Step
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li>
            <asp:LinkButton ID="lnkSend" runat="server" onclick="lnkSend_Click" >Send</asp:LinkButton></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Send to Workflow
            </td>
            <td class="entry_data">
                <asp:DropDownList ID="ddlWorkflow" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlWorkflow_SelectedIndexChanged" Width="250px">
                </asp:DropDownList>
                <asp:HiddenField ID="hidCylinderId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Send to Step</td>
            <td class="entry_data">
                <asp:DropDownList ID="ddlStep" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Cylinder Barcode To Send<asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtCylinderBarCode" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;</td>
            <td class="entry_data">
                <asp:TextBox ID="txtCylinderBarCode" runat="server" ReadOnly="True" 
                    Width="250px" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Remark<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRemark" ErrorMessage=" *" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="entry_data">
                <asp:TextBox ID="txtRemark" runat="server" Height="111px" MaxLength="255" 
                    TextMode="MultiLine" Width="250px"></asp:TextBox>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    <asp:GridView ID="gvResult" runat="server" CellPadding="4" CssClass="grid" 
        ForeColor="#333333" GridLines="None" OnRowCommand="gvResult_RowCommand" 
        OnRowDataBound="gvResult_RowDataBound" ViewStateMode="Enabled" 
    Width="100%" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSend" runat="server" CausesValidation="False">send</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="cylinderbarcode" HeaderText="Cylinder Barcode" />
            <asp:BoundField DataField="department" HeaderText="Department" />
            <asp:BoundField DataField="errordescription" HeaderText="Error Description" />
            <asp:BoundField DataField="remark" HeaderText="Remark" />
            <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
