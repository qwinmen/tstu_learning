namespace Lab_2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraph2 = new ZedGraph.ZedGraphControl();
            this.zedGraph3 = new ZedGraph.ZedGraphControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.zedGraph4 = new ZedGraph.ZedGraphControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph.Location = new System.Drawing.Point(0, 0);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0;
            this.zedGraph.ScrollMaxX = 0;
            this.zedGraph.ScrollMaxY = 0;
            this.zedGraph.ScrollMaxY2 = 0;
            this.zedGraph.ScrollMinX = 0;
            this.zedGraph.ScrollMinY = 0;
            this.zedGraph.ScrollMinY2 = 0;
            this.zedGraph.Size = new System.Drawing.Size(393, 295);
            this.zedGraph.TabIndex = 0;
            // 
            // zedGraph2
            // 
            this.zedGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph2.Location = new System.Drawing.Point(0, 0);
            this.zedGraph2.Name = "zedGraph2";
            this.zedGraph2.ScrollGrace = 0;
            this.zedGraph2.ScrollMaxX = 0;
            this.zedGraph2.ScrollMaxY = 0;
            this.zedGraph2.ScrollMaxY2 = 0;
            this.zedGraph2.ScrollMinX = 0;
            this.zedGraph2.ScrollMinY = 0;
            this.zedGraph2.ScrollMinY2 = 0;
            this.zedGraph2.Size = new System.Drawing.Size(389, 295);
            this.zedGraph2.TabIndex = 1;
            // 
            // zedGraph3
            // 
            this.zedGraph3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph3.Location = new System.Drawing.Point(0, 0);
            this.zedGraph3.Name = "zedGraph3";
            this.zedGraph3.ScrollGrace = 0;
            this.zedGraph3.ScrollMaxX = 0;
            this.zedGraph3.ScrollMaxY = 0;
            this.zedGraph3.ScrollMaxY2 = 0;
            this.zedGraph3.ScrollMinX = 0;
            this.zedGraph3.ScrollMinY = 0;
            this.zedGraph3.ScrollMinY2 = 0;
            this.zedGraph3.Size = new System.Drawing.Size(394, 257);
            this.zedGraph3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zedGraph);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zedGraph2);
            this.splitContainer1.Size = new System.Drawing.Size(786, 295);
            this.splitContainer1.SplitterDistance = 393;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 295);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.zedGraph3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.zedGraph4);
            this.splitContainer2.Size = new System.Drawing.Size(786, 257);
            this.splitContainer2.SplitterDistance = 394;
            this.splitContainer2.TabIndex = 4;
            // 
            // zedGraph4
            // 
            this.zedGraph4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph4.Location = new System.Drawing.Point(0, 0);
            this.zedGraph4.Name = "zedGraph4";
            this.zedGraph4.ScrollGrace = 0;
            this.zedGraph4.ScrollMaxX = 0;
            this.zedGraph4.ScrollMaxY = 0;
            this.zedGraph4.ScrollMaxY2 = 0;
            this.zedGraph4.ScrollMinX = 0;
            this.zedGraph4.ScrollMinY = 0;
            this.zedGraph4.ScrollMinY2 = 0;
            this.zedGraph4.Size = new System.Drawing.Size(388, 257);
            this.zedGraph4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 552);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Lab2";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private ZedGraph.ZedGraphControl zedGraph2;
        private ZedGraph.ZedGraphControl zedGraph3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ZedGraph.ZedGraphControl zedGraph4;
    }
}

