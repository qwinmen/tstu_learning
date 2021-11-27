namespace Vika
{
    partial class StartControl
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.ytdTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.helpTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.devCoTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.appViewTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(13, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(259, 42);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "QwinCor Inc. 2016";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(450, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 42);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "<div align=\"right\"><font size=\"+4\">User</font><br/>all user</div>";
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.Location = new System.Drawing.Point(13, 51);
            this.itemPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.itemPanel1.Size = new System.Drawing.Size(565, 296);
            this.itemPanel1.TabIndex = 7;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 60;
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ytdTile,
            this.helpTile,
            this.devCoTile,
            this.appViewTile});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // ytdTile
            // 
            this.ytdTile.Name = "ytdTile";
            this.ytdTile.SymbolColor = System.Drawing.Color.Empty;
            this.ytdTile.Text = "<font size=\"+4\">Вход <br/>админастратора</font>";
            this.ytdTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.ytdTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.ytdTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(98)))), ((int)(((byte)(185)))));
            this.ytdTile.TileStyle.BackColorGradientAngle = 45;
            this.ytdTile.TileStyle.BackgroundImage = global::Vika.Properties.Resources.admin;
            this.ytdTile.TileStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.ytdTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ytdTile.TileStyle.PaddingBottom = 4;
            this.ytdTile.TileStyle.PaddingLeft = 4;
            this.ytdTile.TileStyle.PaddingRight = 4;
            this.ytdTile.TileStyle.PaddingTop = 4;
            this.ytdTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.ytdTile.TitleText = "Администрирование";
            this.ytdTile.Click += new System.EventHandler(this.ytdTile_Click);
            // 
            // helpTile
            // 
            this.helpTile.Name = "helpTile";
            this.helpTile.SymbolColor = System.Drawing.Color.Empty;
            this.helpTile.Text = "<font size=\"+4\">Programmer</font><br/>qwinmen @2016<br/>QwinCor Metro";
            this.helpTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            // 
            // 
            // 
            this.helpTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(102)))), ((int)(((byte)(168)))));
            this.helpTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.helpTile.TileStyle.BackColorGradientAngle = 45;
            this.helpTile.TileStyle.BackgroundImage = global::Vika.Properties.Resources.about;
            this.helpTile.TileStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.helpTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.helpTile.TileStyle.PaddingBottom = 4;
            this.helpTile.TileStyle.PaddingLeft = 4;
            this.helpTile.TileStyle.PaddingRight = 4;
            this.helpTile.TileStyle.PaddingTop = 4;
            this.helpTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.helpTile.TitleText = "About";
            this.helpTile.Click += new System.EventHandler(this.helpTile_Click);
            // 
            // devCoTile
            // 
            this.devCoTile.Name = "devCoTile";
            this.devCoTile.SymbolColor = System.Drawing.Color.Empty;
            this.devCoTile.Text = "<font size=\"+4\">Информация<br/>о базе</font>";
            this.devCoTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet;
            // 
            // 
            // 
            this.devCoTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.devCoTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(61)))));
            this.devCoTile.TileStyle.BackColorGradientAngle = 45;
            this.devCoTile.TileStyle.BackgroundImage = global::Vika.Properties.Resources.basedate;
            this.devCoTile.TileStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.devCoTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.devCoTile.TileStyle.PaddingBottom = 4;
            this.devCoTile.TileStyle.PaddingLeft = 4;
            this.devCoTile.TileStyle.PaddingRight = 4;
            this.devCoTile.TileStyle.PaddingTop = 4;
            this.devCoTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.devCoTile.TitleText = "Соединение";
            this.devCoTile.Click += new System.EventHandler(this.devCoTile_Click);
            // 
            // appViewTile
            // 
            this.appViewTile.Name = "appViewTile";
            this.appViewTile.SymbolColor = System.Drawing.Color.Empty;
            this.appViewTile.Text = "<font size=\"+4\">Перейти<br/>к просмотру</font>";
            this.appViewTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            // 
            // 
            // 
            this.appViewTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.appViewTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.appViewTile.TileStyle.BackColorGradientAngle = 45;
            this.appViewTile.TileStyle.BackgroundImage = global::Vika.Properties.Resources.tables;
            this.appViewTile.TileStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center;
            this.appViewTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.appViewTile.TileStyle.PaddingBottom = 4;
            this.appViewTile.TileStyle.PaddingLeft = 4;
            this.appViewTile.TileStyle.PaddingRight = 4;
            this.appViewTile.TileStyle.PaddingTop = 4;
            this.appViewTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.appViewTile.TitleText = "Таблица";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Vika.Properties.Resources.allUser;
            this.pictureBox1.Location = new System.Drawing.Point(516, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // StartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.itemPanel1);
            this.Name = "StartControl";
            this.Size = new System.Drawing.Size(602, 362);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem ytdTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem helpTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem devCoTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem appViewTile;
    }
}
