Imports MT.Common.Controls.OutlookStyleNavigateBar
Imports System.ComponentModel

Namespace Reporting
    Public Class SPReportSettings

        Private nvbFilterView As NavigateBarButton
        Private nvbGroupingView As NavigateBarButton
        Private _ViewerForm As SPReportViewer
        Private _reportFilters As SPReportFilterCollection = Nothing
        Private _reportGroupings As SPReportGroupingCollection = Nothing
        Private _reportParameters As SPReportParameterCollection = Nothing
        Private _AdvancedSearchHandler As SPAdvancedSearchDelegate
        Private _FilterSetupHandler As SPFilterSetupDelegate

#Region "Properties"
        Protected Friend ReadOnly Property Filters() As SPReportFilterCollection
            Get
                If _reportFilters Is Nothing Then _reportFilters = New SPReportFilterCollection
                Return _reportFilters
            End Get
        End Property
        Protected Friend ReadOnly Property Groups() As SPReportGroupingCollection
            Get
                If _reportGroupings Is Nothing Then _reportGroupings = New SPReportGroupingCollection
                Return _reportGroupings
            End Get
        End Property
        Protected Friend ReadOnly Property Parameters() As SPReportParameterCollection
            Get
                If _reportParameters Is Nothing Then _reportParameters = New SPReportParameterCollection
                Return _reportParameters
            End Get
        End Property
        Public Property AdvancedSearchHandler() As SPAdvancedSearchDelegate
            Get
                Return _AdvancedSearchHandler
            End Get
            Set(ByVal value As SPAdvancedSearchDelegate)
                _AdvancedSearchHandler = value
            End Set
        End Property
        Public Property FilterSetupHandler() As SPFilterSetupDelegate
            Get
                Return _FilterSetupHandler
            End Get
            Set(ByVal value As SPFilterSetupDelegate)
                _FilterSetupHandler = value
            End Set
        End Property


        ''' <summary>
        ''' Handle to the Report Viewer Form to enable Settings Form refresh a Loaded Report.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <Description("Handle to the Report Viewer Form to enable Settings Form refresh a Loaded Report.")> _
        Protected Friend WriteOnly Property ViewerForm() As SPReportViewer
            Set(ByVal value As SPReportViewer)
                _ViewerForm = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub AddFilter(ByVal DisplayMember As String, ByVal ValueMember As String, ByVal [Type] As SPReportFilterFieldTypes)
            Filters.Add(DisplayMember, ValueMember, [Type])
        End Sub
        Public Sub AddGrouping(ByVal DisplayMember As String, ByVal ValueMember As String)
            Groups.Add(DisplayMember, ValueMember)
        End Sub
        Public Sub AddParameter(ByVal Name As String, ByVal Value As Object)
            Parameters.Add(Name, Value)
        End Sub
#End Region


        Private Sub InitializeNavBar()
            AppNavigation.CollapsibleScreenWidth = 150
            AppNavigation.Dock = DockStyle.Fill
            nvbFilterView = New NavigateBarButton()
            With nvbFilterView
                .RelatedControl = FilterView
                .Caption = "Report Filters"
                .ToolTipText = "Report Filter Options"
                .Image = My.Resources.Clock
                .Enabled = True
                .Key = "FILTERVIEW"
            End With

            nvbGroupingView = New NavigateBarButton
            With nvbGroupingView
                .RelatedControl = Nothing
                .Caption = "Report Grouping"
                .ToolTipText = "Report Grouping Options"
                .Image = My.Resources.Clock
                .Enabled = True
                .Key = "GROUPINGVIEW"
            End With

            AppNavigation.NavigateBarButtons.Clear()
            AppNavigation.NavigateBarButtons.Add(nvbFilterView)
            AppNavigation.NavigateBarButtons.Add(nvbGroupingView)

            AppNavigation.NavigateBarDisplayedButtonCount = 2
            AppNavigation.Theme = NavigateBarTheme.VS2005Color

        End Sub
        Private Sub InitializeFilters()
            FilterView.Filters = Filters

        End Sub

        Private Sub InitializeGrouping()

        End Sub

        Private Sub SPReportSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            InitializeFilters()
            InitializeGrouping()
            InitializeNavBar()
            If Me._ViewerForm IsNot Nothing Then
                Me._ViewerForm.MdiParent = Me.MdiParent
                Me._ViewerForm.Show()
            End If

            Me.DockState = WeifenLuo.WinFormsUI.DockState.DockLeft

        End Sub
    End Class
End Namespace
