using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Лаб-1 ООП наследование+изменение_свойств_свой-метод
namespace Delite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 6; i++)
            {
                RainbowButton rainbowButton = new RainbowButton();
                rainbowButton.Left = 0 + i;
                rainbowButton.Top = 50 + i;
                rainbowButton.Height = 50 + i * 2;
                rainbowButton.Width = 50 + i * 2;

                rainbowButton.Text = "лошадь "+i.ToString();
                this.Controls.Add(rainbowButton);
            }
            
            
        }
    }


    public sealed class RainbowButton : Button// Наследуемся от класса кнопки
    {
        private Random rand;
        public byte r, g, b, a;
        public int numberOfClicks;
        public RainbowButton() // Конструктор класса
        {
            rand = new Random(); // инициализируем рандомизатор
            //this.ForeColor = Color.FromArgb(rand.Next(int.MaxValue)); // задаем случайный цвет текста
            ChangeTextColor();
            r = this.ForeColor.R;
            g = this.ForeColor.G;
            b = this.ForeColor.B;
            a = this.ForeColor.A;
            this.numberOfClicks = 0;
        }

        public void ChangeTextColor()
        {
            this.ForeColor = Color.FromArgb(rand.Next(int.MaxValue)); // задаем случайный цвет текста
        }

        protected override void OnMouseClick(MouseEventArgs e) // переопределяем обработчик базового класса
        // Данный метод вызывается при клике по кнопке
        {
            //this.ForeColor = Color.FromArgb(rand.Next(int.MaxValue)); // опять меняем цвет текста
            ChangeTextColor();
            base.OnMouseClick(e); // вызываем обработчик базового класса, что бы ничего не "потерялось"
            this.numberOfClicks++;
            r = this.ForeColor.R;
            g = this.ForeColor.G;
            b = this.ForeColor.B;
            a = this.ForeColor.A;
            string text = String.Format("ARGB значения: Alpha: {0}, " +
                "red: {1}, green: {2}, blue: {3}", new object[] { a, r, g, b });
            MessageBox.Show("Кликнули " + this.numberOfClicks + " раз; " + text, "Info");
        }
    }
}
