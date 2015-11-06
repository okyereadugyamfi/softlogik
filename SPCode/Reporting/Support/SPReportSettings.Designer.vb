Namespace Reporting
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SPReportSettings
        Inherits UI.NavigatorForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.FilterView = New SPReportFilterUI
            Me.AppNavigation.SuspendLayout()
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'AppNavigation
            '
            Me.AppNavigation.Controls.Add(Me.FilterView)
            Me.AppNavigation.Dock = System.Windows.Forms.DockStyle.None
            Me.AppNavigation.Size = New System.Drawing.Size(222, 391)
            '
            'FilterView
            '
            Me.FilterView.Location = New System.Drawing.Point(165, 12)
            Me.FilterView.Name = "FilterView"
            Me.FilterView.Size = New System.Drawing.Size(339, 428)
            Me.FilterView.TabIndex = 5
            '
            'SPReportSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(317, 391)
            Me.Name = "SPReportSettings"
            Me.Text = "Report Settings"
            Me.Controls.SetChildIndex(Me.AppNavigation, 0)
            Me.AppNavigation.ResumeLayout(False)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents FilterView As SPReportFilterUI
    End Class
End Namespace

