using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Шахматы
{
    /// <summary>
    /// Либо закреплять и каждый раз управление ставить через меню
    ///либо хранить умолчания\новые клавиши в файле
    ///и при старте проги инициализировать этот класс чтобы
    ///считать управление а при переназначении в меню - перепиать
    ///новые клавиши вместо старых в файл.XML?
    /// </summary>
    public class KeyControlsDeff
    {
        /// <summary>
        /// Конструктор для Чтения/доступа
        /// </summary>
        public KeyControlsDeff()
        {
            ReadFromFile();
        }

        //MessageBox.Show(roses[index].Name);//Показать Name Tag xml
        private List<Rose> roses = new List<Rose>();//масив роз + явный шаблон класса Rose
        private List<Rose> lilian = new List<Rose>();

        /// <summary>
        /// Получить значение для [цвет фигуры] по индексу [0..3]
        /// return KeyValuePair (Name--Value)
        /// </summary>
        public KeyValuePair<string, string> ReadParam(string colorFig, int index)
        {
            if (index >= 0 && index <= 3)
                return (colorFig == "black")
                           ? new KeyValuePair<string, string>(roses[index].Name, roses[index].Value)
                           : new KeyValuePair<string, string>(lilian[index].Name, lilian[index].Value);

            //roses[index].Value : lilian[index].Value;
            return new KeyValuePair<string, string>("null", "null"); ;
        }

        /// <summary>
        /// Записать новые кнопы заместо старых в XML
        /// </summary>
        /// <param name="sqrtTag">black или white</param>
        /// <param name="index">0..3</param>
        /// <param name="value">new key</param>
        public void WriteParam(string sqrtTag, int index, string value)
        {
            bool key = false;
            //изменить содержимое массива
            if (index >= 0 && index <= 3)
                if (sqrtTag == "black")
                {//Rose
                    roses[index].Value = value; key = true;

                }
                else if (sqrtTag == "white")
                {//White
                    lilian[index].Value = value; key = true;
                }
            //записать изменения в файл
            if (key) SaveToFile();
        }

        /// <summary>
        /// Записать новые кнопы заместо старых в XML
        /// </summary>
        public void WriteParam(string[,] arr)
        {//int index, string value
            //изменить содержимое массива
            for (int i = 0; i < 4; i++)
            {
                if (arr[0, i]!=null)
                roses[i].Value = arr[0, i];
            }
            
            for (int i = 0; i < 4; i++)
            {
                if (arr[1, i]!=null)
                lilian[i].Value = arr[1, i];
            }

            //записать изменения в файл
            if (true) SaveToFile();
        }

        /// <summary>
        /// Считать комбо из файла keyControl.xml
        /// </summary>
        private void ReadFromFile()
        {
            FileStream fs = null;
            XmlTextReader xmlIn = null;
            try
            {
                fs = new FileStream("keyControl.xml", FileMode.Open);
                xmlIn = new XmlTextReader(fs);
                xmlIn.WhitespaceHandling = WhitespaceHandling.None;//Откл обработку пробелов
                xmlIn.MoveToContent();
            } //
            catch
            {
                MessageBox.Show("Нет файла разметки keyControl.xml, укажите путь к нему");
                OpenFileDialog openFilexml = new OpenFileDialog
                                                 {
                                                     Filter = "XML файлы|*.xml|Родной файл|keyControl.xml"
                                                 };
                if (openFilexml.ShowDialog() != DialogResult.OK)
                    return;
                fs = new FileStream(openFilexml.FileName, FileMode.Open);
                xmlIn = new XmlTextReader(fs)
                            {
                                WhitespaceHandling = WhitespaceHandling.None
                            };
                xmlIn.MoveToContent();
            }

            if (xmlIn.Name != "black")//Проверим первый тег дока
                throw new ArgumentException("Тег открытия xml повреждён или изменён.");

            //цикл чтения документа <Black></Black>
            do
            {
                if (!xmlIn.Read())
                    throw new ArgumentException("Ошибка чтения xml структуры файла.");

                if ((xmlIn.NodeType == XmlNodeType.EndElement) & (xmlIn.Name == "black"))
                    break;//Это конец Дока, элемент black И завершающий_элемент

                if (xmlIn.NodeType == XmlNodeType.EndElement)
                    continue;//Если эт <конечный /> элемент, то не проверяем

                switch (xmlIn.Name)
                {
                    case "Rose":
                        {//если это роза, то читаем ее параметры
                            Rose newItem = new Rose("", 0, "");
                            roses.Add(newItem);
                            newItem.LoadFromFile(xmlIn);
                        }
                        break;
                    case "White":
                        {//если это роза, то читаем ее параметры
                            Rose newItem = new Rose("", 0, "");
                            lilian.Add(newItem);
                            newItem.LoadFromFile(xmlIn);
                        }
                        break;
                }

            } while (!xmlIn.EOF);


            //закрываем потоки
            xmlIn.Close();
            if (fs != null) fs.Close();
        }

        /// <summary>
        /// Сохранить\переписать кнопки в файл xml
        /// </summary>
        void SaveToFile()
        {
            //создание потока записи и обьекта создания xml-документа
            FileStream fs = null;
            try { fs = new FileStream("keyControl.xml", FileMode.OpenOrCreate); }
            catch { MessageBox.Show("Нет файла разметки keyControl.xml"); }

            if (fs != null)
            {
                XmlTextWriter xmlOut = new XmlTextWriter(fs, Encoding.Unicode);
                xmlOut.Formatting = Formatting.Indented;
                //старт начала документа
                xmlOut.WriteStartDocument();
                xmlOut.WriteComment("Этот файл - собственность QwinCor");
                xmlOut.WriteComment("qwinmen@yandex.ru");

                //создаем корневой элемент
                xmlOut.WriteStartElement("black");
                xmlOut.WriteAttributeString("Version", DateTime.Now.ToShortDateString());

                //перебор всех роз и сохранение их
                foreach (Rose item in roses)
                    item.SaveToFile(xmlOut, "Rose");
                foreach (Rose item in lilian)
                    item.SaveToFile(xmlOut, "White");

                //закрываем корневой тег и документ
                xmlOut.WriteEndElement();
                xmlOut.WriteEndDocument();

                //закрываем обьекты записи
                xmlOut.Close();
                fs.Close();
            }

        }

        /// <summary>
        /// Вернет "индекс" если в направлении Key можно поднятся
        /// Иначе null
        /// </summary>
        public string Go(string key, string bevelStateIndex)
        {
            const int up = 0, down = 7, left = 0, right = 7;
            if (bevelStateIndex == null) return null;

            int one = Convert.ToInt32(bevelStateIndex[0].ToString());
            if (key == "up")
            {//идти вверх, тоесть на строку ниже 44--34
                //берем положение квадрата и переписываем в новое
                one -= 1;
                if (one < up) return null;
                return (one + "" + bevelStateIndex[1]);
            }
            if (key == "down")
            {
                //берем положение квадрата и переписываем в новое
                one += 1;
                if (one > down) return null;
                return (one + "" + bevelStateIndex[1]);
            }

            one = Convert.ToInt32(bevelStateIndex[1].ToString());
            if (key == "left")
            {
                //берем положение квадрата и переписываем в новое
                one -= 1;
                if (one < left) return null;
                return (bevelStateIndex[0] + "" + one);
            }
            if (key == "right")
            {
                //берем положение квадрата и переписываем в новое
                one += 1;
                if (one > right) return null;
                return (bevelStateIndex[0] + "" + one);
            }

            return null;
        }

    }
}
