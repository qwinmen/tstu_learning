        #region gears.c
        
        static int T0 = 0;
        static int Frames = 0;
        static int autoexit = 0;
        static int win = 0;
        static bool Visible = true;
        static bool Animate = true;
        static float viewDist = 40.0f;
        private const float M_PI = 3.14159265f;

        float cos(float angl)
        {
            return (float)Math.Cos(angl);
        }

        float sin(float angl)
        {
            return (float)Math.Sin(angl);
        }

        float sqrt(float value)
        {
            return (float)Math.Sqrt(value);
        }

        void gear(float inner_radius, float outer_radius, float width, int teeth, float tooth_depth)
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
        private float view_roty = 30.0f;float view_rotz = 0.0f;
        private static int gear1, gear2, gear3;
        private static float angle = 0.0f;

        private void cleanup()
        {
            Gl.glDeleteLists(gear1, 1);
            Gl.glDeleteLists(gear2, 1);
            Gl.glDeleteLists(gear3, 1);
            Glut.glutDestroyWindow(win);
        }

        void draw()
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
            Gl.glRotatef(-2.0f*angle - 9.0f, 0.0f, 0.0f, 1.0f);
            Gl.glCallList(gear2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-3.1f, 4.2f, 0.0f);
            Gl.glRotatef(-2.0f*angle - 25.0f, 0.0f, 0.0f, 1.0f);
            Gl.glCallList(gear3);
            Gl.glPopMatrix();

            Gl.glPopMatrix();

            Glut.glutSwapBuffers();

            Frames++;

            {
                int t = Glut.glutGet(Glut.GLUT_ELAPSED_TIME);
                if (t - T0 >= 5000)
                {
                    float seconds = (t - T0)/1000.0f;
                    float fps = Frames/seconds;
                    label2.Text=String.Format("{0} frames in {1} seconds = {2} FPS\n", Frames, seconds, fps);
                    fflush(stdout);
                    T0 = t;
                    Frames = 0;
                    if ((t >= 999.0*autoexit) && (autoexit==1))
                    {
                        cleanup();
                        exit(0);
                    }
                }
            }
        }

        void idle()
        {
            double t0 = -1.0;
            double t = Glut.glutGet(Glut.GLUT_ELAPSED_TIME)/1000.0;
            float dt = 0f;
            if (t0 < 0.0) t0 = t;

            dt = (float)(t - t0);
            t0 = t;

            angle += 70.0f*dt; /* 70 degrees per second */
            angle = fmod(angle, 360.0); /* prevents eventual overflow */

            Glut.glutPostRedisplay();
        }

        void update_idle_func()
        {
            if (Visible && Animate)
                Glut.glutIdleFunc(idle);
            else
                Glut.glutIdleFunc(null);
        }

        /* change view angle, exit upon ESC */
/* ARGSUSED1 */
        static void Key(byte k, int x, int y)
        {
            switch (k)
            {
                case 'z':
                    view_rotz += 5.0;
                    break;
                case 'Z':
                    view_rotz -= 5.0;
                    break;
                case 'd':
                    viewDist += 1.0;
                    break;
                case 'D':
                    viewDist -= 1.0;
                    break;
                case 'a':
                    Animate = !Animate;
                    update_idle_func();
                    break;
                case 27: /* Escape */
                    cleanup();
                    exit(0);
                    break;
                default:
                    return;
            }
            Glut.glutPostRedisplay();
        }

        /* change view angle */
        /* ARGSUSED1 */
		//Смена положения обьекта
        void special(int k)
        {
            switch (k)
            {
                case Glut.GLUT_KEY_UP:
                    view_rotx += 5.0;
                    break;
                case Glut.GLUT_KEY_DOWN:
                    view_rotx -= 5.0;
                    break;
                case Glut.GLUT_KEY_LEFT:
                    view_roty += 5.0;
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    view_roty -= 5.0;
                    break;
                default:
                    return;
            }
            Glut.glutPostRedisplay();
        }

        /* new window size or exposure */
        void reshape(int width, int height)
        {
            float h = (float)height / (float)width;

            Gl.glViewport(0, 0, (int)width, (int)height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-1.0, 1.0, -h, h, 5.0, 200.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        void init(int argc, char[] argv)
        {

            var pos = new float[] {5.0f, 5.0f, 10.0f, 0.0f};
            var red = new[] {0.8f, 0.1f, 0.0f, 1.0f};
            var green = new[] {0.0f, 0.8f, 0.2f, 1.0f};
            var blue = new[]{0.2f,0.2f,1.0f,1.0f};
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
                    
                    //printf("GL_RENDERER   = %s\n", (char*) glGetString(GL_RENDERER));
                    //printf("GL_VERSION    = %s\n", (char*) glGetString(GL_VERSION));
                    //printf("GL_VENDOR     = %s\n", (char*) glGetString(GL_VENDOR));
                    //printf("GL_EXTENSIONS = %s\n", (char*) glGetString(GL_EXTENSIONS));
                }
                else if ( argv[i].CompareTo("-exit") == 0)
                {
                    autoexit = 30;
                    //printf("Auto Exit after %i seconds.\n", autoexit);
                }
            }
        }

        void visible(int vis)
        {
            Visible = vis==1?true:false;
            update_idle_func();
        }

        private int main(int argc, char[] argv)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE);

            Glut.glutInitWindowPosition(0, 0);
            Glut.glutInitWindowSize(300, 300);
            win = Glut.glutCreateWindow("Gears");
            init(argc, argv);

            Glut.glutDisplayFunc(draw);
            Glut.glutReshapeFunc(reshape);
            Glut.glutKeyboardFunc(Key);
            Glut.glutSpecialFunc(special);
            Glut.glutVisibilityFunc(visible);
            update_idle_func();

            Glut.glutMainLoop();
            return 0; /* ANSI C requires main to return int. */
        }

        #endregion
