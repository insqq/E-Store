<%@ Page Title="" Language="C#" MasterPageFile="~/Logined.Master" AutoEventWireup="true" CodeBehind="contact_logined.aspx.cs" Inherits="Internet_Shop.contact_logined" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    .auto-style2 {
        text-align: right;
        font-size: 13px;
        width: 130px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="center_content">
        <div class="center_title_bar">Звязок з адміністрацією</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <div class="contact_form">

                    <asp:Label ID="lbl_top" runat="server" Style="color: #FF0000"></asp:Label>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">Тема: </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Текст: </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>



                    <div style="width: 80%; margin-top: 20px"><a id="A1" runat="server" onserverclick="btnSend_Click" class="contact">Надіслати</a> </div>

                </div>
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>




</asp:Content>
