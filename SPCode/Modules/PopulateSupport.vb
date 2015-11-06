
Module PopulateSupport



    Public Function BuildSetupList(ByRef TreeViewControl As Object, ByRef ImageListControl As ImageList, ByRef SourceData As DataTable, ByVal ParentField As String, _
ByVal CompareField As String, ByVal DisplayField As String, ByVal NodeIDField As String, Optional ByVal ClearTree As Boolean = True) As Boolean
        Cursor.Current = Cursors.WaitCursor

        Dim tvwTreeView As TreeView = CType(TreeViewControl, TreeView)
        Dim imlImageList As ImageList = ImageListControl

        tvwTreeView.BeginUpdate()
        If ClearTree Then
            tvwTreeView.Nodes.Clear()
        End If
        tvwTreeView.ImageList = imlImageList

        Dim dvTreeTable As New DataView, currentNode As TreeNode

        dvTreeTable.Table = SourceData



        If ClearTree = False Then 'Might be a root node
            tvwTreeView.BeginUpdate()
            Try
                currentNode = tvwTreeView.Nodes(0)
                Call BuildSetupNode(currentNode, dvTreeTable, _
                Nothing, ParentField, CompareField, NodeIDField, DisplayField)

                currentNode.Expand()
            Catch ex As Exception

            End Try
            tvwTreeView.EndUpdate()
        Else
            dvTreeTable.RowFilter = " IsNull(" & ParentField & ",'') = '' "
            For Each drvRow As DataRowView In dvTreeTable
                tvwTreeView.BeginUpdate()
                currentNode = tvwTreeView.Nodes.Add(drvRow( _
                DisplayField).ToString)
                currentNode.Tag = drvRow(NodeIDField).ToString
                Call BuildNode(currentNode, dvTreeTable, drvRow, _
                ParentField, CompareField, NodeIDField, DisplayField)
                currentNode.Expand()
                tvwTreeView.EndUpdate()
            Next

        End If

        tvwTreeView.EndUpdate()
        Cursor.Current = Cursors.Default
        Return True
    End Function
    Public Function BuildTree(ByRef TreeViewControl As TreeView, ByRef ImageListControl As ImageList, ByRef SourceData As DataTable, ByVal ParentField As String, _
    ByVal CompareField As String, ByVal DisplayField As String, ByVal NodeIDField As String, Optional ByVal ClearTree As Boolean = True) As Boolean
        Cursor.Current = Cursors.WaitCursor

        Dim tvwTreeView As TreeView = CType(TreeViewControl, TreeView)
        Dim imlImageList As ImageList = ImageListControl

        tvwTreeView.BeginUpdate()
        If ClearTree Then
            tvwTreeView.Nodes.Clear()
        End If
        tvwTreeView.ImageList = imlImageList


        Dim dvTreeTable As New DataView, currentNode As TreeNode

        dvTreeTable.Table = SourceData



        If ClearTree = False Then 'Might be a root node
            tvwTreeView.BeginUpdate()
            Try
                currentNode = tvwTreeView.Nodes(0)
                Call BuildNode(currentNode, dvTreeTable, _
                Nothing, ParentField, CompareField, NodeIDField, DisplayField)

                currentNode.Expand()
            Catch ex As Exception

            End Try
            tvwTreeView.EndUpdate()
        Else
            dvTreeTable.RowFilter = " IsNull(" & ParentField & ",'') = '' "
            For Each drvRow As DataRowView In dvTreeTable
                tvwTreeView.BeginUpdate()
                currentNode = tvwTreeView.Nodes.Add(drvRow( _
                DisplayField).ToString)
                currentNode.Tag = drvRow(NodeIDField).ToString
                Call BuildNode(currentNode, dvTreeTable, drvRow, _
                ParentField, CompareField, NodeIDField, DisplayField)
                currentNode.Expand()
                tvwTreeView.EndUpdate()
            Next

        End If

        tvwTreeView.EndUpdate()
        Cursor.Current = Cursors.Default
        Return True
    End Function


    Private Sub BuildSetupNode(ByRef currentNode As TreeNode, ByRef sourceData As DataView, ByRef currentRecord As DataRowView, ByVal ParentField As String, ByVal CompareField As String, ByVal NodeIDField As String, ByVal DisplayField As String)
        Dim newData As New DataView(sourceData.Table)
        Dim newNode As TreeNode

        sourceData.RowFilter = vbNullString
        If Not currentRecord Is Nothing Then
            sourceData.RowFilter = ParentField & " = '" & _
            currentRecord(CompareField).ToString & "'"
        End If

        currentNode.TreeView.BeginUpdate()

        For Each drvRow As DataRowView In sourceData
            newData.RowFilter = ParentField & "  = '" & drvRow(CompareField).ToString & "'"
            newNode = currentNode.Nodes.Add(drvRow(DisplayField).ToString)
            newNode.Tag = drvRow(NodeIDField).ToString
            If newData.Count > 0 Then
                Call BuildSetupNode(newNode, newData, drvRow, ParentField, _
                CompareField, NodeIDField, DisplayField)
            End If
        Next

        currentNode.TreeView.EndUpdate()
    End Sub
    Private Sub BuildNode(ByRef currentNode As TreeNode, ByRef sourceData As DataView, ByRef currentRecord As DataRowView, ByVal ParentField As String, ByVal CompareField As String, ByVal NodeIDField As String, ByVal DisplayField As String)
        Dim newData As New DataView(sourceData.Table)
        Dim newNode As TreeNode

        sourceData.RowFilter = vbNullString
        If Not currentRecord Is Nothing Then
            sourceData.RowFilter = ParentField & " = '" & _
            currentRecord(CompareField).ToString & "'"
        End If

        currentNode.TreeView.BeginUpdate()

        For Each drvRow As DataRowView In sourceData
            newData.RowFilter = ParentField & "  = '" & drvRow(CompareField).ToString & "'"
            newNode = currentNode.Nodes.Add(drvRow(DisplayField).ToString)
            newNode.Tag = drvRow(NodeIDField).ToString
            If newData.Count > 0 Then
                Call BuildNode(newNode, newData, drvRow, ParentField, _
                CompareField, NodeIDField, DisplayField)
            End If
        Next

        currentNode.TreeView.EndUpdate()
    End Sub

    Public Function TreeNodeID(ByVal SourceNode As TreeNode, ByVal SelectedIndex As Integer) As Integer
        If SourceNode.Index <> SelectedIndex Then
            For Each curNode As TreeNode In SourceNode.Nodes
                If curNode.Index <> SelectedIndex Then
                    If Not curNode.Nodes Is Nothing Then
                        Call TreeNodeID(curNode, SelectedIndex)
                    End If
                End If
            Next
        Else
            Return CType(SourceNode.Tag, Integer)
        End If
    End Function
    Public Function TreeNodeSearch(ByVal SourceNode As TreeNode, ByVal SearchID As Integer) As TreeNode
        If CType(SourceNode.Tag, Integer) <> SearchID Then
            For Each curNode As TreeNode In SourceNode.Nodes
                If CType(curNode.Tag, Integer) <> SearchID Then
                    If Not curNode.Nodes Is Nothing Then
                        Call TreeNodeSearch(curNode, SearchID)
                    End If
                End If
            Next
        End If
        Return SourceNode
    End Function

End Module

