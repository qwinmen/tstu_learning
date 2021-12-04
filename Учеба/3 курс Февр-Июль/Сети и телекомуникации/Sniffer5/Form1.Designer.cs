namespace Sniffer5
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
            this.itemPanel_IpConteiner = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.switchBtn_OnSniff = new DevComponents.DotNetBar.SwitchButtonItem();
            this.labelItem_IP = new DevComponents.DotNetBar.LabelItem();
            this.itemContainer_SniffIP = new DevComponents.DotNetBar.ItemContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.advTree_IP = new DevComponents.AdvTree.AdvTree();
            this.col_Ver = new DevComponents.AdvTree.ColumnHeader();
            this.col_HeaderLen = new DevComponents.AdvTree.ColumnHeader();
            this.col_DiffServs = new DevComponents.AdvTree.ColumnHeader();
            this.col_TotlLen = new DevComponents.AdvTree.ColumnHeader();
            this.col_Identiff = new DevComponents.AdvTree.ColumnHeader();
            this.col_Flags = new DevComponents.AdvTree.ColumnHeader();
            this.col_FragOfst = new DevComponents.AdvTree.ColumnHeader();
            this.col_Ttl = new DevComponents.AdvTree.ColumnHeader();
            this.col_Protocl = new DevComponents.AdvTree.ColumnHeader();
            this.col_Src = new DevComponents.AdvTree.ColumnHeader();
            this.col_Source = new DevComponents.AdvTree.ColumnHeader();
            this.col_Destinat = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.textBox_Protocols = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_IP)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPanel_IpConteiner
            // 
            this.itemPanel_IpConteiner.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel_IpConteiner.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel_IpConteiner.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel_IpConteiner.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel_IpConteiner.ContainerControlProcessDialogKey = true;
            this.itemPanel_IpConteiner.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemPanel_IpConteiner.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer_SniffIP});
            this.itemPanel_IpConteiner.ItemSpacing = 3;
            this.itemPanel_IpConteiner.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel_IpConteiner.Location = new System.Drawing.Point(0, 0);
            this.itemPanel_IpConteiner.Name = "itemPanel_IpConteiner";
            this.itemPanel_IpConteiner.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.ApplicationScroll;
            this.itemPanel_IpConteiner.Size = new System.Drawing.Size(216, 188);
            this.itemPanel_IpConteiner.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.itemPanel_IpConteiner.TabIndex = 1;
            this.itemPanel_IpConteiner.Text = "itemPanel1";
            this.itemPanel_IpConteiner.TouchEnabled = false;
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer1.BackgroundStyle.BorderColorLightSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.itemContainer1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.FixedSize = new System.Drawing.Size(196, 23);
            this.itemContainer1.ItemSpacing = 3;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(196, 23);
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.switchBtn_OnSniff,
            this.labelItem_IP});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // switchBtn_OnSniff
            // 
            this.switchBtn_OnSniff.Name = "switchBtn_OnSniff";
            this.switchBtn_OnSniff.ValueChanged += new System.EventHandler(this.switchBtn_OnSniff_ValueChanged);
            // 
            // labelItem_IP
            // 
            this.labelItem_IP.Name = "labelItem_IP";
            this.labelItem_IP.Text = "IP:";
            // 
            // itemContainer_SniffIP
            // 
            // 
            // 
            // 
            this.itemContainer_SniffIP.BackgroundStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemContainer_SniffIP.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_SniffIP.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_SniffIP.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_SniffIP.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_SniffIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_SniffIP.BackgroundStyle.MarginBottom = 50;
            this.itemContainer_SniffIP.BackgroundStyle.PaddingLeft = 5;
            this.itemContainer_SniffIP.ItemSpacing = 3;
            this.itemContainer_SniffIP.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer_SniffIP.MinimumSize = new System.Drawing.Size(196, 23);
            this.itemContainer_SniffIP.Name = "itemContainer_SniffIP";
            // 
            // 
            // 
            this.itemContainer_SniffIP.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.advTree_IP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Protocols, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(216, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.54728F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.45272F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 188);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // advTree_IP
            // 
            this.advTree_IP.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree_IP.AllowDrop = true;
            this.advTree_IP.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree_IP.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree_IP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree_IP.Columns.Add(this.col_Ver);
            this.advTree_IP.Columns.Add(this.col_HeaderLen);
            this.advTree_IP.Columns.Add(this.col_DiffServs);
            this.advTree_IP.Columns.Add(this.col_TotlLen);
            this.advTree_IP.Columns.Add(this.col_Identiff);
            this.advTree_IP.Columns.Add(this.col_Flags);
            this.advTree_IP.Columns.Add(this.col_FragOfst);
            this.advTree_IP.Columns.Add(this.col_Ttl);
            this.advTree_IP.Columns.Add(this.col_Protocl);
            this.advTree_IP.Columns.Add(this.col_Src);
            this.advTree_IP.Columns.Add(this.col_Source);
            this.advTree_IP.Columns.Add(this.col_Destinat);
            this.advTree_IP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree_IP.DragDropEnabled = false;
            this.advTree_IP.DragDropNodeCopyEnabled = false;
            this.advTree_IP.GridLinesColor = System.Drawing.Color.Gray;
            this.advTree_IP.GridRowLines = true;
            this.advTree_IP.Location = new System.Drawing.Point(3, 3);
            this.advTree_IP.Name = "advTree_IP";
            this.advTree_IP.NodesConnector = this.nodeConnector1;
            this.advTree_IP.NodeStyle = this.elementStyle1;
            this.advTree_IP.PathSeparator = ";";
            this.advTree_IP.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.advTree_IP.Size = new System.Drawing.Size(449, 72);
            this.advTree_IP.Styles.Add(this.elementStyle1);
            this.advTree_IP.TabIndex = 0;
            this.advTree_IP.Text = "advTree1";
            this.advTree_IP.TouchEnabled = false;
            // 
            // col_Ver
            // 
            this.col_Ver.Name = "col_Ver";
            this.col_Ver.Text = "Версия";
            this.col_Ver.Tooltip = "Версия протокола";
            this.col_Ver.Width.Absolute = 150;
            this.col_Ver.Width.AutoSize = true;
            this.col_Ver.Width.AutoSizeMinHeader = true;
            // 
            // col_HeaderLen
            // 
            this.col_HeaderLen.Name = "col_HeaderLen";
            this.col_HeaderLen.Text = "Длина h";
            this.col_HeaderLen.Tooltip = "Длина заголовка";
            this.col_HeaderLen.Width.Absolute = 100;
            this.col_HeaderLen.Width.AutoSize = true;
            this.col_HeaderLen.Width.AutoSizeMinHeader = true;
            // 
            // col_DiffServs
            // 
            this.col_DiffServs.Name = "col_DiffServs";
            this.col_DiffServs.Text = "Сервис";
            this.col_DiffServs.Tooltip = "Тип сервиса ToS";
            this.col_DiffServs.Width.Absolute = 150;
            this.col_DiffServs.Width.AutoSize = true;
            this.col_DiffServs.Width.AutoSizeMinHeader = true;
            // 
            // col_TotlLen
            // 
            this.col_TotlLen.Name = "col_TotlLen";
            this.col_TotlLen.Text = "Длина t";
            this.col_TotlLen.Tooltip = "Общая длина";
            this.col_TotlLen.Width.Absolute = 150;
            this.col_TotlLen.Width.AutoSize = true;
            this.col_TotlLen.Width.AutoSizeMinHeader = true;
            // 
            // col_Identiff
            // 
            this.col_Identiff.Name = "col_Identiff";
            this.col_Identiff.Text = "Id";
            this.col_Identiff.Tooltip = "Идентификатор пакета";
            this.col_Identiff.Width.Absolute = 150;
            this.col_Identiff.Width.AutoSize = true;
            this.col_Identiff.Width.AutoSizeMinHeader = true;
            // 
            // col_Flags
            // 
            this.col_Flags.Name = "col_Flags";
            this.col_Flags.Text = "Флаг";
            this.col_Flags.Width.Absolute = 150;
            this.col_Flags.Width.AutoSize = true;
            this.col_Flags.Width.AutoSizeMinHeader = true;
            // 
            // col_FragOfst
            // 
            this.col_FragOfst.Name = "col_FragOfst";
            this.col_FragOfst.Text = "Смещение";
            this.col_FragOfst.Tooltip = "Смещение фрагмента";
            this.col_FragOfst.Width.Absolute = 150;
            this.col_FragOfst.Width.AutoSize = true;
            this.col_FragOfst.Width.AutoSizeMinHeader = true;
            // 
            // col_Ttl
            // 
            this.col_Ttl.Name = "col_Ttl";
            this.col_Ttl.Text = "Ttl";
            this.col_Ttl.Tooltip = "Время жизни пакета";
            this.col_Ttl.Width.Absolute = 150;
            this.col_Ttl.Width.AutoSize = true;
            this.col_Ttl.Width.AutoSizeMinHeader = true;
            // 
            // col_Protocl
            // 
            this.col_Protocl.Name = "col_Protocl";
            this.col_Protocl.Text = "Протокол";
            this.col_Protocl.Tooltip = "Тип протокола";
            this.col_Protocl.Width.Absolute = 150;
            this.col_Protocl.Width.AutoSize = true;
            this.col_Protocl.Width.AutoSizeMinHeader = true;
            // 
            // col_Src
            // 
            this.col_Src.Name = "col_Src";
            this.col_Src.Text = "Crs";
            this.col_Src.Tooltip = "Контрольная сумма";
            this.col_Src.Width.Absolute = 150;
            this.col_Src.Width.AutoSize = true;
            this.col_Src.Width.AutoSizeMinHeader = true;
            // 
            // col_Source
            // 
            this.col_Source.Name = "col_Source";
            this.col_Source.Text = "От IP";
            this.col_Source.Tooltip = "Адрес источника";
            this.col_Source.Width.Absolute = 150;
            this.col_Source.Width.AutoSize = true;
            this.col_Source.Width.AutoSizeMinHeader = true;
            // 
            // col_Destinat
            // 
            this.col_Destinat.Name = "col_Destinat";
            this.col_Destinat.Text = "Для IP";
            this.col_Destinat.Tooltip = "Адрес получателя";
            this.col_Destinat.Width.Absolute = 150;
            this.col_Destinat.Width.AutoSize = true;
            this.col_Destinat.Width.AutoSizeMinHeader = true;
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
            // textBox_Protocols
            // 
            this.textBox_Protocols.BackColor = System.Drawing.Color.DimGray;
            this.textBox_Protocols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Protocols.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Protocols.Location = new System.Drawing.Point(3, 81);
            this.textBox_Protocols.Multiline = true;
            this.textBox_Protocols.Name = "textBox_Protocols";
            this.textBox_Protocols.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Protocols.Size = new System.Drawing.Size(449, 104);
            this.textBox_Protocols.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 188);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.itemPanel_IpConteiner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sn5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_IP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemPanel itemPanel_IpConteiner;
        private DevComponents.DotNetBar.SwitchButtonItem switchBtn_OnSniff;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.LabelItem labelItem_IP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.AdvTree.AdvTree advTree_IP;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.TextBox textBox_Protocols;
        private DevComponents.AdvTree.ColumnHeader col_Ver;
        private DevComponents.AdvTree.ColumnHeader col_HeaderLen;
        private DevComponents.AdvTree.ColumnHeader col_DiffServs;
        private DevComponents.AdvTree.ColumnHeader col_TotlLen;
        private DevComponents.AdvTree.ColumnHeader col_Identiff;
        private DevComponents.AdvTree.ColumnHeader col_Flags;
        private DevComponents.AdvTree.ColumnHeader col_FragOfst;
        private DevComponents.AdvTree.ColumnHeader col_Ttl;
        private DevComponents.AdvTree.ColumnHeader col_Protocl;
        private DevComponents.AdvTree.ColumnHeader col_Src;
        private DevComponents.AdvTree.ColumnHeader col_Source;
        private DevComponents.AdvTree.ColumnHeader col_Destinat;
        private DevComponents.DotNetBar.ItemContainer itemContainer_SniffIP;
    }
}

