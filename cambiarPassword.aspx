<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cambiarPassword.aspx.vb" Inherits="Lab2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="E-mail:" style="margin-right: 60px"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" Width="200px"></asp:TextBox>
            
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Solicitar cambiar contraseña" style="margin-left: 40px" UseSubmitBehavior="False"/>
            <br />
            <br />
            <asp:Label ID="LabelEspera" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Codigo:" style="margin-right: 60px"></asp:Label>
        <asp:TextBox ID="TextBoxCodigo" runat="server" Width="200px" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nueva password" style="margin-right: 45px"></asp:Label>
        <asp:TextBox ID="TextBoxPass" runat="server" Width="200px" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Repetir password" style="margin-right: 40px"></asp:Label>
        <asp:TextBox ID="TextBoxPass2" runat="server" Width="200px" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Modificar contraseña" style="margin-left: 60px" UseSubmitBehavior="False" />
        <br />
        <br />
        <asp:Label ID="LabelError" runat="server"></asp:Label>
    </form>
</body>
</html>
