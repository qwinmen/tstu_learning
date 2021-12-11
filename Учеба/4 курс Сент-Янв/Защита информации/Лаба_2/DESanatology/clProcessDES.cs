using System;
using System.Text;

namespace DESanatology
{
    class clProcessDES : clCommonProcess
    {
        public clProcessDES(Form1.ProgressEventHandler IncrementProgress, Form1.ProgressInitHandler InitProgress)
        {
            this.IncrementProgress = IncrementProgress;
            this.InitProgress = InitProgress;
        }


        #region Event for progress bar
        public event Form1.ProgressInitHandler InitProgress;
        public event Form1.ProgressEventHandler IncrementProgress;

        protected virtual void OnIncrementProgress(ProgressEventArgs e)
        {
            if (IncrementProgress != null)
                IncrementProgress(this, e);
        }

        protected virtual void OnInitProgress(clProgressInitArgs e)
        {
            if (InitProgress != null)
                InitProgress(this, e);
        }
        #endregion

        #region Encryption Process
        /// <summary>
        /// Процесс шифрования
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="IsTextBinary"></param>
        /// <returns></returns>
        public override/*static*/ string EncryptionStart(string text, string key, bool IsTextBinary)
        {
            #region Get 16 sub-keys using key
            //ключ в hex
            string hex_key = this.FromTextToHex(key);
            string binary_key = this.FromHexToBinary(hex_key);
            string key_plus = this.DoPermutation(binary_key, clDESData.pc_1);

            string C0 = "", D0 = "";
            //Задать начальные значения половинок
            C0 = this.SetLeftHalvesKey(key_plus);
            D0 = this.SetRightHalvesKey(key_plus);
            //Алгоритм вычисления последовательности ключей
            Keys keys = this.SetAllKeys(C0, D0);

            #endregion

            #region Encrypt process

            //string hex_text = this.FromTextToHex(text);
            string binaryText = "";

            if (IsTextBinary == false)
            {
                binaryText = this.FromTextToBinary(text);
            }
            else
            {
                binaryText = text;
            }

            binaryText = this.setTextMutipleOf64Bits(binaryText);

            #region Initialize Progress Bar
            OnInitProgress(new clProgressInitArgs(binaryText.Length));
            #endregion
            //выходная строка
            StringBuilder EncryptedTextBuilder = new StringBuilder(binaryText.Length);

            for (int i = 0; i < (binaryText.Length / 64); i++)
            {
                string PermutatedText = this.DoPermutation(binaryText.Substring(i * 64, 64), clDESData.ip);

                string L0 = "", R0 = "";

                L0 = this.SetLeftHalvesKey(PermutatedText);
                R0 = this.SetRightHalvesKey(PermutatedText);

                string FinalText = this.FinalEncription(L0, R0, keys, false);

                EncryptedTextBuilder.Append(FinalText);

                #region Increase Progress Bar
                OnIncrementProgress(new ProgressEventArgs(FinalText.Length));
                #endregion
            }

            return EncryptedTextBuilder.ToString();

            #endregion
        }
        #endregion

        #region Decryption Process
        /// <summary>
        /// Процесс расшифровки
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="IsTextBinary"></param>
        /// <returns></returns>
        public override/*static*/ string DecryptionStart(string text, string key, bool IsTextBinary)
        {
            #region Get 16 sub-keys using key

            string hex_key = this.FromTextToHex(key);
            string binary_key = this.FromHexToBinary(hex_key);
            string key_plus = this.DoPermutation(binary_key, clDESData.pc_1);

            string C0 = "", D0 = "";

            C0 = this.SetLeftHalvesKey(key_plus);
            D0 = this.SetRightHalvesKey(key_plus);

            Keys keys = this.SetAllKeys(C0, D0);

            #endregion

            #region Decrypt process

            string binaryText = "";

            if (IsTextBinary == false)
            {
                binaryText = this.FromTextToBinary(text);
            }
            else
            {
                binaryText = text;
            }
            //выровнять блок до 64
            binaryText = this.setTextMutipleOf64Bits(binaryText);

            #region Initialize Progress Bar
            OnInitProgress(new clProgressInitArgs(binaryText.Length));
            #endregion

            StringBuilder DecryptedTextBuilder = new StringBuilder(binaryText.Length);

            for (int i = 0; i < (binaryText.Length / 64); i++)
            {
                string PermutatedText = this.DoPermutation(binaryText.Substring(i * 64, 64), clDESData.ip);

                string L0 = "", R0 = "";

                L0 = this.SetLeftHalvesKey(PermutatedText);
                R0 = this.SetRightHalvesKey(PermutatedText);

                string FinalText = this.FinalEncription(L0, R0, keys, true);

                #region It's for correct subtracted '0' that have added for set text multiple of 64bit
                if ((i * 64 + 64) == binaryText.Length)
                {
                    StringBuilder last_text = new StringBuilder(FinalText.TrimEnd('0'));

                    int count = FinalText.Length - last_text.Length;

                    if ((count % 8) != 0)
                    {
                        count = 8 - (count % 8);
                    }

                    string append_text = "";

                    for (int k = 0; k < count; k++)
                    {
                        append_text += "0";
                    }

                    DecryptedTextBuilder.Append(last_text.ToString() + append_text);
                }
                #endregion
                else
                {
                    DecryptedTextBuilder.Append(FinalText);
                }

                //DecryptedTextBuilder.Append(FinalText);

                #region Increase Progress Bar
                OnIncrementProgress(new ProgressEventArgs(FinalText.Length));
                #endregion
            }

            return DecryptedTextBuilder.ToString();//.TrimEnd('0');

            #endregion
        }
        #endregion

        #region Check a string whether Korean or not. - not used in this program.
        /// <summary>
        /// Проверка на Корейские иероглифы
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public /*static*/ bool IsKorean(char word)
        {
            if (word >= '\xAC00' && word <= '\xD7AF')
            {
                return true;
            }

            if (word >= '\x3130' && word <= '\x318F')
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Transform a text to a hex
        /// <summary>
        /// Перевести текст в hex
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string FromTextToHex(string text)
        {
            string hexstring = "";

            foreach (char word in text)
            {
                hexstring += String.Format("{0:X}", Convert.ToInt32(word));
            }

            return hexstring;
        }
        #endregion

        #region Transform a hex or a binary number to text
        /// <summary>
        /// Перевести hex в строку
        /// </summary>
        /// <param name="hexstring"></param>
        /// <returns></returns>
        public string FromHexToText(string hexstring)
        {
            StringBuilder text = new StringBuilder(hexstring.Length / 2);

            for (int i = 0; i < (hexstring.Length / 2); i++)
            {
                string word = hexstring.Substring(i * 2, 2);
                text.Append((char)Convert.ToInt32(word, 16));
            }

            return text.ToString();
        }

        /// <summary>
        /// Перевод bin в строку
        /// </summary>
        /// <param name="binarystring"></param>
        /// <returns></returns>
        public /*static*/ string FromBinaryToText(string binarystring)
        {
            StringBuilder text = new StringBuilder(binarystring.Length / 8);

            for (int i = 0; i < (binarystring.Length / 8); i++)
            {
                string word = binarystring.Substring(i * 8, 8);
                text.Append((char)Convert.ToInt32(word, 2));
                //text += (char)Convert.ToInt32(word, 16);
            }

            return text.ToString();
        }
        #endregion

        #region Set a length of text to multiple of 64 bits
        /// <summary>
        /// Выравниваем длину текста до 64 бит
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string setTextMutipleOf64Bits(string text)
        {
            if ((text.Length % 64) != 0)
            {
                int maxLength = 0;
                maxLength = ((text.Length / 64) + 1) * 64;
                text = text.PadRight(maxLength, '0');
            }

            return text;
        }
        #endregion

        #region Transform an integer to binary number
        /// <summary>
        /// Переводим Строку в двоичное
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string FromTextToBinary(string text)
        {
            StringBuilder binarystring = new StringBuilder(text.Length * 8);

            foreach (char word in text)
            {
                int binary = (int)word;
                int factor = 128;

                for (int i = 0; i < 8; i++)
                {
                    if (binary >= factor)
                    {
                        binary -= factor;
                        binarystring.Append("1");
                    }
                    else
                    {
                        binarystring.Append("0");
                    }
                    factor /= 2;
                }
            }

            return binarystring.ToString();
        }

        /// <summary>
        /// Переводим десятичное в двоичное
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public static string FromDeciamlToBinary(int binary)
        {
            if (binary < 0)
                return null;

            string binarystring = "";
            int factor = 128;

            for (int i = 0; i < 8; i++)
            {
                if (binary >= factor)
                {
                    binary -= factor;
                    binarystring += "1";
                }
                else
                {
                    binarystring += "0";
                }
                factor /= 2;
            }

            return binarystring;
        }

        /// <summary>
        /// Перевод двоичное в байты
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public static byte FromBinaryToByte(string binary)
        {
            byte value = 0;
            int factor = 128;

            for (int i = 0; i < 8; i++)
            {
                if (binary[i] == '1')
                {
                    value += (byte)factor;
                }

                factor /= 2;
            }

            return value;
        }
        #endregion

        #region Transform a hex integer to a binary number
        /// <summary>
        /// Перевод из hex в двоичное
        /// </summary>
        /// <param name="hexstring"></param>
        /// <returns></returns>
        public string FromHexToBinary(string hexstring)
        {
            string binarystring = "";

            try
            {
                for (int i = 0; i < hexstring.Length; i++)
                {
                    int hex = Convert.ToInt32(hexstring[i].ToString(), 16);

                    int factor = 8;

                    for (int j = 0; j < 4; j++)
                    {
                        if (hex >= factor)
                        {
                            hex -= factor;
                            binarystring += "1";
                        }
                        else
                        {
                            binarystring += "0";
                        }
                        factor /= 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - wrong hexa integer format.");
            }

            return binarystring;
        }
        #endregion

        #region Permutation
        /// <summary>
        /// Перестановки
        /// </summary>
        /// <param name="text"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public string DoPermutation(string text, int[] order)
        {
            StringBuilder PermutatedText = new StringBuilder(order.Length);

            for (int i = 0; i < order.Length; i++)
            {
                PermutatedText.Append(text[order[i] - 1]);
            }

            return PermutatedText.ToString();
        }
        
        /// <summary>
        /// For SBoxes Transformation
        /// Перестановки
        /// </summary>
        /// <param name="text"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public string DoPermutation(string text, int[,] order)
        {
            string PermutatedText = "";

            int rowIndex = Convert.ToInt32(text[0].ToString() + text[text.Length - 1].ToString(), 2);
            int colIndex = Convert.ToInt32(text.Substring(1, 4), 2);

            PermutatedText = clProcessDES.FromDeciamlToBinary(order[rowIndex, colIndex]);

            return PermutatedText;
        }
        #endregion

        #region Divide a text to left and right halves
        public string SetLeftHalvesKey(string text)
        {
            return this.SetHalvesKey(true, text);
        }

        public string SetRightHalvesKey(string text)
        {
            return this.SetHalvesKey(false, text);
        }
        /// <summary>
        /// Определить половинки C0 и D0
        /// </summary>
        /// <param name="IsLeft"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public string SetHalvesKey(bool IsLeft, string text)
        {
            if ((text.Length % 8) != 0)
            {
                Console.WriteLine("The key is not multiple of 8bit.");
                return null;
            }

            int midindex = (text.Length / 2) - 1;

            string result = "";

            if (IsLeft)
            {//Для левой половинки ключа C0
                result = text.Substring(0, midindex + 1);
            }
            else
            {//Для правой половинки ключа D0
                result = text.Substring(midindex + 1);
            }

            return result;
        }
        #endregion

        #region Do Leftshift
        public string LeftShift(string text)
        {
            return this.LeftShift(text, 1);
        }
        /// <summary>
        /// Сдвиг влево
        /// </summary>
        /// <param name="text"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public string LeftShift(string text, int count)
        {
            if (count < 1)
            {
                Console.WriteLine("The count of leftshift is must more than 1 time.");
                return null;
            }

            string temp = text.Substring(0, count);
            StringBuilder shifted = new StringBuilder(text.Length);
            shifted.Append(text.Substring(count) + temp);

            return shifted.ToString();
        }
        #endregion

        #region KeyµйА» ±ёЗПґВ ёЮј­µе - Get all of keys
        public Keys SetAllKeys(string C0, string D0)
        {
            Keys keys = new Keys();
            keys.Cn[0] = C0;
            keys.Dn[0] = D0;
            //выполнить 16 раундов
            for (int i = 1; i < keys.Cn.Length; i++)
            {
                keys.Cn[i] = this.LeftShift(keys.Cn[i - 1], clDESData.nrOfShifts[i]);
                keys.Dn[i] = this.LeftShift(keys.Dn[i - 1], clDESData.nrOfShifts[i]);
                keys.Kn[i - 1] = this.DoPermutation(keys.Cn[i] + keys.Dn[i], clDESData.pc_2);
            }

            return keys;
        }
        #endregion

        #region Do Encryption
        /// <summary>
        /// Инверсная перестановка
        /// </summary>
        /// <param name="L0"></param>
        /// <param name="R0"></param>
        /// <param name="keys"></param>
        /// <param name="IsReverse"></param>
        /// <returns></returns>
        public string FinalEncription(string L0, string R0, Keys keys, bool IsReverse)
        {
            string Ln = "", Rn = "", Ln_1 = L0, Rn_1 = R0;

            int i = 0;

            if (IsReverse == true)
            {
                i = 15;
            }

            while (this.IsEnough(i, IsReverse))
            {
                Ln = Rn_1;
                Rn = this.XOR(Ln_1, this.f(Rn_1, keys.Kn[i]));

                //Next Step of L1, R1 is L2 = R1, R2 = L1 + f(R1, K2), hence, value of Step1's Ln, Rn is Rn_1, Ln_1 in Step2.
                Ln_1 = Ln;
                Rn_1 = Rn;

                if (IsReverse == false)
                {
                    i += 1;
                }
                else
                {
                    i -= 1;
                }
            }

            string R16L16 = Rn + Ln;
            //выполнить перестановку
            string Encripted_Text = this.DoPermutation(R16L16, clDESData.ip_1);

            return Encripted_Text;
        }

        public /*static*/ bool IsEnough(int i, bool IsReverse)
        {
            return (IsReverse == false) ? i < 16 : i >= 0;
        }
        #endregion

        #region The function f
        /// <summary>
        /// Функция F()
        /// </summary>
        /// <param name="Rn_1"></param>
        /// <param name="Kn"></param>
        /// <returns></returns>
        public string f(string Rn_1, string Kn)
        {
            string E_Rn_1 = this.E_Selection(Rn_1);

            string XOR_Rn_1_Kn = this.XOR(E_Rn_1, Kn);

            string sBoxedText = this.sBox_Transform(XOR_Rn_1_Kn);

            string P_sBoxedText = this.P(sBoxedText);

            return P_sBoxedText;
        }
        #endregion

        #region The function P
        public string P(string text)
        {
            string PermutatedText = "";

            PermutatedText = this.DoPermutation(text, clDESData.pc_p);

            return PermutatedText;
        }
        #endregion

        #region SBoxes transformation
        public string sBox_Transform(string text)
        {
            StringBuilder TransformedText = new StringBuilder(32);

            for (int i = 0; i < 8; i++)
            {
                string temp = text.Substring(i * 6, 6);
                TransformedText.Append(this.DoPermutation(temp, clDESData.sBoxes[i]));
            }

            return TransformedText.ToString();
        }
        #endregion

        #region E Selection
        public string E_Selection(string Rn_1)
        {
            string ExpandedText = this.DoPermutation(Rn_1, clDESData.pc_e);

            return ExpandedText;
        }
        #endregion

        #region XOR операции
        public string XOR(string text1, string text2)
        {
            if (text1.Length != text2.Length)
            {
                Console.WriteLine("Two data blocks for XOR are must get same size.");
                return null;
            }

            StringBuilder XORed_Text = new StringBuilder(text1.Length);

            for (int i = 0; i < text1.Length; i++)
            {
                if (text1[i] != text2[i])
                {
                    XORed_Text.Append("1");
                }
                else
                {
                    XORed_Text.Append("0");
                }
            }

            return XORed_Text.ToString();
        }
        #endregion


    }
}
