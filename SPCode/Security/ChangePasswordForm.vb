
Namespace Security
    Public Class ChangePasswordForm

        Private m_Authenticated As Boolean
        Public Sub New()
            Authenticated = False
            InitializeComponent()
        End Sub
        Public Property Authenticated() As Boolean
            Get
                Return m_Authenticated
            End Get
            Protected Set(ByVal value As Boolean)
                m_Authenticated = value
            End Set
        End Property
        Private Sub OnLogin(ByVal sender As Object, ByVal args As LoginEventArgs)
            Dim successful As Boolean = args.Authenticated
            If successful = False Then
                MessageBox.Show("Invalid user name or password. Please try again", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Else
                Authenticated = True
                Close()
            End If
        End Sub
        Public Shared Sub Logout()
            SPLoginControl.Logout()
        End Sub
        Public Shared ReadOnly Property IsLoggedIn() As Boolean
            Get
                Return SPLoginControl.IsLoggedIn
            End Get
        End Property
    End Class
End Namespace