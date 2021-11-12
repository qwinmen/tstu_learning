using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
//работа с бд пунктуации
namespace Mary
{
    /// <summary>
    /// Здесь описаны все знаки препинания, которые являются разделителями между слов
    /// Идея проста - на форме есть сетка, в неё грузим пунктуацию из файла-базы.
    /// Также можно чтото удалить, чтото добавить. Все хранение в файл базы данных.
    /// </summary>
    public partial class fPunct : Form
    {
        public fPunct()
        {
            InitializeComponent();
            ReadData();
        }

        private BindingSource _bindingSource = new BindingSource();
        private OleDbConnection connection;
        private DataSet dataSet = new DataSet();

        private void ReadData()
        {
            //соединяемся с сервером
            if(CreateConnection()!=null)
            {
                connection = CreateConnection();

                //подготовим команду
                OleDbCommand command = new OleDbCommand("SELECT * FROM Punctuation");
                command.Connection = connection;

                //создаем адаптер и набор данных
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                //заполняем набор данных
                adapter.Fill(dataSet);

                //закрываем больше ненужное соединение
                connection.Close();

                //связываем набор данных с сеткой через посредника bindingSource
                dataGridView1.AutoGenerateColumns = true;
                _bindingSource.DataSource = dataSet.Tables[0];
                dataGridView1.DataSource = _bindingSource;
            }
        }

        OleDbConnection CreateConnection()
        {//C:\Users\user\Desktop\Учеба\2 курс Февр-Июль\ЛПО-КУРСАЧ\Mary\bin\Debug\
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString =
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PunctuationDB.mdb;Persist Security Info=False";
            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
                connection.Close();
            }

            return connection;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Punctuation", connection);
            //создаем обьект команды
            adapter.UpdateCommand =
                new OleDbCommand("UPDATE Punctuation SET Type = ?"+"WHERE Values = ?");

            //создать параметры связи данных
            adapter.UpdateCommand.Parameters.Add("Type", OleDbType.VarChar, 50, "Type");
            adapter.UpdateCommand.Parameters.Add("Values", OleDbType.Integer, 50, "Values");
            //++++++++

            //Реализация добавления записи из таблицы
            adapter.InsertCommand =
                new OleDbCommand("INSERT INTO Punctuation (Type)" + "VALUES (?)");
            adapter.InsertCommand.Parameters.Add("Type", OleDbType.VarChar, 50, "Type");
            adapter.InsertCommand.Connection = connection;

            //Реализация команды удаления поля из таблицы
            adapter.DeleteCommand = new OleDbCommand("DELETE FROM Punctuation WHERE Type=?");
            //adapter.DeleteCommand.Parameters.Add("Values", OleDbType.Integer, 10, "Values");
            adapter.DeleteCommand.Parameters.Add("Type", OleDbType.VarChar, 50, "Type");
            adapter.DeleteCommand.Connection = connection;

            //указать обьект соединения
            adapter.UpdateCommand.Connection = connection;

            //вызов обновления данных в базе
            adapter.Update(dataSet.Tables[0]);

            DataGridToArray(dataGridView1);

            //зактырь таблицу-форму
            if (fPunct.ActiveForm != null)
                ActiveForm.Close();
        }

        void DataGridToArray(DataGridView dataGridView)
        {
            string[] arr = new string[dataGridView.RowCount];
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (dataGridView.Rows[i].Cells[1].Value.ToString() != "" || dataGridView.Rows[i].Cells[1].Value != null)
                    arr[i] = dataGridView.Rows[i].Cells[1].Value.ToString();
            }
            if (arr.Length != 0) PunctArr = arr;
        }
        
        /// <summary>
        /// хранит строки с базы данных - знаки пунктуации
        /// </summary>
        internal static string[] PunctArr { get; private set; }//знаки препинания для FormTable.Filter()
    }
}
