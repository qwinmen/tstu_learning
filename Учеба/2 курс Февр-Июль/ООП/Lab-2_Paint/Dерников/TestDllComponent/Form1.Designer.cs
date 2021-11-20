namespace TestDllComponent
{
    partial class Former1
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
            this.form11 = new DllAplication.Form1();
            this.userControl11 = new PNGEDIT4.UserControl1();
            this.SuspendLayout();
            // 
            // form11
            // 
            this.form11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.form11.Location = new System.Drawing.Point(12, 22);
            this.form11.Name = "form11";
            this.form11.Size = new System.Drawing.Size(136, 134);
            this.form11.StateClose = false;
            this.form11.TabIndex = 0;
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(828, 435);
            this.userControl11.TabIndex = 1;
            // 
            // Former1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 435);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.form11);
            this.Name = "Former1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        internal DllAplication.Form1 form11;
        private PNGEDIT4.UserControl1 userControl11;
        





    }
}

