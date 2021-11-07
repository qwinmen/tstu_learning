using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabRaI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int K = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//Проверка на пустоту
            {
                int index = Convert.ToInt32(textBox1.Text); //Считываем введеное число
                K = index; // присваеваем его К
                panel1.Invalidate();
            }
            else
                MessageBox.Show("Введите число!");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {//Проверка на коректный ввод
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))// В поле TexBox
                e.Handled = true;  //требуется вводить лишь цифры
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create points that define curve.
            Point point0 = new Point(90, 115);
            Point point1 = new Point(100, 100);//Y
            Point point4 = new Point(110, 115);
            Point point11 = new Point(100, 100);

            Point point2 = new Point(100, 300);//0:0
            Point point3 = new Point(300, 300);

            Point point00 = new Point(290, 290);
            Point point12 = new Point(300, 300);//X
            Point point44 = new Point(290, 310);

            Point[] curvePoints = { point0, point1, point4, point11, point2, point3, point00, point12, point44 };

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(new Pen(Color.Red,3), curvePoints);
            //_____________________________________________//

            double Yt;
            int y = 0;
            Point p1;
            Point p2;

            int x = -3,lim=3,Y=0;
            int[] p = {};
            for (; x < lim; x++)
            {
                //p1 = new Point(x, y);
                //y = (int)(f(x) * 50); // число 50 задает масштаб по Y
                //y = y + 100; // смещаем график на 100 пикселей оп Y
                Y = K/((x ^ 2) + 1);
                p[x] = Y;
                p2 = new Point(x, y);
                Graphics dc = e.Graphics;
                Point[] arreyPoin = { p1, p2 };
                dc.DrawPolygon(new Pen(Color.Red), arreyPoin); //строим отрезок графика между начально и конечной точкой аппроксимации
            }
            
        }
        int f(int X)//функция
        {
            return K/((X ^ 2) + 1);
        }
    }
}
        
