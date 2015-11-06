/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : Theme for NavigateBar and Sub-Controls
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{

    // TODO : Office2007 color theme
    // TODO : Use ProfessionalColorTable

    #region NavigateBarTheme
    /// <summary>
    /// Theme class. 
    /// </summary>
    public sealed class NavigateBarTheme : IComparable<NavigateBarTheme>
    {

        #region Theme : SystemColor
        /// <summary>
        /// Default ThemeColor. Using system colors
        /// </summary>
        public static NavigateBarTheme SystemColor
        {
            get
            {
                NavigateBarTheme theme = new NavigateBarTheme();

                theme.LightColor = ProfessionalColors.ToolStripGradientMiddle;
                theme.DarkColor = ProfessionalColors.ToolStripGradientEnd;
                theme.DarkDarkColor = ProfessionalColors.MenuBorder;

                theme.MouseOverLightColor = ProfessionalColors.ButtonSelectedGradientBegin;
                theme.MouseOverDarkColor = ProfessionalColors.ButtonSelectedGradientEnd;

                theme.SelectedLightColor = ProfessionalColors.ButtonPressedGradientBegin;
                theme.SelectedDarkColor = ProfessionalColors.ButtonPressedGradientEnd;

                return theme;
            }
        }
        #endregion

        #region Theme : BlueColor
        /// <summary>
        /// Blue based theme
        /// </summary>
        public static NavigateBarTheme BlueColor
        {
            get
            {
                NavigateBarTheme theme = new NavigateBarTheme();

                theme.LightColor = Color.FromArgb(203, 225, 252);
                theme.DarkColor = Color.FromArgb(126, 166, 225);
                theme.DarkDarkColor = Color.FromArgb(0, 0, 160);

                theme.MouseOverLightColor = Color.FromArgb(255, 255, 220);
                theme.MouseOverDarkColor = Color.FromArgb(247, 192, 91);

                theme.SelectedLightColor = Color.FromArgb(251, 230, 148);
                theme.SelectedDarkColor = Color.FromArgb(239, 150, 21);

                return theme;
            }
        }
        #endregion

        #region Theme : OliveColor
        /// <summary>
        /// Green based theme
        /// </summary>
        public static NavigateBarTheme OliveColor
        {
            get
            {
                NavigateBarTheme theme = new NavigateBarTheme();

                theme.LightColor = Color.FromArgb(234, 240, 207);
                theme.DarkColor = Color.FromArgb(178, 193, 140);
                theme.DarkDarkColor = Color.FromArgb(139, 161, 105);

                theme.MouseOverLightColor = Color.FromArgb(255, 255, 220);
                theme.MouseOverDarkColor = Color.FromArgb(247, 192, 91);

                theme.SelectedLightColor = Color.FromArgb(251, 230, 148);
                theme.SelectedDarkColor = Color.FromArgb(239, 150, 21);

                return theme;
            }
        }
        #endregion

        #region Theme : SilverColor
        /// <summary>
        /// Gray based theme
        /// </summary>
        public static NavigateBarTheme SilverColor
        {
            get
            {
                NavigateBarTheme theme = new NavigateBarTheme();

                theme.LightColor = Color.FromArgb(225, 226, 236);
                theme.DarkColor = Color.FromArgb(150, 148, 178);
                theme.DarkDarkColor = Color.FromArgb(150, 148, 178);

                theme.MouseOverLightColor = Color.FromArgb(255, 255, 220);
                theme.MouseOverDarkColor = Color.FromArgb(247, 192, 91);

                theme.SelectedLightColor = Color.FromArgb(251, 230, 148);
                theme.SelectedDarkColor = Color.FromArgb(239, 150, 21);

                return theme;
            }
        }
        #endregion

        #region Theme : VS2005Color
        /// <summary>
        /// Gray based theme
        /// </summary>
        public static NavigateBarTheme VS2005Color
        {
            get
            {
                NavigateBarTheme theme = new NavigateBarTheme();

                PropertyGridEx.CustomColorScheme customScheme = new PropertyGridEx.CustomColorScheme();
                theme.LightColor = customScheme.ToolStripGradientMiddle;
                theme.DarkColor = customScheme.ToolStripGradientEnd;
                theme.DarkDarkColor = customScheme.MenuBorder;

                theme.MouseOverLightColor = customScheme.ButtonSelectedGradientBegin;
                theme.MouseOverDarkColor = customScheme.ButtonSelectedGradientEnd;

                theme.SelectedLightColor = customScheme.ButtonPressedGradientBegin;
                theme.SelectedDarkColor = customScheme.ButtonPressedGradientEnd;


                return theme;   
            }
        }
        #endregion

        #region Properties

        Color darkColor;
        public Color DarkColor
        {
            get { return darkColor; }
            set { darkColor = value; }
        }

        Color lightColor;
        public Color LightColor
        {
            get { return lightColor; }
            set { lightColor = value; }
        }

        Color darkDarkColor;
        public Color DarkDarkColor
        {
            get { return darkDarkColor; }
            set { darkDarkColor = value; }
        }

        Color mouseOverDarkColor;
        public Color MouseOverDarkColor
        {
            get { return mouseOverDarkColor; }
            set { mouseOverDarkColor = value; }
        }

        Color mouseOverLightColor;
        public Color MouseOverLightColor
        {
            get { return mouseOverLightColor; }
            set { mouseOverLightColor = value; }
        }

        Color selectedDarkColor;
        public Color SelectedDarkColor
        {
            get { return selectedDarkColor; }
            set { selectedDarkColor = value; }
        }

        Color selectedLightColor;
        public Color SelectedLightColor
        {
            get { return selectedLightColor; }
            set { selectedLightColor = value; }
        }

        #endregion

        #region Overrided Methods
        /// <summary>
        /// Return LightColor and DarkColor info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "LightColor : " + lightColor.ToString() + " DarkColor : " + darkColor.ToString();
        }
        #endregion

        #region IComparable<NavigateBarTheme> Members

        /// <summary>
        /// Compare themes
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(NavigateBarTheme other)
        {

            // Not: Alfa renk kayıt edilen ile geri dönen uyuşmuyor

            if (other.DarkColor.R != this.DarkColor.R ||
                other.DarkColor.G != this.DarkColor.G ||
                other.DarkColor.B != this.DarkColor.B)
                return -1;
            if (other.DarkDarkColor.R != this.DarkDarkColor.R ||
                other.DarkDarkColor.G != this.DarkDarkColor.G ||
                other.DarkDarkColor.B != this.DarkDarkColor.B)
                return -1;
            if (other.LightColor.R != this.LightColor.R ||
                other.LightColor.G != this.LightColor.G ||
                other.LightColor.B != this.LightColor.B)
                return -1;
            if (other.MouseOverDarkColor.R != this.MouseOverDarkColor.R ||
                other.MouseOverDarkColor.G != this.MouseOverDarkColor.G ||
                other.MouseOverDarkColor.B != this.MouseOverDarkColor.B)
                return -1;
            if (other.MouseOverLightColor.R != this.MouseOverLightColor.R ||
                other.MouseOverLightColor.G != this.MouseOverLightColor.G ||
                other.MouseOverLightColor.B != this.MouseOverLightColor.B)
                return -1;
            if (other.SelectedDarkColor.R != this.SelectedDarkColor.R ||
                other.SelectedDarkColor.G != this.SelectedDarkColor.G ||
                other.SelectedDarkColor.B != this.SelectedDarkColor.B)
                return -1;
            if (other.SelectedLightColor.R != this.SelectedLightColor.R ||
                other.SelectedLightColor.G != this.SelectedLightColor.G ||
                other.SelectedLightColor.B != this.SelectedLightColor.B)
                return -1;

            return 0;
        }

        #endregion
    }
    #endregion

}
