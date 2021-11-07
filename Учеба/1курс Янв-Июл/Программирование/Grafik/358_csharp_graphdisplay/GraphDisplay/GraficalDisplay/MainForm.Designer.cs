namespace GraficDisplay
{
    using GraphLib;

    partial class MainForm
    {
        PlotterDisplayEx display = null;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.î÷èñòèòüÏîëåToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.âûõîäToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxSin = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxExpCtg = new System.Windows.Forms.GroupBox();
            this.comboCtgK2 = new System.Windows.Forms.ComboBox();
            this.comboCtgK1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxExpTg = new System.Windows.Forms.GroupBox();
            this.comboTgK2 = new System.Windows.Forms.ComboBox();
            this.comboTgK1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxExpCos = new System.Windows.Forms.GroupBox();
            this.comboCosK2 = new System.Windows.Forms.ComboBox();
            this.comboCosK1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxExpSin = new System.Windows.Forms.GroupBox();
            this.comboSinK2 = new System.Windows.Forms.ComboBox();
            this.comboSinK1 = new System.Windows.Forms.ComboBox();
            this.expSin = new System.Windows.Forms.Label();
            this.checkBoxCTan = new System.Windows.Forms.CheckBox();
            this.checkBoxTan = new System.Windows.Forms.CheckBox();
            this.checkBoxCos = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBoxSettings = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ImageCircleSin = new System.Windows.Forms.PictureBox();
            this.ImageCircleTg = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ImageCircleCtg = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.EditAngle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ImageCircleCos = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.display = new GraphLib.PlotterDisplayEx();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxExpCtg.SuspendLayout();
            this.groupBoxExpTg.SuspendLayout();
            this.groupBoxExpCos.SuspendLayout();
            this.groupBoxExpSin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.GroupBoxSettings.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCircleSin)).BeginInit();
            this.ImageCircleTg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.ImageCircleCtg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCircleCos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // layoutToolStripMenuItem
            // 
            this.layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.î÷èñòèòüÏîëåToolStripMenuItem,
            this.âûõîäToolStripMenuItem});
            this.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            this.layoutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.layoutToolStripMenuItem.Text = "Ôàéë";
            // 
            // î÷èñòèòüÏîëåToolStripMenuItem
            // 
            this.î÷èñòèòüÏîëåToolStripMenuItem.Name = "î÷èñòèòüÏîëåToolStripMenuItem";
            this.î÷èñòèòüÏîëåToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.î÷èñòèòüÏîëåToolStripMenuItem.Text = "Î÷èñòèòü ïîëå";
            this.î÷èñòèòüÏîëåToolStripMenuItem.Click += new System.EventHandler(this.î÷èñòèòüÏîëåToolStripMenuItem_Click);
            // 
            // âûõîäToolStripMenuItem
            // 
            this.âûõîäToolStripMenuItem.Name = "âûõîäToolStripMenuItem";
            this.âûõîäToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.âûõîäToolStripMenuItem.Text = "Âûõîä";
            this.âûõîäToolStripMenuItem.Click += new System.EventHandler(this.âûõîäToolStripMenuItem_Click);
            // 
            // checkBoxSin
            // 
            this.checkBoxSin.AutoSize = true;
            this.checkBoxSin.Location = new System.Drawing.Point(25, 35);
            this.checkBoxSin.Name = "checkBoxSin";
            this.checkBoxSin.Size = new System.Drawing.Size(39, 17);
            this.checkBoxSin.TabIndex = 3;
            this.checkBoxSin.Text = "sin";
            this.checkBoxSin.UseVisualStyleBackColor = true;
            this.checkBoxSin.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxExpCtg);
            this.groupBox1.Controls.Add(this.groupBoxExpTg);
            this.groupBox1.Controls.Add(this.groupBoxExpCos);
            this.groupBox1.Controls.Add(this.groupBoxExpSin);
            this.groupBox1.Controls.Add(this.checkBoxCTan);
            this.groupBox1.Controls.Add(this.checkBoxTan);
            this.groupBox1.Controls.Add(this.checkBoxCos);
            this.groupBox1.Controls.Add(this.checkBoxSin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 216);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Âûáåðèòå âèä ãðàôèêà";
            // 
            // groupBoxExpCtg
            // 
            this.groupBoxExpCtg.Controls.Add(this.comboBox4);
            this.groupBoxExpCtg.Controls.Add(this.comboCtgK2);
            this.groupBoxExpCtg.Controls.Add(this.comboCtgK1);
            this.groupBoxExpCtg.Controls.Add(this.label7);
            this.groupBoxExpCtg.Location = new System.Drawing.Point(72, 161);
            this.groupBoxExpCtg.Name = "groupBoxExpCtg";
            this.groupBoxExpCtg.Size = new System.Drawing.Size(203, 41);
            this.groupBoxExpCtg.TabIndex = 13;
            this.groupBoxExpCtg.TabStop = false;
            this.groupBoxExpCtg.Text = "Âûðàæåíèå äëÿ tg";
            this.groupBoxExpCtg.Visible = false;
            // 
            // comboCtgK2
            // 
            this.comboCtgK2.DisplayMember = "0";
            this.comboCtgK2.FormattingEnabled = true;
            this.comboCtgK2.Items.AddRange(new object[] {
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3"});
            this.comboCtgK2.Location = new System.Drawing.Point(154, 12);
            this.comboCtgK2.Name = "comboCtgK2";
            this.comboCtgK2.Size = new System.Drawing.Size(31, 21);
            this.comboCtgK2.TabIndex = 9;
            this.comboCtgK2.Text = "0";
            this.comboCtgK2.SelectedIndexChanged += new System.EventHandler(this.comboCtgK2_SelectedIndexChanged);
            // 
            // comboCtgK1
            // 
            this.comboCtgK1.FormattingEnabled = true;
            this.comboCtgK1.Items.AddRange(new object[] {
            "0,3",
            "0,5",
            "1",
            "2",
            "3",
            "4"});
            this.comboCtgK1.Location = new System.Drawing.Point(13, 14);
            this.comboCtgK1.Name = "comboCtgK1";
            this.comboCtgK1.Size = new System.Drawing.Size(45, 21);
            this.comboCtgK1.TabIndex = 7;
            this.comboCtgK1.Text = "1";
            this.comboCtgK1.SelectedIndexChanged += new System.EventHandler(this.comboCtgK1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(61, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "* ctg(             x ) +";
            // 
            // groupBoxExpTg
            // 
            this.groupBoxExpTg.Controls.Add(this.comboBox3);
            this.groupBoxExpTg.Controls.Add(this.comboTgK2);
            this.groupBoxExpTg.Controls.Add(this.comboTgK1);
            this.groupBoxExpTg.Controls.Add(this.label6);
            this.groupBoxExpTg.Location = new System.Drawing.Point(72, 114);
            this.groupBoxExpTg.Name = "groupBoxExpTg";
            this.groupBoxExpTg.Size = new System.Drawing.Size(203, 41);
            this.groupBoxExpTg.TabIndex = 12;
            this.groupBoxExpTg.TabStop = false;
            this.groupBoxExpTg.Text = "Âûðàæåíèå äëÿ tg";
            this.groupBoxExpTg.Visible = false;
            // 
            // comboTgK2
            // 
            this.comboTgK2.DisplayMember = "0";
            this.comboTgK2.FormattingEnabled = true;
            this.comboTgK2.Items.AddRange(new object[] {
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3"});
            this.comboTgK2.Location = new System.Drawing.Point(154, 13);
            this.comboTgK2.Name = "comboTgK2";
            this.comboTgK2.Size = new System.Drawing.Size(31, 21);
            this.comboTgK2.TabIndex = 9;
            this.comboTgK2.Text = "0";
            this.comboTgK2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboTgK1
            // 
            this.comboTgK1.FormattingEnabled = true;
            this.comboTgK1.Items.AddRange(new object[] {
            "0,3",
            "0,5",
            "1",
            "2",
            "3",
            "4"});
            this.comboTgK1.Location = new System.Drawing.Point(13, 14);
            this.comboTgK1.Name = "comboTgK1";
            this.comboTgK1.Size = new System.Drawing.Size(45, 21);
            this.comboTgK1.TabIndex = 7;
            this.comboTgK1.Text = "1";
            this.comboTgK1.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(61, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "* tg(             x ) +";
            // 
            // groupBoxExpCos
            // 
            this.groupBoxExpCos.Controls.Add(this.comboBox2);
            this.groupBoxExpCos.Controls.Add(this.comboCosK2);
            this.groupBoxExpCos.Controls.Add(this.comboCosK1);
            this.groupBoxExpCos.Controls.Add(this.label5);
            this.groupBoxExpCos.Location = new System.Drawing.Point(72, 67);
            this.groupBoxExpCos.Name = "groupBoxExpCos";
            this.groupBoxExpCos.Size = new System.Drawing.Size(203, 41);
            this.groupBoxExpCos.TabIndex = 11;
            this.groupBoxExpCos.TabStop = false;
            this.groupBoxExpCos.Text = "Âûðàæåíèå äëÿ cos";
            this.groupBoxExpCos.Visible = false;
            // 
            // comboCosK2
            // 
            this.comboCosK2.DisplayMember = "0";
            this.comboCosK2.FormattingEnabled = true;
            this.comboCosK2.Items.AddRange(new object[] {
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3"});
            this.comboCosK2.Location = new System.Drawing.Point(154, 12);
            this.comboCosK2.Name = "comboCosK2";
            this.comboCosK2.Size = new System.Drawing.Size(31, 21);
            this.comboCosK2.TabIndex = 9;
            this.comboCosK2.Text = "0";
            this.comboCosK2.SelectedIndexChanged += new System.EventHandler(this.comboCosK2_SelectedIndexChanged);
            // 
            // comboCosK1
            // 
            this.comboCosK1.FormattingEnabled = true;
            this.comboCosK1.Items.AddRange(new object[] {
            "0,3",
            "0,5",
            "1",
            "2",
            "3",
            "4"});
            this.comboCosK1.Location = new System.Drawing.Point(13, 14);
            this.comboCosK1.Name = "comboCosK1";
            this.comboCosK1.Size = new System.Drawing.Size(45, 21);
            this.comboCosK1.TabIndex = 7;
            this.comboCosK1.Text = "1";
            this.comboCosK1.SelectedIndexChanged += new System.EventHandler(this.comboCosK1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(61, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "* cos(             x ) +";
            // 
            // groupBoxExpSin
            // 
            this.groupBoxExpSin.Controls.Add(this.comboBox1);
            this.groupBoxExpSin.Controls.Add(this.comboSinK2);
            this.groupBoxExpSin.Controls.Add(this.comboSinK1);
            this.groupBoxExpSin.Controls.Add(this.expSin);
            this.groupBoxExpSin.Location = new System.Drawing.Point(70, 20);
            this.groupBoxExpSin.Name = "groupBoxExpSin";
            this.groupBoxExpSin.Size = new System.Drawing.Size(203, 41);
            this.groupBoxExpSin.TabIndex = 10;
            this.groupBoxExpSin.TabStop = false;
            this.groupBoxExpSin.Text = "Âûðàæåíèå äëÿ sin";
            this.groupBoxExpSin.Visible = false;
            // 
            // comboSinK2
            // 
            this.comboSinK2.DisplayMember = "0";
            this.comboSinK2.FormattingEnabled = true;
            this.comboSinK2.Items.AddRange(new object[] {
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3"});
            this.comboSinK2.Location = new System.Drawing.Point(156, 14);
            this.comboSinK2.Name = "comboSinK2";
            this.comboSinK2.Size = new System.Drawing.Size(31, 21);
            this.comboSinK2.TabIndex = 9;
            this.comboSinK2.Text = "0";
            this.comboSinK2.SelectedIndexChanged += new System.EventHandler(this.comboSinK2_SelectedIndexChanged);
            // 
            // comboSinK1
            // 
            this.comboSinK1.FormattingEnabled = true;
            this.comboSinK1.Items.AddRange(new object[] {
            "0,3",
            "0,5",
            "1",
            "2",
            "3",
            "4"});
            this.comboSinK1.Location = new System.Drawing.Point(13, 14);
            this.comboSinK1.Name = "comboSinK1";
            this.comboSinK1.Size = new System.Drawing.Size(45, 21);
            this.comboSinK1.TabIndex = 7;
            this.comboSinK1.Text = "1";
            this.comboSinK1.SelectedIndexChanged += new System.EventHandler(this.comboSinK1_SelectedIndexChanged);
            // 
            // expSin
            // 
            this.expSin.AutoSize = true;
            this.expSin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expSin.Location = new System.Drawing.Point(61, 15);
            this.expSin.Name = "expSin";
            this.expSin.Size = new System.Drawing.Size(97, 15);
            this.expSin.TabIndex = 8;
            this.expSin.Text = "* sin(             x ) +";
            // 
            // checkBoxCTan
            // 
            this.checkBoxCTan.AutoSize = true;
            this.checkBoxCTan.Location = new System.Drawing.Point(25, 179);
            this.checkBoxCTan.Name = "checkBoxCTan";
            this.checkBoxCTan.Size = new System.Drawing.Size(41, 17);
            this.checkBoxCTan.TabIndex = 6;
            this.checkBoxCTan.Text = "ctg";
            this.checkBoxCTan.UseVisualStyleBackColor = true;
            this.checkBoxCTan.CheckedChanged += new System.EventHandler(this.checkBoxCTan_CheckedChanged);
            // 
            // checkBoxTan
            // 
            this.checkBoxTan.AutoSize = true;
            this.checkBoxTan.Location = new System.Drawing.Point(25, 131);
            this.checkBoxTan.Name = "checkBoxTan";
            this.checkBoxTan.Size = new System.Drawing.Size(35, 17);
            this.checkBoxTan.TabIndex = 5;
            this.checkBoxTan.Text = "tg";
            this.checkBoxTan.UseVisualStyleBackColor = true;
            this.checkBoxTan.CheckedChanged += new System.EventHandler(this.checkBoxTan_CheckedChanged);
            // 
            // checkBoxCos
            // 
            this.checkBoxCos.AutoSize = true;
            this.checkBoxCos.Location = new System.Drawing.Point(25, 83);
            this.checkBoxCos.Name = "checkBoxCos";
            this.checkBoxCos.Size = new System.Drawing.Size(43, 17);
            this.checkBoxCos.TabIndex = 4;
            this.checkBoxCos.Text = "cos";
            this.checkBoxCos.UseVisualStyleBackColor = true;
            this.checkBoxCos.CheckedChanged += new System.EventHandler(this.checkBoxCos_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.display, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 538);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.GroupBoxSettings, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(719, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(302, 370);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // GroupBoxSettings
            // 
            this.GroupBoxSettings.Controls.Add(this.label4);
            this.GroupBoxSettings.Controls.Add(this.label3);
            this.GroupBoxSettings.Controls.Add(this.label2);
            this.GroupBoxSettings.Controls.Add(this.label1);
            this.GroupBoxSettings.Controls.Add(this.button4);
            this.GroupBoxSettings.Controls.Add(this.button3);
            this.GroupBoxSettings.Controls.Add(this.button2);
            this.GroupBoxSettings.Controls.Add(this.button1);
            this.GroupBoxSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxSettings.Location = new System.Drawing.Point(3, 225);
            this.GroupBoxSettings.Name = "GroupBoxSettings";
            this.GroupBoxSettings.Size = new System.Drawing.Size(296, 142);
            this.GroupBoxSettings.TabIndex = 5;
            this.GroupBoxSettings.TabStop = false;
            this.GroupBoxSettings.Text = " Íàñòðîéêè";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Öâåò ctg:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Öâåò tg:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Öâåò cos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Öâåò sin:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(89, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 23);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 23);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(719, 379);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(302, 123);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Íàñòðîéêà áëîêîâ";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(12, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(107, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Áëîê íàñòðîéêè";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(203, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Áëîê ñ åäèíè÷íûìè îêðóæíîñòÿìè";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ImageCircleTg, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.ImageCircleCtg, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 379);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(710, 156);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ImageCircleSin);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(145, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 150);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Åä. îêðóæ. sin";
            // 
            // ImageCircleSin
            // 
            this.ImageCircleSin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageCircleSin.Location = new System.Drawing.Point(3, 16);
            this.ImageCircleSin.Name = "ImageCircleSin";
            this.ImageCircleSin.Size = new System.Drawing.Size(130, 131);
            this.ImageCircleSin.TabIndex = 0;
            this.ImageCircleSin.TabStop = false;
            this.ImageCircleSin.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageCircleSin_Paint);
            // 
            // ImageCircleTg
            // 
            this.ImageCircleTg.Controls.Add(this.pictureBox3);
            this.ImageCircleTg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageCircleTg.Location = new System.Drawing.Point(429, 3);
            this.ImageCircleTg.Name = "ImageCircleTg";
            this.ImageCircleTg.Size = new System.Drawing.Size(136, 150);
            this.ImageCircleTg.TabIndex = 3;
            this.ImageCircleTg.TabStop = false;
            this.ImageCircleTg.Text = "Åä. îêðóæ. tg";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(3, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(130, 131);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox3_Paint);
            // 
            // ImageCircleCtg
            // 
            this.ImageCircleCtg.Controls.Add(this.pictureBox4);
            this.ImageCircleCtg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageCircleCtg.Location = new System.Drawing.Point(571, 3);
            this.ImageCircleCtg.Name = "ImageCircleCtg";
            this.ImageCircleCtg.Size = new System.Drawing.Size(136, 150);
            this.ImageCircleCtg.TabIndex = 4;
            this.ImageCircleCtg.TabStop = false;
            this.ImageCircleCtg.Text = "Åä. îêðóæ. ctg";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(3, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(130, 131);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox4_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.EditAngle);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 150);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Çíàêè ôóíêöèé";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 98);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "ïðèìåíèòü";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // EditAngle
            // 
            this.EditAngle.Location = new System.Drawing.Point(12, 59);
            this.EditAngle.Name = "EditAngle";
            this.EditAngle.Size = new System.Drawing.Size(74, 20);
            this.EditAngle.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ââåäèòå óãîë: ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ImageCircleCos);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(287, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(136, 150);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Åä. îêðóæ. cos";
            // 
            // ImageCircleCos
            // 
            this.ImageCircleCos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageCircleCos.Location = new System.Drawing.Point(3, 16);
            this.ImageCircleCos.Name = "ImageCircleCos";
            this.ImageCircleCos.Size = new System.Drawing.Size(130, 131);
            this.ImageCircleCos.TabIndex = 0;
            this.ImageCircleCos.TabStop = false;
            this.ImageCircleCos.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageCircleCos_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-2",
            "-1",
            "1",
            "2",
            "3"});
            this.comboBox1.Location = new System.Drawing.Point(95, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(32, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "-2",
            "-1",
            "1",
            "2",
            "3"});
            this.comboBox2.Location = new System.Drawing.Point(97, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(32, 21);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.Text = "1";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "-2",
            "-1",
            "1",
            "2",
            "3"});
            this.comboBox3.Location = new System.Drawing.Point(89, 13);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(32, 21);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.Text = "1";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "-2",
            "-1",
            "1",
            "2",
            "3"});
            this.comboBox4.Location = new System.Drawing.Point(93, 14);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(32, 21);
            this.comboBox4.TabIndex = 13;
            this.comboBox4.Text = "1";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.Black;
            this.display.BackgroundColorBot = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.display.BackgroundColorTop = System.Drawing.Color.Navy;
            this.display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.display.DashedGridColor = System.Drawing.Color.Blue;
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.DoubleBuffering = true;
            this.display.Location = new System.Drawing.Point(3, 3);
            this.display.Name = "display";
            this.display.PlaySpeed = 0.5F;
            this.display.Size = new System.Drawing.Size(710, 370);
            this.display.SolidGridColor = System.Drawing.Color.Blue;
            this.display.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "MainForm";
            this.Text = "GraphLib Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxExpCtg.ResumeLayout(false);
            this.groupBoxExpCtg.PerformLayout();
            this.groupBoxExpTg.ResumeLayout(false);
            this.groupBoxExpTg.PerformLayout();
            this.groupBoxExpCos.ResumeLayout(false);
            this.groupBoxExpCos.PerformLayout();
            this.groupBoxExpSin.ResumeLayout(false);
            this.groupBoxExpSin.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.GroupBoxSettings.ResumeLayout(false);
            this.GroupBoxSettings.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCircleSin)).EndInit();
            this.ImageCircleTg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ImageCircleCtg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCircleCos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxSin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCTan;
        private System.Windows.Forms.CheckBox checkBoxTan;
        private System.Windows.Forms.CheckBox checkBoxCos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem î÷èñòèòüÏîëåToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem âûõîäToolStripMenuItem;
        private System.Windows.Forms.GroupBox GroupBoxSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboSinK1;
        private System.Windows.Forms.Label expSin;
        private System.Windows.Forms.ComboBox comboSinK2;
        private System.Windows.Forms.GroupBox groupBoxExpSin;
        private System.Windows.Forms.GroupBox groupBoxExpCos;
        private System.Windows.Forms.ComboBox comboCosK2;
        private System.Windows.Forms.ComboBox comboCosK1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxExpTg;
        private System.Windows.Forms.ComboBox comboTgK2;
        private System.Windows.Forms.ComboBox comboTgK1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxExpCtg;
        private System.Windows.Forms.ComboBox comboCtgK2;
        private System.Windows.Forms.ComboBox comboCtgK1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EditAngle;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox ImageCircleSin;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox ImageCircleCos;
        private System.Windows.Forms.GroupBox ImageCircleTg;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox ImageCircleCtg;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox4;

    }
}

