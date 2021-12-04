namespace JulFest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDragDrop = new heaparessential.Controls.FloatPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxInptCod = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.heaparResizer1 = new heaparessential.Controls.HeaparResizer();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.heaparResizer2 = new heaparessential.Controls.HeaparResizer();
            this.advTree2 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.panel1.SuspendLayout();
            this.pnlDragDrop.ControlsPanel.SuspendLayout();
            this.pnlDragDrop.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pnlDragDrop);
            this.panel1.Controls.Add(this.textBoxX1);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 387);
            this.panel1.TabIndex = 0;
            // 
            // pnlDragDrop
            // 
            this.pnlDragDrop.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.pnlDragDrop.AllowDrop = true;
            this.pnlDragDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDragDrop.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlDragDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // pnlDragDrop.FloatPanel
            // 
            this.pnlDragDrop.ControlsPanel.AllowDrop = true;
            this.pnlDragDrop.ControlsPanel.Controls.Add(this.label1);
            this.pnlDragDrop.ControlsPanel.Controls.Add(this.checkBoxInptCod);
            this.pnlDragDrop.ControlsPanel.Controls.Add(this.radioButton2);
            this.pnlDragDrop.ControlsPanel.Controls.Add(this.label2);
            this.pnlDragDrop.ControlsPanel.Controls.Add(this.button1);
            this.pnlDragDrop.ControlsPanel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlDragDrop.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDragDrop.ControlsPanel.Location = new System.Drawing.Point(0, 22);
            this.pnlDragDrop.ControlsPanel.Name = "FloatPanel";
            this.pnlDragDrop.ControlsPanel.Size = new System.Drawing.Size(283, 68);
            this.pnlDragDrop.ControlsPanel.TabIndex = 1;
            this.pnlDragDrop.ControlsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseMove);
            this.pnlDragDrop.ControlsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseDown);
            this.pnlDragDrop.ControlsPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseUp);
            this.pnlDragDrop.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDragDrop.Location = new System.Drawing.Point(324, 292);
            this.pnlDragDrop.Name = "pnlDragDrop";
            this.pnlDragDrop.Opened = true;
            this.pnlDragDrop.PanelHeight = 70;
            this.pnlDragDrop.Size = new System.Drawing.Size(285, 92);
            this.pnlDragDrop.TabIndex = 9;
            this.pnlDragDrop.Title = "Info";
            this.pnlDragDrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseMove);
            this.pnlDragDrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseDown);
            this.pnlDragDrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDragDrop_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вход";
            // 
            // checkBoxInptCod
            // 
            this.checkBoxInptCod.AutoSize = true;
            this.checkBoxInptCod.Checked = true;
            this.checkBoxInptCod.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBoxInptCod.Location = new System.Drawing.Point(103, 14);
            this.checkBoxInptCod.Name = "checkBoxInptCod";
            this.checkBoxInptCod.Size = new System.Drawing.Size(57, 17);
            this.checkBoxInptCod.TabIndex = 7;
            this.checkBoxInptCod.TabStop = true;
            this.checkBoxInptCod.Text = "Сжать";
            this.checkBoxInptCod.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioButton2.Location = new System.Drawing.Point(103, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "Разжать";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(18, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выход";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(209, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxX1
            // 
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxX1.Location = new System.Drawing.Point(285, 150);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(327, 237);
            this.textBoxX1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Red;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(285, 145);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(327, 5);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInput.Location = new System.Drawing.Point(285, 0);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(327, 145);
            this.txtInput.TabIndex = 0;
            // 
            // heaparResizer1
            // 
            this.heaparResizer1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.heaparResizer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.heaparResizer1.Location = new System.Drawing.Point(0, 0);
            this.heaparResizer1.Name = "heaparResizer1";
            this.heaparResizer1.Size = new System.Drawing.Size(32, 4);
            this.heaparResizer1.Style = heaparessential.Controls.ResizerStyle.Vertical;
            this.heaparResizer1.TabIndex = 1;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.groupPanel1;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(279, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 387);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 10;
            this.expandableSplitter1.TabStop = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.DarkOrange;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Red;
            this.groupPanel1.Controls.Add(this.advTree2);
            this.groupPanel1.Controls.Add(this.heaparResizer2);
            this.groupPanel1.Controls.Add(this.advTree1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(279, 387);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(55)))), ((int)(((byte)(52)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 11;
            this.groupPanel1.Text = "Словарь";
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
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Top;
            this.advTree1.GridRowLines = true;
            this.advTree1.HScrollBarVisible = false;
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(273, 208);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.TouchEnabled = false;
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
            // heaparResizer2
            // 
            this.heaparResizer2.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.heaparResizer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.heaparResizer2.Location = new System.Drawing.Point(0, 208);
            this.heaparResizer2.Name = "heaparResizer2";
            this.heaparResizer2.Size = new System.Drawing.Size(273, 5);
            this.heaparResizer2.Style = heaparessential.Controls.ResizerStyle.Vertical;
            this.heaparResizer2.TabIndex = 1;
            this.heaparResizer2.Text = "heaparResizer2";
            // 
            // advTree2
            // 
            this.advTree2.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree2.AllowDrop = true;
            this.advTree2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree2.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree2.Columns.Add(this.columnHeader3);
            this.advTree2.Columns.Add(this.columnHeader4);
            this.advTree2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree2.GridRowLines = true;
            this.advTree2.HScrollBarVisible = false;
            this.advTree2.Location = new System.Drawing.Point(0, 213);
            this.advTree2.MultiNodeDragCountVisible = false;
            this.advTree2.MultiNodeDragDropAllowed = false;
            this.advTree2.Name = "advTree2";
            this.advTree2.NodesConnector = this.nodeConnector2;
            this.advTree2.NodeStyle = this.elementStyle2;
            this.advTree2.PathSeparator = ";";
            this.advTree2.Size = new System.Drawing.Size(273, 153);
            this.advTree2.Styles.Add(this.elementStyle2);
            this.advTree2.TabIndex = 2;
            this.advTree2.Text = "advTree2";
            this.advTree2.TouchEnabled = false;
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Символы";
            this.columnHeader1.Width.Absolute = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Количество";
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "Символы";
            this.columnHeader3.Width.Absolute = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "Цепочка";
            this.columnHeader4.Width.Absolute = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 387);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "JulFest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDragDrop.ControlsPanel.ResumeLayout(false);
            this.pnlDragDrop.ControlsPanel.PerformLayout();
            this.pnlDragDrop.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.Splitter splitter1;
        private heaparessential.Controls.FloatPanel pnlDragDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton checkBoxInptCod;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private heaparessential.Controls.HeaparResizer heaparResizer1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.AdvTree advTree2;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private heaparessential.Controls.HeaparResizer heaparResizer2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        
    }
}

