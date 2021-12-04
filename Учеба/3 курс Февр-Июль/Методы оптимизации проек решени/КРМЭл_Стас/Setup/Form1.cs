using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Setup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init(1);
        }

        private void Init(int cbx)
        {
            zedGraphControl1.GraphPane.Title.Text = "";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Ось X";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Ось t";

            zedGraphControl2.GraphPane.Title.Text = "";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Ось X'";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Ось t";

            //выводiм две лiнii iз первой лабы
            XtYt();

            if (cbx == 1) Raschet();
            else if (cbx == 2) Raschet2();
            else Raschet3();
        }

        private void XtYt()
        {
            var xt0 = new PointD(0, 0);
            var xt1 = new PointD(1, 1);

            //var yt0 = new PointD(0, 0);
            //var yt1 = new PointD(1, 1);

            PointPairList _listX = new PointPairList();
            //по краевым точкаm строiм лiнiю
            _listX.Add(new PointPair(xt0.X, xt0.Y));
            _listX.Add(new PointPair(xt1.X, xt1.Y));
            DrawGraph(zedGraphControl1, _listX, Color.Green, SymbolType.Circle, "Функцiонал x(t)");

            //PointPairList _listY = new PointPairList();
            //по краевым точкаm строiм лiнiю
            //_listY.Add(new PointPair(yt0.X, yt0.Y));
            //_listY.Add(new PointPair(yt1.X, yt1.Y));
            //DrawGraph(zedGraphControl2, _listY, Color.DeepPink, SymbolType.Circle, "Функцiонал x'(t)");
        }

        /// <summary>
        /// Отрiсовка графiка функцii
        /// </summary>
        private void DrawGraph(ZedGraphControl zedGraph, PointPairList _list, Color lineColor, SymbolType symbolType, string title)
        {
            // Получiм панель для рiсованiя
            GraphPane pane = zedGraph.GraphPane;

            //pane.LineType = LineType.Normal;

            // Очiстiм спiсок крiвых на тот случай, еслi до этого сiгналы уже былi нарiсованы
            //pane.CurveList.Clear();

            // !!!
            // Устанавлiваем iнтересующiй нас iнтервал по осi X
            pane.XAxis.Scale.MinAuto = true;//pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.MaxAuto = true;//pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавлiваем iнтересующiй нас iнтервал по осi Y
            pane.YAxis.Scale.MinAuto = true;//pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.MaxAuto = true;//pane.YAxis.Scale.Max = ymax_limit;


            // Включiм отображенiе сеткi
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Создадiм крiвую с названiем "Sinc",// которая будет рiсоваться голубым цветом (Color.Blue),
            // Опорные точкi выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(title, _list, lineColor, symbolType);

            // Включiм сглажiванiе
            //myCurve.Line.IsSmooth = true;
            // Вызываем метод AxisChange (), чтобы обновiть данные об осях.
            // В протiвном случае на рiсунке будет показана только часть графiка,
            // которая умещается в iнтервалы по осям, установленные по умолчанiю
            zedGraph.AxisChange();

            // Обновляем графiк
            zedGraph.Invalidate();

        }

        private void Raschet()
        {
            var index = 0;
            var epsilon = 0.01;
            var delta = 0.15;
            var TODO = 3;
            var tmp = Math.Abs(1.0) / TODO;
            //разбiть отрезок iнтегрiрованiя [-1;1]
            //на трi частi:
            double t0 = 0 + tmp;
            double t1 = t0 + tmp;

            var idelI = clSimpson.Simpson(1.0, 0.0, tmp, TODO);
            //предпологаем что в этiх значенiях t, iкс равен 0
            double x0 = 0.0;
            double x1 = 0.0;

            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            //вычiслiм значенiе iнтеграла с этiмi точкамi
            //вычiслiм iнтеграл по Сiмпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));

            //делаем прiрощенiе по x для x0
            x0 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
        a1:
            //вычiслiм значенiе iнтеграла с этiмi точкамi
            //вычiслiм iнтеграл по Сiмпсон
            Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));
            index++;//1

            if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
            {
                x0 += delta;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);
            }
            else
            {
                x1 += delta;
                Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));
                index++;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);

                if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
                {
                    x1 += delta;
                    SetPointCurve(t0, x0, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
                else
                {
                    x0 += delta;
                    SetPointCurve(t0, x0, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
            }

            if (Math.Abs(Integral[index]) - Math.Abs(idelI) <= epsilon)
            {
                x0 += delta;x1 += delta;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);
                ExitMessg(t1, t1, new PointD(x1, x1 += delta));
                MessageBox.Show(String.Format("Выход прi  x0=[{0}], x1=[{1}]", x0, x1));
                return;
            }

            x1 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            //if (Integral[index] - Integral[index - 1] <= idelI)
            //  MessageBox.Show("kjkjk");
            goto a1;
        }

        GraphPane _pane;

        /// <summary>
        /// Нарiсовать точку по коордiнате
        /// </summary>
        private void SetPointCurve(double x, double y, ZedGraphControl control)
        {
            _pane = control.GraphPane;

            // Включiм отображенiе сеткi
            _pane.XAxis.MajorGrid.IsVisible = true;
            _pane.YAxis.MajorGrid.IsVisible = true;

            _pane.XAxis.Scale.MaxAuto = true;
            _pane.XAxis.Scale.MinAuto = true;

            _pane.YAxis.Scale.MaxAuto = true;
            _pane.YAxis.Scale.MinAuto = true;

            LineItem curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            // У крiвой лiнiя будет невiдiмой
            curvePount.Line.IsVisible = false;
            //Тег будет лiнком для поiска точкi, которую надо перезапiсать

            // Цвет заполненiя круга - колубой
            curvePount.Symbol.Fill.Color = Color.Blue;
            // Тiп заполненiя - сплошная залiвка
            curvePount.Symbol.Fill.Type = FillType.Solid;
            // Размер круга
            curvePount.Symbol.Size = 7;
            //-----------------------------------------//
            control.AxisChange();
            control.Invalidate();
        }


        //----------------------------ЧiСЛЕНО---------
        internal static double ПроiзводнаяПоiкс(double a1, double start, double end, double tmp)
        {//start=-1\\end=(-1)-0.1
            return (X(a1, end, tmp) - X(a1, start, tmp)) / tmp;//0.67
        }

        internal static double ВтораяПроiзводнаяПоiкс(double a2, double start, double end, double tmp)
        {//start=-1\\end=(-1)-0.1
            return ПроiзводнаяПоiкс(a2, start, end, tmp)/tmp;
            //return (Y(a2, end) - Y(a2, start)) / tmp;//0.67
        }
        //--------------------------------------------

        #region Сiстема X i Y

        public static double X(double a1, double t, double a2)
        {
            //return (-t + 1.0 + (a1) * (t - 1.0) * (t + 1.0) * Math.Sin(t));

            var w0 = 3.0 * (-1.0) * t * t + 2.0 * 2.0 * t;
            var w1 = t * (t - 1.0) * t * t * (t - 1.0) * (t - 1.0) * Math.Cos(t);
            var w2 = t * (t - 1.0) * t * t * (t - 1.0) * (t - 1.0) * Math.Sin(t);
            return w0 + a1 * w1 + a2 * w2;
        }

        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            int cbx = ((RadioButton) sender).TabIndex;
            ClearHolst();
            Init(cbx);
        }

        private void Raschet2()
        {
            var index = 0;
            var epsilon = 0.01;
            var delta = 0.16;
            var TODO = 4;
            var tmp = Math.Abs(1.0) / TODO;
            //разбiть отрезок iнтегрiрованiя [-1;1]
            //на 4 частi:
            double t0 = 0 + tmp;
            double t1 = t0 + tmp;
            double t2 = t1 + tmp;

            var idelI = clSimpson.Simpson(1.0, 0.0, tmp, TODO);
            //предпологаем что в этiх значенiях t, iкс равен 0
            double x0 = 0.0;
            double x1 = 0.0;
            double x2 = 0.0;

            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            SetPointCurve(t2, x2, zedGraphControl1);
            
            //вычiслiм значенiе iнтеграла с этiмi точкамi
            //вычiслiм iнтеграл по Сiмпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));

            //делаем прiрощенiе по x для x0
            x0 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
        a1:
            //вычiслiм значенiе iнтеграла с этiмi точкамi
            //вычiслiм iнтеграл по Сiмпсон
            Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));
            index++;//1

            if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
            {
                x0 += delta;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);
            }
            else
            {
                x1 += delta;
                Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));
                index++;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);

                if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
                {
                    x1 += delta;
                    SetPointCurve(t0, x0, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
                else
                {
                    x0 += delta;
                    SetPointCurve(t0, x0, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
            }

            x2 += delta;
            Integral.Add(clSimpson.Simpson(x1, x2, tmp, TODO));
            index++;
            SetPointCurve(t1, x1, zedGraphControl1);
            SetPointCurve(t2, x2, zedGraphControl1);

            if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
            {
                x2 += delta;
                SetPointCurve(t1, x1, zedGraphControl1);
                SetPointCurve(t2, x2, zedGraphControl1);
            }
            else
            {
                x1 += delta;
                SetPointCurve(t1, x1, zedGraphControl1);
                SetPointCurve(t2, x2, zedGraphControl1);
            }

            if (Math.Abs(Integral[index]) - Math.Abs(idelI) <= epsilon)
            {
                x2 += delta; 
                SetPointCurve(t1, x1, zedGraphControl1);
                SetPointCurve(t2, x2, zedGraphControl1);
                ExitMessg(t2, t2, new PointD(x2 += delta, x2 += delta));
                MessageBox.Show(String.Format("Выход прi  x0=[{0}], x1=[{1}], x2=[{2}]", x0, x1, x2));
                return;
            }

            x1 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            
            goto a1;
        }

        private void Raschet3()
        {
            var index = 0;
            var epsilon = 0.01;
            var delta = 0.17;
            var TODO = 5;
            var tmp = Math.Abs(1.0) / TODO;
            //разбiть отрезок iнтегрiрованiя [-1;1]
            //на 5 частei:
            double t0 = 0 + tmp;
            double t1 = t0 + tmp;
            double t2 = t1 + tmp;
            double t3 = t2 + tmp;

            var idelI = clSimpson.Simpson(1.0, 0.0, tmp, TODO);
            //предпологаем что в этiх значенiях t, iкс равен 0
            double x0 = 0.0;
            double x1 = 0.0;
            double x2 = 0.0;
            double x3 = 0.0;

            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            SetPointCurve(t2, x2, zedGraphControl1);
            SetPointCurve(t3, x3, zedGraphControl1);

            //вычiслiм значенiе iнтеграла с этiмi точкамi
            //вычiслiм iнтеграл по Сiмпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));

            //делаем прiрощенiе по x для x0
            x0 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
        a1:
            //вычiслiм значенiе iнтеграла с этiмi точкамi
            //вычiслiм iнтеграл по Сiмпсон
            Integral.Add(clSimpson.Simpson(x0, x1, tmp, TODO));
            index++;//1

            if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
            {
                x0 += delta;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);
            }
            else
            {
                x1 += delta;
                Integral.Add(clSimpson.Simpson(x1, x2, tmp, TODO));
                index++;
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);

                if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
                {
                    x1 += delta;
                    SetPointCurve(t0, x0, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
                else
                {
                    x2 += delta;
                    SetPointCurve(t2, x2, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
            }

            x2 += delta;
            Integral.Add(clSimpson.Simpson(x2, x3, tmp, TODO));
            index++;
            SetPointCurve(t1, x1, zedGraphControl1);
            SetPointCurve(t2, x2, zedGraphControl1);

            if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
            {
                x3 += delta;
                SetPointCurve(t2, x2, zedGraphControl1);
                SetPointCurve(t3, x3, zedGraphControl1);
            }
            else
            {
                x2 += delta;
                SetPointCurve(t1, x1, zedGraphControl1);
                SetPointCurve(t2, x2, zedGraphControl1);
            }

            if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
            {
                x1 += delta;
                SetPointCurve(t2, x2, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);
            }
            else
            {
                x3 += delta;
                Integral.Add(clSimpson.Simpson(x1, x3, tmp, TODO));
                index++;
                SetPointCurve(t3, x3, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);

                if (Math.Abs(Integral[index - 1]) > Math.Abs(Integral[index]))
                {
                    x1 += delta;
                    SetPointCurve(t0, x0, zedGraphControl1);
                    SetPointCurve(t1, x1, zedGraphControl1);
                }
                else
                {
                    x3 += delta;
                    SetPointCurve(t2, x2, zedGraphControl1);
                    SetPointCurve(t3, x3, zedGraphControl1);
                }
            }

            if (Math.Abs(Integral[index]) - Math.Abs(idelI) <= epsilon)
            {
                x3 += delta;
                SetPointCurve(t2, x2, zedGraphControl1);
                SetPointCurve(t3, x3, zedGraphControl1);
                ExitMessg(t3, t3, new PointD(x3 += delta, x3 += delta));
                MessageBox.Show(String.Format("Выход прi  x0=[{0}], x1=[{1}], x2=[{2}], x3=[{3}]", x0, x1, x2, x3));
                return;
            }

            x2 += delta; x3 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            SetPointCurve(t2, x2, zedGraphControl1);

            goto a1;
        }

        private void ClearHolst()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;

            //pane.LineType = LineType.Normal;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        /// <summary>
        /// Сообщенiе выхода
        /// </summary>
        private void ExitMessg(double t1, double t2, PointD x)
        {
            SetPointCurve(t1, x.X, zedGraphControl1);
            SetPointCurve(t2, x.Y, zedGraphControl1);
        }

    }
}
