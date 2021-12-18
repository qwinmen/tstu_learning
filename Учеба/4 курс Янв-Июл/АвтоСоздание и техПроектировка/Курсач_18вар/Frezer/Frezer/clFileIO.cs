using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Frezer
{
    public class clFileIO
    {
        public static List<string> _listBD;
        public const string DefaultPictureName = "no-image";
        public const string DefaultOutputResultMsg = "В базе отсутствуют инструменты, подходящие под заготовку.";
        public const string DefaultRunContructorMsg = "Запустить конструктор для проектирования? [start]";
        private const string Patch = @"Фрезерные_преспособления.txt";
        
        /// <summary>
        /// A - прямоугольная
        /// B - овальная 
        /// C - конус 
        /// </summary>
        public enum RadioType
        {
            A = 0,
            C = 1,
            B = 2,
        }
        /// <summary>
        /// 0 - Отрезание дисковой отрезной фрезой
        /// 1 - Фрезерование пазо-концевой фрезой
        /// 2 - Фрезерование плоскости цилиндрической фрезой
        /// </summary>
        public enum ListboxOperType
        {
            A = 0,
            C = 1,
            B = 2,
        }

        public clFileIO()
        {
            _listBD = new List<string>();
            LoadFile();
        }

        //Читаем БД файл
        private void LoadFile()
        {
            try
            {
                StreamReader fileStream = File.OpenText(Patch);
                while (!fileStream.EndOfStream)
                {
                    string str = fileStream.ReadLine();
                    if (string.IsNullOrEmpty(str) || str.IndexOf("//") != -1) continue;

                    _listBD.Add(str);
                }
            }
            catch (Exception)
            {
                new Exception(string.Format("Файл базы {0} не открывается или отсутствует в каталоге Debug.", Patch));
            }
        }

        /// <summary>
        /// Все строки из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAll()
        {//"[L0u7DTWe8KyVVZhL] Расточные головки"
            return _listBD;
        }

        //name = "Расточные головки"
        public string GetPictureFromName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return DefaultPictureName;
            string keyValuePair = _listBD.Where(i=>i.Contains(name)).FirstOrDefault();
            if (string.IsNullOrEmpty(keyValuePair))
                return DefaultPictureName;

            return SplitString(keyValuePair).Key;
        }

        //str = "[L0u7DTWe8KyVVZhL] Расточные головки"
        private KeyValuePair<string , string> SplitString(string str)
        {
            int x = (str.IndexOf(']'));
            if (x == -1)
                return new KeyValuePair<string, string>(DefaultPictureName, str);

            string pic = str.Substring(1, x - 1);
            string name = str.Substring(x + 2);
            return new KeyValuePair<string, string>(pic, name);
        }

        public void Clear()
        {
            new clFileIO();
        }

    }
}
