Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PaymodeForm
        Inherits SetupForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymodeForm))
            Me.gbxOutline = New System.Windows.Forms.GroupBox
            Me.ddlCategory = New System.Windows.Forms.ComboBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.ddlBankID = New System.Windows.Forms.ComboBox
            Me.lblCategory = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.tbcMain.SuspendLayout()
            Me.tabGeneral.SuspendLayout()
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbxOutline.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvwName
            '
            Me.tvwName.LineColor = System.Drawing.Color.Black
            Me.tvwName.Size = New System.Drawing.Size(203, 275)
            Me.tvwName.TabIndex = 3
            '
            'tbcMain
            '
            Me.tbcMain.Size = New System.Drawing.Size(408, 275)
            Me.tbcMain.TabIndex = 5
            '
            'tabGeneral
            '
            Me.tabGeneral.Controls.Add(Me.gbxOutline)
            Me.tabGeneral.Size = New System.Drawing.Size(400, 252)
            Me.tabGeneral.TabIndex = 6
            '
            'IconSource
            '
            Me.IconSource.ImageStream = CType(resources.GetObject("IconSource.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconSource.Images.SetKeyName(0, "wi0054-48.gif")
            '
            'gbxOutline
            '
            Me.gbxOutline.Controls.Add(Me.ddlCategory)
            Me.gbxOutline.Controls.Add(Me.Label1)
            Me.gbxOutline.Controls.Add(Me.ddlBankID)
            Me.gbxOutline.Controls.Add(Me.lblCategory)
            Me.gbxOutline.Controls.Add(Me.lblNote)
            Me.gbxOutline.Controls.Add(Me.TextBox2)
            Me.gbxOutline.Controls.Add(Me.TextBox1)
            Me.gbxOutline.Controls.Add(Me.lblName)
            Me.gbxOutline.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gbxOutline.Location = New System.Drawing.Point(3, 3)
            Me.gbxOutline.Name = "gbxOutline"
            Me.gbxOutline.Size = New System.Drawing.Size(394, 246)
            Me.gbxOutline.TabIndex = 1
            Me.gbxOutline.TabStop = False
            '
            'ddlCategory
            '
            Me.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ddlCategory.FormattingEnabled = True
            Me.ddlCategory.Location = New System.Drawing.Point(67, 39)
            Me.ddlCategory.Name = "ddlCategory"
            Me.ddlCategory.Size = New System.Drawing.Size(121, 21)
            Me.ddlCategory.TabIndex = 6
            Me.ddlCategory.Tag = "Category"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(9, 69)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(35, 13)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Bank:"
            '
            'ddlBankID
            '
            Me.ddlBankID.FormattingEnabled = True
            Me.ddlBankID.Location = New System.Drawing.Point(67, 66)
            Me.ddlBankID.Name = "ddlBankID"
            Me.ddlBankID.Size = New System.Drawing.Size(121, 21)
            Me.ddlBankID.TabIndex = 4
            Me.ddlBankID.Tag = "BankID"
            '
            'lblCategory
            '
            Me.lblCategory.AutoSize = True
            Me.lblCategory.Location = New System.Drawing.Point(6, 42)
            Me.lblCategory.Name = "lblCategory"
            Me.lblCategory.Size = New System.Drawing.Size(52, 13)
            Me.lblCategory.TabIndex = 3
            Me.lblCategory.Text = "Category:"
            '
            'lblNote
            '
            Me.lblNote.AutoSize = True
            Me.lblNote.Location = New System.Drawing.Point(9, 94)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(33, 13)
            Me.lblNote.TabIndex = 0
            Me.lblNote.Text = "N&ote:"
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(67, 91)
            Me.TextBox2.Multiline = True
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox2.Size = New System.Drawing.Size(300, 100)
            Me.TextBox2.TabIndex = 1
            Me.TextBox2.Tag = "Note"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(67, 13)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(300, 20)
            Me.TextBox1.TabIndex = 1
            Me.TextBox1.Tag = "Name"
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.Location = New System.Drawing.Point(6, 16)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(38, 13)
            Me.lblName.TabIndex = 0
            Me.lblName.Text = "&Name:"
            '
            'PaymodeForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(615, 300)
            Me.Name = "PaymodeForm"
            Me.Text = "Payment Modes"
            Me.tbcMain.ResumeLayout(False)
            Me.tabGeneral.ResumeLayout(False)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbxOutline.ResumeLayout(False)
            Me.gbxOutline.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents gbxOutline As System.Windows.Forms.GroupBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCategory As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents ddlBankID As System.Windows.Forms.ComboBox
        Friend WithEvents ddlCategory As System.Windows.Forms.ComboBox
    End Class
End Namespace

