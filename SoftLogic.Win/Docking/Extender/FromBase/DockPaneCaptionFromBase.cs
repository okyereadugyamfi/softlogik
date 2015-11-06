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
using System.Windows.Forms;
using System.ComponentModel;
using WeifenLuo.WinFormsUI;
using System.Drawing.Drawing2D;

namespace SoftLogik.Win.UI.Controls.Docking
{
	[ToolboxItem(false)]
	public class DockPaneCaptionFromBase : DockPaneCaptionBase
	{
#region consts
		private const int _TextGapTop = 1;
		private const int _TextGapBottom = 2;
		private const int _TextGapLeft = 3;
		private const int _TextGapRight = 3;
		private const int _ButtonGapTop = 2;
		private const int _ButtonGapBottom = 2;
		private const int _ButtonGapBetween = 4;
		private const int _ButtonGapLeft = 1;
		private const int _ButtonGapRight = 2;
		private const int _ButtonMargin = 2;
		private const string _ResourceImageCloseEnabled = "DockPaneCaption.CloseEnabled.bmp";
		private const string _ResourceImageCloseDisabled = "DockPaneCaption.CloseDisabled.bmp";
		private const string _ResourceImageOptionsEnabled = "DockPaneCaption.OptionsEnabled.bmp";
		private const string _ResourceImageOptionsDisabled = "DockPaneCaption.OptionsDisabled.bmp";
		private const string _ResourceImageAutoHideYes = "DockPaneCaption.AutoHideYes.bmp";
		private const string _ResourceImageAutoHideNo = "DockPaneCaption.AutoHideNo.bmp";
		private const string _ResourceToolTipClose = "DockPaneCaption_ToolTipClose";
		private const string _ResourceToolTipAutoHide = "DockPaneCaption_ToolTipAutoHide";
		private const string _ResourceToolTipOptions = "DockPaneCaption_ToolTipOptions";
#endregion
		private PopupButton m_buttonClose;
		private PopupButton m_buttonAutoHide;
		private PopupButton m_buttonOptions;

		protected internal DockPaneCaptionFromBase(DockPane pane) : base(pane)
		{
			SuspendLayout();
			Font = SystemInformation.MenuFont;

			m_buttonClose = new PopupButton(ImageCloseEnabled, ImageCloseDisabled);
			m_buttonClose.ActiveBackColorGradientBegin = Color.FromArgb(59, 128, 237);
			m_buttonClose.ActiveBackColorGradientEnd = Color.FromArgb(49, 106, 197);
			m_buttonClose.InactiveBackColorGradientBegin = Color.FromArgb(204, 199, 186);
			m_buttonClose.InactiveBackColorGradientEnd = Color.FromArgb(204, 199, 186);

			m_buttonAutoHide = new PopupButton();
			m_buttonAutoHide.ActiveBackColorGradientBegin = Color.FromArgb(59, 128, 237);
			m_buttonAutoHide.ActiveBackColorGradientEnd = Color.FromArgb(49, 106, 197);
			m_buttonAutoHide.InactiveBackColorGradientBegin = Color.FromArgb(204, 199, 186);
			m_buttonAutoHide.InactiveBackColorGradientEnd = Color.FromArgb(204, 199, 186);

			m_buttonOptions = new PopupButton(ImageOptionsEnabled, ImageOptionsDisabled);
			m_buttonOptions.ActiveBackColorGradientBegin = Color.FromArgb(59, 128, 237);
			m_buttonOptions.ActiveBackColorGradientEnd = Color.FromArgb(49, 106, 197);
			m_buttonOptions.InactiveBackColorGradientBegin = Color.FromArgb(204, 199, 186);
			m_buttonOptions.InactiveBackColorGradientEnd = Color.FromArgb(204, 199, 186);

			m_buttonClose.ToolTipText = ToolTipClose;
			m_buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			m_buttonClose.Click += new System.EventHandler(Close_Click);

			m_buttonAutoHide.ToolTipText = ToolTipAutoHide;
			m_buttonAutoHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			m_buttonAutoHide.Click += new System.EventHandler(AutoHide_Click);

			m_buttonOptions.ToolTipText = ToolTipOptions;
			m_buttonOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			m_buttonOptions.Click += new System.EventHandler(Options_Click);

			Controls.AddRange(new Control[] {m_buttonClose, m_buttonAutoHide, m_buttonOptions});
			ResumeLayout();
		}
#region Customizable Properties
		protected virtual int TextGapTop
		{
			get
			{
				return _TextGapTop;
			}
		}
		protected virtual int TextGapBottom
		{
			get
			{
				return _TextGapBottom;
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
		protected virtual int ButtonGapTop
		{
			get
			{
				return _ButtonGapTop;
			}
		}
		protected virtual int ButtonGapBottom
		{
			get
			{
				return _ButtonGapBottom;
			}
		}
		protected virtual int ButtonGapLeft
		{
			get
			{
				return _ButtonGapLeft;
			}
		}
		protected virtual int ButtonGapRight
		{
			get
			{
				return _ButtonGapRight;
			}
		}
		protected virtual int ButtonGapBetween
		{
			get
			{
				return _ButtonGapBetween;
			}
		}

		private static Image _imageOptionsEnabled = null;
		protected virtual Image ImageOptionsEnabled
		{
			get
			{
				if (_imageOptionsEnabled == null)
				{
					_imageOptionsEnabled = ResourceHelper.LoadExtenderBitmap(_ResourceImageOptionsEnabled);
				}
				return _imageOptionsEnabled;
			}
		}
		private static Image _imageOptionsDisabled = null;
		protected virtual Image ImageOptionsDisabled
		{
			get
			{
				if (_imageOptionsDisabled == null)
				{
					_imageOptionsDisabled = ResourceHelper.LoadExtenderBitmap(_ResourceImageOptionsDisabled);
				}
				return _imageOptionsDisabled;
			}
		}

		private static Image _imageCloseEnabled = null;
		protected virtual Image ImageCloseEnabled
		{
			get
			{
				if (_imageCloseEnabled == null)
				{
					_imageCloseEnabled = ResourceHelper.LoadExtenderBitmap(_ResourceImageCloseEnabled);
				}
				return _imageCloseEnabled;
			}
		}
		private static Image _imageCloseDisabled = null;
		protected virtual Image ImageCloseDisabled
		{
			get
			{
				if (_imageCloseDisabled == null)
				{
					_imageCloseDisabled = ResourceHelper.LoadExtenderBitmap(_ResourceImageCloseDisabled);
				}
				return _imageCloseDisabled;
			}
		}
		private static Image _imageAutoHideYes = null;
		protected virtual Image ImageAutoHideYes
		{
			get
			{
				if (_imageAutoHideYes == null)
				{
					_imageAutoHideYes = ResourceHelper.LoadExtenderBitmap(_ResourceImageAutoHideYes);
				}
				return _imageAutoHideYes;
			}
		}
		private static Image _imageAutoHideNo = null;
		protected virtual Image ImageAutoHideNo
		{
			get
			{
				if (_imageAutoHideNo == null)
				{
					_imageAutoHideNo = ResourceHelper.LoadExtenderBitmap(_ResourceImageAutoHideNo);
				}
				return _imageAutoHideNo;
			}
		}

		private static string _toolTipClose = null;
		protected virtual string ToolTipClose
		{
			get
			{
				if (_toolTipClose == null)
				{
					_toolTipClose = ResourceHelper.GetString(_ResourceToolTipClose);
				}
				return _toolTipClose;
			}
		}
		private static string _toolTipAutoHide = null;
		protected virtual string ToolTipAutoHide
		{
			get
			{
				if (_toolTipAutoHide == null)
				{
					_toolTipAutoHide = ResourceHelper.GetString(_ResourceToolTipAutoHide);
				}
				return _toolTipAutoHide;
			}
		}
		private static string _toolTipOptions = null;
		protected virtual string ToolTipOptions
		{
			get
			{
				if (_toolTipOptions == null)
				{
					_toolTipOptions = ResourceHelper.GetString(_ResourceToolTipOptions);
				}
				return _toolTipOptions;
			}
		}

		protected virtual Color ActiveBackColor
		{
			get
			{
				return Color.FromArgb(59, 128, 237);
			}
		}
		protected virtual Color InactiveBackColor
		{
			get
			{
				return Color.FromArgb(204, 199, 186);
			}
		}
		protected virtual Color ActiveTextColor
		{
			get
			{
				return SystemColors.ActiveCaptionText;
			}
		}
		protected virtual Color InactiveTextColor
		{
			get
			{
				return SystemColors.ControlText;
			}
		}
		protected virtual Color InactiveBorderColor
		{
			get
			{
				return SystemColors.GrayText;
			}
		}
		protected virtual Color ActiveButtonBorderColor
		{
			get
			{
				return Color.FromArgb(60, 90, 170);
			}
		}
		protected virtual Color InactiveButtonBorderColor
		{
			get
			{
				return Color.FromArgb(140, 134, 123);
			}
		}
		private static StringFormat _textStringFormat = null;
		protected virtual StringFormat TextStringFormat
		{
			get
			{
				if (_textStringFormat == null)
				{
					_textStringFormat = new StringFormat();
					_textStringFormat.Trimming = StringTrimming.EllipsisCharacter;
					_textStringFormat.LineAlignment = StringAlignment.Center;
					_textStringFormat.FormatFlags = StringFormatFlags.NoWrap;
				}
				return _textStringFormat;
			}
		}
#endregion
		protected override int MeasureHeight()
		{
			int height = Font.Height + TextGapTop + TextGapBottom;
			if (height < (ImageCloseEnabled.Height + ButtonGapTop + ButtonGapBottom))
			{
				height = ImageCloseEnabled.Height + ButtonGapTop + ButtonGapBottom;
			}
			return height;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (DockPane.IsActivated)
			{
				using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(59, 128, 237), Color.FromArgb(49, 106, 197), LinearGradientMode.Vertical))
				{
					e.Graphics.FillRectangle(brush, ClientRectangle);
				}
			}
			DrawCaption(e.Graphics);
		}
		private void DrawCaption(Graphics g)
		{
			if (DockPane.IsActivated)
			{
				BackColor = ActiveBackColor;
			}
			else
			{
				BackColor = InactiveBackColor;
			}

			Rectangle rectCaption = ClientRectangle;
			if (! DockPane.IsActivated)
			{
				using (Pen pen = new Pen(InactiveBorderColor))
				{
					g.DrawLine(pen, rectCaption.X + 1, rectCaption.Y, rectCaption.X + rectCaption.Width - 2, rectCaption.Y);
					g.DrawLine(pen, rectCaption.X + 1, rectCaption.Y + rectCaption.Height - 1, rectCaption.X + rectCaption.Width - 2, rectCaption.Y + rectCaption.Height - 1);
					g.DrawLine(pen, rectCaption.X, rectCaption.Y + 1, rectCaption.X, rectCaption.Y + rectCaption.Height - 2);
					g.DrawLine(pen, rectCaption.X + rectCaption.Width - 1, rectCaption.Y + 1, rectCaption.X + rectCaption.Width - 1, rectCaption.Y + rectCaption.Height - 2);
				}
			}

			Rectangle rectCaptionText = rectCaption;
			rectCaptionText.X += TextGapLeft;
			rectCaptionText.Width = rectCaption.Width - ButtonGapRight - ButtonGapLeft - ButtonGapBetween - 3 * m_buttonClose.Width - TextGapLeft - TextGapRight;
			rectCaptionText.Y += TextGapTop;
			rectCaptionText.Height -= TextGapTop + TextGapBottom;

			Brush brush = null;
			if (DockPane.IsActivated)
			{
				brush = new SolidBrush(ActiveTextColor);
			}
			else
			{
				brush = new SolidBrush(InactiveTextColor);
			}
			using (brush)
			{
				g.DrawString(DockPane.CaptionText, Font, brush, rectCaptionText, TextStringFormat);
			}

		}
		protected override void OnLayout(LayoutEventArgs levent)
		{
			// set the size and location for close and auto-hide buttons
			Rectangle rectCaption = ClientRectangle;
			int buttonWidth = ImageCloseEnabled.Width;
			int buttonHeight = ImageCloseEnabled.Height;
			int height = rectCaption.Height - ButtonGapTop - ButtonGapBottom;
			if (buttonHeight < height)
			{
				buttonWidth = System.Convert.ToInt32(buttonWidth * (height / buttonHeight));
				buttonHeight = height;
			}

			m_buttonClose.SuspendLayout();
			m_buttonAutoHide.SuspendLayout();
			m_buttonOptions.SuspendLayout();

			Size buttonSize = new Size(buttonWidth, buttonHeight);
			m_buttonAutoHide.Size = buttonSize;
			m_buttonClose.Size = buttonSize;
			m_buttonOptions.Size = buttonSize;

			int x = rectCaption.X + rectCaption.Width - 1 - ButtonGapRight - m_buttonClose.Width;
			int y = rectCaption.Y + ButtonGapTop;
			Point point = new Point(x, y);
			m_buttonClose.Location = point;
			point.Offset(-(m_buttonAutoHide.Width + ButtonGapBetween), 0);
			m_buttonAutoHide.Location = point;
			point.Offset(-(m_buttonOptions.Width + ButtonGapBetween), 0);
			m_buttonOptions.Location = point;

			m_buttonClose.ResumeLayout();
			m_buttonAutoHide.ResumeLayout();
			m_buttonOptions.ResumeLayout();
			base.OnLayout(levent);
		}
		protected override void OnRefreshChanges()
		{
			SetButtons();
			Invalidate();
		}

		private ContextMenuStrip m_contextmenu;
        private void SetButtons()
        {
            if (DockPane.ActiveContent != null)
            {
                m_buttonClose.Enabled = DockPane.ActiveContent.DockHandler.CloseButton;
                m_contextmenu = DockPane.ActiveContent.DockHandler.TabPageContextMenuStrip;
                if (m_contextmenu != null)
                {
                    m_buttonOptions.Visible = true;
                    if (m_buttonOptions.ToolTipText == "")
                    {
                        m_buttonOptions.ToolTipText = m_contextmenu.Text;
                    }
                }
                else
                {
                    m_buttonOptions.Visible = false;
                }
            }
            else
            {
                m_buttonClose.Enabled = false;
            }

            m_buttonAutoHide.Visible = !DockPane.IsFloat;
            if (DockPane.IsAutoHide)
            {
                m_buttonAutoHide.ImageEnabled = ImageAutoHideYes;
            }
            else
            {
                m_buttonAutoHide.ImageEnabled = ImageAutoHideNo;
            }

            m_buttonAutoHide.IsActivated = DockPane.IsActivated;
            m_buttonClose.IsActivated = DockPane.IsActivated;
            m_buttonOptions.IsActivated = DockPane.IsActivated;

            if (DockPane.IsActivated)
            {
                m_buttonAutoHide.ForeColor = ActiveTextColor;
                m_buttonAutoHide.BorderColor = ActiveButtonBorderColor;
            }
            else
            {
                m_buttonAutoHide.ForeColor = InactiveTextColor;
                m_buttonAutoHide.BorderColor = InactiveButtonBorderColor;
            }

            m_buttonClose.ForeColor = m_buttonAutoHide.ForeColor;
            m_buttonClose.BorderColor = m_buttonAutoHide.BorderColor;
            m_buttonOptions.ForeColor = m_buttonAutoHide.ForeColor;
            m_buttonOptions.BorderColor = m_buttonAutoHide.BorderColor;

        }
        private void Close_Click(object sender, EventArgs e)
        {
            DockPane.CloseActiveContent();
        }
        private void AutoHide_Click(object sender, EventArgs e)
        {
            DockPane.DockState = DockHelper.ToggleAutoHideState(DockPane.DockState);
            if (!DockPane.IsAutoHide)
            {
                DockPane.Activate();
            }
        }
        private void Options_Click(object sender, EventArgs e)
        {
            if (m_contextmenu != null)
            {
                int x = 0;
                int y = m_buttonOptions.Location.Y + m_buttonOptions.Height;
                m_contextmenu.Show(m_buttonOptions, new Point(x, y));
            }
        }
    }
}
