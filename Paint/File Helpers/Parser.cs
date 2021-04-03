using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Paint
{
    public static class Parser
    {
        public static Color ParseColor(string str)
        {
            string[] inner = str.Split(new char[] { '[', ']' });
            if (inner[1].IndexOf(",") == -1)
            {
                if (inner[1] == "Empty") return Color.Transparent;
                return (Color)(new ColorConverter().ConvertFromString(inner[1]));
            }
            else
            {

                string[] vals = inner[1].Split(new char[] { ',' });
                int A = 0, R = 0, G = 0, B = 0;
                foreach (var val in vals)
                {

                    string[] para = val.Split(new char[] { '=' });
                    switch (para[0].Trim())
                    {
                        case "A":
                            {
                                A = int.Parse(para[1]);
                            }
                            break;
                        case "R":
                            {
                                R = int.Parse(para[1]);
                            }
                            break;
                        case "G":
                            {
                                G = int.Parse(para[1]);
                            }
                            break;
                        case "B":
                            {
                                B = int.Parse(para[1]);
                            }
                            break;
                    }

                }

                return Color.FromArgb(A, R, G, B);
            }
        }
        public static RectangleF ParseRectangleF(string str)
        {
            string[] inner = str.Split(new char[] { '{', '}' });
            string[] vals = inner[1].Split(new char[] { ',' });
            RectangleF rect = new RectangleF();
            foreach (var val in vals)
            {

                string[] para = val.Split(new char[] { '=' });
                switch (para[0].Trim())
                {
                    case "X":
                        {
                            rect.X = float.Parse(para[1]);
                        }
                        break;
                    case "Y":
                        {
                            rect.Y = float.Parse(para[1]);
                        }
                        break;
                    case "Width":
                        {
                            rect.Width = float.Parse(para[1]);
                        }
                        break;
                    case "Height":
                        {
                            rect.Height = float.Parse(para[1]);
                        }
                        break;
                }

            }

            return rect;
        }
        public static PointF ParsePointF(string str)
        {
            string[] inner = str.Split(new char[] { '{', '}' });
            string[] vals = inner[1].Split(new char[] { ',' });
            PointF point = new PointF();
            foreach (var val in vals)
            {

                string[] para = val.Split(new char[] { '=' });
                switch (para[0].Trim())
                {
                    case "X":
                        {
                            point.X = float.Parse(para[1]);
                        }
                        break;
                    case "Y":
                        {
                            point.Y = float.Parse(para[1]);
                        }
                        break;
                }

            }

            return point;
        }
    }
}
