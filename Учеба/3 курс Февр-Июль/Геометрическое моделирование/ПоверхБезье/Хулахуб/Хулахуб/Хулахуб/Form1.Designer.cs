using System.Windows.Forms;

namespace Хулахуб
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
            this.zedGraphControl_XY = new ZedGraph.ZedGraphControl();
            this.zedGraphControl_XZ = new ZedGraph.ZedGraphControl();
            this.zedGraphControl_YZ = new ZedGraph.ZedGraphControl();
            this.roundButton1 = new System.Windows.Forms.Button();
            this.roundButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphControl_XY
            // 
            this.zedGraphControl_XY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl_XY.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XY.IsEnableHEdit = true;
            this.zedGraphControl_XY.IsEnableVEdit = true;
            this.zedGraphControl_XY.Location = new System.Drawing.Point(312, 238);
            this.zedGraphControl_XY.Name = "zedGraphControl_XY";
            this.zedGraphControl_XY.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XY.ScrollGrace = 0D;
            this.zedGraphControl_XY.ScrollMaxX = 0D;
            this.zedGraphControl_XY.ScrollMaxY = 0D;
            this.zedGraphControl_XY.ScrollMaxY2 = 0D;
            this.zedGraphControl_XY.ScrollMinX = 0D;
            this.zedGraphControl_XY.ScrollMinY = 0D;
            this.zedGraphControl_XY.ScrollMinY2 = 0D;
            this.zedGraphControl_XY.Size = new System.Drawing.Size(488, 318);
            this.zedGraphControl_XY.TabIndex = 0;
            this.zedGraphControl_XY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_XY_MouseClick);
            // 
            // zedGraphControl_XZ
            // 
            this.zedGraphControl_XZ.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl_XZ.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl_XZ.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XZ.IsEnableHEdit = true;
            this.zedGraphControl_XZ.IsEnableVEdit = true;
            this.zedGraphControl_XZ.Location = new System.Drawing.Point(312, 0);
            this.zedGraphControl_XZ.Name = "zedGraphControl_XZ";
            this.zedGraphControl_XZ.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XZ.ScrollGrace = 0D;
            this.zedGraphControl_XZ.ScrollMaxX = 0D;
            this.zedGraphControl_XZ.ScrollMaxY = 0D;
            this.zedGraphControl_XZ.ScrollMaxY2 = 0D;
            this.zedGraphControl_XZ.ScrollMinX = 0D;
            this.zedGraphControl_XZ.ScrollMinY = 0D;
            this.zedGraphControl_XZ.ScrollMinY2 = 0D;
            this.zedGraphControl_XZ.Size = new System.Drawing.Size(488, 238);
            this.zedGraphControl_XZ.TabIndex = 1;
            this.zedGraphControl_XZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_XZ_MouseClick);
            // 
            // zedGraphControl_YZ
            // 
            this.zedGraphControl_YZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.zedGraphControl_YZ.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl_YZ.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_YZ.IsEnableHEdit = true;
            this.zedGraphControl_YZ.IsEnableVEdit = true;
            this.zedGraphControl_YZ.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl_YZ.Name = "zedGraphControl_YZ";
            this.zedGraphControl_YZ.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_YZ.ScrollGrace = 0D;
            this.zedGraphControl_YZ.ScrollMaxX = 0D;
            this.zedGraphControl_YZ.ScrollMaxY = 0D;
            this.zedGraphControl_YZ.ScrollMaxY2 = 0D;
            this.zedGraphControl_YZ.ScrollMinX = 0D;
            this.zedGraphControl_YZ.ScrollMinY = 0D;
            this.zedGraphControl_YZ.ScrollMinY2 = 0D;
            this.zedGraphControl_YZ.Size = new System.Drawing.Size(312, 556);
            this.zedGraphControl_YZ.TabIndex = 2;
            this.zedGraphControl_YZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_YZ_MouseClick);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.roundButton1.Location = new System.Drawing.Point(0, 0);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(39, 33);
            this.roundButton1.TabIndex = 3;
            this.roundButton1.Text = "Bld";
            this.roundButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.MediumOrchid;
            this.roundButton2.Location = new System.Drawing.Point(0, 39);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(39, 33);
            this.roundButton2.TabIndex = 3;
            this.roundButton2.Text = "Old";
            this.roundButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.zedGraphControl_XY);
            this.Controls.Add(this.zedGraphControl_XZ);
            this.Controls.Add(this.zedGraphControl_YZ);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Хош назвать форму Барабулька?";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        private string _load = "Барабулька";

        #endregion

        private void Control()
        {
            this.Text = _load == this.Text ? this.Text : _load;
        }

        private ZedGraph.ZedGraphControl zedGraphControl_XY;
        private ZedGraph.ZedGraphControl zedGraphControl_XZ;
        private ZedGraph.ZedGraphControl zedGraphControl_YZ;
        private Button roundButton1;
        private Button roundButton2;
        

    }
}

