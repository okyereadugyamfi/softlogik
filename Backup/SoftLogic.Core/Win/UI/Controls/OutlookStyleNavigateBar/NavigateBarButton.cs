using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;
using System.Drawing;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// NavigateBarButton for NavigateBar
    /// </summary>
    [Browsable(false)]
    [ToolboxItem(false)]
    public sealed class NavigateBarButton : UserControl
    {
        const int LIT_WIDTH = 8;

        // Delegate

        #region Delegate & Events

        public delegate void OnNavigateBarButtonSelectedEventHandler(NavigateBarButtonEventArgs e);
        public event OnNavigateBarButtonSelectedEventHandler OnNavigateBarButtonSelected;

        public delegate void OnNavigateBarButtonCaptionChangedEventHandler(string tOldCaption, string tNewCaption);
        public event OnNavigateBarButtonCaptionChangedEventHandler OnNavigateBarButtonCaptionChanged;

        public delegate void OnNavigateBarButtonCaptionDescriptionChangedEventHandler(string tOldCaptionDesc, string tNewCaptionDesc);
        public event OnNavigateBarButtonCaptionDescriptionChangedEventHandler OnNavigateBarButtonCaptionDescriptionChanged;

        public delegate void OnNavigateBarButtonDisplayChangedEventHandler(bool tOldValue, bool tNewValue);
        public event OnNavigateBarButtonDisplayChangedEventHandler OnNavigateBarButtonDisplayChanged;

        #endregion

        // Properties

        #region Image
        private Image image = null;
        /// <summary>
        /// NavigateBarButton image (24x24 recommended) (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                if (image != null)
                    disableImage = (Image)NavigateBarHelper.ConvertToGrayscale((Bitmap)image);
                Invalidate();
            }
        }
        #endregion

        #region MouseOverImage
        private Image mouseOverImage = null;
        /// <summary>
        /// NavigateBarButton mouse over image  (24x24 recommended) (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public Image MouseOverImage
        {
            get { return mouseOverImage == null ? image : mouseOverImage; }
            set
            {
                mouseOverImage = value;
                Invalidate();
            }
        }
        #endregion

        #region SelectedImage
        private Image selectedImage = null;
        /// <summary>
        /// NavigateBarButton selected image  (24x24 recommended) (Get/Set)
        /// Get / Set
        /// </summary>
        [Category("NavigateBarButton")]
        public Image SelectedImage
        {
            get
            {
                return selectedImage == null ? image : selectedImage;
            }
            set
            {
                selectedImage = value;
                Invalidate();
            }
        }
        #endregion

        #region DisableImage
        Image disableImage;
        internal Image DisableImage
        {
            get { return disableImage; }
        }
        #endregion

        #region Caption
        private string caption = "";
        private string captionOrjinal = "";
        /// <summary>
        /// NavigateBarButton caption (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public string Caption
        {
            get { return caption; }
            set
            {
                string oldCaption = caption;
                caption = value;
                captionOrjinal = value;

                Invalidate();
                if (OnNavigateBarButtonCaptionChanged != null)
                    OnNavigateBarButtonCaptionChanged(oldCaption, caption);

            }
        }
        #endregion

        #region CaptionDescription
        private string captionDesc = "";
        /// <summary>
        /// Displayed text on description band (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public string CaptionDescription
        {
            get
            {
                if (string.IsNullOrEmpty(captionDesc))
                    return captionOrjinal;
                else
                    return captionDesc;
            }
            set
            {
                string oldCaptionDesc = captionDesc;
                captionDesc = value;
                Invalidate();
                if (OnNavigateBarButtonCaptionDescriptionChanged != null)
                    OnNavigateBarButtonCaptionDescriptionChanged(oldCaptionDesc, captionDesc);
            }
        }
        #endregion

        #region Key
        string key = "";
        /// <summary>
        /// Key value for button. Key value must be uniq in collection. This value required save and restore settings.
        /// </summary>
        public string Key
        {
            get { return key; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Cannot null or empty");
                key = value;
            }
        }
        #endregion

        #region IsSelected
        private bool isSelected = false;
        /// <summary>
        /// Is selected NavigateBarButton (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (this.Enabled)
                    isSelected = value;
                else
                    isSelected = false;

                overFlowPanelButton.IsSelected = value;
                Invalidate();
            }
        }

        #endregion

        #region IsDisplayed
        private bool isDisplayed = true;
        /// <summary>
        /// Is display NavigateBarButton in NavigateBar ? (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public bool IsDisplayed
        {
            get { return isDisplayed; }
            set
            {
                bool oldValue = isDisplayed;
                isDisplayed = value;

                if (OnNavigateBarButtonDisplayChanged != null)
                    OnNavigateBarButtonDisplayChanged(oldValue, isDisplayed);
            }
        }

        #endregion

        #region IsShowCaption
        bool isShowCaption = true;
        /// <summary>
        /// Is show caption band? (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public bool IsShowCaption
        {
            get { return isShowCaption; }
            set { isShowCaption = value; }
        }
        #endregion

        #region IsAlwaysDisplayed
        bool isAlwaysDisplayed = false;
        /// <summary>
        /// Is always show in navigatebar (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public bool IsAlwaysDisplayed
        {
            get { return isAlwaysDisplayed; }
            set
            {
                isAlwaysDisplayed = value;
                // Eğer gizlenemeyen düğme ve gizliyse göster
                // If set true
                if (isAlwaysDisplayed && !this.IsDisplayed)
                    this.IsDisplayed = true;
            }
        }
        #endregion

        #region IsShowCaptionDescription
        bool isShowCaptionDescription = true;
        /// <summary>
        /// Is show caption description band ? (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public bool IsShowCaptionDescription
        {
            get { return isShowCaptionDescription; }
            set { isShowCaptionDescription = value; }
        }
        #endregion

        #region IsShowCaptionImage
        bool isShowCaptionImage = true;
        /// <summary>
        /// Is show image on caption band? (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public bool IsShowCaptionImage
        {
            get { return isShowCaptionImage; }
            set { isShowCaptionImage = value; }
        }
        #endregion

        #region Checked
        bool isChecked = true;
        /// <summary>
        /// Contain isdisplay value for Menu Option form (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        internal bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }
        #endregion

        #region CaptionOrjinal
        [Category("NavigateBarButton")]
        internal string CaptionOrjinal
        {
            get { return captionOrjinal; }
            set { captionOrjinal = value; }
        }
        #endregion

        #region RelatedControl
        private Control relatedControl = null;
        /// <summary>
        /// Displayed control for NavigateBarButton (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public Control RelatedControl
        {
            get { return relatedControl; }
            set { relatedControl = value; }
        }
        #endregion

        #region Font
        private Font font = new Font("Tahoma", 8, FontStyle.Bold);
        /// <summary>
        /// NavigateBarButton font (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public new Font Font
        {
            get { return font; }
            set
            {
                font = value;
                Invalidate();
            }
        }
        #endregion

        #region ForeColor
        /// <summary>
        /// NavigateBarButton Forecolor
        /// </summary>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                Invalidate();
            }
        }
        #endregion

        #region ToolTipText
        string toolTipText = "";
        /// <summary>
        /// Tooltiptext for NavigateBarButton (Get/Set)
        /// </summary>
        [Category("NavigateBarButton")]
        public string ToolTipText
        {
            get
            {
                toolTipText = string.IsNullOrEmpty(toolTipText) ? CaptionOrjinal + (CaptionOrjinal.Equals(CaptionDescription) ? "" : "\n" + CaptionDescription) : toolTipText;
                return toolTipText;
            }
            set
            {
                toolTipText = value;
            }
        }
        #endregion

        #region OverFlowPanelButton
        NavigateBarOverFlowPanelButton overFlowPanelButton = null;
        /// <summary>
        /// Displayed button on OverFlowPanel
        /// </summary>
        internal NavigateBarOverFlowPanelButton OverFlowPanelButton
        {
            get
            {
                contextMenuItem.Text = captionOrjinal;
                contextMenuItem.Image = image;
                return overFlowPanelButton;
            }
        }
        #endregion

        #region ContextMenuItem
        NavigateBarOverFlowPanelMenuItem contextMenuItem = null;
        /// <summary>
        /// ContextMenu menu item
        /// </summary>
        internal NavigateBarOverFlowPanelMenuItem ContextMenuItem
        {
            get { return contextMenuItem; }
        }
        #endregion

        #region NavigateBar
        NavigateBar navigateBar = null;
        internal NavigateBar NavigateBar
        {
            get { return navigateBar; }
            set
            {
                navigateBar = value;
                Invalidate();
            }
        }
        #endregion

        // Static Properties

        #region DefaultButtonHeight
        static int defaultButtonHeight = NavigateBar.BUTTON_HEIGHT;
        public static int DefaultButtonHeight
        {
            get { return defaultButtonHeight; }
        }
        #endregion

        #region MinimumButtonHeight
        static int minimumButtonHeight = 20;
        public static int MinimumButtonHeight
        {
            get { return minimumButtonHeight; }
        }
        #endregion

        static ToolTip toolTip;

        #region Yapıcı Metodlar

        public NavigateBarButton()
        {
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        public NavigateBarButton(string tCaption)
        {
            this.Caption = tCaption;
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption and Image
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        /// <param name="tImage">Image (24x24 recommended)</param>
        public NavigateBarButton(string tCaption, Image tImage)
        {
            this.Caption = tCaption;
            this.Image = tImage;
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption, image and related control
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        /// <param name="tImage">Image (24x24 recommended)</param>
        /// <param name="tRelatedControl">Related control</param>
        public NavigateBarButton(string tCaption, Image tImage, Control tRelatedControl)
        {
            this.Caption = tCaption;
            this.Image = tImage;
            this.RelatedControl = tRelatedControl;
            InitNavigateBarButton();
        }

        /// <summary>
        /// Caption, key, image and related control
        /// </summary>
        /// <param name="tCaption">Caption text</param>
        /// <param name="tKey">Key value. Value must be uniq in collection</param>
        /// <param name="tImage">Image (24x24 recommended)</param>
        /// <param name="tRelatedControl">Related control</param>
        public NavigateBarButton(string tCaption, string tKey, Image tImage, Control tRelatedControl)
        {
            this.Caption = tCaption;
            this.Key = tKey;
            this.Image = tImage;
            this.RelatedControl = tRelatedControl;
            InitNavigateBarButton();
        }

        /// <summary>
        /// Related control
        /// </summary>
        /// <param name="tRelatedControl">Related control</param>
        public NavigateBarButton(Control tRelatedControl)
        {
            this.RelatedControl = tRelatedControl;
            InitNavigateBarButton();
        }


        void InitNavigateBarButton()
        {
            // Control

            this.MinimumSize = new Size(NavigateBar.OVER_FLOW_BUTTON_WIDTH, minimumButtonHeight);
            this.Cursor = Cursors.Hand;
            this.ResizeRedraw = true;
            this.VisibleChanged += new EventHandler(NavigateBarButton_VisibleChanged);
            this.EnabledChanged += new EventHandler(NavigateBarButton_EnabledChanged);

            // ToolTip

            toolTip = new ToolTip();
            toolTip.ShowAlways = true;

            // OverFlowPanelButton (Panel içerisine sığmadığında overflowpanel içerisinde bu eleman gösteriliyor)
            // If cannot display navigatebutton then show this button on overflowpanel

            overFlowPanelButton = new NavigateBarOverFlowPanelButton(this);
            overFlowPanelButton.NavigateBarButton = this;
            overFlowPanelButton.IsSelected = isSelected;
            overFlowPanelButton.Click += delegate(object sender, EventArgs e)
                {
                    PerformClick(this);
                };

            // ContextMenuItem (OverFlowPanel sığmadığında menüde bu eleman gösteriliyor)
            // If cannot display on overflowpanel then show on contextmenu

            contextMenuItem = new NavigateBarOverFlowPanelMenuItem(this, false);
            contextMenuItem.Click += delegate(object sender, EventArgs e)
                {
                    PerformClick(this);
                };

        }

        #endregion

        #region NavigateBarButton Events
        /// <summary>
        /// If cannot visible button then hide button on overflowpanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NavigateBarButton_VisibleChanged(object sender, EventArgs e)
        {
            overFlowPanelButton.IsOnOverFlowPanel = !this.Visible;
        }

        /// <summary>
        /// if disable button select possible first button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NavigateBarButton_EnabledChanged(object sender, EventArgs e)
        {
            overFlowPanelButton.Enabled = this.Enabled;

            // Eğer disable duruma getirildiyse bir önceki butona geç
            if (!this.Enabled && NavigateBar != null)
            {
                if (this.IsSelected) // Eğer seçili olan button disable edildiyse
                {
                    int index = 0;
                    for (int i = 0; i < NavigateBar.NavigateBarButtons.Count; i++)
                    {
                        if (NavigateBar.NavigateBarButtons[i].Equals(this))
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index > 0)
                        NavigateBar.SelectedButton = NavigateBar.NavigateBarButtons[index - 1];
                    else if (index == 0 && NavigateBar.NavigateBarButtons.Count > 0)
                        NavigateBar.SelectedButton = NavigateBar.NavigateBarButtons[1];
                    else
                        NavigateBar.SelectedButton = NavigateBar.NavigateBarButtons[index];
                }
            }

            Invalidate();

        }
        #endregion

        #region PerfromClick
        void PerformClick(NavigateBarButton tNavigateBarButton)
        {
            // Eğer gösterilen bir button ise click olayını çalıştır
            // Run button click
            if (tNavigateBarButton.IsDisplayed)
            {
                if (OnNavigateBarButtonSelected != null)
                    OnNavigateBarButtonSelected(new NavigateBarButtonEventArgs(tNavigateBarButton));
            }
        }
        #endregion

        #region Overrided Metodlar
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (OnNavigateBarButtonSelected != null)
                    OnNavigateBarButtonSelected(new NavigateBarButtonEventArgs(this));

            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintThisControl(PaintType.Normal);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            PaintThisControl(PaintType.MouseOver);

            if (!Caption.Equals(CaptionOrjinal))
                toolTip.SetToolTip(this, ToolTipText);
            else
                toolTip.RemoveAll();

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            PaintThisControl(PaintType.Normal);
        }

        /// <summary>
        /// on resizing button reorganize caption text
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {

            if (this.Height > navigateBar.NavigateBarButtonHeight) // Tekil boyutlandırma yapılmamalı
                Height = navigateBar.NavigateBarButtonHeight;

            Graphics g = this.CreateGraphics();
            int widthCaption = (int)g.MeasureString(captionOrjinal, Font).Width; // Caption pixel olarak uzunluğunu al

            if (this.Width < (widthCaption + LIT_WIDTH * 2 + (Image == null ? 24 : Image.Width)))
            {

                caption = "..";

                for (int i = captionOrjinal.Length - 1; i >= 0; i--)
                {
                    string tmpCaption = captionOrjinal.Trim().Substring(0, i);

                    int widthCaptionTmp = (int)g.MeasureString(tmpCaption + "..", Font).Width; // Caption pixel olarak uzunluğunu al
                    if (this.Width >= (widthCaptionTmp + LIT_WIDTH * 2 + (Image == null ? 24 : Image.Width)))
                    {
                        caption = tmpCaption + "..";
                        break;
                    }
                }

            }
            else
            {
                caption = captionOrjinal;
            }

            g.Dispose();

            //Invalidate();
            base.OnResize(e);

        }

        /// <summary>
        /// return CaptionOrjinal info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.CaptionOrjinal;
        }

        #endregion

        #region Diğer Metodlar
        /// <summary>
        /// Paint NavigateBarButton
        /// </summary>
        /// <param name="LightColor"></param>
        /// <param name="DarkColor"></param>
        /// <param name="paintType"></param>
        void PaintThisControl(PaintType tPaintType)
        {

            NavigateBarTheme theme = navigateBar.Theme;
            Color lightColor = theme.LightColor;
            Color darkColor = theme.DarkColor;

            Image imageButton = null;
            switch (tPaintType)
            {
                case PaintType.Normal:
                    {
                        imageButton = isSelected ? SelectedImage : Image;
                        lightColor = isSelected ? theme.SelectedLightColor : theme.LightColor;
                        darkColor = isSelected ? theme.SelectedDarkColor : theme.DarkColor;
                        break;
                    }
                case PaintType.Selected:
                    {
                        imageButton = SelectedImage;
                        lightColor = isSelected ? theme.SelectedLightColor : theme.LightColor;
                        darkColor = isSelected ? theme.SelectedDarkColor : theme.DarkColor;
                        break;
                    }
                case PaintType.MouseOver:
                    {
                        lightColor = isSelected ? theme.SelectedLightColor : theme.MouseOverLightColor;
                        darkColor = isSelected ? theme.SelectedDarkColor : theme.MouseOverDarkColor;
                        imageButton = isSelected ? SelectedImage : MouseOverImage;
                        break;
                    }
            }

            // Gradient olarak boyama işlemi
            // Paint gradient

            NavigateBarHelper.PaintGradientControl(this, lightColor, darkColor, navigateBar.NavigateBarPaintAngle);
            Graphics g = this.CreateGraphics();

            // Yazıyı yazma
            // Draw caption text

            if (!string.IsNullOrEmpty(Caption))
            {
                Brush brushText;
                if (this.Enabled)
                    brushText = new SolidBrush(this.ForeColor);
                else
                    brushText = SystemBrushes.GrayText; // Disable color

                g.DrawString(Caption.Equals("..") ? "" : Caption,
                    Font,
                    brushText,
                    LIT_WIDTH + (imageButton == null ? 0 : imageButton.Width) + (imageButton != null ? LIT_WIDTH : 0), this.Height / 2 - Font.Height / 2);
            }

            // Resmi gösterme
            // Draw Image

            if (imageButton != null)
            {
                Image img = null;
                if (this.Enabled) // Orjinal resmi kullan // use orjinal picture
                    img = imageButton;
                else
                    img = image;

                if (!this.Enabled)
                    img = disableImage;

                int leftPos = LIT_WIDTH;
                // Eğer button metni gözükmüyorsa sadece image gözükecek şekilde ortala
                // if cannot display button text then set image position center button
                if (caption.Equals(".."))
                {
                    leftPos = (int)((Width - img.Width) / 2) - 2;
                    leftPos = leftPos <= 0 ? 1 : leftPos;
                }

                g.DrawImage(img,
                    new Rectangle(leftPos, (int)((Height - img.Height) / 2),
                    img.Width,
                    img.Height > Height ? Height : img.Height));
            }

            // Dış Çizgi
            // Draw rectangle 

            g.DrawRectangle(new Pen(theme.DarkDarkColor), new Rectangle(0, 0, Width - 1, Height));

            //

            g.Dispose();
        }
        #endregion

    }
}

