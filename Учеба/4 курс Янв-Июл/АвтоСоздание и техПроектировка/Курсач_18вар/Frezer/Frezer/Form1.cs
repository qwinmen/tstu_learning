using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Frezer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            numericUpDown_Диаметр.Enabled = false;
        }

        private static clFileIO _clFileIo = new clFileIO();
        private static fRunConstructor _fRunConstructor = new fRunConstructor();

        /// <summary>
        /// Сообщения об ошибках
        /// </summary>
        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выполнить расчеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Ok_Click(object sender, EventArgs e)
        {
            {//Проверить заполнение полей
                if (checkedListBox_TO.CheckedItems.Count == 0)
                    checkedListBox_TO.SetItemChecked(0, true);
            }

            //Чистим вывод
            listBox_OutputList.Items.Clear();
            //Отфильтровать для логики
            IEnumerable<string> list = Filter();
            //Логика
            IEnumerable<string> res = Logika(list);
            foreach (string str in res)
                listBox_OutputList.Items.Add(str);
            if (listBox_OutputList.Items.Count == 0)
            {
                listBox_OutputList.Items.Add(clFileIO.DefaultOutputResultMsg);
                listBox_OutputList.Items.Add(clFileIO.DefaultRunContructorMsg);
            }
                
        }

        /// <summary>
        /// Подобрать инструмент
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Вернет набор инструментов</returns>
        private IEnumerable<string> Logika(IEnumerable<string> data)
        {
            var result = new List<string>();
            string[] arrey = data.ToArray();
            for (int i = 0; i < arrey.Length; i++)
            {
                if (arrey[i] == null) continue;

                int x = (arrey[i].IndexOf(";]"));
                if (x == -1)
                {
                    if (checkBox_БезПараметров.Checked)
                        result.Add(arrey[i]);
                    arrey[i] = null;
                    continue;
                }
                if(numericUpDown_Диаметр.Enabled)
                {//L//D
                    int xL = (arrey[i].IndexOf("L="));
                    int xD = (arrey[i].IndexOf("D="));
                    if (xL != -1)
                    {
                        var subStart = arrey[i].Substring(xL);//L=138;D=100;]{0;1;2;}
                        var subEnd = subStart.Substring(subStart.IndexOf('=') + 1);//138;D=100;]{0;1;2;}
                        string resultStr = subEnd.Substring(0, subEnd.IndexOf(';'));//138
                        int lengthL = int.Parse(resultStr);

                        //TODO: Если длина заготовки с формы > чем в БД инструмент:
                        if(numericUpDown_Длина.Value > lengthL)
                            continue;//то нафиг такую заготовку
                    }
                    if (xD != -1)
                    {
                        var subStart = arrey[i].Substring(xD);//D=100;]{0;1;2;}
                        var subEnd = subStart.Substring(subStart.IndexOf('=') + 1);//100;]{0;1;2;}
                        string resultStr = subEnd.Substring(0, subEnd.IndexOf(';'));//100
                        int lengthD = int.Parse(resultStr);

                        //TODO: Если диаметр заготовки с формы > чем в БД инструмент:
                        if (numericUpDown_Диаметр.Value > lengthD)
                            continue;//то нафиг такую заготовку
                    }
                    //Если все устраивает:
                    result.Add(arrey[i]);
                }
                else
                {//L//H//W
                    int xL = (arrey[i].IndexOf("L="));
                    int xH = (arrey[i].IndexOf("H="));
                    int xW = (arrey[i].IndexOf("W="));
                    if (xL != -1)
                    {
                        var subStart = arrey[i].Substring(xL);//L=138;D=100;]{0;1;2;}
                        var subEnd = subStart.Substring(subStart.IndexOf('=') + 1);//138;D=100;]{0;1;2;}
                        string resultStr = subEnd.Substring(0, subEnd.IndexOf(';'));//138
                        int lengthL = int.Parse(resultStr);

                        //TODO: Если длина заготовки с формы > чем в БД инструмент:
                        if (numericUpDown_Длина.Value > lengthL)
                            continue;//то нафиг такую заготовку
                    }
                    if (xH != -1)
                    {
                        var subStart = arrey[i].Substring(xH);
                        var subEnd = subStart.Substring(subStart.IndexOf('=') + 1);
                        string resultStr = subEnd.Substring(0, subEnd.IndexOf(';'));
                        int lengthH = int.Parse(resultStr);

                        //TODO: Если высота заготовки с формы > чем в БД инструмент:
                        if (numericUpDown_Высота.Value > lengthH)
                            continue;//то нафиг такую заготовку
                    }
                    if (xW != -1)
                    {
                        var subStart = arrey[i].Substring(xW);
                        var subEnd = subStart.Substring(subStart.IndexOf('=') + 1);
                        string resultStr = subEnd.Substring(0, subEnd.IndexOf(';'));
                        int lengthW = int.Parse(resultStr);

                        //TODO: Если ширина заготовки с формы > чем в БД инструмент:
                        if (numericUpDown_Высота.Value > lengthW)
                            continue;//то нафиг такую заготовку
                    }
                    //Если все устраивает:
                    result.Add(arrey[i]);
                }
                arrey[i] = null;
            }
            return result;
        }

        /// <summary>
        /// Определить, что грузить из БД для заданых параметров
        /// </summary>
        private IEnumerable<string> Filter()
        {
            IEnumerable<string> dataSet = _clFileIo.GetAll();
            /*Каждый элемент имеет максимальные параметры
             [форма] A B C
             [габариты] L W H D
             */
            IEnumerable<string> typeFilterSet = new List<string>();
            {//Фильтр по Типу заготовки:
                if (radioButton_Прямоугольник.Checked)
                    typeFilterSet = FormaFilter(clFileIO.RadioType.A, dataSet);
                if (radioButton_Овал.Checked)
                    typeFilterSet = FormaFilter(clFileIO.RadioType.B, dataSet);
                if (radioButton_Конус.Checked)
                    typeFilterSet = FormaFilter(clFileIO.RadioType.C, dataSet);
            }
            IEnumerable<string> texoperFilterSet = new List<string>();
            {//Фильтр по Технической операции:
                IEnumerable<int> cheked = new List<int>();
                for (int i = 0; i < checkedListBox_TO.Items.Count; i++)
                {
                    if (checkedListBox_TO.GetItemChecked(i))
                        ((List<int>)cheked).Add(i);
                }
                texoperFilterSet = TexOperFilter(cheked, typeFilterSet);
            }
            IEnumerable<string> gabaritFilterSet = new List<string>();
            {//Фильтр по Габаритам:
                gabaritFilterSet = GabaritFilter(numericUpDown_Диаметр.Enabled ? 0 : 1, texoperFilterSet);
            }

            return gabaritFilterSet;
        }

        /// <summary>
        /// [габариты]:
        /// L - длина 
        /// W - ширина 
        /// H - высота 
        /// D - диаметр
        /// </summary>
        /// <param name="typeGroup">0-Длина И Диаметр</param>
        /// <param name="data"></param>
        /// <returns>Вернет набор с габаритом выбранной группы И без групп</returns>
        private IEnumerable<string> GabaritFilter(int typeGroup, IEnumerable<string> data)
        {
            var result = new List<string>();
            string[] arrey = data.ToArray();
            {//Без групп:
                for (int i = 0; i < arrey.Length; i++)
                {
                    if (arrey[i] == null) continue;

                    int x = (arrey[i].IndexOf(";]"));
                    if (x != -1) continue;
                    //строки без [Габарит;]:
                    result.Add(arrey[i]);//их также пишем в результат
                    arrey[i] = null;
                }
            }

            switch (typeGroup)
            {
                case 0: //L=;D=;
                    for (int i = 0; i < arrey.Length; i++)
                    {
                        if(arrey[i] == null) continue;

                        int xL = (arrey[i].IndexOf("L="));
                        int xD = (arrey[i].IndexOf("D="));
                        if (xL == -1 || xD == -1) continue;

                        result.Add(arrey[i]);
                        arrey[i] = null;
                    }
                    break;
                case 1: //L=;H=;W=;
                    for (int i = 0; i < arrey.Length; i++)
                    {
                        if (arrey[i] == null) continue;

                        int xL = (arrey[i].IndexOf("L="));
                        int xH = (arrey[i].IndexOf("H="));
                        int xW = (arrey[i].IndexOf("W="));
                        if (xL == -1 || xH == -1 || xW == -1) continue;

                        result.Add(arrey[i]);
                        arrey[i] = null;
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// A-0- Отрезание дисковой отрезной фрезой
        /// C-1- Фрезерование пазо-концевой фрезой
        /// B-2- Фрезерование плоскости цилиндрической фрезой
        /// </summary>
        /// <param name="cheked"></param>
        /// <param name="data"></param>
        /// <returns>Выбрать все записи с ТехОперац И без них</returns>
        private IEnumerable<string> TexOperFilter(IEnumerable<int> cheked, IEnumerable<string> data)
        {
            var result = new List<string>();
            string[] arrey = data.ToArray();
            for (int i = 0; i < arrey.Length; i++)
            {
                if (arrey[i] == null) continue;

                int x = (arrey[i].IndexOf('{'));
                if (x != -1) continue;
                //строки без {ТехОперации;}:
                result.Add(arrey[i]);//их также пишем в результат
                arrey[i] = null;
            }

            foreach (clFileIO.ListboxOperType point in cheked)
            {
                switch (point)
                {
                    case clFileIO.ListboxOperType.A:
                        for (int i = 0; i < arrey.Length; i++)
                        {
                            if(arrey[i] == null) continue;
                            int subIndex = (arrey[i].IndexOf("{"));
                            int x = (arrey[i].IndexOf("0;", subIndex));
                            if(x == -1) continue;

                            result.Add(arrey[i]);
                            arrey[i] = null;
                        }
                        break;
                    case clFileIO.ListboxOperType.B:
                        for (int i = 0; i < arrey.Length; i++)
                        {
                            if (arrey[i] == null) continue;
                            int subIndex = (arrey[i].IndexOf("{"));
                            int x = (arrey[i].IndexOf("2;", subIndex));
                            if (x == -1) continue;

                            result.Add(arrey[i]);
                            arrey[i] = null;
                        }
                        break;
                    case clFileIO.ListboxOperType.C:
                        for (int i = 0; i < arrey.Length; i++)
                        {
                            if (arrey[i] == null) continue;
                            int subIndex = (arrey[i].IndexOf("{"));
                            int x = (arrey[i].IndexOf("1;", subIndex));
                            if (x == -1) continue;

                            result.Add(arrey[i]);
                            arrey[i] = null;
                        }
                        break;
                }
            }
            
            return result;
        }

        /// <summary>
        /// A - прямоугольная
        /// B - овальная 
        /// C - конус 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns>Выбрать все записи с типом Type И без типа</returns>
        private IEnumerable<string> FormaFilter(clFileIO.RadioType type, IEnumerable<string> data)
        {
            IEnumerable<string> result = new List<string>();
            switch (type)
            {
                case clFileIO.RadioType.A:
                    result = data.Select(i => i).Where(i =>
                        i.IndexOf("[A;") != -1 || (i.IndexOf("[C;") == -1 && i.IndexOf("[B;") == -1)
                        );
                    break;
                case clFileIO.RadioType.C:
                    result = data.Select(i => i).Where(i =>
                        i.IndexOf("[C;") != -1 || (i.IndexOf("[A;") == -1 && i.IndexOf("[B;") == -1)
                        );
                    break;
                case clFileIO.RadioType.B:
                    result = data.Select(i => i).Where(i =>
                        i.IndexOf("[B;") != -1 || (i.IndexOf("[C;") == -1 && i.IndexOf("[A;") == -1)
                        );
                    break;
            }

            return result;
        }

        /// <summary>
        /// Отобразить фото текущего элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_OutputList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            if(listBox == null) return;
            //ShowImage("Расточные головки")
            ShowImage(listBox.SelectedItem != null ? listBox.SelectedItem.ToString() : "");
            if (listBox.SelectedItem != null && listBox.SelectedItem.ToString() == clFileIO.DefaultRunContructorMsg)
            {
                if (_fRunConstructor.ShowDialog() != DialogResult.OK)
                    return;
            }
        }

        /// <summary>
        /// Вывести картинку элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        private void ShowImage(string item)
        {
            if(string.IsNullOrEmpty(item))
                panel_Image.BackgroundImage = Image.FromFile(string.Format(@"images/{0}.png", clFileIO.DefaultPictureName));
            else
            {
                try
                {
                    var pic = GetImageFromName(item);
                    panel_Image.BackgroundImage = Image.FromFile(@"images/"+pic+".png");
                }
                catch (Exception)
                {
                    panel_Image.BackgroundImage = Image.FromFile(string.Format(@"images/{0}.png", clFileIO.DefaultPictureName));
                }
            }
        }

        /// <summary>
        /// Получить рисунок по Имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        private string GetImageFromName(string name)
        {
            return _clFileIo.GetPictureFromName(name);
        }

        /// <summary>
        /// Скрыть Диаметр_поле_ввода и Показать 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_Dlina_CheckedChanged(object sender, EventArgs e)
        {
            var control = sender as RadioButton;
            if(control == null) return;

            if(control.Text.Contains("Д"))
            {
                numericUpDown_Диаметр.Enabled = true;
                numericUpDown_Ширина.Enabled = numericUpDown_Высота.Enabled = false;
            }
            else
            {
                numericUpDown_Диаметр.Enabled = false;
                numericUpDown_Ширина.Enabled = numericUpDown_Высота.Enabled = true;
            }
        }



    }
}
