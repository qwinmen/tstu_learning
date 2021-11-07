using System.Windows.Forms;

namespace Magomed
{
    partial class fParamInterpol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fParamInterpol));
            this.groupBox_XY = new System.Windows.Forms.GroupBox();
            this.buttonOK_Y = new System.Windows.Forms.Button();
            this.buttonOK_X = new System.Windows.Forms.Button();
            this.textBox_YParam = new System.Windows.Forms.TextBox();
            this.textBox_XParam = new System.Windows.Forms.TextBox();
            this.radioButton_Y = new System.Windows.Forms.RadioButton();
            this.radioButton_X = new System.Windows.Forms.RadioButton();
            this.comboBox_MetodCheked = new System.Windows.Forms.ComboBox();
            this.groupBox_Metod = new System.Windows.Forms.GroupBox();
            this.groupBox_XY.SuspendLayout();
            this.groupBox_Metod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_XY
            // 
            this.groupBox_XY.Controls.Add(this.buttonOK_Y);
            this.groupBox_XY.Controls.Add(this.buttonOK_X);
            this.groupBox_XY.Controls.Add(this.textBox_YParam);
            this.groupBox_XY.Controls.Add(this.textBox_XParam);
            this.groupBox_XY.Controls.Add(this.radioButton_Y);
            this.groupBox_XY.Controls.Add(this.radioButton_X);
            this.groupBox_XY.Location = new System.Drawing.Point(12, 87);
            this.groupBox_XY.Name = "groupBox_XY";
            this.groupBox_XY.Size = new System.Drawing.Size(220, 100);
            this.groupBox_XY.TabIndex = 0;
            this.groupBox_XY.TabStop = false;
            this.groupBox_XY.Text = "Известно значение:";
            // 
            // buttonOK_Y
            // 
            this.buttonOK_Y.Enabled = false;
            this.buttonOK_Y.Location = new System.Drawing.Point(181, 63);
            this.buttonOK_Y.Name = "buttonOK_Y";
            this.buttonOK_Y.Size = new System.Drawing.Size(32, 20);
            this.buttonOK_Y.TabIndex = 5;
            this.buttonOK_Y.Text = "Ok";
            this.buttonOK_Y.UseVisualStyleBackColor = true;
            this.buttonOK_Y.Click += new System.EventHandler(this.buttonOK_Y_Click);
            // 
            // buttonOK_X
            // 
            this.buttonOK_X.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK_X.Location = new System.Drawing.Point(181, 30);
            this.buttonOK_X.Name = "buttonOK_X";
            this.buttonOK_X.Size = new System.Drawing.Size(32, 20);
            this.buttonOK_X.TabIndex = 4;
            this.buttonOK_X.Text = "Ok";
            this.buttonOK_X.UseVisualStyleBackColor = true;
            this.buttonOK_X.Click += new System.EventHandler(this.buttonOK_X_Click);
            // 
            // textBox_YParam
            // 
            this.textBox_YParam.Enabled = false;
            this.textBox_YParam.Location = new System.Drawing.Point(75, 63);
            this.textBox_YParam.Name = "textBox_YParam";
            this.textBox_YParam.Size = new System.Drawing.Size(100, 20);
            this.textBox_YParam.TabIndex = 3;
            // 
            // textBox_XParam
            // 
            this.textBox_XParam.Location = new System.Drawing.Point(75, 30);
            this.textBox_XParam.Name = "textBox_XParam";
            this.textBox_XParam.Size = new System.Drawing.Size(100, 20);
            this.textBox_XParam.TabIndex = 2;
            // 
            // radioButton_Y
            // 
            this.radioButton_Y.AutoSize = true;
            this.radioButton_Y.Location = new System.Drawing.Point(10, 64);
            this.radioButton_Y.Name = "radioButton_Y";
            this.radioButton_Y.Size = new System.Drawing.Size(59, 17);
            this.radioButton_Y.TabIndex = 1;
            this.radioButton_Y.TabStop = true;
            this.radioButton_Y.Text = "Y [2..9]";
            this.radioButton_Y.UseVisualStyleBackColor = true;
            // 
            // radioButton_X
            // 
            this.radioButton_X.AutoSize = true;
            this.radioButton_X.Location = new System.Drawing.Point(10, 31);
            this.radioButton_X.Name = "radioButton_X";
            this.radioButton_X.Size = new System.Drawing.Size(59, 17);
            this.radioButton_X.TabIndex = 0;
            this.radioButton_X.TabStop = true;
            this.radioButton_X.Text = "X [1..5]";
            this.radioButton_X.UseVisualStyleBackColor = true;
            this.radioButton_X.CheckedChanged += new System.EventHandler(this.radioButton_X_CheckedChanged);
            // 
            // comboBox_MetodCheked
            // 
            this.comboBox_MetodCheked.Items.AddRange(new object[] {
            "1-й метод Ньютона",
            "2-й метод Ньютона",
            "1-й метод Гаусса",
            "2-й метод Гаусса",
            "Метод Стирлинга",
            "Метод Бесселя",
            "Метод Лагранжа",
            "Метод Кубических Сплайнов"});
            this.comboBox_MetodCheked.Location = new System.Drawing.Point(6, 27);
            this.comboBox_MetodCheked.Name = "comboBox_MetodCheked";
            this.comboBox_MetodCheked.Size = new System.Drawing.Size(207, 21);
            this.comboBox_MetodCheked.TabIndex = 1;
            this.comboBox_MetodCheked.Text = "Укажите метод";
            // 
            // groupBox_Metod
            // 
            this.groupBox_Metod.Controls.Add(this.comboBox_MetodCheked);
            this.groupBox_Metod.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Metod.Name = "groupBox_Metod";
            this.groupBox_Metod.Size = new System.Drawing.Size(220, 69);
            this.groupBox_Metod.TabIndex = 2;
            this.groupBox_Metod.TabStop = false;
            this.groupBox_Metod.Text = "Метод интерполяций:";
            // 
            // fParamInterpol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 201);
            this.Controls.Add(this.groupBox_Metod);
            this.Controls.Add(this.groupBox_XY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fParamInterpol";
            this.ShowInTaskbar = false;
            this.Text = "Параметры";
            this.groupBox_XY.ResumeLayout(false);
            this.groupBox_XY.PerformLayout();
            this.groupBox_Metod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_XY;
        private System.Windows.Forms.RadioButton radioButton_Y;
        private System.Windows.Forms.RadioButton radioButton_X;
        private System.Windows.Forms.ComboBox comboBox_MetodCheked;
        private System.Windows.Forms.GroupBox groupBox_Metod;
        private System.Windows.Forms.TextBox textBox_YParam;
        private System.Windows.Forms.TextBox textBox_XParam;
        private System.Windows.Forms.Button buttonOK_Y;
        internal System.Windows.Forms.Button buttonOK_X;
    }
}