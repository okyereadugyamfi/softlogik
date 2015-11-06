Namespace Security
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ChangePasswordForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
        Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.LogoPictureBox = New System.Windows.Forms.PictureBox
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LogoPictureBox
            '
            Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
            Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            Me.LogoPictureBox.Name = "LogoPictureBox"
            Me.LogoPictureBox.Size = New System.Drawing.Size(121, 185)
            Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.LogoPictureBox.TabIndex = 0
            Me.LogoPictureBox.TabStop = False
            '
            'ChangePasswordForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(393, 185)
            Me.ControlBox = False
            Me.Controls.Add(Me.LogoPictureBox)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ChangePasswordForm"
            Me.Opacity = 0.95
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Change Password"
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

    End Class
End Namespace

