namespace Trans
{
    partial class FormTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTable));
            this.listViewKod_Table = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewKod_Table
            // 
            this.listViewKod_Table.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewKod_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewKod_Table.FullRowSelect = true;
            this.listViewKod_Table.GridLines = true;
            this.listViewKod_Table.Location = new System.Drawing.Point(0, 0);
            this.listViewKod_Table.Name = "listViewKod_Table";
            this.listViewKod_Table.Size = new System.Drawing.Size(284, 369);
            this.listViewKod_Table.TabIndex = 0;
            this.listViewKod_Table.UseCompatibleStateImageBehavior = false;
            this.listViewKod_Table.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Лексема";
            this.columnHeader1.Width = 144;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Код";
            this.columnHeader2.Width = 135;
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 369);
            this.Controls.Add(this.listViewKod_Table);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTable";
            this.ShowInTaskbar = false;
            this.Text = "Кодировочная таблица";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewKod_Table;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}