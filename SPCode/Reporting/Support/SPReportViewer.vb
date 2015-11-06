Namespace Reporting
    Public Class SPReportViewer

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            Me.ReportViewer1.RefreshReport()
        End Sub
    End Class
End Namespace
