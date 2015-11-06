/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar overflowpanel
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// If cannot display button in NavigateBar then display button in this control
    /// </summary>
    [ToolboxItem(false)]
    class NavigateBarOverFlowPanel : UserControl
    {

        #region NavigateBar
        NavigateBar navigateBar = null;
        public NavigateBar NavigateBar
        {
            get { return navigateBar; }
            set
            {
                navigateBar = value;
                Invalidate();
            }
        }
        #endregion

        // Arrow Button

        NavigateBarOverFlowPanelButton panelArrowBtn = null;
        NavigateBarButton panelArratNavBtn;

        // ContextMenu

        ContextMenuStrip mnContextMenu;

        NavigateBarOverFlowPanelMenuItem mnShowMoreButton;
        NavigateBarOverFlowPanelMenuItem mnShowFewerButton;
        NavigateBarOverFlowPanelMenuItem mnMenuOptions;
        NavigateBarOverFlowPanelMenuItem mnAddRemoveButton;

        // Var

        bool isMenuSeperatorAdded = false;

        #region Yapıcı Metodlar
        public NavigateBarOverFlowPanel()
        {
            InitNavigateBarOverFlowPanel();
            InitContextMenuItems();
        }

        public NavigateBarOverFlowPanel(NavigateBar tNavigateBar)
        {
            NavigateBar = tNavigateBar;
            InitNavigateBarOverFlowPanel();
            InitContextMenuItems();
        }

        void InitNavigateBarOverFlowPanel()
        {
            // Control

            Dock = DockStyle.Fill;
            MinimumSize = new Size(NavigateBar.OVER_FLOW_BUTTON_WIDTH, NavigateBar.BUTTON_HEIGHT);
            Height = NavigateBar.BUTTON_HEIGHT;


            // Arrow button

            panelArratNavBtn = new NavigateBarButton(SoftLogik.Properties.Resources.TEXT_CONFIGURE_BUTTONS, SoftLogik.Properties.Resources.ArrowMenu);
            panelArratNavBtn.NavigateBar = NavigateBar;
            panelArrowBtn = new NavigateBarOverFlowPanelButton(panelArratNavBtn);
            panelArrowBtn.Left = Width - panelArrowBtn.Width - 1;
            panelArrowBtn.IsSelected = false;
            panelArrowBtn.Visible = true;
            panelArrowBtn.Tag = "__ARROW";
            panelArrowBtn.Click += delegate(object sender, EventArgs e)
                {
                    // OK tıklandığında okun yanında context menü açılması sağlanıyor
                    // Click arrow button show context menu near arrow button
                    mnContextMenu.Show(this, (Left + Width), panelArrowBtn.Top + Height / 2);
                };

            //

        }

        #endregion

        #region ContextMenu metodları

        void InitContextMenuItems()
        {
            mnContextMenu = new ContextMenuStrip();

            // Menü kapatıldığında okun clickini kaldır
            // Closed context menu remove selected state on arrow button
            mnContextMenu.Closed += delegate(object sender, ToolStripDropDownClosedEventArgs e)
                {
                    panelArrowBtn.IsSelected = false;
                    Refresh();
                };

            // Show More Button menu item

            mnShowMoreButton = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnShowMoreButton.Text  = SoftLogik.Properties.Resources.TEXT_SHOW_MORE_BUTTONS;
            mnShowMoreButton.Image  = SoftLogik.Properties.Resources.ArrowUp;
            mnShowMoreButton.Click += delegate(object sender, EventArgs e)
                {
                    NavigateBar.MoveButtons(MoveType.MoveUp);
                };

            // Show Fewer Button menu item

            mnShowFewerButton = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnShowFewerButton.Text  = SoftLogik.Properties.Resources.TEXT_SHOW_FEWER_BUTTONS;
            mnShowFewerButton.Image  = SoftLogik.Properties.Resources.ArrowDown;
            mnShowFewerButton.Click += delegate(object sender, EventArgs e)
                 {
                     NavigateBar.MoveButtons(MoveType.MoveDown);
                 };

            // Seçenek
            // Menu Options menu item
            mnMenuOptions = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnMenuOptions.Text  = SoftLogik.Properties.Resources.TEXT_MENU_OPTIONS;
            mnMenuOptions.Click += delegate(object sender, EventArgs e)
                {
                    NavigateBar.RunNavigateBarOptionsForm();
                };

            // Ekle / Kaldır
            // Add or Remove Button menu item
            mnAddRemoveButton = new NavigateBarOverFlowPanelMenuItem(null, false);
            mnAddRemoveButton.Text  = SoftLogik.Properties.Resources.TEXT_ADD_OR_REMOVE_BUTTON;

        }

        /// <summary>
        /// Buildng context menu
        /// </summary>
        /// <returns></returns>
        void BuildContextMenu()
        {

            if (mnContextMenu == null) return;

            mnContextMenu.Items.Clear();
            mnAddRemoveButton.DropDownItems.Clear();

            mnContextMenu.Items.Add(mnShowMoreButton);
            mnContextMenu.Items.Add(mnShowFewerButton);
            mnContextMenu.Items.Add(mnMenuOptions);
            mnContextMenu.Items.Add(mnAddRemoveButton);

            if (navigateBar != null)
            {

                // NavigateBarButton görünümleri değiştiren ContextMenu oluşturuluyor
                // Building context menu navigatebarbutton in collection

                foreach (NavigateBarButton otb in navigateBar.NavigateBarButtons)
                {

                    // Her zaman gösterilecek
                    // If always show skip
                    if (otb.IsAlwaysDisplayed) 
                        continue;

                    NavigateBarOverFlowPanelMenuItem ofpmi = new NavigateBarOverFlowPanelMenuItem(otb, true);
                    ofpmi.Click += delegate(object sender, EventArgs e)
                    {
                        // Seçilen Button Panel içerisindek kaldırılır yada eklenilir
                        // Show or Hide NavigatebarButton in panel
                        if (sender is NavigateBarOverFlowPanelMenuItem)
                        {
                            NavigateBarButton nvb = (sender as NavigateBarOverFlowPanelMenuItem).NavigateBarButton;
                            nvb.IsDisplayed = !nvb.IsDisplayed;
                        }
                    };

                    mnAddRemoveButton.DropDownItems.Add(ofpmi);

                }
            }

        }

        /// <summary>
        /// Görünen ve en fazla görünmesi gereken buton sayısına göre menülerin enable durumunu değiştirir
        /// </summary>
        public void SetContextMenuEnableState()
        {

            if (mnContextMenu == null)
                return;

            // Eğer düğme varsa
            // If any button displayed context menu

            mnMenuOptions.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);
            mnAddRemoveButton.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);
            mnShowFewerButton.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);
            mnShowMoreButton.Enabled = (NavigateBar.NavigateBarButtons.Count > 0);

            //

            int visibleButtonCount = NavigateBar.GetVisibleButtonCount(VisibleType.Visible);

            // Tüm NavigateBarButonlar gözüküyor sadece aşağı hareket edebilir
            // All buttons is displayed. Only move down
            if (visibleButtonCount == NavigateBar.NavigateBarDisplayedButtonCount && NavigateBar.NavigateBarButtons.Count > 0)
            {
                mnShowMoreButton.Enabled = false;
                mnShowFewerButton.Enabled = true;
            }

            // Aşağı - yukarı hareket edebilir
            // Move up or down
            if (visibleButtonCount < NavigateBar.NavigateBarDisplayedButtonCount &&
                visibleButtonCount > 0 && NavigateBar.NavigateBarButtons.Count > 0)
            {
                mnShowMoreButton.Enabled = true;
                mnShowFewerButton.Enabled = true;
            }

            // Tüm NavigateBarButonlar gizli sadece yukarı hareket edebilir
            // All buttons is visible. Only move up
            if (visibleButtonCount == 0 && NavigateBar.NavigateBarButtons.Count > 0)
            {
                mnShowMoreButton.Enabled = true;
                mnShowFewerButton.Enabled = false;
            }

            // 


        }

        #endregion

        #region Method : ReDisplayOverFlowButtons
        /// <summary>
        /// If button cannot displayed NavigateBar panel then display on this panel
        /// </summary>
        public void ReDisplayOverFlowButtons()
        {

            NavigateBarButtonCollection nvbCol = NavigateBar.NavigateBarButtonsOnOverFlowPanel;

            // Ön Temizlik
            // Clear contextmenu items

            if (mnContextMenu != null) // ilk gelişinde menü daha oluşmadı
                mnContextMenu.Items.Clear();

            BuildContextMenu();
            isMenuSeperatorAdded = false;

            Controls.Clear();

            // OverFlowPanel üzerine simgeleri sırasına göre ekle
            // Eğer simgelerin toplam uzunluğu panelden fazla ise ContextMenu
            // üzerine ekle
            // Panel içerisine kaç adet button sığıyor

            // Add button on overflowpanel looking order
            // calculate how many button displayable on panel
            // If cannot display button on overflowpanel then show on contextmenu

            int addedBtnCount = 0;
            int displayableBtnCount = (Width - NavigateBar.OVER_FLOW_BUTTON_WIDTH - 4) / NavigateBar.OVER_FLOW_BUTTON_WIDTH;
            displayableBtnCount = (displayableBtnCount > nvbCol.Count ? nvbCol.Count : displayableBtnCount);

            for (int i = 0; i < nvbCol.Count; i++)
            {

                NavigateBarOverFlowPanelButton overFlowPanelButton = nvbCol[i].OverFlowPanelButton;

                if (overFlowPanelButton.IsOnOverFlowPanel &&
                    overFlowPanelButton.NavigateBarButton.IsDisplayed) // Eğer panel üzerindeki button ise // If is display
                {

                    if (addedBtnCount < displayableBtnCount) // Tüm buttonlar sığıyor // all buttons can visible
                    {
                        overFlowPanelButton.Left = Width - Math.Abs(i - 1 - nvbCol.Count) * NavigateBar.OVER_FLOW_BUTTON_WIDTH; // Tersten dizmek için
                        Controls.Add(overFlowPanelButton);
                        addedBtnCount++;
                    }
                    else // panel içerinde yer yoksa contextmenüye ekle // cannot show button add contextmenu
                    {
                        if (nvbCol[i].Enabled) // Eğer button disable ise menüye ekleme // if disable button then don't add context menu
                        {
                            if (!isMenuSeperatorAdded) // İlke defa alt menüler ekleniyor // fisrt menu item added, add sperator 
                            {
                                mnContextMenu.Items.Add(new ToolStripSeparator());
                                isMenuSeperatorAdded = true;
                            }

                            // Panel içerisinde yer almayacaklar için menü oluştur

                            mnContextMenu.Items.Add(overFlowPanelButton.NavigateBarButton.ContextMenuItem);

                        }

                        // Sığmayanlardan dolayı buttonları bir button geri al
                        // If added button cannot visible overflowpanel set new position for other buttons and display new addes button

                        for (int j = 0; j < Controls.Count; j++)
                            Controls[j].Left += NavigateBar.OVER_FLOW_BUTTON_WIDTH;

                    }

                }

            }

            // ContextMenu içim OK butonunu ekle
            // Add arrow button for context menu
            if (panelArrowBtn != null)
            {
                panelArrowBtn.Left = Width - panelArrowBtn.Width - 1;
                Controls.Add(panelArrowBtn);
            }

        }
        #endregion

        #region Overrided Methodlar
        public override void Refresh()
        {
            panelArrowBtn.IsSelected = false;
            base.Refresh();
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintThisControl();
        }

        protected override void OnResize(EventArgs e)
        {
            ReDisplayOverFlowButtons();
            Invalidate();
            base.OnResize(e);
        }
        #endregion

        #region Diğer Methodlar

        void PaintThisControl()
        {

            NavigateBarTheme theme = navigateBar.Theme;

            // Gradient olarak boyama işlemi
            // Paint gradient

            NavigateBarHelper.PaintGradientControl(this, theme.LightColor, theme.DarkColor, navigateBar.NavigateBarPaintAngle);
            Graphics g = this.CreateGraphics();

            // Etrafın çizgisi
            // draw rectangle

            g.DrawRectangle(new Pen(theme.DarkDarkColor), new Rectangle(0, 0, Width - 1, Height - 1));

            //

            g.Dispose();
        }

        #endregion
    }
}
