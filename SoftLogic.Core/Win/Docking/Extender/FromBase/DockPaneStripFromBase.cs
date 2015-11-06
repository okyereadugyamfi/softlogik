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
using System.Windows.Forms;
using System.ComponentModel;
using WeifenLuo.WinFormsUI;

namespace SoftLogik.Win.UI.Docking
{

    [ToolboxItem(false)]
    public class DockPaneStripFromBase : DockPaneStripBase
    {

        #region Private Consts
        private const int _ToolWindowStripGapLeft = 4;
        private const int _ToolWindowStripGapRight = 3;
        private const int _ToolWindowImageHeight = 16;
        private const int _ToolWindowImageWidth = 16;
        private const int _ToolWindowImageGapTop = 2;
        private const int _ToolWindowImageGapBottom = 1;
        private const int _ToolWindowImageGapLeft = 5;
        private const int _ToolWindowImageGapRight = 2;
        private const int _ToolWindowTextGapRight = 1;
        private const int _ToolWindowTabSeperatorGapTop = 3;
        private const int _ToolWindowTabSeperatorGapBottom = 3;
        private const int _DocumentToolWindowTabMinHeight = 24;
        private const int _DocumentTabMinHeight = 20;
        private const int _DocumentTabMaxWidth = 200;
        private const int _DocumentButtonGapTop = 3;
        private const int _DocumentButtonGapBottom = 4;
        private const int _DocumentButtonGapBetween = 5;
        private const int _DocumentButtonGapRight = 3;
        private const int _DocumentTabGapTop = 3;
        private const int _DocumentTabGapLeft = 3;
        private const int _DocumentTabGapRight = 1;
        private const int _DocumentTabOverlap = 14;
        private const int _DocumentTextExtraHeight = 3;
        private const int _DocumentTextExtraWidth = 24;
        private const int _DocumentIconGapLeft = 6;
        private const int _DocumentIconHeight = 14;
        private const int _DocumentIconWidth = 15;
        private const string _ResourceImageCloseEnabled = "DockPaneStrip.CloseEnabled.bmp";
        private const string _ResourceImageCloseDisabled = "DockPaneStrip.CloseDisabled.bmp";
        private const string _ResourceImageOptionsEnabled = "DockPaneStrip.OptionsEnabled.bmp";
        private const string _ResourceImageOptionsDisabled = "DockPaneStrip.OptionsDisabled.bmp";
        private const string _ResourceImageOverflowEnabled = "DockPaneStrip.OverflowEnabled.bmp";
        private const string _ResourceImageOverflowDisabled = "DockPaneStrip.OverflowDisabled.bmp";
        private const string _ResourceToolTipClose = "DockPaneStrip_ToolTipClose";
        private const string _ResourceToolTipOptions = "DockPaneStrip_ToolTipOptions";

        #endregion

        #region Private Variables
        private int m_offsetX = 0;
        private PopupButton m_buttonClose;
        private PopupButton m_buttonOptions;
        private IContainer m_components;
        private ToolTip m_toolTip;
        #endregion

        #region Customizable Properties
        protected virtual int ToolWindowStripGapLeft
        {
            get
            {
                return _ToolWindowStripGapLeft;
            }
        }
        protected virtual int ToolWindowStripGapRight
        {
            get
            {
                return _ToolWindowStripGapRight;
            }
        }
        protected virtual int ToolWindowImageHeight
        {
            get
            {
                return _ToolWindowImageHeight;
            }
        }
        protected virtual int ToolWindowImageWidth
        {
            get
            {
                return _ToolWindowImageWidth;
            }
        }
        protected virtual int ToolWindowImageGapTop
        {
            get
            {
                return _ToolWindowImageGapTop;
            }
        }
        protected virtual int ToolWindowImageGapBottom
        {
            get
            {
                return _ToolWindowImageGapBottom;
            }
        }
        protected virtual int ToolWindowImageGapLeft
        {
            get
            {
                return _ToolWindowImageGapLeft;
            }
        }
        protected virtual int ToolWindowImageGapRight
        {
            get
            {
                return _ToolWindowImageGapRight;
            }
        }
        protected virtual int ToolWindowTextGapRight
        {
            get
            {
                return _ToolWindowTextGapRight;
            }
        }
        protected virtual int ToolWindowTabSeperatorGapTop
        {
            get
            {
                return _ToolWindowTabSeperatorGapTop;
            }
        }
        protected virtual int ToolWindowTabSeperatorGapBottom
        {
            get
            {
                return _ToolWindowTabSeperatorGapBottom;
            }
        }
        private static Image _imageCloseEnabled = null;
        protected virtual Image ImageCloseEnabled
        {
            get
            {
                if (_imageCloseEnabled == null)
                {
                    _imageCloseEnabled = Properties.Resources.DockPaneStrip_CloseEnabled;  //ResourceHelper.LoadExtenderBitmap(_ResourceImageCloseEnabled);
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
                    _imageCloseDisabled = Properties.Resources.DockPaneStrip_CloseDisabled;  //ResourceHelper.LoadExtenderBitmap(_ResourceImageCloseDisabled);
                }
                return _imageCloseDisabled;
            }
        }
        private static Image _imageOptionsEnabled = null;
        protected virtual Image ImageOptionsEnabled
        {
            get
            {
                if (_imageOptionsEnabled == null)
                {
                    _imageOptionsEnabled = Properties.Resources.DockPaneStrip_OptionsEnabled;  //ResourceHelper.LoadExtenderBitmap(_ResourceImageOptionsEnabled);
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
                    _imageOptionsDisabled = Properties.Resources.DockPaneStrip_OptionsDisabled;  //ResourceHelper.LoadExtenderBitmap(_ResourceImageOptionsDisabled);
                }
                return _imageOptionsDisabled;
            }
        }
        private static Image _imageOverflowEnabled = null;
        protected virtual Image ImageOverflowEnabled
        {
            get
            {
                if (_imageOverflowEnabled == null)
                {
                    _imageOverflowEnabled = Properties.Resources.DockPaneStrip_OverflowEnabled;  //ResourceHelper.LoadExtenderBitmap(_ResourceImageOverflowEnabled);
                }
                return _imageOverflowEnabled;
            }
        }
        private static Image _imageOverflowDisabled = null;
        protected virtual Image ImageOverflowDisabled
        {
            get
            {
                if (_imageOverflowDisabled == null)
                {
                    _imageOverflowDisabled = Properties.Resources.DockPaneStrip_OverflowDisabled ;  //ResourceHelper.LoadExtenderBitmap(_ResourceImageOverflowDisabled);
                }
                return _imageOverflowDisabled;
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

        private static StringFormat _toolWindowTextStringFormat = null;
        protected virtual StringFormat ToolWindowTextStringFormat
        {
            get
            {
                if (_toolWindowTextStringFormat == null)
                {
                    _toolWindowTextStringFormat = new StringFormat(StringFormat.GenericTypographic);
                    _toolWindowTextStringFormat.Trimming = StringTrimming.EllipsisCharacter;
                    _toolWindowTextStringFormat.LineAlignment = StringAlignment.Center;
                    _toolWindowTextStringFormat.FormatFlags = StringFormatFlags.NoWrap;
                }
                return _toolWindowTextStringFormat;
            }
        }
        private static StringFormat _documentTextStringFormat = null;
        public static StringFormat DocumentTextStringFormat
        {
            get
            {
                if (_documentTextStringFormat == null)
                {
                    _documentTextStringFormat = new StringFormat(StringFormat.GenericTypographic);
                    _documentTextStringFormat.Alignment = StringAlignment.Center;
                    _documentTextStringFormat.Trimming = StringTrimming.EllipsisPath;
                    _documentTextStringFormat.LineAlignment = StringAlignment.Center;
                    _documentTextStringFormat.FormatFlags = StringFormatFlags.NoWrap;
                }
                return _documentTextStringFormat;
            }
        }
        protected virtual int DocumentToolWindowTabMinHeight
        {
            get
            {
                return _DocumentToolWindowTabMinHeight;
            }
        }
        protected virtual int DocumentTabMinHeight
        {
            get
            {
                return _DocumentTabMinHeight;
            }
        }
        protected virtual int DocumentTabMaxWidth
        {
            get
            {
                return _DocumentTabMaxWidth;
            }
        }
        protected virtual int DocumentButtonGapTop
        {
            get
            {
                return _DocumentButtonGapTop;
            }
        }
        protected virtual int DocumentButtonGapBottom
        {
            get
            {
                return _DocumentButtonGapBottom;
            }
        }
        protected virtual int DocumentButtonGapBetween
        {
            get
            {
                return _DocumentButtonGapBetween;
            }
        }
        protected virtual int DocumentButtonGapRight
        {
            get
            {
                return _DocumentButtonGapRight;
            }
        }
        protected virtual int DocumentTabGapTop
        {
            get
            {
                return _DocumentTabGapTop;
            }
        }
        protected virtual int DocumentTabGapLeft
        {
            get
            {
                return _DocumentTabGapLeft;
            }
        }
        protected virtual int DocumentTabGapRight
        {
            get
            {
                return _DocumentTabGapRight;
            }
        }
        protected virtual int DocumentTextExtraHeight
        {
            get
            {
                return _DocumentTextExtraHeight;
            }
        }
        protected virtual int DocumentTextExtraWidth
        {
            get
            {
                return _DocumentTextExtraWidth;
            }
        }
        protected virtual int DocumentIconGapLeft
        {
            get
            {
                return _DocumentIconGapLeft;
            }
        }
        protected virtual int DocumentIconWidth
        {
            get
            {
                return _DocumentIconWidth;
            }
        }
        protected virtual int DocumentIconHeight
        {
            get
            {
                return _DocumentIconHeight;
            }
        }
        protected virtual void OnBeginDrawTabStrip(DockPane.AppearanceStyle appearance)
        {
        }
        protected virtual void OnEndDrawTabStrip(DockPane.AppearanceStyle appearance)
        {
        }
        protected virtual void OnBeginDrawTab(DockPane.AppearanceStyle appearance)
        {
        }
        protected virtual void OnEndDrawTab(DockPane.AppearanceStyle appearance)
        {
        }
        protected virtual Pen OutlineInnerPen
        {
            get
            {
                return SystemPens.ControlText;
            }
        }
        protected virtual Pen OutlineOuterPen
        {
            get
            {
                return new Pen(Color.FromArgb(127, 157, 185));
            }
        }
        protected virtual Brush ActiveBackBrush
        {
            get
            {
                return SystemBrushes.Control;
            }
        }
        protected virtual Brush ActiveTextBrush
        {
            get
            {
                return SystemBrushes.ControlText;
            }
        }
        protected virtual Pen TabSeperatorPen
        {
            get
            {
                return SystemPens.GrayText;
            }
        }
        protected virtual Brush InactiveTextBrush
        {
            get
            {
                return SystemBrushes.FromSystemColor(SystemColors.ControlDarkDark);
            }
        }
        #endregion

        #region new + Dispose Methods
        protected internal DockPaneStripFromBase(DockPane pane)
            : base(pane)
        {

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            SuspendLayout();
            Font = SystemInformation.MenuFont;
            BackColor = Color.FromArgb(228, 226, 213);

            m_components = new Container();
            m_toolTip = new ToolTip(Components);

            m_buttonClose = new PopupButton(ImageCloseEnabled, ImageCloseDisabled);
            m_buttonClose.IsActivated = true;
            m_buttonClose.ActiveBackColorGradientBegin = Color.FromArgb(228, 226, 213);
            m_buttonClose.ActiveBackColorGradientEnd = Color.FromArgb(228, 226, 213);
            m_buttonClose.ToolTipText = ToolTipClose;
            m_buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            m_buttonOptions = new PopupButton(ImageOptionsEnabled, ImageOptionsDisabled);
            m_buttonOptions.IsActivated = true;
            m_buttonOptions.ActiveBackColorGradientBegin = Color.FromArgb(228, 226, 213);
            m_buttonOptions.ActiveBackColorGradientEnd = Color.FromArgb(228, 226, 213);
            m_buttonOptions.ToolTipText = ToolTipOptions;
            m_buttonOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            m_buttonClose.Click += new System.EventHandler(Close_Click);
            m_buttonOptions.Click += new System.EventHandler(Options_Click);
            Controls.AddRange(new Control[] { m_buttonClose, m_buttonOptions });
            ResumeLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region (Measure Height) Private Methods
        protected override int MeasureHeight()
        {
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.ToolWindow)
            {
                return MeasureHeight_ToolWindow();
            }
            else
            {
                return MeasureHeight_Document();
            }
        }

        private int MeasureHeight_ToolWindow()
        {
            if (DockPane.IsAutoHide || Tabs.Count <= 1)
            {
                return 0;
            }
            int height = Math.Max(Font.Height, ToolWindowImageHeight) + ToolWindowImageGapTop + ToolWindowImageGapBottom;
            if (height < DocumentToolWindowTabMinHeight)
            {
                height = DocumentToolWindowTabMinHeight;
            }
            return height;
        }

        private int MeasureHeight_Document()
        {
            int height = Math.Max(Font.Height + DocumentTabGapTop + DocumentTextExtraHeight, ImageCloseEnabled.Height + DocumentButtonGapTop + DocumentButtonGapBottom);
            if (height < DocumentTabMinHeight)
            {
                height = DocumentTabMinHeight;
            }
            return height;
        }

        #endregion

        #region (OnPaint + OnRefreshChanges) Protected Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = TabsRectangle;
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.Document)
            {
                rect.X -= DocumentTabGapLeft;
                rect.Width += DocumentTabGapLeft;
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(228, 226, 213), Color.FromArgb(228, 226, 213), LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(231, 231, 218), Color.FromArgb(231, 231, 218), LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            DrawTabStrip(e.Graphics);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            int count = Tabs.Count;
            Rectangle tabrect = TabsRectangle;

            // Resize to a bigger window
            if (count > 1)
            {
                if (OffsetX < 0 && GetTabRectangle(count - 1).Right < tabrect.Right)
                {
                    OffsetX += (tabrect.Right - GetTabRectangle(count - 1).Right);
                    if (DockPane.DockPanel.ShowDocumentIcon)
                    {
                        OffsetX += DocumentIconWidth;
                    }
                    if (OffsetX > 0)
                    {
                        OffsetX = 0;
                    }
                    OnRefreshChanges();
                }
            }

            //Resize to a smaller window
            IDockContent content = null;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of count for every iteration:
            int tempFor1 = count;
            for (int i = 0; i < tempFor1; i++)
            {
                content = Tabs[i].Content;
                if (content == DockPane.ActiveContent)
                {
                    if (!(tabrect.Contains(GetTabRectangle(i))))
                    {
                        EnsureTabVisible(content);
                    }
                }
            }

        }

        protected override void OnRefreshChanges()
        {
            CalculateTabs();
            SetInertButtons();
            Invalidate();
        }
        #endregion
        #region (GetOutlinePath) Private Method
        protected override GraphicsPath GetOutlinePath(int index)
        {
            Point[] pts = new Point[8];
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.Document)
            {
                Rectangle rectTab = GetTabRectangle(index);
                rectTab.Intersect(TabsRectangle);
                int y = DockPane.PointToClient(PointToScreen(new Point(0, rectTab.Bottom))).Y;
                Rectangle rectPaneClient = DockPane.ClientRectangle;
                pts[0] = DockPane.PointToScreen(new Point(rectPaneClient.Left, y));
                pts[1] = PointToScreen(new Point(rectTab.Left, rectTab.Bottom));
                pts[2] = PointToScreen(new Point(rectTab.Left, rectTab.Top));
                pts[3] = PointToScreen(new Point(rectTab.Right + _DocumentTabOverlap, rectTab.Top));
                pts[4] = PointToScreen(new Point(rectTab.Right + _DocumentTabOverlap, rectTab.Bottom));
                pts[5] = DockPane.PointToScreen(new Point(rectPaneClient.Right, y));
                pts[6] = DockPane.PointToScreen(new Point(rectPaneClient.Right, rectPaneClient.Bottom));
                pts[7] = DockPane.PointToScreen(new Point(rectPaneClient.Left, rectPaneClient.Bottom));
            }
            else
            {
                Rectangle rectTab = GetTabRectangle(index);
                rectTab.Intersect(TabsRectangle);
                int y = DockPane.PointToClient(PointToScreen(new Point(0, rectTab.Top))).Y + 1;
                Rectangle rectPaneClient = DockPane.ClientRectangle;
                pts[0] = DockPane.PointToScreen(new Point(rectPaneClient.Left, rectPaneClient.Top));
                pts[1] = DockPane.PointToScreen(new Point(rectPaneClient.Right, rectPaneClient.Top));
                pts[2] = DockPane.PointToScreen(new Point(rectPaneClient.Right, y));
                pts[3] = PointToScreen(new Point(rectTab.Right + 1, rectTab.Top));
                pts[4] = PointToScreen(new Point(rectTab.Right + 1, rectTab.Bottom));
                pts[5] = PointToScreen(new Point(rectTab.Left + 1, rectTab.Bottom));
                pts[6] = PointToScreen(new Point(rectTab.Left + 1, rectTab.Top));
                pts[7] = DockPane.PointToScreen(new Point(rectPaneClient.Left, y));
            }
            GraphicsPath path = new GraphicsPath();
            path.AddLines(pts);
            return path;
        }
        #endregion

        #region (Calculate Tabs) Private Methods
        private void CalculateTabs()
        {
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.ToolWindow)
            {
                CalculateTabs_ToolWindow();
            }
            else
            {
                CalculateTabs_Document();
            }
        }

        private void CalculateTabs_ToolWindow()
        {
            if (Tabs.Count <= 1 || DockPane.IsAutoHide)
            {
                return;
            }
            Rectangle rectTabStrip = ClientRectangle;
            // Calculate tab widths
            int countTabs = Tabs.Count;
            foreach (DockPaneTabFromBase tab in Tabs)
            {
                tab.MaxWidth = GetTabOriginalWidth(Tabs.IndexOf(tab));
                tab.Flag = false;
            }
            // Set tab whose max width less than average width
            bool anyWidthWithinAverage = true;
            int totalWidth = rectTabStrip.Width - ToolWindowStripGapLeft - ToolWindowStripGapRight;
            int totalAllocatedWidth = 0;
            int averageWidth = (int)System.Math.Floor((double)totalWidth / countTabs);
            int remainedTabs = countTabs;
            anyWidthWithinAverage = true;
            while (anyWidthWithinAverage && remainedTabs > 0)
            {
                anyWidthWithinAverage = false;
                foreach (DockPaneTabFromBase tab in Tabs)
                {
                    if (tab.Flag)
                    {
                        continue;
                    }
                    if (tab.MaxWidth <= averageWidth)
                    {
                        tab.Flag = true;
                        tab.TabWidth = tab.MaxWidth;
                        totalAllocatedWidth += tab.TabWidth;
                        anyWidthWithinAverage = true;
                        remainedTabs -= 1;
                    }
                }
                if (remainedTabs != 0)
                {
                    averageWidth = (int)System.Math.Floor(((double)totalWidth - totalAllocatedWidth) / remainedTabs);
                }
            }
            // If any tab width not set yet, set it to the average width
            if (remainedTabs > 0)
            {
                int roundUpWidth = (totalWidth - totalAllocatedWidth) - (averageWidth * remainedTabs);
                foreach (DockPaneTabFromBase tab in Tabs)
                {
                    if (tab.Flag)
                    {
                        continue;
                    }
                    tab.Flag = true;
                    if (roundUpWidth > 0)
                    {
                        tab.TabWidth = averageWidth + 1;
                        roundUpWidth -= 1;
                    }
                    else
                    {
                        tab.TabWidth = averageWidth;
                    }
                }
            }
       }


        private void CalculateTabs_Document()
        {
            int countTabs = Tabs.Count;
            if (countTabs == 0)
            {
                return;
            }
            Rectangle rectTabStrip = ClientRectangle;
            int x = rectTabStrip.X + DocumentTabGapLeft + OffsetX;
            foreach (DockPaneTabFromBase tab in Tabs)
            {
                tab.TabX = x;
                tab.TabWidth = Math.Min(GetTabOriginalWidth(Tabs.IndexOf(tab)), DocumentTabMaxWidth);
                x += tab.TabWidth;
            }
        }
        #endregion

        #region (GetTabOriginalWidth) Private Methods
        protected virtual int GetTabOriginalWidth(int index)
        {
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.ToolWindow)
            {
                return GetTabOriginalWidth_ToolWindow(index);
            }
            else
            {
                return GetTabOriginalWidth_Document(index);
            }
        }

        private int GetTabOriginalWidth_ToolWindow(int index)
        {
            IDockContent content = Tabs[index].Content;
            using (Graphics g = CreateGraphics())
            {
                SizeF sizeString = g.MeasureString(content.DockHandler.TabText, Font);
                return ToolWindowImageWidth + System.Convert.ToInt32(sizeString.Width) + 1 + ToolWindowImageGapLeft + ToolWindowImageGapRight + ToolWindowTextGapRight;
            }
        }

        private int GetTabOriginalWidth_Document(int index)
        {
            IDockContent content = Tabs[index].Content;
            using (Graphics g = CreateGraphics())
            {
                SizeF sizeText = new SizeF();
                //If content Is DockPane.ActiveContent AndAlso DockPane.IsActiveDocumentPane Then
                using (Font boldFont = new Font(this.Font, FontStyle.Bold))
                {
                    sizeText = g.MeasureString(content.DockHandler.TabText, boldFont, DocumentTabMaxWidth, DocumentTextStringFormat);
                }
                //Else
                //    sizeText = g.MeasureString(content.DockHandler.TabText, Font, DocumentTabMaxWidth, DocumentTextStringFormat)
                //End If
                if (DockPane.DockPanel.ShowDocumentIcon)
                {
                    return System.Convert.ToInt32(sizeText.Width) + 1 + DocumentTextExtraWidth + DocumentIconWidth + DocumentIconGapLeft;
                }
                else
                {
                    return System.Convert.ToInt32(sizeText.Width) + 1 + DocumentTextExtraWidth;
                }

            }
        }

        #endregion

        #region (DrawTabStrip) Private Methods
        protected virtual void DrawTabStrip(Graphics g)
        {
            OnBeginDrawTabStrip(Appearance);
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.Document)
            {
                DrawTabStrip_Document(g);
            }
            else
            {
                DrawTabStrip_ToolWindow(g);
            }
            OnEndDrawTabStrip(Appearance);
        }

        private void DrawTabStrip_Document(Graphics g)
        {
            int count = Tabs.Count;
            if (count == 0)
            {
                return;
            }

            g.DrawLine(OutlineOuterPen, ClientRectangle.Left, ClientRectangle.Bottom - 1, ClientRectangle.Right, ClientRectangle.Bottom - 1);

            // Draw the tabs
            Rectangle rectTabs = TabsRectangle;
            Rectangle rectTab = Rectangle.Empty;
            g.SetClip(rectTabs, CombineMode.Replace);

            int j = 0;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of count for every iteration:
            int tempFor1 = count;
            for (int i = 0; i < tempFor1; i++)
            {
                rectTab = GetTabRectangle(i);
                if (rectTab.IntersectsWith(rectTabs))
                {
                    DrawTab(g, Tabs[i].Content, rectTab, j);
                    j = j + 1;
                }
            }
        }

        private void DrawTabStrip_ToolWindow(Graphics g)
        {

            // TODO: Clean up and add properties for colors
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Tabs.Count for every iteration:
            int tempFor1 = Tabs.Count;
            for (int i = 0; i < tempFor1; i++)
            {
                Rectangle tabrect = GetTabRectangle(i);
                Rectangle rectIcon = new Rectangle(tabrect.X + ToolWindowImageGapLeft, tabrect.Y + tabrect.Height - 1 - ToolWindowImageGapBottom - ToolWindowImageHeight, ToolWindowImageWidth, ToolWindowImageHeight);
                Rectangle rectText = rectIcon;

                rectText.X += rectIcon.Width + ToolWindowImageGapRight;
                rectText.Width = tabrect.Width - rectIcon.Width - ToolWindowImageGapLeft - ToolWindowImageGapRight - ToolWindowTextGapRight;

                if (DockPane.ActiveContent == Tabs[i].Content)
                {

                    // color area as the tab
                    g.FillRectangle(new SolidBrush(Color.FromArgb(252, 252, 254)), ClientRectangle.X, ClientRectangle.Y - 1, ClientRectangle.Width - 1, tabrect.Y + 2);

                    DrawHelper.DrawTab(g, tabrect, Corners.Bottom, GradientType.Flat, Color.FromArgb(252, 252, 254), Color.FromArgb(252, 252, 254), Color.FromArgb(172, 168, 153), false);

                    // line to the left
                    g.DrawLine(TabSeperatorPen, tabrect.X, tabrect.Y + 1, ClientRectangle.X, tabrect.Y + 1);

                    // line to the right
                    g.DrawLine(TabSeperatorPen, tabrect.X + tabrect.Width, tabrect.Y + 1, ClientRectangle.Width, tabrect.Y + 1);

                    // text
                    g.DrawString(Tabs[i].Content.DockHandler.TabText, Font, new SolidBrush(Color.Black), rectText, ToolWindowTextStringFormat);

                }
                else
                {
                    if (Tabs.IndexOf(DockPane.ActiveContent) != Tabs.IndexOf(Tabs[i].Content) + 1 && Tabs.IndexOf(Tabs[i].Content) != Tabs.Count - 1)
                    {
                        g.DrawLine(TabSeperatorPen, tabrect.X + tabrect.Width - 1, tabrect.Y + ToolWindowTabSeperatorGapTop, tabrect.X + tabrect.Width - 1, tabrect.Y + tabrect.Height - 1 - ToolWindowTabSeperatorGapBottom);
                    }
                    g.DrawString(Tabs[i].Content.DockHandler.TabText, Font, InactiveTextBrush, rectText, ToolWindowTextStringFormat);
                }

                if (tabrect.Contains(rectIcon))
                {
                    g.DrawIcon(Tabs[i].Content.DockHandler.Icon, rectIcon);
                }
            }
        }
        #endregion

        #region (GetTabRectangle) Private Methods
        protected virtual Rectangle GetTabRectangle(int index)
        {
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.ToolWindow)
            {
                return GetTabRectangle_ToolWindow(index);
            }
            else
            {
                return GetTabRectangle_Document(index);
            }
        }

        private Rectangle GetTabRectangle_ToolWindow(int index)
        {
            Rectangle rectTabStrip = ClientRectangle;
            DockPaneTabFromBase tab = (DockPaneTabFromBase)((Tabs[index]));
            return new Rectangle(tab.TabX, rectTabStrip.Y + 2, tab.TabWidth, rectTabStrip.Height - 3);
        }

        private Rectangle GetTabRectangle_Document(int index)
        {
            Rectangle rectTabStrip = ClientRectangle;
            DockPaneTabFromBase tab = (DockPaneTabFromBase)(Tabs[index]);
            return new Rectangle(tab.TabX, rectTabStrip.Y + DocumentTabGapTop, tab.TabWidth, rectTabStrip.Height - DocumentTabGapTop);
        }
        #endregion

        #region (DrawTab) Private Methods
        private void DrawTab(Graphics g, IDockContent content, Rectangle rect, int index)
        {
            OnBeginDrawTab(Appearance);
            if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.ToolWindow)
            {
                DrawTab_ToolWindow(g, content, rect, index);
            }
            else
            {
                DrawTab_Document(g, content, rect, index);
            }
            OnEndDrawTab(Appearance);
        }

        private void DrawTab_ToolWindow(Graphics g, IDockContent content, Rectangle rect, int index)
        {
            Rectangle rectIcon = new Rectangle(rect.X + ToolWindowImageGapLeft, rect.Y + rect.Height - 1 - ToolWindowImageGapBottom - ToolWindowImageHeight, ToolWindowImageWidth, ToolWindowImageHeight);
            Rectangle rectText = rectIcon;
            rectText.X += rectIcon.Width + ToolWindowImageGapRight;
            rectText.Width = rect.Width - rectIcon.Width - ToolWindowImageGapLeft - ToolWindowImageGapRight - ToolWindowTextGapRight;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (DockPane.ActiveContent == content)
            {
                DrawHelper.DrawTab(g, rect, Corners.Bottom, GradientType.Flat, Color.LightBlue, Color.WhiteSmoke, Color.Gray, false);
                g.DrawString(content.DockHandler.TabText, Font, ActiveTextBrush, rectText, ToolWindowTextStringFormat);
            }
            else
            {
                if (Tabs.IndexOf(DockPane.ActiveContent) != Tabs.IndexOf(content) + 1)
                {
                    g.DrawLine(TabSeperatorPen, rect.X + rect.Width - 1, rect.Y + ToolWindowTabSeperatorGapTop, rect.X + rect.Width - 1, rect.Y + rect.Height - 1 - ToolWindowTabSeperatorGapBottom);
                }
                g.DrawString(content.DockHandler.TabText, Font, InactiveTextBrush, rectText, ToolWindowTextStringFormat);
            }
            if (rect.Contains(rectIcon))
            {
                g.DrawIcon(content.DockHandler.Icon, rectIcon);
            }
        }

        private void DrawTab_Document(Graphics g, IDockContent content, Rectangle rect, int index)
        {
            Rectangle rectText = rect;
            //INSTANT C# NOTE: The VB integer division operator \ was replaced 1 time(s) by the regular division operator /
            rectText.X += (int)System.Math.Floor((double)DocumentTextExtraWidth / 2);
            rectText.Width -= DocumentTextExtraWidth;
            rectText.X += _DocumentTabOverlap;

            if (index == 0)
            {
                rect.Width += _DocumentTabOverlap;
            }
            else
            {
                rect.X += _DocumentTabOverlap;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (DockPane.ActiveContent == content)
            {

                if (index == 0)
                {
                    if (DockPane.DockPanel.ShowDocumentIcon)
                    {
                        rectText.X += DocumentIconGapLeft;
                        rectText.Width -= DocumentIconGapLeft;
                    }
                }
                else
                {
                    rect.X -= _DocumentTabOverlap;
                    rect.Width += _DocumentTabOverlap;
                    if (DockPane.DockPanel.ShowDocumentIcon)
                    {
                        rectText.X += DocumentIconGapLeft;
                        rectText.Width -= DocumentIconGapLeft;
                    }
                }

                // Draw Tab & Text
                DrawHelper.DrawDocumentTab(g, rect, Color.White, Color.White, Color.FromArgb(127, 157, 185), TabDrawType.Active, true);
                if (DockPane.IsActiveDocumentPane)
                {
                    using (Font boldFont = new Font(this.Font, FontStyle.Bold))
                    {
                        g.DrawString(content.DockHandler.TabText, boldFont, ActiveTextBrush, rectText, DocumentTextStringFormat);
                    }
                }
                else
                {
                    g.DrawString(content.DockHandler.TabText, Font, InactiveTextBrush, rectText, DocumentTextStringFormat);
                }

                // Draw Icon
                if (DockPane.DockPanel.ShowDocumentIcon)
                {
                    Icon icon = content.DockHandler.Icon;
                    Rectangle rectIcon = new Rectangle();
                    if (index == 0)
                    {
                        rectIcon = new Rectangle(rect.X + DocumentIconGapLeft + _DocumentTabOverlap, System.Convert.ToInt32(rectText.Y + (rect.Height - DocumentIconHeight) / 2), DocumentIconWidth, DocumentIconHeight);
                    }
                    else
                    {
                        rectIcon = new Rectangle(rect.X + DocumentIconGapLeft + _DocumentTabOverlap, System.Convert.ToInt32(rectText.Y + (rect.Height - DocumentIconHeight) / 2), DocumentIconWidth, DocumentIconHeight);
                    }
                    g.DrawIcon(content.DockHandler.Icon, rectIcon);
                }
            }
            else
            {
                if (index == 0)
                {
                    DrawHelper.DrawDocumentTab(g, rect, Color.FromArgb(254, 253, 253), Color.FromArgb(241, 239, 226), Color.FromArgb(172, 168, 153), TabDrawType.First, true);
                }
                else
                {
                    DrawHelper.DrawDocumentTab(g, rect, Color.FromArgb(254, 253, 253), Color.FromArgb(241, 239, 226), Color.FromArgb(172, 168, 153), TabDrawType.Inactive, true);
                }
                g.DrawLine(OutlineOuterPen, rect.X, ClientRectangle.Bottom - 1, rect.X + rect.Width, ClientRectangle.Bottom - 1);
                g.DrawString(content.DockHandler.TabText, Font, InactiveTextBrush, rectText, DocumentTextStringFormat);
            }

        }
        #endregion

        #region (Buttons Related) Private Methods
        private void SetInertButtons()
        {
            // Set the visibility of the inert buttons
            if (DockPane.DockState == DockState.Document)
            {
                m_buttonClose.Visible = true;
                m_buttonOptions.Visible = true;
            }
            else
            {
                m_buttonClose.Visible = false;
                m_buttonOptions.Visible = false;
            }

            // Enable/disable overflow button
            int count = Tabs.Count;
            if (count != 0)
            {
                Rectangle rectTabs = TabsRectangle;
                if (GetTabRectangle(count - 1).Right > rectTabs.Right || GetTabRectangle(0).Left < rectTabs.Left)
                {
                    m_buttonOptions.ImageEnabled = ImageOverflowEnabled;
                    m_buttonOptions.ImageDisabled = ImageOverflowDisabled;
                }
                else
                {
                    m_buttonOptions.ImageEnabled = ImageOptionsEnabled;
                    m_buttonOptions.ImageDisabled = ImageOptionsDisabled;
                }
            }

            // Enable/disable close button
            if (DockPane.ActiveContent == null)
            {
                m_buttonClose.Enabled = false;
            }
            else
            {
                m_buttonClose.Enabled = DockPane.ActiveContent.DockHandler.CloseButton;
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            Rectangle rectTabStrip = ClientRectangle;
            // Set position and size of the buttons
            int buttonWidth = ImageCloseEnabled.Width;
            int buttonHeight = ImageCloseEnabled.Height;
            int height = rectTabStrip.Height - DocumentButtonGapTop - DocumentButtonGapBottom;
            if (buttonHeight < height)
            {
                //INSTANT C# NOTE: The VB integer division operator \ was replaced 1 time(s) by the regular division operator /
                buttonWidth = buttonWidth * ((int)System.Math.Floor((double)height / buttonHeight));
                buttonHeight = height;
            }
            Size buttonSize = new Size(buttonWidth, buttonHeight);
            m_buttonClose.Size = buttonSize;
            m_buttonOptions.Size = buttonSize;
            int x = rectTabStrip.X + rectTabStrip.Width - DocumentTabGapLeft - DocumentButtonGapRight - buttonWidth;
            int y = rectTabStrip.Y + DocumentButtonGapTop;
            m_buttonClose.Location = new Point(x, y);
            Point point = m_buttonClose.Location;
            point.Offset(-(DocumentButtonGapBetween + buttonWidth), 0);
            m_buttonOptions.Location = point;
            OnRefreshChanges();
            base.OnLayout(levent);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            int i = 0;
            int width = -1;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Tabs.Count for every iteration:
            int tempFor1 = Tabs.Count;
            for (i = 0; i < tempFor1; i++)
            {
                if (Tabs[i].Content == DockPane.ActiveContent)
                {
                    width = GetTabRectangle(i).Width;
                    break;
                }
            }
            DockPane.CloseActiveContent();
            if (width > 0 && Tabs.Count > 0 && GetTabRectangle(0).X < 0)
            {
                OffsetX += Math.Min(width, Math.Abs(GetTabRectangle(0).X)) + 4;
                OnRefreshChanges();
            }
        }

        private ContextMenuStrip m_contextmenu = new ContextMenuStrip();
        private void Options_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = m_buttonOptions.Location.Y + m_buttonOptions.Height;

            m_contextmenu.Items.Clear();
            foreach (IDockContent content in DockPane.Contents)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)(m_contextmenu.Items.Add(content.DockHandler.TabText, content.DockHandler.Icon.ToBitmap()));
                item.Tag = content;
                item.Click += new System.EventHandler(MenuItem_Click);
            }
            m_contextmenu.Show(m_buttonOptions, x, y);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                IDockContent content = (WeifenLuo.WinFormsUI.IDockContent)item.Tag;
                if (content != null)
                {
                    EnsureTabVisible(content);
                    content.DockHandler.Activate();
                }
            }
        }

        protected override int GetHitTest(Point ptMouse)
        {
            Rectangle rectTabStrip = TabsRectangle;
            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of Tabs.Count for every iteration:
            int tempFor1 = Tabs.Count;
            for (int i = 0; i < tempFor1; i++)
            {
                Rectangle rectTab = GetTabRectangle(i);
                rectTab.Intersect(rectTabStrip);
                if (rectTab.Contains(ptMouse))
                {
                    return i;
                }
            }
            return -1;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int index = GetHitTest(PointToClient(Control.MousePosition));
            string toolTip = string.Empty;
            base.OnMouseMove(e);
            if (index != -1)
            {
                Rectangle rectTab = GetTabRectangle(index);
                if (Tabs[index].Content.DockHandler.ToolTipText != null)
                {
                    toolTip = Tabs[index].Content.DockHandler.ToolTipText;
                }
                else if (rectTab.Width < GetTabOriginalWidth(index))
                {
                    toolTip = Tabs[index].Content.DockHandler.TabText;
                }
            }
            if (m_toolTip.GetToolTip(this) != toolTip)
            {
                m_toolTip.Active = false;
                m_toolTip.SetToolTip(this, toolTip);
                m_toolTip.Active = true;
            }
        }
        #endregion

        #region Protected + Private Properties
        protected IContainer Components
        {
            get
            {
                return m_components;
            }
        }

        private int OffsetX
        {
            get
            {
                return m_offsetX;
            }
            set
            {
                m_offsetX = value;
            }
        }

        private Rectangle TabsRectangle
        {
            get
            {
                if (Appearance == WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.ToolWindow)
                {
                    return ClientRectangle;
                }
                Rectangle rectWindow = ClientRectangle;
                int x = rectWindow.X;
                int y = rectWindow.Y;
                int width = rectWindow.Width;
                int height = rectWindow.Height;
                x += DocumentTabGapLeft;
                width -= DocumentTabGapLeft + DocumentTabGapRight + DocumentButtonGapRight + m_buttonClose.Width * 2 + DocumentButtonGapBetween * 3;
                return new Rectangle(x, y, width, height);
            }
        }
        #endregion

        protected override void EnsureTabVisible(IDockContent content)
        {
            if (Appearance != WeifenLuo.WinFormsUI.DockPane.AppearanceStyle.Document)
            {
                return;
            }
            Rectangle rectTabStrip = TabsRectangle;
            Rectangle rectTab = GetTabRectangle(Tabs.IndexOf(content));
            if ((rectTab.Right + _DocumentTabOverlap) > rectTabStrip.Right)
            {
                OffsetX -= rectTab.Right - rectTabStrip.Right + _DocumentTabOverlap;
                rectTab.X -= rectTab.Right - rectTabStrip.Right + _DocumentTabOverlap;
            }
            if (rectTab.Left < rectTabStrip.Left)
            {
                OffsetX += rectTabStrip.Left - rectTab.Left;
            }
            OnRefreshChanges();
        }
    }
}
