namespace TreeControll
{
    partial class UCLogika
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonAND = new System.Windows.Forms.RadioButton();
            this.radioButtonOR = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel1.LinkColor = System.Drawing.Color.LimeGreen;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(111, 21);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Выбрать логику";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Vika.Properties.Resources.module;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(90, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonAND
            // 
            this.radioButtonAND.AutoSize = true;
            this.radioButtonAND.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonAND.Checked = true;
            this.radioButtonAND.Location = new System.Drawing.Point(6, 24);
            this.radioButtonAND.Name = "radioButtonAND";
            this.radioButtonAND.Size = new System.Drawing.Size(48, 17);
            this.radioButtonAND.TabIndex = 7;
            this.radioButtonAND.TabStop = true;
            this.radioButtonAND.Text = "AND";
            this.radioButtonAND.UseVisualStyleBackColor = true;
            this.radioButtonAND.CheckedChanged += new System.EventHandler(this.radioButtonAND_CheckedChanged);
            // 
            // radioButtonOR
            // 
            this.radioButtonOR.AutoSize = true;
            this.radioButtonOR.Location = new System.Drawing.Point(63, 24);
            this.radioButtonOR.Name = "radioButtonOR";
            this.radioButtonOR.Size = new System.Drawing.Size(41, 17);
            this.radioButtonOR.TabIndex = 7;
            this.radioButtonOR.Text = "OR";
            this.radioButtonOR.UseVisualStyleBackColor = true;
            this.radioButtonOR.CheckedChanged += new System.EventHandler(this.radioButtonOR_CheckedChanged);
            // 
            // UCLogika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButtonOR);
            this.Controls.Add(this.radioButtonAND);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Name = "UCLogika";
            this.Size = new System.Drawing.Size(111, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonAND;
        private System.Windows.Forms.RadioButton radioButtonOR;
    }
}
