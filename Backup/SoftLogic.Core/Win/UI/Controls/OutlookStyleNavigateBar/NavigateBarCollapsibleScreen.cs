/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar collapsible screen
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// If navigatebar width equal or small minimum size then show related control in this form
    /// </summary>
    class NavigateBarCollapsibleScreen : System.Windows.Forms.Form
    {

        #region Text
        public override string Text
        {
            get { return caption.Caption; }
            set { caption.Caption = value; }
        }
        #endregion

        #region IsShowWindow
        bool isShowWindow = false;
        public bool IsShowWindow
        {
            get { return isShowWindow; }
            set { isShowWindow = value; }
        }
        #endregion

        NavigateBar navigateBar = null;
        NavigateBarCaption caption = new NavigateBarCaption();
        Panel panelControl = new Panel();

        #region Yapıcı Method
        public NavigateBarCollapsibleScreen(NavigateBar tNavigateBar)
        {
            navigateBar = tNavigateBar;
            // Get positon on desktop screen
            Point p = new Point(navigateBar.Location.X + Width, navigateBar.Location.Y);
            DesktopLocation = this.PointToScreen(p);

            // Caption info
            caption.Height = 20;
            caption.NavigateBar = navigateBar;

            //
            panelControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(caption);
            Controls.Add(panelControl);

            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        #endregion

        #region overrided Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            NavigateBarHelper.PaintGradientControl(this, navigateBar.Theme.LightColor, navigateBar.Theme.DarkColor);
        }
        #endregion

        #region SetControl
        public void SetControl(Control tControl)
        {
            if (tControl == null)
                return;

            panelControl.Top = caption.Height + 2;
            panelControl.Left = 2;
            panelControl.Height = Height - caption.Height - 4;
            panelControl.Width = Width - 4;

            tControl.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(tControl);
            tControl.Focus();

        }
        #endregion
    }
}