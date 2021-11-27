#include "stdafx.h"
#include <windows.h>
#include<gl\GL.h>
#include<math.h>
#include <glut.h>

const int screenWidth = 640;
const int screenHeight = 480;

GLdouble f(GLdouble x, GLdouble z, GLdouble a1){
	GLdouble a = pow(x-3.14, 2)+pow(z-3.14, 2);
	GLdouble //a1 = 0.8,
		a2 = -3,
		a3 = 1;
	return a1*sin(x)*cos(z)-a2*cos(a3*a)*exp(-a);
}

void myInit(void){
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glColor3f(1.0f, 0.0f, 1.0f);
	glPointSize(1.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0.0, 640.0, 0.0, 480.0);
}

void myDisplay(void){
	glClear(GL_COLOR_BUFFER_BIT);
	GLdouble A, B, C, D, x;
	//GLint n=628;
	GLdouble Ymin[628], Ymax[628];
	A = screenWidth/6.28;
	B = 0;//screenWidth/2.0;
	C = screenHeight/6.28;
	D = screenHeight/2.0;
	glBegin(GL_POINTS);
	for(int i = 0; i<628; i++)
		Ymin[i]=Ymax[i]=C*f(i*0.01, 0, 0.2)+D;
	int j=0;
	GLdouble a1=0.2;
	//for(GLdouble a1 = 0.1; a1<=0.9; a1+=0.05){

		for(int i = 0; i<628; i++)//координаты самой первой кривой
			Ymin[i]=Ymax[i]=C*f(i*0.01, 0, 0.2)+D;

		for(x=0, j=0; x<=6.28, j<628; x+=0.01, j++)
		{
			for(GLdouble z=0.1; z<=6.28; z+=0.1)
			{
				//glColor3f(1, 0, 1);
					if((C*f(x, z, a1)+D)>=Ymax[j])
					{
						Ymax[j]=(C*f(x, z, a1)+D);
						glColor3f(1, 0, 1);
						glVertex2d(A*x+B, C*f(x, z, a1)+D);
					}
					else if((C*f(x, z, a1)+D)<=Ymin[j])
					{
						Ymin[j]=(C*f(x, z, a1)+D);
						glColor3f(1, 1, 0);
						glVertex2d(A*x+B, C*f(x, z, a1)+D);
					}

			}		
		}		
	//}
	glEnd();
	glFlush();
}


int main(int argc, char **argv)
{
glutInit(&argc,argv);
glutInitDisplayMode(GLUT_SINGLE|GLUT_RGB);
glutInitWindowSize(640,480);		//Указываем размер окна
glutInitWindowPosition(50,50);	//Позиция окна
glutCreateWindow("Window");		//Имя окна
glutDisplayFunc(myDisplay);				//Вызов функции отрисовки
//glutReshapeFunc(myReshape);
//glutMouseFunc(myMouse);
//glutKeyboardFunc(myKeyboard);

myInit();
glutMainLoop();

return 0;
}
