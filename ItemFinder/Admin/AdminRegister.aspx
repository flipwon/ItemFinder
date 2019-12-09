<%@ Page Title="" Language="C#" MasterPageFile="~/ItemFinder.Master" AutoEventWireup="true" CodeBehind="AdminRegister.aspx.cs" Inherits="ItemFinder.Admin.AdminRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register a User (Admin)</h1>
    <div>
        <label>Username:</label>
        <asp:TextBox runat="server" Id="TxtUser"></asp:TextBox>
    </div>

    <div>
        <label>Password:</label>
        <asp:TextBox runat="server" Id="TxtPassword" TextMode="Password"></asp:TextBox>
    </div>

    <div>
        <label>Confirm Password:</label>
        <asp:TextBox runat="server" Id="TxtPasswordConfirm" TextMode="Password"></asp:TextBox>
    </div>
    
    <!--Had this active to make the first root user-->
    <div>
        <label>Role:</label>
        <asp:DropDownList ID="DrpRole" runat="server">
            <asp:ListItem Selected="True">Admin</asp:ListItem>
            <asp:ListItem>User</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div>
        <asp:Button runat="server" Id="BtnRegister" Text="Register" OnClick="BtnRegister_OnClick"></asp:Button>
    </div>

</asp:Content>
