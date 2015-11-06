Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SPRadioButtonList
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.RadioGroupBox = New System.Windows.Forms.GroupBox
            Me.RadioTableLayout = New System.Windows.Forms.TableLayoutPanel
            Me.RadioGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'RadioGroupBox
            '
            Me.RadioGroupBox.Controls.Add(Me.RadioTableLayout)
            Me.RadioGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RadioGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.RadioGroupBox.Name = "RadioGroupBox"
            Me.RadioGroupBox.Size = New System.Drawing.Size(206, 194)
            Me.RadioGroupBox.TabIndex = 0
            Me.RadioGroupBox.TabStop = False
            '
            'RadioTableLayout
            '
            Me.RadioTableLayout.ColumnCount = 2
            Me.RadioTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.RadioTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.RadioTableLayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RadioTableLayout.Location = New System.Drawing.Point(3, 16)
            Me.RadioTableLayout.Name = "RadioTableLayout"
            Me.RadioTableLayout.RowCount = 2
            Me.RadioTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.RadioTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.RadioTableLayout.Size = New System.Drawing.Size(200, 175)
            Me.RadioTableLayout.TabIndex = 0
            '
            'SPRadioButtonGroup
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RadioGroupBox)
            Me.Name = "SPRadioButtonGroup"
            Me.Size = New System.Drawing.Size(206, 194)
            Me.RadioGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RadioGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents RadioTableLayout As System.Windows.Forms.TableLayoutPanel

    End Class
End Namespace

