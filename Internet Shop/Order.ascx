<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Order.ascx.cs" Inherits="Internet_Shop.Order" %>


<div style="margin-top: 15px; margin-left:15%">
    <div style="width: 35%; height: auto; float: left; margin-right: 10px;">
        <asp:Label runat="server" ID="lblDate">date</asp:Label>
    </div>
    <div style="width: 10%; margin-bottom: 5px; margin-right: 10px; float: left;">
        <asp:Label runat="server" ID="lbltotalPrice" >price</asp:Label>
    </div>
    <div style="width: 15%; margin-bottom: 5px; margin-right: 10px; float: left;">
        <asp:Label runat="server" ID="lblStatus">status</asp:Label>

    </div>
    <div style="width: 10%; margin-bottom: 5px; margin-right: 10px; float:left">
        <asp:Button runat="server" ID="btnChangeStatus" Text="Change Status" OnClick="btnChangeStatus_Click"/>
    </div>


</div>
