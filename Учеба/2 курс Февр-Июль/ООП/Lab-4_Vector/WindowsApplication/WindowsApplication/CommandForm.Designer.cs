namespace WindowsApplication1
{
    partial class CommandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandForm));
            this.MainTools = new System.Windows.Forms.ToolStrip();
            this.SelectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.TboxBtn = new System.Windows.Forms.ToolStripButton();
            this.LineBtn = new System.Windows.Forms.ToolStripButton();
            this.RectBtn = new System.Windows.Forms.ToolStripButton();
            this.CircBtn = new System.Windows.Forms.ToolStripButton();
            this.RrectBtn = new System.Windows.Forms.ToolStripButton();
            this.ImgBtn = new System.Windows.Forms.ToolStripButton();
            this.PcolBtn1 = new System.Windows.Forms.ToolStripButton();
            this.FcolBtn = new System.Windows.Forms.ToolStripButton();
            this.MainTools.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTools
            // 
            this.MainTools.Dock = System.Windows.Forms.DockStyle.None;
            this.MainTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectBtn,
            this.LineBtn,
            this.RectBtn,
            this.CircBtn,
            this.TboxBtn,
            this.RrectBtn,
            this.ImgBtn,
            this.PcolBtn1,
            this.FcolBtn});
            this.MainTools.Location = new System.Drawing.Point(39, 9);
            this.MainTools.Name = "MainTools";
            this.MainTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainTools.Size = new System.Drawing.Size(329, 25);
            this.MainTools.TabIndex = 0;
            this.MainTools.Text = "MainTools";
            // 
            // SelectBtn
            // 
            this.SelectBtn.Checked = true;
            this.SelectBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectBtn.Image")));
            this.SelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(28, 22);
            this.SelectBtn.Text = "SEL";
            this.SelectBtn.MouseEnter += new System.EventHandler(this.SelectBtn_MouseEnter);
            this.SelectBtn.MouseHover += new System.EventHandler(this.SelectBtn_MouseHover);
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 76);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(21, 20);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // TboxBtn
            // 
            this.TboxBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TboxBtn.Image = ((System.Drawing.Image)(resources.GetObject("TboxBtn.Image")));
            this.TboxBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TboxBtn.Name = "TboxBtn";
            this.TboxBtn.Size = new System.Drawing.Size(42, 17);
            this.TboxBtn.Text = "TBOX";
            this.TboxBtn.Click += new System.EventHandler(this.TboxBtn_Click);
            // 
            // LineBtn
            // 
            this.LineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LineBtn.Image = ((System.Drawing.Image)(resources.GetObject("LineBtn.Image")));
            this.LineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineBtn.Name = "LineBtn";
            this.LineBtn.Size = new System.Drawing.Size(42, 17);
            this.LineBtn.Text = "LINE";
            this.LineBtn.Click += new System.EventHandler(this.LineBtn_Click);
            // 
            // RectBtn
            // 
            this.RectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RectBtn.Image = ((System.Drawing.Image)(resources.GetObject("RectBtn.Image")));
            this.RectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectBtn.Name = "RectBtn";
            this.RectBtn.Size = new System.Drawing.Size(42, 17);
            this.RectBtn.Text = "RECT";
            this.RectBtn.Click += new System.EventHandler(this.RectBtn_Click);
            // 
            // CircBtn
            // 
            this.CircBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CircBtn.Image = ((System.Drawing.Image)(resources.GetObject("CircBtn.Image")));
            this.CircBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CircBtn.Name = "CircBtn";
            this.CircBtn.Size = new System.Drawing.Size(42, 17);
            this.CircBtn.Text = "CIRC";
            this.CircBtn.Click += new System.EventHandler(this.CircBtn_Click);
            // 
            // RrectBtn
            // 
            this.RrectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RrectBtn.Image = ((System.Drawing.Image)(resources.GetObject("RrectBtn.Image")));
            this.RrectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RrectBtn.Name = "RrectBtn";
            this.RrectBtn.Size = new System.Drawing.Size(42, 17);
            this.RrectBtn.Text = "RRECT";
            this.RrectBtn.Click += new System.EventHandler(this.RrectBtn_Click);
            // 
            // ImgBtn
            // 
            this.ImgBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ImgBtn.Image = ((System.Drawing.Image)(resources.GetObject("ImgBtn.Image")));
            this.ImgBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImgBtn.Name = "ImgBtn";
            this.ImgBtn.Size = new System.Drawing.Size(42, 17);
            this.ImgBtn.Text = "IMG";
            this.ImgBtn.Click += new System.EventHandler(this.ImgBtn_Click);
            // 
            // PcolBtn1
            // 
            this.PcolBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PcolBtn1.Image = ((System.Drawing.Image)(resources.GetObject("PcolBtn1.Image")));
            this.PcolBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PcolBtn1.Name = "PcolBtn1";
            this.PcolBtn1.Size = new System.Drawing.Size(42, 17);
            this.PcolBtn1.Text = "PCOL";
            this.PcolBtn1.Click += new System.EventHandler(this.PcolBtn1_Click);
            // 
            // FcolBtn
            // 
            this.FcolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FcolBtn.Image = ((System.Drawing.Image)(resources.GetObject("FcolBtn.Image")));
            this.FcolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FcolBtn.Name = "FcolBtn";
            this.FcolBtn.Size = new System.Drawing.Size(37, 17);
            this.FcolBtn.Text = "FCOL";
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 76);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.MainTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.CommandForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommandForm_FormClosed);
            this.Activated += new System.EventHandler(this.CommandForm_Activated);
            this.Click += new System.EventHandler(this.CommandForm_Click);
            this.Load += new System.EventHandler(this.CommandForm_Load);
            this.MainTools.ResumeLayout(false);
            this.MainTools.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainTools;
        private System.Windows.Forms.ToolStripButton SelectBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton TboxBtn;
        private System.Windows.Forms.ToolStripButton LineBtn;
        private System.Windows.Forms.ToolStripButton RectBtn;
        private System.Windows.Forms.ToolStripButton CircBtn;
        private System.Windows.Forms.ToolStripButton RrectBtn;
        private System.Windows.Forms.ToolStripButton ImgBtn;
        private System.Windows.Forms.ToolStripButton PcolBtn1;
        private System.Windows.Forms.ToolStripButton FcolBtn;


    }
}