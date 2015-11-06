/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar save and restore settings class
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// Save and restore last settings in XML file for navigatebar and buttons.
    /// </summary>
    class NavigateBarSettings
    {

        #region DisplayedButtonCount
        int displayedbuttonCount = 0;
        /// <summary>
        /// How many button displayed in panel on exit ? (Get)
        /// </summary>
        public int DisplayedButtonCount
        {
            get { return displayedbuttonCount; }
        }
        #endregion

        #region PaintAngle
        float paintAngle = NavigateBar.BUTTON_PAINT_ANGLE;
        /// <summary>
        /// What is paint angle on exit ? (Get)
        /// </summary>
        public float PaintAngle
        {
            get { return paintAngle; }
        }
        #endregion

        #region Theme
        NavigateBarTheme theme = NavigateBarTheme.VS2005Color;
        /// <summary>
        /// Theme info on exit ? (Get)
        /// </summary>
        public NavigateBarTheme Theme
        {
            get { return theme; }
        }
        #endregion

        #region ButtonRestoreInfo
        Dictionary<string, ButtonRestoreSettings> restoreInfo = new Dictionary<string, ButtonRestoreSettings>();
        /// <summary>
        /// Buttons info. string parameter is NavigateBarButton.Key value.
        /// </summary>
        public Dictionary<string, ButtonRestoreSettings> ButtonRestoreInfo
        {
            get { return restoreInfo; }
        }
        #endregion

        #region ButtonHeight
        int buttonHeight = NavigateBar.BUTTON_HEIGHT;
        /// <summary>
        /// What is button height on exit ? (Get)
        /// </summary>
        public int ButtonHeight
        {
            get { return buttonHeight; }
        }
        #endregion

        #region IsLoad
        bool isLoad = true;
        /// <summary>
        /// Is load setting from XML file ?
        /// </summary>
        public bool IsLoad
        {
            get { return isLoad; }
        }
        #endregion

        //Var

        /// <summary>
        /// Full path for setting file
        /// </summary>
        string settingsFileName = "";

        NavigateBar navigateBar;

        #region Yapıcı Method
        public NavigateBarSettings(NavigateBar tNavigateBar)
        {
            navigateBar = tNavigateBar;

            theme = tNavigateBar.Theme;

            // Setting file  (Her kullanıcının kendi dizininde)

            settingsFileName = Application.UserAppDataPath + "\\NavigateBarSettings.xml";

            //
            RestoreSettingsFromXmlFile();

        }
        #endregion

        #region Save Settings

        /// <summary>
        /// Save settings in XML file
        /// </summary>
        public void SaveSettingsToXmlFile()
        {

            if (!navigateBar.SaveAndRestoreSettings)
            {
                if (File.Exists(settingsFileName))
                    File.Delete(settingsFileName);

                return;
            }

            if (navigateBar.NavigateBarButtons.Count < 0) return;

            int dispCount = navigateBar.NavigateBarButtons.GetDisplayedItemCount();

            XmlTextWriter xtw = new XmlTextWriter(settingsFileName, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument(true);

            // Comment
            xtw.WriteComment("Outlook 2003 Style Navigation Pane Settings");
            xtw.WriteComment("Do not manual change this file");

            // Navigatebar panel info
            xtw.WriteStartElement("NavigateBarSettings");
            xtw.WriteAttributeString("DiplayedButtonCount", dispCount.ToString());
            xtw.WriteAttributeString("ButtonHeight", navigateBar.NavigateBarButtonHeight.ToString());
            xtw.WriteAttributeString("PaintAngle", navigateBar.NavigateBarPaintAngle.ToString());

            // Theme info
            xtw.WriteAttributeString("LightColor", navigateBar.Theme.LightColor.ToArgb().ToString());
            xtw.WriteAttributeString("DarkColor", navigateBar.Theme.DarkColor.ToArgb().ToString());
            xtw.WriteAttributeString("DarkDarkColor", navigateBar.Theme.DarkDarkColor.ToArgb().ToString());

            xtw.WriteAttributeString("MouseOverLightColor", navigateBar.Theme.MouseOverLightColor.ToArgb().ToString());
            xtw.WriteAttributeString("MouseOverDarkColor", navigateBar.Theme.MouseOverDarkColor.ToArgb().ToString());

            xtw.WriteAttributeString("SelectedLightColor", navigateBar.Theme.SelectedLightColor.ToArgb().ToString());
            xtw.WriteAttributeString("SelectedDarkColor", navigateBar.Theme.SelectedDarkColor.ToArgb().ToString());

            // Buttons info
            for (int i = 0; i < navigateBar.NavigateBarButtons.Count; i++)
            {
                NavigateBarButton nvb = navigateBar.NavigateBarButtons[i];
                // If null or empty key value skip this button
                if (!string.IsNullOrEmpty(nvb.Key)) // Key boş bırakılan buttonlar xml içerisine kayıt edilmiyor
                {
                    xtw.WriteStartElement(nvb.Key.Replace(" ", ""));
                    xtw.WriteAttributeString("Enabled", nvb.Enabled.ToString());
                    xtw.WriteAttributeString("Display", nvb.IsDisplayed.ToString());
                    xtw.WriteAttributeString("Visible", nvb.Visible.ToString());
                    xtw.WriteAttributeString("Selected", nvb.IsSelected.ToString());
                    xtw.WriteAttributeString("OrderNo", i.ToString());
                    xtw.WriteEndElement();
                }
            }

            xtw.WriteEndElement(); // NavigateBarSettings

            xtw.Flush();
            xtw.Close();
        }
        #endregion

        #region Restore Settings
        /// <summary>
        /// Restore settings from XML file
        /// </summary>
        void RestoreSettingsFromXmlFile()
        {

            if (!File.Exists(settingsFileName))
            {
                isLoad = false;
                return;
            }

            restoreInfo.Clear();

            try
            {
                XmlTextReader xtr = new XmlTextReader(settingsFileName);

                while (xtr.Read())
                {

                    if (xtr.NodeType == XmlNodeType.Element)
                    {
                        // NavigateBar
                        if (xtr.Name.Equals("NavigateBarSettings") && xtr.HasAttributes)
                        {
                            for (int i = 0; i < xtr.AttributeCount; i++)
                            {
                                xtr.MoveToAttribute(i);
                                if (xtr.Name.Equals("DiplayedButtonCount")) displayedbuttonCount = Convert.ToInt32(xtr.Value);
                                if (xtr.Name.Equals("ButtonHeight")) buttonHeight = Convert.ToInt32(xtr.Value);
                                if (xtr.Name.Equals("PaintAngle")) paintAngle = (float)Convert.ToInt32(xtr.Value);
                                if (xtr.Name.Equals("LightColor")) theme.LightColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                                if (xtr.Name.Equals("DarkColor")) theme.DarkColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                                if (xtr.Name.Equals("DarkDarkColor")) theme.DarkDarkColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                                if (xtr.Name.Equals("MouseOverLightColor")) theme.MouseOverLightColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                                if (xtr.Name.Equals("MouseOverDarkColor")) theme.MouseOverDarkColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                                if (xtr.Name.Equals("SelectedLightColor")) theme.SelectedLightColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                                if (xtr.Name.Equals("SelectedDarkColor")) theme.SelectedDarkColor = Color.FromArgb(Convert.ToInt32(xtr.Value));
                            }
                            continue;
                        }

                        // Buttons
                        ButtonRestoreSettings brs = new ButtonRestoreSettings();
                        brs.Key = xtr.Name;

                        if (xtr.HasAttributes)
                        {
                            for (int i = 0; i < xtr.AttributeCount; i++)
                            {
                                xtr.MoveToAttribute(i);
                                if (xtr.Name.Equals("Enabled")) brs.Enabled = xtr.Value.Equals("True");
                                if (xtr.Name.Equals("Display")) brs.Display = xtr.Value.Equals("True");
                                if (xtr.Name.Equals("Visible")) brs.Visible = xtr.Value.Equals("True");
                                if (xtr.Name.Equals("Selected")) brs.Selected = xtr.Value.Equals("True");
                                if (xtr.Name.Equals("OrderNo")) brs.Order = Convert.ToInt32(xtr.Value);
                            }
                        }

                        restoreInfo.Add(brs.Key, brs);
                    }

                } //while
            }
            catch { isLoad = false; }
        }
        #endregion

        #region Overrided Method
        public override string ToString()
        {
            return "NavigateBarSettings";
        }
        #endregion

        #region SubClass ButtonRestoreSettings
        internal class ButtonRestoreSettings
        {
            string key = "";
            public string Key
            {
                get { return key; }
                set { key = value; }
            }

            bool visible = true;
            public bool Visible
            {
                get { return visible; }
                set { visible = value; }
            }

            bool enabled = true;
            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            bool selected = false;
            public bool Selected
            {
                get { return selected; }
                set { selected = value; }
            }

            bool display = true;
            public bool Display
            {
                get { return display; }
                set { display = value; }
            }

            int order = 0;
            public int Order
            {
                get { return order; }
                set { order = value; }
            }
        }
        #endregion
    }
}
