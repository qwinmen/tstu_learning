using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Modeli_Kursovik_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // double C1_vh = 15.4375, C2_vh = 13.4118, C3_vh = 8.90625, C5_vh = 0;
            var C1 = new double[400];
            var C2 = new double[400];
            var C3 = new double[400];
            var C4 = new double[400];
            var C5 = new double[400];
            var T_vyh = new double[400];
            double E1 = 156000, E2 = 166400, E3 = 177400, E4 = 160000;
            double A1 = 10000, A2 = 20000, A3 = 50000, A4 = 500;
            double Q1 = 361000, Q2 = 950000, Q4 = 1520;
            double T_t = 500, M = 19, V = 10, K_t = 2000, F = 5, V_vh = 0.01, R = 8.31, Ct = 1200, ro = 1.9;
            double k1, k2, k3, k4;
            double T_vh = 1200.0, C1_vh = 15.4375, C2_vh = 13.4118, C3_vh = 8.90625, C4_vh = 0.0, C5_vh = 0.0;
            double Vr = 0.01 , d = 0.01 , eps = 0.01;

            T_vyh[0] = 1200.0;
            C1[0] = 15.4375;
            C2[0] = 13.4118;
            C3[0] = 8.90625;
            C4[0] = 0;
            C5[0] = 0;


            k1 = A1 * Math.Exp(-E1 / (R * T_vh));
            k2 = A2 * Math.Exp(-E2 / (R * T_vh));
            k3 = A3 * Math.Exp(-E3 / (R * T_vh));
            k4 = A4 * Math.Exp(-E4 / (R * T_vh));

            C1[1] = C1[0] + (((1.0 / (V / Vr)) * (C1_vh - C1[0])) - (2 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C3[0]) - (2 * k3 * C1[0] * C3[0])) * d;
            C2[1] = C2[0] + (((1.0 / (V / Vr)) * (C2_vh - C2[0])) - (2 * k1 * C1[0] * C2[0] * C3[0]) - (4 * k4 * C2[0] * C3[0])) * d;
            C3[1] = C3[0] + (((1.0 / (V / Vr)) * (C3_vh - C3[0])) - (3 * k1 * C1[0] * C2[0] * C3[0]) - (k3 * C1[0] * C3[0]) - (3 * k4 * C2[0] * C3[0])) * d;
            C5[1] = C5[0] + (((1.0 / (V / Vr)) * (C5_vh - C4[0])) + (6 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C5[0]) + (6 * k4 * C2[0] * C3[0])) * d;

            C4[1] = C4[0] + (((1 / (V / Vr)) * (C4_vh - C4[0])) + (2 * k1 * C1[0] * C2[0] * C3[0])) * d;

            T_vyh[1] = T_vyh[0] + ((1 / (V / Vr)) * (T_vh - T_vyh[0]) + (k1 * C1[0] * C2[0] * C3[0] * Q1 / (Ct * ro)) + (k4 * C2[0] * C3[0] / (Ct * ro)) - (k2 * C1[0] * C5[0] / (Ct * ro)) - ((K_t / (Ct * ro * V)) * (T_vyh[0] - T_t) * F)) * d;


            for (int i = 2; i < C5.Length; i++)
            {
                k1 = A1 * Math.Exp(-E1 / (R * T_vyh[i - 1]));
                k2 = A2 * Math.Exp(-E2 / (R * T_vyh[i - 1]));
                k3 = A3 * Math.Exp(-E3 / (R * T_vyh[i - 1]));
                k4 = A4 * Math.Exp(-E4 / (R * T_vyh[i - 1]));

                d = d + 0.01;
                if (Vr <= 0.2)
                    Vr = Vr + 0.01; // 0.01<=Vr <=0.2
                else break;
                if (F <= 20)
                    F = F + 0.1;//5 <= F <= 20
                else break;

                if(Math.Abs(T_vyh[i] - T_vyh [i-1]) > eps)
                {

                T_vyh[i] = T_vyh[i-1] + ((1 / (V / Vr)) * (T_vh - T_vyh[i-1]) + (k1 * C1[i-1] * C2[i-1] * C3[i-1] * Q1 / (Ct * ro)) + (k4 * C2[i-1] * C3[i-1] / (Ct * ro)) - (k2 * C1[i-1] * C5[i-1] / (Ct * ro)) - ((K_t / (Ct * ro *V)) * (T_vyh[i-1] - T_t) * F)) * d;
                
                }

                if(Math.Abs(C1[i] - C1[i-1]) > eps)
                {
                C1[i] = C1[i-1] + (((1.0 / (V / Vr)) * (C1_vh - C1[i-1])) - (2 * k1 * C1[i-1] *C2 [i-1]* C3[i-1]) - (k2 * C1[i-1]*C3[i-1]) - (2*k3*C1[i-1]*C3[i-1])) * d;
                } 

                if(Math.Abs(C2[i] - C2[i-1]) > eps)
                {
                C2[i] = C2[i - 1] + (((1.0 / (V / Vr)) * (C2_vh - C1[i - 1])) - (2 * k1 * C1[i - 1] * C2[i - 1] * C3[i - 1]) - (4 * k4 * C2[i-1] * C3[i-1])) * d;
                }

                if(Math.Abs(C3[i] - C3[i-1]) > eps)
                {
                C3[i] = C3[i - 1] + (((1.0 / (V / Vr)) * (C3_vh - C3[i - 1])) - (3 * k1 * C1[i - 1] * C2[i - 1] * C3[i - 1]) - (k3 * C1[i - 1] * C3[i - 1]) - (3 * k4 * C2[i - 1] * C3[i - 1])) * d;
                }
                if(Math.Abs(C5[i] - C5[i-1]) > eps)
                {
                    C5[i] = C5[i - 1] + (((1.0 / (V / Vr)) * (C5_vh - C5[i - 1])) - (6 * k1 * C1[i - 1] * C2[i - 1] * C3[i - 1]) - (k2 * C1[i - 1] * C5[i - 1]) + (6 * k4 * C2[i - 1] * C3[i - 1])) * d; 
                }
                if(Math.Abs(C4[i] - C4[i-1]) > eps)
                {
                    C4[i] = C4[i - 1] + (((1.0 / (V / Vr)) * (C4_vh - C4[i - 1])) + (2 * k1 * C1[i - 1] * C2[i - 1] * C3[i - 1])) * d;
                }


               chart1.Series[0].Points.AddXY(d, C4[i]);
               chart1.Series[0].ChartType = SeriesChartType.Spline;//.Point; 
                // chart1.Series[0].Points.AddXY(d, C4);

            }
         

            //C1 = ((1.0 / (V / Vr)) * (C1_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C3_vh) - (2 * k3 * C1_vh * C3_vh);
            //C2 = ((1.0 / (V / Vr)) * (C2_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (4 * k4 * C2_vh * C3_vh);
            //C3 = ((1.0 / (V / Vr)) * (C3_vh - 0)) - (3 * k1 * C1_vh * C2_vh * C3_vh) - (k3 * C1_vh * C3_vh) - (3 * k4 * C2_vh * C3_vh);
            //C5 = ((1.0 / (V / Vr)) * (C5_vh - 0)) + (6 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C5_vh) + (6 * k4 * C2_vh * C3_vh);

            //C4 = ((1 / (V / Vr)) * (0 - 0)) + (2 * k1 * C1 * C2 * C3);

           // C1 = C1_vh + (((1.0 / (V / Vr)) * (C1_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C3_vh) - (2 * k3 * C1_vh * C3_vh)) * d;
           // C2 = C2_vh + (((1.0 / (V / Vr)) * (C2_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (4 * k4 * C2_vh * C3_vh)) * d;
           // C3 = C3_vh + (((1.0 / (V / Vr)) * (C3_vh - 0)) - (3 * k1 * C1_vh * C2_vh * C3_vh) - (k3 * C1_vh * C3_vh) - (3 * k4 * C2_vh * C3_vh)) * d;
           // C5 = C5_vh + (((1.0 / (V / Vr)) * (C5_vh - 0)) + (6 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C5_vh) + (6 * k4 * C2_vh * C3_vh)) * d;

           // C4 = 0 + (((1 / (V / Vr)) * (0 - 0)) + (2 * k1 * C1 * C2 * C3)) * d;


         //   textBox1.Text = Convert.ToString(C1[1]);
          //  textBox2.Text = Convert.ToString(C2[1]);
           // textBox3.Text = Convert.ToString(C3[1]);
            //textBox4.Text = Convert.ToString(C5[1]);
          //  textBox5.Text = Convert.ToString(C4[16]);
            //textBox6.Text = Convert.ToString(T_vyh[1]);

           // chart1.Series[0].Points.AddY(C4);
           // chart1.Series[0].Points.AddXY(d, C4);

          //  T_vyh = T_vh + ((1 / (V / Vr)) * (T_vh - T_vyh) + (k1 * C1 * C2 * C3 * Q1 / (Ct * ro)) + (k4 * C2 * C3 / (Ct * ro)) - (k2 * C1 * C5 / (Ct * ro)) - ((K_t / (Ct * ro *V)) * (T_vyh - T_t) * F)) * d;

          //  chart1.Series[0].Points.AddXY(d, C4);

        }
    }
}
