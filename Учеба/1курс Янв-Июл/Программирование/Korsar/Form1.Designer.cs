namespace Korsar
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
            this.bAktivator = new System.Windows.Forms.Button();
            this.bUbegaet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAktivator
            // 
            this.bAktivator.Location = new System.Drawing.Point(12, 12);
            this.bAktivator.Name = "bAktivator";
            this.bAktivator.Size = new System.Drawing.Size(104, 23);
            this.bAktivator.TabIndex = 0;
            this.bAktivator.Text = "Жми, небойся";
            this.bAktivator.UseVisualStyleBackColor = true;
            this.bAktivator.Click += new System.EventHandler(this.bAktivator_Click);
            
            // 
            // bUbegaet
            // 
            this.bUbegaet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bUbegaet.Image = global::Korsar.Properties.Resources.kotSan;
            this.bUbegaet.Location = new System.Drawing.Point(116, 102);
            this.bUbegaet.Name = "bUbegaet";
            this.bUbegaet.Size = new System.Drawing.Size(110, 64);
            this.bUbegaet.TabIndex = 1;
            this.bUbegaet.UseVisualStyleBackColor = true;
            this.bUbegaet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bUbegaet_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 286);
            this.Controls.Add(this.bUbegaet);
            this.Controls.Add(this.bAktivator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "QwinCor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAktivator;
        private System.Windows.Forms.Button bUbegaet;
    }
}

