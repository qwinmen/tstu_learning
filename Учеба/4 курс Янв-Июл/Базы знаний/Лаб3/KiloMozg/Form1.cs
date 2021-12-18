using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.AdvTree;
using FastColoredTextBoxNS;
using ZedGraph;
using Label = System.Windows.Forms.Label;

//вариант D7
//Построение аппроксиматора на нейронной сети
namespace KiloMozg
{
    public partial class Form1 : Form
    {
        private clNeiro _clNeiro = new clNeiro();
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _pane;
        
        public Form1()
        {
            InitializeComponent();

            _clNeiro = new clNeiro(advTree_Lesson);
            timerUpdateForm.Interval = 100;
            timerUpdateForm.Start();
            timerUpdateForm.Tick += new EventHandler(timerUpdateForm_Tick);
        }

        private delegate void PrintInTxt(string str, int index);//делегат
        private PrintInTxt PrintDelegateFunc;//переменая делегата
        
        /// <summary>
        /// Каждую секунду таймера будем запрашивть из класса clNeiro номер строки теста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdateForm_Tick(object sender, EventArgs e)
        {
            PrintDelegateFunc = new PrintInTxt(Label1T);//инициалим переменую делегата
            
            label0.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[0]), 0 });
            label1.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[1]), 1 });
            label2.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[2]), 2 });
            label3.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[3]), 3 });
            label4.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[4]), 4 });
            label5.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[5]), 5 });
            label6.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[6]), 6 });
            label7.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[7]), 7 });
            label8.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[8]), 8 });
            label9.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[9]), 9 });
            label10.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[10]), 10 });
            label11.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[11]), 11 });
            label12.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[12]), 12 });
            label13.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[13]), 13 });
            label14.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[14]), 14 });
            label15.Invoke(PrintDelegateFunc, new object[] { string.Format("{0:0.000}", _clNeiro._wForm[15]), 15 });
            label16.Text = "Итераций всего: " + _clNeiro.threadd;

            var ts = new StringTextSource(fastColoredTextBox1);
            //open source string
            ts.OpenString(_clNeiro._отчетНаФорму.ToString());
            //assign TextSource to the component
            fastColoredTextBox1.TextSource = ts;

            if (fastColoredTextBox1.Lines[fastColoredTextBox1.LinesCount - 1].Contains("--END--") || 
                fastColoredTextBox1.Lines[fastColoredTextBox1.LinesCount - 2].Contains("--END--"))
                timerUpdateForm.Stop();

            foreach (var VARIABLE in _clNeiro._list)
                SetPointCurve(VARIABLE.X, VARIABLE.Y);//точки пересчета ошибки [ep1]
            DrawGraph();
        }

        //для вывода текста метод
        private void Label1T(string str, int index)
        {
            switch (index)
            {
                case 0: label0.Text = str; break;
                case 1: label1.Text = str; break;
                case 2: label2.Text = str; break;
                case 3: label3.Text = str; break;
                case 4: label4.Text = str; break;
                case 5: label5.Text = str; break;
                case 6: label6.Text = str; break;
                case 7: label7.Text = str; break;
                case 8: label8.Text = str; break;
                case 9: label9.Text = str; break;
                case 10: label10.Text = str; break;
                case 11: label11.Text = str; break;
                case 12: label12.Text = str; break;
                case 13: label13.Text = str; break;
                case 14: label14.Text = str; break;
                case 15: label15.Text = str; break;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //загружаем таблицу
            advTree_Lesson.Nodes.AddRange(_clNeiro.LoadTable());
            //готовим оси графика
            Show_Graphics();

            //_list.Add(3, 3); _list.Add(13, 30);//основная линия ошибки [E]
        }

        /// <summary>
        /// Подготовка осей
        /// </summary>
        public void Show_Graphics()
        {
            zedGraphControl1.GraphPane.Title.IsVisible = false;//скрыть верхний заголовок
            zedGraphControl1.GraphPane.XAxis.Title.Text = "шаги обучения";
            zedGraphControl1.GraphPane.XAxis.Color = Color.Blue;
            zedGraphControl1.GraphPane.YAxis.Title.Text = "E ошибка";
            zedGraphControl1.GraphPane.YAxis.Color = Color.Red;
            _pane = zedGraphControl1.GraphPane;
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph()
        {
            // Получим панель для рисования
            //GraphPane pane = zedGraphControl1.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();
            // Устанавливаем интересующий нас интервал по оси X
            _pane.XAxis.Scale.MinAuto = true;
            _pane.XAxis.Scale.MaxAuto = true;

            // !!!
            // Устанавливаем интересующий нас интервал по оси Y
            _pane.YAxis.Scale.MinAuto = true;
            _pane.YAxis.Scale.MaxAuto = true;

            // Включим отображение сетки
            _pane.XAxis.MajorGrid.IsVisible = true;
            _pane.YAxis.MajorGrid.IsVisible = true;
            
            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = _pane.AddCurve("", _clNeiro._list, Color.Blue, SymbolType.Plus);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        }

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            LineItem curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);

            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;

            // Цвет заполнения круга - колубой
            curvePount.Symbol.Fill.Color = Color.Blue;

            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;

            // Размер круга
            curvePount.Symbol.Size = 7;

            //zedGraph.AxisChange();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            //центруем сплиттер по половинке формы
            groupBox2.Width = this.Width/2;
        }

        #region Подсветка текста в отчете
        private KeyValuePair<Regex, Style>[] PAIRS = new []
                                                         {
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@"ep+[\d]+", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Green, null, FontStyle.Italic)),//ep1
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@"F\(+[h]\S[\d]+\)", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Blue, null, FontStyle.Italic)),//F(h¹15)
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@"[h|δ]\S[\d]+", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Cyan, null, FontStyle.Italic)),//h¹15//δ¹3
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@"Δ?w\S?[\d]+", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Khaki, null, FontStyle.Italic)),//Δw¹13//w¹3
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@"--END--", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.DarkGreen, null, FontStyle.Italic))
                                                         };
        /// <summary>
        /// Подсветка переменных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {}

        private void fastColoredTextBox1_VisibleRangeChanged(object sender, EventArgs e)
        {
            var range = fastColoredTextBox1.VisibleRange;
            range.ClearStyle(StyleIndex.All);
            foreach (KeyValuePair<Regex, Style> keyValuePair in PAIRS)
            {
                range.SetStyle(keyValuePair.Value, keyValuePair.Key);
            }
            //timerUpdateForm.Stop();
        }

        #endregion

        /// <summary>
        /// Выполнить старт на устоявшейся системе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_NewInputX_Click(object sender, EventArgs e)
        {
            if (doubleInput_X1.ValueObject==null)
                highlighter1.SetHighlightColor(doubleInput_X1, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            else if(doubleInput_X2.ValueObject == null)
                highlighter1.SetHighlightColor(doubleInput_X2, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            else if (doubleInput_X3.ValueObject == null)
                highlighter1.SetHighlightColor(doubleInput_X3, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            else
            {//если все три входа адекватны
                highlighter1.SetHighlightColor(doubleInput_X1, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                highlighter1.SetHighlightColor(doubleInput_X2, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                highlighter1.SetHighlightColor(doubleInput_X3, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                if (timerUpdateForm.Enabled) return;//еще не рассчитана система!
                timerUpdateForm.Start();
                //Выполнить считывание входов и прогонку сетки
                _clNeiro.Tester(doubleInput_X1.Value, doubleInput_X2.Value, doubleInput_X3.Value, advTree_Lesson.SelectedIndex);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _clNeiro.CloseThread();
        }

        

        




    }
}
