Namespace Reporting
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SPReportViewer
        Inherits UI.DockableForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ReportViewer1
            '
            Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
            Me.ReportViewer1.Name = "ReportViewer1"
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
            Me.ReportViewer1.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
            Me.ReportViewer1.Size = New System.Drawing.Size(600, 353)
            Me.ReportViewer1.TabIndex = 2
            '
            'SPReportViewer
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(600, 353)
            Me.Controls.Add(Me.ReportViewer1)
            Me.Name = "SPReportViewer"
            Me.Text = "Report Viewer"
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    End Class
End Namespace

