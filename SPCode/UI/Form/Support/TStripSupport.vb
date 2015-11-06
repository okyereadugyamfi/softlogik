Imports SoftLogik.Win.UI

Module TStripSupport

    Public Class MasterToolbarButtonNames
        Public Const ToolbarNew As String = "NewRecord"
        Public Const ToolbarDelete As String = "DeleteRecord"
        Public Const ToolbarSave As String = "SaveRecord"
        Public Const ToolbarUndo As String = "UndoRecord"
        Public Const ToolbarCopy As String = "CopyRecord"
        Public Const ToolbarRefresh As String = "RefreshRecord"
        Public Const ToolbarSort As String = "SortRecord"
        Public Const ToolbarSearch As String = "SearchRecord"
        Public Const ToolbarLast As String = "LastRecord"
        Public Const ToolbarFirst As String = "FirstRecord"
        Public Const ToolbarNext As String = "NextRecord"
        Public Const ToolbarPrevious As String = "PreviousRecord"
        Public Const ToolbarClose As String = "CloseWindow"
    End Class

    Public Sub ToolbarToggle(ByRef tbrAny As ToolStrip, ByVal InitialState As Boolean)
        Try
            If InitialState Then
                With tbrAny
                    .Items(MasterToolbarButtonNames.ToolbarSave).Enabled = False
                    .Items(MasterToolbarButtonNames.ToolbarUndo).Enabled = False

                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ToolbarToggleDefault(ByRef tbrAny As ToolStrip)
        ToolbarToggleDefault(tbrAny, Nothing)
    End Sub
    Public Sub ToolbarToggleDefault(ByRef tbrAny As ToolStrip, ByRef treeVw As SPTreeView)
        On Error Resume Next
        With tbrAny
            .Items(MasterToolbarButtonNames.ToolbarSave).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarUndo).Enabled = False

            .Items(MasterToolbarButtonNames.ToolbarDelete).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarSearch).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarCopy).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarNew).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarRefresh).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarSort).Enabled = True


            .Items(MasterToolbarButtonNames.ToolbarFirst).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarNext).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarPrevious).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarLast).Enabled = True
            If (treeVw IsNot Nothing) Then treeVw.Enabled = True
        End With

    End Sub
    Public Sub ToolbarToggleSave(ByRef tbrAny As ToolStrip)
        ToolbarToggleSave(tbrAny, Nothing)
    End Sub
    Public Sub ToolbarToggleSave(ByRef tbrAny As ToolStrip, ByRef treeVw As SPTreeView)

        On Error Resume Next
        With tbrAny
            .Items(MasterToolbarButtonNames.ToolbarSave).Enabled = True
            .Items(MasterToolbarButtonNames.ToolbarUndo).Enabled = True

            .Items(MasterToolbarButtonNames.ToolbarDelete).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarSearch).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarCopy).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarNew).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarRefresh).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarSort).Enabled = False

            .Items(MasterToolbarButtonNames.ToolbarFirst).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarNext).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarPrevious).Enabled = False
            .Items(MasterToolbarButtonNames.ToolbarLast).Enabled = False


            If (treeVw IsNot Nothing) Then treeVw.Enabled = False
        End With
    End Sub
    Public Sub ToolbarToggle(ByRef tbrAny As ToolStrip)
        Try
            With tbrAny
                .Items(MasterToolbarButtonNames.ToolbarNew).Enabled = Not _
                .Items(MasterToolbarButtonNames.ToolbarNew).Enabled

                .Items(MasterToolbarButtonNames.ToolbarDelete).Enabled = Not _
                .Items(MasterToolbarButtonNames.ToolbarDelete).Enabled

                .Items(MasterToolbarButtonNames.ToolbarSave).Enabled = Not _
                .Items(MasterToolbarButtonNames.ToolbarSave).Enabled

                .Items(MasterToolbarButtonNames.ToolbarUndo).Enabled = Not _
                .Items(MasterToolbarButtonNames.ToolbarUndo).Enabled

                .Items(MasterToolbarButtonNames.ToolbarSearch).Enabled = Not _
                .Items(MasterToolbarButtonNames.ToolbarSearch).Enabled
            End With

        Catch ex As Exception

        End Try
    End Sub
    Public Sub TransactionToolStrip(ByRef SourceToolbar As ToolStrip)
        Dim btn As ToolStripItem = Nothing

        Try
            With SourceToolbar
                .Items.Add(New ToolStripSeparator) 'Add a Separator

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_SAVECHANGES")
                    .Tag = "Save"
                End With
                .Items.Add(btn)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_UNDOCHANGES")
                    .Tag = "Undo"
                End With
                .Items.Add(btn)

                .Items.Add(New ToolStripSeparator)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_CLOSE")
                    .Tag = "Exit"
                End With
                .Items.Add(btn)
            End With
        Catch ex As Exception
        Finally
            btn.Dispose()
        End Try
    End Sub

    Public Sub MasterToolStrip(ByRef SourceToolbar As ToolStrip)
        Dim btn As ToolStripButton = Nothing
        'This procedure assumes an Image List has been already attached to the
        'supplied Toolbar with the required images in the required order
        Try
            With SourceToolbar
                .Items.Add(New ToolStripSeparator) 'Add a Separator

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_NEW")
                    .Tag = "New"
                    .ImageIndex = 0
                End With
                .Items.Add(btn)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_DELETE")
                    .Tag = "Delete"
                    .ImageIndex = 1
                End With
                .Items.Add(btn)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_SAVECHANGES")
                    .Tag = "Save"
                    .ImageIndex = 2
                End With
                .Items.Add(btn)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_UNDOCHANGES")
                    .Tag = "Undo"
                    .ImageIndex = 3
                End With
                .Items.Add(btn)

                .Items.Add(New ToolStripSeparator)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_FIND")
                    .Tag = "Find"
                    .ImageIndex = 4
                End With
                .Items.Add(btn)

                .Items.Add(New ToolStripSeparator)

                btn = New ToolStripButton
                With CType(btn, ToolStripButton)
                    .AutoToolTip = True
                    .ToolTipText = TextDictionary("TT_CLOSE")
                    .Tag = "Exit"
                    .ImageIndex = 5
                End With
                .Items.Add(btn)
            End With

        Catch ex As Exception
        Finally
            btn.Dispose()
        End Try
    End Sub

End Module
