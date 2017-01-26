<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BillOut.aspx.cs" Inherits="WoodvilleWater.BillOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <table width="80%">

        <tr><td width="5%">Share Price:</td>
            <td width="5%"><asp:TextBox ID="txtFname" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="5%">Date of Assessment:</td>
            <td width="5%"><asp:TextBox ID="txtLname" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Date Due:</td>
            <td width="5%"><asp:TextBox ID="txtAddress1" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Assessment Fee:</td>
            <td><asp:TextBox ID="txtCity" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%"><asp:Button ID="BtnAssess" runat="server" Text="Assess Shareholders" OnClick="BtnAdd_Click" /></td>
            <td width="5%"><asp:Button ID="BtnExit" runat="server" Text="  Exit  " OnClick="BtnExit_Click" /></td>
        </tr>
            
    </table>
</asp:Content>
