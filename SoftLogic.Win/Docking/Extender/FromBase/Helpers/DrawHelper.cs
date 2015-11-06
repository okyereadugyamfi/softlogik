using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SoftLogik.Win.UI.Controls.Docking
{
	public class DrawHelper
	{
		public static int bshift = 8;
        public static void DrawTab(Graphics g, Rectangle r, Corners corner, GradientType gradient, Color darkColor, Color lightColor, Color edgeColor, bool closed)
        {
            //dims
            Point[] points = null;
            GraphicsPath path = null;
            Region region = null;
            LinearGradientBrush linearBrush = null;
            Brush brush = null;
            Pen pen = null;
            r.Inflate(-1, -1);
            //set brushes

            switch (gradient)
            {

                case GradientType.Flat:
                    brush = new SolidBrush(darkColor);
                    break;
                case GradientType.Linear:
                    brush = new LinearGradientBrush(r, darkColor, lightColor, LinearGradientMode.Vertical);
                    break;
                case GradientType.Bell:
                    linearBrush = new LinearGradientBrush(r, darkColor, lightColor, LinearGradientMode.Vertical);
                    linearBrush.SetSigmaBellShape(0.17F, 0.67F);
                    brush = linearBrush;
                    break;
            }
            pen = new Pen(edgeColor, 1F);
            //generic points
            points = new Point[12] { new Point(r.Left, r.Bottom), new Point(r.Left, r.Bottom - bshift), new Point(r.Left, r.Top + bshift), new Point(r.Left, r.Top), new Point(r.Left + bshift, r.Top), new Point(r.Right - bshift, r.Top), new Point(r.Right, r.Top), new Point(r.Right, r.Top + bshift), new Point(r.Right, r.Bottom - bshift), new Point(r.Right, r.Bottom), new Point(r.Right - bshift, r.Bottom), new Point(r.Left + bshift, r.Bottom) };

            path = new GraphicsPath();
            switch (corner)
            {
                case Corners.LeftBottom:
                    path.AddLine(points[3], points[1]);
                    path.AddBezier(points[1], points[0], points[0], points[11]);
                    path.AddLine(points[11], points[9]);
                    path.AddLine(points[9], points[6]);
                    path.AddLine(points[6], points[3]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[3], points[1]);
                    g.DrawBezier(pen, points[1], points[0], points[0], points[11]);
                    g.DrawLine(pen, points[11], points[9]);
                    g.DrawLine(pen, points[9], points[6]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[6], points[3]);
                    }
                    break;
                case Corners.LeftTop:
                    path.AddLine(points[0], points[2]);
                    path.AddBezier(points[2], points[3], points[3], points[4]);
                    path.AddLine(points[4], points[6]);
                    path.AddLine(points[6], points[9]);
                    path.AddLine(points[9], points[0]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[0], points[2]);
                    g.DrawBezier(pen, points[2], points[3], points[3], points[4]);
                    g.DrawLine(pen, points[4], points[6]);
                    g.DrawLine(pen, points[6], points[9]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[9], points[0]);
                    }
                    break;

                case Corners.Bottom:
                    path.AddLine(points[1], points[3]);
                    path.AddBezier(points[1], points[0], points[0], points[11]);
                    path.AddLine(points[11], points[10]);
                    path.AddBezier(points[10], points[9], points[9], points[8]);
                    path.AddLine(points[8], points[6]);
                    path.AddLine(points[6], points[3]);
                    region = new Region(path);
                    g.FillRegion(brush, region);

                    g.DrawLine(pen, points[1], points[3]);
                    g.DrawBezier(pen, points[1], points[0], points[0], points[11]);
                    g.DrawLine(pen, points[11], points[10]);
                    g.DrawBezier(pen, points[10], points[9], points[9], points[8]);
                    g.DrawLine(pen, points[8], points[6]);

                    if (closed)
                    {
                        g.DrawLine(pen, points[6], points[3]);
                    }
                    break;

                case Corners.Top:
                    path.AddLine(points[0], points[2]);
                    path.AddBezier(points[2], points[3], points[3], points[4]);
                    path.AddLine(points[4], points[5]);
                    path.AddBezier(points[5], points[6], points[6], points[7]);
                    path.AddLine(points[7], points[9]);
                    path.AddLine(points[9], points[0]);
                    region = new Region(path);
                    g.FillRegion(brush, region);

                    g.DrawLine(pen, points[0], points[2]);
                    g.DrawBezier(pen, points[2], points[3], points[3], points[4]);
                    g.DrawLine(pen, points[4], points[5]);
                    g.DrawBezier(pen, points[5], points[6], points[6], points[7]);
                    g.DrawLine(pen, points[7], points[9]);

                    if (closed)
                    {
                        g.DrawLine(pen, points[9], points[0]);
                    }

                    break;
                case Corners.RightBottom:
                    path.AddLine(points[3], points[0]);
                    path.AddLine(points[0], points[10]);
                    path.AddBezier(points[10], points[9], points[9], points[8]);
                    path.AddLine(points[8], points[6]);
                    path.AddLine(points[6], points[3]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[3], points[0]);
                    g.DrawLine(pen, points[0], points[10]);
                    g.DrawBezier(pen, points[10], points[9], points[9], points[8]);
                    g.DrawLine(pen, points[8], points[6]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[6], points[3]);
                    }
                    break;
                case Corners.RightTop:
                    path.AddLine(points[0], points[3]);
                    path.AddLine(points[3], points[5]);
                    path.AddBezier(points[5], points[6], points[6], points[7]);
                    path.AddLine(points[7], points[9]);
                    path.AddLine(points[9], points[0]);
                    region = new Region(path);
                    g.FillRegion(brush, region);
                    g.DrawLine(pen, points[0], points[3]);
                    g.DrawLine(pen, points[3], points[5]);
                    g.DrawBezier(pen, points[5], points[6], points[6], points[7]);
                    g.DrawLine(pen, points[7], points[9]);
                    if (closed)
                    {
                        g.DrawLine(pen, points[9], points[0]);
                    }
                    break;
            }
        }
        public static void DrawDocumentTab(Graphics g, Rectangle rect, Color backColorBegin, Color backColorEnd, Color edgeColor, TabDrawType tabType, bool closed)
        {
            GraphicsPath path = null;
            Region region = null;
            Brush brush = null;
            Pen pen = null;
            brush = new LinearGradientBrush(rect, backColorBegin, backColorEnd, LinearGradientMode.Vertical);
            pen = new Pen(edgeColor, 1.0F);
            path = new GraphicsPath();

            if (tabType == TabDrawType.First)
            {
                path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
                path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
                path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
            }
            else
            {
                if (tabType == TabDrawType.Active)
                {
                    path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height, rect.Top + 2);
                    path.AddLine(rect.Left + rect.Height + 4, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                }
                else
                {
                    path.AddLine(rect.Left, rect.Top + 6, rect.Left + 4, rect.Top + 2);
                    path.AddLine(rect.Left + 8, rect.Top, rect.Right - 3, rect.Top);
                    path.AddLine(rect.Right - 1, rect.Top + 2, rect.Right - 1, rect.Bottom + 1);
                    path.AddLine(rect.Right - 1, rect.Bottom + 1, rect.Left, rect.Bottom + 1);
                }
            }
            region = new Region(path);
            g.FillRegion(brush, region);
            g.DrawPath(pen, path);
        }
    }
    public enum Corners : int
    {
        RightTop,
        LeftTop,
        LeftBottom,
        RightBottom,
        Bottom,
        Top
    }
    public enum TabDrawType : int
    {
        First,
        Active,
        Inactive
    }
    public enum GradientType : int
    {
        Flat,
        Linear,
        Bell
    }
}
