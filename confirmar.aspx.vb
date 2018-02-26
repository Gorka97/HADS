Imports System.Data.SqlClient
Imports BaseDeDatos.accesodatosSQL
Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conectar()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email = Convert.ToString(Request.QueryString("email"))
        Dim st = "SELECT numconfir FROM Usuarios WHERE email='" & email & "'"
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

        Dim codigo = Convert.ToString(Request.QueryString("cod"))
        If codigo.Equals(cod) Then
            Dim st2 = "UPDATE Usuarios SET confirmado = 1 WHERE email = '" & email & "'"
            Dim bool = updateDatos(st2)
            If (bool) Then
                Response.Redirect("http://hads18-24.azurewebsites.net/inicio.aspx")
            Else
                LabelError.Text = "No se ha podido confirmar tu registro"
            End If
        Else
            LabelError.Text = "El codigo es incorrecto"
        End If
    End Sub
End Class