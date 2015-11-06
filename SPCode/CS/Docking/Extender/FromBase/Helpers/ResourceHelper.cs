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
using System.Resources;

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
			
			internal class ResourceHelper
			{
				
				private static ResourceManager m_resourceManager;
				static ResourceHelper()
				{
					m_resourceManager = new ResourceManager("Strings", typeof(ResourceHelper).Assembly);
				}
				public static Bitmap LoadBitmap(string name)
				{
					Assembly Assembly = typeof(DockPanel).Assembly;
					string fullNamePrefix = "WeifenLuo.WinFormsUI.Resources.";
					return new Bitmap(Assembly.GetManifestResourceStream(fullNamePrefix + name));
				}
				public static Bitmap LoadExtenderBitmap(string name)
				{
					//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
					Bitmap outBitmap = (Bitmap) (Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("SoftLogik.Win." + name)));
					return outBitmap;
				}
				public static string GetString(string name)
				{
					//On Error Resume Next VBConversions Warning: On Error Resume Next not supported in C#
					return m_resourceManager.GetString(name);
				}
			}
		}
	}
	
}
