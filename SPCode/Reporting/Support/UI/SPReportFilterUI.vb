Namespace Reporting
    Public Class SPReportFilterUI

        Private _Filters As SPReportFilterCollection
        Private _Operators As ArrayList

        Public WriteOnly Property Filters() As SPReportFilterCollection
            Set(ByVal value As SPReportFilterCollection)
                _Filters = value
            End Set
        End Property

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            If Not DesignMode Then
                FilterList.DataSource = SPReportUIFactory.GetDefaultFilterList
            End If
            BuildFieldList()
            BuildOperatorList()
            MyBase.OnLoad(e)
        End Sub

        Private Sub BuildFieldList()
            If _Filters IsNot Nothing Then
                bsFields.DataSource = _Filters

                Dim fieldColumn As DataGridViewComboBoxColumn = DirectCast(FilterList.Columns("FieldDataGridViewTextBoxColumn"), DataGridViewComboBoxColumn)

                If fieldColumn IsNot Nothing Then
                    With fieldColumn
                        .DataSource = bsFields
                        .DisplayMember = "DisplayMember"
                        .ValueMember = "ValueMember"
                    End With
                End If
            End If
        End Sub
        Private Sub BuildOperatorList()
            _Operators = SPComparisonsHelper.GetComparisonDataList(GetType(SPComparisons))
            If _Operators IsNot Nothing Then
                bsOperators.DataSource = _Operators

                Dim operatorColumn As DataGridViewComboBoxColumn = DirectCast(FilterList.Columns("OperationDataGridViewTextBoxColumn"), DataGridViewComboBoxColumn)

                If operatorColumn IsNot Nothing Then
                    With operatorColumn
                        .DataSource = bsOperators
                        .DisplayMember = "Name"
                        .ValueMember = "Value"
                    End With
                End If
            End If
        End Sub

        Private Sub btnAddFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            bsFilterTable.AddNew()
        End Sub

        Private Sub NewFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFilter.Click
            bsFilterTable.AddNew()
        End Sub

        Private Sub DeleteFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFilter.Click
            Try
                bsFilterTable.RemoveCurrent()
            Catch ex As Exception
            End Try

        End Sub
    End Class
End Namespace

