using System;
using System.Collections.Generic;
using System.IO;
namespace Paint
{
    public static class ProjectFileManager
    {

        public static void SaveProject(string filename, List<GraphicsElement> elements, System.Drawing.Size sz, System.Drawing.Color color)
        {
            string xml = "<project>\n";
            xml += XML.XML_TYPE("Width", sz.Width) + "\n";
            xml += XML.XML_TYPE("Height", sz.Height) + "\n";
            xml += XML.XML_TYPE("BColor", color) + "\n";
            foreach (var element in elements)
            {
                xml += "<element>\n";
                if (element.Name != null) xml += XML.XML_TYPE("Name", element.Name) + "\n";
                xml += XML.XML_TYPE("PenWidth", element.PenWidth) + "\n";
                xml += XML.XML_TYPE("Type", element.Type) + "\n";
                xml += XML.XML_TYPE("Angle", element.Angle) + "\n";
                xml += XML.XML_TYPE("Color", element.Color) + "\n";
                xml += XML.XML_TYPE("Transparency", element.Transparency) + "\n";
                if (element.Font != null) xml += XML.XML_TYPE("Font", element.Font) + "\n";
                xml += XML.XML_TYPE("Filled", element.Filled) + "\n";
                if (element.Text != null) xml += XML.XML_TYPE("Text", element.Text) + "\n";
                xml += XML.XML_TYPE("Rectangle", element.ClientRectangle) + "\n";
                if (element.Image != null)
                {
                    string image = "";
                    using (MemoryStream ms = new MemoryStream())
                    {
                        element.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        foreach (var item in ms.ToArray())
                        {
                            image += item.ToString() + ",";
                        }
                    }
                    xml += XML.XML_TYPE("Image", image) + "\n";
                }
                if (element.Path != null)
                {

                    xml += "<path>\n";
                    for (int i = 0; i < element.Path.PointCount; i++)
                    {
                        xml += XML.XML_TYPE("Point", element.Path.PathPoints[i]) + "\n";
                    }
                    xml += "</path>\n";
                }
                xml += "</element>\n";
            }
            xml += "</project>";
            File.WriteAllText(filename, xml);
        }
        public static List<GraphicsElement> OpenProject(string filename, out System.Drawing.Size sz, out System.Drawing.Color col)
        {
            sz = new System.Drawing.Size();
            col = System.Drawing.Color.Empty;
            string file = File.ReadAllText(filename);
            string[] lines = file.Split(new char[] { '\n' });
            List<GraphicsElement> tmp = new List<GraphicsElement>();
            GraphicsElement tmp2 = new GraphicsElement(new System.Drawing.SizeF());
            List<System.Drawing.PointF> points = new List<System.Drawing.PointF>();
            foreach (var line in lines)
            {
                if (line == string.Empty) continue;
                if (line == "<element>") tmp2 = new GraphicsElement(new System.Drawing.SizeF());
                else if (line == "</element>") { tmp2.update_Transparency(); tmp.Add(tmp2); }
                else if (line == "<project>" || line == "</project>")
                {

                }
                else if (line == "<path>")
                {
                    points.Clear();
                    tmp2.Path = new GraphicsPath();
                }
                else if (line == "</path>") tmp2.Path.AddLines(points.ToArray());
                else
                {
                    var xt = XML.XML_TYPE_PARSE(line);
                    foreach (var item in xt)
                    {

                        switch (item.Type)
                        {
                            case "Name":
                                {
                                    tmp2.Name = item.value;
                                }
                                break;
                            case "PenWidth":
                                {
                                    tmp2.PenWidth = int.Parse(item.value);
                                }
                                break;
                            case "Type":
                                {
                                    tmp2.Type = (ElementType)Enum.Parse(typeof(ElementType), item.value);
                                }
                                break;
                            case "Angle":
                                {
                                    tmp2.Angle = float.Parse(item.value);
                                }
                                break;
                            case "Color":
                                {
                                    tmp2.Color = Parser.ParseColor(item.value);
                                }
                                break;
                            case "Transparency":
                                {
                                    tmp2.Transparency = int.Parse(item.value);
                                }
                                break;
                            case "Filled":
                                {
                                    tmp2.Filled = bool.Parse(item.value);
                                }
                                break;
                            case "Rectangle":
                                {
                                    var rect = Parser.ParseRectangleF(item.value);
                                    tmp2.Position = rect.Location;
                                    tmp2.Size = rect.Size;
                                }
                                break;
                            case "Point":
                                {
                                    points.Add(Parser.ParsePointF(item.value));
                                }
                                break;
                            case "Image":
                                {
                                    string[] b = item.value.Split(new char[] { ',' });
                                    List<byte> byts = new List<byte>();
                                    foreach (string byt in b) if (byt != string.Empty) byts.Add(byte.Parse(byt));
                                    tmp2.Image = System.Drawing.Image.FromStream(new MemoryStream(byts.ToArray()));
                                }
                                break;
                            case "Width":
                                {
                                    sz = new System.Drawing.Size(int.Parse(item.value), 0);
                                }
                                break;
                            case "Height":
                                {
                                    sz = new System.Drawing.Size(sz.Width, int.Parse(item.value));
                                }
                                break;
                            case "BColor":
                                {
                                    col = Parser.ParseColor(item.value);
                                }
                                break;
                        }

                    }
                }
            }
            return tmp;
        }

    }
}
