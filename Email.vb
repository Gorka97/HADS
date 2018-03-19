Imports System.Net.Mail

Public Class Email
    Public Function EnviarEmailConfirmacion(NumConf As String, Email As String) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("garce012@ikasle.ehu.eus", "Gorka")
            'Direccion de destino
            Dim to_address As New MailAddress(Email)
            'Password de la cuenta
            Dim from_pass As String = "******"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.es"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Confirmar registro"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "Para completar su registro acceda a la direccion http://hads18-24.azurewebsites.net/confirmar.aspx?cod=" + NumConf + "&email=" + Email + "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function EnviarEmailModificar(NumConf As String, Email As String) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New MailAddress("garce012@ikasle.ehu.eus", "Gorka")
            'Direccion de destino
            Dim to_address As New MailAddress(Email)
            'Password de la cuenta
            Dim from_pass As String = "*******"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.es"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Modificar contraseña"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>" + "Para modificar su contraseña introduzca el codigo " + NumConf + " en la direccion http://hads18-24.azurewebsites.net/cambiarPassword.aspx" + "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function
End Class
