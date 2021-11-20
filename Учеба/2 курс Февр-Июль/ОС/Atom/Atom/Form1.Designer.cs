namespace Atom
{
    partial class fMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.pnlForm = new System.Windows.Forms.Panel();
            this.txtBoxForWrite = new System.Windows.Forms.TextBox();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.txtBoxForWrite);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(369, 170);
            this.pnlForm.TabIndex = 0;
            // 
            // txtBoxForWrite
            // 
            this.txtBoxForWrite.CausesValidation = false;
            this.txtBoxForWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxForWrite.Location = new System.Drawing.Point(0, 0);
            this.txtBoxForWrite.Multiline = true;
            this.txtBoxForWrite.Name = "txtBoxForWrite";
            this.txtBoxForWrite.ReadOnly = true;
            this.txtBoxForWrite.Size = new System.Drawing.Size(369, 170);
            this.txtBoxForWrite.TabIndex = 0;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 170);
            this.Controls.Add(this.pnlForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "Atom";
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TextBox txtBoxForWrite;
    }
}

