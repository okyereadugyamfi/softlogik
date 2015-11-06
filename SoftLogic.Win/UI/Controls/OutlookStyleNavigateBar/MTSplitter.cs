using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// Splitter
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Splitter))]
    [Description("3D Splitter")]
    public class MTSplitter : Splitter
    {

        #region SplitterLightColor
        private Color splitterLightColor = ProfessionalColors.SeparatorLight;
        /// <summary>
        /// Get/Set, Splitter için açık renk
        /// </summary>
        [Browsable(true)]
        [Description("Splitter için açık renk")]
        [Category("MT Kontrol")]
        [DefaultValue(typeof(Color), "ProfessionalColors.SeparatorLight")]
        public Color SplitterLightColor
        {
            get { return splitterLightColor; }
            set
            {
                splitterLightColor = value;
                Invalidate();
            }
        }
        #endregion

        #region SplitterDarkColor
        private Color splitterDarkColor = ProfessionalColors.SeparatorDark;
        /// <summary>
        /// Get/Set, Splitter için koyu renk
        /// </summary>
        [Browsable(true)]
        [Description("Splitter için koyu renk")]
        [Category("MT Kontrol")]
        [DefaultValue(typeof(Color), "ProfessionalColors.SeparatorDark")]
        public Color SplitterDarkColor
        {
            get { return splitterDarkColor; }
            set
            {
                splitterDarkColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructors

        public MTSplitter()
        {
            this.Size = new Size(4, 100);
            
            this.SetCursorStyle();

            // DockStyle değiştirildiğinde
            this.DockChanged += delegate
            {
                this.SetCursorStyle();
            };

            // Sistem renkleri değiştirildiğinde
            this.SystemColorsChanged += delegate
            {
                this.SplitterDarkColor = ProfessionalColors.SeparatorDark;
                this.SplitterLightColor = ProfessionalColors.SeparatorLight;
            };
            
            // Tekrar boyutlandırıldığında
            this.Resize += delegate(object sender, EventArgs e)
            {
                this.Invalidate();
            };

        }


        void SetCursorStyle()
        {
            // Cursor Dock duruma göre değiştir

            if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right) // Dik durumda ise
                Cursor = Cursors.SizeWE;
            else if (this.Dock == DockStyle.Bottom || this.Dock == DockStyle.Top) // Yatay durumda ise
                Cursor = Cursors.SizeNS;
            else
                Cursor = Cursors.Default; // Kaplamış yada hiçbiri ise
        }

        #endregion

        #region OnPaintBackground : Drawing Method
        /// <summary>
        /// Splitter için nokta işaretlerini oluştur
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

            base.OnPaintBackground(pevent);

            Rectangle splitRectangle = this.ClientRectangle;

            if (!(splitRectangle.Width > 0 && splitRectangle.Height > 0))
                return;

            // Ters renk splitter içerisinde gözükmesi için

            Brush koyuRenk = new SolidBrush(this.SplitterDarkColor);
            Brush acikRenk = new SolidBrush(this.SplitterLightColor);

            // Eğer splitter dikey konumda ise 
            // Not : Splitter nesnesi DockStyle.Fill yada DockStyle.None değerlerini almıyor

            if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right) // Dikey konumda ise
            {
                // Splitter 3D görünümü ver
                using (Brush b = new LinearGradientBrush(splitRectangle, this.SplitterLightColor, this.SplitterDarkColor, LinearGradientMode.Horizontal))
                {
                    pevent.Graphics.FillRectangle(b, splitRectangle);
                }

                int noktaBoyut = 4, noktaYukseklik = 2;
                int noktaSayisi = Math.Min((splitRectangle.Height / noktaBoyut), 10);
                int ilkNoktaKoor = (splitRectangle.Height - (noktaSayisi * noktaBoyut)) / 2;
                int noktaLeft = (int)(this.Width / 2);

                // Kareleri oluştur
                for (int i = 0; i < noktaSayisi; i++)
                {
                    // Noktanın koyu rengi
                    pevent.Graphics.FillRectangle(koyuRenk, noktaLeft, ilkNoktaKoor, noktaYukseklik, noktaYukseklik);
                    // Noktanın açık rengi
                    pevent.Graphics.FillRectangle(acikRenk, noktaLeft, ilkNoktaKoor + 1, noktaYukseklik, noktaYukseklik);
                    ilkNoktaKoor += noktaBoyut;
                }


            }
            else if (this.Dock == DockStyle.Bottom || this.Dock == DockStyle.Top) // Eğer splitter yatay durumda ise
            {

                using (Brush b = new LinearGradientBrush(splitRectangle, this.SplitterLightColor, this.SplitterDarkColor, LinearGradientMode.Vertical))
                {
                    pevent.Graphics.FillRectangle(b, splitRectangle);
                }

                int noktaBoyut = 4, noktaYukseklik = 2;
                int noktaSayisi = Math.Min((splitRectangle.Width / noktaBoyut), 10);
                int ilkNoktaKoor = (splitRectangle.Width - (noktaSayisi * noktaBoyut)) / 2;
                int Y = (int)((splitRectangle.Height - 1) / 2);

                // Kareleri oluştur
                for (int i = 0; i < noktaSayisi; i++)
                {
                    pevent.Graphics.FillRectangle(koyuRenk, ilkNoktaKoor, Y, noktaYukseklik, noktaYukseklik);
                    pevent.Graphics.FillRectangle(acikRenk, ilkNoktaKoor + 1, Y + 1, noktaYukseklik, noktaYukseklik);
                    ilkNoktaKoor += noktaBoyut;
                }

            }

            if (koyuRenk is IDisposable)
                koyuRenk.Dispose();

            if (acikRenk is IDisposable)
                acikRenk.Dispose();

        }

        #endregion

    }
}
