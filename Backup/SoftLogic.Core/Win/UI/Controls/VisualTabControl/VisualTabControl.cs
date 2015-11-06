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


namespace SoftLogik.Win.UI
{
    [ToolboxBitmap(typeof(TabControl))]
    public partial class VisualTabControl : TabControl
	{
		
		
		
		#region     Variables
		
		private VisualTabControlDisplayManager _DisplayManager = VisualTabControlDisplayManager.Framework;
		
		#endregion
		
		#region     Properties
		
		[System.ComponentModel.DefaultValue(typeof(VisualTabControlDisplayManager), "Framework"), System.ComponentModel.Category("Appearance")]public VisualTabControlDisplayManager DisplayManager
		{
			get
			{
				return _DisplayManager;
			}
			set
			{
				_DisplayManager = value;
				if (this._DisplayManager.Equals(VisualTabControlDisplayManager.Framework))
				{
					this.SetStyle(ControlStyles.UserPaint, true);
					this.ItemSize = new Size(0, 15);
					this.Padding = new Point(9, 0);
				}
				else
				{
					this.ItemSize = new Size(0, 0);
					this.Padding = new Point(6, 3);
					this.SetStyle(ControlStyles.UserPaint, false);
				}
			}
		}
		
		#endregion
		
		#region     Constructor
		
		public VisualTabControl()
		{
			if (this._DisplayManager.Equals(VisualTabControlDisplayManager.Framework))
			{
				this.SetStyle(ControlStyles.UserPaint, true);
				this.ItemSize = new Size(0, 15);
				this.Padding = new Point(9, 0);
			}
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.ResizeRedraw = true;
		}
		
		#endregion
		
		#region     Private Methods
		
		private System.Drawing.Drawing2D.GraphicsPath GetPath(int index)
		{
			System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
			path.Reset();
			
			Rectangle rect = this.GetTabRect(index);
			
			if (index == 0)
			{
				path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
				path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
				path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
			}
			else
			{
				if (index == this.SelectedIndex)
				{
					path.AddLine(rect.Left + 5 - rect.Height, rect.Bottom + 1, rect.Left + 4, rect.Top + 2);
					path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
					path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
					path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left + 5 - rect.Height, rect.Bottom + 1);
				}
				else
				{
					path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
					path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
					path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
					path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
				}
			}
			return path;
		}
		
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			
			//   Paint the Background
			this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);
			
			//   Paint all the tabs
			if (this.TabCount > 0)
			{
				for (int index = 0; index <= this.TabCount - 1; index++)
				{
					this.PaintTab(e, index);
				}
			}
			
			//   paint a border round the pagebox
			//   We can't make the border disappear so have to do it like this.
			if (this.TabCount > 0)
			{
				
				Rectangle borderRect = this.TabPages[0].Bounds;
				if (this.SelectedTab != null)
				{
					borderRect = this.SelectedTab.Bounds;
				}
				
				borderRect.Inflate(1, 1);
				ControlPaint.DrawBorder(e.Graphics, borderRect, VisualThemedColors.ToolBorder, ButtonBorderStyle.Solid);
				
			}
			
			//   repaint the bit where the selected tab is
			switch (this.SelectedIndex)
			{
				case - 1:
					break;
				case 0:
					Rectangle selrect = this.GetTabRect(this.SelectedIndex);
					int selrectRight = selrect.Right;
					e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect.Left + 2, selrect.Bottom + 1, selrectRight - 2, selrect.Bottom + 1);
					break;
				default:
					Rectangle selrect_1 = this.GetTabRect(this.SelectedIndex);
					int selrectRight_1 = selrect_1.Right;
					e.Graphics.DrawLine(SystemPens.ControlLightLight, selrect_1.Left + 6 - selrect_1.Height, selrect_1.Bottom + 1, selrectRight_1 - 2, selrect_1.Bottom + 1);
					break;
			}
			
		}
		
		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
		{
			if (this.DesignMode)
			{
				System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
				pevent.Graphics.FillRectangle(backBrush, this.Bounds);
				backBrush.Dispose();
			}
			else
			{
				this.PaintTransparentBackground(pevent.Graphics, this.ClientRectangle);
			}
		}
		
		protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
		{
			if (this.Parent != null)
			{
				clipRect.Offset(this.Location);
				PaintEventArgs e = new PaintEventArgs(g, clipRect);
				GraphicsState state = g.Save();
				g.SmoothingMode = SmoothingMode.HighSpeed;
				try
				{
					g.TranslateTransform(System.Convert.ToSingle(- this.Location.X), System.Convert.ToSingle(- this.Location.Y));
					this.InvokePaintBackground(this.Parent, e);
					this.InvokePaint(this.Parent, e);
					
				}
				finally
				{
					g.Restore(state);
					clipRect.Offset(- this.Location.X, - this.Location.Y);
				}
			}
			else
			{
				System.Drawing.Drawing2D.LinearGradientBrush backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(this.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
				g.FillRectangle(backBrush, this.Bounds);
				backBrush.Dispose();
			}
		}
		
		private void PaintTab(System.Windows.Forms.PaintEventArgs e, int index)
		{
			
			System.Drawing.Drawing2D.GraphicsPath path = this.GetPath(index);
			this.PaintTabBackground(e.Graphics, index, path);
			this.PaintTabBorder(e.Graphics, index, path);
			this.PaintTabText(e.Graphics, index);
			this.PaintTabImage(e.Graphics, index);
			
		}
		
		private void PaintTabBackground(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path)
		{
			Rectangle rect = this.GetTabRect(index);
			
			if (rect.Height > 1 && rect.Width > 1)
			{
				System.Drawing.Brush buttonBrush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, SystemColors.ControlLightLight, SystemColors.ControlLight, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
				
				if (index == this.SelectedIndex)
				{
					buttonBrush = new System.Drawing.SolidBrush(SystemColors.ControlLightLight);
				}
				
				graph.FillPath(buttonBrush, path);
				buttonBrush.Dispose();
			}
			
		}
		
		private void PaintTabBorder(System.Drawing.Graphics graph, int index, System.Drawing.Drawing2D.GraphicsPath path)
		{
			Pen borderPen = new Pen(SystemColors.ControlDark);
			if (index == this.SelectedIndex)
			{
				borderPen = new Pen(VisualThemedColors.ToolBorder);
			}
			
			graph.DrawPath(borderPen, path);
			borderPen.Dispose();
		}
		
		private void PaintTabImage(System.Drawing.Graphics graph, int index)
		{
			Image tabImage = null;
			if (this.TabPages[index].ImageIndex > - 1 && (this.ImageList != null))
			{
				tabImage = this.ImageList.Images[this.TabPages[index].ImageIndex];
			}
			else if (this.TabPages[index].ImageKey.Trim().Length > 0 && (this.ImageList != null))
			{
				tabImage = this.ImageList.Images[this.TabPages[index].ImageKey];
			}
			if (tabImage != null)
			{
				Rectangle rect = this.GetTabRect(index);
				graph.DrawImage(tabImage, rect.Right - rect.Height - 4, 4, rect.Height - 2, rect.Height - 2);
			}
		}
		
		private void PaintTabText(System.Drawing.Graphics graph, int index)
		{
			Rectangle rect = this.GetTabRect(index);
			Rectangle rect2 = new Rectangle(rect.Left + 8, rect.Top + 1, rect.Width - 6, rect.Height);
			if (index == 0)
			{
				rect2 = new Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height, rect.Height);
			}
			
			string tabtext = this.TabPages[index].Text;
			
			System.Drawing.StringFormat format = new System.Drawing.StringFormat();
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Center;
			format.Trimming = StringTrimming.EllipsisCharacter;
			
			Brush forebrush = null;
			
			if (this.TabPages[index].Enabled == false)
			{
				forebrush = SystemBrushes.ControlDark;
			}
			else
			{
				forebrush = SystemBrushes.ControlText;
			}
			
			Font tabFont = this.Font;
			if (index == this.SelectedIndex)
			{
				tabFont = new Font(this.Font, FontStyle.Bold);
				if (index == 0)
				{
					rect2 = new Rectangle(rect.Left + rect.Height, rect.Top + 1, rect.Width - rect.Height + 5, rect.Height);
				}
			}
			
			graph.DrawString(tabtext, tabFont, forebrush, rect2, format);
			
		}
		
		#endregion
		
		public enum VisualTabControlDisplayManager
		{
			@Default,
			Framework
		}
		
		protected override void OnSelecting(System.Windows.Forms.TabControlCancelEventArgs e)
		{
			if (e.Action == TabControlAction.Selecting && (e.TabPage != null)&& e.TabPage.Enabled == false)
			{
				
				e.Cancel = true;
				if (e.TabPageIndex == 0 && this.TabPages.Count == 1)
				{
					if (this.TabPages[0].Controls.Count > 0)
					{
						Form item = this.TabPages[0].Controls[0] as Form;
						if (item != null)
						{
							item.Close();
						}
					}
					this.TabPages.RemoveAt(0);
				}
				else if (e.TabPageIndex == 0 && this.TabPages.Count > 1)
				{
					e.Cancel = false;
				}
			}
			base.OnSelecting(e);
		}
		
		protected override void OnSelected(System.Windows.Forms.TabControlEventArgs e)
		{
			if (e.Action == TabControlAction.Selected && (e.TabPage != null)&& e.TabPage.Enabled == false)
			{
				
				if (this.TabPages.Count > e.TabPageIndex + 1)
				{
					this.SelectedIndex = e.TabPageIndex + 1;
				}
				else if (e.TabPageIndex > 0)
				{
					this.SelectedIndex = e.TabPageIndex - 1;
				}
			}
			base.OnSelected(e);
			this.Invalidate();
		}
		
	}
}
