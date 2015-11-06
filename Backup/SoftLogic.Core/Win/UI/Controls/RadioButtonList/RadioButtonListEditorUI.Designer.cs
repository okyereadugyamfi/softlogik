namespace SoftLogik.Win.UI.Controls
{
    public partial class RadioButtonListEditorUI : System.Windows.Forms.Form
    {

        //UserControl overrides dispose to clean up the component list.
        internal RadioButtonListEditorUI()
        {
            InitializeComponent();
        }
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
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
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.OutlineBox = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ItemPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ItemsList = new System.Windows.Forms.ListBox();
            this.NavigationPanel = new System.Windows.Forms.Panel();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.OutlineBox.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.NavigationPanel.SuspendLayout();
            this.SuspendLayout();
            //
            //OutlineBox
            //
            this.OutlineBox.Controls.Add(this.TableLayoutPanel1);
            this.OutlineBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineBox.Location = new System.Drawing.Point(0, 0);
            this.OutlineBox.Name = "OutlineBox";
            this.OutlineBox.Size = new System.Drawing.Size(356, 374);
            this.OutlineBox.TabIndex = 0;
            this.OutlineBox.TabStop = false;
            //
            //TableLayoutPanel1
            //
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (float)(50.0)));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (float)(50.0)));
            this.TableLayoutPanel1.Controls.Add(this.ItemPropertyGrid, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.ItemsList, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.NavigationPanel, 0, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (float)(50.0)));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (float)(50.0)));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (float)(33.0)));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(350, 355);
            this.TableLayoutPanel1.TabIndex = 0;
            //
            //ItemPropertyGrid
            //
            this.ItemPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemPropertyGrid.Location = new System.Drawing.Point(178, 3);
            this.ItemPropertyGrid.Name = "ItemPropertyGrid";
            this.TableLayoutPanel1.SetRowSpan(this.ItemPropertyGrid, 2);
            this.ItemPropertyGrid.Size = new System.Drawing.Size(169, 316);
            this.ItemPropertyGrid.TabIndex = 1;
            //
            //ItemsList
            //
            this.ItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsList.FormattingEnabled = true;
            this.ItemsList.Location = new System.Drawing.Point(3, 3);
            this.ItemsList.Name = "ItemsList";
            this.TableLayoutPanel1.SetRowSpan(this.ItemsList, 2);
            this.ItemsList.Size = new System.Drawing.Size(169, 316);
            this.ItemsList.TabIndex = 3;
            //
            //NavigationPanel
            //
            this.TableLayoutPanel1.SetColumnSpan(this.NavigationPanel, 2);
            this.NavigationPanel.Controls.Add(this.Button2);
            this.NavigationPanel.Controls.Add(this.btnAddItem);
            this.NavigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationPanel.Location = new System.Drawing.Point(3, 325);
            this.NavigationPanel.Name = "NavigationPanel";
            this.NavigationPanel.Size = new System.Drawing.Size(344, 27);
            this.NavigationPanel.TabIndex = 4;
            //
            //Button2
            //
            this.Button2.Location = new System.Drawing.Point(84, 1);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "&Remove";
            this.Button2.UseVisualStyleBackColor = true;
            //
            //btnAddItem
            //
            this.btnAddItem.Location = new System.Drawing.Point(3, 1);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "&Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            //
            //RadioButtonListEditorUI
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF((float)(6.0), (float)(13.0));
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 374);
            this.Controls.Add(this.OutlineBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RadioButtonListEditorUI";
            this.OutlineBox.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.NavigationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.GroupBox OutlineBox;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.PropertyGrid ItemPropertyGrid;
        internal System.Windows.Forms.ListBox ItemsList;
        internal System.Windows.Forms.Panel NavigationPanel;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button btnAddItem;

    }
}