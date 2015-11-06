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

namespace SoftLogik.Win.UI
	{
		public partial class LookupForm : DockableForm
		{
			
			//Form overrides dispose to clean up the component list.
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
				this.tbcMain = new UI.VisualTabControl(this.components);
				this.tabSimple = new System.Windows.Forms.TabPage();
				this.tlpSimple = new System.Windows.Forms.TableLayoutPanel();
				this.SimpleResults = new System.Windows.Forms.DataGridView();
				this.SimpleResults.DoubleClick += new System.EventHandler(SimpleResults_DoubleClick);
				this.bsSimpleSearch = new System.Windows.Forms.BindingSource(this.components);
				this.SearchFor = new System.Windows.Forms.ComboBox();
				this.SearchFor.SelectedIndexChanged += new System.EventHandler(SearchFor_SelectedIndexChanged);
				this.lblSearchFor = new System.Windows.Forms.Label();
				this.SearchText = new System.Windows.Forms.TextBox();
				this.SearchText.TextChanged += new System.EventHandler(SearchText_TextChanged);
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				this.tbcMain.SuspendLayout();
				this.tabSimple.SuspendLayout();
				this.tlpSimple.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.SimpleResults).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.bsSimpleSearch).BeginInit();
				this.SuspendLayout();
				//
				//tbcMain
				//
				this.tbcMain.Controls.Add(this.tabSimple);
				this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tbcMain.ItemSize = new System.Drawing.Size(0, 15);
				this.tbcMain.Location = new System.Drawing.Point(0, 0);
				this.tbcMain.Name = "tbcMain";
				this.tbcMain.Padding = new System.Drawing.Point(9, 0);
				this.tbcMain.SelectedIndex = 0;
				this.tbcMain.Size = new System.Drawing.Size(499, 449);
				this.tbcMain.TabIndex = 3;
				//
				//tabSimple
				//
				this.tabSimple.Controls.Add(this.tlpSimple);
				this.tabSimple.Location = new System.Drawing.Point(4, 19);
				this.tabSimple.Name = "tabSimple";
				this.tabSimple.Padding = new System.Windows.Forms.Padding(3);
				this.tabSimple.Size = new System.Drawing.Size(491, 426);
				this.tabSimple.TabIndex = 0;
				this.tabSimple.Text = "Simple";
				this.tabSimple.UseVisualStyleBackColor = true;
				//
				//tlpSimple
				//
				this.tlpSimple.ColumnCount = 3;
				this.tlpSimple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.18072));
				this.tlpSimple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.81928));
				this.tlpSimple.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 323.0));
				this.tlpSimple.Controls.Add(this.SimpleResults, 0, 1);
				this.tlpSimple.Controls.Add(this.SearchFor, 1, 0);
				this.tlpSimple.Controls.Add(this.lblSearchFor, 0, 0);
				this.tlpSimple.Controls.Add(this.SearchText, 2, 0);
				this.tlpSimple.Dock = System.Windows.Forms.DockStyle.Fill;
				this.tlpSimple.Location = new System.Drawing.Point(3, 3);
				this.tlpSimple.Name = "tlpSimple";
				this.tlpSimple.RowCount = 2;
				this.tlpSimple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.565657));
				this.tlpSimple.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.43434));
				this.tlpSimple.Size = new System.Drawing.Size(485, 420);
				this.tlpSimple.TabIndex = 1;
				//
				//SimpleResults
				//
				this.SimpleResults.AllowUserToAddRows = false;
				this.SimpleResults.AllowUserToDeleteRows = false;
				this.SimpleResults.AllowUserToOrderColumns = true;
				this.SimpleResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
				this.tlpSimple.SetColumnSpan(this.SimpleResults, 3);
				this.SimpleResults.Dock = System.Windows.Forms.DockStyle.Fill;
				this.SimpleResults.Location = new System.Drawing.Point(3, 30);
				this.SimpleResults.Name = "SimpleResults";
				this.SimpleResults.ReadOnly = true;
				this.SimpleResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
				this.SimpleResults.Size = new System.Drawing.Size(479, 387);
				this.SimpleResults.TabIndex = 0;
				//
				//SearchFor
				//
				this.SearchFor.Dock = System.Windows.Forms.DockStyle.Fill;
				this.SearchFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				this.SearchFor.FlatStyle = System.Windows.Forms.FlatStyle.System;
				this.SearchFor.FormattingEnabled = true;
				this.SearchFor.Items.AddRange(new object[] {"ID", "Name"});
				this.SearchFor.Location = new System.Drawing.Point(76, 3);
				this.SearchFor.Name = "SearchFor";
				this.SearchFor.Size = new System.Drawing.Size(82, 21);
				this.SearchFor.TabIndex = 1;
				//
				//lblSearchFor
				//
				this.lblSearchFor.AutoSize = true;
				this.lblSearchFor.Dock = System.Windows.Forms.DockStyle.Fill;
				this.lblSearchFor.Location = new System.Drawing.Point(3, 0);
				this.lblSearchFor.Name = "lblSearchFor";
				this.lblSearchFor.Size = new System.Drawing.Size(67, 27);
				this.lblSearchFor.TabIndex = 2;
				this.lblSearchFor.Text = "Search For:";
				this.lblSearchFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				//
				//SearchText
				//
				this.SearchText.Dock = System.Windows.Forms.DockStyle.Fill;
				this.SearchText.Location = new System.Drawing.Point(164, 3);
				this.SearchText.Name = "SearchText";
				this.SearchText.Size = new System.Drawing.Size(318, 20);
				this.SearchText.TabIndex = 3;
				//
				//LookupForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(499, 449);
				this.Controls.Add(this.tbcMain);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "LookupForm";
				this.ShowInTaskbar = false;
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				this.tbcMain.ResumeLayout(false);
				this.tabSimple.ResumeLayout(false);
				this.tlpSimple.ResumeLayout(false);
				this.tlpSimple.PerformLayout();
				((System.ComponentModel.ISupportInitialize) this.SimpleResults).EndInit();
				((System.ComponentModel.ISupportInitialize) this.bsSimpleSearch).EndInit();
				this.ResumeLayout(false);
				
			}
			internal System.Windows.Forms.TabPage tabSimple;
			protected internal UI.VisualTabControl tbcMain;
			protected internal System.Windows.Forms.TableLayoutPanel tlpSimple;
			protected internal System.Windows.Forms.DataGridView SimpleResults;
			protected internal System.Windows.Forms.ComboBox SearchFor;
			protected internal System.Windows.Forms.Label lblSearchFor;
			protected internal System.Windows.Forms.TextBox SearchText;
			internal System.Windows.Forms.BindingSource bsSimpleSearch;
		}
	}