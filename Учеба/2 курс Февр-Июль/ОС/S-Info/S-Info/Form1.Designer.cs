namespace S_Info
{
    partial class fMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Metricks");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.listViewData = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.categoryPanelsData = new heaparessential.Controls.CategoryPanels();
            this.floatPanel4 = new heaparessential.Controls.FloatPanel();
            this.tableLayoutPanelTimeInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblForSysTime = new System.Windows.Forms.Label();
            this.lblCursorPos = new System.Windows.Forms.Label();
            this.activePanel1 = new heaparessential.Controls.ActivePanel();
            this.activePanel2 = new heaparessential.Controls.ActivePanel();
            this.checkBoxOnOffCursorPos = new System.Windows.Forms.CheckBox();
            this.floatPanel3 = new heaparessential.Controls.FloatPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelForPicture = new System.Windows.Forms.Panel();
            this.rBtnReset = new AdvButton.RoundButton();
            this.btnPic3 = new System.Windows.Forms.Button();
            this.btnPic2 = new System.Windows.Forms.Button();
            this.btnPic1 = new System.Windows.Forms.Button();
            this.groupBoxMouseSpeed = new System.Windows.Forms.GroupBox();
            this.rBtnResetMouseSpeed = new AdvButton.RoundButton();
            this.trackBarSpedMouse = new System.Windows.Forms.TrackBar();
            this.colorSelector1 = new heaparessential.Controls.ColorSelector();
            this.listViewGetSysColor = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.floatPanel2 = new heaparessential.Controls.FloatPanel();
            this.treeViewMetrick = new System.Windows.Forms.TreeView();
            this.floatPanel1 = new heaparessential.Controls.FloatPanel();
            this.FloatPanel = new heaparessential.Controls.FloatDesignPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.categoryPanelsData.SuspendLayout();
            this.floatPanel4.ControlsPanel.SuspendLayout();
            this.floatPanel4.SuspendLayout();
            this.tableLayoutPanelTimeInfo.SuspendLayout();
            this.activePanel2.SuspendLayout();
            this.floatPanel3.ControlsPanel.SuspendLayout();
            this.floatPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelForPicture.SuspendLayout();
            this.groupBoxMouseSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpedMouse)).BeginInit();
            this.floatPanel2.ControlsPanel.SuspendLayout();
            this.floatPanel2.SuspendLayout();
            this.floatPanel1.ControlsPanel.SuspendLayout();
            this.floatPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewData
            // 
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewData.FullRowSelect = true;
            this.listViewData.GridLines = true;
            this.listViewData.Location = new System.Drawing.Point(0, 0);
            this.listViewData.MultiSelect = false;
            this.listViewData.Name = "listViewData";
            this.listViewData.Scrollable = false;
            this.listViewData.Size = new System.Drawing.Size(535, 200);
            this.listViewData.TabIndex = 0;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Параметр";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значение";
            this.columnHeader2.Width = 330;
            // 
            // categoryPanelsData
            // 
            this.categoryPanelsData.AutoScroll = true;
            this.categoryPanelsData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoryPanelsData.Controls.Add(this.floatPanel4);
            this.categoryPanelsData.Controls.Add(this.floatPanel3);
            this.categoryPanelsData.Controls.Add(this.floatPanel2);
            this.categoryPanelsData.Controls.Add(this.floatPanel1);
            this.categoryPanelsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryPanelsData.Location = new System.Drawing.Point(0, 0);
            this.categoryPanelsData.Name = "categoryPanelsData";
            this.categoryPanelsData.Panels.AddRange(new heaparessential.Controls.FloatPanel[] {
            this.floatPanel1,
            this.floatPanel2,
            this.floatPanel3,
            this.floatPanel4});
            this.categoryPanelsData.Size = new System.Drawing.Size(537, 398);
            this.categoryPanelsData.TabIndex = 1;
            // 
            // floatPanel4
            // 
            // 
            // floatPanel4.FloatPanel
            // 
            this.floatPanel4.ControlsPanel.Controls.Add(this.tableLayoutPanelTimeInfo);
            this.floatPanel4.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floatPanel4.ControlsPanel.Location = new System.Drawing.Point(0, 22);
            this.floatPanel4.ControlsPanel.Name = "FloatPanel";
            this.floatPanel4.ControlsPanel.Size = new System.Drawing.Size(535, 108);
            this.floatPanel4.ControlsPanel.TabIndex = 1;
            this.floatPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.floatPanel4.Location = new System.Drawing.Point(0, 266);
            this.floatPanel4.Name = "floatPanel4";
            this.floatPanel4.Opened = true;
            this.floatPanel4.PanelHeight = 128;
            this.floatPanel4.Size = new System.Drawing.Size(535, 130);
            this.floatPanel4.TabIndex = 3;
            this.floatPanel4.Title = "Time Info";
            // 
            // tableLayoutPanelTimeInfo
            // 
            this.tableLayoutPanelTimeInfo.ColumnCount = 2;
            this.tableLayoutPanelTimeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTimeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTimeInfo.Controls.Add(this.lblForSysTime, 0, 0);
            this.tableLayoutPanelTimeInfo.Controls.Add(this.lblCursorPos, 1, 0);
            this.tableLayoutPanelTimeInfo.Controls.Add(this.activePanel1, 0, 1);
            this.tableLayoutPanelTimeInfo.Controls.Add(this.activePanel2, 1, 1);
            this.tableLayoutPanelTimeInfo.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanelTimeInfo.Name = "tableLayoutPanelTimeInfo";
            this.tableLayoutPanelTimeInfo.RowCount = 2;
            this.tableLayoutPanelTimeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.27472F));
            this.tableLayoutPanelTimeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.72527F));
            this.tableLayoutPanelTimeInfo.Size = new System.Drawing.Size(529, 91);
            this.tableLayoutPanelTimeInfo.TabIndex = 0;
            // 
            // lblForSysTime
            // 
            this.lblForSysTime.AutoSize = true;
            this.lblForSysTime.Location = new System.Drawing.Point(3, 0);
            this.lblForSysTime.Name = "lblForSysTime";
            this.lblForSysTime.Size = new System.Drawing.Size(0, 13);
            this.lblForSysTime.TabIndex = 0;
            // 
            // lblCursorPos
            // 
            this.lblCursorPos.AutoSize = true;
            this.lblCursorPos.Location = new System.Drawing.Point(267, 0);
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Size = new System.Drawing.Size(0, 13);
            this.lblCursorPos.TabIndex = 1;
            // 
            // activePanel1
            // 
            this.activePanel1.BottomTitle = "QwinCor 2014";
            this.activePanel1.BottomTitleOffset = new System.Drawing.Point(8, 8);
            this.activePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activePanel1.Location = new System.Drawing.Point(3, 25);
            this.activePanel1.Name = "activePanel1";
            this.activePanel1.Size = new System.Drawing.Size(258, 63);
            this.activePanel1.TabIndex = 3;
            this.activePanel1.TopTitleOffset = new System.Drawing.Point(8, 8);
            this.activePanel1.Click += new System.EventHandler(this.activePanel1_Click);
            // 
            // activePanel2
            // 
            this.activePanel2.BottomTitleOffset = new System.Drawing.Point(8, 8);
            this.activePanel2.Controls.Add(this.checkBoxOnOffCursorPos);
            this.activePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activePanel2.Location = new System.Drawing.Point(267, 25);
            this.activePanel2.Name = "activePanel2";
            this.activePanel2.Size = new System.Drawing.Size(259, 63);
            this.activePanel2.TabIndex = 4;
            this.activePanel2.TopTitleOffset = new System.Drawing.Point(8, 8);
            // 
            // checkBoxOnOffCursorPos
            // 
            this.checkBoxOnOffCursorPos.AutoSize = true;
            this.checkBoxOnOffCursorPos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBoxOnOffCursorPos.Location = new System.Drawing.Point(6, 3);
            this.checkBoxOnOffCursorPos.Name = "checkBoxOnOffCursorPos";
            this.checkBoxOnOffCursorPos.Size = new System.Drawing.Size(59, 17);
            this.checkBoxOnOffCursorPos.TabIndex = 2;
            this.checkBoxOnOffCursorPos.Text = "On\\Off";
            this.checkBoxOnOffCursorPos.UseVisualStyleBackColor = false;
            this.checkBoxOnOffCursorPos.CheckedChanged += new System.EventHandler(this.checkBoxOnOffCursorPos_CheckedChanged);
            // 
            // floatPanel3
            // 
            this.floatPanel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // floatPanel3.FloatPanel
            // 
            this.floatPanel3.ControlsPanel.Controls.Add(this.tableLayoutPanel1);
            this.floatPanel3.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floatPanel3.ControlsPanel.Location = new System.Drawing.Point(0, 22);
            this.floatPanel3.ControlsPanel.Name = "FloatPanel";
            this.floatPanel3.ControlsPanel.Size = new System.Drawing.Size(535, 0);
            this.floatPanel3.ControlsPanel.TabIndex = 1;
            this.floatPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.floatPanel3.Location = new System.Drawing.Point(0, 244);
            this.floatPanel3.Name = "floatPanel3";
            this.floatPanel3.Opened = false;
            this.floatPanel3.PanelHeight = 238;
            this.floatPanel3.Size = new System.Drawing.Size(535, 22);
            this.floatPanel3.TabIndex = 2;
            this.floatPanel3.Title = "Parametr Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panelForPicture, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxMouseSpeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorSelector1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewGetSysColor, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.34375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.65625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(535, 0);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelForPicture
            // 
            this.panelForPicture.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelForPicture.Controls.Add(this.rBtnReset);
            this.panelForPicture.Controls.Add(this.btnPic3);
            this.panelForPicture.Controls.Add(this.btnPic2);
            this.panelForPicture.Controls.Add(this.btnPic1);
            this.panelForPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForPicture.Location = new System.Drawing.Point(3, 3);
            this.panelForPicture.Name = "panelForPicture";
            this.panelForPicture.Size = new System.Drawing.Size(261, 1);
            this.panelForPicture.TabIndex = 0;
            // 
            // rBtnReset
            // 
            this.rBtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnReset.ColorGradient = ((byte)(2));
            this.rBtnReset.ColorStepGradient = ((byte)(2));
            this.rBtnReset.FadeOut = false;
            this.rBtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtnReset.HoverColor = System.Drawing.SystemColors.ControlDark;
            this.rBtnReset.Image = global::S_Info.Properties.Resources.Reset;
            this.rBtnReset.Location = new System.Drawing.Point(242, 3);
            this.rBtnReset.Name = "rBtnReset";
            this.rBtnReset.Size = new System.Drawing.Size(16, 16);
            this.rBtnReset.TabIndex = 3;
            this.rBtnReset.TextStartPoint = new System.Drawing.Point(0, 0);
            this.toolTip1.SetToolTip(this.rBtnReset, "Reset");
            this.rBtnReset.UseVisualStyleBackColor = true;
            this.rBtnReset.Click += new System.EventHandler(this.btnPic1_Click);
            // 
            // btnPic3
            // 
            this.btnPic3.Image = global::S_Info.Properties.Resources.ICONРассвет;
            this.btnPic3.Location = new System.Drawing.Point(171, 0);
            this.btnPic3.Name = "btnPic3";
            this.btnPic3.Size = new System.Drawing.Size(70, 57);
            this.btnPic3.TabIndex = 2;
            this.btnPic3.UseVisualStyleBackColor = true;
            this.btnPic3.Click += new System.EventHandler(this.btnPic1_Click);
            // 
            // btnPic2
            // 
            this.btnPic2.Image = global::S_Info.Properties.Resources.ICONIMAG0195;
            this.btnPic2.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPic2.Location = new System.Drawing.Point(95, 0);
            this.btnPic2.Name = "btnPic2";
            this.btnPic2.Size = new System.Drawing.Size(70, 57);
            this.btnPic2.TabIndex = 1;
            this.btnPic2.UseVisualStyleBackColor = true;
            this.btnPic2.Click += new System.EventHandler(this.btnPic1_Click);
            // 
            // btnPic1
            // 
            this.btnPic1.Image = global::S_Info.Properties.Resources.ICONA_корпус;
            this.btnPic1.Location = new System.Drawing.Point(19, 0);
            this.btnPic1.Name = "btnPic1";
            this.btnPic1.Size = new System.Drawing.Size(70, 57);
            this.btnPic1.TabIndex = 0;
            this.btnPic1.UseVisualStyleBackColor = true;
            this.btnPic1.Click += new System.EventHandler(this.btnPic1_Click);
            // 
            // groupBoxMouseSpeed
            // 
            this.groupBoxMouseSpeed.Controls.Add(this.rBtnResetMouseSpeed);
            this.groupBoxMouseSpeed.Controls.Add(this.trackBarSpedMouse);
            this.groupBoxMouseSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMouseSpeed.Location = new System.Drawing.Point(270, 3);
            this.groupBoxMouseSpeed.Name = "groupBoxMouseSpeed";
            this.groupBoxMouseSpeed.Size = new System.Drawing.Size(262, 1);
            this.groupBoxMouseSpeed.TabIndex = 2;
            this.groupBoxMouseSpeed.TabStop = false;
            this.groupBoxMouseSpeed.Text = "Mouse speed";
            // 
            // rBtnResetMouseSpeed
            // 
            this.rBtnResetMouseSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rBtnResetMouseSpeed.ColorGradient = ((byte)(2));
            this.rBtnResetMouseSpeed.ColorStepGradient = ((byte)(2));
            this.rBtnResetMouseSpeed.FadeOut = false;
            this.rBtnResetMouseSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtnResetMouseSpeed.HoverColor = System.Drawing.SystemColors.ControlDark;
            this.rBtnResetMouseSpeed.Image = global::S_Info.Properties.Resources.Reset;
            this.rBtnResetMouseSpeed.Location = new System.Drawing.Point(238, 12);
            this.rBtnResetMouseSpeed.Name = "rBtnResetMouseSpeed";
            this.rBtnResetMouseSpeed.Size = new System.Drawing.Size(16, 16);
            this.rBtnResetMouseSpeed.TabIndex = 4;
            this.rBtnResetMouseSpeed.TextStartPoint = new System.Drawing.Point(0, 0);
            this.toolTip1.SetToolTip(this.rBtnResetMouseSpeed, "Reset");
            this.rBtnResetMouseSpeed.UseVisualStyleBackColor = true;
            this.rBtnResetMouseSpeed.Click += new System.EventHandler(this.btnPic1_Click);
            // 
            // trackBarSpedMouse
            // 
            this.trackBarSpedMouse.Location = new System.Drawing.Point(6, 12);
            this.trackBarSpedMouse.Maximum = 19;
            this.trackBarSpedMouse.Name = "trackBarSpedMouse";
            this.trackBarSpedMouse.Size = new System.Drawing.Size(176, 45);
            this.trackBarSpedMouse.TabIndex = 1;
            this.trackBarSpedMouse.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.toolTip1.SetToolTip(this.trackBarSpedMouse, "Speed mouse");
            this.trackBarSpedMouse.Scroll += new System.EventHandler(this.trackBarSpedMouse_Scroll);
            // 
            // colorSelector1
            // 
            this.colorSelector1.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorSelector1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.colorSelector1.ForegroundColor = System.Drawing.SystemColors.ControlDark;
            this.colorSelector1.Location = new System.Drawing.Point(3, 3);
            this.colorSelector1.Name = "colorSelector1";
            this.colorSelector1.Size = new System.Drawing.Size(89, 1);
            this.colorSelector1.TabIndex = 3;
            this.colorSelector1.ForegroundColorChanged += new System.EventHandler(this.colorSelector1_ForegroundColorChanged);
            // 
            // listViewGetSysColor
            // 
            this.listViewGetSysColor.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewGetSysColor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewGetSysColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGetSysColor.FullRowSelect = true;
            this.listViewGetSysColor.GridLines = true;
            this.listViewGetSysColor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewGetSysColor.HoverSelection = true;
            this.listViewGetSysColor.Location = new System.Drawing.Point(270, 3);
            this.listViewGetSysColor.Name = "listViewGetSysColor";
            this.listViewGetSysColor.Size = new System.Drawing.Size(262, 1);
            this.listViewGetSysColor.TabIndex = 4;
            this.listViewGetSysColor.UseCompatibleStateImageBehavior = false;
            this.listViewGetSysColor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Системное имя";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Константа";
            this.columnHeader4.Width = 71;
            // 
            // floatPanel2
            // 
            // 
            // floatPanel2.FloatPanel
            // 
            this.floatPanel2.ControlsPanel.Controls.Add(this.treeViewMetrick);
            this.floatPanel2.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floatPanel2.ControlsPanel.Location = new System.Drawing.Point(0, 22);
            this.floatPanel2.ControlsPanel.Name = "FloatPanel";
            this.floatPanel2.ControlsPanel.Size = new System.Drawing.Size(535, 0);
            this.floatPanel2.ControlsPanel.TabIndex = 1;
            this.floatPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.floatPanel2.Location = new System.Drawing.Point(0, 222);
            this.floatPanel2.Name = "floatPanel2";
            this.floatPanel2.Opened = false;
            this.floatPanel2.PanelHeight = 228;
            this.floatPanel2.Size = new System.Drawing.Size(535, 22);
            this.floatPanel2.TabIndex = 1;
            this.floatPanel2.Title = "Metrick Info";
            // 
            // treeViewMetrick
            // 
            this.treeViewMetrick.AccessibleDescription = "";
            this.treeViewMetrick.AllowDrop = true;
            this.treeViewMetrick.CheckBoxes = true;
            this.treeViewMetrick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMetrick.Location = new System.Drawing.Point(0, 0);
            this.treeViewMetrick.Name = "treeViewMetrick";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Metricks";
            this.treeViewMetrick.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewMetrick.Size = new System.Drawing.Size(535, 0);
            this.treeViewMetrick.TabIndex = 0;
            this.treeViewMetrick.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMetrick_AfterSelect);
            // 
            // floatPanel1
            // 
            // 
            // floatPanel1.FloatPanel
            // 
            this.floatPanel1.ControlsPanel.Controls.Add(this.listViewData);
            this.floatPanel1.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floatPanel1.ControlsPanel.Location = new System.Drawing.Point(0, 22);
            this.floatPanel1.ControlsPanel.Name = "FloatPanel";
            this.floatPanel1.ControlsPanel.Size = new System.Drawing.Size(535, 200);
            this.floatPanel1.ControlsPanel.TabIndex = 1;
            this.floatPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.floatPanel1.Location = new System.Drawing.Point(0, 0);
            this.floatPanel1.Name = "floatPanel1";
            this.floatPanel1.Opened = true;
            this.floatPanel1.PanelHeight = 200;
            this.floatPanel1.Size = new System.Drawing.Size(535, 222);
            this.floatPanel1.TabIndex = 0;
            this.floatPanel1.Title = "System Info";
            // 
            // FloatPanel
            // 
            this.FloatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FloatPanel.Location = new System.Drawing.Point(0, 22);
            this.FloatPanel.Name = "FloatPanel";
            this.FloatPanel.Size = new System.Drawing.Size(518, 128);
            this.FloatPanel.TabIndex = 1;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 398);
            this.Controls.Add(this.categoryPanelsData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "S-Info";
            this.categoryPanelsData.ResumeLayout(false);
            this.floatPanel4.ControlsPanel.ResumeLayout(false);
            this.floatPanel4.ResumeLayout(false);
            this.tableLayoutPanelTimeInfo.ResumeLayout(false);
            this.tableLayoutPanelTimeInfo.PerformLayout();
            this.activePanel2.ResumeLayout(false);
            this.activePanel2.PerformLayout();
            this.floatPanel3.ControlsPanel.ResumeLayout(false);
            this.floatPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelForPicture.ResumeLayout(false);
            this.groupBoxMouseSpeed.ResumeLayout(false);
            this.groupBoxMouseSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpedMouse)).EndInit();
            this.floatPanel2.ControlsPanel.ResumeLayout(false);
            this.floatPanel2.ResumeLayout(false);
            this.floatPanel1.ControlsPanel.ResumeLayout(false);
            this.floatPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private heaparessential.Controls.CategoryPanels categoryPanelsData;
        private heaparessential.Controls.FloatPanel floatPanel1;
        private System.Windows.Forms.TreeView treeViewMetrick;
        private heaparessential.Controls.FloatPanel floatPanel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private heaparessential.Controls.FloatDesignPanel FloatPanel;
        private heaparessential.Controls.FloatPanel floatPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelForPicture;
        private System.Windows.Forms.Button btnPic1;
        private System.Windows.Forms.Button btnPic3;
        private System.Windows.Forms.Button btnPic2;
        private AdvButton.RoundButton rBtnReset;
        private System.Windows.Forms.TrackBar trackBarSpedMouse;
        private System.Windows.Forms.GroupBox groupBoxMouseSpeed;
        private AdvButton.RoundButton rBtnResetMouseSpeed;
        private heaparessential.Controls.ColorSelector colorSelector1;
        private System.Windows.Forms.ListView listViewGetSysColor;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private heaparessential.Controls.FloatPanel floatPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimeInfo;
        private System.Windows.Forms.Label lblForSysTime;
        private System.Windows.Forms.Label lblCursorPos;
        private System.Windows.Forms.CheckBox checkBoxOnOffCursorPos;
        private heaparessential.Controls.ActivePanel activePanel1;
        private heaparessential.Controls.ActivePanel activePanel2;

    }
}

