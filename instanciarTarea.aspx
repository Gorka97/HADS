<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="instanciarTarea.aspx.vb" Inherits="Lab2.instanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="TextBoxUsuario" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tarea"></asp:Label>
        <asp:TextBox ID="TextBoxTarea" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Horas estimadas"></asp:Label>
        <asp:TextBox ID="TextBoxHorasEst" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Horas reales"></asp:Label>
        <asp:TextBox ID="TextBoxHorasReal" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonTarea" runat="server" Height="88px" Text="Crear Tarea" Width="173px" />
        <div style="margin-left: 520px">
            <asp:GridView ID="GridViewTareas" runat="server">
            </asp:GridView>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="tareasAlumno.aspx">Pagina Anterior</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
