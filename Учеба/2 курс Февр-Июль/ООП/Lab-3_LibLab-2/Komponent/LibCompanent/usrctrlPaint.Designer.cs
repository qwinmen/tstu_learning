namespace LibCompanent
{
    partial class usrctrlPaint
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabLayoutPnlInstrument = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelForButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnBrush = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnElipsise = new System.Windows.Forms.Button();
            this.btnRoundRectangle = new System.Windows.Forms.Button();
            this.btnPolyGon = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.flowLayoutPanelForSterka = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSterka = new System.Windows.Forms.Button();
            this.pictureBoxHolst = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelForRight = new System.Windows.Forms.FlowLayoutPanel();
            this.trackBarForPenSize = new System.Windows.Forms.TrackBar();
            this.colorSelect = new heaparessential.Controls.ColorSelector();
            this.checkBoxForFill = new System.Windows.Forms.CheckBox();
            this.toolTipForBtn = new System.Windows.Forms.ToolTip(this.components);
            this.tabLayoutPnlInstrument.SuspendLayout();
            this.flowLayoutPanelForButtons.SuspendLayout();
            this.flowLayoutPanelForSterka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHolst)).BeginInit();
            this.flowLayoutPanelForRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarForPenSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tabLayoutPnlInstrument
            // 
            this.tabLayoutPnlInstrument.BackColor = System.Drawing.SystemColors.Control;
            this.tabLayoutPnlInstrument.ColumnCount = 2;
            this.tabLayoutPnlInstrument.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.49194F));
            this.tabLayoutPnlInstrument.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.50806F));
            this.tabLayoutPnlInstrument.Controls.Add(this.flowLayoutPanelForButtons, 1, 0);
            this.tabLayoutPnlInstrument.Controls.Add(this.flowLayoutPanelForSterka, 0, 0);
            this.tabLayoutPnlInstrument.Controls.Add(this.pictureBoxHolst, 1, 1);
            this.tabLayoutPnlInstrument.Controls.Add(this.flowLayoutPanelForRight, 0, 1);
            this.tabLayoutPnlInstrument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLayoutPnlInstrument.Location = new System.Drawing.Point(0, 0);
            this.tabLayoutPnlInstrument.Name = "tabLayoutPnlInstrument";
            this.tabLayoutPnlInstrument.RowCount = 2;
            this.tabLayoutPnlInstrument.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.864266F));
            this.tabLayoutPnlInstrument.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.13573F));
            this.tabLayoutPnlInstrument.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabLayoutPnlInstrument.Size = new System.Drawing.Size(496, 361);
            this.tabLayoutPnlInstrument.TabIndex = 1;
            // 
            // flowLayoutPanelForButtons
            // 
            this.flowLayoutPanelForButtons.Controls.Add(this.btnPen);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnBrush);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnRectangle);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnLine);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnElipsise);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnRoundRectangle);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnPolyGon);
            this.flowLayoutPanelForButtons.Controls.Add(this.btnTriangle);
            this.flowLayoutPanelForButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelForButtons.Location = new System.Drawing.Point(60, 3);
            this.flowLayoutPanelForButtons.Name = "flowLayoutPanelForButtons";
            this.flowLayoutPanelForButtons.Size = new System.Drawing.Size(433, 26);
            this.flowLayoutPanelForButtons.TabIndex = 2;
            // 
            // btnPen
            // 
            this.btnPen.AccessibleName = "";
            this.btnPen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPen.BackgroundImage = global::LibCompanent.Properties.Resources.btnPen;
            this.btnPen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPen.ForeColor = System.Drawing.Color.Red;
            this.btnPen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPen.Location = new System.Drawing.Point(3, 3);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(33, 21);
            this.toolTipForBtn.SetToolTip(btnPen, "Карандаш");
            this.btnPen.TabIndex = 0;
            this.btnPen.Tag = "";
            this.btnPen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnBrush
            // 
            this.btnBrush.AccessibleName = "";
            this.btnBrush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrush.BackgroundImage = global::LibCompanent.Properties.Resources.btnBrush;
            this.btnBrush.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrush.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrush.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBrush.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrush.ForeColor = System.Drawing.Color.Red;
            this.btnBrush.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrush.Location = new System.Drawing.Point(42, 3);
            this.btnBrush.Name = "btnBrush";
            this.toolTipForBtn.SetToolTip(btnBrush, "Кисть");
            this.btnBrush.Size = new System.Drawing.Size(33, 21);
            this.btnBrush.TabIndex = 1;
            this.btnBrush.Tag = "";
            this.btnBrush.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrush.UseVisualStyleBackColor = true;
            this.btnBrush.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.AccessibleName = "";
            this.btnRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRectangle.BackgroundImage = global::LibCompanent.Properties.Resources.btnRectangle;
            this.btnRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRectangle.ForeColor = System.Drawing.Color.Red;
            this.btnRectangle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRectangle.Location = new System.Drawing.Point(81, 3);
            this.btnRectangle.Name = "btnRectangle";
            this.toolTipForBtn.SetToolTip(btnRectangle, "Прямоугольник");
            this.btnRectangle.Size = new System.Drawing.Size(33, 21);
            this.btnRectangle.TabIndex = 2;
            this.btnRectangle.Tag = "";
            this.btnRectangle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnLine
            // 
            this.btnLine.AccessibleName = "";
            this.btnLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLine.BackgroundImage = global::LibCompanent.Properties.Resources.btnLine;
            this.btnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLine.ForeColor = System.Drawing.Color.Red;
            this.btnLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLine.Location = new System.Drawing.Point(120, 3);
            this.btnLine.Name = "btnLine";
            this.toolTipForBtn.SetToolTip(btnLine, "Линия");
            this.btnLine.Size = new System.Drawing.Size(33, 21);
            this.btnLine.TabIndex = 3;
            this.btnLine.Tag = "";
            this.btnLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnElipsise
            // 
            this.btnElipsise.AccessibleName = "";
            this.btnElipsise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnElipsise.BackgroundImage = global::LibCompanent.Properties.Resources.btnElipsise;
            this.btnElipsise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnElipsise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElipsise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnElipsise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnElipsise.ForeColor = System.Drawing.Color.Red;
            this.btnElipsise.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnElipsise.Location = new System.Drawing.Point(159, 3);
            this.btnElipsise.Name = "btnElipsise";
            this.toolTipForBtn.SetToolTip(btnElipsise, "Эллипсис");
            this.btnElipsise.Size = new System.Drawing.Size(33, 21);
            this.btnElipsise.TabIndex = 4;
            this.btnElipsise.Tag = "";
            this.btnElipsise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnElipsise.UseVisualStyleBackColor = true;
            this.btnElipsise.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnRoundRectangle
            // 
            this.btnRoundRectangle.AccessibleName = "";
            this.btnRoundRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRoundRectangle.BackgroundImage = global::LibCompanent.Properties.Resources.btnRoundRectangle;
            this.btnRoundRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRoundRectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoundRectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRoundRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRoundRectangle.ForeColor = System.Drawing.Color.Red;
            this.btnRoundRectangle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoundRectangle.Location = new System.Drawing.Point(198, 3);
            this.btnRoundRectangle.Name = "btnRoundRectangle";
            this.toolTipForBtn.SetToolTip(btnRoundRectangle, "Скругленный прямоугольник");
            this.btnRoundRectangle.Size = new System.Drawing.Size(33, 21);
            this.btnRoundRectangle.TabIndex = 5;
            this.btnRoundRectangle.Tag = "";
            this.btnRoundRectangle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoundRectangle.UseVisualStyleBackColor = true;
            this.btnRoundRectangle.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnPolyGon
            // 
            this.btnPolyGon.AccessibleName = "";
            this.btnPolyGon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPolyGon.BackgroundImage = global::LibCompanent.Properties.Resources.btnPolyGon;
            this.btnPolyGon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPolyGon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPolyGon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPolyGon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPolyGon.ForeColor = System.Drawing.Color.Red;
            this.btnPolyGon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPolyGon.Location = new System.Drawing.Point(237, 3);
            this.btnPolyGon.Name = "btnPolyGon";
            this.toolTipForBtn.SetToolTip(btnPolyGon, "Многоугольник");
            this.btnPolyGon.Size = new System.Drawing.Size(33, 21);
            this.btnPolyGon.TabIndex = 6;
            this.btnPolyGon.Tag = "";
            this.btnPolyGon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPolyGon.UseVisualStyleBackColor = true;
            this.btnPolyGon.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.AccessibleName = "";
            this.btnTriangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTriangle.BackgroundImage = global::LibCompanent.Properties.Resources.btnTriangle;
            this.btnTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTriangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTriangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTriangle.ForeColor = System.Drawing.Color.Red;
            this.btnTriangle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTriangle.Location = new System.Drawing.Point(276, 3);
            this.btnTriangle.Name = "btnTriangle";
            this.toolTipForBtn.SetToolTip(btnTriangle, "Триугольник");
            this.btnTriangle.Size = new System.Drawing.Size(33, 21);
            this.btnTriangle.TabIndex = 8;
            this.btnTriangle.Tag = "";
            this.btnTriangle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // flowLayoutPanelForSterka
            // 
            this.flowLayoutPanelForSterka.Controls.Add(this.btnSterka);
            this.flowLayoutPanelForSterka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelForSterka.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelForSterka.Name = "flowLayoutPanelForSterka";
            this.flowLayoutPanelForSterka.Size = new System.Drawing.Size(51, 26);
            this.flowLayoutPanelForSterka.TabIndex = 3;
            // 
            // btnSterka
            // 
            this.btnSterka.AccessibleName = "";
            this.btnSterka.BackgroundImage = global::LibCompanent.Properties.Resources.btnSterka;
            this.btnSterka.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSterka.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSterka.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSterka.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSterka.ForeColor = System.Drawing.Color.Red;
            this.btnSterka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSterka.Location = new System.Drawing.Point(3, 3);
            this.btnSterka.Name = "btnSterka";
            this.toolTipForBtn.SetToolTip(btnSterka, "Ластик");
            this.btnSterka.Size = new System.Drawing.Size(41, 21);
            this.btnSterka.TabIndex = 7;
            this.btnSterka.Tag = "";
            this.btnSterka.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSterka.UseVisualStyleBackColor = true;
            this.btnSterka.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // pictureBoxHolst
            // 
            this.pictureBoxHolst.BackColor = System.Drawing.Color.White;
            this.pictureBoxHolst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxHolst.Location = new System.Drawing.Point(60, 35);
            this.pictureBoxHolst.Name = "pictureBoxHolst";
            this.pictureBoxHolst.Size = new System.Drawing.Size(433, 323);
            this.pictureBoxHolst.TabIndex = 0;
            this.pictureBoxHolst.TabStop = false;
            this.pictureBoxHolst.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxHolst_Paint);
            this.pictureBoxHolst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBoxHolst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBoxHolst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // flowLayoutPanelForRight
            // 
            this.flowLayoutPanelForRight.Controls.Add(this.trackBarForPenSize);
            this.flowLayoutPanelForRight.Controls.Add(this.checkBoxForFill);
            this.flowLayoutPanelForRight.Controls.Add(this.colorSelect);
            this.flowLayoutPanelForRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelForRight.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutPanelForRight.Name = "flowLayoutPanelForRight";
            this.flowLayoutPanelForRight.Size = new System.Drawing.Size(51, 323);
            this.flowLayoutPanelForRight.TabIndex = 4;
            // 
            // trackBarForPenSize
            // 
            this.trackBarForPenSize.Location = new System.Drawing.Point(3, 3);
            this.trackBarForPenSize.Name = "trackBarForPenSize";
            this.trackBarForPenSize.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarForPenSize.Size = new System.Drawing.Size(45, 80);
            this.trackBarForPenSize.TabIndex = 2;
            this.trackBarForPenSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarForPenSize_MouseUp);
            // 
            // colorSelect
            // 
            this.colorSelect.BackgroundColor = System.Drawing.Color.White;
            this.colorSelect.ForegroundColor = System.Drawing.Color.Black;
            this.colorSelect.Location = new System.Drawing.Point(3, 111);
            this.colorSelect.Name = "colorSelect";
            this.colorSelect.Size = new System.Drawing.Size(50, 145);
            this.colorSelect.TabIndex = 1;
            this.colorSelect.ForegroundColorChanged += new System.EventHandler(this.colorSelect_ForegroundColorChanged);
            this.colorSelect.BackgroundColorChanged += new System.EventHandler(this.colorSelect_BackgroundColorChanged);
            // 
            // checkBoxForFill
            // 
            this.checkBoxForFill.BackgroundImage = global::LibCompanent.Properties.Resources.checkBoxForFill;
            this.checkBoxForFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxForFill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxForFill.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxForFill.Location = new System.Drawing.Point(3, 89);
            this.checkBoxForFill.Name = "checkBoxForFill";
            this.checkBoxForFill.Size = new System.Drawing.Size(41, 16);
            this.checkBoxForFill.TabIndex = 9;
            this.checkBoxForFill.Text = "F";
            this.checkBoxForFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipForBtn.SetToolTip(this.checkBoxForFill, "Заливка");
            this.checkBoxForFill.UseVisualStyleBackColor = true;
            this.checkBoxForFill.CheckStateChanged += new System.EventHandler(this.checkBoxForFill_CheckStateChanged);
            // 
            // usrctrlPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabLayoutPnlInstrument);
            this.Name = "usrctrlPaint";
            this.Size = new System.Drawing.Size(496, 361);
            this.Resize += new System.EventHandler(this.FormGanza_Resize);
            this.tabLayoutPnlInstrument.ResumeLayout(false);
            this.flowLayoutPanelForButtons.ResumeLayout(false);
            this.flowLayoutPanelForSterka.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHolst)).EndInit();
            this.flowLayoutPanelForRight.ResumeLayout(false);
            this.flowLayoutPanelForRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarForPenSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabLayoutPnlInstrument;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForButtons;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnBrush;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnElipsise;
        private System.Windows.Forms.Button btnRoundRectangle;
        private System.Windows.Forms.Button btnPolyGon;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForSterka;
        private System.Windows.Forms.Button btnSterka;
        private System.Windows.Forms.PictureBox pictureBoxHolst;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelForRight;
        private System.Windows.Forms.TrackBar trackBarForPenSize;
        private heaparessential.Controls.ColorSelector colorSelect;
        private System.Windows.Forms.ToolTip toolTipForBtn;
        private System.Windows.Forms.CheckBox checkBoxForFill;
    }
}
