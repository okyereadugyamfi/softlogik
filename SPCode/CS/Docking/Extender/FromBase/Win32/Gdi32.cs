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
using System.Runtime.InteropServices;
using SoftLogik.Win.UI.Docking.Win32;

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
			
			internal class Gdi32
			{
				
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int flags);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr CreateRectRgnIndirect(ref Win32.RECT rect);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern bool FillRgn(IntPtr hDC, IntPtr hrgn, IntPtr hBrush);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern int GetClipBox(IntPtr hDC, ref Rect rectBox);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr CreateBrushIndirect(ref LOGBRUSH brush);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern bool PatBlt(IntPtr hDC, int x, int y, int width, int height, UInt32 flags);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr DeleteObject(IntPtr hObject);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern bool DeleteDC(IntPtr hDC);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
				[DllImport("gdi32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr CreateCompatibleDC(IntPtr hDC);
			}
		}
	}
	
}
