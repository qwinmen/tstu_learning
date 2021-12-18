namespace DataMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblStateConnect = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
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
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.metroTabPanel2 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.listViewEx2 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.listViewPoints = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.metroTabPanel3 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.label1 = new System.Windows.Forms.Label();
            this.label1_Итог = new System.Windows.Forms.Label();
            this.panel2_прут = new System.Windows.Forms.Panel();
            this.panel1_болт = new System.Windows.Forms.Panel();
            this.metroTabItem1 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItem2 = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.metroTabItemSearch = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.colorThemeButton = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem2 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.metroShell1.SuspendLayout();
            this.metroTabPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.metroTabPanel2.SuspendLayout();
            this.metroTabPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
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
            this.lblStateConnect,
            this.buttonItem1,
            this.textBoxItem1,
            this.buttonItem4});
            this.metroStatusBar1.Location = new System.Drawing.Point(0, 451);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(709, 21);
            this.metroStatusBar1.TabIndex = 0;
            this.metroStatusBar1.Text = "ОК";
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
            // buttonItem1
            // 
            this.buttonItem1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Загрузить новое";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // buttonItem4
            // 
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "ОК";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
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
            this.metroShell1.HelpButtonText = "Помощь";
            this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroTabItem1,
            this.metroTabItem2,
            this.metroTabItemSearch});
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(0, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.colorThemeButton,
            this.qatCustomizeItem2});
            this.metroShell1.SettingsButtonVisible = false;
            this.metroShell1.Size = new System.Drawing.Size(709, 450);
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
            this.metroShell1.HelpButtonClick += new System.EventHandler(this.metroShell1_HelpButtonClick);
            // 
            // metroTabPanel1
            // 
            this.metroTabPanel1.CanvasColor = System.Drawing.Color.Black;
            this.metroTabPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel1.Controls.Add(this.metroToolbar1);
            this.metroTabPanel1.Controls.Add(this.listViewEx1);
            this.metroTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel1.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroTabPanel1.Name = "metroTabPanel1";
            this.metroTabPanel1.Size = new System.Drawing.Size(709, 399);
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
            this.metroToolbar1.Size = new System.Drawing.Size(295, 25);
            this.metroToolbar1.TabIndex = 3;
            this.metroToolbar1.Text = "Меню";
            this.metroToolbar1.Visible = false;
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
            this.markAsPaidButton.Name = "markAsPaidButton";
            this.markAsPaidButton.Text = "Построить";
            this.markAsPaidButton.Tooltip = "Нарисовать график";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Очистить";
            this.buttonItem3.Tooltip = "Очистить экран";
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
            // 
            // listViewEx1
            // 
            this.listViewEx1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewEx1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx1.ForeColor = System.Drawing.Color.Black;
            this.listViewEx1.LargeImageList = this.imageList1;
            this.listViewEx1.Location = new System.Drawing.Point(0, 0);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(709, 399);
            this.listViewEx1.TabIndex = 4;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.ItemActivate += new System.EventHandler(this.listViewEx1_ItemActivate);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // metroTabPanel2
            // 
            this.metroTabPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel2.Controls.Add(this.listViewEx2);
            this.metroTabPanel2.Controls.Add(this.listViewPoints);
            this.metroTabPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel2.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel2.Name = "metroTabPanel2";
            this.metroTabPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel2.Size = new System.Drawing.Size(709, 399);
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
            // listViewEx2
            // 
            this.listViewEx2.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewEx2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx2.Border.Class = "ListViewBorder";
            this.listViewEx2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx2.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx2.ForeColor = System.Drawing.Color.Black;
            this.listViewEx2.LargeImageList = this.imageList2;
            this.listViewEx2.Location = new System.Drawing.Point(3, 0);
            this.listViewEx2.Name = "listViewEx2";
            this.listViewEx2.Size = new System.Drawing.Size(703, 396);
            this.listViewEx2.TabIndex = 1;
            this.listViewEx2.UseCompatibleStateImageBehavior = false;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
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
            this.listViewPoints.Size = new System.Drawing.Size(703, 396);
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
            this.metroTabPanel3.Controls.Add(this.labelX1);
            this.metroTabPanel3.Controls.Add(this.integerInput1);
            this.metroTabPanel3.Controls.Add(this.label1);
            this.metroTabPanel3.Controls.Add(this.label1_Итог);
            this.metroTabPanel3.Controls.Add(this.panel2_прут);
            this.metroTabPanel3.Controls.Add(this.panel1_болт);
            this.metroTabPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel3.Location = new System.Drawing.Point(0, 51);
            this.metroTabPanel3.Name = "metroTabPanel3";
            this.metroTabPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel3.Size = new System.Drawing.Size(709, 399);
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
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(312, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(95, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "погрешность, мм";
            // 
            // integerInput1
            // 
            this.integerInput1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.ForeColor = System.Drawing.Color.Black;
            this.integerInput1.Location = new System.Drawing.Point(226, 22);
            this.integerInput1.MaxValue = 10;
            this.integerInput1.MinValue = 0;
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.ShowUpDown = true;
            this.integerInput1.Size = new System.Drawing.Size(80, 20);
            this.integerInput1.TabIndex = 3;
            this.integerInput1.Value = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(226, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "Критерий выбора: минимальное количество отходов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1_Итог
            // 
            this.label1_Итог.BackColor = System.Drawing.Color.White;
            this.label1_Итог.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1_Итог.ForeColor = System.Drawing.Color.Black;
            this.label1_Итог.Location = new System.Drawing.Point(59, 197);
            this.label1_Итог.Name = "label1_Итог";
            this.label1_Итог.Size = new System.Drawing.Size(515, 188);
            this.label1_Итог.TabIndex = 1;
            this.label1_Итог.Text = "Ничего не выбрано";
            // 
            // panel2_прут
            // 
            this.panel2_прут.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panel2_прут.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2_прут.ForeColor = System.Drawing.Color.Black;
            this.panel2_прут.Location = new System.Drawing.Point(413, 22);
            this.panel2_прут.Name = "panel2_прут";
            this.panel2_прут.Size = new System.Drawing.Size(162, 148);
            this.panel2_прут.TabIndex = 0;
            // 
            // panel1_болт
            // 
            this.panel1_болт.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.panel1_болт.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1_болт.ForeColor = System.Drawing.Color.Black;
            this.panel1_болт.Location = new System.Drawing.Point(58, 22);
            this.panel1_болт.Name = "panel1_болт";
            this.panel1_болт.Size = new System.Drawing.Size(162, 148);
            this.panel1_болт.TabIndex = 0;
            // 
            // metroTabItem1
            // 
            this.metroTabItem1.Checked = true;
            this.metroTabItem1.Name = "metroTabItem1";
            this.metroTabItem1.Panel = this.metroTabPanel1;
            this.metroTabItem1.Text = "&ДЕТАЛИ";
            this.metroTabItem1.Tooltip = "Просмотр изделий";
            this.metroTabItem1.Click += new System.EventHandler(this.metroTabItem1_Click);
            // 
            // metroTabItem2
            // 
            this.metroTabItem2.Name = "metroTabItem2";
            this.metroTabItem2.Panel = this.metroTabPanel2;
            this.metroTabItem2.Text = "&ЗАГОТОВКИ";
            this.metroTabItem2.Tooltip = "Просмотр прутков";
            this.metroTabItem2.Click += new System.EventHandler(this.metroTabItem2_Click);
            // 
            // metroTabItemSearch
            // 
            this.metroTabItemSearch.Name = "metroTabItemSearch";
            this.metroTabItemSearch.Panel = this.metroTabPanel3;
            this.metroTabItemSearch.Text = "&КАТАЛОГ";
            this.metroTabItemSearch.Click += new System.EventHandler(this.metroTabItemSearch_Click);
            // 
            // colorThemeButton
            // 
            this.colorThemeButton.AutoExpandOnClick = true;
            this.colorThemeButton.CanCustomize = false;
            this.colorThemeButton.FixedSize = new System.Drawing.Size(16, 16);
            this.colorThemeButton.Icon = ((System.Drawing.Icon)(resources.GetObject("colorThemeButton.Icon")));
            this.colorThemeButton.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.colorThemeButton.Name = "colorThemeButton";
            this.colorThemeButton.NotificationMarkOffset = new System.Drawing.Point(0, 0);
            this.colorThemeButton.ShowSubItems = false;
            this.colorThemeButton.Tooltip = "Изменить тему";
            // 
            // qatCustomizeItem2
            // 
            this.qatCustomizeItem2.BeginGroup = true;
            this.qatCustomizeItem2.Name = "qatCustomizeItem2";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 473);
            this.Controls.Add(this.metroShell1);
            this.Controls.Add(this.metroStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "РПА: выбор заготовок";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.fMain_Resize);
            this.metroShell1.ResumeLayout(false);
            this.metroShell1.PerformLayout();
            this.metroTabPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.metroTabPanel2.ResumeLayout(false);
            this.metroTabPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.ButtonItem colorThemeButton;

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
        
        private System.Windows.Forms.ListView listViewPoints;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem_3To4;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx2;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label1_Итог;
        private System.Windows.Forms.Panel panel2_прут;
        private System.Windows.Forms.Panel panel1_болт;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput integerInput1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem2;
    }
}

