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
using System.Runtime.InteropServices;

namespace SoftLogik.Win.UI.Docking
{
    internal class Gdi32
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int flags);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr CreateRectRgnIndirect(ref Win32.RECT rect);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static bool FillRgn(IntPtr hDC, IntPtr hrgn, IntPtr hBrush);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static int GetClipBox(IntPtr hDC, ref Win32.RECT rectBox);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static int SelectClipRgn(IntPtr hDC, IntPtr hRgn);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr CreateBrushIndirect(ref Win32.LOGBRUSH brush);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static bool PatBlt(IntPtr hDC, int x, int y, int width, int height, UInt32 flags);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr CreateCompatibleDC(IntPtr hDC);
    }
}
