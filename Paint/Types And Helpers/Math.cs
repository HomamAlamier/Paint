using System;
using System.Drawing;
using math = System.Math;
namespace Paint
{
    public static class Math
    {
        //Original
        public static double PI { get => math.PI; }
        public static double Min(double a, double b) => math.Min(a, b);
        public static int Min(int a, int b) => math.Min(a, b);
        public static float Min(float a, float b) => math.Min(a, b);
        public static double Max(double a, double b) => math.Max(a, b);
        public static int Max(int a, int b) => math.Max(a, b);
        public static float Max(float a, float b) => math.Max(a, b);
        public static double Abs(double a) => math.Abs(a);
        public static double Atan(double a) => math.Atan(a);
        public static double Atan2(double a, double b) => math.Atan2(a, b);
        public static double Cos(double a) => math.Cos(a);
        public static double Sin(double a) => math.Sin(a);
        public static double Pow(double a, double b) => math.Pow(a, b);
        public static double Sqrt(double a) => math.Sqrt(a);

        //Custom
        public static double DisatnceBetween2Points(Point P, Point Q) => Sqrt(Pow(Q.X - P.X, 2) + Pow(Q.Y - P.Y, 2));
        public static double DisatnceBetween2Points(double P, double Q) => Sqrt(Pow(Q, 2) + Pow(P, 2));
        public static double ToDegree(double radians) => radians * 180 / PI;
        public static double ToRadian(double degrees) => degrees * PI / 180;
        public static PointF RotatePoint(PointF center, PointF point, float angle)
        {


            double cos = math.Cos(ToRadian(angle));
            double sin = math.Sin(ToRadian(angle));

            point.X -= center.X;
            point.Y -= center.Y;

            double xnew = point.X * cos - point.Y * sin;
            double ynew = point.X * sin + point.Y * cos;

            return new PointF(center.X + (float)xnew, center.Y + (float)ynew);
        }
        public static RectangleF RotateRectangle(RectangleF rect, float angle)
        {
            var ps = RotatePoint(rect.Center(), rect.Location, angle);
            var pe = RotatePoint(rect.Center(), rect.End(), angle);

            var p1 = Min(ps, pe);
            var p2 = Max(ps, pe);

            float w = p2.X - p1.X;
            float h = p2.Y - p1.Y;

            return new RectangleF(p1, new SizeF(w, h));

        }
        public static Point Min(Point a, Point b)
        {
            int p1 = a.X + a.Y;
            int p2 = b.X + b.Y;
            if (p1 < p2) return a;
            else return b;
        }
        public static Point Max(Point a, Point b)
        {
            int p1 = a.X + a.Y;
            int p2 = b.X + b.Y;
            if (p1 < p2) return b;
            else return a;
        }
        public static PointF Min(PointF a, PointF b)
        {
            return new PointF(a.X > b.X ? b.X : a.X
                , a.Y > b.Y ? b.Y : a.Y);
        }
        public static PointF Max(PointF a, PointF b)
        {
            return new PointF(a.X < b.X ? b.X : a.X
                 , a.Y < b.Y ? b.Y : a.Y);
        }

        public static PointF Max(PointF[] a)
        {
            if (a.Length == 0) return new PointF();
            else if (a.Length == 1) return a[0];
            else if (a.Length == 2) Max(a[0], a[1]);

            float maxX = a[0].X, maxY = a[0].Y;
            foreach (PointF pnt in a)
            {
                if (pnt.X > maxX) maxX = pnt.X;
                if (pnt.Y > maxY) maxY = pnt.Y;
            }
            return new PointF(maxX, maxY);
        }
        public static PointF Min(PointF[] a)
        {
            if (a.Length == 0) return new PointF();
            else if (a.Length == 1) return a[0];
            else if (a.Length == 2) Min(a[0], a[1]);
            float minX = a[0].X, minY = a[0].Y;
            foreach (PointF pnt in a)
            {
                if (pnt.X < minX) minX = pnt.X;
                if (pnt.Y < minY) minY = pnt.Y;
            }
            return new PointF(minX, minY);
        }
        public static float SizeTo_emSize(Graphics g,float size)
        {
            return g.DpiY * size / 72f;
        }
    }
}
