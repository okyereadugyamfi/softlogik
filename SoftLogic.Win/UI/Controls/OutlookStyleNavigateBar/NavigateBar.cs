using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{

    #region Enums

    /// <summary>
    /// Button's visible type
    /// </summary>
    enum VisibleType
    {
        All,
        Visible,
        Unvisible
    }

    /// <summary>
    /// Button's move type
    /// </summary>
    enum MoveType
    {
        MoveUp,
        MoveDown
    }

    /// <summary>
    /// Paint style for control
    /// </summary>
    enum PaintType
    {
        Normal,
        Selected,
        MouseOver
    }
    #endregion

    #region Class : NavigateBar

    /// <summary>
    /// Outlook 2003 Style Navigation Pane
    /// </summary>
    [ToolboxBitmap(typeof(NavigateBar), "Resources.NavigateBar.bmp")]
    [ToolboxItem(true)]
    [Description("Outlook 2003 Style Navigation Pane")]
    [Browsable(true)]
    public sealed class NavigateBar : Panel
    {

        #region Const

        /// <summary>
        /// value = 22
        /// </summary>
        internal const int OVER_FLOW_BUTTON_WIDTH = 22;
        /// <summary>
        /// value = 32
        /// </summary>
        internal const int BUTTON_HEIGHT = 32;

        /// <summary>
        /// value = 20
        /// </summary>
        const int HIDE_STEP = 20;

        /// <summary>
        /// value = 90F
        /// </summary>
        internal const float BUTTON_PAINT_ANGLE = 90F;

        #endregion

        // Delegate & Events

        #region Delegate & Events

        public delegate void OnNavigateBarButtonHeightChangedEventHandler(int tOldHeight, int tNewHeight);
        /// <summary>
        /// Occurs when button height changes
        /// </summary>
        public event OnNavigateBarButtonHeightChangedEventHandler OnNavigateBarButtonHeightChanged;

        public delegate void OnNavigateBarButtonEventHandler(NavigateBarButton tNavigateBarButton);
        /// <summary>
        /// Occurs when a new button added
        /// </summary>
        public event OnNavigateBarButtonEventHandler OnNavigateBarButtonAdded;
        /// <summary>
        /// Occurs when a button removed
        /// </summary>
        public event OnNavigateBarButtonEventHandler OnNavigateBarButtonRemoved;
        /// <summary>
        /// Occurs when a button selected
        /// </summary>
        public event OnNavigateBarButtonEventHandler OnNavigateBarButtonSelected;

        #endregion

        // Properties

        #region NavigateBarButtons
        NavigateBarButtonCollection navigateBarButtonCollection = new NavigateBarButtonCollection();

        /// <summary>
        /// NavigateBarButton Collection (Get)
        /// </summary>
        [Browsable(false)]
        [Category("NavigateBar Properties")]
        [Description("NavigateBarButton collection for NavigateBar")]
        public NavigateBarButtonCollection NavigateBarButtons
        {
            get { return navigateBarButtonCollection; }
        }

        #endregion

        #region NavigateBarButtonsOnOverFlowPanel

        NavigateBarButtonCollection nvbtnOnOverPanel = new NavigateBarButtonCollection();
        /// <summary>
        /// Button on OwerFlowPanel
        /// </summary>
        internal NavigateBarButtonCollection NavigateBarButtonsOnOverFlowPanel
        {
            get { return nvbtnOnOverPanel; }
        }
        #endregion

        #region NavigateBarButtonHeight

        private int navigateBarButtonHeight = NavigateBar.BUTTON_HEIGHT;
        /// <summary>
        /// NavigateBarButton height (Get/Set)
        /// </summary>
        [Category("NavigateBar Properties")]
        [Description("Buttons height")]
        public int NavigateBarButtonHeight
        {
            get { return navigateBarButtonHeight; }
            set
            {
                int oldHeight = navigateBarButtonHeight;
                if (value < NavigateBarButton.MinimumButtonHeight)
                    value = NavigateBarButton.DefaultButtonHeight;
                navigateBarButtonHeight = value;

                foreach (NavigateBarButton nvb in navigateBarButtonCollection)
                    nvb.Height = navigateBarButtonHeight;

                SetSplitterPosition();
                ReSizeControlPanel();

                if (OnNavigateBarButtonHeightChanged != null)
                    OnNavigateBarButtonHeightChanged(oldHeight, navigateBarButtonHeight);
            }
        }

        #endregion

        #region NavigateBarPaintAngle
        float paintAngle = BUTTON_PAINT_ANGLE;
        /// <summary>
        /// Paint angle for NavigateBar and sub-controls
        /// </summary>
        [Category("NavigateBar Properties")]
        [Description("Paint angle for NavigateBar and sub-controls")]
        public float NavigateBarPaintAngle
        {
            get { return paintAngle; }
            set
            {
                paintAngle = value;
                foreach (NavigateBarButton tButton in NavigateBarButtons)
                    tButton.Invalidate();
                overFlowPanel.ReDisplayOverFlowButtons();
                navigateBarCaption.Invalidate();
                navigateBarCaptionDesc.Invalidate();
                Invalidate();
            }
        }
        #endregion

        #region DisplayedNavigateBarButtonCount

        private int displayedNavigateBarButtonCount = 0;
        /// <summary>
        /// How many buttons displayed in NavigateBar ? (Get/Set)
        /// </summary>
        [Category("NavigateBar Properties")]
        [Description("How many buttons displayed in NavigateBar ?")]
        public int NavigateBarDisplayedButtonCount
        {
            get
            {
                return displayedNavigateBarButtonCount;
            }
            set
            {
                displayedNavigateBarButtonCount = value;
                if (displayedNavigateBarButtonCount < 0 ||
                    displayedNavigateBarButtonCount > navigateBarButtonCollection.Count)
                    displayedNavigateBarButtonCount = navigateBarButtonCollection.Count;

                ReDisplay(displayedNavigateBarButtonCount);
            }
        }

        #endregion

        #region SelectedButton
        private NavigateBarButton selectedButton = null;
        /// <summary>
        /// Selected NavigateBarButton (Get/Set)
        /// </summary>
        [Category("NavigateBar Properties")]
        [Description("Selected NavigateBarButton")]
        public NavigateBarButton SelectedButton
        {
            get { return selectedButton; }
            set
            {
                if (value != null)
                {
                    if (value.IsDisplayed && !selectedButton.Equals(value) && value.Enabled)
                        NavigateBarButton_Selected(new NavigateBarButtonEventArgs(value));
                }
            }
        }
        #endregion

        #region Theme
        NavigateBarTheme navigateBarTheme = NavigateBarTheme.VS2005Color;
        /// <summary>
        /// Theme for NavigateBar and sub-controls. Default value SystemColor. (Get/Set)
        /// </summary>
        [Category("NavigateBar Properties")]
        [Browsable(false)]
        public NavigateBarTheme Theme
        {
            get { return navigateBarTheme; }
            set
            {
                if (value == null)
                    value = NavigateBarTheme.SystemColor;

                navigateBarTheme = value;

                foreach (NavigateBarButton tButton in NavigateBarButtons)
                    tButton.Invalidate();

                navigateBarSplitter.SplitterLightColor = Theme.DarkColor;
                navigateBarSplitter.SplitterDarkColor = Theme.DarkDarkColor;

                overFlowPanel.ReDisplayOverFlowButtons();
                collapsibleText.Invalidate();
                collapsibleScreen.Invalidate();
                navigateBarCaption.Invalidate();
                navigateBarCaptionDesc.Invalidate();
                relatedControlPanel.Invalidate();
                Invalidate();
            }
        }
        #endregion

        #region SaveAndRestoreSettings
        bool saveAndRestoreSettings = false;
        [Category("NavigateBar Properties")]
        [Description("Is setting save or restore ?")]
        public bool SaveAndRestoreSettings
        {
            get { return saveAndRestoreSettings; }
            set { saveAndRestoreSettings = value; }
        }
        #endregion

        #region CollapsibleScreenWidth
        int collapsibleScreenWidth = 120;
        /// <summary>
        /// Collapsible screen width
        /// </summary>
        [Category("NavigateBar Properties")]
        [Description("Collapsible screen width")]
        public int CollapsibleScreenWidth
        {
            get { return collapsibleScreenWidth; }
            set
            {
                collapsibleScreenWidth = value;
                collapsibleScreen.Width = collapsibleScreenWidth;
                collapsibleScreen.Invalidate();
            }
        }
        #endregion

        #region isShowCollapsibleScreen
        bool isShowCollapsibleScreen = false;
        [Category("NavigateBar Properties")]
        [Description("Is display collapsible screen?")]
        public bool IsShowCollapsibleScreen
        {
            get { return isShowCollapsibleScreen; }
            set { isShowCollapsibleScreen = value; }
        }
        #endregion

        NavigateBarCaption navigateBarCaption;
        NavigateBarCaptionDescription navigateBarCaptionDesc;
        NavigateBarOverFlowPanel overFlowPanel;
        NavigateBarCollapsibleScreen collapsibleScreen;
        NavigateBarCollapsibleText collapsibleText;
        NavigateBarSettings settings;
        NavigateBarRelatedControlPanel relatedControlPanel;

        ContainerControl navigateBarButtonContainer;
        Panel captionPanel;

         MTSplitter navigateBarSplitter;

        //Var
        int displayedButtonCount = 0;
        int lastDisplayedButtonCount = 0;
        bool collapsibleScreenRequired = false;

        #region Yapıcı Methodlar
        public NavigateBar()
        {
            InitOutlookStyleNavigateBar();
        }

        void InitOutlookStyleNavigateBar()
        {

            // Collection

            navigateBarButtonCollection.OnNavigateBarButtonAdded += new NavigateBarButtonCollection.OnItemAddedEventHandler(NavigateBarButtonCollection_OnNavigateBarButtonItemAdded);
            navigateBarButtonCollection.OnNavigateBarButtonRemoved += new NavigateBarButtonCollection.OnItemRemovedEventHandler(NavigateBarButtonCollection_OnNavigateBarButtonItemRemoved);

            // Control

            this.BackColor = SystemColors.ControlLightLight;
            this.Dock = DockStyle.Fill;
            this.BorderStyle = BorderStyle.None;
            this.Resize += new EventHandler(NavigateBar_Resize);
            this.SystemColorsChanged += delegate(object sender, EventArgs e)
                {
                    // if changed system color then apply new color on theme
                    this.Theme = NavigateBarTheme.SystemColor;
                };

            this.MinimumSize = new Size(NavigateBar.OVER_FLOW_BUTTON_WIDTH, 100);
            this.Disposed += new EventHandler(NavigateBar_Disposed);
            this.HandleCreated += new EventHandler(NavigateBar_HandleCreated);

            #region OverFlowPanel
            overFlowPanel = new NavigateBarOverFlowPanel(this);
            overFlowPanel.Dock = DockStyle.Bottom;
            overFlowPanel.NavigateBar = this;
            #endregion

            #region Collapsibile Screen

            collapsibleScreen = new NavigateBarCollapsibleScreen(this);
            collapsibleScreen.ControlBox = false;
            collapsibleScreen.FormBorderStyle = FormBorderStyle.None;
            collapsibleScreen.Width = this.CollapsibleScreenWidth;
            collapsibleScreen.ShowInTaskbar = false;
            collapsibleScreen.Activated += delegate(object sender, EventArgs e)
                {
                    collapsibleText.ContentImage  = SoftLogik.Win.Properties.Resources.ArrowLeft;

                    if (collapsibleScreen.IsShowWindow)
                    {
                        int tmpWidth = CollapsibleScreenWidth;
                        if ((CollapsibleScreenWidth % HIDE_STEP) != 0)
                        {
                            int adet = (int)(CollapsibleScreenWidth / HIDE_STEP);
                            tmpWidth = adet * HIDE_STEP;
                        }

                        collapsibleScreen.SuspendLayout();
                        for (int i = 0; i <= tmpWidth; i += HIDE_STEP)
                        {
                            System.Threading.Thread.Sleep(5);
                            collapsibleScreen.Width = i;
                        }
                        collapsibleScreen.Width = CollapsibleScreenWidth;
                        collapsibleScreen.ResumeLayout();
                        Update();
                    }
                };
            collapsibleScreen.Deactivate += delegate(object sender, EventArgs e)
                {

                    collapsibleText.ContentImage = SoftLogik.Win.Properties.Resources.ArrowRight;

                    if (collapsibleScreen.IsShowWindow)
                    {
                        collapsibleScreen.SuspendLayout();
                        for (int i = collapsibleScreen.Width; i >= 0; i -= HIDE_STEP)
                        {
                            System.Threading.Thread.Sleep(5);
                            collapsibleScreen.Width = i;
                        }
                        collapsibleScreen.ResumeLayout();
                        Update();
                    }

                    collapsibleScreen.IsShowWindow = false;
                    collapsibleScreen.Hide();

                };
            #endregion

            #region Caption

            navigateBarCaption = new NavigateBarCaption();
            navigateBarCaption.NavigateBar = this;
            navigateBarCaption.Dock = DockStyle.Top;
            navigateBarCaption.VisibleChanged += new EventHandler(NavigateBarCaption_VisibleChanged);

            navigateBarCaptionDesc = new NavigateBarCaptionDescription();
            navigateBarCaptionDesc.NavigateBar = this;
            navigateBarCaptionDesc.Dock = DockStyle.Top;
            navigateBarCaptionDesc.VisibleChanged += new EventHandler(NavigateBarCaption_VisibleChanged);

            captionPanel = new Panel();
            captionPanel.Height = navigateBarCaption.Height + navigateBarCaptionDesc.Height;
            captionPanel.Dock = DockStyle.Top;
            captionPanel.Controls.Add(navigateBarCaptionDesc);
            captionPanel.Controls.Add(navigateBarCaption);

            #endregion

            // using display for related control
            relatedControlPanel = new NavigateBarRelatedControlPanel();
            relatedControlPanel.NavigateBar = this;

            #region navigateBarSplitter
            // Splitter
            navigateBarSplitter = new MTSplitter();
            navigateBarSplitter.Size = new Size(6, 0); // Splitter height 6 pixel
            navigateBarSplitter.Dock = DockStyle.Bottom;
            navigateBarSplitter.MinSize = 0;
            navigateBarSplitter.SplitterMoving += new SplitterEventHandler(NavigateBarSplitter_SplitterMoving);
            navigateBarSplitter.SplitterMoved += new SplitterEventHandler(NavigateBarSplitter_SplitterMoved);
            #endregion

            // Containers

            navigateBarButtonContainer = new ContainerControl();
            navigateBarButtonContainer.Dock = DockStyle.Bottom;
            navigateBarButtonContainer.Width = 120;
            navigateBarButtonContainer.Height = 200;

            // Read from setting in XML file

            settings = new NavigateBarSettings(this);

            // If show collaplible screen display button caption on this control

            collapsibleText = new NavigateBarCollapsibleText();
            collapsibleText.NavigateBar = this;
            collapsibleText.Invalidate();
            collapsibleText.MouseClick += delegate(object sender, MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Left)
                        ShowOverScreen();
                };
            collapsibleText.MouseEnter += delegate(object sender, EventArgs e)
                {
                    ShowOverScreen();
                };

            // Add controls in NavigateBar

            Controls.Add(navigateBarSplitter);
            Controls.Add(captionPanel);
            Controls.Add(relatedControlPanel);
            Controls.Add(navigateBarButtonContainer);
            Controls.Add(overFlowPanel);

        }

        #endregion

        #region NavigateBar Events

        void NavigateBar_HandleCreated(object sender, EventArgs e)
        {
            // if loaded setting, displayed button count is last count else max displayed button count

            // Eğer ayarlar yüklenebilirse gösterilecek olan buttoun sayısı kayıt edilen sayıdır
            // değilse en fazla gösterilecek olan button sayısını kullan
            if (saveAndRestoreSettings && settings.IsLoad)
            {
                // Panel's properties

                if (Theme.CompareTo(settings.Theme) != 0)
                    Theme = settings.Theme; // Load saving theme
                NavigateBarButtonHeight = settings.ButtonHeight; // load buttons height
                NavigateBarPaintAngle = settings.PaintAngle; // load paint angle
                displayedButtonCount = settings.DisplayedButtonCount; // load last displayed button count

                // Re-Order buttons (In collection)
                // Buttonları yeniden sıraya yerleştir (Kolleksiyon içerisinde sıralanıyor)

                NavigateBarButton selBtn = SelectedButton; // Seçili button yedekle // backup selected button

                foreach (KeyValuePair<string, NavigateBarSettings.ButtonRestoreSettings> kvp in settings.ButtonRestoreInfo)
                {
                    NavigateBarButton nvb = NavigateBarButtons.FindByKey(kvp.Key);
                    if (nvb != null)
                    {
                        NavigateBarButton tmpButton = nvb;
                        //int konum = NavigateBarButtons.IndexOf(nvb);
                        NavigateBarButtons.Remove(nvb);
                        NavigateBarButtons.Insert(kvp.Value.Order, tmpButton);
                    }
                }

                SelectedButton = selBtn; // Sıralama sonrasında tekrar seç // set backuped selected button

            }
            else
            {
                displayedButtonCount = displayedNavigateBarButtonCount;
            }

            ReDisplay(displayedButtonCount);
        }

        /// <summary>
        /// Save settings on exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NavigateBar_Disposed(object sender, EventArgs e)
        {
            settings.SaveSettingsToXmlFile();
        }

        /// <summary>
        /// if resizing navigatebar resize sub-controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NavigateBar_Resize(object sender, EventArgs e)
        {

            collapsibleScreenRequired = (Width <= MinimumSize.Width + 5);

            if (collapsibleScreenRequired)
                relatedControlPanel.Controls.Clear();

            if (SelectedButton != null)
                SetControlForNavigateBarButton(SelectedButton.RelatedControl);

            ReSizeControlPanel();
        }

        #endregion

        #region ShowOverScreen
        void ShowOverScreen()
        {
            if (!isShowCollapsibleScreen ||
                !collapsibleScreenRequired ||
                collapsibleScreen.IsShowWindow ||
                SelectedButton.RelatedControl == null)
                return;

            Point p = new Point(relatedControlPanel.Location.X + Width, relatedControlPanel.Location.Y);
            collapsibleScreen.DesktopLocation = relatedControlPanel.PointToScreen(p);
            collapsibleScreen.Text = SelectedButton.CaptionOrjinal;
            collapsibleScreen.Height = relatedControlPanel.Height;
            collapsibleScreen.Width = CollapsibleScreenWidth;
            // 
            collapsibleScreen.SetControl(SelectedButton.RelatedControl);
            collapsibleScreen.IsShowWindow = true;
            collapsibleScreen.Focus();
            collapsibleScreen.Show();

        }

        #endregion

        #region Splitter Events

        void NavigateBarSplitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ChangeSplitterPosition();
        }

        void NavigateBarSplitter_SplitterMoving(object sender, SplitterEventArgs e)
        {

            if (!this.Created)
                return;

            bool oldShowSetting = IsShowCollapsibleScreen;

            int nvbtnCount = 0;

            float nvbtnCountTmp = navigateBarSplitter.SplitPosition / navigateBarButtonHeight;
            nvbtnCount = (int)Math.Round(nvbtnCountTmp, 2);

            // Kolleksiyondan büyük olamaz
            // Cannot bigger collection button count
            nvbtnCount = nvbtnCount > NavigateBarButtons.Count ? NavigateBarButtons.Count : nvbtnCount;

            // İstenen adet sayısıdan fazla olamaz
            // Cannot bigger max displayed button count
            nvbtnCount = nvbtnCount > displayedNavigateBarButtonCount ? displayedNavigateBarButtonCount : nvbtnCount;

            displayedButtonCount = nvbtnCount;

            //
            ChangeSplitterPosition();

            if (displayedButtonCount != lastDisplayedButtonCount)
            {
                lastDisplayedButtonCount = displayedButtonCount;
                ReDisplayNavigateBarButtons();
                ReSizeControlPanel();
                ReFreshOverFlowPanel();
                ChangeSplitterPosition();
            }

            IsShowCollapsibleScreen = oldShowSetting;
        }

        #endregion

        #region Event : NavigateBarCaption_VisibleChanged

        void NavigateBarCaption_VisibleChanged(object sender, EventArgs e)
        {

            bool showCaption = navigateBarCaption.Visible;
            bool showCaptionDesc = navigateBarCaptionDesc.Visible;

            captionPanel.Height = navigateBarCaption.Height + navigateBarCaptionDesc.Height;

            // Display only caption
            // Sadece Caption göster
            if (showCaption && !showCaptionDesc)
                captionPanel.Height = navigateBarCaption.Height;

            // Display only captiondescription
            // Sadece CaptionDesription göster
            if (!showCaption && showCaptionDesc)
                captionPanel.Height = navigateBarCaptionDesc.Height;

            // Hide caption and caption description
            // Her ikisinide gizle
            if (!showCaption && !showCaptionDesc)
            {
                captionPanel.Height = 1;
            }

            ReSizeControlPanel();
        }

        #endregion

        #region Event : NavigateBarButtonCollection_OnNavigateBarButtonItemAdded
        /// <summary>
        /// Add new NavigateBarButton in collection
        /// </summary>
        /// <param name="e"></param>
        void NavigateBarButtonCollection_OnNavigateBarButtonItemAdded(NavigateBarButtonEventArgs e)
        {

            NavigateBarButton navigateBarButton = e.NavigateBarButton;

            if (navigateBarButton == null)
                return;

            // NavigateBarButtona özelliklerini belirt
            // Set NavigateBarButton properties

            navigateBarButton.NavigateBar = this;
            navigateBarButton.Height = this.NavigateBarButtonHeight;

            // Eğer gözükmesini istenen sayıdan dazla ise eklenen
            // NavigateBarButtonları görünmez yaparak OverFlowPanele gönder

            // if collection count bigger max displayed count then show on overflowpanel

            if (navigateBarButtonCollection.Count > NavigateBarDisplayedButtonCount)
                navigateBarButton.Visible = false;

            // NavigateBarButtonu ekle
            // Add navigatebar button

            navigateBarButtonContainer.Controls.Add(navigateBarButton);
            ReDisplayNavigateBarButtons();

            // Eğer ilk NavigateBarButton eklendiyse Captionlar için tıkla
            // if added first navigatebar button select first button

            if (navigateBarButtonCollection.Count == 1)
            {
                navigateBarButton.IsSelected = true;
                NavigateBarButton_Selected(new NavigateBarButtonEventArgs(navigateBarButton));
            }

            navigateBarButton.Dock = DockStyle.Bottom;

            // Buttonun kayıtlı ayarlarını geri yükle
            // Load setting for added button

            if (saveAndRestoreSettings && settings.IsLoad)
            {
                NavigateBarSettings.ButtonRestoreSettings brs = null;
                settings.ButtonRestoreInfo.TryGetValue(navigateBarButton.Key, out brs);
                if (brs != null)
                {
                    navigateBarButton.Visible = brs.Visible;
                    navigateBarButton.Enabled = brs.Enabled;
                    navigateBarButton.IsDisplayed = brs.Display;
                    navigateBarButton.IsSelected = brs.Selected;

                    if (brs.Selected) // seçili // If selected on exit then select
                        SelectedButton = navigateBarButton;
                }
            }

            // Adeti yeniden belirler
            // set new displayed button count

            displayedButtonCount = GetVisibleButtonCount(VisibleType.Visible);

            // NavigateBarButton olayları / events

            navigateBarButton.OnNavigateBarButtonSelected += new NavigateBarButton.OnNavigateBarButtonSelectedEventHandler(NavigateBarButton_Selected);
            navigateBarButton.OnNavigateBarButtonDisplayChanged += new NavigateBarButton.OnNavigateBarButtonDisplayChangedEventHandler(NavigateBarButton_DisplayChanged);

            // trigger Event
            if (OnNavigateBarButtonAdded != null)
                OnNavigateBarButtonAdded(navigateBarButton);

        }


        #endregion

        #region Event : NavigateBarButtonCollection_OnNavigateBarButtonItemRemoved
        /// <summary>
        /// Remove NavigateBarButton from collection
        /// </summary>
        /// <param name="e"></param>
        void NavigateBarButtonCollection_OnNavigateBarButtonItemRemoved(NavigateBarButtonEventArgs e)
        {
            try
            {

                if (navigateBarButtonCollection.Count >= 0)
                {

                    // Görünen NavigateBarButton sayısını yenile 
                    // set new displayed button count

                    displayedButtonCount = GetVisibleButtonCount(VisibleType.Visible);

                    // Sonraki elemanı aktif hale getir
                    // Select next button if possible

                    if (navigateBarButtonCollection.Count >= 0)
                        this.SelectedButton = navigateBarButtonCollection[0];
                    else
                        this.SelectedButton = null;

                    ReDisplay(displayedButtonCount);

                    // Event çalıştır // trigger event

                    if (OnNavigateBarButtonRemoved != null)
                        OnNavigateBarButtonRemoved(e.NavigateBarButton);
                }
            }
            catch { }

        }
        #endregion

        #region Event : NavigateBarButton_Selected

        void NavigateBarButton_Selected(NavigateBarButtonEventArgs e)
        {

            // Zaten seçili ise 
            // If already selected return

            if (selectedButton != null && SelectedButton.Equals(e.NavigateBarButton))
                return;

            // Control içerisindeki tüm butonların IsSelected ayarla
            // set IsSelected state for all buttons in collection

            foreach (NavigateBarButton nvb in navigateBarButtonCollection)
                nvb.IsSelected = nvb.Equals(e.NavigateBarButton);

            overFlowPanel.Refresh();

            // Seçili NavigateBarButtonun özelliklerini aktar
            // Set new caption and image info for selected button

            navigateBarCaption.Caption = e.NavigateBarButton.CaptionOrjinal;
            navigateBarCaption.Image = e.NavigateBarButton.IsShowCaptionImage ? e.NavigateBarButton.Image : null;
            navigateBarCaptionDesc.Caption = e.NavigateBarButton.CaptionDescription;

            navigateBarCaption.Visible = e.NavigateBarButton.IsShowCaption;
            navigateBarCaptionDesc.Visible = e.NavigateBarButton.IsShowCaptionDescription;

            // Seçili buttonu bar üzerindeki değişkenede atama
            // Set selected button var

            selectedButton = e.NavigateBarButton;

            // Seçilen NavigateBarButton için Controlü göster
            // display releated control for selected button

            SetControlForNavigateBarButton(e.NavigateBarButton.RelatedControl);

            //
            if (OnNavigateBarButtonSelected != null)
                OnNavigateBarButtonSelected(e.NavigateBarButton);

        }
        #endregion

        #region Method : SetControlForNavigateBarButton
        /// <summary>
        /// Show selected control for selected button
        /// </summary>
        /// <param name="tControl"></param>
        void SetControlForNavigateBarButton(Control tControl)
        {

            Control control = tControl;

            relatedControlPanel.Controls.Clear();

            if (collapsibleScreenRequired) // Not enough width navigatebar, display only caption // Yeterli yer yok sadece başlık göster
            {
                navigateBarCaption.Visible = false;
                navigateBarCaptionDesc.Visible = false;

                if (SelectedButton != null)
                {
                    collapsibleText.ContentText = SelectedButton.CaptionOrjinal; //NavigateBarHelper.GetVerticalText(" " + SelectedButton.CaptionOrjinal);
                    collapsibleText.ContentImage = IsShowCollapsibleScreen && SelectedButton.RelatedControl != null ? SoftLogik.Win.Properties.Resources.ArrowRight : SelectedButton.Image;
                }
                else
                {
                    collapsibleText.ContentText = "Navigation Pane";
                    collapsibleText.ContentImage = null;
                }

                control = collapsibleText;

            }
            else // Normal kontrolü göster // display releated control
            {
                navigateBarCaption.Visible = SelectedButton.IsShowCaption;
                navigateBarCaptionDesc.Visible = SelectedButton.IsShowCaptionDescription;
            }

            // Gösterilen kontrol ile aynı ise gösterme
            // If displayed related control same as new control then return

            if (control != null && !relatedControlPanel.Controls.Contains(control))
            {
                control.Dock = DockStyle.Fill;
                relatedControlPanel.Controls.Add(control);
                control.Invalidate();
                control.Focus();
            }
        }

        #endregion

        #region Event : NavigateBarButton_DisplayChanged

        /// <summary>
        /// If changed IsDisplayed state NavigateBarButton
        /// </summary>
        /// <param name="tOldValue"></param>
        /// <param name="tNewValue"></param>
        void NavigateBarButton_DisplayChanged(bool tOldValue, bool tNewValue)
        {

            displayedButtonCount = GetVisibleButtonCount(VisibleType.Visible);
            lastDisplayedButtonCount = displayedButtonCount;

            bool existsDisplay = false;

            // Tüm butonlar eğer görünmüyorsa Control görünüm alanını ve 
            // overflow kontrol analını temizle
            // selectedButton null olarak ata

            // If all buttons is not displayed then clear overflowpanel and set null selectedbutton 

            foreach (NavigateBarButton nvb in navigateBarButtonCollection)
            {
                if (nvb.IsDisplayed)
                {
                    existsDisplay = true;
                    break;
                }
            }

            // Eğer seçili button IsDisplayed değilse olan ilk tabı seç
            // If selected new button not isdisplayed then select possible first button

            if (existsDisplay && selectedButton != null)
            {
                if (!this.selectedButton.IsDisplayed)
                {
                    foreach (NavigateBarButton nvb in this.NavigateBarButtons)
                    {
                        if (nvb.IsDisplayed)
                        {
                            this.SelectedButton = nvb;
                            break;
                        }
                    }
                }

            }
            else
            {
                relatedControlPanel.Controls.Clear();
                displayedButtonCount = GetVisibleButtonCount(VisibleType.Visible);
                navigateBarCaption.Caption = "";
                navigateBarCaptionDesc.Caption = "";
                selectedButton = null;
            }

            // NavigateBarı yenile
            // Refresh items on navigatebar

            ChangeSplitterPosition();
            ReDisplayNavigateBarButtons();

            // OverFlowPaneli yenile
            // Refresh items on overflowpanel

            ReFreshOverFlowPanel();
            ReSizeControlPanel();

        }
        #endregion

        #region Method : ReDisplayNavigateBarButtons
        /// <summary>
        /// Set button visible state for splitter position
        /// </summary>
        void ReDisplayNavigateBarButtons()
        {
            try
            {
                nvbtnOnOverPanel.Clear();

                int j = 0;

                for (int i = 0; i < navigateBarButtonCollection.Count; i++)
                {
                    if (navigateBarButtonCollection[i].IsDisplayed)
                    {
                        navigateBarButtonCollection[i].Visible = (j < displayedButtonCount);
                        // If not displayed in navigatebar then show on overflowpanel
                        nvbtnOnOverPanel.Add(navigateBarButtonCollection[i]); // OverFlowPanel buttonları
                        j++;
                    }
                    else
                    {
                        navigateBarButtonCollection[i].Visible = false;
                    }
                }

            }
            catch { }
        }
        #endregion

        #region Method : MoveButtons

        /// <summary>
        /// Programatic move navigatebar buttons
        /// </summary>
        /// <param name="tMoveType"></param>
        internal void MoveButtons(MoveType tMoveType)
        {

            // Aşağı kaydır
            // Move Down
            if (tMoveType == MoveType.MoveDown && displayedButtonCount > 0)
                displayedButtonCount--;

            // Yukarı kaydır
            // Move Up
            if (tMoveType == MoveType.MoveUp && displayedButtonCount < NavigateBarDisplayedButtonCount)
                displayedButtonCount++;

            ReDisplay(displayedButtonCount);

        }

        #endregion

        #region Method : ReDisplay
        /// <summary>
        /// Set displayed button count in NavigateBar panel
        /// </summary>
        /// <param name="tButtonCount">Displayed button count. This value cannot bigger NavigateBarDisplayedButtonCount value</param>
        public void ReDisplay(int tButtonCount)
        {

            if (tButtonCount < 0 || tButtonCount > displayedNavigateBarButtonCount)
                return;

            displayedButtonCount = tButtonCount; // GetVisibleButtonCount(VisibleType.Visible);

            // Ekranı yenile
            // Refresh navigatebar items
            ReDisplayNavigateBarButtons();
            SetSplitterPosition();

            // OverFlowPaneli yenile
            // refresh overflowpanel
            ReFreshOverFlowPanel();
            ReSizeControlPanel();

        }
        #endregion

        #region Method : RunNavigateBarOptionsForm
        /// <summary>
        /// Run Navigatebar Menu Option screen and if changed order buttons set new order
        /// </summary>
        internal void RunNavigateBarOptionsForm()
        {

            for (int i = 0; i < NavigateBarButtons.Count; i++)
                NavigateBarButtons[i].IsChecked = NavigateBarButtons[i].IsDisplayed;

            NavigateBarOptions frmNavBarOptions = new NavigateBarOptions(this);
            if (frmNavBarOptions.ShowDialog() == DialogResult.OK &&
                frmNavBarOptions.HasChange)
            {
                for (int i = 0; i < NavigateBarButtons.Count; i++)
                {
                    navigateBarButtonContainer.Controls.SetChildIndex(NavigateBarButtons[i], i);

                    if (NavigateBarButtons[i].IsDisplayed != NavigateBarButtons[i].IsChecked)
                        NavigateBarButtons[i].IsDisplayed = NavigateBarButtons[i].IsChecked;

                }

                displayedButtonCount = GetVisibleButtonCount(VisibleType.Visible);
                ReDisplay(displayedButtonCount);
            }

            frmNavBarOptions.Dispose();

        }
        #endregion

        #region Method : ReFreshOverFlowPanel
        /// <summary>
        /// ReFresh OverFlowPanel
        /// </summary>
        void ReFreshOverFlowPanel()
        {
            overFlowPanel.ReDisplayOverFlowButtons();
            overFlowPanel.SetContextMenuEnableState();
        }
        #endregion

        #region Methods : SplitterPosition

        /// <summary>
        /// Calculate new positon for splitter
        /// </summary>
        void ChangeSplitterPosition()
        {
            if (!this.Created)
                return;

            try
            {
                int visibleItemCount = GetVisibleButtonCount(VisibleType.Visible); // displayedItemCount;

                if (navigateBarSplitter.SplitPosition > (visibleItemCount * navigateBarButtonHeight))
                    navigateBarSplitter.SplitPosition = visibleItemCount * navigateBarButtonHeight;

            }
            catch { }
        }

        /// <summary>
        /// Change splitter position
        /// </summary>
        void SetSplitterPosition()
        {
            try
            {
                navigateBarSplitter.SplitPosition = displayedButtonCount * navigateBarButtonHeight;
            }
            catch { }
        }

        #endregion

        #region Method : GetVisibleButtonCount
        /// <summary>
        /// Get visible button count
        /// </summary>
        /// <param name="tVisibleType"></param>
        /// <returns></returns>
        internal int GetVisibleButtonCount(VisibleType tVisibleType)
        {

            int visibleItemCount = 0;

            foreach (NavigateBarButton nvb in navigateBarButtonCollection)
            {

                // Gözükmeyecekse pas geç
                // If not displayed skip button
                if (!nvb.IsDisplayed) continue;

                switch (tVisibleType)
                {
                    case VisibleType.Unvisible:
                        {
                            if (!nvb.Visible) visibleItemCount++;
                            break;
                        }
                    case VisibleType.Visible:
                        {
                            if (nvb.Visible) visibleItemCount++;
                            break;
                        }
                    case VisibleType.All:
                        {
                            visibleItemCount++;
                            break;
                        }
                }
            }

            return visibleItemCount;
        }
        #endregion

        #region Method : ReSizeControlPanel
        void ReSizeControlPanel()
        {

            try
            {
                int visibleItemCount = GetVisibleButtonCount(VisibleType.Visible); // displayedItemCount;
                int newHeight = Height - relatedControlPanel.Top - (visibleItemCount * navigateBarButtonHeight) - navigateBarSplitter.Height - overFlowPanel.Height;

                Point newLocation = new Point(1, captionPanel.Height); // Konum // Positon

                relatedControlPanel.Location = newLocation;
                relatedControlPanel.SuspendLayout();
                relatedControlPanel.Width = Width - 2;
                relatedControlPanel.Height = Height - relatedControlPanel.Top - (visibleItemCount * navigateBarButtonHeight) - navigateBarSplitter.Height - overFlowPanel.Height;
                relatedControlPanel.ResumeLayout();
            }
            catch { }
        }
        #endregion

        #region Overrided Methodlar
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Graphics g = this.CreateGraphics();
            g.DrawRectangle(new Pen(navigateBarTheme.DarkDarkColor), new Rectangle(0, 1, Width - 1, Height - 1));
            g.Dispose();
        }
        #endregion

    }

    #endregion
}
