using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using DevComponents.Editors;
using TreeControll;

/*Слои:
 refImagOUT
 * groupBoxOUT * 
 * this.metroTabPanel1.Controls.Add(this.metroToolbar1);
 */
namespace Vika
{
    public partial class fMain : MetroAppForm
    {
        StartControl _StartControl = null; // Start control displayed on startup
        MetroBillCommands _Commands = null; // All application commands

        public fMain()
        {
            InitializeComponent();

            // Prepare commands
            _Commands = new MetroBillCommands();

            _Commands.ToggleStartControl = new Command(components);
            _Commands.ToggleStartControl.Executed += new EventHandler(ToggleStartControlExecuted);

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
            _Commands.ChangeMetroTheme = new Command(components, new EventHandler(ChangeMetroThemeExecuted));
            _Commands.NotImplemented = new Command(components, new EventHandler(NotImplementedExecuted));
            //Нажал на плитку Информация о БД
            _Commands.DevComponents = new Command(components, new EventHandler(DevComponentsExecuted));
            _Commands.GettingStartedCommand = new Command(components, new EventHandler(GettingStartedExecuted));

            this.SuspendLayout();
            _StartControl = new StartControl();
            _StartControl.Commands = _Commands;
            this.Controls.Add(_StartControl);
            _StartControl.BringToFront();

            //боковой язычёк
            _StartControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;

            //клик по всей области главной формы
            _StartControl.Click += new EventHandler(StartControl_Click);
            this.ResumeLayout(false);

            // Assign commands to toolbar buttons
            //newInvoiceButton.Command = _Commands.InvoiceCommands.New;

            // Add metro color themes
            MetroColorGeneratorParameters[] metroThemes = MetroColorGeneratorParameters.GetAllPredefinedThemes();
            foreach (MetroColorGeneratorParameters mt in metroThemes)
            {
                ButtonItem theme = new ButtonItem(mt.ThemeName, mt.ThemeName);
                theme.Command = _Commands.ChangeMetroTheme;
                theme.CommandParameter = mt;
                colorThemeButton.SubItems.Add(theme);
            }

            AddSampleData();
        }

        /// <summary>
        /// Нажал на плитку About
        /// </summary>
        private void GettingStartedExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("22222222");//System.Diagnostics.Process.Start("http://www.devcomponents.com/kb2/?p=1160");
        }

        /// <summary>
        /// Нажал на плитку Админка
        /// </summary>
        private void NotImplementedExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("11111");//MessageBoxEx.Show(this, "Placeholder for real action. This command is not implemented.", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Нажал на плитку Информация о БД
        /// </summary>
        private void DevComponentsExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("44444444");//System.Diagnostics.Process.Start("http://www.devcomponents.com/dotnetbar/");
        }

        private void ChangeMetroThemeExecuted(object sender, EventArgs e)
        {
            ICommandSource source = (ICommandSource)sender;
            MetroColorGeneratorParameters theme = (MetroColorGeneratorParameters)source.CommandParameter;
            StyleManager.MetroColorGeneratorParameters = theme;
        }

        /// <summary>
        /// Нажал на плитку Просмотр таблицы
        /// </summary>
        private void ToggleStartControlExecuted(object sender, EventArgs e)
        {
            //MessageBox.Show("34343434343");
            _StartControl.IsOpen = !_StartControl.IsOpen;

            //если есть Админка в true то делаем поля открытыми
            //иначе поля в readOnly
            GroupPanelVisible();
        }

        /// <summary>
        /// Вкл\откл доступ к панелям параметров
        /// </summary>
        private void GroupPanelVisible()
        {
            if(!_StartControl.Administrator)
            {
                groupPanelOUT.Enabled = false;
                groupPanelParamInit.Enabled = false;
            }
            else
            {
                groupPanelOUT.Enabled = true;
                groupPanelParamInit.Enabled = true;
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

        /// <summary>
        /// Записать инфу с БД (SELECT) в AdvTree и вывести
        /// </summary>
        private void AddSampleData()
        {
            //Заполнить таблицу SELECT
            int index = 0;
            if (_dbcommand.ListSelectAll != null)
            foreach (AdvTree tree in _dbcommand.ListSelectAll)
            {
                while (index < Convert.ToInt32(_dbcommand.Count))//tree.Nodes.Capacity)
                {
                    advTree1.Nodes.Add(tree.Nodes[index]);
                    index++;
                }
            }
            

        }

        /// <summary>
        /// Записать инфу с БД (SHOW) в AdvTree и вывести
        /// </summary>
        private void AddShowData()
        {
            //Заполнить таблицу 
            int index = 0;
            if (_dbcommand.ListShowAll != null)
                foreach (AdvTree tree in _dbcommand.ListShowAll)
                {
                    while (index < _dbcommand.CountShow)//tree.Nodes.Capacity)
                    {
                        advTree2.Nodes.Add(tree.Nodes[index]);
                        index++;
                    }
                }
        }

        private Node CreateClientRow(string clientName, string location, double totalInvoiced)
        {
            Node node = new Node(clientName);
            node.Cells.Add(new Cell(location));
            node.Cells.Add(new Cell(totalInvoiced.ToString("C")));
            return node;
        }
        private Node CreateInvoiceRow(DateTime date, string clientName, double invoiceAmount, string invoiceFileName)
        {
            Node node = new Node(date.ToShortDateString());
            node.Cells.Add(new Cell(clientName));
            node.Cells.Add(new Cell(invoiceAmount.ToString("C")));
            node.Tag = invoiceFileName;
            return node;
        }
        private void advTree1_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node node = e.Node;
            if (!string.IsNullOrEmpty((string)node.Tag))
            {
                //richTextBox1.Rtf = ResourceManager.GetString((string)node.Tag);
            }
            //else richTextBox1.Text = "";
        }
        private static global::System.Resources.ResourceManager resourceMan;
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MetroBill.Properties.Resources", typeof(Vika.Properties.Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }


        /// <summary>
        /// Клик по области вокруг плиток
        /// </summary>
        private void StartControl_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("ssssss");
            _StartControl.IsOpen = false;

            GroupPanelVisible();
        }

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

        /// <summary>
        /// Панель была открыта?
        /// </summary>
        private void metroAppButton1_ExpandChange(object sender, EventArgs e)
        {
            if (!_StartControl.Visible)
                _StartControl.SlideOutButtonVisible = !metroTabItem1.Expanded;
        }

        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "MetroShell Settings Button Clicked", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "MetroShell Help Button Clicked", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroShell1_SelectedTabChanged(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        /// <summary>
        /// Инициализируем класс работы с БД. Подключаемся
        /// </summary>
        private clBDCommand _dbcommand = new clBDCommand();
        /// <summary>
        /// Инициализация подключения к базе данных
        /// </summary>
        private void fMain_Load(object sender, EventArgs e)
        {
            lblStateConnect.BackColor = _dbcommand.ConnectionState ? Color.LightGreen : Color.IndianRed;
            //richTextBox1.AppendText("Колличество записей в таблице: "+_dbcommand.Count);
            Count = _dbcommand.Count;
            
        }

        /// <summary>
        /// Перекинуть количество записей в таблице на форму StartControl.cs-->fConnectInfo.cs
        /// </summary>
        internal static string Count { get; set; }

        /// <summary>
        /// Закрыть соединение с базой
        /// </summary>
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dbcommand.ClosedConnection();
        }

        /// <summary>
        /// Клик на ленту с миниатюрами изображений транзисторов
        /// </summary>
        private void btnp_Click(object sender, EventArgs e)
        {
            ButtonItem tmp = sender as ButtonItem;
            //Вывести большое изображение в refImgOUT
            if (tmp != null) ChangeImageFrom_refImgOUT(tmp.Text);

        }
        
        /// <summary>
        /// на вход имя картинки
        /// </summary>
        private void ChangeImageFrom_refImgOUT(string picture)
        {
            if(!String.IsNullOrEmpty(picture))
            {
                //ищем её по имени в каталоге
                clDictonary pic = new clDictonary();
                //выводим в область refImgOUT
                refImgOUT.Image = Image.FromFile(pic.Image(picture));
            }
            else
                refImgOUT.Image = Properties.Resources.download;
        }

        /// <summary>
        /// Клик по строке из таблицы
        /// </summary>
        private void advTree1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            //Считать содержимое выделенной строки
            var tmp = sender as AdvTree;

            AddPropertyFromSelectedTable(e.Node.Text);

            //передать в панель редактора\просмотра
            btnIParam_Click(sender, e);

            if(btnIOpisanie.Checked)
            {//если открыто показ изображения выбранного транзистора
                //то нужен только один параметр - имя рисунка
                btnIOpisanie_Click(sender, e);
            }
            
        }

        /// <summary>
        /// Вывести Имя из таблицы
        /// </summary>
        private void AddPropertyFromSelectedTable(string name)
        {
            //Зарядить Имя выбранной детали из таблицы
            btnIName.Text = name;
            btnIName.Refresh();
        }

        /// <summary>
        /// Сменить\Показать параметры выбраной детали из таблицы
        /// Клик по Параметры
        /// </summary>
        private void btnIParam_Click(object sender, EventArgs e)
        {
            int index = 0;
            foreach (AdvTree tree in _dbcommand.ListSelectFull)
            {
                while (index < tree.Nodes.Count)//Capacity)
                {//посточное сканирование
                    if (tree.Nodes[index].Tag.ToString() == btnIName.Text)
                    {//Взять значение из tree.Nodes[index] для вывода "Параметры"
                        if (!btnIOpisanie.Checked)
                        {
                            //refImgOUT скрывать
                            refImgOUT.Hide();
                            //показать groupPanelOUT
                            groupPanelOUT.Show();
                            groupPanelParamInit.Show();
                            expandableSplitter_Parametr.Show();
                        }

                        //заполнить поля Параметры
                        //Значение в строке[index] и столбце[0]
                        #region Parametrs Limits

                        //MessageBox.Show("ik0=" + tree.Nodes[index].Cells[0].Text);
                        doubleInput_ik0.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ik0.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ik0.Tag)].Text).Replace('.', ','));

                        doubleInput_ik1.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ik1.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ik1.Tag)].Text).Replace('.', ','));

                        doubleInput_uk0.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uk0.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uk0.Tag)].Text).Replace('.', ','));

                        doubleInput_uk1.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uk1.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uk1.Tag)].Text).Replace('.', ','));

                        doubleInput_uk2.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uk2.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uk2.Tag)].Text).Replace('.', ','));

                        doubleInput_pk.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_pk.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_pk.Tag)].Text).Replace('.', ','));

                        doubleInput_tc0.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tc0.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tc0.Tag)].Text).Replace('.', ','));

                        doubleInput_tc1.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tc1.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tc1.Tag)].Text).Replace('.', ','));

                        doubleInput_tc2.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tc2.Tag)].Text))
                                ? 0.0
                                : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tc2.Tag)].Text).Replace('.', ','));

                        #endregion

                        #region Parametrs Standart

                        doubleInput_ik0.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ik0.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ik0.Tag)].Text).Replace('.', ','));

                        doubleInput_ukb.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ukb.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ukb.Tag)].Text).Replace('.', ','));

                        doubleInput_ikb.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ikb.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ikb.Tag)].Text).Replace('.', ','));

                        doubleInput_uke.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uke.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_uke.Tag)].Text).Replace('.', ','));

                        doubleInput_ikbo.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ikbo.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ikbo.Tag)].Text).Replace('.', ','));

                        doubleInput_fgr.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_fgr.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_fgr.Tag)].Text).Replace('.', ','));

                        doubleInput_kh.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_kh.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_kh.Tag)].Text).Replace('.', ','));

                        doubleInput_ck.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ck.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ck.Tag)].Text).Replace('.', ','));

                        doubleInput_ca.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ca.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_ca.Tag)].Text).Replace('.', ','));
                        
                        doubleInput_tpac.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tpac.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_tpac.Tag)].Text).Replace('.', ','));

                        doubleInput_rtnc.Value =
                            string.IsNullOrEmpty((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_rtnc.Tag)].Text))
                            ? 0.0
                            : Convert.ToDouble((tree.Nodes[index].Cells[Convert.ToInt32(doubleInput_rtnc.Tag)].Text).Replace('.', ','));

                        #endregion

                        textBox_h21.Text = tree.Nodes[index].Cells[Convert.ToInt32(textBox_h21.Tag)].Text;
                        textBox_title.Text = (tree.Nodes[index].Cells[Convert.ToInt32(textBox_title.Tag)].Text);
                        textBox_picture.Text = (tree.Nodes[index].Cells[Convert.ToInt32(textBox_picture.Tag)].Text);
                        
                        return;
                    }
                    index++;
                }
            }
        }


        /// <summary>
        /// Клик по панели предельные_параметры сворачивает её
        /// </summary>
        private void groupPanelOUT_Click(object sender, EventArgs e)
        {
            expandableSplitter_Parametr.Expanded = false;
        }

        /// <summary>
        /// Клик по Форма - показать эскиз обьекта
        /// </summary>
        private void btnIOpisanie_Click(object sender, EventArgs e)
        {
            //Делаем невидимыми панели Параметры
            groupPanelOUT.Hide();
            groupPanelParamInit.Hide();
            expandableSplitter_Parametr.Hide();
            //показать вывод изображений
            refImgOUT.Show();
            //загрузить изображение
            //берем поле с именем рисунка
            string tmpName = textBox_picture.Text;
            ChangeImageFrom_refImgOUT(tmpName);
        }

        /// <summary>
        /// Загрузить изображение транзистора
        /// </summary>
        private void textBox_picture_ButtonCustomClick(object sender, EventArgs e)
        {
            LoadPictureFromFile();
            //Уведломить что произошло изменение поля для запроса UPDATE
            textBox_h21_KeyPress(sender, null);
        }

        /// <summary>
        /// Подгрузить файл, нажали кнопку выбора изображения обьекта
        /// </summary>
        private void LoadPictureFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Файлы изображений|*.gif|Все файлы|*.*" };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            //name.gif:
            string[] tmpName = (openFileDialog.FileName.Split('\\'));
            //name:
            string name = tmpName[tmpName.Length - 1].Split('.')[0];
            //Поместить в поле Форма:
            textBox_picture.Text = name;

        }

        /// <summary>
        /// Выполнить обновление данных в таблице.
        /// Вставить в базу.
        /// Вставка ИЗМЕНЕНЫХ_ДАННЫХ ИЛИ ВСТАВКА_НОВОЙ_ЗАПИСИ
        /// </summary>
        private void newInvoiceButton_Click(object sender, EventArgs e)
        {
            //Доступно для Админа
            if(_StartControl.Administrator)
            {
                //для ИЗМЕНЕНЫХ или НОВЫХ контролируем кнопку btnIName
                for (int i = 0; i < advTree1.Nodes.Count; i++)
                {
                    if(advTree1.Nodes[i].Text == btnIName.Text)
                    {//если имя старое (есть в таблице) то это изменение старых параметров
                        //использовать Update //MessageBox.Show("Уже есть такой");
                        SborParametrov();
                    }
                    //если имя новое то это вставка новых данных в бд
                    //использовать Insert
                }
                
                
                
            }
            //Очистить(если надо) содержимое в таблице AdvTree
            advTree1.ClearAndDisposeAllNodes();
            //Обновить содержимое _dbcommand.ListSelectAll
            _dbcommand.Select();
            //Обновить содержимое таблицы AdvTree
            AddSampleData();
        }

        /// <summary>
        /// Поглядеть содержимое панели Параметры и 
        /// опросить каждый компонент
        /// Команда UPDATE
        /// </summary>
        private void SborParametrov()
        {
            int index = 0;
            var keyValuePair = new KeyValuePair<string, string>[25];
            
            if(_listDoubleInput.Count > 0)
            foreach (DoubleInput doubleInput in _listDoubleInput)
            {
                string key = doubleInput.Name.Split('_')[1];
                keyValuePair[index] = new KeyValuePair<string, string>(key, doubleInput.Text);
                index++;
            }
            //Отдельно для текстовых полей:
            if (_listTextInput.Count > 0)
                foreach (TextBoxX textInput in _listTextInput)
                {
                    string key = textInput.Name.Split('_')[1];
                    keyValuePair[index] = new KeyValuePair<string, string>(key, textInput.Text);
                    index++;
                }

            string lkey = _lastChangedControll.Name.Split('_')[1];
            keyValuePair[index] = new KeyValuePair<string, string>(lkey, _lastChangedControll.Text);

            //Очистить лист
            _listDoubleInput.Clear();
            //Передать подготовленный список измененний
            _dbcommand.UpdateStr(btnIName.Text, keyValuePair);

        }

        /// <summary>
        /// Контейнер для полей ввода цифр
        /// </summary>
        private readonly List<DoubleInput> _listDoubleInput = new List<DoubleInput>();

        /// <summary>
        /// Когда фокус покидает полеВвода
        /// </summary>
        private void doubleInput_ik0_Leave(object sender, EventArgs e)
        {
            //если список несодержит ПолеВвода, то добавляем его.
            if (!_listDoubleInput.Contains(sender as DoubleInput))
                _listDoubleInput.Add(sender as DoubleInput);

        }

        /// <summary>
        /// Последний контрол с изменениями
        /// </summary>
        private DoubleInput _lastChangedControll;

        /// <summary>
        /// Запомнить последний измененый
        /// </summary>
        private void doubleInput_ik0_ValueChanged(object sender, EventArgs e)
        {
            //если список несодержит ПолеВвода, то пишем в последний
            if (!_listDoubleInput.Contains(sender as DoubleInput))
                _lastChangedControll = (sender as DoubleInput);

        }

        /// <summary>
        /// Изменение содержимого текстовых полей Параметры.
        /// Сводим три текстовых поля!
        /// </summary>
        private void textBox_h21_KeyPress(object sender, KeyPressEventArgs e)
        {
            //если список несодержит ПолеВвода, то добавляем его.
            if (!_listTextInput.Contains(sender as TextBoxX))
                _listTextInput.Add(sender as TextBoxX);
        }

        /// <summary>
        /// Контейнер для полей ввода текста
        /// </summary>
        private readonly List<TextBoxX> _listTextInput = new List<TextBoxX>();

        /// <summary>
        /// Создать новую строку в таблице
        /// </summary>
        private void markAsPaidButton_Click(object sender, EventArgs e)
        {
            /*Логика такая: если btnIName (primeryKey) измененый (его нет в AdvTree) то
             * это совершенно новая запись и её обрабатываем как INSERT             */
            //Доступно для Админа
            if (_StartControl.Administrator)
            {//для ИЗМЕНЕНЫХ или НОВЫХ контролируем кнопку btnIName
                int sovpadenie = 0;
                for (int i = 0; i < advTree1.Nodes.Count; i++)
                {
                    if (advTree1.Nodes[i].Text == btnIName.Text)
                    {//если есть совпадение то подымаем счетчик
                        sovpadenie++;
                    }
                }

                if(sovpadenie==0)
                {//если ==0 то запись уникальная (уникальное Имя в btnIName)
                    //Команда INSERT
                    SborParametrov(true);
                }
                //Очистить(если надо) содержимое в таблице AdvTree
                advTree1.ClearAndDisposeAllNodes();
                //Обновить содержимое _dbcommand.ListSelectAll
                _dbcommand.Select();
                //Обновить содержимое таблицы AdvTree
                AddSampleData();
            }
        }

        /// <summary>
        /// Поглядеть содержимое панели Параметры и 
        /// опросить каждый компонент
        /// Команда INSERT
        /// </summary>
        private void SborParametrov(bool flag)
        {
            if(flag)
            {
                int index = 0;
                var keyValuePair = new KeyValuePair<string, string>[25];

                if (_listDoubleInput.Count > 0)
                    foreach (DoubleInput doubleInput in _listDoubleInput)
                    {
                        string key = doubleInput.Name.Split('_')[1];
                        keyValuePair[index] = new KeyValuePair<string, string>(key, doubleInput.Text);
                        index++;
                    }
                //Отдельно для текстовых полей:
                if (_listTextInput.Count > 0)
                    foreach (TextBoxX textInput in _listTextInput)
                    {
                        string key = textInput.Name.Split('_')[1];
                        keyValuePair[index] = new KeyValuePair<string, string>(key, textInput.Text);
                        index++;
                    }

                string lkey = _lastChangedControll.Name.Split('_')[1];
                keyValuePair[index] = new KeyValuePair<string, string>(lkey, _lastChangedControll.Text);
                keyValuePair[index+1] = new KeyValuePair<string, string>("name", btnIName.Text);
                //Очистить лист
                _listDoubleInput.Clear();

                //проверить список keyValuePair на повтор пар
                //если есть такие, то оставить последние
                ProverkaPovtorov(keyValuePair);
            }
        }
        
        /// <summary>
        /// Проверить лист на наличие повторяющихся пар.
        /// Оставить последнии из повторов.
        /// </summary>
         private void ProverkaPovtorov(KeyValuePair<string, string>[] keyValuePair)
         {
             var word = new string[keyValuePair.Length];
             int index = 0;
             foreach (var pair in keyValuePair)
             {
                 word[index] = pair.Key;
                 index++;
             }

             var Massiv = new string[word.Length];
             int i = 0, j = 0;
             foreach (string ts in word)//A
             {
                 Massiv[j] = ts;
                 j++;
                 if(ts!=null)
                 {
                     for (int e = 0; e < i; e++)
                         if (ts.CompareTo(Massiv[e]) == 0)
                         {//Если есть результ, то есть совпадение с текущим значением ts!
                             Massiv[e] = null;//Занулим все совпадения
                         }
                     i++;
                 }
             }

             index = 0;
             foreach (var pair in Massiv)
             {
                 if (pair == null) keyValuePair[index] = new KeyValuePair<string, string>(null, null);
                 else keyValuePair[index] = new KeyValuePair<string, string>(pair, keyValuePair[index].Value);
                 index++;
             }



             //Передать подготовленный список измененний
             _dbcommand.InsertStr(btnIName.Text, keyValuePair);
         }

        private readonly fConnectInfo _connectInfo = new fConnectInfo();
        /// <summary>
        /// Клик по меню Подключение
        /// </summary>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            _connectInfo.Count(fMain.Count);
            _connectInfo.ShowDialog();
        }

        /// <summary>
        /// Удалить выбранную (активную) запись из БД
        /// </summary>
        private void addNoteButton_Click(object sender, EventArgs e)
        {
            //Гарантируем админку
            if(!_StartControl.Administrator)
                return;

            //Передать подготовленный список измененний
            _dbcommand.DeleteStr(btnIName.Text);
            //Очистить(если надо) содержимое в таблице AdvTree
            advTree1.ClearAndDisposeAllNodes();
            //Обновить содержимое _dbcommand.ListSelectAll
            _dbcommand.Select();
            //Обновить содержимое таблицы AdvTree
            AddSampleData();
        }

        /// <summary>
        /// Какая структура таблицы
        /// </summary>
        private void voidInvoiceButton_Click(object sender, EventArgs e)
        {
            //Структура - запрос
            _dbcommand.ShowTable();
            metroTabItem2.Checked = true;
            //Очистить(если надо) содержимое в таблице AdvTree
            advTree2.ClearAndDisposeAllNodes();
            //Обновить содержимое таблицы AdvTree
            AddShowData();
        }

        /// <summary>
        /// Выполнить поиск в БД
        /// </summary>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            //перейти на вкладку поиска
            metroTabItemSearch.Checked = true;
        }

        /// <summary>
        /// Выполнить переход на экран HOME и выводом выбранной транзистора из AdvTree3
        /// </summary>
        private void advTree3_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            //ИМЯ выделенной ноды:
            string tmpStrName = e.Node.FullPath;

            //MessageBox.Show(e.Node.FullPath);
            if (string.IsNullOrEmpty(tmpStrName))
                return;
            //переключится на HOME:
            metroTabItem1.Checked = true;
            int i = 0;
            //найти в advTree1 элемент с tmpStrName и взять его индекс
            foreach (Node node in advTree1.Nodes)
            {
                if (node.FullPath == e.Node.FullPath)
                {
                    //выделить по индексу
                    advTree1.SelectedIndex = i;
                    //найти по имяни и выделить транзистор в AdvTree1
                    advTree1_NodeClick(sender, e);
                    return;
                }
                i++;
            }
        }

        /// <summary>
        /// Пересчитать положения тулбара
        /// </summary>
        private void metroTabItem1_Click(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }



        #region Technology QwinCor - Adaptive Search

        /// <summary>
        /// Нода для создания и помещения в массив
        /// </summary>
        private DevComponents.Tree.Node _tmpNode;
        /// <summary>
        /// Контейнер для созданных нод
        /// </summary>
        private DevComponents.Tree.Node[] _arrNodes = new DevComponents.Tree.Node[25];

        /// <summary>
        /// Начальный НОД-ПОИСК
        /// </summary>
        private void node1_NodeClick(object sender, EventArgs e)
        {
            treeGX1.Refresh();
            //У корня только одно направление-ветка
            if (node1.Nodes.Count != 0)
                return;
            //Выполнить начальное построение
            //Поле
            node1.Nodes.Add(CreatePole());
            //разрешаем добавить ПОЛЕ:
            status = false;
        }

        private int _indexNodes = 0;
        /// <summary>
        /// Построить поле
        /// </summary>
        private DevComponents.Tree.Node CreatePole()
        {

            UCPole pole = new UCPole() { EmployeeName = "Выбрать поле", Expanded = false };
            //обработчик Next-->>
            pole.MyEvent += new MyEventHandler(ucPole1_MyEvent);
            //обработчик Выбор Параметра
            //pole.SelectPole += new MyEventHandler(ucPole_SelectPole);
            //обработчик Выбор Маски
            //pole.SelectMaska += new MyEventHandler(ucPole_SelectMaska);
            //обработчик Ввод значения текст\число
            //pole.InputTextBox += new MyEventHandler(ucPole_InputTextBox);
            //pole.InputDoubleBox += new MyEventHandler(ucPole_InputDoubleBox); 

            _tmpNode = new DevComponents.Tree.Node() { HostedControl = pole };
            _arrNodes[_indexNodes] = _tmpNode;
            _indexNodes++;

            return _tmpNode;

        }

        /// <summary>
        /// TRUE для Логики, False для ПОЛЯ
        /// </summary>
        private bool status = false;

        /// <summary>
        /// ПОЛЕ: Обработчик кнопки Next-->>построить Логика
        /// </summary>
        private void ucPole1_MyEvent(object sender, EventArgs e)
        {
            //если статус положителен то запретить добавлять ПОЛЕ
            if (status)
            {
                //надо добавлять Логику
                ucLogika1_LogikaEvent(sender, e);
                return;
            }

            //MessageBox.Show("Прикрутить логику к текущей ноде");

            //Выполнить начальное построение
            //Логика
            UCLogika logika = new UCLogika() { EmployeeName = "Выбрать логику", Expanded = false };
            logika.LogikaEvent += new MyEventHandlerClick(ucLogika1_LogikaEvent);

            //создать ноду с полем логика
            //вывести получившееся и гдето сохранить в массиве.
            _tmpNode = new DevComponents.Tree.Node() { HostedControl = logika };
            _arrNodes[_indexNodes] = _tmpNode;//index=1//
            //построить ноду текущая(следующая);
            _arrNodes[_indexNodes - 1].Nodes.Add(_tmpNode);//index-1 = 0//
            //разрешаем добавить логику к полю:
            status = true;

            _indexNodes++;
            treeGX1.Refresh();
        }

        /// <summary>
        /// ЛОГИКА: Обработчик кнопки Next-->>построить Поле
        /// </summary>
        private void ucLogika1_LogikaEvent(object sender, EventArgs e)
        {
            //если статус false то запретить добавлять ЛОГИКУ
            if (!status)
            {
                //надо добавлять Поле
                ucPole1_MyEvent(sender, e);
                return;
            }

            //MessageBox.Show("Прикрутить поле к текущей ноде");

            //Поле
            UCPole pole = new UCPole() { EmployeeName = "Выбрать поле", Expanded = false };
            pole.MyEvent += new MyEventHandler(ucPole1_MyEvent);
            //pole.SelectPole += new MyEventHandler(SelectedPole);
            //pole.SelectMaska += new MyEventHandler(SelectedMaska);

            //построить текущую ноду
            _tmpNode = new DevComponents.Tree.Node() { HostedControl = pole };
            _arrNodes[_indexNodes] = _tmpNode;//index=2//
            //к последней ноде прикрутить текущую
            _arrNodes[_indexNodes - 1].Nodes.Add(_tmpNode);//index-1 = 1//
            //разрешить добавить Поле к ЛОГИКЕ
            status = false;

            _indexNodes++;
            treeGX1.Refresh();
        }


        /// <summary>
        /// Выполнить поиск, построить строку из значений
        /// </summary>
        private void node1_NodeDoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(_indexNodes.ToString());
            KeyValuePair<string, KeyValuePair<string, string>>[] tmpStr =
                new KeyValuePair<string, KeyValuePair<string, string>>[25];
            int i = 0;
            foreach (DevComponents.Tree.Node node in _arrNodes)
            {
                if (node == null) continue;

                try
                {
                    UCLogika tmplogik = node.HostedControl as UCLogika;
                    //MessageBox.Show(tmplogik.EmployeeName + tmplogik.isAND);
                    if (tmplogik.isAND)
                        tmpStr[i] = new KeyValuePair<string, KeyValuePair<string, string>>(i.ToString(), new KeyValuePair<string, string>("AND", "AND"));
                    else tmpStr[i] = new KeyValuePair<string, KeyValuePair<string, string>>(i.ToString(), new KeyValuePair<string, string>("OR", "OR"));
                }
                catch (NullReferenceException)
                {
                    UCPole tmppole = node.HostedControl as UCPole;
                    //MessageBox.Show(tmppole.EmployeeTitle + tmppole.EmployeeMaska + tmppole.InputText);
                    tmpStr[i] = new KeyValuePair<string, KeyValuePair<string, string>>(tmppole.EmployeeTitle, new KeyValuePair<string, string>(tmppole.EmployeeMaska, tmppole.InputText));
                }
                i++;
            }
            //можно передавать на обработку и составление команды
            // Распаковать массив и передать на обработку строку
            //Структура - запрос
            _dbcommand.SelectLink(tmpStr);

            //Очистить(если надо) содержимое в таблице AdvTree
            advTree3.ClearAndDisposeAllNodes();
            //Обновить содержимое таблицы AdvTree
            AddLinkData();

        }

        /// <summary>
        /// Записать инфу с БД (SelectLink) в AdvTree и вывести
        /// </summary>
        private void AddLinkData()
        {
            //Заполнить таблицу 
            int index = 0;
            if (_dbcommand.ListSelectLink != null)
                foreach (AdvTree tree in _dbcommand.ListSelectLink)
                {
                    while (index < _dbcommand.CountLink)//tree.Nodes.Capacity)
                    {
                        advTree3.Nodes.Add(tree.Nodes[index]);
                        index++;
                    }
                }
        }

        /// <summary>
        /// Очистить поле поиска
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DevComponents.Tree.Node node in _arrNodes)
            {
                if (node == null) continue;
                node.Nodes.Clear();
            }

            //построить корень заново
            CreateNodeROOT();
        }

        /// <summary>
        /// Построить корень нод
        /// </summary>
        private void CreateNodeROOT()
        {

            //DELETE all components
            _indexNodes = 1;
            DevComponents.Tree.Node tmp = _arrNodes[0];
            _arrNodes = new DevComponents.Tree.Node[25];
            _arrNodes[0] = tmp;

            status = false;
            try
            {
                _tmpNode.Nodes.Clear();
            }
            catch (NullReferenceException) { }

        }

        #endregion

        

        


    }
}
