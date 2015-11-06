Namespace Reporting
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SPReportFilterUI
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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SPReportFilterUI))
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.FilterList = New System.Windows.Forms.DataGridView
            Me.FieldDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            Me.bsFields = New System.Windows.Forms.BindingSource(Me.components)
            Me.OperationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            Me.bsOperators = New System.Windows.Forms.BindingSource(Me.components)
            Me.ValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ValueField = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.FilterIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.bsFilterTable = New System.Windows.Forms.BindingSource(Me.components)
            Me.DSFilters = New Win.DSFilters
            Me.tbrMainOptions = New System.Windows.Forms.ToolStrip
            Me.NewFilter = New System.Windows.Forms.ToolStripButton
            Me.DeleteFilter = New System.Windows.Forms.ToolStripButton
            Me.ToolStripButton3 = New System.Windows.Forms.ToolStripSeparator
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.FilterList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsFields, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsOperators, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsFilterTable, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DSFilters, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbrMainOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.14577!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.85423!))
            Me.TableLayoutPanel1.Controls.Add(Me.FilterList, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.tbrMainOptions, 0, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 2
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(343, 425)
            Me.TableLayoutPanel1.TabIndex = 1
            '
            'FilterList
            '
            Me.FilterList.AllowUserToOrderColumns = True
            Me.FilterList.AutoGenerateColumns = False
            Me.FilterList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
            Me.FilterList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.FilterList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FieldDataGridViewTextBoxColumn, Me.OperationDataGridViewTextBoxColumn, Me.ValueDataGridViewTextBoxColumn, Me.ValueField, Me.FilterIDDataGridViewTextBoxColumn})
            Me.TableLayoutPanel1.SetColumnSpan(Me.FilterList, 2)
            Me.FilterList.DataSource = Me.bsFilterTable
            Me.FilterList.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FilterList.Location = New System.Drawing.Point(3, 30)
            Me.FilterList.MultiSelect = False
            Me.FilterList.Name = "FilterList"
            Me.FilterList.RowHeadersVisible = False
            Me.FilterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.FilterList.Size = New System.Drawing.Size(337, 392)
            Me.FilterList.TabIndex = 0
            Me.FilterList.TabStop = False
            '
            'FieldDataGridViewTextBoxColumn
            '
            Me.FieldDataGridViewTextBoxColumn.DataPropertyName = "Field"
            Me.FieldDataGridViewTextBoxColumn.DataSource = Me.bsFields
            Me.FieldDataGridViewTextBoxColumn.Frozen = True
            Me.FieldDataGridViewTextBoxColumn.HeaderText = "Field"
            Me.FieldDataGridViewTextBoxColumn.Name = "FieldDataGridViewTextBoxColumn"
            Me.FieldDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.FieldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.FieldDataGridViewTextBoxColumn.Width = 54
            '
            'OperationDataGridViewTextBoxColumn
            '
            Me.OperationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.OperationDataGridViewTextBoxColumn.DataPropertyName = "Operation"
            Me.OperationDataGridViewTextBoxColumn.DataSource = Me.bsOperators
            Me.OperationDataGridViewTextBoxColumn.HeaderText = "Operation"
            Me.OperationDataGridViewTextBoxColumn.Name = "OperationDataGridViewTextBoxColumn"
            Me.OperationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.OperationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'ValueDataGridViewTextBoxColumn
            '
            Me.ValueDataGridViewTextBoxColumn.DataPropertyName = "Value"
            Me.ValueDataGridViewTextBoxColumn.HeaderText = "Value"
            Me.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
            Me.ValueDataGridViewTextBoxColumn.Visible = False
            Me.ValueDataGridViewTextBoxColumn.Width = 59
            '
            'ValueField
            '
            Me.ValueField.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ValueField.HeaderText = "Value"
            Me.ValueField.Name = "ValueField"
            Me.ValueField.ReadOnly = True
            '
            'FilterIDDataGridViewTextBoxColumn
            '
            Me.FilterIDDataGridViewTextBoxColumn.DataPropertyName = "FilterID"
            Me.FilterIDDataGridViewTextBoxColumn.HeaderText = "FilterID"
            Me.FilterIDDataGridViewTextBoxColumn.Name = "FilterIDDataGridViewTextBoxColumn"
            Me.FilterIDDataGridViewTextBoxColumn.Visible = False
            Me.FilterIDDataGridViewTextBoxColumn.Width = 65
            '
            'bsFilterTable
            '
            Me.bsFilterTable.DataMember = "SPFilterTable"
            Me.bsFilterTable.DataSource = Me.DSFilters
            '
            'DSFilters
            '
            Me.DSFilters.DataSetName = "DSFilters"
            Me.DSFilters.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'tbrMainOptions
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.tbrMainOptions, 2)
            Me.tbrMainOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.tbrMainOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewFilter, Me.DeleteFilter, Me.ToolStripButton3})
            Me.tbrMainOptions.Location = New System.Drawing.Point(0, 0)
            Me.tbrMainOptions.Name = "tbrMainOptions"
            Me.tbrMainOptions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
            Me.tbrMainOptions.Size = New System.Drawing.Size(343, 25)
            Me.tbrMainOptions.TabIndex = 5
            Me.tbrMainOptions.Text = "ToolStrip1"
            '
            'NewFilter
            '
            Me.NewFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.NewFilter.Image = CType(resources.GetObject("NewFilter.Image"), System.Drawing.Image)
            Me.NewFilter.Name = "NewFilter"
            Me.NewFilter.RightToLeftAutoMirrorImage = True
            Me.NewFilter.Size = New System.Drawing.Size(23, 22)
            Me.NewFilter.Text = "Add new"
            '
            'DeleteFilter
            '
            Me.DeleteFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.DeleteFilter.Image = CType(resources.GetObject("DeleteFilter.Image"), System.Drawing.Image)
            Me.DeleteFilter.Name = "DeleteFilter"
            Me.DeleteFilter.RightToLeftAutoMirrorImage = True
            Me.DeleteFilter.Size = New System.Drawing.Size(23, 22)
            Me.DeleteFilter.Text = "Delete"
            '
            'ToolStripButton3
            '
            Me.ToolStripButton3.Name = "ToolStripButton3"
            Me.ToolStripButton3.Size = New System.Drawing.Size(6, 25)
            '
            'SPReportFilterUI
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "SPReportFilterUI"
            Me.Size = New System.Drawing.Size(343, 425)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.FilterList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsFields, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsOperators, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsFilterTable, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DSFilters, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbrMainOptions.ResumeLayout(False)
            Me.tbrMainOptions.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents FilterList As System.Windows.Forms.DataGridView
        Friend WithEvents tbrMainOptions As System.Windows.Forms.ToolStrip
        Friend WithEvents NewFilter As System.Windows.Forms.ToolStripButton
        Friend WithEvents DeleteFilter As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents bsFilterTable As System.Windows.Forms.BindingSource
        Friend WithEvents DSFilters As SoftLogik.Win.DSFilters
        Friend WithEvents bsFields As System.Windows.Forms.BindingSource
        Friend WithEvents bsOperators As System.Windows.Forms.BindingSource
        Friend WithEvents FieldDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents OperationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents ValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ValueField As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FilterIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

    End Class
End Namespace

