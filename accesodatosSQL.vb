Imports System.Data.SqlClient

Public Class accesodatosSQL
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hads24-2018.database.windows.net,1433;Initial Catalog=HADS24-TAREAS;Persist Security Info=False;User ID=Gorka;Password=********;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellido As String, ByVal pass As String, ByVal rol As String, ByVal numconf As Integer) As Boolean
        Dim val As Byte
        val = 0
        Dim st = "insert into Usuarios values ('" & email & "', '" & nombre & "', '" & apellido & "', " & numconf & ", " & val & " , '" & rol & "', '" & pass & "')"
        Dim numregs As Integer

        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
            If numregs = 1 Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function    Public Shared Function getDatos(ByVal instruccion As String) As SqlDataReader
        Dim st = instruccion
        comando = New SqlCommand(st, conexion)
        Return (comando.ExecuteReader())
    End Function    Public Shared Function updateDatos(ByVal instruccion As String) As Boolean
        Dim st = instruccion
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
            If numregs = 1 Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class
