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
		public partial class SPRadioButtonListEditorUI
		{
			
			private SPRadioButtonItemCollection _RadioItems = null;
			
			internal SPRadioButtonListEditorUI(SPRadioButtonItemCollection itemsTarget, IWindowsFormsEditorService editorService)
			{
				
				InitializeComponent();
				
			}
			
			// LightShape is the property for which this control provides
			// a custom user interface in the Properties window.
			public SPRadioButtonItemCollection RadioItems
			{
				
				get
				{
					return this._RadioItems;
				}
				
				set
				{
					if (!(this._RadioItems is value))
					{
						this._RadioItems = value;
					}
				}
			}
		}
	}
	
	
	
}
