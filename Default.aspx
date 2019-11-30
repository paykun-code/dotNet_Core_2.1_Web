<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>PayKun Demo</h1>
            <table>
                <tr>
                <td><label>full name</label></td>
                <td>
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><label>product name</label></td>
                <td>
                    <asp:TextBox ID="product_name" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td><label>email</label></td>
                <td>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><label>amount</label></td>
                <td>
                    <asp:TextBox ID="amount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><label>contact No</label></td>
                <td>
                    <asp:TextBox ID="contact" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><label>country</label></td>
                <td>
                    <asp:TextBox ID="country" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td><label>state</label></td>
                <td>
                    <asp:TextBox ID="state" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td><label>city</label></td>
                
                <td>
                    <asp:TextBox ID="city" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><label>postal code</label></td>
                
                <td><asp:TextBox ID="postalcode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label>address</label></td>
                <td>
                    <asp:TextBox ID="address" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <center colspan="2">
                        <asp:Button ID="ProcessPayment" runat="server" Text="Pay Now" OnClick="ProcessPayment_Click" />
                    </center>
                </td>
            </tr>
            </table>
        </div>
    </form>
    <div runat="server" id="payment_form">
        <asp:Literal runat="server" ID="PaymentinnerForm" />
    </div>
</body>
</html>
