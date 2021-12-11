namespace DeCriptoBag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.stepIndicator1 = new DevComponents.DotNetBar.Controls.StepIndicator();
            this.roundButton_m = new AdvButton.RoundButton();
            this.roundButton_n = new AdvButton.RoundButton();
            this.roundButton_ClosedKey = new AdvButton.RoundButton();
            this.expandablePanel_M = new DevComponents.DotNetBar.ExpandablePanel();
            this.textBox_MInput = new System.Windows.Forms.TextBox();
            this.expandablePanel_Key = new DevComponents.DotNetBar.ExpandablePanel();
            this.textBox_KeyInput = new System.Windows.Forms.TextBox();
            this.expandablePanel_N = new DevComponents.DotNetBar.ExpandablePanel();
            this.textBox_NInput = new System.Windows.Forms.TextBox();
            this.textBox_TextInput = new System.Windows.Forms.TextBox();
            this.groupPanel_DeCript = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxX_OutText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.expandablePanel_M.SuspendLayout();
            this.expandablePanel_Key.SuspendLayout();
            this.expandablePanel_N.SuspendLayout();
            this.groupPanel_DeCript.SuspendLayout();
            this.SuspendLayout();
            // 
            // stepIndicator1
            // 
            this.stepIndicator1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stepIndicator1.CurrentStep = 2;
            this.stepIndicator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.stepIndicator1.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.stepIndicator1.Location = new System.Drawing.Point(0, 0);
            this.stepIndicator1.Name = "stepIndicator1";
            this.stepIndicator1.Orientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.stepIndicator1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.stepIndicator1.Size = new System.Drawing.Size(23, 318);
            this.stepIndicator1.StepCount = 3;
            this.stepIndicator1.TabIndex = 0;
            this.stepIndicator1.Text = "stepIndicator1";
            // 
            // roundButton_m
            // 
            this.roundButton_m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.roundButton_m.ColorGradient = ((byte)(2));
            this.roundButton_m.ColorStepGradient = ((byte)(2));
            this.roundButton_m.FadeOut = false;
            this.roundButton_m.HoverColor = System.Drawing.Color.Coral;
            this.roundButton_m.Image = global::DeCriptoBag.Properties.Resources.n;
            this.roundButton_m.Location = new System.Drawing.Point(0, 248);
            this.roundButton_m.Name = "roundButton_m";
            this.roundButton_m.Size = new System.Drawing.Size(23, 23);
            this.roundButton_m.TabIndex = 4;
            this.roundButton_m.Tag = "3";
            this.roundButton_m.TextStartPoint = new System.Drawing.Point(0, 0);
            this.roundButton_m.UseVisualStyleBackColor = false;
            this.roundButton_m.Click += new System.EventHandler(this.roundButton_ClosedKey_Click);
            // 
            // roundButton_n
            // 
            this.roundButton_n.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.roundButton_n.BackgroundImage = global::DeCriptoBag.Properties.Resources.key;
            this.roundButton_n.ColorGradient = ((byte)(2));
            this.roundButton_n.ColorStepGradient = ((byte)(2));
            this.roundButton_n.FadeOut = false;
            this.roundButton_n.HoverColor = System.Drawing.Color.Coral;
            this.roundButton_n.Image = global::DeCriptoBag.Properties.Resources.key;
            this.roundButton_n.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.roundButton_n.Location = new System.Drawing.Point(0, 148);
            this.roundButton_n.Name = "roundButton_n";
            this.roundButton_n.Size = new System.Drawing.Size(23, 23);
            this.roundButton_n.TabIndex = 3;
            this.roundButton_n.Tag = "2";
            this.roundButton_n.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roundButton_n.TextStartPoint = new System.Drawing.Point(0, 0);
            this.roundButton_n.UseVisualStyleBackColor = true;
            this.roundButton_n.Click += new System.EventHandler(this.roundButton_ClosedKey_Click);
            // 
            // roundButton_ClosedKey
            // 
            this.roundButton_ClosedKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.roundButton_ClosedKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundButton_ClosedKey.ColorGradient = ((byte)(2));
            this.roundButton_ClosedKey.ColorStepGradient = ((byte)(2));
            this.roundButton_ClosedKey.FadeOut = false;
            this.roundButton_ClosedKey.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.roundButton_ClosedKey.FlatAppearance.BorderSize = 0;
            this.roundButton_ClosedKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.roundButton_ClosedKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.roundButton_ClosedKey.HoverColor = System.Drawing.Color.Coral;
            this.roundButton_ClosedKey.Image = global::DeCriptoBag.Properties.Resources.m;
            this.roundButton_ClosedKey.Location = new System.Drawing.Point(0, 39);
            this.roundButton_ClosedKey.Name = "roundButton_ClosedKey";
            this.roundButton_ClosedKey.Size = new System.Drawing.Size(23, 23);
            this.roundButton_ClosedKey.TabIndex = 2;
            this.roundButton_ClosedKey.Tag = "1";
            this.roundButton_ClosedKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundButton_ClosedKey.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roundButton_ClosedKey.TextStartPoint = new System.Drawing.Point(0, 0);
            this.roundButton_ClosedKey.UseVisualStyleBackColor = false;
            this.roundButton_ClosedKey.Click += new System.EventHandler(this.roundButton_ClosedKey_Click);
            // 
            // expandablePanel_M
            // 
            this.expandablePanel_M.AnimationTime = 50;
            this.expandablePanel_M.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_M.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_M.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel_M.Controls.Add(this.textBox_MInput);
            this.expandablePanel_M.Expanded = false;
            this.expandablePanel_M.ExpandedBounds = new System.Drawing.Rectangle(23, 152, 116, 49);
            this.expandablePanel_M.ExpandOnTitleClick = true;
            this.expandablePanel_M.HideControlsWhenCollapsed = true;
            this.expandablePanel_M.Location = new System.Drawing.Point(0, 152);
            this.expandablePanel_M.Name = "expandablePanel_M";
            this.expandablePanel_M.Size = new System.Drawing.Size(22, 19);
            this.expandablePanel_M.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_M.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_M.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_M.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_M.Style.GradientAngle = 90;
            this.expandablePanel_M.TabIndex = 5;
            this.expandablePanel_M.TextDockConstrained = false;
            this.expandablePanel_M.TextMarkupEnabled = false;
            this.expandablePanel_M.TitleHeight = 18;
            this.expandablePanel_M.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_M.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_M.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_M.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_M.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_M.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_M.TitleStyle.GradientAngle = 90;
            this.expandablePanel_M.TitleText = "m>E(key)";
            this.expandablePanel_M.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_M_ExpandedChanging);
            // 
            // textBox_MInput
            // 
            this.textBox_MInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_MInput.Location = new System.Drawing.Point(13, 27);
            this.textBox_MInput.MaxLength = 7;
            this.textBox_MInput.Name = "textBox_MInput";
            this.textBox_MInput.Size = new System.Drawing.Size(91, 13);
            this.textBox_MInput.TabIndex = 1;
            this.textBox_MInput.TextChanged += new System.EventHandler(this.textBox_MInput_TextChanged);
            // 
            // expandablePanel_Key
            // 
            this.expandablePanel_Key.AnimationTime = 50;
            this.expandablePanel_Key.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Key.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_Key.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel_Key.Controls.Add(this.textBox_KeyInput);
            this.expandablePanel_Key.Expanded = false;
            this.expandablePanel_Key.ExpandedBounds = new System.Drawing.Rectangle(0, 42, 144, 49);
            this.expandablePanel_Key.ExpandOnTitleClick = true;
            this.expandablePanel_Key.HideControlsWhenCollapsed = true;
            this.expandablePanel_Key.Location = new System.Drawing.Point(0, 42);
            this.expandablePanel_Key.Name = "expandablePanel_Key";
            this.expandablePanel_Key.Size = new System.Drawing.Size(22, 49);
            this.expandablePanel_Key.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Key.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Key.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Key.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Key.Style.GradientAngle = 90;
            this.expandablePanel_Key.TabIndex = 6;
            this.expandablePanel_Key.TextDockConstrained = false;
            this.expandablePanel_Key.TextMarkupEnabled = false;
            this.expandablePanel_Key.TitleHeight = 18;
            this.expandablePanel_Key.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Key.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Key.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Key.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Key.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Key.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Key.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Key.TitleText = "Закрытый ключ";
            this.expandablePanel_Key.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_M_ExpandedChanging);
            // 
            // textBox_KeyInput
            // 
            this.textBox_KeyInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_KeyInput.Location = new System.Drawing.Point(3, 27);
            this.textBox_KeyInput.MaxLength = 105;
            this.textBox_KeyInput.Name = "textBox_KeyInput";
            this.textBox_KeyInput.Size = new System.Drawing.Size(138, 13);
            this.textBox_KeyInput.TabIndex = 1;
            this.textBox_KeyInput.TextChanged += new System.EventHandler(this.textBox_KeyInput_TextChanged);
            // 
            // expandablePanel_N
            // 
            this.expandablePanel_N.AnimationTime = 50;
            this.expandablePanel_N.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_N.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_N.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel_N.Controls.Add(this.textBox_NInput);
            this.expandablePanel_N.Expanded = false;
            this.expandablePanel_N.ExpandedBounds = new System.Drawing.Rectangle(29, 248, 115, 49);
            this.expandablePanel_N.ExpandOnTitleClick = true;
            this.expandablePanel_N.HideControlsWhenCollapsed = true;
            this.expandablePanel_N.Location = new System.Drawing.Point(1, 252);
            this.expandablePanel_N.Name = "expandablePanel_N";
            this.expandablePanel_N.Size = new System.Drawing.Size(22, 19);
            this.expandablePanel_N.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_N.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_N.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_N.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_N.Style.GradientAngle = 90;
            this.expandablePanel_N.TabIndex = 7;
            this.expandablePanel_N.TextDockConstrained = false;
            this.expandablePanel_N.TextMarkupEnabled = false;
            this.expandablePanel_N.TitleHeight = 18;
            this.expandablePanel_N.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_N.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_N.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_N.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_N.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_N.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_N.TitleStyle.GradientAngle = 90;
            this.expandablePanel_N.TitleText = "Взаимно простое";
            this.expandablePanel_N.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_M_ExpandedChanging);
            // 
            // textBox_NInput
            // 
            this.textBox_NInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_NInput.Location = new System.Drawing.Point(9, 27);
            this.textBox_NInput.MaxLength = 3;
            this.textBox_NInput.Name = "textBox_NInput";
            this.textBox_NInput.Size = new System.Drawing.Size(96, 13);
            this.textBox_NInput.TabIndex = 1;
            this.textBox_NInput.TextChanged += new System.EventHandler(this.textBox_NInput_TextChanged);
            // 
            // textBox_TextInput
            // 
            this.textBox_TextInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_TextInput.Location = new System.Drawing.Point(23, 0);
            this.textBox_TextInput.Multiline = true;
            this.textBox_TextInput.Name = "textBox_TextInput";
            this.textBox_TextInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_TextInput.Size = new System.Drawing.Size(397, 142);
            this.textBox_TextInput.TabIndex = 8;
            this.textBox_TextInput.TextChanged += new System.EventHandler(this.textBox_TextInput_TextChanged);
            this.textBox_TextInput.Click += new System.EventHandler(this.textBox_TextInput_Click);
            // 
            // groupPanel_DeCript
            // 
            this.groupPanel_DeCript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupPanel_DeCript.CanvasColor = System.Drawing.Color.Coral;
            this.groupPanel_DeCript.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_DeCript.Controls.Add(this.textBoxX_OutText);
            this.groupPanel_DeCript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_DeCript.Location = new System.Drawing.Point(23, 142);
            this.groupPanel_DeCript.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.groupPanel_DeCript.Name = "groupPanel_DeCript";
            this.groupPanel_DeCript.Size = new System.Drawing.Size(397, 176);
            // 
            // 
            // 
            this.groupPanel_DeCript.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_DeCript.Style.BackColorGradientAngle = 90;
            this.groupPanel_DeCript.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_DeCript.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DeCript.Style.BorderBottomWidth = 1;
            this.groupPanel_DeCript.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_DeCript.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DeCript.Style.BorderLeftWidth = 1;
            this.groupPanel_DeCript.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DeCript.Style.BorderRightWidth = 1;
            this.groupPanel_DeCript.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_DeCript.Style.BorderTopWidth = 1;
            this.groupPanel_DeCript.Style.CornerDiameter = 4;
            this.groupPanel_DeCript.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_DeCript.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_DeCript.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_DeCript.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_DeCript.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_DeCript.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_DeCript.TabIndex = 9;
            this.groupPanel_DeCript.Text = "Результат";
            // 
            // textBoxX_OutText
            // 
            this.textBoxX_OutText.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // 
            // 
            this.textBoxX_OutText.Border.Class = "TextBoxBorder";
            this.textBoxX_OutText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_OutText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxX_OutText.Location = new System.Drawing.Point(0, 0);
            this.textBoxX_OutText.Multiline = true;
            this.textBoxX_OutText.Name = "textBoxX_OutText";
            this.textBoxX_OutText.ReadOnly = true;
            this.textBoxX_OutText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX_OutText.Size = new System.Drawing.Size(391, 155);
            this.textBoxX_OutText.TabIndex = 0;
            this.textBoxX_OutText.WatermarkColor = System.Drawing.Color.GreenYellow;
            this.textBoxX_OutText.WatermarkText = "Out";
            this.textBoxX_OutText.Click += new System.EventHandler(this.textBox_TextInput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 318);
            this.Controls.Add(this.roundButton_n);
            this.Controls.Add(this.roundButton_m);
            this.Controls.Add(this.roundButton_ClosedKey);
            this.Controls.Add(this.groupPanel_DeCript);
            this.Controls.Add(this.textBox_TextInput);
            this.Controls.Add(this.stepIndicator1);
            this.Controls.Add(this.expandablePanel_Key);
            this.Controls.Add(this.expandablePanel_M);
            this.Controls.Add(this.expandablePanel_N);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ДеШифрование";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.expandablePanel_M.ResumeLayout(false);
            this.expandablePanel_M.PerformLayout();
            this.expandablePanel_Key.ResumeLayout(false);
            this.expandablePanel_Key.PerformLayout();
            this.expandablePanel_N.ResumeLayout(false);
            this.expandablePanel_N.PerformLayout();
            this.groupPanel_DeCript.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.StepIndicator stepIndicator1;
        private AdvButton.RoundButton roundButton_ClosedKey;
        private AdvButton.RoundButton roundButton_n;
        private AdvButton.RoundButton roundButton_m;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel_M;
        private System.Windows.Forms.TextBox textBox_MInput;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel_Key;
        private System.Windows.Forms.TextBox textBox_KeyInput;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel_N;
        private System.Windows.Forms.TextBox textBox_NInput;
        private System.Windows.Forms.TextBox textBox_TextInput;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_DeCript;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_OutText;
    }
}

