 
Partial Class DSFilters
    Partial Class SPFilterTableDataTable

        Private Sub SPFilterTableDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.FilterIDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
