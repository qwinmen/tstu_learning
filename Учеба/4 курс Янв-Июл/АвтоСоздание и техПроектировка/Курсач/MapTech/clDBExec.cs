using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace MapTech
{
    /// <summary>
    /// Взаимодействие с базой данных
    /// </summary>
    class clDBExec
    {
        private readonly OdbcConnection _connection;
        private OdbcCommand _command;
        private OdbcDataReader _reader;

        /// <summary>
        /// Все таблицы в базе Diplom
        /// </summary>
        internal enum Table
        {
            aglomerator,
            drobilka,
            ekstruder,
            konteiner,
            konveer,
            magnit,
            peskosuwilka
        }

        
        internal struct PanelImage
        {
            private Dictionary<Table, Bitmap> _resursePicture;
            /// <summary>
            /// Храним ссылку для _resursePicture[_tag]
            /// </summary>
            internal string _tag;
            public PanelImage(string tag)
            {
                _resursePicture = new Dictionary<Table, Bitmap>
                                      {
                                          {Table.aglomerator, global::MapTech.Properties.Resources.Агломератор},
                                          {Table.drobilka, global::MapTech.Properties.Resources.Дробилка},
                                          {Table.ekstruder, global::MapTech.Properties.Resources.Экструдер},
                                          {Table.konteiner, global::MapTech.Properties.Resources.Контеинер},
                                          {Table.konveer, global::MapTech.Properties.Resources.Конвеер},
                                          {Table.magnit, global::MapTech.Properties.Resources.Магнит},
                                          {Table.peskosuwilka, global::MapTech.Properties.Resources.Сушилка}
                                      };
                _tag = tag;
            }
            /// <summary>
            /// Вернуть рисунок по ключу Таблицы
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public Bitmap GetPanelImageForKey(string key)
            {
                return _resursePicture[(Table)Enum.Parse(typeof(Table), key)];
            }
        }

        public clDBExec()
        {
            //"Dsn=MySQL ODBC Unicode;uid=root;"
            //server=localhost;User Id=root;Persist Security Info=True;database=Diplom
            _connection =
                new OdbcConnection(
                    "Dsn=MySQL ODBC Unicode;server=localhost;User Id=root;Persist Security Info=True;database=Diplom");

            ConnectionState = OpenConnection();
            if (ConnectionState)
            {
                _command = _connection.CreateCommand();
                CountAll(Table.aglomerator.ToString());
                CountRows(Table.aglomerator.ToString());

                SelectAll(Table.aglomerator.ToString());

            }
        }

        /// <summary>
        /// Открыть соединение
        /// </summary>
        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения с БД " + ex);
                //lblStateConnect.BackColor = Color.Red;
                return false;
            }
        }

        /// <summary>
        /// Состояние соединения
        /// </summary>
        public bool ConnectionState { get; private set; }

        /// <summary>
        /// Вывести све значения в таблице nameTabl
        /// </summary>
        private void SelectAll(string nameTabl)
        {
            _command.CommandText = "Select * from "+nameTabl;

            _reader = _command.ExecuteReader();

            AdvTree advTree = new AdvTree();
            AdvTree advTreeFull = new AdvTree();

            Object[] row = new object[_reader.FieldCount];
            while (_reader.Read())
            {
                _reader.GetValues(row);
                advTree.Nodes.Add(CreateInvoiceRow(row));

                advTreeFull.Nodes.Add(ReturnFullTablesParam(row));
            }
            ListSelectAll = new List<AdvTree> { advTree };
            ListSelectFull = new List<AdvTree> { advTreeFull };

            //Закрыть набор
            _reader.Close();
        }

        /// <summary>
        /// Контейнер для запроса Select
        /// </summary>
        public List<AdvTree> ListSelectAll { get; private set; }

        /// <summary>
        /// Контейнер для возврата всего что есть в таблице
        /// </summary>
        public List<AdvTree> ListSelectFull { get; private set; }

        private Node CreateInvoiceRow(Object[] row)//(DateTime date, string clientName, double invoiceAmount, string invoiceFileName)
        {
            //name:
            Node node = new Node(row[0].ToString());
            //h21:
            node.Cells.Add(new Cell(row[1].ToString()));
            //описание:
            node.Cells.Add(new Cell(row[2].ToString()));
            node.Tag = row[0].ToString();
            return node;
        }

        /// <summary>
        /// Выпилить все значения из ответа от базы
        /// </summary>
        private Node ReturnFullTablesParam(Object[] row)
        {
            string tmp = "";
            //name:
            var node = new Node(row[0].ToString());
            for (int i = 1; i < CountRow; i++)
            {
                node.Cells.Add(new Cell(row[i].ToString()));
                tmp += (row[i].ToString());
            }
            node.Tag = row[0].ToString();
            return node;
        }

        /// <summary>
        /// Выпилить все значения из ответа от базы
        /// </summary>
        private Node ReturnFullTablesParam(Object[] row, bool flag)
        {
            string tmp = "";
            //name:
            var node = new Node(row[0].ToString());
            for (int i = 1; i < row.Length; i++)
            {
                node.Cells.Add(new Cell(row[i].ToString()));
                tmp += (row[i].ToString());
            }
            node.Tag = row[0].ToString();
            return node;
        }

        /// <summary>
        /// Количество записей в таблице nameTabl
        /// </summary>
        private void CountAll(string nameTabl)
        {
            _command.CommandText = "Select count(*) from " + nameTabl;
            var number = _command.ExecuteScalar();
            Count = number.ToString();
        }

        /// <summary>
        /// Количество записей
        /// </summary>
        public string Count { get; private set; }

        /// <summary>
        /// Количество столбцов в таблице nameTable
        /// </summary>
        private void CountRows(string nameTable)
        {
            _command.CommandText =
                string.Format("SELECT count(*) FROM information_schema.COLUMNS WHERE TABLE_NAME='{0}'", nameTable);
            
            var number = _command.ExecuteScalar();
            CountRow = Convert.ToInt32(number);
        }

        /// <summary>
        /// Количество столбцов
        /// </summary>
        public int CountRow { get; private set; }

        /// <summary>
        /// Закрыть соединение
        /// </summary>
        public void ClosedConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        /// <summary>
        /// Выполнить команду UPDATE в БД.
        /// Имя поля Name обязательно!
        /// </summary>
        internal void UpdateStr(string name, params KeyValuePair<string, string>[] param)
        {
            //--Update transistor set ik0=20, ik1=120, tc0=11 where `name` = 'ГТ308А';
            //если имя не пусто тогда
            if (!String.IsNullOrEmpty(name))
            {
                _command.CommandText = "Update transistor set ";
                //"ik0 = 11, ik1 = 53 where `name` = {btnIName.Text}"
                foreach (KeyValuePair<string, string> s in param)
                {
                    if (s.Key == null && s.Value == null) continue;

                    if (s.Key != null)
                        if (s.Key.Contains("h21") || s.Key.Contains("title") || s.Key.Contains("picture") || s.Value == "")
                            _command.CommandText += " " + s.Key + "='" + s.Value + "' , ";
                        else
                        {
                            if (!s.Value.Contains(',')) _command.CommandText += " " + s.Key + "=" + s.Value + " , ";
                            else _command.CommandText += " " + s.Key + "='" + s.Value.Replace(',', '.') + "' , ";
                        }
                }
                _command.CommandText += ("where `name` = " + "'" + name + "'");

                //удалить последний знак ','
                _command.CommandText = _command.CommandText.Remove((_command.CommandText.LastIndexOf(',')), 1);
                //MessageBox.Show(_command.CommandText);
                //Выполнить команду
                _command.ExecuteReader();
                //Закрыть набор
                _reader.Close();

            }

        }

        /// <summary>
        /// Выполнить команду INSERT в БД.
        /// Имя поля Name обязательно!
        /// </summary>
        internal void InsertStr(string name, params KeyValuePair<string, string>[] param)
        {
            /*
             insert into transistor (name, ik0, ik1 , uk0, uk1, uk2, pk , tc0 , tc1 , tc2 , h21 , ukb ,
                                        ikb , uke , ikbo, fgr, kh, ck, ca, tpac, rtnc, title, picture)
                             values ('1Т308Г', 50, 120, 15, 20, 3, 150, 45, 85, 70, '100...300', 1,
                                        10, null, 5, 120, 6, 8, 22, null, null, 
                        'для работы в автогенераторах, усилителях мощности, импульсных схемах', 'p32')
             */
            //если имя не пусто тогда
            if (!string.IsNullOrEmpty(name))
            {
                _command.CommandText = "insert into transistor ( ";
                //"s.Key, s.Key, s.Key ) "
                foreach (KeyValuePair<string, string> s in param)
                {
                    if (string.IsNullOrEmpty(s.Key)) continue;

                    if (s.Key.Contains("h21") || s.Key.Contains("title") || s.Key.Contains("picture"))
                        _command.CommandText += " " + s.Key + " , ";
                    else
                    {
                        if (!s.Key.Contains(',')) _command.CommandText += " " + s.Key + " , ";
                        else _command.CommandText += " " + s.Key.Replace(',', '_') + " , ";
                    }
                }
                //удалить последний знак ','
                _command.CommandText = _command.CommandText.Remove((_command.CommandText.LastIndexOf(',')), 1);

                //") values ( "
                _command.CommandText += (") values ( ");

                //" s.Value, s.Value, s.Value )"
                foreach (KeyValuePair<string, string> s in param)
                {
                    if (s.Value == null) continue;

                    if (s.Key.Contains("h21") || s.Key.Contains("title") || s.Key.Contains("picture") || s.Value == "" || s.Key.Contains("name"))
                        _command.CommandText += " '" + s.Value + "' , ";
                    else
                    {
                        if (!s.Value.Contains(',')) _command.CommandText += " " + s.Value + " , ";
                        else _command.CommandText += " " + s.Value.Replace(',', '.') + " , ";
                    }
                }
                //удалить последний знак ','
                _command.CommandText = _command.CommandText.Remove((_command.CommandText.LastIndexOf(',')), 1);

                //")"
                _command.CommandText += (")");

                //MessageBox.Show(_command.CommandText);
                //Выполнить команду
                _command.ExecuteReader();
                //Закрыть набор
                _reader.Close();

            }

        }

        /// <summary>
        /// Выполнить команду DELETE в БД.
        /// Имя поля Name обязательно!
        /// </summary>
        internal void DeleteStr(string name, string nameTabl)
        {
            //--Delete From transistor where name = '{btnIName}'
            //если имя пусто тогда//гарантируем заполненый поля
            if (String.IsNullOrEmpty(name))
                return;

            _command.CommandText = string.Format("Delete From {0} where name = '", nameTabl);
            
            _command.CommandText += name + "'";
            //MessageBox.Show(_command.CommandText);

            //Выполнить команду
            _command.ExecuteReader();
            //Закрыть набор
            _reader.Close();

        }

        /// <summary>
        /// Выполнить команду SHOW в БД.
        /// </summary>
        internal void ShowTable(string nameTabl)
        {
            _command = _connection.CreateCommand();
            //--SHOW COLUMNS FROM transistor;
            _command.CommandText = "SHOW COLUMNS FROM " + nameTabl;
            //Выполнить команду
            _reader = _command.ExecuteReader();
            var advTreeFull = new AdvTree();

            var row = new object[_reader.FieldCount];
            while (_reader.Read())
            {
                _reader.GetValues(row);
                advTreeFull.Nodes.Add(ReturnFullTablesParam(row, true));
            }
            ListShowAll = new List<AdvTree> { advTreeFull };
            CountShow = advTreeFull.Nodes.Count;
            //Закрыть набор
            _reader.Close();
            _command.Cancel();
        }


        /// <summary>
        /// Количество полей
        /// </summary>
        public int CountShow { get; private set; }

        /// <summary>
        /// Контейнер для запроса SHOW
        /// </summary>
        public List<AdvTree> ListShowAll { get; private set; }

        /// <summary>
        /// Вывести вcе значения в таблице
        /// </summary>
        internal void Select(string nameTabl)
        {
            CountAll(nameTabl);
            CountRows(nameTabl);

            _command = _connection.CreateCommand();
            _command.CommandText = "Select * from "+nameTabl;
            _reader = _command.ExecuteReader();

            AdvTree advTree = new AdvTree();
            AdvTree advTreeFull = new AdvTree();

            Object[] row = new object[_reader.FieldCount];
            while (_reader.Read())
            {
                _reader.GetValues(row);
                advTree.Nodes.Add(CreateInvoiceRow(row));

                advTreeFull.Nodes.Add(ReturnFullTablesParam(row));
            }
            ListSelectAll.Clear(); ListSelectFull.Clear();
            ListSelectAll = new List<AdvTree> { advTree };
            ListSelectFull = new List<AdvTree> { advTreeFull };

            //Обновить количество записей Поле
            Count = advTreeFull.Nodes.Count.ToString();

            //Закрыть набор
            _reader.Close();
        }

        /// <summary>
        /// Выполнить поиск строки в БД
        /// </summary>
        internal void SelectLink(KeyValuePair<string, KeyValuePair<string, string>>[] str)
        {
            //<число, <"AND","AND"> >
            //<pole, <maska, value> >

            //"Select * from transistor where pole like `maska+value+maska` AND ..."

            _command = _connection.CreateCommand();
            _command.CommandText = "Select * from transistor where";// name like '%А'";
            //проверить строка - число?
            Regex rxNums = new Regex(@"^\d+$"); // любые цифры

            bool flagLogikaAdd = false;

            //обработать строку запроса
            foreach (var keyValuePair in str)
            {
                if (string.IsNullOrEmpty(keyValuePair.Key))
                    continue;

                if (rxNums.IsMatch(keyValuePair.Key))
                {//MessageBox.Show("Это число.");
                    //для логики число - значение
                    //keyValuePair.Key || keyValuePair.Value
                    _command.CommandText += " " + keyValuePair.Value.Key + " ";
                    //сообщить о логике
                    flagLogikaAdd = true;
                }
                else
                {//MessageBox.Show("Это не число.");
                    //для ПОЛЕ(Key) - МАСКА(Value.Key) - ЗНАЧЕНИЕ(Value.Value):
                    //keyValuePair.Key || keyValuePair.Value.Key || keyValuePair.Value.Value

                    //сбросить логику
                    flagLogikaAdd = false;
                    //поле:
                    _command.CommandText += " " + keyValuePair.Key + " like ";
                    //маска:
                    switch (keyValuePair.Value.Key)
                    {
                        case "заканчивая"://значение:
                            _command.CommandText += " '" + ("%" + keyValuePair.Value.Value) + "' ";
                            break;
                        case "начиная с"://значение:
                            _command.CommandText += " '" + (keyValuePair.Value.Value + "%") + "' ";
                            break;
                        case "содержит"://значение:
                            _command.CommandText += " '" + ("%" + keyValuePair.Value.Value + "%") + "' ";
                            break;
                        default:
                            _command.CommandText += " '" + ("%" + keyValuePair.Value.Value + "%") + "' ";
                            break;
                    }
                }
            }

            //если в true то отпилить из запроса последний OR или AND
            if (flagLogikaAdd)
            {
                //удалить последний знак логики
                _command.CommandText =
                    _command.CommandText.Remove(
                        (_command.CommandText.LastIndexOf("AND")) > (_command.CommandText.LastIndexOf("OR"))
                            ? (_command.CommandText.LastIndexOf("AND"))
                            : (_command.CommandText.LastIndexOf("OR")), 3);
            }

            //MessageBox.Show(_command.CommandText);

            try
            {
                //выполнить запрос
                _reader = _command.ExecuteReader();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при составлении поиска: " + _command.CommandText);
                return;
            }

            //Получить ответ
            AdvTree advTreeFull = new AdvTree();

            Object[] row = new object[_reader.FieldCount];
            while (_reader.Read())
            {
                _reader.GetValues(row);
                advTreeFull.Nodes.Add(ReturnFullTablesParam(row));
            }

            ListSelectLink = new List<AdvTree> { advTreeFull };

            //Обновить количество записей Поле
            CountLink = advTreeFull.Nodes.Count;

            //Закрыть набор
            _reader.Close();
        }

        /// <summary>
        /// Контейнер для запроса SelectLink
        /// </summary>
        public List<AdvTree> ListSelectLink { get; private set; }
        /// <summary>
        /// Количество записей
        /// </summary>
        public int CountLink { get; private set; }

        /// <summary>
        /// Вернуть набор для таблицы
        /// </summary>
        /// <param name="nameTabl"></param>
        public List<DevComponents.AdvTree.ColumnHeader> GetHeaderTable(string nameTabl)
        {
            DevComponents.AdvTree.ColumnHeader columnHeader1;
            var listRes = new List<DevComponents.AdvTree.ColumnHeader>();
            var str = new[] {"null"};//для заголовков таблицы

            switch ((Table)Enum.Parse(typeof(Table), nameTabl))
            {
                case Table.aglomerator://`имя`, `цена`, `фото`, `производительность`, `размергранулы`, `чвротор`, `мощность`, `габариты`, `загрузпроем`, `ножи`, `масса`
                    {
                        str = new[]
                                      {
                                          "Название", "Цена (руб)", "Фото", "Производительность (кг\\ч)",
                                          "Размер гранул (мм)", "Частота вращения ротора (об\\мин)", "Мощность (кВт)",
                                          "Габариты ДхШхВ (мм)", "Загруз проем (мм)", "Ножи (шт)", "Масса (кг)"
                                      };
                    }
                    break;
                case Table.drobilka://`имя`, `цена`, `фото`, `производительность`, `мощность`, `загрузпроем`, `ротацнож`, `стационнож`, `габариты`, `масса`
                    {
                        str = new[]
                                      {
                                          "Название", "Цена (руб)", "Фото", "Производительность (кг\\ч)",
                                          "Мощность (кВт)", "Загруз проем (мм)", "Ротацион ножи (шт)",
                                          "Стационар ножи (шт)",
                                          "Габариты ДхШхВ (мм)", "Масса (кг)"
                                      };
                    }
                    break;
                case Table.ekstruder://`имя`, `цена`, `фото`, `производительность`, `скоростьшнека`, `регулиртемпература`, `погрешностьтемператур`, `мощность`, `габариты`
                    {
                        str = new[]
                                      {
                                          "Название", "Цена (руб)", "Фото", "Производительность (кг\\ч)",
                                          "Скор вращ шнека (об\\мин)",
                                          "Диап регул температуры (*С)", "Погреш температуры (*С)",
                                          "Мощность (кВт)", "Габариты ДхШхВ (мм)"
                                      };
                    }
                    break;
                case Table.konteiner://`имя`, `описание`, `цена`, `фото`, `температура`, `размеры`, `грузоподьемность`, `вес`, `толщина`, `конструкция`, `окраска`, `цвет`, `обьем`
                    {
                        str = new[]
                                      {
                                          "Название", "Описание", "Цена (руб)", "Фото", "Температура (*С)",
                                          "Габариты ДхШхВ (мм)", "Грузоподъемность (кг)",
                                          "Вес (кг)", "Толщина металла (мм)", "Конструкция", "Окраска", "Цвет",
                                          "Объем (л)"
                                      };
                    }
                    break;
                case Table.konveer://`имя`, `цена`, `фото`, `ширина`, `длина`, `скорость`, `наклон`, `привод`, `дипривод`, `динатяжного`, `дироликов`
                    {
                        str = new[]
                                      {
                                          "Название", "Цена (руб)", "Фото", "Ширина ленты (мм)", "Длина (м)",
                                          "Скорость (м\\с)", "Угол наклона (град)", "Привод", "Диам привода (мм)",
                                          "Диам натяж (мм)", "Диам роликов (мм)"
                                      };
                    }
                    break;
                case Table.magnit://`имя`, `цена`, `фото`, `габариты`, `ширина`, `глубина`, `масса`
                    {
                        str = new[]
                                      {
                                          "Название", "Цена (руб)", "Фото", "Габариты ДхШхВ (мм)", "Ширина ленты (мм)",
                                          "Глубина извлечения (мм)", "Масса (кг)"
                                      };
                    }
                    break;
                case Table.peskosuwilka://`имя`, `цена`, `фото`, `производительность`, `фракциявыход`, `влажностьвыход`, `чвротор`, `мощность`, `температуракамеры`, `времянагревакамеры`, `времясушки`, `загрузка`, `габариты`, `масса`
                    {
                        str = new[]
                                      {
                                          "Название", "Цена (руб)", "Фото", "Производительность (кг\\ч)",
                                          "Велич фракц песка (мм)", "Влажность выход (%)", "Частота вращения (об\\мин)",
                                          "Мощность (кВт)", "Нагрев камеры (*С)", "Разогрев камеры (мин)",
                                          "Время сушки (мин)", "Кол загруж материала (кг)",
                                          "Габариты ДхШхВ (мм)", "Масса (кг)"
                                      };
                    }
                    break;
                default:
                    break;
            }

            foreach (string s in str)
            {
                columnHeader1 = new DevComponents.AdvTree.ColumnHeader { Text = s };
                columnHeader1.Width.Absolute = s.Length * 8;
                listRes.Add(columnHeader1);
            }

            return listRes;
        }

        /// <summary>
        /// Вернуть список _tag с макс ценами из всех таблиц
        /// </summary>
        internal List<string> GetAllCost()
        {
            var resList = new List<string>();
            var tmp = new string[10];//Note: 10 потому что в Table 7 элементов
            var jTmp = 0;
            for (var i = Table.aglomerator; i <= Table.peskosuwilka; i++, jTmp++)
                tmp[jTmp] = i.ToString();
            //Выставить в порядке
            resList.Add(tmp[3]); resList.Add(tmp[4]); resList.Add(tmp[1]); resList.Add(tmp[4]);
            resList.Add(tmp[5]); resList.Add(tmp[2]); resList.Add(tmp[0]); resList.Add(tmp[4]);
            //-------------------------------------------------
            //В БД все макс стоимости:
            /*
SELECT имя, max(цена) as cost FROM drobilka 
union all SELECT имя, max(цена) FROM peskosuwilka
union all SELECT имя, max(цена) FROM magnit
union all SELECT имя, max(цена) FROM aglomerator
union all SELECT имя, max(цена) FROM ekstruder
union all SELECT имя, max(цена) FROM konteiner
union all SELECT имя, max(цена) FROM konveer             */
            var list = new List<string>();
            foreach (var VARIABLE in resList)
            {
                SelectOrderBy(VARIABLE);
                foreach (var dsd in ListSelectFull.Select(tree => tree.Nodes[0]))
                {
                    list.Add(string.Format("{1:000000}, {0}", dsd.Text, (int)dsd.Text[0]+(int)dsd.Text[dsd.Text.Length - 1]));
                    break;
                }
            }
            НазванияОборудованияПоСтоимости = list;

            //-------------------------------------------------););
            return resList;
        }

        internal List<string> НазванияОборудованияПоСтоимости { get; set; }

        /// <summary>
        /// Сортировка по колонке "цена"
        /// </summary>
        private void SelectOrderBy(string nameTabl)
        {
            CountAll(nameTabl);
            CountRows(nameTabl);

            _command = _connection.CreateCommand();
            _command.CommandText = "Select * from " + nameTabl + " order by цена desc";
            _reader = _command.ExecuteReader();

            AdvTree advTree = new AdvTree();
            AdvTree advTreeFull = new AdvTree();

            Object[] row = new object[_reader.FieldCount];
            while (_reader.Read())
            {
                _reader.GetValues(row);
                advTree.Nodes.Add(CreateInvoiceRow(row));

                advTreeFull.Nodes.Add(ReturnFullTablesParam(row));
            }
            ListSelectAll.Clear(); ListSelectFull.Clear();
            ListSelectAll = new List<AdvTree> { advTree };
            ListSelectFull = new List<AdvTree> { advTreeFull };

            //Обновить количество записей Поле
            Count = advTreeFull.Nodes.Count.ToString();

            //Закрыть набор
            _reader.Close();
        }

    }
}
