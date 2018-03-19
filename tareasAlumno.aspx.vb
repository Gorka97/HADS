Imports System.Data.SqlClient
Imports BaseDeDatos.accesodatosSQL

Public Class tareasAlumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        cerrarconexion()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        conectar()
        DropDownList1.AutoPostBack = True
        GridView1.AutoGenerateSelectButton = True

        If Not Page.IsPostBack Then
            Dim st = "select codigoasig from EstudiantesGrupo inner join GruposClase on EstudiantesGrupo.Grupo = GruposClase.codigo where email='" & Session("email") & "'"
            Dim RS As SqlDataReader
            Try
                RS = getDatos(st)
            Catch ex As Exception
                Exit Sub
            End Try
            While (RS.Read())
                DropDownList1.Items.Add(RS.Item("codigoasig"))
            End While
            RS.Close()

            Dim ds = cargarTareasGenericas(DropDownList1.SelectedValue, Session("email"))
            Dim dt = ds.Tables("TareasGenericas")

            GridView1.DataSource = dt
            GridView1.DataBind()
            Session("ds") = ds
            Session("tabla") = dt

        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        Response.Redirect("inicio.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim ds = cargarTareasGenericas(DropDownList1.SelectedValue, Session("email"))
        Dim dt = ds.Tables("TareasGenericas")
        Session("tabla") = dt

        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim tabla = Session("tabla")
        Dim cod = tabla.Rows(GridView1.SelectedIndex).Item("Codigo")
        Dim horas = tabla.Rows(GridView1.SelectedIndex).Item("HEstimadas")
        Dim usuario = Session("email")

        Response.Redirect("InstanciarTarea.aspx?tarea=" & cod & "&usuario=" & usuario & "&horas=" & horas)

    End Sub

    Protected Sub SortRecords(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression
        Dim direction As String = String.Empty

        If SortDirection = SortDirection.Ascending Then

            SortDirection = SortDirection.Descending

            direction = " DESC"

        Else

            SortDirection = SortDirection.Ascending

            direction = " ASC"

        End If

        Dim table As DataTable = Session("tabla")

        table.DefaultView.Sort = sortExpression & direction

        GridView1.DataSource = table
        GridView1.DataBind()

    End Sub

    Public Property SortDirection() As SortDirection

        Get

            If ViewState("SortDirection") Is Nothing Then

                ViewState("SortDirection") = SortDirection.Ascending

            End If

            Return DirectCast(ViewState("SortDirection"), SortDirection)

        End Get

        Set(ByVal value As SortDirection)

            ViewState("SortDirection") = value

        End Set

    End Property
End Class