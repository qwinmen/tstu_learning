﻿namespace Механики
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
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.activePanelMenu = new heaparessential.Controls.ActivePanel();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.DarkCyan;
            this.simpleOpenGlControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(490, 351);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            // 
            // activePanelMenu
            // 
            this.activePanelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.activePanelMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.activePanelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activePanelMenu.BottomHighlightColor = System.Drawing.Color.YellowGreen;
            this.activePanelMenu.BottomTitleOffset = new System.Drawing.Point(8, 8);
            this.activePanelMenu.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.activePanelMenu.HoverColor = System.Drawing.Color.AntiqueWhite;
            this.activePanelMenu.Location = new System.Drawing.Point(261, 259);
            this.activePanelMenu.Name = "activePanelMenu";
            this.activePanelMenu.PassiveColor = System.Drawing.Color.LightBlue;
            this.activePanelMenu.Size = new System.Drawing.Size(217, 80);
            this.activePanelMenu.TabIndex = 1;
            this.activePanelMenu.TopHighlightColor = System.Drawing.SystemColors.ActiveBorder;
            this.activePanelMenu.TopTitleOffset = new System.Drawing.Point(8, 8);
            this.activePanelMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseMove);
            this.activePanelMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseDown);
            this.activePanelMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 351);
            this.Controls.Add(this.activePanelMenu);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RePack от R.G. Механики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private heaparessential.Controls.ActivePanel activePanelMenu;
    }
}

