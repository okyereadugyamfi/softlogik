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
using System.IO;
using System.Drawing.Imaging;
using System.ComponentModel;
using SoftLogik.Win.UI;
using ComponentFactory.Krypton.Toolkit;


namespace SoftLogik.Win
{
	namespace UI
	{
		public class SPFormRecordBindingEventArgs : System.EventArgs
		{
			
			
			private DataTable _DataSource = null;
			private SPRecordBindingSettings _RecordBindingSettings = new SPRecordBindingSettings();
			
			
			public DataTable DataSource
			{
				get
				{
					return _DataSource;
				}
				set
				{
					_DataSource = value;
				}
			}
			public SPRecordBindingSettings BindingSettings
			{
				get
				{
					return _RecordBindingSettings;
				}
				set
				{
					_RecordBindingSettings = value;
				}
			}
			
			internal SPFormRecordBindingEventArgs()
			{
			}
		}
		
		
		public class SPRecordBindingSettings
		{
			public SPRecordBindingSettings()
			{
				_TreeGroups = new List<SPTreeNodeGroup>();
				
			}
			
			private List<SPTreeNodeGroup> _TreeGroups;
			private NewRecordCallback _NewRecordProc = null;
			private string _DisplayMember = string.Empty;
			private string _ValueMember = string.Empty;
			
			public string DisplayMember
			{
				get
				{
					return _DisplayMember;
				}
				set
				{
					_DisplayMember = value;
				}
			}
			public string ValueMember
			{
				get
				{
					return _ValueMember;
				}
				set
				{
					_ValueMember = value;
				}
			}
			
			public List<SPTreeNodeGroup> NodeGroups
			{
				get
				{
					return _TreeGroups;
				}
			}
			public NewRecordCallback NewRecordProc
			{
				get
				{
					return _NewRecordProc;
				}
				set
				{
					_NewRecordProc = value;
				}
			}
		}
		
		public class SPFormNavigateEventArgs : System.EventArgs
		{
			
			
			private SPRecordNavigateDirections _NavigateDirection;
			private DataRow _LastRecord;
			private DataRow _CurrentRecord;
			
			public SPRecordNavigateDirections Direction
			{
				get
				{
					return _NavigateDirection;
				}
			}
			
			public DataRow LastRecord
			{
				get
				{
					return _LastRecord;
				}
				set
				{
					_LastRecord = value;
				}
			}
			public DataRow CurrentRecord
			{
				get
				{
					return _CurrentRecord;
				}
				set
				{
					_CurrentRecord = value;
				}
			}
			
			internal SPFormNavigateEventArgs(SPRecordNavigateDirections navDirection)
			{
				_NavigateDirection = navDirection;
			}
			internal SPFormNavigateEventArgs(SPRecordNavigateDirections navDirection, DataRow LastRecord, DataRow CurrentRecord)
			{
				this._LastRecord = LastRecord;
				this._CurrentRecord = CurrentRecord;
				_NavigateDirection = navDirection;
			}
		}
		
		public class SPFormRecordUpdateEventArgs : System.EventArgs
		{
			
			
			private DataRow _DataRow;
			private SPFormDataStates _DataState;
			
			public DataRow DataRow
			{
				get
				{
					return _DataRow;
				}
			}
			
			[Description("Gets the State the Data Record is currently set to.")]public SPFormDataStates DataState
			{
				get
				{
					return _DataState;
				}
			}
			
			internal SPFormRecordUpdateEventArgs(DataRow DataRow, SPFormDataStates DataState)
			{
				this._DataRow = DataRow;
				this._DataState = DataState;
			}
			
		}
		
		public class SPFormValidatingEventArgs : EventArgs
		{
			
			
			
		}
		
		public class SPValidationItemCollection : List<SPValidationItem>
		{
			
			
		}
		
		public class SPValidationItem
		{
			
			private string _Name;
			private SPValidationItemCommands _Command;
			private string _ControlName;
			
		}
		
		[Description("Represents the internal Form Data Manipulation States.")]public class SPFormRecordStateManager
		{
			
			[Description("Gets or Sets the Current Form Record Operation Mode")]public SPFormRecordModes CurrentState;
			[Description("Gets or Sets the Showing Data Flag")]public bool ShowingData;
			[Description("Gets or Sets the Form Binding Flag.")]public bool BindingData;
			[Description("Gets or Sets the Duplication Data Flag.")]public bool DuplicatingData;
			[Description("Gets or Sets the NewRecord Data.")]public DataRow NewRecordData;
		}
		
		public delegate DataRowView  NewRecordCallback();
		
		public class SPMasterFormManager
		{
			
			
			private static SPMasterFormItemCollection _List = new SPMasterFormItemCollection();
			
			public static MasterForm CreateMaster(string TypeID)
			{
				if (_List.Contains(TypeID) == false)
				{
					MasterForm newForm = new MasterForm();
					newForm.TypeID = TypeID;
					_List.Add(newForm);
					return newForm;
				}
				else
				{
					return _List[TypeID];
				}
			}
		}
		
		public class SPMasterFormItemCollection : List<MasterForm>
		{
			
			
			public MasterForm this[string TypeID]
			{
				get
				{
					foreach (MasterForm frm in this)
					{
						if (frm.TypeID == TypeID)
						{
							return frm;
						}
					}
					
					return null;
				}
			}
			public bool Contains(string TypeID)
			{
				foreach (MasterForm frm in this)
				{
					if (frm.TypeID == TypeID)
					{
						return true;
					}
				}
				
				return false;
			}
		}
		
		sealed class SPFormSupport
		{
			internal static void BindControls(System.Windows.Forms.Control.ControlCollection Controls, ref BindingSource DetailBinding, ref SPFormRecordStateManager RecordState, EventHandler OnFieldChanged)
			{
				if (DetailBinding != null)
				{
					RecordState.ShowingData = true;
					foreach (Control ctl in Controls) //go thru all controls
					{
						if (ctl.Controls.Count == 0 || ctl.GetType().Name.StartsWith("Krypton"))
						{
							BindInnerControls(ctl, ref DetailBinding, OnFieldChanged);
						}
						else
						{
							BindControls(ctl.Controls, ref DetailBinding, ref RecordState, OnFieldChanged);
						}
					}
					RecordState.ShowingData = false;
				}
			}
			internal static void BindInnerControls(Control OuterControl, ref BindingSource DetailBinding, EventHandler OnFieldChanged)
			{
				foreach (Control ctl in OuterControl.Controls)
				{
					if (ctl.Controls.Count == 0 || ctl.GetType().Name.StartsWith("Krypton"))
					{
						if (ctl.Tag != null)
						{
							if (! string.IsNullOrEmpty(ctl.Tag.ToString().Trim()))
							{
								if (ctl is ListControl)
								{
									try
									{
										ctl.DataBindings.Add("SelectedValue", DetailBinding, ctl.Tag.ToString());
										((ListControl) ctl).SelectedValueChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
								else if ((ctl is ComboBox) || (ctl is KryptonComboBox))
								{
									try
									{
										ctl.DataBindings.Add("SelectedValue", DetailBinding, ctl.Tag.ToString());
										((ComboBox) ctl).SelectedValueChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
								else if (ctl is CheckBox)
								{
									try
									{
										ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString());
										((CheckBox) ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
								else if (ctl is KryptonCheckBox)
								{
									try
									{
										ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString());
										((KryptonCheckBox) ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
								else if ((ctl is RadioButton) || (ctl is KryptonRadioButton))
								{
									try
									{
										ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString());
										((RadioButton) ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
								else if (ctl is PictureBox)
								{
									try
									{
										Binding imageBinding = new Binding("Image", DetailBinding, ctl.Tag.ToString());
										imageBinding.Parse += new System.Windows.Forms.ConvertEventHandler(OnParseImage);
										imageBinding.Format += new System.Windows.Forms.ConvertEventHandler(OnFormatImage);
										
										ctl.DataBindings.Add(imageBinding);
									}
									catch (Exception)
									{
									}
								}
								else if (ctl is TabPage)
								{
									//do nothing
								}
								else if (ctl is ComponentFactory.Krypton.Toolkit.KryptonTextBox|| ctl is ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown)
								{
									try
									{
										Binding textBinding = new Binding("Text", DetailBinding, ctl.Tag.ToString());
										ctl.DataBindings.Add(textBinding);
										ctl.TextChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
								else
								{
									try
									{
										Binding textBinding = new Binding("Text", DetailBinding, ctl.Tag.ToString());
										textBinding.Parse += new System.Windows.Forms.ConvertEventHandler(OnParseText);
										textBinding.Format += new System.Windows.Forms.ConvertEventHandler(OnFormatText);
										
										ctl.DataBindings.Add(textBinding);
										ctl.TextChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
									}
									catch (Exception)
									{
									}
								}
							}
						}
					}
					else
					{
						BindInnerControls(ctl, ref DetailBinding, OnFieldChanged);
					}
				}
			}
			
			
			private static void OnParseImage(object sender, ConvertEventArgs e)
			{
				try
				{
					Image imageSource = (Image) e.Value;
					MemoryStream imageStream = new MemoryStream();
					imageSource.Save(imageStream, ImageFormat.Jpeg);
					e.Value = imageStream.ToArray();
				}
				catch (Exception)
				{
				}
			}
			private static void OnFormatImage(object sender, ConvertEventArgs e)
			{
				if (e.DesiredType == typeof(Image))
				{
					try
					{
						if (e.Value == DBNull.Value)
						{
							e.Value = global::My.Resources.NoImage;
						}
						else
						{
							e.Value = Image.FromStream(new MemoryStream((byte[]) e.Value));
						}
					}
					catch (Exception)
					{
					}
					
				}
			}
			private static void OnParseText(object sender, ConvertEventArgs e)
			{
				
			}
			private static void OnFormatText(object sender, ConvertEventArgs e)
			{
				
			}
			
		}
	}
	
	
}
