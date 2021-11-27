using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Шахматы
{
    partial class fTransformPawnToN : DevComponents.DotNetBar.Metro.MetroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTransformPawnToN));
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.btnILaden = new DevComponents.DotNetBar.ButtonItem();
            this.btnIKoni = new DevComponents.DotNetBar.ButtonItem();
            this.btnISlon = new DevComponents.DotNetBar.ButtonItem();
            this.btnIFerz = new DevComponents.DotNetBar.ButtonItem();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.lblPlus = new DevComponents.DotNetBar.LabelItem();
            this.opisaniePlus = new DevComponents.DotNetBar.LabelItem();
            this.lblMinus = new DevComponents.DotNetBar.LabelItem();
            this.opisanieMinus = new DevComponents.DotNetBar.LabelItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemPanel1.ForeColor = System.Drawing.Color.Black;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnILaden,
            this.btnIKoni,
            this.btnISlon,
            this.btnIFerz});
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(0, 0);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(112, 108);
            this.itemPanel1.TabIndex = 0;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // btnILaden
            // 
            this.btnILaden.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnILaden.Checked = true;
            this.btnILaden.Image = global::Шахматы.Properties.Resources.rook26;
            this.btnILaden.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnILaden.Name = "btnILaden";
            this.btnILaden.OptionGroup = "leftCharts";
            this.btnILaden.Text = "Ладья";
            this.btnILaden.Click += new System.EventHandler(this.btnILaden_Click);
            this.btnILaden.DoubleClick += new System.EventHandler(this.btnIFerz_DoubleClick);
            // 
            // btnIKoni
            // 
            this.btnIKoni.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnIKoni.Image = global::Шахматы.Properties.Resources.knight48;
            this.btnIKoni.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnIKoni.Name = "btnIKoni";
            this.btnIKoni.OptionGroup = "leftCharts";
            this.btnIKoni.Text = "Конь";
            this.btnIKoni.Click += new System.EventHandler(this.btnILaden_Click);
            this.btnIKoni.DoubleClick += new System.EventHandler(this.btnIFerz_DoubleClick);
            // 
            // btnISlon
            // 
            this.btnISlon.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnISlon.Image = global::Шахматы.Properties.Resources.bishop48;
            this.btnISlon.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnISlon.Name = "btnISlon";
            this.btnISlon.OptionGroup = "leftCharts";
            this.btnISlon.Text = "Слон";
            this.btnISlon.Click += new System.EventHandler(this.btnILaden_Click);
            this.btnISlon.DoubleClick += new System.EventHandler(this.btnIFerz_DoubleClick);
            // 
            // btnIFerz
            // 
            this.btnIFerz.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnIFerz.Image = global::Шахматы.Properties.Resources.queen48;
            this.btnIFerz.ImageFixedSize = new System.Drawing.Size(14, 14);
            this.btnIFerz.Name = "btnIFerz";
            this.btnIFerz.OptionGroup = "leftCharts";
            this.btnIFerz.Text = "Ферзь";
            this.btnIFerz.Click += new System.EventHandler(this.btnILaden_Click);
            this.btnIFerz.DoubleClick += new System.EventHandler(this.btnIFerz_DoubleClick);
            // 
            // itemPanel2
            // 
            this.itemPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel2.ForeColor = System.Drawing.Color.Black;
            this.itemPanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblPlus,
            this.opisaniePlus,
            this.lblMinus,
            this.opisanieMinus});
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.Location = new System.Drawing.Point(112, 0);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(216, 108);
            this.itemPanel2.TabIndex = 1;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // lblPlus
            // 
            this.lblPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblPlus.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.lblPlus.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.PaddingBottom = 1;
            this.lblPlus.PaddingLeft = 1;
            this.lblPlus.PaddingRight = 1;
            this.lblPlus.PaddingTop = 1;
            this.lblPlus.Text = "<b>Плюсы</b>";
            // 
            // opisaniePlus
            // 
            this.opisaniePlus.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.opisaniePlus.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.opisaniePlus.Name = "opisaniePlus";
            this.opisaniePlus.PaddingBottom = 1;
            this.opisaniePlus.PaddingLeft = 1;
            this.opisaniePlus.PaddingRight = 1;
            // 
            // lblMinus
            // 
            this.lblMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblMinus.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.lblMinus.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.lblMinus.Name = "lblMinus";
            this.lblMinus.PaddingBottom = 1;
            this.lblMinus.PaddingLeft = 1;
            this.lblMinus.PaddingRight = 1;
            this.lblMinus.PaddingTop = 1;
            this.lblMinus.Text = "<b>Минусы</b>";
            // 
            // opisanieMinus
            // 
            this.opisanieMinus.BeginGroup = true;
            this.opisanieMinus.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.opisanieMinus.Category = "Culture";
            this.opisanieMinus.ContainerNewLineAfter = true;
            this.opisanieMinus.GlobalItem = false;
            this.opisanieMinus.GlobalName = "opisanieMinus";
            this.opisanieMinus.Name = "opisanieMinus";
            this.opisanieMinus.PaddingBottom = 1;
            this.opisanieMinus.PaddingLeft = 1;
            this.opisanieMinus.PaddingRight = 1;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192))))), System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(47)))), ((int)(((byte)(37))))));
            // 
            // fTransformPawnToN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(328, 108);
            this.ControlBox = false;
            this.Controls.Add(this.itemPanel2);
            this.Controls.Add(this.itemPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fTransformPawnToN";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Апгрейд пешки";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ButtonItem btnILaden;
        private DevComponents.DotNetBar.ButtonItem btnIKoni;
        private DevComponents.DotNetBar.ButtonItem btnISlon;
        private DevComponents.DotNetBar.ButtonItem btnIFerz;
        private DevComponents.DotNetBar.ItemPanel itemPanel2;
        private DevComponents.DotNetBar.LabelItem lblPlus;
        private DevComponents.DotNetBar.LabelItem lblMinus;
        private DevComponents.DotNetBar.LabelItem opisaniePlus;
        private DevComponents.DotNetBar.LabelItem opisanieMinus;
        private StyleManager styleManager1;

    }
}