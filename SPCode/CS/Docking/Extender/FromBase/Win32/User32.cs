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
			
			internal class User32
			{
				
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool AnimateWindow(IntPtr hWnd, UInt32 dwTime, SoftLogik.Win.UI.Docking.Win32.FlagsAnimateWindow dwFlags);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool DragDetect(IntPtr hWnd, UI.Docking.Win32.POINT pt);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr GetSysColorBrush(int index);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool InvalidateRect(IntPtr hWnd, ref RECT rect, bool @erase);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr LoadCursor(IntPtr hInstance, UInt32 cursor);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr SetCursor(IntPtr hCursor);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr GetFocus();
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr SetFocus(IntPtr hWnd);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool ReleaseCapture();
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool WaitMessage();
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool TranslateMessage(ref MSG msg);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool DispatchMessage(ref MSG msg);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool PostMessage(IntPtr hWnd, int Msg, UInt32 wParam, UInt32 lParam);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern UInt32 SendMessage(IntPtr hWnd, int Msg, UInt32 wParam, UInt32 lParam);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern UInt32 SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool GetMessage(ref MSG msg, int hWnd, UInt32 wFilterMin, UInt32 wFilterMax);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool PeekMessage(ref MSG msg, int hWnd, UInt32 wFilterMin, UInt32 wFilterMax, UInt32 wFlag);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr GetDC(IntPtr hWnd);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr GetWindowDC(IntPtr hWnd);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern int ShowWindow(IntPtr hWnd, short cmdShow);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, SoftLogik.Win.UI.Docking.Win32.FlagsSetWindowPos flags);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref UI.Docking.Win32.POINT pptDst, ref UI.Docking.Win32.SIZE psize, IntPtr hdcSrc, ref UI.Docking.Win32.POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool ClientToScreen(IntPtr hWnd, ref UI.Docking.Win32.POINT pt);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool ScreenToClient(IntPtr hWnd, ref UI.Docking.Win32.POINT pt);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern UInt16 GetKeyState(int virtKey);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr GetParent(IntPtr hWnd);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool DrawFocusRect(IntPtr hWnd, ref RECT rect);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool HideCaret(IntPtr hWnd);
				[DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern bool ShowCaret(IntPtr hWnd);
				[DllImport("user32.dll", CharSet = CharSet.Auto)]public static  extern bool SystemParametersInfo(SoftLogik.Win.UI.Docking.Win32.SystemParametersInfoActions uAction, UInt32 uParam, ref UInt32 lpvParam, UInt32 fuWinIni);
				[DllImport("user32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr WindowFromPoint(UI.Docking.Win32.POINT point);
			}
		}
	}
	
}
