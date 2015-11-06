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
		public partial class NavigatorForm
		{
			public NavigatorForm()
			{
				InitializeComponent();
			}
			
			public delegate void NavigationChangedEventHandler(object sender, SPNavigatorFormOptionsChangedEventArgs e);
			private NavigationChangedEventHandler NavigationChangedEvent;
			
			public event NavigationChangedEventHandler NavigationChanged
			{
				add
				{
					NavigationChangedEvent = (NavigationChangedEventHandler) System.Delegate.Combine(NavigationChangedEvent, value);
				}
				remove
				{
					NavigationChangedEvent = (NavigationChangedEventHandler) System.Delegate.Remove(NavigationChangedEvent, value);
				}
			}
			
			
			protected override void OnLoad(System.EventArgs e)
			{
				base.OnLoad(e);
				if (! DesignMode)
				{
					this.DockState = WeifenLuo.WinFormsUI.DockState.DockLeft;
					AppNavigation.OnNavigateBarButtonSelected += new MT.Common.Controls.OutlookStyleNavigateBar.NavigateBar.OnNavigateBarButtonEventHandler(OnNavigateBarButtonSelected);
				}
			}
			
			
			protected virtual void OnNavigateBarButtonSelected(MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton tNavigationButton)
			{
				if (NavigationChangedEvent != null)
					NavigationChangedEvent(this, new SPNavigatorFormOptionsChangedEventArgs(tNavigationButton));
			}
			
		}
		
		public class SPNavigatorFormOptionsChangedEventArgs : EventArgs
		{
			
			
			private MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton _navButton;
			
			public MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton SelectedBar
			{
				get
				{
					return _navButton;
				}
			}
			
			public SPNavigatorFormOptionsChangedEventArgs(MT.Common.Controls.OutlookStyleNavigateBar.NavigateBarButton NavButton)
			{
				_navButton = NavButton;
			}
		}
	}
	
}
