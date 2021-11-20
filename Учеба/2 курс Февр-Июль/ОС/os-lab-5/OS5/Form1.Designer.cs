namespace OS5
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
            heaparessential.Controls.CBButton cbButton1 = new heaparessential.Controls.CBButton();
            heaparessential.Controls.CBButton cbButton2 = new heaparessential.Controls.CBButton();
            heaparessential.Controls.CBButton cbButton3 = new heaparessential.Controls.CBButton();
            this.buttonsPanel1 = new heaparessential.Controls.ButtonsPanel();
            this.bevel1 = new heaparessential.Controls.Bevel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.bevel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel1
            // 
            this.buttonsPanel1.AutoScroll = true;
            cbButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            cbButton1.Image = null;
            cbButton1.Title = "Критическая секция";
            cbButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            cbButton2.Image = null;
            cbButton2.Title = "Mutex";
            cbButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            cbButton3.Image = null;
            cbButton3.Title = "Event";
            this.buttonsPanel1.Buttons.AddRange(new heaparessential.Controls.CBButton[] {
            cbButton1,
            cbButton2,
            cbButton3});
            this.buttonsPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonsPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonsPanel1.Name = "buttonsPanel1";
            this.buttonsPanel1.Opened = true;
            this.buttonsPanel1.SelectedButtonIndex = -1;
            this.buttonsPanel1.ShowCaptionPanel = true;
            this.buttonsPanel1.Size = new System.Drawing.Size(284, 88);
            this.buttonsPanel1.TabIndex = 0;
            this.buttonsPanel1.Title = null;
            this.buttonsPanel1.Click += new System.EventHandler(this.buttonsPanel1_Click);
            this.buttonsPanel1.Clicked += new heaparessential.Controls.ButtonsPanel.ButtonClicked(this.buttonsPanel1_Clicked);
            // 
            // bevel1
            // 
            this.bevel1.Controls.Add(this.textBox1);
            this.bevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bevel1.Location = new System.Drawing.Point(0, 88);
            this.bevel1.Name = "bevel1";
            this.bevel1.Size = new System.Drawing.Size(284, 177);
            this.bevel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(284, 177);
            this.textBox1.TabIndex = 0;
            this.textBox1.SizeChanged += new System.EventHandler(this.textBox1_SizeChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(204, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "выкл";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(204, 44);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "выкл";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(204, 65);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(52, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "выкл";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bevel1);
            this.Controls.Add(this.buttonsPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.bevel1.ResumeLayout(false);
            this.bevel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private heaparessential.Controls.ButtonsPanel buttonsPanel1;
        private heaparessential.Controls.Bevel bevel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.TextBox textBox1;


    }
}

