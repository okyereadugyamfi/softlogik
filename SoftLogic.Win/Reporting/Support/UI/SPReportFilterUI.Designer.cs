using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;

namespace SoftLogik.Win
{
	namespace Reporting
	{
		public partial class SPReportFilterUI : System.Windows.Forms.UserControl
		{
			
			
			//UserControl overrides dispose to clean up the component list.
			[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
				try
				{
					if (disposing && (components != null))
					{
						components.Dispose();
					}
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPReportFilterUI));
				this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
				this.FilterList = new System.Windows.Forms.DataGridView();
				this.FieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
				this.bsFields = new System.Windows.Forms.BindingSource(this.components);
				this.OperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
				this.bsOperators = new System.Windows.Forms.BindingSource(this.components);
				this.ValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
				this.ValueField = new System.Windows.Forms.DataGridViewTextBoxColumn();
				this.FilterIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
				this.bsFilterTable = new System.Windows.Forms.BindingSource(this.components);
				this.DSFilters = new Win.DSFilters();
				this.tbrMainOptions = new System.Windows.Forms.ToolStrip();
				this.NewFilter = new System.Windows.Forms.ToolStripButton();
				this.NewFilter.Click += new System.EventHandler(NewFilter_Click);
				this.DeleteFilter = new System.Windows.Forms.ToolStripButton();
				this.DeleteFilter.Click += new System.EventHandler(DeleteFilter_Click);
				this.ToolStripButton3 = new System.Windows.Forms.ToolStripSeparator();
				this.TableLayoutPanel1.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.FilterList).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.bsFields).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.bsOperators).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.bsFilterTable).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.DSFilters).BeginInit();
				this.tbrMainOptions.SuspendLayout();
				this.SuspendLayout();
				//
				//TableLayoutPanel1
				//
				this.TableLayoutPanel1.ColumnCount = 2;
				this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.14577));
				this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.85423));
				this.TableLayoutPanel1.Controls.Add(this.FilterList, 0, 1);
				this.TableLayoutPanel1.Controls.Add(this.tbrMainOptions, 0, 0);
				this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
				this.TableLayoutPanel1.Name = "TableLayoutPanel1";
				this.TableLayoutPanel1.RowCount = 2;
				this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0));
				this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.0));
				this.TableLayoutPanel1.Size = new System.Drawing.Size(343, 425);
				this.TableLayoutPanel1.TabIndex = 1;
				//
				//FilterList
				//
				this.FilterList.AllowUserToOrderColumns = true;
				this.FilterList.AutoGenerateColumns = false;
				this.FilterList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
				this.FilterList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
				this.FilterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.FieldDataGridViewTextBoxColumn, this.OperationDataGridViewTextBoxColumn, this.ValueDataGridViewTextBoxColumn, this.ValueField, this.FilterIDDataGridViewTextBoxColumn});
				this.TableLayoutPanel1.SetColumnSpan(this.FilterList, 2);
				this.FilterList.DataSource = this.bsFilterTable;
				this.FilterList.Dock = System.Windows.Forms.DockStyle.Fill;
				this.FilterList.Location = new System.Drawing.Point(3, 30);
				this.FilterList.MultiSelect = false;
				this.FilterList.Name = "FilterList";
				this.FilterList.RowHeadersVisible = false;
				this.FilterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
				this.FilterList.Size = new System.Drawing.Size(337, 392);
				this.FilterList.TabIndex = 0;
				this.FilterList.TabStop = false;
				//
				//FieldDataGridViewTextBoxColumn
				//
				this.FieldDataGridViewTextBoxColumn.DataPropertyName = "Field";
				this.FieldDataGridViewTextBoxColumn.DataSource = this.bsFields;
				this.FieldDataGridViewTextBoxColumn.Frozen = true;
				this.FieldDataGridViewTextBoxColumn.HeaderText = "Field";
				this.FieldDataGridViewTextBoxColumn.Name = "FieldDataGridViewTextBoxColumn";
				this.FieldDataGridViewTextBoxColumn.Resizable = @System.Windows.Forms.DataGridViewTriState.True;
				this.FieldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
				this.FieldDataGridViewTextBoxColumn.Width = 54;
				//
				//OperationDataGridViewTextBoxColumn
				//
				this.OperationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
				this.OperationDataGridViewTextBoxColumn.DataPropertyName = "Operation";
				this.OperationDataGridViewTextBoxColumn.DataSource = this.bsOperators;
				this.OperationDataGridViewTextBoxColumn.HeaderText = "Operation";
				this.OperationDataGridViewTextBoxColumn.Name = "OperationDataGridViewTextBoxColumn";
				this.OperationDataGridViewTextBoxColumn.Resizable = @System.Windows.Forms.DataGridViewTriState.True;
				this.OperationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
				//
				//ValueDataGridViewTextBoxColumn
				//
				this.ValueDataGridViewTextBoxColumn.DataPropertyName = "Value";
				this.ValueDataGridViewTextBoxColumn.HeaderText = "Value";
				this.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn";
				this.ValueDataGridViewTextBoxColumn.Visible = false;
				this.ValueDataGridViewTextBoxColumn.Width = 59;
				//
				//ValueField
				//
				this.ValueField.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
				this.ValueField.HeaderText = "Value";
				this.ValueField.Name = "ValueField";
				this.ValueField.ReadOnly = true;
				//
				//FilterIDDataGridViewTextBoxColumn
				//
				this.FilterIDDataGridViewTextBoxColumn.DataPropertyName = "FilterID";
				this.FilterIDDataGridViewTextBoxColumn.HeaderText = "FilterID";
				this.FilterIDDataGridViewTextBoxColumn.Name = "FilterIDDataGridViewTextBoxColumn";
				this.FilterIDDataGridViewTextBoxColumn.Visible = false;
				this.FilterIDDataGridViewTextBoxColumn.Width = 65;
				//
				//bsFilterTable
				//
				this.bsFilterTable.DataMember = "SPFilterTable";
				this.bsFilterTable.DataSource = this.DSFilters;
				//
				//DSFilters
				//
				this.DSFilters.DataSetName = "DSFilters";
				this.DSFilters.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
				//
				//tbrMainOptions
				//
				this.TableLayoutPanel1.SetColumnSpan(this.tbrMainOptions, 2);
				this.tbrMainOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
				this.tbrMainOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.NewFilter, this.DeleteFilter, this.ToolStripButton3});
				this.tbrMainOptions.Location = new System.Drawing.Point(0, 0);
				this.tbrMainOptions.Name = "tbrMainOptions";
				this.tbrMainOptions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
				this.tbrMainOptions.Size = new System.Drawing.Size(343, 25);
				this.tbrMainOptions.TabIndex = 5;
				this.tbrMainOptions.Text = "ToolStrip1";
				//
				//NewFilter
				//
				this.NewFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.NewFilter.Image = (System.Drawing.Image) (resources.GetObject("NewFilter.Image"));
				this.NewFilter.Name = "NewFilter";
				this.NewFilter.RightToLeftAutoMirrorImage = true;
				this.NewFilter.Size = new System.Drawing.Size(23, 22);
				this.NewFilter.Text = "Add new";
				//
				//DeleteFilter
				//
				this.DeleteFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				this.DeleteFilter.Image = (System.Drawing.Image) (resources.GetObject("DeleteFilter.Image"));
				this.DeleteFilter.Name = "DeleteFilter";
				this.DeleteFilter.RightToLeftAutoMirrorImage = true;
				this.DeleteFilter.Size = new System.Drawing.Size(23, 22);
				this.DeleteFilter.Text = "Delete";
				//
				//ToolStripButton3
				//
				this.ToolStripButton3.Name = "ToolStripButton3";
				this.ToolStripButton3.Size = new System.Drawing.Size(6, 25);
				//
				//SPReportFilterUI
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.Controls.Add(this.TableLayoutPanel1);
				this.Name = "SPReportFilterUI";
				this.Size = new System.Drawing.Size(343, 425);
				this.TableLayoutPanel1.ResumeLayout(false);
				this.TableLayoutPanel1.PerformLayout();
				((System.ComponentModel.ISupportInitialize) this.FilterList).EndInit();
				((System.ComponentModel.ISupportInitialize) this.bsFields).EndInit();
				((System.ComponentModel.ISupportInitialize) this.bsOperators).EndInit();
				((System.ComponentModel.ISupportInitialize) this.bsFilterTable).EndInit();
				((System.ComponentModel.ISupportInitialize) this.DSFilters).EndInit();
				this.tbrMainOptions.ResumeLayout(false);
				this.tbrMainOptions.PerformLayout();
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
			internal System.Windows.Forms.DataGridView FilterList;
			internal System.Windows.Forms.ToolStrip tbrMainOptions;
			internal System.Windows.Forms.ToolStripButton NewFilter;
			internal System.Windows.Forms.ToolStripButton DeleteFilter;
			internal System.Windows.Forms.ToolStripSeparator ToolStripButton3;
			internal System.Windows.Forms.BindingSource bsFilterTable;
			internal SoftLogik.Win.DSFilters DSFilters;
			internal System.Windows.Forms.BindingSource bsFields;
			internal System.Windows.Forms.BindingSource bsOperators;
			internal System.Windows.Forms.DataGridViewComboBoxColumn FieldDataGridViewTextBoxColumn;
			internal System.Windows.Forms.DataGridViewComboBoxColumn OperationDataGridViewTextBoxColumn;
			internal System.Windows.Forms.DataGridViewTextBoxColumn ValueDataGridViewTextBoxColumn;
			internal System.Windows.Forms.DataGridViewTextBoxColumn ValueField;
			internal System.Windows.Forms.DataGridViewTextBoxColumn FilterIDDataGridViewTextBoxColumn;
			
		}
	}
	
	
}
