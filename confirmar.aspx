<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="confirmar.aspx.vb" Inherits="Lab2.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
            <br />
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="CONFIRMAR REGISTRO" Height="53px" Width="380px" />
        </div>
    </form>
</body>
</html>
