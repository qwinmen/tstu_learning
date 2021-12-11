namespace WindowsFormsApplication1
{
    partial class main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.button_chipmode = new System.Windows.Forms.Button();
            this.button_linemode = new System.Windows.Forms.Button();
            this.button_trace = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.legend = new System.Windows.Forms.Label();
            this.Scroll_interspace = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_interspace = new System.Windows.Forms.Label();
            this.workbench = new WindowsFormsApplication1.feald_interface();
            this.SuspendLayout();
            // 
            // button_chipmode
            // 
            this.button_chipmode.BackColor = System.Drawing.Color.Black;
            this.button_chipmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_chipmode.ForeColor = System.Drawing.Color.White;
            this.button_chipmode.Location = new System.Drawing.Point(6, 41);
            this.button_chipmode.Name = "button_chipmode";
            this.button_chipmode.Size = new System.Drawing.Size(95, 23);
            this.button_chipmode.TabIndex = 1;
            this.button_chipmode.Text = "элемент";
            this.button_chipmode.UseVisualStyleBackColor = false;
            this.button_chipmode.Click += new System.EventHandler(this.button_chipmode_Click);
            // 
            // button_linemode
            // 
            this.button_linemode.BackColor = System.Drawing.Color.Chocolate;
            this.button_linemode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_linemode.ForeColor = System.Drawing.Color.White;
            this.button_linemode.Location = new System.Drawing.Point(6, 70);
            this.button_linemode.Name = "button_linemode";
            this.button_linemode.Size = new System.Drawing.Size(95, 23);
            this.button_linemode.TabIndex = 2;
            this.button_linemode.Text = "путь";
            this.button_linemode.UseVisualStyleBackColor = false;
            this.button_linemode.Click += new System.EventHandler(this.button_linemode_Click);
            // 
            // button_trace
            // 
            this.button_trace.BackColor = System.Drawing.Color.DarkBlue;
            this.button_trace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trace.ForeColor = System.Drawing.Color.White;
            this.button_trace.Location = new System.Drawing.Point(6, 99);
            this.button_trace.Name = "button_trace";
            this.button_trace.Size = new System.Drawing.Size(95, 23);
            this.button_trace.TabIndex = 2;
            this.button_trace.Text = "трассировать";
            this.button_trace.UseVisualStyleBackColor = false;
            this.button_trace.Click += new System.EventHandler(this.button_trace_Click);
            // 
            // button_clean
            // 
            this.button_clean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clean.ForeColor = System.Drawing.Color.White;
            this.button_clean.Location = new System.Drawing.Point(6, 128);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(95, 23);
            this.button_clean.TabIndex = 2;
            this.button_clean.Text = "очистить";
            this.button_clean.UseVisualStyleBackColor = false;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // legend
            // 
            this.legend.AutoSize = true;
            this.legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.legend.ForeColor = System.Drawing.Color.Maroon;
            this.legend.Location = new System.Drawing.Point(118, 23);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(467, 220);
            this.legend.TabIndex = 3;
            this.legend.Text = resources.GetString("legend.Text");
            this.legend.Visible = false;
            // 
            // Scroll_interspace
            // 
            this.Scroll_interspace.LargeChange = 1;
            this.Scroll_interspace.Location = new System.Drawing.Point(6, 186);
            this.Scroll_interspace.Maximum = 7;
            this.Scroll_interspace.Name = "Scroll_interspace";
            this.Scroll_interspace.Size = new System.Drawing.Size(95, 17);
            this.Scroll_interspace.TabIndex = 4;
            this.Scroll_interspace.Value = 1;
            this.Scroll_interspace.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Scroll_interspace_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Интервал";
            // 
            // label_interspace
            // 
            this.label_interspace.AutoSize = true;
            this.label_interspace.ForeColor = System.Drawing.Color.White;
            this.label_interspace.Location = new System.Drawing.Point(65, 164);
            this.label_interspace.Name = "label_interspace";
            this.label_interspace.Size = new System.Drawing.Size(13, 13);
            this.label_interspace.TabIndex = 5;
            this.label_interspace.Text = "1";
            // 
            // workbench
            // 
            this.workbench.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.workbench.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.workbench.Location = new System.Drawing.Point(107, 12);
            this.workbench.Name = "workbench";
            this.workbench.Size = new System.Drawing.Size(531, 439);
            this.workbench.TabIndex = 0;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(650, 463);
            this.Controls.Add(this.label_interspace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Scroll_interspace);
            this.Controls.Add(this.legend);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.button_trace);
            this.Controls.Add(this.button_linemode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_chipmode);
            this.Controls.Add(this.workbench);
            this.Name = "main";
            this.Text = "---";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private feald_interface workbench;
        private System.Windows.Forms.Button button_chipmode;
        private System.Windows.Forms.Button button_linemode;
        private System.Windows.Forms.Button button_trace;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label legend;
        private System.Windows.Forms.HScrollBar Scroll_interspace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_interspace;
    }
}

