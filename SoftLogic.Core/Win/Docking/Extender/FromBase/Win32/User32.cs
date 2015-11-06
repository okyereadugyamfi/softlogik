// *****************************************************************************
// 
//  Copyright 2004, Weifen Luo
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Weifen Luo
//  and are supplied subject to licence terms.
// 
//  WinFormsUI Library Version 1.0
// *****************************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SoftLogik.Win.UI.Docking
{
	internal class User32
	{
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool AnimateWindow(IntPtr hWnd, UInt32 dwTime, Win32.FlagsAnimateWindow dwFlags);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool DragDetect(IntPtr hWnd, Win32.POINT pt);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr GetSysColorBrush(int index);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool InvalidateRect(IntPtr hWnd, ref Win32.RECT rect, bool erase);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr LoadCursor(IntPtr hInstance, UInt32 cursor);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr SetCursor(IntPtr hCursor);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr GetFocus();
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr SetFocus(IntPtr hWnd);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool ReleaseCapture();
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool WaitMessage();
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool TranslateMessage(ref Win32.MSG msg);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool DispatchMessage(ref Win32.MSG msg);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool PostMessage(IntPtr hWnd, int Msg, UInt32 wParam, UInt32 lParam);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static UInt32 SendMessage(IntPtr hWnd, int Msg, UInt32 wParam, UInt32 lParam);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static UInt32 SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool GetMessage(ref Win32.MSG msg, int hWnd, UInt32 wFilterMin, UInt32 wFilterMax);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool PeekMessage(ref Win32.MSG msg, int hWnd, UInt32 wFilterMin, UInt32 wFilterMax, UInt32 wFlag);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr BeginPaint(IntPtr hWnd, ref Win32.PAINTSTRUCT ps);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool EndPaint(IntPtr hWnd, ref Win32.PAINTSTRUCT ps);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr GetDC(IntPtr hWnd);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static IntPtr GetWindowDC(IntPtr hWnd);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static int ShowWindow(IntPtr hWnd, short cmdShow);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, Win32.FlagsSetWindowPos flags);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Win32.POINT pptDst, ref Win32.SIZE psize, IntPtr hdcSrc, ref Win32.POINT pprSrc, Int32 crKey, ref Win32.BLENDFUNCTION pblend, Int32 dwFlags);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool GetWindowRect(IntPtr hWnd, ref Win32.RECT rect);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool ClientToScreen(IntPtr hWnd, ref Win32.POINT pt);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public extern static bool ScreenToClient(IntPtr hWnd, ref Win32.POINT pt);
		[DllImport("User32.dll", CharSet=CharSet.Auto)]
        public extern static bool TrackMouseEvent(ref Win32.TRACKMOUSEEVENTS tme);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public extern static bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public extern static ushort GetKeyState(int virtKey);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr GetParent(IntPtr hWnd);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public extern static bool DrawFocusRect(IntPtr hWnd, ref Win32.RECT rect);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public extern static bool HideCaret(IntPtr hWnd);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public extern static bool ShowCaret(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool SystemParametersInfo(Win32.SystemParametersInfoActions uAction, UInt32 uParam, ref UInt32 lpvParam, UInt32 fuWinIni);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr WindowFromPoint(Win32.POINT point);
    }
}
