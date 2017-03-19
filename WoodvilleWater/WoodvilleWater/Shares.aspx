<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shares.aspx.cs" Inherits="WoodvilleWater.Shares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr><td colspan = "4"><asp:Label ID="lblError" runat="server" BackColor = "Red" ForeColor="Yellow" Text="Label" Visible="false"></asp:Label></td></tr>

        <tr><td colspan = "2"><h1>Shares to transfer</h1></td></tr>
        <tr><td colspan = "2"><asp:Button ID="BtnExit" runat="server" style="float: right;" Text="  Exit  " OnClick="BtnExit_Click" /></td></tr>
        <tr><td style="width: 6%">From Account ID:<br /><asp:DropDownList ID="DDLFromID" runat="server" OnSelectedIndexChanged="DDLFromID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
            <td>From Share Holder Name<br /><asp:DropDownList ID="DDLFromName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLFromName_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        <tr><td style="width: 6%">From Certificates:
            <asp:GridView ID="GVCert" AutoGenerateColumns="False" runat="server" DataKeyNames="CertificateNumber" OnSelectedIndexChanged="GVCert_SelectedIndexChanged">
             <Columns> 
                 <asp:BoundField HeaderText="Cert ID" DataField="CertificateNumber" 
           SortExpression="CertificateNumber"></asp:BoundField>
                    <asp:BoundField HeaderText="No. Shares" DataField="NumberOfShares" 
           SortExpression="NumberOfShares"></asp:BoundField>
        <asp:BoundField HeaderText="Note" DataField="Note" 
           SortExpression="Note"></asp:BoundField>
                    <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
            </asp:GridView>
        </td>
            <td>
                <table>

                <tr><td style="width: 199px">Certificate Number:</td><td>Number of Shares:</td> <td style="width: 199px">Number of Shares to Transfer:</td></tr>
                <tr><td style="width: 199px"><asp:Label ID="lblCertSelected" runat="server" Text=""></asp:Label></td>
                    <td style="width: 199px"><asp:Label ID="lblNumShares" runat="server" Text=""></asp:Label></td>
                    <td style="width: 199px"><asp:TextBox ID="txtNumTransfer" Width="145px" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td></td></tr>
                <tr><td></td></tr>
                <tr><td>To Shareholder Name:</td>
                    <td>New Certificate Number:</td>
                    <td>Remaining Certificate Number:</td>
                </tr>
                <tr><td><asp:DropDownList ID="DDLToName" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                    <td><asp:TextBox ID="txtNewCert" Width="145px" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtRemainCert" Width="145px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>New Certificate Note:</td>
                    <td>Remaining Certificate Note:</td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:TextBox ID="txtNewCertNote" runat="server" Height="65px" Width="145px"></asp:TextBox></td>
                    <td><asp:TextBox ID="txtRemCertNote" runat="server" Height="65px" Width="145px"></asp:TextBox></td>
                </tr>
            </table>
            </td>
        <tr><td style="width: 6%"><asp:Button ID="BtnTransfer" runat="server" Text="Transfer Shares" OnClick="BtnTransfer_Click" /></td>
        </tr>
        </table>
</asp:Content>
