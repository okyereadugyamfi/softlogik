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
			
			internal class AutoHideTabFromBase : AutoHideTab
			{
				
				internal AutoHideTabFromBase(IDockContent content) : base(content)
				{
				}
				private int m_tabX = 0;
				protected internal int TabX
				{
					get
					{
						return m_tabX;
					}
					set
					{
						m_tabX = value;
					}
				}
				private int m_tabWidth = 0;
				protected internal int TabWidth
				{
					get
					{
						return m_tabWidth;
					}
					set
					{
						m_tabWidth = value;
					}
				}
			}
		}
	}
	
}
