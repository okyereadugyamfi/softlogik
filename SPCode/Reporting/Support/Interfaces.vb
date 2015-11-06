Namespace Reporting
    Public Class SPReportFilterValue

        Private _Name As String
        Private _Value As Object = Nothing

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property Value() As Object
            Get
                Return _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property

    End Class

    Public Class SPReportFilterValueCollection
        Inherits List(Of SPReportFilterValue)

    End Class

    Public Delegate Function SPAdvancedSearchDelegate(ByVal Options As String) As SPReportFilterValue
    Public Delegate Function SPFilterSetupDelegate(ByVal Options As String) As SPReportFilterValueCollection

End Namespace
