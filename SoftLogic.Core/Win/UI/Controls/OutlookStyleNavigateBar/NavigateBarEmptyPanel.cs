/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar related control container panel
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// Show related control on this panel
    /// </summary>
    class NavigateBarRelatedControlPanel : Panel
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

        public NavigateBarRelatedControlPanel()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #region Overrided Methodlar
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            NavigateBarHelper.PaintGradientControl(this,navigateBar.Theme.LightColor, navigateBar.Theme.DarkColor);
        }
        #endregion
    }
}
