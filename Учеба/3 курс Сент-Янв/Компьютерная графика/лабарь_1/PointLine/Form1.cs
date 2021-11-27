using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace PointLine
{
    public partial class fMain : Form
    {
        public fMain()
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
            Gl.glEnable(Gl.GL_ALPHA_TEST);//чтобы разрешить обрабатывать четвертый компонент цвета
            Gl.glEnable(Gl.GL_BLEND);//чтобы разрешить наложение цветов
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

            button1_Click();
        }

        private void button1_Click()
        {
            //очистка экрана перед визуализацией кадра (Цвет И Глубина)
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);//устанавл цвет отрисовки геометрии

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();
            // устанавливаем размер точек, равный 5 пикселям 
            Gl.glPointSize(5);
            // рисуем точки ПО РИКСЕЛЬНО
            Gl.glBegin(Gl.GL_POINTS);
            for (double i = 1; i < 50; i += 0.04)
            {
                Gl.glVertex2d(i, 1);//x
                Gl.glVertex2d(1, i);//y
            }
            Gl.glEnd();

            Gl.glPointSize(1);
            //Брезенхем(10, 10, 400, 400);
            Gl.glBegin(Gl.GL_POINTS);
            DrawPoint(0);// [x--------x]
            Gl.glEnd();

            // возвращаем матрицу из стека 
            Gl.glPopMatrix();
            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();
            // сигнал для обновление элемента реализующего визуализацию. 
            OGlControl.Invalidate();//обновить отображаемый кадр
        }
        
        /// <summary>
        /// Отрисовка точек из контейнеров
        /// </summary>
        private void DrawPoint(int key)
        {
            switch (_globalFlag)
            {
                case 0://для Х+45
                    {
                        foreach (KeyValuePair<PointF, Color> keyValuePair in PointColor)
                        {
                            Gl.glColor3b(keyValuePair.Value.R, keyValuePair.Value.G, keyValuePair.Value.B);
                            Gl.glVertex2f(keyValuePair.Key.X, keyValuePair.Key.Y);
                        }

                        for (double i = 0; i < duplicatePointColor.Count(); i++)
                            duplicatePointColor[i] = Gradient(i);//пишем новые цвета
                        double index0 = 0;
                        foreach (PointF pnt in duplicatePointColor)
                        {
                            Gl.glColor3b(duplicatePointColor[index0].R, duplicatePointColor[index0].G, duplicatePointColor[index0].B);
                            Gl.glVertex2f(pnt.X, pnt.Y);
                            index0++;
                        }
                        
                    }
                    break;

                case 1://Для У-45
                    {
                        foreach (KeyValuePair<PointF, Color> keyValuePair in PointColor)
                        {
                            Gl.glColor3b(keyValuePair.Value.R, keyValuePair.Value.G, keyValuePair.Value.B);
                            Gl.glVertex2f(keyValuePair.Key.Y, keyValuePair.Key.X);
                        }

                        for (double i = 0; i < duplicatePointColor.Count(); i++)
                            duplicatePointColor[i] = Gradient(i);//пишем новые цвета
                        double index1 = 0;
                        foreach (PointF pnt in duplicatePointColor)
                        {
                            Gl.glColor3b(duplicatePointColor[index1].R, duplicatePointColor[index1].G, duplicatePointColor[index1].B);
                            Gl.glVertex2f(pnt.Y, pnt.X);
                            index1++;
                        }
                        _globalFlag = 0;
                        
                    }
                    break;
            }
        }

        /// <summary>
        /// Цвет основной линии
        /// </summary>
        private static Color _globalColor = Color.FromArgb(127, 0, 0);

        private static byte index = 0;
        private static int tmp;

        /// <summary>
        /// Расчитать цвет опорного пиксела от позиции его в ступеньке
        /// </summary>
        private static Color Gradient(double step)
        {
            
            if(step == 0) tmp = _stupeniList[0];
            //от step до tmp
            //tmp = tmp + _stupeniList[1]
            if(step<=tmp)
            {
                int Rgradient = _globalColor.R-27;// _stupeniList[index];
                int Ggradient = _globalColor.G;// _stupeniList[index];
                int Bgradient = _globalColor.B;// _stupeniList[index];
                return Color.FromArgb(Rgradient, Ggradient, Bgradient);
            }
            else
            {
                index++;
                //tmp = tmp + _stupeniList[index];
                int Rgradient = _globalColor.R-27;//_stupeniList[index];
                int Ggradient = _globalColor.G;// _stupeniList[index];
                int Bgradient = _globalColor.B;// _stupeniList[index];
                return Color.FromArgb(Rgradient, Ggradient, Bgradient);
            }
        }

        private static int _globalFlag = 0;//координатная четверть
        //Алгоритм построения\высчитывания линии\координат по двум точкам
        private static void Брезенхем(int a, int b, int c, int d)
        {
            //очистка контейнеров
            PointColor.Clear();
            duplicatePointColor.Clear();

            int xStart = a, yStart = b, xEnd = c, yEnd = d;
            //Находим dx dy
            int dx = (xEnd - xStart);
            int dy = (yEnd - yStart);
            _globalFlag = 0;//reset

            if (dx < dy)//поменять местами координаты точек
            {
                int tmp = xStart;//2
                xStart = yStart;//1
                yStart = tmp;//2

                tmp = xEnd;//7
                xEnd = yEnd;//4
                yEnd = tmp;//7

                dx = (xEnd - xStart);
                dy = (yEnd - yStart);

                _globalFlag = 1;
            }

            int d1 = (dy << 1) - dx;//2*dy - dx;
            PointColor.Add(new Point(xStart, yStart), _globalColor);//начальная точа
            duplicatePointColor.Add(new PointF(xStart, yStart + 0.04f), _globalColor);//Для точек всей ступеньки

            for (int i = xStart; i < xEnd; i++)//т.к по Х постоянное приращение на 1
                d1 = Coordinats(d1 >= 0, dx, dy, d1, i == xEnd - 1);

            
        }

        /// <summary>
        /// di = di + 2*dy - dx
        /// </summary>
        private static int ControlFull(int dx, int dy, int di) { return di + ((dy - dx) << 1); }//di + 2*(dy - dx)

        /// <summary>
        /// di = di + 2*dy
        /// </summary>
        private static int ControlLite(int dy, int di) { return di + (dy << 1); }//di + 2*(dy)

        /// <summary>
        /// находим прирост [x;y]
        /// </summary>
        private static int Coordinats(bool flag, int dx, int dy, int d1, bool stop)
        {
            if(!flag && stop) _stupeniList.Add(_index+1);//1 - конец

            if(flag)
            {//flag=true начало новой ступеньки
                float x2 = PointColor.Last().Key.X + 0.04f;//xStart + 1;
                float y2 = PointColor.Last().Key.Y + 0.04f;//yStart + 1;
                
                PointColor.Add(new PointF(x2, y2), _globalColor);
                
                //duplicatePointColor.Add(new PointF(x2+0.04f, y2+0.04f), _globalColor);//Для точек в углах лесинки
                duplicatePointColor.Add(new PointF(x2, y2 + 0.04f), _globalColor);//Для точек всей ступеньки
                
                _stupeniList.Add(_index+1);
                _index = 0;

                return ControlFull(dx, dy, d1);//d1 = d1 + 2 * (dy - dx);
            }
            else
            {//flag=false продолжение старой ступени
                float x2 = PointColor.Last().Key.X + 0.04f;//xStart + 1;
                float y2 = PointColor.Last().Key.Y;//yStart;

                _index++;
                PointColor.Add(new PointF(x2, y2), _globalColor);

                //duplicatePointColor.Add(new PointF(x2+0.04f, y2), _globalColor);//Для точек в углах лесинки
                duplicatePointColor.Add(new PointF(x2, y2 + 0.04f), _globalColor);
                
                return ControlLite(dy, d1);//d1 = d1 + 2 * (dy);
            }
        }

        private static int _index = 0;//счетчик вызовов flag = false

        /// <summary>
        /// Основной контейнер x;y;color
        /// </summary>
        private static Dictionary<PointF, Color> PointColor = new Dictionary<PointF, Color>();

        /// <summary>
        /// Сколько пикселей на одной ступеньке (для градиента цветов)
        /// </summary>
        private static List<int> _stupeniList = new List<int>();

        /// <summary>
        /// Вспомогательный контейнер x;y;color
        /// </summary>
        private static clArrayList duplicatePointColor = new clArrayList();

        private static int c, d;
        
        public void OGlControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Form2.CheckedBox)
            {
                c = e.X;
                d = OGlControl.Height - e.Y;//768 - e.Y;
                Брезенхем(2, 2, c, d);
                button1_Click();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            fMain.ActiveForm.Close();
        }

        private void контрольToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form2 _child = new Form2();
            _child.Show();
        }

        private void fMain_Load(object sender, System.EventArgs e)
        {
            InitGL();
        }

        private void fMain_Resize(object sender, System.EventArgs e)
        {
            button1_Click();//InitGL();
        }

        public void NewCoordinates(int x0, int y0, int x1, int y1)
        {
            Брезенхем(x0, y0, x1, y1);
            button1_Click();
        }


    }
}
