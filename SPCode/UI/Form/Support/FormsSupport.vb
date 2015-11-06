Imports System.IO
Imports System.Data
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports SoftLogik.Win.UI
Imports ComponentFactory.Krypton.Toolkit

Namespace UI
    Public Class SPFormRecordBindingEventArgs
        Inherits System.EventArgs

        Private _DataSource As DataTable = Nothing
        Private _RecordBindingSettings As SPRecordBindingSettings = New SPRecordBindingSettings


        Public Property DataSource() As DataTable
            Get
                Return _DataSource
            End Get
            Set(ByVal value As DataTable)
                _DataSource = value
            End Set
        End Property
        Public Property BindingSettings() As SPRecordBindingSettings
            Get
                Return _RecordBindingSettings
            End Get
            Set(ByVal value As SPRecordBindingSettings)
                _RecordBindingSettings = value
            End Set
        End Property

        Friend Sub New()
        End Sub
    End Class


    Public Class SPRecordBindingSettings

        Private _TreeGroups As List(Of SPTreeNodeGroup) = New List(Of SPTreeNodeGroup)
        Private _NewRecordProc As NewRecordCallback = Nothing
        Private _DisplayMember As String = String.Empty
        Private _ValueMember As String = String.Empty

        Public Property DisplayMember() As String
            Get
                Return _DisplayMember
            End Get
            Set(ByVal value As String)
                _DisplayMember = value
            End Set
        End Property
        Public Property ValueMember() As String
            Get
                Return _ValueMember
            End Get
            Set(ByVal value As String)
                _ValueMember = value
            End Set
        End Property

        Public ReadOnly Property NodeGroups() As List(Of SPTreeNodeGroup)
            Get
                Return _TreeGroups
            End Get
        End Property
        Public Property NewRecordProc() As NewRecordCallback
            Get
                Return _NewRecordProc
            End Get
            Set(ByVal value As NewRecordCallback)
                _NewRecordProc = value
            End Set
        End Property
    End Class

    Public Class SPFormNavigateEventArgs
        Inherits System.EventArgs

        Private _NavigateDirection As SPRecordNavigateDirections
        Private _LastRecord As DataRow
        Private _CurrentRecord As DataRow

        Public ReadOnly Property Direction() As SPRecordNavigateDirections
            Get
                Return _NavigateDirection
            End Get
        End Property

        Public Property LastRecord() As DataRow
            Get
                Return _LastRecord
            End Get
            Set(ByVal value As DataRow)
                _LastRecord = value
            End Set
        End Property
        Public Property CurrentRecord() As DataRow
            Get
                Return _CurrentRecord
            End Get
            Set(ByVal value As DataRow)
                _CurrentRecord = value
            End Set
        End Property

        Friend Sub New(ByVal navDirection As SPRecordNavigateDirections)
            _NavigateDirection = navDirection
        End Sub
        Friend Sub New(ByVal navDirection As SPRecordNavigateDirections, ByVal LastRecord As DataRow, ByVal CurrentRecord As DataRow)
            Me._LastRecord = LastRecord
            Me._CurrentRecord = CurrentRecord
            _NavigateDirection = navDirection
        End Sub
    End Class

    Public Class SPFormRecordUpdateEventArgs
        Inherits System.EventArgs

        Private _DataRow As DataRow
        Private _DataState As SPFormDataStates

        Public ReadOnly Property DataRow() As DataRow
            Get
                Return _DataRow
            End Get
        End Property

        <Description("Gets the State the Data Record is currently set to.")> _
        Public ReadOnly Property DataState() As SPFormDataStates
            Get
                Return _DataState
            End Get
        End Property

        Friend Sub New(ByVal DataRow As DataRow, ByVal DataState As SPFormDataStates)
            Me._DataRow = DataRow
            Me._DataState = DataState
        End Sub

    End Class

    Public Class SPFormValidatingEventArgs
        Inherits EventArgs


    End Class

    Public Class SPValidationItemCollection
        Inherits List(Of SPValidationItem)

    End Class

    Public Class SPValidationItem
        Private _Name As String
        Private _Command As SPValidationItemCommands
        Private _ControlName As String

    End Class

    <Description("Represents the internal Form Data Manipulation States.")> _
    Public Class SPFormRecordStateManager
        <Description("Gets or Sets the Current Form Record Operation Mode")> Public CurrentState As SPFormRecordModes
        <Description("Gets or Sets the Showing Data Flag")> Public ShowingData As Boolean
        <Description("Gets or Sets the Form Binding Flag.")> Public BindingData As Boolean
        <Description("Gets or Sets the Duplication Data Flag.")> Public DuplicatingData As Boolean
        <Description("Gets or Sets the NewRecord Data.")> Public NewRecordData As DataRow
    End Class

    Public Delegate Function NewRecordCallback() As DataRowView

    Public Class SPMasterFormManager

        Private Shared _List As New SPMasterFormItemCollection

        Public Shared Function CreateMaster(ByVal TypeID As String) As MasterForm
            If _List.Contains(TypeID) = False Then
                Dim newForm As MasterForm = New MasterForm
                newForm.TypeID = TypeID
                _List.Add(newForm)
                Return newForm
            Else
                Return _List.Item(TypeID)
            End If
        End Function
    End Class

    Public Class SPMasterFormItemCollection
        Inherits List(Of MasterForm)

        Default Public Overloads ReadOnly Property Item(ByVal TypeID As String) As MasterForm
            Get
                For Each frm As MasterForm In Me
                    If frm.TypeID = TypeID Then
                        Return frm
                    End If
                Next

                Return Nothing
            End Get
        End Property
        Public Overloads Function Contains(ByVal TypeID As String) As Boolean
            For Each frm As MasterForm In Me
                If frm.TypeID = TypeID Then
                    Return True
                End If
            Next

            Return False
        End Function
    End Class

    Module SPFormSupport
        Friend Sub BindControls(ByRef Controls As System.Windows.Forms.Control.ControlCollection, ByRef DetailBinding As BindingSource, ByRef RecordState As SPFormRecordStateManager, ByVal OnFieldChanged As EventHandler)
            If DetailBinding IsNot Nothing Then
                RecordState.ShowingData = True
                For Each ctl As Control In Controls 'go thru all controls
                    If ctl.Controls.Count = 0 OrElse ctl.GetType().Name.StartsWith("Krypton") Then
                        BindInnerControls(ctl, DetailBinding, OnFieldChanged)
                    Else
                        BindControls(ctl.Controls, DetailBinding, RecordState, OnFieldChanged)
                    End If
                Next
                RecordState.ShowingData = False
            End If
        End Sub
        Friend Sub BindInnerControls(ByVal OuterControl As Control, ByRef DetailBinding As BindingSource, ByVal OnFieldChanged As EventHandler)
            For Each ctl As Control In OuterControl.Controls
                If ctl.Controls.Count = 0 OrElse _
                ctl.GetType().Name.StartsWith("Krypton") Then
                    If ctl.Tag IsNot Nothing Then
                        If Not String.IsNullOrEmpty(ctl.Tag.ToString().Trim()) Then
                            If TypeOf ctl Is ListControl Then
                                Try
                                    ctl.DataBindings.Add("SelectedValue", DetailBinding, ctl.Tag.ToString)
                                    AddHandler CType(ctl, ListControl).SelectedValueChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            ElseIf (TypeOf ctl Is ComboBox) Or (TypeOf ctl Is KryptonComboBox) Then
                                Try
                                    ctl.DataBindings.Add("SelectedValue", DetailBinding, ctl.Tag.ToString)
                                    AddHandler CType(ctl, ComboBox).SelectedValueChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            ElseIf (TypeOf ctl Is CheckBox) Then
                                Try
                                    ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString)
                                    AddHandler CType(ctl, CheckBox).CheckedChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            ElseIf (TypeOf ctl Is KryptonCheckBox) Then
                                Try
                                    ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString)
                                    AddHandler CType(ctl, KryptonCheckBox).CheckedChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            ElseIf (TypeOf ctl Is RadioButton) Or (TypeOf ctl Is KryptonRadioButton) Then
                                Try
                                    ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString)
                                    AddHandler CType(ctl, RadioButton).CheckedChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            ElseIf TypeOf ctl Is PictureBox Then
                                Try
                                    Dim imageBinding As New Binding("Image", DetailBinding, ctl.Tag.ToString)
                                    AddHandler imageBinding.Parse, AddressOf OnParseImage
                                    AddHandler imageBinding.Format, AddressOf OnFormatImage

                                    ctl.DataBindings.Add(imageBinding)
                                Catch ex As Exception
                                End Try
                            ElseIf TypeOf ctl Is TabPage Then
                                'do nothing
                            ElseIf TypeOf ctl Is ComponentFactory.Krypton.Toolkit.KryptonTextBox Or TypeOf ctl Is ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown Then
                                Try
                                    Dim textBinding As New Binding("Text", DetailBinding, ctl.Tag.ToString)
                                    ctl.DataBindings.Add(textBinding)
                                    AddHandler ctl.TextChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            Else
                                Try
                                    Dim textBinding As New Binding("Text", DetailBinding, ctl.Tag.ToString)
                                    AddHandler textBinding.Parse, AddressOf OnParseText
                                    AddHandler textBinding.Format, AddressOf OnFormatText

                                    ctl.DataBindings.Add(textBinding)
                                    AddHandler ctl.TextChanged, OnFieldChanged  'Add Handler to capture field data changes
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    End If
                Else
                    BindInnerControls(ctl, DetailBinding, OnFieldChanged)
                End If
            Next
        End Sub


        Private Sub OnParseImage(ByVal sender As Object, ByVal e As ConvertEventArgs)
            Try
                Dim imageSource As Image = CType(e.Value, Image)
                Dim imageStream As New MemoryStream
                imageSource.Save(imageStream, ImageFormat.Jpeg)
                e.Value = imageStream.ToArray
            Catch ex As Exception
            End Try
        End Sub
        Private Sub OnFormatImage(ByVal sender As Object, ByVal e As ConvertEventArgs)
            If e.DesiredType Is GetType(Image) Then
                Try
                    If e.Value Is DBNull.Value Then
                        e.Value = My.Resources.NoImage
                    Else
                        e.Value = Image.FromStream(New MemoryStream(CType(e.Value, Byte())))
                    End If
                Catch ex As Exception
                End Try

            End If
        End Sub
        Private Sub OnParseText(ByVal sender As Object, ByVal e As ConvertEventArgs)

        End Sub
        Private Sub OnFormatText(ByVal sender As Object, ByVal e As ConvertEventArgs)

        End Sub

    End Module
End Namespace

