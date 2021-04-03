using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paint
{
    public class XML_TYPE
    {
        public string Type { get; set; }
        public string value { get; set; }
    }
    public static class XML
    {
        public static string XML_TYPE(string type, string[] keys, string[] values)
        {
            string tmp = "<" + type + " ";
            for (int i = 0; i < keys.Length; i++)
            {
                tmp += keys[i] + "=\"" + values[i] + "\" ";
            }
            tmp += "/>";
            return tmp;
        }
        public static string XML_TYPE(string type, object value)
        {
            if (value == null) return "";
            return "<" + type + " value=\"" + value.ToString() + "\" />";
        }
        public static XML_TYPE[] XML_TYPE_PARSE(string str)
        {
            List<XML_TYPE> types = new List<XML_TYPE>();
            string[] blocks = str.Split(new char[] { '<', '>' });
            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == string.Empty) continue;
                string blk = blocks[i];
                if (blk.IndexOf(" ") == -1) continue;
                string t = blk.Substring(0, blk.IndexOf(" "));
                int fQ = blk.IndexOf("\"");
                int indQ = 0, oldQ = fQ;
                while (indQ > -1)
                {
                    indQ = blk.IndexOf("\"", oldQ + 1);
                    if (indQ > -1) oldQ = indQ;
                }
                fQ++;
                string v = blk.Substring(fQ, oldQ - fQ);
                types.Add(new Paint.XML_TYPE() { Type = t, value = v });
            }
            return types.ToArray();
        }

    }
}
