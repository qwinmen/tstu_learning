using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Magomed
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10); // задаем положение графика
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20); // размеры графика
        }
        public bool flag=false;
        public void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1, 0, 0); // строим график
            SetSize(); // и устанавливаем его положение и размер
        }

        
        // Функция построения графика
        private void CreateGraph(ZedGraphControl zgc ,double Rx,double Ry)
        {
            double[] X = { 1, 2, 3, 4, 5 };//{300, 400, 500, 600};
            double[] Y = { 6, 5, 9, 2, 8 };//{52.88, 65.61, 78.07, 99.24};
            GraphPane myPane = zgc.GraphPane;
            // Задаем название графика и сторон
            myPane.Title.Text = "График синусойды";
            myPane.XAxis.Title.Text = "Ось X";
            myPane.YAxis.Title.Text = "Ось Y";
            
            // строим синусойду
            double[]x={3}, y={3};
            PointPairList list1 = new PointPairList();
            list1.Add(x,y);
            for ( int i = 0; i < 1; i++ )
            {//Циклом От точка начала До точка Конец
                //x = i;
                //y = Math.Sin(x);
                int o = 0;
                foreach (double xx in X)
                {
                    if (o<Y.Length)
                    {
                        list1.Add(xx, Y[o]);//ставится одна Точка  
                        o++;
                    }
                        
                }
                
            }
            // Нарисуем стрелку, указыающую на максимум функции
            // Координаты точки, куда указывает стрелка
            // Координаты привязаны к осям
            double xend = 3.0;
            double yend = 9.0;
            // Координаты точки начала стрелки
            double xstart = xend + 0.5;
            double ystart = yend + 0.5;
            // Рисование стрелки с текстом
            // Создадим стрелку
            ArrowObj arrow = new ArrowObj(xstart, ystart, xend, yend);
            // Добавим стрелку в список отображаемых объектов
            myPane.GraphObjList.Add(arrow);
            // Напишем текст около начала стрелки
            // Координаты привязаны к осям
            TextObj text = new TextObj("Max", xstart, ystart);
            // Отключим рамку вокруг текста
            text.FontSpec.Border.IsVisible = false;
            // Добавим текст в список отображаемых объектов
            myPane.GraphObjList.Add(text);
            LineItem myCurve = myPane.AddCurve("Sin", list1, Color.Red, SymbolType.Diamond); // отрисовываем график

            
            if(Rx!=0 && Ry!=0)
            {//На входе нули - ничего не рисуем
                PointPairList list2 = new PointPairList();
                list2.Add(Rx, Ry);
                LineItem myCurve2 = myPane.AddCurve("Interp", list2, Color.Green, SymbolType.Diamond);
            }
            
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            myPane.AxisChange();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {//Событие по Выходу
            Close();//FormMain.ActiveForm.Close();
        }

        public void FF(double Rx,double Ry)
        {
            //fParamInterpol fParamInterpol = new fParamInterpol();
            
        }
        /*изменение полинова в зависимости от метода*/
        private void interpolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fParamInterpol fParamInterpol=new fParamInterpol();
            if (fParamInterpol.ShowDialog() != DialogResult.OK)//если нажата кн отмена то делаем ретурн
                return; 
            //fParamInterpol.Show();
            GraphPane pane = zedGraphControl1.GraphPane;
            PointPairList list2 = new PointPairList();
            list2.Add(fParamInterpol.Age, fParamInterpol.Age);
            LineItem myCurve2 = pane.AddCurve("Curve 2", list2, Color.Black, SymbolType.Diamond);
            pane.AxisChange();
            //zedGraphControl1.AxisChange();
            // Обновляем график
            zedGraphControl1.Invalidate();
            //MessageBox.Show(fParamInterpol.Age.ToString());
            
        }
    }
}
