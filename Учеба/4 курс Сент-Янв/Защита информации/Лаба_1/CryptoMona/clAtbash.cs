using System.Text.RegularExpressions;
//http://kriptografea.narod.ru/atbash.html
namespace CryptoMona
{
    /// <summary>
    /// Шифрование Атбаш
    /// </summary>
    class clAtbash
    {
        public clAtbash(string txtIn)
        {
        }

        /// <summary>
        /// Запрос алфавит-строки
        /// </summary>
        internal string StrAlf(string flagLng)
        {
            if (flagLng.Equals("ru"))
                return _ru;
            if (flagLng.Equals("en"))
                return _en;

            return "-1";
        }

        /// <summary>
        /// принять введеную строку
        /// </summary>
        internal void Analiz(string textin)
        {
            OutString = "";
            //взять символ и перевернуть с учетом выбранного алфавита
            //1]От начала алфавита до символа столько букв [len,
            //2]сколько от конца алфавита до шифр-символа [x.
            foreach (char c in textin)
            {
                //65..90 OR 97..122 [En]
                if((c>=65 && c<=90)||(c>=97 && c<=122))
                {   //1]
                    int len = isToUp(c, true) ? c - 65 : c - 97;
                    //2]
                    char x = (char)(isToUp(c, true) ? 90 - len : 122 - len);
                    OutString += x;
                }
                //1040..1103 OR 1025 OR 1105 [Ru]
                else if ((c >= 1040 && c <= 1103) || (c == 1025 | c == 1105))
                {
                    //1]65=ё ИЛИ -15=Ё
                    int len = c - 1040;
                    //if (len == 65 || len == -15)
                    //    len = isToUp(c, false) ? len + 53 : len - 59;
                    //if (c == 1065 || c == 1097)//щ-->ё
                    //    len = isToUp(c, false) ? len - 27 : len + 21;
                    //2]
                    char x = isToUp(c, false) ? char.ToUpper((char) (1103 - len)) : char.ToLower((char) (1103 - len));

                    OutString += x;
                }
                else OutString += c;
            }

        }

        /// <summary>
        /// Выходная шифрованая строка
        /// </summary>
        internal string OutString { get; private  set; }

        /// <summary>
        /// Вернет True при заглавных символах на входе
        /// </summary>
        /// <param name="c">Символ на входе</param>
        /// <param name="flagLeng">true=En</param>
        /// <returns>False при наборе [a-z]</returns>
        private bool isToUp(char c, bool flagLeng)
        {
            var _regexEn = new Regex(
                "[A-Z-[aeiou]]",
                RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );
            var _regexRu = new Regex(
                "[ЁА-Я-[aeiou]]",
                RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );
            return flagLeng ? _regexEn.Match(c.ToString()).Success : _regexRu.Match(c.ToString()).Success;
        }

        private string _ru = "а, б, в, г, д, е, ё, ж, з, и, й, к, л, м, н, о, п, р, с, т, у, ф, х, ц, ч, ш, щ, ъ, ы, ь, э, ю, я";//33

        private string _en = "A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z";//26

    }
}
