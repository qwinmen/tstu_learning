namespace sZip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_IN = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.radioButton_Сжать = new System.Windows.Forms.RadioButton();
            this.radioButton_Восстановить = new System.Windows.Forms.RadioButton();
            this.textBox_OUT = new System.Windows.Forms.TextBox();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_IN
            // 
            this.textBox_IN.Location = new System.Drawing.Point(12, 12);
            this.textBox_IN.Multiline = true;
            this.textBox_IN.Name = "textBox_IN";
            this.textBox_IN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_IN.Size = new System.Drawing.Size(416, 85);
            this.textBox_IN.TabIndex = 0;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(434, 12);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(94, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "Хорошо";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // radioButton_Сжать
            // 
            this.radioButton_Сжать.AutoSize = true;
            this.radioButton_Сжать.Checked = true;
            this.radioButton_Сжать.Location = new System.Drawing.Point(434, 57);
            this.radioButton_Сжать.Name = "radioButton_Сжать";
            this.radioButton_Сжать.Size = new System.Drawing.Size(85, 17);
            this.radioButton_Сжать.TabIndex = 2;
            this.radioButton_Сжать.TabStop = true;
            this.radioButton_Сжать.Text = "Надо сжать";
            this.radioButton_Сжать.UseVisualStyleBackColor = true;
            // 
            // radioButton_Восстановить
            // 
            this.radioButton_Восстановить.AutoSize = true;
            this.radioButton_Восстановить.Location = new System.Drawing.Point(434, 80);
            this.radioButton_Восстановить.Name = "radioButton_Восстановить";
            this.radioButton_Восстановить.Size = new System.Drawing.Size(94, 17);
            this.radioButton_Восстановить.TabIndex = 3;
            this.radioButton_Восстановить.Text = "Надо вернуть";
            this.radioButton_Восстановить.UseVisualStyleBackColor = true;
            // 
            // textBox_OUT
            // 
            this.textBox_OUT.Location = new System.Drawing.Point(12, 103);
            this.textBox_OUT.Multiline = true;
            this.textBox_OUT.Name = "textBox_OUT";
            this.textBox_OUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_OUT.Size = new System.Drawing.Size(516, 128);
            this.textBox_OUT.TabIndex = 4;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.HScrollBarVisible = false;
            this.advTree1.Location = new System.Drawing.Point(12, 237);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(516, 117);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 5;
            this.advTree1.Text = "advTree1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Символ";
            this.columnHeader1.Width.Absolute = 265;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Номер";
            this.columnHeader2.Width.Absolute = 265;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 20);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(282, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 20);
            this.label3.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 385);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.advTree1);
            this.Controls.Add(this.textBox_OUT);
            this.Controls.Add(this.radioButton_Восстановить);
            this.Controls.Add(this.radioButton_Сжать);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_IN);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(553, 401);
            this.Name = "Form1";
            this.Text = "Zip архиватор Королёва";
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IN;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.RadioButton radioButton_Сжать;
        private System.Windows.Forms.RadioButton radioButton_Восстановить;
        private System.Windows.Forms.TextBox textBox_OUT;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

