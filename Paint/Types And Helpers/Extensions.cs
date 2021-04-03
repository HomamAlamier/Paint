using System.Drawing;
using System.Collections.Generic;
using System;
using System.Drawing.Drawing2D;

namespace Paint
{
    static class PointExtension
    {
        public static Point Offset(this Point point, Point p1)
        {
            return new Point(point.X + p1.X, point.Y + p1.Y);
        }
        public static PointF Offset(this PointF point, PointF p1)
        {
            return new PointF(point.X + p1.X, point.Y + p1.Y);
        }
        public static PointF Offset(this PointF point, float x, float y)
        {
            return new PointF(point.X + x, point.Y + y);
        }
    }
    static class RectangleExtension
    {
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2));
        }
        public static Point End(this Rectangle rectangle)
        {
            return new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);
        }
        public static PointF Center(this RectangleF rectangle)
        {
            return new PointF(rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2));
        }
        public static PointF End(this RectangleF rectangle)
        {
            return new PointF(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);
        }
    }
    static class GraphicsExtensions
    {
        public static void DrawRectangle(this Graphics g, Pen pen, RectangleF rect)
        {
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
    static class BitmapExtensions
    {
        public static Bitmap DrawControl(System.Windows.Forms.Control control)
        {
            Bitmap x = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(x, control.ClientRectangle);
            return x;
        }
    }
    static class ColorExtensions
    {
        public static bool IsEquals(this Color col,Color col2)
        {
            return col.R == col2.R && col.G == col2.G && col.B == col2.B;
        }
    }

    [Serializable]
    public class GraphicsPath
    {
        public PointF[] PathPoints { get; set; }
        public byte[] PathTypes { get; set; }
        public FillMode FillMode { get; set; }
        public System.Drawing.Drawing2D.GraphicsPath getPath()
        {
            if (PathPoints != null && PathTypes != null)
            {
                return new System.Drawing.Drawing2D.GraphicsPath(PathPoints, PathTypes, FillMode);
            }
            return new System.Drawing.Drawing2D.GraphicsPath();
        }
        public GraphicsPath() { }
        public GraphicsPath(Point[] PathPoints,byte[] PathTypes)
        {
            this.PathPoints = new PointF[PathPoints.Length];
            for (int ind = 0; ind < PathPoints.Length; ind++)
            {
                this.PathPoints[ind] = new PointF(PathPoints[ind].X, PathPoints[ind].Y);
            }
            this.PathTypes = PathTypes;
        }
        public GraphicsPath(PointF[] PathPoints,byte[] PathTypes)
        {
            this.PathPoints = PathPoints;
            this.PathTypes = PathTypes;
        }
        public int PointCount => PathPoints.Length;
        public void AddLines(PointF[] data)
        {
            var p = getPath();
            p.AddLines(data);
            PathPoints =p.PathPoints;
            PathTypes = p.PathTypes;
        }
        public void AddLines(Point[] data)
        {
            if (data.Length == 0) return;
            var p = getPath();
            p.AddLines(data);
            PathPoints = p.PathPoints;
            PathTypes = p.PathTypes;
        }
        public void Transform(Matrix data)
        {
            var p = getPath();
            p.Transform(data);
            PathPoints = p.PathPoints;
            PathTypes = p.PathTypes;
        }
        public void AddString(string text,FontFamily family,int style,float sizeEm,PointF pnt,StringFormat fmt)
        {
            var p = getPath();
            p.AddString(text, family, style, sizeEm, pnt, fmt);
            PathPoints = p.PathPoints;
            PathTypes = p.PathTypes;
        }
    }
}
