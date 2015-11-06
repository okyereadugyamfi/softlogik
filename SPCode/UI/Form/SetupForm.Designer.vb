Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SetupForm
        Inherits RecordForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupForm))
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.tvwName = New SoftLogik.Win.UI.SPTreeView
            Me.tbcMain = New SoftLogik.Win.UI.SPTabControl(Me.components)
            Me.tabGeneral = New System.Windows.Forms.TabPage
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.tbcMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'IconSource
            '
            Me.IconSource.ImageStream = CType(resources.GetObject("IconSource.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconSource.Images.SetKeyName(0, "DOC.png")
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 40)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.tvwName)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.tbcMain)
            Me.SplitContainer1.Size = New System.Drawing.Size(778, 403)
            Me.SplitContainer1.SplitterDistance = 257
            Me.SplitContainer1.TabIndex = 10
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
            'SetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(778, 443)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Name = "SetupForm"
            Me.Text = "SetupForm"
            Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.tbcMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Protected Friend WithEvents tvwName As SoftLogik.Win.UI.SPTreeView
        Public WithEvents tbcMain As SoftLogik.Win.UI.SPTabControl
        Public WithEvents tabGeneral As System.Windows.Forms.TabPage
    End Class
End Namespace

