using System;
using WeifenLuo.WinFormsUI;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SoftLogik.Win.UI.Controls.Docking
{
    public class DockPaneStripOverride : DockPaneStripVS2003
    {
        protected internal DockPaneStripOverride(DockPane pane)
            : base(pane)
        {
            BackColor = SystemColors.ControlLight;
        }
    }
}
