/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar collapsible screen text
 * 
 */

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// if show collapsible screen then display caption text on this control
    /// </summary>
    class NavigateBarCollapsibleText : Panel
    {

        #region NavigateBar
        NavigateBar navigateBar;
        public NavigateBar NavigateBar
        {
            set
            {
                navigateBar = value;
                Invalidate();
            }
        }
        #endregion

        #region ContentText
        string contentText = "";
        public string ContentText
        {
            get { return contentText; }
            set
            {
                contentText = value;
                Invalidate();
            }
        }
        #endregion

        #region ContentImage
        Image contentImage = null;
        public Image ContentImage
        {
            get { return contentImage; }
            set
            {
                contentImage = value;
                Invalidate();
            }
        }
        #endregion

        bool isMouseOver = false;

        #region Overrided Methods

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isMouseOver = false;
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;// CreateGraphics();
            Rectangle recImage = new Rectangle(2, 12, 18, 18);

            string text = NavigateBarHelper.GetVerticalText(ContentText);

            Brush brushTextColor;

            if (isMouseOver)
                brushTextColor = new SolidBrush(Color.Black);
            else
                brushTextColor = SystemBrushes.ActiveCaptionText;

            NavigateBarHelper.PaintGradientControl(this, navigateBar.Theme.LightColor, navigateBar.Theme.DarkColor, 180F);
            g.DrawImage(ContentImage, recImage);
            g.DrawString(text, new Font("Tahoma", 11, FontStyle.Bold), brushTextColor, 4, 40);

            g.Dispose();
        }
        #endregion

    }
}
