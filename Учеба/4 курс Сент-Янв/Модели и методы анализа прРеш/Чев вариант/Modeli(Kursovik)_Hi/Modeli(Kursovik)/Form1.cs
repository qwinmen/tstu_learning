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
using Sluch;

namespace Modeli_Kursovik_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private clГСЧ _гсч = new clГСЧ(); // var massivГСЧ = _гсч.ГСЧрезульт;
        double d = 0.01;

        private void button1_Click(object sender, EventArgs e)
        {
           // double C1_vh = 15.4375, C2_vh = 13.4118, C3_vh = 8.90625, C5_vh = 0;
            var C1 = new double[400];
            var C2 = new double[400];
            var C3 = new double[400];
            var C4 = new double[400];
            var C5 = new double[400];
            var T_vyh = new double[400];
            double E1 = 156000, E2 = 166400, E3 = 177000, E4 = 160000;
            double A1 = 10000, A2 = 20000, A3 = 50000, A4 = 500;
            double Q1 = 361000, Q2 = 950000, Q4 = 1520000;
            double T_t = 500, M = 19, V = 10, K_t = 2000, F = 5, V_vh = 0.01, R = 8.31, Ct = 1200, ro = 1.9;
            double k1, k2, k3, k4;
            double T_vh = 1200.0, C1_vh = 15.4375, C2_vh = 13.4118, C3_vh = 8.90625, C4_vh = 0.0, C5_vh = 0.0;
            double Vr = 0.01 , d = 0.1 , eps = 0.1;

            T_vyh[0] = 1200.0;   
            C1[0] = 15.4375;
            C2[0] = 13.4118;
            C3[0] = 8.90625;
            C4[0] = 0;
            C5[0] = 0;

            k1 = A1 * Math.Exp(-E1 / (R * T_vyh[0]));
            k2 = A2 * Math.Exp(-E2 / (R * T_vyh[0]));
            k3 = A3 * Math.Exp(-E3 / (R * T_vyh[0]));
            k4 = A4 * Math.Exp(-E4 / (R * T_vyh[0]));

            C5[1] = C5[0] + (((1.0 / (V / Vr)) * (C5_vh - C5[0])) - (6 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C5[0]) + (6 * k4 * C2[0] * C3[0])) * d;
            C4[1] = C4[0] + (((1.0 / (V / Vr)) * (C4_vh - C4[0])) + (2 * k1 * C1[0] * C2[0] * C3[0])) * d;

           //k1 = A1 * Math.Exp(-E1 / (R * T_vh));
          // k2 = A2 * Math.Exp(-E2 / (R * T_vh));
         //  k3 = A3 * Math.Exp(-E3 / (R * T_vh));
          // k4 = A4 * Math.Exp(-E4 / (R * T_vh));

           // C1[1] = C1[0] + (((1.0 / (V / Vr)) * (C1_vh - C1[0])) - (2 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C3[0]) - (2 * k3 * C1[0] * C3[0])) * d;
           // C2[1] = C2[0] + (((1.0 / (V / Vr)) * (C2_vh - C2[0])) - (2 * k1 * C1[0] * C2[0] * C3[0]) - (4 * k4 * C2[0] * C3[0])) * d;
           // C3[1] = C3[0] + (((1.0 / (V / Vr)) * (C3_vh - C3[0])) - (3 * k1 * C1[0] * C2[0] * C3[0]) - (k3 * C1[0] * C3[0]) - (3 * k4 * C2[0] * C3[0])) * d;
           // C5[1] = C5[0] + (((1.0 / (V / Vr)) * (C5_vh - C4[0])) + (6 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C5[0]) + (6 * k4 * C2[0] * C3[0])) * d;

           // C4[1] = C4[0] + (((1 / (V / Vr)) * (C4_vh - C4[0])) + (2 * k1 * C1[0] * C2[0] * C3[0])) * d;

          //  T_vyh[1] = T_vyh[0] + ((1 / (V / Vr)) * (T_vh - T_vyh[0]) + (k1 * C1[0] * C2[0] * C3[0] * Q1 / (Ct * ro)) + (k4 * C2[0] * C3[0] / (Ct * ro)) - (k2 * C1[0] * C5[0] / (Ct * ro)) - ((K_t / (Ct * ro * V)) * (T_vyh[0] - T_t) * F)) * d;


            for (int i = 1; i < C5.Length; i++)
            {


                k1 = A1 * Math.Exp(-E1 / (R * T_vyh[i - 1]));
                k2 = A2 * Math.Exp(-E2 / (R * T_vyh[i - 1]));
                k3 = A3 * Math.Exp(-E3 / (R * T_vyh[i - 1]));
                k4 = A4 * Math.Exp(-E4 / (R * T_vyh[i - 1]));

                d = d + 1;
                //Vr = Vr + 0.01;
               // F = F + 0.1;
             if (Vr <= 0.2)
                    Vr = Vr + 0.01; // 0.01 <= Vr <=0.2
                else break;

                if (F <= 20)
                    F = F + 0.1; //5 <= F <= 20
                else break;

                if(Math.Abs(T_vyh[i] - T_vyh [i-1]) > eps)
                {

                T_vyh[i] = T_vyh[i-1] + ((1 / (V / Vr)) * (T_vh - T_vyh[i-1]) + (k1 * C1[i-1] * C2[i-1] * C3[i-1] * Q1 / (Ct * ro)) + (k4 * C2[i-1] * C3[i-1] * Q4 / (Ct * ro)) - (k2 * C1[i-1] * C5[i-1] * Q2 / (Ct * ro)) - ((K_t / (Ct * ro *V)) * (T_vyh[i-1] - T_t) * F)) * d;
                
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
                    C5[i+1] = C5[i] + (((1.0 / (V / Vr)) * (C5_vh - C5[i])) - (6 * k1 * C1[i - 1] * C2[i - 1] * C3[i - 1]) - (k2 * C1[i - 1] * C5[i - 1]) + (6 * k4 * C2[i - 1] * C3[i - 1])) * d; 
                }
                if(Math.Abs(C4[i] - C4[i-1]) > eps)
                {
                    C4[i+1] = C4[i] + (((1.0 / (V / Vr)) * (C4_vh - C4[i])) + (2 * k1 * C1[i - 1] * C2[i - 1] * C3[i - 1])) * d;
                }


               chart1.Series[0].Points.AddXY(d, C4[i]);
               chart1.Series[0].ChartType = SeriesChartType.Spline;
               // chart1.Series[0].Points.AddXY(d, C4);


            }

          
         

            //C1 = ((1.0 / (V / Vr)) * (C1_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C3_vh) - (2 * k3 * C1_vh * C3_vh);
            //C2 = ((1.0 / (V / Vr)) * (C2_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (4 * k4 * C2_vh * C3_vh);
            //C3 = ((1.0 / (V / Vr)) * (C3_vh - 0)) - (3 * k1 * C1_vh * C2_vh * C3_vh) - (k3 * C1_vh * C3_vh) - (3 * k4 * C2_vh * C3_vh);
            //C5 = ((1.0 / (V / Vr)) * (C5_vh - 0)) + (6 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C5_vh) + (6 * k4 * C2_vh * C3_vh);

            //C4 = ((1 / (V / Vr)) * (0 - 0)) + (2 * k1 * C1 * C2 * C3);
           // T_vyh = T_vh + ((1 / (V / Vr)) * (T_vh - T_vyh) + (k1 * C1 * C2 * C3 * Q1 / (Ct * ro)) + (k4 * C2 * C3 / (Ct * ro)) - (k2 * C1 * C5 / (Ct * ro)) - ((K_t / (Ct * ro * V)) * (T_vyh - T_t) * F)) * d;
            
          /*  k1 = A1 * Math.Exp(-E1 / (R * T_vh));
            k2 = A2 * Math.Exp(-E2 / (R * T_vh));
            k3 = A3 * Math.Exp(-E3 / (R * T_vh));
            k4 = A4 * Math.Exp(-E4 / (R * T_vh));

            C1 = C1 + (((1.0 / (V / Vr)) * (C1_vh - 0)) - (2 * k1 * C1 * C2 * C3) - (k2 * C1_vh * C3_vh) - (2 * k3 * C1_vh * C3_vh)) * d;
            C2 = C2 + (((1.0 / (V / Vr)) * (C2_vh - 0)) - (2 * k1 * C1 * C2 * C3_vh) - (4 * k4 * C2_vh * C3_vh)) * d;
            C3 = C3 + (((1.0 / (V / Vr)) * (C3_vh - 0)) - (3 * k1 * C1 * C2 * C3_vh) - (k3 * C1_vh * C3_vh) - (3 * k4 * C2_vh * C3_vh)) * d;
            C5 = C5 + (((1.0 / (V / Vr)) * (C5_vh - 0)) + (6 * k1 * C1 * C2 * C3_vh) - (k2 * C1_vh * C5_vh) + (6 * k4 * C2_vh * C3_vh)) * d;

            C4 = C4 + (((1 / (V / Vr)) * (0 - C4)) + (2 * k1 * C1 * C2 * C3)) * d;*/


         //   textBox1.Text = Convert.ToString(C1[1]);
          //  textBox2.Text = Convert.ToString(C2[1]);
           // textBox3.Text = Convert.ToString(C3[1]);
            //textBox4.Text = Convert.ToString(C5[1]);
           // textBox1.Text = Convert.ToString(Vr);
           // textBox2.Text = Convert.ToString(F);
          //  textBox5.Text = Convert.ToString(C4[21]);
            //textBox6.Text = Convert.ToString(T_vyh[1]);

           // chart1.Series[0].Points.AddY(C4);
           // chart1.Series[0].Points.AddXY(d, C4);

          //  T_vyh = T_vh + ((1 / (V / Vr)) * (T_vh - T_vyh) + (k1 * C1 * C2 * C3 * Q1 / (Ct * ro)) + (k4 * C2 * C3 / (Ct * ro)) - (k2 * C1 * C5 / (Ct * ro)) - ((K_t / (Ct * ro *V)) * (T_vyh - T_t) * F)) * d;

          //  chart1.Series[0].Points.AddXY(d, C4);

        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            var massivГСЧ = _гсч.ГСЧрезульт;
            double i = 0;
            foreach (var temp in massivГСЧ)
            {
                chart2.Series[0].Points.AddXY(i, temp);
                i++;
                chart2.Series[0].ChartType = SeriesChartType.Spline;
            }


        }*/

        private double generator(ref double x)
        {
            const double m = 1000000.0;
            double a = 8; double inc = 65.0;
            x = ((a * x) + inc) % m;
            return x / m;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // double C1_vh = 15.4375, C2_vh = 13.4118, C3_vh = 8.90625, C5_vh = 0;

            double x0 = 500;
            double[] x = new double[500];

            for (int i = 0; i < 500; i++)
                x[i] = generator(ref x0) - 0.5;

            double M, sum = 0.0;
            for (int i = 0; i < 500; i++)
                sum += x[i];

            M = 1.0 / 500.0 * sum;

            double w = 0;
            double sun = 0;
            //int sun;
            for (int i = 0; i < 500; i++)
                w = Math.Pow((x[i] - M), 2);

            sun += w;

            double[] z = new double[490];
            double k = 1, v = 0;
            double alf0 = 0.1, M0 = 15.0, A1 = 1, A2 = 1, N = 10;
            double constanta = 12;//Math.Pow((gam0 / gamx / alf0), (double)1 / (double)2);

            for (int i = 0; i < 490; i++)
            {
                for (int j = i; j < i + 10; j++)
                {//K = 0.4exp(-0.071dt)
                    v += x[j] * constanta * Math.Exp(-alf0 * (j - i));
                }
                z[i] = (1.0 / N * v + M0);
                v = 0;
            }

            for (int i = 0; i < 490; i++) {
                chart2.Series[0].Points.AddXY(i, z[i]);
                chart2.Series[0].ChartType = SeriesChartType.Spline;

            }



            var C1 = new double[200];
            var C2 = new double[200];
            var C3 = new double[200];
            var C4 = new double[200];
            var C5 = new double[200];
            var T_vyh = new double[200];

           // var massivГСЧ = _гсч.ГСЧрезульт;

            double E1 = 156000, E2 = 166400, E3 = 177000, E4 = 160000;
            double a1 = 10000, a2 = 20000, A3 = 50000, A4 = 500;
            double Q1 = 361000, Q2 = 950000, Q4 = 1520000;
            double T_t = 500, Mv = 19, V = 10, K_t = 2000, F = 5, V_vh = 0.01, R = 8.31, Ct = 1200, ro = 1.9;
            double k1, k2, k3, k4;
            double T_vh = 1200.0, C1_vh = z[0], C2_vh = 13.4118, C3_vh = 8.90625, C4_vh = 0.0, C5_vh = 0.0;
            double Vr = 0.01, d = 0.0001, eps = 0.001;

           

            T_vyh[0] = 1200.0;
            C1[0] = z[0];
            C2[0] = 13.4118;
            C3[0] = 8.90625;
            C4[0] = 0;
            C5[0] = 0;

            k1 = a1 * Math.Exp(-E1 / (R * T_vyh[0]));
            k2 = a2 * Math.Exp(-E2 / (R * T_vyh[0]));
            k3 = A3 * Math.Exp(-E3 / (R * T_vyh[0]));
            k4 = A4 * Math.Exp(-E4 / (R * T_vyh[0]));

            C5[1] = C5[0] + (((1.0 / (V / Vr)) * (C5_vh - C5[0])) - (6 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C5[0]) + (6 * k4 * C2[0] * C3[0])) * d;
            C4[1] = C4[0] + (((1.0 / (V / Vr)) * (C4_vh - C4[0])) + (2 * k1 * C1[0] * C2[0] * C3[0])) * d;

            //k1 = A1 * Math.Exp(-E1 / (R * T_vh));
            // k2 = A2 * Math.Exp(-E2 / (R * T_vh));
            //  k3 = A3 * Math.Exp(-E3 / (R * T_vh));
            // k4 = A4 * Math.Exp(-E4 / (R * T_vh));

            // C1[1] = C1[0] + (((1.0 / (V / Vr)) * (C1_vh - C1[0])) - (2 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C3[0]) - (2 * k3 * C1[0] * C3[0])) * d;
            // C2[1] = C2[0] + (((1.0 / (V / Vr)) * (C2_vh - C2[0])) - (2 * k1 * C1[0] * C2[0] * C3[0]) - (4 * k4 * C2[0] * C3[0])) * d;
            // C3[1] = C3[0] + (((1.0 / (V / Vr)) * (C3_vh - C3[0])) - (3 * k1 * C1[0] * C2[0] * C3[0]) - (k3 * C1[0] * C3[0]) - (3 * k4 * C2[0] * C3[0])) * d;
            // C5[1] = C5[0] + (((1.0 / (V / Vr)) * (C5_vh - C4[0])) + (6 * k1 * C1[0] * C2[0] * C3[0]) - (k2 * C1[0] * C5[0]) + (6 * k4 * C2[0] * C3[0])) * d;

            // C4[1] = C4[0] + (((1 / (V / Vr)) * (C4_vh - C4[0])) + (2 * k1 * C1[0] * C2[0] * C3[0])) * d;

            //  T_vyh[1] = T_vyh[0] + ((1 / (V / Vr)) * (T_vh - T_vyh[0]) + (k1 * C1[0] * C2[0] * C3[0] * Q1 / (Ct * ro)) + (k4 * C2[0] * C3[0] / (Ct * ro)) - (k2 * C1[0] * C5[0] / (Ct * ro)) - ((K_t / (Ct * ro * V)) * (T_vyh[0] - T_t) * F)) * d;


            for (int i = 1; i < C5.Length; i++)
            {
                k1 = A1 * Math.Exp(-E1 / (R * T_vyh[i - 1]));
                k2 = A2 * Math.Exp(-E2 / (R * T_vyh[i - 1]));
                k3 = A3 * Math.Exp(-E3 / (R * T_vyh[i - 1]));
                k4 = A4 * Math.Exp(-E4 / (R * T_vyh[i - 1]));

                d = d + 0.0001;
               // Vr = Vr + 0.01;
              //  F = F + 0.1;
                 if (Vr <= 0.2)
                        Vr = Vr + 0.01; // 0.01 <= Vr <=0.2
                    else break;

                 if (F <= 20)
                     F = F + 0.1; //5 <= F <= 20
                 else break;

                if (Math.Abs(T_vyh[i] - T_vyh[i - 1]) > eps)
                {

                    T_vyh[i] = T_vyh[i - 1] + ((1 / (V / Vr)) * (T_vh - T_vyh[i - 1]) + (k1 * z[i] * C2[i - 1] * C3[i - 1] * Q1 / (Ct * ro)) + (k4 * C2[i - 1] * C3[i - 1] * Q4 / (Ct * ro)) - (k2 * z[i] * C5[i - 1] * Q2 / (Ct * ro)) - ((K_t / (Ct * Mv)) * (T_vyh[i - 1] - T_t) * F)) * d;

                }

                if (Math.Abs(C1[i] - C1[i - 1]) > eps)
                {
                    C1[i] = z[i] + (((1.0 / (V / Vr)) * (C1_vh - z[i])) - (2 * k1 * z[i] * C2[i - 1] * C3[i - 1]) - (k2 * z[i] * C3[i - 1]) - (2 * k3 * z[i] * C3[i - 1])) * d;
                }

                if (Math.Abs(C2[i] - C2[i - 1]) > eps)
                {
                    C2[i] = C2[i - 1] + (((1.0 / (V / Vr)) * (C2_vh - C2[i - 1])) - (2 * k1 * z[i] * C2[i - 1] * C3[i - 1]) - (4 * k4 * C2[i - 1] * C3[i - 1])) * d;
                }

                if (Math.Abs(C3[i] - C3[i - 1]) > eps)
                {
                    C3[i] = C3[i - 1] + (((1.0 / (V / Vr)) * (C3_vh - C3[i - 1])) - (3 * k1 * z[i] * C2[i - 1] * C3[i - 1]) - (k3 * z[i] * C3[i - 1]) - (3 * k4 * C2[i - 1] * C3[i - 1])) * d;
                }



                if (Math.Abs(C5[i] - C5[i - 1]) > eps)
                {
                    C5[i + 1] = C5[i] + (((1.0 / (V / Vr)) * (C5_vh - C5[i])) - (6 * k1 * z[i] * C2[i - 1] * C3[i - 1]) - (k2 * z[i] * C5[i - 1]) + (6 * k4 * C2[i - 1] * C3[i - 1])) * d;
                }
                if (Math.Abs(C4[i] - C4[i - 1]) > eps)
                {
                    C4[i + 1] = C4[i] + (((1.0 / (V / Vr)) * (C4_vh - C4[i])) + (2 * k1 * z[i] * C2[i - 1] * C3[i - 1])) * d;
                }


                //chart3.Series[0].Points.AddXY(d, C4[i-1]);
               // chart3.Series[0].ChartType = SeriesChartType.Spline;
                // chart1.Series[0].Points.AddXY(d, C4);


            }


            //C1 = ((1.0 / (V / Vr)) * (C1_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C3_vh) - (2 * k3 * C1_vh * C3_vh);
            //C2 = ((1.0 / (V / Vr)) * (C2_vh - 0)) - (2 * k1 * C1_vh * C2_vh * C3_vh) - (4 * k4 * C2_vh * C3_vh);
            //C3 = ((1.0 / (V / Vr)) * (C3_vh - 0)) - (3 * k1 * C1_vh * C2_vh * C3_vh) - (k3 * C1_vh * C3_vh) - (3 * k4 * C2_vh * C3_vh);
            //C5 = ((1.0 / (V / Vr)) * (C5_vh - 0)) + (6 * k1 * C1_vh * C2_vh * C3_vh) - (k2 * C1_vh * C5_vh) + (6 * k4 * C2_vh * C3_vh);

            //C4 = ((1 / (V / Vr)) * (0 - 0)) + (2 * k1 * C1 * C2 * C3);
            // T_vyh = T_vh + ((1 / (V / Vr)) * (T_vh - T_vyh) + (k1 * C1 * C2 * C3 * Q1 / (Ct * ro)) + (k4 * C2 * C3 / (Ct * ro)) - (k2 * C1 * C5 / (Ct * ro)) - ((K_t / (Ct * ro * V)) * (T_vyh - T_t) * F)) * d;

            /*  k1 = A1 * Math.Exp(-E1 / (R * T_vh));
              k2 = A2 * Math.Exp(-E2 / (R * T_vh));
              k3 = A3 * Math.Exp(-E3 / (R * T_vh));
              k4 = A4 * Math.Exp(-E4 / (R * T_vh));

              C1 = C1 + (((1.0 / (V / Vr)) * (C1_vh - 0)) - (2 * k1 * C1 * C2 * C3) - (k2 * C1_vh * C3_vh) - (2 * k3 * C1_vh * C3_vh)) * d;
              C2 = C2 + (((1.0 / (V / Vr)) * (C2_vh - 0)) - (2 * k1 * C1 * C2 * C3_vh) - (4 * k4 * C2_vh * C3_vh)) * d;
              C3 = C3 + (((1.0 / (V / Vr)) * (C3_vh - 0)) - (3 * k1 * C1 * C2 * C3_vh) - (k3 * C1_vh * C3_vh) - (3 * k4 * C2_vh * C3_vh)) * d;
              C5 = C5 + (((1.0 / (V / Vr)) * (C5_vh - 0)) + (6 * k1 * C1 * C2 * C3_vh) - (k2 * C1_vh * C5_vh) + (6 * k4 * C2_vh * C3_vh)) * d;

              C4 = C4 + (((1 / (V / Vr)) * (0 - C4)) + (2 * k1 * C1 * C2 * C3)) * d;*/


            //   textBox1.Text = Convert.ToString(C1[1]);
            //  textBox2.Text = Convert.ToString(C2[1]);
            // textBox3.Text = Convert.ToString(C3[1]);
            //textBox4.Text = Convert.ToString(C5[1]);
            //textBox1.Text = Convert.ToString(Vr);
           // textBox2.Text = Convert.ToString(F);
         //   textBox5.Text = Convert.ToString(C4[21]);
            //textBox6.Text = Convert.ToString(T_vyh[1]);

            // chart1.Series[0].Points.AddY(C4);
            // chart1.Series[0].Points.AddXY(d, C4);

            //  T_vyh = T_vh + ((1 / (V / Vr)) * (T_vh - T_vyh) + (k1 * C1 * C2 * C3 * Q1 / (Ct * ro)) + (k4 * C2 * C3 / (Ct * ro)) - (k2 * C1 * C5 / (Ct * ro)) - ((K_t / (Ct * ro *V)) * (T_vyh - T_t) * F)) * d;

            //  chart1.Series[0].Points.AddXY(d, C4);


        }

        
    }
}
