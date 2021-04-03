using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class ExportForm : Form
    {
        Bitmap image;
        Color backCol;
        Color orgbackcol;
        int zoom = 1;
        int maxZoom = 8;
        bool trans = false;
        Rectangle imgRect;
        Point down;
        List<GraphicsElement> elements;
        Size size;
        public ExportForm(List<GraphicsElement> elements, Color backColor, Size sz)
        {
            InitializeComponent();
            //backup = new Bitmap(image);
            this.backCol = Color.FromArgb(backColor.A, backColor);
            this.orgbackcol = Color.FromArgb(backColor.A, backColor);
            this.elements = elements;
            size = sz;
            setupImageBox();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            pictureBox1.MouseUp += delegate
            {
                pictureBox1.Cursor = Cursors.Default;
            };
            pictureBox1.Paint += PictureBox1_Paint;
            stats.Text = "Width = " + sz.Width + ", Height = " + sz.Height;
        }
        void updateImage()
        {
            image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(backCol);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            foreach (var element in elements)
            {
                if (element.Type == ElementType.Path)
                {
                    g.TranslateTransform(element.Position.X, element.Position.Y);
                    g.DrawPath(new Pen(element.Color, element.PenWidth) { EndCap = LineCap.Round, StartCap = LineCap.Round, LineJoin = LineJoin.Bevel }, element.Path.getPath());
                    g.TranslateTransform(-element.Position.X, -element.Position.Y);
                }
                else if (element.Type == ElementType.Image)
                {
                    Matrix mat = new Matrix();
                    mat.RotateAt(element.Angle, element.ClientRectangle.Center());
                    g.Transform = mat;
                    g.DrawImage(element.Image, new RectangleF(element.Position, element.Size));
                    g.Transform = new Matrix();
                }
                else if (element.Type == ElementType.Text)
                {
                    g.TranslateTransform(element.Position.X, element.Position.Y);

                    if (element.Filled)
                        g.FillPath(new SolidBrush(element.Color), element.Path.getPath());
                    else
                        g.DrawPath(new Pen(element.Color, element.PenWidth), element.Path.getPath());

                    g.TranslateTransform(-element.Position.X, -element.Position.Y);
                    if (element.Size.Width == 0)
                    {
                        element.Size = g.MeasureString(element.Text, element.Font);
                    }
                }

            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            e.Graphics.DrawImage(image, imgRect);
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoom < maxZoom) zoom++;
            else if (zoom > -maxZoom) zoom--;
            float percent = (zoom * 10f) / 100f;
            int w = (int)(percent * image.Width);
            int h = (int)(percent * image.Height);
            if (imgRect.Width + w >= 100 && imgRect.Height + h >= 100)
            {
                imgRect.Size = new Size(image.Width + w, image.Height + h);
                Point center = pictureBox1.ClientRectangle.Center();
                Point pnt = new Point(imgRect.Width / 2, imgRect.Height / 2);
                center.Offset(-pnt.X, -pnt.Y);
                imgRect.Location = center;
                pictureBox1.Invalidate();
            }
            Text = "Export [Zoom " + zoom.ToString() + "x]";
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.X - down.X;
                int dy = e.Y - down.Y;
                imgRect.Location = new Point(imgRect.Location.X + dx, imgRect.Location.Y + dy);
                down = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            down = e.Location;
            pictureBox1.Cursor = Cursors.SizeAll;
        }

        void setupImageBox()
        {
            imgRect = new Rectangle(new Point(), size);
            Point center = pictureBox1.ClientRectangle.Center();
            Point centerI = imgRect.Center();
            center.Offset(-centerI.X, -centerI.Y);
            imgRect.Location = center;
            pictureBox1.Invalidate();
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filter = "";
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            switch (comboBox1.SelectedIndex)
            {
                case 0: { filter = "JPEG Image|*.jpg"; format = System.Drawing.Imaging.ImageFormat.Jpeg; } break;
                case 1: { filter = "BMP Image|*.bmp"; format = System.Drawing.Imaging.ImageFormat.Bmp; } break;
                case 2: { filter = "PNG Image|*.png"; format = System.Drawing.Imaging.ImageFormat.Png; } break;
                case 3: { filter = "PNG Image|*.png"; format = System.Drawing.Imaging.ImageFormat.Png; } break;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName, format);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PNG transparent" && !trans)
            {
                backCol = Color.FromArgb(0, 0, 0, 0);
                updateImage();
                pictureBox1.Invalidate();
            }
            else
            {
                backCol = orgbackcol;
                updateImage();
                pictureBox1.Invalidate();
            }
        }
    }
}
