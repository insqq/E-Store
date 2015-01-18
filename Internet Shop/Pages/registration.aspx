<%@ Page Title="registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Internet_Shop.registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        
        .auto-style1 {
            text-align: right;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            text-align: right;
            font-size: 15px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server">

      

   </script>


    <div class="center_content">
        <div class="center_title_bar">Реєстрація</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">
                <asp:Label ID="Label_top" runat="server" style="font-size: 15px; color: #FF0000;"></asp:Label>
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style3">Імя:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox_name" runat="server" Width="170px"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="name_required" runat="server" ControlToValidate="TextBox_name" ErrorMessage="name is required" style="text-align: right; color: #FF0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Прізвище:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox_surename" runat="server" Width="170px"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="surename_required" runat="server" ControlToValidate="TextBox_surename" ErrorMessage="surename is required" style="text-align: right; color: #FF0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Логін:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox_nickname" runat="server" Width="170px"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="nickname_required" runat="server" ControlToValidate="TextBox_nickname" ErrorMessage="nickname is required" style="text-align: right; color: #FF0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Е-мейл:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox_email" runat="server" Width="170px"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="Email__required" runat="server" ControlToValidate="TextBox_email" ErrorMessage="Email is required" style="text-align: right; color: #FF0000"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_email" ErrorMessage="incorrect Email" style="color: #FF0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Пароль:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox_password" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="password__required" runat="server" ControlToValidate="TextBox_password" ErrorMessage="password is required" style="text-align: right; color: #FF0000"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox_confirmpassword" ControlToValidate="TextBox_password" ErrorMessage="both password must be same" style="color: #FF0000"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Підтвердження:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TextBox_confirmpassword" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="confirmpw_required" runat="server" ControlToValidate="TextBox_confirmpassword" ErrorMessage="confirm password is required" style="text-align: right; color: #FF0000"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div style="margin: 20px 25% 0 0; width: 50%"><a id="A1" runat="server" onserverclick="ButtonClick" class="contact">Надіслати</a></div>
                
            </div>
            <div class="bottom_prod_box_big"></div>
        </div>
    </div>

</asp:Content>
