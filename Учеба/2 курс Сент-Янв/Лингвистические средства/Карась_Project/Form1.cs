using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Карась_Project
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public static bool _globalSbros;
        static List<string> _list = new List<string>();
        static List<ListViewItem.ListViewSubItem> list = new List<ListViewItem.ListViewSubItem>();
        public static int key, index, ent;
        public static bool flag, tactic, host;
        private static int ghost;
        private void textBoxIn_KeyDown(object sender, KeyEventArgs e)
        {//жмем Enter
            _globalSbros = false;
            if (e.KeyCode == Keys.Enter && listViewHashTable.Visible)
            {//Агримся на нажатие Enter с условием активности ХешТабл окна
                HashClass hashClass = new HashClass();
                //-----------------ввод----------------------------//
                String[] text = textBoxIn.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int tact = 0;
                if (Bastion(text) || flag)
                {
                    tactic = true;
                    MessageBox.Show("Этo повтор");
                    hashClass.BufferWords(text);
                    _list.Add(hashClass.Num().ToString());
                    ghost = hashClass.Num();//пишем номер повтора
                    ListViewItem stroka1 = new ListViewItem(hashClass.Num().ToString());
                    list.Add(stroka1.SubItems.Add("(" + hashClass.Id() + ")"));
                    list.Add(stroka1.SubItems.Add("(" + hashClass.Type() + ")"));
                    var moe = "*";
                    list.Add(stroka1.SubItems.Add("(" + moe + ")"));
                    list.Add(stroka1.SubItems.Add("(" + hashClass.Kollizi().ToString() + ")"));
                    listViewHashTable.Items.Add(stroka1);
                    tact++;
                }
                else
                {
                    tactic = false;
                    hashClass.BufferWords(text);
                    //-----------------вывод---------------------------//
                    _list.Add(hashClass.Num().ToString());
                    ListViewItem stroka1 = new ListViewItem(hashClass.Num().ToString());
                    list.Add(stroka1.SubItems.Add(hashClass.Id()));
                    list.Add(stroka1.SubItems.Add(hashClass.Type()));
                    list.Add(stroka1.SubItems.Add(hashClass.Hasher().ToString()));
                    list.Add(stroka1.SubItems.Add(hashClass.Kollizi().ToString()));
                    listViewHashTable.Items.Add(stroka1);

                    if (flag)
                    {
                        listViewHashTable.Items.Clear();
                        int ee = 0;
                        for (int i = 0; i < _list.Count; i++)
                        {
                            ListViewItem stroka2 = new ListViewItem(_list[i]); //0-1-2
                            stroka2.SubItems.Add(list[ee]); //0-4-8
                            ee++;
                            stroka2.SubItems.Add(list[ee]); //1-5-9
                            ee++;
                            stroka2.SubItems.Add(list[ee]); //2-6-10
                            ee++;
                            if (i == ent && ent != -42)// - tact - 1 && tactic) //i==1 - 1строка
                            {//перезаписать строку-1
                                stroka2.SubItems.Add(index.ToString()); //3-7-11
                                list[ee].Text = index.ToString();
                                ee++;
                            }
                            else
                            {//перезаписать в нули
                                stroka2.SubItems.Add(list[ee]); //3-7-11
                                ee++;
                            }
                            listViewHashTable.Items.Add(stroka2);
                        }
                    }
                }
                flag = false;
            }
        }
        private bool Bastion(string[] _words)
        {//Защита от повторного ввода
            bool key = false;
            string dd = _words[_words.Length - 1];
            for (int i = 0; i < _words.Length - 1; i++)
            {
                if (_words[i] == dd)
                {
                    key = true;
                }
            }
            return key;//true на совпадение
        }

        private void btnReset_Click(object sender, EventArgs e)
        {//Reset//
            textBoxIn.ReadOnly = false;
            textBoxIn.Visible = true;
            textBoxIn.Clear();
            #region Делается сброс всей статики сдесь и в классе хеш
            HashClass hashClass = new HashClass();
            _globalSbros = true;
            hashClass.GlobalSbros(_globalSbros);
            key = 0; index = 0; ent = 0; flag = false; tactic = false;
            #endregion
            listViewHashTable.Visible = true;
            listViewHashTable.Items.Clear();
            _list.Clear(); list.Clear();
        }




        #region LPO-3 *Входящй ФАЙЛ Publik_Karp.txt*
        private StreamReader reader;//паток чтоб прочесть файл
        private OpenFileDialog openFileDialog;//Окно Открытия файла
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        public static class StaticData
        {//Буфер данных для переброски кода между классами
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {//File/Open/
            textBoxIn.ReadOnly = true;//Текстовая область только для отображения
            textBoxIn.Visible = false;//Текстовая область невидна
            listViewHashTable.Visible = false;//Таблица с хешами невидна
            openFileDialog = new OpenFileDialog();//Запрос на Открытие окна "Выбор Файла"
            openFileDialog.Filter = "Text files|*.txt";//Фильтр на выбор формата открываемого файла

            if (openFileDialog.ShowDialog() != DialogResult.OK)//Если выбрана "Отмена" то
                return;//Возвращаемся_Делаем Откат

            TextLoad();//Грузим тексты с внешнего файла//Метод ниже
            //toolStripStatusLabel.Visible = true;
            toolStrTbNameFile.Text = openFileDialog.SafeFileName;//Выводим Имя открытого файла на панель
            toolStrTbNameFile.Visible = true;//Делаем тексты видимыми

            panel1.Invalidate();//Делаем "Обновить" для всех компонентов на форме
        }

        void TextLoad()
        {//Вывод текста с открытого файла в textBox.In
            StaticData.DataBuffer = Path.GetFullPath(openFileDialog.FileName);//Юзаем буфер для получения пути до файла
            reader = new StreamReader(openFileDialog.OpenFile());//Пишем в приготовленный поток инфу с файла
            try//Блок безопасности
            {//Если все стабильно открыто - то выполнение
                textBoxIn.Visible = true;//Делаем панель с текстами файла видимыми
                textBoxIn.Text = reader.ReadToEnd();//Читаем Файлик до конца
                BuffWords.DataBuffer = textBoxIn.Text;//Пихаем в буфер cчитаные тексты с файла для ЛАБ_3
                viewToolStripMenuItem.Enabled = true;//Делаем доступным меню "View"
                /*----------------------------------*/
                textBoxIn.ReadOnly = true;//Панель с текстом доступ только на чтение
                listViewHashTable.Visible = false;//Отключаем видимость у ХешТаблицы для работ с парсером
            }
            catch (OutOfMemoryException ex)
            {//ИНАЧЕ вывод сообщения об ошибки открытия
                MessageBox.Show("Ошибка при чтении файла");//Вывод ошибки на экран
                return;//Возврат-Откат на предидущий шаг
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {//File/Exit/
            Close();//Закрыть прогу
        }

        private void хешТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Хеш Таблица
            textBoxIn.Clear();//Чистим текстовую область
            btnReset.Visible = true;//Делаем кнопу видимой
            textBoxIn.ReadOnly = false;//Открыть доступ для записи
            textBoxOut.Visible = false;//Текстовая область справо невидима
            listViewHashTable.Visible = true;//ХешТабла видимая
        }

        private void восходящийПарсерToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Восходящий Парсер
            textBoxIn.Clear();//Очистка компонента от содержимого
            TextLoad();//Повторный подгруз текстов с файла-буфера
            btnReset.Visible = false;//Делаем кнопу Сброс невидимой
            textBoxOut.Visible = true;//Открываем доступ к области с право для вывода работы парсера
            fVosxodParser fvosxod = new fVosxodParser();//Создаем обьект-ссылку на класс парсера
            textBoxOut.Text = fvosxod.inOutTextBox();//Вывод в текстовую панель Out результа отработки парсера
        }

        private void таблицаОтношенийToolStripMenuItem_Click(object sender, EventArgs e)
        {//View/Таблица Отношений
            TextLoad();
            FormTable formTable=new FormTable();//Создаем обьект-ссылку на окно Таблицы
            formTable.Show();//Связываемся через ссылку с окном Таблицы Отношений
            fVosxodParser fvosxod = new fVosxodParser();//Создаем обьект-ссылку на класс парсера
            textBoxOut.Text = fvosxod.inOutTextBox();//Вывод в текстовую панель Out результа отработки парсера
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        public static class BuffWords
        {//ПЕРЕДАЧА ТЕКСТА В fVosxodParser.cs
            //Буфер данных
            public static String DataBuffer = String.Empty;
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        #endregion

        
    }
}
