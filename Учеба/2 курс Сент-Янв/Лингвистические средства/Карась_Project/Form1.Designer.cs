namespace Карась_Project
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.listViewHashTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrTbNameFile = new System.Windows.Forms.ToolStripTextBox();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.восходящийПарсерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.хешТаблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.таблицаОтношенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.listViewHashTable);
            this.panel1.Controls.Add(this.panelMenu);
            this.panel1.Controls.Add(this.textBoxOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 265);
            this.panel1.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.Location = new System.Drawing.Point(208, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(54, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // listViewHashTable
            // 
            this.listViewHashTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewHashTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewHashTable.GridLines = true;
            this.listViewHashTable.Location = new System.Drawing.Point(271, 3);
            this.listViewHashTable.Name = "listViewHashTable";
            this.listViewHashTable.Size = new System.Drawing.Size(375, 259);
            this.listViewHashTable.TabIndex = 1;
            this.listViewHashTable.UseCompatibleStateImageBehavior = false;
            this.listViewHashTable.View = System.Windows.Forms.View.Details;
            this.listViewHashTable.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TYPE";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "HASH";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "CH";
            // 
            // textBoxIn
            // 
            this.textBoxIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIn.Location = new System.Drawing.Point(0, 0);
            this.textBoxIn.Multiline = true;
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(265, 230);
            this.textBoxIn.TabIndex = 0;
            this.textBoxIn.Visible = false;
            this.textBoxIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIn_KeyDown);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnReset);
            this.panelMenu.Controls.Add(this.menuBar);
            this.panelMenu.Location = new System.Drawing.Point(0, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(265, 28);
            this.panelMenu.TabIndex = 3;
            // 
            // menuBar
            // 
            this.menuBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuBar.AutoSize = false;
            this.menuBar.Dock = System.Windows.Forms.DockStyle.None;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStrTbNameFile,
            this.viewToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(265, 21);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 17);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrTbNameFile
            // 
            this.toolStrTbNameFile.Name = "toolStrTbNameFile";
            this.toolStrTbNameFile.Size = new System.Drawing.Size(100, 17);
            this.toolStrTbNameFile.Visible = false;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.восходящийПарсерToolStripMenuItem,
            this.таблицаОтношенийToolStripMenuItem,
            this.toolStripSeparator1,
            this.хешТаблицаToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 17);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // восходящийПарсерToolStripMenuItem
            // 
            this.восходящийПарсерToolStripMenuItem.Name = "восходящийПарсерToolStripMenuItem";
            this.восходящийПарсерToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.восходящийПарсерToolStripMenuItem.Text = "Восходящий Парсер";
            this.восходящийПарсерToolStripMenuItem.Click += new System.EventHandler(this.восходящийПарсерToolStripMenuItem_Click);
            // 
            // textBoxOut
            // 
            this.textBoxOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOut.Location = new System.Drawing.Point(271, 3);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ReadOnly = true;
            this.textBoxOut.Size = new System.Drawing.Size(375, 259);
            this.textBoxOut.TabIndex = 4;
            this.textBoxOut.Visible = false;
            // 
            // хешТаблицаToolStripMenuItem
            // 
            this.хешТаблицаToolStripMenuItem.Name = "хешТаблицаToolStripMenuItem";
            this.хешТаблицаToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.хешТаблицаToolStripMenuItem.Text = "Хеш Таблица";
            this.хешТаблицаToolStripMenuItem.Click += new System.EventHandler(this.хешТаблицаToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // таблицаОтношенийToolStripMenuItem
            // 
            this.таблицаОтношенийToolStripMenuItem.Name = "таблицаОтношенийToolStripMenuItem";
            this.таблицаОтношенийToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.таблицаОтношенийToolStripMenuItem.Text = "Таблица Отношений";
            this.таблицаОтношенийToolStripMenuItem.Click += new System.EventHandler(this.таблицаОтношенийToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.textBoxIn);
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 230);
            this.panel2.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 265);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Карась_Project";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.ListView listViewHashTable;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrTbNameFile;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem восходящийПарсерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хешТаблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаОтношенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Panel panel2;
    }
}

