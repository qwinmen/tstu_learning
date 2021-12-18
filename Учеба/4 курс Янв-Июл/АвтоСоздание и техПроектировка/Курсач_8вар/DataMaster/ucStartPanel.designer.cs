namespace GModel
{
    partial class ucStartPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.mtiLagranj = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.mtiBese = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.mtiArmitt = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.lblxCorp = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            this.itemPanel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.Location = new System.Drawing.Point(20, 106);
            this.itemPanel1.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.itemPanel1.Size = new System.Drawing.Size(609, 148);
            this.itemPanel1.TabIndex = 0;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer1.ItemSpacing = 30;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.mtiLagranj,
            this.mtiBese,
            this.mtiArmitt});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.TitleStyle.MarginTop = 20;
            this.itemContainer1.TitleStyle.PaddingTop = 20;
            // 
            // mtiLagranj
            // 
            this.mtiLagranj.Name = "mtiLagranj";
            this.mtiLagranj.SymbolColor = System.Drawing.Color.Empty;
            this.mtiLagranj.Text = "<font size=\"+4\">База  данных\r\n<br/>Детали\r\n</font>";
            this.mtiLagranj.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.mtiLagranj.TileSize = new System.Drawing.Size(180, 110);
            // 
            // 
            // 
            this.mtiLagranj.TileStyle.BackgroundImage = global::DataMaster.Properties.Resources.fArtD;
            this.mtiLagranj.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mtiLagranj.TitleText = "Подробнее..";
            this.mtiLagranj.TitleTextColor = System.Drawing.SystemColors.HighlightText;
            // 
            // mtiBese
            // 
            this.mtiBese.Name = "mtiBese";
            this.mtiBese.SymbolColor = System.Drawing.Color.Empty;
            this.mtiBese.Text = "<font size=\"+4\">База данных<br/>Заготовки</font>";
            this.mtiBese.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.mtiBese.TileSize = new System.Drawing.Size(180, 110);
            // 
            // 
            // 
            this.mtiBese.TileStyle.BackgroundImage = global::DataMaster.Properties.Resources.fArtZagg;
            this.mtiBese.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mtiBese.TitleText = "Подробнее..";
            // 
            // mtiArmitt
            // 
            this.mtiArmitt.Name = "mtiArmitt";
            this.mtiArmitt.SymbolColor = System.Drawing.Color.Empty;
            this.mtiArmitt.Text = "<font size=\"+4\">Каталог</font>";
            this.mtiArmitt.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.mtiArmitt.TileSize = new System.Drawing.Size(180, 110);
            // 
            // 
            // 
            this.mtiArmitt.TileStyle.BackgroundImage = global::DataMaster.Properties.Resources.fArtCat;
            this.mtiArmitt.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mtiArmitt.TitleText = "Подробнее..";
            // 
            // lblxCorp
            // 
            // 
            // 
            // 
            this.lblxCorp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblxCorp.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lblxCorp.Location = new System.Drawing.Point(20, 13);
            this.lblxCorp.Name = "lblxCorp";
            this.lblxCorp.Size = new System.Drawing.Size(280, 40);
            this.lblxCorp.TabIndex = 1;
            this.lblxCorp.Text = "QwinCor Inc. 2016";
            // 
            // ucStartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblxCorp);
            this.Controls.Add(this.itemPanel1);
            this.Name = "ucStartPanel";
            this.Size = new System.Drawing.Size(649, 342);
            this.Text = "ucStartPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem mtiLagranj;
        private DevComponents.DotNetBar.Metro.MetroTileItem mtiBese;
        private DevComponents.DotNetBar.Metro.MetroTileItem mtiArmitt;
        private DevComponents.DotNetBar.LabelX lblxCorp;
    }
}
