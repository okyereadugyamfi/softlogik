Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.ComponentModel

Namespace UI
    <Designer(GetType(SPRadioButtonListDesigner))> _
     <ToolboxBitmap(GetType(SPRadioButtonListDesigner))> _
     <DefaultEvent("SelectedIndexChanged")> _
    Public Class SPRadioButtonList

        Public Enum RadioLayoutStyles
            [Horizontal]
            [Vertical]
            [Table]
        End Enum

        Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Private _RadioList As SPRadioButtonItemCollection = New SPRadioButtonItemCollection
        Private _radioLayoutStyle As RadioLayoutStyles
        Private _SelectedIndex As Integer = -1
        Private _SelectedValue As Object = Nothing

#Region "Overrides"
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)

            Try
                Me.RadioGroupBox.Text = Me.Text
                BuildRadioTable()
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub OnCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

#End Region

#Region "Properties"
        <Category("Behavior")> _
        <Description("Gets or Sets the Radio Buttons Layout Style")> _
        Public Property LayoutStyle() As RadioLayoutStyles
            Get
                Return _radioLayoutStyle
            End Get
            Set(ByVal value As RadioLayoutStyles)
                _radioLayoutStyle = value
            End Set
        End Property
        <Category("Behavior"), Browsable(True), _
        EditorAttribute(GetType(SPRadioButtonListItemsEditor), _
        GetType(System.Drawing.Design.UITypeEditor))> _
        Public Property Items() As SPRadioButtonItemCollection
            Get
                Return Me._RadioList
            End Get
            Set(ByVal value As SPRadioButtonItemCollection)
                Me._RadioList = value
                BuildRadioTable()
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub Add(ByVal Name As String, ByVal Text As String, ByVal Selected As Boolean)
            Me._RadioList.Add(New SPRadioButtonItem(Name, Text, Selected))
        End Sub

        Public Sub Remove(ByVal Name As String)
            Me._RadioList.Remove(Me._RadioList.Item(Name))
        End Sub
#End Region

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
                    Me.Controls.Clear()
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
                        BuildRadioTable()
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

#Region "Building the Radio Button List"

        Public Sub BuildRadioTable()
            Dim radioTable As TableLayoutPanel = Me.RadioTableLayout
            radioTable.Controls.Clear()

            With radioTable
                .RowStyles.Clear()
                .ColumnStyles.Clear()

                .RowStyles.Add( _
                New RowStyle(SizeType.AutoSize))
                .ColumnStyles.Add( _
                 New ColumnStyle(SizeType.AutoSize))

                Select Case Me._radioLayoutStyle
                    Case RadioLayoutStyles.Horizontal
                        .ColumnCount = 1
                        .RowCount = Me._RadioList.Count
                    Case RadioLayoutStyles.Vertical
                        .ColumnCount = Me._RadioList.Count
                        .RowCount = 1
                    Case RadioLayoutStyles.Table
                        .ColumnCount = (Me._RadioList.Count) \ 2
                        .RowCount = .ColumnCount
                End Select

                Dim tempItems(,) As SPRadioButtonItem = ArrangeItems(.RowCount, .ColumnCount)
                ' Fill in the TableLayoutPanel.
                FillTable(tempItems, .RowCount, .ColumnCount, Me.RadioTableLayout)

            End With


        End Sub
        Private Function ArrangeItems( _
         ByVal rows As Integer, ByVal cols As Integer) _
         As SPRadioButtonItem(,)

            ' Return array of RadioButtonItem instances that matches
            ' the layout of the control:
            Dim items(cols - 1, rows - 1) As SPRadioButtonItem

            ' Fill in the items array:
            Dim currentItem As Integer = 0
            For col As Integer = 0 To cols - 1
                For row As Integer = 0 To rows - 1
                    If currentItem < Me._RadioList.Count Then
                        items(col, row) = Me._RadioList(currentItem)
                        currentItem += 1
                    End If
                Next
            Next
            Return items
        End Function

        Private Sub FillTable(ByVal items As SPRadioButtonItem(,), _
     ByVal rows As Integer, ByVal cols As Integer, _
     ByRef tbl As TableLayoutPanel)

            For col As Integer = 0 To cols - 1
                For row As Integer = 0 To rows - 1
                    Dim radioItem As SPRadioButtonItem = items(col, row)
                    If radioItem IsNot Nothing Then
                        If Not String.IsNullOrEmpty(radioItem.Name) Then
                            Dim btn As New RadioButton
                            btn.Name = radioItem.Name
                            btn.Text = radioItem.Text
                            btn.Dock = DockStyle.Fill
                            AddHandler btn.CheckedChanged, AddressOf OnCheckedChanged
                            tbl.Controls.Add(btn, col, row)
                        End If
                    End If
                Next
            Next
        End Sub

#End Region

    End Class

    Public Class SPRadioButtonItemCollection
        Inherits List(Of SPRadioButtonItem)

        Default Public Overloads ReadOnly Property Item(ByVal Name As String) As SPRadioButtonItem
            Get
                For cnt As Integer = 0 To Me.Count - 1
                    If Me.Item(cnt).Name = Name Then
                        Return Me.Item(cnt)
                    End If
                Next

                Return Nothing
            End Get
        End Property

    End Class
    Public Class SPRadioButtonItem

        Private _Name As String = String.Empty
        Private _Checked As Boolean = False
        Private _ID As Integer = -1
        Private _Text As String = String.Empty

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal value As String)
                _Text = value
            End Set
        End Property
        Public Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
            End Set
        End Property

        Friend Sub New()

        End Sub
        Friend Sub New(ByVal Name As String, ByVal Text As String, ByVal Checked As Boolean)
            Me.Name = Name
            Me.Text = Text
            Me.Checked = Checked
        End Sub
    End Class

#Region "Designer Extensions"
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Public Class SPRadioButtonListDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Private lists As DesignerActionListCollection

        'Use pull model to populate smart tag menu.
        Public Overrides ReadOnly Property ActionLists() _
        As DesignerActionListCollection
            Get
                If lists Is Nothing Then
                    lists = New DesignerActionListCollection()
                    lists.Add( _
                    New SPRadioButtonListActionList(Me.Component))
                End If
                Return lists
            End Get
        End Property
    End Class

    '///////////////////////////////////////////////////////////////
    'DesignerActionList-derived class defines smart tag entries and
    ' resultant actions.
    '///////////////////////////////////////////////////////////////
    Public Class SPRadioButtonListActionList
        Inherits System.ComponentModel.Design.DesignerActionList

        Private taskView As SPRadioButtonList
        Private m_enmDockStyle As DockStyle = DockStyle.None

        Private designerActionUISvc As DesignerActionUIService = Nothing

        'The constructor associates the control 
        'with the smart tag list.
        Public Sub New(ByVal component As IComponent)

            MyBase.New(component)
            Me.taskView = CType(component, SPRadioButtonList)

            ' Cache a reference to DesignerActionUIService, so the
            ' DesigneractionList can be refreshed.
            Me.designerActionUISvc = _
            CType(GetService(GetType(DesignerActionUIService)),  _
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
                "Matching SPRadioButtonList property not found!", propName)
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


    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class SPRadioButtonListItemsEditor
        Inherits UITypeEditor

        Private editorService As IWindowsFormsEditorService

        Public Overloads Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            If ((context IsNot Nothing) And (context.Instance IsNot Nothing) And (provider IsNot Nothing)) Then
                editorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

                If (editorService IsNot Nothing) Then
                    Dim selectionControl As _
                          New SPRadioButtonListEditorUI( _
                          CType(value, SPRadioButtonItemCollection), _
                          editorService)

                    editorService.ShowDialog(selectionControl)

                    value = selectionControl.RadioItems
                End If
            End If

            Return value
        End Function

        Public Overloads Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
            If ((context IsNot Nothing) And (context.Instance IsNot Nothing)) Then
                Return UITypeEditorEditStyle.Modal
            End If
            Return MyBase.GetEditStyle(context)
        End Function

    End Class
#End Region
End Namespace
