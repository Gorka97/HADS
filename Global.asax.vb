Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la aplicación
        Dim Alumnos As New ArrayList
        Dim Profesores As New ArrayList
        Application.Contents("Alumnos") = Alumnos
        Application.Contents("Profesores") = Profesores
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al iniciar la sesión
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al comienzo de cada solicitud
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena al intentar autenticar el uso
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando se produce un error
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la sesión
        Application.Lock()
        Dim s As String
        Dim array As New ArrayList
        s = Session("tipo")
        If (s.Equals("P")) Then
            array = Application.Contents("Profesores")
            s = Session("email")
            array.Remove(s)
            Application.Contents("Profesores") = array
        ElseIf s.Equals("A") Then
            array = Application.Contents("Alumnos")
            s = Session("email")
            array.Remove(s)
            Application.Contents("Alumnos") = array
        End If

        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Se desencadena cuando finaliza la aplicación
    End Sub

End Class