
Public Structure SPPolicy

    Private m_strName As String
    Private m_hshPolicyData As Hashtable

    Public Property Name() As String
        Get
            Return m_strName
        End Get
        Set(ByVal value As String)
            m_strName = value
        End Set
    End Property
    Public Property PolicyData() As Hashtable
        Get
            Return m_hshPolicyData
        End Get
        Set(ByVal value As Hashtable)
            m_hshPolicyData = value
        End Set
    End Property

End Structure

