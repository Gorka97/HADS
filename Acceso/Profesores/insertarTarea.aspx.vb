Imports System.Data.SqlClient
Imports BaseDeDatos.accesodatosSQL

Public Class insertarTarea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim da = obtenerTareas()
        Dim ds As New DataSet
        da.Fill(ds, "ProfesoresTareas")
        Dim dt = ds.Tables("ProfesoresTareas")

        Session("dsInsertar") = ds
        Session("adapter") = da
        Dim builder As New SqlCommandBuilder(da)

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()
        Response.Redirect("inicio.aspx")
    End Sub

    Protected Sub ButtonTarea_Click(sender As Object, e As EventArgs) Handles ButtonTarea.Click
        Dim codigo = TextBoxCodigo.Text
        Dim descrip = TextBoxDescripcion.Text
        Dim codAsig = DropDownListAsignatura.SelectedValue
        Dim hEst = TextBoxHorasEst.Text
        Dim tipoTarea = DropDownListTarea.SelectedValue

        Dim da As SqlDataAdapter
        da = Session("adapter")
        Dim ds As DataSet
        ds = Session("dsInsertar")
        Dim dt As DataTable
        dt = ds.Tables("ProfesoresTareas")
        Dim rowMbrs As DataRow = dt.NewRow()
        rowMbrs("Codigo") = codigo
        rowMbrs("Descripcion") = descrip
        rowMbrs("CodAsig") = codAsig
        rowMbrs("HEstimadas") = hEst
        rowMbrs("Explotacion") = False
        rowMbrs("TipoTarea") = tipoTarea
        dt.Rows.Add(rowMbrs)
        da.Update(ds, "ProfesoresTareas")
        ds.AcceptChanges()

    End Sub
End Class