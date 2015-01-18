<%@ Page Title="productions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Internet_Shop.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center_content">
        <div id="center_title_bar" class="center_title_bar">Latest Products</div>
        

        <asp:PlaceHolder ID="main_content" runat="server">

        </asp:PlaceHolder>
    </div>
    <!-- end of center content -->
</asp:Content>
