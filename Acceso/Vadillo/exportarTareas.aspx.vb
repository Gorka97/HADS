Imports System.Xml
Imports BaseDeDatos.accesodatosSQL
Public Class exportarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ButtonImportar_Click(sender As Object, e As EventArgs) Handles ButtonImportar.Click
        Dim cod = DropDownList1.SelectedValue
        Dim da = obtenerTareasCod(cod)
        Dim ds As New DataSet
        ds.DataSetName = "tareas"
        da.Fill(ds, "tarea")
        ds.Tables("tarea").Columns.Item("CodAsig").ColumnMapping = MappingType.Hidden
        ds.Tables("tarea").Columns.Item("Codigo").ColumnMapping = MappingType.Attribute
        For Each dc In ds.Tables("tarea").Columns
            dc.ColumnName = dc.ColumnName.ToLower
        Next
        ds.WriteXml(Server.MapPath("./App_Data/" & DropDownList1.SelectedValue & ".xml"))
        LabelError.Text = "Tareas exportadas correctamente"

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()
        Response.Redirect("inicio.aspx")
    End Sub
End Class