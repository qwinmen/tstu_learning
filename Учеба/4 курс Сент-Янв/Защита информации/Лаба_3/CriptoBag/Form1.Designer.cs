namespace CriptoBag
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
            this.slider_CountKey = new DevComponents.DotNetBar.Controls.Slider();
            this.textBoxX_Key = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.expandablePanel_Key = new DevComponents.DotNetBar.ExpandablePanel();
            this.reflectionLabel_n = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.reflectionLabel_m = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox_InputText = new System.Windows.Forms.TextBox();
            this.groupPanel_Out = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBox_OutText = new System.Windows.Forms.TextBox();
            this.expandablePanel_Key.SuspendLayout();
            this.groupPanel_Out.SuspendLayout();
            this.SuspendLayout();
            // 
            // slider_CountKey
            // 
            this.slider_CountKey.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.slider_CountKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.slider_CountKey.FocusCuesEnabled = false;
            this.slider_CountKey.Font = new System.Drawing.Font("Segoe Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slider_CountKey.LabelWidth = 58;
            this.slider_CountKey.Location = new System.Drawing.Point(11, 42);
            this.slider_CountKey.Maximum = 13;
            this.slider_CountKey.Minimum = 6;
            this.slider_CountKey.Name = "slider_CountKey";
            this.slider_CountKey.Size = new System.Drawing.Size(232, 19);
            this.slider_CountKey.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.slider_CountKey.TabIndex = 0;
            this.slider_CountKey.Text = "Количество";
            this.slider_CountKey.Value = 6;
            this.slider_CountKey.ValueChanged += new System.EventHandler(this.slider_CountKey_ValueChanged);
            // 
            // textBoxX_Key
            // 
            // 
            // 
            // 
            this.textBoxX_Key.Border.Class = "TextBoxBorder";
            this.textBoxX_Key.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_Key.ButtonCustom.Image = global::CriptoBag.Properties.Resources.copy;
            this.textBoxX_Key.ButtonCustom.Visible = true;
            this.textBoxX_Key.Location = new System.Drawing.Point(11, 67);
            this.textBoxX_Key.Name = "textBoxX_Key";
            this.textBoxX_Key.Size = new System.Drawing.Size(232, 22);
            this.textBoxX_Key.TabIndex = 1;
            this.textBoxX_Key.WatermarkText = "Генератор ключа";
            this.textBoxX_Key.ButtonCustomClick += new System.EventHandler(this.textBoxX_Key_ButtonCustomClick);
            // 
            // expandablePanel_Key
            // 
            this.expandablePanel_Key.CanvasColor = System.Drawing.Color.Coral;
            this.expandablePanel_Key.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_Key.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel_Key.Controls.Add(this.reflectionLabel_n);
            this.expandablePanel_Key.Controls.Add(this.reflectionLabel_m);
            this.expandablePanel_Key.Controls.Add(this.textBoxX_Key);
            this.expandablePanel_Key.Controls.Add(this.slider_CountKey);
            this.expandablePanel_Key.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.expandablePanel_Key.Expanded = false;
            this.expandablePanel_Key.ExpandedBounds = new System.Drawing.Rectangle(1, 90, 254, 125);
            this.expandablePanel_Key.ExpandOnTitleClick = true;
            this.expandablePanel_Key.HideControlsWhenCollapsed = true;
            this.expandablePanel_Key.Location = new System.Drawing.Point(-10, 90);
            this.expandablePanel_Key.Name = "expandablePanel_Key";
            this.expandablePanel_Key.Size = new System.Drawing.Size(30, 125);
            this.expandablePanel_Key.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Key.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Key.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel_Key.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Key.Style.GradientAngle = 90;
            this.expandablePanel_Key.TabIndex = 2;
            this.expandablePanel_Key.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Key.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Key.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel_Key.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Key.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Key.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Key.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Key.TitleText = "Сверхвозрастающая последовательность";
            this.expandablePanel_Key.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanel_Key_ExpandedChanging);
            // 
            // reflectionLabel_n
            // 
            this.reflectionLabel_n.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.reflectionLabel_n.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel_n.Location = new System.Drawing.Point(159, 95);
            this.reflectionLabel_n.Name = "reflectionLabel_n";
            this.reflectionLabel_n.Size = new System.Drawing.Size(84, 26);
            this.reflectionLabel_n.TabIndex = 2;
            this.reflectionLabel_n.Text = "<b><font size=\"+3\"><i>n</i>=<font color=\"#B02B2C\">31</font></font></b>";
            this.toolTip1.SetToolTip(this.reflectionLabel_n, "Взаимно простое число");
            // 
            // reflectionLabel_m
            // 
            this.reflectionLabel_m.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.reflectionLabel_m.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel_m.Location = new System.Drawing.Point(11, 95);
            this.reflectionLabel_m.Name = "reflectionLabel_m";
            this.reflectionLabel_m.Size = new System.Drawing.Size(142, 26);
            this.reflectionLabel_m.TabIndex = 2;
            this.reflectionLabel_m.Text = "<b><font size=\"+3\"><i>m</i>=<font color=\"#B02B2C\">107</font></font></b>";
            this.toolTip1.SetToolTip(this.reflectionLabel_m, "Число больше суммы элементов ключа");
            // 
            // textBox_InputText
            // 
            this.textBox_InputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_InputText.Location = new System.Drawing.Point(0, 0);
            this.textBox_InputText.Multiline = true;
            this.textBox_InputText.Name = "textBox_InputText";
            this.textBox_InputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_InputText.Size = new System.Drawing.Size(434, 221);
            this.textBox_InputText.TabIndex = 3;
            this.textBox_InputText.TextChanged += new System.EventHandler(this.textBox_InputText_TextChanged);
            // 
            // groupPanel_Out
            // 
            this.groupPanel_Out.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Out.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Out.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Green;
            this.groupPanel_Out.Controls.Add(this.textBox_OutText);
            this.groupPanel_Out.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel_Out.Location = new System.Drawing.Point(0, 221);
            this.groupPanel_Out.Name = "groupPanel_Out";
            this.groupPanel_Out.Size = new System.Drawing.Size(434, 151);
            // 
            // 
            // 
            this.groupPanel_Out.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(185)))));
            this.groupPanel_Out.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(191)))), ((int)(((byte)(139)))));
            this.groupPanel_Out.Style.BackColorGradientAngle = 90;
            this.groupPanel_Out.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Out.Style.BorderBottomWidth = 1;
            this.groupPanel_Out.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(164)))), ((int)(((byte)(90)))));
            this.groupPanel_Out.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Out.Style.BorderLeftWidth = 1;
            this.groupPanel_Out.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Out.Style.BorderRightWidth = 1;
            this.groupPanel_Out.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Out.Style.BorderTopWidth = 1;
            this.groupPanel_Out.Style.CornerDiameter = 4;
            this.groupPanel_Out.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Out.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Out.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(74)))), ((int)(((byte)(31)))));
            this.groupPanel_Out.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Out.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Out.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Out.TabIndex = 4;
            this.groupPanel_Out.Text = "Результат ";
            // 
            // textBox_OutText
            // 
            this.textBox_OutText.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox_OutText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_OutText.Location = new System.Drawing.Point(0, 0);
            this.textBox_OutText.Multiline = true;
            this.textBox_OutText.Name = "textBox_OutText";
            this.textBox_OutText.ReadOnly = true;
            this.textBox_OutText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_OutText.Size = new System.Drawing.Size(428, 130);
            this.textBox_OutText.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chartreuse;
            this.ClientSize = new System.Drawing.Size(434, 372);
            this.Controls.Add(this.expandablePanel_Key);
            this.Controls.Add(this.textBox_InputText);
            this.Controls.Add(this.groupPanel_Out);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Шифрование";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.expandablePanel_Key.ResumeLayout(false);
            this.groupPanel_Out.ResumeLayout(false);
            this.groupPanel_Out.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Slider slider_CountKey;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_Key;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel_Key;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel_n;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel_m;
        private System.Windows.Forms.TextBox textBox_InputText;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_Out;
        private System.Windows.Forms.TextBox textBox_OutText;
    }
}

