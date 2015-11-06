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
using SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar;


namespace SoftLogik.Win
{
	namespace Reporting
	{
		public partial class SPReportSettings
		{
			public SPReportSettings()
			{
				InitializeComponent();
			}
			
			private NavigateBarButton nvbFilterView;
			private NavigateBarButton nvbGroupingView;
			private SPReportViewer _ViewerForm;
			private SPReportFilterCollection _reportFilters = null;
			private SPReportGroupingCollection _reportGroupings = null;
			private SPReportParameterCollection _reportParameters = null;
			private SPAdvancedSearchDelegate _AdvancedSearchHandler;
			private SPFilterSetupDelegate _FilterSetupHandler;
			
			#region Properties
			protected internal SPReportFilterCollection Filters
			{
				get
				{
					if (_reportFilters == null)
					{
						_reportFilters = new SPReportFilterCollection();
					}
					return _reportFilters;
				}
			}
			protected internal SPReportGroupingCollection Groups
			{
				get
				{
					if (_reportGroupings == null)
					{
						_reportGroupings = new SPReportGroupingCollection();
					}
					return _reportGroupings;
				}
			}
			protected internal SPReportParameterCollection Parameters
			{
				get
				{
					if (_reportParameters == null)
					{
						_reportParameters = new SPReportParameterCollection();
					}
					return _reportParameters;
				}
			}
			public SPAdvancedSearchDelegate AdvancedSearchHandler
			{
				get
				{
					return _AdvancedSearchHandler;
				}
				set
				{
					_AdvancedSearchHandler = value;
				}
			}
			public SPFilterSetupDelegate FilterSetupHandler
			{
				get
				{
					return _FilterSetupHandler;
				}
				set
				{
					_FilterSetupHandler = value;
				}
			}
			
			
			/// <summary>
			/// Handle to the Report Viewer Form to enable Settings Form refresh a Loaded Report.
			/// </summary>
			/// <value></value>
			/// <remarks></remarks>
			[Description("Handle to the Report Viewer Form to enable Settings Form refresh a Loaded Report.")]protected internal SPReportViewer ViewerForm
			{
				set
				{
					_ViewerForm = value;
				}
			}
			#endregion
			
			#region Methods
			public void AddFilter(string DisplayMember, string ValueMember, SPReportFilterFieldTypes @Type)
			{
				Filters.Add(DisplayMember, ValueMember, @Type);
			}
			public void AddGrouping(string DisplayMember, string ValueMember)
			{
				Groups.Add(DisplayMember, ValueMember);
			}
			public void AddParameter(string Name, object Value)
			{
				Parameters.Add(Name, Value);
			}
			#endregion
			
			
			private void InitializeNavBar()
			{
				AppNavigation.CollapsibleScreenWidth = 150;
				AppNavigation.Dock = DockStyle.Fill;
				nvbFilterView = new NavigateBarButton();
				nvbFilterView.RelatedControl = FilterView;
				nvbFilterView.Caption = "Report Filters";
				nvbFilterView.ToolTipText = "Report Filter Options";
                nvbFilterView.Image = global::SoftLogik.Properties.Resources.Clock;
				nvbFilterView.Enabled = true;
				nvbFilterView.Key = "FILTERVIEW";
				
				nvbGroupingView = new NavigateBarButton();
				nvbGroupingView.RelatedControl = null;
				nvbGroupingView.Caption = "Report Grouping";
				nvbGroupingView.ToolTipText = "Report Grouping Options";
				nvbGroupingView.Image = global::SoftLogik.Properties.Resources.Clock;
				nvbGroupingView.Enabled = true;
				nvbGroupingView.Key = "GROUPINGVIEW";
				
				AppNavigation.NavigateBarButtons.Clear();
				AppNavigation.NavigateBarButtons.Add(nvbFilterView);
				AppNavigation.NavigateBarButtons.Add(nvbGroupingView);
				
				AppNavigation.NavigateBarDisplayedButtonCount = 2;
				AppNavigation.Theme = NavigateBarTheme.VS2005Color;
				
			}
			private void InitializeFilters()
			{
				FilterView.Filters = Filters;
				
			}
			
			private void InitializeGrouping()
			{
				
			}
			
			private void SPReportSettings_Load(object sender, System.EventArgs e)
			{
				InitializeFilters();
				InitializeGrouping();
				InitializeNavBar();
				if (this._ViewerForm != null)
				{
					this._ViewerForm.MdiParent = this.MdiParent;
					this._ViewerForm.Show();
				}
				
				this.DockState = WeifenLuo.WinFormsUI.DockState.DockLeft;
				
			}
		}
	}
	
}
