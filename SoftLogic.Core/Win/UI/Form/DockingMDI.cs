using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;
using System.Reflection;


namespace SoftLogik.Win.UI
	{
		public partial class DockingMDI
		{
			public DockingMDI()
			{
                //oDefaultRenderer = new ToolStripProfessionalRenderer(new PropertyGridEx.CustomColorScheme());
                oDefaultRenderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
				
				InitializeComponent();
			}
			private ReloadContent sourceReloadContentFunc;
			private bool m_boolCanExit = false;
			protected ToolStripProfessionalRenderer oDefaultRenderer;
			
			protected override void OnLoad(System.EventArgs e)
			{
				ToolStripManager.Renderer = oDefaultRenderer;
				if (! DesignMode)
				{
					string configFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
					
					// Set DockPanel properties
					DockPanel.ActiveAutoHideContent = null;
					DockPanel.Parent = this;
					Docking.Extender.SetSchema(DockPanel, SoftLogik.Win.UI.Docking.Extender.Schema.FromBase);
					
					DockPanel.SuspendLayout(true);
					if (System.IO.File.Exists(configFile))
					{
						try
						{
							DockPanel.LoadFromXml(configFile, new WeifenLuo.WinFormsUI.DeserializeDockContent(prReloadContent));
						}
						catch (Exception)
						{
						}
						
					}
					DockPanel.ResumeLayout(true, true);
					
					this.Text = AssemblyTitle;
				}
				base.OnLoad(e);
			}

            public string AssemblyTitle
            {
                get
                {
                    object[] attributes = Assembly.GetAssembly(this.GetType()).GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                    if (attributes.Length > 0)
                    {
                        AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                        if (titleAttribute.Title != "")
                        {
                            return titleAttribute.Title;
                        }
                    }
                    return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
                }
            }

			public ReloadContent ReloadContentFunction
			{
				get
				{
					return sourceReloadContentFunc;
				}
				set
				{
					sourceReloadContentFunc = value;
				}
			}
			
			private IDockContent prReloadContent(string persistString)
			{
				if (ReloadContentFunction != null)
				{
					return ReloadContentFunction.Invoke(persistString);
				}
				else
				{
					return null;
				}
			}
			protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
			{
				//MyBase.OnFormClosing(e)
				//If Not e.Cancel Then
				if (! m_boolCanExit)
				{
					if (!(MessageBox.Show("Are you sure, you want to exit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes))
					{
						e.Cancel = true;
					}
					else
					{
						string configFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
						DockPanel.SaveAsXml(configFile);
						
						
						while (DockPanel.Contents.Count > 0)
						{
							DockContent dc = (DockContent) (DockPanel.Contents[0]);
                            if (dc.Name != this.Name)
							{
                                if(dc is RecordForm)
                                {
                                    ((RecordForm)dc).AlreadyExiting = true;
                                }
                                
								dc.Close();
							}
						}
					}
				}
				//End If
			}
			
			public delegate IDockContent  ReloadContent(string persistString);
			
		}
	}
