namespace Razbor
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
            DevComponents.Instrumentation.GradientFillColor gradientFillColor3 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GradientFillColor gradientFillColor4 = new DevComponents.Instrumentation.GradientFillColor();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale6 = new DevComponents.Instrumentation.GaugeLinearScale();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevComponents.Instrumentation.GaugePointer gaugePointer6 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection6 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale7 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer7 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection7 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale8 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer8 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection8 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale9 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer9 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection9 = new DevComponents.Instrumentation.GaugeSection();
            DevComponents.Instrumentation.GaugeLinearScale gaugeLinearScale10 = new DevComponents.Instrumentation.GaugeLinearScale();
            DevComponents.Instrumentation.GaugePointer gaugePointer10 = new DevComponents.Instrumentation.GaugePointer();
            DevComponents.Instrumentation.GaugeSection gaugeSection10 = new DevComponents.Instrumentation.GaugeSection();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gaugeControl1 = new DevComponents.Instrumentation.GaugeControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraph.Location = new System.Drawing.Point(0, 0);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0;
            this.zedGraph.ScrollMaxX = 0;
            this.zedGraph.ScrollMaxY = 0;
            this.zedGraph.ScrollMaxY2 = 0;
            this.zedGraph.ScrollMinX = 0;
            this.zedGraph.ScrollMinY = 0;
            this.zedGraph.ScrollMinY2 = 0;
            this.zedGraph.Size = new System.Drawing.Size(687, 303);
            this.zedGraph.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(458, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.groupBox1.Size = new System.Drawing.Size(227, 157);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дихотомия";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(0, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(234, 138);
            this.textBox1.TabIndex = 0;
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            gradientFillColor3.BorderColor = System.Drawing.Color.Silver;
            gradientFillColor3.Color1 = System.Drawing.SystemColors.WindowFrame;
            gradientFillColor3.Color2 = System.Drawing.Color.Wheat;
            gradientFillColor3.GradientFillType = DevComponents.Instrumentation.GradientFillType.StartToEnd;
            this.gaugeControl1.Frame.BackColor = gradientFillColor3;
            gradientFillColor4.BorderColor = System.Drawing.Color.Transparent;
            gradientFillColor4.BorderWidth = 1;
            gradientFillColor4.Color1 = System.Drawing.Color.Transparent;
            gradientFillColor4.Color2 = System.Drawing.Color.Transparent;
            this.gaugeControl1.Frame.FrameColor = gradientFillColor4;
            this.gaugeControl1.Frame.InnerBevel = 0F;
            this.gaugeControl1.Frame.OuterBevel = 0F;
            this.gaugeControl1.Frame.RoundRectangleArc = 0F;
            this.gaugeControl1.Frame.Style = DevComponents.Instrumentation.GaugeFrameStyle.Rectangular;
            gaugeLinearScale6.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale6.Location")));
            gaugeLinearScale6.MajorTickMarks.Layout.Length = 0.689F;
            gaugeLinearScale6.MajorTickMarks.Layout.ScaleOffset = -0.284F;
            gaugeLinearScale6.MajorTickMarks.Layout.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Rectangle;
            gaugeLinearScale6.MajorTickMarks.Layout.Width = 0.046F;
            gaugeLinearScale6.MaxPin.EndOffset = 0.013F;
            gaugeLinearScale6.MaxPin.Name = "MaxPin";
            gaugeLinearScale6.MaxPin.Visible = false;
            gaugeLinearScale6.MaxValue = 300;
            gaugeLinearScale6.MinPin.Name = "MinPin";
            gaugeLinearScale6.MinValue = 250;
            gaugeLinearScale6.Name = "Scale1";
            gaugeLinearScale6.Orientation = System.Windows.Forms.Orientation.Vertical;
            gaugePointer6.BulbSize = 0.128F;
            gaugePointer6.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer6.CapFillColor.BorderWidth = 1;
            gaugePointer6.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer6.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer6.CapInnerBevel = 0.147F;
            gaugePointer6.CapWidth = 0.279F;
            gaugePointer6.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer6.FillColor.BorderWidth = 1;
            gaugePointer6.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer6.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer6.Length = 0.058F;
            gaugePointer6.Name = "Pointer1";
            gaugePointer6.ScaleOffset = 0.003F;
            gaugePointer6.Style = DevComponents.Instrumentation.PointerStyle.Bar;
            gaugePointer6.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer6.ThermoBackColor.BorderWidth = 1;
            gaugePointer6.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer6.Value = 260;
            gaugePointer6.Width = 0.122F;
            gaugeLinearScale6.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer6});
            gaugeSection6.FillColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            gaugeSection6.FillColor.Color2 = System.Drawing.Color.Red;
            gaugeSection6.FillColor.GradientAngle = 50;
            gaugeSection6.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.StartToEnd;
            gaugeSection6.LabelColor = System.Drawing.SystemColors.Window;
            gaugeSection6.Name = "Section1";
            gaugeLinearScale6.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection6});
            gaugeLinearScale6.Size = new System.Drawing.SizeF(0.3247863F, 0.9230769F);
            gaugeLinearScale6.Width = 0.085F;
            gaugeLinearScale7.Labels.Layout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            gaugeLinearScale7.Labels.Visible = false;
            gaugeLinearScale7.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale7.Location")));
            gaugeLinearScale7.MajorTickMarks.Layout.Length = 0.195F;
            gaugeLinearScale7.MajorTickMarks.Layout.ScaleOffset = -0.044F;
            gaugeLinearScale7.MajorTickMarks.Layout.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Rectangle;
            gaugeLinearScale7.MajorTickMarks.Layout.Width = 0.046F;
            gaugeLinearScale7.MaxPin.Name = "MaxPin";
            gaugeLinearScale7.MaxPin.Visible = false;
            gaugeLinearScale7.MaxValue = 300;
            gaugeLinearScale7.MinPin.Name = "MinPin";
            gaugeLinearScale7.MinValue = 250;
            gaugeLinearScale7.Name = "Scale2";
            gaugeLinearScale7.Orientation = System.Windows.Forms.Orientation.Vertical;
            gaugePointer7.BulbSize = 0.128F;
            gaugePointer7.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer7.CapFillColor.BorderWidth = 1;
            gaugePointer7.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer7.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer7.CapInnerBevel = 0.147F;
            gaugePointer7.CapWidth = 0.279F;
            gaugePointer7.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer7.FillColor.BorderWidth = 1;
            gaugePointer7.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer7.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer7.Length = 0.058F;
            gaugePointer7.Name = "Pointer1";
            gaugePointer7.ScaleOffset = 0.003F;
            gaugePointer7.Style = DevComponents.Instrumentation.PointerStyle.Bar;
            gaugePointer7.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer7.ThermoBackColor.BorderWidth = 1;
            gaugePointer7.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer7.Value = 260;
            gaugePointer7.Width = 0.122F;
            gaugeLinearScale7.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer7});
            gaugeSection7.FillColor.Color1 = System.Drawing.Color.Red;
            gaugeSection7.FillColor.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            gaugeSection7.FillColor.GradientAngle = 50;
            gaugeSection7.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.Angle;
            gaugeSection7.Name = "Section1";
            gaugeLinearScale7.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection7});
            gaugeLinearScale7.Size = new System.Drawing.SizeF(0.3247863F, 0.9230769F);
            gaugeLinearScale7.Width = 0.085F;
            gaugeLinearScale8.Labels.Layout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            gaugeLinearScale8.Labels.Visible = false;
            gaugeLinearScale8.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale8.Location")));
            gaugeLinearScale8.MajorTickMarks.Layout.Width = 0.046F;
            gaugeLinearScale8.MaxPin.Name = "MaxPin";
            gaugeLinearScale8.MaxPin.Visible = false;
            gaugeLinearScale8.MaxValue = 300;
            gaugeLinearScale8.MinPin.Name = "MinPin";
            gaugeLinearScale8.MinValue = 250;
            gaugeLinearScale8.Name = "Scale3";
            gaugeLinearScale8.Orientation = System.Windows.Forms.Orientation.Vertical;
            gaugePointer8.BulbSize = 0.128F;
            gaugePointer8.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer8.CapFillColor.BorderWidth = 1;
            gaugePointer8.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer8.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer8.CapInnerBevel = 0.147F;
            gaugePointer8.CapWidth = 0.279F;
            gaugePointer8.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer8.FillColor.BorderWidth = 1;
            gaugePointer8.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer8.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer8.Length = 0.058F;
            gaugePointer8.Name = "Pointer1";
            gaugePointer8.ScaleOffset = 0.003F;
            gaugePointer8.Style = DevComponents.Instrumentation.PointerStyle.Bar;
            gaugePointer8.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer8.ThermoBackColor.BorderWidth = 1;
            gaugePointer8.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer8.Value = 260;
            gaugePointer8.Width = 0.122F;
            gaugeLinearScale8.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer8});
            gaugeSection8.FillColor.Color1 = System.Drawing.Color.Red;
            gaugeSection8.FillColor.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            gaugeSection8.FillColor.GradientAngle = 50;
            gaugeSection8.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.Angle;
            gaugeSection8.Name = "Section1";
            gaugeLinearScale8.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection8});
            gaugeLinearScale8.Size = new System.Drawing.SizeF(0.3247863F, 0.9230769F);
            gaugeLinearScale8.Width = 0.085F;
            gaugeLinearScale9.Labels.Layout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            gaugeLinearScale9.Labels.Visible = false;
            gaugeLinearScale9.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale9.Location")));
            gaugeLinearScale9.MajorTickMarks.Layout.Width = 0.046F;
            gaugeLinearScale9.MaxPin.Name = "MaxPin";
            gaugeLinearScale9.MaxPin.Visible = false;
            gaugeLinearScale9.MaxValue = 300;
            gaugeLinearScale9.MinPin.Name = "MinPin";
            gaugeLinearScale9.MinValue = 250;
            gaugeLinearScale9.Name = "Scale4";
            gaugeLinearScale9.Orientation = System.Windows.Forms.Orientation.Vertical;
            gaugePointer9.BulbSize = 0.128F;
            gaugePointer9.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer9.CapFillColor.BorderWidth = 1;
            gaugePointer9.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer9.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer9.CapInnerBevel = 0.147F;
            gaugePointer9.CapWidth = 0.279F;
            gaugePointer9.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer9.FillColor.BorderWidth = 1;
            gaugePointer9.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer9.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer9.Length = 0.058F;
            gaugePointer9.Name = "Pointer1";
            gaugePointer9.ScaleOffset = 0.003F;
            gaugePointer9.Style = DevComponents.Instrumentation.PointerStyle.Bar;
            gaugePointer9.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer9.ThermoBackColor.BorderWidth = 1;
            gaugePointer9.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer9.Value = 260;
            gaugePointer9.Width = 0.122F;
            gaugeLinearScale9.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer9});
            gaugeSection9.FillColor.Color1 = System.Drawing.Color.Red;
            gaugeSection9.FillColor.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            gaugeSection9.FillColor.GradientAngle = 50;
            gaugeSection9.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.Angle;
            gaugeSection9.Name = "Section1";
            gaugeLinearScale9.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection9});
            gaugeLinearScale9.Size = new System.Drawing.SizeF(0.3247863F, 0.9230769F);
            gaugeLinearScale9.Width = 0.085F;
            gaugeLinearScale10.Labels.Layout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            gaugeLinearScale10.Labels.Visible = false;
            gaugeLinearScale10.Location = ((System.Drawing.PointF)(resources.GetObject("gaugeLinearScale10.Location")));
            gaugeLinearScale10.MajorTickMarks.Layout.Length = 0.805F;
            gaugeLinearScale10.MajorTickMarks.Layout.Placement = DevComponents.Instrumentation.DisplayPlacement.Near;
            gaugeLinearScale10.MajorTickMarks.Layout.ScaleOffset = -0.123F;
            gaugeLinearScale10.MajorTickMarks.Layout.Style = DevComponents.Instrumentation.GaugeMarkerStyle.Rectangle;
            gaugeLinearScale10.MajorTickMarks.Layout.Width = 0.046F;
            gaugeLinearScale10.MaxPin.Name = "MaxPin";
            gaugeLinearScale10.MaxPin.Visible = false;
            gaugeLinearScale10.MaxValue = 300;
            gaugeLinearScale10.MinPin.Name = "MinPin";
            gaugeLinearScale10.MinValue = 250;
            gaugeLinearScale10.Name = "Scale5";
            gaugeLinearScale10.Orientation = System.Windows.Forms.Orientation.Vertical;
            gaugePointer10.BulbSize = 0.128F;
            gaugePointer10.CapFillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer10.CapFillColor.BorderWidth = 1;
            gaugePointer10.CapFillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer10.CapFillColor.Color2 = System.Drawing.Color.DimGray;
            gaugePointer10.CapInnerBevel = 0.147F;
            gaugePointer10.CapWidth = 0.279F;
            gaugePointer10.FillColor.BorderColor = System.Drawing.Color.DimGray;
            gaugePointer10.FillColor.BorderWidth = 1;
            gaugePointer10.FillColor.Color1 = System.Drawing.Color.WhiteSmoke;
            gaugePointer10.FillColor.Color2 = System.Drawing.Color.Red;
            gaugePointer10.Length = 0.058F;
            gaugePointer10.Name = "Pointer1";
            gaugePointer10.ScaleOffset = 0.003F;
            gaugePointer10.Style = DevComponents.Instrumentation.PointerStyle.Bar;
            gaugePointer10.ThermoBackColor.BorderColor = System.Drawing.Color.Black;
            gaugePointer10.ThermoBackColor.BorderWidth = 1;
            gaugePointer10.ThermoBackColor.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            gaugePointer10.Value = 260;
            gaugePointer10.Width = 0.122F;
            gaugeLinearScale10.Pointers.AddRange(new DevComponents.Instrumentation.GaugePointer[] {
            gaugePointer10});
            gaugeSection10.FillColor.Color1 = System.Drawing.Color.Red;
            gaugeSection10.FillColor.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            gaugeSection10.FillColor.GradientAngle = 50;
            gaugeSection10.FillColor.GradientFillType = DevComponents.Instrumentation.GradientFillType.Angle;
            gaugeSection10.Name = "Section1";
            gaugeLinearScale10.Sections.AddRange(new DevComponents.Instrumentation.GaugeSection[] {
            gaugeSection10});
            gaugeLinearScale10.Size = new System.Drawing.SizeF(0.3247863F, 0.9230769F);
            gaugeLinearScale10.Width = 0.085F;
            this.gaugeControl1.LinearScales.AddRange(new DevComponents.Instrumentation.GaugeLinearScale[] {
            gaugeLinearScale6,
            gaugeLinearScale7,
            gaugeLinearScale8,
            gaugeLinearScale9,
            gaugeLinearScale10});
            this.gaugeControl1.Location = new System.Drawing.Point(458, 160);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(227, 136);
            this.gaugeControl1.TabIndex = 2;
            this.gaugeControl1.Text = "gaugeControl1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(631, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "C1(tao)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartDinamiks);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(631, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "C3(tao)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Start_C1L);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 303);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(687, 195);
            this.zedGraphControl1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 498);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gaugeControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private DevComponents.Instrumentation.GaugeControl gaugeControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private ZedGraph.ZedGraphControl zedGraphControl1;

    }
}

