using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.ComponentModel;
using System.Collections; 
using System.Drawing;
 
namespace SoftLogik.Win.UI.Controls
{
[Designer(typeof(RadioButtonListDesigner)), 
ToolboxBitmap(typeof(RadioButtonListDesigner)), 
DefaultEvent("SelectedIndexChanged")]
public partial class RadioButtonList
{

	public enum RadioLayoutStyles: int
	{
		Horizontal,
		Vertical,
		Table
	}

	public delegate void SelectedIndexChangedEventHandler(object sender, System.EventArgs e);
	public event SelectedIndexChangedEventHandler SelectedIndexChanged;

	private RadioButtonItemCollection _RadioList = new RadioButtonItemCollection();
	private RadioLayoutStyles _radioLayoutStyle;
	private int _SelectedIndex = -1;
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
		catch (Exception ex)
		{
		}
	}

	protected void OnCheckedChanged(object sender, System.EventArgs e)
	{

	}

#endregion

#region Properties
	[Category("Behavior"), Description("Gets or Sets the Radio Buttons Layout Style")]
	public RadioLayoutStyles LayoutStyle
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
	[Category("Behavior"), Browsable(true), EditorAttribute(typeof(RadioButtonListItemsEditor), typeof(System.Drawing.Design.UITypeEditor))]
	public RadioButtonItemCollection Items
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
		this._RadioList.Add(new RadioButtonItem(Name, Text, Selected));
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

	[Category("Data")]
	public object DataSource
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
				if (! (value is IList || m_oDataSource is IListSource))
				{
					throw (new System.Exception("Invalid DataSource"));
				}
				else
				{
					if (value is IListSource)
					{
						IListSource myListSource = (IListSource)value;
						if (myListSource.ContainsListCollection == true)
						{
							throw (new System.Exception("Invalid DataSource"));
						}
					}
					this.m_oDataSource = value;
					this.m_currencyManager = (CurrencyManager)(this.BindingContext[value]);
					BuildRadioTable();
				}
			}
		}
	} // end of DataSource property

	[Category("Data")]
	public string ValueMember
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
	[Category("Data")]
	public string DisplayMember
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
				PropertyDescriptor pdValueMember = null;
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
				PropertyDescriptor pdDisplayMember = null;
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
				radioTable.ColumnCount = (int)System.Math.Floor((double)this._RadioList.Count / 2);
				radioTable.RowCount = radioTable.ColumnCount;
                break; 
		}

		RadioButtonItem[,] tempItems = ArrangeItems(radioTable.RowCount, radioTable.ColumnCount);
			// Fill in the TableLayoutPanel.
		FillTable(tempItems, radioTable.RowCount, radioTable.ColumnCount, ref this.RadioTableLayout);



	}
	private RadioButtonItem[,] ArrangeItems(int rows, int cols)
	{

		// Return array of RadioButtonItem instances that matches
		// the layout of the control:
		RadioButtonItem[,] items = new RadioButtonItem[cols, rows];

		// Fill in the items array:
		int currentItem = 0;
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of cols for every iteration:
		int tempFor1 = cols;
		for (int col = 0; col < tempFor1; col++)
		{
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of rows for every iteration:
			int tempFor2 = rows;
			for (int row = 0; row < tempFor2; row++)
			{
				if (currentItem < this._RadioList.Count)
				{
					items[col, row] = this._RadioList[currentItem];
					currentItem += 1;
				}
			}
		}
		return items;
	}

	private void FillTable(RadioButtonItem[,] items, int rows, int cols, ref TableLayoutPanel tbl)
	{

//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of cols for every iteration:
		int tempFor1 = cols;
		for (int col = 0; col < tempFor1; col++)
		{
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of rows for every iteration:
			int tempFor2 = rows;
			for (int row = 0; row < tempFor2; row++)
			{
				RadioButtonItem radioItem = items[col, row];
				if (radioItem != null)
				{
					if (! (string.IsNullOrEmpty(radioItem.Name)))
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

public class RadioButtonItemCollection : System.Collections.Generic.List<RadioButtonItem>
{

	public RadioButtonItem this[string Name]
	{
		get
		{
//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of this.Count for every iteration:
			int tempFor1 = this.Count;
			for (int cnt = 0; cnt < tempFor1; cnt++)
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
public class RadioButtonItem
{

	private string _Name = string.Empty;
	private bool _Checked = false;
	private int _ID = -1;
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

	internal RadioButtonItem()
	{

	}
	internal RadioButtonItem(string Name, string Text, bool Checked)
	{
		this.Name = Name;
		this.Text = Text;
		this.Checked = Checked;
	}
}

#region Designer Extensions
[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
public class RadioButtonListDesigner : System.Windows.Forms.Design.ControlDesigner
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
				lists.Add(new RadioButtonListActionList(this.Component));
			}
			return lists;
		}
	}
}

/////////////////////////////////////////////////////////////////
//DesignerActionList-derived class defines smart tag entries and
// resultant actions.
/////////////////////////////////////////////////////////////////
public class RadioButtonListActionList : System.ComponentModel.Design.DesignerActionList
{

	private RadioButtonList taskView;
	private DockStyle m_enmDockStyle = DockStyle.None;

	private DesignerActionUIService designerActionUISvc = null;

	//The constructor associates the control 
	//with the smart tag list.
	public RadioButtonListActionList(IComponent component) : base(component)

	{
		this.taskView = (RadioButtonList)component;

		// Cache a reference to DesignerActionUIService, so the
		// DesigneractionList can be refreshed.
		this.designerActionUISvc = (DesignerActionUIService)(GetService(typeof(DesignerActionUIService)));

	}

	//Helper method to retrieve control properties. Use of 
	// GetProperties enables undo and menu updates to work properly.
	private PropertyDescriptor GetPropertyByName(string propName)
	{
		PropertyDescriptor prop = null;
		prop = TypeDescriptor.GetProperties(taskView)[propName];
		if (prop == null)
		{
			throw new ArgumentException("Matching RadioButtonList property not found!", propName);
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
        Items.Add(new DesignerActionHeaderItem(""));

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
            Items.Add(new DesignerActionMethodItem(this, "ParentDock", "Dock in parent Container", "", "Dock in Parent Container"));
        }
        else if (Dock == DockStyle.Fill)
        {
            Items.Add(new DesignerActionMethodItem(this, "ParentDock", "Undock from parent container", "", "Undock in Parent Container"));

        }
        return items;
    }

}


[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
public class RadioButtonListItemsEditor : UITypeEditor
{

    private IWindowsFormsEditorService editorService;

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        if ((context != null) & (context.Instance != null) & (provider != null))
        {
            editorService = (IWindowsFormsEditorService)(provider.GetService(typeof(IWindowsFormsEditorService)));

            if (editorService != null)
            {
                RadioButtonListEditorUI selectionControl = new RadioButtonListEditorUI((RadioButtonItemCollection)value, editorService);

                editorService.ShowDialog(selectionControl);

                value = selectionControl.RadioItems;
            }
        }

        return value;
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
        if ((context != null) & (context.Instance != null))
        {
            return UITypeEditorEditStyle.Modal;
        }
        return base.GetEditStyle(context);
    }

}
#endregion
}