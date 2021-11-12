namespace Mary
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.statusStripSost = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.IndikatorProgram = new System.Windows.Forms.ToolStripStatusLabel();
            this.IndikatorVar = new System.Windows.Forms.ToolStripStatusLabel();
            this.IndikatorBegin = new System.Windows.Forms.ToolStripStatusLabel();
            this.IndikatorEnd = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblLayoutPnlForOUT = new System.Windows.Forms.TableLayoutPanel();
            this.txtBoxFortranOUT = new System.Windows.Forms.TextBox();
            this.textBoxOUT = new System.Windows.Forms.TextBox();
            this.textBoxIN = new FastColoredTextBoxNS.FastColoredTextBox();
            this.roundButton1 = new AdvButton.RoundButton();
            this.bHelp = new System.Windows.Forms.Button();
            this.menuStrip_Up = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.восходящийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Пунктуация = new System.Windows.Forms.ToolStripMenuItem();
            this.hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripSost.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblLayoutPnlForOUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIN)).BeginInit();
            this.menuStrip_Up.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripSost
            // 
            this.statusStripSost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStripSost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLPath,
            this.IndikatorProgram,
            this.IndikatorVar,
            this.IndikatorBegin,
            this.IndikatorEnd});
            this.statusStripSost.Location = new System.Drawing.Point(0, 281);
            this.statusStripSost.Name = "statusStripSost";
            this.statusStripSost.Size = new System.Drawing.Size(555, 22);
            this.statusStripSost.TabIndex = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel.Text = "Open:";
            this.toolStripStatusLabel.Visible = false;
            // 
            // toolStripStatusLPath
            // 
            this.toolStripStatusLPath.Name = "toolStripStatusLPath";
            this.toolStripStatusLPath.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLPath.Visible = false;
            // 
            // IndikatorProgram
            // 
            this.IndikatorProgram.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.IndikatorProgram.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IndikatorProgram.Name = "IndikatorProgram";
            this.IndikatorProgram.Size = new System.Drawing.Size(15, 17);
            this.IndikatorProgram.Text = "P";
            this.IndikatorProgram.ToolTipText = "Program";
            this.IndikatorProgram.Visible = false;
            // 
            // IndikatorVar
            // 
            this.IndikatorVar.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.IndikatorVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IndikatorVar.Name = "IndikatorVar";
            this.IndikatorVar.Size = new System.Drawing.Size(15, 17);
            this.IndikatorVar.Text = "V";
            this.IndikatorVar.ToolTipText = "Var";
            this.IndikatorVar.Visible = false;
            // 
            // IndikatorBegin
            // 
            this.IndikatorBegin.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.IndikatorBegin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IndikatorBegin.Name = "IndikatorBegin";
            this.IndikatorBegin.Size = new System.Drawing.Size(15, 17);
            this.IndikatorBegin.Text = "B";
            this.IndikatorBegin.ToolTipText = "Begin";
            this.IndikatorBegin.Visible = false;
            // 
            // IndikatorEnd
            // 
            this.IndikatorEnd.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.IndikatorEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IndikatorEnd.Name = "IndikatorEnd";
            this.IndikatorEnd.Size = new System.Drawing.Size(15, 17);
            this.IndikatorEnd.Text = "E";
            this.IndikatorEnd.ToolTipText = "End";
            this.IndikatorEnd.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tblLayoutPnlForOUT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIN, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 257);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tblLayoutPnlForOUT
            // 
            this.tblLayoutPnlForOUT.ColumnCount = 1;
            this.tblLayoutPnlForOUT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.75F));
            this.tblLayoutPnlForOUT.Controls.Add(this.txtBoxFortranOUT, 0, 1);
            this.tblLayoutPnlForOUT.Controls.Add(this.textBoxOUT, 0, 0);
            this.tblLayoutPnlForOUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPnlForOUT.Location = new System.Drawing.Point(280, 3);
            this.tblLayoutPnlForOUT.Name = "tblLayoutPnlForOUT";
            this.tblLayoutPnlForOUT.RowCount = 2;
            this.tblLayoutPnlForOUT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnlForOUT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnlForOUT.Size = new System.Drawing.Size(272, 251);
            this.tblLayoutPnlForOUT.TabIndex = 1;
            // 
            // txtBoxFortranOUT
            // 
            this.txtBoxFortranOUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFortranOUT.Location = new System.Drawing.Point(3, 128);
            this.txtBoxFortranOUT.Multiline = true;
            this.txtBoxFortranOUT.Name = "txtBoxFortranOUT";
            this.txtBoxFortranOUT.ReadOnly = true;
            this.txtBoxFortranOUT.Size = new System.Drawing.Size(266, 120);
            this.txtBoxFortranOUT.TabIndex = 3;
            // 
            // textBoxOUT
            // 
            this.textBoxOUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOUT.Location = new System.Drawing.Point(3, 3);
            this.textBoxOUT.Multiline = true;
            this.textBoxOUT.Name = "textBoxOUT";
            this.textBoxOUT.Size = new System.Drawing.Size(266, 119);
            this.textBoxOUT.TabIndex = 2;
            this.textBoxOUT.Visible = false;
            // 
            // textBoxIN
            // 
            this.textBoxIN.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textBoxIN.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.textBoxIN.BackBrush = null;
            this.textBoxIN.CharHeight = 14;
            this.textBoxIN.CharWidth = 8;
            this.textBoxIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxIN.DelayedTextChangedInterval = 50;
            this.textBoxIN.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIN.IsReplaceMode = false;
            this.textBoxIN.Location = new System.Drawing.Point(3, 3);
            this.textBoxIN.Name = "textBoxIN";
            this.textBoxIN.Paddings = new System.Windows.Forms.Padding(0);
            this.textBoxIN.ReadOnly = true;
            this.textBoxIN.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBoxIN.Size = new System.Drawing.Size(271, 251);
            this.textBoxIN.SourceTextBox = this.textBoxIN;
            this.textBoxIN.TabIndex = 2;
            this.textBoxIN.WordWrap = true;
            this.textBoxIN.Zoom = 100;
            this.textBoxIN.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.textBoxIN_TextChanged);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.Red;
            this.roundButton1.ColorGradient = ((byte)(2));
            this.roundButton1.ColorStepGradient = ((byte)(2));
            this.roundButton1.FadeOut = false;
            this.roundButton1.HoverColor = System.Drawing.Color.Red;
            this.roundButton1.Location = new System.Drawing.Point(130, 0);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(25, 24);
            this.roundButton1.TabIndex = 5;
            this.roundButton1.TextStartPoint = new System.Drawing.Point(0, 0);
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // bHelp
            // 
            this.bHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bHelp.BackColor = System.Drawing.SystemColors.Control;
            this.bHelp.BackgroundImage = global::Mary.Properties.Resources.link;
            this.bHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bHelp.Location = new System.Drawing.Point(528, 281);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(27, 22);
            this.bHelp.TabIndex = 4;
            this.bHelp.UseVisualStyleBackColor = false;
            this.bHelp.Visible = false;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // menuStrip_Up
            // 
            this.menuStrip_Up.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.menuStrip_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip_Up.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.hashToolStripMenuItem});
            this.menuStrip_Up.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Up.Name = "menuStrip_Up";
            this.menuStrip_Up.Size = new System.Drawing.Size(555, 24);
            this.menuStrip_Up.TabIndex = 3;
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
            this.openToolStripMenuItem.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.openToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openToolStripMenuItem.Image = global::Mary.Properties.Resources.iOpen;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.exitToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitToolStripMenuItem.Image = global::Mary.Properties.Resources.iExit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem,
            this.parserToolStripMenuItem,
            this.toolStripSeparator1,
            this.Пунктуация});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.ToolTipText = "Работа с файла";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.tableToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableToolStripMenuItem.Enabled = false;
            this.tableToolStripMenuItem.Image = global::Mary.Properties.Resources.iTable;
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tableToolStripMenuItem.Text = "Table";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.tableToolStripMenuItem_Click);
            // 
            // parserToolStripMenuItem
            // 
            this.parserToolStripMenuItem.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.parserToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.parserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.восходящийToolStripMenuItem});
            this.parserToolStripMenuItem.Image = global::Mary.Properties.Resources.iParser;
            this.parserToolStripMenuItem.Name = "parserToolStripMenuItem";
            this.parserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.parserToolStripMenuItem.Text = "Parser";
            this.parserToolStripMenuItem.Visible = false;
            // 
            // восходящийToolStripMenuItem
            // 
            this.восходящийToolStripMenuItem.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.восходящийToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.восходящийToolStripMenuItem.Name = "восходящийToolStripMenuItem";
            this.восходящийToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.восходящийToolStripMenuItem.Text = "Восходящий";
            this.восходящийToolStripMenuItem.Click += new System.EventHandler(this.восходящийToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.Highlight;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // Пунктуация
            // 
            this.Пунктуация.BackgroundImage = global::Mary.Properties.Resources.FonPanel2;
            this.Пунктуация.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Пунктуация.Image = global::Mary.Properties.Resources.iPunctuation;
            this.Пунктуация.Name = "Пунктуация";
            this.Пунктуация.Size = new System.Drawing.Size(152, 22);
            this.Пунктуация.Text = "Punctuation";
            this.Пунктуация.Click += new System.EventHandler(this.Пунктуация_Click);
            // 
            // hashToolStripMenuItem
            // 
            this.hashToolStripMenuItem.Enabled = false;
            this.hashToolStripMenuItem.Name = "hashToolStripMenuItem";
            this.hashToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.hashToolStripMenuItem.Text = "Edit";
            this.hashToolStripMenuItem.ToolTipText = "Работа с формы";
            this.hashToolStripMenuItem.Click += new System.EventHandler(this.hashToolStripMenuItem_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 303);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.bHelp);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip_Up);
            this.Controls.Add(this.statusStripSost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "Mary";
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.statusStripSost.ResumeLayout(false);
            this.statusStripSost.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblLayoutPnlForOUT.ResumeLayout(false);
            this.tblLayoutPnlForOUT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxIN)).EndInit();
            this.menuStrip_Up.ResumeLayout(false);
            this.menuStrip_Up.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripSost;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip_Up;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem восходящийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hashToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLPath;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPnlForOUT;
        internal System.Windows.Forms.TextBox textBoxOUT;
        internal System.Windows.Forms.TextBox txtBoxFortranOUT;
        private System.Windows.Forms.Button bHelp;
        private FastColoredTextBoxNS.FastColoredTextBox textBoxIN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Пунктуация;
        private AdvButton.RoundButton roundButton1;
        private System.Windows.Forms.ToolStripStatusLabel IndikatorProgram;
        private System.Windows.Forms.ToolStripStatusLabel IndikatorEnd;
        private System.Windows.Forms.ToolStripStatusLabel IndikatorVar;
        private System.Windows.Forms.ToolStripStatusLabel IndikatorBegin;
    }
}

