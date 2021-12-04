using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Lab_2
{//вар 17
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zedGraph.GraphPane.Title.Text = "";
            zedGraph.GraphPane.YAxis.Title.Text = "С(вых)";
            zedGraph.GraphPane.XAxis.Title.Text = "t";
            //Свых(t):
            DrawGraph(zedGraph, dM_1_55());

            zedGraph2.GraphPane.Title.Text = "";
            zedGraph2.GraphPane.YAxis.Title.Text = "С(вх)";
            zedGraph2.GraphPane.XAxis.Title.Text = "t";
            //Свх(t):
            DrawGraph(zedGraph2, Cвх_t());

            zedGraph3.GraphPane.Title.Text = "";
            zedGraph3.GraphPane.YAxis.Title.Text = "m(вх)";
            zedGraph3.GraphPane.XAxis.Title.Text = "t";
            //mвх(t):
            DrawGraph(zedGraph3, mвх_t());

            zedGraph4.GraphPane.Title.Text = "";
            zedGraph4.GraphPane.YAxis.Title.Text = "Tп";
            zedGraph4.GraphPane.XAxis.Title.Text = "t";
            //Тп(t):
            DrawGraph(zedGraph4, Tп_t());
        }

        private const double _S = 0.75;
        private const double _sigma = 0.12;
        private const double _Cвх = 21.4;
        private const double _Cвых = 9.7;
        private const double _mвх = 7.5;
        private const double _mвт = 8.2;
        private const double _Tp = 95.7;
        private const double _P0 = 7900.0;
        private const double _P1 = 7600.0;

        private const double _dCвх = 2.0;
        private const double _dmвх = 3.8;
        private const double _dTп = 17.0;

        /// <summary>
        /// (M) Найти Массу раствора в апорате
        /// Начальное условие
        /// </summary>
        private double M_1_56(double i)
        {
            return _S*((_P1 - _P0) + ((_mвх - _mвт)/_sigma)*((_mвх - _mвт)/_sigma+i))/i;
        }

        /// <summary>
        /// (mвых) Масса на выходе
        /// </summary>
        private double mвых(double i)
        {
            return (_sigma*Math.Sqrt(_P0 + M_1_56(i)/_S - _P1));
        }

        /// <summary>
        /// dM(t)/dt =0
        /// </summary>
        private PointPairList dM_1_55()
        {
            PointPairList Cвых = new PointPairList();
            for (double i = 0; i < 500; i+=0.1)
            {
                Cвых.Add(i,(_mвх * _Cвх - mвых(i) * _Cвых) / M_1_56(i)+_Tp);
            }

            //Cвых(t)
            return Cвых;
        }

        /// <summary>
        /// Cвх(t)
        /// </summary>
        private PointPairList Cвх_t()
        {
            PointPairList Cвхt = new PointPairList();
            for (double i = 0; i < 500; i += 0.1)
            {
                Cвхt.Add(i, (_dmвх + mвых(i) + _Cвых) / M_1_56(i)+_dTп);
            }

            return Cвхt;
        }

        /// <summary>
        /// mвх(t)
        /// </summary>
        private PointPairList mвх_t()
        {
            PointPairList mвхt= new PointPairList();
            for (double i = 0; i < 500; i += 0.1)
            {
                mвхt.Add(i, mвых(i) + _mвт + (_dTп + _dCвх));
            }

            return mвхt;
        }

        private PointPairList Tп_t()
        {
            PointPairList Tпt= new PointPairList();
            for (double i = 0; i < 500; i += 0.1)
            {
                Tпt.Add(i, _dTп/(_dmвх * _dCвх - mвых(i) * _Cвых) + M_1_56(i) + _Tp);
            }

            return Tпt;
        }


        #region Рунге-Куты
        static double q(double x, double y)
        {//y'=x+sin(y/п)//15 вар
            return x + Math.Sin(y / Math.PI);//x + cos(y / sqrt(10));
        }
        static void Reshenie()
        {
            double x, y = 5.3, h = 0.01, a = 1.7, b = 2.7, k1, k2, k3, k4;
            x = a;
            Console.Write("{0}\t{1}\n", x, y);
            for (int i = 1; i < (b - a) / h; i++)
            {
                k1 = h * q(x, y);
                k2 = h * q(x + h / 2, y + k1 / 2);
                k3 = h * q(x + h / 2, y + k2 / 2);
                k4 = h * q(x + h, y + k3);
                x = x + h;
                y = y + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                Console.Write("{0:#.##}\t{1:#.##}\n", x, y);
            }
        }
        #endregion 





        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(ZedGraphControl zedGraph, PointPairList _list)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

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
            LineItem myCurve = pane.AddCurve("", _list, Color.Blue, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }






    }
}
