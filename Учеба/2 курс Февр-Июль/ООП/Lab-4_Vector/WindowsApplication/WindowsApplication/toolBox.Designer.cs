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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SelectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RectBtn = new System.Windows.Forms.ToolStripButton();
            this.LineBtn = new System.Windows.Forms.ToolStripButton();
            this.CirciBtn = new System.Windows.Forms.ToolStripButton();
            this.RRectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PolyBtn = new System.Windows.Forms.ToolStripButton();
            this.CurveBtn = new System.Windows.Forms.ToolStripButton();
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
            this.PenMnu});
            this.toolStrip2.Location = new System.Drawing.Point(103, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(136, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "Pen";
            // 
            // PenMnu
            // 
            this.PenMnu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PenMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenColor});
            this.PenMnu.Image = ((System.Drawing.Image)(resources.GetObject("PenMnu.Image")));
            this.PenMnu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PenMnu.Name = "PenMnu";
            this.PenMnu.Size = new System.Drawing.Size(39, 22);
            this.PenMnu.Text = "Цвет";
            // 
            // PenColor
            // 
            this.PenColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.PenColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(152, 22);
            this.PenColor.Text = "color";
            this.PenColor.Click += new System.EventHandler(this.PenColor_Click);
            // 
            // SelectBtn
            // 
            this.SelectBtn.Checked = true;
            this.SelectBtn.CheckOnClick = true;
            this.SelectBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(100, 16);
            this.SelectBtn.Text = "Курсор";
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(100, 6);
            // 
            // RectBtn
            // 
            this.RectBtn.CheckOnClick = true;
            this.RectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RectBtn.Image = ((System.Drawing.Image)(resources.GetObject("RectBtn.Image")));
            this.RectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectBtn.Name = "RectBtn";
            this.RectBtn.Size = new System.Drawing.Size(100, 16);
            this.RectBtn.Text = "Прямоугольник";
            this.RectBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.RectBtn.Click += new System.EventHandler(this.RectBtn_Click);
            // 
            // LineBtn
            // 
            this.LineBtn.CheckOnClick = true;
            this.LineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LineBtn.Image = ((System.Drawing.Image)(resources.GetObject("LineBtn.Image")));
            this.LineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineBtn.Name = "LineBtn";
            this.LineBtn.Size = new System.Drawing.Size(100, 16);
            this.LineBtn.Text = "Линия";
            this.LineBtn.Click += new System.EventHandler(this.LineBtn_Click);
            // 
            // CirciBtn
            // 
            this.CirciBtn.CheckOnClick = true;
            this.CirciBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CirciBtn.Image = ((System.Drawing.Image)(resources.GetObject("CirciBtn.Image")));
            this.CirciBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CirciBtn.Name = "CirciBtn";
            this.CirciBtn.Size = new System.Drawing.Size(100, 16);
            this.CirciBtn.Text = "Круг";
            this.CirciBtn.Click += new System.EventHandler(this.CirciBtn_Click);
            // 
            // RRectBtn
            // 
            this.RRectBtn.CheckOnClick = true;
            this.RRectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RRectBtn.Image = ((System.Drawing.Image)(resources.GetObject("RRectBtn.Image")));
            this.RRectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RRectBtn.Name = "RRectBtn";
            this.RRectBtn.Size = new System.Drawing.Size(100, 16);
            this.RRectBtn.Text = "Еще прямоугольник";
            this.RRectBtn.Click += new System.EventHandler(this.RRectBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
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
            this.PolyBtn,
            this.CurveBtn,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(103, 177);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PolyBtn
            // 
            this.PolyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PolyBtn.Image = ((System.Drawing.Image)(resources.GetObject("PolyBtn.Image")));
            this.PolyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PolyBtn.Name = "PolyBtn";
            this.PolyBtn.Size = new System.Drawing.Size(100, 16);
            this.PolyBtn.Text = "Ломанная";
            this.PolyBtn.Click += new System.EventHandler(this.PolyBtn_Click);
            // 
            // CurveBtn
            // 
            this.CurveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CurveBtn.Image = ((System.Drawing.Image)(resources.GetObject("CurveBtn.Image")));
            this.CurveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CurveBtn.Name = "CurveBtn";
            this.CurveBtn.Size = new System.Drawing.Size(100, 16);
            this.CurveBtn.Text = "Карандашик";
            this.CurveBtn.ToolTipText = "Draw a free hand curved shape";
            this.CurveBtn.Click += new System.EventHandler(this.CurveBtn_Click);
            // 
            // toolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "toolBox";
            this.Size = new System.Drawing.Size(239, 177);
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
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton SelectBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton RectBtn;
        private System.Windows.Forms.ToolStripButton LineBtn;
        private System.Windows.Forms.ToolStripButton CirciBtn;
        private System.Windows.Forms.ToolStripButton RRectBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PolyBtn;
        private System.Windows.Forms.ToolStripButton CurveBtn;
    }
}
