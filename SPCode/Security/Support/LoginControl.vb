'Questions? Comments? go to 
'http://www.idesign.net

#Region "Using directives"

Imports System
Imports System.Threading
Imports System.Security.Principal
Imports System.Diagnostics
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

#End Region

Namespace Security
    <DefaultEvent("LoginEvent"), ToolboxBitmap(GetType(SPLoginControl), "LoginControl.bmp")> _
    Public MustInherit Class SPLoginControl

        Private m_ApplicationName As String = String.Empty
        Private m_CacheRoles As Boolean = False

        Public Event LoginEvent As EventHandler(Of LoginEventArgs)

        <Category("Credentials")> _
        Public Property CacheRoles() As Boolean
            Get
                Return m_CacheRoles
            End Get
            Set(ByVal value As Boolean)
                m_CacheRoles = value
            End Set
        End Property
        <Category("Credentials")> _
        Public Property ApplicationName() As String
            Get
                Return m_ApplicationName
            End Get

            Set(ByVal value As String)
                m_ApplicationName = value
            End Set
        End Property

        Private Function GetAppName() As String
            If ApplicationName <> String.Empty Then
                Return ApplicationName
            End If
            Dim clientAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly()
            Dim assemblyName As AssemblyName = clientAssembly.GetName()
            Return assemblyName.Name
        End Function
        Public Shared Sub Logout()
            Dim customPrincipal As CustomPrincipal = TryCast(Thread.CurrentPrincipal, CustomPrincipal)
            If Not customPrincipal Is Nothing Then
                customPrincipal.Detach()
            End If
        End Sub
        Public Shared ReadOnly Property IsLoggedIn() As Boolean
            Get
                Return TypeOf Thread.CurrentPrincipal Is CustomPrincipal
            End Get
        End Property

        Protected Overridable Sub OnLogin(ByVal sender As Object, ByVal e As EventArgs) Handles m_LogInButton.Click
            Dim userName As String = m_UserNameBox.Text
            Dim password As String = m_PasswordBox.Text

            If userName = String.Empty Then
                m_ErrorProvider.SetError(m_UserNameBox, "Please Enter User Name")
                Return
            Else
                m_ErrorProvider.SetError(m_UserNameBox, String.Empty)
            End If
            If password = String.Empty Then
                m_ErrorProvider.SetError(m_PasswordBox, "Please Enter Password")
                Return
            Else
                m_ErrorProvider.SetError(m_PasswordBox, String.Empty)
            End If
            Dim applicationName As String = GetAppName()
            Dim userManager As IUserManager = GetUserManager()

            Dim authenticated As Boolean = userManager.Authenticate(applicationName, userName, password)
            If authenticated Then
                Dim identity As IIdentity = New GenericIdentity(userName)
                CustomPrincipal.Attach(identity, applicationName, userManager, CacheRoles)
            End If
            Dim loginEventArgs As LoginEventArgs = New LoginEventArgs(authenticated)

            RaiseEvent LoginEvent(Me, loginEventArgs)
        End Sub

        Protected MustOverride Function GetUserManager() As IUserManager

    End Class



End Namespace