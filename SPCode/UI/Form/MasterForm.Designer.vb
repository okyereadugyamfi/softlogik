Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MasterForm
        Inherits SetupForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterForm))
            Me.gbxOutline = New System.Windows.Forms.GroupBox
            Me.TypeIDField = New System.Windows.Forms.TextBox
            Me.NoteLabel = New System.Windows.Forms.Label
            Me.NoteTextField = New System.Windows.Forms.TextBox
            Me.NameTextField = New System.Windows.Forms.TextBox
            Me.NameLabel = New System.Windows.Forms.Label
            Me.tbcMain.SuspendLayout()
            Me.tabGeneral.SuspendLayout()
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbxOutline.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvwName
            '
            Me.tvwName.LineColor = System.Drawing.Color.Black
            Me.tvwName.TabIndex = 3
            '
            'tbcMain
            '
            Me.tbcMain.TabIndex = 5
            '
            'tabGeneral
            '
            Me.tabGeneral.Controls.Add(Me.gbxOutline)
            Me.tabGeneral.TabIndex = 6
            '
            'IconSource
            '
            Me.IconSource.ImageStream = CType(resources.GetObject("IconSource.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconSource.Images.SetKeyName(0, "DOC.png")
            '
            'gbxOutline
            '
            Me.gbxOutline.Controls.Add(Me.TypeIDField)
            Me.gbxOutline.Controls.Add(Me.NoteLabel)
            Me.gbxOutline.Controls.Add(Me.NoteTextField)
            Me.gbxOutline.Controls.Add(Me.NameTextField)
            Me.gbxOutline.Controls.Add(Me.NameLabel)
            Me.gbxOutline.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gbxOutline.Location = New System.Drawing.Point(3, 3)
            Me.gbxOutline.Name = "gbxOutline"
            Me.gbxOutline.Size = New System.Drawing.Size(503, 389)
            Me.gbxOutline.TabIndex = 0
            Me.gbxOutline.TabStop = False
            '
            'TypeIDField
            '
            Me.TypeIDField.Location = New System.Drawing.Point(90, 298)
            Me.TypeIDField.Name = "TypeIDField"
            Me.TypeIDField.Size = New System.Drawing.Size(100, 20)
            Me.TypeIDField.TabIndex = 2
            Me.TypeIDField.Tag = "TypeID"
            Me.TypeIDField.Visible = False
            '
            'NoteLabel
            '
            Me.NoteLabel.AutoSize = True
            Me.NoteLabel.Location = New System.Drawing.Point(33, 95)
            Me.NoteLabel.Name = "NoteLabel"
            Me.NoteLabel.Size = New System.Drawing.Size(33, 13)
            Me.NoteLabel.TabIndex = 0
            Me.NoteLabel.Text = "N&ote:"
            '
            'NoteTextField
            '
            Me.NoteTextField.Location = New System.Drawing.Point(90, 92)
            Me.NoteTextField.Multiline = True
            Me.NoteTextField.Name = "NoteTextField"
            Me.NoteTextField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.NoteTextField.Size = New System.Drawing.Size(300, 200)
            Me.NoteTextField.TabIndex = 1
            Me.NoteTextField.Tag = "Note"
            '
            'NameTextField
            '
            Me.NameTextField.Location = New System.Drawing.Point(90, 66)
            Me.NameTextField.Name = "NameTextField"
            Me.NameTextField.Size = New System.Drawing.Size(300, 20)
            Me.NameTextField.TabIndex = 1
            Me.NameTextField.Tag = "Name"
            '
            'NameLabel
            '
            Me.NameLabel.AutoSize = True
            Me.NameLabel.Location = New System.Drawing.Point(33, 69)
            Me.NameLabel.Name = "NameLabel"
            Me.NameLabel.Size = New System.Drawing.Size(38, 13)
            Me.NameLabel.TabIndex = 0
            Me.NameLabel.Text = "&Name:"
            '
            'MasterForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(778, 443)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MasterForm"
            Me.tbcMain.ResumeLayout(False)
            Me.tabGeneral.ResumeLayout(False)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbxOutline.ResumeLayout(False)
            Me.gbxOutline.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbxOutline As System.Windows.Forms.GroupBox
        Protected Friend WithEvents NoteLabel As System.Windows.Forms.Label
        Protected Friend WithEvents NoteTextField As System.Windows.Forms.TextBox
        Protected Friend WithEvents NameTextField As System.Windows.Forms.TextBox
        Protected Friend WithEvents NameLabel As System.Windows.Forms.Label
        Protected Friend WithEvents TypeIDField As System.Windows.Forms.TextBox

    End Class
End Namespace

