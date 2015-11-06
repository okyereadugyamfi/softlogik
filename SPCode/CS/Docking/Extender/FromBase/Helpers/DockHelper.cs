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
			
			internal class DockHelper
			{
				
				public static bool IsDockStateAutoHide(DockState dockState)
				{
					if (dockState == dockState.DockLeftAutoHide || dockState == dockState.DockRightAutoHide || dockState == dockState.DockTopAutoHide || dockState == dockState.DockBottomAutoHide)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static bool IsDockStateDocked(DockState dockState)
				{
					return (dockState == dockState.DockLeft || dockState == dockState.DockRight || dockState == dockState.DockTop || dockState == dockState.DockBottom);
				}
				public static bool IsDockBottom(DockState dockState)
				{
					if (dockState == dockState.DockBottom || dockState == dockState.DockBottomAutoHide)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static bool IsDockLeft(DockState dockState)
				{
					if (dockState == dockState.DockLeft || dockState == dockState.DockLeftAutoHide)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static bool IsDockRight(DockState dockState)
				{
					if (dockState == dockState.DockRight || dockState == dockState.DockRightAutoHide)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static bool IsDockTop(DockState dockState)
				{
					if (dockState == dockState.DockTop || dockState == dockState.DockTopAutoHide)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static bool IsDockStateValid(DockState dockState, DockAreas dockableAreas)
				{
					if (((dockableAreas && DockAreas.Float) == 0) && (dockState == dockState.Float))
					{
						return false;
					}
					else if (((dockableAreas && DockAreas.Document) == 0) && (dockState == dockState.Document))
					{
						return false;
					}
					else if (((dockableAreas && DockAreas.DockLeft) == 0) && (dockState == dockState.DockLeft || dockState == dockState.DockLeftAutoHide))
					{
						return false;
					}
					else if (((dockableAreas && DockAreas.DockRight) == 0) && (dockState == dockState.DockRight || dockState == dockState.DockRightAutoHide))
					{
						return false;
					}
					else if (((dockableAreas && DockAreas.DockTop) == 0) && (dockState == dockState.DockTop || dockState == dockState.DockTopAutoHide))
					{
						return false;
					}
					else if (((dockableAreas && DockAreas.DockBottom) == 0) && (dockState == dockState.DockBottom || dockState == dockState.DockBottomAutoHide))
					{
						return false;
					}
					else
					{
						return true;
					}
				}
				public static bool IsDockWindowState(DockState state)
				{
					if (state == DockState.DockTop || state == DockState.DockBottom || state == DockState.DockLeft || state == DockState.DockRight || state == DockState.Document)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static bool IsValidRestoreState(DockState state)
				{
					if (state == DockState.DockLeft || state == DockState.DockRight || state == DockState.DockTop || state == DockState.DockBottom || state == DockState.Document)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				public static DockState ToggleAutoHideState(DockState state)
				{
					if (state == DockState.DockLeft)
					{
						return DockState.DockLeftAutoHide;
					}
					else if (state == DockState.DockRight)
					{
						return DockState.DockRightAutoHide;
					}
					else if (state == DockState.DockTop)
					{
						return DockState.DockTopAutoHide;
					}
					else if (state == DockState.DockBottom)
					{
						return DockState.DockBottomAutoHide;
					}
					else if (state == DockState.DockLeftAutoHide)
					{
						return DockState.DockLeft;
					}
					else if (state == DockState.DockRightAutoHide)
					{
						return DockState.DockRight;
					}
					else if (state == DockState.DockTopAutoHide)
					{
						return DockState.DockTop;
					}
					else if (state == DockState.DockBottomAutoHide)
					{
						return DockState.DockBottom;
					}
					else
					{
						return state;
					}
				}
			}
		}
	}
	
}
