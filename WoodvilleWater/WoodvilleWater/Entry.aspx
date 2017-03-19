<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="WoodvilleWater.Entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <asp:Panel ID="pnlMain" runat="server">
        <table width="100%">
            <tr>
                <td><asp:Label ID="lblError" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DDLIDNAME" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLIDNAME_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
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
    </asp:Panel>
    <asp:Panel ID="pnlMessage" runat="server" Visible ="false">
        <div style="text-align:center">
        <table>
            <tr>
                <td><asp:Label ID="lblMessage" runat="server"  BackColor="Red" Font-Bold="true" Font-Size="Large" ForeColor="Yellow" Text="Label"></asp:Label></td>
            </tr>
            <tr><td>&nbsp</td>
            </tr>
            <tr><td>&nbsp</td>
            </tr>
            
            <tr>
                <td><asp:Button ID="btnCloseMessage" runat="server" Text="Ok" OnClick="btnCloseUpdate_Click" /></td>
            </tr>
         
        </table>
        </div>
    </asp:Panel>
</asp:Content>
