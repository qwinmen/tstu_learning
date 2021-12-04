namespace GModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblStateConnect = new DevComponents.DotNetBar.LabelItem();
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroTabPanel1 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroToolbar1 = new DevComponents.DotNetBar.Metro.MetroToolbar();
            this.voidInvoiceButton = new DevComponents.DotNetBar.ButtonItem();
            this.addNoteButton = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.newInvoiceButton = new DevComponents.DotNetBar.ButtonItem();
            this.markAsPaidButton = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.switchButtonItem_3To4 = new DevComponents.DotNetBar.SwitchButtonItem();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.metroTabPanel2 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.listViewPoints = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.metroTabPanel3 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroTabItem1 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem2 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItemSearch = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.colorThemeButton = new DevComponents.DotNetBar.ButtonItem();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.metroShell1.SuspendLayout();
            this.metroTabPanel1.SuspendLayout();
            this.metroTabPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lblStateConnect});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 352);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(656, 21);
            this.metroStatusBar1.TabIndex = 0;
            this.metroStatusBar1.Text = "metroStatusBar1";
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "READY";
            // 
            // lblStateConnect
            // 
            this.lblStateConnect.BackColor = System.Drawing.Color.LightGreen;
            this.lblStateConnect.DividerStyle = true;
            this.lblStateConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStateConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblStateConnect.Height = 15;
            this.lblStateConnect.Name = "lblStateConnect";
            this.lblStateConnect.Text = "C";
            this.lblStateConnect.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblStateConnect.Tooltip = "Состояние подключения";
            this.lblStateConnect.Width = 15;
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Controls.Add(this.metroTabPanel1);
            this.metroShell1.Controls.Add(this.metroTabPanel2);
            this.metroShell1.Controls.Add(this.metroTabPanel3);
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroShell1.ForeColor = System.Drawing.Color.Black;
            this.metroShell1.HelpButtonText = null;
            this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTabItem1,
            this.metroTabItem2,
            this.metroTabItemSearch});
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(0, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.colorThemeButton});
            this.metroShell1.Size = new System.Drawing.Size(656, 351);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 1;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.Text = "metroShell1";
            this.metroShell1.SelectedTabChanged += new System.EventHandler(this.metroShell1_SelectedTabChanged);
            // 
            // metroTabPanel1
            // 
            this.metroTabPanel1.CanvasColor = System.Drawing.Color.Black;
            this.metroTabPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel1.Controls.Add(this.metroToolbar1);
            this.metroTabPanel1.Controls.Add(this.zedGraph);
            this.metroTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel1.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroTabPanel1.Name = "metroTabPanel1";
            this.metroTabPanel1.Size = new System.Drawing.Size(656, 300);
            // 
            // 
            // 
            this.metroTabPanel1.Style.BackColor = System.Drawing.Color.Aquamarine;
            this.metroTabPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel1.TabIndex = 1;
            // 
            // metroToolbar1
            // 
            this.metroToolbar1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.metroToolbar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroToolbar1.ContainerControlProcessDialogKey = true;
            this.metroToolbar1.ExpandDirection = DevComponents.DotNetBar.Metro.eExpandDirection.Top;
            this.metroToolbar1.ExtraItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.voidInvoiceButton,
            this.addNoteButton,
            this.buttonItem2});
            this.metroToolbar1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroToolbar1.ForeColor = System.Drawing.Color.Black;
            this.metroToolbar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.newInvoiceButton,
            this.markAsPaidButton,
            this.buttonItem3,
            this.switchButtonItem_3To4});
            this.metroToolbar1.Location = new System.Drawing.Point(136, 215);
            this.metroToolbar1.Name = "metroToolbar1";
            this.metroToolbar1.Size = new System.Drawing.Size(295, 52);
            this.metroToolbar1.TabIndex = 3;
            this.metroToolbar1.Text = "Меню";
            // 
            // voidInvoiceButton
            // 
            this.voidInvoiceButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.voidInvoiceButton.Name = "voidInvoiceButton";
            this.voidInvoiceButton.Text = "Структура";
            this.voidInvoiceButton.Tooltip = "Какая структура таблицы";
            // 
            // addNoteButton
            // 
            this.addNoteButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Text = "Удалить";
            this.addNoteButton.Tooltip = "Удалить выделенное";
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "Подключение";
            this.buttonItem2.Tooltip = "Информация";
            // 
            // newInvoiceButton
            // 
            this.newInvoiceButton.Name = "newInvoiceButton";
            this.newInvoiceButton.Tag = "update";
            this.newInvoiceButton.Tooltip = "Обновить запись";
            // 
            // markAsPaidButton
            // 
            this.markAsPaidButton.Image = global::GModel.Properties.Resources.edit;
            this.markAsPaidButton.Name = "markAsPaidButton";
            this.markAsPaidButton.Text = "Построить";
            this.markAsPaidButton.Tooltip = "Нарисовать график";
            this.markAsPaidButton.Click += new System.EventHandler(this.markAsPaidButton_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Image = global::GModel.Properties.Resources.delete;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Очистить";
            this.buttonItem3.Tooltip = "Очистить экран";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // switchButtonItem_3To4
            // 
            this.switchButtonItem_3To4.ButtonHeight = 16;
            this.switchButtonItem_3To4.ButtonWidth = 60;
            this.switchButtonItem_3To4.Margin.Left = 10;
            this.switchButtonItem_3To4.Name = "switchButtonItem_3To4";
            this.switchButtonItem_3To4.SwitchFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.switchButtonItem_3To4.SwitchWidth = 22;
            this.switchButtonItem_3To4.Tooltip = "Группы из точек по 3 или 4";
            this.switchButtonItem_3To4.Visible = false;
            this.switchButtonItem_3To4.ValueChanged += new System.EventHandler(this.switchButtonItem_3To4_ValueChanged);
            // 
            // zedGraph
            // 
            this.zedGraph.BackColor = System.Drawing.Color.White;
            this.zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraph.ForeColor = System.Drawing.Color.Black;
            this.zedGraph.Location = new System.Drawing.Point(0, 0);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Z)));
            this.zedGraph.ScrollGrace = 0;
            this.zedGraph.ScrollMaxX = 0;
            this.zedGraph.ScrollMaxY = 0;
            this.zedGraph.ScrollMaxY2 = 0;
            this.zedGraph.ScrollMinX = 0;
            this.zedGraph.ScrollMinY = 0;
            this.zedGraph.ScrollMinY2 = 0;
            this.zedGraph.Size = new System.Drawing.Size(656, 300);
            this.zedGraph.TabIndex = 4;
            this.zedGraph.ZoomModifierKeys = System.Windows.Forms.Keys.Down;
            this.zedGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraph_MouseClick);
            // 
            // metroTabPanel2
            // 
            this.metroTabPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel2.Controls.Add(this.listViewPoints);
            this.metroTabPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel2.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel2.Name = "metroTabPanel2";
            this.metroTabPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel2.Size = new System.Drawing.Size(656, 300);
            // 
            // 
            // 
            this.metroTabPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel2.TabIndex = 2;
            this.metroTabPanel2.Visible = false;
            // 
            // listViewPoints
            // 
            this.listViewPoints.BackColor = System.Drawing.Color.White;
            this.listViewPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPoints.ForeColor = System.Drawing.Color.Black;
            this.listViewPoints.FullRowSelect = true;
            this.listViewPoints.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPoints.Location = new System.Drawing.Point(3, 0);
            this.listViewPoints.MultiSelect = false;
            this.listViewPoints.Name = "listViewPoints";
            this.listViewPoints.Size = new System.Drawing.Size(650, 297);
            this.listViewPoints.TabIndex = 0;
            this.listViewPoints.UseCompatibleStateImageBehavior = false;
            this.listViewPoints.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 260;
            // 
            // metroTabPanel3
            // 
            this.metroTabPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel3.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel3.Name = "metroTabPanel3";
            this.metroTabPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel3.Size = new System.Drawing.Size(656, 300);
            // 
            // 
            // 
            this.metroTabPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel3.TabIndex = 3;
            this.metroTabPanel3.Visible = false;
            // 
            // metroTabItem1
            // 
            this.metroTabItem1.Checked = true;
            this.metroTabItem1.Name = "metroTabItem1";
            this.metroTabItem1.Panel = this.metroTabPanel1;
            this.metroTabItem1.Text = "&HOME";
            this.metroTabItem1.Tooltip = "Работа с графиком";
            this.metroTabItem1.Click += new System.EventHandler(this.metroTabItem1_Click);
            // 
            // metroTabItem2
            // 
            this.metroTabItem2.Name = "metroTabItem2";
            this.metroTabItem2.Panel = this.metroTabPanel2;
            this.metroTabItem2.Text = "VIEW";
            this.metroTabItem2.Tooltip = "Просмотр координат точек";
            this.metroTabItem2.Click += new System.EventHandler(this.metroTabItem2_Click);
            // 
            // metroTabItemSearch
            // 
            this.metroTabItemSearch.Name = "metroTabItemSearch";
            this.metroTabItemSearch.Panel = this.metroTabPanel3;
            this.metroTabItemSearch.Text = "SEARCH";
            // 
            // colorThemeButton
            // 
            this.colorThemeButton.AutoExpandOnClick = true;
            this.colorThemeButton.CanCustomize = false;
            this.colorThemeButton.FixedSize = new System.Drawing.Size(16, 16);
            this.colorThemeButton.Image = global::GModel.Properties.Resources.tema;
            this.colorThemeButton.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.colorThemeButton.Name = "colorThemeButton";
            this.colorThemeButton.NotificationMarkOffset = new System.Drawing.Point(0, 0);
            this.colorThemeButton.ShowSubItems = false;
            this.colorThemeButton.Tooltip = "Изменить тему";
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.BeginGroup = true;
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = true;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = true;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 374);
            this.Controls.Add(this.metroShell1);
            this.Controls.Add(this.metroStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Геометрическое моделирование";
            this.Resize += new System.EventHandler(this.fMain_Resize);
            this.metroShell1.ResumeLayout(false);
            this.metroShell1.PerformLayout();
            this.metroTabPanel1.ResumeLayout(false);
            this.metroTabPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.ButtonItem colorThemeButton;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel1;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItemSearch;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel3;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel2;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.Metro.MetroTabItem metroTabItem2;
        private DevComponents.DotNetBar.Metro.MetroToolbar metroToolbar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem markAsPaidButton;
        private DevComponents.DotNetBar.ButtonItem newInvoiceButton;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem addNoteButton;
        private DevComponents.DotNetBar.ButtonItem voidInvoiceButton;
        private DevComponents.DotNetBar.LabelItem lblStateConnect;
        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.ListView listViewPoints;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem_3To4;
        
    }
}

