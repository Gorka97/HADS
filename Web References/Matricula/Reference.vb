﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
'
Namespace Matricula
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="MatriculasBinding", [Namespace]:="http://ehusw.es/jav/ServiciosWeb/comprobarmatricula.php?wsdl")>  _
    Partial Public Class Matriculas
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private comprobarOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Lab2.My.MySettings.Default.Lab2_Matricula_Matriculas
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event comprobarCompleted As comprobarCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ehusw.es/jav/ServiciosWeb/comprobarmatricula.php/comprobar", RequestNamespace:="http://ehusw.es/jav/ServiciosWeb/comprobarmatricula.php?wsdl", ResponseNamespace:="http://ehusw.es/jav/ServiciosWeb/comprobarmatricula.php?wsdl")>  _
        Public Function comprobar(ByVal x As String) As <System.Xml.Serialization.SoapElementAttribute("z")> String
            Dim results() As Object = Me.Invoke("comprobar", New Object() {x})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub comprobarAsync(ByVal x As String)
            Me.comprobarAsync(x, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub comprobarAsync(ByVal x As String, ByVal userState As Object)
            If (Me.comprobarOperationCompleted Is Nothing) Then
                Me.comprobarOperationCompleted = AddressOf Me.OncomprobarOperationCompleted
            End If
            Me.InvokeAsync("comprobar", New Object() {x}, Me.comprobarOperationCompleted, userState)
        End Sub
        
        Private Sub OncomprobarOperationCompleted(ByVal arg As Object)
            If (Not (Me.comprobarCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent comprobarCompleted(Me, New comprobarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")>  _
    Public Delegate Sub comprobarCompletedEventHandler(ByVal sender As Object, ByVal e As comprobarCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class comprobarCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
