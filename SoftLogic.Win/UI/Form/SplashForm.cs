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
using System.Reflection;

namespace SoftLogik.Win.UI
	{
		public sealed partial class SplashForm
		{
			public SplashForm()
			{
				InitializeComponent();
			}
			
			private Image _SplashImage;
			
			public Image SplashImage
			{
				set
				{
					_SplashImage = value;
				}
			}
			//TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
			//  of the Project Designer ("Properties" under the "Project" menu).
			
			
			protected override void OnLoad(System.EventArgs e)
			{
				base.OnLoad(e);
				//Set up the dialog text at runtime according to the application's assembly information.
				
				//Application title
                if (AssemblyTitle != "")
				{
                    ApplicationTitle.Text = AssemblyTitle; 
				}
				else
				{
					//If the application title is missing, use the application name, without the extension
					ApplicationTitle.Text = AssemblyProduct;
				}

                Version.Text = String.Format("Version {0} {0}", AssemblyVersion);
				
				//Copyright info
				Copyright.Text = AssemblyCopyright;
			}
			protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
			{
				if (_SplashImage != null)
				{
					e.Graphics.DrawImage(_SplashImage, new Rectangle(0, 0, this.Width, this.Height));
				}
				else
				{
					base.OnPaintBackground(e);
				}
			}

            #region Assembly Attribute Accessors

            public string AssemblyTitle
            {
                get
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
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

            public string AssemblyVersion
            {
                get
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
            }

            public string AssemblyDescription
            {
                get
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                    if (attributes.Length == 0)
                    {
                        return "";
                    }
                    return ((AssemblyDescriptionAttribute)attributes[0]).Description;
                }
            }

            public string AssemblyProduct
            {
                get
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                    if (attributes.Length == 0)
                    {
                        return "";
                    }
                    return ((AssemblyProductAttribute)attributes[0]).Product;
                }
            }

            public string AssemblyCopyright
            {
                get
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                    if (attributes.Length == 0)
                    {
                        return "";
                    }
                    return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                }
            }

            public string AssemblyCompany
            {
                get
                {
                    object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                    if (attributes.Length == 0)
                    {
                        return "";
                    }
                    return ((AssemblyCompanyAttribute)attributes[0]).Company;
                }
            }
            #endregion

		}
	}
