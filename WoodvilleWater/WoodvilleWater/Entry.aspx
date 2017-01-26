<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="WoodvilleWater.Entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <table width="80%">
        <tr><td width="5%">Account ID:</td>
            <td width="5%"><asp:Label ID="lblAccount" runat="server"></asp:Label></td>
        </tr>
        <tr><td width="5%">First Name:</td>
            <td width="5%"><asp:TextBox ID="txtFname" MaxLength="50" runat="server"></asp:TextBox></td>
            <td width="5%">Last Name:</td>
            <td width="5%"><asp:TextBox ID="txtLname" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Address 1:</td>
            <td width="5%"><asp:TextBox ID="txtAddress1" MaxLength="50" runat="server"></asp:TextBox></td>
            <td width="5%">Address 2:</td>
            <td width="5%"><asp:TextBox ID="txtAddress2" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Address 3:</td>
            <td width="5%"><asp:TextBox ID="txtAddress3" MaxLength="50" runat="server"></asp:TextBox></td>           
        </tr>
        <tr><td width="5%">City:</td>
            <td><asp:TextBox ID="txtCity" MaxLength="50" runat="server"></asp:TextBox></td>
            <td width="5%">State/Zip:</td>
            <td width="5%"><asp:TextBox ID="txtState" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Phone:</td>
            <td><asp:TextBox ID="txtPhone" MaxLength="50" runat="server"></asp:TextBox></td>
        <td width="5%">Email:</td>
            <td><asp:TextBox ID="txtEmail" MaxLength="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr><td width="5%">Notes:</td>
            <td width="15%" colspan="3"><asp:TextBox ID="txtNotes" MaxLength="250" Width="686px"  runat="server" Height="67px"></asp:TextBox></td>
        </tr>
        <tr><td width="5%"><asp:Button ID="BtnAdd" runat="server" Text="Add Entry" OnClick="BtnAdd_Click" /></td>
            <td width="5%"><asp:Button ID="BtnExit" runat="server" Text="  Exit  " OnClick="BtnExit_Click" /></td>
        </tr>
            
    </table>
</asp:Content>
