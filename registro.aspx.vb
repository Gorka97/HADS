Imports BaseDeDatos.accesodatosSQL
Imports BaseDeDatos.Email
Imports System.Security.Cryptography

Public Class WebForm1
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
    End Sub

    Protected Sub ButtonRegistrar_Click(sender As Object, e As EventArgs) Handles ButtonRegistrar.Click

        If TextBoxPass.Text.Equals(TextBoxPass2.Text) Then
            Randomize()
            Dim NumConf = CLng(Rnd() * 9000000) + 1000000
            Dim pass = encriptar(TextBoxPass.Text)
            Dim insercion = insertar(TextBoxEmail.Text, TextBoxNombre.Text, TextBoxApellido.Text, pass, DropDownListRol.SelectedValue, NumConf)
            If insercion Then
                LabelRegistro.Text = "En breves instantes recibirá un email para confirmar su registro. Puede cerrar esta pagina."
                Dim envio As New BaseDeDatos.Email
                LabelEmailEnviado.Text = envio.EnviarEmailConfirmacion(NumConf, TextBoxEmail.Text)
            End If
        Else
            LabelRegistro.Text = "Las contraseñas no coinciden"
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Function encriptar(ByVal pass)

        Dim uEncode As New UnicodeEncoding()
        Dim bytClearString() As Byte = uEncode.GetBytes(pass)
        Dim sha As New SHA256Managed()
        Dim hash() As Byte = sha.ComputeHash(bytClearString)
        Return Convert.ToBase64String(hash)

    End Function

End Class