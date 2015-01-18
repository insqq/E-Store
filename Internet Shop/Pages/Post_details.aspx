<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post_details.aspx.cs" Inherits="Internet_Shop.Post_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center_content">
        <asp:PlaceHolder ID="PlaceHolder_post" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder_leaveComment" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
