namespace qip
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
            this.bevel1 = new heaparessential.Controls.Bevel();
            this.checkBoxEnterLock = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.txtBoxClient = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bevel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bevel1
            // 
            this.bevel1.Controls.Add(this.checkBoxEnterLock);
            this.bevel1.Controls.Add(this.splitContainer1);
            this.bevel1.Controls.Add(this.btnSend);
            this.bevel1.Controls.Add(this.statusStrip1);
            this.bevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bevel1.Location = new System.Drawing.Point(0, 0);
            this.bevel1.Name = "bevel1";
            this.bevel1.Size = new System.Drawing.Size(284, 265);
            this.bevel1.TabIndex = 0;
            // 
            // checkBoxEnterLock
            // 
            this.checkBoxEnterLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnterLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEnterLock.BackgroundImage = global::qip.Properties.Resources.enterBlock;
            this.checkBoxEnterLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBoxEnterLock.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxEnterLock.Location = new System.Drawing.Point(208, 243);
            this.checkBoxEnterLock.Name = "checkBoxEnterLock";
            this.checkBoxEnterLock.Size = new System.Drawing.Size(25, 22);
            this.checkBoxEnterLock.TabIndex = 5;
            this.checkBoxEnterLock.UseVisualStyleBackColor = true;
            this.checkBoxEnterLock.CheckedChanged += new System.EventHandler(this.checkBoxEnterLock_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fctb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClientConnect);
            this.splitContainer1.Panel2.Controls.Add(this.txtBoxClient);
            this.splitContainer1.Size = new System.Drawing.Size(284, 243);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 3;
            // 
            // fctb
            // 
            this.fctb.AutoCompleteBrackets = false;
            this.fctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 22);
            this.fctb.BackBrush = null;
            this.fctb.BackColor = System.Drawing.Color.LightGreen;
            this.fctb.CharHeight = 22;
            this.fctb.CharWidth = 10;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Consolas", 14.25F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(0, 0);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ShowLineNumbers = false;
            this.fctb.Size = new System.Drawing.Size(284, 183);
            this.fctb.TabIndex = 1;
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            
            this.fctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChanged);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClientConnect.Image = global::qip.Properties.Resources.ClientICO;
            this.btnClientConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientConnect.Location = new System.Drawing.Point(231, 0);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(53, 22);
            this.btnClientConnect.TabIndex = 6;
            this.btnClientConnect.Text = "Client";
            this.btnClientConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientConnect.UseCompatibleTextRendering = true;
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // txtBoxClient
            // 
            this.txtBoxClient.BackColor = System.Drawing.Color.SeaShell;
            this.txtBoxClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxClient.Location = new System.Drawing.Point(0, 0);
            this.txtBoxClient.Multiline = true;
            this.txtBoxClient.Name = "txtBoxClient";
            this.txtBoxClient.Size = new System.Drawing.Size(284, 56);
            this.txtBoxClient.TabIndex = 0;
            this.txtBoxClient.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxClient_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSend.Image = global::qip.Properties.Resources.pics_dll_24;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(231, 243);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(53, 22);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.UseCompatibleTextRendering = true;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::qip.Properties.Resources.pics_dll_16_161;
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(133, 17);
            this.toolStripStatusLabel2.Text = "Созданный ящик";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(23, 23);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 265);
            this.Controls.Add(this.bevel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "QIP";
            this.bevel1.ResumeLayout(false);
            this.bevel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private heaparessential.Controls.Bevel bevel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtBoxClient;
        private System.Windows.Forms.CheckBox checkBoxEnterLock;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

