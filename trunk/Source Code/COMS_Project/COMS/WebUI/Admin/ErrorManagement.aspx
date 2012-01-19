<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ErrorManagement.aspx.cs" Inherits="WebUI.Admin.ErrorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
    <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
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
                <asp:Literal ID="ltrErrorMessage" runat="server"></asp:Literal>
            </td>
            <td class="entry_data">
                <asp:TextBox BorderColor="black" maxlength="100" 
                    style="border-color:Black;width:336px;" ID="txtErrorCode" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hPageState" runat="server" Value="NEW" />
    <asp:HiddenField ID="hUpdateID" runat="server" Value="" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">

    <asp:GridView ID="gvErrorMsgs" runat="server" 
    onrowdatabound="gvErrorMsgs_RowDataBound" ViewStateMode="Enabled" Width="100%" 
        onrowcommand="gvErrorMsgs_RowCommand" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
               <ItemTemplate>
                    <asp:CheckBox ID="chkID" runat="server" />
                    &nbsp;<asp:LinkButton ID="lnkEdit" runat="server">edit</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderStyle-HorizontalAlign="Left" 
                HeaderText="Error Message" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
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
