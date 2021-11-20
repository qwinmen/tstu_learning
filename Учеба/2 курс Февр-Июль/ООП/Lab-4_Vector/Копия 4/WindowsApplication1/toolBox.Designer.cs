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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.RectBtn = new System.Windows.Forms.Button();
            this.RRectBtn = new System.Windows.Forms.Button();
            this.LineBtn = new System.Windows.Forms.Button();
            this.CirciBtn = new System.Windows.Forms.Button();
            this.PolyBtn = new System.Windows.Forms.Button();
            this.CurveBtn = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
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
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.Controls.Add(this.SelectBtn);
            this.flowLayoutPanel1.Controls.Add(this.RectBtn);
            this.flowLayoutPanel1.Controls.Add(this.RRectBtn);
            this.flowLayoutPanel1.Controls.Add(this.LineBtn);
            this.flowLayoutPanel1.Controls.Add(this.CirciBtn);
            this.flowLayoutPanel1.Controls.Add(this.PolyBtn);
            this.flowLayoutPanel1.Controls.Add(this.CurveBtn);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(127, 372);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.BackgroundImage = global::WindowsApplication1.Properties.Resources.ПАНЕЛЬ;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenMnu,
            this.FillMnu});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(127, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "Pen";
            // 
            // SelectBtn
            // 
            this.SelectBtn.AutoSize = true;
            this.SelectBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.Выбор;
            this.SelectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectBtn.FlatAppearance.BorderSize = 0;
            this.SelectBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectBtn.Location = new System.Drawing.Point(3, 3);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(120, 30);
            this.SelectBtn.TabIndex = 0;
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // RectBtn
            // 
            this.RectBtn.AutoSize = true;
            this.RectBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.Прямоуг;
            this.RectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RectBtn.FlatAppearance.BorderSize = 0;
            this.RectBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RectBtn.Location = new System.Drawing.Point(3, 39);
            this.RectBtn.Name = "RectBtn";
            this.RectBtn.Size = new System.Drawing.Size(120, 30);
            this.RectBtn.TabIndex = 1;
            this.RectBtn.UseVisualStyleBackColor = true;
            this.RectBtn.Click += new System.EventHandler(this.RectBtn_Click);
            // 
            // RRectBtn
            // 
            this.RRectBtn.AutoSize = true;
            this.RRectBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.КругПрямоуг;
            this.RRectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RRectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RRectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RRectBtn.FlatAppearance.BorderSize = 0;
            this.RRectBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RRectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RRectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RRectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RRectBtn.Location = new System.Drawing.Point(3, 75);
            this.RRectBtn.Name = "RRectBtn";
            this.RRectBtn.Size = new System.Drawing.Size(120, 47);
            this.RRectBtn.TabIndex = 4;
            this.RRectBtn.UseVisualStyleBackColor = true;
            this.RRectBtn.Click += new System.EventHandler(this.RRectBtn_Click);
            // 
            // LineBtn
            // 
            this.LineBtn.AutoSize = true;
            this.LineBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.Линия;
            this.LineBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LineBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LineBtn.FlatAppearance.BorderSize = 0;
            this.LineBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LineBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LineBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineBtn.Location = new System.Drawing.Point(3, 128);
            this.LineBtn.Name = "LineBtn";
            this.LineBtn.Size = new System.Drawing.Size(120, 30);
            this.LineBtn.TabIndex = 2;
            this.LineBtn.UseVisualStyleBackColor = true;
            this.LineBtn.Click += new System.EventHandler(this.LineBtn_Click);
            // 
            // CirciBtn
            // 
            this.CirciBtn.AutoSize = true;
            this.CirciBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.Круг;
            this.CirciBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CirciBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CirciBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CirciBtn.FlatAppearance.BorderSize = 0;
            this.CirciBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CirciBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CirciBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CirciBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CirciBtn.Location = new System.Drawing.Point(3, 164);
            this.CirciBtn.Name = "CirciBtn";
            this.CirciBtn.Size = new System.Drawing.Size(120, 30);
            this.CirciBtn.TabIndex = 3;
            this.CirciBtn.UseVisualStyleBackColor = true;
            this.CirciBtn.Click += new System.EventHandler(this.CirciBtn_Click);
            // 
            // PolyBtn
            // 
            this.PolyBtn.AutoSize = true;
            this.PolyBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.МногоУ;
            this.PolyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PolyBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PolyBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PolyBtn.FlatAppearance.BorderSize = 0;
            this.PolyBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PolyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PolyBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PolyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PolyBtn.Location = new System.Drawing.Point(3, 200);
            this.PolyBtn.Name = "PolyBtn";
            this.PolyBtn.Size = new System.Drawing.Size(120, 30);
            this.PolyBtn.TabIndex = 5;
            this.PolyBtn.UseVisualStyleBackColor = true;
            this.PolyBtn.Click += new System.EventHandler(this.PolyBtn_Click);
            // 
            // CurveBtn
            // 
            this.CurveBtn.AutoSize = true;
            this.CurveBtn.BackgroundImage = global::WindowsApplication1.Properties.Resources.Карандаш;
            this.CurveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CurveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurveBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurveBtn.FlatAppearance.BorderSize = 0;
            this.CurveBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurveBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CurveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurveBtn.Location = new System.Drawing.Point(3, 236);
            this.CurveBtn.Name = "CurveBtn";
            this.CurveBtn.Size = new System.Drawing.Size(120, 30);
            this.CurveBtn.TabIndex = 6;
            this.CurveBtn.UseVisualStyleBackColor = true;
            this.CurveBtn.Click += new System.EventHandler(this.CurveBtn_Click);
            // 
            // button8
            // 
            this.button8.AutoSize = true;
            this.button8.BackgroundImage = global::WindowsApplication1.Properties.Resources.Удалит;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(3, 272);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 30);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // button9
            // 
            this.button9.AutoSize = true;
            this.button9.BackgroundImage = global::WindowsApplication1.Properties.Resources.Копи;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(3, 308);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(120, 30);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.toolStripButton4_Click);
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
            this.PenMnu.Size = new System.Drawing.Size(35, 22);
            this.PenMnu.Text = "Pen";
            // 
            // PenColor
            // 
            this.PenColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.PenColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(100, 22);
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
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "width";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem10.Text = "0,5";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem11.Text = "1";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem12.Text = "1,5";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem13.Text = "2";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem14.Text = "3";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem15.Text = "4";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem16.Text = "5";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.MaxLength = 2;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 22);
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
            this.FillMnu.Size = new System.Drawing.Size(29, 22);
            this.FillMnu.Text = "Fill";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.CheckOnClick = true;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem17.Text = "ON";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click);
            // 
            // FillColor
            // 
            this.FillColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.FillColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillColor.ForeColor = System.Drawing.Color.White;
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(101, 22);
            this.FillColor.Text = "Color";
            this.FillColor.Click += new System.EventHandler(this.FillColor_Click);
            // 
            // toolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "toolBox";
            this.Size = new System.Drawing.Size(127, 397);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button RectBtn;
        private System.Windows.Forms.Button RRectBtn;
        private System.Windows.Forms.Button LineBtn;
        private System.Windows.Forms.Button CirciBtn;
        private System.Windows.Forms.Button PolyBtn;
        private System.Windows.Forms.Button CurveBtn;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}
