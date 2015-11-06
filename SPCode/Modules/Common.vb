


Module Common

    Private m_frmMainShell As Form

    Public ReadOnly Property MainShell() As Form
        Get
            Return m_frmMainShell
        End Get
    End Property

    Friend Sub SetMainShell(ByRef NewShell As Form)
        m_frmMainShell = NewShell
    End Sub

End Module


Public Class FormDataState
    Private m_boolShowState As Boolean
    Private m_boolEditState As Boolean
    Private m_boolNewState As Boolean

    Public Sub New()
        m_boolEditState = False
        m_boolShowState = False
        m_boolNewState = False
    End Sub

    Public Sub New(ByVal ShowState As Boolean, Optional ByVal EditState As Boolean = False, Optional ByVal NewState As Boolean = False)
        m_boolEditState = ShowState
        m_boolShowState = EditState
        m_boolNewState = NewState
    End Sub

    Property ShowState() As Boolean
        Get
            Return m_boolShowState
        End Get
        Set(ByVal Value As Boolean)
            m_boolShowState = Value
        End Set
    End Property
    Property EditState() As Boolean
        Get
            Return m_boolEditState
        End Get
        Set(ByVal Value As Boolean)
            m_boolEditState = Value
        End Set
    End Property
    Property NewState() As Boolean
        Get
            Return m_boolNewState
        End Get
        Set(ByVal Value As Boolean)
            m_boolNewState = Value
        End Set
    End Property

End Class

