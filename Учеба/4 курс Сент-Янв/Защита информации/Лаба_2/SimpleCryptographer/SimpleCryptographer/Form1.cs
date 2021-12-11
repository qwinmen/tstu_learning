using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SimpleCryptographer
{
    public partial class Form1 : Form
    {
        public delegate void ProgressInitHandler(object sender, ProgressInitArgs e);
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
        public static event ProgressEventHandler IncrementProgress;
        public static event ProgressInitHandler InitProgress;
        Cryptographer cryptographer = null;
        int elapsed = 0;

        private bool IsFile = false;
        private bool IsEncryption = false;

        #region For show just result time at once at the end of program, not continuously.
        DateTime start;
        DateTime end;
        TimeSpan result;
        #endregion

        #region For check elapsed time
        TimerCallback timerDelegate;
        AutoResetEvent autoEvent;
        System.Threading.Timer timer1;
        BackgroundWorker wkr;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Disable/enable all buttons
        public void DisableButtons()
        {
            btnFileDecrypt.Enabled = false;
            btnFileEncrypt.Enabled = false;
            btnFileSelect.Enabled = false;
            btnTextDecrypt.Enabled = false;
            btnTextEncrypt.Enabled = false;
        }

        public void EnableButtons()
        {
            btnFileDecrypt.Enabled = true;
            btnFileEncrypt.Enabled = true;
            btnFileSelect.Enabled = true;
            btnTextDecrypt.Enabled = true;
            btnTextEncrypt.Enabled = true;
        }
        #endregion

        #region Check elasped time option before start encryption/decryption process.
        private void StartProcess()
        {
            if (rbContinuous.Checked == true)
            {
                timer1 = new System.Threading.Timer(timerDelegate, autoEvent, 0, 1000);
                wkr.RunWorkerAsync();
            }
            else if (rbResult.Checked == true)
            {
                DisableButtons();
                start = DateTime.Now;
                this.StartSelectedProcess();
                end = DateTime.Now;

                result = end - start;

                lblProgress.Text = "Elapsed Time : " + result.ToString();

                if (IsFile == true)
                {
                    MessageBox.Show(lblEncryptedFilename.Text + " File Encryption/Decryption is complete.");
                }

                EnableButtons();
            }
        }
        #endregion

        #region Main method for start encryption and decryption
        private void StartSelectedProcess()
        {
            elapsed = 0;
            ClearProgressBar();

            if (IsEncryption == true)
            {
                if (IsFile == true)
                {
                    cryptographer = new Cryptographer((rbDES.Checked == true) ? Algorithms.DES_File : Algorithms.AES_File, IncrementProgress, InitProgress);
                    cryptographer.EncryptionStart(txtFile.Text.Replace("\\", "\\\\"), txtAlteredFile.Text.Replace("\\", "\\\\"), txtKey_File.Text.ToUpper());
                }
                else
                {
                    txtEncrypted.Clear();
                    cryptographer = new Cryptographer((rbDES.Checked == true) ? Algorithms.DES : Algorithms.AES, IncrementProgress, InitProgress);
                    txtEncrypted.Text = cryptographer.EncryptionStart(txtPlainText.Text, txtKey.Text.ToUpper(), false);
                }
            }
            else
            {
                if (IsFile == true)
                {
                    cryptographer = new Cryptographer((rbDES.Checked == true) ? Algorithms.DES_File : Algorithms.AES_File, IncrementProgress, InitProgress);
                    cryptographer.DecryptionStart(txtFile.Text.Replace("\\", "\\\\"), txtAlteredFile.Text.Replace("\\", "\\\\"), txtKey_File.Text.ToUpper());
                }
                else
                {
                    txtEncrypted.Clear();
                    cryptographer = new Cryptographer((rbDES.Checked == true) ? Algorithms.DES : Algorithms.AES, IncrementProgress, InitProgress);
                    txtEncrypted.Text = AES.BaseTransform.FromBinaryToText(cryptographer.DecryptionStart(txtPlainText.Text, txtKey.Text.ToUpper(), true));
                }
            }
        }
        #endregion

        #region encrypt, decrypt, file select button event method
        private void btnFileEncrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey_File.Text) || !FileCheck())
            {
                return;
            }
            IsFile = true;
            IsEncryption = true;

            StartProcess();
        }

        private void btnFileDecrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey_File.Text) || !FileCheck())
            {
                return;
            }
            IsFile = true;
            IsEncryption = false;

            StartProcess();            
        }

        private void btnTextEncrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey.Text))
            {
                return;
            }
            IsFile = false;
            IsEncryption = true;

            StartProcess();
        }

        private void btnTextDecrypt_Click(object sender, EventArgs e)
        {
            if (!KeyCheck(txtKey.Text))
            {
                return;
            }
            IsFile = false;
            IsEncryption = false;

            StartProcess();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            txtFile.Clear();
            txtAlteredFile.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
                txtAlteredFile.Text = openFileDialog1.FileName.Replace(".", "_2.");
            }
        }
        #endregion

        #region Checking method
        private bool FileCheck()
        {
            if (txtFile.Text == "")
            {
                MessageBox.Show("Plaese select a file for encryption/decryption");
                return false;
            }

            return true;
        }

        private bool KeyCheck(string key)
        {
            if (rbDES.Checked)
            {
                if (key.Length == 16)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The key is must be 16-HexDecimal Length for DES algorithm");
                    return false;
                }
            }
            else
            {
                if (key.Length == 32)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The key is must be 32-HexDecimal Length for AES algorithm");
                    return false;
                }
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            StartUp startup = new StartUp();
            startup.ShowDialog();

            #region Initialize progressbar
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;

            InitProgress += new ProgressInitHandler(Initialize);
            IncrementProgress += new ProgressEventHandler(increase);
            #endregion

            #region Initialize timer
            timerDelegate = new TimerCallback(this.timer1_Tick);
            autoEvent = new AutoResetEvent(false);
            #endregion

            #region Initialize BackgroundWorker for ecryption and decryption process
            wkr = new BackgroundWorker();
            wkr.DoWork += new DoWorkEventHandler(wkr_DoWork);
            wkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wkr_RunWorkerCompleted);
            #endregion            
        }

        #region Progress bar event
        void increase(object sender, ProgressEventArgs e)
        {
            progressBar1.Increment(e.Increment);
        }

        void Initialize(object sender, ProgressInitArgs e)
        {
            progressBar1.Maximum = e.Maximum;
        }
        #endregion

        private void ClearProgressBar()
        {
            progressBar1.Value = 0;
        }

        #region BackgroundWorker Event
        void wkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Dispose();

            if (IsFile == true)
            {
                MessageBox.Show(lblEncryptedFilename.Text + " File Encryption/Decryption is complete.");
            }

            EnableButtons();
        }

        void wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            DisableButtons();
            this.StartSelectedProcess();
        }
        #endregion

        #region Timer Event
        public void timer1_Tick(object stateInfo)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                elapsed++;
                lblProgress.Text = "Elapsed Time : " + elapsed.ToString() + " sec.";
            }));
        }
        #endregion

        private void rbDES_CheckedChanged(object sender, EventArgs e)
        {
            txtKey_File.MaxLength = 16;
            txtKey.MaxLength = 16;
        }

        private void rbAES_CheckedChanged(object sender, EventArgs e)
        {
            txtKey_File.MaxLength = 32;
            txtKey.MaxLength = 32;
        }

        #region Check key value
        private void txtKey_File_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHexaDecimal(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHexaDecimal(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private bool IsHexaDecimal(char value)
        {
            if ((('0' <= value) && (value <= '9')) ||
                (('A' <= value) && (value <= 'F')) ||
                (('a' <= value) && (value <= 'f')) ||
                (8 == (int)value))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}