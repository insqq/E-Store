<%@ Page Title="sing up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enter.aspx.cs" Inherits="Internet_Shop.Sign_in" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center_content">
        <div class="center_title_bar">Вхід</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <asp:Label ID="lbl_top" runat="server" style="color: #FF0000"></asp:Label>

                    <div >
                        <label ><strong> Логін :</strong></label>
                        <asp:TextBox ID="TextBox_nickname" runat="server" type="text" Width="180px" />
                    </div>

                    <div >
                        <br />
                        <label ><strong>Пароль:</strong></label>
                        <asp:TextBox runat="server" ID="TextBox_password" type="text"  Width="180px" TextMode="Password" />
                    </div >

                    <div style="width: 80%; margin-top:20px"><a id="A1" runat="server" onserverclick="login_Click" class="contact">Ввійти</a> </div>
                    

                    

                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>
</asp:Content>
