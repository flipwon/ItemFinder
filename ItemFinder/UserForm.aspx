<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="ItemFinder.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <!--Script to post back, dont think we need this atm
    <script type="text/javascript">
        function doPostBack(o){
            __doPostBack(o.id,'');
        }
    </script>-->
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
            <asp:Image ID="ImgMap" runat="server" />
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
            <asp:Button ID="BtnAddItem" runat="server" Text="Button" />
        </div>

    </form>
</body>
</html>
