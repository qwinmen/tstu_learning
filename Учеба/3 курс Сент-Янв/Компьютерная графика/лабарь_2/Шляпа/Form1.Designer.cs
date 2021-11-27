namespace Шляпа
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
            this.OGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // OGlControl
            // 
            this.OGlControl.AccumBits = ((byte)(0));
            this.OGlControl.AutoCheckErrors = false;
            this.OGlControl.AutoFinish = false;
            this.OGlControl.AutoMakeCurrent = true;
            this.OGlControl.AutoSwapBuffers = true;
            this.OGlControl.BackColor = System.Drawing.Color.Black;
            this.OGlControl.ColorBits = ((byte)(32));
            this.OGlControl.DepthBits = ((byte)(16));
            this.OGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OGlControl.Location = new System.Drawing.Point(0, 0);
            this.OGlControl.Name = "OGlControl";
            this.OGlControl.Size = new System.Drawing.Size(462, 390);
            this.OGlControl.StencilBits = ((byte)(0));
            this.OGlControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 390);
            this.Controls.Add(this.OGlControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl OGlControl;
    }
}

