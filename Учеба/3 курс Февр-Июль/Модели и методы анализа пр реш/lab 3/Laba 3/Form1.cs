using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

//вар 17
namespace Laba_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            zedGraphControl1.GraphPane.Title.Text = "C1";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "y";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "x";

            zedGraphControl2.GraphPane.Title.Text = "C1";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "y";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "x";

            zedGraphControl3.GraphPane.Title.Text = "C2";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "y";
            zedGraphControl3.GraphPane.XAxis.Title.Text = "x";

            zedGraphControl4.GraphPane.Title.Text = "C2";
            zedGraphControl4.GraphPane.YAxis.Title.Text = "y";
            zedGraphControl4.GraphPane.XAxis.Title.Text = "x";

            zedGraphControl5.GraphPane.Title.Text = "C3";
            zedGraphControl5.GraphPane.YAxis.Title.Text = "y";
            zedGraphControl5.GraphPane.XAxis.Title.Text = "x";

            zedGraphControl6.GraphPane.Title.Text = "C3";
            zedGraphControl6.GraphPane.YAxis.Title.Text = "y";
            zedGraphControl6.GraphPane.XAxis.Title.Text = "x";

            Решение();
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


        private void Решение()
        {
            PointPairList leftList1 = new PointPairList();
            PointPairList leftList2 = new PointPairList();
            PointPairList leftList3 = new PointPairList();

            PointPairList rightList1 = new PointPairList();
            PointPairList rightList2 = new PointPairList();
            PointPairList rightList3 = new PointPairList();

            double h = 0.5,
                   x,
                   y,
                   z,
                   y_prev,
                   z_prev,
                   xНачало = 0,
                   xКонец = 80,
                   koef1,
                   koef2,
                   koef3,
                   C_in_proc = 20,
                   C_in;
            //общее:
            double R = 8.31,
                   E1 = 251000,
                   E2 = 297000,
                   PI = Math.PI,
                   A1 = 2E11,
                   A2 = 8E12,
                   ro = 1.4,
                   D = 0.1;
            //# m5 вариант:
            double m = 1.2, T = 1240;

            //C_in - изменяется от 3-% до 4-% в 17 варианте
            C_in = C_in_proc*ro/(28.05*100)*1000;

            koef1 = -A1*Math.Pow(2.71828, -E1/(R*T))*PI*D*D*ro/(4*m);
            koef2 = -koef1;
            koef3 = -A2*Math.Pow(2.71828, -E2/(R*T))*PI*D*D*ro/(4*m);



            x = xНачало;
            y_prev = C_in;
            z_prev = 0;


            #region рунге-кутта

            double k1y, k2y, k3y, k4y, k1z, k2z, k3z, k4z;
            // for (int i = 0; i <=(xКонец - xНачало)/h + h/2; i++)
            //for (int i = 0; i <=50 ; i++)
            for (int i = 0; i < (xКонец - xНачало); i++)
            {
                //        y = y_prev + h*koef1*y_prev;
                k1y = koef1*y_prev;
                k2y = koef1*(y_prev + h*k1y/2);
                k3y = koef1*(y_prev + h*k2y/2);
                k4y = koef1*(y_prev + h*k3y);
                y = y_prev + h*(k1y + 2*k2y + 2*k3y + k4y)/6;

                //        z = z_prev + h*(koef2*y_prev + koef3*z_prev);
                k1z = koef2*y_prev + koef3*z_prev;
                k2z = koef2*y_prev + koef3*(z_prev + h*k1z/2);
                k3z = koef2*y_prev + koef3*(z_prev + h*k2z/2);
                k4z = koef2*y_prev + koef3*(z_prev + h*k3z);
                z = z_prev + h*(k1z + 2*k2z + 2*k3z + k4z)/6;

                x++;//x = x++;
                y_prev = y;
                z_prev = z;
                
                leftList1.Add(x, y);
                rightList1.Add(x, z);
                
            }
            #endregion

            C_in_proc = 25;
            C_in = C_in_proc*ro/(28.05*100)*1000;
            x = xНачало;
            y_prev = C_in;
            z_prev = 0;
            for (int i = 0; i < (xКонец - xНачало); i++)
            {
                //        y = y_prev + h*koef1*y_prev;
                k1y = koef1*y_prev;
                k2y = koef1*(y_prev + h*k1y/2);
                k3y = koef1*(y_prev + h*k2y/2);
                k4y = koef1*(y_prev + h*k3y);
                y = y_prev + h*(k1y + 2*k2y + 2*k3y + k4y)/6;

                //        z = z_prev + h*(koef2*y_prev + koef3*z_prev);
                k1z = koef2*y_prev + koef3*z_prev;
                k2z = koef2*y_prev + koef3*(z_prev + h*k1z/2);
                k3z = koef2*y_prev + koef3*(z_prev + h*k2z/2);
                k4z = koef2*y_prev + koef3*(z_prev + h*k3z);
                z = z_prev + h*(k1z + 2*k2z + 2*k3z + k4z)/6;

                x++;//x = x++;
                y_prev = y;
                z_prev = z;
                //this->chart1->Series["С2"]->Points->AddXY(x, y);
                leftList2.Add(x, y);
                //this->chart2->Series["С2"]->Points->AddXY(x, z);
                rightList2.Add(x, z);
                //printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
                //printf("x = %lf, y = %lf\n", x, y);
            }
            C_in_proc = 30;
            C_in = C_in_proc*ro/(28.05*100)*1000;
            x = xНачало;
            y_prev = C_in;
            z_prev = 0;
            for (int i = 0; i < (xКонец - xНачало); i++)
            {
                //        y = y_prev + h*koef1*y_prev;
                k1y = koef1*y_prev;
                k2y = koef1*(y_prev + h*k1y/2);
                k3y = koef1*(y_prev + h*k2y/2);
                k4y = koef1*(y_prev + h*k3y);
                y = y_prev + h*(k1y + 2*k2y + 2*k3y + k4y)/6;

                //        z = z_prev + h*(koef2*y_prev + koef3*z_prev);
                k1z = koef2*y_prev + koef3*z_prev;
                k2z = koef2*y_prev + koef3*(z_prev + h*k1z/2);
                k3z = koef2*y_prev + koef3*(z_prev + h*k2z/2);
                k4z = koef2*y_prev + koef3*(z_prev + h*k3z);
                z = z_prev + h*(k1z + 2*k2z + 2*k3z + k4z)/6;

                x++;//x = x++;
                y_prev = y;
                z_prev = z;
                //this->chart1->Series["С3"]->Points->AddXY(x, y);
                leftList3.Add(x,y);
                //this->chart2->Series["С3"]->Points->AddXY(x, z);
                rightList3.Add(x, z);
                //printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
                //printf("x = %lf, y = %lf\n", x, y);
            }

            DrawGraph(zedGraphControl1, leftList1);
            DrawGraph(zedGraphControl2, rightList1);

            DrawGraph(zedGraphControl3, leftList2);
            DrawGraph(zedGraphControl4, rightList2);

            DrawGraph(zedGraphControl5, leftList3);
            DrawGraph(zedGraphControl6, rightList3);
        }






    }
}
