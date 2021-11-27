using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace Vika
{
    /// <summary>
    /// Описание всех команд для базы transistor
    /// </summary>
    class clBDCommand
    {
        private readonly OdbcConnection _connection;
        private OdbcCommand _command;
        private OdbcDataReader _reader;
         
        public clBDCommand()
        {
            //server=localhost;pooling=False;database=test;Convert Zero Datetime=True;Character Set=utf8;Check Parameters=False;Allow User Variables=True;User Id=root;port=3306;Integrated Security=False

            _connection = new OdbcConnection("Dsn=MySQL ODBC Unicode;uid=root;");
            
            ConnectionState = OpenConnection();
            if(ConnectionState)
            {
                _command = _connection.CreateCommand();
                CountAll();
                CountRows();

                SelectAll();

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
        /// Вывести све значения в таблице
        /// </summary>
        private void SelectAll()
        {
            _command.CommandText = "Select * from microsxema";
            
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
            ListSelectAll = new List<AdvTree> {advTree};
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
            node.Cells.Add(new Cell(row[10].ToString()));
            //описание:
            node.Cells.Add(new Cell(row[21].ToString()));
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
        /// Количество записей в таблице
        /// </summary>
        private void CountAll()
        {
            _command.CommandText = "Select count(*) from microsxema";
            var number = _command.ExecuteScalar();
            Count = number.ToString();
        }
        /// <summary>
        /// Количество записей
        /// </summary>
        public string Count { get; private set; }

        /// <summary>
        /// Количество столбцов в таблице
        /// </summary>
        private void CountRows()
        {
            _command.CommandText = "SELECT count(*) FROM information_schema.COLUMNS WHERE TABLE_NAME='microsxema'";
            
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
            if(!String.IsNullOrEmpty(name))
            {
                _command.CommandText = "Update microsxema set ";
                //"ik0 = 11, ik1 = 53 where `name` = {btnIName.Text}"
                foreach (KeyValuePair<string, string> s in param)
                {
                    if(s.Key == null && s.Value == null) continue;

                    if (s.Key != null)
                        if (s.Key.Contains("h21") || s.Key.Contains("title") || s.Key.Contains("picture") || s.Value == "")
                            _command.CommandText += " " + s.Key + "='" + s.Value + "' , ";
                        else
                        {
                            if(!s.Value.Contains(',')) _command.CommandText += " " + s.Key + "=" + s.Value + " , ";
                            else _command.CommandText += " " + s.Key + "='" + s.Value.Replace(',','.') + "' , ";
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
                _command.CommandText = "insert into microsxema ( ";
                //"s.Key, s.Key, s.Key ) "
                foreach (KeyValuePair<string, string> s in param)
                {
                    if (string.IsNullOrEmpty(s.Key)) continue;

                    if (s.Key.Contains("h21") || s.Key.Contains("title") || s.Key.Contains("picture"))
                        _command.CommandText += " " + s.Key + " , ";
                    else
                    {
                        if (!s.Key.Contains(',')) _command.CommandText += " " + s.Key +" , ";
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
        internal void DeleteStr(string name)
        {
            //--Delete From transistor where name = '{btnIName}'
            //если имя пусто тогда//гарантируем заполненый поля
            if (String.IsNullOrEmpty(name))
                return;

            _command.CommandText = "Delete From microsxema where name = '";

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
        internal void ShowTable()
        {
            _command = _connection.CreateCommand();
            //--SHOW COLUMNS FROM transistor;
            _command.CommandText = "SHOW COLUMNS FROM microsxema";
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
        /// Вывести све значения в таблице
        /// </summary>
        internal void Select()
        {
            _command = _connection.CreateCommand();
            _command.CommandText = "Select * from microsxema";
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
            _command.CommandText = "Select * from microsxema where";// name like '%А'";
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
                MessageBox.Show("Ошибка при составлении поиска: "+_command.CommandText);
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

    }
}
