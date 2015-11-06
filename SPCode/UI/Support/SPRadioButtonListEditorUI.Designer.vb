Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SPRadioButtonListEditorUI
        Inherits System.Windows.Forms.Form

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
            Me.OutlineBox = New System.Windows.Forms.GroupBox
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.ItemPropertyGrid = New System.Windows.Forms.PropertyGrid
            Me.ItemsList = New System.Windows.Forms.ListBox
            Me.NavigationPanel = New System.Windows.Forms.Panel
            Me.Button2 = New System.Windows.Forms.Button
            Me.btnAddItem = New System.Windows.Forms.Button
            Me.OutlineBox.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.NavigationPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'OutlineBox
            '
            Me.OutlineBox.Controls.Add(Me.TableLayoutPanel1)
            Me.OutlineBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.OutlineBox.Location = New System.Drawing.Point(0, 0)
            Me.OutlineBox.Name = "OutlineBox"
            Me.OutlineBox.Size = New System.Drawing.Size(356, 374)
            Me.OutlineBox.TabIndex = 0
            Me.OutlineBox.TabStop = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.ItemPropertyGrid, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.ItemsList, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.NavigationPanel, 0, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(350, 355)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'ItemPropertyGrid
            '
            Me.ItemPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ItemPropertyGrid.Location = New System.Drawing.Point(178, 3)
            Me.ItemPropertyGrid.Name = "ItemPropertyGrid"
            Me.TableLayoutPanel1.SetRowSpan(Me.ItemPropertyGrid, 2)
            Me.ItemPropertyGrid.Size = New System.Drawing.Size(169, 316)
            Me.ItemPropertyGrid.TabIndex = 1
            '
            'ItemsList
            '
            Me.ItemsList.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ItemsList.FormattingEnabled = True
            Me.ItemsList.Location = New System.Drawing.Point(3, 3)
            Me.ItemsList.Name = "ItemsList"
            Me.TableLayoutPanel1.SetRowSpan(Me.ItemsList, 2)
            Me.ItemsList.Size = New System.Drawing.Size(169, 316)
            Me.ItemsList.TabIndex = 3
            '
            'NavigationPanel
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.NavigationPanel, 2)
            Me.NavigationPanel.Controls.Add(Me.Button2)
            Me.NavigationPanel.Controls.Add(Me.btnAddItem)
            Me.NavigationPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.NavigationPanel.Location = New System.Drawing.Point(3, 325)
            Me.NavigationPanel.Name = "NavigationPanel"
            Me.NavigationPanel.Size = New System.Drawing.Size(344, 27)
            Me.NavigationPanel.TabIndex = 4
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(84, 1)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(75, 23)
            Me.Button2.TabIndex = 4
            Me.Button2.Text = "&Remove"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'btnAddItem
            '
            Me.btnAddItem.Location = New System.Drawing.Point(3, 1)
            Me.btnAddItem.Name = "btnAddItem"
            Me.btnAddItem.Size = New System.Drawing.Size(75, 23)
            Me.btnAddItem.TabIndex = 3
            Me.btnAddItem.Text = "&Add"
            Me.btnAddItem.UseVisualStyleBackColor = True
            '
            'SPRadioButtonListEditorUI
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(356, 374)
            Me.Controls.Add(Me.OutlineBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SPRadioButtonListEditorUI"
            Me.OutlineBox.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.NavigationPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents OutlineBox As System.Windows.Forms.GroupBox
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents ItemPropertyGrid As System.Windows.Forms.PropertyGrid
        Friend WithEvents ItemsList As System.Windows.Forms.ListBox
        Friend WithEvents NavigationPanel As System.Windows.Forms.Panel
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents btnAddItem As System.Windows.Forms.Button

    End Class
End Namespace

