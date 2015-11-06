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
using System.ComponentModel;

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
			
			[ToolboxItem(false)]public class AutoHideStripFromBase : AutoHideStripBase
			{
				
				private const int _ImageHeight = 16;
				private const int _ImageWidth = 16;
				private const int _ImageGapTop = 2;
				private const int _ImageGapLeft = 4;
				private const int _ImageGapRight = 4;
				private const int _ImageGapBottom = 2;
				private const int _TextGapLeft = 4;
				private const int _TextGapRight = 10;
				private const int _TabGapTop = 3;
				private const int _TabGapLeft = 2;
				private const int _TabGapBetween = 10;
				private static StringFormat _stringFormatTabHorizontal;
				private static StringFormat _stringFormatTabVertical;
				private static Matrix _matrixIdentity;
				private static DockState[] _dockStates;
				#region Customizable Properties
				protected virtual StringFormat StringFormatTabHorizontal
				{
					get
					{
						return _stringFormatTabHorizontal;
					}
				}
				protected virtual StringFormat StringFormatTabVertical
				{
					get
					{
						return _stringFormatTabVertical;
					}
				}
				protected virtual int ImageHeight
				{
					get
					{
						return _ImageHeight;
					}
				}
				protected virtual int ImageWidth
				{
					get
					{
						return _ImageWidth;
					}
				}
				protected virtual int ImageGapTop
				{
					get
					{
						return _ImageGapTop;
					}
				}
				protected virtual int ImageGapLeft
				{
					get
					{
						return _ImageGapLeft;
					}
				}
				protected virtual int ImageGapRight
				{
					get
					{
						return _ImageGapRight;
					}
				}
				protected virtual int ImageGapBottom
				{
					get
					{
						return _ImageGapBottom;
					}
				}
				protected virtual int TextGapLeft
				{
					get
					{
						return _TextGapLeft;
					}
				}
				protected virtual int TextGapRight
				{
					get
					{
						return _TextGapRight;
					}
				}
				protected virtual int TabGapTop
				{
					get
					{
						return _TabGapTop;
					}
				}
				protected virtual int TabGapLeft
				{
					get
					{
						return _TabGapLeft;
					}
				}
				protected virtual int TabGapBetween
				{
					get
					{
						return _TabGapBetween;
					}
				}
				protected virtual void BeginDrawTab()
				{
				}
				protected virtual void EndDrawTab()
				{
				}
				protected virtual Brush BrushTabBackGround
				{
					get
					{
						return SystemBrushes.Control;
					}
				}
				protected virtual Pen PenTabBorder
				{
					get
					{
						return SystemPens.GrayText;
					}
				}
				protected virtual Brush BrushTabText
				{
					get
					{
						return SystemBrushes.FromSystemColor(SystemColors.ControlDarkDark);
					}
				}
				#endregion
				private Matrix MatrixIdentity
				{
					get
					{
						return _matrixIdentity;
					}
				}
				private DockState[] DockStates
				{
					get
					{
						return _dockStates;
					}
				}
				static AutoHideStripFromBase()
				{
					_stringFormatTabHorizontal = new StringFormat();
					_stringFormatTabHorizontal.Alignment = StringAlignment.Near;
					_stringFormatTabHorizontal.LineAlignment = StringAlignment.Center;
					_stringFormatTabHorizontal.FormatFlags = StringFormatFlags.NoWrap;
					_stringFormatTabVertical = new StringFormat();
					_stringFormatTabVertical.Alignment = StringAlignment.Near;
					_stringFormatTabVertical.LineAlignment = StringAlignment.Center;
					_stringFormatTabVertical.FormatFlags = StringFormatFlags.NoWrap || StringFormatFlags.DirectionVertical;
					_matrixIdentity = new Matrix();
					_dockStates = new DockState[5];
					_dockStates[0] = DockState.DockLeftAutoHide;
					_dockStates[1] = DockState.DockRightAutoHide;
					_dockStates[2] = DockState.DockTopAutoHide;
					_dockStates[3] = DockState.DockBottomAutoHide;
				}
				protected internal AutoHideStripFromBase(DockPanel panel) : base(panel)
				{
					SetStyle(ControlStyles.ResizeRedraw, true);
					SetStyle(ControlStyles.UserPaint, true);
					SetStyle(ControlStyles.AllPaintingInWmPaint, true);
					SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
					BackColor = Color.WhiteSmoke;
				}
				protected override void OnPaint(PaintEventArgs e)
				{
					Graphics g = e.Graphics;
					using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.Navy, Color.WhiteSmoke, LinearGradientMode.BackwardDiagonal))
					{
						g.FillRectangle(brush, ClientRectangle);
					}
					
					DrawTabStrip(g);
				}
				protected override void OnLayout(LayoutEventArgs levent)
				{
					CalculateTabs();
					base.OnLayout(levent);
				}
				private void DrawTabStrip(Graphics g)
				{
					DrawTabStrip(g, DockState.DockTopAutoHide);
					DrawTabStrip(g, DockState.DockBottomAutoHide);
					DrawTabStrip(g, DockState.DockLeftAutoHide);
					DrawTabStrip(g, DockState.DockRightAutoHide);
				}
				private void DrawTabStrip(Graphics g, DockState dockState)
				{
					Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
					if (rectTabStrip.IsEmpty)
					{
						return;
					}
					Matrix matrixIdentity = g.Transform;
					if (dockState == dockState.DockLeftAutoHide || dockState == dockState.DockRightAutoHide)
					{
						Matrix matrixRotated = new Matrix();
						matrixRotated.RotateAt(90, new PointF((rectTabStrip.X)+ (rectTabStrip.Height)/ 2, (rectTabStrip.Y)+ (rectTabStrip.Height)/ 2));
						g.Transform = matrixRotated;
					}
					foreach (AutoHidePane pane in GetPanes(dockState))
					{
						foreach (AutoHideTabFromBase tab in pane.Tabs)
						{
							DrawTab(g, tab);
						}
					}
					g.Transform = matrixIdentity;
				}
				private void CalculateTabs()
				{
					CalculateTabs(DockState.DockTopAutoHide);
					CalculateTabs(DockState.DockBottomAutoHide);
					CalculateTabs(DockState.DockLeftAutoHide);
					CalculateTabs(DockState.DockRightAutoHide);
				}
				private void CalculateTabs(DockState dockState)
				{
					Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
					int imageHeight = rectTabStrip.Height - ImageGapTop - ImageGapBottom;
					int imageWidth = imageWidth;
					if (imageHeight > this.ImageHeight)
					{
						imageWidth = this.ImageWidth * (imageHeight / this.ImageHeight);
					}
					using (Graphics g = CreateGraphics())
					{
						int x = TabGapLeft + rectTabStrip.X;
						foreach (AutoHidePane pane in GetPanes(dockState))
						{
							int maxWidth = 0;
							foreach (AutoHideTabFromBase tab in pane.Tabs)
							{
								int width = imageWidth + ImageGapLeft + ImageGapRight + ((int) (g.MeasureString(tab.Content.DockHandler.TabText, Font).Width))+ 1 + TextGapLeft + TextGapRight;
								if (width > maxWidth)
								{
									maxWidth = width;
								}
							}
							foreach (AutoHideTabFromBase tab in pane.Tabs)
							{
								tab.TabX = x;
								if (tab.Content == pane.DockPane.ActiveContent)
								{
									tab.TabWidth = maxWidth;
								}
								else
								{
									tab.TabWidth = imageWidth + ImageGapLeft + ImageGapRight;
								}
								x += tab.TabWidth;
							}
							x += TabGapBetween;
						}
					}
					
				}
				private void DrawTab(Graphics g, AutoHideTabFromBase tab)
				{
					Rectangle rectTab = GetTabRectangle(tab);
					if (rectTab.IsEmpty)
					{
						return;
					}
					DockState dockState = tab.Content.DockHandler.DockState;
					IDockContent content = tab.Content;
					BeginDrawTab();
					Brush brushTabBackGround = this.BrushTabBackGround;
					Pen penTabBorder = this.PenTabBorder;
					Brush brushTabText = this.BrushTabText;
					
					g.SmoothingMode = SmoothingMode.AntiAlias;
					if (dockState == dockState.DockTopAutoHide || dockState == dockState.DockRightAutoHide)
					{
						DrawHelper.DrawTab(g, rectTab, Corners.Bottom, GradientType.Flat, Color.FromArgb(244, 242, 232), Color.FromArgb(244, 242, 232), Color.FromArgb(172, 168, 153), true);
					}
					else
					{
						DrawHelper.DrawTab(g, rectTab, Corners.Top, GradientType.Flat, Color.FromArgb(244, 242, 232), Color.FromArgb(244, 242, 232), Color.FromArgb(172, 168, 153), true);
					}
					
					// Set no rotate for drawing icon and text
					Matrix matrixRotate = g.Transform;
					g.Transform = MatrixIdentity;
					
					// Draw the icon
					Rectangle rectImage = rectTab;
					rectImage.X += ImageGapLeft;
					rectImage.Y += ImageGapTop;
					int imageHeight = rectTab.Height - ImageGapTop - ImageGapBottom;
					int imageWidth = this.ImageWidth;
					if (imageHeight > this.ImageHeight)
					{
						imageWidth = this.ImageWidth * (imageHeight / this.ImageHeight);
					}
					rectImage.Height = imageHeight;
					rectImage.Width = imageWidth;
					rectImage = GetTransformedRectangle(dockState, rectImage);
					g.DrawIcon(content.DockHandler.Icon, rectImage);
					
					// Draw the text
					if (content == content.DockHandler.Pane.ActiveContent)
					{
						Rectangle rectText = rectTab;
						rectText.X += ImageGapLeft + imageWidth + ImageGapRight + TextGapLeft;
						rectText.Width -= ImageGapLeft + imageWidth + ImageGapRight + TextGapLeft;
						rectText = GetTransformedRectangle(dockState, rectText);
						if (dockState == dockState.DockLeftAutoHide || dockState == dockState.DockRightAutoHide)
						{
							g.DrawString(content.DockHandler.TabText, Font, brushTabText, rectText, StringFormatTabVertical);
						}
						else
						{
							g.DrawString(content.DockHandler.TabText, Font, brushTabText, rectText, StringFormatTabHorizontal);
						}
					}
					// Set rotate back
					g.Transform = matrixRotate;
					EndDrawTab();
				}
				private Rectangle GetLogicalTabStripRectangle(DockState dockState)
				{
					return GetLogicalTabStripRectangle(dockState, false);
				}
				private Rectangle GetLogicalTabStripRectangle(DockState dockState, bool transformed)
				{
					if (! DockHelper.IsDockStateAutoHide(dockState))
					{
						return Rectangle.Empty;
					}
					int leftPanes = GetPanes(dockState.DockLeftAutoHide).Count;
					int rightPanes = GetPanes(dockState.DockRightAutoHide).Count;
					int topPanes = GetPanes(dockState.DockTopAutoHide).Count;
					int bottomPanes = GetPanes(dockState.DockBottomAutoHide).Count;
					int x;
					int y;
					int width;
					int height;
					height = MeasureHeight();
					if (dockState == dockState.DockLeftAutoHide && leftPanes > 0)
					{
						x = 0;
						if (topPanes == 0)
						{
							y = 0;
						}
						else
						{
							
							y = height;
						}
						if (topPanes == 0)
						{
							if (bottomPanes == 0)
							{
								width = this.Height;
							}
							else
							{
								width = this.Height - height;
							}
						}
						else
						{
							if (bottomPanes == 0)
							{
								width = this.Height - height;
							}
							else
							{
								width = this.Height - height * 2;
							}
						}
					}
					else if (dockState == dockState.DockRightAutoHide && rightPanes > 0)
					{
						x = this.Width - height;
						if (leftPanes != 0 && x < height)
						{
							x = height;
						}
						if (topPanes == 0)
						{
							y = 0;
						}
						else
						{
							
							y = height;
						}
						if (topPanes == 0)
						{
							if (bottomPanes == 0)
							{
								width = this.Height;
							}
							else
							{
								width = this.Height - height;
							}
						}
						else
						{
							if (bottomPanes == 0)
							{
								width = this.Height - height;
							}
							else
							{
								width = this.Height - height * 2;
							}
						}
					}
					else if (dockState == dockState.DockTopAutoHide && topPanes > 0)
					{
						if (leftPanes == 0)
						{
							x = 0;
						}
						else
						{
							
							x = height;
						}
						y = 0;
						if (leftPanes == 0)
						{
							if (rightPanes == 0)
							{
								width = this.Width;
							}
							else
							{
								width = this.Width - height;
							}
						}
						else
						{
							if (rightPanes == 0)
							{
								width = this.Width - height;
							}
							else
							{
								width = this.Width - height * 2;
							}
						}
					}
					else if (dockState == dockState.DockBottomAutoHide && bottomPanes > 0)
					{
						if (leftPanes == 0)
						{
							x = 0;
						}
						else
						{
							
							x = height;
						}
						y = this.Height - height;
						if (topPanes != 0 && y < height)
						{
							y = height;
						}
						if (leftPanes == 0)
						{
							if (rightPanes == 0)
							{
								width = this.Width;
							}
							else
							{
								width = this.Width - height;
							}
						}
						else
						{
							if (rightPanes == 0)
							{
								width = this.Width - height;
							}
							else
							{
								width = this.Width - height * 2;
							}
						}
						
					}
					else
					{
						return Rectangle.Empty;
					}
					if (! transformed)
					{
						return new Rectangle(x, y, width, height);
					}
					else
					{
						return GetTransformedRectangle(dockState, new Rectangle(x, y, width, height));
					}
				}
				private Rectangle GetTabRectangle(AutoHideTabFromBase tab)
				{
					return GetTabRectangle(tab, false);
				}
				private Rectangle GetTabRectangle(AutoHideTabFromBase tab, bool transformed)
				{
					DockState dockState = tab.Content.DockHandler.DockState;
					Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
					if (rectTabStrip.IsEmpty)
					{
						return Rectangle.Empty;
					}
					int x = tab.TabX;
					int y;
					
					if (dockState == dockState.DockTopAutoHide || dockState == dockState.DockRightAutoHide)
					{
						y = rectTabStrip.Y;
					}
					else
					{
						y = rectTabStrip.Y + TabGapTop;
					}
					
					int width = (tab ).TabWidth;
					int height = rectTabStrip.Height - TabGapTop;
					if (! transformed)
					{
						return new Rectangle(x, y, width, height);
					}
					else
					{
						return GetTransformedRectangle(dockState, new Rectangle(x, y, width, height));
					}
				}
				private Rectangle GetTransformedRectangle(DockState dockState, Rectangle rect)
				{
					if (dockState != dockState.DockLeftAutoHide && dockState != dockState.DockRightAutoHide)
					{
						return rect;
					}
					PointF[] pts = new PointF[2]();
					// the center of the rectangle
					pts[0].X = (rect.X)+ (rect.Width)/ 2;
					pts[0].Y = (rect.Y)+ (rect.Height)/ 2;
					Rectangle rectTabStrip = GetLogicalTabStripRectangle(dockState);
					Matrix matrix = new Matrix();
					matrix.RotateAt(90, new PointF((rectTabStrip.X)+ (rectTabStrip.Height)/ 2, (rectTabStrip.Y)+ (rectTabStrip.Height)/ 2));
					matrix.TransformPoints(pts);
					return new Rectangle(System.Convert.ToInt32(pts[0].X - (rect.Height)/ 2 + 0.5F), System.Convert.ToInt32(pts[0].Y - (rect.Width)/ 2 + 0.5F), rect.Height, rect.Width);
				}
				protected override IDockContent GetHitTest(Point ptMouse)
				{
					foreach (DockState state in DockStates)
					{
						Rectangle rectTabStrip = GetLogicalTabStripRectangle(state, true);
						if (! rectTabStrip.Contains(ptMouse))
						{
							continue;
						}
						foreach (AutoHidePane pane in GetPanes(state))
						{
							foreach (AutoHideTabFromBase tab in pane.Tabs)
							{
								Rectangle rectTab = GetTabRectangle(tab, true);
								rectTab.Intersect(rectTabStrip);
								if (rectTab.Contains(ptMouse))
								{
									return tab.Content;
								}
							}
						}
					}
					return null;
				}
				protected override int MeasureHeight()
				{
					return Math.Max(ImageGapBottom + ImageGapTop + ImageHeight, Font.Height) + TabGapTop;
				}
				protected override void OnRefreshChanges()
				{
					CalculateTabs();
					Invalidate();
				}
			}
		}
	}
	
}
