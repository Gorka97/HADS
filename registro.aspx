<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registro.aspx.vb" Inherits="Lab2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="REGISTRO DE USUARIOS"></asp:Label>
            <br />
        </div>
        <div>
            <asp:Label ID="labelEmail" runat="server" Text=" E-mail" style="margin-right: 115px;" ></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="E-mail incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="labelNombre" runat="server" Text="Nombre" style="margin-right: 105px;"></asp:Label>
        <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="labelApellidos" runat="server" Text="Apellidos" style="margin-right: 100px;"></asp:Label>
        <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxApellido" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="labelpsw" runat="server" Text="Password" style="margin-right: 95px;"></asp:Label>
            <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="labelPass2" runat="server" Text="Repetir password" style="margin-right: 50px;"></asp:Label>
            <asp:TextBox ID="TextBoxPass2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="labelRol" runat="server" Text="Rol" style="margin-right: 130px"></asp:Label>
            <asp:DropDownList ID="DropDownListRol" runat="server">
                <asp:ListItem Selected="True">Alumno</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="ButtonRegistrar" runat="server" Text="Registrarse" Width="209px" style="margin-left: 80px"/>
        </div>
        <p>
            <asp:Label ID="LabelRegistro" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="LabelEmailEnviado" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
