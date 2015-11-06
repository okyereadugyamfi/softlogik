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

namespace SoftLogik.Win.UI.Controls
{
    public sealed class RibbonPanelRenderEventArgs : RibbonRenderEventArgs
    {
        private RibbonPanel _panel;

        public RibbonPanelRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonPanel panel, System.Windows.Forms.Control canvas)
            : base(owner, g, clip)
        {
            Panel = panel;
            Canvas = canvas;
        }


        /// <summary>
        /// Gets or sets the panel related to the events
        /// </summary>
        public RibbonPanel Panel
        {
            get
            {
                return _panel;
            }
            set
            {
                _panel = value;
            }
        }

        private System.Windows.Forms.Control _canvas;

        /// <summary>
        /// Gets or sets the control where the panel is being rendered
        /// </summary>
        public System.Windows.Forms.Control Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }

    }
}
