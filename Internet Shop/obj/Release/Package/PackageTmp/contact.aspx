<%@ Page Title="contact us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Internet_Shop.contact" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Electronix Store - Contact</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 121px;
            font-size: 13px;
        }
        .auto-style3 {
            width: 121px;
            text-align: right;
            font-size: 13px;
        }
        .auto-style4 {
            text-align: left;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="center_content">
        <div class="center_title_bar">Contact Us</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                   
                    <asp:Label ID="lbl_top" runat="server" Style="color: #FF0000"></asp:Label>
                    <table class="auto-style1">
                        <tr>
                            <td style="text-align: right; " class="auto-style2">Імя: </td>
                            <td class="auto-style4">
                                <asp:TextBox ID="TextBox1" runat="server" Width="250px" style="text-align: left"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Емейл: </td>
                            <td class="auto-style4">
                                <asp:TextBox ID="TextBox2" runat="server" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Телефон: </td>
                            <td class="auto-style4">
                                <asp:TextBox ID="TextBox3" runat="server" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Тема: </td>
                            <td class="auto-style4">
                                <asp:TextBox ID="TextBox4" runat="server" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Текст: </td>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" Height="100px" TextMode="MultiLine" Width="350px" style="resize:none"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                    <div style="width: 80%; margin-top:20px"><a id="A1" runat="server" onserverclick="btnSend_Click" class="contact">Надіслати</a> </div>
                   
                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>
</asp:Content>
