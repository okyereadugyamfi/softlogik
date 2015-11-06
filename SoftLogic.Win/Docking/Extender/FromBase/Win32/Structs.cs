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
namespace SoftLogik.Win.UI.Controls.Docking.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MSG
    {
        public IntPtr hwnd;
        public int message;
        public IntPtr wParam;
        public IntPtr lParam;
        public int time;
        public int pt_x;
        public int pt_y;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public int fErase;
        public Rectangle rcPaint;
        public int fRestore;
        public int fIncUpdate;
        public int Reserved1;
        public int Reserved2;
        public int Reserved3;
        public int Reserved4;
        public int Reserved5;
        public int Reserved6;
        public int Reserved7;
        public int Reserved8;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public override string ToString()
        {
            return "{left=" + left.ToString() + ", " + "top=" + top.ToString() + ", " + "right=" + right.ToString() + ", " + "bottom=" + bottom.ToString() + "}";
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int x;
        public int y;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct SIZE
    {
        public int cx;
        public int cy;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct TRACKMOUSEEVENTS
    {
        public const UInt32 TME_HOVER = 1;
        public const UInt32 TME_LEAVE = 2;
        public const UInt32 TME_NONCLIENT = 16;
        public const UInt32 TME_QUERY = 1073741824;
        public const UInt32 TME_CANCEL = 2147483648;
        public const UInt32 HOVER_DEFAULT = 4294967295;
        private UInt32 cbSize;
        private UInt32 dwFlags;
        private IntPtr hWnd;
        private UInt32 dwHoverTime;
        public TRACKMOUSEEVENTS(UInt32 dwFlags, IntPtr hWnd, UInt32 dwHoverTime)
        {
            cbSize = 16;
            this.dwFlags = dwFlags;
            this.hWnd = hWnd;
            this.dwHoverTime = dwHoverTime;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct LOGBRUSH
    {
        public UInt32 lbStyle;
        public UInt32 lbColor;
        public UInt32 lbHatch;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct NCCALCSIZE_PARAMS
    {
        public RECT rgrc1;
        public RECT rgrc2;
        public RECT rgrc3;
        private IntPtr lppos;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct CWPRETSTRUCT
    {
        public int lResult;
        public int lParam;
        public int wParam;
        public int message;
        public IntPtr hwnd;
    }
}
