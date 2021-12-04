namespace Сам
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
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.checkBoxX1 = new System.Windows.Forms.CheckBox();
            this.roundButton1 = new AdvButton.RoundButton();
            this.roundButton2 = new AdvButton.RoundButton();
            this.SuspendLayout();
            // 
            // zedGraphControl_XY
            // 
            this.zedGraphControl_XY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl_XY.Location = new System.Drawing.Point(308, 234);
            this.zedGraphControl_XY.Name = "zedGraphControl_XY";
            this.zedGraphControl_XY.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XY.ScrollGrace = 0;
            this.zedGraphControl_XY.ScrollMaxX = 0;
            this.zedGraphControl_XY.ScrollMaxY = 0;
            this.zedGraphControl_XY.ScrollMaxY2 = 0;
            this.zedGraphControl_XY.ScrollMinX = 0;
            this.zedGraphControl_XY.ScrollMinY = 0;
            this.zedGraphControl_XY.ScrollMinY2 = 0;
            this.zedGraphControl_XY.SelectModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XY.Size = new System.Drawing.Size(397, 283);
            this.zedGraphControl_XY.TabIndex = 0;
            this.zedGraphControl_XY.PointEditEvent += new ZedGraph.ZedGraphControl.PointEditHandler(this.zedGraphXY_PointEditEvent);
            this.zedGraphControl_XY.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_XY_MouseClick);
            // 
            // zedGraphControl_XZ
            // 
            this.zedGraphControl_XZ.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl_XZ.Location = new System.Drawing.Point(308, 0);
            this.zedGraphControl_XZ.Name = "zedGraphControl_XZ";
            this.zedGraphControl_XZ.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XZ.ScrollGrace = 0;
            this.zedGraphControl_XZ.ScrollMaxX = 0;
            this.zedGraphControl_XZ.ScrollMaxY = 0;
            this.zedGraphControl_XZ.ScrollMaxY2 = 0;
            this.zedGraphControl_XZ.ScrollMinX = 0;
            this.zedGraphControl_XZ.ScrollMinY = 0;
            this.zedGraphControl_XZ.ScrollMinY2 = 0;
            this.zedGraphControl_XZ.Size = new System.Drawing.Size(397, 228);
            this.zedGraphControl_XZ.TabIndex = 0;
            this.zedGraphControl_XZ.PointEditEvent += new ZedGraph.ZedGraphControl.PointEditHandler(this.zedGraphXZ_PointEditEvent);
            this.zedGraphControl_XZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_XZ_MouseClick);
            // 
            // zedGraphControl_YZ
            // 
            this.zedGraphControl_YZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.zedGraphControl_YZ.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl_YZ.Name = "zedGraphControl_YZ";
            this.zedGraphControl_YZ.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_YZ.ScrollGrace = 0;
            this.zedGraphControl_YZ.ScrollMaxX = 0;
            this.zedGraphControl_YZ.ScrollMaxY = 0;
            this.zedGraphControl_YZ.ScrollMaxY2 = 0;
            this.zedGraphControl_YZ.ScrollMinX = 0;
            this.zedGraphControl_YZ.ScrollMinY = 0;
            this.zedGraphControl_YZ.ScrollMinY2 = 0;
            this.zedGraphControl_YZ.Size = new System.Drawing.Size(302, 517);
            this.zedGraphControl_YZ.TabIndex = 0;
            this.zedGraphControl_YZ.PointEditEvent += new ZedGraph.ZedGraphControl.PointEditHandler(this.zedGraphYZ_PointEditEvent);
            this.zedGraphControl_YZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_YZ_MouseClick);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(302, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 517);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.Location = new System.Drawing.Point(308, 228);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(397, 6);
            this.expandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter2.TabIndex = 2;
            this.expandableSplitter2.TabStop = false;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.Location = new System.Drawing.Point(2, 2);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(15, 14);
            this.checkBoxX1.TabIndex = 3;
            this.checkBoxX1.UseVisualStyleBackColor = true;
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.Chocolate;
            this.roundButton1.ColorGradient = ((byte)(2));
            this.roundButton1.ColorStepGradient = ((byte)(2));
            this.roundButton1.FadeOut = false;
            this.roundButton1.HoverColor = System.Drawing.Color.IndianRed;
            this.roundButton1.Location = new System.Drawing.Point(2, 46);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(33, 29);
            this.roundButton1.TabIndex = 4;
            this.roundButton1.TextStartPoint = new System.Drawing.Point(0, 0);
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.Moccasin;
            this.roundButton2.ColorGradient = ((byte)(2));
            this.roundButton2.ColorStepGradient = ((byte)(2));
            this.roundButton2.FadeOut = false;
            this.roundButton2.HoverColor = System.Drawing.Color.OldLace;
            this.roundButton2.Location = new System.Drawing.Point(2, 81);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(33, 29);
            this.roundButton2.TabIndex = 4;
            this.roundButton2.TextStartPoint = new System.Drawing.Point(0, 0);
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 517);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.zedGraphControl_XY);
            this.Controls.Add(this.expandableSplitter2);
            this.Controls.Add(this.zedGraphControl_XZ);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.zedGraphControl_YZ);
            this.Name = "Form1";
            this.Text = "Lab 4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl_XY;
        private ZedGraph.ZedGraphControl zedGraphControl_XZ;
        private ZedGraph.ZedGraphControl zedGraphControl_YZ;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        private System.Windows.Forms.CheckBox checkBoxX1;
        private AdvButton.RoundButton roundButton1;
        private AdvButton.RoundButton roundButton2;
    }
}

