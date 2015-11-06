using System;
using WeifenLuo.WinFormsUI;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SoftLogik.Win.UI.Docking
{
    public class AutoHideStripOverride : AutoHideStripVS2003
    {
        protected internal AutoHideStripOverride(DockPanel dockPanel)
            : base(dockPanel)
        {
            BackColor = Color.Yellow;
        }
    }
}