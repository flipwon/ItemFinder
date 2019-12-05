<%@ Page Title="" Language="C#" MasterPageFile="~/ItemFinder.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ItemFinder.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
    

    <div>
        <asp:Button runat="server" Id="BtnRegister" Text="Register" OnClick="BtnRegister_OnClick"></asp:Button>
    </div>
    
    <div>
        <asp:Button runat="server" Id="BtnLogin" Text="Login" OnClick="BtnLogin_OnClick"></asp:Button>
    </div>
    
    <asp:Label runat="server" Id="LblStatus" Text=""></asp:Label>

</asp:Content>
