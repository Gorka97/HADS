<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="inicio.aspx.vb" Inherits="Lab2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="E-mail" style="margin-right: 70px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />    
        <asp:Label ID="Label2" runat="server" Text="Password" style="margin-right: 50px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Acceder" style="margin-left: 90px" />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" style="margin-right: 50px" NavigateUrl="~/registro.aspx">Quiero registrarme</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/cambiarPassword.aspx">Modificar contraseña</asp:HyperLink>
        <p>
            <asp:Label ID="LabelConexion" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
