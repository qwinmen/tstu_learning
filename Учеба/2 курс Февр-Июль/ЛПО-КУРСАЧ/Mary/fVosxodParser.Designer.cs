namespace Mary
{
    partial class fVosxodParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fVosxodParser));
            this.listViewTablVosxod = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewTablVosxod
            // 
            this.listViewTablVosxod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTablVosxod.FullRowSelect = true;
            this.listViewTablVosxod.GridLines = true;
            this.listViewTablVosxod.HideSelection = false;
            this.listViewTablVosxod.Location = new System.Drawing.Point(0, 0);
            this.listViewTablVosxod.MultiSelect = false;
            this.listViewTablVosxod.Name = "listViewTablVosxod";
            this.listViewTablVosxod.Size = new System.Drawing.Size(522, 269);
            this.listViewTablVosxod.TabIndex = 1;
            this.listViewTablVosxod.UseCompatibleStateImageBehavior = false;
            this.listViewTablVosxod.View = System.Windows.Forms.View.Details;
            // 
            // fVosxodParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 269);
            this.Controls.Add(this.listViewTablVosxod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fVosxodParser";
            this.Text = "Таблица отношений";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTablVosxod;
    }
}