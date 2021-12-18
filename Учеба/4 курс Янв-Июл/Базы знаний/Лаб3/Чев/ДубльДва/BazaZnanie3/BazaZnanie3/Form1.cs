﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BazaZnanie3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

	    private double[,] x =
	    {
		    // x0,x1,x2,x3
		    {1, 0, 0, 0},
		    {1, 0, 0, 1},
		    {1, 0, 1, 0},
		    {1, 0, 1, 1},
		    {1, 1, 0, 0},
		    {1, 1, 0, 1},
		    {1, 1, 1, 0},
		    {1, 1, 1, 1},
	    };

	    private double[] d = {1, 0, 1, 0, 0, 1, 0, 1};
	    private double[,] w_ij;
	    private double[] w;
	    private Random random = new Random();
	    private List<double> E_list = new List<double>();

        private void button1_Click(object sender, EventArgs e)
        {
			chart1.Series[0].Points.Clear();
			textBox6.Text = "";
			learn();
			show_W();
			for (int i = 0; i < E_list.Count; i++)
				chart1.Series[0].Points.AddXY(i, E_list[i]);

	        try
	        {
				double x1 = Double.Parse(textBox1.Text),
				   x2 = Double.Parse(textBox2.Text),
				   x3 = Double.Parse(textBox3.Text);
				textBox4.Text = calculate(x1, x2, x3)+"";
				E_list.Clear();
	        }
	        catch (Exception)
	        {
				MessageBox.Show(@"Неверные входные данные. Проверьте правильность ввода.", @"Ошибка", MessageBoxButtons.OK);
				textBox4.Text = @"Ошибка";
	        }
        }

	    private void show_W()
	    {
		    String s = "";
		    for (int i = 0; i < 4; i++)
		    {
			    for (int j = 0; j < 4; j++)
			    {
				    s += "w[" + i + "][" + j + "]=" + w_ij[i, j] + Environment.NewLine;
			    }
		    }
		    s += Environment.NewLine;
		    for (int i = 0; i < 4; i++)
		    {
			    s += "w_[" + i + "]=" + w[i] + Environment.NewLine;
		    }

		    textBox6.Text = s;
	    }

	    private void learn()
         {
            w_ij = new double[4,4];  // Номер нейрона; номер входного х
            w = new double[5]; //4 связи от 4 нейронов в скрытом слое + 1 связь доп х0=1 (нулевая по счету)
            for (int i = 0; i < 4; i++)
            {
                w[i] = random.NextDouble() / 10;
                for (int j = 0; j < 4; j++)
                {
                    w_ij[i, j] = random.NextDouble() / 10;
                }
            }

            double[] h = new double[4];
            double[] O = new double[4];
            double O_final;
            double E = 999999;
            while (E > 0.0005)
            {
                E = 0;
              //  int shag = 0;
                for (int p = 0; p < 8; p++)
                {
                    double er;
                    do
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            h[i] = x[p, 0] * w_ij[i, 0] + x[p, 1] * w_ij[i, 1] + x[p, 2] * w_ij[i, 2] + x[p, 3] * w_ij[i, 3];
                            O[i] = F(h[i]);

                        }
                        double h_final = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            h_final += O[i] * w[i + 1]; // берем w[i+1], тк.к w[0] - дополнительная, относится к х0 
                        }
                        h_final += x[p, 0] * w[0];
                        O_final = F(h_final);
                        //далее определяем локальную ошибку дельта и пересчитываем w
                        double delta2sloi = 2 * (d[p] - O_final) * F_proizv(h_final);
                        double[] delta1sloi = new double[4];
                        for (int i = 0; i < 4; i++)
                        {
                            delta1sloi[i] = F_proizv(h[i]) * (delta2sloi * w[i + 1]); // берем w[i+1], т.к w[0] - дополнительная, относится к х0
                        }
                        int c = 1;
                        for (int i = 0; i < 4; i++)
                        { //прибавляем dw
                            for (int j = 0; j < 4; j++)
                            {
                                double dw = c * delta1sloi[i] * x[p, j];
                                w_ij[i, j] = w_ij[i, j] + dw;
                            }
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            double dw = c * delta2sloi * O[i];
                            w[i + 1] = w[i + 1] + dw;
                        }

                        double dw1 = c * delta2sloi * x[p, 0];
                        w[0] = w[0] + dw1;

                        for (int i = 0; i < 4; i++) //посчитаем h для каждого нейрона в скрытом слое
                        {
                            h[i] = x[p, 0] * w_ij[i, 0] + x[p, 1] * w_ij[i, 1] + x[p, 2] * w_ij[i, 2] + x[p, 3] * w_ij[i, 3];
                            O[i] = F(h[i]);
                        }

                        h_final = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            h_final += O[i] * w[i + 1]; // берем w[i+1], т.к w[0] - дополнительная
                        }
                        h_final += x[p, 0] * w[0];
                        O_final = F(h_final);
                        er = Math.Pow((d[p] - O_final), 2);
                    } while (er > 0.0001);

                    E += er;

                }

               E_list.Add(E);
            }
            //удалось определить w, можем посчитать резульат
        for (int p = 0; p < 8; p++)
        {
            for (int i = 0; i < 4; i++) //посчитаем h для каждого нейрона в скрытом слое
            {
                h[i] = x[p,0] * w_ij[i,0] + x[p,1] * w_ij[i,1] + x[p,2] * w_ij[i,2] + x[p,3] * w_ij[i,3];
                O[i] = F(h[i]);
            }
            double h_final = 0;
            for (int i = 0; i < 4; i++) {
                h_final += O[i] * w[i+1]; 
            }
            h_final += x[p,0] * w[0];
            O_final = F(h_final);
        }

         }
        private double F(double h)
        {
            return 2 / (1 + Math.Exp(-h)) - 1;
        }

        private double F_proizv(double h)
        {
            return 2 * Math.Exp(-h) / Math.Pow(1 + Math.Exp(-h), 2);
        }

        private double calculate(double x1, double x2, double x3)
        {
            double[] h = new double[4];
            double[] O = new double[4];
            double O_final;
            for (int i = 0; i < 4; i++) //посчитаем h для каждого нейрона в скрытом слое
            {
                h[i] = (1) * w_ij[i,0] + x1 * w_ij[i,1] + x2 * w_ij[i,2] + x3 * w_ij[i,3];
                O[i] = F(h[i]);
            }
            double h_final = 0;
            for (int i = 0; i < 4; i++)
            {
                h_final += O[i] * w[i + 1]; // берем w[i+1],т.к w[0] - дополнительная, относится к х0
            }
            h_final += (1) * w[0];
            O_final = F(h_final);
            return O_final;
        }

    }

}
