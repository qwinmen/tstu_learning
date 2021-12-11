using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace lablitovka
{
    public partial class Form1 : Form
    {
        int Diameter = 10;
        int x = 0;
        int y = 20;
        int x1 = 550;
        int y1 = 350;
        int dx = 1;
        int dy = 1;
        int dx1 = 1;
        int dy1 = 1;
        double rast;

        private readonly Timer _timer;
        private BufferedGraphics _bufGraphics;
        public Form1()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Tick += timer_Tick;
            _timer.Interval = 1;
            
            InitializeGraphics();

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();
            Diameter = trackBar2.Value;
   
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString();
            dx = trackBar1.Value;
            dy = trackBar1.Value;
            dx1 = trackBar1.Value;
            dy1 = trackBar1.Value;
        }

        private void InitializeGraphics()
        {

            BufferedGraphicsContext context = new BufferedGraphicsContext();
            _bufGraphics = context.Allocate(CreateGraphics(), ClientRectangle);

            context.MaximumBuffer = ClientRectangle.Size;

        }

        private bool flag = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            _bufGraphics.Graphics.Clear(Color.Black);
//  Код:       

            if (x < 170 && !flag)
            {
                x += 10;
                flag = false;
            }
            else
            {
                x -= 10;
                flag = x>50?true:false;
            }
            //Рисуем в буфере, чтобы не мигало изображение
        
            Pen pen = new Pen(Brushes.Red);
            
            
            _bufGraphics.Graphics.FillEllipse(Brushes.Red, 300, 300, 130, 70);
            //****************************porshen**************************************** 
            //_bufGraphics.Graphics.FillRectangle(Brushes.Silver, 50, x, 100, 70);

            _bufGraphics.Graphics.FillRectangle(Brushes.Silver, 315, 60 + x, 100, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 315, 60 + x, 100, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 315, 70 + x, 100, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 315, 80 + x, 100, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 300, 90 + x, 130, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 300, 100 + x, 130, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 300, 110 + x, 130, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 300, 120 + x, 130, 70);
            _bufGraphics.Graphics.FillEllipse(Brushes.Silver, 300, 130 + x, 130, 70);
            //*******************************************************************************    
            _bufGraphics.Graphics.DrawEllipse(pen, 300, 200, 130, 70);
            
            _bufGraphics.Graphics.DrawLine(pen, 300, 240, 300, 340);
            _bufGraphics.Graphics.DrawLine(pen, 430, 340, 430, 240);
            _bufGraphics.Graphics.DrawLine(pen, 300, 240, 300, 340);
            _bufGraphics.Graphics.DrawLine(pen, 430, 340, 430, 240);
            _bufGraphics.Render(); //выводим то, что отрисовано в буфере
            
            rast = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
            if (rast == Diameter*2 || rast < Diameter*2)
            {
                textBox1.Text = "Контакт";
            }
            else textBox1.Text = "Нет контакта";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            button1.Text = "Стоп";
            
            _timer.Enabled = !_timer.Enabled;
            _timer.Interval = 200;
           
            
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            
            bool timerState = _timer.Enabled;
            _timer.Stop();
           

            InitializeGraphics();

            _timer.Enabled = timerState;
            //_timer.Interval = 5;
            _timer.Start();

            ResetPosition();
          

        }

        private void ResetPosition()
        {
            if (x == 170)
            {
                while (x > 0)
                {
                    x--;
                }
            }
           

        }
    }
}
