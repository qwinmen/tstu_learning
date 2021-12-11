namespace SimpleCryptographer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbDES = new System.Windows.Forms.RadioButton();
            this.rbAES = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEncryptedFilename = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTextEncrypt = new System.Windows.Forms.Button();
            this.btnFileDecrypt = new System.Windows.Forms.Button();
            this.btnFileEncrypt = new System.Windows.Forms.Button();
            this.btnTextDecrypt = new System.Windows.Forms.Button();
            this.BoxAlgorithm = new System.Windows.Forms.GroupBox();
            this.BoxFileCrypt = new System.Windows.Forms.GroupBox();
            this.txtAlteredFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKey_File = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.BoxTextCrypt = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BoxElapsedTime = new System.Windows.Forms.GroupBox();
            this.rbResult = new System.Windows.Forms.RadioButton();
            this.rbContinuous = new System.Windows.Forms.RadioButton();
            this.BoxAlgorithm.SuspendLayout();
            this.BoxFileCrypt.SuspendLayout();
            this.BoxTextCrypt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.BoxElapsedTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDES
            // 
            this.rbDES.AutoSize = true;
            this.rbDES.Checked = true;
            this.rbDES.Location = new System.Drawing.Point(18, 28);
            this.rbDES.Name = "rbDES";
            this.rbDES.Size = new System.Drawing.Size(47, 17);
            this.rbDES.TabIndex = 0;
            this.rbDES.TabStop = true;
            this.rbDES.Text = "DES";
            this.rbDES.UseVisualStyleBackColor = true;
            this.rbDES.CheckedChanged += new System.EventHandler(this.rbDES_CheckedChanged);
            // 
            // rbAES
            // 
            this.rbAES.AutoSize = true;
            this.rbAES.Location = new System.Drawing.Point(80, 28);
            this.rbAES.Name = "rbAES";
            this.rbAES.Size = new System.Drawing.Size(46, 17);
            this.rbAES.TabIndex = 1;
            this.rbAES.Text = "AES";
            this.rbAES.UseVisualStyleBackColor = true;
            this.rbAES.CheckedChanged += new System.EventHandler(this.rbAES_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtEncrypted
            // 
            this.txtEncrypted.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtEncrypted.Location = new System.Drawing.Point(45, 196);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Name = "txtEncrypted";
            this.txtEncrypted.ReadOnly = true;
            this.txtEncrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncrypted.Size = new System.Drawing.Size(340, 87);
            this.txtEncrypted.TabIndex = 3;
            // 
            // txtPlainText
            // 
            this.txtPlainText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPlainText.Location = new System.Drawing.Point(45, 25);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlainText.Size = new System.Drawing.Size(340, 78);
            this.txtPlainText.TabIndex = 4;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(45, 15);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(243, 20);
            this.txtFile.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File : ";
            // 
            // lblEncryptedFilename
            // 
            this.lblEncryptedFilename.AutoSize = true;
            this.lblEncryptedFilename.Location = new System.Drawing.Point(8, 48);
            this.lblEncryptedFilename.Name = "lblEncryptedFilename";
            this.lblEncryptedFilename.Size = new System.Drawing.Size(0, 13);
            this.lblEncryptedFilename.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // btnTextEncrypt
            // 
            this.btnTextEncrypt.Location = new System.Drawing.Point(5, 296);
            this.btnTextEncrypt.Name = "btnTextEncrypt";
            this.btnTextEncrypt.Size = new System.Drawing.Size(89, 25);
            this.btnTextEncrypt.TabIndex = 10;
            this.btnTextEncrypt.Text = "Text-Encryption";
            this.btnTextEncrypt.UseVisualStyleBackColor = true;
            this.btnTextEncrypt.Click += new System.EventHandler(this.btnTextEncrypt_Click);
            // 
            // btnFileDecrypt
            // 
            this.btnFileDecrypt.Location = new System.Drawing.Point(100, 129);
            this.btnFileDecrypt.Name = "btnFileDecrypt";
            this.btnFileDecrypt.Size = new System.Drawing.Size(89, 25);
            this.btnFileDecrypt.TabIndex = 11;
            this.btnFileDecrypt.Text = "File-Decryption";
            this.btnFileDecrypt.UseVisualStyleBackColor = true;
            this.btnFileDecrypt.Click += new System.EventHandler(this.btnFileDecrypt_Click);
            // 
            // btnFileEncrypt
            // 
            this.btnFileEncrypt.Location = new System.Drawing.Point(7, 129);
            this.btnFileEncrypt.Name = "btnFileEncrypt";
            this.btnFileEncrypt.Size = new System.Drawing.Size(89, 25);
            this.btnFileEncrypt.TabIndex = 12;
            this.btnFileEncrypt.Text = "File-Encryption";
            this.btnFileEncrypt.UseVisualStyleBackColor = true;
            this.btnFileEncrypt.Click += new System.EventHandler(this.btnFileEncrypt_Click);
            // 
            // btnTextDecrypt
            // 
            this.btnTextDecrypt.Location = new System.Drawing.Point(101, 296);
            this.btnTextDecrypt.Name = "btnTextDecrypt";
            this.btnTextDecrypt.Size = new System.Drawing.Size(89, 25);
            this.btnTextDecrypt.TabIndex = 13;
            this.btnTextDecrypt.Text = "Text-Decryption";
            this.btnTextDecrypt.UseVisualStyleBackColor = true;
            this.btnTextDecrypt.Click += new System.EventHandler(this.btnTextDecrypt_Click);
            // 
            // BoxAlgorithm
            // 
            this.BoxAlgorithm.Controls.Add(this.rbAES);
            this.BoxAlgorithm.Controls.Add(this.rbDES);
            this.BoxAlgorithm.Location = new System.Drawing.Point(19, 29);
            this.BoxAlgorithm.Name = "BoxAlgorithm";
            this.BoxAlgorithm.Size = new System.Drawing.Size(146, 63);
            this.BoxAlgorithm.TabIndex = 14;
            this.BoxAlgorithm.TabStop = false;
            this.BoxAlgorithm.Text = "Cryptography Algorithm";
            // 
            // BoxFileCrypt
            // 
            this.BoxFileCrypt.Controls.Add(this.txtAlteredFile);
            this.BoxFileCrypt.Controls.Add(this.label9);
            this.BoxFileCrypt.Controls.Add(this.label7);
            this.BoxFileCrypt.Controls.Add(this.txtFile);
            this.BoxFileCrypt.Controls.Add(this.txtKey_File);
            this.BoxFileCrypt.Controls.Add(this.label1);
            this.BoxFileCrypt.Controls.Add(this.label8);
            this.BoxFileCrypt.Controls.Add(this.btnFileSelect);
            this.BoxFileCrypt.Controls.Add(this.lblEncryptedFilename);
            this.BoxFileCrypt.Controls.Add(this.label3);
            this.BoxFileCrypt.Controls.Add(this.btnFileEncrypt);
            this.BoxFileCrypt.Controls.Add(this.btnFileDecrypt);
            this.BoxFileCrypt.Location = new System.Drawing.Point(19, 209);
            this.BoxFileCrypt.Name = "BoxFileCrypt";
            this.BoxFileCrypt.Size = new System.Drawing.Size(400, 166);
            this.BoxFileCrypt.TabIndex = 15;
            this.BoxFileCrypt.TabStop = false;
            this.BoxFileCrypt.Text = "Encryption and Decryption for files";
            // 
            // txtAlteredFile
            // 
            this.txtAlteredFile.Location = new System.Drawing.Point(141, 44);
            this.txtAlteredFile.Name = "txtAlteredFile";
            this.txtAlteredFile.ReadOnly = true;
            this.txtAlteredFile.Size = new System.Drawing.Size(243, 20);
            this.txtAlteredFile.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Altered File Name : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(329, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "The key is only allowed for Hex-Decimal( ex : 0123456789ABCDEF )";
            // 
            // txtKey_File
            // 
            this.txtKey_File.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKey_File.Location = new System.Drawing.Point(45, 73);
            this.txtKey_File.MaxLength = 16;
            this.txtKey_File.Name = "txtKey_File";
            this.txtKey_File.Size = new System.Drawing.Size(340, 20);
            this.txtKey_File.TabIndex = 23;
            this.txtKey_File.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_File_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Key : ";
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(293, 15);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(64, 23);
            this.btnFileSelect.TabIndex = 16;
            this.btnFileSelect.Text = "Files..";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // BoxTextCrypt
            // 
            this.BoxTextCrypt.Controls.Add(this.label6);
            this.BoxTextCrypt.Controls.Add(this.label10);
            this.BoxTextCrypt.Controls.Add(this.txtKey);
            this.BoxTextCrypt.Controls.Add(this.label4);
            this.BoxTextCrypt.Controls.Add(this.label5);
            this.BoxTextCrypt.Controls.Add(this.label2);
            this.BoxTextCrypt.Controls.Add(this.txtPlainText);
            this.BoxTextCrypt.Controls.Add(this.txtEncrypted);
            this.BoxTextCrypt.Controls.Add(this.btnTextEncrypt);
            this.BoxTextCrypt.Controls.Add(this.btnTextDecrypt);
            this.BoxTextCrypt.Location = new System.Drawing.Point(19, 399);
            this.BoxTextCrypt.Name = "BoxTextCrypt";
            this.BoxTextCrypt.Size = new System.Drawing.Size(400, 332);
            this.BoxTextCrypt.TabIndex = 15;
            this.BoxTextCrypt.TabStop = false;
            this.BoxTextCrypt.Text = "Encryption and Decryption for texts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(329, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "The key is only allowed for Hex-Decimal( ex : 0123456789ABCDEF )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Only for alphabet and number.";
            // 
            // txtKey
            // 
            this.txtKey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKey.Location = new System.Drawing.Point(45, 119);
            this.txtKey.MaxLength = 16;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(340, 20);
            this.txtKey.TabIndex = 17;
            this.txtKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKey_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "The Result text for Encryption and Decryption";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Key : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Text : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProgress);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(19, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 87);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Progress";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(8, 55);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 22);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(375, 20);
            this.progressBar1.TabIndex = 0;
            // 
            // BoxElapsedTime
            // 
            this.BoxElapsedTime.Controls.Add(this.rbResult);
            this.BoxElapsedTime.Controls.Add(this.rbContinuous);
            this.BoxElapsedTime.Location = new System.Drawing.Point(179, 29);
            this.BoxElapsedTime.Name = "BoxElapsedTime";
            this.BoxElapsedTime.Size = new System.Drawing.Size(239, 63);
            this.BoxElapsedTime.TabIndex = 15;
            this.BoxElapsedTime.TabStop = false;
            this.BoxElapsedTime.Text = "ElapsedTime Mode";
            // 
            // rbResult
            // 
            this.rbResult.AutoSize = true;
            this.rbResult.Location = new System.Drawing.Point(152, 28);
            this.rbResult.Name = "rbResult";
            this.rbResult.Size = new System.Drawing.Size(74, 17);
            this.rbResult.TabIndex = 1;
            this.rbResult.Text = "Only result";
            this.rbResult.UseVisualStyleBackColor = true;
            // 
            // rbContinuous
            // 
            this.rbContinuous.AutoSize = true;
            this.rbContinuous.Checked = true;
            this.rbContinuous.Location = new System.Drawing.Point(18, 28);
            this.rbContinuous.Name = "rbContinuous";
            this.rbContinuous.Size = new System.Drawing.Size(121, 17);
            this.rbContinuous.TabIndex = 0;
            this.rbContinuous.TabStop = true;
            this.rbContinuous.Text = "Continuous(Second)";
            this.rbContinuous.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 763);
            this.Controls.Add(this.BoxElapsedTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BoxTextCrypt);
            this.Controls.Add(this.BoxFileCrypt);
            this.Controls.Add(this.BoxAlgorithm);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Very Very Simple Cryptographer by WannaBe Version-3.141592";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BoxAlgorithm.ResumeLayout(false);
            this.BoxAlgorithm.PerformLayout();
            this.BoxFileCrypt.ResumeLayout(false);
            this.BoxFileCrypt.PerformLayout();
            this.BoxTextCrypt.ResumeLayout(false);
            this.BoxTextCrypt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.BoxElapsedTime.ResumeLayout(false);
            this.BoxElapsedTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDES;
        private System.Windows.Forms.RadioButton rbAES;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEncryptedFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTextEncrypt;
        private System.Windows.Forms.Button btnFileDecrypt;
        private System.Windows.Forms.Button btnFileEncrypt;
        private System.Windows.Forms.Button btnTextDecrypt;
        private System.Windows.Forms.GroupBox BoxAlgorithm;
        private System.Windows.Forms.GroupBox BoxFileCrypt;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.GroupBox BoxTextCrypt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKey_File;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAlteredFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.GroupBox BoxElapsedTime;
        private System.Windows.Forms.RadioButton rbResult;
        private System.Windows.Forms.RadioButton rbContinuous;
    }
}

