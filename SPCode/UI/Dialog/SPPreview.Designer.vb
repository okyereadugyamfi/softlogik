Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Class SPPreview
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl
            Me.SuspendLayout()
            '
            'PrintPreviewControl1
            '
            Me.PrintPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PrintPreviewControl1.Location = New System.Drawing.Point(0, 0)
            Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
            Me.PrintPreviewControl1.Size = New System.Drawing.Size(397, 358)
            Me.PrintPreviewControl1.TabIndex = 0
            '
            'SPPreview
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PrintPreviewControl1)
            Me.Name = "SPPreview"
            Me.Size = New System.Drawing.Size(397, 358)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl

    End Class
End Namespace


