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
using System.Windows.Forms.VisualStyles;


namespace SoftLogik.Win. UI
{
	public class VisualThemedColors
	{
		
		
		#region     Variables and Constants
		
		private const string NormalColor = "NormalColor";
		private const string HomeStead = "HomeStead";
		private const string Metallic = "Metallic";
		private const string NoTheme = "NoTheme";
		
		private static Color[] _toolBorder;
		#endregion
		
		#region     Properties
		
		public static int CurrentThemeIndex
		{
			get
			{
				return VisualThemedColors.GetCurrentThemeIndex();
			}
		}
		
		public static string CurrentThemeName
		{
			get
			{
				return VisualThemedColors.GetCurrentThemeName();
			}
		}
		
		public static Color ToolBorder
		{
			get
			{
				return VisualThemedColors._toolBorder[VisualThemedColors.CurrentThemeIndex];
			}
		}
		
		#endregion
		
		#region     Constructors
		
		private VisualThemedColors()
		{
		}
		
		static VisualThemedColors()
		{
			Color[] colorArray1;
			colorArray1 = new Color[] {Color.FromArgb(127, 157, 185), Color.FromArgb(164, 185, 127), Color.FromArgb(165, 172, 178), Color.FromArgb(132, 130, 132)};
			VisualThemedColors._toolBorder = colorArray1;
		}
		
		#endregion
		
		private static int GetCurrentThemeIndex()
		{
			int theme = (int)ColorScheme.NoTheme;
			
			if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
			{
				
				
				switch (VisualStyleInformation.ColorScheme)
				{
					case NormalColor:
						theme = (int)ColorScheme.NormalColor;
						break;
					case HomeStead:
                        theme = (int)ColorScheme.HomeStead;
						break;
					case Metallic:
                        theme = (int)ColorScheme.Metallic;
						break;
					default:
                        theme = (int)ColorScheme.NoTheme;
						break;
				}
			}
			
			return theme;
		}
		
		private static string GetCurrentThemeName()
		{
			string theme = "NoTheme";
			
			if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
			{
				
				theme = VisualStyleInformation.ColorScheme;
			}
			
			return theme;
		}
		
		
		public enum ColorScheme
		{
			NormalColor = 0,
			HomeStead = 1,
			Metallic = 2,
			NoTheme = 3
		}
		
	}
}
