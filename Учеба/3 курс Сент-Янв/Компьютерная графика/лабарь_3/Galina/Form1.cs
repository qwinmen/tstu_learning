using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Galina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //----------------------------------------------------------------------
            Point A = new Point(intInput_Ax.Value, intInput_Ay.Value); //начальная нижняя точка
            Point B = new Point(intInputBx.Value, intInputBy.Value); //начальная верхняя точка
            Point r = new Point(intInputZx.Value, intInputZy.Value); //диалональ-смещение
            _tmpA = new Point4(A, r, 1);
            _tmpB = new Point4(B, r, 1);

            OGlControl.InitializeContexts();

            OGlControl.MouseWheel += (OGlControl_MouseWheel);
            
        }

        private const int CentrX = 8, CentrY = 8;

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
            if ((float) OGlControl.Width <= (float) OGlControl.Height)
                Glu.gluOrtho2D(0.0, 30.0*(float) OGlControl.Height/(float) OGlControl.Width, 0.0, 30.0);
            else
                Glu.gluOrtho2D(0.0, 30.0*(float) OGlControl.Width/(float) OGlControl.Height, 0.0, 30.0);

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

        /// <summary>
        /// Перерисовка компонента GL
        /// </summary>
        private void ResizeGL()
        {
            //очистка экрана перед визуализацией кадра (Цвет И Глубина)
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glViewport(0, 0, OGlControl.Width, OGlControl.Height);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0); //устанавл цвет отрисовки геометрии
            //Gl.glRotatef (10.0f, 30.0f, 0.0f, 0.0f); // поворот-ось X 
            //Gl.glRotatef(10.0f, 0.0f, 30.0f, 0.0f); // поворот-ось X 
            //Gl.glRotatef(2.85f, 0.0f, 1.0f, 0.0f); // поворот-ось X 
            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();
            // устанавливаем размер точек, равный 5 пикселям 
            Gl.glPointSize(5);

            // выполняем перемещение в прострастве по осям X и Y
            Gl.glTranslated(CentrX, CentrY, 0);

            try
            {
                intInput_Ax.Value = _tmpA.X;//A.X;
                intInput_Ay.Value = _tmpA.Y;//A.Y;
                intInputBx.Value = _tmpB.X;//B.X;
                intInputBy.Value = _tmpB.Y;//B.Y;
                intInputZx.Value = _tmpA.Zxy.X;//r.X;
                intInputZy.Value = _tmpA.Zxy.Y;//r.Y;
            }
            catch (Exception)
            {
                //----------------------------------------------------------------------
                Point A = new Point(intInput_Ax.Value, intInput_Ay.Value); //начальная нижняя точка
                Point B = new Point(intInputBx.Value, intInputBy.Value); //начальная верхняя точка
                Point r = new Point(intInputZx.Value, intInputZy.Value); //диалональ-смещение
                _tmpA = new Point4(A, r, 1);
                _tmpB = new Point4(B, r, 1);
                intInput_Ax.Value = _tmpA.X;//A.X;
                intInput_Ay.Value = _tmpA.Y;//A.Y;
                intInputBx.Value = _tmpB.X;//B.X;
                intInputBy.Value = _tmpB.Y;//B.Y;
                intInputZx.Value = _tmpA.Zxy.X;//r.X;
                intInputZy.Value = _tmpA.Zxy.Y;//r.Y;
            }
            

            switch (2)
            {
                case 1:
                    Gl.glBegin(Gl.GL_POINTS);
                    //Kvadrat(A, B, r);
                    break;
                case 2:
                    Gl.glBegin(Gl.GL_LINES);
                    //Kvadrat(A, B, r);
                    Kvadrat(_tmpA, _tmpB);
                    break;
                case 3:
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    //Kvadrat(A, B, r);
                    break;
            }
            Gl.glEnd();
            //----------------------------------------------------------------------
            // возвращаем матрицу из стека 
            Gl.glPopMatrix();
            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();
            // сигнал для обновление элемента реализующего визуализацию. 
            OGlControl.Invalidate(); //обновить отображаемый кадр
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeGL();
        }

        private Point4 _tmpA;
        private Point4 _tmpB;

        private void Kvadrat(Point4 A, Point4 B)
        {
            Point a = new Point(A.X + A.Zxy.X, A.Y + A.Zxy.Y);
            Point b = new Point(B.X + A.Zxy.X, B.Y + A.Zxy.Y);

            //ближний квадрат:
            //низ:
            Gl.glVertex2d(A.X, A.Y);
            Gl.glVertex2d(B.X, A.Y);
            //верх:
            Gl.glVertex2d(B.X, B.Y);
            Gl.glVertex2d(A.X, B.Y);
            //лево:
            Gl.glVertex2d(A.X, A.Y);
            Gl.glVertex2d(A.X, B.Y);
            //право:
            Gl.glVertex2d(B.X, A.Y);
            Gl.glVertex2d(B.X, B.Y);

            //смещение на дальний квадрат:
            //А-а:
            Gl.glVertex2d(A.X, A.Y);
            Gl.glVertex2d(a.X, a.Y);
            //В-b:
            Gl.glVertex2d(B.X, B.Y);
            Gl.glVertex2d(b.X, b.Y);
            //AB-ab:left:
            Gl.glVertex2d(A.X, B.Y);
            Gl.glVertex2d(a.X, b.Y);
            //AB-ab:right:
            Gl.glVertex2d(B.X, A.Y);
            Gl.glVertex2d(b.X, a.Y);

            //дальний квадрат:
            //низ:
            Gl.glVertex2d(a.X, a.Y);
            Gl.glVertex2d(b.X, a.Y);
            //верх:
            Gl.glVertex2d(b.X, b.Y);
            Gl.glVertex2d(a.X, b.Y);
            //лево:
            Gl.glVertex2d(a.X, a.Y);
            Gl.glVertex2d(a.X, b.Y);
            //право:
            Gl.glVertex2d(b.X, a.Y);
            Gl.glVertex2d(b.X, b.Y);

        }

        private void Kvadrat(Point A, Point B, Point r)
        {
            Point a = new Point(A.X + r.X, A.Y + r.Y);
            Point b = new Point(B.X + r.X, B.Y + r.Y);

            //ближний квадрат:
            //низ:
            Gl.glVertex2d(A.X, A.Y);
            Gl.glVertex2d(B.X, A.Y);
            //верх:
            Gl.glVertex2d(B.X, B.Y);
            Gl.glVertex2d(A.X, B.Y);
            //лево:
            Gl.glVertex2d(A.X, A.Y);
            Gl.glVertex2d(A.X, B.Y);
            //право:
            Gl.glVertex2d(B.X, A.Y);
            Gl.glVertex2d(B.X, B.Y);

            //смещение на дальний квадрат:
            //А-а:
            Gl.glVertex2d(A.X, A.Y);
            Gl.glVertex2d(a.X, a.Y);
            //В-b:
            Gl.glVertex2d(B.X, B.Y);
            Gl.glVertex2d(b.X, b.Y);
            //AB-ab:left:
            Gl.glVertex2d(A.X, B.Y);
            Gl.glVertex2d(a.X, b.Y);
            //AB-ab:right:
            Gl.glVertex2d(B.X, A.Y);
            Gl.glVertex2d(b.X, a.Y);

            //дальний квадрат:
            //низ:
            Gl.glVertex2d(a.X, a.Y);
            Gl.glVertex2d(b.X, a.Y);
            //верх:
            Gl.glVertex2d(b.X, b.Y);
            Gl.glVertex2d(a.X, b.Y);
            //лево:
            Gl.glVertex2d(a.X, a.Y);
            Gl.glVertex2d(a.X, b.Y);
            //право:
            Gl.glVertex2d(b.X, a.Y);
            Gl.glVertex2d(b.X, b.Y);

        }

        /// <summary>
        /// Перерисовать с новыми А-В точками
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Point A = new Point(intInput_Ax.Value, intInput_Ay.Value); //начальная нижняя точка
            Point B = new Point(intInputBx.Value, intInputBy.Value); //начальная верхняя точка
            Point r = new Point(intInputZx.Value, intInputZy.Value); //диалональ-смещение
            _tmpA = new Point4(A, r, 1);
            _tmpB = new Point4(B, r, 1);

            ResizeGL();
        }

        private void bar1_BarStateChanged(object sender, DevComponents.DotNetBar.BarStateChangedEventArgs e)
        {
            ResizeGL();
        }

        private int _count = 0;
        private void OGlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int numberOfPixelsToMove = numberOfTextLinesToMove;
            
            if (numberOfPixelsToMove > 0)
            {//увеличение масштаба
                _count++;//= _count + numberOfPixelsToMove;
            }
            else if (_count > 0)
            {//уменьшение масштаба
                _count--; //= _count + numberOfPixelsToMove;
            }
            Mashtab();
        }


        /// <summary>
        /// Перерисовка компонента GL
        /// </summary>
        private void ResizeGL(Point4 a, Point4 b)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glViewport(0, 0, OGlControl.Width, OGlControl.Height);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0); //устанавл цвет отрисовки геометрии
            Gl.glPushMatrix();
            Gl.glPointSize(3);
            Gl.glTranslated(CentrX, CentrY, 0);
            
            Gl.glBegin(Gl.GL_LINES);
            Kvadrat(a, b);
            Gl.glEnd();

            Gl.glPopMatrix();
            Gl.glFlush();
            OGlControl.Invalidate(); //обновить отображаемый кадр
        }


        private void Mashtab()
        {
            //есть коэфициент масштабирования _count > 0
            //вставить _count в матрицу 4х4
            //Пересчитать обьект:   умножить две вершины куба на матрицу
            label1.Text = "A- x:" + _tmpA.X * _count + " y:" + _tmpA.Y * _count + " z:" + _tmpA.Zxy.Y * _count;
            label2.Text = "B- x:" + _tmpB.X * _count + " y:" + _tmpB.Y * _count + " z:" + _tmpB.Zxy.Y * _count;

            Point A = new Point(intInput_Ax.Value * _count, intInput_Ay.Value * _count); //начальная нижняя точка
            Point B = new Point(intInputBx.Value * _count, intInputBy.Value * _count); //начальная верхняя точка
            Point r = new Point(intInputZx.Value * _count, intInputZy.Value * _count); //диалональ-смещение
            
            var _A = new Point4(A, r, 1);
            var _B = new Point4(B, r, 1);

            ResizeGL(_A, _B);
        }





    }
}
    