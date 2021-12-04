using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Дубль;

namespace КРмЭл
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.Title.Text = "";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Ось X";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Ось t";

            zedGraphControl2.GraphPane.Title.Text = "";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Ось Y";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Ось t";

            //выводим две линии из первой лабы
            XtYt();

            Raschet(12);
            RaschetY();
        }

        private void XtYt()
        {
            var xt0 = new PointD(-1, 2);
            var xt1 = new PointD(1, 0);

            var yt0 = new PointD(-1, -1);
            var yt1 = new PointD(1, 1);

            PointPairList _listX = new PointPairList();
            //по краевым точкаm строим линию
            _listX.Add(new PointPair(xt0.X, xt0.Y));
            _listX.Add(new PointPair(xt1.X, xt1.Y));
            DrawGraph(zedGraphControl1, _listX, Color.Green, SymbolType.Circle, "Функционал x(t)");

            PointPairList _listY = new PointPairList();
            //по краевым точкаm строим линию
            _listY.Add(new PointPair(yt0.X, yt0.Y));
            _listY.Add(new PointPair(yt1.X, yt1.Y));
            DrawGraph(zedGraphControl2, _listY, Color.DeepPink, SymbolType.Circle, "Функционал y(t)");
        }

        GraphPane _pane;

        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y, ZedGraphControl control)
        {
            _pane = control.GraphPane;

            // Включим отображение сетки
            _pane.XAxis.MajorGrid.IsVisible = true;
            _pane.YAxis.MajorGrid.IsVisible = true;

            _pane.XAxis.Scale.MaxAuto = true;
            _pane.XAxis.Scale.MinAuto = true;

            _pane.YAxis.Scale.MaxAuto = true;
            _pane.YAxis.Scale.MinAuto = true;

            LineItem curvePount = _pane.AddCurve("", new[] { x }, new[] { y }, Color.Blue, SymbolType.Circle);
            // У кривой линия будет невидимой
            curvePount.Line.IsVisible = false;
            //Тег будет линком для поиска точки, которую надо перезаписать

            // Цвет заполнения круга - колубой
            curvePount.Symbol.Fill.Color = Color.Blue;
            // Тип заполнения - сплошная заливка
            curvePount.Symbol.Fill.Type = FillType.Solid;
            // Размер круга
            curvePount.Symbol.Size = 7;
            //-----------------------------------------//
            control.AxisChange();
            control.Invalidate();
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(ZedGraphControl zedGraph, PointPairList _list, Color lineColor, SymbolType symbolType, string title)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            //pane.LineType = LineType.Normal;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();

            // !!!
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.MinAuto = true;//pane.XAxis.Scale.Min = xmin_limit;
            pane.XAxis.Scale.MaxAuto = true;//pane.XAxis.Scale.Max = xmax_limit;

            // !!!
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.MinAuto = true;//pane.YAxis.Scale.Min = ymin_limit;
            pane.YAxis.Scale.MaxAuto = true;//pane.YAxis.Scale.Max = ymax_limit;


            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Создадим кривую с названием "Sinc",// которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(title, _list, lineColor, symbolType);

            // Включим сглаживание
            //myCurve.Line.IsSmooth = true;
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();

        }

        private void Raschet(int a)
        {
            var index = 0;
            var epsilon = 0.001;
            var delta = 0.65;
            var tmp = Math.Abs(-1.0 - 1.0) / 3.0;
            //разбить отрезок интегрирования [-1;1]
            //на три части:
            double t0 = -1.0 + tmp;
            double t1 = t0 + tmp;

            var idelI = clSimpson.Simpson(2.0, 0.0, tmp);
            //предпологаем что в этих значениях t, икс равен 0
            double x0 = 0.0;
            double x1 = 0.0;

            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(x0, x1, tmp));
     
            //делаем прирощение по x для x0
            x0 += delta;
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);
        a1:
            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(x0, x1, tmp));
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
                Integral.Add(clSimpson.Simpson(x0, x1, tmp));
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

            if (Math.Abs(Integral[index-1]) - Math.Abs(Integral[index]) <= epsilon)
            {
                MessageBox.Show(String.Format("Выход при  x0=[{0}], x1=[{1}]", x0, x1));
                SetPointCurve(t0, x0, zedGraphControl1);
                SetPointCurve(t1, x1, zedGraphControl1);
                return;
            }
            
            //if (Integral[index] - Integral[index - 1] <= idelI)
              //  MessageBox.Show("kjkjk");
            goto a1;
        }

        private void RaschetY()
        {
            var index = 0;
            var epsilon = 0.001;
            var delta = 0.16;
            var tmp = Math.Abs(-1.0 - 1.0) / 3.0;
            //разбить отрезок интегрирования [-1;1]
            //на три части:
            double t0 = -1.0 + tmp;
            double t1 = t0 + tmp;

            var idelI = clSimpson.Simpson(1.0, -1.0, tmp);
            //предпологаем что в этих значениях t, икс равен 0
            double x0 = 0.0;
            double x1 = 0.0;

            SetPointCurve(t0, x0, zedGraphControl2);
            SetPointCurve(t1, x1, zedGraphControl2);

            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(x0, x1, tmp));

            SetPointCurve(t0, x0, zedGraphControl2);
            SetPointCurve(t1, x1, zedGraphControl2);
            //делаем прирощение по x для x0
            x0 -= delta;
 
        a1:
            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(x0, x1, tmp));
            index++;//1

            if (Math.Abs(Integral[index - 1]) < Math.Abs(Integral[index]))
            {
                SetPointCurve(t0, x0, zedGraphControl2);
                SetPointCurve(t1, x1, zedGraphControl2);
                x0 -= delta;
            }
            else
            {
                SetPointCurve(t0, x0, zedGraphControl2);
                SetPointCurve(t1, x1, zedGraphControl2);
                x1 += delta;
                Integral.Add(clSimpson.Simpson(x0, x1, tmp));
                index++;

                if (Math.Abs(Integral[index - 1]) < Math.Abs(Integral[index]))
                {
                    SetPointCurve(t0, x0, zedGraphControl2);
                    SetPointCurve(t1, x1, zedGraphControl2);
                    x1 += delta;
                }
                else
                {
                    SetPointCurve(t0, x0, zedGraphControl2);
                    SetPointCurve(t1, x1, zedGraphControl2);
                    x0 -= delta;
                }
            }

            if (Math.Abs(Integral[index-1]) - Math.Abs(Integral[index]) <= epsilon)
            {
                MessageBox.Show(String.Format("Выход при  x0=[{0}], x1=[{1}]", x0, x1));
                SetPointCurve(t0, x0, zedGraphControl2);
                SetPointCurve(t1, x1, zedGraphControl2);
                return;
            }

            //if (Integral[index] - Integral[index - 1] <= idelI)
              //  return;//MessageBox.Show("kjkjk");
            goto a1;
        }

        /*
        private void Raschet()
        {
            var index = 0;
            var epsilon = 0.1;

            #region Решения для X(t)

            var idelI = clSimpson.Simpson(2.0, 0.0);
            var tmp = Math.Abs(-1.0 - 1.0)/3.0;
            //разбить отрезок интегрирования [-1;1]
            //на три части:
            double t0 = -1.0 + tmp;
            double t1 = t0 + tmp;
            //предпологаем что в этих значениях t, икс равен 0
            double x0 = 0.0;
            double x1 = 0.0;

            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            List<double> Integral = new List<double>();

            Integral.Add(clSimpson.Simpson(x0, x1));

            //делаем прирощение по x для x0
            x0 += 0.1;
            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(x0, x1));
            index++;//1
a1:
            
            //если текущий меньше предыдущего, то опять прирощение
            while (CompareI(Integral[index-1], Integral[index]))
            {
                //делаем прирощение по x для x0
                x0 += 0.1;
                //вычислим значение интеграла с этими точками
                //вычислим интеграл по Симпсон
                Integral.Add(clSimpson.Simpson(x0, x1));
                index++;//2
                
            }
            
            
            //если текущий больше предыдущего, то переходим на x1
            //делаем прирощение по x для x1
            x1 += 0.1;
            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(x0, x1));
            index++;//3

            x1 += 0.1;
            //вычислим значение интеграла с этими точками
            //вычислим интеграл по Симпсон
            Integral.Add(clSimpson.Simpson(x0, x1));
            index++;//3
            
            while (CompareI(Integral[index-1], Integral[index]))
            {
                //делаем прирощение по x для x0
                x1 += 0.1;
                //вычислим значение интеграла с этими точками
                //вычислим интеграл по Симпсон
                Integral.Add(clSimpson.Simpson(x0, x1));
                index++;//4
                
            }

            
            SetPointCurve(t0, x0, zedGraphControl1);
            SetPointCurve(t1, x1, zedGraphControl1);

            if (idelI - Integral[index] < epsilon) return;
            goto a1;

            #endregion


        }
        */


        /// <summary>
        /// Вернет true если текущий меньше предыдущего 
        /// </summary>
        /// <param name="I0">предыдущий</param>
        /// <param name="I1">текущий</param>
        /// <returns></returns>
        private bool CompareI(double I0, double I1)
        {
            if (I1 < I0) return true;
            return false;
        }

        clSimpson _clSimpson = new clSimpson();

        #region Производные X' и Y' по t

        /// <summary>
        /// Производная по t от -t+1+(a1)*(t-1)*(t+1)*sin(t)
        /// </summary>
        public static double ПроизводнаяПоИкс(double a1, double t)
        {//a1*(t^2-1)*cos(t)+2*a1*t*sin(t)-1
            return a1 * (t * t - 1.0) * Math.Cos(t) + 2.0 * a1 * t * Math.Sin(t) - 1.0;
        }
        //----------------------------ЧИСЛЕНО---------
        internal static double ПроизводнаяПоИкс(double a1, double start, double end, double tmp)
        {//start=-1\\end=(-1)-0.1
            return (X(a1, end) - X(a1, start)) / tmp;//0.67
        }

        internal static double ПроизводнаяПоИгрек(double a2, double start, double end, double tmp)
        {//start=-1\\end=(-1)-0.1
            return (Y(a2, end) - Y(a2, start)) / tmp;//0.67
        }
        //--------------------------------------------

        /// <summary>
        /// Производная по t от t+(a2)*(t-1)*(t+1)*t^2
        /// </summary>
        public static double ПроизводнаяПоИгрек(double a2, double t)
        {//a2*(4*t^3-2*t)+1
            return a2 * (4.0 * (t * t * t) - 2.0 * t) + 1.0;
        }

        #endregion

        #region Система X и Y

        public static double X(double a1, double t)
        {
            return (-t + 1.0 + (a1) * (t - 1.0) * (t + 1.0) * Math.Sin(t));
        }

        public static double Y(double a2, double t)
        {
            return (t + (a2) * (t - 1.0) * (t + 1.0) * (t * t));
        }

        #endregion

        




    }
}
