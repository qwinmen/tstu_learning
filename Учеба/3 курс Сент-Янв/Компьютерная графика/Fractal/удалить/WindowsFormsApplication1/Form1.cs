using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        Random random = new Random();

        /// <summary>
        /// Рисуем фигуру
        /// </summary>
        /// <param name="x">начальная точка по X дерева</param>
        /// <param name="y">начальная точка по Y дерева</param>
        /// <param name="a">угол наклона ствола</param>
        /// <param name="l">длина отрезка ветви</param>
        private void Pictures(double x, double y, double a, int l)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            
            int p;
            if (l < 8)
                 return;

            //Координаты конца ветки вычисляются учитывая переданный угол:
            double x1 = Math.Round(x + l*Math.Cos(a));
            double y1 = Math.Round(y + l*Math.Sin(a));

            if (l > 100)//200>100//94>100
                p = 100;
            else
                p = l;

            Pen pen = new Pen(Color.Black);

            if (p < 40)
            {//то ветки короткие и они становятся листьями
                //Генерация листьев
                if (random.Next() > 0.5)
                {
                    pen.Color = Color.Green;
                }                    
                else
                    pen.Color = Color.FromArgb(90, 139, 5);

                for (int i = 0; i < 3; i++)//3 - ширина основания листа
                {
                    g.DrawLine(pen, new Point((int)x + i, (int)y), new Point((int)x1, (int)y1));
                }
                

            }
            else
            {//то ветка с длинной более 40
                //Генерация веток
                pen.Color = Color.FromArgb(100, 3, 4);

                for (int i = 0; i < (p / 6); i++)
                {
                    g.DrawLine(pen, new Point((int)x + i - (p / 12), (int)y),
                               new Point((int)x1, (int)y1));
                }
                

            }
            
            //Следующие ветки
            for (int i = 0; i < (9 - random.Next(6)); i++)
            {
                int s = random.Next(l - l / 6) + (l / 6);
                double a1 = a + 1.6 * (0.5 - random.NextDouble()); //Угол наклона веток
                x1 = Math.Round(x + s * Math.Cos(a));
                y1 = Math.Round(y + s * Math.Sin(a));
                //рекурсив:
                Pictures(x1, y1, a1, p - 5 - random.Next(30)); //Чем меньше вычетаем, тем пышнее дерево
            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Image)new Bitmap(1000, 1000);
            Pictures(320, 580, 3*Math.PI / 2, 200);
        }

    }
}
