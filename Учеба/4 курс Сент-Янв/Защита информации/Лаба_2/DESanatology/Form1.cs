using System;
using System.Windows.Forms;

namespace DESanatology
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ввели ключ 64_бит или 16 символов hex
        /// Два разряда hex равны 1_байту
        /// 16\2=8 разрядов равны 8_байтам = 64_бит
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxItem_Key_KeyPress(object sender, KeyPressEventArgs e)
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

        /// <summary>
        /// Проверка введенного ключа
        /// Диапазон HEX
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        
        private bool IsEncryption = false;

        /// <summary>
        /// Включение шифрования\дешифровки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchButtonItem_GoCript_ValueChanged(object sender, EventArgs e)
        {
            //Шифровать:
            if(switchButtonItem_GoCript.Value)
            {
                if (!KeyCheck(textBoxItem_Key.Text))
                    return;
                IsEncryption = false;
                
            }else//Дешифровка:
            {
                if (!KeyCheck(textBoxItem_Key.Text))
                    return;
                IsEncryption = true;
            }
            StartProcess();

        }

        /// <summary>
        /// Шифрование
        /// </summary>
        private void StartProcess()
        {
            this.StartSelectedProcess();
        }

        clCryptographer cryptographer = null;
        
        //Контроль загрузки процесса на форму
        public delegate void ProgressInitHandler(object sender, clProgressInitArgs e);
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
        public static event ProgressEventHandler IncrementProgress;
        public static event ProgressInitHandler InitProgress;

        private void StartSelectedProcess()
        {
            if (IsEncryption == true)
            {//Зашифровка
                textBox_Out.Clear();
                cryptographer = new clCryptographer(IncrementProgress, InitProgress);
                textBox_Out.Text = cryptographer.EncryptionStart(textBox_In.Text, textBoxItem_Key.Text.ToUpper(), false);
            }
            else
            {//Расшифровка
                textBox_Out.Clear();
                cryptographer = new clCryptographer(IncrementProgress, InitProgress);
                textBox_Out.Text = clBaseTransform.FromBinaryToText(cryptographer.DecryptionStart(textBox_In.Text, textBoxItem_Key.Text.ToUpper(), true));
            }
        }

        /// <summary>
        /// Проверка длинны ключа
        /// Составляет 16 символов
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool KeyCheck(string key)
        {
            if (key.Length == 16)
                return true;

            MessageBox.Show("Формат ключа 16 знаков в hex диапазоне!");
            return false;
            
        }

        /// <summary>
        /// Криптовать находу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_In_TextChanged(object sender, EventArgs e)
        {
            switchButtonItem_GoCript_ValueChanged(sender, e);
        }



    }
}
