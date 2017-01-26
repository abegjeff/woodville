<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="WoodvilleWater.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr><td><h1>Person to bill or process payment</h1></td></tr>
        <tr><td><h2>Account ID:<br /></h2><asp:DropDownList ID="DDLFrom" runat="server"></asp:DropDownList></td>
            <td><h2>Share Holder Name<br /></h2><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr><td><h2>Assessments:</h2>
            <asp:GridView ID="GVAssessment" runat="server" AutoGenerateColumns="False">
                 <Columns>
        <asp:BoundField HeaderText="Last Name" DataField="LastName" 
           SortExpression="LastName"></asp:BoundField>
        <asp:BoundField HeaderText="First Name" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Hire Date" DataField="HireDate" 
           SortExpression="HireDate"
            DataFormatString="{0:d}"></asp:BoundField>
        <asp:BoundField HeaderText="Due Date" DataField="HireDate" 
           SortExpression="HireDate"
            DataFormatString="{0:d}"></asp:BoundField>
        <asp:BoundField HeaderText="Amount Due" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Note" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
    </Columns>

            </asp:GridView>
        </td></tr>
        <tr><td></td></tr>
        <tr><td colspan="2"><hr /></td></tr>        
        <tr><td><h2>Payments:</h2>
            <asp:GridView ID="GVPay" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Date" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Batch" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField HeaderText="Amount Paid" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Note" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                    </Columns>
            </asp:GridView>
        </td>

            <td><h2>Penalties:</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Date" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Fee" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField HeaderText="Interest" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Note" DataField="FirstName" 
           SortExpression="FirstName"></asp:BoundField>
                    </Columns>
            </asp:GridView>
        </td>
        </tr>
            <tr><td width="5%"><asp:Button ID="BtnProcess" runat="server" Text="Process Payments" OnClick="BtnProcess_Click" /></td>
            <td width="5%"><asp:Button ID="BtnExit" runat="server" Text="  Exit  " OnClick="BtnExit_Click" /></td>
        </tr>
        </table>
</asp:Content>
