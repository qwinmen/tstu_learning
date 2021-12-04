using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

//Вар 17
namespace Laba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.Title.Text = "";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "x";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "t";

            zedGraphControl2.GraphPane.Title.Text = "";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "x";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "T";

            Расчеты();
        }

        double a = 0.013; //м*м.с
        double dx = 0.1; //м
        //double dt = 0.5*dx*dx;
        double dt = 1;
        double XMin = 0;
        double X = 1; //м
        double tMin = 0;
        double tMax = 100; //с

        double fi(double _x)
        {
            return 25 - 2 * (_x + 1.0) * (_x + 1.0);//return 20 - _x;
        }

        double f1(double _t)
        {
            return _t + 5.0 * Math.Cos(_t) + 18;//return 20 + _t + 5 * Math.Sin(_t);
        }

        double f2(double _t)
        {
            return 17 + 0.15 * _t;//return 0.0003*_t*_t + 0.06*_t + 19;
        }


        private void Расчеты()
        {
            PointPairList list = new PointPairList();

            int tN = (int) ((tMax - tMin)/dt) + 1;
            int xN = (int) ((X - XMin)/dx) + 1;

            double[,] T = new double[tN, tN];
            for (int j = 0; j < tN; ++j)
            {
                T[j,0] = xN;
            }

            
            for (int j = 0; j < tN; ++j)
                for (int i = 0; i < xN; ++i)
                    T[j,i] = -666;

            for (int j = 0; j < tN; ++j)
            {
                T[j,0] = f1(j*dx);
            }

            for (int i = 0; i < xN; ++i)
            {
                T[0,i] = fi(i*dx);
            }

            for (int j = 0; j < tN; ++j)
            {
                T[j, xN - 1] = f2(j*dx);
            }

            for (int j = 0; j < tN - 1; ++j)
            {

                for (int i = 1; i < xN - 1; ++i)
                {
                    T[j + 1, i] = a*dt/(dx*dx)*(T[j, i + 1] - 2*T[j, i] + T[j, i - 1]) + T[j, i];
                }
            }

            for (int j = 0; j < tN; ++j)
                for (int i = 0; i < xN; ++i)// fprintf(f, "T[%d][%d] = %lf\n", j, i, T[j][i]);//fprintf(f, "%lf\n%lf\n%lf\n", j * dt, i * dx, T[j][i]);//t, x, T
                    list.Add(j*dt, i*dx, T[j, i]);
            


            PointPairList tm = new PointPairList();
            foreach (PointPair pointPair in list)
            {
                tm.Add(pointPair.X, pointPair.Y);
            }
            DrawGraph(zedGraphControl1, new PointPairList(tm));

            PointPairList tm2 = new PointPairList();
            foreach (PointPair pointPair in list)
            {
                tm2.Add(pointPair.Y, pointPair.Z);
            }
            DrawGraph(zedGraphControl2, new PointPairList(tm2));
        }


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
