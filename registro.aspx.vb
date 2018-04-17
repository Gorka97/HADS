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

        Dim has As New OC.Core.Crypto.Hash
        Dim texto As String = pass.ToString
        Dim passFinal As String = has.Sha256(texto).ToLower
        Return passFinal

    End Function

End Class