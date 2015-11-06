Namespace Security
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LoginForm
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
            Me.m_LogInControl = New SoftLogik.Win.Security.AspNetLoginControl
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LogoPictureBox
            '
            Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
            Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            Me.LogoPictureBox.Name = "LogoPictureBox"
            Me.LogoPictureBox.Size = New System.Drawing.Size(121, 151)
            Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.LogoPictureBox.TabIndex = 0
            Me.LogoPictureBox.TabStop = False
            '
            'm_LogInControl
            '
            Me.m_LogInControl.AccessibleName = ""
            Me.m_LogInControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.m_LogInControl.ApplicationName = "/"
            Me.m_LogInControl.BackColor = System.Drawing.SystemColors.Control
            Me.m_LogInControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.m_LogInControl.CacheRoles = False
            Me.m_LogInControl.Location = New System.Drawing.Point(127, 24)
            Me.m_LogInControl.Name = "m_LogInControl"
            Me.m_LogInControl.Padding = New System.Windows.Forms.Padding(1)
            Me.m_LogInControl.Size = New System.Drawing.Size(264, 101)
            Me.m_LogInControl.TabIndex = 2
            '
            'LoginForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(393, 151)
            Me.ControlBox = False
            Me.Controls.Add(Me.m_LogInControl)
            Me.Controls.Add(Me.LogoPictureBox)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LoginForm"
            Me.Opacity = 0.95
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Program Login"
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Protected Friend WithEvents m_LogInControl As SoftLogik.Win.Security.AspNetLoginControl

    End Class
End Namespace

