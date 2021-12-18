namespace Frezer
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
            this.groupBox_Forms = new System.Windows.Forms.GroupBox();
            this.radioButton_Конус = new System.Windows.Forms.RadioButton();
            this.radioButton_Овал = new System.Windows.Forms.RadioButton();
            this.radioButton_Прямоугольник = new System.Windows.Forms.RadioButton();
            this.panel_InputInfo = new System.Windows.Forms.Panel();
            this.groupBox_TexOperation = new System.Windows.Forms.GroupBox();
            this.checkBox_БезПараметров = new System.Windows.Forms.CheckBox();
            this.button_Ok = new System.Windows.Forms.Button();
            this.checkedListBox_TO = new System.Windows.Forms.CheckedListBox();
            this.groupBox_Gabarits = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_Diametr = new System.Windows.Forms.RadioButton();
            this.radioButton_Dlina = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Диаметр = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Высота = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Ширина = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Длина = new System.Windows.Forms.NumericUpDown();
            this.groupBox_Выходной = new System.Windows.Forms.GroupBox();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.listBox_OutputList = new System.Windows.Forms.ListBox();
            this.groupBox_Image = new System.Windows.Forms.GroupBox();
            this.panel_Image = new System.Windows.Forms.Panel();
            this.groupBox_Forms.SuspendLayout();
            this.panel_InputInfo.SuspendLayout();
            this.groupBox_TexOperation.SuspendLayout();
            this.groupBox_Gabarits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Диаметр)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Высота)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ширина)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Длина)).BeginInit();
            this.groupBox_Выходной.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.groupBox_Image.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Forms
            // 
            this.groupBox_Forms.Controls.Add(this.radioButton_Конус);
            this.groupBox_Forms.Controls.Add(this.radioButton_Овал);
            this.groupBox_Forms.Controls.Add(this.radioButton_Прямоугольник);
            this.groupBox_Forms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Forms.Location = new System.Drawing.Point(198, 0);
            this.groupBox_Forms.Name = "groupBox_Forms";
            this.groupBox_Forms.Size = new System.Drawing.Size(215, 219);
            this.groupBox_Forms.TabIndex = 1;
            this.groupBox_Forms.TabStop = false;
            this.groupBox_Forms.Text = "Форма заготовки";
            // 
            // radioButton_Конус
            // 
            this.radioButton_Конус.AutoSize = true;
            this.radioButton_Конус.Location = new System.Drawing.Point(28, 118);
            this.radioButton_Конус.Name = "radioButton_Конус";
            this.radioButton_Конус.Size = new System.Drawing.Size(55, 17);
            this.radioButton_Конус.TabIndex = 2;
            this.radioButton_Конус.Text = "Конус";
            this.radioButton_Конус.UseVisualStyleBackColor = true;
            // 
            // radioButton_Овал
            // 
            this.radioButton_Овал.AutoSize = true;
            this.radioButton_Овал.Location = new System.Drawing.Point(28, 67);
            this.radioButton_Овал.Name = "radioButton_Овал";
            this.radioButton_Овал.Size = new System.Drawing.Size(75, 17);
            this.radioButton_Овал.TabIndex = 1;
            this.radioButton_Овал.Text = "Овальная";
            this.radioButton_Овал.UseVisualStyleBackColor = true;
            // 
            // radioButton_Прямоугольник
            // 
            this.radioButton_Прямоугольник.AutoSize = true;
            this.radioButton_Прямоугольник.Checked = true;
            this.radioButton_Прямоугольник.Location = new System.Drawing.Point(28, 23);
            this.radioButton_Прямоугольник.Name = "radioButton_Прямоугольник";
            this.radioButton_Прямоугольник.Size = new System.Drawing.Size(105, 17);
            this.radioButton_Прямоугольник.TabIndex = 0;
            this.radioButton_Прямоугольник.TabStop = true;
            this.radioButton_Прямоугольник.Text = "Прямоугольная";
            this.radioButton_Прямоугольник.UseVisualStyleBackColor = true;
            // 
            // panel_InputInfo
            // 
            this.panel_InputInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_InputInfo.Controls.Add(this.groupBox_Forms);
            this.panel_InputInfo.Controls.Add(this.groupBox_TexOperation);
            this.panel_InputInfo.Controls.Add(this.groupBox_Gabarits);
            this.panel_InputInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_InputInfo.Location = new System.Drawing.Point(0, 0);
            this.panel_InputInfo.Name = "panel_InputInfo";
            this.panel_InputInfo.Size = new System.Drawing.Size(704, 219);
            this.panel_InputInfo.TabIndex = 2;
            // 
            // groupBox_TexOperation
            // 
            this.groupBox_TexOperation.Controls.Add(this.checkBox_БезПараметров);
            this.groupBox_TexOperation.Controls.Add(this.button_Ok);
            this.groupBox_TexOperation.Controls.Add(this.checkedListBox_TO);
            this.groupBox_TexOperation.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_TexOperation.Location = new System.Drawing.Point(413, 0);
            this.groupBox_TexOperation.Name = "groupBox_TexOperation";
            this.groupBox_TexOperation.Size = new System.Drawing.Size(291, 219);
            this.groupBox_TexOperation.TabIndex = 2;
            this.groupBox_TexOperation.TabStop = false;
            this.groupBox_TexOperation.Text = "Техническая операция";
            // 
            // checkBox_БезПараметров
            // 
            this.checkBox_БезПараметров.AutoSize = true;
            this.checkBox_БезПараметров.Checked = true;
            this.checkBox_БезПараметров.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_БезПараметров.Location = new System.Drawing.Point(105, 193);
            this.checkBox_БезПараметров.Name = "checkBox_БезПараметров";
            this.checkBox_БезПараметров.Size = new System.Drawing.Size(109, 17);
            this.checkBox_БезПараметров.TabIndex = 2;
            this.checkBox_БезПараметров.Text = "Без параметров";
            this.checkBox_БезПараметров.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(6, 191);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 1;
            this.button_Ok.Text = "Расчет";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // checkedListBox_TO
            // 
            this.checkedListBox_TO.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBox_TO.FormattingEnabled = true;
            this.checkedListBox_TO.Items.AddRange(new object[] {
            "Отрезание дисковой отрезной фрезой",
            "Фрезерование пазо-концевой фрезой",
            "Фрезерование плоскости цилиндрической фрезой"});
            this.checkedListBox_TO.Location = new System.Drawing.Point(3, 16);
            this.checkedListBox_TO.Name = "checkedListBox_TO";
            this.checkedListBox_TO.Size = new System.Drawing.Size(285, 169);
            this.checkedListBox_TO.TabIndex = 0;
            // 
            // groupBox_Gabarits
            // 
            this.groupBox_Gabarits.BackgroundImage = global::Frezer.Properties.Resources.GropChecked3;
            this.groupBox_Gabarits.Controls.Add(this.label4);
            this.groupBox_Gabarits.Controls.Add(this.label1);
            this.groupBox_Gabarits.Controls.Add(this.radioButton_Diametr);
            this.groupBox_Gabarits.Controls.Add(this.radioButton_Dlina);
            this.groupBox_Gabarits.Controls.Add(this.label3);
            this.groupBox_Gabarits.Controls.Add(this.label2);
            this.groupBox_Gabarits.Controls.Add(this.numericUpDown_Диаметр);
            this.groupBox_Gabarits.Controls.Add(this.numericUpDown_Высота);
            this.groupBox_Gabarits.Controls.Add(this.numericUpDown_Ширина);
            this.groupBox_Gabarits.Controls.Add(this.numericUpDown_Длина);
            this.groupBox_Gabarits.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_Gabarits.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Gabarits.Name = "groupBox_Gabarits";
            this.groupBox_Gabarits.Size = new System.Drawing.Size(198, 219);
            this.groupBox_Gabarits.TabIndex = 0;
            this.groupBox_Gabarits.TabStop = false;
            this.groupBox_Gabarits.Text = "Габариты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Диаметр, мм:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Длина, мм:";
            // 
            // radioButton_Diametr
            // 
            this.radioButton_Diametr.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_Diametr.Location = new System.Drawing.Point(6, 158);
            this.radioButton_Diametr.Name = "radioButton_Diametr";
            this.radioButton_Diametr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton_Diametr.Size = new System.Drawing.Size(48, 28);
            this.radioButton_Diametr.TabIndex = 2;
            this.radioButton_Diametr.Text = "Д";
            this.radioButton_Diametr.UseVisualStyleBackColor = false;
            this.radioButton_Diametr.CheckedChanged += new System.EventHandler(this.radioButton_Dlina_CheckedChanged);
            // 
            // radioButton_Dlina
            // 
            this.radioButton_Dlina.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_Dlina.Checked = true;
            this.radioButton_Dlina.Location = new System.Drawing.Point(8, 72);
            this.radioButton_Dlina.Name = "radioButton_Dlina";
            this.radioButton_Dlina.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.radioButton_Dlina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton_Dlina.Size = new System.Drawing.Size(46, 75);
            this.radioButton_Dlina.TabIndex = 5;
            this.radioButton_Dlina.TabStop = true;
            this.radioButton_Dlina.Text = "Ш\\В";
            this.radioButton_Dlina.UseVisualStyleBackColor = false;
            this.radioButton_Dlina.CheckedChanged += new System.EventHandler(this.radioButton_Dlina_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Высота, мм:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина, мм:";
            // 
            // numericUpDown_Диаметр
            // 
            this.numericUpDown_Диаметр.Location = new System.Drawing.Point(60, 169);
            this.numericUpDown_Диаметр.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_Диаметр.Name = "numericUpDown_Диаметр";
            this.numericUpDown_Диаметр.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Диаметр.TabIndex = 0;
            this.numericUpDown_Диаметр.ThousandsSeparator = true;
            // 
            // numericUpDown_Высота
            // 
            this.numericUpDown_Высота.Location = new System.Drawing.Point(60, 127);
            this.numericUpDown_Высота.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_Высота.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Высота.Name = "numericUpDown_Высота";
            this.numericUpDown_Высота.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Высота.TabIndex = 0;
            this.numericUpDown_Высота.ThousandsSeparator = true;
            this.numericUpDown_Высота.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Ширина
            // 
            this.numericUpDown_Ширина.Location = new System.Drawing.Point(60, 85);
            this.numericUpDown_Ширина.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_Ширина.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Ширина.Name = "numericUpDown_Ширина";
            this.numericUpDown_Ширина.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Ширина.TabIndex = 0;
            this.numericUpDown_Ширина.ThousandsSeparator = true;
            this.numericUpDown_Ширина.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown_Длина
            // 
            this.numericUpDown_Длина.Location = new System.Drawing.Point(60, 43);
            this.numericUpDown_Длина.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_Длина.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Длина.Name = "numericUpDown_Длина";
            this.numericUpDown_Длина.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Длина.TabIndex = 0;
            this.numericUpDown_Длина.ThousandsSeparator = true;
            this.numericUpDown_Длина.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox_Выходной
            // 
            this.groupBox_Выходной.Controls.Add(this.panel_Info);
            this.groupBox_Выходной.Controls.Add(this.groupBox_Image);
            this.groupBox_Выходной.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Выходной.Location = new System.Drawing.Point(0, 219);
            this.groupBox_Выходной.Name = "groupBox_Выходной";
            this.groupBox_Выходной.Size = new System.Drawing.Size(704, 193);
            this.groupBox_Выходной.TabIndex = 3;
            this.groupBox_Выходной.TabStop = false;
            this.groupBox_Выходной.Text = "Перечень станочных приспособлений";
            // 
            // panel_Info
            // 
            this.panel_Info.Controls.Add(this.listBox_OutputList);
            this.panel_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Info.Location = new System.Drawing.Point(3, 16);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(515, 174);
            this.panel_Info.TabIndex = 1;
            // 
            // listBox_OutputList
            // 
            this.listBox_OutputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_OutputList.FormattingEnabled = true;
            this.listBox_OutputList.Items.AddRange(new object[] {
            "В итоговый отчет включены данные с указанными условиями,",
            "либо вообще без таковых."});
            this.listBox_OutputList.Location = new System.Drawing.Point(0, 0);
            this.listBox_OutputList.Name = "listBox_OutputList";
            this.listBox_OutputList.Size = new System.Drawing.Size(515, 173);
            this.listBox_OutputList.TabIndex = 0;
            this.listBox_OutputList.SelectedIndexChanged += new System.EventHandler(this.listBox_OutputList_SelectedIndexChanged);
            // 
            // groupBox_Image
            // 
            this.groupBox_Image.Controls.Add(this.panel_Image);
            this.groupBox_Image.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_Image.Location = new System.Drawing.Point(518, 16);
            this.groupBox_Image.Name = "groupBox_Image";
            this.groupBox_Image.Size = new System.Drawing.Size(183, 174);
            this.groupBox_Image.TabIndex = 0;
            this.groupBox_Image.TabStop = false;
            this.groupBox_Image.Text = "Внешний вид";
            // 
            // panel_Image
            // 
            this.panel_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Image.Location = new System.Drawing.Point(3, 16);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(177, 155);
            this.panel_Image.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 412);
            this.Controls.Add(this.groupBox_Выходной);
            this.Controls.Add(this.panel_InputInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "18 вариант";
            this.groupBox_Forms.ResumeLayout(false);
            this.groupBox_Forms.PerformLayout();
            this.panel_InputInfo.ResumeLayout(false);
            this.groupBox_TexOperation.ResumeLayout(false);
            this.groupBox_TexOperation.PerformLayout();
            this.groupBox_Gabarits.ResumeLayout(false);
            this.groupBox_Gabarits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Диаметр)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Высота)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ширина)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Длина)).EndInit();
            this.groupBox_Выходной.ResumeLayout(false);
            this.panel_Info.ResumeLayout(false);
            this.groupBox_Image.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Gabarits;
        private System.Windows.Forms.GroupBox groupBox_Forms;
        private System.Windows.Forms.Panel panel_InputInfo;
        private System.Windows.Forms.GroupBox groupBox_TexOperation;
        private System.Windows.Forms.RadioButton radioButton_Конус;
        private System.Windows.Forms.RadioButton radioButton_Овал;
        private System.Windows.Forms.RadioButton radioButton_Прямоугольник;
        private System.Windows.Forms.NumericUpDown numericUpDown_Длина;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Диаметр;
        private System.Windows.Forms.NumericUpDown numericUpDown_Высота;
        private System.Windows.Forms.NumericUpDown numericUpDown_Ширина;
        private System.Windows.Forms.CheckedListBox checkedListBox_TO;
        private System.Windows.Forms.GroupBox groupBox_Выходной;
        private System.Windows.Forms.Panel panel_Info;
        private System.Windows.Forms.GroupBox groupBox_Image;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.ListBox listBox_OutputList;
        private System.Windows.Forms.Panel panel_Image;
        private System.Windows.Forms.RadioButton radioButton_Diametr;
        private System.Windows.Forms.RadioButton radioButton_Dlina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_БезПараметров;
    }
}

