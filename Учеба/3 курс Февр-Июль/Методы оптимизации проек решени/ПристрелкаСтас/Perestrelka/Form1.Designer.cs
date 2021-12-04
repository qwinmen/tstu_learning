namespace Perestrelka
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zedGraph_tx = new ZedGraph.ZedGraphControl();
            this.zedGraph_ty = new ZedGraph.ZedGraphControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zedGraph_tx);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zedGraph_ty);
            this.splitContainer1.Size = new System.Drawing.Size(623, 396);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 0;
            // 
            // zedGraph_tx
            // 
            this.zedGraph_tx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_tx.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_tx.Name = "zedGraph_tx";
            this.zedGraph_tx.ScrollGrace = 0;
            this.zedGraph_tx.ScrollMaxX = 0;
            this.zedGraph_tx.ScrollMaxY = 0;
            this.zedGraph_tx.ScrollMaxY2 = 0;
            this.zedGraph_tx.ScrollMinX = 0;
            this.zedGraph_tx.ScrollMinY = 0;
            this.zedGraph_tx.ScrollMinY2 = 0;
            this.zedGraph_tx.Size = new System.Drawing.Size(308, 396);
            this.zedGraph_tx.TabIndex = 0;
            // 
            // zedGraph_ty
            // 
            this.zedGraph_ty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_ty.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_ty.Name = "zedGraph_ty";
            this.zedGraph_ty.ScrollGrace = 0;
            this.zedGraph_ty.ScrollMaxX = 0;
            this.zedGraph_ty.ScrollMaxY = 0;
            this.zedGraph_ty.ScrollMaxY2 = 0;
            this.zedGraph_ty.ScrollMinX = 0;
            this.zedGraph_ty.ScrollMinY = 0;
            this.zedGraph_ty.ScrollMinY2 = 0;
            this.zedGraph_ty.Size = new System.Drawing.Size(311, 396);
            this.zedGraph_ty.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 396);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zedGraph_tx;
        private ZedGraph.ZedGraphControl zedGraph_ty;
    }
}

