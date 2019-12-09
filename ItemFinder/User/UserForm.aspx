<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../ItemFinder.Master" CodeBehind="UserForm.aspx.cs" Inherits="ItemFinder.UserForm" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <label>Search</label>
        <asp:TextBox ID="TxtSearch" runat="server" OnTextChanged="TxtSearch_OnTextChanged" AutoPostBack="True"></asp:TextBox>
    </div>

    <div>
        <asp:DropDownList ID="DrpSearch" runat="server"></asp:DropDownList>
    </div>

    <div>
        <asp:Button ID="BtnSearch" runat="server" Text="Button" OnClick="BtnSearch_OnClick"/>
    </div>

    <div>
        <asp:ImageButton ID="ImgMap" runat="server" Width="250px" ImageUrl="~/Images/sqljoins.jpg"/>
    </div>

    <div>
        <asp:Label ID="LblName" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <asp:Label ID="LblDept" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <asp:Label ID="LblDesc" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <asp:Label ID="LblPrice" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>

    <div>
        <asp:Button ID="BtnAddItem" runat="server" Text="Add Item" OnClick="BtnAddItem_OnClick"/>
    </div>
</asp:Content>