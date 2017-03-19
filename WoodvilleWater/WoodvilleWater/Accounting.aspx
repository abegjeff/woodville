<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accounting.aspx.cs" Inherits="WoodvilleWater.Accounting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <table>
        <td>
    <table width="80%">
        <tr><td width="5%">Select an ID:</td>
            <td><asp:DropDownList ID="DDLID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLID_SelectedIndexChanged"></asp:DropDownList>
                <asp:Label ID="pickID" runat="server" Visible="false" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnActive" runat="server" Text="All Accounts" OnClick="btnActive_Click" />
            </td>
            <td>
                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
            </td>
            <td>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
            </td>

        </tr>
        
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
       
    </table>
</td>
        <td align="top">
             <table>
        <tr><td width="5%" ><strong>Certificates:</strong></td>
        </tr>
        <tr><td colspan="3"><asp:GridView ID="GVCert" runat="server" AutoGenerateColumns="False">
                 <Columns>
        <asp:BoundField HeaderText="Number" DataField="CertificateNumber"></asp:BoundField>
        <asp:BoundField HeaderText="Shares" DataField="NumberOfShares"></asp:BoundField>        
    </Columns>
    </asp:GridView></td>
        </tr>
                 <tr><td colspan="3">&nbsp;</td></tr>
                 <tr><td colspan="3">&nbsp;</td></tr>
        <tr><td colspan="3"><strong>Balance:</strong>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblBalance" runat="server"></asp:Label></td></tr>
    </table>
    <tr><td><strong>Assessments</strong></td></tr>
    <tr><td colspan="2"><asp:GridView ID="GVAssess" runat="server" AutoGenerateColumns="False">
                 <Columns>
        <asp:BoundField HeaderText="Date" DataField="DAssessment"></asp:BoundField>
        <asp:BoundField HeaderText="Price of Share" DataField="PriceOfShare"></asp:BoundField> 
        <asp:BoundField HeaderText="Assessment Fee" DataField="AssessmentFee"></asp:BoundField>
        <asp:BoundField HeaderText="Due Date" DataField="DDate"></asp:BoundField>
        <asp:BoundField HeaderText="Amount Due" DataField="AmountDue"></asp:BoundField>
        <asp:BoundField HeaderText="Note" DataField="Note"></asp:BoundField>           
    </Columns>
    </asp:GridView></td></tr>
        <tr><td><strong>Payments</strong></td><td><strong>Penalities</strong></td></tr>
        <tr><td><asp:GridView ID="GVPayments" runat="server" AutoGenerateColumns="False">
                 <Columns>
        <asp:BoundField HeaderText="Date" DataField="DPaid"></asp:BoundField>
        <asp:BoundField HeaderText="Amount Paid" DataField="AmountPaid"></asp:BoundField> 
        <asp:BoundField HeaderText="Note" DataField="Note"></asp:BoundField>           
    </Columns>
    </asp:GridView></td>
            <td><asp:GridView ID="GVPen" runat="server" AutoGenerateColumns="False">
                 <Columns>
        <asp:BoundField HeaderText="Date" DataField="PDate"></asp:BoundField>
        <asp:BoundField HeaderText="Fee" DataField="PenaltyFee"></asp:BoundField>
        <asp:BoundField HeaderText="Interest" DataField="PenaltyInterest"></asp:BoundField>             
        <asp:BoundField HeaderText="Note" DataField="Note"></asp:BoundField>           
    </Columns>
    </asp:GridView></td>
        </tr>
    <tr><td width="5%"><asp:Button ID="BtnAdd" runat="server" Text="Add Entry" OnClick="BtnAdd_Click" /></td>
            <td width="5%"><asp:Button ID="BtnExit" runat="server" Text="  Exit  " OnClick="BtnExit_Click" /></td>
        </tr>
     </table>
</asp:Content>
