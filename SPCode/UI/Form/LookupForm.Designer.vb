Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LookupForm
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
            Me.tbcMain = New UI.SPTabControl(Me.components)
            Me.tabSimple = New System.Windows.Forms.TabPage
            Me.tlpSimple = New System.Windows.Forms.TableLayoutPanel
            Me.SimpleResults = New System.Windows.Forms.DataGridView
            Me.bsSimpleSearch = New System.Windows.Forms.BindingSource(Me.components)
            Me.SearchFor = New System.Windows.Forms.ComboBox
            Me.lblSearchFor = New System.Windows.Forms.Label
            Me.SearchText = New System.Windows.Forms.TextBox
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbcMain.SuspendLayout()
            Me.tabSimple.SuspendLayout()
            Me.tlpSimple.SuspendLayout()
            CType(Me.SimpleResults, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsSimpleSearch, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tbcMain
            '
            Me.tbcMain.Controls.Add(Me.tabSimple)
            Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbcMain.ItemSize = New System.Drawing.Size(0, 15)
            Me.tbcMain.Location = New System.Drawing.Point(0, 0)
            Me.tbcMain.Name = "tbcMain"
            Me.tbcMain.Padding = New System.Drawing.Point(9, 0)
            Me.tbcMain.SelectedIndex = 0
            Me.tbcMain.Size = New System.Drawing.Size(499, 449)
            Me.tbcMain.TabIndex = 3
            '
            'tabSimple
            '
            Me.tabSimple.Controls.Add(Me.tlpSimple)
            Me.tabSimple.Location = New System.Drawing.Point(4, 19)
            Me.tabSimple.Name = "tabSimple"
            Me.tabSimple.Padding = New System.Windows.Forms.Padding(3)
            Me.tabSimple.Size = New System.Drawing.Size(491, 426)
            Me.tabSimple.TabIndex = 0
            Me.tabSimple.Text = "Simple"
            Me.tabSimple.UseVisualStyleBackColor = True
            '
            'tlpSimple
            '
            Me.tlpSimple.ColumnCount = 3
            Me.tlpSimple.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.18072!))
            Me.tlpSimple.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.81928!))
            Me.tlpSimple.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 323.0!))
            Me.tlpSimple.Controls.Add(Me.SimpleResults, 0, 1)
            Me.tlpSimple.Controls.Add(Me.SearchFor, 1, 0)
            Me.tlpSimple.Controls.Add(Me.lblSearchFor, 0, 0)
            Me.tlpSimple.Controls.Add(Me.SearchText, 2, 0)
            Me.tlpSimple.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tlpSimple.Location = New System.Drawing.Point(3, 3)
            Me.tlpSimple.Name = "tlpSimple"
            Me.tlpSimple.RowCount = 2
            Me.tlpSimple.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.565657!))
            Me.tlpSimple.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.43434!))
            Me.tlpSimple.Size = New System.Drawing.Size(485, 420)
            Me.tlpSimple.TabIndex = 1
            '
            'SimpleResults
            '
            Me.SimpleResults.AllowUserToAddRows = False
            Me.SimpleResults.AllowUserToDeleteRows = False
            Me.SimpleResults.AllowUserToOrderColumns = True
            Me.SimpleResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.tlpSimple.SetColumnSpan(Me.SimpleResults, 3)
            Me.SimpleResults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SimpleResults.Location = New System.Drawing.Point(3, 30)
            Me.SimpleResults.Name = "SimpleResults"
            Me.SimpleResults.ReadOnly = True
            Me.SimpleResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.SimpleResults.Size = New System.Drawing.Size(479, 387)
            Me.SimpleResults.TabIndex = 0
            '
            'SearchFor
            '
            Me.SearchFor.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SearchFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SearchFor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.SearchFor.FormattingEnabled = True
            Me.SearchFor.Items.AddRange(New Object() {"ID", "Name"})
            Me.SearchFor.Location = New System.Drawing.Point(76, 3)
            Me.SearchFor.Name = "SearchFor"
            Me.SearchFor.Size = New System.Drawing.Size(82, 21)
            Me.SearchFor.TabIndex = 1
            '
            'lblSearchFor
            '
            Me.lblSearchFor.AutoSize = True
            Me.lblSearchFor.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSearchFor.Location = New System.Drawing.Point(3, 0)
            Me.lblSearchFor.Name = "lblSearchFor"
            Me.lblSearchFor.Size = New System.Drawing.Size(67, 27)
            Me.lblSearchFor.TabIndex = 2
            Me.lblSearchFor.Text = "Search For:"
            Me.lblSearchFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'SearchText
            '
            Me.SearchText.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SearchText.Location = New System.Drawing.Point(164, 3)
            Me.SearchText.Name = "SearchText"
            Me.SearchText.Size = New System.Drawing.Size(318, 20)
            Me.SearchText.TabIndex = 3
            '
            'LookupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(499, 449)
            Me.Controls.Add(Me.tbcMain)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LookupForm"
            Me.ShowInTaskbar = False
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbcMain.ResumeLayout(False)
            Me.tabSimple.ResumeLayout(False)
            Me.tlpSimple.ResumeLayout(False)
            Me.tlpSimple.PerformLayout()
            CType(Me.SimpleResults, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsSimpleSearch, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents tabSimple As System.Windows.Forms.TabPage
        Protected Friend WithEvents tbcMain As UI.SPTabControl
        Protected Friend WithEvents tlpSimple As System.Windows.Forms.TableLayoutPanel
        Protected Friend WithEvents SimpleResults As System.Windows.Forms.DataGridView
        Protected Friend WithEvents SearchFor As System.Windows.Forms.ComboBox
        Protected Friend WithEvents lblSearchFor As System.Windows.Forms.Label
        Protected Friend WithEvents SearchText As System.Windows.Forms.TextBox
        Friend WithEvents bsSimpleSearch As System.Windows.Forms.BindingSource
    End Class
End Namespace

