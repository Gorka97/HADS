Imports System.Data.SqlClient
Imports BaseDeDatos.accesodatosSQL
Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String

        result = conectar()
        LabelConexion.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim c As Boolean = False
        Dim st = "SELECT tipo FROM Usuarios WHERE email='" & TextBoxEmail.Text & "' AND pass='" & TextBoxPass.Text & "' "
        Dim RS As SqlDataReader
        Try
            RS = getDatos(st)
        Catch ex As Exception
            LabelConexion.Text = "Usuario o contraseña incorrecto. Intentelo de nuevo"
            c = True
            Exit Sub
        End Try
        If Not (c) Then
            RS.Read()
            Dim tipo As String = RS.Item("tipo")
            RS.Close()
            If (tipo = "Alumno") Then
                Session("email") = TextBoxEmail.Text
                Response.Redirect("alumno.aspx")
            Else
                Session("email") = TextBoxEmail.Text
                Response.Redirect("profesor.aspx")
            End If
        End If
    End Sub
End Class