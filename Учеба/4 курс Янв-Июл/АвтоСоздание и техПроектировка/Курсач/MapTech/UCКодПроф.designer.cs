namespace TestFile
{
    partial class UCКодПроф
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
            this.textBox1_InSearch = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3_Selected = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1_OKe = new System.Windows.Forms.Button();
            this.linkLabel4_File = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1_InSearch
            // 
            this.textBox1_InSearch.Location = new System.Drawing.Point(3, 23);
            this.textBox1_InSearch.Name = "textBox1_InSearch";
            this.textBox1_InSearch.Size = new System.Drawing.Size(139, 20);
            this.textBox1_InSearch.TabIndex = 0;
            this.textBox1_InSearch.TextChanged += new System.EventHandler(this.textBox1_InSearch_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(142, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Наименование профессии";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 70);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(501, 238);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Код";
            this.columnHeader1.Text = "Код";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "КЧ";
            this.columnHeader2.Text = "КЧ";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "Наименование профессии";
            this.columnHeader3.Text = "Наименование профессии";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "Код выпуска ЕТКС";
            this.columnHeader4.Text = "Код выпуска ЕТКС";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "Код по ОКЗ";
            this.columnHeader5.Text = "Код по ОКЗ";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 80;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(1, 49);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(133, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "ПРОФЕССИИ РАБОЧИХ";
            // 
            // linkLabel3_Selected
            // 
            this.linkLabel3_Selected.AutoSize = true;
            this.linkLabel3_Selected.Location = new System.Drawing.Point(149, 7);
            this.linkLabel3_Selected.Name = "linkLabel3_Selected";
            this.linkLabel3_Selected.Size = new System.Drawing.Size(55, 13);
            this.linkLabel3_Selected.TabIndex = 4;
            this.linkLabel3_Selected.TabStop = true;
            this.linkLabel3_Selected.Text = "Выбрано:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(149, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "00000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.TextChanged += new System.EventHandler(this.linkLabel4_File_TextChanged);
            // 
            // button1_OKe
            // 
            this.button1_OKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1_OKe.Location = new System.Drawing.Point(423, 7);
            this.button1_OKe.Name = "button1_OKe";
            this.button1_OKe.Size = new System.Drawing.Size(75, 23);
            this.button1_OKe.TabIndex = 6;
            this.button1_OKe.Text = "ОК";
            this.button1_OKe.UseVisualStyleBackColor = true;
            this.button1_OKe.Click += new System.EventHandler(this.button1_OKe_Click);
            // 
            // linkLabel4_File
            // 
            this.linkLabel4_File.AutoSize = true;
            this.linkLabel4_File.Location = new System.Drawing.Point(149, 49);
            this.linkLabel4_File.Name = "linkLabel4_File";
            this.linkLabel4_File.Size = new System.Drawing.Size(39, 13);
            this.linkLabel4_File.TabIndex = 7;
            this.linkLabel4_File.TabStop = true;
            this.linkLabel4_File.Text = "Файл:";
            this.linkLabel4_File.Click += new System.EventHandler(this.linkLabel4_File_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1_OKe);
            this.panel1.Controls.Add(this.linkLabel4_File);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1_InSearch);
            this.panel1.Controls.Add(this.linkLabel3_Selected);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 70);
            this.panel1.TabIndex = 8;
            // 
            // UCКодПроф
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "UCКодПроф";
            this.Size = new System.Drawing.Size(501, 308);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_InSearch;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.LinkLabel linkLabel3_Selected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1_OKe;
        private System.Windows.Forms.LinkLabel linkLabel4_File;
        private System.Windows.Forms.Panel panel1;

    }
}
