Imports System

Namespace Security
    Public Interface IUserManager
        Function Authenticate(ByVal applicationName As String, ByVal userName As String, ByVal password As String) As Boolean
        Function IsInRole(ByVal applicationName As String, ByVal userName As String, ByVal role As String) As Boolean
        Function GetRoles(ByVal applicationName As String, ByVal userName As String) As String()
    End Interface
End Namespace


