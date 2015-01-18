﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Logined.Master" AutoEventWireup="true" CodeBehind="My_account_admin.aspx.cs" Inherits="Internet_Shop.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 67%;
        }

        .auto-style2 {
            width: 150px;
            font-size: 13px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/ui-lightness/jquery-ui-1.10.4.custom.css" rel="stylesheet">
    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/jquery-ui-1.10.4.custom.js"></script>
    <script>
        $(function () {
            $("#tabs").tabs();
        });
    </script>
    <div class="center_content">
        <div class="center_title_bar">Admin Panel</div>
        <div class="prod_box_big">
            <asp:Label ID="lbl_top" runat="server" Style="color: #FF0000"></asp:Label>

            <div id="tabs">
                <ul>
                    <li><a href="#tabs-1">About</a></li>
                    <li><a href="#tabs-2">Список замовлень</a></li>
                    <li><a href="#tabs-3">Добавити товар</a></li>
                    <li><a href="#tabs-4">Повідомлення від користувачів</a></li>
                    <li><a href="#tabs-4">Опублікувати Повідомлення</a></li>
                </ul>
                <div id="tabs-1">
                    fill text
                </div>
                <div id="tabs-2">


                </div>
                <div id="tabs-3">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">Назва:</td>
                            <td>
                                <asp:TextBox ID="tb_name" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Виробник:</td>
                            <td>
                                <asp:TextBox ID="tb_manufacturer" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Звичайна ціна:</td>
                            <td>
                                <asp:TextBox ID="tb_price" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Ціна по знижці:</td>
                            <td>
                                <asp:TextBox ID="tb_priceless" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Інформація:</td>
                            <td>
                                <asp:TextBox ID="tb_info" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Тип товару:</td>
                            <td>
                                <asp:TextBox ID="tb_type" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Наявність на складі:</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="pressent">є на складі</asp:ListItem>
                                    <asp:ListItem Value="absent">немає на складі</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Вага:</td>
                            <td>
                                <asp:TextBox ID="tb_weight" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Час страховки:</td>
                            <td>
                                <asp:TextBox ID="tb_insurance" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення (90х90):</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_1" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення велике:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_2" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення маленьке 1:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_3" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення маленьке 2:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_4" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення маленьке 3:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_5" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення велике 1:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_6" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення велике 2:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_7" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style2">Зображення велике 3:</td>
                            <td>
                                <asp:PlaceHolder ID="ph_fu_8" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>


                        <tr>
                            <td class="auto-style2"></td>
                            <td style="text-align: right">
                                <asp:Button ID="btn_addgoods" runat="server" OnClick="btn_addgoods_Click" Text="Додати" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>



        </div>
    </div>
</asp:Content>