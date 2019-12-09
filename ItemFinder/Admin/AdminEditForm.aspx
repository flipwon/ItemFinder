<%@ Page Title="" Language="C#" MasterPageFile="~/ItemFinder.Master" AutoEventWireup="true" CodeBehind="AdminEditForm.aspx.cs" Inherits="ItemFinder.AdminEditForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image runat="server" ID="imgPin" Width="10px" ImageUrl="~/Images/mappin.png"/>
    <div>
        <asp:ImageButton ID="ImgMap" runat="server" Width="250px" ImageUrl="~/Images/sqljoins.jpg" OnClick="ImgMap_OnClick"/>
    </div>

    <div>
        <label>Name</label>
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <label>Department</label>
        <asp:DropDownList ID="DrpDepartment" runat="server"></asp:DropDownList>
    </div>
    <div>
        <label>Description (Optional)</label>
        <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <label>Price (Optional)</label>
        <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
    </div>
    
    <div>
        <label>Image (Optional)</label>
        <asp:FileUpload ID="FilImage" runat="server" />
    </div>
    
    <asp:Button ID="BtnUpdateItem" runat="server" Text="Update Item" />
</asp:Content>
