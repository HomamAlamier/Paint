using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paint
{
    public partial class TextInsertDialog : Form
    {
        public Font ResultFont { get => textBox1.Font; set => textBox1.Font = value; }
        public string ResultText { get => textBox1.Text; set => textBox1.Text = value; }
        public string OkButtonText { get => button1.Text; set => button1.Text = value; }

        bool init = true;
        public TextInsertDialog()
        {
            InitializeComponent();
        }

        private void TextInsertDialog_Load(object sender, EventArgs e)
        {
            foreach (var font in FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            comboBox2.Text = textBox1.Font.Size.ToString();
            comboBox1.Text = textBox1.Font.FontFamily.Name;
            if (textBox1.Font.Style.HasFlag(FontStyle.Bold)) checkBox1.Checked = true;
            if (textBox1.Font.Style.HasFlag(FontStyle.Italic)) checkBox2.Checked = true;
            if (textBox1.Font.Style.HasFlag(FontStyle.Underline)) checkBox3.Checked = true;
            init = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init) textBox1.Font = new Font(comboBox1.Text, float.Parse(comboBox2.Text), textBox1.Font.Style);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init) textBox1.Font = new Font(textBox1.Font.FontFamily, float.Parse(comboBox2.Text), textBox1.Font.Style);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!init) textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size,
                (checkBox1.Checked ? FontStyle.Bold : FontStyle.Regular) |
                (checkBox2.Checked ? FontStyle.Italic : FontStyle.Regular) |
                (checkBox3.Checked ? FontStyle.Underline : FontStyle.Regular));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!init) textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size,
                (checkBox1.Checked ? FontStyle.Bold : FontStyle.Regular) |
                (checkBox2.Checked ? FontStyle.Italic : FontStyle.Regular) |
                (checkBox3.Checked ? FontStyle.Underline : FontStyle.Regular));
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!init) textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size,
                (checkBox1.Checked ? FontStyle.Bold : FontStyle.Regular) |
                (checkBox2.Checked ? FontStyle.Italic : FontStyle.Regular) |
                (checkBox3.Checked ? FontStyle.Underline : FontStyle.Regular));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
