using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestFile
{
    /// <summary>
    /// определить открытый делегат button_Click
    /// </summary>
    public delegate void chEventHandler(object sender, EventArgs e);

    public partial class UCКодПроф : UserControl
    {
        public UCКодПроф()
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
            _pathToFile = flag ? _pathToFile : Environment.CurrentDirectory + "\\Klassifikator\\KlProff.txt";
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
            string txt = "", b = "", e = "", c = "";
            var indexL = 0;

            foreach (string s in _massiv)
            {
                /*
                 10019   6   Автоклавщик - сушильщик аккумуляторных      19    8290
                             ластин в производстве свинцовых
                             аккумуляторов
                 10021   3   Автоматчик                                  02    8211
                 */
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
                    b = s.Substring(5, 5);
                    e = s.Substring(s.Length - 4 - 6, 2);
                    c = s.Substring(s.Length - 4, 4);
                    txt = s.Substring(10, (s.Length - a.Length - b.Length - e.Length - c.Length) - 4).Trim();
                    listView1.Items.Add(new ListViewItem(new[] { a, b, txt, e, c }));
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

        private int indexBgColor = 0;
        /// <summary>
        /// Вводим ориентир - Первая буква проффесии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_InSearch_TextChanged(object sender, EventArgs e)
        {
            listView1.Items[indexBgColor].BackColor = Color.White;
            var txt = textBox1_InSearch.Text;
            if (txt.Length != 0)
                txt = txt.Replace(txt[0], char.ToUpper(txt[0]));

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (!listView1.Items[i].SubItems[2].Text.Contains(txt)) continue;
                listView1.EnsureVisible(i);
                listView1.Items[i].BackColor = Color.LightBlue;
                listView1.Items[i].Selected = true;
                indexBgColor = i;
                break;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count != 0)
            {
                КодПроф = ((ListView)sender).SelectedItems[0].Text;
                НаименовПроф = ((ListView)sender).SelectedItems[0].SubItems[2].Text;
            }

            //отразить в лейбл индекс професси
            label1.Text = КодПроф;
        }

        public string КодПроф { get; private set; }
        public string НаименовПроф { get; private set; }

        private void button1_OKe_Click(object sender, EventArgs e)
        {
            //Скрыть форму
            this.Visible = false;
        }

        /// <summary>
        /// Событие которое высвитится в событиях контрола	
        /// </summary>
        public event chEventHandler ИзмененияВЛинке;

        private void linkLabel4_File_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ИзмененияВЛинке(sender, e);
            }
            catch (NullReferenceException)
            {}
        }




    }
}
