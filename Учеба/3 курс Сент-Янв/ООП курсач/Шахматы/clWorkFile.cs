using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Шахматы
{
    class clWorkFile
    {
        public clWorkFile(){ }

        /// <summary>
        /// Количество запусков за сеанс
        /// </summary>
        public int Schetchik { get; set; }
        /// <summary>
        /// Количество выйгрышей черных
        /// </summary>
        public int BlackWin { get; set; }

        /// <summary>
        /// Сохранить в файл
        /// </summary>
        public void Save()
        {
            StreamWriter sw = File.CreateText("save.txt");
            //в начало пишем колич игр
            sw.WriteLine(Schetchik);
            //пишем результат игры
            sw.WriteLine(BlackWin);

            sw.Close();
        }

        private List<string > _arr = new List<string>();
        /// <summary>
        /// Подгрузить файл
        /// </summary>
        public void Load()
        {
            _arr.Clear();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("save.txt");
            }
            catch
            {
                MessageBox.Show("Нет файла save.txt, укажите путь к нему");

                OpenFileDialog loadDialog = new OpenFileDialog
                                                {
                                                    Filter = "Текстовые файлы|*.txt|Родной файл|save.txt"
                                                };
                if (loadDialog.ShowDialog() != DialogResult.OK)
                    return;
                sr = new StreamReader(loadDialog.FileName);
            }

            


            while (true)
            {
                string str = sr.ReadLine();
                if(str==null)
                    break;
                _arr.Add(str);
            }
            sr.Close();

            InShetchikLoad();
            InBlackWin();
        }

        /// <summary>
        /// Перегнать строку в целое и поместить в счетчик загрузок
        /// </summary>
        private void InShetchikLoad()
        {
            if (_arr != null)
                Schetchik = Convert.ToInt32(_arr[0]);
        }
        /// <summary>
        /// Перегнать строку в целое и поместить в счетчик побед
        /// </summary>
        private void InBlackWin()
        {
            if (_arr != null)
                BlackWin = Convert.ToInt32(_arr[1]);
        }
    }
}
