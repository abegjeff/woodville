<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="WoodvilleWater.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr><td>
    <table>
        <tr><td><asp:Label ID="lblAdmin" Visible="false" runat="server"></asp:Label></td></tr>        
        <tr><td><asp:Button ID="BtnEntry" runat="server" Width="30px" OnClick="BtnEntry_Click" />&nbsp;Enter Share Holders</td></tr>
        <tr><td><asp:Button ID="BtnShare" runat="server" Width="30px" OnClick="BtnShare_Click" />&nbsp;Transfer Shares</td></tr>
        <tr><td><asp:Button ID="BtnBilling" runat="server" Width="30px" OnClick="BtnBilling_Click" />&nbsp;Annual Billing</td></tr>
        <tr><td><asp:Button ID="BtnPayments" runat="server" Width="30px" OnClick="BtnPayments_Click" />&nbsp;Enter Payments</td></tr>
        <tr><td><asp:Button ID="BtnPaid" runat="server" Width="30px" OnClick="BtnPaid_Click" />&nbsp;Shareholders Paid</td></tr>
        <tr><td><asp:Button ID="BtnNotPaid" runat="server" Width="30px" OnClick="BtnNotPaid_Click" />&nbsp;Shareholders not Paid</td></tr>
        <tr><td><asp:Button ID="BtnExit" runat="server" Width="30px" OnClick="BtnExit_Click" />&nbsp;Logout/Exit</td></tr>
    </table></td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td>
            <asp:Panel ID="PnlAdmin" Visible="false" runat="server">
                <table>
                     <tr><td><asp:Button ID="BtnDefaultFee" runat="server" Width="30px" OnClick="BtnDefaultFee_Click" />Assessment Fee Default</td></tr>
                    <tr><td><asp:Button ID="BtnBillOut" runat="server" Width="30px" OnClick="BtnBillOut_Click" />Assess Water Users</td></tr>
        </table>
                    

            </asp:Panel></td>
        </tr>
    </table>
</asp:Content>
