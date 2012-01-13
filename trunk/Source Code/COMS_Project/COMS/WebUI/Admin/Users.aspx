<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebUI.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <ul>
        <li><asp:TextBox ID="txtBxSearchKey" runat="server" 
                Width="150px" ToolTip="Search by staff code" /></li>
        <li><asp:LinkButton ID="lnkSearch" runat="server" OnClick="lnkSearch_Click">Search</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click">Save</asp:LinkButton></li>
        <li><asp:LinkButton ID="lnkDelete" runat="server" onclick="lnkDelete_Click">Delete</asp:LinkButton></li>
</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
    
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    
    <asp:GridView ID="gvUserInfo" runat="server" 
        onrowdatabound="gvUserInfo_RowDataBound" ViewStateMode="Enabled" Width="100%" 
        onrowcommand="gvUserInfo_RowCommand" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField>
               <ItemTemplate>
                    <asp:CheckBox ID="chk2ID" runat="server" />
                    &nbsp;<asp:LinkButton ID="lnkEdit" runat="server">edit</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="staff_code" HeaderText="Staff Code" />
            <asp:BoundField DataField="barcode" HeaderText="Bar Code" />
            <asp:BoundField DataField="surname" HeaderText="Surname" />
            <asp:BoundField DataField="given_name" HeaderText="Name" />
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
&nbsp;<table class="entry_table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="entry_label">
                Name
            </td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtName" style="width:200px;" runat="server"></asp:TextBox>
            </td>
            <td class="entry_label">
                Surname
            </td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtSurname" style="width:200px;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Staff Code<span class="errorMsg" style="font-family: Arial">*</span></td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtStaffCode" style="width:200px;" 
                    runat="server" ToolTip="Compulsory field"></asp:TextBox>
            </td>
            <td class="entry_label">
                Bar Code</td>
            <td class="entry_data">
             <asp:TextBox BorderColor="black" ID="txtBarCode" style="width:200px;" runat="server"></asp:TextBox>
             </td>
        </tr>
        <tr>
            <td class="entry_label">
                Department</td>
            <td class="entry_data" style="table-layout: fixed">
                <asp:DropDownList ID="DepartmentList" runat="server">
                </asp:DropDownList>
            </td>
            <td class="entry_label">
                Position</td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtPosition" style="width:200px;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="entry_label">
                Username<span class="errorMsg" style="font-family: Arial">*</span></td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtUsername" style="width:200px;" 
                    runat="server" ToolTip="Compulsory field"></asp:TextBox>
            </td>
            <td class="entry_label">
                Password<span class="errorMsg" style="font-family: Arial">*</span>
            </td>
            <td class="entry_data">
            <asp:TextBox BorderColor="black" ID="txtPassword" style="width:200px;" runat="server"></asp:TextBox>
            </td>
        </tr>
        </table>
        <asp:Literal ID="LitStatus" runat="server"></asp:Literal>
        <table>
        <tr>
        <td class="entry_data">
                <div style="width: 100%; height: 150px; overflow: scroll;">
                    <asp:GridView ID="gvAccess" runat="server" Width="566px" CellPadding="4" GridLines="None"
                        onrowdatabound="gvAccess_RowDataBound" CssClass="grid" ForeColor="#333333" 
                        ToolTip="Compulsory field">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkID" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="Assigned Roles" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        </table>
            <asp:HiddenField ID="hPageState" runat="server" Value="NEW" />
            <asp:HiddenField ID="hUpdateID" runat="server" Value="" />
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ModuleName">
                        <asp:Literal ID="ltrModule_name" runat="server"></asp:Literal>
</asp:Content>

