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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms.ComponentModel;


namespace SoftLogik.Win
{
	namespace UI
	{
		[Designer(typeof(SPRadioButtonListDesigner))][ToolboxBitmap(typeof(SPRadioButtonListDesigner))][DefaultEvent("SelectedIndexChanged")]public partial class SPRadioButtonList
		{
			
			
			public enum RadioLayoutStyles
			{
				@Horizontal,
				@Vertical,
				@Table
			}
			
			public delegate void SelectedIndexChangedEventHandler(object sender, System.EventArgs e);
			private SelectedIndexChangedEventHandler SelectedIndexChangedEvent;
			
			public event SelectedIndexChangedEventHandler SelectedIndexChanged
			{
				add
				{
					SelectedIndexChangedEvent = (SelectedIndexChangedEventHandler) System.Delegate.Combine(SelectedIndexChangedEvent, value);
				}
				remove
				{
					SelectedIndexChangedEvent = (SelectedIndexChangedEventHandler) System.Delegate.Remove(SelectedIndexChangedEvent, value);
				}
			}
			
			
			private SPRadioButtonItemCollection _RadioList = new SPRadioButtonItemCollection();
			private RadioLayoutStyles _radioLayoutStyle;
			private int _SelectedIndex = - 1;
			private object _SelectedValue = null;
			
			#region Overrides
			protected override void OnLoad(System.EventArgs e)
			{
				base.OnLoad(e);
				
				try
				{
					this.RadioGroupBox.Text = this.Text;
					BuildRadioTable();
				}
				catch (Exception)
				{
				}
			}
			
			protected void OnCheckedChanged(System.Object sender, System.EventArgs e)
			{
				
			}
			
			#endregion
			
			#region Properties
			[Category("Behavior")][Description("Gets or Sets the Radio Buttons Layout Style")]public RadioLayoutStyles LayoutStyle
			{
				get
				{
					return _radioLayoutStyle;
				}
				set
				{
					_radioLayoutStyle = value;
				}
			}
			[Category("Behavior"), Browsable(true), EditorAttribute(typeof(SPRadioButtonListItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]public SPRadioButtonItemCollection Items
			{
				get
				{
					return this._RadioList;
				}
				set
				{
					this._RadioList = value;
					BuildRadioTable();
				}
			}
			#endregion
			
			#region Methods
			public void Add(string Name, string Text, bool Selected)
			{
				this._RadioList.Add(new SPRadioButtonItem(Name, Text, Selected));
			}
			
			public void Remove(string Name)
			{
				this._RadioList.Remove(this._RadioList[Name]);
			}
			#endregion
			
			#region Data Binding
			private CurrencyManager m_currencyManager = null;
			private string m_ValueMember;
			private string m_DisplayMember;
			private object m_oDataSource;
			
			[Category("Data")]public object DataSource
			{
				get
				{
					return m_oDataSource;
				}
				set
				{
					if (value == null)
					{
						this.m_currencyManager = null;
						this.Controls.Clear();
					}
					else
					{
						if (!(value is IList|| m_oDataSource is IListSource))
						{
							throw (new System.Exception("Invalid DataSource"));
						}
						else
						{
							if (value is IListSource)
							{
								IListSource myListSource = (IListSource) value;
								if (myListSource.ContainsListCollection == true)
								{
									throw (new System.Exception("Invalid DataSource"));
								}
							}
							this.m_oDataSource = value;
							this.m_currencyManager = (CurrencyManager) (this.BindingContext[value]);
							BuildRadioTable();
						}
					}
				}
			} // end of DataSource property
			
			[Category("Data")]public string ValueMember
			{
				get
				{
					return this.m_ValueMember;
				}
				set
				{
					this.m_ValueMember = value;
				}
			}
			[Category("Data")]public string DisplayMember
			{
				get
				{
					return this.m_DisplayMember;
				}
				set
				{
					this.m_DisplayMember = value;
				}
			}
			public object GetValue(int index)
			{
				IList innerList = this.m_currencyManager.List;
				if (innerList != null)
				{
					if ((this.ValueMember != "") && (index >= 0 && 0 < innerList.Count))
					{
						PropertyDescriptor pdValueMember;
						pdValueMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
						return pdValueMember.GetValue(innerList[index]);
					}
				}
				return null;
			}
			public object GetDisplay(int index)
			{
				IList innerList = this.m_currencyManager.List;
				if (innerList != null)
				{
					if ((this.DisplayMember != "") && (index >= 0 && 0 < innerList.Count))
					{
						PropertyDescriptor pdDisplayMember;
						pdDisplayMember = this.m_currencyManager.GetItemProperties()[this.ValueMember];
						return pdDisplayMember.GetValue(innerList[index]);
					}
				}
				return null;
			}
			
			#endregion
			
			#region Building the Radio Button List
			
			public void BuildRadioTable()
			{
				TableLayoutPanel radioTable = this.RadioTableLayout;
				radioTable.Controls.Clear();
				
				radioTable.RowStyles.Clear();
				radioTable.ColumnStyles.Clear();
				
				radioTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				radioTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				
				switch (this._radioLayoutStyle)
				{
					case RadioLayoutStyles.Horizontal:
						radioTable.ColumnCount = 1;
						radioTable.RowCount = this._RadioList.Count;
						break;
					case RadioLayoutStyles.Vertical:
						radioTable.ColumnCount = this._RadioList.Count;
						radioTable.RowCount = 1;
						break;
					case RadioLayoutStyles.Table:
						radioTable.ColumnCount = (this._RadioList.Count) / 2;
						radioTable.RowCount = radioTable.ColumnCount;
						break;
				}
				
				SPRadioButtonItem[,] tempItems = ArrangeItems(radioTable.RowCount, radioTable.ColumnCount);
				// Fill in the TableLayoutPanel.
				FillTable(tempItems, radioTable.RowCount, radioTable.ColumnCount, this.RadioTableLayout);
				
				
				
			}
			private SPRadioButtonItem[,] ArrangeItems(int rows, int cols)
			{
				
				// Return array of RadioButtonItem instances that matches
				// the layout of the control:
				SPRadioButtonItem[,] items = new SPRadioButtonItem[cols, rows];
				
				// Fill in the items array:
				int currentItem = 0;
				for (int col = 0; col <= cols - 1; col++)
				{
					for (int row = 0; row <= rows - 1; row++)
					{
						if (currentItem < this._RadioList.Count)
						{
							items[col, row] = this._RadioList[currentItem];
							currentItem++;
						}
					}
				}
				return items;
			}
			
			private void FillTable(SPRadioButtonItem[,] items, int rows, int cols, TableLayoutPanel tbl)
			{
				
				for (int col = 0; col <= cols - 1; col++)
				{
					for (int row = 0; row <= rows - 1; row++)
					{
						SPRadioButtonItem radioItem = items[col, row];
						if (radioItem != null)
						{
							if (! string.IsNullOrEmpty(radioItem.Name))
							{
								RadioButton btn = new RadioButton();
								btn.Name = radioItem.Name;
								btn.Text = radioItem.Text;
								btn.Dock = DockStyle.Fill;
								btn.CheckedChanged += new System.EventHandler(OnCheckedChanged);
								tbl.Controls.Add(btn, col, row);
							}
						}
					}
				}
			}
			
			#endregion
			
		}
		
		public class SPRadioButtonItemCollection : List<SPRadioButtonItem>
		{
			
			
			public SPRadioButtonItem this[string Name]
			{
				get
				{
					for (int cnt = 0; cnt <= this.Count - 1; cnt++)
					{
						if (this[cnt].Name == Name)
						{
							return this[cnt];
						}
					}
					
					return null;
				}
			}
			
		}
		public class SPRadioButtonItem
		{
			
			
			private string _Name = string.Empty;
			private bool _Checked = false;
			private int _ID = - 1;
			private string _Text = string.Empty;
			
			public string Name
			{
				get
				{
					return _Name;
				}
				set
				{
					_Name = value;
				}
			}
			public string Text
			{
				get
				{
					return _Text;
				}
				set
				{
					_Text = value;
				}
			}
			public bool Checked
			{
				get
				{
					return _Checked;
				}
				set
				{
					_Checked = value;
				}
			}
			
			internal SPRadioButtonItem()
			{
				
			}
			internal SPRadioButtonItem(string Name, string Text, bool Checked)
			{
				this.Name = Name;
				this.Text = Text;
				this.Checked = @Checked;
			}
		}
		
		#region Designer Extensions
		[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]public class SPRadioButtonListDesigner : System.Windows.Forms.Design.ControlDesigner
		{
			
			
			private DesignerActionListCollection lists;
			
			//Use pull model to populate smart tag menu.
			public override DesignerActionListCollection ActionLists
			{
				get
				{
					if (lists == null)
					{
						lists = new DesignerActionListCollection();
						lists.Add(new SPRadioButtonListActionList(this.Component));
					}
					return lists;
				}
			}
		}
		
		/////////////////////////////////////////////////////////////////
		//DesignerActionList-derived class defines smart tag entries and
		// resultant actions.
		/////////////////////////////////////////////////////////////////
		public class SPRadioButtonListActionList : System.ComponentModel.Design.DesignerActionList
		{
			
			
			private SPRadioButtonList taskView;
			private DockStyle m_enmDockStyle = DockStyle.None;
			
			private DesignerActionUIService designerActionUISvc = null;
			
			//The constructor associates the control
			//with the smart tag list.
			public SPRadioButtonListActionList(IComponent component) : base(component)
			{
				
				this.taskView = (SPRadioButtonList) component;
				
				// Cache a reference to DesignerActionUIService, so the
				// DesigneractionList can be refreshed.
				this.designerActionUISvc = (DesignerActionUIService) (GetService(typeof(DesignerActionUIService)));
				
			}
			
			//Helper method to retrieve control properties. Use of
			// GetProperties enables undo and menu updates to work properly.
			private PropertyDescriptor GetPropertyByName(string propName)
			{
				PropertyDescriptor prop;
				prop = TypeDescriptor.GetProperties(taskView)[propName];
				if (prop == null)
				{
					throw (new ArgumentException("Matching SPRadioButtonList property not found!", propName));
				}
				else
				{
					return prop;
				}
			}
			
			public DockStyle Dock
			{
				get
				{
					return taskView.Dock;
				}
				set
				{
					GetPropertyByName("Dock").SetValue(taskView, value);
				}
			}
			
			
			//Method that is target of a DesignerActionMethodItem
			public void EditItems()
			{
				//GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
			}
			public void EditColumns()
			{
				//GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
			}
			
			public void EditGroups()
			{
				//GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill)
			}
			public void ParentDock()
			{
				if (Dock == DockStyle.Fill)
				{
					GetPropertyByName("Dock").SetValue(taskView, DockStyle.None);
				}
				else if (Dock == DockStyle.None)
				{
					GetPropertyByName("Dock").SetValue(taskView, DockStyle.Fill);
				}
			}
			
			//Implementation of this virtual method creates smart tag
			// items, associates their targets, and collects into list.
			public override DesignerActionItemCollection GetSortedActionItems()
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection();
				
				//Define static section header entries.
				//items.Add(New DesignerActionHeaderItem("-"))
				items.Add(new DesignerActionHeaderItem(""));
				
				//items.Add(New DesignerActionMethodItem( _
				//Me, "EditItems", _
				//"Edit Items", _
				//" ", _
				//"Opens the Items Collection Editor"))
				
				//items.Add(New DesignerActionMethodItem( _
				//Me, "EditColumns", _
				//"Edit Columns", _
				//" ", _
				//"Opens the Columns Collection Editor"))
				
				//items.Add(New DesignerActionMethodItem( _
				//Me, "EditGroups", _
				//"Edit Groups", _
				//" ", _
				//"Opens the Groups Collection Editor"))
				
				if (Dock == DockStyle.None)
				{
					items.Add(new DesignerActionMethodItem(this, "ParentDock", "Dock in parent Container", "", "Dock in Parent Container"));
				}
				else if (Dock == DockStyle.Fill)
				{
					items.Add(new DesignerActionMethodItem(this, "ParentDock", "Undock from parent container", "", "Undock in Parent Container"));
					
				}
				return items;
			}
			
		}
		
		
		[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]public class SPRadioButtonListItemsEditor : UITypeEditor
		{
			
			
			private IWindowsFormsEditorService editorService;
			
			public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
			{
				if ((context != null) && (context.Instance != null) && (provider != null))
				{
					editorService = (IWindowsFormsEditorService) (provider.GetService(typeof(IWindowsFormsEditorService)));
					
					if (editorService != null)
					{
						SPRadioButtonListEditorUI selectionControl = new SPRadioButtonListEditorUI(((SPRadioButtonItemCollection) value), editorService);
						
						editorService.ShowDialog(selectionControl);
						
						value = selectionControl.RadioItems;
					}
				}
				
				return value;
			}
			
			public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
			{
				if ((context != null) && (context.Instance != null))
				{
					return UITypeEditorEditStyle.Modal;
				}
				return base.GetEditStyle(context);
			}
			
		}
		#endregion
	}
	
}
