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


namespace SoftLogik.Win
{
	namespace UI
	{
		/// <summary>
		/// Wrap the TabOrderManager class and supply extendee controls with a custom tab scheme.
		/// </summary>
		[ProvideProperty("TabScheme", typeof(Control)), Description("Wrap the TabOrderManager class and supply extendee controls with a custom tab scheme"), ToolboxBitmap(typeof(TabSchemeProvider), "TabSchemeProvider")]public class TabSchemeProvider : Component, IExtenderProvider
		{
			
			
			#region MEMBER VARIABLES
			
			
			/// <summary>
			/// Hashtable to store the controls that use our extender property.
			/// </summary>
			private Hashtable extendees = new Hashtable();
			
			/// <summary>
			/// The form we're hosted on, which will be calculated by watching the extendees entering the control hierarchy.
			/// </summary>
			private System.Windows.Forms.Form topLevelForm = null;
			
			#endregion
			
			#region PUBLIC PROPERTIES
			#endregion
			
			public TabSchemeProvider()
			{
				InitializeComponent();
			}
			
			private void InitializeComponent()
			{
				
			}
			
			/// <summary>
			/// Get whether or not we're managing a given control.
			/// </summary>
			/// <param name="c"></param>
			/// <returns></returns>
			[DefaultValue(VisualTabOrderManager.TabScheme.None)]public VisualTabOrderManager.TabScheme GetTabScheme(Control c)
			{
				if (! extendees.Contains(c))
				{
					return VisualTabOrderManager.TabScheme.None;
				}
				
				return ((VisualTabOrderManager.TabScheme) (extendees[c]));
			}
			
			/// <summary>
			/// Hook up to the form load event and indicate that we've done so.
			/// </summary>
			private void HookFormLoad()
			{
				if (topLevelForm != null)
				{
					topLevelForm.Load += new System.EventHandler(TopLevelForm_Load);
				}
			}
			
			/// <summary>
			/// Unhook from the form load event and indicate that we need to do so again before applying tab schemes.
			/// </summary>
			private void UnhookFormLoad()
			{
				if (topLevelForm != null)
				{
					topLevelForm.Load -= new System.EventHandler(TopLevelForm_Load);
				}
			}
			
			/// <summary>
			/// Hook up to all of the parent changed events for this control and its ancestors so that we are informed
			/// if and when they are added to the top-level form (whose load event we need).
			/// It's not adequate to look at just the control, because it may have been added to its parent, but the parent
			/// may not be descendent of the form -yet-.
			/// </summary>
			/// <param name="c"></param>
			private void HookParentChangedEvents(Control c)
			{
				while (c != null)
				{
					c.ParentChanged += new System.EventHandler(Extendee_ParentChanged);
					c = c.Parent;
				}
			}
			
			/// <summary>
			/// Set the tab scheme to use on a given control
			/// </summary>
			/// <param name="c"></param>
			public void SetTabScheme(Control c, VisualTabOrderManager.TabScheme val)
			{
				
				if (val != VisualTabOrderManager.TabScheme.None)
				{
					extendees[c] = val;
					
					if (topLevelForm == null)
					{
						if (c.TopLevelControl != null)
						{
							//' We're in luck.
							//' This is the form, or this control knows about it, so take the opportunity to grab it and wire up to its Load event.
							topLevelForm = (Form) c.TopLevelControl;
							HookFormLoad();
						}
						else
						{
							//' Set up to wait around until this control or one of its ancestors is added to the form's control hierarchy.
							HookParentChangedEvents(c);
						}
					}
				}
				else if (extendees.Contains(c))
				{
					extendees.Remove(c);
					
					//' If we no longer have any extendees, we don't need to be wired up to the form load event.
					if (extendees.Count == 0)
					{
						UnhookFormLoad();
					}
				}
			}
			
			#region IExtenderProvider Members
			
			public bool CanExtend(object extendee)
			{
				return ((extendee) is Form|| (extendee) is Panel|| (extendee) is GroupBox|| (extendee) is UserControl);
			}
			
			#endregion
			
			public void TopLevelForm_Load(object sender, EventArgs e)
			{
				Form f = (Form) sender;
				VisualTabOrderManager tom = new VisualTabOrderManager(f);
				
				//// Add an override for everything with a tab scheme set EXCEPT for the form, which
				//// serves as the root of the whole process.
				VisualTabOrderManager.TabScheme formScheme = VisualTabOrderManager.TabScheme.None;
				IDictionaryEnumerator extendeeEnumerator = extendees.GetEnumerator();
				while (extendeeEnumerator.MoveNext())
				{
					Control c = (Control) extendeeEnumerator.Key;
					VisualTabOrderManager.TabScheme scheme = (VisualTabOrderManager.TabScheme) extendeeEnumerator.Value;
					
					if (c == f)
					{
						formScheme = scheme;
					}
					else
					{
						tom.SetSchemeForControl(c, scheme);
					}
				}
				
				tom.SetTabOrder(formScheme);
			}
			
			/// <summary>
			/// We track when each extendee's parent is changed, and also when their parents are changed, until
			/// SOMEBODY finally changes their parent to the form, at which point we can hook the load to apply
			/// the tab schemes.
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void Extendee_ParentChanged(object sender, EventArgs e)
			{
				if (topLevelForm != null)
				{
					//// We've already found the form and attached a load event handler, so there's nothing left to do.
					return;
				}
				
				Control c = (Control) sender;
				
				if (c.TopLevelControl != null&& c.TopLevelControl is Form)
				{
					//' We found the form, so we're done.
					topLevelForm = (Form) c.TopLevelControl;
					HookFormLoad();
				}
			}
		}
		
	}
	
}
