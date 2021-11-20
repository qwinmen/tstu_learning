namespace WindowsApplication1
{
    partial class toolBox
    {

        private vectShapes s;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(toolBox));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.PenMnu = new System.Windows.Forms.ToolStripDropDownButton();
            this.PenColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.FillMnu = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.FillColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.iNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SelectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RectBtn = new System.Windows.Forms.ToolStripButton();
            this.LineBtn = new System.Windows.Forms.ToolStripButton();
            this.CirciBtn = new System.Windows.Forms.ToolStripButton();
            this.RRectBtn = new System.Windows.Forms.ToolStripButton();
            this.ImageBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Grid1Btn = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.textMnu = new System.Windows.Forms.ToolStripDropDownButton();
            this.SimpleTextBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.RTFBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ArcBtn = new System.Windows.Forms.ToolStripButton();
            this.PolyBtn = new System.Windows.Forms.ToolStripButton();
            this.CurveBtn = new System.Windows.Forms.ToolStripButton();
            this.GraphBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoBtn = new System.Windows.Forms.ToolStripButton();
            this.RedoBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.GroupBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.deGroupBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.polyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
            this.delPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripMenuItem();
            this.addArcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.delNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenMnu,
            this.FillMnu,
            this.toolStripDropDownButton2,
            this.toolStripButton5});
            this.toolStrip2.Location = new System.Drawing.Point(56, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip2.Size = new System.Drawing.Size(290, 26);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "Pen";
            // 
            // PenMnu
            // 
            this.PenMnu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PenMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenColor,
            this.toolStripMenuItem2});
            this.PenMnu.Image = ((System.Drawing.Image)(resources.GetObject("PenMnu.Image")));
            this.PenMnu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PenMnu.Name = "PenMnu";
            this.PenMnu.Size = new System.Drawing.Size(45, 23);
            this.PenMnu.Text = "Pen";
            // 
            // PenColor
            // 
            this.PenColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.PenColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(122, 26);
            this.PenColor.Text = "color";
            this.PenColor.Click += new System.EventHandler(this.PenColor_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripTextBox2});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 26);
            this.toolStripMenuItem2.Text = "width";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem10.Text = "0,5";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem11.Text = "1";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem12.Text = "1,5";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem13.Text = "2";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem14.Text = "3";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem15.Text = "4";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem16.Text = "5";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.MaxLength = 2;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 31);
            this.toolStripTextBox2.TextChanged += new System.EventHandler(this.toolStripTextBox2_TextChanged);
            // 
            // FillMnu
            // 
            this.FillMnu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FillMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17,
            this.FillColor});
            this.FillMnu.Image = ((System.Drawing.Image)(resources.GetObject("FillMnu.Image")));
            this.FillMnu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FillMnu.Name = "FillMnu";
            this.FillMnu.Size = new System.Drawing.Size(38, 23);
            this.FillMnu.Text = "Fill";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.CheckOnClick = true;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(124, 26);
            this.toolStripMenuItem17.Text = "ON";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click);
            // 
            // FillColor
            // 
            this.FillColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.FillColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillColor.ForeColor = System.Drawing.Color.White;
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(124, 26);
            this.FillColor.Text = "Color";
            this.FillColor.Click += new System.EventHandler(this.FillColor_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNToolStripMenuItem,
            this.oUTToolStripMenuItem,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22,
            this.toolStripMenuItem23,
            this.toolStripMenuItem24,
            this.toolStripMenuItem25,
            this.toolStripMenuItem26,
            this.toolStripMenuItem27,
            this.toolStripMenuItem28,
            this.toolStripMenuItem29,
            this.toolStripMenuItem30,
            this.toolStripMenuItem31});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(58, 23);
            this.toolStripDropDownButton2.Text = "Zoom";
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click_1);
            // 
            // iNToolStripMenuItem
            // 
            this.iNToolStripMenuItem.Name = "iNToolStripMenuItem";
            this.iNToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.iNToolStripMenuItem.Text = "IN";
            this.iNToolStripMenuItem.Click += new System.EventHandler(this.iNToolStripMenuItem_Click);
            // 
            // oUTToolStripMenuItem
            // 
            this.oUTToolStripMenuItem.Name = "oUTToolStripMenuItem";
            this.oUTToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.oUTToolStripMenuItem.Text = "OUT";
            this.oUTToolStripMenuItem.Click += new System.EventHandler(this.oUTToolStripMenuItem_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem21.Text = "0.4";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.toolStripMenuItem21_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem22.Text = "0.6";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.toolStripMenuItem22_Click);
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem23.Text = "0.8";
            this.toolStripMenuItem23.Click += new System.EventHandler(this.toolStripMenuItem23_Click);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem24.Text = "1";
            this.toolStripMenuItem24.Click += new System.EventHandler(this.toolStripMenuItem24_Click);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem25.Text = "1.2";
            this.toolStripMenuItem25.Click += new System.EventHandler(this.toolStripMenuItem25_Click);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem26.Text = "1.4";
            this.toolStripMenuItem26.Click += new System.EventHandler(this.toolStripMenuItem26_Click);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem27.Text = "1.6";
            this.toolStripMenuItem27.Click += new System.EventHandler(this.toolStripMenuItem27_Click);
            // 
            // toolStripMenuItem28
            // 
            this.toolStripMenuItem28.Name = "toolStripMenuItem28";
            this.toolStripMenuItem28.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem28.Text = "2";
            this.toolStripMenuItem28.Click += new System.EventHandler(this.toolStripMenuItem28_Click);
            // 
            // toolStripMenuItem29
            // 
            this.toolStripMenuItem29.Name = "toolStripMenuItem29";
            this.toolStripMenuItem29.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem29.Text = "3";
            this.toolStripMenuItem29.Click += new System.EventHandler(this.toolStripMenuItem29_Click);
            // 
            // toolStripMenuItem30
            // 
            this.toolStripMenuItem30.Name = "toolStripMenuItem30";
            this.toolStripMenuItem30.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem30.Text = "4";
            this.toolStripMenuItem30.Click += new System.EventHandler(this.toolStripMenuItem30_Click);
            // 
            // toolStripMenuItem31
            // 
            this.toolStripMenuItem31.Name = "toolStripMenuItem31";
            this.toolStripMenuItem31.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem31.Text = "?";
            this.toolStripMenuItem31.Click += new System.EventHandler(this.toolStripMenuItem31_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton5.Text = "?";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // SelectBtn
            // 
            this.SelectBtn.Checked = true;
            this.SelectBtn.CheckOnClick = true;
            this.SelectBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(51, 23);
            this.SelectBtn.Text = "Select";
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(51, 6);
            // 
            // RectBtn
            // 
            this.RectBtn.CheckOnClick = true;
            this.RectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RectBtn.Image = ((System.Drawing.Image)(resources.GetObject("RectBtn.Image")));
            this.RectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectBtn.Name = "RectBtn";
            this.RectBtn.Size = new System.Drawing.Size(51, 23);
            this.RectBtn.Text = "Rect";
            this.RectBtn.Click += new System.EventHandler(this.RectBtn_Click);
            // 
            // LineBtn
            // 
            this.LineBtn.CheckOnClick = true;
            this.LineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LineBtn.Image = ((System.Drawing.Image)(resources.GetObject("LineBtn.Image")));
            this.LineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineBtn.Name = "LineBtn";
            this.LineBtn.Size = new System.Drawing.Size(51, 23);
            this.LineBtn.Text = "Line";
            this.LineBtn.Click += new System.EventHandler(this.LineBtn_Click);
            // 
            // CirciBtn
            // 
            this.CirciBtn.CheckOnClick = true;
            this.CirciBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CirciBtn.Image = ((System.Drawing.Image)(resources.GetObject("CirciBtn.Image")));
            this.CirciBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CirciBtn.Name = "CirciBtn";
            this.CirciBtn.Size = new System.Drawing.Size(51, 23);
            this.CirciBtn.Text = "Circ";
            this.CirciBtn.Click += new System.EventHandler(this.CirciBtn_Click);
            // 
            // RRectBtn
            // 
            this.RRectBtn.CheckOnClick = true;
            this.RRectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RRectBtn.Image = ((System.Drawing.Image)(resources.GetObject("RRectBtn.Image")));
            this.RRectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RRectBtn.Name = "RRectBtn";
            this.RRectBtn.Size = new System.Drawing.Size(51, 23);
            this.RRectBtn.Text = "RRect";
            this.RRectBtn.Click += new System.EventHandler(this.RRectBtn_Click);
            // 
            // ImageBtn
            // 
            this.ImageBtn.CheckOnClick = true;
            this.ImageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ImageBtn.Image = ((System.Drawing.Image)(resources.GetObject("ImageBtn.Image")));
            this.ImageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImageBtn.Name = "ImageBtn";
            this.ImageBtn.Size = new System.Drawing.Size(51, 23);
            this.ImageBtn.Text = "Image";
            this.ImageBtn.ToolTipText = "Image";
            this.ImageBtn.Click += new System.EventHandler(this.ImageBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(51, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(51, 6);
            // 
            // Grid1Btn
            // 
            this.Grid1Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Grid1Btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripTextBox1});
            this.Grid1Btn.Image = ((System.Drawing.Image)(resources.GetObject("Grid1Btn.Image")));
            this.Grid1Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Grid1Btn.Name = "Grid1Btn";
            this.Grid1Btn.Size = new System.Drawing.Size(51, 23);
            this.Grid1Btn.Text = "Grid";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem1.Text = "OFF";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem3.Text = "3";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem4.Text = "5";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem5.Text = "8";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem6.Text = "10";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem7.Text = "12";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem8.Text = "15";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(160, 24);
            this.toolStripMenuItem9.Text = "20";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.MaxLength = 4;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 31);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectBtn,
            this.toolStripSeparator3,
            this.RectBtn,
            this.LineBtn,
            this.CirciBtn,
            this.RRectBtn,
            this.textMnu,
            this.ImageBtn,
            this.ArcBtn,
            this.PolyBtn,
            this.CurveBtn,
            this.GraphBtn,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.Grid1Btn,
            this.UndoBtn,
            this.RedoBtn,
            this.toolStripSeparator6,
            this.toolStripSplitButton1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(56, 719);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textMnu
            // 
            this.textMnu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.textMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimpleTextBtn,
            this.RTFBtn});
            this.textMnu.Image = ((System.Drawing.Image)(resources.GetObject("textMnu.Image")));
            this.textMnu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textMnu.Name = "textMnu";
            this.textMnu.Size = new System.Drawing.Size(51, 23);
            this.textMnu.Text = "Text";
            // 
            // SimpleTextBtn
            // 
            this.SimpleTextBtn.CheckOnClick = true;
            this.SimpleTextBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SimpleTextBtn.Name = "SimpleTextBtn";
            this.SimpleTextBtn.Size = new System.Drawing.Size(143, 24);
            this.SimpleTextBtn.Text = "SimpleText";
            this.SimpleTextBtn.Click += new System.EventHandler(this.SimpleTextBtn_Click);
            // 
            // RTFBtn
            // 
            this.RTFBtn.CheckOnClick = true;
            this.RTFBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RTFBtn.Name = "RTFBtn";
            this.RTFBtn.Size = new System.Drawing.Size(143, 24);
            this.RTFBtn.Text = "RTF";
            this.RTFBtn.Click += new System.EventHandler(this.RTFBtn_Click);
            // 
            // ArcBtn
            // 
            this.ArcBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ArcBtn.Image = ((System.Drawing.Image)(resources.GetObject("ArcBtn.Image")));
            this.ArcBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ArcBtn.Name = "ArcBtn";
            this.ArcBtn.Size = new System.Drawing.Size(51, 23);
            this.ArcBtn.Text = "Arc";
            this.ArcBtn.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // PolyBtn
            // 
            this.PolyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PolyBtn.Image = ((System.Drawing.Image)(resources.GetObject("PolyBtn.Image")));
            this.PolyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PolyBtn.Name = "PolyBtn";
            this.PolyBtn.Size = new System.Drawing.Size(51, 23);
            this.PolyBtn.Text = "Poly";
            this.PolyBtn.Click += new System.EventHandler(this.PolyBtn_Click);
            // 
            // CurveBtn
            // 
            this.CurveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CurveBtn.Image = ((System.Drawing.Image)(resources.GetObject("CurveBtn.Image")));
            this.CurveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CurveBtn.Name = "CurveBtn";
            this.CurveBtn.Size = new System.Drawing.Size(51, 23);
            this.CurveBtn.Text = "Pen";
            this.CurveBtn.ToolTipText = "Draw a free hand curved shape";
            this.CurveBtn.Click += new System.EventHandler(this.CurveBtn_Click);
            // 
            // GraphBtn
            // 
            this.GraphBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GraphBtn.Image = ((System.Drawing.Image)(resources.GetObject("GraphBtn.Image")));
            this.GraphBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GraphBtn.Name = "GraphBtn";
            this.GraphBtn.Size = new System.Drawing.Size(51, 23);
            this.GraphBtn.Text = "Graph";
            this.GraphBtn.ToolTipText = "Draw a Graph ";
            this.GraphBtn.Click += new System.EventHandler(this.GraphBtn_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem18,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem20,
            this.toolStripMenuItem32,
            this.toolStripMenuItem19,
            this.printToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(51, 23);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(192, 24);
            this.toolStripMenuItem18.Text = "Load";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.toolStripMenuItem18_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(192, 24);
            this.toolStripMenuItem20.Text = "Load Objects";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.toolStripMenuItem20_Click);
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(192, 24);
            this.toolStripMenuItem32.Text = "Save Selected Objs";
            this.toolStripMenuItem32.Click += new System.EventHandler(this.toolStripMenuItem32_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(192, 24);
            this.toolStripMenuItem19.Text = "Preview";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.toolStripMenuItem19_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // UndoBtn
            // 
            this.UndoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UndoBtn.Enabled = false;
            this.UndoBtn.Image = ((System.Drawing.Image)(resources.GetObject("UndoBtn.Image")));
            this.UndoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(51, 23);
            this.UndoBtn.Text = "Undo";
            this.UndoBtn.ToolTipText = "Undo";
            this.UndoBtn.Click += new System.EventHandler(this.UndoBtn_Click);
            // 
            // RedoBtn
            // 
            this.RedoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RedoBtn.Enabled = false;
            this.RedoBtn.Image = ((System.Drawing.Image)(resources.GetObject("RedoBtn.Image")));
            this.RedoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoBtn.Name = "RedoBtn";
            this.RedoBtn.Size = new System.Drawing.Size(51, 23);
            this.RedoBtn.Text = "Redo";
            this.RedoBtn.ToolTipText = "Redo";
            this.RedoBtn.Click += new System.EventHandler(this.RedoBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(51, 6);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GroupBtn,
            this.deGroupBtn,
            this.polyToolStripMenuItem,
            this.toolStripMenuItem34});
            this.toolStripSplitButton1.Enabled = false;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(51, 23);
            this.toolStripSplitButton1.Text = "Obj";
            // 
            // GroupBtn
            // 
            this.GroupBtn.Name = "GroupBtn";
            this.GroupBtn.Size = new System.Drawing.Size(152, 24);
            this.GroupBtn.Text = "Group";
            this.GroupBtn.ToolTipText = "Groups 2 or more objects";
            this.GroupBtn.Click += new System.EventHandler(this.objToolStripMenuItem_Click);
            // 
            // deGroupBtn
            // 
            this.deGroupBtn.Name = "deGroupBtn";
            this.deGroupBtn.Size = new System.Drawing.Size(152, 24);
            this.deGroupBtn.Text = "deGroup";
            this.deGroupBtn.ToolTipText = "Dismantles a group obj";
            this.deGroupBtn.Click += new System.EventHandler(this.deGroupBtn_Click);
            // 
            // polyToolStripMenuItem
            // 
            this.polyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem33,
            this.delPointsToolStripMenuItem,
            this.extPointsToolStripMenuItem,
            this.mirrorToolStripMenuItem});
            this.polyToolStripMenuItem.Name = "polyToolStripMenuItem";
            this.polyToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.polyToolStripMenuItem.Text = "Poly";
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(139, 24);
            this.toolStripMenuItem33.Text = "Merge";
            this.toolStripMenuItem33.ToolTipText = "Merge 2 or more selected polygons";
            this.toolStripMenuItem33.Click += new System.EventHandler(this.toolStripMenuItem33_Click);
            // 
            // delPointsToolStripMenuItem
            // 
            this.delPointsToolStripMenuItem.Name = "delPointsToolStripMenuItem";
            this.delPointsToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.delPointsToolStripMenuItem.Text = "Del.Points";
            this.delPointsToolStripMenuItem.ToolTipText = "Deletes selected points from polygons";
            this.delPointsToolStripMenuItem.Click += new System.EventHandler(this.delPointsToolStripMenuItem_Click);
            // 
            // extPointsToolStripMenuItem
            // 
            this.extPointsToolStripMenuItem.Name = "extPointsToolStripMenuItem";
            this.extPointsToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.extPointsToolStripMenuItem.Text = "Ext.Points";
            this.extPointsToolStripMenuItem.ToolTipText = "Exctracts selected points from polygons";
            this.extPointsToolStripMenuItem.Click += new System.EventHandler(this.extPointsToolStripMenuItem_Click);
            // 
            // mirrorToolStripMenuItem
            // 
            this.mirrorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.xYToolStripMenuItem});
            this.mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            this.mirrorToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.mirrorToolStripMenuItem.Text = "Mirror";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // xYToolStripMenuItem
            // 
            this.xYToolStripMenuItem.Name = "xYToolStripMenuItem";
            this.xYToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.xYToolStripMenuItem.Text = "XY";
            this.xYToolStripMenuItem.Click += new System.EventHandler(this.xYToolStripMenuItem_Click);
            // 
            // toolStripMenuItem34
            // 
            this.toolStripMenuItem34.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addArcToolStripMenuItem,
            this.delNodeToolStripMenuItem});
            this.toolStripMenuItem34.Name = "toolStripMenuItem34";
            this.toolStripMenuItem34.Size = new System.Drawing.Size(152, 24);
            this.toolStripMenuItem34.Text = "Graph";
            // 
            // addArcToolStripMenuItem
            // 
            this.addArcToolStripMenuItem.Name = "addArcToolStripMenuItem";
            this.addArcToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.addArcToolStripMenuItem.Text = "AddArc";
            this.addArcToolStripMenuItem.Click += new System.EventHandler(this.addArcToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 23);
            this.toolStripButton1.Text = "2Front";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(51, 23);
            this.toolStripButton2.Text = "2Back";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(51, 23);
            this.toolStripButton3.Text = "Delete";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Enabled = false;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(51, 23);
            this.toolStripButton4.Text = "Copy";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(56, 26);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(290, 693);
            this.propertyGrid1.TabIndex = 2;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // delNodeToolStripMenuItem
            // 
            this.delNodeToolStripMenuItem.Name = "delNodeToolStripMenuItem";
            this.delNodeToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.delNodeToolStripMenuItem.Text = "DelNode";
            this.delNodeToolStripMenuItem.Click += new System.EventHandler(this.delNodeToolStripMenuItem_Click);
            // 
            // toolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "toolBox";
            this.Size = new System.Drawing.Size(346, 719);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton PenMnu;
        private System.Windows.Forms.ToolStripMenuItem PenColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripDropDownButton FillMnu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem FillColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton SelectBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton RectBtn;
        private System.Windows.Forms.ToolStripButton LineBtn;
        private System.Windows.Forms.ToolStripButton CirciBtn;
        private System.Windows.Forms.ToolStripButton RRectBtn;
        private System.Windows.Forms.ToolStripButton ImageBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton Grid1Btn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton UndoBtn;
        private System.Windows.Forms.ToolStripButton RedoBtn;
        private System.Windows.Forms.ToolStripButton ArcBtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem iNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem22;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem23;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem24;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem26;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem27;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem28;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem29;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem30;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem31;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem32;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem GroupBtn;
        private System.Windows.Forms.ToolStripMenuItem deGroupBtn;
        private System.Windows.Forms.ToolStripButton PolyBtn;
        private System.Windows.Forms.ToolStripMenuItem polyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem33;
        private System.Windows.Forms.ToolStripMenuItem delPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xYToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton textMnu;
        private System.Windows.Forms.ToolStripMenuItem SimpleTextBtn;
        private System.Windows.Forms.ToolStripMenuItem RTFBtn;
        private System.Windows.Forms.ToolStripButton CurveBtn;
        private System.Windows.Forms.ToolStripButton GraphBtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem34;
        private System.Windows.Forms.ToolStripMenuItem addArcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delNodeToolStripMenuItem;
    }
}
