namespace FoxPro
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
            this.txtBx_Input = new System.Windows.Forms.TextBox();
            this.txtBx_Alfavit = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.microChartItem1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBx_Input
            // 
            this.txtBx_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBx_Input.Location = new System.Drawing.Point(0, 0);
            this.txtBx_Input.Multiline = true;
            this.txtBx_Input.Name = "txtBx_Input";
            this.txtBx_Input.Size = new System.Drawing.Size(650, 236);
            this.txtBx_Input.TabIndex = 0;
            this.txtBx_Input.TextChanged += new System.EventHandler(this.txtBx_Input_TextChanged);
            // 
            // txtBx_Alfavit
            // 
            this.txtBx_Alfavit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBx_Alfavit.Location = new System.Drawing.Point(0, 239);
            this.txtBx_Alfavit.Multiline = true;
            this.txtBx_Alfavit.Name = "txtBx_Alfavit";
            this.txtBx_Alfavit.Size = new System.Drawing.Size(650, 89);
            this.txtBx_Alfavit.TabIndex = 1;
            this.txtBx_Alfavit.TextChanged += new System.EventHandler(this.txtBx_Alfavit_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.microChartItem1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe Marker", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 141);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.radioButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radioButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSalmon;
            this.radioButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(286, 100);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(35, 19);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.Text = "Ex";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.Click += new System.EventHandler(this.radialMenu1_ItemClick);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.radioButton2.Checked = true;
            this.radioButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radioButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSalmon;
            this.radioButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(286, 77);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(36, 19);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Ru";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.Click += new System.EventHandler(this.radialMenu1_ItemClick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.radioButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.radioButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSalmon;
            this.radioButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(286, 54);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 19);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "En";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.Click += new System.EventHandler(this.radialMenu1_ItemClick);
            // 
            // microChartItem1
            // 
            this.microChartItem1.BackColor = System.Drawing.Color.GreenYellow;
            this.microChartItem1.ForeColor = System.Drawing.Color.Tomato;
            this.microChartItem1.Location = new System.Drawing.Point(24, 120);
            this.microChartItem1.MarqueeAnimationSpeed = 150;
            this.microChartItem1.Name = "microChartItem1";
            this.microChartItem1.Size = new System.Drawing.Size(236, 11);
            this.microChartItem1.Step = 1;
            this.microChartItem1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(24, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Мощность алфавита";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Информационный объем сообщения";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSalmon;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(269, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 112);
            this.button1.TabIndex = 3;
            this.button1.Text = "Алфавит";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Информационный вес символа";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtBx_Alfavit);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.txtBx_Input);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 328);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel2.Location = new System.Drawing.Point(268, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 166);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseUp);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Coral;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 236);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(650, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(650, 328);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FoxPro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBx_Input;
        private System.Windows.Forms.TextBox txtBx_Alfavit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar microChartItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

