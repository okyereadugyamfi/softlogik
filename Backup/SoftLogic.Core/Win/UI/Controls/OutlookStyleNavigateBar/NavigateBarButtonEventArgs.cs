/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBarButton event args
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    #region Class : NavigateBarButtonEventArgs

    /// <summary>
    /// NavigateBarButton EventArgs
    /// </summary>
    public sealed class NavigateBarButtonEventArgs : System.EventArgs
    {

        #region NavigateBarButton
        NavigateBarButton navigateBarButton;
        /// <summary>
        /// Selected NavigateBarButton
        /// </summary>
        public NavigateBarButton NavigateBarButton
        {
            get { return navigateBarButton; }
        }
        #endregion

        public NavigateBarButtonEventArgs(NavigateBarButton tNavigateBarButton)
        {
            if (tNavigateBarButton == null)
                throw new NullReferenceException("Cannot null tNavigateBarButton");

            navigateBarButton = tNavigateBarButton;
        }

    }
    #endregion
}
