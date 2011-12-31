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

    function updateCheckList(checkBox) {

        var rownum =0;
        rownum = checkBox.id.charAt(checkBox.id.length - 1);
        if (checkBox.checked) {
            document.getElementById("OutputPlaceHolder_gvErrorMsgs_checkedList_" + rownum).setAttribute("value", checkBox.value);
        } else {
            document.getElementById("OutputPlaceHolder_gvErrorMsgs_checkedList_" + rownum).setAttribute("value", "");
        }
    }
</script>
    <asp:GridView ID="gvErrorMsgs" runat="server" 
    onrowdatabound="gvErrorMsgs_RowDataBound" ViewStateMode="Enabled" Width="100%">
        <Columns>
            <asp:TemplateField>
               <ItemTemplate>
                    <asp:HiddenField ID="checkedList" runat="server" Value="" />
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Error Message" />
        </Columns>
    </asp:GridView>
</asp:Content>
