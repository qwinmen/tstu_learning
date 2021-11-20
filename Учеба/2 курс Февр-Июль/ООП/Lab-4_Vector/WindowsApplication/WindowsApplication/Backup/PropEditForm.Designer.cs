using System.Windows.Forms.Design;
using System.Collections;

namespace WindowsApplication1
{
    partial class PropEditForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.vectShapes1 = new WindowsApplication1.vectShapes();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(97, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "AddColorToBrush";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vectShapes1
            // 
            this.vectShapes1.A4 = false;
            this.vectShapes1.AllowDrop = true;
            this.vectShapes1.BackColor = System.Drawing.Color.White;
            this.vectShapes1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            this.vectShapes1.dx = 0;
            this.vectShapes1.dy = 0;
            this.vectShapes1.gridSize = 0;
            this.vectShapes1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.vectShapes1.Location = new System.Drawing.Point(9, 40);
            this.vectShapes1.Name = "vectShapes1";
            this.vectShapes1.Size = new System.Drawing.Size(245, 166);
            this.vectShapes1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.vectShapes1.TabIndex = 2;
            this.vectShapes1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.vectShapes1.Zoom = 1F;
            // 
            // PropEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 266);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.vectShapes1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropEditForm";
            this.ShowInTaskbar = false;
            this.Text = "PropEditForm";
            this.Load += new System.EventHandler(this.PropEditForm_Load);
            this.Closed += new System.EventHandler(this._Closed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion        
        
        //public string BarValue;
        public ArrayList BarValue;
        public System.Windows.Forms.TextBox textBox1;
        public IWindowsFormsEditorService _wfes;
        private System.Windows.Forms.Button button1;
        public vectShapes vectShapes1;
        private System.Windows.Forms.Button button2;
    }
}