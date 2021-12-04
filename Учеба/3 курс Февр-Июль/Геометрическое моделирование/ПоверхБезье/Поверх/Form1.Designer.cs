namespace Поверх
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
            this.roundButton1 = new AdvButton.RoundButton();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.roundButton2 = new AdvButton.RoundButton();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.SuspendLayout();
            // 
            // zedGraphControl_XY
            // 
            this.zedGraphControl_XY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl_XY.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XY.IsEnableHEdit = true;
            this.zedGraphControl_XY.IsEnableVEdit = true;
            this.zedGraphControl_XY.Location = new System.Drawing.Point(219, 238);
            this.zedGraphControl_XY.Name = "zedGraphControl_XY";
            this.zedGraphControl_XY.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XY.ScrollGrace = 0;
            this.zedGraphControl_XY.ScrollMaxX = 0;
            this.zedGraphControl_XY.ScrollMaxY = 0;
            this.zedGraphControl_XY.ScrollMaxY2 = 0;
            this.zedGraphControl_XY.ScrollMinX = 0;
            this.zedGraphControl_XY.ScrollMinY = 0;
            this.zedGraphControl_XY.ScrollMinY2 = 0;
            this.zedGraphControl_XY.Size = new System.Drawing.Size(581, 318);
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
            this.zedGraphControl_XZ.Location = new System.Drawing.Point(219, 0);
            this.zedGraphControl_XZ.Name = "zedGraphControl_XZ";
            this.zedGraphControl_XZ.PanModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl_XZ.ScrollGrace = 0;
            this.zedGraphControl_XZ.ScrollMaxX = 0;
            this.zedGraphControl_XZ.ScrollMaxY = 0;
            this.zedGraphControl_XZ.ScrollMaxY2 = 0;
            this.zedGraphControl_XZ.ScrollMinX = 0;
            this.zedGraphControl_XZ.ScrollMinY = 0;
            this.zedGraphControl_XZ.ScrollMinY2 = 0;
            this.zedGraphControl_XZ.Size = new System.Drawing.Size(581, 238);
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
            this.zedGraphControl_YZ.ScrollGrace = 0;
            this.zedGraphControl_YZ.ScrollMaxX = 0;
            this.zedGraphControl_YZ.ScrollMaxY = 0;
            this.zedGraphControl_YZ.ScrollMaxY2 = 0;
            this.zedGraphControl_YZ.ScrollMinX = 0;
            this.zedGraphControl_YZ.ScrollMinY = 0;
            this.zedGraphControl_YZ.ScrollMinY2 = 0;
            this.zedGraphControl_YZ.Size = new System.Drawing.Size(213, 556);
            this.zedGraphControl_YZ.TabIndex = 2;
            this.zedGraphControl_YZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl_YZ_MouseClick);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.roundButton1.ColorGradient = ((byte)(2));
            this.roundButton1.ColorStepGradient = ((byte)(2));
            this.roundButton1.FadeOut = false;
            this.roundButton1.HoverColor = System.Drawing.SystemColors.ControlDark;
            this.roundButton1.Location = new System.Drawing.Point(0, 0);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(39, 33);
            this.roundButton1.TabIndex = 3;
            this.roundButton1.Text = "Bld";
            this.roundButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roundButton1.TextStartPoint = new System.Drawing.Point(10, 10);
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.zedGraphControl_YZ;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(213, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 556);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 4;
            this.expandableSplitter1.TabStop = false;
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.expandableSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter2.ExpandableControl = this.zedGraphControl_XZ;
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
            this.expandableSplitter2.Location = new System.Drawing.Point(219, 238);
            this.expandableSplitter2.MaximumSize = new System.Drawing.Size(0, 8);
            this.expandableSplitter2.MinExtra = 5;
            this.expandableSplitter2.MinimumSize = new System.Drawing.Size(5, 5);
            this.expandableSplitter2.MinSize = 5;
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(581, 5);
            this.expandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter2.TabIndex = 5;
            this.expandableSplitter2.TabStop = false;
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.MediumOrchid;
            this.roundButton2.ColorGradient = ((byte)(2));
            this.roundButton2.ColorStepGradient = ((byte)(2));
            this.roundButton2.FadeOut = false;
            this.roundButton2.HoverColor = System.Drawing.SystemColors.ControlDark;
            this.roundButton2.Location = new System.Drawing.Point(0, 39);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(39, 33);
            this.roundButton2.TabIndex = 3;
            this.roundButton2.Text = "Old";
            this.roundButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.roundButton2.TextStartPoint = new System.Drawing.Point(10, 10);
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Bottom;
            this.checkBoxX1.Location = new System.Drawing.Point(9, 80);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(20, 17);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 6;
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.expandableSplitter2);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.zedGraphControl_XY);
            this.Controls.Add(this.zedGraphControl_XZ);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.zedGraphControl_YZ);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Поверхность Безье 16 точек";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl_XY;
        private ZedGraph.ZedGraphControl zedGraphControl_XZ;
        private ZedGraph.ZedGraphControl zedGraphControl_YZ;
        private AdvButton.RoundButton roundButton1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        private AdvButton.RoundButton roundButton2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
    }
}

