<%@ Page Title="specials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Specials.aspx.cs" Inherits="Internet_Shop.Specials" %>
<%@ Register Src="~/Order.ascx" TagName="Order" TagPrefix="ordr" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center_content">
        <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <asp:Label ID="lbl_top" runat="server" style="color: #FF0000"></asp:Label>
                <br />
                <asp:PlaceHolder ID="phOrders" runat="server">

                </asp:PlaceHolder>
            </div>
            <div class="bottom_prod_box_big"></div>


    </div>
</asp:Content>
