Imports System.ComponentModel

Namespace UI
    <Description("Data Aware MenuStrip Component")> _
    <ToolboxBitmap(GetType(SPMenuStrip), "SPMenuStrip")> _
    Public Class SPMenuStrip

        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            ' Calling the base class OnPaint
            MyBase.OnPaint(pe)
        End Sub

        Private m_autoBuild As Boolean = True

        Public Property AutoBuildTree() As Boolean
            Get
                Return Me.m_autoBuild
            End Get
            Set(ByVal value As Boolean)
                Me.m_autoBuild = value
            End Set
        End Property

#Region "Data Binding"
        Private m_currencyManager As CurrencyManager = Nothing
        Private m_ValueMember As String
        Private m_DisplayMember As String
        Private m_oDataSource As Object

        <Category("Data")> _
Public Property DataSource() As Object
            Get
                Return m_oDataSource
            End Get
            Set(ByVal value As Object)
                If value Is Nothing Then
                    Me.m_currencyManager = Nothing
                    Me.Items.Clear()
                Else
                    If Not (TypeOf value Is IList OrElse TypeOf m_oDataSource Is IListSource) Then
                        Throw (New System.Exception("Invalid DataSource"))
                    Else
                        If TypeOf value Is IListSource Then
                            Dim myListSource As IListSource = CType(value, IListSource)
                            If myListSource.ContainsListCollection = True Then
                                Throw (New System.Exception("Invalid DataSource"))
                            End If
                        End If
                        Me.m_oDataSource = value
                        Me.m_currencyManager = CType(Me.BindingContext(value), CurrencyManager)
                        If Me.AutoBuildTree Then
                            BuildTree()
                        End If
                    End If
                End If
            End Set
        End Property ' end of DataSource property

        <Category("Data")> _
        Public Property ValueMember() As String
            Get
                Return Me.m_ValueMember
            End Get
            Set(ByVal value As String)
                Me.m_ValueMember = value
            End Set
        End Property

        <Category("Data")> _
        Public Property DisplayMember() As String
            Get
                Return Me.m_DisplayMember
            End Get
            Set(ByVal value As String)
                Me.m_DisplayMember = value
            End Set
        End Property

        Public Function GetValue(ByVal index As Integer) As Object
            Dim innerList As IList = Me.m_currencyManager.List
            If Not innerList Is Nothing Then
                If (Me.ValueMember <> "") AndAlso (index >= 0 AndAlso 0 < innerList.Count) Then
                    Dim pdValueMember As PropertyDescriptor
                    pdValueMember = Me.m_currencyManager.GetItemProperties()(Me.ValueMember)
                    Return pdValueMember.GetValue(innerList(index))
                End If
            End If
            Return Nothing
        End Function

        Public Function GetDisplay(ByVal index As Integer) As Object
            Dim innerList As IList = Me.m_currencyManager.List
            If Not innerList Is Nothing Then
                If (Me.DisplayMember <> "") AndAlso (index >= 0 AndAlso 0 < innerList.Count) Then
                    Dim pdDisplayMember As PropertyDescriptor
                    pdDisplayMember = Me.m_currencyManager.GetItemProperties()(Me.ValueMember)
                    Return pdDisplayMember.GetValue(innerList(index))
                End If
            End If
            Return Nothing
        End Function

#End Region

#Region "Building the Tree"

        Private treeGroups As ArrayList = New ArrayList()

        Public Sub BuildTree()
            Me.Items.Clear()
            If (Not Me.m_currencyManager Is Nothing) AndAlso (Not Me.m_currencyManager.List Is Nothing) Then
                Dim innerList As IList = Me.m_currencyManager.List
                Dim currNode As ToolStripItemCollection = Me.Items
                Dim currGroupIndex As Integer = 0
                Dim currListIndex As Integer = 0


                If Me.treeGroups.Count > currGroupIndex Then
                    Dim currGroup As SPTreeNodeGroup = CType(treeGroups(currGroupIndex), SPTreeNodeGroup)
                    Dim myFirstNode As SPMenuStripItem = Nothing
                    Dim pdGroupBy As PropertyDescriptor
                    Dim pdValue As PropertyDescriptor
                    Dim pdDisplay As PropertyDescriptor

                    pdGroupBy = Me.m_currencyManager.GetItemProperties()(currGroup.GroupBy)
                    pdValue = Me.m_currencyManager.GetItemProperties()(currGroup.ValueMember)
                    pdDisplay = Me.m_currencyManager.GetItemProperties()(currGroup.DisplayMember)

                    Dim currGroupBy As String = Nothing
                    If innerList.Count > currListIndex Then
                        Dim currObject As Object
                        Do While currListIndex < innerList.Count
                            currObject = innerList(currListIndex)
                            If pdGroupBy.GetValue(currObject).ToString() <> currGroupBy Then
                                currGroupBy = pdGroupBy.GetValue(currObject).ToString()

                                myFirstNode = New SPMenuStripItem(currGroup.Name, pdDisplay.GetValue(currObject).ToString(), currObject, pdValue.GetValue(innerList(currListIndex)), currGroup.ImageIndex, currListIndex)

                                currNode.Add(CType(myFirstNode, ToolStripItem))
                            Else
                                AddMenuItems(currGroupIndex, currListIndex, Me.Items, currGroup.GroupBy)
                            End If
                        Loop ' end while
                    End If ' end if
                Else
                    Do While currListIndex < innerList.Count
                        AddMenuItems(currGroupIndex, currListIndex, Me.Items, "")
                    Loop
                End If ' end else



            End If ' end if
        End Sub

        Private Sub AddMenuItems(ByVal currGroupIndex As Integer, ByRef currentListIndex As Integer, ByVal currNodes As ToolStripItemCollection, ByVal prevGroupByField As String)
            Dim innerList As IList = Me.m_currencyManager.List
            Dim pdPrevGroupBy As System.ComponentModel.PropertyDescriptor = Nothing
            Dim prevGroupByValue As String = Nothing

            Dim currGroup As SPTreeNodeGroup

            If prevGroupByField <> "" Then
                pdPrevGroupBy = Me.m_currencyManager.GetItemProperties()(prevGroupByField)
            End If

            currGroupIndex += 1

            If treeGroups.Count > currGroupIndex Then
                currGroup = CType(treeGroups(currGroupIndex), SPTreeNodeGroup)
                Dim pdGroupBy As PropertyDescriptor = Nothing
                Dim pdValue As PropertyDescriptor = Nothing
                Dim pdDisplay As PropertyDescriptor = Nothing

                pdGroupBy = Me.m_currencyManager.GetItemProperties()(currGroup.GroupBy)
                pdValue = Me.m_currencyManager.GetItemProperties()(currGroup.ValueMember)
                pdDisplay = Me.m_currencyManager.GetItemProperties()(currGroup.DisplayMember)

                Dim currGroupBy As String = Nothing

                If innerList.Count > currentListIndex Then
                    If Not pdPrevGroupBy Is Nothing Then
                        prevGroupByValue = pdPrevGroupBy.GetValue(innerList(currentListIndex)).ToString()
                    End If

                    Dim myFirstNode As SPMenuStripItem = Nothing
                    Dim currObject As Object = Nothing

                    Do While (currentListIndex < innerList.Count) AndAlso (Not pdPrevGroupBy Is Nothing) AndAlso (pdPrevGroupBy.GetValue(innerList(currentListIndex)).ToString() = prevGroupByValue)
                        currObject = innerList(currentListIndex)
                        If pdGroupBy.GetValue(currObject).ToString() <> currGroupBy Then
                            currGroupBy = pdGroupBy.GetValue(currObject).ToString()

                            myFirstNode = New SPMenuStripItem(currGroup.Name, pdDisplay.GetValue(currObject).ToString(), currObject, pdValue.GetValue(innerList(currentListIndex)), currGroup.ImageIndex, currentListIndex)

                            currNodes.Add(CType(myFirstNode, SPMenuStripItem))
                        Else
                            AddMenuItems(currGroupIndex, currentListIndex, Me.Items, currGroup.GroupBy)
                        End If
                    Loop
                End If
            Else
                Dim myNewLeafNode As SPMenuStripItem
                Dim currObject As Object = Me.m_currencyManager.List(currentListIndex)

                If (Not Me.DisplayMember Is Nothing) AndAlso (Not Me.ValueMember Is Nothing) AndAlso (Me.DisplayMember <> "") AndAlso (Me.ValueMember <> "") Then
                    Dim pdDisplayloc As PropertyDescriptor = Me.m_currencyManager.GetItemProperties()(Me.DisplayMember)
                    Dim pdValueloc As PropertyDescriptor = Me.m_currencyManager.GetItemProperties()(Me.ValueMember)

                    If Me.Tag Is Nothing Then
                        myNewLeafNode = New SPMenuStripItem("", pdDisplayloc.GetValue(currObject).ToString(), currObject, pdValueloc.GetValue(currObject), currentListIndex)
                    Else
                        myNewLeafNode = New SPMenuStripItem(Me.Tag.ToString(), pdDisplayloc.GetValue(currObject).ToString(), currObject, pdValueloc.GetValue(currObject), currentListIndex)
                    End If
                Else
                    myNewLeafNode = New SPMenuStripItem("", currentListIndex.ToString(), currObject, currObject, currentListIndex, currentListIndex)
                End If

                currNodes.Add(CType(myNewLeafNode, SPMenuStripItem))
                currentListIndex += 1
            End If
        End Sub
#End Region

    End Class


    <Description("Specify Grouping for  a collection of Menu Items in MenuStrip")> _
    Public Class SPMenuStripItemGroup
        Private groupName As String
        Private groupByMember As String
        Private groupByDisplayMember As String
        Private groupByValueMember As String

        Private groupImageIndex As Integer

        Public Sub New(ByVal name As String, ByVal groupBy As String, ByVal displayMember As String, ByVal valueMember As String, ByVal imageIndex As Integer)
            Me.ImageIndex = imageIndex
            Me.Name = name
            Me.GroupBy = groupBy
            Me.DisplayMember = displayMember
            Me.ValueMember = valueMember
        End Sub

        Public Sub New(ByVal name As String, ByVal groupBy As String)
            Me.New(name, groupBy, groupBy, groupBy, -1)
        End Sub

        Public Property ImageIndex() As Integer
            Get
                Return groupImageIndex
            End Get
            Set(ByVal value As Integer)
                groupImageIndex = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return groupName
            End Get
            Set(ByVal value As String)
                groupName = value
            End Set
        End Property

        Public Property GroupBy() As String
            Get
                Return groupByMember
            End Get
            Set(ByVal value As String)
                groupByMember = value
            End Set
        End Property

        Public Property DisplayMember() As String
            Get
                Return groupByDisplayMember
            End Get
            Set(ByVal value As String)
                groupByDisplayMember = value
            End Set
        End Property
        Public Property ValueMember() As String
            Get
                Return groupByValueMember
            End Get
            Set(ByVal value As String)
                groupByValueMember = value
            End Set
        End Property
    End Class
    <Description("A menu item in the MenuStrip")> _
    Public Class SPMenuStripItem
        Inherits ToolStripMenuItem
        Private m_groupName As String
        Private m_value As Object
        Private m_item As Object
        Private m_position As Integer

        Public Sub New()

        End Sub

        Public Sub New(ByVal GroupName As String, ByVal text As String, ByVal item As Object, ByVal value As Object, ByVal imageIndex As Integer, ByVal position As Integer)
            Me.GroupName = GroupName
            Me.Text = text
            Me.Item = item
            Me.Value = value
            Me.ImageIndex = imageIndex
            Me.m_position = position
        End Sub

        Public Sub New(ByVal groupName As String, ByVal text As String, ByVal item As Object, ByVal value As Object, ByVal position As Integer)
            Me.GroupName = groupName
            Me.Text = text
            Me.Item = item
            Me.Value = value
            Me.m_position = position
        End Sub

        Public Property GroupName() As String
            Get
                Return m_groupName
            End Get
            Set(ByVal value As String)
                Me.m_groupName = value
            End Set
        End Property

        Public Property Item() As Object
            Get
                Return m_item
            End Get
            Set(ByVal value As Object)
                m_item = value
            End Set
        End Property

        Public Property Value() As Object
            Get
                Return m_value
            End Get
            Set(ByVal value As Object)
                m_value = value
            End Set
        End Property

        Public ReadOnly Property Position() As Integer
            Get
                Return m_position
            End Get
        End Property
    End Class
End Namespace
