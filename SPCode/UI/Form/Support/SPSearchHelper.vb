Imports SoftLogik.Win.Data
Imports SoftLogik.Win.SPDataProxy
Imports SoftLogik.Win.SPDataProxyTableAdapters

Namespace UI
    Public Class SPSearchHelper

        Public Shared Function GetSearchResults(ByVal SearchType As String, ByVal SubType As String, _
                                ByVal SearchFor As String, ByVal SearchItem As String, Optional ByVal ConnectionString As String = Nothing) As SPDataProxy.SPLookupDataTable
            If String.IsNullOrEmpty(ConnectionString) Then
                Using lookupAdapter As New taSPLookup
                    Return lookupAdapter.GetSearchResults(SearchType, SubType, SearchFor, SearchItem)
                End Using
            Else
                Dim lookupAdapter As ISPDataStore = New SQLDataStore(New SqlClient.SqlConnection(ConnectionString))
                Dim objParams As New SPDataParamCollection

                With objParams
                    .Add("@SearchType", SearchType)
                    .Add("@SubType", SubType)
                    .Add("@SearchFor", SearchFor)
                    .Add("@SearchItem", SearchItem)
                End With

                Dim genericSearchTable As DataTable = lookupAdapter.GetTable("SPLookup_Search", objParams)
                Dim searchTable As New SPDataProxy.SPLookupDataTable()
                searchTable.Load(genericSearchTable.CreateDataReader)
                Return searchTable
            End If
        End Function
    End Class
End Namespace

