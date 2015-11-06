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
	namespace UI
	{
		public partial class SPComboBox : ComboBox
		{
			
			
			private string m_strLookupText = "<New...>";
			private int m_intLookupIndex;
			
			public delegate void PopulateEventHandler(object sender, SPComboBoxEventArgs evt);
			private PopulateEventHandler PopulateEvent;
			
			public event PopulateEventHandler Populate
			{
				add
				{
					PopulateEvent = (PopulateEventHandler) System.Delegate.Combine(PopulateEvent, value);
				}
				remove
				{
					PopulateEvent = (PopulateEventHandler) System.Delegate.Remove(PopulateEvent, value);
				}
			}
			
			public delegate void LookupEventHandler(object sender, SPComboBoxEventArgs evt);
			private LookupEventHandler LookupEvent;
			
			public event LookupEventHandler Lookup
			{
				add
				{
					LookupEvent = (LookupEventHandler) System.Delegate.Combine(LookupEvent, value);
				}
				remove
				{
					LookupEvent = (LookupEventHandler) System.Delegate.Remove(LookupEvent, value);
				}
			}
			
			
			
			public string LookupText
			{
				get
				{
					return m_strLookupText;
				}
				set
				{
					m_strLookupText = value;
				}
			}
			public int LookupIndex
			{
				get
				{
					return m_intLookupIndex;
				}
				set
				{
					m_intLookupIndex = value;
				}
			}
			
			protected override void OnSelectedValueChanged(System.EventArgs e)
			{
				base.OnSelectedValueChanged(e);
				
				if (this.SelectedIndex == LookupIndex)
				{
					if (LookupEvent != null)
						LookupEvent(this, new SPComboBoxEventArgs());
				}
			}
			
			
		}
		
		public class SPComboBoxEventArgs : EventArgs
		{
			
			
			private object m_objData;
			
			public object Data
			{
				get
				{
					return m_objData;
				}
				set
				{
					m_objData = value;
				}
			}
		}
	}
	
	
	
	
}
