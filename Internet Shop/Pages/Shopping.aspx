<%@ Page Title="shopping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shopping.aspx.cs" Inherits="Internet_Shop.Shopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 25px;
        }

        .auto-style3 {
            width: 200px;
        }

        .auto-style4 {
            width: 50px;
        }

        .auto-style5 {
            width: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center_content">
        <div class="center_title_bar">Покупки</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <asp:Label ID="lbl_top" runat="server" Style="color: #FF0000"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" Style="margin-left: 20px;" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:PlaceHolder ID="PlaceHolder_deliverPlace" runat="server">
                    <asp:Label ID="Lbl_Address" runat="server" Text="Адресса: "></asp:Label>
                    <asp:TextBox ID="tbAddress" runat="server" style="width:200px;"></asp:TextBox>
                </asp:PlaceHolder>
                <br />
                <asp:PlaceHolder ID="PlaceHolder_buttons" runat="server"></asp:PlaceHolder>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>
</asp:Content>
