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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;

namespace SoftLogik.Win.UI.Controls.Docking
{
	[ToolboxItem(false)]
	public class PopupButton : Button
	{

        private enum RepeatClickStatus : int
		{
			Disabled,
			Started,
			Repeating,
			Stopped
		}
		private class RepeatClickEventArgs : System.EventArgs
		{
			private static RepeatClickEventArgs _empty;
            static RepeatClickEventArgs()
			{
				_empty = new RepeatClickEventArgs();
			}
			public static new RepeatClickEventArgs Empty
			{
				get
				{
					return _empty;
				}
			}
		}

#region Private fields
			private IContainer components = new Container();
			private bool m_isActivated = false;
			private int m_borderWidth = 1;
			private bool m_mouseOver = false;
			private bool m_mouseCapture = false;
			private bool m_isPopup = false;
			private Image m_imageEnabled = null;
			private Image m_imageDisabled = null;
			private int m_imageIndexEnabled = -1;
			private int m_imageIndexDisabled = -1;
			private bool m_monochrom = true;
			private ToolTip m_toolTip = null;
			private string m_toolTipText = "";
			private Color m_borderColor = Color.Empty;
			private Color m_activeGradientBegin = Color.Empty;
			private Color m_activeGradientEnd = Color.Empty;
			private Color m_inactiveGradientBegin = Color.Empty;
			private Color m_inactiveGradientEnd = Color.Empty;
			private RepeatClickStatus m_clickStatus = RepeatClickStatus.Disabled;
			private int m_repeatClickDelay = 500;
			private int m_repeatClickInterval = 100;
			private Timer m_timer;
#endregion

#region Public Methods
            public PopupButton()
            {
                InternalConstruct(null, null);
            }
            public PopupButton(Image c_imageEnabled)
            {
                InternalConstruct(c_imageEnabled, null);
            }
            public PopupButton(Image c_imageEnabled, Image c_imageDisabled)
            {
                InternalConstruct(c_imageEnabled, c_imageDisabled);
            }
#endregion

#region Private Methods
			private void InternalConstruct(Image c_imageEnabled, Image c_imageDisabled)
			{
				// Remember parameters
				this.ImageEnabled = c_imageEnabled;
				this.ImageDisabled = c_imageDisabled;
				// Prevent drawing flicker by blitting from memory in WM_PAINT
				SetStyle(ControlStyles.ResizeRedraw, true);
				SetStyle(ControlStyles.UserPaint, true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				// Prevent base class from trying to generate double click events and
				// so testing clicks against the double click time and rectangle. Getting
				// rid of this allows the user to press then release button very quickly.
				//SetStyle(ControlStyles.StandardDoubleClick, false);
				// Should not be allowed to select this control
				SetStyle(ControlStyles.Selectable, false);
				m_timer = new Timer();
				m_timer.Enabled = false;
				m_timer.Tick += new System.EventHandler(Timer_Tick);
			}
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			private bool ShouldSerializeBorderColor()
			{
				return (m_borderColor != Color.Empty);
			}
			private bool ShouldSerializeImageEnabled()
			{
				return (m_imageEnabled != null);
			}
			private bool ShouldSerializeImageDisabled()
			{
				return (m_imageDisabled != null);
			}
			private void DrawBackground(Graphics g)
			{
				if (m_mouseOver)
				{
					if (m_isActivated)
					{
						using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(156, 182, 231), Color.FromArgb(156, 182, 231), LinearGradientMode.Vertical))
						{
							g.FillRectangle(brush, ClientRectangle);
						}
					}
					else
					{
						using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(236, 233, 216), Color.FromArgb(236, 233, 216), LinearGradientMode.Vertical))
						{
							g.FillRectangle(brush, ClientRectangle);
						}
					}
				}
				else
				{
					if (m_isActivated)
					{
						using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, ActiveBackColorGradientBegin, ActiveBackColorGradientEnd, LinearGradientMode.Vertical))
						{
							g.FillRectangle(brush, ClientRectangle);
						}
					}
					else
					{
						using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, InactiveBackColorGradientBegin, InactiveBackColorGradientEnd, LinearGradientMode.Vertical))
						{
							g.FillRectangle(brush, ClientRectangle);
						}
					}
				}
			}
			private void DrawImage(Graphics g)
			{
				Image image = null;
				if (this.Enabled)
				{
					image = this.ImageEnabled;
				}
				else
				{
					if (ImageDisabled != null)
					{
						image = this.ImageDisabled;
					}
					else
					{
						image = this.ImageEnabled;
					}
				}
				ImageAttributes imageAttr = null;
				if (image == null)
				{
					return;
				}
				if (m_monochrom)
				{
					imageAttr = new ImageAttributes();
					// transform the monochrom image
					// white -> BackColor
					// black -> ForeColor
					ColorMap[] myColorMap = new ColorMap[2];
					myColorMap[0] = new ColorMap();
					myColorMap[0].OldColor = Color.White;
					myColorMap[0].NewColor = Color.Transparent;
					myColorMap[1] = new ColorMap();
					myColorMap[1].OldColor = Color.Black;
					myColorMap[1].NewColor = this.ForeColor;
					imageAttr.SetRemapTable(myColorMap);
				}
				Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
				if ((! Enabled) && (ImageDisabled == null))
				{
					using (Bitmap bitmapMono = new Bitmap(image, ClientRectangle.Size))
					{
						if (imageAttr != null)
						{
							using (Graphics gMono = Graphics.FromImage(bitmapMono))
							{
								gMono.DrawImage(image, new Point[3] {new Point(0, 0), new Point(image.Width - 1, 0), new Point(0, image.Height - 1)}, rect, GraphicsUnit.Pixel, imageAttr);
							}
						}
						ControlPaint.DrawImageDisabled(g, bitmapMono, 0, 0, this.BackColor);
					}
				}
				else
				{
					// Three points provided are upper-left, upper-right and 
					// lower-left of the destination parallelogram. 
					Point[] pts = new Point[3];
					if (Enabled && m_mouseOver && m_mouseCapture)
					{
						pts[0].X = 1;
						pts[0].Y = 1;
					}
					else
					{
						pts[0].X = 0;
						pts[0].Y = 0;
					}
					pts[1].X = pts[0].X + ClientRectangle.Width;
					pts[1].Y = pts[0].Y;
					pts[2].X = pts[0].X;
					pts[2].Y = pts[1].Y + ClientRectangle.Height;
					if (imageAttr == null)
					{
						g.DrawImage(image, pts, rect, GraphicsUnit.Pixel);
					}
					else
					{
						g.DrawImage(image, pts, rect, GraphicsUnit.Pixel, imageAttr);
					}
				}
			}
			private void DrawText(Graphics g)
			{
				if (Text == string.Empty)
				{
					return;
				}
				Rectangle rect = ClientRectangle;
				rect.X += BorderWidth;
				rect.Y += BorderWidth;
				rect.Width -= 2 * BorderWidth;
				rect.Height -= 2 * BorderWidth;
				StringFormat stringFormat = new StringFormat();
				if (TextAlign == ContentAlignment.TopLeft)
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Near;
				}
				else if (TextAlign == ContentAlignment.TopCenter)
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Near;
				}
				else if (TextAlign == ContentAlignment.TopRight)
				{
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Near;
				}
				else if (TextAlign == ContentAlignment.MiddleLeft)
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
				}
				else if (TextAlign == ContentAlignment.MiddleCenter)
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
				}
				else if (TextAlign == ContentAlignment.MiddleRight)
				{
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Center;
				}
				else if (TextAlign == ContentAlignment.BottomLeft)
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Far;
				}
				else if (TextAlign == ContentAlignment.BottomCenter)
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Far;
				}
				else if (TextAlign == ContentAlignment.BottomRight)
				{
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Far;
				}
				using (Brush brush = new SolidBrush(ForeColor))
				{
					g.DrawString(Text, Font, brush, rect, stringFormat);
				}
			}
			private void DrawBorder(Graphics g)
			{
				ButtonBorderStyle bs = 0;
				// Decide on the type of border to draw around image
				if (! this.Enabled)
				{
					if (IsPopup)
					{
						bs = ButtonBorderStyle.Outset;
					}
					else
					{
						bs = ButtonBorderStyle.Solid;
					}
				}
				else if (m_mouseOver && m_mouseCapture)
				{
					bs = ButtonBorderStyle.Inset;
				}
				else if (IsPopup || m_mouseOver)
				{
					if (m_isActivated)
					{
						BorderColor = Color.FromArgb(60, 90, 170);
					}
					else
					{
						BorderColor = Color.FromArgb(140, 134, 123);
					}
					bs = ButtonBorderStyle.Solid;
				}
				else
				{
					bs = ButtonBorderStyle.Solid;
				}
				Color colorLeftTop = new Color();
				Color colorRightBottom = new Color();
				if (bs == ButtonBorderStyle.Solid)
				{
					colorLeftTop = this.BorderColor;
					colorRightBottom = this.BorderColor;
				}
				else if (bs == ButtonBorderStyle.Outset)
				{
					if (m_borderColor.IsEmpty)
					{
						colorLeftTop = this.BackColor;
					}
					else
					{
						colorLeftTop = m_borderColor;
					}
					colorRightBottom = this.BackColor;
				}
				else
				{
					colorLeftTop = this.BackColor;
					if (m_borderColor.IsEmpty)
					{
						colorRightBottom = this.BackColor;
					}
					else
					{
						colorRightBottom = m_borderColor;
					}
				}

				ControlPaint.DrawBorder(g, ClientRectangle, colorLeftTop, m_borderWidth, bs, colorLeftTop, m_borderWidth, bs, colorRightBottom, m_borderWidth, bs, colorRightBottom, m_borderWidth, bs);
			}
#endregion

#region Properties
			public bool IsActivated
			{
				get
				{
					return m_isActivated;
				}
				set
				{
					m_isActivated = value;
				}
			}

			[Category("Appearance")]
			public System.Drawing.Color ActiveBackColorGradientBegin
			{
				get
				{
					return m_activeGradientBegin;
				}
				set
				{
					m_activeGradientBegin = value;
				}
			}

			[Category("Appearance")]
			public System.Drawing.Color ActiveBackColorGradientEnd
			{
				get
				{
					return m_activeGradientEnd;
				}
				set
				{
					m_activeGradientEnd = value;
				}
			}

			[Category("Appearance")]
			public System.Drawing.Color InactiveBackColorGradientBegin
			{
				get
				{
					return m_inactiveGradientBegin;
				}
				set
				{
					m_inactiveGradientBegin = value;
				}
			}

			[Category("Appearance")]
			public System.Drawing.Color InactiveBackColorGradientEnd
			{
				get
				{
					return m_inactiveGradientEnd;
				}
				set
				{
					m_inactiveGradientEnd = value;
				}
			}

			[Category("Appearance")]
			public Color BorderColor
			{
				get
				{
					return m_borderColor;
				}
				set
				{
					if (m_borderColor != value)
					{
						m_borderColor = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance"), DefaultValue(1)]
			public int BorderWidth
			{
				get
				{
					return m_borderWidth;
				}
				set
				{
					if (value < 1)
					{
						value = 1;
					}
					if (m_borderWidth != value)
					{
						m_borderWidth = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance")]
			public Image ImageEnabled
			{
				get
				{
					if (m_imageEnabled != null)
					{
						return m_imageEnabled;
					}
					try
					{
						if (ImageList == null || ImageIndexEnabled == -1)
						{
							return null;
						}
						else
						{
							return ImageList.Images[m_imageIndexEnabled];
						}
					}
					catch
					{
						return null;
					}
				}
				set
				{
					if (value != m_imageEnabled)
					{
						m_imageEnabled = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance")]
			public Image ImageDisabled
			{
				get
				{
					if (m_imageDisabled != null)
					{
						return m_imageDisabled;
					}
					try
					{
						if (ImageList == null || ImageIndexDisabled == -1)
						{
							return null;
						}
						else
						{
							return ImageList.Images[m_imageIndexDisabled];
						}
					}
					catch
					{
						return null;
					}
				}
				set
				{
					if (m_imageDisabled == value)
					{
						m_imageDisabled = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance"), DefaultValue(-1), Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", "System.Drawing.Design.UITypeEditor,System.Drawing"), TypeConverter(typeof(System.Windows.Forms.ImageIndexConverter)), RefreshProperties(RefreshProperties.Repaint)]
			public int ImageIndexEnabled
			{
				get
				{
					return m_imageIndexEnabled;
				}
				set
				{
					if (m_imageIndexEnabled != value)
					{
						m_imageIndexEnabled = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance"), DefaultValue(-1), Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design", "System.Drawing.Design.UITypeEditor,System.Drawing"), TypeConverter(typeof(System.Windows.Forms.ImageIndexConverter)), RefreshProperties(RefreshProperties.Repaint)]
			public int ImageIndexDisabled
			{
				get
				{
					return m_imageIndexDisabled;
				}
				set
				{
					if (m_imageIndexDisabled != value)
					{
						m_imageIndexDisabled = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance"), DefaultValue(false)]
			public bool IsPopup
			{
				get
				{
					return m_isPopup;
				}
				set
				{
					if (m_isPopup != value)
					{
						m_isPopup = value;
						Invalidate();
					}
				}
			}
			[Category("Appearance"), DefaultValue(true)]
			public bool Monochrome
			{
				get
				{
					return m_monochrom;
				}
				set
				{
					if (value != m_monochrom)
					{
						m_monochrom = value;
						Invalidate();
					}
				}
			}
			[Category("Behavior"), DefaultValue(false)]
			public bool RepeatClick
			{
				get
				{
					return (ClickStatus != RepeatClickStatus.Disabled);
				}
				set
				{
					ClickStatus = RepeatClickStatus.Stopped;
				}
			}
			private RepeatClickStatus ClickStatus
			{
				get
				{
					return m_clickStatus;
				}
				set
				{
					if (m_clickStatus == value)
					{
						return;
					}
					m_clickStatus = value;
					if (ClickStatus == RepeatClickStatus.Started)
					{
						Timer.Interval = RepeatClickDelay;
						Timer.Enabled = true;
					}
					else if (ClickStatus == RepeatClickStatus.Repeating)
					{
						Timer.Interval = RepeatClickInterval;
					}
					else
					{
						Timer.Enabled = false;
					}
				}
			}
			[Category("Behavior"), DefaultValue(500)]
			public int RepeatClickDelay
			{
				get
				{
					return m_repeatClickDelay;
				}
				set
				{
					m_repeatClickDelay = value;
				}
			}
			[Category("Behavior"), DefaultValue(100)]
			public int RepeatClickInterval
			{
				get
				{
					return m_repeatClickInterval;
				}
				set
				{
					m_repeatClickInterval = value;
				}
			}
			private Timer Timer
			{
				get
				{
					return m_timer;
				}
			}
			[Category("Appearance"), DefaultValue("")]
			public string ToolTipText
			{
				get
				{
					return m_toolTipText;
				}
				set
				{
					if (m_toolTipText != value)
					{
						if (m_toolTip == null)
						{
							m_toolTip = new ToolTip(this.components);
						}
						m_toolTipText = value;
						m_toolTip.SetToolTip(this, value);
					}
				}
			}
#endregion

#region Events
			private void Timer_Tick(object sender, EventArgs e)
			{
				if (m_mouseCapture && m_mouseOver)
				{
					OnClick(RepeatClickEventArgs.Empty);
				}
				if (ClickStatus == RepeatClickStatus.Started)
				{
					ClickStatus = RepeatClickStatus.Repeating;
				}
			}
			protected override void OnMouseDown(MouseEventArgs e)
			{
				base.OnMouseDown(e);
				if (e.Button != System.Windows.Forms.MouseButtons.Left)
				{
					return;
				}
				if (m_mouseCapture == false || m_mouseOver == false)
				{
					m_mouseCapture = true;
					m_mouseOver = true;
					//Redraw to show button state
					Invalidate();
				}
				if (RepeatClick)
				{
					OnClick(RepeatClickEventArgs.Empty);
					ClickStatus = RepeatClickStatus.Started;
				}
			}
			protected override void OnClick(EventArgs e)
			{
				if (RepeatClick && ! (e is RepeatClickEventArgs))
				{
					return;
				}
				base.OnClick(e);
			}
			protected override void OnMouseUp(MouseEventArgs e)
			{
				base.OnMouseUp(e);
				if (e.Button != MouseButtons.Left)
				{
					return;
				}
				if (m_mouseOver == true || m_mouseCapture == true)
				{
					m_mouseOver = false;
					m_mouseCapture = false;
					// Redraw to show button state
					Invalidate();
				}
				if (RepeatClick)
				{
					ClickStatus = RepeatClickStatus.Stopped;
				}
			}
			protected override void OnMouseMove(MouseEventArgs e)
			{
				base.OnMouseMove(e);
				// Is mouse point inside our client rectangle
				bool over = this.ClientRectangle.Contains(new Point(e.X, e.Y));
				// If entering the button area or leaving the button area...
				if (over != m_mouseOver)
				{
					// Update state
					m_mouseOver = over;
					// Redraw to show button state
					Invalidate();
				}
			}
			protected override void OnMouseEnter(EventArgs e)
			{
				// Update state to reflect mouse over the button area
				if (! m_mouseOver)
				{
					m_mouseOver = true;
					// Redraw to show button state
					Invalidate();
				}
				base.OnMouseEnter(e);
			}
			protected override void OnMouseLeave(EventArgs e)
			{
				// Update state to reflect mouse not over the button area
				if (m_mouseOver)
				{
					m_mouseOver = false;
					// Redraw to show button state
					Invalidate();
				}
				base.OnMouseLeave(e);
			}
			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				DrawBackground(e.Graphics);
				DrawImage(e.Graphics);
				DrawText(e.Graphics);
				if (m_mouseOver | m_mouseCapture)
				{
					DrawBorder(e.Graphics);
				}
			}
			protected override void OnEnabledChanged(EventArgs e)
			{
				base.OnEnabledChanged(e);
				if (Enabled == false)
				{
					m_mouseOver = false;
					m_mouseCapture = false;
					if (RepeatClick && ClickStatus != RepeatClickStatus.Stopped)
					{
						ClickStatus = RepeatClickStatus.Stopped;
					}
				}
				Invalidate();
			}
#endregion

			private void InitializeComponent()
			{
				this.SuspendLayout();
				//
				//PopupButton
				//
				this.AutoSize = true;
				this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.ResumeLayout(false);

			}
		}
}
