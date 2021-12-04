namespace Infoboard
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
            DevComponents.Instrumentation.GradientFillColor gradientFillColor1 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor2 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugeText gaugeText1 = new DevComponents.Instrumentation.GaugeText();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevComponents.Instrumentation.NumericIndicator numericIndicator1 = new DevComponents.Instrumentation.NumericIndicator();
            DevComponents.Instrumentation.GaugeText gaugeText2 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.NumericIndicator numericIndicator2 = new DevComponents.Instrumentation.NumericIndicator();
            DevComponents.Instrumentation.GaugeText gaugeText3 = new DevComponents.Instrumentation.GaugeText();
            DevComponents.Instrumentation.NumericIndicator numericIndicator3 = new DevComponents.Instrumentation.NumericIndicator();
            this.radialMenu1 = new DevComponents.DotNetBar.RadialMenu();
            this.radMnu_Rus = new DevComponents.DotNetBar.RadialMenuItem();
            this.radMnu_En = new DevComponents.DotNetBar.RadialMenuItem();
            this.radMnu_Obj = new DevComponents.DotNetBar.RadialMenuItem();
            this.txtBx_Input = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBx_Alfavit = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gaugeControl1 = new DevComponents.Instrumentation.GaugeControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.microChartItem1 = new DevComponents.DotNetBar.MicroChartItem();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radialMenu1
            // 
            this.radialMenu1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.radMnu_Rus,
            this.radMnu_En,
            this.radMnu_Obj});
            this.radialMenu1.Location = new System.Drawing.Point(22, 4);
            this.radialMenu1.MaxItemPieAngle = 180;
            this.radialMenu1.Name = "radialMenu1";
            this.radialMenu1.Size = new System.Drawing.Size(28, 28);
            this.radialMenu1.Symbol = "";
            this.radialMenu1.TabIndex = 0;
            this.radialMenu1.Text = "radialMenu1";
            this.radialMenu1.ItemClick += new System.EventHandler(this.radialMenu1_ItemClick);
            // 
            // radMnu_Rus
            // 
            this.radMnu_Rus.Name = "radMnu_Rus";
            this.radMnu_Rus.Text = "Ru";
            // 
            // radMnu_En
            // 
            this.radMnu_En.Name = "radMnu_En";
            this.radMnu_En.Text = "En";
            // 
            // radMnu_Obj
            // 
            this.radMnu_Obj.Name = "radMnu_Obj";
            this.radMnu_Obj.Text = "Blend";
            // 
            // txtBx_Input
            // 
            // 
            // 
            // 
            this.txtBx_Input.Border.Class = "TextBoxBorder";
            this.txtBx_Input.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBx_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBx_Input.Location = new System.Drawing.Point(5, 5);
            this.txtBx_Input.Multiline = true;
            this.txtBx_Input.Name = "txtBx_Input";
            this.txtBx_Input.Size = new System.Drawing.Size(499, 53);
            this.txtBx_Input.TabIndex = 2;
            this.txtBx_Input.WatermarkText = "Input";
            this.txtBx_Input.TextChanged += new System.EventHandler(this.txtBx_Input_TextChanged);
            // 
            // txtBx_Alfavit
            // 
            // 
            // 
            // 
            this.txtBx_Alfavit.Border.Class = "TextBoxBorder";
            this.txtBx_Alfavit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBx_Alfavit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBx_Alfavit.Location = new System.Drawing.Point(5, 66);
            this.txtBx_Alfavit.Multiline = true;
            this.txtBx_Alfavit.Name = "txtBx_Alfavit";
            this.txtBx_Alfavit.Size = new System.Drawing.Size(499, 53);
            this.txtBx_Alfavit.TabIndex = 2;
            this.txtBx_Alfavit.WatermarkText = "Alfavit";
            this.txtBx_Alfavit.TextChanged += new System.EventHandler(this.txtBx_Alfavit_TextChanged);
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            gradientFillColor1.Color1 = System.Drawing.Color.Gainsboro;
            gradientFillColor1.Color2 = System.Drawing.Color.DarkGray;
            this.gaugeControl1.Frame.BackColor = gradientFillColor1;
            gradientFillColor2.BorderColor = System.Drawing.Color.Gainsboro;
            gradientFillColor2.BorderWidth = 1;
            gradientFillColor2.Color1 = System.Drawing.Color.White;
            gradientFillColor2.Color2 = System.Drawing.Color.DimGray;
            this.gaugeControl1.Frame.FrameColor = gradientFillColor2;
            this.gaugeControl1.Frame.InnerBevel = 0F;
            this.gaugeControl1.Frame.OuterBevel = 0F;
            this.gaugeControl1.Frame.RoundRectangleArc = 0F;
            gaugeText1.AutoSize = false;
            gaugeText1.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText1.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText1.Location")));
            gaugeText1.Name = "txt_i";
            gaugeText1.Size = new System.Drawing.SizeF(0.6491228F, 0.1491228F);
            gaugeText1.Text = "Информационный вес символа алфавита";
            gaugeText1.TextAlignment = DevComponents.Instrumentation.TextAlignment.MiddleLeft;
            numericIndicator1.BackColor.BorderColor = System.Drawing.Color.Gray;
            numericIndicator1.BackColor.BorderWidth = 1;
            numericIndicator1.BackColor.Color1 = System.Drawing.Color.Black;
            numericIndicator1.DecimalColor = System.Drawing.Color.Lime;
            numericIndicator1.DecimalDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(0)))));
            numericIndicator1.DigitColor = System.Drawing.Color.Red;
            numericIndicator1.DigitDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            numericIndicator1.Location = ((System.Drawing.PointF)(resources.GetObject("numericIndicator1.Location")));
            numericIndicator1.Name = "numInd_i";
            numericIndicator1.SegmentWidth = 0.489F;
            numericIndicator1.SeparatorWidth = 0.104F;
            numericIndicator1.ShowDimColonPoints = false;
            numericIndicator1.ShowDimSegments = false;
            numericIndicator1.Size = new System.Drawing.SizeF(0.991228F, 0.1491228F);
            numericIndicator1.Style = DevComponents.Instrumentation.NumericIndicatorStyle.Digital16Segment;
            numericIndicator1.Text = "0.00BIT";
            gaugeText2.AutoSize = false;
            gaugeText2.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText2.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText2.Location")));
            gaugeText2.Name = "txt_V";
            gaugeText2.Size = new System.Drawing.SizeF(0.5789474F, 0.0877193F);
            gaugeText2.Text = "Информационный объем сообщения";
            gaugeText2.TextAlignment = DevComponents.Instrumentation.TextAlignment.MiddleLeft;
            numericIndicator2.BackColor.BorderColor = System.Drawing.Color.Gray;
            numericIndicator2.BackColor.BorderWidth = 1;
            numericIndicator2.BackColor.Color1 = System.Drawing.Color.Black;
            numericIndicator2.DecimalColor = System.Drawing.Color.Lime;
            numericIndicator2.DecimalDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(0)))));
            numericIndicator2.DigitColor = System.Drawing.Color.Red;
            numericIndicator2.DigitDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            numericIndicator2.Location = ((System.Drawing.PointF)(resources.GetObject("numericIndicator2.Location")));
            numericIndicator2.Name = "numInd_V";
            numericIndicator2.NumberOfDigits = 8;
            numericIndicator2.SegmentWidth = 0.489F;
            numericIndicator2.SeparatorWidth = 0.104F;
            numericIndicator2.ShowDimColonPoints = false;
            numericIndicator2.ShowDimSegments = false;
            numericIndicator2.Size = new System.Drawing.SizeF(0.991228F, 0.1491228F);
            numericIndicator2.Style = DevComponents.Instrumentation.NumericIndicatorStyle.Digital16Segment;
            numericIndicator2.Text = "0.0000BIT";
            gaugeText3.AutoSize = false;
            gaugeText3.BackColor.BorderColor = System.Drawing.Color.Black;
            gaugeText3.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeText3.Location")));
            gaugeText3.Name = "txt_N";
            gaugeText3.Size = new System.Drawing.SizeF(0.3245614F, 0.06140351F);
            gaugeText3.Text = "Мощность алфавита";
            gaugeText3.TextAlignment = DevComponents.Instrumentation.TextAlignment.MiddleLeft;
            numericIndicator3.BackColor.BorderColor = System.Drawing.Color.Gray;
            numericIndicator3.BackColor.BorderWidth = 1;
            numericIndicator3.BackColor.Color1 = System.Drawing.Color.Black;
            numericIndicator3.DecimalColor = System.Drawing.Color.Lime;
            numericIndicator3.DecimalDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(0)))));
            numericIndicator3.DigitColor = System.Drawing.Color.Red;
            numericIndicator3.DigitDimColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            numericIndicator3.Location = ((System.Drawing.PointF)(resources.GetObject("numericIndicator3.Location")));
            numericIndicator3.Name = "numInd_N";
            numericIndicator3.SegmentWidth = 0.489F;
            numericIndicator3.SeparatorWidth = 0.104F;
            numericIndicator3.ShowDimColonPoints = false;
            numericIndicator3.ShowDimSegments = false;
            numericIndicator3.Size = new System.Drawing.SizeF(0.991228F, 0.1491228F);
            numericIndicator3.Style = DevComponents.Instrumentation.NumericIndicatorStyle.Digital16Segment;
            numericIndicator3.Text = "0.00000";
            this.gaugeControl1.GaugeItems.AddRange(new DevComponents.Instrumentation.GaugeItem[] {
            gaugeText1,
            numericIndicator1,
            gaugeText2,
            numericIndicator2,
            gaugeText3,
            numericIndicator3});
            this.gaugeControl1.Location = new System.Drawing.Point(0, 124);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(509, 228);
            this.gaugeControl1.TabIndex = 3;
            this.gaugeControl1.Text = "gaugeControl1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtBx_Input, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBx_Alfavit, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 124);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ribbonBar1.AutoOverflowEnabled = false;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.radialMenu1);
            this.ribbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1,
            this.microChartItem1});
            this.ribbonBar1.ItemSpacing = 40;
            this.ribbonBar1.Location = new System.Drawing.Point(181, 319);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(158, 49);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 5;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.radialMenu1;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // microChartItem1
            // 
            this.microChartItem1.ChartHeight = 25;
            this.microChartItem1.ChartType = DevComponents.DotNetBar.eMicroChartType.Pie;
            this.microChartItem1.Name = "microChartItem1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(509, 352);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gaugeControl1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Измерение информации";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gaugeControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RadialMenu radialMenu1;
        private DevComponents.DotNetBar.RadialMenuItem radMnu_Rus;
        private DevComponents.DotNetBar.RadialMenuItem radMnu_En;
        private DevComponents.DotNetBar.RadialMenuItem radMnu_Obj;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBx_Input;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBx_Alfavit;
        private DevComponents.Instrumentation.GaugeControl gaugeControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.MicroChartItem microChartItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;


    }
}

