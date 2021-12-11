namespace Expromt
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.лапшаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.btn_ReactorA = new DevComponents.DotNetBar.ButtonItem();
            this.btn_ReactorB = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.btn_IzmelA = new DevComponents.DotNetBar.ButtonItem();
            this.btn_IzmelB = new DevComponents.DotNetBar.ButtonItem();
            this.btn_IzmelC = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
            this.btn_MagnitA = new DevComponents.DotNetBar.ButtonItem();
            this.btn_MagnitB = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
            this.btn_KonteinerA = new DevComponents.DotNetBar.ButtonItem();
            this.btn_KonteinerB = new DevComponents.DotNetBar.ButtonItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.открытьКартуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "План";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 373);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лапшаToolStripMenuItem,
            this.открытьКартуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 48);
            // 
            // лапшаToolStripMenuItem
            // 
            this.лапшаToolStripMenuItem.Name = "лапшаToolStripMenuItem";
            this.лапшаToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.лапшаToolStripMenuItem.Text = "Очистить поле";
            this.лапшаToolStripMenuItem.Click += new System.EventHandler(this.лапшаToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.itemPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(433, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 392);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Компоненты";
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer2,
            this.itemContainer3,
            this.itemContainer4});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(3, 16);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(105, 373);
            this.itemPanel1.TabIndex = 0;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.BackColor = System.Drawing.Color.AntiqueWhite;
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer1.ItemSpacing = 2;
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_ReactorA,
            this.btn_ReactorB});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.TitleText = "Реакторы";
            // 
            // btn_ReactorA
            // 
            this.btn_ReactorA.AutoCheckOnClick = true;
            this.btn_ReactorA.AutoCollapseOnClick = false;
            this.btn_ReactorA.CanCustomize = false;
            this.btn_ReactorA.Image = global::Expromt.Properties.Resources.ReactorA;
            this.btn_ReactorA.ImageAlt = global::Expromt.Properties.Resources.ReactorA;
            this.btn_ReactorA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_ReactorA.Name = "btn_ReactorA";
            this.btn_ReactorA.ShowSubItems = false;
            this.btn_ReactorA.Text = "Реактор А";
            this.btn_ReactorA.Tooltip = "Реактор А";
            this.btn_ReactorA.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // btn_ReactorB
            // 
            this.btn_ReactorB.AutoCheckOnClick = true;
            this.btn_ReactorB.AutoCollapseOnClick = false;
            this.btn_ReactorB.CanCustomize = false;
            this.btn_ReactorB.Image = global::Expromt.Properties.Resources.ReactorB;
            this.btn_ReactorB.ImageAlt = global::Expromt.Properties.Resources.ReactorB;
            this.btn_ReactorB.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_ReactorB.Name = "btn_ReactorB";
            this.btn_ReactorB.ShowSubItems = false;
            this.btn_ReactorB.Text = "Реактор B";
            this.btn_ReactorB.Tooltip = "Реактор B";
            this.btn_ReactorB.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.BackColor = System.Drawing.Color.Aquamarine;
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer2.Name = "itemContainer2";
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_IzmelA,
            this.btn_IzmelB,
            this.btn_IzmelC});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.TitleText = "Измельчители";
            // 
            // btn_IzmelA
            // 
            this.btn_IzmelA.AutoCheckOnClick = true;
            this.btn_IzmelA.AutoCollapseOnClick = false;
            this.btn_IzmelA.CanCustomize = false;
            this.btn_IzmelA.Image = global::Expromt.Properties.Resources.IzmelA;
            this.btn_IzmelA.ImageAlt = global::Expromt.Properties.Resources.IzmelA;
            this.btn_IzmelA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_IzmelA.Name = "btn_IzmelA";
            this.btn_IzmelA.ShowSubItems = false;
            this.btn_IzmelA.Text = "Измельчитель А";
            this.btn_IzmelA.Tooltip = "Измельчитель А";
            this.btn_IzmelA.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // btn_IzmelB
            // 
            this.btn_IzmelB.AutoCheckOnClick = true;
            this.btn_IzmelB.AutoCollapseOnClick = false;
            this.btn_IzmelB.CanCustomize = false;
            this.btn_IzmelB.Image = global::Expromt.Properties.Resources.IzmelB;
            this.btn_IzmelB.ImageAlt = global::Expromt.Properties.Resources.IzmelB;
            this.btn_IzmelB.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_IzmelB.Name = "btn_IzmelB";
            this.btn_IzmelB.ShowSubItems = false;
            this.btn_IzmelB.Text = "Измельчитель B";
            this.btn_IzmelB.Tooltip = "Измельчитель B";
            this.btn_IzmelB.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // btn_IzmelC
            // 
            this.btn_IzmelC.AutoCheckOnClick = true;
            this.btn_IzmelC.AutoCollapseOnClick = false;
            this.btn_IzmelC.CanCustomize = false;
            this.btn_IzmelC.Image = global::Expromt.Properties.Resources.IzmelC;
            this.btn_IzmelC.ImageAlt = global::Expromt.Properties.Resources.IzmelC;
            this.btn_IzmelC.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_IzmelC.Name = "btn_IzmelC";
            this.btn_IzmelC.ShowSubItems = false;
            this.btn_IzmelC.Text = "Измельчитель C";
            this.btn_IzmelC.Tooltip = "Измельчитель C";
            this.btn_IzmelC.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // itemContainer3
            // 
            // 
            // 
            // 
            this.itemContainer3.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer3.Name = "itemContainer3";
            this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_MagnitA,
            this.btn_MagnitB});
            // 
            // 
            // 
            this.itemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer3.TitleText = "Защита";
            // 
            // btn_MagnitA
            // 
            this.btn_MagnitA.AutoCheckOnClick = true;
            this.btn_MagnitA.AutoCollapseOnClick = false;
            this.btn_MagnitA.CanCustomize = false;
            this.btn_MagnitA.Image = global::Expromt.Properties.Resources.MagnitA;
            this.btn_MagnitA.ImageAlt = global::Expromt.Properties.Resources.MagnitA;
            this.btn_MagnitA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_MagnitA.Name = "btn_MagnitA";
            this.btn_MagnitA.ShowSubItems = false;
            this.btn_MagnitA.Text = "Магнит A";
            this.btn_MagnitA.Tooltip = "Магнит A";
            this.btn_MagnitA.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // btn_MagnitB
            // 
            this.btn_MagnitB.AutoCheckOnClick = true;
            this.btn_MagnitB.AutoCollapseOnClick = false;
            this.btn_MagnitB.CanCustomize = false;
            this.btn_MagnitB.Image = global::Expromt.Properties.Resources.MagnitB;
            this.btn_MagnitB.ImageAlt = global::Expromt.Properties.Resources.MagnitA;
            this.btn_MagnitB.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_MagnitB.Name = "btn_MagnitB";
            this.btn_MagnitB.ShowSubItems = false;
            this.btn_MagnitB.Text = "Магнит A";
            this.btn_MagnitB.Tooltip = "Магнит A";
            this.btn_MagnitB.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // itemContainer4
            // 
            // 
            // 
            // 
            this.itemContainer4.BackgroundStyle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.itemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer4.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer4.Name = "itemContainer4";
            this.itemContainer4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_KonteinerA,
            this.btn_KonteinerB});
            // 
            // 
            // 
            this.itemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer4.TitleText = "Контейнеры";
            // 
            // btn_KonteinerA
            // 
            this.btn_KonteinerA.AutoCheckOnClick = true;
            this.btn_KonteinerA.AutoCollapseOnClick = false;
            this.btn_KonteinerA.CanCustomize = false;
            this.btn_KonteinerA.Image = global::Expromt.Properties.Resources.KonteinerA;
            this.btn_KonteinerA.ImageAlt = global::Expromt.Properties.Resources.KonteinerA;
            this.btn_KonteinerA.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_KonteinerA.Name = "btn_KonteinerA";
            this.btn_KonteinerA.ShowSubItems = false;
            this.btn_KonteinerA.Text = "Контейнер А";
            this.btn_KonteinerA.Tooltip = "Контейнер А";
            this.btn_KonteinerA.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // btn_KonteinerB
            // 
            this.btn_KonteinerB.AutoCheckOnClick = true;
            this.btn_KonteinerB.AutoCollapseOnClick = false;
            this.btn_KonteinerB.CanCustomize = false;
            this.btn_KonteinerB.Image = global::Expromt.Properties.Resources.KonteinerB;
            this.btn_KonteinerB.ImageAlt = global::Expromt.Properties.Resources.KonteinerB;
            this.btn_KonteinerB.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Large;
            this.btn_KonteinerB.Name = "btn_KonteinerB";
            this.btn_KonteinerB.ShowSubItems = false;
            this.btn_KonteinerB.Text = "Контейнер B";
            this.btn_KonteinerB.Tooltip = "Контейнер B";
            this.btn_KonteinerB.CheckedChanged += new System.EventHandler(this.btn_ReactorA_CheckedChanged);
            // 
            // открытьКартуToolStripMenuItem
            // 
            this.открытьКартуToolStripMenuItem.Name = "открытьКартуToolStripMenuItem";
            this.открытьКартуToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.открытьКартуToolStripMenuItem.Text = "Открыть карту...";
            this.открытьКартуToolStripMenuItem.Click += new System.EventHandler(this.открытьКартуToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Трассировка";
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.ButtonItem btn_ReactorA;
        private DevComponents.DotNetBar.ItemContainer itemContainer2;
        private DevComponents.DotNetBar.ButtonItem btn_IzmelA;
        private DevComponents.DotNetBar.ButtonItem btn_IzmelB;
        private DevComponents.DotNetBar.ButtonItem btn_IzmelC;
        private DevComponents.DotNetBar.ButtonItem btn_ReactorB;
        private DevComponents.DotNetBar.ItemContainer itemContainer3;
        private DevComponents.DotNetBar.ButtonItem btn_MagnitA;
        private DevComponents.DotNetBar.ButtonItem btn_MagnitB;
        private DevComponents.DotNetBar.ItemContainer itemContainer4;
        private DevComponents.DotNetBar.ButtonItem btn_KonteinerA;
        private DevComponents.DotNetBar.ButtonItem btn_KonteinerB;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem лапшаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьКартуToolStripMenuItem;

    }
}

