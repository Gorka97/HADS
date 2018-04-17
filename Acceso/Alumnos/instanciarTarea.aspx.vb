Imports BaseDeDatos.accesodatosSQL
Imports System.Data.SqlClient

Public Class instanciarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim usuario = Request.QueryString("usuario")
        Dim tarea = Request.QueryString("tarea")
        Dim horas = Request.QueryString("horas")
        Dim da = obtenerInstanciadas(usuario)

        Dim ds As New DataSet
        da.Fill(ds, "EstudiantesTareas")
        Dim dt = ds.Tables("EstudiantesTareas")
        Session("dsInstanciar") = ds
        GridViewTareas.DataSource = dt
        GridViewTareas.DataBind()

        TextBoxUsuario.Text = usuario
        TextBoxUsuario.Enabled = False
        TextBoxTarea.Text = tarea
        TextBoxTarea.Enabled = False
        TextBoxHorasEst.Text = horas
        TextBoxHorasEst.Enabled = False

        Session("adapter") = da

        Dim builder As New SqlCommandBuilder(da)

    End Sub

    Protected Sub ButtonTarea_Click(sender As Object, e As EventArgs) Handles ButtonTarea.Click

        Dim usuario = Request.QueryString("usuario")
        Dim tarea = Request.QueryString("tarea")
        Dim horasEst = Request.QueryString("horas")
        Dim horasReal As String = TextBoxHorasReal.Text

        Dim da As SqlDataAdapter
        da = Session("adapter")
        Dim ds As DataSet
        ds = Session("dsInstanciar")
        Dim dt As DataTable
        dt = ds.Tables("EstudiantesTareas")

        Dim rowMbrs As DataRow = dt.NewRow()
        rowMbrs("email") = usuario
        rowMbrs("codTarea") = tarea
        rowMbrs("HEstimadas") = horasEst
        rowMbrs("HReales") = horasReal
        dt.Rows.Add(rowMbrs)
        GridViewTareas.DataSource = dt
        GridViewTareas.DataBind()
        da.Update(ds, "EstudiantesTareas")

        TextBoxHorasReal.Enabled = False
        ButtonTarea.Enabled = False

    End Sub
End Class