<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shares.aspx.cs" Inherits="WoodvilleWater.Shares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr><td><h1>Shares to transfer</h1></td></tr>
        <tr><td><h2>From Account ID:<br /></h2><asp:DropDownList ID="DDLFrom" runat="server"></asp:DropDownList></td>
            <td><h2>From Share Holder Name<br /></h2><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr><td><h2>From Certificates:</h2>
            <asp:GridView ID="GVCert" AutoGenerateColumns="false" runat="server">
             <Columns> 
                 <asp:BoundField HeaderText="Cert ID" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                    <asp:BoundField HeaderText="No. Shares" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="No. to Transfer" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Cert to Transfer To" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Note" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                    </Columns>
            </asp:GridView>
        </td></tr>
        <tr><td width="5%"><asp:Button ID="BtnTransfer" runat="server" Text="Transfer Shares" OnClick="BtnTransfer_Click" /></td>
            <td width="5%"><asp:Button ID="BtnExit" runat="server" Text="  Exit  " OnClick="BtnExit_Click" /></td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr><td><h2>To Account ID:<br /></h2><asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
            <td><h2>To Share Holder Name<br /></h2><asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr><td><h2>To Certificates:</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                 <Columns> 
                 <asp:BoundField HeaderText="Cert ID" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                    <asp:BoundField HeaderText="No. Shares" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                    </Columns>
            </asp:GridView>
        </td></tr>
        </table>
</asp:Content>
