<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SetLanguage.aspx.cs" Inherits="WebUI.SetLanguage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleName" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
<ul>
        <li>
            <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click">Save</asp:LinkButton></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="InputPlaceHolder" runat="server">
    <p>
        <asp:DropDownList ID="ddlLanguage" runat="server" Width="200px">
            <asp:ListItem Selected="True" Value="EN">English</asp:ListItem>
            <asp:ListItem Value="VN">Vietnam</asp:ListItem>
        </asp:DropDownList>
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OutputPlaceHolder" runat="server">
</asp:Content>
