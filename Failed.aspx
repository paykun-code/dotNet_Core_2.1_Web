<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Failed.aspx.cs" Inherits="_Failed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Payment Failed</h1>
            <div runat="server" id="payment_form">
                <asp:Literal runat="server" ID="payment_failed_detail" />
            </div>
        </div>
    </form>
</body>
</html>
