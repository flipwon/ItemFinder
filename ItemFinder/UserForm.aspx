<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="ItemFinder.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>

    <form id="form1" runat="server">

        <div>
            <label>Search</label>
            <asp:TextBox ID="TxtSearch" runat="server" OnTextChanged="TxtSearch_OnTextChanged"></asp:TextBox>
        </div>
        
        <div>
            <label>Test Search</label>

        </div>

        <div>
            <asp:Button ID="BtnSearch" runat="server" Text="Button" />
        </div>

        <div>
            <asp:ImageButton ID="ImgMap" runat="server" Width="250px" ImageUrl="~/Images/sqljoins.jpg" />
        </div>
        
        <div>
            <asp:Label ID="LblName" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div>
            <asp:Label ID="LblDept" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div>
            <asp:Label ID="LblDesc" runat="server" Text="Label"></asp:Label>
        </div>
        
        <div>
            <asp:Label ID="LblPrice" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
            <asp:Button ID="BtnAddItem" runat="server" Text="Add Item" OnClick="BtnAddItem_OnClick"/>
        </div>

    </form>
</body>
</html>
