using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Karma
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Точки для вывода на холст
        /// </summary>
        private static PointPairList _integral = new PointPairList();
        private const double _epsilon = 0.01;
        private clSimpson _clSimpson = new clSimpson();

        public Form1()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.Title.Text = "Градиент";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Ось A2";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Ось A1";

            zedGraphControl2.GraphPane.Title.Text = "";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Ось A1";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Ось t";

            zedGraphControl3.GraphPane.Title.Text = "";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Ось A2";
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Ось t";

            //выводим две линии из первой лабы
            XtYt();

            Poisk();
            DrawGraph(zedGraphControl1, _integral, Color.Red, SymbolType.Square, "градиент [a1;a2]");
            foreach (PointPair pair in _integral)
            {
                SetPointCurve(pair.X, pair.Y);
            }
            //выводим из второй
            Xa();
            Table(_integral);
        }

        private void XtYt()
        {
            var xt0 = new PointD(0, 0);
            var xt1 = new PointD(1, 1);

            var yt0 = new PointD(0, 0);
            var yt1 = new PointD(1, 1);

            PointPairList _listX = new PointPairList();
            //по краевым точкаm строим линию
            _listX.Add(new PointPair(xt0.X, xt0.Y));
            _listX.Add(new PointPair(xt1.X, xt1.Y));
            DrawGraph(zedGraphControl2, _listX, Color.Green, SymbolType.Circle, "Функционал x(t)");

            PointPairList _listY = new PointPairList();
            //по краевым точкаm строим линию
            _listY.Add(new PointPair(yt0.X, yt0.Y));
            _listY.Add(new PointPair(yt1.X, yt1.Y));
            DrawGraph(zedGraphControl3, _listY, Color.DeepPink, SymbolType.Circle, "Функционал y(t)");
        }

        /// <summary>
        /// Note: Чтобы проверить правильность метода-ответа
        /// заменяем 
        /// var x = X(a1.X, i); на var x = X(0, i);
        /// var y = Y(a2.Y, i); на var y = Y(0, i);
        /// Если линии слились с эталоном, то система работает
        /// </summary>
        private void Xa()
        {
            PointPairList list = new PointPairList();
            var a1 = _integral[_integral.Count - 1];
            for (double i = 0.0; i < 1.0; i += 0.1)
            {
                var x = X(a1.X, i);
                list.Add(i, x);
            }
            DrawGraph(zedGraphControl2, list, Color.Blue, SymbolType.TriangleDown, "x(t) при найденом A1");

            list = new PointPairList();
            var a2 = _integral[_integral.Count - 1];
            for (double i = 0.0; i < 1.0; i += 0.1)
            {
                var y = Y(a2.Y, i);
                list.Add(i, y);
            }
            DrawGraph(zedGraphControl3, list, Color.Red, SymbolType.Triangle, "y(t) при найденом A2");


        }

        private void Table(PointPairList list)
        {
            int index = 0;
            foreach (var xy in list)
            {
                ListViewItem stroka1 = new ListViewItem(xy.X.ToString());
                stroka1.SubItems.Add(xy.Y.ToString());

                if (index % 2 == 0) listView1.Items.Add(stroka1);
                else
                {
                    stroka1.BackColor = Color.PapayaWhip;
                    listView1.Items.Add(stroka1);
                }
                index++;
            }

        }

        GraphPane _pane;
        #region Note: Drawning
        /// <summary>
        /// Нарисовать точку по координате
        /// </summary>
        private void SetPointCurve(double x, double y)
        {
            _pane = zedGraphControl1.GraphPane;

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
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
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
        #endregion

        #region Система X и Y

        public static double X(double a1, double t)
        {//return (t + (a1) * (t - 1.0) * (t + 1.0) * Math.Sin(t*t*t));
            #region //Note: a1
            return (t + (a1) * (t - 1.0) * (t + 1.0) * (t * t* t));
            #endregion
            return 3.0 * (-1.0) * t * t * a1 + 2.0 - 2.0 * t;
        }

        public static double Y(double a2, double t)
        {
            #region //Note: a2
            return (t + (a2) * (t - 1.0) * (t + 1.0) * (t * t));
            #endregion
            var w1 = t * (t - 1.0) * t * t * (t - 1.0) * (t - 1.0) * Math.Pow(Math.Exp(t), 2);
            var w2 = t * (t - 1.0) * t * t * (t - 1.0) * (t - 1.0) * Math.Sin(t);
            return w1 + a2 * w2;
        }

        #endregion

        #region Производные X' и Y' по t
       
        //----------------------------ЧИСЛЕНО---------
        /// <summary>
        /// X'
        /// </summary>
        internal static double ПроизводнаяПоИкс(double a1, double start, double end)
        {//start=-1\\end=(-1)-0.1
            #region Note: x'
            #endregion
            return (X(a1, end) - X(a1, start)) / 0.1;
        }

        /// <summary>
        /// X''
        /// </summary>
        internal static double ПроизводнаяПоИгрек(double a2, double start, double end)
        {//start=-1\\end=(-1)-0.1
            #region Note: x''
            return (Y(a2, end) - Y(a2, start)) / 0.1;
            #endregion
            return (1.0/(end*end))*(X(a2, end) - 2.0*X(a2, start) + X(a2, start));
        }
        //--------------------------------------------
        
        #endregion

        /// <summary>
        /// Note: Метод поиска основан на градиентном
        /// </summary>
        internal static void Poisk()
        {
            var _h = 0.01;
            var deltaA = 0.1;//знаменатель системы gradA

            //[0] - А0 начальная точка в которой a1=1.0 И a2=1:
            Point A0 = new Point(1.0, 1.0);
            //вычислим интеграл по Симпсон
            List<double> Integral = new List<double>();
            Integral.Add(clSimpson.Simpson(A0.X, A0.Y));
            int index = 0;
            _integral.Add(A0.X, A0.Y);

            //сделать приращение по A0
            A0.X += 0.1;
            Integral.Add(clSimpson.Simpson(A0.X, A0.Y));
            A0.Y += 0.1;
            Integral.Add(clSimpson.Simpson(A0.X, A0.Y));

            //[1] - Найти градиент точки А0
            double dx1_A0 = Sistema_X(A0, Integral, index, deltaA);
            double dx2_A0 = Sistema_Y(A0, Integral, index, deltaA);

            //[2] - построить следующую точку
            double x1_A1 = A0.X + _h * (dx1_A0);
            double x2_A1 = A0.Y + _h * (dx2_A0);
            index++;

            Point A1 = new Point(x1_A1, x2_A1);
            Integral.Add(clSimpson.Simpson(A1.X, A1.Y));
            _integral.Add(A1.X, A1.Y);

            int i = 0;
            while (!Exit(A1, Integral, index))
            {
                i++;
                //сделать приращение по A1
                if (Integral[index - 1] > Integral[index + 2])
                {
                    A1.X -= 0.1;
                    Integral.Add(clSimpson.Simpson(A1.X, A1.Y));//[4
                    A1.Y -= 0.1;
                    Integral.Add(clSimpson.Simpson(A1.X, A1.Y));//[5
                }
                else
                {
                    A1.X += 0.1;
                    Integral.Add(clSimpson.Simpson(A1.X, A1.Y)); //[4
                    A1.Y += 0.1;
                    Integral.Add(clSimpson.Simpson(A1.X, A1.Y)); //[5
                }

                index += 2;

                //Найти градиент точки А1
                dx1_A0 = Sistema_X(A1, Integral, index, deltaA);
                dx2_A0 = Sistema_Y(A1, Integral, index, deltaA);

                //[2] - построить следующую точку
                x1_A1 = A1.X + _h * (dx1_A0);//0.78//0.46//0.68//0.53
                x2_A1 = A1.Y + _h * (dx2_A0);//2.0//14.0//41.0//122.0

                A1 = new Point(x1_A1, x2_A1);
                Integral.Add(clSimpson.Simpson(A1.X, A1.Y));
                index += 1;


                _integral.Add(A1.X, A1.Y);
            }




        }

        /// <summary>
        /// Find Grad(A)
        /// </summary>
        private static double Sistema_X(Point An, List<double> Integral, int index, double deltaA)
        {//0-1//3-4//6-7
            return (Integral[index] - Integral[index + 1]) / deltaA;//0-1//1-2//4-5
        }

        /// <summary>
        /// Find Grad(A)
        /// </summary>
        private static double Sistema_Y(Point An, List<double> Integral, int index, double deltaA)
        {//0-2//3-5//6-8
            return (Integral[index] - Integral[index + 2]) / deltaA;//0-2//1-3//4-6
        }

        /// <summary>
        /// Условие выхода - нахождение градиента
        /// </summary>
        private static bool Exit(Point An, List<double> Integral, int index)
        {//0-3//3-6
            if (Math.Abs(Integral[index - 1] - Integral[index + 2]) <= _epsilon)//0-3//3-6//6-9..
            {
                //Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y);
                MessageBox.Show(String.Format("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y));
                return true;
            }
            return false;

            //if (Math.Abs(Sistema_X(An, Integral, index)) + Math.Abs(Sistema_Y(An, Integral, index)) <= 0.01)
            {
                Console.WriteLine("Выход при A[{0:0.###};{1:0.###}]", An.X, An.Y);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Класс Точки для хранения [X;Y]
        /// </summary>
        class Point
        {
            private static int index = 0;
            private double _x, _y;
            /// <summary>
            /// [x.X1; X2.y]
            /// </summary>
            public Point(double x, double y)
            {
                _x = x;
                _y = y;
                //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
                index++;
            }
            /// <summary>
            /// [Point]
            /// </summary>
            public Point(Point A)
            {
                _x = A.X;
                _y = A.Y;
                //Console.WriteLine("new Point[X1={0:0.####}; X2={1:0.####}]", x, y);
                index++;
            }

            public double X { get { return _x; } set { _x = value; } }
            public double Y { get { return _y; } set { _y = value; } }

            public override string ToString()
            {
                return index.ToString();
            }

            public static Point operator +(Point x1, Point x2)
            {
                return new Point(x1.X + x2.X, x1.Y + x2.Y);
            }

            public static Point operator /(Point x1, double x2)
            {
                return new Point(x1.X / x2, x1.Y / x2);
            }

        }


    }
}
