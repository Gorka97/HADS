Imports System.Data.SqlClient
Imports System.Security.Cryptography
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
        Dim pass = encriptar(TextBoxPass.Text)
        LabelConexion.Text = pass.ToString
        Dim st = "SELECT * FROM Usuarios WHERE email='" & TextBoxEmail.Text & "'"
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
            Dim password As String = RS.Item("pass")
            RS.Close()
            If (password.Equals(pass.ToString)) Then
                If (TextBoxEmail.Text.Equals("vadillo@ehu.es")) Then
                    Session("email") = TextBoxEmail.Text
                    FormsAuthentication.SetAuthCookie("vadillo", True)
                    Response.Redirect("/Acceso/Profesores/profesor.aspx")
                ElseIf (TextBoxEmail.Text.Equals("admin@ehu.es")) Then
                    Session("email") = TextBoxEmail.Text
                    FormsAuthentication.SetAuthCookie("admin", True)
                    Response.Redirect("/Acceso/Admin/.aspx")
                ElseIf (tipo = "Alumno") Then
                    Session("email") = TextBoxEmail.Text
                    FormsAuthentication.SetAuthCookie("alumno", True)
                    Response.Redirect("/Acceso/Alumnos/alumno.aspx")
                Else
                    Session("email") = TextBoxEmail.Text
                    FormsAuthentication.SetAuthCookie("profesor", True)
                    Response.Redirect("/Acceso/Profesores/profesor.aspx")
                End If
            End If
        End If
    End Sub

    Protected Function encriptar(ByVal pass)

        Dim has As New OC.Core.Crypto.Hash
        Dim texto As String = pass.ToString
        Dim passFinal As String = has.Sha256(texto).ToLower
        Return passFinal

    End Function
End Class