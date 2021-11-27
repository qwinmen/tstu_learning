using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Шляпа
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OGlControl.InitializeContexts();
        }

        /// <summary>
        /// Инициализация GL
        /// </summary>
        private void InitGL()
        {
            // инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            //Gl.glEnable(Gl.GL_ALPHA_TEST);//чтобы разрешить обрабатывать четвертый компонент цвета
            //Gl.glEnable(Gl.GL_BLEND);//чтобы разрешить наложение цветов
            // очитка окна
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соотвествии с размерами элемента anT
            Gl.glViewport(0, 0, OGlControl.Width, OGlControl.Height);

            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();

            // теперь необходимо корректно настроить 2D ортогональную проекцию
            // в зависимости от того, какая сторона больше
            // мы немного варьируем то, как будет сконфигурированный настройки проекции
            if ((float)OGlControl.Width <= (float)OGlControl.Height)
                Glu.gluOrtho2D(0.0, 30.0 * (float)OGlControl.Height / (float)OGlControl.Width, 0.0, 30.0);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)OGlControl.Width / (float)OGlControl.Height, 0.0, 30.0);

            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // очистка матрицы 
            Gl.glLoadIdentity();

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGL();
            ResizeGL();
        }

        //private const double частотаДескрита = 0.035;//аля Z-плоскость
        //(int)((2*Math.PI)/частотаДескрита)+1 СТРОЧЕК И Screen.PrimaryScreen.Bounds.Width ТОЧЕК В КАЖДОЙ СТРОКЕ
        //private static PointF[,] arr = new PointF[(int)((2 * Math.PI) / частотаДескрита) + 1, Screen.PrimaryScreen.Bounds.Width];



        private static void Red(double[] верхнийГоризонт, double z, int xDist, double mashtab, double[] грань)
        {
            #region
            //PointF[,] верхнийГоризонт = new PointF[(int)((2 * Math.PI) / частотаДескрита) + 1,Screen.PrimaryScreen.Bounds.Width],
              //         нижнийГоризонт = new PointF[(int)((2 * Math.PI) / частотаДескрита) + 1,Screen.PrimaryScreen.Bounds.Width];
            //Этот массив содержит наименьшие значения y для каждого значения x

            //------------------------------------------------------------//
            //int key = 0;//ключ по строкам
            /*
            if(arr[1,0].Y==0)//при resize окна не пересчитывать
            for (double k = 0; k < 2 * Math.PI; k += частотаДескрита)//k отвечает за шаг по z-плоскости (частота дескретизаций)
            {
                for (int i = 0; i < верхнийГоризонт.Length; i++)//<верхнийГоризонт.Length
                {
                    arr[key, i] = new PointF(i * 0.27f, (float)F(i * 0.04f, k) * 60f);//1000f коэфициент типо масштаб
                }
                key++;
            }
            
            for (int строка = 0; строка < (int)((2*Math.PI)/частотаДескрита)+1; строка++)//0..158
            {
                for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i++)//0..1024
                {
                    for (int j = 0; j < строка; j++)//0..158
                    {
                        if (arr[строка, i].Y <= arr[j, i].Y)//
                        {
                            Gl.glColor3f(0, 0, 1);
                            Gl.glVertex2d(arr[строка, i].X, arr[строка, i].Y);
                        }
                        if(arr[строка, i].Y > arr[j, i].Y)
                        {
                            Gl.glColor3d(строка, 0, строка - 58);
                            Gl.glVertex2d(arr[строка, i].X, arr[строка, i].Y);
                        }
                    }
                }
                
            }
            /*Количество выводов точек:
             с выполнением if = 6  347 423
             * без выполне if = 12 700 672
             * тоесть алг работает
             */


            /*
                        for (double k = 0; k < 2*Math.PI; k+=0.04)//k отвечает за шаг по z-плоскости (частота дескретизаций)
                        {
                            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i++)//<верхнийГоризонт.Length
                            {
                                верхнийГоризонт[key,i] = new PointF(i * 0.4f, (float)F(i * 0.04f, k) * 60f);//1000f коэфициент типо масштаб
                                 нижнийГоризонт[key,i] = new PointF(i * 0.4f, (float)F(i * 0.04f, k) * 60f);//1000f коэфициент типо масштаб
                            } key++;
                        }
            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i++)
            {
                Gl.glColor3d(1, 0, 0);
                foreach (PointF pointF in верхнийГоризонт)
                {
                    //if (pointF.Y < верхнийГоризонт[0,i].Y)
                        Gl.glVertex2d(pointF.X, pointF.Y);
                }

                //Gl.glColor3f(0, 0, 1);
                //foreach (PointF pointF in нижнийГоризонт)
                {
                    //Gl.glVertex2d(pointF.X, pointF.Y);
                }
                //if (i > 7) break;
            }
            */
            #endregion
        
            #region

            double k = 0;
            for (; k < z; k += 0.1)
            {
                double index = 0;
                for (int j = 0; j < xDist; j++)//идем по [0]--Х-->1024
                {
                    double tmp = (F(j*0.04, k) * mashtab);
                    if (tmp < грань[j])
                    {
                     //   Gl.glEdgeFlag(Gl.GL_FALSE);
                    }
                    if (tmp > верхнийГоризонт[j])
                    {
                        верхнийГоризонт[j] = tmp;
                        Gl.glColor3d(1, 0, 0);
                        Gl.glVertex2d(index, верхнийГоризонт[j]);
                    }
                    index += 0.3;
                }
                
                //if(k>2.2)break;
            }

            
            
            #endregion
            
            #region
            /*
            double A, B, C, D;
            //GLint n=628;
            double[] Ymin=new double[628], Ymax=new double[628];
            A = 50 / 6.28; //Screen.PrimaryScreen.Bounds.Width/6.28;
            B = 0;//screenWidth/2.0;
            C = -38/6.28;//Screen.PrimaryScreen.Bounds.Height/6.28;
            D = 4 / 2.0; //Screen.PrimaryScreen.Bounds.Height / 2.0;

            for(int i = 0; i<628; i++)
            Ymax[i]=C*F(i*0.01, 0)+D;//x-z-a1

                Ymin=Ymax;
            int j=0;
            double a1=0.2;
            double x = 0;
            for (j = 0; j < 628; x += 0.01, j++)
            {
                for (double z = 0.1; z <= 6.28; z += 0.1) 
	            {
                    double tmp = (C*F(x, z)+D);
                    if (tmp <= Ymax[j] && tmp >= Ymin[j]) { continue; }
			            if(tmp>=Ymax[j])
			            {
				            Ymax[j]=tmp;
				            Gl.glColor3f(1, 0, 0);
                            Gl.glVertex2d(A * x + B, tmp);
			            }
			            else if(tmp<=Ymin[j])
			            {
				            Ymin[j]=tmp;
                            Gl.glColor3f(0, 0, 1);
                            Gl.glVertex2d(A * x + B, tmp);
			            }

	            }
                //if (j > 300) break;
            }*/
            #endregion

        }

        /*
         если на текущей Z-плоскости при некотором заданном значении X соответствующее значение Y
         * на кривой больше максимума или меньше минимума по Y для всех предыдущих кривых при этом значении X,
         * то текущая кривая видима. В противном случае она невидима. 
         */

        /// <summary>
        /// y = F(x,z) [0..2*pi]
        /// </summary>
        private static double F(double x, double z)
        {
            //100 * (z - x * x) * (z - x * x) + (1 - x) * (1 - x);
            return 0.2 * Math.Sin(x) * Math.Cos(z) -
                   1.5 * Math.Cos((7.0 * (Math.Pow(x - Math.PI, 2.0) + Math.Pow(z - Math.PI, 2.0))) / 6.0)*
                               Math.Exp(-(Math.Pow(x - Math.PI, 2.0) + Math.Pow(z - Math.PI, 2.0)));
        }

        static void Blue(double[] нижнийГоризонт, double z, int xDist, double mashtab, double[] грань)
        {
            double k = 0.04;
            int b = 0;
            for (; k < z; k += 0.1)
            {
                double index = 0;
                for (int j = 0; j < xDist; j++)
                {
                    double tmp = (F(j * 0.04, k) * mashtab);
                    if(tmp < грань[j])
                    {
                        //Gl.glEdgeFlag(Gl.GL_FALSE);
                        
                    }
                    if (tmp < нижнийГоризонт[j])
                    {
                        b = (int)z*5;
                        нижнийГоризонт[j] = tmp;
                        Gl.glColor3d(0, 0, b);
                        Gl.glVertex2d(index, нижнийГоризонт[j]);
                    }

                    index += 0.3;

                }

                //if(k>3.2)break;
            }
        }

        /// <summary>
        /// Перерисовка компонента GL
        /// </summary>
        private void ResizeGL()
        {
            //очистка экрана перед визуализацией кадра (Цвет И Глубина)
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glViewport(0, 0, OGlControl.Width, OGlControl.Height);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);//устанавл цвет отрисовки геометрии
            //Gl.glRotatef (10.0f, 30.0f, 0.0f, 0.0f); // поворот-ось X 
            //Gl.glRotatef(10.0f, 0.0f, 30.0f, 0.0f); // поворот-ось X 
            //Gl.glRotatef(2.85f, 0.0f, 1.0f, 0.0f); // поворот-ось X 
            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();
            // устанавливаем размер точек, равный 5 пикселям 
            Gl.glPointSize(1);

            // выполняем перемещение в прострастве по осям X и Y
            Gl.glTranslated(0, 8, 0);
            var Style = Gl.GL_LINES;
            //----------------------------------------------------------------------
            int xDist = 148;//Screen.PrimaryScreen.Bounds.Width;
            double mashtab = 30;// частоты
            double k;
            double z = (2 * Math.PI);// частотаДескрита;// 6.2831/k
            double[] верхнийГоризонт = new double[xDist],
                      нижнийГоризонт = new double[xDist], грань = new double[xDist];
            //for (k = 0; k != 0.04; k += 0.04)
                for (int j = 0; j < xDist; j++)
                    верхнийГоризонт[j] = (F(j * 0.04, 0) * mashtab);//1000f коэфициент типо масштаб

            нижнийГоризонт = верхнийГоризонт;
                     грань = верхнийГоризонт;
            Gl.glColor3d(1, 0, 0);
            double index = 0;

            Gl.glBegin(Gl.GL_LINE_STRIP);
            foreach (double pointF in верхнийГоризонт)
            {
                Gl.glVertex2d(index, pointF);
                index += 0.3;
            }
            Gl.glEnd();
            //----------------------------------------------------------------------
            Gl.glBegin(Gl.GL_LINE_STRIP);//Gl.GL_LINES//Gl.GL_POINTS//Gl.GL_LINE_STRIP
            Red(верхнийГоризонт, z, xDist, mashtab, грань);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);//Gl.GL_LINES//Gl.GL_POINTS//Gl.GL_LINE_STRIP
            Blue(нижнийГоризонт, z, xDist, mashtab, грань);
            Gl.glEnd();

            // возвращаем матрицу из стека 
            Gl.glPopMatrix();
            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();
            // сигнал для обновление элемента реализующего визуализацию. 
            OGlControl.Invalidate();//обновить отображаемый кадр
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeGL();
        }



    }
}
