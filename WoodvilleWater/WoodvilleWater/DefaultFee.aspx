<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultFee.aspx.cs" Inherits="WoodvilleWater.DefaultFee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <table width="30%">
        <tr><td width="5%">Default Name:</td>
            <td width="5%"><asp:TextBox ID="txtName" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
       <tr>
            <td width="5%">Fee:</td>
            <td width="5%"><asp:TextBox ID="txtFee" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Share Price:</td>
            <td width="5%"><asp:TextBox ID="txtSharePrice" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%"><asp:Button ID="BtnSave" runat="server" Text="Save Data" OnClick="BtnSave_Click" /></td>
            <td width="5%"><asp:Button ID="BtnExit" runat="server" Text="  Exit  " OnClick="BtnExit_Click" /></td>
        </tr>
            
    </table>
</asp:Content>
