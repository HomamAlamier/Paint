namespace Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.penWid = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.filledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.szLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.posLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.elementsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxManageTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colorpanel = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rgbText = new System.Windows.Forms.Label();
            this.colorFinal = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colorResult = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.elementsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoResizeWorkSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redOnlyFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenOnlyFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueOnlyFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceColorsWithSelectedColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeImageColorsMatchSelectedColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.inverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.elementsMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorpanel)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(50, 655);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(47, 34);
            this.toolStripButton2.Text = "Select";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penWid});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(47, 34);
            this.toolStripButton1.Text = "Pen";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton1.ToolTipText = "Pen";
            this.toolStripButton1.ButtonClick += new System.EventHandler(this.toolStripButton1_ButtonClick);
            // 
            // penWid
            // 
            this.penWid.AutoSize = false;
            this.penWid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.penWid.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.penWid.Name = "penWid";
            this.penWid.Size = new System.Drawing.Size(70, 28);
            this.penWid.Text = "2";
            this.penWid.ToolTipText = "Pen Width";
            this.penWid.Click += new System.EventHandler(this.penWid_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filledToolStripMenuItem});
            this.toolStripButton3.Image = global::Paint.CursorsData.text;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(47, 34);
            this.toolStripButton3.Text = "Insert Text";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // filledToolStripMenuItem
            // 
            this.filledToolStripMenuItem.Checked = true;
            this.filledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filledToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filledToolStripMenuItem.Name = "filledToolStripMenuItem";
            this.filledToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.filledToolStripMenuItem.Text = "Filled";
            this.filledToolStripMenuItem.Click += new System.EventHandler(this.filledToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Paint.CursorsData.image;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(47, 34);
            this.toolStripButton4.Text = "Insert Image";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Paint.CursorsData.crop;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(47, 34);
            this.toolStripButton5.Text = "Crop";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::Paint.CursorsData.rotate;
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(47, 34);
            this.toolStripButton6.Text = "Rotate";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabel,
            this.szLabel,
            this.posLabel,
            this.toolStripStatusLabel1,
            this.statsLabel,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1302, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolLabel
            // 
            this.toolLabel.Name = "toolLabel";
            this.toolLabel.Size = new System.Drawing.Size(38, 20);
            this.toolLabel.Text = "Tool";
            // 
            // szLabel
            // 
            this.szLabel.Name = "szLabel";
            this.szLabel.Size = new System.Drawing.Size(28, 20);
            this.szLabel.Text = "0,0";
            this.szLabel.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // posLabel
            // 
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(28, 20);
            this.posLabel.Text = "0,0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1045, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // statsLabel
            // 
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(63, 20);
            this.statsLabel.Text = "Nothing";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(85, 20);
            this.toolStripStatusLabel2.Text = "                   ";
            // 
            // elementsMenu
            // 
            this.elementsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.elementsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.elementsMenu.Name = "elementsMenu";
            this.elementsMenu.Size = new System.Drawing.Size(123, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1102, 28);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(200, 655);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.colorpanel);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(1, 221);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 292);
            this.panel3.TabIndex = 1;
            // 
            // colorpanel
            // 
            this.colorpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorpanel.Location = new System.Drawing.Point(0, 17);
            this.colorpanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.colorpanel.Name = "colorpanel";
            this.colorpanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.colorpanel.Size = new System.Drawing.Size(190, 190);
            this.colorpanel.TabIndex = 1;
            this.colorpanel.TabStop = false;
            this.colorpanel.Click += new System.EventHandler(this.colorpanel_Click);
            this.colorpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.colorpanel_Paint);
            this.colorpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorpanel_MouseDown);
            this.colorpanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorpanel_MouseMove);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rgbText);
            this.panel4.Controls.Add(this.colorFinal);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.colorResult);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(190, 81);
            this.panel4.TabIndex = 2;
            // 
            // rgbText
            // 
            this.rgbText.BackColor = System.Drawing.Color.White;
            this.rgbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rgbText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rgbText.Location = new System.Drawing.Point(46, 47);
            this.rgbText.Name = "rgbText";
            this.rgbText.Size = new System.Drawing.Size(98, 23);
            this.rgbText.TabIndex = 10;
            this.rgbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rgbText.Click += new System.EventHandler(this.rgbText_Click);
            // 
            // colorFinal
            // 
            this.colorFinal.Location = new System.Drawing.Point(3, 38);
            this.colorFinal.Name = "colorFinal";
            this.colorFinal.Size = new System.Drawing.Size(39, 40);
            this.colorFinal.TabIndex = 9;
            this.colorFinal.TabStop = false;
            this.colorFinal.Click += new System.EventHandler(this.colorFinal_Click);
            this.colorFinal.Paint += new System.Windows.Forms.PaintEventHandler(this.colorFinal_Paint);
            this.colorFinal.DoubleClick += new System.EventHandler(this.colorFinal_DoubleClick);
            // 
            // button1
            // 
            this.button1.Image = global::Paint.CursorsData.colorpicker;
            this.button1.Location = new System.Drawing.Point(147, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // colorResult
            // 
            this.colorResult.Location = new System.Drawing.Point(0, 0);
            this.colorResult.Name = "colorResult";
            this.colorResult.Size = new System.Drawing.Size(200, 35);
            this.colorResult.TabIndex = 6;
            this.colorResult.TabStop = false;
            this.colorResult.Click += new System.EventHandler(this.colorResult_Click);
            this.colorResult.Paint += new System.Windows.Forms.PaintEventHandler(this.colorResult_Paint);
            this.colorResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorResult_MouseDown);
            this.colorResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorResult_MouseMove);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Color";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.elementsListBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 220);
            this.panel2.TabIndex = 0;
            // 
            // elementsListBox
            // 
            this.elementsListBox.ContextMenuStrip = this.elementsMenu;
            this.elementsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementsListBox.FormattingEnabled = true;
            this.elementsListBox.ItemHeight = 16;
            this.elementsListBox.Location = new System.Drawing.Point(0, 17);
            this.elementsListBox.Name = "elementsListBox";
            this.elementsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.elementsListBox.Size = new System.Drawing.Size(194, 203);
            this.elementsListBox.TabIndex = 1;
            this.elementsListBox.SelectedIndexChanged += new System.EventHandler(this.elementsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elements";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1302, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // exportImageToolStripMenuItem
            // 
            this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            this.exportImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.exportImageToolStripMenuItem.Text = "Export Image";
            this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.exportImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.sizeingToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.editToolStripMenuItem.Text = "Workspace";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(425, 26);
            this.toolStripMenuItem1.Text = "Change BackColor To Selected Color";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // sizeingToolStripMenuItem
            // 
            this.sizeingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.autoResizeWorkSpaceToolStripMenuItem});
            this.sizeingToolStripMenuItem.Name = "sizeingToolStripMenuItem";
            this.sizeingToolStripMenuItem.Size = new System.Drawing.Size(425, 26);
            this.sizeingToolStripMenuItem.Text = "Sizeing";
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(301, 26);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // autoResizeWorkSpaceToolStripMenuItem
            // 
            this.autoResizeWorkSpaceToolStripMenuItem.Name = "autoResizeWorkSpaceToolStripMenuItem";
            this.autoResizeWorkSpaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.autoResizeWorkSpaceToolStripMenuItem.Size = new System.Drawing.Size(301, 26);
            this.autoResizeWorkSpaceToolStripMenuItem.Text = "Auto Resize WorkSpace";
            this.autoResizeWorkSpaceToolStripMenuItem.Click += new System.EventHandler(this.autoResizeWorkSpaceToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilterToolStripMenuItem,
            this.imageElementToolStripMenuItem,
            this.transparencyToolStripMenuItem,
            this.inverseToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // addFilterToolStripMenuItem
            // 
            this.addFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invertColorsToolStripMenuItem,
            this.negativeToolStripMenuItem,
            this.blackWhiteToolStripMenuItem,
            this.colorFiltersToolStripMenuItem});
            this.addFilterToolStripMenuItem.Name = "addFilterToolStripMenuItem";
            this.addFilterToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.addFilterToolStripMenuItem.Text = "Apply Filters";
            this.addFilterToolStripMenuItem.Click += new System.EventHandler(this.addFilterToolStripMenuItem_Click);
            // 
            // invertColorsToolStripMenuItem
            // 
            this.invertColorsToolStripMenuItem.Name = "invertColorsToolStripMenuItem";
            this.invertColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.invertColorsToolStripMenuItem.Text = "Invert Colors";
            this.invertColorsToolStripMenuItem.Click += new System.EventHandler(this.invertColorsToolStripMenuItem_Click_1);
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.negativeToolStripMenuItem.Text = "GrayScale";
            this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negativeToolStripMenuItem_Click);
            // 
            // blackWhiteToolStripMenuItem
            // 
            this.blackWhiteToolStripMenuItem.Name = "blackWhiteToolStripMenuItem";
            this.blackWhiteToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.blackWhiteToolStripMenuItem.Text = "Black White";
            this.blackWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackWhiteToolStripMenuItem_Click);
            // 
            // colorFiltersToolStripMenuItem
            // 
            this.colorFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redOnlyFilterToolStripMenuItem,
            this.greenOnlyFilterToolStripMenuItem,
            this.blueOnlyFilterToolStripMenuItem});
            this.colorFiltersToolStripMenuItem.Name = "colorFiltersToolStripMenuItem";
            this.colorFiltersToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.colorFiltersToolStripMenuItem.Text = "Color Filters";
            // 
            // redOnlyFilterToolStripMenuItem
            // 
            this.redOnlyFilterToolStripMenuItem.Name = "redOnlyFilterToolStripMenuItem";
            this.redOnlyFilterToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.redOnlyFilterToolStripMenuItem.Text = "Red Only Filter";
            this.redOnlyFilterToolStripMenuItem.Click += new System.EventHandler(this.redOnlyFilterToolStripMenuItem_Click);
            // 
            // greenOnlyFilterToolStripMenuItem
            // 
            this.greenOnlyFilterToolStripMenuItem.Name = "greenOnlyFilterToolStripMenuItem";
            this.greenOnlyFilterToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.greenOnlyFilterToolStripMenuItem.Text = "Green Only Filter";
            this.greenOnlyFilterToolStripMenuItem.Click += new System.EventHandler(this.greenOnlyFilterToolStripMenuItem_Click);
            // 
            // blueOnlyFilterToolStripMenuItem
            // 
            this.blueOnlyFilterToolStripMenuItem.Name = "blueOnlyFilterToolStripMenuItem";
            this.blueOnlyFilterToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.blueOnlyFilterToolStripMenuItem.Text = "Blue Only Filter";
            this.blueOnlyFilterToolStripMenuItem.Click += new System.EventHandler(this.blueOnlyFilterToolStripMenuItem_Click);
            // 
            // imageElementToolStripMenuItem
            // 
            this.imageElementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceColorsWithSelectedColorToolStripMenuItem,
            this.removeImageColorsMatchSelectedColorToolStripMenuItem});
            this.imageElementToolStripMenuItem.Name = "imageElementToolStripMenuItem";
            this.imageElementToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.imageElementToolStripMenuItem.Text = "Image Element";
            // 
            // replaceColorsWithSelectedColorToolStripMenuItem
            // 
            this.replaceColorsWithSelectedColorToolStripMenuItem.Name = "replaceColorsWithSelectedColorToolStripMenuItem";
            this.replaceColorsWithSelectedColorToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.replaceColorsWithSelectedColorToolStripMenuItem.Text = "Color Replace";
            this.replaceColorsWithSelectedColorToolStripMenuItem.Click += new System.EventHandler(this.replaceColorsWithSelectedColorToolStripMenuItem_Click);
            // 
            // removeImageColorsMatchSelectedColorToolStripMenuItem
            // 
            this.removeImageColorsMatchSelectedColorToolStripMenuItem.Name = "removeImageColorsMatchSelectedColorToolStripMenuItem";
            this.removeImageColorsMatchSelectedColorToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.removeImageColorsMatchSelectedColorToolStripMenuItem.Text = "Matching Color Remove";
            this.removeImageColorsMatchSelectedColorToolStripMenuItem.Click += new System.EventHandler(this.removeImageColorsMatchSelectedColorToolStripMenuItem_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.transparencyToolStripMenuItem.Text = "Transparency";
            this.transparencyToolStripMenuItem.Click += new System.EventHandler(this.transparencyToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "0%",
            "10%",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // inverseToolStripMenuItem
            // 
            this.inverseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontallyToolStripMenuItem,
            this.verticallyToolStripMenuItem});
            this.inverseToolStripMenuItem.Name = "inverseToolStripMenuItem";
            this.inverseToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.inverseToolStripMenuItem.Text = "Inverse";
            this.inverseToolStripMenuItem.Click += new System.EventHandler(this.inverseToolStripMenuItem_Click);
            // 
            // horizontallyToolStripMenuItem
            // 
            this.horizontallyToolStripMenuItem.Name = "horizontallyToolStripMenuItem";
            this.horizontallyToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.horizontallyToolStripMenuItem.Text = "Horizontally";
            this.horizontallyToolStripMenuItem.Click += new System.EventHandler(this.horizontallyToolStripMenuItem_Click);
            // 
            // verticallyToolStripMenuItem
            // 
            this.verticallyToolStripMenuItem.Name = "verticallyToolStripMenuItem";
            this.verticallyToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.verticallyToolStripMenuItem.Text = "Vertically";
            this.verticallyToolStripMenuItem.Click += new System.EventHandler(this.verticallyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1302, 709);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Paint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.elementsMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorpanel)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel posLabel;
        private System.Windows.Forms.ContextMenuStrip elementsMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel;
        private System.Windows.Forms.Timer toolBoxManageTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.PictureBox colorpanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox colorResult;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox penWid;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redOnlyFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenOnlyFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueOnlyFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem imageElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceColorsWithSelectedColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statsLabel;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSplitButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem filledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem inverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox colorFinal;
        private System.Windows.Forms.ToolStripMenuItem removeImageColorsMatchSelectedColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoResizeWorkSpaceToolStripMenuItem;
        private System.Windows.Forms.Label rgbText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel szLabel;
    }
}

