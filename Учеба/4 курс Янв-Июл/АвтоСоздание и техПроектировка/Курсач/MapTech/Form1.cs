using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Expromt;
using ColumnHeader = DevComponents.AdvTree.ColumnHeader;
using unvell.ReoGrid; //Сам компонент
using unvell.ReoGrid.CellTypes; //Типы ячеек
using unvell.ReoGrid.Actions; //Действия
using unvell.ReoGrid.DataFormat; //Форматы данных
using unvell.ReoGrid.Print; //Печать
using unvell.ReoGrid.Chart; //Диаграммы

//ГОСТ 3.1104-81 http://www.gosthelp.ru/text/GOST3111882ESTDFormyiprav.html
namespace MapTech
{
    public partial class Form1 : Office2007Form
    {
        /// <summary>
        /// Помощь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_Help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            superTabControl_КонтейнерВкладок.SelectedTabIndex = 4;
            superTabControl_КонтейнерВкладок.SelectedTab = superTabItem1_HelpTab;
            superTabControl_КонтейнерВкладок.SelectedPanel = superTabControlPanel1_Help;

            pageSlider1.SelectedPageIndex = 0;
            index = 1;
        }
        /// <summary>
        /// Печать Маршрутной Карты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ПечатьtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterNull print = new PrinterNull();
            print.ShowDialog();
        }
        //Для исключения вылетов гасим контрол при выходе
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            reoGridControl_МаршрутнаяКарта.Dispose();
        }
        private int index = 1;
        //Кнопка Следующий слайд
        private void buttonX1_NextSlideHelp_Click(object sender, EventArgs e)
        {
            if (index > pageSlider1.PageCount - 1) index = 0;
            pageSlider1.SelectedPageIndex = index++;
        }
        
        public Form1()
        {
            InitializeComponent();

            var sheet = reoGridControl_МаршрутнаяКарта.CurrentWorksheet;
            //Отключить отображение Шапки и Нумерации
            sheet.DisableSettings(WorksheetSettings.View_ShowRowHeader);
            sheet.DisableSettings(WorksheetSettings.View_ShowColumnHeader);
            _clTablica.СоздатьШапкуКарты(reoGridControl_МаршрутнаяКарта);
            _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);

            очиститьПолеToolStripMenuItem_Click("", null);

            //Pan();
        }
        void Pan()
        {
            _clTablica.АtrokaSet(new clTablica.A("1", "c", "1", "Погрузка", "0022", "НБЖД№2", reoGridControl_МаршрутнаяКарта));
            _clTablica.БstrokaSet(new clTablica.Б("0921 Контейнер загрузочный", "1", "12533", "1", "1", "1", "500",
                                                  "0.1", "550", "10 мин.", "3 мин.", "7 мин.",
                                                  reoGridControl_МаршрутнаяКарта));
            _clTablica.ОstrokaSet(new clTablica.О("Переместить контейнер на рабочее место К01", reoGridControl_МаршрутнаяКарта));
            _clTablica.ТstrokaSet(new clTablica.Т("Трос 10 метров, тележка для транспортировки ТКВ", reoGridControl_МаршрутнаяКарта));
            _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);

            _clTablica.АtrokaSet(new clTablica.A("1", "c", "1", "Транспортировка", "0192", "НБЖД№12", reoGridControl_МаршрутнаяКарта));
            _clTablica.БstrokaSet(new clTablica.Б("0921 Конвеер загрузочный", "1", "12533", "1", "1", "1", "2000",
                                                  "0.1", "550", "0.2 мин.", "0.1 мин.", "0.1 мин.",
                                                  reoGridControl_МаршрутнаяКарта));
            _clTablica.ОstrokaSet(new clTablica.О("Загрузить конвеерную ленту КЛ-01", reoGridControl_МаршрутнаяКарта));
            _clTablica.ТstrokaSet(new clTablica.Т("Конвеер 10м, тележка для транспортировки ТКВ", reoGridControl_МаршрутнаяКарта));
            _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);
            _clTablica.АtrokaSet(new clTablica.A("1", "c", "1", "Размельчение", "0022", "НБЖД№4", reoGridControl_МаршрутнаяКарта));
            _clTablica.БstrokaSet(new clTablica.Б("3141 Дробилка ДМП", "1", "12533", "1", "1", "1", "500",
                                                  "0.1", "550", "10 мин.", "3 мин.", "7 мин.",
                                                  reoGridControl_МаршрутнаяКарта));
            _clTablica.ОstrokaSet(new clTablica.О("Переместить контейнер на рабочее место К01", reoGridControl_МаршрутнаяКарта));
            _clTablica.ТstrokaSet(new clTablica.Т("Трос 10 метров, тележка для транспортировки ТКВ", reoGridControl_МаршрутнаяКарта));
            _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);
            _clTablica.АtrokaSet(new clTablica.A("1", "c", "1", "Погрузка", "0022", "НБЖД№2", reoGridControl_МаршрутнаяКарта));
            _clTablica.БstrokaSet(new clTablica.Б("0921 Контейнер загрузочный", "1", "12533", "1", "1", "1", "500",
                                                  "0.1", "550", "10 мин.", "3 мин.", "7 мин.",
                                                  reoGridControl_МаршрутнаяКарта));
            _clTablica.ОstrokaSet(new clTablica.О("Переместить контейнер на рабочее место К01", reoGridControl_МаршрутнаяКарта));
            _clTablica.ТstrokaSet(new clTablica.Т("Трос 10 метров, тележка для транспортировки ТКВ", reoGridControl_МаршрутнаяКарта));
            _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);
        }

        private clTablica _clTablica = new clTablica();

        /// <summary>
        /// Раскрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            //развернуть компонент нечеткой логики
            ucNeLogik1.Width = groupPanel1_КритерииАвтоВыбора.Width-10;
            ucNeLogik1.Height = groupPanel1_КритерииАвтоВыбора.Height-10;
        }

        private void radioButton1_НечеткоеПравило_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1_МаксимальнаяСтоимость.Checked)
                ucNeLogik1.Visible = !radioButton1_МаксимальнаяСтоимость.Checked;
            else ucNeLogik1.Visible = !radioButton1_МаксимальнаяСтоимость.Checked;
            //Запуск алгоритма автопостроения
            НачатьАвтоПостроениеЛинии();
        }

        private clDBExec _clDBexec = new clDBExec();

        /// <summary>
        /// Выбран один из 7 пунктов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem1_7_Click(object sender, EventArgs e)
        {
            //Надо достать опознаватель:
            string opozn = (sender as ButtonItem).Tag.ToString();
            _structImg._tag = opozn;
            //определить пункт
            //выполнить запрос в базу+заголовки подготовить
            //вывести результат в таблицу Adv
            var masHd = _clDBexec.GetHeaderTable(opozn);
            LoadHeader(masHd);
            _clDBexec.Select(opozn);
            AddSampleData();
        }

        /// <summary>
        /// Заголовки зависят от выбранной Таблицы
        /// </summary>
        private void LoadHeader(IEnumerable<ColumnHeader> massivH)
        {
            //чистим предыдущее
            advTree1.Columns.Clear();
            foreach (var columnHeader in massivH)
            {
                advTree1.Columns.Add(columnHeader);
            }
        }

        /// <summary>
        /// Записать инфу с БД (SELECT) в AdvTree и вывести
        /// </summary>
        private void AddSampleData()
        {
            //Заполнить таблицу SELECT
            int index = 0;
            if (_clDBexec.ListSelectFull == null) return;
            //Чистим предыдущие
            advTree1.Nodes.Clear();
            foreach (AdvTree tree in _clDBexec.ListSelectFull)
            {
                while (index < Convert.ToInt32(_clDBexec.Count))
                {
                    advTree1.Nodes.Add(tree.Nodes[index]);
                    index++;
                }
            }


        }

        private string _tagActivDrgDrop;

        /// <summary>
        /// Двойной клик по ноде - выполнить Бросить компонент на Flow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advTree1_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left) return;
            
            _tagActivDrgDrop = e.Node.SelectedCell.Parent.FullPath;
            //MessageBox.Show(_tagActivDrgDrop);
            AddPanelToFlowLayoutPanel();
            //Выполнить заполнение Таблицы Операций -> Проектирование\Проектирование ТМ
            ЗаполнитьТаблицуОпераций(_structImg._tag, _tagActivDrgDrop);
        }

        private Panel _panel;
        private clDBExec.PanelImage _structImg = new clDBExec.PanelImage("null");

        /// <summary>
        /// Добавить очередрую панель на поле
        /// </summary>
        private void AddPanelToFlowLayoutPanel(params string[] param)
        {
            reflectionLabel1_НетКомпонентов.Visible = false;

            _panel = new Panel
                         {
                             Size = new Size(50, 50),
                             BackgroundImage =
                                 param.Length == 0
                                     ? _structImg.GetPanelImageForKey(_structImg._tag)
                                     : _structImg.GetPanelImageForKey(param[0]),
                             BackgroundImageLayout = ImageLayout.Stretch
                         };
            flowLayoutPanel_ВизуальныйКонтейнер.Controls.Add(_panel);
        }

        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //удалить все панели с контейнера
            flowLayoutPanel_ВизуальныйКонтейнер.Controls.Clear();
            //показать ПУСТО лейбл
            reflectionLabel1_НетКомпонентов.Visible = true;
            
            //Затереть _OP
            _OP = 00;
            //Очистить содержимое в таблице AdvTree
            advTree2_ТаблОпераций.ClearAndDisposeAllNodes();
            //Почистить формы ввода от старых заполнителей
            ОчиститьВсеПоляВвода();
            //Затереть массив с ИМЕНАМИ станков
            _clDBexec.НазванияОборудованияПоСтоимости = new List<string>();
            //Повысить номер цеха
            _НомерЦеха++;
            //Чистим массив случайных времен Тшт
            _Тшт = new List<double>();
            //Чистим массив случайных времен Тпз
            _Тпз = new List<double>();
        }

        private int _НомерЦеха = 01;

        /// <summary>
        /// Переключатель с АВТО\РУЧНОЙ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchButton_РучнойАвто_ValueChanged(object sender, EventArgs e)
        {
            //Активировать ручной режим составления линии
            //деактивировать панель
            itemPanel_СемьЭлементов.Enabled = advTree1.Visible = !switchButton_РучнойАвто.Value;
            groupPanel1_КритерииАвтоВыбора.Visible = switchButton_РучнойАвто.Value;
            
            //Запуск алгоритма подбора оборудования в автоматическом режиме
            НачатьАвтоПостроениеЛинии();
        }

        /// <summary>
        /// Запуск алгоритма подбора
        /// </summary>
        private void НачатьАвтоПостроениеЛинии()
        {
            if (!switchButton_РучнойАвто.Value) return;//для Ручной
            //Чистим пано
            очиститьПолеToolStripMenuItem_Click("", null);

            //для Авто
            //по максимальной стоимости:
            if(radioButton1_МаксимальнаяСтоимость.Checked)
                foreach (string tag in _clDBexec.GetAllCost())
                {
                    AddPanelToFlowLayoutPanel(tag);
                    //Выполнить заполнение Таблицы Операций -> Проектирование\Проектирование ТМ
                    ЗаполнитьТаблицуОпераций(tag, "");
                }

            //Заполнить Поля Маршрутной карты
            //foreach (string s in _clDBexec.НазванияОборудованияПоСтоимости)
            //{
            //    _clTablica.ТstrokaSet(new clTablica.Т(s, reoGridControl_МаршрутнаяКарта));
            //    _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);
            //}
            
        }

        private int _OP = 00;
        /// <summary>
        /// Последовательность операций
        /// </summary>
        private void ЗаполнитьТаблицуОпераций(string modul, string name)
        {
            //Очистить содержимое в таблице AdvTree//advTree2_ТаблОпераций.ClearAndDisposeAllNodes();
            //NOTE: Подобрать очередному модулю его операции
            {
                var node = new Node(string.Format("{0:0#}", _OP));
                switch ((clDBExec.Table)Enum.Parse(typeof(clDBExec.Table), modul))
                {
                    case clDBExec.Table.aglomerator:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Смешивание.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Смешивание).ToString()));
                        break;
                    case clDBExec.Table.drobilka:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Дробление.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Дробление).ToString()));
                        break;
                    case clDBExec.Table.ekstruder:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Гранулирование.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Гранулирование).ToString()));
                        break;
                    case clDBExec.Table.konteiner:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Зарузка.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Зарузка).ToString()));
                        break;
                    case clDBExec.Table.konveer:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Транспортировка.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Транспортировка).ToString()));
                        break;
                    case clDBExec.Table.magnit:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Контроль.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Контроль).ToString()));
                        break;
                    case clDBExec.Table.peskosuwilka:
                        node.Cells.Add(new Cell(clTablica.OperationEnum.Сушка.ToString()));
                        node.Cells.Add(new Cell(((int)clTablica.OperationEnum.Сушка).ToString()));
                        break;
                }
                advTree2_ТаблОпераций.Nodes.Add(node);
                //Имя пишем в массив//Стол//Код берем из Char первых символов имяни
                if(!string.IsNullOrEmpty(name))
                    _clDBexec.НазванияОборудованияПоСтоимости.Add(string.Format("{1:000000}, {0}", name, (int)name[0] + (int)name[name.Length - 1]));
            }
            _OP += 5;
        }

        /// <summary>
        /// Клик меню по кнопке А/Б/О/Т
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX_АБОТ_Click(object sender, EventArgs e)
        {
            var name = ((ButtonX) sender).Text;
            //Показать поля для заполнений
            switch (name)
            {
                case "А":
                    superTabControl1_АБОТ.SelectedTabIndex = 1;
                    break;
                case "Б":
                    superTabControl1_АБОТ.SelectedTabIndex = 2;
                    break;
                case "О":
                    superTabControl1_АБОТ.SelectedTabIndex = 3;
                    break;
                case "Т":
                    superTabControl1_АБОТ.SelectedTabIndex = 4;
                    break;
                case "00":
                    _clTablica.ПустаяСтрока(reoGridControl_МаршрутнаяКарта);
                    break;
                case ""://Таблица Операций
                    superTabControl1_АБОТ.SelectedTabIndex = 0;
                    break;
                case ""://Подтвердить
                    if(advTree2_ТаблОпераций.Nodes.Count==0) break;
                    ДобавитьДанныеСФормы();
                    //Открыть Таблицу Операций
                    superTabControl1_АБОТ.SelectedTabIndex = 0;
                    break;
            }
        }

        //Клик по строке в Таблице Операций
        private void advTree2_ТаблОпераций_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            //Чистим все поля
            ОчиститьВсеПоляВвода();
            
            var nodeClick = e.Node;
            //Заполнить строки //Опер.
            textBoxX_НОперации.Text = nodeClick.Cells[0].Text;
            //Код, наименование операции
            textBoxX_КодОперации.Text = string.Format("{1}, {0}", nodeClick.Cells[1].Text, nodeClick.Cells[2].Text);
            //Код, наименование оборудования
            textBoxX_Код.Text = _clDBexec.НазванияОборудованияПоСтоимости[nodeClick.Index];
            //Номер (код) цеха, в котором выполняется операция
            textBoxX_Цех.Text = string.Format("{0:00}", _НомерЦеха);
            //Номер (код) участка, конвеера, линии
            textBoxX_Участок.Text = string.Format("{0:00}", _НомерЦеха >= 1 ? _НомерЦеха - 1 : _НомерЦеха);
            //Номер (код) рабочего места
            textBoxX_РМесто.Text = string.Format("{0}{1:0}", _НомерЦеха, (int)nodeClick.Cells[2].Text[0]);
            //Коэфф штучного времени
            textBoxX_Кшт.Text = string.Format("{0:0.##}", КоэффШтучногоВремени(nodeClick.Index));
            //Норма подготовительно-заключительного времени
            textBoxX_Тпз.Text = string.Format("{0:0.##}", НПодгельноЗаклогоВремНаОперю(nodeClick.Index));
            //Заполнение поля Описание
            var описание = "";
            _clTablica.OpisanieOperationEnum.TryGetValue(
                (clTablica.OperationEnum) Enum.Parse(typeof (clTablica.OperationEnum), nodeClick.Cells[1].Text),
                out описание);
            textBoxX1_O.Text = описание;
            //Переключится на вкладку заполнения маршрутной карты//кнопка -А
            buttonX_АБОТ_Click(new ButtonX() { Text = "А" }, e);
        }

        /// <summary>
        /// Чистим все поля ввода АБОТ
        /// </summary>
        private void ОчиститьВсеПоляВвода()
        {
            foreach (var control in superTabControlPanel1_А.Controls)
            {
                try{((TextBoxX)control).Text = "";}
                catch (InvalidCastException){continue;}
            }
            foreach (var control in superTabControlPanel2_Б.Controls)
            {
                try { ((TextBoxX)control).Text = ""; }
                catch (InvalidCastException)
                {
                    try{((DevComponents.Editors.IntegerInput)control).Text = "";}
                    catch (InvalidCastException){continue;}
                }
            }

            textBoxX1_O.Text = "";
            textBoxX_Т.Text = "";
            label_СтрокаСостояний_А.Text =
                label_СтрокаСостояний_Б.Text =
                label_CтрокаСостояний_О.Text = label_СтрокаСостояния_Т.Text = "Строка состояний";
        }

        private void superTabItem_Оптимизация_Click(object sender, EventArgs e)
        {
            fНазванияОборудованияПоСтоимости = _clDBexec.НазванияОборудованияПоСтоимости;
        }

        public static List<string> fНазванияОборудованияПоСтоимости { get; set; }




        #region Вкладка А операций

        fОхранаТруда _fOxranaTruda = new fОхранаТруда();
        //Выбрать из окна нужные документы охран труда
        private void textBoxX6_ДокОхранаТруда_ButtonCustomClick(object sender, EventArgs e)
        {
            //Открыть окно с выбором из базы нормативных документов охраны труда
            _fOxranaTruda.ShowDialog();
            var docResult = _fOxranaTruda._chekedDoc;
            textBoxX6_ДокОхранаТруда.Text = "";
            foreach (var dstr in docResult)
                textBoxX6_ДокОхранаТруда.Text += dstr;
            
        }

        /// <summary>
        /// Кнопка ПОДТВЕРДИТЬ - вписать поля в Таблицу карты
        /// </summary>
        private void ДобавитьДанныеСФормы()
        {
            _clTablica.АtrokaSet(new clTablica.A(textBoxX_Цех.Text, textBoxX_Участок.Text, textBoxX_РМесто.Text
                                                 , textBoxX_НОперации.Text, textBoxX_КодОперации.Text,
                                                 textBoxX6_ДокОхранаТруда.Text, reoGridControl_МаршрутнаяКарта));
            _clTablica.БstrokaSet(new clTablica.Б(textBoxX_Код.Text, textBoxX_СМ.Text, textBoxX_Проф.Text
                                    , textBoxX_Р.Text, textBoxX_УТ.Text, integerInput__КР.Text,
                                    integerInput_КОИД.Text, integerInput_ЕН.Text,
                                    integerInput_ОП.Text, textBoxX_Кшт.Text, textBoxX_Тпз.Text,
                                    textBoxX_Тшт.Text, reoGridControl_МаршрутнаяКарта));
            if (!string.IsNullOrEmpty(textBoxX1_O.Text)) _clTablica.ОstrokaSet(new clTablica.О(textBoxX1_O.Text, reoGridControl_МаршрутнаяКарта));
            if (!string.IsNullOrEmpty(textBoxX_Т.Text)) _clTablica.ТstrokaSet(new clTablica.Т(textBoxX_Т.Text, reoGridControl_МаршрутнаяКарта));
        }
        //Cтрока состояний заполняем тут
        private void textBoxX6_ДокОхранаТруда_Click(object sender, EventArgs e){label_СтрокаСостояний_А.Text = ((DevComponents.DotNetBar.Controls.TextBoxX) sender).WatermarkText;}

        #endregion

        #region Вкладка Б операций

        
        //Enter//Click
        private void textBoxX_Проф_Click(object sender, EventArgs e)
        {
            VisibleUCAll();
            switch (int.Parse(((DevComponents.DotNetBar.Controls.TextBoxX)sender).Tag.ToString()))
            {
                case 2: ucСтепеньМеханизац_2.Visible = true; break;
                case 3: ucКодПроф_3.Visible = true; break;
                case 4: ucРазрядРаботы1.Visible = true; break;
                case 5: ucКодУсловийТруда1.Visible = true; break;
            }
            var ctrl = ((DevComponents.DotNetBar.Controls.TextBoxX)sender).WatermarkText;
            label_СтрокаСостояний_Б.Text = ctrl;
        }

        private void textBoxX_Проф_Leave(object sender, EventArgs e)
        {
            switch (int.Parse(((DevComponents.DotNetBar.Controls.TextBoxX)sender).Tag.ToString()))
            {
                case 2: ucСтепеньМеханизац_2.Visible = ucСтепеньМеханизац_2.ContainsFocus; break;
                case 3: ucКодПроф_3.Visible = ucКодПроф_3.ContainsFocus; break;
                case 4: ucРазрядРаботы1.Visible = ucРазрядРаботы1.ContainsFocus; break;
                case 5: ucКодУсловийТруда1.Visible = ucКодУсловийТруда1.ContainsFocus; break;
            }
        }
        //Погасить все панели СПРАВО
        private void VisibleUCAll()
        {
            foreach (Control cntrl in panel1_ДляНастроекСправо.Controls)
                cntrl.Visible = false;
        }
        //Выбрал Код Професии
        private void ucКодПроф1_ИзмененияВЛинке(object sender, EventArgs e){textBoxX_Проф.Text = ucКодПроф_3.КодПроф;}
        //Выбрал Код Механизации
        private void ucСтепеньМеханизац1_КодСтепеньМеханизацииEvent(object sender, EventArgs e){textBoxX_СМ.Text = ucСтепеньМеханизац_2.КодСтепеньМеханизации.ToString();}
        //Выбрал Разряд Работ
        private void ucРазрядРаботы1_РазрядРабот_Event(object sender, EventArgs e){textBoxX_Р.Text = ucРазрядРаботы1.РазрядРабот.ToString();}
        //Выбрал Код Условий труда
        private void ucКодУсловийТруда1_КодУсловийТруда_Event(object sender, EventArgs e){textBoxX_УТ.Text = ucКодУсловийТруда1.КодУсловийТруда.ToString();}

        private void integerInput_ОП_Click(object sender, EventArgs e)
        {
            try
            {
                var ctrl = ((DevComponents.DotNetBar.Controls.TextBoxX)sender).WatermarkText;
                label_СтрокаСостояний_Б.Text = ctrl;
            }
            catch (InvalidCastException)
            {
                var ctrl = ((DevComponents.Editors.IntegerInput)sender).WatermarkText;
                label_СтрокаСостояний_Б.Text = ctrl;
            }
        }

        /// <summary>
        /// Рассчитать Кшт=[0...1]
        /// </summary>
        /// <returns></returns>
        private double КоэффШтучногоВремени(int index)
        {
            var rnd = new Random();
            var Тшт = 0.0;
            //Кшт = Тшт\(Тшт+Тшт+..)
            var result = 0.0;
            //Если индекс есть в _Тшт[i] то берем его, иначе сгенерить новое и записать _Тшт.Add(Тшт);
            if (index < _Тшт.Count)
                Тшт = _Тшт[index];
            else
                for (int i = 0; i < advTree2_ТаблОпераций.Nodes.Count; i++)
                {
                    //от 0 до 10
                    Тшт = rnd.NextDouble() * (10.0 - 0.1) + 0.1;
                    _Тшт.Add(Тшт);
                }
            
            textBoxX_Тшт.Text = string.Format("{0:0.##}", Тшт);
            var SumТшт = 10.75;

            result = Тшт/SumТшт;
            return result;
        }

        List<double> _Тшт = new List<double>();
        List<double> _Тпз = new List<double>();

        /// <summary>
        /// Расчет Тпз=[0...100]
        /// </summary>
        /// <returns></returns>
        private double НПодгельноЗаклогоВремНаОперю(int index)
        {
            var rnd = new Random();
            //Тпз = Тпз1 + Тпз2 + Тпз3
            var Тпз = 0.0;
            if (index < _Тпз.Count)
                Тпз = _Тпз[index];
            else
                for (int i = 0; i < advTree2_ТаблОпераций.Nodes.Count; i++)
                {
                    //от 0 до 100
                    Тпз = rnd.NextDouble() * (100.0 - 0.1) + 0.1;
                    _Тпз.Add(Тпз);
                }

            return Тпз;
        }

        #endregion

        #region Вкладка О операций
        
        //Строка состояния
        private void textBoxX1_O_Click(object sender, EventArgs e)
        {
            label_CтрокаСостояний_О.Text = ((DevComponents.DotNetBar.Controls.TextBoxX) sender).WatermarkText;
        }

        #endregion
        
        #region Вкладка Т операций

        
        //Строка состояния
        private void textBoxX_Т_Click(object sender, EventArgs e)
        {
            label_СтрокаСостояния_Т.Text = ((DevComponents.DotNetBar.Controls.TextBoxX) sender).WatermarkText;
        }
        //Выбран в таблице
        private void ucТехОснастка1_ТехОснасткаEvent(object sender, EventArgs e)
        {
            textBoxX_Т.Text += ucТехОснастка1.НаименовОснастки+"; ";
        }

        #endregion

        

        

        

        

        

        






    }
}
