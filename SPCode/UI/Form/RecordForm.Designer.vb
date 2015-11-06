Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RecordForm
        Inherits DockableForm

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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecordForm))
            Me.IconSource = New System.Windows.Forms.ImageList(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.tbrMain = New System.Windows.Forms.ToolStrip
            Me.NewRecord = New System.Windows.Forms.ToolStripButton
            Me.DeleteRecord = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
            Me.SaveRecord = New System.Windows.Forms.ToolStripButton
            Me.UndoRecord = New System.Windows.Forms.ToolStripButton
            Me.CopyRecord = New System.Windows.Forms.ToolStripButton
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.RefreshRecord = New System.Windows.Forms.ToolStripButton
            Me.SortRecord = New System.Windows.Forms.ToolStripButton
            Me.SearchRecord = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.FirstRecord = New System.Windows.Forms.ToolStripButton
            Me.PreviousRecord = New System.Windows.Forms.ToolStripButton
            Me.NextRecord = New System.Windows.Forms.ToolStripButton
            Me.LastRecord = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.CloseWindow = New System.Windows.Forms.ToolStripButton
            Me.Panel2 = New System.Windows.Forms.Panel
            Me.DetailBinding = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.tbrMain.SuspendLayout()
            CType(Me.DetailBinding, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'IconSource
            '
            Me.IconSource.ImageStream = CType(resources.GetObject("IconSource.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconSource.TransparentColor = System.Drawing.Color.Transparent
            Me.IconSource.Images.SetKeyName(0, "DOC.png")
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.tbrMain)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(778, 40)
            Me.Panel1.TabIndex = 7
            '
            'tbrMain
            '
            Me.tbrMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbrMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.tbrMain.ImageScalingSize = New System.Drawing.Size(22, 22)
            Me.tbrMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewRecord, Me.DeleteRecord, Me.toolStripSeparator, Me.SaveRecord, Me.UndoRecord, Me.CopyRecord, Me.toolStripSeparator1, Me.RefreshRecord, Me.SortRecord, Me.SearchRecord, Me.ToolStripSeparator3, Me.FirstRecord, Me.PreviousRecord, Me.NextRecord, Me.LastRecord, Me.ToolStripSeparator2, Me.CloseWindow})
            Me.tbrMain.Location = New System.Drawing.Point(0, 0)
            Me.tbrMain.Name = "tbrMain"
            Me.tbrMain.Size = New System.Drawing.Size(778, 40)
            Me.tbrMain.Stretch = True
            Me.tbrMain.TabIndex = 7
            Me.tbrMain.Text = "Main Toolbar"
            '
            'NewRecord
            '
            Me.NewRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.NewRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.Edit_file_24
            Me.NewRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.NewRecord.Name = "NewRecord"
            Me.NewRecord.Size = New System.Drawing.Size(26, 37)
            Me.NewRecord.Text = "Create a &New Record"
            '
            'DeleteRecord
            '
            Me.DeleteRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.DeleteRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.editdelete
            Me.DeleteRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.DeleteRecord.Name = "DeleteRecord"
            Me.DeleteRecord.Size = New System.Drawing.Size(26, 37)
            Me.DeleteRecord.Text = "&Delete an Existing Record"
            '
            'toolStripSeparator
            '
            Me.toolStripSeparator.Name = "toolStripSeparator"
            Me.toolStripSeparator.Size = New System.Drawing.Size(6, 40)
            '
            'SaveRecord
            '
            Me.SaveRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.SaveRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.filesave
            Me.SaveRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.SaveRecord.Name = "SaveRecord"
            Me.SaveRecord.Size = New System.Drawing.Size(26, 37)
            Me.SaveRecord.Text = "&Save a Modified Record"
            '
            'UndoRecord
            '
            Me.UndoRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.UndoRecord.Image = CType(resources.GetObject("UndoRecord.Image"), System.Drawing.Image)
            Me.UndoRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.UndoRecord.Name = "UndoRecord"
            Me.UndoRecord.Size = New System.Drawing.Size(26, 37)
            Me.UndoRecord.Text = "&Undo modifications to selected Record"
            '
            'CopyRecord
            '
            Me.CopyRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.CopyRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.copy
            Me.CopyRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.CopyRecord.Name = "CopyRecord"
            Me.CopyRecord.Size = New System.Drawing.Size(26, 37)
            Me.CopyRecord.Text = "D&uplicate selected Record"
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 40)
            '
            'RefreshRecord
            '
            Me.RefreshRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.RefreshRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.reload
            Me.RefreshRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.RefreshRecord.Name = "RefreshRecord"
            Me.RefreshRecord.Size = New System.Drawing.Size(26, 37)
            Me.RefreshRecord.Text = "Refresh"
            '
            'SortRecord
            '
            Me.SortRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.SortRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.sort_incr
            Me.SortRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.SortRecord.Name = "SortRecord"
            Me.SortRecord.Size = New System.Drawing.Size(26, 37)
            Me.SortRecord.Text = "Sort"
            '
            'SearchRecord
            '
            Me.SearchRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.SearchRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.search22
            Me.SearchRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.SearchRecord.Name = "SearchRecord"
            Me.SearchRecord.Size = New System.Drawing.Size(26, 37)
            Me.SearchRecord.Text = "&Search for Records"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
            '
            'FirstRecord
            '
            Me.FirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.FirstRecord.Image = Global.SoftLogik.Win.My.Resources.Resources._2leftarrow
            Me.FirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.FirstRecord.Name = "FirstRecord"
            Me.FirstRecord.Size = New System.Drawing.Size(26, 37)
            Me.FirstRecord.Text = "First"
            Me.FirstRecord.ToolTipText = "Goto First Record"
            '
            'PreviousRecord
            '
            Me.PreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.PreviousRecord.Image = Global.SoftLogik.Win.My.Resources.Resources._1leftarrow
            Me.PreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.PreviousRecord.Name = "PreviousRecord"
            Me.PreviousRecord.Size = New System.Drawing.Size(26, 37)
            Me.PreviousRecord.Text = "Previous"
            Me.PreviousRecord.ToolTipText = "Goto Previous Record"
            '
            'NextRecord
            '
            Me.NextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.NextRecord.Image = Global.SoftLogik.Win.My.Resources.Resources._1rightarrow
            Me.NextRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.NextRecord.Name = "NextRecord"
            Me.NextRecord.Size = New System.Drawing.Size(26, 37)
            Me.NextRecord.Text = "Next"
            Me.NextRecord.ToolTipText = "Goto Next Record"
            '
            'LastRecord
            '
            Me.LastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.LastRecord.Image = Global.SoftLogik.Win.My.Resources.Resources._2rightarrow
            Me.LastRecord.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.LastRecord.Name = "LastRecord"
            Me.LastRecord.Size = New System.Drawing.Size(26, 37)
            Me.LastRecord.Text = "Last"
            Me.LastRecord.ToolTipText = "Goto Last Record"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
            '
            'CloseWindow
            '
            Me.CloseWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.CloseWindow.Image = CType(resources.GetObject("CloseWindow.Image"), System.Drawing.Image)
            Me.CloseWindow.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.CloseWindow.Name = "CloseWindow"
            Me.CloseWindow.Size = New System.Drawing.Size(26, 37)
            Me.CloseWindow.Text = "ToolStripButton1"
            Me.CloseWindow.ToolTipText = "Close this Screen."
            '
            'Panel2
            '
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 40)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(778, 403)
            Me.Panel2.TabIndex = 8
            '
            'DetailBinding
            '
            '
            'RecordForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(778, 443)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Me.DoubleBuffered = True
            Me.Name = "RecordForm"
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.tbrMain.ResumeLayout(False)
            Me.tbrMain.PerformLayout()
            CType(Me.DetailBinding, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DetailBinding As System.Windows.Forms.BindingSource
        Protected Friend WithEvents IconSource As System.Windows.Forms.ImageList
        Public WithEvents tbrMain As System.Windows.Forms.ToolStrip
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Protected Friend WithEvents NewRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents DeleteRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
        Protected Friend WithEvents SaveRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents UndoRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents CopyRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Protected Friend WithEvents SearchRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Protected Friend WithEvents FirstRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents PreviousRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents NextRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents LastRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Protected Friend WithEvents CloseWindow As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents SortRecord As System.Windows.Forms.ToolStripButton
        Protected Friend WithEvents RefreshRecord As System.Windows.Forms.ToolStripButton
    End Class
End Namespace

