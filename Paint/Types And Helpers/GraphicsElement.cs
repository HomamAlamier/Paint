using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System.Windows.Forms;

namespace Paint
{
    [Serializable]
    public class GraphicsElement
    {
        SizeF sz;
        int alpha = 255;
        public ElementType Type { get; set; }
        public float Angle { get; set; }
        public PointF Position { get; set; }
        public SizeF Size { get => sz; set { sz = value; } }
        public RectangleF ClientRectangle { get => new RectangleF(Position, Size); }
        public Image Image { get; set; }
        public GraphicsPath Path { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public float Scale { get; set; }
        public int Transparency
        {
            get => alpha; set
            {
                alpha = value > 255 ? 255 : value;
                update_Transparency();
            }
        }
        public string Text { get; set; }
        public Font Font { get; set; }
        public bool Filled { get; set; }
        public string Name { get; set; }
        public GraphicsElement(SizeF size)
        {
            Position = new PointF();
            this.Size = size;
            Filled = true;
        }
        public void Rotate(float angle)
        {
            Matrix mat = new Matrix();
            mat.Rotate(-angle);
            Path.Transform(mat);
            int minX = 0,
                minY = 0,
                maxX = 0,
                maxY = 0;
            foreach (PointF point in Path.PathPoints)
            {
                if ((int)point.X < minX)
                    minX = (int)point.X;

                if ((int)point.Y < minY)
                    minY = (int)point.Y;
            }
            mat = new Matrix();
            mat.Translate(
                minX < 0 ? -minX : minX,
                minY < 0 ? -minY : minY
                );
            Path.Transform(mat);
            foreach (PointF point in Path.PathPoints)
            {
                if ((int)point.X > maxX)
                    maxX = (int)point.X;

                if ((int)point.Y > maxY)
                    maxY = (int)point.Y;
            }
            Size = new Size(maxX, maxY);
        }
        public void RotateAt(float angle, PointF centerPoint)
        {
            if (Type == ElementType.Image)
            {
                Angle += angle;
                if (Angle > 360) Angle -= 360;
            }
            else
            {
                Matrix mat = new Matrix();
                mat.RotateAt(angle, centerPoint);
                Path.Transform(mat);
            }

        }
        public void RecalcCoords()
        {
            if (Type != ElementType.Image)
            {
                int minX = 0,
                minY = 0,
                maxX = 0,
                maxY = 0;
                foreach (PointF point in Path.PathPoints)
                {
                    if ((int)point.X < minX)
                        minX = (int)point.X;

                    if ((int)point.Y < minY)
                        minY = (int)point.Y;
                }
                foreach (PointF point in Path.PathPoints)
                {
                    if ((int)point.X > maxX)
                        maxX = (int)point.X;

                    if ((int)point.Y > maxY)
                        maxY = (int)point.Y;
                }
                Matrix mat = new Matrix();
                mat.Translate(-minX, -minY);
                Path.Transform(mat);

                Position = Position.Offset(minX, minY);
                Size = new Size((maxX + (int)Math.Abs(minX)) + 5, (maxY + (int)Math.Abs(minY)) + 5);
            }
        }
        public RectangleF getSelectRectangle()
        {
            if (Type == ElementType.Image)
            {
                var P = Math.RotatePoint(
                    ClientRectangle.Center(), ClientRectangle.Location, Angle);
                var R = Math.RotatePoint(ClientRectangle.Center(),
                    new PointF(ClientRectangle.Right, ClientRectangle.Y), Angle);
                var B = Math.RotatePoint(ClientRectangle.Center(),
                    new PointF(ClientRectangle.Right, ClientRectangle.Bottom), Angle);
                var L = Math.RotatePoint(ClientRectangle.Center(),
                    new PointF(ClientRectangle.X, ClientRectangle.Bottom), Angle);

                var pnt = Math.Max(new PointF[] { P, R, B, L });
                var pnt2 = Math.Min(new PointF[] { P, R, B, L });

                return new RectangleF(pnt2.X, pnt2.Y, pnt.X - pnt2.X, pnt.Y - pnt2.Y);
            }
            else
                return ClientRectangle;
        }
        public void Offset(int x, int y)
        {
            Position = new PointF(Position.X + x, Position.Y + y);
        }
        public void Offset(float x, float y)
        {
            Position = new PointF(Position.X + x, Position.Y + y);
        }
        public GraphicsElement Clone()
        {
            GraphicsElement tmp = new GraphicsElement(Size);
            tmp.Text = Text;
            tmp.Position = Position;
            tmp.Path = Path == null ? null : new GraphicsPath(Path.PathPoints, Path.PathTypes);
            tmp.Image = Image == null ? null : new Bitmap(Image);
            tmp.PenWidth = PenWidth;
            tmp.Font = Font;
            tmp.Filled = Filled;
            tmp.Color = Color;
            tmp.Angle = Angle;
            tmp.Type = Type;
            tmp.alpha = alpha;
            return tmp;
        }

        public void update_Transparency()
        {
            if (Type == ElementType.Image)
            {
                if (Image != null)
                {
                    Image = ImageProcessing.ProcessImage((Bitmap)Image, (pix) =>
                    {
                        return new Pixel(Color.FromArgb(Transparency, pix.Color), pix.Location);
                    });
                }
            }
            else
                Color = Color.FromArgb(Transparency, Color);
        }
    }
}
