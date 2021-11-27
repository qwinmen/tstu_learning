namespace TreeControll
{
    partial class UCPole
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
            this.linkLabelName = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.doubleInput1 = new DevComponents.Editors.DoubleInput();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxМаска = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelName
            // 
            this.linkLabelName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.linkLabelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelName.Location = new System.Drawing.Point(0, 0);
            this.linkLabelName.Name = "linkLabelName";
            this.linkLabelName.Size = new System.Drawing.Size(102, 21);
            this.linkLabelName.TabIndex = 0;
            this.linkLabelName.TabStop = true;
            this.linkLabelName.Text = "Выбрать поле";
            this.linkLabelName.Click += new System.EventHandler(this.linkLabelName_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "name",
            "ik0 ",
            "ik1 ",
            "uk0 ",
            "uk1 ",
            "uk2 ",
            "pk ",
            "tc0 ",
            "tc1 ",
            "tc2 ",
            "h21 ",
            "ukb ",
            "ikb ",
            "uke ",
            "ikbo",
            "fgr ",
            "kh ",
            "ck ",
            "ca ",
            "tpac",
            "rtnc",
            "title",
            "picture"});
            this.comboBox1.Location = new System.Drawing.Point(0, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // doubleInput1
            // 
            // 
            // 
            // 
            this.doubleInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput1.Dock = System.Windows.Forms.DockStyle.Top;
            this.doubleInput1.Increment = 1;
            this.doubleInput1.Location = new System.Drawing.Point(0, 63);
            this.doubleInput1.Name = "doubleInput1";
            this.doubleInput1.ShowUpDown = true;
            this.doubleInput1.Size = new System.Drawing.Size(102, 20);
            this.doubleInput1.TabIndex = 2;
            this.doubleInput1.WatermarkText = "значение";
            this.doubleInput1.ValueObjectChanged += new System.EventHandler(this.doubleInput1_ValueObjectChanged);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(0, 62);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(102, 20);
            this.textBoxX1.TabIndex = 3;
            this.textBoxX1.Visible = false;
            this.textBoxX1.WatermarkText = "значение";
            this.textBoxX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxX1_KeyDown);
            // 
            // comboBoxМаска
            // 
            this.comboBoxМаска.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxМаска.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxМаска.FormattingEnabled = true;
            this.comboBoxМаска.Items.AddRange(new object[] {
            "заканчивая",
            "начиная с",
            "содержит"});
            this.comboBoxМаска.Location = new System.Drawing.Point(0, 42);
            this.comboBoxМаска.Name = "comboBoxМаска";
            this.comboBoxМаска.Size = new System.Drawing.Size(102, 21);
            this.comboBoxМаска.Sorted = true;
            this.comboBoxМаска.TabIndex = 4;
            this.comboBoxМаска.SelectionChangeCommitted += new System.EventHandler(this.comboBoxМаска_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Vika.Properties.Resources.module;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(80, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UCPole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.doubleInput1);
            this.Controls.Add(this.comboBoxМаска);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linkLabelName);
            this.Name = "UCPole";
            this.Size = new System.Drawing.Size(102, 83);
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelName;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevComponents.Editors.DoubleInput doubleInput1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.ComboBox comboBoxМаска;
        private System.Windows.Forms.Button button1;
    }
}
