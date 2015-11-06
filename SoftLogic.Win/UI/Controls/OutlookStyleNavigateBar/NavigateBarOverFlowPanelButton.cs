using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

 
namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// OverFlowPanel button control
    /// </summary>
    [ToolboxItem(false)]
    class NavigateBarOverFlowPanelButton : UserControl
    {

        #region IsSelected
        bool isSelected = false;
        [Category("NavigateBarButton")]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                Invalidate();
            }
        }
        #endregion

        #region IsOnOverFlowPanel
        bool isOnOverFlowPanel = false;
        [Category("NavigateBarButton")]
        public bool IsOnOverFlowPanel
        {
            get { return isOnOverFlowPanel; }
            set { isOnOverFlowPanel = value; }
        }
        #endregion

        #region NavigateBarButton
        NavigateBarButton navigateBarButton;
        public NavigateBarButton NavigateBarButton
        {
            get { return navigateBarButton; }
            set
            {
                if (navigateBarButton != null)
                {
                    navigateBarButton = value;
                    if (navigateBarButton.NavigateBar != null)
                        Invalidate();

                }

            }
        }
        #endregion

        static ToolTip toolTip = new ToolTip();

        #region Yapıcı Methodlar

        public NavigateBarOverFlowPanelButton(NavigateBarButton tNavigateBarButton)
        {
            navigateBarButton = tNavigateBarButton;
            InitOverFlowButton();
        }

        void InitOverFlowButton()
        {
            this.Width = NavigateBar.OVER_FLOW_BUTTON_WIDTH;
            this.Height = NavigateBar.BUTTON_HEIGHT - 2; // Alt üst çizgilerin görünmesi için -2 ve 1 // for display button line (top & bottom)
            this.Top = 1;
            this.Tag = "BUTTON";
            toolTip.ShowAlways = true;
            toolTip.InitialDelay = 200;
            toolTip.AutomaticDelay = 200;
        }
        #endregion

        #region Overrided Methodlar
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintThisControl(PaintType.Normal);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            PaintThisControl(PaintType.MouseOver);
            toolTip.SetToolTip(this, navigateBarButton.ToolTipText);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            PaintThisControl(PaintType.Normal);
            toolTip.RemoveAll();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            toolTip.RemoveAll();
            // Only left click
            if (e.Button == MouseButtons.Left) // Sadece sol click ile button seçilebilmeli
                IsSelected = true;
        }
        #endregion

        #region Drawing Method
        void PaintThisControl(PaintType paintType)
        {
            NavigateBarTheme theme = navigateBarButton.NavigateBar.Theme;

            Color lightColor = theme.LightColor;
            Color darkColor = theme.DarkColor;

            Image imageButton = null;
            switch (paintType)
            {
                case PaintType.Normal:
                    {
                        imageButton = isSelected ? navigateBarButton.SelectedImage : navigateBarButton.Image;
                        lightColor = isSelected ? theme.SelectedLightColor : theme.LightColor;
                        darkColor = isSelected ? theme.SelectedDarkColor : theme.DarkColor;
                        break;
                    }
                case PaintType.Selected:
                    {
                        imageButton = NavigateBarButton.SelectedImage;
                        lightColor = isSelected ? theme.SelectedLightColor : theme.LightColor;
                        darkColor = isSelected ? theme.SelectedDarkColor : theme.DarkColor;
                        break;
                    }
                case PaintType.MouseOver:
                    {
                        lightColor = isSelected ? theme.SelectedLightColor : theme.MouseOverLightColor;
                        darkColor = isSelected ? theme.SelectedDarkColor : theme.MouseOverDarkColor;
                        imageButton = isSelected ? navigateBarButton.SelectedImage : navigateBarButton.MouseOverImage;
                        break;
                    }
            }

            // Gradient olarak boyama işlemi
            // Paint gradient

            NavigateBarHelper.PaintGradientControl(this, lightColor, darkColor, navigateBarButton.NavigateBar.NavigateBarPaintAngle);
            Graphics g = this.CreateGraphics();

            // Image

            // OverFlowPanelde mutlaka bir image gösterilmeli
            // Image must display on panel
            if (imageButton == null)
                imageButton  = SoftLogik.Win.Properties.Resources.NoImage; 

            if (!this.Enabled)
                imageButton = navigateBarButton.DisableImage;

            Rectangle recImage;
            if (this.Tag.Equals("BUTTON")) // Normal button daha küçük görünmeli
                recImage = new Rectangle((Width - imageButton.Width + 6) / 2, (Height - imageButton.Height + 6) / 2, imageButton.Width - 6, imageButton.Height - 6);
            else // OK için olduğu gibi kullan
                recImage = new Rectangle((Width - imageButton.Width) / 2, (Height - imageButton.Height) / 2, imageButton.Width, imageButton.Height);

            g.DrawImage(imageButton, recImage);

            //

            g.Dispose();
        }
        #endregion

    }
}
