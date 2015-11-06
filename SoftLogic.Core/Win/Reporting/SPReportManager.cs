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
using SoftLogik.Win.UI;


namespace SoftLogik.Win
{
	namespace Reporting
	{
		public partial class SPReportManager
		{
			
			
			private static SPReportViewer _reportViewer = null;
			private static SPReportSettings _reportSettings = null;
			private static Form _MdiParent = null;
			
			private static SPReportViewer Viewer
			{
				get
				{
					if (_reportViewer == null)
					{
						_reportViewer = new SPReportViewer();
					}
					if (_reportViewer.IsDisposed)
					{
						_reportViewer = new SPReportViewer();
					}
					return _reportViewer;
				}
			}
			public static SPReportSettings Settings
			{
				get
				{
					if (_reportSettings == null)
					{
						_reportSettings = new SPReportSettings();
					}
					if (_reportSettings.IsDisposed)
					{
						_reportSettings = new SPReportSettings();
					}
					return _reportSettings;
				}
			}
			
			
			public static Form MdiParent
			{
				set
				{
					_MdiParent = value;
				}
			}
			
			[Description("Load and Show a Report a specified Report File in the Customized Report Viewer.")]public static void ShowReport(string ReportFile)
			{
				Settings.MdiParent = _MdiParent;
				Settings.ViewerForm = Viewer;
				Settings.Show();
			}
			
			[Description("Load and Print a Report a specified Report File.")]public static void PrintReport(string ReportFile)
			{
				Viewer.MdiParent = _MdiParent;
				Settings.MdiParent = _MdiParent;
				Settings.ViewerForm = Viewer;
			}
			
		}
	}
	
	
}
