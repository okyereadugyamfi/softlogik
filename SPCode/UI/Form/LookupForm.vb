Namespace UI
    Public Class LookupForm

        Public Event ItemSelected(ByVal e As SPLookupFormItemSelectedEventArgs)


#Region "Data Members"

        Private _DataSource As SPDataProxy.SPLookupDataTable
        Private Shared _SearchDBConnection As String = String.Empty
#End Region

#Region "Properties"
        Private _SearchType As String = String.Empty
        Public Property SearchType() As String
            Get
                Return _SearchType
            End Get
            Set(ByVal value As String)
                _SearchType = value
            End Set
        End Property

        Private _SubType As String = String.Empty
        Public Property SubType() As String
            Get
                Return _SubType
            End Get
            Set(ByVal value As String)
                _SubType = value
            End Set
        End Property

        Private _SearchResults As DataGridViewSelectedRowCollection = Nothing
        Private _FirstResult As DataGridViewRow = Nothing

        Public ReadOnly Property FirstResult() As DataGridViewRow
            Get
                Return _FirstResult
            End Get
        End Property
        Public ReadOnly Property SearchResults() As DataGridViewSelectedRowCollection
            Get
                Return _SearchResults
            End Get
        End Property
        Public Shared WriteOnly Property SearchDBConnection() As String
            Set(ByVal value As String)
                _SearchDBConnection = value
            End Set
        End Property
#End Region

        Private Sub BindResultList()
            bsSimpleSearch.DataSource = SPSearchHelper.GetSearchResults(SearchType, SubType, SearchFor.Text, SearchText.Text, _SearchDBConnection)
            SimpleResults.DataSource = bsSimpleSearch

            SimpleResults.Columns("ID").Visible = False
            SimpleResults.Columns("Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub
        Private Sub SimpleResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SimpleResults.DoubleClick
            If SimpleResults.SelectedRows IsNot Nothing AndAlso SimpleResults.SelectedRows.Count > 0 Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                RaiseEvent ItemSelected(New SPLookupFormItemSelectedEventArgs(SimpleResults.SelectedRows(0), SimpleResults.SelectedRows))

                _FirstResult = SimpleResults.SelectedRows(0)
                _SearchResults = SimpleResults.SelectedRows
            End If
        End Sub
        Private Sub SearchFor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchFor.SelectedIndexChanged
            If SearchText.CanFocus Then SearchText.Focus()
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            On Error Resume Next
            Me.DockState = WeifenLuo.WinFormsUI.DockState.DockLeftAutoHide
            SearchFor.SelectedIndex = 0
            BindResultList()

            MyBase.OnLoad(e)
        End Sub
        Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
            'Me.DialogResult = CType(IIf(e.CloseReason <> CloseReason.UserClosing, System.Windows.Forms.DialogResult.OK, System.Windows.Forms.DialogResult.Cancel), System.Windows.Forms.DialogResult)
            MyBase.OnFormClosing(e)
        End Sub

        Private Sub SearchText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchText.TextChanged
            BindResultList()
        End Sub
    End Class

    Public Class SPLookupFormItemSelectedEventArgs
        Inherits EventArgs

        Private _SelectedItems As DataGridViewSelectedRowCollection = Nothing
        Private _FirstItem As DataGridViewRow = Nothing

        Public ReadOnly Property FirstItem() As DataGridViewRow
            Get
                Return _FirstItem
            End Get
        End Property
        Public ReadOnly Property SelectedItems() As DataGridViewSelectedRowCollection
            Get
                Return _SelectedItems
            End Get
        End Property

        Public Sub New(ByVal FirstItem As DataGridViewRow, ByVal SelectedItems As DataGridViewSelectedRowCollection)
            Me._FirstItem = FirstItem
            Me._SelectedItems = SelectedItems
        End Sub
    End Class


End Namespace
