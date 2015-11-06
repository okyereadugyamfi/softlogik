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
		public class FormRecordBindingEventArgs : System.EventArgs
		{
			
			
			private object _DataSource = null;
			private RecordBindingSettings _RecordBindingSettings = new RecordBindingSettings();
			
			
			public object DataSource
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
			public RecordBindingSettings BindingSettings
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
			
			internal FormRecordBindingEventArgs()
			{
			}
		}
		
        public delegate object NewRecordCallback();

        [Description("Represents the internal Form Data Manipulation States.")]
        public class FormRecordStateManager
        {

            [Description("Gets or Sets the Current Form Record Operation Mode")]
            public FormRecordModes CurrentState;
            [Description("Gets or Sets the Showing Data Flag")]
            public bool ShowingData;
            [Description("Gets or Sets the Form Binding Flag.")]
            public bool BindingData;
            [Description("Gets or Sets the Duplication Data Flag.")]
            public bool DuplicatingData;
            [Description("Gets or Sets the NewRecord Data.")]
            public object NewRecordData;
        }

		public class RecordBindingSettings
		{
			public RecordBindingSettings()
			{
				_TreeGroups = new List<DataTreeNodeGroup>();
			}
			
			private List<DataTreeNodeGroup> _TreeGroups;
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
			
			public List<DataTreeNodeGroup> NodeGroups
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
		
		public class RecordNavigateEventArgs : System.EventArgs
		{
			
			
			private RecordNavigateDirections _NavigateDirection;
			private object _PreviousRecord;
            private object _CurrentRecord;
            private bool _Cancel;
			
			public RecordNavigateDirections Direction
			{
				get
				{
					return _NavigateDirection;
				}
			}
			
			public object PreviousRecord
			{
				get
				{
					return _PreviousRecord;
				}
				set
				{
					_PreviousRecord = value;
				}
			}
			public object CurrentRecord
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

            internal RecordNavigateEventArgs(RecordNavigateDirections Direction, ref object LastRecord, ref object CurrentRecord)
			{
				this._PreviousRecord = LastRecord;
				this._CurrentRecord = CurrentRecord;
				this._NavigateDirection = Direction;
			}
		}
		
		public class FormRecordUpdateEventArgs : System.EventArgs
		{
			
			
			private object _DataRow;
			private FormDataStates _DataState;
			
			public object DataRow
			{
				get
				{
					return _DataRow;
				}
			}
			
			[Description("Gets the State the Data Record is currently set to.")]public FormDataStates DataState
			{
				get
				{
					return _DataState;
				}
			}
			
			internal FormRecordUpdateEventArgs(object DataRow, FormDataStates DataState)
			{
				this._DataRow = DataRow;
				this._DataState = DataState;
			}
			
		}
		
		public class FormValidatingEventArgs : EventArgs
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
		
	
		//public delegate DataRowView  NewRecordCallback();
		
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
			internal static void BindControls(System.Windows.Forms.Control.ControlCollection Controls, ref BindingSource DetailBinding, EventHandler OnFieldChanged)
			{
				if (DetailBinding != null)
				{
					foreach (Control ctl in Controls) //go thru all controls
					{
                        if (ctl.Controls.Count == 0 || (ctl.GetType().Name.StartsWith("Krypton") && !ctl.GetType().Name.StartsWith("KryptonPanel")))
						{
							BindInnerControls(ctl, ref DetailBinding, OnFieldChanged);
						}
						else
						{
							BindControls(ctl.Controls, ref DetailBinding, OnFieldChanged);
						}
					}
				}
			}
			internal static void BindInnerControls(Control OuterControl, ref BindingSource DetailBinding, EventHandler OnFieldChanged)
			{

                Control ctl = OuterControl;

                if (ctl.Controls.Count == 0 || (ctl.GetType().Name.StartsWith("Krypton") && !ctl.GetType().Name.StartsWith("KryptonPanel")))
                {
                    if (ctl.Tag != null)
                    {
                        if (!string.IsNullOrEmpty(ctl.Tag.ToString().Trim()))
                        {
                            if (ctl is ListControl)
                            {
                                try
                                {
                                    ctl.DataBindings.Add("SelectedValue", DetailBinding, ctl.Tag.ToString());
                                    ((ListControl)ctl).SelectedValueChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else if (ctl is KryptonComboBox)
                            {
                                try
                                {
                                    ctl.DataBindings.Add("SelectedValue", DetailBinding, ctl.Tag.ToString());
                                    ((KryptonComboBox)ctl).SelectedValueChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
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
                                    ((CheckBox)ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
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
                                    ((KryptonCheckBox)ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else if (ctl is RadioButton)
                            {
                                try
                                {
                                    ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString());
                                    ((RadioButton)ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else if (ctl is KryptonRadioButton)
                            {
                                try
                                {
                                    ctl.DataBindings.Add("Checked", DetailBinding, ctl.Tag.ToString());
                                    ((KryptonRadioButton)ctl).CheckedChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
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
                            else if (ctl is KryptonTextBox)
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
                            else if (ctl is KryptonNumericUpDown)
                            {
                                try
                                {
                                    Binding textBinding = new Binding("Value", DetailBinding, ctl.Tag.ToString());
                                    ctl.DataBindings.Add(textBinding);
                                    ((KryptonNumericUpDown)ctl).ValueChanged += new System.EventHandler(OnFieldChanged); //Add Handler to capture field data changes
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
                    foreach (Control parentCtl in ctl.Controls) //go thru all controls
                    {
                        BindInnerControls(parentCtl, ref DetailBinding, OnFieldChanged);
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
							e.Value = global::SoftLogik.Properties.Resources.NoImage;
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
