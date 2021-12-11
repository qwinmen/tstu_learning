using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;
//Реализовать движение механических узлов в виде шестеренки
//http://esate.ru/uroki/OpenGL/uroki-OpenGL-c-sharp/initsializatsiya-opengl-v-c-sharp-step-2/
namespace Механики
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Инициализация элемента графики
            simpleOpenGlControl1.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Визуализировать
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            // отчитка окна 
            Gl.glClearColor(.9f, .9f, .9f, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);


            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)simpleOpenGlControl1.Width / (float)simpleOpenGlControl1.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glClearDepth(1.0f);											// Depth Buffer Setup
            Gl.glDepthFunc(Gl.GL_LEQUAL);										// The Type Of Depth Testing (Less Or Equal)
            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            //LoadGridModel();
            LoadGridModel(true);
        }

        // массив вершин создаваемого геометрического объекта 
        private float[,] GeomObject = new float[32, 3];
        // счетчик его вершин 
        private int count_elements = 0;

        /// <summary>
        /// Загрузить сеточную модель
        /// </summary>
        private void LoadGridModel()
        {
            //Почистить буферы рисунка Цвет_Глубина
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //очищаем объектно-видовую матрицу
            Gl.glLoadIdentity();
            //красный цвет отрисовки геометрии
            Gl.glColor3f(1.0f, 0, 0);
            //помещение текущей матрицы в стэк матриц
            Gl.glPushMatrix();
            /*------------------------------------------------*/
            //перемещение объекта на 6 едениц по оси Z
            Gl.glTranslated(0, 0, -6);
            //поворот сцены на 45 градусов сразу по двум осям
            Gl.glRotated(45, 1, 1, 0);

            // рисуем сферу радиусом 2 в виде сетки в той области, куда мы переместились. 
            //Сфера будет разбита на 32 меридиана и 32 параллели. 
            //Glut.glutWireSphere(2, 32, 32);
            // пирамида для визуализации (4 точки) 

            GeomObject[0, 0] = -0.7f;
            GeomObject[0, 1] = 0;
            GeomObject[0, 2] = 0;

            GeomObject[1, 0] = 0.7f;
            GeomObject[1, 1] = 0;
            GeomObject[1, 2] = 0;

            GeomObject[2, 0] = 0.0f;
            GeomObject[2, 1] = 0;
            GeomObject[2, 2] = 1.0f;

            GeomObject[3, 0] = 0;
            GeomObject[3, 1] = 0.7f;
            GeomObject[3, 2] = 0.3f;

            
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            
            // количество вершин рассматриваемого геометрического объекта 
            count_elements = 4;
            
            /*------------------------------------------------*/
            //вызвать матрицу из стека матриц
            Gl.glPopMatrix();
            //Дожидаемся, пока библиотека OpenGL завершит визуализацию этого кадра:
            Gl.glFlush();
            //вызываем его перерисовку. 
            simpleOpenGlControl1.Invalidate();

            Draw();
            
        }

        private int LastTickCount = 1;
        private void UpdateFramerate()
        {
            Frames++;
            if (Math.Abs(Environment.TickCount - LastTickCount) > 1000)
            {
                LastFrameRate = (float)Frames * 1000 / Math.Abs(Environment.TickCount - LastTickCount);
                LastTickCount = Environment.TickCount;
                Frames = 0;
            }
        }

        private void LoadGridModel(bool a)
        {
            Gl.glShadeModel(Gl.GL_FLAT);											// Select Flat Shading (Nice Definition Of Objects)
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);				// Set Perspective Calculations To Most Accurate

            quadratic = Glu.gluNewQuadric();										// Create A Pointer To The Quadric Object
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);						// Create Smooth Normals
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);							// Create Texture Coords

            Gl.glEnable(Gl.GL_LIGHT0);											// Enable Default Light
            Gl.glEnable(Gl.GL_LIGHTING);											// Enable Lighting

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);									// Enable Color Material

            //в цикл
            Update(Environment.TickCount);	// Update The Counter
            Drawer();
        }
        
        // функция отрисовки 
        private void Draw()
        {

            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(.9f, .9f, .9f, 1);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // утснаовка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            // перемещаем камеру для более хорошего обзора объекта
            Gl.glTranslated(0, 0, -7);
            // поворачиваем ее на 15 градусов
            Gl.glRotated(15, 1, 1, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            // начинаем отрисовку объекта
            Gl.glBegin(Gl.GL_LINE_LOOP);

            // геометрические данные ме бырем из массива GeomObject
            // рисуем основание с помощью зацикленной линии
            Gl.glVertex3d(GeomObject[0, 0], GeomObject[0, 1], GeomObject[0, 2]);
            Gl.glVertex3d(GeomObject[1, 0], GeomObject[1, 1], GeomObject[1, 2]);
            Gl.glVertex3d(GeomObject[2, 0], GeomObject[2, 1], GeomObject[2, 2]);

            // завершаем отрисовку примитивов
            Gl.glEnd();

            // рисуем линии от вершин основания к вершине пирамиды
            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex3d(GeomObject[0, 0], GeomObject[0, 1], GeomObject[0, 2]);
            Gl.glVertex3d(GeomObject[3, 0], GeomObject[3, 1], GeomObject[3, 2]);

            Gl.glVertex3d(GeomObject[1, 0], GeomObject[1, 1], GeomObject[1, 2]);
            Gl.glVertex3d(GeomObject[3, 0], GeomObject[3, 1], GeomObject[3, 2]);

            Gl.glVertex3d(GeomObject[2, 0], GeomObject[2, 1], GeomObject[2, 2]);
            Gl.glVertex3d(GeomObject[3, 0], GeomObject[3, 1], GeomObject[3, 2]);

            // завершаем отрисовку примитивов
            Gl.glEnd();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // возвращаем состояние матрицы
            Gl.glPopMatrix();

            // отрисовываем геометрию
            Gl.glFlush();

            // обновляем состояние элемента
            simpleOpenGlControl1.Invalidate();
        }


        //перетаскмвание панели
        #region Panel Drag Drop

        private Boolean _dragging;
        private Point _startDragPoint;

        /// <summary>
        /// Нажатие
        /// </summary>
        private void pnlDragDrop_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _startDragPoint = e.Location;
        }

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                ((Control)sender).Left = ((Control)sender).Location.X + (e.Location.X - _startDragPoint.X);
                ((Control)sender).Top = ((Control)sender).Location.Y + (e.Location.Y - _startDragPoint.Y);
            }
        }

        /// <summary>
        /// Освобождение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDragDrop_MouseUp(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                _dragging = false;
                activePanelMenu.Invalidate();
            }
        }

        #endregion

        private void Form1_Resize(object sender, EventArgs e)
        {
            //LoadGridModel();
            LoadGridModel(true);
        }


        bool isClicked = false;										// NEW: Clicking The Mouse?
        bool isRClicked = false;										// NEW: Clicking The Right Mouse Button?
        bool isDragging = false;					                    // NEW: Dragging The Mouse?

        void Update(int milliseconds)									// Perform Motion Updates Here
        {

            if (isRClicked)													// ПКМ мыши - сброс поворотов обьектов
            {
                Matrix3fSetIdentity(&LastRot);								// Reset Rotation
                Matrix3fSetIdentity(&ThisRot);								// Reset Rotation
                Matrix4fSetRotationFromMatrix3f(&Transform, &ThisRot);		// Reset Rotation
            }

            if (!isDragging)												// При загрузке
            {
                if (isClicked)												// First Click
                {
                    isDragging = true;										// Prepare For Dragging
                    LastRot = ThisRot;										// Set Last Static Rotation To Last Dynamic One
                    ArcBall.click(&MousePt);								// Update Start Vector And Prepare For Dragging
                }
            }
            else
            {
                if (isClicked)												// Still Clicked, So Still Dragging
                {
                    Quat4fT ThisQuat;

                    ArcBall.drag(&MousePt, &ThisQuat);						// Update End Vector And Get Rotation As Quaternion
                    Matrix3fSetRotationFromQuat4f(&ThisRot, &ThisQuat);		// Convert Quaternion Into Matrix3fT
                    Matrix3fMulMatrix3f(&ThisRot, &LastRot);				// Accumulate Last Rotation Into This One
                    Matrix4fSetRotationFromMatrix3f(&Transform, &ThisRot);	// Set Our Final Transform's Rotation From This One
                }
                else														// No Longer Dragging
                    isDragging = false;
            }
        }

        //Draw A Torus With Normals
        void Torus(float MinorRadius, float MajorRadius)
        {
            
            int i, j;
            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);//glBegin(GL_TRIANGLE_STRIP); // Start A Triangle Strip
            for (i = 0; i < 20; i++) // Stacks
            {
                for (j = -1; j < 20; j++) // Slices
                {
                    float wrapFrac = (j%20)/(float) 20;
                    float phi = PI2*wrapFrac;
                    float sinphi = Convert.ToSingle(Math.Sin(phi));
                    float cosphi = Convert.ToSingle(Math.Cos((double)phi));
                    
                    float r = MajorRadius + MinorRadius*cosphi;
                    
                    Gl.glNormal3f(Convert.ToSingle(Math.Sin(PI2*(i%20 + wrapFrac)/20f))*cosphi, sinphi,
                        Convert.ToSingle(Math.Cos(PI2*(i%20 + wrapFrac)/(float) 20))*cosphi);//glNormal3f(float(sin(PI2*(i%20 + wrapFrac)/(float) 20))*cosphi,sinphi,float(cos(PI2*(i%20 + wrapFrac)/(float) 20))*cosphi);
                    Gl.glVertex3f(Convert.ToSingle(Math.Sin(PI2*(i%20 + wrapFrac)/(float) 20))*r, MinorRadius*sinphi,
                                                   Convert.ToSingle(Math.Cos(PI2*(i%20 + wrapFrac)/(float) 20))*r);

                    Gl.glNormal3f(Convert.ToSingle(Math.Sin(PI2*(i + 1%20 + wrapFrac)/(float) 20))*cosphi,
                                  sinphi, Convert.ToSingle(Math.Cos(PI2*(i + 1%20 + wrapFrac)/(float) 20))*cosphi);
                    Gl.glVertex3f(Convert.ToSingle(Math.Sin(PI2*(i + 1%20 + wrapFrac)/(float) 20))*r,
                                  MinorRadius*sinphi, Convert.ToSingle(Math.Cos(PI2*(i + 1%20 + wrapFrac)/(float) 20))*r);
                }
            }
            Gl.glEnd(); // Done Torus
        }

        const float PI2 = 2.0f * 3.1415926535f;								// PI Squared
        Glu.GLUquadric quadratic;
        //Glu.GLUquadricObj quadratic;

        void Drawer()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);//glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // Clear Screen And Depth Buffer
            Gl.glLoadIdentity();//glLoadIdentity(); // Reset The Current Modelview Matrix
            Gl.glTranslatef(-1.5f, 0.0f, -6.0f);//glTranslatef(-1.5f, 0.0f, -6.0f); // Move Left 1.5 Units And Into The Screen 6.0
            Gl.glPushMatrix();//glPushMatrix(); // NEW: Prepare Dynamic Transform

            clMatrix.Matrix4fT Transform = new clMatrix.Matrix4fT
                                               {
                                                   M = new float[]
                                                           {
                                                               1.0f, 0.0f, 0.0f, 0.0f, // NEW: Final Transform
                                                               0.0f, 1.0f, 0.0f, 0.0f,
                                                               0.0f, 0.0f, 1.0f, 0.0f,
                                                               0.0f, 0.0f, 0.0f, 1.0f
                                                           }
                                               };

            Gl.glMultMatrixf(Transform.M);//glMultMatrixf(Transform.M); // NEW: Apply Dynamic Transform
            Gl.glColor3f(0.75f, 0.75f, 1.0f);//glColor3f(0.75f, 0.75f, 1.0f);
            Torus(0.30f, 1.00f);
            Gl.glPopMatrix();//glPopMatrix(); // NEW: Unapply Dynamic Transform

            Gl.glLoadIdentity(); //glLoadIdentity(); // Reset The Current Modelview Matrix
            Gl.glTranslatef(1.5f, 0.0f, -6.0f); //glTranslatef(1.5f, 0.0f, -6.0f); // Move Right 1.5 Units And Into The Screen 7.0

            Gl.glPushMatrix();//glPushMatrix(); // NEW: Prepare Dynamic Transform
            Gl.glMultMatrixf(Transform.M);//glMultMatrixf(Transform.M); // NEW: Apply Dynamic Transform
            Gl.glColor3f(1.0f, 0.75f, 0.75f);//glColor3f(1.0f, 0.75f, 0.75f);

            quadratic = Glu.gluNewQuadric();										// Create A Pointer To The Quadric Object
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);						// Create Smooth Normals
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);							// Create Texture Coords
            Glu.gluSphere(quadratic, 1.3f, 20, 20);//gluSphere(quadratic, 1.3f, 20, 20);
            Gl.glPopMatrix(); //glPopMatrix(); // NEW: Unapply Dynamic Transform

            Gl.glFlush();//glFlush(); // Flush The GL Rendering Pipeline

            simpleOpenGlControl1.Invalidate();
        }

        

    }
}
