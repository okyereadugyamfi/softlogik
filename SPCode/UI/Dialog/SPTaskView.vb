Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Text
Imports System.Reflection
Imports vbAccelerator.Components.Controls
Imports vbAccelerator.Components.Controls.ExplorerBarFramework

Namespace Win.Controls
    Public Enum SPTaskStyle
        None
        TextLink
        TextImage
    End Enum
    ''' <summary>
    ''' Organizes the various Tasks to be done by a user on a particular screen.
    ''' </summary>
    <Designer(GetType(SPTaskViewDesigner))> _
    <ToolboxBitmap(GetType(SPTaskViewDesigner))> _
    <DefaultEvent("TaskSelect")> _
    Public Class SPTaskView
#Region "Data Members"
        Private m_objTaskSet As SPTaskSet = New SPTaskSet
        Private m_intLastTaskCount As Integer = 0
#End Region

#Region "Events"
        Public Event TasksLoad As EventHandler
        Public Event TasksClose As EventHandler
        Public Event TaskSelect As SPTaskSelectEventHandler
#End Region

#Region "Proxy Subs to Raise Events"
        Protected Overridable Sub OnTaskSelect(ByVal taskItem As SPTaskItemEventArgs)
            RaiseEvent TaskSelect(Me, taskItem)
        End Sub
        Protected Overridable Sub OnTasksLoad(ByVal e As EventArgs)
            RaiseEvent TasksLoad(Me, e)
            RefreshView()
        End Sub
        Protected Overridable Sub OnTasksClose(ByVal e As EventArgs)
            RaiseEvent TasksClose(Me, e)
        End Sub
#End Region

#Region "Local Procedures"
        Friend Sub RefreshView()
            Try
                If (m_intLastTaskCount <> Me.TaskSet.TaskList.Count) AndAlso _
                Me.TaskSet.SourceActivated Then
                    ResetView()

                    With Me
                        For Each Category As SPTaskItem In Me.m_objTaskSet.GroupsOnly
                            Dim lvGroup As ExplorerBar = New ExplorerBar
                            With lvGroup
                                .Tag = Category.ToString
                                .Text = Category.Description
                            End With
                            .Bars.Add(lvGroup)
                            lvGroup.CanExpand = False
                            Dim barItems As ExplorerBarItemCollection = lvGroup.Items
                            For Each taskItem As SPTaskItem In Me.m_objTaskSet.TasksOnly(Category.Name)
                                Dim lvItem As ExplorerBarItem

                                Select Case taskItem.Style
                                    Case SPTaskStyle.TextImage
                                        lvItem = New ExplorerBarLinkItem
                                        With CType(lvItem, ExplorerBarLinkItem)
                                            .Tag = taskItem.Name
                                            .Text = taskItem.Description
                                            .IconIndex = taskItem.IconIndex
                                        End With
                                    Case Else
                                        lvItem = New ExplorerBarLinkItem
                                        With CType(lvItem, ExplorerBarLinkItem)
                                            .Tag = taskItem.Name
                                            .Text = taskItem.Description
                                        End With
                                End Select

                                barItems.Add(lvItem)
                            Next
                        Next
                    End With
                    m_intLastTaskCount = Me.TaskSet.TaskList.Count
                End If
            Catch ex As Exception
            End Try
        End Sub
        Friend Sub ResetView()
            For intBarIndex As Integer = 0 To Me.Bars.Count - 1
                Me.Bars.RemoveAt(intBarIndex)
            Next
            m_intLastTaskCount = 0
        End Sub
#End Region

#Region "Event Handlers"

#End Region

#Region "Overrides Procedures"
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            RefreshView()
        End Sub
#End Region

        <Browsable(False)> _
        Public Property TaskSet() As SPTaskSet
            Get
                Return m_objTaskSet
            End Get
            Set(ByVal value As SPTaskSet)
                m_objTaskSet = value
            End Set
        End Property

        Private Sub SPTaskView_ItemClick(ByVal sender As Object, ByVal args As vbAccelerator.Components.Controls.ExplorerBarItemClickEventArgs) Handles Me.ItemClick
            Try
                OnTaskSelect(New SPTaskItemEventArgs(m_objTaskSet(args.Item.Tag.ToString)))
            Catch ex As Exception
            End Try
        End Sub
    End Class

    Public Delegate Sub SPTaskSelectEventHandler(ByVal sender As Object, ByVal taskItem As SPTaskItemEventArgs)

    Public Class SPTaskSet

        Private m_objTasks As SPTaskItemCollection = New SPTaskItemCollection
        Private m_evtTaskSelectHandle As SPTaskSelectEventHandler = Nothing
        Private m_boolSourceActivated As Boolean = True

        ''' <summary>
        ''' Maintains an List of Tasks to be displayed in the control
        ''' </summary>
        Default Public ReadOnly Property Tasks(ByVal Index As Integer) As SPTaskItem
            Get
                Try
                    Return m_objTasks(Index)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property
        Default Public ReadOnly Property Tasks(ByVal Name As String) As SPTaskItem
            Get
                Try
                    For counter As Integer = 0 To m_objTasks.Count
                        If m_objTasks(counter).Name = Name Then
                            Return m_objTasks(counter)
                        End If
                    Next
                    Return Nothing
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property

        Public ReadOnly Property TaskList() As SPTaskItemCollection
            Get
                Return m_objTasks
            End Get
        End Property
        Public ReadOnly Property TaskSelectHandle() As SPTaskSelectEventHandler
            Get
                Return m_evtTaskSelectHandle
            End Get
        End Property

        Public ReadOnly Property TasksOnly() As SPTaskItemCollection
            Get
                Dim objTasks As SPTaskItemCollection = New SPTaskItemCollection

                For Each taskItem As SPTaskItem In m_objTasks
                    If taskItem.IsCategory = False Then
                        objTasks.Add(taskItem)
                    End If
                Next

                Return objTasks
            End Get
        End Property
        Public ReadOnly Property TasksOnly(ByVal GroupName As String) As SPTaskItemCollection
            Get
                Dim objTasks As SPTaskItemCollection = New SPTaskItemCollection

                For Each taskItem As SPTaskItem In m_objTasks
                    If taskItem.IsCategory = False And taskItem.Category = GroupName Then
                        objTasks.Add(taskItem)
                    End If
                Next

                Return objTasks
            End Get
        End Property
        Public ReadOnly Property GroupsOnly() As SPTaskItemCollection
            Get
                Dim objGroups As SPTaskItemCollection = New SPTaskItemCollection

                For Each taskItem As SPTaskItem In m_objTasks
                    If taskItem.IsCategory Then
                        objGroups.Add(taskItem)
                    End If
                Next

                Return objGroups
            End Get
        End Property

        Public Property SourceActivated() As Boolean
            Get
                Return m_boolSourceActivated
            End Get
            Set(ByVal value As Boolean)
                m_boolSourceActivated = value
            End Set
        End Property
    End Class
    Public Class SPTaskItem

        Private m_strName As String = String.Empty
        Private m_strDescription As String = String.Empty
        Private m_boolIsCategory As Boolean = False
        Private m_strCategory As String = String.Empty
        Private m_strIconKey As String = String.Empty
        Private m_intIconIndex As Integer
        Private m_enmTaskStyle As SPTaskStyle

        Public Sub New(ByVal Name As String)
            Me.m_strName = Name
        End Sub

        Public Sub New(ByVal Name As String, ByVal Description As String)
            Me.m_strName = Name
            Me.m_strDescription = Description
        End Sub

        Public Sub New(ByVal Name As String, ByVal Description As String, ByVal Category As String)
            Me.m_strName = Name
            Me.m_strDescription = Description
            Me.m_strCategory = Category
        End Sub

        Public Sub New(ByVal Name As String, ByVal Description As String, ByVal Category As String, ByVal IsCategory As Boolean)
            Me.m_strName = Name
            Me.m_strDescription = Description
            Me.m_strCategory = Category
            Me.m_boolIsCategory = IsCategory
        End Sub

        Public Sub New(ByVal Name As String, ByVal Description As String, ByVal IsCategory As Boolean)
            Me.m_strName = Name
            Me.m_strDescription = Description
            Me.m_strCategory = Category
            Me.m_boolIsCategory = IsCategory
        End Sub

        <Description("Gets or Sets the name of the Task Item")> _
        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property


        <Description("Gets or Sets the Style of the Task Item")> _
    Public Property Style() As SPTaskStyle
            Get
                Return m_enmTaskStyle
            End Get
            Set(ByVal value As SPTaskStyle)
                m_enmTaskStyle = value
            End Set
        End Property

        <Description("Gets or Sets the description of the Task Item")> _
        Public Property Description() As String
            Get
                Return m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        <Description("Gets or Sets the Group of the Task Item")> _
        Public Property Category() As String
            Get
                Return m_strCategory
            End Get
            Set(ByVal value As String)
                m_strCategory = value
            End Set
        End Property
        <Description("Gets or Sets if a TaskItem is a Category Section Header")> _
        Public Property IsCategory() As Boolean
            Get
                Return m_boolIsCategory
            End Get
            Set(ByVal value As Boolean)
                m_boolIsCategory = value
            End Set
        End Property

        <Description("Gets or Sets a TaskItem's Icon Key in the Corresponding Image List")> _
    Public Property IconKey() As String
            Get
                Return m_strIconKey
            End Get
            Set(ByVal value As String)
                m_strIconKey = value
            End Set
        End Property

        <Description("Gets or Sets a TaskItem's Icon Index in the Corresponding Image List")> _
    Public Property IconIndex() As Integer
            Get
                Return m_intIconIndex
            End Get
            Set(ByVal value As Integer)
                m_intIconIndex = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.Name
        End Function

    End Class
    Public Class SPTaskItemCollection
        Inherits List(Of SPTaskItem)
    End Class
    Public Class SPTaskItemEventArgs : Inherits EventArgs

        Private m_objTask As SPTaskItem

        Public Sub New(ByVal NewTask As SPTaskItem)
            m_objTask = NewTask
        End Sub

        Public ReadOnly Property Task() As SPTaskItem
            Get
                Return m_objTask
            End Get
        End Property
    End Class

#Region "Designer Extensions"
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Public Class SPTaskViewDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Private lists As DesignerActionListCollection

        'Use pull model to populate smart tag menu.
        Public Overrides ReadOnly Property ActionLists() _
        As DesignerActionListCollection
            Get
                If lists Is Nothing Then
                    lists = New DesignerActionListCollection()
                    lists.Add( _
                    New SPTaskViewActionList(Me.Component))
                End If
                Return lists
            End Get
        End Property
    End Class

    '///////////////////////////////////////////////////////////////
    'DesignerActionList-derived class defines smart tag entries and
    ' resultant actions.
    '///////////////////////////////////////////////////////////////
    Public Class SPTaskViewActionList
        Inherits System.ComponentModel.Design.DesignerActionList

        Private taskView As SPTaskView
        Private m_enmDockStyle As DockStyle = DockStyle.None

        Private designerActionUISvc As DesignerActionUIService = Nothing

        'The constructor associates the control 
        'with the smart tag list.
        Public Sub New(ByVal component As IComponent)

            MyBase.New(component)
            Me.taskView = CType(component, SPTaskView)

            ' Cache a reference to DesignerActionUIService, so the
            ' DesigneractionList can be refreshed.
            Me.designerActionUISvc = _
            CType(GetService(GetType(DesignerActionUIService)), _
            DesignerActionUIService)

        End Sub

        'Helper method to retrieve control properties. Use of 
        ' GetProperties enables undo and menu updates to work properly.
        Private Function GetPropertyByName(ByVal propName As String) _
        As PropertyDescriptor
            Dim prop As PropertyDescriptor
            prop = TypeDescriptor.GetProperties(taskView)(propName)
            If prop Is Nothing Then
                Throw New ArgumentException( _
                "Matching SPTaskView property not found!", propName)
            Else
                Return prop
            End If
        End Function

        Public Property Dock() As DockStyle
            Get
                Return taskView.Dock
            End Get
            Set(ByVal value As DockStyle)
                GetPropertyByName("Dock").SetValue(taskView, value)
            End Set
        End Property


        'Method that is target of a DesignerActionMethodItem
        Public Sub EditItems()
            'GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
        End Sub
        Public Sub EditColumns()
            'GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
        End Sub

        Public Sub EditGroups()
            'GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
        End Sub
        Public Sub ParentDock()
            If Dock = DockStyle.Fill Then
                GetPropertyByName("Dock").SetValue(taskView, DockStyle.None)
            ElseIf Dock = DockStyle.None Then
                GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
            End If
        End Sub

        'Implementation of this virtual method creates smart tag  
        ' items, associates their targets, and collects into list.
        Public Overrides Function GetSortedActionItems() _
        As DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection()

            'Define static section header entries.
            'items.Add(New DesignerActionHeaderItem("-"))
            items.Add(New DesignerActionHeaderItem(""))

            'items.Add(New DesignerActionMethodItem( _
            'Me, "EditItems", _
            '"Edit Items", _
            '" ", _
            '"Opens the Items Collection Editor"))

            'items.Add(New DesignerActionMethodItem( _
            'Me, "EditColumns", _
            '"Edit Columns", _
            '" ", _
            '"Opens the Columns Collection Editor"))

            'items.Add(New DesignerActionMethodItem( _
            'Me, "EditGroups", _
            '"Edit Groups", _
            '" ", _
            '"Opens the Groups Collection Editor"))

            If Dock = DockStyle.None Then
                items.Add(New DesignerActionMethodItem( _
                Me, "ParentDock", _
                 "Dock in parent Container", _
                "", _
                "Dock in Parent Container"))
            ElseIf Dock = DockStyle.Fill Then
                items.Add(New DesignerActionMethodItem( _
                Me, "ParentDock", _
                 "Undock from parent container", _
                "", _
                "Undock in Parent Container"))

            End If
            Return items
        End Function

    End Class

#End Region
End Namespace


