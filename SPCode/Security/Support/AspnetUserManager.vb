'Questions? Comments? go to 
'http://www.idesign.net

Imports System
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Web.Security

Namespace Security
    Friend Class AspNetUserManager
        Implements IUserManager
        Public Function Authenticate(ByVal applicationName As String, ByVal userName As String, ByVal password As String) As Boolean Implements Security.IUserManager.Authenticate
            Membership.ApplicationName = applicationName
            Return Membership.ValidateUser(userName, password)
        End Function
        Public Function IsInRole(ByVal applicationName As String, ByVal userName As String, ByVal role As String) As Boolean Implements Security.IUserManager.IsInRole
            Roles.ApplicationName = applicationName
            Return Roles.IsUserInRole(userName, role)
        End Function
        Public Function GetRoles(ByVal applicationName As String, ByVal userName As String) As String() Implements Security.IUserManager.GetRoles
            Roles.ApplicationName = applicationName
            Return Roles.GetRolesForUser(userName)
        End Function
    End Class
End Namespace
