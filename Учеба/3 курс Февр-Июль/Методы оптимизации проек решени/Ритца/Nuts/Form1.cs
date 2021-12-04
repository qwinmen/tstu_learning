using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Nuts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _AddText("Active");
            
            //точка входа
            Resot();
        }

        private void _AddText(string  str)
        {
            textBox1.Text += str + "\r\n";
        }

        /// <summary>
        /// Отрисовка графика функции
        /// </summary>
        private void DrawGraph(ZedGraphControl zedGraph, PointPairList _list, Color lineColor, SymbolType symbolType)
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
            LineItem myCurve = pane.AddCurve("", _list, lineColor, symbolType);

            // Включим сглаживание
            //myCurve.Line.IsSmooth = true;
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();

        }

        /// <summary>
        /// Первое построение по краевым точкам
        /// </summary>
        private void Resot()
        {
            zedGraph.GraphPane.CurveList.Clear();

            var xt0 = new PointD(-1, 2);
            var xt1 = new PointD(1, 0);

            PointPairList _listX = new PointPairList();
            //по краевым точкаm строим линию
            _listX.Add(new PointPair(xt0.X, xt0.Y));
            _listX.Add(new PointPair(xt1.X, xt1.Y));
            DrawGraph(zedGraph, _listX, Color.Blue, SymbolType.Circle);

            _AddText(String.Concat("Построение по краевым точкам [" + xt0.X +';' + xt0.Y + "] [" + xt1.X +';' + xt1.Y+']'));

            Poverka(xt0, xt1);

        }

        private clSimpson _clSimpson = new clSimpson();
        private clGradient _grad;

        private void Poverka(PointD xt0, PointD xt1)
        {
            _grad = new clGradient(textBox1);

            zedGraph.GraphPane.Title.Text = "";
            zedGraph.GraphPane.YAxis.Title.Text = "x";
            zedGraph.GraphPane.XAxis.Title.Text = "t";
            
            const double epsilon = 0.01;
            _AddText("epsilon = "+epsilon);

            //шаг t
            double delta = 0.1;

            //принимаем a1, a2 = 1
            double a1 = 1.0, a2 = 1.0;
            
            List<double> производныеX = new List<double>();
            List<double> производныеY = new List<double>();
            int countList = 0;

            //note: вычислим производные по X и Y
            for (double t = -1.0; t < 1.0; t+=delta, countList++)
            {
                double proizvodX = ПроизводнаяПоИкс(a1, t);
                производныеX.Add(proizvodX);

                double proizvodY = ПроизводнаяПоИгрек(a2, t);
                производныеY.Add(proizvodY);
            }

            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            //note: решаем систему, находим X и Y
            for (double t = -1.0; t < 1.0; t+=delta)
            {
                double x = X(a1, t);
                listX.Add(x);

                double y = Y(a2, t);
                listY.Add(y);
            }

            List<double> Integral = new List<double>();

            int index = 0;
            //note: решаем интеграл
            for (double t = -1.0; t < 1.0; t+=delta)
            {
                //t=[-1.0; 1.0]
                double integrl = _clSimpson.Simpson(-1.0, 1.0, 0.1, t, производныеX[index], производныеY[index]);
                Integral.Add(integrl);
                index++;
            }
            //Площадь интеграла
            double sumInteg = Integral.Sum();

            //Изменяем a1 a2
            a1 = a1 - 0.1;
            a2 = a2 - 0.1;

            for (double t = -0.1; t < 1.0; t+=delta)
            {
                //note: Считаем градиент
                if (t < -0.01 || t > 0.01)
                    _grad.Poisk(new Point(a1, a2), t);
            }

            
            

            

        }


        #region Производные X' и Y' по t
        
        /// <summary>
        /// Производная по t от -t+1+(a1)*(t-1)*(t+1)*sin(t)
        /// </summary>
        public double ПроизводнаяПоИкс(double a1, double t)
        {//a1*(t^2-1)*cos(t)+2*a1*t*sin(t)-1
            return a1*(t*t-1.0)*Math.Cos(t)+2.0*a1*t*Math.Sin(t)-1.0;
        }

        /// <summary>
        /// Производная по t от t+(a2)*(t-1)*(t+1)*t^2
        /// </summary>
        public double ПроизводнаяПоИгрек(double a2, double t)
        {//a2*(4*t^3-2*t)+1
            return a2*(4.0*(t*t*t) - 2.0*t) + 1.0;
        }

        #endregion

        #region Система X и Y

        public double X(double a1, double t)
        {
            return (-t + 1.0 + (a1)*(t - 1.0)*(t + 1.0)*Math.Sin(t));
        }

        public double Y(double a2, double t)
        {
            return (t + (a2)*(t - 1.0)*(t + 1.0)*(t*t));
        }

        #endregion





    }
}
