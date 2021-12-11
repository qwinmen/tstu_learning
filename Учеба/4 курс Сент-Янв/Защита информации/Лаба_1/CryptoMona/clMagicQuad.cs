//http://neudoff.net/info/informatika/shifrovanie-po-metodu-magicheskix-kvadratov/
//http://crypto-r.narod.ru/glava2/glava2_2.html
namespace CryptoMona
{
    /// <summary>
    /// Шифрование методом Магический квадрат
    /// </summary>
    class clMagicQuad
    {
        public clMagicQuad(HeaparGrid.HeaparGrid squad, object textNum)
        {
            //выпилить массив чисел-строк
            string[] words = textNum.ToString().Split(' '); //Делим строку на ПОДСТРОКИ
            
            //заполнить обьект цифровой последовательностью
            quadOut = SetNumeric(squad, words);

        }

        /// <summary>
        /// Обьект на форме, содержит цифровой ряд
        /// </summary>
        internal HeaparGrid.HeaparGrid quadOut { get; private set; }

        /// <summary>
        /// Залить числа в таблицу
        /// </summary>
        /// <param name="squad">Таблица которую заполняем</param>
        /// <param name="num">Последовательность чисел</param>
        /// <returns>Готовый обьект</returns>
        private HeaparGrid.HeaparGrid SetNumeric(HeaparGrid.HeaparGrid squad, string[] num)
        {
            int d = 0;
            for (int i = 0; i < squad.ColCount; i++)
            {
                for (int j = 0; j < squad.RowCount; j++)
                {
                    squad[j, i].Data = num[d];
                    d++;
                } 
            }

            return squad;
        }

        /// <summary>
        /// Заполнить таблицу входящим сообщением
        /// </summary>
        /// <param name="txtIn">Входящее сообщение</param>
        /// <param name="gridOut">Таблица для заполнения</param>
        internal void SetCrypto(string txtIn, HeaparGrid.HeaparGrid gridOut)
        {
            TextOut = "";
            //Ячейка==индекс символа, 
            //Индекс символа==quadOut[j,i]
            for (int i = 0; i < gridOut.ColCount; i++)
            {
                for (int j = 0; j < gridOut.RowCount; j++)
                {
                    int num = int.Parse(quadOut[j, i].Data.ToString());
                    if (num > txtIn.Length) gridOut[j, i].Data = "_";
                    else gridOut[j, i].Data = txtIn[num - 1];
                    //Записать результат в выходСтроку
                    TextOut += gridOut[j, i].Data + "";
                }
            }

        }

        /// <summary>
        /// Для передачи шифрстроки на форму
        /// </summary>
        internal string TextOut { get; private set; }

    }
}
