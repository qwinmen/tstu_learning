using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using ZedGraph;

namespace GModel
{
    public partial class fMain : MetroAppForm
    {
        ucStartPanel _StartControl = null; // Start control displayed on startup
        MetroBillCommands _Commands = null; // All application commands

        public fMain()
        {
            InitializeComponent();

            // Prepare commands
            _Commands = new MetroBillCommands
                            {
                                ToggleStartControl = new Command(components)
                            };
            //Подпись на Метод Лагранжа
            _Commands.ToggleStartControl.Executed += ToggleStartControlExecuted;
            //Нажал на плитку Метод Безье
            _Commands.DevComponents = new Command(components, DevComponentsExecuted);
            //Нажал на плитку Метод Эрмита
            _Commands.NotImplemented = new Command(components, NotImplementedExecuted);
            //Нажал на плитку Метод В-Сплайн
            _Commands.GettingStartedCommand = new Command(components, GettingStartedExecuted);
            //Нажал на плитку Метод Поверхности
            _Commands.Poverxnost = new Command(components, Poverxnost_Click);
            //Нажал на плитку Метод Чегонить тут
            _Commands.NewMethod = new Command(components, NonameMethod_Click);


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
            _StartControl = new ucStartPanel {Location = new Point(0, 28), Commands = _Commands};
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
                                                                          Command = _Commands.ChangeMetroTheme, CommandParameter = mt
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


        private clLagranj _lagranj;
        private clBese _bese;
        private clErmit _ermit;
        private clBSpline _bspline;

        /// <summary>
        /// Нажал на плитку Метод Лагранжа
        /// </summary>
        private void ToggleStartControlExecuted(object sender, EventArgs e)
        {
            MessageBox.Show("метод Лагранжа");
            _StartControl.IsOpen = !_StartControl.IsOpen;
            //инициализация класса лагранж
            _lagranj = new clLagranj(zedGraph);

            ClearClassLink(0);
        }

        /// <summary>
        /// Нажал на плитку Метод Эрмита
        /// </summary>
        private void NotImplementedExecuted(object sender, EventArgs e)
        {
            MessageBox.Show("метод Эрмита");
            
            _StartControl.IsOpen = !_StartControl.IsOpen;
            //инициализация класса
            _ermit = new clErmit(zedGraph);

            ClearClassLink(2);
        }

        /// <summary>
        /// Нажал на плитку Метод Безье
        /// </summary>
        private void DevComponentsExecuted(object sender, EventArgs e)
        {
            MessageBox.Show("метод Безье");
            
            _StartControl.IsOpen = !_StartControl.IsOpen;
            //инициализация класса безье
            _bese = new clBese(zedGraph);

            ClearClassLink(1);
        }

        /// <summary>
        /// Нажал на плитку Метод В-Сплайн
        /// </summary>
        private void GettingStartedExecuted(object sender, EventArgs e)
        {
            MessageBox.Show("метод В-сплайн");
            _StartControl.IsOpen = !_StartControl.IsOpen;
            //инициализация класса
            _bspline = new clBSpline(zedGraph);

            ClearClassLink(3);
        }

        /// <summary>
        /// Нажал на плитку Метод Поверхности
        /// </summary>
        private void Poverxnost_Click(object sender, EventArgs e)
        {
            MessageBox.Show("метод Поверхности");

            ClearClassLink(4);
        }

        /// <summary>
        /// Нажал на плитку Метод Чегонить там
        /// </summary>
        private void NonameMethod_Click(object sender, EventArgs e)
        {
            MessageBox.Show("метод Ну хрен знает");

            ClearClassLink(5);
        }

        /// <summary>
        /// Клик по области вокруг плиток
        /// </summary>
        private void StartControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Клик по области вокруг плиток");
            //Открыть последнюю рабочую область
            _StartControl.IsOpen = false;
        }

        #endregion


        

        #region Изменение размеров при изменениях формы

        private void metroTabItem1_Click(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private void metroShell1_SelectedTabChanged(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            if (fMain.ActiveForm != null)
            {
                _StartControl.Height = fMain.ActiveForm.Height;
                _StartControl.Width = fMain.ActiveForm.Width;
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
        /// Снять опорную точку
        /// Отобразить точку на холсте
        /// </summary>
        private void zedGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            
            if (_lagranj != null)
                _lagranj.zedGraph_MouseClick(sender, e);
            else if(_bese != null)
                _bese.zedGraph_MouseClick(sender, e);
            else if (_ermit != null)
                _ermit.zedGraph_MouseClick(sender, e);
            else if (_bspline != null)
                _bspline.zedGraph_MouseClick(sender, e);

        }

        /// <summary>
        /// Точки сняты, рассчитать формулу
        /// </summary>
        private void markAsPaidButton_Click(object sender, EventArgs e)
        {
            if (_lagranj != null)
                _lagranj.btnBuild();
            else if(_bese != null)
                _bese.btnBuild();
            else if (_ermit != null)
                _ermit.btnBuild();
            else if (_bspline != null)
                _bspline.btnBuild();

        }

        /// <summary>
        /// Очистить форму и массивы точек
        /// </summary>
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            if (_lagranj != null)
                _lagranj.btnClear();
            else if(_bese != null)
                _bese.btnClear();
            else if (_ermit != null)
                _ermit.btnClear();
            else if (_bspline != null)
                _bspline.btnClear();

        }

        /// <summary>
        /// Актив вкладка ТочкиСписок
        /// </summary>
        private void metroTabItem2_Click(object sender, EventArgs e)
        {
            listViewPoints.Groups.Clear();

            if (_lagranj != null)
                _lagranj.SetValueListView(listViewPoints);
            else if (_bese != null)
                _bese.SetValueListView(listViewPoints);
            else if (_ermit != null)
                _ermit.SetValueListView(listViewPoints);
            else if (_bspline != null)
                _bspline.SetValueListView(listViewPoints);

        }

        /// <summary>
        /// Обнулить ссылки на все классы кроме переданного
        /// </summary>
        private void ClearClassLink(int num)
        {
            GraphPane pane = zedGraph.GraphPane;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            switchButtonItem_3To4.Visible = false;
            //обнулить
            switch (num)
            {
                case 0://все кроме лагранжа
                    _bese = null;
                    _ermit = null;
                    _bspline = null;
                    break;
                case 1://все кроме безье
                    _lagranj = null;
                    _ermit = null;
                    _bspline = null;
                    break;
                case 2://все кроме эрмит
                    _lagranj = null;
                    _bese = null;
                    _bspline = null;
                    break;
                case 3: //все кроме бсплайна
                    _lagranj = null;
                    _bese = null;
                    _ermit = null;

                    switchButtonItem_3To4.Visible = true;
                    switchButtonItem_3To4.Value = false;
                    break;
                case 4: break;
                case 5: break;
            }
            
        }

        private void switchButtonItem_3To4_ValueChanged(object sender, EventArgs e)
        {
            _bspline._switchFlag = switchButtonItem_3To4.Value;
        }



    }
}
