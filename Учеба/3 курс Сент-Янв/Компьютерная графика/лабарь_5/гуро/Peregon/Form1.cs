using System.Drawing;
using System.Windows.Forms;
//http://www.cyberforum.ru/cpp-beginners/thread238839.html
//Алгоритм закраски треугольника методом Гуро
namespace Peregon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = (Image)new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //0.0 - темный//1.0 - светлый
            AreaGuro(1.0, 1.0, 0.0, 500, 335, 400, 25, 30, 335);
        }

        
        /// <summary>
        /// закрашивание Гуро.
        /// Интенсивность считается только в вершинах, в остальных апроксимируется
        ///double	Ia,Ib,Ic - интенсивности отраженного света в вершинах A,B,C
        ///int		(xa...yc) - координаты вершин треугольника A,B,C
        /// </summary>
        private void AreaGuro(double Ia,double Ib,double Ic,double xa,double ya,double xb,double yb,double xc,double yc)
        {
            double I1, I2;

            double y, x;
            double x1, x2, t1, t2;

            
            if (ya == yb)
            {
                t1 = ya;
                ya = yc;
                yc = t1;
                t1 = xa;
                xa = xc;
                xc = t1;
                t1 = Ia;
                Ia = Ic;
                Ic = t1;
            }
            
            if (ya == yc)
            {
                t1 = ya;
                ya = yb;
                yb = t1;
                t1 = xa;
                xa = xb;
                xb = t1;
                t1 = Ia;
                Ia = Ib;
                Ib = t1;
                
            }

            if (yc > ya)
            {
                //закрашиваем линии от верхней к нижней
                for (y = ya; y <= yc; y++)
                {
                    //точки пересечения линии(y) с границами грани
                    x1 = ((y - ya)/(yb - ya))*(xb - xa) + xa;
                    x2 = ((y - ya)/(yc - ya))*(xc - xa) + xa;

                    //интенсивности в точках пересечения линии(y) с границами грани
                    t1 = (x1 - xb)/(xa - xb);
                    t2 = (x2 - xc)/(xa - xc);
                    I1 = t1*Ia + (1 - t1)*Ib;
                    I2 = t2*Ia + (1 - t2)*Ic;

                    if (x2 > x1)
                    {
                        //рисовать линию
                        for (x = x1; x < x2; x++)
                        {
                            Intensive(x, y, x1, x2, I1, I2);
                        }
                    }
                    else
                    {
                        //рисовать линию
                        for (x = x1; x > x2; x--)
                        {
                            Intensive(x, y, x1, x2, I1, I2);
                        }
                    }
                    
                }
            }
            else
            {
                //закрашиваем линии от нижней k верхней
                for (y = ya; y >= yc; y--)
                {
                    //точки пересечения линии(y) с границами грани
                    x1 = ((y - ya)/(yb - ya))*(xb - xa) + xa;
                    x2 = ((y - ya)/(yc - ya))*(xc - xa) + xa;

                    //интенсивности в точках пересечения линии(y) с границами грани
                    t1 = (x1 - xb)/(xa - xb);
                    t2 = (x2 - xc)/(xa - xc);
                    I1 = t1*Ia + (1 - t1)*Ib;
                    I2 = t2*Ia + (1 - t2)*Ic;

                    //рисовать линию
                    if (x2 > x1)
                    {
                        //рисовать линию (строка с лево на право)
                        for (x = x1; x < x2; x++)
                        {
                            Intensive(x, y, x1, x2, I1, I2);
                        }
                    }
                    else
                    {
                        //рисовать линию (строка с право на лево)
                        for (x = x1; x > x2; x--)
                        {
                            Intensive(x, y, x1, x2, I1, I2);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Вычислить интенсивность точки [x,y]
        /// x, y - рассматриваемая точка;
        /// x1, x2 - граничные точки;
        /// I1, I2 - интенсивность в граничных точках
        /// </summary>
        private void Intensive(double x, double y, double x1, double x2, double I1, double I2)
        {
            //интенсивность в точке x
            double t = (x2 - x) / (x2 - x1);
            double I = t * I1 + (1 - t) * I2;
            //поставить точку
            SetPixel((int)x, (int)y, I, I, I);


        }

        /// <summary>
        /// Отрисовка
        /// </summary>
        private void SetPixel(int x, int y, double r, double g, double b)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            //Заливка выбор цвета
            double sr = 105*r;
            double sg = 155 * g;
            double sb = 25 * b;
            
            graphics.DrawRectangle(new Pen(Color.FromArgb((int)sr, (int)sg, (int)sb)), x, y, 1, 1);
        }




    }
}
