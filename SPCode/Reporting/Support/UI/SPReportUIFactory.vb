
Namespace Reporting
    Public Class SPReportUIFactory
        Public Shared Function GetDefaultFilterList() As DSFilters.SPFilterTableDataTable
            Dim newFilterTable As New DSFilters.SPFilterTableDataTable
            Return newFilterTable
        End Function


    End Class
End Namespace
