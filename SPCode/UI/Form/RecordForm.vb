Imports System.IO
Imports System.Drawing.Imaging
Imports SoftLogik.Win.UI

Namespace UI
    Public Class RecordForm

        'Navigation Events
        Public Event NavigationChanged(ByVal sender As System.Object, ByVal e As SPFormNavigateEventArgs)
        Public Event RecordBinding(ByVal sender As System.Object, ByVal e As SPFormRecordBindingEventArgs)
        Public Event Databound(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Public Event RecordChanged(ByVal sender As System.Object, ByVal e As SPFormRecordUpdateEventArgs)
        Public Event RecordValidating(ByVal sender As System.Object, ByVal e As SPFormValidatingEventArgs)

#Region "Properties"

        Protected _DataSource As DataTable = Nothing
        Protected _BindingSettings As SPRecordBindingSettings
        Protected _RecordState As SPFormRecordStateManager = New SPFormRecordStateManager()
        Protected _LookupForm As LookupForm
        Protected _FirstField As Control = Nothing
        Protected _NewRecordProc As NewRecordCallback

        Public WriteOnly Property LookupForm() As LookupForm
            Set(ByVal value As LookupForm)
                _LookupForm = value
            End Set
        End Property

#End Region
#Region "Form Overrides"
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            'WindowState = FormWindowState.Maximized

            If Not DesignMode Then
                Dim dataBindSettings As New SPFormRecordBindingEventArgs()
                OnRecordBinding(dataBindSettings)
                Me._RecordState.CurrentState = SPFormRecordModes.EditMode 'By Default Form is in Edit Mode
                Me._RecordState.BindingData = True
                _DataSource = dataBindSettings.DataSource
                _BindingSettings = dataBindSettings.BindingSettings
                _NewRecordProc = _BindingSettings.NewRecordProc

                BindControls(Me.Controls, DetailBinding, _RecordState, AddressOf OnFieldChanged)

                MyTabOrderManager = New UI.SPTabOrderManager(Me)
                MyTabOrderManager.SetTabOrder(UI.SPTabOrderManager.TabScheme.DownFirst) ' set tab order
            End If

        End Sub

        Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
            MyBase.OnActivated(e)

        End Sub
        Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
            If _RecordState.CurrentState = SPFormRecordModes.DirtyMode Or _
               _RecordState.CurrentState = SPFormRecordModes.InsertMode Then
                Dim msgResult As DialogResult = MessageBox.Show("Save Changes made to " & Me.Text & "?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                Select Case msgResult
                    Case Windows.Forms.DialogResult.Yes
                        OnSaveRecord() 'Save Changes
                    Case Windows.Forms.DialogResult.No
                    Case Windows.Forms.DialogResult.Cancel
                        e.Cancel = True
                End Select
            End If
            MyBase.OnFormClosing(e)
        End Sub
        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyDown(e)

            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.N
                        NewRecord.PerformClick()
                    Case Keys.S
                        SaveRecord.PerformClick()
                    Case Keys.Delete
                        DeleteRecord.PerformClick()
                End Select
            End If

            If e.KeyCode = Keys.Escape Then
                If _RecordState.CurrentState = SPFormRecordModes.DirtyMode Then
                    UndoRecord.PerformClick()
                Else
                    CloseWindow.PerformClick()
                End If
            End If


        End Sub
#End Region

#Region "Protected Overrides"
        Protected Overridable Sub OnRecordBinding(ByVal e As SPFormRecordBindingEventArgs)
            RaiseEvent RecordBinding(Me, e) 'let client respond
        End Sub


        Protected Overridable Sub OnRecordChanged(ByVal e As SPFormRecordUpdateEventArgs)
            RaiseEvent RecordChanged(Me, e)
        End Sub
#End Region
#Region "Private Methods"
        Protected Overridable Sub OnFieldChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If _RecordState.ShowingData = False Then
                If _RecordState.CurrentState = SPFormRecordModes.EditMode AndAlso _
                _RecordState.CurrentState <> SPFormRecordModes.DirtyMode AndAlso (Not _RecordState.BindingData) Then
                    _RecordState.CurrentState = SPFormRecordModes.DirtyMode
                    UpdateFormCaption()
                    ToolbarToggleSave(tbrMain, Nothing)
                End If
            End If
            _RecordState.BindingData = False
        End Sub
        Protected Overridable Sub OnNewRecord()
            Try
                DetailBinding.AddNew()
                DetailBinding.MoveFirst()
                Me._RecordState.CurrentState = SPFormRecordModes.InsertMode
                ToolbarToggleSave(tbrMain, Nothing)
                FirstFieldFocus()
            Catch ex As Exception
            End Try
        End Sub
        Protected Overridable Sub OnRefreshRecord()
            Try
                Me._RecordState.CurrentState = SPFormRecordModes.EditMode
                FirstFieldFocus()
            Catch ex As Exception
            End Try
        End Sub
        Protected Overridable Sub OnSortRecord()
            Try
                Me._RecordState.CurrentState = SPFormRecordModes.EditMode
                FirstFieldFocus()
            Catch ex As Exception
            End Try
        End Sub
        Protected Overridable Sub OnSaveRecord()
            Me.Validate()
            Try
                _RecordState.ShowingData = True
                DetailBinding.EndEdit()
                _RecordState.ShowingData = False
            Catch ex As Exception
                Exit Sub
            End Try

            If DetailBinding.Current IsNot Nothing Then
                If Me._RecordState.CurrentState = SPFormRecordModes.InsertMode Then
                    OnRecordChanged(New SPFormRecordUpdateEventArgs(_RecordState.NewRecordData, SPFormDataStates.[New]))
                    _RecordState.NewRecordData = Nothing
                Else
                    OnRecordChanged(New SPFormRecordUpdateEventArgs(CType(DetailBinding.Current, DataRowView).Row, SPFormDataStates.Edited))
                End If


                _RecordState.CurrentState = SPFormRecordModes.EditMode
                UpdateFormCaption(True)
            End If
        End Sub
        Protected Overridable Sub OnUndoRecord()
            On Error Resume Next
            If DetailBinding.Current IsNot Nothing Then
                If CType(DetailBinding.Current, DataRowView).IsNew Then
                    DetailBinding.RemoveCurrent()
                Else
                    DetailBinding.CancelEdit()
                End If


            End If
            _RecordState.CurrentState = SPFormRecordModes.EditMode
            UpdateFormCaption(True)
        End Sub
        Protected Overridable Sub OnDeleteRecord()
            Try
                If MessageBox.Show("Are you sure you want to Delete '" & CType(DetailBinding.Current, DataRowView).Row(_BindingSettings.DisplayMember).ToString & "' ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    OnRecordChanged(New SPFormRecordUpdateEventArgs(CType(DetailBinding.Current, DataRowView).Row, SPFormDataStates.Deleted))
                    _RecordState.ShowingData = True
                    DetailBinding.RemoveCurrent()
                    _RecordState.ShowingData = False
                End If
            Catch ex As Exception
            End Try
        End Sub
        Protected Overridable Sub OnSearchRecord()
            If _LookupForm IsNot Nothing Then
                With _LookupForm
                    .ShowDialog(Me)
                    '.SearchResults()
                End With
            End If
        End Sub
        Protected Overridable Sub OnCopyRecord()
            If DetailBinding.Current IsNot Nothing Then
                '_RecordState.ShowingData = True
                Dim clonedDataRow As DataRowView = CType(DetailBinding.Current, DataRowView)
                Dim newDataRow As DataRowView = CType(DetailBinding.AddNew(), DataRowView)
                DuplicateRecord(clonedDataRow, newDataRow)
                DetailBinding.ResetBindings(False)
                _RecordState.CurrentState = SPFormRecordModes.InsertMode
                '_RecordState.ShowingData = False
            End If
        End Sub
        Protected Overridable Sub OnNavigate(ByVal direction As SPRecordNavigateDirections)
            Dim lastRecord As DataRow, currentRecord As DataRow
            On Error Resume Next
            _RecordState.ShowingData = True
            lastRecord = CType(DetailBinding.Current, DataRowView).Row
            Select Case direction
                Case SPRecordNavigateDirections.First
                    SelectNameInList(0)
                Case SPRecordNavigateDirections.Last
                    SelectNameInList(DetailBinding.Count - 1)
                Case SPRecordNavigateDirections.Next
                    SelectNameInList(DetailBinding.Position + 1)
                Case SPRecordNavigateDirections.Previous
                    SelectNameInList(DetailBinding.Position - 1)
            End Select

            _RecordState.ShowingData = False
            currentRecord = CType(DetailBinding.Current, DataRowView).Row
            RaiseEvent NavigationChanged(tbrMain, New SPFormNavigateEventArgs(direction, lastRecord, currentRecord))
        End Sub
        Protected Overridable Sub OnCloseWindow()
            Me.Close()
        End Sub

#End Region
#Region "Support Methods"
        Protected Overridable Sub UpdateFormCaption(Optional ByVal Clear As Boolean = False)
            Dim strText As String = Me.Text

            If Not Clear Then
                strText &= CStr(IIf(strText.EndsWith("*"), vbNullString, "*"))
                Me.Text = strText
            Else
                Me.Text = strText.Replace("*", vbNullString)
            End If
        End Sub
        Protected Overridable Sub FirstFieldFocus()
            Dim lastTabIndex As Integer
            Try
                Dim firstControl As Control = Me.GetNextControl(Me, True)
                If firstControl IsNot Nothing Then
                    lastTabIndex = firstControl.TabIndex
                    FindFirstField(firstControl, lastTabIndex)
                End If
            Catch ex As Exception
                Exit Sub
            End Try

        End Sub
        Private Sub FindFirstField(ByRef OuterControl As Control, ByRef lastTabIndex As Integer)
            Dim ctl As Control = OuterControl
            While Not ctl Is Nothing
                If (Not ctl.HasChildren) AndAlso (ctl.CanFocus AndAlso ctl.CanSelect) Then
                    ctl.Focus()
                    Exit Sub
                Else
                    ctl = ctl.GetNextControl(ctl, True)
                    FindFirstField(ctl, lastTabIndex)
                End If
            End While
        End Sub
        Private Sub DuplicateRecord(ByVal SourceRow As DataRowView, ByRef TargetRow As DataRowView)
            _RecordState.DuplicatingData = True
            TargetRow.Row.ItemArray = SourceRow.Row.ItemArray

            For Each itm As DataColumn In TargetRow.Row.Table.Columns
                If itm.ReadOnly Then
                    If itm.AutoIncrement Then
                        TargetRow(itm.ColumnName) = 0
                    End If
                End If
            Next
            _RecordState.DuplicatingData = False
        End Sub
#End Region
#Region "List and Toolbar Events"
        Protected Overridable Sub ToolbarOperation(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Select Case CType(sender, ToolStripItem).Name
                Case MasterToolbarButtonNames.ToolbarNew
                    OnNewRecord()
                Case MasterToolbarButtonNames.ToolbarSave
                    OnSaveRecord()
                Case MasterToolbarButtonNames.ToolbarDelete
                    OnDeleteRecord()
                Case MasterToolbarButtonNames.ToolbarUndo
                    OnUndoRecord()
                Case MasterToolbarButtonNames.ToolbarSearch
                    OnSearchRecord()
                Case MasterToolbarButtonNames.ToolbarCopy
                    OnCopyRecord()
                Case MasterToolbarButtonNames.ToolbarRefresh
                    OnRefreshRecord()
                Case MasterToolbarButtonNames.ToolbarSort
                    OnSortRecord()
                Case MasterToolbarButtonNames.ToolbarFirst
                    OnNavigate(SPRecordNavigateDirections.First)
                Case MasterToolbarButtonNames.ToolbarPrevious
                    OnNavigate(SPRecordNavigateDirections.Previous)
                Case MasterToolbarButtonNames.ToolbarNext
                    OnNavigate(SPRecordNavigateDirections.Next)
                Case MasterToolbarButtonNames.ToolbarLast
                    OnNavigate(SPRecordNavigateDirections.Last)
                Case MasterToolbarButtonNames.ToolbarClose  'Close Window
                    OnCloseWindow()
            End Select
        End Sub
        Private Sub tbrMain_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbrMain.ItemClicked
            ToolbarOperation(e.ClickedItem, e)
        End Sub
        Protected Overridable Sub SelectNameInList(ByVal Index As Integer)
            Dim selectedRow As Integer = Index
            Dim lastRecord As DataRow = Nothing, currentRecord As DataRow = Nothing

            If selectedRow <> -1 Then
                _RecordState.ShowingData = True
                If DetailBinding.Current IsNot Nothing Then
                    lastRecord = CType(DetailBinding.Current, DataRowView).Row
                End If
                DetailBinding.Position = selectedRow
                _RecordState.ShowingData = False
                If DetailBinding.Current IsNot Nothing Then
                    currentRecord = CType(DetailBinding.Current, DataRowView).Row
                End If
                RaiseEvent NavigationChanged(tbrMain, New SPFormNavigateEventArgs(SPRecordNavigateDirections.None, lastRecord, currentRecord))
            End If
        End Sub
#End Region

        Private Sub DetailBinding_BindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.BindingCompleteEventArgs) Handles DetailBinding.BindingComplete
            Me._RecordState.BindingData = False
        End Sub

        Private Sub DetailBinding_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailBinding.DataSourceChanged
            Me._RecordState.BindingData = True
        End Sub

        Private Sub DetailBinding_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles DetailBinding.ListChanged
            If e.ListChangedType = System.ComponentModel.ListChangedType.ItemAdded Then
                If _NewRecordProc IsNot Nothing AndAlso _RecordState.DuplicatingData = False _
                AndAlso _RecordState.ShowingData = False Then
                    CType(DetailBinding.Item(e.NewIndex), DataRowView).Row.ItemArray = _NewRecordProc.Invoke.Row.ItemArray
                    _RecordState.NewRecordData = CType(DetailBinding.Item(e.NewIndex), DataRowView).Row
                End If
            End If
        End Sub

    End Class
End Namespace



