using System;
using System.Text;

namespace DESanatology
{
    /// <summary>
    /// Перевести бинарник в тексты
    /// </summary>
    class clBaseTransform
    {

        public static string FromBinaryToText(string binarystring)
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
    }
}
