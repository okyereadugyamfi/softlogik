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
				if ((new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.Title != "")
				{
					ApplicationTitle.Text = (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.Title;
				}
				else
				{
					//If the application title is missing, use the application name, without the extension
					ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension((new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.AssemblyName);
				}
				
				//Format the version information using the text set into the Version control at design time as the
				//  formatting string.  This allows for effective localization if desired.
				//  Build and revision information could be included by using the following code and changing the
				//  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
				//  String.Format() in Help for more information.
				//
				//    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
				
				Version.Text = System.String.Format(Version.Text, (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.Version.Major, (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.Version.Minor);
				
				//Copyright info
				Copyright.Text = (new Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase()).Info.Copyright;
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
		}
	}
	
	
}
