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

// *****************************************************************************
//
//  Copyright 2004, Weifen Luo
//  All rights reserved. The software and associated documentation
//  supplied hereunder are the proprietary information of Weifen Luo
//  and are supplied subject to licence terms.
//
//  WinFormsUI Library Version 1.0
// *****************************************************************************
namespace SoftLogik.Win
{
	namespace UI
	{
		namespace Docking
		{
			
			public class Extender
			{
				
				
				public enum Schema
				{
					@Default,
					Override,
					FromBase
				}
				
				private class DockPaneStripOverrideFactory : DockPanelExtender.IDockPaneStripFactory
				{
					
					
					public WeifenLuo.WinFormsUI.DockPaneStripBase CreateDockPaneStrip(WeifenLuo.WinFormsUI.DockPane pane)
					{
						return new DockPaneStripOverride(pane);
					}
				}
				
				private class AutoHideStripOverrideFactory : DockPanelExtender.IAutoHideStripFactory
				{
					
					
					public WeifenLuo.WinFormsUI.AutoHideStripBase CreateAutoHideStrip(WeifenLuo.WinFormsUI.DockPanel panel)
					{
						return new AutoHideStripOverride(panel);
					}
				}
				
				private class DockPaneCaptionFromBaseFactory : DockPanelExtender.IDockPaneCaptionFactory
				{
					
					
					public WeifenLuo.WinFormsUI.DockPaneCaptionBase CreateDockPaneCaption(WeifenLuo.WinFormsUI.DockPane pane)
					{
						return new DockPaneCaptionFromBase(pane);
					}
				}
				
				private class DockPaneTabFromBaseFactory : DockPanelExtender.IDockPaneTabFactory
				{
					
					
					public WeifenLuo.WinFormsUI.DockPaneTab CreateDockPaneTab(WeifenLuo.WinFormsUI.IDockContent content)
					{
						return new DockPaneTabFromBase(content);
					}
				}
				
				private class DockPaneStripFromBaseFactory : DockPanelExtender.IDockPaneStripFactory
				{
					
					
					public WeifenLuo.WinFormsUI.DockPaneStripBase CreateDockPaneStrip(WeifenLuo.WinFormsUI.DockPane pane)
					{
						return new DockPaneStripFromBase(pane);
					}
				}
				
				private class AutoHideTabFromBaseFactory : DockPanelExtender.IAutoHideTabFactory
				{
					
					
					public WeifenLuo.WinFormsUI.AutoHideTab CreateAutoHideTab(WeifenLuo.WinFormsUI.IDockContent content)
					{
						return new AutoHideTabFromBase(content);
					}
				}
				
				private class AutoHideStripFromBaseFactory : DockPanelExtender.IAutoHideStripFactory
				{
					
					
					public WeifenLuo.WinFormsUI.AutoHideStripBase CreateAutoHideStrip(WeifenLuo.WinFormsUI.DockPanel panel)
					{
						return new AutoHideStripFromBase(panel);
					}
				}
				
				public static void SetSchema(DockPanel dockPanel, Extender.Schema schema)
				{
					if (schema == @Extender.Schema.Default)
					{
						dockPanel.Extender.AutoHideTabFactory = null;
						dockPanel.Extender.DockPaneTabFactory = null;
						dockPanel.Extender.AutoHideStripFactory = null;
						dockPanel.Extender.DockPaneCaptionFactory = null;
						dockPanel.Extender.DockPaneStripFactory = null;
					}
					else if (schema == Extender.Schema.Override)
					{
						dockPanel.Extender.AutoHideTabFactory = null;
						dockPanel.Extender.DockPaneTabFactory = null;
						dockPanel.Extender.DockPaneCaptionFactory = null;
						dockPanel.Extender.AutoHideStripFactory = new AutoHideStripOverrideFactory();
						dockPanel.Extender.DockPaneStripFactory = new DockPaneStripOverrideFactory();
					}
					else if (schema == Extender.Schema.FromBase)
					{
						dockPanel.Extender.AutoHideTabFactory = new AutoHideTabFromBaseFactory();
						dockPanel.Extender.DockPaneTabFactory = new DockPaneTabFromBaseFactory();
						dockPanel.Extender.AutoHideStripFactory = new AutoHideStripFromBaseFactory();
						dockPanel.Extender.DockPaneCaptionFactory = new DockPaneCaptionFromBaseFactory();
						dockPanel.Extender.DockPaneStripFactory = new DockPaneStripFromBaseFactory();
					}
				}
				
			}
		}
	}
	
}
