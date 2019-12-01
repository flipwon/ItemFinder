<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ItemFinder.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login Page</h1>
        </div>
        <div>
            <label>User Name: </label>
            <asp:TextBox runat="server" ID="TxtUserName"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValUserNameReq" runat="server"
                                        ControlToValidate="TxtUserName" Display="Dynamic"
                                        ErrorMessage="Name Required"></asp:RequiredFieldValidator>
        </div>
        <div>
            <label>Password: </label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValPasswordReq" runat="server" 
                                        ControlToValidate="TxtPassword" Display="Dynamic"
                                        ErrorMessage="Password Required"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button runat="server" ID="BtnLogin" OnClick="BtnLogin_OnClick" Text="Login"/>
        </div>
        <div>
            <asp:Label runat="server" ID="LblError" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
