using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ZedGraph;

namespace Пристрелка
{
    public partial class Form1 : Office2007Form
    {
        public Form1()
        {
            InitializeComponent();

            Resot();

        }

        /// <summary>
        /// Расчет
        /// </summary>
        private void PristrelkaX(PointD xt0, PointD xt1, PointD yt0, PointD yt1)
        {
            zedGraph_tx.GraphPane.Title.Text = "";
            zedGraph_tx.GraphPane.YAxis.Title.Text = "x";
            zedGraph_tx.GraphPane.XAxis.Title.Text = "t";

            List<double> rMas = new List<double>();
            //снять разницу по X[0]
            var res = Progon(xt0, xt1);
            //добавим разницу в массив
            rMas.Add(res);
            
            //задаем Z
            doubleInput_z.Value = doubleInput_z.Value - 1;
            //Разница x[1] при новом Z
            res = Progon(xt0, xt1);
            rMas.Add(res);

            int ier = 2, i = 0, iter = 0;
            //пока разница превышает заданную точность выполняем
            while (res > doubleInput_epsilon.Value)
            {
                i++;
                //если res[i] > res[i-1]
                if (res < rMas[i - 1])
                    doubleInput_z.Value = doubleInput_z.Value - 0.01;
                else doubleInput_z.Value = doubleInput_z.Value + 0.01;
                
                res = Progon(xt0, xt1);
                rMas.Add(res);

                //if (res == rMas[i - 1])
                //    iter++;
                //else iter = 0;

                //если пять последних ячеек не изменяются, то выход
                if(iter==6 || i==100) break;
            }
            rMas.Sort();
            MessageBoxEx.Show("X min = " + rMas[0]);
            
        }

        /// <summary>
        /// Для Х
        /// </summary>
        private double Progon(PointD xt0, PointD xt1)
        {
            PointPairList _list = new PointPairList();
			//количество шагов от t0 до t1
            var variacii = (Math.Abs(xt0.X) + Math.Abs(xt1.X)) / doubleInput_step.Value + 1;
            
			List<double> z = new List<double>();//var z = new double[(int)variacii];
            z.Add(doubleInput_z.Value);//z[0] = doubleInput_z.Value;
            List<double> x = new List<double>();//var x = new double[z.Length];
            x.Add(xt0.Y);//x[0] = xt0.Y;
            var index = 0;
            for (double i = xt0.X; i <= xt1.X; i += doubleInput_step.Value)
            {
                index++;
                z.Add(z[index - 1] + doubleInput_step.Value);//z.Add(z[index - 1] - i * doubleInput_step.Value);
                x.Add(x[index - 1] + z[index - 1] * doubleInput_step.Value);//x.Add(1.0 + z[index - 1] * doubleInput_step.Value);//

                _list.Add(i, x[index - 1]);
            }
            DrawGraph(zedGraph_tx, _list, Color.Red, SymbolType.Star);
            
            //снять разницу по X
            return Math.Abs(xt1.Y - (_list[_list.Count - 1].Y));//Math.Abs(xt1.Y) + Math.Abs(x[index - 1]);
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


        private void doubleInput_step_ButtonFreeTextClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Resot();
        }

        private void doubleInput_z_ButtonFreeTextClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Resot();
        }

        private void Resot()
        {
            zedGraph_tx.GraphPane.CurveList.Clear();
            zedGraph_ty.GraphPane.CurveList.Clear();

            var xt0 = new PointD(0.0, 1.0);//(-1, 2);
            var xt1 = new PointD(1.0, 3.0/2.0);//(1, 0);

            var yt0 = new PointD(0.0, 0.0);//(-1, -1);
            var yt1 = new PointD(1, 1);

            PointPairList _listX = new PointPairList();
            //по краевым точкаm строим линию
            _listX.Add(new PointPair(xt0.X, xt0.Y));
            _listX.Add(new PointPair(xt1.X, xt1.Y));
            DrawGraph(zedGraph_tx, _listX, Color.Blue, SymbolType.Circle);

            PristrelkaX(xt0, xt1, yt0, yt1);

            PointPairList _listY = new PointPairList();
            //по краевым точкаm строим линию
            _listY.Add(new PointPair(yt0.X, yt0.Y));
            _listY.Add(new PointPair(yt1.X, yt1.Y));
            DrawGraph(zedGraph_ty, _listY, Color.Blue, SymbolType.Circle);

            PristrelkaY(xt0, xt1, yt0, yt1);
        }

        private void PristrelkaY(PointD xt0, PointD xt1, PointD yt0, PointD yt1)
        {
            zedGraph_ty.GraphPane.Title.Text = "";
            zedGraph_ty.GraphPane.YAxis.Title.Text = "y";
            zedGraph_ty.GraphPane.XAxis.Title.Text = "t";
            
            List<double> rMas = new List<double>();
            //снять разницу по Y[0]
            var res = ProgonY(yt0, yt1);//3.98
            rMas.Add(res);

            var tmpU = doubleInput_u.Value;
            doubleInput_u.Value = doubleInput_u.Value - 0.1;

            var minState = tmpU < doubleInput_u.Value ? false : true;
            //y[1]
            res = ProgonY(yt0, yt1);//3.79
            rMas.Add(res);

            int ier = 2, i = 0, iter = 0;
            while (res > doubleInput_epsilon.Value)
            {
                i++;
                if (minState)
                //если res[i] < res[i-1]
                if (res < rMas[i - 1])
                doubleInput_u.Value = doubleInput_u.Value - 0.01;
                else doubleInput_u.Value = doubleInput_u.Value + 0.01;
                else
                 if (res > rMas[i - 1])
                doubleInput_u.Value = doubleInput_u.Value - 0.01;
                else doubleInput_u.Value = doubleInput_u.Value + 0.01;
                

                res = ProgonY(yt0, yt1);

                rMas.Add(res);

                if (res == rMas[i - 1])
                    iter++;
                else iter = 0;

                //если пять последних ячеек не изменяются, то выход
                if (iter == 6 )
                    break;
            }
            rMas.Sort();
            MessageBoxEx.Show("Y min = " + rMas[0]);

        }

        private double ProgonY(PointD yt0, PointD yt1)
        {
            var _list = new PointPairList();
            
            var u = new List<double>();//var u = new double[(int)variacii];
            u.Add(doubleInput_u.Value);//u[0] = doubleInput_u.Value;
            var y = new List<double>();//var y = new double[u.Length];
            y.Add(yt0.Y);//y[0] = yt1.Y;

            var index = 0;
            for (double i = yt0.X; i <= yt1.X+.001; i += doubleInput_step.Value)
            {
                index++;
                u.Add(u[index - 1]);//u[index] = u[index - 1];
                y.Add(y[index - 1] + u[index - 1] * doubleInput_step.Value);//y[index] = y[index - 1] + u[index - 1] * doubleInput_step.Value;

                _list.Add(i, y[index - 1]);
            }
            DrawGraph(zedGraph_ty, _list, Color.Red, SymbolType.Plus);

            //снять разницу по Y
            if (y[index - 1] > yt1.Y)
                return y[index - 1] - yt1.Y;//Math.Abs() - Math.Abs();//
            return yt1.Y - y[index - 1];//Math.Abs(yt1.Y) + Math.Abs(y[index - 1]);
            //var bull = Math.Abs(yt1.Y) + Math.Abs(y[index - 1]);

           // return bull;
        }

    }
}
