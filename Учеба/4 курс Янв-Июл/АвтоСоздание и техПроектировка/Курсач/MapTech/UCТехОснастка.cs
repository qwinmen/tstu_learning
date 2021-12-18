using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TestFile
{
    /// <summary>
    /// определить открытый делегат
    /// </summary>
    public delegate void listEventHandler(object sender, System.EventArgs e);

    public partial class UCТехОснастка : UserControl
    {
        /// <summary>
        /// Событие которое высвитится в событиях контрола	
        /// </summary>
        public event listEventHandler ТехОснасткаEvent;

        public UCТехОснастка()
        {
            InitializeComponent();
            Init(false);
        }
        /// <summary>
        /// Путь к файлу с классификатором
        /// </summary>
        private string _pathToFile;

        private List<string> _massiv;

        private void Init(bool flag)
        {
            _massiv = new List<string>();
            //Папка с запущенным .EXE+путь к папке Класификатора
            _pathToFile = flag ? _pathToFile : Environment.CurrentDirectory + "\\Klassifikator\\TexOsn.txt";
            //Проверить есть ли такой файл на диске
            if (File.Exists(_pathToFile)) //загрузка содержимого в массив:
                _massiv.AddRange(File.ReadAllLines(_pathToFile));

            linkLabel4_File.Text = "Файл: " +
                                   (_pathToFile.Length > 6
                                        ? (_pathToFile.Substring(_pathToFile.LastIndexOf('\\')))
                                        : _pathToFile);
            //Грузим из файла
            if (_pathToFile.Length > 6) LoadToListBox();
        }

        /// <summary>
        /// Вернуть полный путь до выбранного текстовика
        /// </summary>
        /// <returns></returns>
        private string OpenFileDialogGetPatch()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый файл|*.txt";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return _pathToFile;
            return openFileDialog.FileName;
        }

        /// <summary>
        /// Загрузить строки в листбокс
        /// </summary>
        private void LoadToListBox()
        {
            if (_massiv == null || _massiv.Count == 0) return;

            listView1.BeginUpdate();//Отключить перерисовку для добавлений полей
            listView1.Items.Clear();
            string b = "";
            var indexL = 0;

            foreach (string s in _massiv)
            {
                //5//1//text//2//4
                /*Обрезать с начало и с конца, оставшееся в text
                 * Если с начало нет - то дополнить text
                 */
                try
                {
                    var a = s.Substring(0, 5);
                    if (a.Contains("    "))
                    {
                        listView1.Items[indexL - 1].SubItems[2].Text += " " + s.Trim();
                        continue;
                    }
                    b = s.Substring(5);
                    listView1.Items.Add(new ListViewItem(new[] { a, b}));
                    indexL++;
                }
                catch (Exception)
                {
                    linkLabel4_File.Text = String.Format("Файл: {0} не подходит!", (_pathToFile.Substring(_pathToFile.LastIndexOf('\\'))));
                }
            }

            listView1.EndUpdate();//Включить перерисовку и обновить компонент
        }

        private void linkLabel4_File_Click(object sender, EventArgs e)
        {
            _pathToFile = OpenFileDialogGetPatch();
            //Вызвать Диалог Открыть Файл
            Init(true);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView) sender).SelectedItems.Count == 0) return;
            КодПроф = ((ListView)sender).SelectedItems[0].Text;
            try
            {
                НаименовОснастки = ((ListView)sender).SelectedItems[0].SubItems[1].Text;
                ТехОснасткаEvent(sender, e);
            }
            catch (System.NullReferenceException)
            {
            }
        }

        public string КодПроф { get; private set; }
        public string НаименовОснастки { get; private set; }

        private void button1_OKe_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var res = string.Format("{0}-{1}{2}{3}", rnd.Next(5), rnd.Next(9), rnd.Next(9), rnd.Next(9));
            listView1.Items.Add(new ListViewItem(new[] {res, textBox1.Text}));
            textBox1.Text = "";
        }




    }
}
