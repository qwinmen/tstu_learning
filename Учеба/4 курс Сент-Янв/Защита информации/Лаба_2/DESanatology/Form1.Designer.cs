namespace DESanatology
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
            this.textBox_Out = new System.Windows.Forms.TextBox();
            this.textBox_In = new System.Windows.Forms.TextBox();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.switchButtonItem_GoCript = new DevComponents.DotNetBar.SwitchButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.textBoxItem_Key = new DevComponents.DotNetBar.TextBoxItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Out
            // 
            this.textBox_Out.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_Out.Location = new System.Drawing.Point(0, 200);
            this.textBox_Out.Multiline = true;
            this.textBox_Out.Name = "textBox_Out";
            this.textBox_Out.ReadOnly = true;
            this.textBox_Out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Out.Size = new System.Drawing.Size(444, 121);
            this.textBox_Out.TabIndex = 0;
            // 
            // textBox_In
            // 
            this.textBox_In.BackColor = System.Drawing.Color.Azure;
            this.textBox_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_In.Location = new System.Drawing.Point(0, 74);
            this.textBox_In.Multiline = true;
            this.textBox_In.Name = "textBox_In";
            this.textBox_In.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_In.Size = new System.Drawing.Size(444, 123);
            this.textBox_In.TabIndex = 1;
            this.textBox_In.TextChanged += new System.EventHandler(this.textBox_In_TextChanged);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AntiAlias = false;
            this.ribbonControl1.AutoKeyboardExpand = false;
            this.ribbonControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CanCustomize = false;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.DefaultGroupFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.EnableQatPlacement = false;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1});
            this.ribbonControl1.KeyTipsEnabled = false;
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MdiSystemItemVisible = false;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(444, 74);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 2;
            this.ribbonControl1.Text = "ribbonControl1";
            this.ribbonControl1.UseCustomizeDialog = false;
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.AntiAlias = false;
            this.ribbonPanel1.CanvasColor = System.Drawing.Color.YellowGreen;
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar2);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(444, 48);
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
            this.ribbonBar2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.switchButtonItem_GoCript});
            this.ribbonBar2.Location = new System.Drawing.Point(143, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(115, 45);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 1;
            this.ribbonBar2.Text = "Режим";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // switchButtonItem_GoCript
            // 
            this.switchButtonItem_GoCript.Name = "switchButtonItem_GoCript";
            this.switchButtonItem_GoCript.OffText = "-> 01";
            this.switchButtonItem_GoCript.OnText = "a <-";
            this.switchButtonItem_GoCript.TextVisible = false;
            this.switchButtonItem_GoCript.ValueChanged += new System.EventHandler(this.switchButtonItem_GoCript_ValueChanged);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackgroundImage = global::DESanatology.Properties.Resources.kRes;
            this.ribbonBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.ribbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBoxItem_Key});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.OverflowButtonImage = global::DESanatology.Properties.Resources.kRes;
            this.ribbonBar1.ResizeItemsToFit = false;
            this.ribbonBar1.Size = new System.Drawing.Size(140, 45);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Ключ";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // textBoxItem_Key
            // 
            this.textBoxItem_Key.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.textBoxItem_Key.MaxLength = 16;
            this.textBoxItem_Key.Name = "textBoxItem_Key";
            this.textBoxItem_Key.ShowSubItems = false;
            this.textBoxItem_Key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxItem_Key.TextBoxHeight = 22;
            this.textBoxItem_Key.TextBoxWidth = 120;
            this.textBoxItem_Key.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem_Key.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxItem_Key.WatermarkImage = global::DESanatology.Properties.Resources.kRes1;
            this.textBoxItem_Key.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.textBoxItem_Key.WatermarkText = "Key";
            this.textBoxItem_Key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxItem_Key_KeyPress);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "Параметры";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 197);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(444, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 321);
            this.Controls.Add(this.textBox_In);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.textBox_Out);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Anatology DES";
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Out;
        private System.Windows.Forms.TextBox textBox_In;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.SwitchButtonItem switchButtonItem_GoCript;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem_Key;
        private System.Windows.Forms.Splitter splitter1;
    }
}

