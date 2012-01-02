<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebUI.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:LinkButton ID="lnkSearch" runat="server" onclick="lnkSearch_Click">Search</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkSave" runat="server">Save</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkDelete" runat="server">Delete</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Name
            </td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td class="entry_label">
                Surname
            </td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtSurname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Staff Code</td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtStaffCode" runat="server"></asp:TextBox>
            </td>
            <td class="entry_label">
                Bar Code</td>
            <td class="entry_data">
             <asp:TextBox BorderColor="black" ID="txtBarCode" runat="server"></asp:TextBox>
             </td>
        </tr>
        <tr>
            <td class="entry_label">
                Position</td>
            <td class="entry_data" style="table-layout: fixed">
            <asp:TextBox BorderColor="black" ID="txtPosition" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Username</td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtUsername" runat="server"></asp:TextBox>
            </td>
            <td class="entry_label">
                Password
            </td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    
    <asp:GridView ID="gvUserInfo" runat="server" 
        onrowdatabound="gvUserInfo_RowDataBound" ViewStateMode="Enabled" Width="50%" 
        onrowcommand="gvUserInfo_RowCommand">
        <Columns>
            <asp:TemplateField>
               <ItemTemplate>
                    <asp:CheckBox ID="chkID" runat="server" />
                    &nbsp;<asp:LinkButton ID="lnkEdit" runat="server">edit</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="staff_code" HeaderText="Staff Code" />
            <asp:BoundField DataField="barcode" HeaderText="Bar Code" />
            <asp:BoundField DataField="surname" HeaderText="Surname" />
            <asp:BoundField DataField="given_name" HeaderText="Name" />
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
                        <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

