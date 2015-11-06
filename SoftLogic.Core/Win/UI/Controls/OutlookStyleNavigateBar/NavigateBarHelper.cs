/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBar helper methods
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    class NavigateBarHelper
    {

        #region PaintGradientControl
        /// <summary>
        /// Paint gradient
        /// </summary>
        /// <param name="tControl">Painting control</param>
        /// <param name="tLightColor">Light Color</param>
        /// <param name="tDarkColor">Dark Color</param>
        public static void PaintGradientControl(Control tControl, Color tLightColor, Color tDarkColor)
        {
            NavigateBarHelper.PaintGradientControl(tControl, tLightColor, tDarkColor, NavigateBar.BUTTON_PAINT_ANGLE);
        }
        #endregion

        #region PaintGradientControl

        /// <summary>
        /// Paint gradient
        /// </summary>
        /// <param name="tControl">Painting control</param>
        /// <param name="tLightColor">Light Color</param>
        /// <param name="tDarkColor">Dark Color</param>
        /// <param name="tAngle">Angle for painting</param>
        public static void PaintGradientControl(Control tControl, Color tLightColor, Color tDarkColor, float tAngle)
        {

            Rectangle r = tControl.ClientRectangle;
            if (r.Width == 0 || r.Height == 0)
                return;

            Graphics g = tControl.CreateGraphics();
            using (LinearGradientBrush lgb = new LinearGradientBrush(r, tLightColor, tDarkColor, tAngle))
            {
                g.FillRectangle(lgb, r);
            }
            g.Dispose();

        }
        #endregion

        #region ConvertToGrayscale
        /// <summary>
        /// Convert image gray style
        /// </summary>
        /// <param name="tSourceBitmap">Bitmap source</param>
        /// <returns></returns>
        public static Bitmap ConvertToGrayscale(Bitmap tSourceBitmap)
        {

            Bitmap bitmap = new Bitmap(tSourceBitmap.Width, tSourceBitmap.Height);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color color = tSourceBitmap.GetPixel(x, y);
                    int luma = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    bitmap.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
                }
            }

            bitmap.MakeTransparent(); // Convert transparent

            return bitmap;
        }
        #endregion

        #region GetVerticalText
        /// <summary>
        /// Text ifadeyi dikey konuma getirir.
        /// </summary>
        /// <param name="tString">Text</param>
        /// <returns></returns>
        public static string GetVerticalText(string tString)
        {
            string vertText = "";

            foreach (char ch in tString)
                vertText += ch + "\n\r";

            return vertText;
        }
        #endregion

    }
}
