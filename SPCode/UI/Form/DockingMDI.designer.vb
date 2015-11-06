Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DockingMDI
        Inherits DocklessForm

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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DockingMDI))
            Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.DockPanel = New WeifenLuo.WinFormsUI.DockPanel
            Me.mnuFChangeLogin = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuFActiveUsers = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuFChangePassword = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.mnuFSecurity = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.mnuFPrintSetup = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
            Me.mnuFSend = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuFSAttachment = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.mnuFSMessage = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
            Me.mnuFExit = New System.Windows.Forms.ToolStripMenuItem
            Me.StatusStrip = New System.Windows.Forms.StatusStrip
            Me.InfoPanel = New System.Windows.Forms.ToolStripStatusLabel
            Me.InfoProgress = New System.Windows.Forms.ToolStripProgressBar
            Me.QuickActions = New System.Windows.Forms.ToolStripSplitButton
            Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.StatusStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'DockPanel
            '
            Me.DockPanel.ActiveAutoHideContent = Nothing
            Me.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DockPanel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
            Me.DockPanel.Location = New System.Drawing.Point(0, 0)
            Me.DockPanel.Name = "DockPanel"
            Me.DockPanel.ShowDocumentIcon = True
            Me.DockPanel.Size = New System.Drawing.Size(665, 416)
            Me.DockPanel.TabIndex = 9
            '
            'mnuFChangeLogin
            '
            Me.mnuFChangeLogin.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuFChangeLogin.Name = "mnuFChangeLogin"
            Me.mnuFChangeLogin.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
            Me.mnuFChangeLogin.Size = New System.Drawing.Size(192, 22)
            Me.mnuFChangeLogin.Text = "&Change Login"
            '
            'mnuFActiveUsers
            '
            Me.mnuFActiveUsers.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuFActiveUsers.Name = "mnuFActiveUsers"
            Me.mnuFActiveUsers.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
            Me.mnuFActiveUsers.Size = New System.Drawing.Size(192, 22)
            Me.mnuFActiveUsers.Text = "Active &User(s)"
            '
            'mnuFChangePassword
            '
            Me.mnuFChangePassword.Name = "mnuFChangePassword"
            Me.mnuFChangePassword.Size = New System.Drawing.Size(192, 22)
            Me.mnuFChangePassword.Text = "Change &Password"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(189, 6)
            '
            'mnuFSecurity
            '
            Me.mnuFSecurity.ImageTransparentColor = System.Drawing.Color.Black
            Me.mnuFSecurity.Name = "mnuFSecurity"
            Me.mnuFSecurity.ShortcutKeys = System.Windows.Forms.Keys.F7
            Me.mnuFSecurity.Size = New System.Drawing.Size(192, 22)
            Me.mnuFSecurity.Text = "&Security"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(189, 6)
            '
            'mnuFPrintSetup
            '
            Me.mnuFPrintSetup.Name = "mnuFPrintSetup"
            Me.mnuFPrintSetup.Size = New System.Drawing.Size(192, 22)
            Me.mnuFPrintSetup.Text = "Print Setup"
            '
            'ToolStripSeparator5
            '
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            Me.ToolStripSeparator5.Size = New System.Drawing.Size(189, 6)
            '
            'mnuFSend
            '
            Me.mnuFSend.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFSAttachment, Me.ToolStripSeparator1, Me.mnuFSMessage})
            Me.mnuFSend.Name = "mnuFSend"
            Me.mnuFSend.Size = New System.Drawing.Size(192, 22)
            Me.mnuFSend.Text = "Send"
            '
            'mnuFSAttachment
            '
            Me.mnuFSAttachment.Name = "mnuFSAttachment"
            Me.mnuFSAttachment.Size = New System.Drawing.Size(153, 22)
            Me.mnuFSAttachment.Text = "As Attachment"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(150, 6)
            '
            'mnuFSMessage
            '
            Me.mnuFSMessage.Name = "mnuFSMessage"
            Me.mnuFSMessage.Size = New System.Drawing.Size(153, 22)
            Me.mnuFSMessage.Text = "&Message"
            '
            'ToolStripSeparator9
            '
            Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
            Me.ToolStripSeparator9.Size = New System.Drawing.Size(189, 6)
            '
            'mnuFExit
            '
            Me.mnuFExit.Name = "mnuFExit"
            Me.mnuFExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
            Me.mnuFExit.Size = New System.Drawing.Size(192, 22)
            Me.mnuFExit.Text = "E&xit"
            '
            'StatusStrip
            '
            Me.StatusStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoPanel, Me.InfoProgress, Me.QuickActions})
            Me.StatusStrip.Location = New System.Drawing.Point(0, 394)
            Me.StatusStrip.Name = "StatusStrip"
            Me.StatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
            Me.StatusStrip.Size = New System.Drawing.Size(665, 22)
            Me.StatusStrip.TabIndex = 13
            Me.StatusStrip.Text = "StatusStrip"
            '
            'InfoPanel
            '
            Me.InfoPanel.AutoSize = False
            Me.InfoPanel.AutoToolTip = True
            Me.InfoPanel.Name = "InfoPanel"
            Me.InfoPanel.Size = New System.Drawing.Size(600, 17)
            '
            'InfoProgress
            '
            Me.InfoProgress.Name = "InfoProgress"
            Me.InfoProgress.Size = New System.Drawing.Size(100, 16)
            '
            'QuickActions
            '
            Me.QuickActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.QuickActions.Image = CType(resources.GetObject("QuickActions.Image"), System.Drawing.Image)
            Me.QuickActions.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.QuickActions.Name = "QuickActions"
            Me.QuickActions.Size = New System.Drawing.Size(32, 20)
            Me.QuickActions.Text = "Quick Launch"
            Me.QuickActions.ToolTipText = "Quick Actions"
            '
            'DockingMDI
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(665, 416)
            Me.Controls.Add(Me.StatusStrip)
            Me.Controls.Add(Me.DockPanel)
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.IsMdiContainer = True
            Me.Name = "DockingMDI"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.StatusStrip.ResumeLayout(False)
            Me.StatusStrip.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
        Protected Friend WithEvents DockPanel As WeifenLuo.WinFormsUI.DockPanel
        Friend WithEvents mnuFChangeLogin As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuFActiveUsers As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuFChangePassword As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuFSecurity As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuFPrintSetup As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuFSend As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuFSAttachment As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuFSMessage As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuFExit As System.Windows.Forms.ToolStripMenuItem
        Public WithEvents InfoPanel As System.Windows.Forms.ToolStripStatusLabel
        Public WithEvents InfoProgress As System.Windows.Forms.ToolStripProgressBar
        Public WithEvents QuickActions As System.Windows.Forms.ToolStripSplitButton
        Protected Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
        Public WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager

    End Class
End Namespace

