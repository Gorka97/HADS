Imports System.Data.SqlClient
Imports BaseDeDatos.accesodatosSQL

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBoxEmail.Enabled() = False
        Dim st = "SELECT * FROM Usuarios WHERE email='" & TextBoxEmail.Text & "'"
        Dim RS As SqlDataReader
        Try
            RS = getDatos(st)
        Catch ex As Exception
            LabelEspera.Text = ex.Message
            Exit Sub
        End Try
        RS.Read()
        Dim cod As String = RS.Item("numconfir")
        RS.Close()

        Dim email = TextBoxEmail.Text
        Dim envio As New BaseDeDatos.Email
        Dim bool = envio.EnviarEmailModificar(cod, email)
        If bool Then
            LabelEspera.Text = "En breves instantes recibira un email con su codigo de verificacion"
        Else
            LabelEspera.Text = "Se ha producido un error, intentelo mas tarde"
        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim st = "SELECT numconfir FROM Usuarios WHERE email='" & TextBoxEmail.Text & "'"
        Dim RS As SqlDataReader
        Try
            RS = getDatos(st)
        Catch ex As Exception
            LabelError.Text = ex.Message
            Exit Sub
        End Try
        RS.Read()
        Dim cod As String = RS.Item("numconfir")
        RS.Close()
        If TextBoxCodigo.Text.Equals(cod) Then
            If TextBoxPass.Text.Equals(TextBoxPass2.Text) Then
                Dim st2 = "UPDATE Usuarios SET pass = '" & TextBoxPass.Text & "' WHERE email = '" & TextBoxEmail.Text & "'"
                Dim bool = updateDatos(st2)
                If (bool) Then
                    Response.Redirect("http://hads18-24.azurewebsites.net/inicio.aspx")
                Else
                    LabelError.Text = "No se ha podido actualizar las contraeña"
                End If
            Else
                LabelError.Text = "Las contraseñas no coinciden"
            End If
        Else
            LabelError.Text = "El codigo es incorrecto"
        End If

    End Sub
End Class