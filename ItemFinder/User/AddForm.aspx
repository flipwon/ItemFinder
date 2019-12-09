<%@ Page Title="" Language="C#" MasterPageFile="~/ItemFinder.Master" AutoEventWireup="true" CodeBehind="AddForm.aspx.cs" Inherits="ItemFinder.AddForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        document.onmousemove = getCoordinate;
        var mosX = 0;
        var mosY = 0;
        var pin = document.getElementById('imgPin');

        //Keep the location of the mouse and apply it to a hidden field.
        function getCoordinate(e) {
            mosX = event.clientX + document.body.scrollLeft;
            mosY = event.clientY + document.body.scrollTop;
            document.getElementById('<%=hidCoords.ClientID%>').value = "" + mosX + "," + mosY;
            
            return true;
        }


    </script>

    <style>
        .parent {
            position: relative;
            top: 0;
            left: 0;
        }
        .image1 {
            position: relative;
            top: 0;
            left: 0;
        }
        .image2 {
            position: absolute;
            top: 30px;
            left: 70px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hidCoords" runat="server" />

    <div class="parent">
        <asp:ImageButton ID="ImgMap" CssClass="image1" runat="server" 
                         Width="600px" ImageUrl="~/Images/supermarket.jpg" 
                         OnClick="ImgMap_OnClick" />

        <asp:Image ID="imgPin" CssClass="image2" runat="server"   
                   Width="10px" ImageUrl="~/Images/mappin.png"
                   Visible="False"/>
    </div>
    
    <div><label>Test Location:</label><asp:Label ID="lblTestCoord" runat="server" Text="Label"></asp:Label></div>

    <div>
        <label>Name</label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <label>Department</label>
        <asp:DropDownList ID="drpDepartment" runat="server"></asp:DropDownList>
    </div>
    <div>
        <label>Description (Optional)</label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <label>Price (Optional)</label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <label>Image (Optional)</label>
        <asp:FileUpload ID="filImage" runat="server" />
    </div>
    
    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_OnClick" />

</asp:Content>
