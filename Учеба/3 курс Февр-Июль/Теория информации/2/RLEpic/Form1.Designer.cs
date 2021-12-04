using System.Windows.Forms;

namespace RLEpic
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
            this.ribbonControlPanel = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.textBoxItem_Разд1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.textBoxItem_Разд2 = new DevComponents.DotNetBar.TextBoxItem();
            this.ribbonBarPodxodSjatia = new DevComponents.DotNetBar.RibbonBar();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBoxItem2 = new DevComponents.DotNetBar.CheckBoxItem();
            this.ribbonBarCompress = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItemSjatie = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemDekompress = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_LoadSjatoe = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.textBoxItem2 = new DevComponents.DotNetBar.TextBoxItem();
            this.ribbonBarSave = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.sliderItem_ШагСетки = new DevComponents.DotNetBar.SliderItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnLoad = new DevComponents.DotNetBar.ButtonItem();
            this.btnRandomImg = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBarCreatPict = new DevComponents.DotNetBar.RibbonBar();
            this.btnLastic = new DevComponents.DotNetBar.ButtonItem();
            this.btnKarandash = new DevComponents.DotNetBar.ButtonItem();
            this.btnClear = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItemAlgoritm = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItemVisual = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.bevel1 = new ClassLibrary1.Bevel();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ribbonControlPanel.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControlPanel
            // 
            // 
            // 
            // 
            this.ribbonControlPanel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControlPanel.Controls.Add(this.ribbonPanel2);
            this.ribbonControlPanel.Controls.Add(this.ribbonPanel1);
            this.ribbonControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControlPanel.Expanded = false;
            this.ribbonControlPanel.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItemAlgoritm,
            this.ribbonTabItemVisual});
            this.ribbonControlPanel.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlPanel.Name = "ribbonControlPanel";
            this.ribbonControlPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControlPanel.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControlPanel.Size = new System.Drawing.Size(578, 72);
            this.ribbonControlPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControlPanel.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControlPanel.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControlPanel.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControlPanel.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControlPanel.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControlPanel.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControlPanel.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControlPanel.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControlPanel.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControlPanel.SystemText.QatDialogOkButton = "OK";
            this.ribbonControlPanel.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControlPanel.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControlPanel.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControlPanel.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControlPanel.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControlPanel.TabGroupHeight = 14;
            this.ribbonControlPanel.TabIndex = 0;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar2);
            this.ribbonPanel1.Controls.Add(this.ribbonBarPodxodSjatia);
            this.ribbonPanel1.Controls.Add(this.ribbonBarCompress);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(578, 44);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            this.ribbonPanel1.Visible = false;
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem3,
            this.textBoxItem_Разд1,
            this.labelItem4,
            this.textBoxItem_Разд2});
            this.ribbonBar2.Location = new System.Drawing.Point(320, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(183, 41);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 2;
            this.ribbonBar2.Text = "Разделитель";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.PaddingLeft = 5;
            this.labelItem3.Text = "<КП>";
            // 
            // textBoxItem_Разд1
            // 
            this.textBoxItem_Разд1.MaxLength = 1;
            this.textBoxItem_Разд1.Name = "textBoxItem_Разд1";
            this.textBoxItem_Разд1.Text = " ";
            this.textBoxItem_Разд1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxItem_Разд1.TextBoxWidth = 35;
            this.textBoxItem_Разд1.Tooltip = "Первый разделитель";
            this.textBoxItem_Разд1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem_Разд1.TextChanged += new System.EventHandler(this.textBoxItem_Разд1_TextChanged);
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "<Знак>";
            // 
            // textBoxItem_Разд2
            // 
            this.textBoxItem_Разд2.MaxLength = 1;
            this.textBoxItem_Разд2.Name = "textBoxItem_Разд2";
            this.textBoxItem_Разд2.Text = " ";
            this.textBoxItem_Разд2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxItem_Разд2.TextBoxWidth = 35;
            this.textBoxItem_Разд2.Tooltip = "Второй разделитель";
            this.textBoxItem_Разд2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem_Разд2.TextChanged += new System.EventHandler(this.textBoxItem_Разд2_TextChanged);
            // 
            // ribbonBarPodxodSjatia
            // 
            this.ribbonBarPodxodSjatia.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarPodxodSjatia.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarPodxodSjatia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarPodxodSjatia.ContainerControlProcessDialogKey = true;
            this.ribbonBarPodxodSjatia.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarPodxodSjatia.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.checkBoxItem1,
            this.checkBoxItem2});
            this.ribbonBarPodxodSjatia.Location = new System.Drawing.Point(162, 0);
            this.ribbonBarPodxodSjatia.Name = "ribbonBarPodxodSjatia";
            this.ribbonBarPodxodSjatia.Size = new System.Drawing.Size(158, 41);
            this.ribbonBarPodxodSjatia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarPodxodSjatia.TabIndex = 1;
            this.ribbonBarPodxodSjatia.Text = "Вариант схемы";
            // 
            // 
            // 
            this.ribbonBarPodxodSjatia.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarPodxodSjatia.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // checkBoxItem1
            // 
            this.checkBoxItem1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxItem1.Checked = true;
            this.checkBoxItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxItem1.Name = "checkBoxItem1";
            this.checkBoxItem1.Text = "Вариант 1";
            this.checkBoxItem1.Tooltip = "Простой подход";
            this.checkBoxItem1.Click += new System.EventHandler(this.checkBoxItem1_Click);
            // 
            // checkBoxItem2
            // 
            this.checkBoxItem2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxItem2.Name = "checkBoxItem2";
            this.checkBoxItem2.Text = "Вариант 2";
            this.checkBoxItem2.Tooltip = "Мудреный вариант";
            this.checkBoxItem2.Click += new System.EventHandler(this.checkBoxItem2_Click);
            // 
            // ribbonBarCompress
            // 
            this.ribbonBarCompress.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarCompress.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarCompress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarCompress.ContainerControlProcessDialogKey = true;
            this.ribbonBarCompress.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarCompress.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItemSjatie,
            this.buttonItemDekompress,
            this.buttonItem3,
            this.buttonItem_LoadSjatoe});
            this.ribbonBarCompress.ItemSpacing = 3;
            this.ribbonBarCompress.Location = new System.Drawing.Point(3, 0);
            this.ribbonBarCompress.Name = "ribbonBarCompress";
            this.ribbonBarCompress.Size = new System.Drawing.Size(159, 41);
            this.ribbonBarCompress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarCompress.TabIndex = 0;
            this.ribbonBarCompress.Text = "&Compress";
            // 
            // 
            // 
            this.ribbonBarCompress.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarCompress.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItemSjatie
            // 
            this.buttonItemSjatie.Image = global::RLEpic.Properties.Resources.icondeposit;
            this.buttonItemSjatie.ImageAlt = global::RLEpic.Properties.Resources.icondeposit;
            this.buttonItemSjatie.ImagePaddingHorizontal = 18;
            this.buttonItemSjatie.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItemSjatie.ImageSmall = global::RLEpic.Properties.Resources.icondeposit;
            this.buttonItemSjatie.Name = "buttonItemSjatie";
            this.buttonItemSjatie.SubItemsExpandWidth = 14;
            this.buttonItemSjatie.Tooltip = "Сжатие";
            this.buttonItemSjatie.Click += new System.EventHandler(this.buttonItemSjatie_Click);
            // 
            // buttonItemDekompress
            // 
            this.buttonItemDekompress.Image = global::RLEpic.Properties.Resources.iconloot;
            this.buttonItemDekompress.ImagePaddingHorizontal = 18;
            this.buttonItemDekompress.Name = "buttonItemDekompress";
            this.buttonItemDekompress.SubItemsExpandWidth = 14;
            this.buttonItemDekompress.Text = "buttonItem2";
            this.buttonItemDekompress.Tooltip = "Восстановка";
            this.buttonItemDekompress.Click += new System.EventHandler(this.buttonItemDekompress_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ImagePaddingHorizontal = 18;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.SubItemsExpandWidth = 10;
            this.buttonItem3.Symbol = "";
            this.buttonItem3.Tooltip = "Сохранить сжатую последовательность";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem_LoadSjatoe
            // 
            this.buttonItem_LoadSjatoe.ImagePaddingHorizontal = 18;
            this.buttonItem_LoadSjatoe.Name = "buttonItem_LoadSjatoe";
            this.buttonItem_LoadSjatoe.SubItemsExpandWidth = 14;
            this.buttonItem_LoadSjatoe.Symbol = "";
            this.buttonItem_LoadSjatoe.Text = "buttonItem4";
            this.buttonItem_LoadSjatoe.Tooltip = "Загрузить сжатый файл";
            this.buttonItem_LoadSjatoe.Click += new System.EventHandler(this.buttonItem_LoadSjatoe_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar1);
            this.ribbonPanel2.Controls.Add(this.ribbonBarSave);
            this.ribbonPanel2.Controls.Add(this.ribbonBarCreatPict);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(578, 44);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.textBoxItem1,
            this.labelItem2,
            this.textBoxItem2});
            this.ribbonBar1.Location = new System.Drawing.Point(332, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(130, 41);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 2;
            this.ribbonBar1.Text = "Рабочая область";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "X:";
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.MaxLength = 4;
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.Text = "100";
            this.textBoxItem1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxItem1.TextBoxWidth = 40;
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem1.WatermarkText = "100";
            this.textBoxItem1.TextChanged += new System.EventHandler(this.textBoxItem1_TextChanged);
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "Y:";
            // 
            // textBoxItem2
            // 
            this.textBoxItem2.MaxLength = 4;
            this.textBoxItem2.Name = "textBoxItem2";
            this.textBoxItem2.Text = "100";
            this.textBoxItem2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxItem2.TextBoxWidth = 40;
            this.textBoxItem2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem2.WatermarkText = "100";
            this.textBoxItem2.TextChanged += new System.EventHandler(this.textBoxItem2_TextChanged);
            // 
            // ribbonBarSave
            // 
            this.ribbonBarSave.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarSave.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarSave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarSave.ContainerControlProcessDialogKey = true;
            this.ribbonBarSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarSave.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.btnSave,
            this.btnLoad,
            this.btnRandomImg});
            this.ribbonBarSave.Location = new System.Drawing.Point(162, 0);
            this.ribbonBarSave.Name = "ribbonBarSave";
            this.ribbonBarSave.Size = new System.Drawing.Size(170, 41);
            this.ribbonBarSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarSave.TabIndex = 1;
            this.ribbonBarSave.Text = "Опции холста";
            // 
            // 
            // 
            this.ribbonBarSave.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarSave.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem2
            // 
            this.buttonItem2.AutoExpandOnClick = true;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sliderItem_ШагСетки});
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "Сетка";
            // 
            // sliderItem_ШагСетки
            // 
            this.sliderItem_ШагСетки.Maximum = 30;
            this.sliderItem_ШагСетки.Minimum = 5;
            this.sliderItem_ШагСетки.Name = "sliderItem_ШагСетки";
            this.sliderItem_ШагСетки.Text = "Шаг 10";
            this.sliderItem_ШагСетки.Tooltip = "Размер ячеек";
            this.sliderItem_ШагСетки.Value = 10;
            this.sliderItem_ШагСетки.ValueChanged += new System.EventHandler(this.sliderItem_ШагСетки_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::RLEpic.Properties.Resources.btnSave;
            this.btnSave.ImagePaddingHorizontal = 18;
            this.btnSave.Name = "btnSave";
            this.btnSave.SubItemsExpandWidth = 14;
            this.btnSave.Text = "buttonItem3";
            this.btnSave.Tooltip = "Сохранить в файл";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::RLEpic.Properties.Resources.btnLoad;
            this.btnLoad.ImagePaddingHorizontal = 18;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.SubItemsExpandWidth = 14;
            this.btnLoad.Text = "buttonItem4";
            this.btnLoad.Tooltip = "Загрузить из файла";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRandomImg
            // 
            this.btnRandomImg.Image = global::RLEpic.Properties.Resources.btnRandomImg;
            this.btnRandomImg.ImagePaddingHorizontal = 18;
            this.btnRandomImg.Name = "btnRandomImg";
            this.btnRandomImg.SubItemsExpandWidth = 14;
            this.btnRandomImg.Text = "buttonItem3";
            this.btnRandomImg.Tooltip = "Сгенерировать рандомный рисунок";
            this.btnRandomImg.Click += new System.EventHandler(this.btnRandomImg_Click);
            // 
            // ribbonBarCreatPict
            // 
            this.ribbonBarCreatPict.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBarCreatPict.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarCreatPict.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarCreatPict.ContainerControlProcessDialogKey = true;
            this.ribbonBarCreatPict.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBarCreatPict.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnLastic,
            this.btnKarandash,
            this.btnClear});
            this.ribbonBarCreatPict.Location = new System.Drawing.Point(3, 0);
            this.ribbonBarCreatPict.Name = "ribbonBarCreatPict";
            this.ribbonBarCreatPict.Size = new System.Drawing.Size(159, 41);
            this.ribbonBarCreatPict.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarCreatPict.TabIndex = 0;
            this.ribbonBarCreatPict.Text = "Рисование";
            // 
            // 
            // 
            this.ribbonBarCreatPict.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarCreatPict.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnLastic
            // 
            this.btnLastic.Image = global::RLEpic.Properties.Resources.btnSterka1;
            this.btnLastic.ImagePaddingHorizontal = 34;
            this.btnLastic.Name = "btnLastic";
            this.btnLastic.SubItemsExpandWidth = 14;
            this.btnLastic.Text = "buttonItem2";
            this.btnLastic.Tooltip = "Ластик";
            this.btnLastic.Click += new System.EventHandler(this.btnLastic_Click);
            // 
            // btnKarandash
            // 
            this.btnKarandash.Image = global::RLEpic.Properties.Resources.btnKarandash;
            this.btnKarandash.ImagePaddingHorizontal = 34;
            this.btnKarandash.Name = "btnKarandash";
            this.btnKarandash.SubItemsExpandWidth = 14;
            this.btnKarandash.Text = "buttonItem2";
            this.btnKarandash.Tooltip = "Карандаш";
            this.btnKarandash.Click += new System.EventHandler(this.btnKarandash_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::RLEpic.Properties.Resources.btnClear;
            this.btnClear.ImagePaddingHorizontal = 34;
            this.btnClear.Name = "btnClear";
            this.btnClear.SubItemsExpandWidth = 14;
            this.btnClear.Text = "buttonItem2";
            this.btnClear.Tooltip = "Очистить холст";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ribbonTabItemAlgoritm
            // 
            this.ribbonTabItemAlgoritm.Name = "ribbonTabItemAlgoritm";
            this.ribbonTabItemAlgoritm.Panel = this.ribbonPanel1;
            this.ribbonTabItemAlgoritm.Text = "Алгоритм";
            // 
            // ribbonTabItemVisual
            // 
            this.ribbonTabItemVisual.Checked = true;
            this.ribbonTabItemVisual.Name = "ribbonTabItemVisual";
            this.ribbonTabItemVisual.Panel = this.ribbonPanel2;
            this.ribbonTabItemVisual.Text = "Отображение";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // bevel1
            // 
            this.bevel1.AutoScroll = true;
            this.bevel1.BevelLineStep = 15;
            this.bevel1.BevelShadowColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bevel1.BKarandash = '1';
            this.bevel1.BSterka = '0';
            this.bevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bevel1.KarandashColor = System.Drawing.Color.MediumVioletRed;
            this.bevel1.LastikColor = System.Drawing.SystemColors.ButtonFace;
            this.bevel1.Location = new System.Drawing.Point(0, 72);
            this.bevel1.Name = "bevel1";
            this.bevel1.Rejim = false;
            this.bevel1.Size = new System.Drawing.Size(578, 321);
            this.bevel1.TabIndex = 1;
            this.bevel1.MouseDownEvent += new ClassLibrary1.MouseDwnEventHandler(this.bevel1_MouseDownEvent);
            this.bevel1.MouseUpEvent += new ClassLibrary1.MouseUpEventHandler(this.bevel1_MouseUpEvent);
            this.bevel1.MouseMoveEvent += new ClassLibrary1.MouseMovEventHandler(this.bevel1_MouseMoveEvent);
            this.bevel1.CliclEvent += new ClassLibrary1.ClickEventHandler(this.bevel1_CliclEvent);
            // 
            // progressBarX1
            // 
            this.progressBarX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarX1.BackColor = System.Drawing.Color.Lime;
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.progressBarX1.BackgroundStyle.TextColor = System.Drawing.Color.Blue;
            this.progressBarX1.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.progressBarX1.ChunkColor = System.Drawing.Color.Red;
            this.progressBarX1.ChunkColor2 = System.Drawing.Color.Black;
            this.progressBarX1.Location = new System.Drawing.Point(445, 13);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(132, 10);
            this.progressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.progressBarX1.TabIndex = 3;
            this.progressBarX1.Text = "меньше - лучше";
            this.progressBarX1.TextVisible = true;
            this.toolTip1.SetToolTip(this.progressBarX1, "100");
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(578, 393);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.bevel1);
            this.Controls.Add(this.ribbonControlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RLEpic";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ribbonControlPanel.ResumeLayout(false);
            this.ribbonControlPanel.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControlPanel;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBarCompress;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItemAlgoritm;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItemVisual;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem buttonItemSjatie;
        private Panel panel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBarPodxodSjatia;
        private DevComponents.DotNetBar.ButtonItem buttonItemDekompress;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem2;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBarSave;
        private DevComponents.DotNetBar.RibbonBar ribbonBarCreatPict;
        private DevComponents.DotNetBar.ButtonItem btnLastic;
        private DevComponents.DotNetBar.ButtonItem btnKarandash;
        private DevComponents.DotNetBar.ButtonItem btnClear;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.SliderItem sliderItem_ШагСетки;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnLoad;
        private ClassLibrary1.Bevel bevel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem2;
        private DevComponents.DotNetBar.ButtonItem btnRandomImg;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem_Разд1;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem_Разд2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem_LoadSjatoe;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private ToolTip toolTip1;
    }
}

