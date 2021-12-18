using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using GModel;

//вариант 8//система выбора заготовки//AKiTP.pdf
namespace DataMaster
{
    public partial class Form1 : MetroAppForm
    {
        ucStartPanel _StartControl = null; // Start control displayed on startup
        MetroBillCommands _Commands = null; // All application commands

        public Form1()
        {
            InitializeComponent();


            // Prepare commands
            _Commands = new MetroBillCommands
            {
                ToggleStartControl = new Command(components)
            };
            //Подпись на Метод Детали
            _Commands.ToggleStartControl.Executed += ToggleStartControlExecuted;
            //Нажал на плитку Метод Заготовки
            _Commands.DevComponents = new Command(components, DevComponentsExecuted);
            //Нажал на плитку Метод Каталог
            _Commands.NotImplemented = new Command(components, NotImplementedExecuted);
            

            // Initialize Client related commands
            _Commands.ClientCommands.New = new Command(components); // We pass in components from Form so the command gets disposed automatically when form is disposed
            _Commands.ClientCommands.New.Executed += NewClientExecuted;
            _Commands.ClientCommands.Cancel = new Command(components);
            _Commands.ClientCommands.Cancel.Executed += CancelClientExecuted;
            _Commands.ClientCommands.Save = new Command(components);
            _Commands.ClientCommands.Save.Executed += SaveClientExecuted;
            // Invoice related commands
            _Commands.InvoiceCommands.New = new Command(components); // We pass in components from Form so the command gets disposed automatically when form is disposed
            _Commands.InvoiceCommands.New.Executed += NewInvoiceExecuted;
            _Commands.InvoiceCommands.Cancel = new Command(components);
            _Commands.InvoiceCommands.Cancel.Executed += CancelInvoiceExecuted;
            _Commands.InvoiceCommands.Save = new Command(components);
            _Commands.InvoiceCommands.Save.Executed += SaveInvoiceExecuted;
            // General commands
            _Commands.ChangeMetroTheme = new Command(components, ChangeMetroThemeExecuted);

            this.SuspendLayout();
            /*
             РАСПОЛОЖИТЬ СЛАЙДПАНЕЛЬ НИЖЕ КНОПОК УПРАВЛЕНИЯ ВЕРХНИЙ КРАЙ ФОРМЫ 
             */
            _StartControl = new ucStartPanel { Location = new Point(0, 28), Commands = _Commands };
            this.Controls.Add(_StartControl);
            _StartControl.BringToFront();

            //боковой язычёк
            _StartControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;

            //клик по всей области главной формы
            _StartControl.Click += new EventHandler(StartControl_Click);
            this.ResumeLayout(false);

            // Assign commands to toolbar buttons
            newInvoiceButton.Command = _Commands.InvoiceCommands.New;

            // Генератор тем
            MetroColorGeneratorParameters[] metroThemes = MetroColorGeneratorParameters.GetAllPredefinedThemes();
            foreach (ButtonItem theme in metroThemes.Select(mt => new ButtonItem(mt.ThemeName, mt.ThemeName)
            {
                Command = _Commands.ChangeMetroTheme,
                CommandParameter = mt
            }))
            {
                colorThemeButton.SubItems.Add(theme);
            }

        }


        /// <summary>
        /// Плитка Add New Clients
        /// </summary>
        private void NewClientExecuted(object sender, EventArgs e)
        {
            MessageBox.Show("CLIENTURE");
            if (!_StartControl.Visible)
                _StartControl.SlideOutButtonVisible = false;
        }

        private void CancelClientExecuted(object sender, EventArgs e)
        {
            // Simply close client entry form "dialog"
            CloseClientDialog();
        }

        private void CloseClientDialog()
        {
            if (!_StartControl.Visible)
                _StartControl.SlideOutButtonVisible = true;

            _Commands.ClientCommands.New.Enabled = true; // Enable new client command
        }

        void SaveClientExecuted(object sender, EventArgs e)
        {
            // Here we would save new client to the storage of choice then close the "dialog"
            CloseClientDialog();
        }

        void NewInvoiceExecuted(object sender, EventArgs e)
        {
            _Commands.InvoiceCommands.New.Enabled = false; // Disable new invoice command to prevent re-entrancy
            if (!_StartControl.Visible)
                _StartControl.SlideOutButtonVisible = false;
        }

        private void CancelInvoiceExecuted(object sender, EventArgs e)
        {
            // Simply close invoice entry form "dialog"
            CloseInvoiceDialog();
        }

        private void CloseInvoiceDialog()
        {
            if (!_StartControl.Visible)
                _StartControl.SlideOutButtonVisible = true;

            _Commands.InvoiceCommands.New.Enabled = true; // Enable new invoice command
        }

        void SaveInvoiceExecuted(object sender, EventArgs e)
        {
            // Here we would save new invoice to the storage of choice then close the "dialog"
            CloseInvoiceDialog();
        }

        private void ChangeMetroThemeExecuted(object sender, EventArgs e)
        {
            ICommandSource source = (ICommandSource)sender;
            MetroColorGeneratorParameters theme = (MetroColorGeneratorParameters)source.CommandParameter;
            StyleManager.MetroColorGeneratorParameters = theme;
        }


        #region Методы плитки


        private clBolt _bolt = new clBolt();
        private clZagotovka _zagatovka = new clZagotovka();

        /// <summary>
        /// Нажал на плитку Детали
        /// </summary>
        private void ToggleStartControlExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("метод Детали");
            _StartControl.IsOpen = !_StartControl.IsOpen;
            //Активируем вкладку 1
            metroTabItem1.Select();
            listViewEx1 = _bolt.GetListViewEx(listViewEx1, imageList1, "Изделие");

            ClearClassLink(0);
        }

        /// <summary>
        /// Нажал на плитку Метод Каталог
        /// </summary>
        private void NotImplementedExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("метод Каталог");
            _StartControl.IsOpen = !_StartControl.IsOpen;
            //инициализация класса
            //_ermit = new clErmit(zedGraph);
            metroTabItemSearch.Select();

            ClearClassLink(2);
        }

        /// <summary>
        /// Нажал на плитку Метод Заготовки
        /// </summary>
        private void DevComponentsExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("метод Заготовки");
            _StartControl.IsOpen = !_StartControl.IsOpen;
            metroTabItem2.Select();
            listViewEx2 = _zagatovka.GetListViewEx(listViewEx2, imageList2, "Болванка");

            ClearClassLink(1);
        }

        /// <summary>
        /// Клик по области вокруг плиток
        /// </summary>
        private void StartControl_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Клик по области вокруг плиток");
            //Открыть последнюю рабочую область
            //_StartControl.IsOpen = false;
            ToggleStartControlExecuted(sender, e);
        }

        #endregion




        #region Изменение размеров при изменениях формы

        private void metroTabItem1_Click(object sender, EventArgs e)
        {
            listViewEx1 = _bolt.GetListViewEx(listViewEx1, imageList1, "Изделие");
            UpdateControlsSizeAndLocation();
        }

        private void metroTabItem2_Click(object sender, EventArgs e)
        {
            listViewEx2 = _zagatovka.GetListViewEx(listViewEx2, imageList2, "Болванка");
        }

        private void metroShell1_SelectedTabChanged(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            if (Form1.ActiveForm != null)
            {
                _StartControl.Height = ActiveForm.Height;
                _StartControl.Width = ActiveForm.Width;
            }
        }

        /// <summary>
        /// Загрузка формы и распределение размеров
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnLoad(e);
        }

        private Rectangle GetStartControlBounds()
        {
            int captionHeight = metroShell1.MetroTabStrip.GetCaptionHeight() + 2;
            Thickness borderThickness = this.GetBorderThickness();
            //слайд-переход с главного окна
            return new Rectangle((int)borderThickness.Left, captionHeight, this.Width - (int)borderThickness.Horizontal, this.Height - captionHeight - 1);
        }

        /// <summary>
        /// Обновить расположение контейнеров на форме
        /// </summary>
        private void UpdateControlsSizeAndLocation()
        {
            if (_StartControl != null)
            {
                if (!_StartControl.IsOpen)
                    _StartControl.OpenBounds = GetStartControlBounds();
                else
                    _StartControl.Bounds = GetStartControlBounds();
                if (!IsModalPanelDisplayed)
                    _StartControl.BringToFront();
            }
            //расположение менюхи в низу -три точки-
            metroToolbar1.Location = new Point((this.Width - metroToolbar1.Width) / 2, metroToolbar1.Parent.Height - metroToolbar1.Height - 1);
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnResize(e);
        }


        #endregion


        /// <summary>
        /// Обнулить ссылки на все классы кроме переданного
        /// </summary>
        private void ClearClassLink(int num)
        {
            switchButtonItem_3To4.Visible = false;
            //обнулить
            switch (num)
            {
                case 0://все кроме лагранжа
                    //_bese = null;
                    //_ermit = null;
                    //_bspline = null;
                    break;
                case 1://все кроме безье
                    //_lagranj = null;
                    //_ermit = null;
                    //_bspline = null;
                    break;
                case 2://все кроме эрмит
                    //_lagranj = null;
                    //_bese = null;
                    //_bspline = null;
                    break;
                case 3: //все кроме бсплайна
                    //_lagranj = null;
                    //_bese = null;
                    //_ermit = null;

                    switchButtonItem_3To4.Visible = true;
                    switchButtonItem_3To4.Value = false;
                    break;
                case 4: break;
                case 5: break;
            }

        }

        private string _activBolt = "";

        private void metroTabItemSearch_Click(object sender, EventArgs e)
        {
            if (_bolt.GetD() == null || _zagatovka.GetD() == null) return;
            if (listViewEx1.SelectedItems.Count != 0)
                _activBolt = listViewEx1.SelectedItems[0].Text;
            //сравнить диаметры болта и заготовок//вывести подходящий
            if (SearchBoltAndPrut(_bolt.GetD(), _zagatovka.GetD()) == "null")
                label1_Итог.Text = "Изделие " + _activBolt + " оптимально изготовить из прутка, которого нет в базе.";
            else if (SearchBoltAndPrut(_bolt.GetD(), _zagatovka.GetD()) == "err")
                label1_Итог.Text = "Ничего не выбрано.";
            else
                label1_Итог.Text = "Изделие " + _activBolt + " оптимально изготовить из прутка " +
                                   SearchBoltAndPrut(_bolt.GetD(), _zagatovka.GetD());
            SetBoltBgImg(SearchBoltAndPrut(_bolt.GetD(), _zagatovka.GetD()));
        }

        /// <summary>
        /// Выбрали деталь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewEx1_ItemActivate(object sender, EventArgs e)
        {
            //Перейти на вкладку результатов
            metroTabItemSearch.Select();
            metroTabItemSearch_Click(sender, e);
        }

        private string SearchBoltAndPrut(List<double > bolt, List<double > prut)
        {
            if (_activBolt == "") return "err";
            prut.Sort();
            var str = _activBolt.Replace("m", "");
            foreach (var d in prut)
            {
                if (d >= double.Parse(str) && integerInput1.Value + double.Parse(str) >= d)
                {
                    return "D" + d + ", диаметр стержня " + d + "мм";
                }
            }
            
            return "null";
        }

        

        private void SetBoltBgImg(string namePrut)
        {
            if (listViewEx1.SelectedItems.Count != 0 && namePrut != "err")
            panel1_болт.BackgroundImage = listViewEx1.SelectedItems[0].ImageList.Images[0];
            if (listViewEx2.LargeImageList.Images.Count != 0 && namePrut != "err")
                panel2_прут.BackgroundImage = listViewEx2.LargeImageList.Images[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewEx2 = _zagatovka.GetListViewEx(listViewEx2, imageList2, "Болванка");
        }

        //Кнопка Открыть диалог выбора файла для копировки
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            AddFile(!metroTabItem1.Checked);
        }


        private Image image;
        //откуда берем
        string sourceDir = Directory.GetCurrentDirectory();
        //куда копировать
        string backupDir = Directory.GetCurrentDirectory();
        private string fileNameA = "";

        /// <summary>
        /// True для png|Болванка
        /// </summary>
        /// <param name="flag"></param>
        private void AddFile(bool flag)
        {

            //куда копировать
            backupDir = Directory.GetCurrentDirectory() + (!flag ? "\\Изделие\\" : "\\Болванка\\");
            //открыть выбор файлов
            OpenFileDialog _openDialog = new OpenFileDialog();
            _openDialog.Filter = !flag ? "Файлы изделий|*.png;" : "Файлы заготовок|*.jpg;";
            if (_openDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                image = Image.FromFile(_openDialog.FileName);
                if (_openDialog.SafeFileName != null)
                {
                    sourceDir = _openDialog.FileName.Replace(_openDialog.SafeFileName, "");
                    textBoxItem1.Text = _openDialog.SafeFileName;
                    fileNameA = _openDialog.SafeFileName;
                }
            }
            catch (OutOfMemoryException ex)
            {

                MessageBox.Show("Ошибка при чтении изображения");
                return;
            }

        }

        //В textBox1 изменили имя файла//Кнопка ОК
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            var fNameB = textBoxItem1.Text;
            try
            {
                // Will not overwrite if the destination file already exists.
                var a = Path.Combine(sourceDir, fileNameA);
                var b = Path.Combine(backupDir, fNameB);
                File.Copy(a, b);
            }// Catch exception if the file was already copied.
            catch (Exception copyError)
            {
                MessageBox.Show(copyError.Message);
            }
            //Обновить форму после загрузки файла
            if (metroTabItem1.Checked) metroTabItem1_Click(sender, e);
            if (metroTabItem2.Checked) metroTabItem2_Click(sender, e);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (metroTabItem1.Checked)
            if (listViewEx1.FocusedItem.Selected && listViewEx1.FocusedItem.Text != "")
            {
                DeleteFile(listViewEx1.FocusedItem.Text);
                metroTabItem1_Click(sender, e);
            }
            if (metroTabItem2.Checked)
            if (listViewEx2.FocusedItem.Selected && listViewEx2.FocusedItem.Text != "")
            {
                DeleteFile(listViewEx2.FocusedItem.Text);
                metroTabItem2_Click(sender, e);
            }
        }

        //Удалить файл с именем name в конкретной директории sourceDir
        private void DeleteFile(string name)
        {
            backupDir = Directory.GetCurrentDirectory();
            try
            {
                var path = Path.Combine(backupDir,
                                        ((metroTabItem1.Checked ? "Изделие\\" : "Болванка\\")) + name +
                                        (metroTabItem1.Checked ? ".png" : ".jpg"));
                File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Кнопка Помощь
        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
            Form2 formHelp = new Form2();
            if (formHelp.ShowDialog() != DialogResult.OK)
                return;
            
        }

    }
}
