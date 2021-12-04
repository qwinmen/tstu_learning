namespace PKordano
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
            this.textBox_InputTXT = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.textBox_Решето = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_Menu = new System.Windows.Forms.GroupBox();
            this.btn_Rnd = new System.Windows.Forms.Button();
            this.textBox_OutText = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox_Menu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_InputTXT
            // 
            this.textBox_InputTXT.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_InputTXT.Location = new System.Drawing.Point(0, 0);
            this.textBox_InputTXT.Multiline = true;
            this.textBox_InputTXT.Name = "textBox_InputTXT";
            this.textBox_InputTXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_InputTXT.Size = new System.Drawing.Size(715, 71);
            this.textBox_InputTXT.TabIndex = 0;
            this.textBox_InputTXT.Text = "барабулька";
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(6, 17);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(70, 22);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // textBox_Решето
            // 
            this.textBox_Решето.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Решето.Location = new System.Drawing.Point(0, 0);
            this.textBox_Решето.Multiline = true;
            this.textBox_Решето.Name = "textBox_Решето";
            this.textBox_Решето.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Решето.Size = new System.Drawing.Size(360, 291);
            this.textBox_Решето.TabIndex = 2;
            this.textBox_Решето.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.textBox_Решето.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel1.Text = "QwinCor@2015";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.DarkGreen;
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel2.Text = "Random";
            // 
            // groupBox_Menu
            // 
            this.groupBox_Menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox_Menu.Controls.Add(this.btn_Rnd);
            this.groupBox_Menu.Controls.Add(this.btn_Ok);
            this.groupBox_Menu.Controls.Add(this.label1);
            this.groupBox_Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox_Menu.Location = new System.Drawing.Point(0, 71);
            this.groupBox_Menu.Name = "groupBox_Menu";
            this.groupBox_Menu.Size = new System.Drawing.Size(715, 46);
            this.groupBox_Menu.TabIndex = 4;
            this.groupBox_Menu.TabStop = false;
            this.groupBox_Menu.Text = "Menu";
            // 
            // btn_Rnd
            // 
            this.btn_Rnd.Location = new System.Drawing.Point(82, 17);
            this.btn_Rnd.Name = "btn_Rnd";
            this.btn_Rnd.Size = new System.Drawing.Size(70, 22);
            this.btn_Rnd.TabIndex = 2;
            this.btn_Rnd.Text = "Random";
            this.btn_Rnd.UseVisualStyleBackColor = true;
            this.btn_Rnd.Click += new System.EventHandler(this.btn_Rnd_Click);
            // 
            // textBox_OutText
            // 
            this.textBox_OutText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_OutText.Location = new System.Drawing.Point(0, 0);
            this.textBox_OutText.Multiline = true;
            this.textBox_OutText.Name = "textBox_OutText";
            this.textBox_OutText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_OutText.Size = new System.Drawing.Size(351, 291);
            this.textBox_OutText.TabIndex = 5;
            this.textBox_OutText.WordWrap = false;
            this.textBox_OutText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.textBox_OutText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 117);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Решето);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_OutText);
            this.splitContainer1.Size = new System.Drawing.Size(715, 291);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(0, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(715, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "                                                     Асимптотическая сложность: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 430);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox_Menu);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox_InputTXT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Решётка Кордано";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_Menu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_InputTXT;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox textBox_Решето;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox_Menu;
        private System.Windows.Forms.Button btn_Rnd;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TextBox textBox_OutText;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
    }
}

