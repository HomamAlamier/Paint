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
    public partial class ResizeForm : Form
    {
        public decimal W { get => numericUpDown1.Value; set => numericUpDown1.Value = value; }
        public decimal H { get => numericUpDown2.Value; set => numericUpDown2.Value = value; }

        public decimal aspectRatioH;
        public decimal aspectRatioW;
        public ResizeForm(decimal W, decimal H)
        {
            InitializeComponent();
            bool c = checkBox1.Checked;
            checkBox1.Checked = false;
            this.W = W;
            this.H = H;
            aspectRatioH = H / W;
            aspectRatioW = W / H;
            checkBox1.Checked = c;
        }

        private void ResizeForm_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) numericUpDown2.Value = aspectRatioH * numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) numericUpDown1.Value = aspectRatioW * numericUpDown2.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
