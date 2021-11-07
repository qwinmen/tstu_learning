using System;

namespace _1PolynomNutona_Lagranj
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 1.5;//точка для которой строим полином
            int[] Xi={1,2,3,4,5};
            Console.WriteLine("По методу Лагранжа: "+L(x,Xi));
            Console.WriteLine("По методу Ньютона 1: " + N(x, Xi));
            //=========================================//
            Console.Write("По методу Ньютона 2: ");N2(x);
            //=========================================//
            Console.WriteLine("По методу Рунге-Кутты:");Reshenie();
            //=========================================//
            double[] h={0.1, 0.05, 0.01, 0.005};
            double a=0.8, b=1.5;
            Console.Write("Выберите шаг:\n[0] 0.1,\n[1] 0.05,\n[2] 0.01,\n[3] 0.005.\n");
            int i = Convert.ToInt32(Console.ReadLine());
            /*из формулы для нахождения шага разбиения h=(b-a)/n
             *выводим формулу для нахождения количества отрезков разбиения n=(b-a)/h */
            double n = (b - a) / h[i]; Console.WriteLine("Количество шагов: {0}", n);
            Console.WriteLine("По формуле Симпсона: "); Simpson(a, b, n, h[i]);
            Console.WriteLine("По формуле СимпсонаV2: "); SimpsonV2(a, b, n, h[i]);
        }
        #region 1Нютон и Лагранж
        internal static int F(int x)
        {//in X out Y
            switch (x)
            {
                case 1:
                    return 6;
                case 2:
                    return 5;
                case 3:
                    return 9;
                case 4:
                    return 2;
                case 5:
                    return 8;
            }
            return 0;
        }
        static double L(double x, int[] Xi)
        {
            int i, j;
            double m, res = 0;
            for (i = 0; i <= 4; i++)
            {
                m = 1.0;
                for (j = 0; j <= 4; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    else
                    {
                        m = m*((x - Xi[j])/(Xi[i] - Xi[j]));
                    }
                }
                res = res + m*F(Xi[i]);
            }
            return res;
        }
        static double Delta(int n, int k, int[] Xi) //n-порядок, k-коэффициент
        {
            if (n == 1)
                return (F(Xi[k + 1]) - F(Xi[k]));
            else
                return (Delta(n - 1, k + 1, Xi) - Delta(n - 1, k, Xi));
        }
        static double Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
        static double N(double x, int[] Xi)
        {
            double P = 0, h = 1.0, q, c = 1.0;
            int i;
            q = (x - Xi[0])/h;
            P = F(Xi[0]);
            for (i = 1; i <= 4; i++)
            {
                c *= (q - (i - 1));
                P = P + (c*(1/Factorial(i))*Delta(i, 0, Xi));
            }
            return P;
        }
        #endregion

        #region 2Ньютон
        static void N2(double _x)
        {
            double[] X = { 1, 2, 3, 4, 5 };//{300, 400, 500, 600};
            double[] Y = { 6, 5, 9, 2, 8 };//{52.88, 65.61, 78.07, 99.24};
            int n = 4;
            double testX = 0;
            //Console.Write("Вводим проверяемый Х\n");
            //string tX = Console.ReadLine();
            testX = _x;//Convert.ToDouble(tX);
            if (testX > X[3] || testX < X[0])
            {
                Console.Write("Недопустимое значение\n");
                //return 0;
            }
            double[][] razn = new double[n + n + 1][]; /*создание динамического массива для
                                                      * таблицы конечных разностей
                                                       [n+n+1]столько у нас строк в таблице*/
            int k = 0;
            for (int i = 0; i <= n; ++i)
            {
                razn[i] = new double[n + 1 + k];
                --k;// выделяем память для каждой строки определенное кол столбцов [n+n+1+k]
                //к- уменьшает число столбцов в строчке на 1, т.к.
                //таблица разностей имеет диагональный вид
            }
            for (int i = 0; i <= n; ++i)// заполняем нулевой столбец массива значениями функции в узлах
            {
                razn[i][0] = Y[i];
                //Console.Write(razn[i][0] + " ");
            }
            //Console.WriteLine("\n--------------------------");
            int r = n;
            for (int j = 1; j <= n + n; ++j)
            {
                for (int i = 0; i < r; ++i)
                {
                    int s = -i;
                    razn[i][j] = razn[-(s - 1)][j - 1] - razn[i][j - 1];//получаем таблицу разностей
                    //Console.Write("r[ " + i + "][ " + j + "]" + razn[i][j] + " ");
                }
                //Console.Write("\n---------------------------\n");
                r--;//это чтобы уменьшать число столбцов, в строке, приводить к диагональному виду таблицу разности
                if (r == 0) break;
            }
            double sum, sum1, sum3, sum2;
            double st = X[1] - X[0];
            
            
                double[] q = new double[10];
                //float* q = new float;   
                double tmp = 1;
                sum = Y[n];
                int p = 1, u = n;
                for (int i = 0; i <= n; i++)
                {
                    q[i] = (testX - X[u]);
                    tmp *= q[i];
                    sum1 = razn[u - 1][i + 1] * tmp;
                    sum2 = Math.Pow(st, p) * factorial(p);//A в степени Б
                    sum3 = sum1 / sum2;
                    sum = sum + sum3;
                    //Console.Write("sum= " + sum + "\n");
                    p++; u--;
                    if (u - 1 < 0) break;//чтобы не выйти за границы таблицы конечн.разностей
                }
                Console.Write( sum + "\n");
        }
        static int factorial(int f)
        {
            int product = 1;
            while (f > 0) { product = f * product; f--; }
            return product;
        }
        #endregion

        #region Рунге-Куты
        static double q(double x, double y)
        {//y'=x+sin(y/п)//15 вар
            return x + Math.Sin(y / Math.PI);//x + cos(y / sqrt(10));
        }
        static void Reshenie()
        {
            double x, y = 5.3, h = 0.1, a = 1.7, b = 2.7, k1, k2, k3, k4;
            x = a;
            Console.Write("{0}\t{1}\n",x,y);
            for (int i = 1; i < (b - a) / h; i++)
            {
                k1 = h * q(x, y);
                k2 = h * q(x + h / 2, y + k1 / 2);
                k3 = h * q(x + h / 2, y + k2 / 2);
                k4 = h * q(x + h, y + k3);
                x = x + h;
                y = y + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                Console.Write("{0:#.##}\t{1:#.##}\n",x,y);
            }
        }

        #endregion

        #region ИнтегралСимпсона
        static void Simpson(double a, double b, double n, double h)
        {//a =0.4//b =1.2//n=(1.2-0.4)/0.1 =8//h =0.1
            double s1 = 0, s2 = 0;
            int i;
            for (i = 1; i <= n; i++)
            {
                if ((i % 2 == 0) && (i != n))
                    s2 += FIntegral(a + i * h);//2-4-6-8//узлы
                else
                    s1 += FIntegral(a + i * h);//1-3-5-7//узлы
            }
            // [(b-a)/3n]*[f(a) + 2*(s2) + 4*(s1) + f(b)]
            //для произвольного четного числа узлов n=2m получим составную формулу:
            Console.WriteLine(((b - a) / (3 * n)) * (FIntegral(a) + 2.0 * s2 + 4.0 * s1 + FIntegral(a + n * h)));
        }
        static double FIntegral(double x)
        {//f(x)
            return (Math.Log(x * x + 1) / x);//(Math.Cos(Math.Pow(x, 2))) / (x + 1);//Math.Tan(x * x) / (x * x + 1);//
        }
        static void SimpsonV2(double a, double b, double n, double h)
        {//a =0.4//b =1.2//n=(1.2-0.4)/0.1 =8//h =0.1
            double x, y;
            x = a;//0.4
            y = FIntegral(x);
            for (int i = 0; i < ((b - a) / h); i++)
            {
                x = x + h;
                y = y + h * (FIntegral(x - h) + 4 * FIntegral(x - h / 2) + FIntegral(x)) / 6;
            }
            //Квадратичная интерполяция позволяет получить формулу Симпсона (парабол):
            Console.WriteLine("x={0}\ty={1}", x, y);
        }
        #endregion
    
       /////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////


    }
}
