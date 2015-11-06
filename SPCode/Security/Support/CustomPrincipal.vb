Imports System
Imports System.Threading
Imports System.Diagnostics
Imports System.Security.Principal

Namespace Security
    Friend Class CustomPrincipal
        Implements IPrincipal
        Private m_User As IIdentity
        Private m_OldPrincipal As IPrincipal
        Private m_UserManager As IUserManager
        Private m_ApplicationName As String
        Private m_Roles As String()
        Private Shared m_ThreadPolicySet As Boolean = False

        Private Sub New(ByVal user As IIdentity, ByVal applicationName As String, ByVal userManager As IUserManager, ByVal cacheRoles As Boolean)
            m_OldPrincipal = Thread.CurrentPrincipal

            m_User = user
            m_ApplicationName = applicationName
            m_UserManager = userManager

            If cacheRoles Then
                m_Roles = m_UserManager.GetRoles(m_ApplicationName, m_User.Name)
            End If
            'Make this object the principal for this thread
            Thread.CurrentPrincipal = Me
        End Sub
        Public Shared Sub Attach(ByVal user As IIdentity, ByVal applicationName As String, ByVal userManager As IUserManager)
            Attach(user, applicationName, userManager, False)
        End Sub
        Public Shared Sub Attach(ByVal user As IIdentity, ByVal applicationName As String, ByVal userManager As IUserManager, ByVal cacheRoles As Boolean)
            Debug.Assert(user.IsAuthenticated)

            Dim _customPrincipal As IPrincipal = New CustomPrincipal(user, applicationName, userManager, cacheRoles)

            'Make sure all future threads in this app domain use this principal
            'but because default principal cannot be set twice:
            If m_ThreadPolicySet = False Then
                Dim currentDomain As AppDomain = AppDomain.CurrentDomain
                currentDomain.SetThreadPrincipal(_customPrincipal)
                m_ThreadPolicySet = True
            End If
        End Sub
        Public Sub Detach()
            Thread.CurrentPrincipal = m_OldPrincipal
        End Sub

        Public ReadOnly Property Identity() As IIdentity Implements IPrincipal.Identity
            Get
                Return m_User
            End Get
        End Property
        Public Function IsInRole(ByVal role As String) As Boolean Implements IPrincipal.IsInRole
            If Not m_Roles Is Nothing Then
                For Each itm As String In m_Roles
                    If itm = role Then
                        Return True
                    End If
                Next
            Else
                Return m_UserManager.IsInRole(m_ApplicationName, m_User.Name, role)
            End If
        End Function

    End Class
End Namespace
