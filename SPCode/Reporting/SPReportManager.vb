Imports System.ComponentModel
Imports SoftLogik.Win.UI

Namespace Reporting
    Public Class SPReportManager

        Private Shared WithEvents _reportViewer As SPReportViewer = Nothing
        Private Shared WithEvents _reportSettings As SPReportSettings = Nothing
        Private Shared _MdiParent As Form = Nothing

        Private Shared ReadOnly Property Viewer() As SPReportViewer
            Get
                If _reportViewer Is Nothing Then _reportViewer = New SPReportViewer
                If _reportViewer.IsDisposed Then _reportViewer = New SPReportViewer
                Return _reportViewer
            End Get
        End Property
        Public Shared ReadOnly Property Settings() As SPReportSettings
            Get
                If _reportSettings Is Nothing Then _reportSettings = New SPReportSettings
                If _reportSettings.IsDisposed Then _reportSettings = New SPReportSettings
                Return _reportSettings
            End Get
        End Property


        Public Shared WriteOnly Property MdiParent() As Form
            Set(ByVal value As Form)
                _MdiParent = value
            End Set
        End Property

        <Description("Load and Show a Report a specified Report File in the Customized Report Viewer.")> _
        Public Shared Sub ShowReport(ByVal ReportFile As String)
            With Settings
                .MdiParent = _MdiParent
                .ViewerForm = Viewer
                .Show()
            End With
        End Sub

        <Description("Load and Print a Report a specified Report File.")> _
        Public Shared Sub PrintReport(ByVal ReportFile As String)
            Viewer.MdiParent = _MdiParent
            With Settings
                .MdiParent = _MdiParent
                .ViewerForm = Viewer
            End With
        End Sub

    End Class
End Namespace

