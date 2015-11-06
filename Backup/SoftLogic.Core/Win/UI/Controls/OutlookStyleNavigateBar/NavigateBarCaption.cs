/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar caption band
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    #region Class : NavigateBarCaption

    [Browsable(false)]
    [ToolboxItem(false)]
    class NavigateBarCaption : UserControl
    {

        #region Caption
        private string caption = "";
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                Invalidate();
            }
        }
        #endregion

        #region Image
        Image image = null;
        public Image Image
        {
            get { return image; }
            set { image = value; }
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

        #region Yapıcı Metod
        public NavigateBarCaption()
        {
            // Control
            Height = SystemInformation.CaptionHeight;// 24;
            Dock = DockStyle.Top;

        }
        #endregion

        #region Overrided Method
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintThisControl();
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
        #endregion

        #region Diğer Metodlar
        void PaintThisControl()
        {

            NavigateBarTheme theme = navigateBar.Theme;

            // Gradient olarak boyama işlemi
            // Paint gradient

            Graphics g = this.CreateGraphics();
            NavigateBarHelper.PaintGradientControl(this, theme.DarkColor, theme.DarkDarkColor, navigateBar.NavigateBarPaintAngle);

            // Image

            if (image != null)
            {
                Rectangle recImage;
                recImage = new Rectangle(4, (Height - 16) / 2, 16, 16);
                g.DrawImage(image, recImage);
            }

            // Yazıyı yazma
            // Draw caption text

            // Eğer boşsa bence göstermesin 
            // If not empty caption text 
            if (!string.IsNullOrEmpty(Caption)) 
            {
                g.DrawString(Caption,
                    new Font(SystemFonts.DialogFont.Name, 11, FontStyle.Bold),
                    SystemBrushes.ControlLightLight, image == null ? 8 : 24, (Height - SystemFonts.DialogFont.GetHeight()) / 2 - 2);

                //image == null ? 8 : image.Width + 4, (this.Height - SystemFonts.DialogFont.Height) / 2);
            }

            // Etrafın çizgisi
            // Draw rectangle
            g.DrawRectangle(new Pen(theme.DarkDarkColor), new Rectangle(0, 0, Width - 1, Height));

            //

            g.Dispose();
        }
        #endregion

    }

    #endregion
}
