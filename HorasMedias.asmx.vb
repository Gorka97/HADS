Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports BaseDeDatos.accesodatosSQL

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class HorasMedias
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hola a todos"
    End Function

    <WebMethod()>
    Public Function media(Asig As String) As String
        conectar()
        Dim comando As New SqlCommand
        Dim st = "SELECT AVG(HReales) FROM EstudiantesTareas inner join TareasGenericas ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo WHERE (TareasGenericas.CodAsig='" + Asig + "')"
        Dim RS As SqlDataReader
        RS = getDatos(st)
        RS.Read()
        Dim res As String = RS.GetSqlValue(0).ToString
        RS.Close()
        Return res

    End Function

End Class