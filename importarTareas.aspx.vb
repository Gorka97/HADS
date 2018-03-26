Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports BaseDeDatos.accesodatosSQL

Public Class importarTareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ButtonImportar_Click(sender As Object, e As EventArgs) Handles ButtonImportar.Click
        Dim da = obtenerTareas()
        Dim ds As New DataSet
        da.Fill(ds, "TareasGenericas")
        Dim dt = ds.Tables("TareasGenericas")

        Session("dsInsertar") = ds
        Session("adapter") = da
        Dim builder As New SqlCommandBuilder(da)

        Dim asig = DropDownList1.SelectedValue
        Dim xd As New XmlDocument
        xd.Load(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"))
        Dim tareas As XmlNodeList
        tareas = xd.GetElementsByTagName("tarea")
        Dim i As Integer
        For i = 0 To tareas.Count - 1
            Dim rowMbrs As DataRow = dt.NewRow()
            rowMbrs("CodAsig") = asig
            rowMbrs("Codigo") = tareas(i).Attributes(0).Value
            rowMbrs("Descripcion") = tareas(i).ChildNodes(0).ChildNodes(0).Value
            rowMbrs("HEstimadas") = tareas(i).ChildNodes(1).ChildNodes(0).Value
            rowMbrs("Explotacion") = tareas(i).ChildNodes(2).ChildNodes(0).Value
            rowMbrs("TipoTarea") = tareas(i).ChildNodes(3).ChildNodes(0).Value
            dt.Rows.Add(rowMbrs)
        Next
        da.Update(ds, "TareasGenericas")
        ds.AcceptChanges()

    End Sub

    Protected Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound, DropDownList1.SelectedIndexChanged

        If File.Exists(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml")) Then
            Xml1.DocumentSource = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml")
            Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl")
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Session.Abandon()
        Response.Redirect("inicio.aspx")
    End Sub
End Class