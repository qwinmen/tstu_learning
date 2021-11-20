namespace WindowsApplication1
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userControl11 = new WindowsApplication1.vectShapes();
            this.toolBox1 = new WindowsApplication1.toolBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControl11);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint_1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolBox1);
            this.splitContainer1.Size = new System.Drawing.Size(644, 413);
            this.splitContainer1.SplitterDistance = 402;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 37;
            // 
            // userControl11
            // 
            this.userControl11.A4 = true;
            this.userControl11.AllowDrop = true;
            this.userControl11.AutoScroll = true;
            this.userControl11.BackColor = System.Drawing.Color.White;
            this.userControl11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControl11.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.dx = 0;
            this.userControl11.dy = 0;
            this.userControl11.gridSize = 0;
            this.userControl11.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.ShowDebug = false;
            this.userControl11.Size = new System.Drawing.Size(402, 413);
            this.userControl11.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.userControl11.TabIndex = 3;
            this.userControl11.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.userControl11.Zoom = 1F;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load_1);
            // 
            // toolBox1
            // 
            this.toolBox1.AutoSize = true;
            this.toolBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBox1.Location = new System.Drawing.Point(0, 0);
            this.toolBox1.Margin = new System.Windows.Forms.Padding(4);
            this.toolBox1.Name = "toolBox1";
            this.toolBox1.Size = new System.Drawing.Size(239, 413);
            this.toolBox1.TabIndex = 1;
            this.toolBox1.Load += new System.EventHandler(this.toolBox1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(644, 413);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "векторный редактор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private vectShapes userControl11;
        private toolBox toolBox1;

    }
}

