/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar caption description band
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    #region Class : NavigateBarCaptionDescription

    [Browsable(false)]
    [ToolboxItem(false)]
    class NavigateBarCaptionDescription : UserControl
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
        public NavigateBarCaptionDescription()
        {
            // Control
            Height = 20;
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
            NavigateBarHelper.PaintGradientControl(this, theme.LightColor, theme.DarkColor, navigateBar.NavigateBarPaintAngle);

            // Yazıyı yazma
            // Draw caption description text

            // If not empty text
            if (!string.IsNullOrEmpty(Caption))
            {
                g.DrawString(Caption,
                    new Font(SystemFonts.DialogFont.Name, 8, FontStyle.Regular),
                    new SolidBrush(SystemColors.ControlText),
                    8, (this.Height - SystemFonts.DialogFont.Height) / 2);
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
