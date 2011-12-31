<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ErrorManagement.aspx.cs" Inherits="WebUI.Admin.ErrorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    <p>Error Code Management</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:LinkButton ID="lnkSave" runat="server" onclick="lnkSave_Click">Save</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkDelete" runat="server" onclick="lnkDelete_Click">Delete</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                New Error Code Message</td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" ID="txtErrorCode" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
<script type="text/javascript">    

    var checkedList = "";
    function updateCheckList(checkBox) {

        if (checkBox.checked) {
            if (checkedList != "") {
                checkedList = checkedList + "," + checkBox.value
            } else {
                checkedList = checkBox.value;
            }
        } else {
            if (checkedList != "") {
                checkedList = checkedList.replace(checkBox.value, "");
                checkedList = checkedList.replace(",,", ",");
                if (checkedList == ",") { checkedList = ""; }
            }
        }
    }
</script>
    <asp:GridView ID="gvErrorMsgs" runat="server" 
    onrowdatabound="gvErrorMsgs_RowDataBound" ViewStateMode="Enabled" Width="100%">
        <Columns>
            <asp:TemplateField></asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Error Message" />
        </Columns>
    </asp:GridView>
</asp:Content>
