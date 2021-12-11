using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ConsoleApplication1
{
    class Program
    {
        private static int Width = 512;
        private static int Height = 512;
        private static double alpha = 0, betta = 0, gamma = 0;

        static void Display()
        {
            Gl.glClearColor(1, 1, 1, 1);//Цвет фона
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3b(0, 0, 0);//цвет фигуры

            Gl.glPushMatrix();//Обязательная хрень
            Gl.glTranslated(5, 5, 0);
            Gl.glRotated(5 * alpha, 0, 0, 1);//1,0,0 [клавиша 2-4/8]
            Gl.glRotated(5 * betta, 0, 1, 0);//Клавиша 6
            Gl.glRotated(5 * gamma, 1, 0, 0);//Клавиша TAB (-/+Y)

            //Glut.glutWireTorus - бублик
            //Wire проволочн модель\ Solid сплошная модель
            //Gl.glScaled(1,1,1);
            Glut.glutSolidTorus(0.5, 2.2, 32, 32);

            Gl.glRotated(45, 1, 1, 0);//!Локальная система координат для КОНУСА!
            Gl.glTranslated(1, -1.2, 1.5);
            Gl.glRotated(5 * alpha, 0, 0, 1);//Клавиши 2-4-8
            Gl.glRotated(5 * betta, 0, 1, 0);//Клавиша 6 (-/+Х)
            Gl.glRotated(5 * gamma, 0, 0, 1);//Клавиша TAB (-/+Y)
            Glut.glutSolidCone(0.5, 4.2, 32, 32);//конус
            Gl.glPopMatrix();
            Gl.glFinish();
        }
        static void Reshape(int w, int h)
        {
            Width = w;
            Height = h;
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, 10, 0, 10, -10, 10);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
        static void Keyboard(byte key, int x, int y)
        {
            const int esc = 27;
            if (key == esc)
                Glut.glutLeaveMainLoop();
            const int w = 56;
            if (key == w)
                alpha += 0.1;
            const int s = 50;
            if (key == s)
                alpha -= 0.1;
            const int a = 52;
            if (key == a)
                alpha += 0.1;
            const int d = 54;
            if (key == d)
                betta -= 0.1;
            const int tilda = 126;
            if (key == tilda)
                gamma += 0.1;
            const int tab = 9;
            if (key == tab)
                gamma -= 0.1;
            Glut.glutPostRedisplay();
        }
        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE);
            
            Glut.glutInitWindowPosition(0, 0);
            Glut.glutInitWindowSize(Width, Height);
            Glut.glutCreateWindow("Upravlenie: Tab, 2, 4, 6, 8. Esc = exit");

            init(args.Length, args);
            Glut.glutDisplayFunc(draw);
            Glut.glutReshapeFunc(reshape);
            Glut.glutKeyboardFunc(Key);
            Glut.glutSpecialFunc(special);
            Glut.glutVisibilityFunc(visible);
            update_idle_func();
            Glut.glutMainLoop();
        }


        static int T0 = 0;
        static int Frames = 0;
        static int autoexit = 0;
        static int win = 0;
        static bool Visible = true;
        static bool Animate = true;
        static float viewDist = 40.0f;
        private const float M_PI = 3.14159265f;

        static float cos(float angl)
        {
            return (float)Math.Cos(angl);
        }

        static float sin(float angl)
        {
            return (float)Math.Sin(angl);
        }

        static float sqrt(float value)
        {
            return (float)Math.Sqrt(value);
        }

        static void gear(float inner_radius, float outer_radius, float width, int teeth, float tooth_depth)
        {
            int i;
            float r0, r1, r2;
            float angle, da;
            float u, v, len;

            r0 = inner_radius;
            r1 = outer_radius - tooth_depth / 2.0f;
            r2 = outer_radius + tooth_depth / 2.0f;

            da = 2.0f * 3.14159265f / teeth / 4.0f;

            Gl.glShadeModel(Gl.GL_FLAT);

            Gl.glNormal3f(0.0f, 0.0f, 1.0f);

            /* draw front face */
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (i = 0; i <= teeth; i++)
            {
                angle = i * 2.0f * M_PI / teeth;
                Gl.glVertex3f(r0 * (float)Math.Cos(angle), r0 * (float)Math.Sin(angle), width * 0.5f);
                Gl.glVertex3f(r1 * (float)Math.Cos(angle), r1 * (float)Math.Sin(angle), width * 0.5f);
                if (i < teeth)
                {
                    Gl.glVertex3f(r0 * cos(angle), r0 * sin(angle), width * 0.5f);
                    Gl.glVertex3f(r1 * cos(angle + 3 * da), r1 * sin(angle + 3 * da), width * 0.5f);
                }
            }
            Gl.glEnd();

            /* draw front sides of teeth */
            Gl.glBegin(Gl.GL_QUADS);
            da = 2.0f * M_PI / teeth / 4.0f;
            for (i = 0; i < teeth; i++)
            {
                angle = i * 2.0f * M_PI / teeth;

                Gl.glVertex3f(r1 * cos(angle), r1 * sin(angle), width * 0.5f);
                Gl.glVertex3f(r2 * cos(angle + da), r2 * sin(angle + da), width * 0.5f);
                Gl.glVertex3f(r2 * cos(angle + 2 * da), r2 * sin(angle + 2 * da), width * 0.5f);
                Gl.glVertex3f(r1 * cos(angle + 3 * da), r1 * sin(angle + 3 * da), width * 0.5f);
            }
            Gl.glEnd();

            Gl.glNormal3f(0.0f, 0.0f, -1.0f);

            /* draw back face */
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (i = 0; i <= teeth; i++)
            {
                angle = i * 2.0f * M_PI / teeth;
                Gl.glVertex3f(r1 * cos(angle), r1 * sin(angle), -width * 0.5f);
                Gl.glVertex3f(r0 * cos(angle), r0 * sin(angle), -width * 0.5f);
                if (i < teeth)
                {
                    Gl.glVertex3f(r1 * cos(angle + 3 * da), r1 * sin(angle + 3 * da), -width * 0.5f);
                    Gl.glVertex3f(r0 * cos(angle), r0 * sin(angle), -width * 0.5f);
                }
            }
            Gl.glEnd();

            /* draw back sides of teeth */
            Gl.glBegin(Gl.GL_QUADS);
            da = 2.0f * M_PI / teeth / 4.0f;
            for (i = 0; i < teeth; i++)
            {
                angle = i * 2.0f * M_PI / teeth;

                Gl.glVertex3f(r1 * cos(angle + 3 * da), r1 * sin(angle + 3 * da), -width * 0.5f);
                Gl.glVertex3f(r2 * cos(angle + 2 * da), r2 * sin(angle + 2 * da), -width * 0.5f);
                Gl.glVertex3f(r2 * cos(angle + da), r2 * sin(angle + da), -width * 0.5f);
                Gl.glVertex3f(r1 * cos(angle), r1 * sin(angle), -width * 0.5f);
            }
            Gl.glEnd();

            /* draw outward faces of teeth */
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (i = 0; i < teeth; i++)
            {
                angle = i * 2.0f * M_PI / teeth;

                Gl.glVertex3f(r1 * cos(angle), r1 * sin(angle), width * 0.5f);
                Gl.glVertex3f(r1 * cos(angle), r1 * sin(angle), -width * 0.5f);
                u = r2 * cos(angle + da) - r1 * cos(angle);
                v = r2 * sin(angle + da) - r1 * sin(angle);
                len = sqrt(u * u + v * v);
                u /= len;
                v /= len;
                Gl.glNormal3f(v, -u, 0.0f);
                Gl.glVertex3f(r2 * cos(angle + da), r2 * sin(angle + da), width * 0.5f);
                Gl.glVertex3f(r2 * cos(angle + da), r2 * sin(angle + da), -width * 0.5f);
                Gl.glNormal3f(cos(angle), sin(angle), 0.0f);
                Gl.glVertex3f(r2 * cos(angle + 2 * da), r2 * sin(angle + 2 * da), width * 0.5f);
                Gl.glVertex3f(r2 * cos(angle + 2 * da), r2 * sin(angle + 2 * da), -width * 0.5f);
                u = r1 * cos(angle + 3 * da) - r2 * cos(angle + 2 * da);
                v = r1 * sin(angle + 3 * da) - r2 * sin(angle + 2 * da);
                Gl.glNormal3f(v, -u, 0.0f);
                Gl.glVertex3f(r1 * cos(angle + 3 * da), r1 * sin(angle + 3 * da), width * 0.5f);
                Gl.glVertex3f(r1 * cos(angle + 3 * da), r1 * sin(angle + 3 * da), -width * 0.5f);
                Gl.glNormal3f(cos(angle), sin(angle), 0.0f);
            }

            Gl.glVertex3f(r1 * cos(0), r1 * sin(0), width * 0.5f);
            Gl.glVertex3f(r1 * cos(0), r1 * sin(0), -width * 0.5f);

            Gl.glEnd();

            Gl.glShadeModel(Gl.GL_SMOOTH);

            /* draw inside radius cylinder */
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (i = 0; i <= teeth; i++)
            {
                angle = i * 2.0f * M_PI / teeth;
                Gl.glNormal3f(-cos(angle), -sin(angle), 0.0f);
                Gl.glVertex3f(r0 * cos(angle), r0 * sin(angle), -width * 0.5f);
                Gl.glVertex3f(r0 * cos(angle), r0 * sin(angle), width * 0.5f);
            }
            Gl.glEnd();

        }

        private static float view_rotx = 20.0f;
        private static float view_roty = 30.0f; static float view_rotz = 0.0f;
        private static int gear1, gear2, gear3;
        private static float angle = 0.0f;

        static void cleanup()
        {
            Gl.glDeleteLists(gear1, 1);
            Gl.glDeleteLists(gear2, 1);
            Gl.glDeleteLists(gear3, 1);
            Glut.glutDestroyWindow(win);
        }

        static void draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();

            Gl.glTranslatef(0.0f, 0.0f, -viewDist);

            Gl.glRotatef(view_rotx, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(view_roty, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(view_rotz, 0.0f, 0.0f, 1.0f);

            Gl.glPushMatrix();
            Gl.glTranslatef(-3.0f, -2.0f, 0.0f);
            Gl.glRotatef(angle, 0.0f, 0.0f, 1.0f);
            Gl.glCallList(gear1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(3.1f, -2.0f, 0.0f);
            Gl.glRotatef(-2.0f * angle - 9.0f, 0.0f, 0.0f, 1.0f);
            Gl.glCallList(gear2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-3.1f, 4.2f, 0.0f);
            Gl.glRotatef(-2.0f * angle - 25.0f, 0.0f, 0.0f, 1.0f);
            Gl.glCallList(gear3);
            Gl.glPopMatrix();

            Gl.glPopMatrix();

            Glut.glutSwapBuffers();

            Frames++;

            {//раз в пять сек выводить колич фреймов
                int t = Glut.glutGet(Glut.GLUT_ELAPSED_TIME);
                if (t - T0 >= 5000)
                {
                    float seconds = (t - T0) / 1000.0f;
                    float fps = Frames / seconds;
                    Console.WriteLine("{0} frames in {1} seconds = {2} FPS\n", Frames, seconds, fps);
                    //fflush(stdout);
                    T0 = t;
                    Frames = 0;
                    if ((t >= 999.0 * autoexit) && (autoexit == 1))
                    {
                        cleanup();
                        //exit(0);
                    }
                }
            }
        }

        /// <summary>
        /// Вращение шестеренок
        /// </summary>
        static void idle()
        {
            double t0 = -1.0;
            double t = Glut.glutGet(Glut.GLUT_ELAPSED_TIME) / 1000.0;
            float dt = (float)t;
            if (t0 > 0.0) t0 = t;

            dt = (float)(t - t0);
            t0 = t;

            angle += 70.0f * dt; /* 70 degrees per second */
            angle = (angle%360.0f); /* prevents eventual overflow */
            //перерисовка
            Glut.glutPostRedisplay();
        }

        static void update_idle_func()
        {
            if (Visible && Animate)
                Glut.glutIdleFunc(idle);
            else
                Glut.glutIdleFunc(null);
        }

        /* change view angle, exit upon ESC */
        /* ARGSUSED1 */
        static void Key(byte key, int x, int y)
        {
            const int esc = 27;
            const int w = 56;
            const int s = 50;
            const int a = 244;
            const int d = 54;
            const int tilda = 126;
            const int tab = 9;

            switch (key)
            {
                case w://вращать в право
                    view_rotz += 5.0f;
                    break;
                case tab://вращать в лево
                    view_rotz -= 5.0f;
                    break;
                case d://уменьшать обьект
                    viewDist += 1.0f;
                    break;
                case s://увеличить обьект
                    viewDist -= 1.0f;
                    break;
                case a://непонятная хрень
                    Animate = !Animate;
                    update_idle_func();
                    break;
                case 27: /* Escape */
                    cleanup();
                    Glut.glutLeaveMainLoop();
                    break;
                
            }
            Glut.glutPostRedisplay();
        }

        /* change view angle */
        /* ARGSUSED1 */
        static void special(int k, int x, int y)
        {
            switch (k)
            {
                case Glut.GLUT_KEY_UP:
                    view_rotx += 5.0f;
                    break;
                case Glut.GLUT_KEY_DOWN:
                    view_rotx -= 5.0f;
                    break;
                case Glut.GLUT_KEY_LEFT:
                    view_roty += 5.0f;
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    view_roty -= 5.0f;
                    break;
                default:
                    return;
            }
            Glut.glutPostRedisplay();
        }

        /* new window size or exposure */
        static void reshape(int width, int height)
        {
            float h = (float)height / (float)width;

            Gl.glViewport(0, 0, (int)width, (int)height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-1.0, 1.0, -h, h, 5.0, 200.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        static void init(int argc, string [] argv)
        {

            var pos = new float[] { 5.0f, 5.0f, 10.0f, 0.0f };
            var red = new[] { 0.8f, 0.1f, 0.0f, 1.0f };
            var green = new[] { 0.0f, 0.8f, 0.2f, 1.0f };
            var blue = new[] { 0.2f, 0.2f, 1.0f, 1.0f };
            int i;

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glEnable(Gl.GL_CULL_FACE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            /* make the gears */
            gear1 = Gl.glGenLists(1);
            Gl.glNewList(gear1, Gl.GL_COMPILE);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, red);
            gear(1.0f, 4.0f, 1.0f, 20, 0.7f);
            Gl.glEndList();

            gear2 = Gl.glGenLists(1);
            Gl.glNewList(gear2, Gl.GL_COMPILE);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, green);
            gear(0.5f, 2.0f, 2.0f, 10, 0.7f);
            Gl.glEndList();

            gear3 = Gl.glGenLists(1);
            Gl.glNewList(gear3, Gl.GL_COMPILE);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE, blue);
            gear(1.3f, 2.0f, 0.5f, 10, 0.7f);
            Gl.glEndList();

            Gl.glEnable(Gl.GL_NORMALIZE);

            for (i = 1; i < argc; i++)
            {
                if (argv[i].CompareTo("-info") == 0)
                {

                    //printf("GL_RENDERER   = %s\n", (char*)glGetString(GL_RENDERER));
                    //printf("GL_VERSION    = %s\n", (char*)glGetString(GL_VERSION));
                    //printf("GL_VENDOR     = %s\n", (char*)glGetString(GL_VENDOR));
                    //printf("GL_EXTENSIONS = %s\n", (char*)glGetString(GL_EXTENSIONS));
                }
                else if (argv[i].CompareTo("-exit") == 0)
                {
                    autoexit = 30;
                    //printf("Auto Exit after %i seconds.\n", autoexit);
                }
            }
        }

        static void visible(int vis)
        {
            Visible = vis == 1 ? true : false;
            update_idle_func();
        }

    }
}
