namespace Саня
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
            this.components = new System.ComponentModel.Container();
            this.txtInput = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bubbleBar1 = new DevComponents.DotNetBar.BubbleBar();
            this.bubbleBarTab1 = new DevComponents.DotNetBar.BubbleBarTab(this.components);
            this.bubbleButton1 = new DevComponents.DotNetBar.BubbleButton();
            this.checkBoxInptCod = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxInptDecd = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label1 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new DevComponents.DotNetBar.LabelX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.advTree2 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.elementStyle6 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle7 = new DevComponents.DotNetBar.ElementStyle();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // 
            // 
            this.txtInput.Border.Class = "TextBoxBorder";
            this.txtInput.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInput.Location = new System.Drawing.Point(3, 3);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(577, 91);
            this.txtInput.TabIndex = 0;
            // 
            // bubbleBar1
            // 
            this.bubbleBar1.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Top;
            this.bubbleBar1.AntiAlias = true;
            this.bubbleBar1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.bubbleBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bubbleBar1.ButtonBackAreaStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBar1.ButtonBackAreaStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderBottomWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.bubbleBar1.ButtonBackAreaStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderLeftWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderRightWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderTopWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingBottom = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingLeft = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingRight = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingTop = 3;
            this.bubbleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bubbleBar1.ImageSizeNormal = new System.Drawing.Size(24, 24);
            this.bubbleBar1.Location = new System.Drawing.Point(3, 94);
            this.bubbleBar1.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight;
            this.bubbleBar1.Name = "bubbleBar1";
            this.bubbleBar1.SelectedTab = this.bubbleBarTab1;
            this.bubbleBar1.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar1.Size = new System.Drawing.Size(577, 50);
            this.bubbleBar1.TabIndex = 1;
            this.bubbleBar1.Tabs.Add(this.bubbleBarTab1);
            this.bubbleBar1.Text = "bubbleBar1";
            // 
            // bubbleBarTab1
            // 
            this.bubbleBarTab1.BackColor = System.Drawing.Color.Khaki;
            this.bubbleBarTab1.BackColor2 = System.Drawing.SystemColors.InactiveCaptionText;
            this.bubbleBarTab1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bubbleBarTab1.Buttons.AddRange(new DevComponents.DotNetBar.BubbleButton[] {
            this.bubbleButton1});
            this.bubbleBarTab1.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBarTab1.LightBorderColor = System.Drawing.Color.Transparent;
            this.bubbleBarTab1.Name = "bubbleBarTab1";
            this.bubbleBarTab1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue;
            this.bubbleBarTab1.Text = "Меню";
            this.bubbleBarTab1.TextColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // bubbleButton1
            // 
            this.bubbleButton1.Image = global::Саня.Properties.Resources._48;
            this.bubbleButton1.ImageLarge = global::Саня.Properties.Resources._32;
            this.bubbleButton1.Name = "bubbleButton1";
            this.bubbleButton1.TooltipText = "Выполнить выбранное";
            this.bubbleButton1.Click += new DevComponents.DotNetBar.ClickEventHandler(this.bubbleButton1_Click);
            // 
            // checkBoxInptCod
            // 
            this.checkBoxInptCod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxInptCod.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxInptCod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxInptCod.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxInptCod.Checked = true;
            this.checkBoxInptCod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInptCod.CheckValue = "Y";
            this.checkBoxInptCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxInptCod.Location = new System.Drawing.Point(386, 100);
            this.checkBoxInptCod.Name = "checkBoxInptCod";
            this.checkBoxInptCod.Size = new System.Drawing.Size(78, 19);
            this.checkBoxInptCod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxInptCod.TabIndex = 2;
            this.checkBoxInptCod.Text = "Сжатие";
            this.checkBoxInptCod.TextColor = System.Drawing.Color.Yellow;
            // 
            // checkBoxInptDecd
            // 
            this.checkBoxInptDecd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxInptDecd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxInptDecd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxInptDecd.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxInptDecd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxInptDecd.Location = new System.Drawing.Point(485, 100);
            this.checkBoxInptDecd.Name = "checkBoxInptDecd";
            this.checkBoxInptDecd.Size = new System.Drawing.Size(78, 19);
            this.checkBoxInptDecd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxInptDecd.TabIndex = 2;
            this.checkBoxInptDecd.Text = "Восстановление";
            this.checkBoxInptDecd.TextColor = System.Drawing.Color.Yellow;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(6, 100);
            this.label1.Name = "label1";
            this.label1.SingleLineColor = System.Drawing.Color.NavajoWhite;
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.Symbol = "";
            this.label1.SymbolColor = System.Drawing.Color.Yellow;
            this.label1.TabIndex = 3;
            this.label1.Text = "bit";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(99, 100);
            this.label2.Name = "label2";
            this.label2.SingleLineColor = System.Drawing.Color.NavajoWhite;
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.Symbol = "";
            this.label2.SymbolColor = System.Drawing.Color.Yellow;
            this.label2.TabIndex = 3;
            this.label2.Text = "bit";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(3, 144);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.advTree2);
            this.splitContainer1.Size = new System.Drawing.Size(577, 137);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 4;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.advTree1.BackgroundStyle.BackgroundImage = global::Саня.Properties.Resources.matritsa;
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.ColumnsBackgroundStyle = this.elementStyle3;
            this.advTree1.ColumnStyleNormal = this.elementStyle5;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.advTree1.ForeColor = System.Drawing.Color.Yellow;
            this.advTree1.GridLinesColor = System.Drawing.Color.Yellow;
            this.advTree1.GridRowLines = true;
            this.advTree1.HScrollBarVisible = false;
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(289, 135);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.Styles.Add(this.elementStyle3);
            this.advTree1.Styles.Add(this.elementStyle4);
            this.advTree1.Styles.Add(this.elementStyle5);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "advTree1";
            this.advTree1.TileGroupLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.advTree1.TouchEnabled = false;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Yellow;
            // 
            // advTree2
            // 
            this.advTree2.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree2.AllowDrop = true;
            this.advTree2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree2.BackgroundStyle.BackgroundImage = global::Саня.Properties.Resources.matritsa;
            this.advTree2.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree2.Columns.Add(this.columnHeader3);
            this.advTree2.Columns.Add(this.columnHeader4);
            this.advTree2.ColumnsBackgroundStyle = this.elementStyle7;
            this.advTree2.ColumnStyleNormal = this.elementStyle6;
            this.advTree2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.advTree2.ForeColor = System.Drawing.Color.Yellow;
            this.advTree2.GridLinesColor = System.Drawing.Color.Yellow;
            this.advTree2.GridRowLines = true;
            this.advTree2.HScrollBarVisible = false;
            this.advTree2.Location = new System.Drawing.Point(0, 0);
            this.advTree2.MultiNodeDragCountVisible = false;
            this.advTree2.MultiNodeDragDropAllowed = false;
            this.advTree2.Name = "advTree2";
            this.advTree2.NodesConnector = this.nodeConnector2;
            this.advTree2.NodeStyle = this.elementStyle2;
            this.advTree2.PathSeparator = ";";
            this.advTree2.Size = new System.Drawing.Size(280, 135);
            this.advTree2.Styles.Add(this.elementStyle2);
            this.advTree2.Styles.Add(this.elementStyle6);
            this.advTree2.Styles.Add(this.elementStyle7);
            this.advTree2.TabIndex = 0;
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
            this.elementStyle2.TextColor = System.Drawing.Color.Yellow;
            // 
            // columnHeader1
            // 
            this.columnHeader1.CellsBackColor = System.Drawing.Color.Transparent;
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Символы";
            this.columnHeader1.Width.Absolute = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.StretchToFill = true;
            this.columnHeader2.Text = "Количество";
            this.columnHeader2.Width.Absolute = 150;
            // 
            // elementStyle3
            // 
            this.elementStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.elementStyle3.BackColorGradientAngle = 90;
            this.elementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderBottomWidth = 1;
            this.elementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderLeftWidth = 1;
            this.elementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderRightWidth = 1;
            this.elementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderTopWidth = 1;
            this.elementStyle3.CornerDiameter = 4;
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Description = "BlueLight";
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.PaddingBottom = 1;
            this.elementStyle3.PaddingLeft = 1;
            this.elementStyle3.PaddingRight = 1;
            this.elementStyle3.PaddingTop = 1;
            this.elementStyle3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.elementStyle4.BackColorGradientAngle = 90;
            this.elementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderBottomWidth = 1;
            this.elementStyle4.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderLeftWidth = 1;
            this.elementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderRightWidth = 1;
            this.elementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderTopWidth = 1;
            this.elementStyle4.CornerDiameter = 4;
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Description = "BlueLight";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            // 
            // elementStyle5
            // 
            this.elementStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle5.BackColorGradientAngle = 90;
            this.elementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderBottomWidth = 1;
            this.elementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderLeftWidth = 1;
            this.elementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderRightWidth = 1;
            this.elementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderTopWidth = 1;
            this.elementStyle5.CornerDiameter = 4;
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Description = "Blue";
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.PaddingBottom = 1;
            this.elementStyle5.PaddingLeft = 1;
            this.elementStyle5.PaddingRight = 1;
            this.elementStyle5.PaddingTop = 1;
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
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
            this.columnHeader4.StretchToFill = true;
            this.columnHeader4.Text = "Цепочка";
            this.columnHeader4.Width.Absolute = 150;
            // 
            // elementStyle6
            // 
            this.elementStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle6.BackColorGradientAngle = 90;
            this.elementStyle6.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderBottomWidth = 1;
            this.elementStyle6.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle6.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderLeftWidth = 1;
            this.elementStyle6.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderRightWidth = 1;
            this.elementStyle6.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderTopWidth = 1;
            this.elementStyle6.CornerDiameter = 4;
            this.elementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle6.Description = "Blue";
            this.elementStyle6.Name = "elementStyle6";
            this.elementStyle6.PaddingBottom = 1;
            this.elementStyle6.PaddingLeft = 1;
            this.elementStyle6.PaddingRight = 1;
            this.elementStyle6.PaddingTop = 1;
            this.elementStyle6.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle7
            // 
            this.elementStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.elementStyle7.BackColorGradientAngle = 90;
            this.elementStyle7.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderBottomWidth = 1;
            this.elementStyle7.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle7.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderLeftWidth = 1;
            this.elementStyle7.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderRightWidth = 1;
            this.elementStyle7.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderTopWidth = 1;
            this.elementStyle7.CornerDiameter = 4;
            this.elementStyle7.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle7.Description = "BlueLight";
            this.elementStyle7.Name = "elementStyle7";
            this.elementStyle7.PaddingBottom = 1;
            this.elementStyle7.PaddingLeft = 1;
            this.elementStyle7.PaddingRight = 1;
            this.elementStyle7.PaddingTop = 1;
            this.elementStyle7.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxX1.Location = new System.Drawing.Point(3, 281);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX1.Size = new System.Drawing.Size(577, 99);
            this.textBoxX1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::Саня.Properties.Resources.matritsa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(583, 383);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxInptDecd);
            this.Controls.Add(this.checkBoxInptCod);
            this.Controls.Add(this.bubbleBar1);
            this.Controls.Add(this.txtInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.Text = "<-=dZEN=->";
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtInput;
        private DevComponents.DotNetBar.BubbleBar bubbleBar1;
        private DevComponents.DotNetBar.BubbleBarTab bubbleBarTab1;
        private DevComponents.DotNetBar.BubbleButton bubbleButton1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxInptCod;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxInptDecd;
        private DevComponents.DotNetBar.LabelX label1;
        private DevComponents.DotNetBar.LabelX label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.AdvTree advTree2;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.DotNetBar.ElementStyle elementStyle6;
        private DevComponents.DotNetBar.ElementStyle elementStyle7;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
    }
}

