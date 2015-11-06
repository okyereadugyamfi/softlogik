Namespace UI
    Public Class SetupForm

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            If Not DesignMode Then
                CreateSetupView(_DataSource, _BindingSettings)
                ToolbarToggleDefault(tbrMain, tvwName)
                If _DataSource Is Nothing Then
                    OnNewRecord()
                ElseIf _DataSource.Rows.Count = 0 Then
                    OnNewRecord()
                End If
            End If
        End Sub

        Protected Overrides Sub OnFieldChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If _RecordState.ShowingData = False Then
                If _RecordState.CurrentState = SPFormRecordModes.EditMode AndAlso _
                _RecordState.CurrentState <> SPFormRecordModes.DirtyMode AndAlso (Not _RecordState.BindingData) Then
                    _RecordState.CurrentState = SPFormRecordModes.DirtyMode
                    UpdateFormCaption()
                    ToolbarToggleSave(tbrMain, tvwName)
                End If
            End If
            _RecordState.BindingData = False
        End Sub
        Protected Overrides Sub OnNewRecord()
            Try
                DetailBinding.AddNew()
                Me._RecordState.CurrentState = SPFormRecordModes.InsertMode
                ToolbarToggleSave(tbrMain, tvwName)
                FirstFieldFocus()
            Catch ex As Exception
            End Try
        End Sub
        Protected Overrides Sub OnSaveRecord()
            MyBase.OnSaveRecord()
            If DetailBinding.Current IsNot Nothing Then
                RefreshMaster()
                ToolbarToggleDefault(tbrMain, tvwName)
            End If
        End Sub
        Protected Overrides Sub OnRefreshRecord()
            Try
                Me._RecordState.CurrentState = SPFormRecordModes.EditMode
                Me._RecordState.ShowingData = True
                OnLoad(New EventArgs())
                FirstFieldFocus()
                Me._RecordState.ShowingData = False
            Catch ex As Exception
            End Try
        End Sub

        Private _lastSortOrder As String = " DESC "
        Protected Overrides Sub OnSortRecord()
            Try
                Me._RecordState.CurrentState = SPFormRecordModes.EditMode
                Me._RecordState.ShowingData = True
                _DataSource.DefaultView.Sort = _BindingSettings.DisplayMember & _lastSortOrder
                If _lastSortOrder = " ASC " Then _lastSortOrder = " DESC " Else _lastSortOrder = " ASC "

                RefreshMaster()
                Me._RecordState.ShowingData = False
                FirstFieldFocus()
            Catch ex As Exception
            End Try
        End Sub
        Protected Overrides Sub OnDeleteRecord()
            MyBase.OnDeleteRecord()
            _RecordState.ShowingData = True
            RefreshMaster()
            _RecordState.ShowingData = False
        End Sub
        Protected Overrides Sub OnUndoRecord()
            MyBase.OnUndoRecord()
            ToolbarToggleDefault(tbrMain, tvwName)
        End Sub
        Protected Overrides Sub OnNavigate(ByVal direction As SPRecordNavigateDirections)
            MyBase.OnNavigate(direction)
            _RecordState.ShowingData = True
            SyncNameList()
            _RecordState.ShowingData = False
        End Sub

        Protected Overridable Sub SyncNameList()
            For Each node As SPTreeNode In tvwName.Nodes
                If (node.Index = DetailBinding.Position) Then
                    tvwName.SelectedNode = node
                    Return
                Else
                    If (node.Nodes.Count > 0) Then If (SyncNameList(node)) Then Return
                End If
            Next
        End Sub
        Protected Overridable Function SyncNameList(ByVal InnerNode As SPTreeNode) As Boolean
            For Each node As SPTreeNode In InnerNode.Nodes
                If (node.Index = DetailBinding.Position) Then
                    tvwName.SelectedNode = node
                    Return True
                Else
                    SyncNameList(node)
                End If
            Next
            Return False
        End Function
        Protected Overridable Sub CreateSetupView(ByRef DataSource As DataTable, ByVal bindingSettings As SPRecordBindingSettings)
            If DataSource IsNot Nothing Then

                With tvwName
                    .DataSource = DataSource.DefaultView
                    .DisplayMember = bindingSettings.DisplayMember
                    .ValueMember = bindingSettings.ValueMember
                    DetailBinding.DataSource = DataSource
                    .SetLeafData(bindingSettings.DisplayMember, bindingSettings.DisplayMember, bindingSettings.ValueMember, 0, -1)
                    For Each itm As SPTreeNodeGroup In bindingSettings.NodeGroups
                        .AddGroup(itm.Name, itm.GroupBy, itm.DisplayMember, itm.ValueMember, itm.ImageIndex, itm.SelectedImageIndex)
                    Next
                    .BuildTree()
                End With

            End If
        End Sub
        Private Sub tvwName_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwName.AfterSelect
            SelectNameInList(e.Node.Index)
        End Sub
        Private Sub RefreshMaster()
            If _DataSource IsNot Nothing Then
                tvwName.BuildTree()
            End If
            DetailBinding.ResetBindings(False)
        End Sub

    End Class
End Namespace
