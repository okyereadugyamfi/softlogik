Imports System.Globalization

Namespace Data

#Region "DataStore Inteface"
    Public Interface ISPDataStore
        ' This interface enables a simplified and structured access to any data source
        ' all data components should use this inteface
        Function GetTable(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing, Optional ByVal Direct As Boolean = False) As DataTable
        Function GetReader(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing) As IDataReader
        Function GetString(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing) As String
        Function ExecuteCommand(ByVal ExecuteText As String, Optional ByRef Params As SPDataParamCollection = Nothing) As Object
        ' Function UpdateDataset(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection) As Object
        'Function UpdateTable(ByVal ExecuteText As String, ByRef Params As SPDataParamCollection) As Object
        Function BeginTransaction() As Boolean
        Function CommitTransaction() As Boolean
        Function AbortTransaction() As Boolean
    End Interface

#End Region

#Region "ISPDataStore Support"


    Public Class SPDataEntity(Of DataEntityType)

    End Class

    Public Class SPDataParam
        Private m_strName As String
        Private m_objValue As Object


        'Constructors
        Public Sub New()
            Me.Name = vbNullString
            Me.Value = Nothing
        End Sub

        Public Sub New(ByVal Name As String, ByVal Value As Object)
            Me.Name = Name
            Me.Value = Value
        End Sub

        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        Public Property Value() As Object
            Get
                Return m_objValue
            End Get
            Set(ByVal value As Object)
                m_objValue = value
            End Set
        End Property
    End Class
    Public Class SPDataParamCollection
        Inherits CollectionBase

        Public Function Add(ByVal Name As String, ByVal Value As Object) As SPDataParam
            Dim objNew As SPDataParam = New SPDataParam(Name, Value)
            List.Add(objNew)

            Return objNew
        End Function
    End Class


    Public Enum SPDataCommandPriority
        Highest
        High
        Medium
        Low
        Lowest
    End Enum

    Public Enum SPDataCommandType
        None
        StoredProcedure
        CommandText
        Both
    End Enum

    Public Class SPCommandParam
        Private m_strName As String
        Private m_objCommand As Object
        Private m_enmPriority As SPDataCommandPriority


        'Constructors
        Public Sub New()
            Me.Name = vbNullString
            Me.Command = Nothing
        End Sub

        Public Sub New(ByVal Name As String, ByVal Value As Object)
            Me.Name = Name
            Me.Command = Value
        End Sub

        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        Public Property Command() As Object
            Get
                Return m_objCommand
            End Get
            Set(ByVal value As Object)
                m_objCommand = value
            End Set
        End Property

        Public Property Priority() As SPDataCommandPriority
            Get
                Return m_enmPriority
            End Get
            Set(ByVal value As SPDataCommandPriority)
                m_enmPriority = value
            End Set
        End Property
    End Class
    Public Class SPCommandParamCollection
        Inherits CollectionBase

        Public Function Add(ByVal Name As String, ByVal Value As Object) As SPCommandParam
            Dim objNew As SPCommandParam = New SPCommandParam(Name, Value)
            List.Add(objNew)
            Return objNew
        End Function
    End Class
#End Region

End Namespace
