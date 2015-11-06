Imports System
Imports System.Web.Services.Protocols
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Configuration

Namespace Security
    <DebuggerStepThrough(), WebServiceBinding(Name:="WindowsUserManagerSoap", Namespace:="http://SecurityServices")> _
    Partial Friend Class UserManager
        Inherits SoapHttpClientProtocol
        Implements IUserManager
        Public Sub New()
            CookieContainer = New System.Net.CookieContainer()
            Dim urlSetting As String = ConfigurationManager.AppSettings("UserManager")
            If Not urlSetting Is Nothing Then
                Url = urlSetting
            Else
                Trace.TraceWarning("No URL was found in application configuration file")
            End If
        End Sub
        Public Sub New(ByVal url As String)
            CookieContainer = New System.Net.CookieContainer()
            url = url
        End Sub
        <SoapDocumentMethod("http://SecurityServices/Authenticate")> _
        Public Function Authenticate(ByVal applicationName As String, ByVal userName As String, ByVal password As String) As Boolean Implements Security.IUserManager.Authenticate
            Dim parameters As String() = {applicationName, userName, password}
            Dim results As Object() = Invoke("Authenticate", parameters)
            Return (CBool(results(0)))
        End Function
        <SoapDocumentMethod("http://SecurityServices/IsInRole")> _
        Public Function IsInRole(ByVal applicationName As String, ByVal userName As String, ByVal role As String) As Boolean Implements Security.IUserManager.IsInRole
            Dim parameters As String() = {applicationName, userName, role}
            Dim results As Object() = Invoke("IsInRole", parameters)
            Return (CBool(results(0)))
        End Function
        <SoapDocumentMethod("http://SecurityServices/GetRoles")> _
        Public Function GetRoles(ByVal applicationName As String, ByVal userName As String) As String() Implements Security.IUserManager.GetRoles
            Dim parameters As String() = {applicationName, userName}
            Dim results As Object() = Invoke("GetRoles", parameters)
            Return (CType(results(0), String()))
        End Function
    End Class
End Namespace
