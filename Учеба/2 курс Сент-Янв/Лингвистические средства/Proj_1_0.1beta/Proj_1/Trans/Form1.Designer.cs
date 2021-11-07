namespace Trans
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.statusStrip_Down = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_Fon = new System.Windows.Forms.Panel();
            this.panel_DOWN = new System.Windows.Forms.Panel();
            this.bHelp = new System.Windows.Forms.Button();
            this.panel_UP = new System.Windows.Forms.Panel();
            this.menuStrip_Up = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip_Down.SuspendLayout();
            this.panel_Fon.SuspendLayout();
            this.panel_DOWN.SuspendLayout();
            this.panel_UP.SuspendLayout();
            this.menuStrip_Up.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.textBoxIn);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 298);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "In";
            // 
            // textBoxIn
            // 
            this.textBoxIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIn.Location = new System.Drawing.Point(3, 16);
            this.textBoxIn.MaxLength = 3276;
            this.textBoxIn.Multiline = true;
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.ShortcutsEnabled = false;
            this.textBoxIn.Size = new System.Drawing.Size(206, 279);
            this.textBoxIn.TabIndex = 0;
            this.textBoxIn.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxOut);
            this.groupBox2.Location = new System.Drawing.Point(221, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Out";
            // 
            // textBoxOut
            // 
            this.textBoxOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOut.Location = new System.Drawing.Point(3, 16);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ReadOnly = true;
            this.textBoxOut.ShortcutsEnabled = false;
            this.textBoxOut.Size = new System.Drawing.Size(206, 279);
            this.textBoxOut.TabIndex = 0;
            this.textBoxOut.Visible = false;
            // 
            // statusStrip_Down
            // 
            this.statusStrip_Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip_Down.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLPath});
            this.statusStrip_Down.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Down.Name = "statusStrip_Down";
            this.statusStrip_Down.Size = new System.Drawing.Size(436, 29);
            this.statusStrip_Down.TabIndex = 2;
            this.statusStrip_Down.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(50, 24);
            this.toolStripStatusLabel.Text = "Open: ";
            this.toolStripStatusLabel.Visible = false;
            // 
            // toolStripStatusLPath
            // 
            this.toolStripStatusLPath.Name = "toolStripStatusLPath";
            this.toolStripStatusLPath.Size = new System.Drawing.Size(0, 24);
            this.toolStripStatusLPath.Visible = false;
            // 
            // panel_Fon
            // 
            this.panel_Fon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Fon.Controls.Add(this.groupBox2);
            this.panel_Fon.Controls.Add(this.groupBox1);
            this.panel_Fon.Location = new System.Drawing.Point(0, 27);
            this.panel_Fon.Name = "panel_Fon";
            this.panel_Fon.Size = new System.Drawing.Size(436, 304);
            this.panel_Fon.TabIndex = 3;
            // 
            // panel_DOWN
            // 
            this.panel_DOWN.Controls.Add(this.bHelp);
            this.panel_DOWN.Controls.Add(this.statusStrip_Down);
            this.panel_DOWN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_DOWN.Location = new System.Drawing.Point(0, 334);
            this.panel_DOWN.Name = "panel_DOWN";
            this.panel_DOWN.Size = new System.Drawing.Size(436, 29);
            this.panel_DOWN.TabIndex = 4;
            // 
            // bHelp
            // 
            this.bHelp.BackgroundImage = global::Trans.Properties.Resources.link;
            this.bHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.bHelp.Location = new System.Drawing.Point(409, 0);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(27, 29);
            this.bHelp.TabIndex = 3;
            this.bHelp.UseVisualStyleBackColor = false;
            this.bHelp.Visible = false;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // panel_UP
            // 
            this.panel_UP.Controls.Add(this.menuStrip_Up);
            this.panel_UP.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_UP.Location = new System.Drawing.Point(0, 0);
            this.panel_UP.Name = "panel_UP";
            this.panel_UP.Size = new System.Drawing.Size(436, 24);
            this.panel_UP.TabIndex = 5;
            // 
            // menuStrip_Up
            // 
            this.menuStrip_Up.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem});
            this.menuStrip_Up.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Up.Name = "menuStrip_Up";
            this.menuStrip_Up.Size = new System.Drawing.Size(436, 24);
            this.menuStrip_Up.TabIndex = 0;
            this.menuStrip_Up.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tableToolStripMenuItem.Text = "Table";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.tableToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 363);
            this.Controls.Add(this.panel_UP);
            this.Controls.Add(this.panel_DOWN);
            this.Controls.Add(this.panel_Fon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_Up;
            this.Name = "FormMain";
            this.Text = "Лексический анализ";
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip_Down.ResumeLayout(false);
            this.statusStrip_Down.PerformLayout();
            this.panel_Fon.ResumeLayout(false);
            this.panel_DOWN.ResumeLayout(false);
            this.panel_DOWN.PerformLayout();
            this.panel_UP.ResumeLayout(false);
            this.panel_UP.PerformLayout();
            this.menuStrip_Up.ResumeLayout(false);
            this.menuStrip_Up.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip_Down;
        private System.Windows.Forms.Panel panel_Fon;
        private System.Windows.Forms.Panel panel_DOWN;
        private System.Windows.Forms.Panel panel_UP;
        private System.Windows.Forms.MenuStrip menuStrip_Up;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLPath;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Button bHelp;
    }
}

