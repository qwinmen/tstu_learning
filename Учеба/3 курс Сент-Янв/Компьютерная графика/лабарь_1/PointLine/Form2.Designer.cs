using System.Drawing;

namespace PointLine
{
    partial class Form2
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
            this.groupBoxБрезенхем = new System.Windows.Forms.GroupBox();
            this.numUpDownY_1 = new System.Windows.Forms.NumericUpDown();
            this.numUpDownX_1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownY_0 = new System.Windows.Forms.NumericUpDown();
            this.numUpDownX_0 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxВклМышку = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxБрезенхем.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownX_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownY_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownX_0)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxБрезенхем
            // 
            this.groupBoxБрезенхем.Controls.Add(this.label3);
            this.groupBoxБрезенхем.Controls.Add(this.label2);
            this.groupBoxБрезенхем.Controls.Add(this.numUpDownY_1);
            this.groupBoxБрезенхем.Controls.Add(this.numUpDownX_1);
            this.groupBoxБрезенхем.Controls.Add(this.label1);
            this.groupBoxБрезенхем.Controls.Add(this.numUpDownY_0);
            this.groupBoxБрезенхем.Controls.Add(this.numUpDownX_0);
            this.groupBoxБрезенхем.Controls.Add(this.checkBoxВклМышку);
            this.groupBoxБрезенхем.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxБрезенхем.Location = new System.Drawing.Point(3, 3);
            this.groupBoxБрезенхем.Name = "groupBoxБрезенхем";
            this.groupBoxБрезенхем.Size = new System.Drawing.Size(278, 156);
            this.groupBoxБрезенхем.TabIndex = 0;
            this.groupBoxБрезенхем.TabStop = false;
            this.groupBoxБрезенхем.Text = "Алгоритм Брезенхема";
            // 
            // numUpDownY_1
            // 
            this.numUpDownY_1.Location = new System.Drawing.Point(130, 77);
            this.numUpDownY_1.Maximum = new decimal(new int[] {
            683,
            0,
            0,
            0});
            this.numUpDownY_1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownY_1.Name = "numUpDownY_1";
            this.numUpDownY_1.Size = new System.Drawing.Size(68, 20);
            this.numUpDownY_1.TabIndex = 5;
            this.numUpDownY_1.Value = new decimal(new int[] {
            307,
            0,
            0,
            0});
            this.numUpDownY_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numUpDownX_0_KeyPress);
            // 
            // numUpDownX_1
            // 
            this.numUpDownX_1.Location = new System.Drawing.Point(18, 77);
            this.numUpDownX_1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownX_1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownX_1.Name = "numUpDownX_1";
            this.numUpDownX_1.Size = new System.Drawing.Size(74, 20);
            this.numUpDownX_1.TabIndex = 4;
            this.numUpDownX_1.Value = new decimal(new int[] {
            247,
            0,
            0,
            0});
            this.numUpDownX_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numUpDownX_0_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Начальная и конечная точки:";
            // 
            // numUpDownY_0
            // 
            this.numUpDownY_0.Location = new System.Drawing.Point(130, 39);
            this.numUpDownY_0.Name = "numUpDownY_0";
            this.numUpDownY_0.Size = new System.Drawing.Size(68, 20);
            this.numUpDownY_0.TabIndex = 2;
            this.numUpDownY_0.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownY_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numUpDownX_0_KeyPress);
            // 
            // numUpDownX_0
            // 
            this.numUpDownX_0.Location = new System.Drawing.Point(18, 39);
            this.numUpDownX_0.Name = "numUpDownX_0";
            this.numUpDownX_0.Size = new System.Drawing.Size(74, 20);
            this.numUpDownX_0.TabIndex = 1;
            this.numUpDownX_0.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownX_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numUpDownX_0_KeyPress);
            // 
            // checkBoxВклМышку
            // 
            this.checkBoxВклМышку.AutoSize = true;
            this.checkBoxВклМышку.Location = new System.Drawing.Point(18, 118);
            this.checkBoxВклМышку.Name = "checkBoxВклМышку";
            this.checkBoxВклМышку.Size = new System.Drawing.Size(141, 17);
            this.checkBoxВклМышку.TabIndex = 0;
            this.checkBoxВклМышку.Text = "Задействовать курсор";
            this.checkBoxВклМышку.UseVisualStyleBackColor = true;
            this.checkBoxВклМышку.CheckedChanged += new System.EventHandler(this.checkBoxВклМышку_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxБрезенхем, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.50943F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.49057F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 265);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(98, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "x;y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(98, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "x;y";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(600, 410);
            this.TopMost = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Настройки";
            this.groupBoxБрезенхем.ResumeLayout(false);
            this.groupBoxБрезенхем.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownX_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownY_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownX_0)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxБрезенхем;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownY_0;
        private System.Windows.Forms.NumericUpDown numUpDownX_0;
        private System.Windows.Forms.CheckBox checkBoxВклМышку;
        private System.Windows.Forms.NumericUpDown numUpDownY_1;
        private System.Windows.Forms.NumericUpDown numUpDownX_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}