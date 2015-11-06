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
using SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar;

namespace SoftLogik.Win.UI
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
					AppNavigation.OnNavigateBarButtonSelected += new NavigateBar.OnNavigateBarButtonEventHandler(OnNavigateBarButtonSelected);
				}
			}
			
			
			protected virtual void OnNavigateBarButtonSelected(NavigateBarButton tNavigationButton)
			{
				if (NavigationChangedEvent != null)
					NavigationChangedEvent(this, new SPNavigatorFormOptionsChangedEventArgs(tNavigationButton));
			}
			
		}
		
		public class SPNavigatorFormOptionsChangedEventArgs : EventArgs
		{
			
			
			private NavigateBarButton _navButton;
			
			public NavigateBarButton SelectedBar
			{
				get
				{
					return _navButton;
				}
			}
			
			public SPNavigatorFormOptionsChangedEventArgs(NavigateBarButton NavButton)
			{
				_navButton = NavButton;
			}
		}
	}