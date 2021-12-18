using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.Instrumentation;
using FastColoredTextBoxNS;
using ZedGraph;

//Лаб2 вар_14
namespace Tuman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _paneT;
        /// <summary>
        /// Для точек на экране (отрисовка)
        /// </summary>
        private GraphPane _paneG;

        private clProcess _clProc = new clProcess();

        private void Form1_Load(object sender, EventArgs e)
        {
            Show_Graphics();
            //просчитать 1-2-3 мю
            ExecuteM();
            //построить графики функций
            DrawGraph(_paneT, _clProc.PaintGraphik(true, 1), true, Color.Chartreuse);
            DrawGraph(_paneG, _clProc.PaintGraphik(false, 1), false, Color.Chartreuse);
            DrawGraph(_paneT, _clProc.PaintGraphik(true, 2), true, Color.Orange);
            DrawGraph(_paneG, _clProc.PaintGraphik(false, 2), false, Color.Orange);
            DrawGraph(_paneT, _clProc.PaintGraphik(true,3), true, Color.Blue);
            DrawGraph(_paneG, _clProc.PaintGraphik(false,3), false, Color.Blue);
        }

        /// <summary>
        /// Обновить лейблы c M
        /// </summary>
        private void ExecuteM()
        {
            var tm = new double[]
                         {
                             _clProc.GetM(1, true, slider_T.Value), _clProc.GetM(2, true, slider_T.Value),
                             _clProc.GetM(3, true, slider_T.Value)
                         };
            //просчитать 1-2-3 мю
            label_Tm1.Text = "Tμ1=" + tm[0];
            label_Tm2.Text = "Tμ2=" + tm[1];
            label_Tm3.Text = "Tμ3=" + tm[2];
            var gm = new double[]
                         {
                             _clProc.GetM(1, !true, slider_G.Value), _clProc.GetM(2, !true, slider_G.Value),
                             _clProc.GetM(3, !true, slider_G.Value)
                         };
            label_Gm1.Text = "Gμ1=" + gm[0];
            label_Gm2.Text = "Gμ2=" + gm[1];
            label_Gm3.Text = "Gμ3=" + gm[2];
            //определить класс
            fastColoredTextBox1.Text = _clProc.GetClass(tm, gm, slider_T.Value, slider_G.Value);
            ribbonClientPanel2.Invalidate();
        }

        /// <summary>
        /// Подготовка осей
        /// </summary>
        public void Show_Graphics()
        {
            zedGraphControl_T.GraphPane.Title.IsVisible = false;//скрыть верхний заголовок
            zedGraphControl_T.GraphPane.XAxis.Title.Text = "область определения";
            zedGraphControl_T.GraphPane.XAxis.Color = Color.Blue;
            zedGraphControl_T.GraphPane.YAxis.Title.Text = "Tμ выход";
            zedGraphControl_T.GraphPane.YAxis.Color = Color.Red;
            _paneT = zedGraphControl_T.GraphPane;

            zedGraphControl_G.GraphPane.Title.IsVisible = false;//скрыть верхний заголовок
            zedGraphControl_G.GraphPane.XAxis.Title.Text = "область определения";
            zedGraphControl_G.GraphPane.XAxis.Color = Color.Blue;
            zedGraphControl_G.GraphPane.YAxis.Title.Text = "Gμ выход";
            zedGraphControl_G.GraphPane.YAxis.Color = Color.Red;
            _paneG = zedGraphControl_G.GraphPane;
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(GraphPane _pane, PointPairList _list, bool isT, Color color)
        {
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
            LineItem myCurve = _pane.AddCurve("", _list, color, SymbolType.Plus);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            if (isT)
            {
                zedGraphControl_T.AxisChange();
                // Обновляем график
                zedGraphControl_T.Invalidate();
            }
            else
            {
                zedGraphControl_G.AxisChange();
                // Обновляем график
                zedGraphControl_G.Invalidate();
            }
            
        }

        

        private void Form1_Resize(object sender, EventArgs e)
        {
            ribbonClientPanel1.Width = this.Width / 3;
            fastColoredTextBox1.Height = (this.ClientSize.Height - label_Tm3.Location.Y) - (label_Tm3.Height + 10);
        }

        private void slider_G_ValueChanged(object sender, EventArgs e)
        {
            GaugeItem gaugeN = gaugeControl_TG.GaugeItems[1];
            ((NumericIndicator) gaugeN).Text = (slider_G.Value < 100 ? "G=0" : "G=") + slider_G.Value;
            //просчитать 1-2-3 мю
            ExecuteM();
        }

        private void slider_T_ValueChanged(object sender, EventArgs e)
        {
            GaugeItem gaugeN = gaugeControl_TG.GaugeItems[0];
            ((NumericIndicator)gaugeN).Text = "T="+slider_T.Value;
            //просчитать 1-2-3 мю
            ExecuteM();
        }

        #region Подсветка текста в отчете
        private KeyValuePair<Regex, Style>[] PAIRS = new[]
                                                         {
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@"(\|\|)", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Green, null, FontStyle.Italic)),//ep1
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(" if", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Blue, null, FontStyle.Italic)),//if 
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@" (&&) ", RegexOptions.IgnoreCase),
                                                                 new TextStyle(Brushes.Cyan, null, FontStyle.Italic)),//h¹15//δ¹3
                                                             new KeyValuePair<Regex, Style>(
                                                                 new Regex(@" ?\(|\)", RegexOptions.IgnoreCase),
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
        {
            foreach (KeyValuePair<Regex, Style> keyValuePair in PAIRS)
            {
                e.ChangedRange.SetStyle(keyValuePair.Value, keyValuePair.Key);
            }
        }

        private void fastColoredTextBox1_VisibleRangeChanged(object sender, EventArgs e){}

        #endregion




    }
}
