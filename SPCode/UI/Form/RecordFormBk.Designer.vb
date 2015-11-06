Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RecordFormBk
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
            Me.splMain = New System.Windows.Forms.SplitContainer
            Me.tvwName = New SoftLogik.Win.UI.SPTreeView
            Me.tbcMain = New SoftLogik.Win.UI.SPTabControl(Me.components)
            Me.tabGeneral = New System.Windows.Forms.TabPage
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.tbrMain.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.DetailBinding, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splMain.Panel1.SuspendLayout()
            Me.splMain.Panel2.SuspendLayout()
            Me.splMain.SuspendLayout()
            Me.tbcMain.SuspendLayout()
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
            Me.tbrMain.Text = "Transaction Toolbar"
            '
            'NewRecord
            '
            Me.NewRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.NewRecord.Image = Global.SoftLogik.Win.My.Resources.Resources.Generic_Document
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
            Me.Panel2.Controls.Add(Me.splMain)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 40)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(778, 403)
            Me.Panel2.TabIndex = 8
            '
            'DetailBinding
            '
            '
            'splMain
            '
            Me.splMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splMain.Location = New System.Drawing.Point(0, 0)
            Me.splMain.Name = "splMain"
            '
            'splMain.Panel1
            '
            Me.splMain.Panel1.Controls.Add(Me.tvwName)
            '
            'splMain.Panel2
            '
            Me.splMain.Panel2.Controls.Add(Me.tbcMain)
            Me.splMain.Size = New System.Drawing.Size(778, 403)
            Me.splMain.SplitterDistance = 257
            Me.splMain.TabIndex = 6
            '
            'tvwName
            '
            Me.tvwName.AutoBuildTree = True
            Me.tvwName.DataSource = Nothing
            Me.tvwName.DisplayMember = Nothing
            Me.tvwName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tvwName.HotTracking = True
            Me.tvwName.ImageIndex = 0
            Me.tvwName.ImageList = Me.IconSource
            Me.tvwName.Location = New System.Drawing.Point(0, 0)
            Me.tvwName.Name = "tvwName"
            Me.tvwName.SelectedImageIndex = 0
            Me.tvwName.ShowRootLines = False
            Me.tvwName.Size = New System.Drawing.Size(257, 403)
            Me.tvwName.TabIndex = 0
            Me.tvwName.ValueMember = Nothing
            '
            'tbcMain
            '
            Me.tbcMain.Controls.Add(Me.tabGeneral)
            Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbcMain.ItemSize = New System.Drawing.Size(0, 15)
            Me.tbcMain.Location = New System.Drawing.Point(0, 0)
            Me.tbcMain.Name = "tbcMain"
            Me.tbcMain.Padding = New System.Drawing.Point(9, 0)
            Me.tbcMain.SelectedIndex = 0
            Me.tbcMain.Size = New System.Drawing.Size(517, 403)
            Me.tbcMain.TabIndex = 0
            '
            'tabGeneral
            '
            Me.tabGeneral.CausesValidation = False
            Me.tabGeneral.Location = New System.Drawing.Point(4, 19)
            Me.tabGeneral.Name = "tabGeneral"
            Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
            Me.tabGeneral.Size = New System.Drawing.Size(509, 380)
            Me.tabGeneral.TabIndex = 1
            Me.tabGeneral.Text = "General"
            Me.tabGeneral.UseVisualStyleBackColor = True
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
            Me.Panel2.ResumeLayout(False)
            CType(Me.DetailBinding, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splMain.Panel1.ResumeLayout(False)
            Me.splMain.Panel2.ResumeLayout(False)
            Me.splMain.ResumeLayout(False)
            Me.tbcMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DetailBinding As System.Windows.Forms.BindingSource
        Protected Friend WithEvents IconSource As System.Windows.Forms.ImageList
        Public WithEvents tbrMain As System.Windows.Forms.ToolStrip
        Friend WithEvents NewRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents DeleteRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents SaveRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents UndoRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents CopyRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents SearchRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents FirstRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents PreviousRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents NextRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents LastRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents CloseWindow As System.Windows.Forms.ToolStripButton
        Friend WithEvents SortRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents RefreshRecord As System.Windows.Forms.ToolStripButton
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents splMain As System.Windows.Forms.SplitContainer
        Protected Friend WithEvents tvwName As SoftLogik.Win.UI.SPTreeView
        Public WithEvents tbcMain As SoftLogik.Win.UI.SPTabControl
        Public WithEvents tabGeneral As System.Windows.Forms.TabPage
    End Class
End Namespace

