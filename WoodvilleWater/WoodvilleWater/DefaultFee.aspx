<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultFee.aspx.cs" Inherits="WoodvilleWater.DefaultFee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <table width="30%">
       <tr><td></td><td>
           <asp:DropDownList ID="DDLFees" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLFees_SelectedIndexChanged">
           </asp:DropDownList>
           </td>
           <td><asp:Button ID="BtnExit" runat="server" style="float: left;" Text="  Exit  " /></td></tr>
        <tr><td style="width: 1%">Default Name:</td>
            <td><asp:TextBox ID="txtName" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
       <tr>
            <td style="width: 1%">Fee:</td>
            <td><asp:TextBox ID="txtFee" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td style="width: 1%">Share Price:</td>
            <td><asp:TextBox ID="txtSharePrice" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td style="width: 1%"></td>
            <td><asp:Button ID="BtnSave" runat="server" Text="Save Data" OnClick="BtnSave_Click" /></td>
        </tr>
            
    </table>
</asp:Content>
