using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SoftLogik.Win.UI.Form.Support
{
    public class DockableProfessionalColorTable : ProfessionalColorTable
    {

        #region ctors
            public DockableProfessionalColorTable() : base(){ }
        #endregion

        public override Color ButtonCheckedGradientBegin
        { 
            get{ return FromHex("");} 
        }
        public override Color ButtonCheckedGradientEnd { get; }
        public override Color ButtonCheckedGradientMiddle { get; }
        public override Color ButtonPressedBorder { get; }
        public override Color ButtonPressedGradientBegin { get; }
        public override Color ButtonPressedGradientEnd { get; }
        public override Color ButtonPressedGradientMiddle { get; }
        public override Color ButtonSelectedBorder { get; }
        public override Color ButtonSelectedGradientBegin { get; }
        public override Color ButtonSelectedGradientEnd { get; }
        public override Color ButtonSelectedGradientMiddle { get; }
        public override Color CheckBackground { get; }
        public override Color CheckPressedBackground { get; }
        public override Color CheckSelectedBackground { get; }
        public override Color GripDark { get; }
        public override Color GripLight { get; }
        public override Color ImageMarginGradientBegin { get; }
        public override Color ImageMarginGradientEnd { get; }
        public override Color ImageMarginGradientMiddle { get; }
        public override Color ImageMarginRevealedGradientBegin { get; }
        public override Color ImageMarginRevealedGradientEnd { get; }
        public override Color ImageMarginRevealedGradientMiddle { get; }
        public override Color MenuBorder { get; }
        public override Color MenuItemBorder { get; }
        public override Color MenuItemPressedGradientBegin { get; }
        public override Color MenuItemPressedGradientEnd { get; }
        public override Color MenuItemPressedGradientMiddle { get; }
        public override Color MenuItemSelected { get; }
        public override Color MenuItemSelectedGradientBegin { get; }
        public override Color MenuItemSelectedGradientEnd { get; }
        public override Color MenuStripGradientBegin { get; }
        public override Color MenuStripGradientEnd { get; }
        public override Color OverflowButtonGradientBegin { get; }
        public override Color OverflowButtonGradientEnd { get; }
        public override Color OverflowButtonGradientMiddle { get; }
        public override Color RaftingContainerGradientBegin { get; }
        public override Color RaftingContainerGradientEnd { get; }
        public override Color SeparatorDark { get; }
        public override Color SeparatorLight { get; }
        public override Color ToolStripBorder { get; }
        public override Color ToolStripDropDownBackground { get; }
        public override Color ToolStripGradientBegin { get; }
        public override Color ToolStripGradientEnd { get; }
        public override Color ToolStripGradientMiddle { get; }
        public override Color ToolStripPanelGradientBegin { get; }
        public override Color ToolStripPanelGradientEnd { get; }

        #region Methods

        private static Color FromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6) throw new Exception("Color not valid");

            return Color.FromArgb(
                int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
        }

        #endregion
    }
}
