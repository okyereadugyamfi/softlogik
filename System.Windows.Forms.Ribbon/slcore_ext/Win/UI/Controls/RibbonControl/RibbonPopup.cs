/*
 
 2008 José Manuel Menéndez Poo
 * 
 * Please give me credit if you use this code. It's all I ask.
 * 
 * Contact me for more info: menendezpoo@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;

namespace SoftLogik.Win.UI.Controls
{
    [ToolboxItemAttribute(false)]
    public class RibbonPopup
        : System.Windows.Forms.Control
    {
        #region Fields
        private System.Windows.Forms.ToolStripDropDown _toolStripDropDown;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the popup is closed
        /// </summary>
        public event EventHandler Closed;

        #endregion

        #region Props

        /// <summary>
        /// Gets the related ToolStripDropDown
        /// </summary>
        public System.Windows.Forms.ToolStripDropDown ToolStripDropDown
        {
            get { return _toolStripDropDown; }
            set { _toolStripDropDown = value; }
        }


        #endregion

        #region Methods

        public void Show(Point screenLocation)
        {
            System.Windows.Forms.ToolStripControlHost host = new System.Windows.Forms.ToolStripControlHost(this);
            ToolStripDropDown = new System.Windows.Forms.ToolStripDropDown();
            ToolStripDropDown.Items.Clear();
            ToolStripDropDown.Items.Add(host);

            ToolStripDropDown.Padding = System.Windows.Forms.Padding.Empty;
            ToolStripDropDown.Margin = System.Windows.Forms.Padding.Empty;
            host.Padding = System.Windows.Forms.Padding.Empty;
            host.Margin = System.Windows.Forms.Padding.Empty;

            ToolStripDropDown.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(ToolStripDropDown_Closed);

            ToolStripDropDown.Show(screenLocation);
        }

        void ToolStripDropDown_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
        {
            OnClosed(EventArgs.Empty);
        }

        public void Close()
        {
            if (ToolStripDropDown != null)
            {
                ToolStripDropDown.Close();
            }
        }

        protected virtual void OnClosed(EventArgs e)
        {
            if (Closed != null)
            {
                Closed(this, e);
            }
        }

        #endregion
    }
}
