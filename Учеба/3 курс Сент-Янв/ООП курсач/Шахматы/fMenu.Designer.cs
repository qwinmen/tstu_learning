using DevComponents.DotNetBar.Metro.ColorTables;
using System.Windows.Forms;

namespace Шахматы
{
    partial class fMenu : DevComponents.DotNetBar.Office2007Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMenu));
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.About = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.expPnl_KingShax = new DevComponents.DotNetBar.ExpandablePanel();
            this.rBtn_OffShax = new System.Windows.Forms.RadioButton();
            this.rBtn_OnShax = new System.Windows.Forms.RadioButton();
            this.expPnl_Help = new DevComponents.DotNetBar.ExpandablePanel();
            this.rBtn_OffHelp = new System.Windows.Forms.RadioButton();
            this.rBtn_OnHelp = new System.Windows.Forms.RadioButton();
            this.expPnl_StartGo = new DevComponents.DotNetBar.ExpandablePanel();
            this.radioBtn_GoWhite = new System.Windows.Forms.RadioButton();
            this.radioBtn_GoBlack = new System.Windows.Forms.RadioButton();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.microChart2 = new DevComponents.DotNetBar.MicroChart();
            this.microChart1 = new DevComponents.DotNetBar.MicroChart();
            this.lbl_vsegoIgr = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.lblWhite = new System.Windows.Forms.Label();
            this.lblBlack = new System.Windows.Forms.Label();
            this.lblPerWin = new DevComponents.DotNetBar.LabelX();
            this.lblContineGame = new DevComponents.DotNetBar.LabelX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox_BoardSel = new System.Windows.Forms.GroupBox();
            this.rb_BoardStyle_2 = new System.Windows.Forms.RadioButton();
            this.rb_BoardStyle_1 = new System.Windows.Forms.RadioButton();
            this.rb_BoardStyle_0 = new System.Windows.Forms.RadioButton();
            this.rb_BoardStyleDeff = new System.Windows.Forms.RadioButton();
            this.reflectionImage4 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.reflectionImage3 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.reflectionImage2 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.groupBox_FigSel = new System.Windows.Forms.GroupBox();
            this.reflectionImage5 = new System.Windows.Forms.PictureBox();
            this.ipnl_FigSwitch = new DevComponents.DotNetBar.ItemPanel();
            this.btnFig_Deff = new DevComponents.DotNetBar.ButtonItem();
            this.btnFig_1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnFig_2 = new DevComponents.DotNetBar.ButtonItem();
            this.lblInfoStyle = new DevComponents.DotNetBar.LabelItem();
            this.tabItem_Style = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblStartWritingKeyWhite = new DevComponents.DotNetBar.LabelX();
            this.lblStartWritingKeyBlack = new DevComponents.DotNetBar.LabelX();
            this.lblWhiteLeft = new DevComponents.DotNetBar.LabelX();
            this.lblBlackLeft = new DevComponents.DotNetBar.LabelX();
            this.lblWhiteRight = new DevComponents.DotNetBar.LabelX();
            this.lblWhiteDown = new DevComponents.DotNetBar.LabelX();
            this.lblBlackRight = new DevComponents.DotNetBar.LabelX();
            this.lblWhiteUp = new DevComponents.DotNetBar.LabelX();
            this.lblBlackDown = new DevComponents.DotNetBar.LabelX();
            this.lblBlackUp = new DevComponents.DotNetBar.LabelX();
            this.lblWhiteKey = new DevComponents.DotNetBar.LabelX();
            this.lblBlackKey = new DevComponents.DotNetBar.LabelX();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.toolTipForKeys = new System.Windows.Forms.ToolTip(this.components);
            this.NastroikiManag = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.expPnl_KingShax.SuspendLayout();
            this.expPnl_Help.SuspendLayout();
            this.expPnl_StartGo.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            this.groupBox_BoardSel.SuspendLayout();
            this.groupBox_FigSel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectionImage5)).BeginInit();
            this.tabControlPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.White;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel5);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(327, 281);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Tabs.Add(this.tabItem_Style);
            this.tabControl1.Tabs.Add(this.About);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabControlPanel4.Controls.Add(this.flowLayoutPanel1);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(327, 256);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.About;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(325, 254);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Шахматы.Properties.Resources.bpc;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 107);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(3, 116);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(313, 131);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // About
            // 
            this.About.AttachedControl = this.tabControlPanel4;
            this.About.Icon = ((System.Drawing.Icon)(resources.GetObject("About.Icon")));
            this.About.Name = "About";
            this.About.Text = "About";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.tabControlPanel1.Controls.Add(this.expandablePanel1);
            this.tabControlPanel1.Controls.Add(this.expPnl_KingShax);
            this.tabControlPanel1.Controls.Add(this.expPnl_Help);
            this.tabControlPanel1.Controls.Add(this.expPnl_StartGo);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(327, 256);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel1.Controls.Add(this.radioButton2);
            this.expandablePanel1.Controls.Add(this.radioButton1);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(1, 159);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(325, 96);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 2;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "Подсветка ходов";
            // 
            // radioButton2
            // 
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.Location = new System.Drawing.Point(162, 33);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(97, 23);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Выключено";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.Location = new System.Drawing.Point(57, 33);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 23);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Включено";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // expPnl_KingShax
            // 
            this.expPnl_KingShax.CanvasColor = System.Drawing.SystemColors.Control;
            this.expPnl_KingShax.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expPnl_KingShax.Controls.Add(this.rBtn_OffShax);
            this.expPnl_KingShax.Controls.Add(this.rBtn_OnShax);
            this.expPnl_KingShax.Dock = System.Windows.Forms.DockStyle.Top;
            this.expPnl_KingShax.Expanded = false;
            this.expPnl_KingShax.ExpandedBounds = new System.Drawing.Rectangle(1, 133, 316, 66);
            this.expPnl_KingShax.HideControlsWhenCollapsed = true;
            this.expPnl_KingShax.Location = new System.Drawing.Point(1, 133);
            this.expPnl_KingShax.Name = "expPnl_KingShax";
            this.expPnl_KingShax.Size = new System.Drawing.Size(325, 26);
            this.expPnl_KingShax.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expPnl_KingShax.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expPnl_KingShax.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expPnl_KingShax.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expPnl_KingShax.Style.GradientAngle = 90;
            this.expPnl_KingShax.TabIndex = 3;
            this.expPnl_KingShax.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expPnl_KingShax.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expPnl_KingShax.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expPnl_KingShax.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expPnl_KingShax.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expPnl_KingShax.TitleStyle.GradientAngle = 90;
            this.expPnl_KingShax.TitleText = "Кароль трус? (Отслеживать ШАХ)";
            // 
            // rBtn_OffShax
            // 
            this.rBtn_OffShax.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_OffShax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rBtn_OffShax.ForeColor = System.Drawing.Color.Black;
            this.rBtn_OffShax.Location = new System.Drawing.Point(162, 34);
            this.rBtn_OffShax.Name = "rBtn_OffShax";
            this.rBtn_OffShax.Size = new System.Drawing.Size(97, 23);
            this.rBtn_OffShax.TabIndex = 2;
            this.rBtn_OffShax.TabStop = true;
            this.rBtn_OffShax.Text = "Выключено";
            this.rBtn_OffShax.UseVisualStyleBackColor = false;
            this.rBtn_OffShax.CheckedChanged += new System.EventHandler(this.rBtn_OnShax_CheckedChanged);
            // 
            // rBtn_OnShax
            // 
            this.rBtn_OnShax.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_OnShax.Checked = true;
            this.rBtn_OnShax.ForeColor = System.Drawing.Color.Black;
            this.rBtn_OnShax.Location = new System.Drawing.Point(57, 34);
            this.rBtn_OnShax.Name = "rBtn_OnShax";
            this.rBtn_OnShax.Size = new System.Drawing.Size(99, 23);
            this.rBtn_OnShax.TabIndex = 1;
            this.rBtn_OnShax.TabStop = true;
            this.rBtn_OnShax.Text = "Включено";
            this.rBtn_OnShax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rBtn_OnShax.UseVisualStyleBackColor = false;
            this.rBtn_OnShax.CheckedChanged += new System.EventHandler(this.rBtn_OnShax_CheckedChanged);
            // 
            // expPnl_Help
            // 
            this.expPnl_Help.CanvasColor = System.Drawing.SystemColors.Control;
            this.expPnl_Help.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expPnl_Help.Controls.Add(this.rBtn_OffHelp);
            this.expPnl_Help.Controls.Add(this.rBtn_OnHelp);
            this.expPnl_Help.Dock = System.Windows.Forms.DockStyle.Top;
            this.expPnl_Help.HideControlsWhenCollapsed = true;
            this.expPnl_Help.Location = new System.Drawing.Point(1, 68);
            this.expPnl_Help.Name = "expPnl_Help";
            this.expPnl_Help.Size = new System.Drawing.Size(325, 65);
            this.expPnl_Help.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expPnl_Help.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expPnl_Help.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expPnl_Help.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expPnl_Help.Style.GradientAngle = 90;
            this.expPnl_Help.TabIndex = 1;
            this.expPnl_Help.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expPnl_Help.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expPnl_Help.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expPnl_Help.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expPnl_Help.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expPnl_Help.TitleStyle.GradientAngle = 90;
            this.expPnl_Help.TitleText = "Подсказки";
            // 
            // rBtn_OffHelp
            // 
            this.rBtn_OffHelp.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_OffHelp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rBtn_OffHelp.ForeColor = System.Drawing.Color.Black;
            this.rBtn_OffHelp.Location = new System.Drawing.Point(162, 33);
            this.rBtn_OffHelp.Name = "rBtn_OffHelp";
            this.rBtn_OffHelp.Size = new System.Drawing.Size(97, 23);
            this.rBtn_OffHelp.TabIndex = 2;
            this.rBtn_OffHelp.TabStop = true;
            this.rBtn_OffHelp.Text = "Выключено";
            this.rBtn_OffHelp.UseVisualStyleBackColor = false;
            this.rBtn_OffHelp.CheckedChanged += new System.EventHandler(this.rBtn_OnHelp_CheckedChanged);
            // 
            // rBtn_OnHelp
            // 
            this.rBtn_OnHelp.BackColor = System.Drawing.Color.Transparent;
            this.rBtn_OnHelp.Checked = true;
            this.rBtn_OnHelp.ForeColor = System.Drawing.Color.Black;
            this.rBtn_OnHelp.Location = new System.Drawing.Point(57, 33);
            this.rBtn_OnHelp.Name = "rBtn_OnHelp";
            this.rBtn_OnHelp.Size = new System.Drawing.Size(99, 23);
            this.rBtn_OnHelp.TabIndex = 1;
            this.rBtn_OnHelp.TabStop = true;
            this.rBtn_OnHelp.Text = "Включено";
            this.rBtn_OnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rBtn_OnHelp.UseVisualStyleBackColor = false;
            this.rBtn_OnHelp.CheckedChanged += new System.EventHandler(this.rBtn_OnHelp_CheckedChanged);
            // 
            // expPnl_StartGo
            // 
            this.expPnl_StartGo.CanvasColor = System.Drawing.SystemColors.Control;
            this.expPnl_StartGo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expPnl_StartGo.Controls.Add(this.radioBtn_GoWhite);
            this.expPnl_StartGo.Controls.Add(this.radioBtn_GoBlack);
            this.expPnl_StartGo.Dock = System.Windows.Forms.DockStyle.Top;
            this.expPnl_StartGo.HideControlsWhenCollapsed = true;
            this.expPnl_StartGo.Location = new System.Drawing.Point(1, 1);
            this.expPnl_StartGo.Name = "expPnl_StartGo";
            this.expPnl_StartGo.Size = new System.Drawing.Size(325, 67);
            this.expPnl_StartGo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expPnl_StartGo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expPnl_StartGo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expPnl_StartGo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expPnl_StartGo.Style.GradientAngle = 90;
            this.expPnl_StartGo.TabIndex = 0;
            this.expPnl_StartGo.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expPnl_StartGo.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expPnl_StartGo.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expPnl_StartGo.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expPnl_StartGo.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expPnl_StartGo.TitleStyle.GradientAngle = 90;
            this.expPnl_StartGo.TitleText = "Кто ходит первым";
            // 
            // radioBtn_GoWhite
            // 
            this.radioBtn_GoWhite.BackColor = System.Drawing.Color.Transparent;
            this.radioBtn_GoWhite.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtn_GoWhite.ForeColor = System.Drawing.Color.Black;
            this.radioBtn_GoWhite.Location = new System.Drawing.Point(162, 33);
            this.radioBtn_GoWhite.Name = "radioBtn_GoWhite";
            this.radioBtn_GoWhite.Size = new System.Drawing.Size(97, 23);
            this.radioBtn_GoWhite.TabIndex = 2;
            this.radioBtn_GoWhite.TabStop = true;
            this.radioBtn_GoWhite.Text = "Белые";
            this.radioBtn_GoWhite.UseVisualStyleBackColor = false;
            this.radioBtn_GoWhite.CheckedChanged += new System.EventHandler(this.radioBtn_GoBlack_CheckedChanged);
            // 
            // radioBtn_GoBlack
            // 
            this.radioBtn_GoBlack.BackColor = System.Drawing.Color.Transparent;
            this.radioBtn_GoBlack.Checked = true;
            this.radioBtn_GoBlack.ForeColor = System.Drawing.Color.Black;
            this.radioBtn_GoBlack.Location = new System.Drawing.Point(57, 33);
            this.radioBtn_GoBlack.Name = "radioBtn_GoBlack";
            this.radioBtn_GoBlack.Size = new System.Drawing.Size(99, 23);
            this.radioBtn_GoBlack.TabIndex = 1;
            this.radioBtn_GoBlack.TabStop = true;
            this.radioBtn_GoBlack.Text = "Черные";
            this.radioBtn_GoBlack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBtn_GoBlack.UseVisualStyleBackColor = false;
            this.radioBtn_GoBlack.CheckedChanged += new System.EventHandler(this.radioBtn_GoBlack_CheckedChanged);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Icon = ((System.Drawing.Icon)(resources.GetObject("tabItem1.Icon")));
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Игра";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.CanvasColor = System.Drawing.Color.Black;
            this.tabControlPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.tabControlPanel2.Controls.Add(this.microChart2);
            this.tabControlPanel2.Controls.Add(this.microChart1);
            this.tabControlPanel2.Controls.Add(this.lbl_vsegoIgr);
            this.tabControlPanel2.Controls.Add(this.lblWhite);
            this.tabControlPanel2.Controls.Add(this.lblBlack);
            this.tabControlPanel2.Controls.Add(this.lblPerWin);
            this.tabControlPanel2.Controls.Add(this.lblContineGame);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(327, 256);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // microChart2
            // 
            this.microChart2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.microChart2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.microChart2.DataMaxValue = 100;
            this.microChart2.DataMinValue = 0;
            this.microChart2.LineChartStyle.HighPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.microChart2.LineChartStyle.LineColor = System.Drawing.Color.White;
            this.microChart2.LineChartStyle.LowPointColor = System.Drawing.Color.Red;
            this.microChart2.Location = new System.Drawing.Point(181, 147);
            this.microChart2.Name = "microChart2";
            this.microChart2.Size = new System.Drawing.Size(94, 35);
            this.microChart2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.microChart2.TabIndex = 3;
            this.microChart2.Text = "microChart1";
            // 
            // microChart1
            // 
            this.microChart1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.microChart1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.microChart1.DataMaxValue = 100;
            this.microChart1.DataMinValue = 0;
            this.microChart1.LineChartStyle.ControlLine2Color = System.Drawing.Color.Blue;
            this.microChart1.LineChartStyle.HighPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.microChart1.LineChartStyle.LowPointColor = System.Drawing.Color.Red;
            this.microChart1.Location = new System.Drawing.Point(44, 147);
            this.microChart1.Name = "microChart1";
            this.microChart1.Size = new System.Drawing.Size(94, 35);
            this.microChart1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.microChart1.TabIndex = 3;
            // 
            // lbl_vsegoIgr
            // 
            this.lbl_vsegoIgr.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_vsegoIgr.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_vsegoIgr.Location = new System.Drawing.Point(148, 55);
            this.lbl_vsegoIgr.Name = "lbl_vsegoIgr";
            this.lbl_vsegoIgr.Size = new System.Drawing.Size(54, 34);
            this.lbl_vsegoIgr.TabIndex = 2;
            // 
            // lblWhite
            // 
            this.lblWhite.AutoSize = true;
            this.lblWhite.BackColor = System.Drawing.Color.Transparent;
            this.lblWhite.Location = new System.Drawing.Point(209, 185);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(40, 13);
            this.lblWhite.TabIndex = 1;
            this.lblWhite.Text = "Белые";
            // 
            // lblBlack
            // 
            this.lblBlack.AutoSize = true;
            this.lblBlack.BackColor = System.Drawing.Color.Transparent;
            this.lblBlack.Location = new System.Drawing.Point(66, 185);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(47, 13);
            this.lblBlack.TabIndex = 1;
            this.lblBlack.Text = "Черные";
            // 
            // lblPerWin
            // 
            this.lblPerWin.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPerWin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPerWin.Location = new System.Drawing.Point(47, 109);
            this.lblPerWin.Name = "lblPerWin";
            this.lblPerWin.SingleLineColor = System.Drawing.Color.Coral;
            this.lblPerWin.Size = new System.Drawing.Size(81, 34);
            this.lblPerWin.TabIndex = 0;
            this.lblPerWin.Text = "Процент побед:";
            // 
            // lblContineGame
            // 
            this.lblContineGame.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblContineGame.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblContineGame.Location = new System.Drawing.Point(47, 55);
            this.lblContineGame.Name = "lblContineGame";
            this.lblContineGame.SingleLineColor = System.Drawing.Color.Coral;
            this.lblContineGame.Size = new System.Drawing.Size(81, 34);
            this.lblContineGame.TabIndex = 0;
            this.lblContineGame.Text = "Сыграно игр:";
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Icon = ((System.Drawing.Icon)(resources.GetObject("tabItem2.Icon")));
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Статистика";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.groupBox_BoardSel);
            this.tabControlPanel5.Controls.Add(this.groupBox_FigSel);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(327, 256);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 5;
            this.tabControlPanel5.TabItem = this.tabItem_Style;
            // 
            // groupBox_BoardSel
            // 
            this.groupBox_BoardSel.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_BoardSel.Controls.Add(this.rb_BoardStyle_2);
            this.groupBox_BoardSel.Controls.Add(this.rb_BoardStyle_1);
            this.groupBox_BoardSel.Controls.Add(this.rb_BoardStyle_0);
            this.groupBox_BoardSel.Controls.Add(this.rb_BoardStyleDeff);
            this.groupBox_BoardSel.Controls.Add(this.reflectionImage4);
            this.groupBox_BoardSel.Controls.Add(this.reflectionImage3);
            this.groupBox_BoardSel.Controls.Add(this.reflectionImage2);
            this.groupBox_BoardSel.Controls.Add(this.reflectionImage1);
            this.groupBox_BoardSel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_BoardSel.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_BoardSel.Location = new System.Drawing.Point(1, 1);
            this.groupBox_BoardSel.Name = "groupBox_BoardSel";
            this.groupBox_BoardSel.Size = new System.Drawing.Size(325, 97);
            this.groupBox_BoardSel.TabIndex = 0;
            this.groupBox_BoardSel.TabStop = false;
            this.groupBox_BoardSel.Text = "Доска";
            // 
            // rb_BoardStyle_2
            // 
            this.rb_BoardStyle_2.AutoSize = true;
            this.rb_BoardStyle_2.Location = new System.Drawing.Point(275, 80);
            this.rb_BoardStyle_2.Name = "rb_BoardStyle_2";
            this.rb_BoardStyle_2.Size = new System.Drawing.Size(14, 13);
            this.rb_BoardStyle_2.TabIndex = 1;
            this.rb_BoardStyle_2.Tag = "3";
            this.rb_BoardStyle_2.UseVisualStyleBackColor = true;
            this.rb_BoardStyle_2.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // rb_BoardStyle_1
            // 
            this.rb_BoardStyle_1.AutoSize = true;
            this.rb_BoardStyle_1.Location = new System.Drawing.Point(197, 80);
            this.rb_BoardStyle_1.Name = "rb_BoardStyle_1";
            this.rb_BoardStyle_1.Size = new System.Drawing.Size(14, 13);
            this.rb_BoardStyle_1.TabIndex = 1;
            this.rb_BoardStyle_1.Tag = "2";
            this.rb_BoardStyle_1.UseVisualStyleBackColor = true;
            this.rb_BoardStyle_1.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // rb_BoardStyle_0
            // 
            this.rb_BoardStyle_0.AutoSize = true;
            this.rb_BoardStyle_0.Location = new System.Drawing.Point(114, 80);
            this.rb_BoardStyle_0.Name = "rb_BoardStyle_0";
            this.rb_BoardStyle_0.Size = new System.Drawing.Size(14, 13);
            this.rb_BoardStyle_0.TabIndex = 1;
            this.rb_BoardStyle_0.Tag = "1";
            this.rb_BoardStyle_0.UseVisualStyleBackColor = true;
            this.rb_BoardStyle_0.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // rb_BoardStyleDeff
            // 
            this.rb_BoardStyleDeff.AutoSize = true;
            this.rb_BoardStyleDeff.Checked = true;
            this.rb_BoardStyleDeff.Location = new System.Drawing.Point(31, 80);
            this.rb_BoardStyleDeff.Name = "rb_BoardStyleDeff";
            this.rb_BoardStyleDeff.Size = new System.Drawing.Size(14, 13);
            this.rb_BoardStyleDeff.TabIndex = 1;
            this.rb_BoardStyleDeff.TabStop = true;
            this.rb_BoardStyleDeff.Tag = "0";
            this.rb_BoardStyleDeff.UseVisualStyleBackColor = true;
            this.rb_BoardStyleDeff.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // reflectionImage4
            // 
            // 
            // 
            // 
            this.reflectionImage4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage4.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage4.Image = global::Шахматы.Properties.Resources.board2_mini;
            this.reflectionImage4.Location = new System.Drawing.Point(254, 25);
            this.reflectionImage4.Name = "reflectionImage4";
            this.reflectionImage4.Size = new System.Drawing.Size(55, 58);
            this.reflectionImage4.TabIndex = 0;
            this.reflectionImage4.Tag = "3";
            this.reflectionImage4.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // reflectionImage3
            // 
            // 
            // 
            // 
            this.reflectionImage3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage3.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage3.Image = global::Шахматы.Properties.Resources.board1_mini;
            this.reflectionImage3.Location = new System.Drawing.Point(177, 25);
            this.reflectionImage3.Name = "reflectionImage3";
            this.reflectionImage3.Size = new System.Drawing.Size(55, 58);
            this.reflectionImage3.TabIndex = 0;
            this.reflectionImage3.Tag = "2";
            this.reflectionImage3.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // reflectionImage2
            // 
            // 
            // 
            // 
            this.reflectionImage2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage2.Image = global::Шахматы.Properties.Resources.board_mini;
            this.reflectionImage2.Location = new System.Drawing.Point(95, 22);
            this.reflectionImage2.Name = "reflectionImage2";
            this.reflectionImage2.Size = new System.Drawing.Size(55, 58);
            this.reflectionImage2.TabIndex = 0;
            this.reflectionImage2.Tag = "1";
            this.reflectionImage2.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // reflectionImage1
            // 
            // 
            // 
            // 
            this.reflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage1.Image = global::Шахматы.Properties.Resources.board_deff_mini;
            this.reflectionImage1.Location = new System.Drawing.Point(13, 22);
            this.reflectionImage1.Name = "reflectionImage1";
            this.reflectionImage1.Size = new System.Drawing.Size(55, 58);
            this.reflectionImage1.TabIndex = 0;
            this.reflectionImage1.Tag = "0";
            this.reflectionImage1.Click += new System.EventHandler(this.rbSelectedBoadrType_Click);
            // 
            // groupBox_FigSel
            // 
            this.groupBox_FigSel.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_FigSel.Controls.Add(this.reflectionImage5);
            this.groupBox_FigSel.Controls.Add(this.ipnl_FigSwitch);
            this.groupBox_FigSel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_FigSel.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_FigSel.Location = new System.Drawing.Point(1, 110);
            this.groupBox_FigSel.Name = "groupBox_FigSel";
            this.groupBox_FigSel.Size = new System.Drawing.Size(325, 145);
            this.groupBox_FigSel.TabIndex = 0;
            this.groupBox_FigSel.TabStop = false;
            this.groupBox_FigSel.Text = "Фигуры";
            // 
            // reflectionImage5
            // 
            this.reflectionImage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.reflectionImage5.InitialImage = null;
            this.reflectionImage5.Location = new System.Drawing.Point(126, 22);
            this.reflectionImage5.Name = "reflectionImage5";
            this.reflectionImage5.Size = new System.Drawing.Size(183, 116);
            this.reflectionImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.reflectionImage5.TabIndex = 2;
            this.reflectionImage5.TabStop = false;
            // 
            // ipnl_FigSwitch
            // 
            // 
            // 
            // 
            this.ipnl_FigSwitch.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.ipnl_FigSwitch.BackgroundStyle.Class = "ItemPanel";
            this.ipnl_FigSwitch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipnl_FigSwitch.ContainerControlProcessDialogKey = true;
            this.ipnl_FigSwitch.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFig_Deff,
            this.btnFig_1,
            this.btnFig_2,
            this.lblInfoStyle});
            this.ipnl_FigSwitch.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.ipnl_FigSwitch.Location = new System.Drawing.Point(11, 22);
            this.ipnl_FigSwitch.Name = "ipnl_FigSwitch";
            this.ipnl_FigSwitch.Size = new System.Drawing.Size(109, 116);
            this.ipnl_FigSwitch.TabIndex = 1;
            // 
            // btnFig_Deff
            // 
            this.btnFig_Deff.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFig_Deff.Checked = true;
            this.btnFig_Deff.Image = global::Шахматы.Properties.Resources.btnFig_stok;
            this.btnFig_Deff.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnFig_Deff.Name = "btnFig_Deff";
            this.btnFig_Deff.OptionGroup = "SelectFigure";
            this.btnFig_Deff.Tag = "0";
            this.btnFig_Deff.Text = "Стоковые";
            this.btnFig_Deff.Click += new System.EventHandler(this.SelectedTypeFigures_Click);
            // 
            // btnFig_1
            // 
            this.btnFig_1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFig_1.Image = global::Шахматы.Properties.Resources.btnFig_autor;
            this.btnFig_1.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnFig_1.Name = "btnFig_1";
            this.btnFig_1.OptionGroup = "SelectFigure";
            this.btnFig_1.Tag = "1";
            this.btnFig_1.Text = "Авторские";
            this.btnFig_1.Click += new System.EventHandler(this.SelectedTypeFigures_Click);
            // 
            // btnFig_2
            // 
            this.btnFig_2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnFig_2.Image = global::Шахматы.Properties.Resources.btnFig_classic;
            this.btnFig_2.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnFig_2.Name = "btnFig_2";
            this.btnFig_2.OptionGroup = "SelectFigure";
            this.btnFig_2.Tag = "2";
            this.btnFig_2.Text = "Классика";
            this.btnFig_2.Click += new System.EventHandler(this.SelectedTypeFigures_Click);
            // 
            // lblInfoStyle
            // 
            this.lblInfoStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoStyle.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblInfoStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.lblInfoStyle.Name = "lblInfoStyle";
            this.lblInfoStyle.PaddingBottom = 1;
            this.lblInfoStyle.PaddingLeft = 1;
            this.lblInfoStyle.PaddingRight = 1;
            this.lblInfoStyle.PaddingTop = 1;
            this.lblInfoStyle.Text = "QwinCor Style";
            // 
            // tabItem_Style
            // 
            this.tabItem_Style.AttachedControl = this.tabControlPanel5;
            this.tabItem_Style.Icon = ((System.Drawing.Icon)(resources.GetObject("tabItem_Style.Icon")));
            this.tabItem_Style.Name = "tabItem_Style";
            this.tabItem_Style.Text = "Оформление";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.lblStartWritingKeyWhite);
            this.tabControlPanel3.Controls.Add(this.lblStartWritingKeyBlack);
            this.tabControlPanel3.Controls.Add(this.lblWhiteLeft);
            this.tabControlPanel3.Controls.Add(this.lblBlackLeft);
            this.tabControlPanel3.Controls.Add(this.lblWhiteRight);
            this.tabControlPanel3.Controls.Add(this.lblWhiteDown);
            this.tabControlPanel3.Controls.Add(this.lblBlackRight);
            this.tabControlPanel3.Controls.Add(this.lblWhiteUp);
            this.tabControlPanel3.Controls.Add(this.lblBlackDown);
            this.tabControlPanel3.Controls.Add(this.lblBlackUp);
            this.tabControlPanel3.Controls.Add(this.lblWhiteKey);
            this.tabControlPanel3.Controls.Add(this.lblBlackKey);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(327, 256);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // lblStartWritingKeyWhite
            // 
            this.lblStartWritingKeyWhite.BackColor = System.Drawing.Color.Transparent;
            this.lblStartWritingKeyWhite.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblStartWritingKeyWhite.BackgroundImage")));
            this.lblStartWritingKeyWhite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblStartWritingKeyWhite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblStartWritingKeyWhite.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.lblStartWritingKeyWhite.Location = new System.Drawing.Point(218, 128);
            this.lblStartWritingKeyWhite.Name = "lblStartWritingKeyWhite";
            this.lblStartWritingKeyWhite.Size = new System.Drawing.Size(32, 30);
            this.lblStartWritingKeyWhite.TabIndex = 2;
            this.lblStartWritingKeyWhite.BackgroundImageChanged += new System.EventHandler(this.lblStartWritingKeyBlack_BackgroundImageChanged);
            // 
            // lblStartWritingKeyBlack
            // 
            this.lblStartWritingKeyBlack.BackColor = System.Drawing.Color.Transparent;
            this.lblStartWritingKeyBlack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblStartWritingKeyBlack.BackgroundImage")));
            this.lblStartWritingKeyBlack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblStartWritingKeyBlack.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblStartWritingKeyBlack.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.lblStartWritingKeyBlack.Location = new System.Drawing.Point(69, 128);
            this.lblStartWritingKeyBlack.Name = "lblStartWritingKeyBlack";
            this.lblStartWritingKeyBlack.Size = new System.Drawing.Size(32, 30);
            this.lblStartWritingKeyBlack.TabIndex = 2;
            this.lblStartWritingKeyBlack.BackgroundImageChanged += new System.EventHandler(this.lblStartWritingKeyBlack_BackgroundImageChanged);
            // 
            // lblWhiteLeft
            // 
            this.lblWhiteLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblWhiteLeft.BackgroundImage")));
            this.lblWhiteLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblWhiteLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWhiteLeft.Location = new System.Drawing.Point(181, 128);
            this.lblWhiteLeft.Name = "lblWhiteLeft";
            this.lblWhiteLeft.Size = new System.Drawing.Size(31, 30);
            this.lblWhiteLeft.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblWhiteLeft, "A");
            this.lblWhiteLeft.Click += new System.EventHandler(this.whiteKeyChenged_Click);
            // 
            // lblBlackLeft
            // 
            this.lblBlackLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblBlackLeft.BackgroundImage")));
            this.lblBlackLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblBlackLeft.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBlackLeft.Location = new System.Drawing.Point(33, 128);
            this.lblBlackLeft.Name = "lblBlackLeft";
            this.lblBlackLeft.Size = new System.Drawing.Size(31, 30);
            this.lblBlackLeft.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblBlackLeft, "Left");
            this.lblBlackLeft.Click += new System.EventHandler(this.blackKeyChenged_Click);
            // 
            // lblWhiteRight
            // 
            this.lblWhiteRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblWhiteRight.BackgroundImage")));
            this.lblWhiteRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblWhiteRight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWhiteRight.Location = new System.Drawing.Point(255, 128);
            this.lblWhiteRight.Name = "lblWhiteRight";
            this.lblWhiteRight.Size = new System.Drawing.Size(31, 30);
            this.lblWhiteRight.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblWhiteRight, "D");
            this.lblWhiteRight.Click += new System.EventHandler(this.whiteKeyChenged_Click);
            // 
            // lblWhiteDown
            // 
            this.lblWhiteDown.BackgroundImage = global::Шахматы.Properties.Resources.Down;
            this.lblWhiteDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblWhiteDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWhiteDown.Location = new System.Drawing.Point(218, 163);
            this.lblWhiteDown.Name = "lblWhiteDown";
            this.lblWhiteDown.Size = new System.Drawing.Size(31, 30);
            this.lblWhiteDown.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblWhiteDown, "S");
            this.lblWhiteDown.Click += new System.EventHandler(this.whiteKeyChenged_Click);
            // 
            // lblBlackRight
            // 
            this.lblBlackRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblBlackRight.BackgroundImage")));
            this.lblBlackRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblBlackRight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBlackRight.Location = new System.Drawing.Point(107, 128);
            this.lblBlackRight.Name = "lblBlackRight";
            this.lblBlackRight.Size = new System.Drawing.Size(31, 30);
            this.lblBlackRight.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblBlackRight, "Right");
            this.lblBlackRight.Click += new System.EventHandler(this.blackKeyChenged_Click);
            // 
            // lblWhiteUp
            // 
            this.lblWhiteUp.BackgroundImage = global::Шахматы.Properties.Resources.Up;
            this.lblWhiteUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblWhiteUp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWhiteUp.Location = new System.Drawing.Point(218, 92);
            this.lblWhiteUp.Name = "lblWhiteUp";
            this.lblWhiteUp.Size = new System.Drawing.Size(31, 30);
            this.lblWhiteUp.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblWhiteUp, "W");
            this.lblWhiteUp.Click += new System.EventHandler(this.whiteKeyChenged_Click);
            // 
            // lblBlackDown
            // 
            this.lblBlackDown.BackgroundImage = global::Шахматы.Properties.Resources.Down;
            this.lblBlackDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblBlackDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBlackDown.Location = new System.Drawing.Point(70, 163);
            this.lblBlackDown.Name = "lblBlackDown";
            this.lblBlackDown.Size = new System.Drawing.Size(31, 30);
            this.lblBlackDown.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblBlackDown, "Down");
            this.lblBlackDown.Click += new System.EventHandler(this.blackKeyChenged_Click);
            // 
            // lblBlackUp
            // 
            this.lblBlackUp.BackgroundImage = global::Шахматы.Properties.Resources.Up;
            this.lblBlackUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.lblBlackUp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBlackUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.lblBlackUp.Location = new System.Drawing.Point(69, 92);
            this.lblBlackUp.Name = "lblBlackUp";
            this.lblBlackUp.Size = new System.Drawing.Size(31, 30);
            this.lblBlackUp.TabIndex = 1;
            this.toolTipForKeys.SetToolTip(this.lblBlackUp, "Up");
            this.lblBlackUp.Click += new System.EventHandler(this.blackKeyChenged_Click);
            // 
            // lblWhiteKey
            // 
            this.lblWhiteKey.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblWhiteKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWhiteKey.Location = new System.Drawing.Point(181, 60);
            this.lblWhiteKey.Name = "lblWhiteKey";
            this.lblWhiteKey.Size = new System.Drawing.Size(105, 21);
            this.lblWhiteKey.TabIndex = 0;
            this.lblWhiteKey.Text = "Белые";
            this.lblWhiteKey.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblBlackKey
            // 
            this.lblBlackKey.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblBlackKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBlackKey.Location = new System.Drawing.Point(33, 60);
            this.lblBlackKey.Name = "lblBlackKey";
            this.lblBlackKey.Size = new System.Drawing.Size(105, 21);
            this.lblBlackKey.TabIndex = 0;
            this.lblBlackKey.Text = "Черные";
            this.lblBlackKey.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Icon = ((System.Drawing.Icon)(resources.GetObject("tabItem3.Icon")));
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "Кнопки";
            // 
            // NastroikiManag
            // 
            this.NastroikiManag.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.NastroikiManag.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192))))), System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(47)))), ((int)(((byte)(37))))));
            // 
            // fMenu
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(327, 281);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fMenu_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            this.expPnl_KingShax.ResumeLayout(false);
            this.expPnl_Help.ResumeLayout(false);
            this.expPnl_StartGo.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.tabControlPanel5.ResumeLayout(false);
            this.groupBox_BoardSel.ResumeLayout(false);
            this.groupBox_BoardSel.PerformLayout();
            this.groupBox_FigSel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reflectionImage5)).EndInit();
            this.tabControlPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.ExpandablePanel expPnl_StartGo;
        private System.Windows.Forms.RadioButton radioBtn_GoWhite;
        private System.Windows.Forms.RadioButton radioBtn_GoBlack;
        private DevComponents.DotNetBar.ExpandablePanel expPnl_KingShax;
        private DevComponents.DotNetBar.ExpandablePanel expPnl_Help;
        private System.Windows.Forms.RadioButton rBtn_OffHelp;
        private System.Windows.Forms.RadioButton rBtn_OnHelp;
        private DevComponents.DotNetBar.LabelX lblContineGame;
        private System.Windows.Forms.RadioButton rBtn_OffShax;
        private System.Windows.Forms.RadioButton rBtn_OnShax;
        private System.Windows.Forms.Label lblBlack;
        private DevComponents.DotNetBar.LabelX lblPerWin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private System.Windows.Forms.Label lblWhite;
        private DevComponents.DotNetBar.LabelX lblBlackKey;
        private DevComponents.DotNetBar.LabelX lblWhiteLeft;
        private DevComponents.DotNetBar.LabelX lblBlackLeft;
        private DevComponents.DotNetBar.LabelX lblWhiteRight;
        private DevComponents.DotNetBar.LabelX lblWhiteDown;
        private DevComponents.DotNetBar.LabelX lblBlackRight;
        private DevComponents.DotNetBar.LabelX lblWhiteUp;
        private DevComponents.DotNetBar.LabelX lblBlackDown;
        private DevComponents.DotNetBar.LabelX lblBlackUp;
        private DevComponents.DotNetBar.LabelX lblWhiteKey;
        private DevComponents.DotNetBar.LabelX lblStartWritingKeyBlack;
        private DevComponents.DotNetBar.LabelX lblStartWritingKeyWhite;
        private System.Windows.Forms.ToolTip toolTipForKeys;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem About;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel lbl_vsegoIgr;
        private DevComponents.DotNetBar.MicroChart microChart2;
        private DevComponents.DotNetBar.MicroChart microChart1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevComponents.DotNetBar.StyleManager NastroikiManag;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItem_Style;
        private GroupBox groupBox_BoardSel;
        private GroupBox groupBox_FigSel;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage1;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage2;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage3;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage4;
        private RadioButton rb_BoardStyle_2;
        private RadioButton rb_BoardStyle_1;
        private RadioButton rb_BoardStyle_0;
        private RadioButton rb_BoardStyleDeff;
        private DevComponents.DotNetBar.ItemPanel ipnl_FigSwitch;
        private DevComponents.DotNetBar.ButtonItem btnFig_Deff;
        private DevComponents.DotNetBar.ButtonItem btnFig_1;
        private DevComponents.DotNetBar.ButtonItem btnFig_2;
        private DevComponents.DotNetBar.LabelItem lblInfoStyle;
        private PictureBox reflectionImage5;
    }
}