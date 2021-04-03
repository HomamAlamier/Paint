using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Paint
{
    #region Enum's
    public enum Tools
    {
        Select,
        Pen,
        Rotate,
        Text,
        InsertImage,
        InsertText,
        Crop,
        ColorPicker,
        ColorRemover
    }
    public enum ElementType
    {
        Path,
        Image,
        Text
    }
    #endregion
    public partial class MainForm : Form
    {
        PictureBox workspace_box;
        Tools tool = Tools.Select;
        PathGradientBrush colorpanel_brush;
        Image cursor_image = null;
        Table<string, Point> cursor_head;

        int maxX, maxY;
        int zoom = 0;
        int colorResultSelectorX = 0;
        double rotateAngle;

        List<Point> penPoints;
        List<int> selectedElemnts = new List<int>();
        List<Form> inToolPanel = new List<Form>();
        List<Rectangle> drawInBackground = new List<Rectangle>();
        List<GraphicsElement> elements = new List<GraphicsElement>();
        List<List<GraphicsElement>> undoQ = new List<List<GraphicsElement>>();
        List<List<GraphicsElement>> redoQ = new List<List<GraphicsElement>>();

        bool cursorEnabled = false;
        bool selectRectangle = false;

        Point crop_start, crop_end;
        Point mouseDownLoc;
        Point mouseDownLoc2;
        Point mouseMoveLoc;
        Point mouseMoveLoc2;
        Point elementStartPoint;
        PointF colorWheel_SelectorLocation;


        Size workspaceSize;

        Bitmap map;

        string Filename = "";

        public MainForm()
        {
            InitializeComponent();
            createWorkSpace();
            centerWorkspacebox();
            apply_workspaceSize();
            setupColorWheel();
            setupCursors();
            changeColorWheelSelectorLocationToColor(Color.Red);
            colorResultSelectorX = colorResult.Width - 1;
            colorResult.Invalidate();
        }

        #region Void
        void applyFilter(ImageProcessing.ProcessPixel filter, bool IH = false)
        {
            Snapshot();
            if (selectedElemnts.Count > 0)
            {
                foreach (int index in selectedElemnts)
                {
                    var element = elements[index];
                    if (element.Type == ElementType.Path || element.Type == ElementType.Text)
                    {
                        element.Color = filter(new Pixel(element.Color, new PointF())).Color;
                    }
                    else if (element.Type == ElementType.Image)
                    {
                        element.Image = ImageProcessing.ProcessImage((Bitmap)element.Image, filter, 0, IH);
                    }
                }
            }
            else
            {
                foreach (GraphicsElement element in elements)
                {
                    if (element.Type == ElementType.Path || element.Type == ElementType.Text)
                    {
                        element.Color = filter(new Pixel(element.Color, new PointF())).Color;
                    }
                    else if (element.Type == ElementType.Image)
                    {
                        element.Image = ImageProcessing.ProcessImage((Bitmap)element.Image, filter, 0, IH);
                    }
                }
            }
            workspace_box.Invalidate();
        }
        void autoResizeWorkSpace()
        {
            Snapshot();
            if (elements.Count == 0) return;
            float minX = elements[0].Position.X,
                minY = elements[0].Position.Y,
                maxX = 0,
                maxY = 0;
            foreach (GraphicsElement element in elements)
            {
                if ((element.Position.X + element.Size.Width) > maxX)
                    maxX = (element.Position.X + element.Size.Width);

                if ((element.Position.Y + element.Size.Height) > maxY)
                    maxY = (element.Position.Y + element.Size.Height);

                if (element.Position.X < minX)
                    minX = element.Position.X;

                if (element.Position.Y < minY)
                    minY = element.Position.Y;
            }
            foreach (GraphicsElement element in elements)
            {
                element.Offset(-(minX - 2), -(minY - 2));
            }
            workspaceSize = new Size((int)(maxX - minX) + 10, (int)(maxY - minY) + 10);
            apply_workspaceSize();
            centerWorkspacebox();
            workspace_box.Invalidate();
        }
        void setupColorWheel()
        {
            float radius = Math.Min((colorpanel.Width / 2), (colorpanel.Height / 2));
            float cX = 0, cY = 0;
            if (colorpanel.Width > colorpanel.Height)
            {
                cX = colorpanel.Width / 2;
                cY = radius;
            }
            else if (colorpanel.Height > colorpanel.Width)
            {
                cX = radius;
                cY = colorpanel.Height / 2;
            }
            PointF center = new PointF(
                cX, cY
                );
            GraphicsPath gp = new GraphicsPath();
            List<PointF> list = new List<PointF>();
            List<Color> cols = new List<Color>();
            for (int angle = 0; angle < 360; angle += 5)
            {
                float angleR = angle * (float)(Math.PI / 180);
                float x = center.X + radius * (float)Math.Cos(angleR);
                float y = center.Y - radius * (float)Math.Sin(angleR);
                list.Add(new PointF(x, y));
                cols.Add(HSLColor.ToRGB(new HColor(0.5, angle, 1)));
            }
            colorpanel_brush = new PathGradientBrush(list.ToArray(), WrapMode.Clamp);
            colorpanel_brush.CenterColor = Color.White;
            colorpanel_brush.CenterPoint = center;
            colorpanel_brush.SurroundColors = cols.ToArray();
            colorWheel_SelectorLocation = new PointF(0, 0);
        }
        void setupCursors()
        {
            cursor_head = new Table<string, Point>();
            string[] points = CursorsData.Points.Split(new char[] { ';' });
            foreach (var pnt in points)
            {
                if (pnt == "") continue;
                string[] val = pnt.Split(new char[] { '=' });
                string[] parsPoint = val[1].Split(new char[] { ',' });
                cursor_head.Add(val[0], new Point(int.Parse(parsPoint[0]), int.Parse(parsPoint[1])));
            }
        }
        void createWorkSpace()
        {
            workspace_box = new PictureBox();
            workspace_box.Size = new Size(500, 500);
            workspaceSize = workspace_box.Size;
            workspace_box.BackColor = Color.White;
            workspace_box.MouseDown += workspace_box_MouseDown;
            workspace_box.MouseMove += workspace_box_MouseMove;
            workspace_box.MouseUp += workspace_box_MouseUp;
            workspace_box.Paint += workspace_box_Paint;
            workspace_box.MouseLeave += Workspace_box_MouseLeave;
            workspace_box.MouseEnter += Workspace_box_MouseEnter;
            workspace_box.MouseDoubleClick += Workspace_box_MouseDoubleClick;
            workspace_box.MouseWheel += Workspace_box_MouseWheel;
            this.Controls.Add(workspace_box);
            KeyPreview = true;
        }
        void apply_workspaceSize()
        {
            float percent = 1 + (zoom * 5f / 100f);
            Size sz = new Size((int)(percent * workspaceSize.Width), (int)(percent * workspaceSize.Height));
            workspace_box.Size = sz;
            szLabel.Text = sz.Width + "x" + sz.Height;
        }
        void centerWorkspacebox()
        {
            Point center = ClientRectangle.Center();
            Point pnt = workspace_box.ClientRectangle.Center();
            center.Offset(-pnt.X, -pnt.Y);
            workspace_box.Location = center;
            szLabel.Text = workspaceSize.Width + "x" + workspaceSize.Height;
        }
        void changeColorWheelSelectorLocationToColor(Color color)
        {
            HColor hcolor = HSLColor.FromRGB(color);
            double angleR = hcolor.Hue * Math.PI / 180;
            PointF center = colorpanel.ClientRectangle.Center();
            double radius = Math.Min((colorpanel.Width / 2), (colorpanel.Height / 2));
            radius *= hcolor.Saturation;
            double x = center.X + Math.Cos(angleR) * radius;
            double y = center.Y - Math.Sin(angleR) * radius;
            colorWheel_SelectorLocation = new PointF((float)x, (float)y);
            colorResult.BackColor = color;
            colorpanel.Invalidate();
        }
        void selectTool(Tools tool)
        {
            if (map != null && tool != Tools.ColorPicker && tool != Tools.ColorRemover)
            {
                map.Dispose();
                map = null;
            }
            switch (tool)
            {
                case Tools.Select:
                    {
                        this.tool = Tools.Select;
                        cursorEnabled = true;
                        cursor_image = CursorsData.selectCur;
                    }
                    break;
                case Tools.Pen:
                    {
                        this.tool = Tools.Pen;
                        cursor_image = CursorsData.Pen;
                        cursorEnabled = true;
                        selectedElemnts.Clear();
                    }
                    break;
                case Tools.Rotate:
                    {
                        this.tool = Tools.Rotate;
                        cursorEnabled = true;
                        cursor_image = CursorsData.rotate;
                    }
                    break;
                case Tools.Text:
                    {
                        this.tool = Tools.Text;
                        cursor_image = CursorsData.text;
                        cursorEnabled = true;
                    }
                    break;
                case Tools.InsertImage:
                    {
                        this.tool = Tools.InsertImage;
                        cursor_image = CursorsData.image;
                        cursorEnabled = true;
                        selectedElemnts.Clear();
                    }
                    break;
                case Tools.InsertText:
                    {
                        this.tool = Tools.InsertText;
                        cursor_image = CursorsData.text;
                        cursorEnabled = true;
                        selectedElemnts.Clear();
                    }
                    break;
                case Tools.Crop:
                    {
                        this.tool = Tools.Crop;
                        cursor_image = CursorsData.crop;
                        cursorEnabled = true;
                        selectedElemnts.Clear();
                        crop_end = new Point();
                        crop_start = new Point();
                    }
                    break;
                case Tools.ColorPicker:
                    {
                        this.tool = Tools.ColorPicker;
                        cursor_image = CursorsData.colorpicker;
                        cursorEnabled = true;
                        selectedElemnts.Clear();
                    }
                    break;
                case Tools.ColorRemover:
                    {
                        this.tool = Tools.ColorRemover;
                        cursor_image = CursorsData.colorpicker;
                        cursorEnabled = true;
                    }
                    break;
            }
            toolLabel.Text = tool.ToString();
            workspace_box.Invalidate();
        }
        void Snapshot()
        {
            List<GraphicsElement> tmp = new List<GraphicsElement>();
            foreach (var item in elements)
            {
                tmp.Add(item.Clone());
            }
            undoQ.Add(tmp);
            redoQ.Clear();
        }
        void undo()
        {
            selectedElemnts.Clear();
            if (undoQ.Count > 0)
            {
                List<GraphicsElement> tmp = new List<GraphicsElement>();
                foreach (var item in elements)
                {
                    tmp.Add(item.Clone());
                }
                redoQ.Add(tmp);
                elements = undoQ[undoQ.Count - 1];
                undoQ.RemoveAt(undoQ.Count - 1);
                workspace_box.Invalidate();
                elementsListBox.Items.Clear();
                foreach (var item in elements)
                {
                    elementsListBox.Items.Add(item.Name == null ? item.Type.ToString() : item.Name);
                }
            }
        }
        void redo()
        {
            selectedElemnts.Clear();
            if (redoQ.Count > 0)
            {
                List<GraphicsElement> tmp = new List<GraphicsElement>();
                foreach (var item in elements)
                {
                    tmp.Add(item.Clone());
                }
                undoQ.Add(tmp);
                elements = redoQ[redoQ.Count - 1];
                redoQ.RemoveAt(redoQ.Count - 1);
                workspace_box.Invalidate();
                elementsListBox.Items.Clear();
                foreach (var item in elements)
                {
                    elementsListBox.Items.Add(item.Name == null ? item.Type.ToString() : item.Name);
                }
            }
        }
        #endregion


        private void Workspace_box_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoom < 80) zoom += zoom >= 0 ? 20 : 2;
            else if (zoom > -10) zoom -= zoom > 0 ? 20 : 2;
            statsLabel.Text = "Zoom " + zoom * 5 + "%";
            apply_workspaceSize();
            centerWorkspacebox();
            workspace_box.Invalidate();
        }
        private void Workspace_box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedElemnts.Count > 0 && selectedElemnts.Count == 1)
            {
                var element = elements[selectedElemnts[0]];
                switch (element.Type)
                {
                    case ElementType.Text:
                        {
                            TextInsertDialog dialog = new TextInsertDialog();
                            dialog.Text = "Edit Text";
                            dialog.OkButtonText = "Edit";
                            dialog.ResultFont = element.Font;
                            dialog.ResultText = element.Text;
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                element.Text = dialog.ResultText;
                                element.Font = dialog.ResultFont;
                                element.Size = new Size(0, 0);
                                element.Path = new GraphicsPath();
                                element.Path.AddString(element.Text, element.Font.FontFamily, (int)element.Font.Style,
                                    Math.SizeTo_emSize(workspace_box.CreateGraphics(), element.Font.Size), new Point(), new StringFormat());
                                workspace_box.Invalidate();
                            }
                            Snapshot();
                        }
                        break;
                }
            }
        }
        private void Workspace_box_MouseEnter(object sender, EventArgs e)
        {
            cursorEnabled = true;
            workspace_box.Invalidate();
        }

        private void Workspace_box_MouseLeave(object sender, EventArgs e)
        {
            cursorEnabled = false;
            workspace_box.Invalidate();
        }




        private void workspace_box_MouseUp(object sender, MouseEventArgs e)
        {
            var upRec = new Rectangle(elementStartPoint, new Size(
               (mouseDownLoc.X - elementStartPoint.X) + maxX,
               (mouseDownLoc.Y - elementStartPoint.Y) + maxY
                ));
            Point loc = new Point((e.X / (1 + (int)(zoom * 5f / 100f))), (e.Y / (1 + (int)(zoom * 5f / 100f))));
            switch (tool)
            {
                case Tools.Select:
                    {
                        if (selectRectangle)
                        {
                            selectRectangle = false;
                            selectedElemnts.Clear();
                            RectangleF selRect = new RectangleF(mouseDownLoc, new Size(e.X - mouseDownLoc.X, e.Y - mouseDownLoc.Y));
                            for (int index = 0; index < elements.Count; index++)
                            {
                                if (selRect.Contains(elements[index].Position))
                                {
                                    selectedElemnts.Add(index);
                                    elementsListBox.SelectedIndices.Add(index);
                                }
                            }
                            workspace_box.Invalidate();

                        }
                    }
                    break;
                case Tools.Pen:
                    {
                        Snapshot();
                        GraphicsElement element = new GraphicsElement(upRec.Size);
                        for (int index = 0; index < penPoints.Count; index++)
                        {
                            penPoints[index] = new Point(penPoints[index].X - elementStartPoint.X, penPoints[index].Y - elementStartPoint.Y);
                        }
                        element.Path = new GraphicsPath();
                        element.Path.AddLines(penPoints.ToArray());
                        element.Type = ElementType.Path;
                        element.Position = upRec.Location;
                        element.Color = colorFinal.BackColor;
                        element.PenWidth = int.Parse(penWid.Text);
                        element.Filled = filledToolStripMenuItem.Checked;
                        element.Scale = zoom;
                        element.Name = "Path";
                        elements.Add(element);
                        elementsListBox.Items.Add("Path");
                        penPoints.Clear();
                        //tool = Tools.Select;
                        workspace_box.Invalidate();
                    }
                    break;
                case Tools.Rotate:
                    {
                        var element = elements[selectedElemnts[0]];
                        element.RecalcCoords();
                        selectTool(Tools.Select);
                    }
                    break;
                case Tools.InsertImage:
                    {
                        Snapshot();
                        OpenFileDialog fileDialog = new OpenFileDialog();
                        fileDialog.Filter = CursorsData.ImageTypes;
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Image img = Image.FromFile(fileDialog.FileName);
                            GraphicsElement z = new GraphicsElement(img.Size);
                            z.Type = ElementType.Image;
                            z.Position = e.Location;
                            z.Image = img;
                            z.Name = "Image";
                            elements.Add(z);
                            elementsListBox.Items.Add("Image");
                            workspace_box.Invalidate();
                        }
                        selectTool(Tools.Select);
                    }
                    break;
                case Tools.InsertText:
                    {
                        TextInsertDialog dialog = new TextInsertDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            Snapshot();
                            GraphicsElement element = new GraphicsElement(new Size(0, 0));
                            element.Text = dialog.ResultText;
                            element.Font = dialog.ResultFont;
                            element.Type = ElementType.Text;
                            element.Position = e.Location;
                            element.Color = colorFinal.BackColor;
                            element.Path = new GraphicsPath();
                            element.Filled = filledToolStripMenuItem.Checked;
                            element.Path.AddString(dialog.ResultText,
                                dialog.ResultFont.FontFamily,
                                (int)dialog.ResultFont.Style,
                                Math.SizeTo_emSize(workspace_box.CreateGraphics(), dialog.ResultFont.Size),
                                new Point(),
                                new StringFormat());
                            element.Size = new SizeF();
                            element.Name = "Text";
                            elements.Add(element);
                            elementsListBox.Items.Add("Text");
                            workspace_box.Invalidate();
                        }
                    }
                    break;
                case Tools.Crop:
                    {
                        Snapshot();
                        toolStripButton2_Click(null, null);
                        cursorEnabled = false;
                        workspace_box.Invalidate();
                        Bitmap workspace = BitmapExtensions.DrawControl(workspace_box);
                        Rectangle result = new Rectangle();
                        if (crop_start.X + crop_start.Y < crop_end.X + crop_end.Y)
                            result = new Rectangle(crop_start, new Size(crop_end.X - crop_start.X, crop_end.Y - crop_start.Y));
                        else
                            result = new Rectangle(crop_end, new Size(crop_start.X - crop_end.X, crop_start.Y - crop_end.Y));
                        Bitmap resultImage = new Bitmap(result.Width, result.Height);
                        Graphics g = Graphics.FromImage(resultImage);
                        g.DrawImage(workspace, new Rectangle(0, 0, resultImage.Width, resultImage.Height), result, GraphicsUnit.Pixel);
                        g.Dispose();

                        Color zs = Color.FromArgb(workspace_box.BackColor.A, workspace_box.BackColor);
                        resultImage = ImageProcessing.ProcessImage(resultImage, (pix) =>
                        {
                            if (pix.Color == zs)
                                return new Pixel(Color.FromArgb(0, 0, 0, 0), pix.Location);
                            else
                                return pix;
                        });

                        GraphicsElement element = new GraphicsElement(resultImage.Size);
                        element.Type = ElementType.Image;
                        element.Image = (Image)new Bitmap(resultImage);
                        element.Position = result.Location;
                        element.Name = "Image[Crop]";
                        elements.Add(element);
                        elementsListBox.Items.Add("Image[Crop]");
                        selectedElemnts.Clear();
                        selectedElemnts.Add(elements.Count - 1);
                        workspace_box.Invalidate();
                        resultImage.Dispose();
                        workspace.Dispose();
                    }
                    break;
                case Tools.ColorPicker:
                    {
                        Bitmap map = BitmapExtensions.DrawControl(workspace_box);
                        Color col = map.GetPixel(e.X, e.Y);
                        HColor col2 = HSLColor.FromRGB(col);
                        changeColorWheelSelectorLocationToColor(col);
                        colorResultSelectorX = (int)System.Math.Round(col2.Lightness * colorResult.Width);
                        colorResult.Invalidate();
                        map.Dispose();
                    }
                    break;
                case Tools.ColorRemover:
                    {
                        var item = elements[selectedElemnts[0]];
                        var col = ((Bitmap)item.Image).GetPixel(loc.X - (int)item.Position.X, loc.Y - (int)item.Position.Y);
                        item.Image = ImageProcessing.ProcessImage((Bitmap)elements[selectedElemnts[0]].Image, (pix) =>
                        {
                            if (pix.Color.IsEquals(col))
                                return new Pixel(Color.FromArgb(0, 0, 0, 0), pix.Location);
                            else
                                return pix;
                        });
                        workspace_box.Invalidate();
                    }
                    break;
            }
            workspace_box.Cursor = Cursors.Default;
        }

        private void workspace_box_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLoc = new Point((int)(e.X / (1f + (zoom * 5f / 100f))), (int)(e.Y / (1f + (zoom * 5f / 100f))));
            mouseDownLoc2 = e.Location;
            elementStartPoint = new Point((int)(e.X / (1f + (zoom * 5f / 100f))), (int)(e.Y / (1f + (zoom * 5f / 100f))));
            maxX = 0;
            maxY = 0;
            if (e.Button == MouseButtons.Right) selectTool(Tools.Select);
            if (tool == Tools.Pen)
            {
                penPoints = new List<Point>();
            }
            switch (tool)
            {
                case Tools.Select:
                    {

                        int sL = -1;
                        for (int index = 0; index < elements.Count; index++)
                        {
                            if (elements[index].getSelectRectangle().Contains(mouseDownLoc))
                            {
                                sL = index;
                            }
                        }
                        if (!selectedElemnts.Contains(sL))
                        {
                            selectedElemnts.Clear();
                            if (sL != -1)
                            {
                                selectedElemnts.Add(sL);
                                elementsListBox.SelectedIndices.Clear();
                                elementsListBox.SelectedIndices.Add(sL);
                            }
                            else
                            {
                                elementsListBox.SelectedIndices.Clear();
                            }
                        }
                        workspace_box.Invalidate();
                        if (cursor_image == null) workspace_box.Cursor = Cursors.SizeAll;
                    }
                    break;
                case Tools.Pen:
                    break;
                case Tools.Rotate:
                    {
                        Snapshot();
                    }
                    break;
                case Tools.Text:
                    break;
                case Tools.Crop:
                    crop_start = mouseDownLoc;
                    break;
                default:
                    break;
            }
        }

        private void workspace_box_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.Clear(workspace_box.BackColor);

            if (zoom != 0)
            {
                Matrix mat = new Matrix();
                mat.Scale(1 + (zoom * 5f / 100f), 1 + (zoom * 5f / 100f));
                g.Transform = mat;
            }

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
                    Matrix tmp = g.Transform;
                    Matrix mat = new Matrix();
                    mat.RotateAt(element.Angle, element.ClientRectangle.Center());
                    mat.Scale(1 + (zoom * 5f / 100f), 1 + (zoom * 5f / 100f));
                    g.Transform = mat;
                    g.DrawImage(element.Image, element.ClientRectangle);
                    g.Transform = tmp;
                }
                else if (element.Type == ElementType.Text)
                {
                    float scale = 1 + (zoom * 5f / 100f);
                    scale -= element.Scale;
                    g.ScaleTransform(scale, scale);
                    g.TranslateTransform(element.Position.X, element.Position.Y);

                    if (element.Filled)
                        g.FillPath(new SolidBrush(element.Color), element.Path.getPath());
                    else
                        g.DrawPath(new Pen(element.Color, element.PenWidth), element.Path.getPath());

                    g.TranslateTransform(-element.Position.X, -element.Position.Y);
                    g.ScaleTransform(-scale, -scale);
                    if (element.Size.Width == 0)
                    {
                        element.Size = g.MeasureString(element.Text, element.Font);
                    }
                }

            }
            //g.Transform = new Matrix();
            if (tool == Tools.Pen && penPoints != null && penPoints.Count > 1)
                g.DrawLines(new Pen(colorFinal.BackColor, int.Parse(penWid.Text)) { EndCap = LineCap.Round, StartCap = LineCap.Round, LineJoin = LineJoin.Bevel }, penPoints.ToArray());
            if (selectedElemnts.Count > 0 && tool != Tools.Rotate)
            {
                for (int selElement2 = 0; selElement2 < selectedElemnts.Count; selElement2++)
                {
                    int selElement = selectedElemnts[selElement2];
                    if (elements.Count == 0) break;
                    if (selElement > -1)
                    {
                        var rect = elements[selElement].getSelectRectangle();
                        g.DrawRectangle(new Pen(Color.Black) { DashStyle = DashStyle.Dash },
                            new RectangleF(rect.X - 2, rect.Y - 2
                            , rect.Width + 4, rect.Height + 4));
                    }
                }
            }
            if (selectRectangle)
            {
                Rectangle selRect = new Rectangle(mouseDownLoc, new Size(mouseMoveLoc.X - mouseDownLoc.X, mouseMoveLoc.Y - mouseDownLoc.Y));
                g.DrawRectangle(new Pen(Color.Black) { DashStyle = DashStyle.Dash }, selRect);
            }
            if (tool == Tools.Crop)
            {
                g.DrawLine(new Pen(Color.Red, 2), crop_start.X, 0, crop_start.X, workspace_box.Height);
                g.DrawLine(new Pen(Color.Red, 2), 0, crop_start.Y, workspace_box.Width, crop_start.Y);

                g.DrawLine(new Pen(Color.Blue, 2), crop_end.X, 0, crop_end.X, workspace_box.Height);
                g.DrawLine(new Pen(Color.Blue, 2), 0, crop_end.Y, workspace_box.Width, crop_end.Y);
            }
            if (tool == Tools.ColorPicker)
            {
                var col = map.GetPixel(mouseMoveLoc2.X, mouseMoveLoc2.Y);
                g.FillRectangle(new SolidBrush(col), new Rectangle(mouseMoveLoc.X + 10, mouseMoveLoc.Y + 10, 15, 15));
                g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(mouseMoveLoc.X + 10, mouseMoveLoc.Y + 10, 15, 15));
            }
            else if (cursor_image != null && cursorEnabled)
            {
                g.DrawImage(cursor_image, new Rectangle(mouseMoveLoc.X + 10, mouseMoveLoc.Y + 10, 15, 15));
            }
        }

        private void workspace_box_MouseMove(object sender, MouseEventArgs e)
        {
            posLabel.Text = (e.X / (1f + (zoom * 5f / 100f))) + "," + (e.Y / (1f + (zoom * 5f / 100f))) + "(" + e.X + "," + e.Y + "[" + (1f +(zoom * 5f / 100f)) + "])";
            mouseMoveLoc = new Point((int)(e.X / (1f + (zoom * 5f / 100f))), (int)(e.Y / (1f + (zoom * 5f / 100f))));
            mouseMoveLoc2 = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = mouseMoveLoc.X - mouseDownLoc.X;
                int deltaY = mouseMoveLoc.Y - mouseDownLoc.Y;
                if (deltaX > maxX) maxX = deltaX;
                if (deltaY > maxY) maxY = deltaY;
                Text = "start_x = " + elementStartPoint.X + ", start_y = " + elementStartPoint.Y + ", maxX = " + maxX + ", maxY = " + maxY;
                if (mouseMoveLoc.X < elementStartPoint.X) elementStartPoint.X = mouseMoveLoc.X;
                if (mouseMoveLoc.Y < elementStartPoint.Y) elementStartPoint.Y = mouseMoveLoc.Y;
                switch (tool)
                {
                    case Tools.Select:
                        {
                            if (selectedElemnts.Count > 0)
                            {
                                for (int selElement = 0; selElement < selectedElemnts.Count; selElement++)
                                {
                                    if (selectedElemnts[selElement] > -1)
                                    {
                                        elements[selectedElemnts[selElement]].Position = new PointF(
                                            mouseMoveLoc.X - (mouseDownLoc.X - elements[selectedElemnts[selElement]].Position.X),
                                            mouseMoveLoc.Y - (mouseDownLoc.Y - elements[selectedElemnts[selElement]].Position.Y)
                                            );
                                    }
                                }
                                mouseDownLoc = mouseMoveLoc;
                                workspace_box.Cursor = Cursors.SizeAll;
                            }
                            else selectRectangle = true;

                            workspace_box.Invalidate();
                        }
                        break;
                    case Tools.Pen:
                        {
                            penPoints.Add(mouseMoveLoc);
                            workspace_box.Invalidate();
                        }
                        break;
                    case Tools.Rotate:
                        {
                            double oldR = rotateAngle;
                            var element = elements[selectedElemnts[0]];
                            PointF center = new PointF(element.Size.Width / 2, element.Size.Height / 2);
                            center = center.Offset(element.Position);
                            double dx = mouseMoveLoc.X - center.X,
                                dy = center.Y - mouseMoveLoc.Y;
                            rotateAngle = Math.Atan2(-dy, dx);
                            if (rotateAngle < 0)
                                rotateAngle = Math.Abs(rotateAngle);
                            else
                                rotateAngle = 2 * Math.PI - rotateAngle;
                            element.RotateAt(-(float)((rotateAngle - oldR) * 180 / Math.PI), new PointF(element.Size.Width / 2, element.Size.Height / 2));
                            Text = "angle = " + (float)(rotateAngle / Math.PI * 180);
                            workspace_box.Invalidate();
                        }
                        break;
                    case Tools.Text:
                    case Tools.Crop:
                        {
                            crop_end = mouseMoveLoc;
                            workspace_box.Invalidate();
                        }
                        break;
                }
            }
            if (cursor_image != null)
            {
                workspace_box.Invalidate();
            }
            if (e.Button == MouseButtons.Middle)
            {
                Point end = new Point(workspace_box.Location.X + workspace_box.Width, workspace_box.Location.Y + workspace_box.Height);
                int offset = 200;
                Rectangle workSpace = new Rectangle(toolStrip1.Width + offset, menuStrip1.Height + offset,
                    (Width - (toolStrip1.Width + panel1.Width)) - offset, (Height - (menuStrip1.Height + statusStrip1.Height)) - offset);
                int dx = (e.X - mouseDownLoc2.X),
                    dy = (e.Y - mouseDownLoc2.Y);
                if (!workSpace.Contains(end) || dx > 0 || dy > 0)
                {
                    workspace_box.Location = new Point(workspace_box.Location.X + dx, workspace_box.Location.Y + dy);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void workspace_box_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int selElement = 0; selElement < selectedElemnts.Count; selElement++)
            {
                if (elements.Count == 0) break;
                if (selectedElemnts[selElement] > -1)
                {
                    elements.RemoveAt(selectedElemnts[selElement]);
                    elementsListBox.Items.RemoveAt(selectedElemnts[selElement]);
                    workspace_box.Invalidate();
                    selElement = -1;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedElemnts.Clear();
            foreach (var item in elementsListBox.SelectedIndices)
            {
                selectedElemnts.Add((int)item);
            }
            workspace_box.Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            selectTool(Tools.Select);
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int selElement = 0; selElement < selectedElemnts.Count; selElement++)
            {
                if (elements.Count == 0) break;
                if (selectedElemnts[selElement] > -1)
                {
                    elements[selectedElemnts[selElement]].Rotate(90);
                }
            }
            workspace_box.Invalidate();
        }

        private void autoResizeWorkSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoResizeWorkSpace();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void colorpanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.FillPie(colorpanel_brush, colorpanel.ClientRectangle, 0, 360);
            g.DrawRectangle(new Pen(Color.Black),
                new Rectangle(new Point((int)colorWheel_SelectorLocation.X - 2, (int)colorWheel_SelectorLocation.Y - 2), new Size(4, 4)));
        }

        private void colorpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float radius = Math.Min((colorpanel.Width / 2), (colorpanel.Height / 2));
                Point center = new Point(colorpanel.Width / 2, colorpanel.Height / 2);
                var dist = Math.DisatnceBetween2Points(e.Location, center);
                if (dist <= radius)
                {
                    colorWheel_SelectorLocation = e.Location;
                    colorpanel.Invalidate();
                    double dx = Math.Abs(e.X - center.X),
                        dy = Math.Abs(e.Y - center.Y);
                    double angle = Math.Atan(dy / dx) / Math.PI * 180;
                    dist = Math.DisatnceBetween2Points(dx, dy);
                    double sat = dist / radius;
                    if (dist < 6) sat = 0;
                    if (e.X < center.X) angle = 180 - angle;
                    if (e.Y > center.Y) angle = 360 - angle;
                    colorResult.BackColor = HSLColor.ToRGB(new HColor(0.5, angle, sat));
                    //texR.Text = colorResult.BackColor.R.ToString();
                    // texG.Text = colorResult.BackColor.G.ToString();
                    //texB.Text = colorResult.BackColor.B.ToString();
                    if (selectedElemnts.Count > 0)
                    {
                        for (int index = 0; index < selectedElemnts.Count; index++)
                        {
                            var element = elements[selectedElemnts[index]];
                            if (element.Type == ElementType.Path || element.Type == ElementType.Text)
                            {
                                element.Color = colorResult.BackColor;
                            }
                        }
                        workspace_box.Invalidate();
                    }
                }
            }
        }

        private void colorpanel_MouseDown(object sender, MouseEventArgs e)
        {
            colorpanel_MouseMove(null, new MouseEventArgs(e.Button, 1, e.X, e.Y, 0));
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.GrayScale);
        }

        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            selectTool(Tools.InsertText);
        }

        private void invertColorsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.Invert);
        }

        private void addFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.BlackWhite);
        }

        private void redOnlyFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.RedOnly);
        }

        private void greenOnlyFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.GreenOnly);
        }

        private void blueOnlyFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.BlueOnly);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            workspace_box.BackColor = colorFinal.BackColor;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            selectTool(Tools.InsertImage);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            selectTool(Tools.Crop);
        }

        private void toolStripButton1_ButtonClick(object sender, EventArgs e)
        {
            selectTool(Tools.Pen);
        }

        private void filledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filledToolStripMenuItem.Checked = !filledToolStripMenuItem.Checked;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redo();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Project File(*.ppro)|*.ppro";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Size sz; Color col;
                elements = ProjectFileManager.OpenProject(openFileDialog.FileName, out sz, out col);
                if (col != Color.Empty)
                    workspace_box.BackColor = col;
                if (sz.Width > 0 && sz.Height > 0)
                    workspace_box.Size = sz;
                centerWorkspacebox();
                workspace_box.Invalidate();
                elementsListBox.Items.Clear();
                foreach (var item in elements)
                {
                    elementsListBox.Items.Add(item.Name == null ? item.Type.ToString() : item.Name);
                }
                Filename = openFileDialog.FileName;
                Text = "Paint - [" + Filename + "]";
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elements.Clear();
            redoQ.Clear();
            undoQ.Clear();
            createWorkSpace();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Filename != string.Empty)
                ProjectFileManager.SaveProject(Filename, elements, workspace_box.Size, workspace_box.BackColor);
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Project File(*.ppro)|*.ppro";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProjectFileManager.SaveProject(saveFileDialog.FileName, elements, workspace_box.Size, workspace_box.BackColor);
                    Filename = saveFileDialog.FileName;
                    Text = "Paint - [" + Filename + "]";
                }
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            selectTool(Tools.Rotate);
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.Inverse_Horizontally, true);
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(ImageFilters.Inverse_Vertically);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float percent = float.Parse(toolStripComboBox1.Text.Substring(0, toolStripComboBox1.Text.IndexOf("%")));
            percent /= 100f;
            int tra = 255 - (int)(percent * 255);
            if (selectedElemnts.Count > 0)
            {
                foreach (var ind in selectedElemnts)
                {
                    elements[ind].Transparency = tra;
                }
            }
            else
            {
                foreach (var item in elements)
                {
                    item.Transparency = tra;
                }
            }
            workspace_box.Invalidate();
        }

        private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm frm = new ExportForm(elements, workspace_box.BackColor, workspaceSize);
            frm.ShowDialog();
        }

        private void transparencyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            int x = 0, y = 0;

            if (e.KeyCode == Keys.Right) x = 1;
            if (e.KeyCode == Keys.Left) x = -1;
            if (e.KeyCode == Keys.Up) y = -1;
            if (e.KeyCode == Keys.Down) y = 1;

            if (selectedElemnts.Count > 0)
            {
                for (int selElement = 0; selElement < selectedElemnts.Count; selElement++)
                {
                    if (selectedElemnts[selElement] > -1)
                    {
                        elements[selectedElemnts[selElement]].Position = new PointF(elements[selectedElemnts[selElement]].Position.X + x,
                            elements[selectedElemnts[selElement]].Position.Y + y);
                    }
                }
            }
            workspace_box.Invalidate();
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeForm frm = new ResizeForm(workspace_box.Width, workspace_box.Height);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                workspaceSize = new Size((int)frm.W, (int)frm.H);
                apply_workspaceSize();
                centerWorkspacebox();
            }
        }

        private void texB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            map = BitmapExtensions.DrawControl(workspace_box);
            selectTool(Tools.ColorPicker);
        }

        private void colorResult_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.Clear(Color.White);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, colorResult.ClientRectangle.Center().Y),
                new Point(colorResult.Width, colorResult.ClientRectangle.Center().Y), Color.Black, colorResult.BackColor);
            brush.InterpolationColors = new ColorBlend(3)
            {
                Colors = new Color[] { Color.Black, colorResult.BackColor, Color.White }
                ,
                Positions = new float[] { 0f, 0.5f, 1f }
            };
            g.FillRectangle(brush, colorResult.ClientRectangle);
            g.DrawRectangle(new Pen(Color.White), new Rectangle(colorResultSelectorX - 2, 1, 4, colorResult.Height - 2));
            //Bitmap x = BitmapExtensions.DrawControl(colorResult);
            //colorFinal.BackColor = x.GetPixel(colorResultSelectorX <= 0 ? 1 : (colorResultSelectorX >= colorResult.Width ? colorResult.Width - 1 : colorResultSelectorX), colorResult.Height / 2);
            //x.Dispose();
        }

        private void colorResult_MouseDown(object sender, MouseEventArgs e)
        {
            colorResultSelectorX = e.X;
            colorResult.Invalidate();
        }

        private void colorResult_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                colorResultSelectorX = e.X;
                colorResult.Invalidate();
                if (selectedElemnts.Count > 0)
                {
                    for (int index = 0; index < selectedElemnts.Count; index++)
                    {
                        var element = elements[selectedElemnts[index]];
                        if (element.Type == ElementType.Path || element.Type == ElementType.Text)
                        {
                            element.Color = colorFinal.BackColor;
                        }
                    }
                    workspace_box.Invalidate();
                }
            }
        }

        private void removeImageColorsMatchSelectedColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedElemnts.Count > 0 && elements[selectedElemnts[0]].Type == ElementType.Image)
            {
                selectTool(Tools.ColorRemover);
            }
        }

        private void penWid_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedElemnts.Count == 0) return;
            List<GraphicsElement> tmp = new List<GraphicsElement>();
            foreach (var item in selectedElemnts)
            {
                tmp.Add(elements[item]);
            }
            Clipboard.Clear();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, tmp.ToArray());
                Clipboard.SetData("PaintElements", ms.ToArray());
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedElemnts.Clear();
            elementsListBox.SelectedIndices.Clear();
            byte[] data = (byte[])Clipboard.GetData("PaintElements");
            if (data != null)
            {
                using (System.IO.MemoryStream ms = new MemoryStream(data, true))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    var obj = binaryFormatter.Deserialize(ms);
                    GraphicsElement[] tmp = (GraphicsElement[])obj;
                    if (tmp != null)
                    {
                        foreach (var item in tmp)
                        {
                            elements.Add(item.Clone());
                            elementsListBox.Items.Add(item.Name != null ? item.Name : item.Type.ToString());
                            selectedElemnts.Add(elements.Count - 1);
                            elementsListBox.SelectedIndices.Add(elements.Count - 1);
                        }
                        workspace_box.Invalidate();
                    }
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedElemnts.Count == 0) return;
            List<GraphicsElement> tmp = new List<GraphicsElement>();
            foreach (var item in selectedElemnts)
            {
                tmp.Add(elements[item]);
            }
            Clipboard.Clear();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(ms, tmp.ToArray());
                Clipboard.SetData("PaintElements", ms.ToArray());
            }
            selectedElemnts.Sort();
            for (int i = selectedElemnts.Count - 1; i > 0; i--)
            {
                elements.RemoveAt(selectedElemnts[i]);
            }
            selectedElemnts.Clear();
            workspace_box.Invalidate();
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void colorFinal_Paint(object sender, PaintEventArgs e)
        {
            rgbText.Text = colorFinal.BackColor.A + "," + colorFinal.BackColor.R + "," + colorFinal.BackColor.G + "," + colorFinal.BackColor.B;
        }

        private void colorpanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void rgbText_Click(object sender, EventArgs e)
        {

        }

        private void colorFinal_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = colorFinal.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorFinal.BackColor = colorDialog.Color;
                HColor hcol = HSLColor.FromRGB(colorDialog.Color);
                changeColorWheelSelectorLocationToColor(colorFinal.BackColor);
                colorResultSelectorX = (int)System.Math.Round(hcol.Lightness * colorResult.Width);
                colorResult.Invalidate();
            }
        }

        private void colorResult_Click(object sender, EventArgs e)
        {

        }

        private void colorFinal_Click(object sender, EventArgs e)
        {

        }

        private void replaceColorsWithSelectedColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedElemnts.Count > 0 && selectedElemnts.Count == 1)
            {
                if (elements[selectedElemnts[0]].Type == ElementType.Image)
                {
                    elements[selectedElemnts[0]].Image = ImageProcessing.ProcessImage((Bitmap)elements[selectedElemnts[0]].Image,
                        (c) =>
                        {
                            if (c.Color.A > 150)
                                return new Pixel(colorFinal.BackColor, c.Location);
                            else return c;
                        });
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (workspace_box != null)
            {
                centerWorkspacebox();
            }
        }
    }

}
