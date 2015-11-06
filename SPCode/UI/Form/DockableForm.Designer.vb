Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DockableForm

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
            Me.ErrorNotify = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.DockingContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
            Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.DockingContextMenu.SuspendLayout()
            Me.SuspendLayout()
            '
            'ErrorNotify
            '
            Me.ErrorNotify.ContainerControl = Me
            '
            'DockingContextMenu
            '
            Me.DockingContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.mnuClose})
            Me.DockingContextMenu.Name = "DockingContextMenu"
            Me.DockingContextMenu.Size = New System.Drawing.Size(151, 32)
            '
            'ToolStripMenuItem1
            '
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
            '
            'mnuClose
            '
            Me.mnuClose.Name = "mnuClose"
            Me.mnuClose.Size = New System.Drawing.Size(150, 22)
            Me.mnuClose.Text = "&Close Window"
            '
            'DockableForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(335, 278)
            Me.KeyPreview = True
            Me.Name = "DockableForm"
            Me.TabPageContextMenuStrip = Me.DockingContextMenu
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.DockingContextMenu.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected Friend WithEvents ErrorNotify As System.Windows.Forms.ErrorProvider
        Protected Friend WithEvents MyTabOrderManager As UI.SPTabOrderManager
        Protected Friend WithEvents DockingContextMenu As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    End Class
End Namespace

