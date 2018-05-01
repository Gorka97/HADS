Public Class alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabla As New DataTable
        Dim tablas As New DataTable

        Dim profesor As New ArrayList
        Dim alumno As New ArrayList
        profesor = Application.Contents(1)
        tabla.Columns.Add("Profesores Conectados: " & profesor.Count)

        alumno = Application.Contents(0)
        tabla.Columns.Add("Alumnos Conectados: " & alumno.Count)
        Dim i As Integer = 0
        For Each p As String In profesor
            If (i <> alumno.Count) Then
                tabla.Rows.Add(p.ToString, alumno(i))
                i = i + 1
            Else
                tabla.Rows.Add(p.ToString)
            End If

        Next

        GridView1.DataSource = tabla
        GridView1.DataBind()

    End Sub


End Class