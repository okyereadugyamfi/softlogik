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
		namespace Docking
		{
			
			public class DockPaneStripOverride : DockPaneStripVS2003
			{
				
				protected internal DockPaneStripOverride(DockPane pane) : base(pane)
				{
					BackColor = SystemColors.ControlLight;
				}
			}
		}
	}
	
}
