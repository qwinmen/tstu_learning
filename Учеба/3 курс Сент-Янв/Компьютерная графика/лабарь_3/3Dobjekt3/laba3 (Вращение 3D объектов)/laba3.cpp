#include <math.h>
#include <stdio.h>
#include <windows.h>

#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/glaux.h>

#define pi 3.14159265358979323846
#define a1 20
#define a2 20
#define sk 0.5
#define l 1
#define la 30.0

struct tochka
{double x;
 double y;
 double z;
};

unsigned int t1;
AUX_RGBImageRec* t11;

unsigned int t2;
AUX_RGBImageRec* t22;

unsigned int t3;
AUX_RGBImageRec* t33;

unsigned int te;
AUX_RGBImageRec* tee;

double d=5,sc=0.1,al=0,mash=1.0;
int pokpvo=0,shod=1,hav=1,p=-3,ik=0;

struct tochka kub[14]={{-3,-3,-3},{-3,3,-3},{3,3,-3},{3,-3,-3},{-3,-3,3},{-3,3,3},{3,3,3},{3,-3,3},{-0.05,9,0.05},{-0.05,-9,0.05},{-9,0,0.2},{9,0,0.2},{0,0,9},{0,0,-9}};
struct tochka kuby[14]={{-3,-3,-3},{-3,3,-3},{3,3,-3},{3,-3,-3},{-3,-3,3},{-3,3,3},{3,3,3},{3,-3,3},{-0.05,9,0.05},{-0.05,-9,0.05},{-9,0,0.2},{9,0,0.2},{0,0,9},{0,0,-9}};
struct tochka kubz[14]={{-3,-3,-3},{-3,3,-3},{3,3,-3},{3,-3,-3},{-3,-3,3},{-3,3,3},{3,3,3},{3,-3,3},{-0.05,9,0.05},{-0.05,-9,0.05},{-9,0,0.2},{9,0,0.2},{0,0,9},{0,0,-9}};
struct tochka osi[4]={{0,0,0},{500,0,0},{0,500,0},{0,0,500}};

double alpha=0, beta=0; 
double bet=0;
void refresh(void);

void CALLBACK mouse(AUX_EVENTREC *event)
{
static int x0,y0=-12345; 
if(y0!=-12345)
{
alpha += event->data[AUX_MOUSEX] - x0;
beta += event->data[AUX_MOUSEY] - y0;
}
x0 = event->data[AUX_MOUSEX];
y0 = event->data[AUX_MOUSEY];
}
//x=-1.750000  y=-1.750000  z=3.000000


void CALLBACK resize(int width,int height)
{
   glViewport(0,0,width,height);
   glMatrixMode( GL_PROJECTION );
   glLoadIdentity();
   glOrtho(-15,15, -15,15, 2,120);   
   gluLookAt( 0,0,5, 0,0,0, 0,1,0 );
   glMatrixMode(GL_MODELVIEW);
}    

void viewkub(struct tochka *kub)
{int i;
 double k1,k2;
 struct tochka kub1[14];
 for(i=0;i<14;i++) kub1[i]=kub[i];

 ///////////////////////////////////////////////////////////////
 for(i=0;i<14;i++)   
	{kub1[i].x=kub1[i].x*cos(a1*pi/180)+kub1[i].z*sin(a1*pi/180);
	 kub1[i].z=-kub1[i].x*sin(a1*pi/180)+kub1[i].z*cos(a1*pi/180);
	}

 for(i=0;i<14;i++)   
	{kub1[i].y=kub1[i].y*cos(a2*pi/180)+kub1[i].z*sin(a2*pi/180);
	 kub1[i].z=-kub1[i].y*sin(a2*pi/180)+kub1[i].z*cos(a2*pi/180);
	}
//////////////////////////////////////////////////////////////
k1=l*cos(la);
k2=l*sin(la);

 
 ///////////////////////////////////////////New Point (8)

 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[8].x+kub1[8].z*k1,kub1[8].y+kub1[8].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glVertex2d(kub1[8].x+kub1[8].z*k1,kub1[8].y+kub1[8].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[8].x+kub1[8].z*k1,kub1[8].y+kub1[8].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glVertex2d(kub1[8].x+kub1[8].z*k1,kub1[8].y+kub1[8].z*k2);
 glEnd();

  ///////////////////////////////////////////New Point (9)

 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[9].x+kub1[9].z*k1,kub1[9].y+kub1[9].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[9].x+kub1[9].z*k1,kub1[9].y+kub1[9].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glVertex2d(kub1[9].x+kub1[9].z*k1,kub1[9].y+kub1[9].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glVertex2d(kub1[9].x+kub1[9].z*k1,kub1[9].y+kub1[9].z*k2);
 glEnd();

 ///////////////////////////////////////////New Point (10)

 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[10].x+kub1[10].z*k1,kub1[10].y+kub1[10].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[10].x+kub1[10].z*k1,kub1[10].y+kub1[10].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[10].x+kub1[10].z*k1,kub1[10].y+kub1[10].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glVertex2d(kub1[10].x+kub1[10].z*k1,kub1[10].y+kub1[10].z*k2);
 glEnd();

 ///////////////////////////////////////////New Point (11)

 glBegin(GL_LINES);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glVertex2d(kub1[11].x+kub1[11].z*k1,kub1[11].y+kub1[11].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[11].x+kub1[11].z*k1,kub1[11].y+kub1[11].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glVertex2d(kub1[11].x+kub1[11].z*k1,kub1[11].y+kub1[11].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glVertex2d(kub1[11].x+kub1[11].z*k1,kub1[11].y+kub1[11].z*k2);
 glEnd();

 ///////////////////////////////////////////New Point (12)

 glBegin(GL_LINES);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glVertex2d(kub1[12].x+kub1[12].z*k1,kub1[12].y+kub1[12].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[12].x+kub1[12].z*k1,kub1[12].y+kub1[12].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glVertex2d(kub1[12].x+kub1[12].z*k1,kub1[12].y+kub1[12].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glVertex2d(kub1[12].x+kub1[12].z*k1,kub1[12].y+kub1[12].z*k2);
 glEnd();

 ///////////////////////////////////////////New Point (13)

 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[13].x+kub1[13].z*k1,kub1[13].y+kub1[13].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[13].x+kub1[13].z*k1,kub1[13].y+kub1[13].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glVertex2d(kub1[13].x+kub1[13].z*k1,kub1[13].y+kub1[13].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[13].x+kub1[13].z*k1,kub1[13].y+kub1[13].z*k2);
 glEnd();

  ////////////////////////////////// line 8-9
 
 glBegin(GL_LINES);
 glVertex2d(kub1[8].x+kub1[8].z*k1,kub1[8].y+kub1[8].z*k2);
 glVertex2d(kub1[9].x+kub1[9].z*k1,kub1[9].y+kub1[9].z*k2);
 glEnd();

 ////////////////////////////////// line 10-11
 
 glBegin(GL_LINES);
 glVertex2d(kub1[10].x+kub1[10].z*k1,kub1[10].y+kub1[10].z*k2);
 glVertex2d(kub1[11].x+kub1[11].z*k1,kub1[11].y+kub1[11].z*k2);
 glEnd();

 ////////////////////////////////// line 12-13
 
 glBegin(GL_LINES);
 glVertex2d(kub1[12].x+kub1[12].z*k1,kub1[12].y+kub1[12].z*k2);
 glVertex2d(kub1[13].x+kub1[13].z*k1,kub1[13].y+kub1[13].z*k2);
 glEnd();
 


/*
  //1 т
 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glEnd();

 //2
 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glEnd();


 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glEnd();

  glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glEnd();
/*
 ///////////////////////////// диагональ
 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glEnd();
 
 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glEnd();
 
 glBegin(GL_LINES);
 glVertex2d(kub1[1].x+kub1[1].z*k1,kub1[1].y+kub1[1].z*k2);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glVertex2d(kub1[2].x+kub1[2].z*k1,kub1[2].y+kub1[2].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[6].x+kub1[6].z*k1,kub1[6].y+kub1[6].z*k2);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[5].x+kub1[5].z*k1,kub1[5].y+kub1[5].z*k2);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[0].x+kub1[0].z*k1,kub1[0].y+kub1[0].z*k2);
 glVertex2d(kub1[7].x+kub1[7].z*k1,kub1[7].y+kub1[7].z*k2);
 glEnd();

 glBegin(GL_LINES);
 glVertex2d(kub1[3].x+kub1[3].z*k1,kub1[3].y+kub1[3].z*k2);
 glVertex2d(kub1[4].x+kub1[4].z*k1,kub1[4].y+kub1[4].z*k2);
 glEnd(); */
}


void povorot(struct tochka *kub)
{int i,k;
 
for(k=0;k<20;k++) 
 for(i=0;i<14;i++) 
	{kub[i].y=kub[i].y*cos(0.005)-kub[i].z*sin(0.005);
	 kub[i].z=kub[i].y*sin(0.005)+kub[i].z*cos(0.005);
	}

 }

void povoroty(struct tochka *kub)
{int i,k;
 

for(k=0;k<20;k++)
 for(i=0;i<14;i++)
	{kub[i].x=kub[i].x*cos(0.005)+kub[i].z*sin(0.005);
	 kub[i].z=-kub[i].x*sin(0.005)+kub[i].z*cos(0.005);
	}

}

void povorotz(struct tochka *kub)
{int i,k;
 
for(k=0;k<20;k++)
 for(i=0;i<14;i++) 
	{kub[i].x=kub[i].x*cos(0.005)-kub[i].y*sin(0.005);
	 kub[i].y=kub[i].x*sin(0.005)+kub[i].y*cos(0.005);
	}

 }

 

  ///////////			  0         1          2		3		4			5		6		7
//struct tochka kub[14]={{-3,-3,-3},{-3,3,-3},{3,3,-3},{3,-3,-3},{-3,-3,3},{-3,3,3},{3,3,3},{3,-3,3},{5,5,5}};
void refresh(void)
{
 kub[0].x=kub[0].y=kub[0].z=kub[1].x=kub[1].z=kub[2].z=kub[3].z=kub[3].y=kub[4].x=kub[4].y=kub[5].x=kub[7].y=-3;
 kub[1].y=kub[2].y=kub[2].x=kub[3].x=kub[4].z=kub[5].z=kub[5].y=kub[6].y=kub[6].x=kub[6].z=kub[7].x=kub[7].z=-3;
 kuby[0].x=kuby[0].y=kuby[0].z=kuby[1].x=kuby[1].z=kuby[2].z=kuby[3].z=kuby[3].y=kuby[4].x=kuby[4].y=kuby[5].x=kuby[7].y=-3;
 kuby[1].y=kuby[2].y=kuby[2].x=kuby[3].x=kuby[4].z=kuby[5].z=kuby[5].y=kuby[6].y=kuby[6].x=kuby[6].z=kuby[7].x=kuby[7].z=-3;
 kubz[0].x=kubz[0].y=kubz[0].z=kubz[1].x=kubz[1].z=kubz[2].z=kubz[3].z=kubz[3].y=kubz[4].x=kubz[4].y=kubz[5].x=kubz[7].y=-3;
 kubz[1].y=kubz[2].y=kubz[2].x=kubz[3].x=kubz[4].z=kubz[5].z=kubz[5].y=kubz[6].y=kubz[6].x=kubz[6].z=kubz[7].x=kubz[7].z=-3;
}

void CALLBACK display(void)
{
	int i=0,k=0;
	static int time = 0;
 
 glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT );
 
 SetCursor(NULL);
 glPushMatrix();
 glRotated(time/100, 0.0, 0.0, 0.0);
 glRotated(alpha, 0,1,0);
 glRotated(beta, -1,0,0);
 glTranslated(0,0,bet);
 if(p==-3)
 {if(ik<3)
 {
  glEnable(GL_TEXTURE_2D);
  glBindTexture(GL_TEXTURE_2D, t3);
  glBegin(GL_POLYGON);
  glTexCoord2d(0,0); glVertex2d(-15,-15);
  glTexCoord2d(0,1); glVertex2d(-15,15);
  glTexCoord2d(1,1); glVertex2d(15,15);
  glTexCoord2d(1,0); glVertex2d(15,-15);
  glEnd();
  ik++;
  glDisable(GL_TEXTURE_2D);
 }
 else if(ik<6)
 {
  glEnable(GL_TEXTURE_2D);
  glBindTexture(GL_TEXTURE_2D, t2);
  glBegin(GL_POLYGON);
  glTexCoord2d(0,0); glVertex2d(-15,-15);
  glTexCoord2d(0,1); glVertex2d(-15,15);
  glTexCoord2d(1,1); glVertex2d(15,15);
  glTexCoord2d(1,0); glVertex2d(15,-15);
  glEnd();
  ik++;
  glDisable(GL_TEXTURE_2D);
 }
 else if(ik<9)
 {glEnable(GL_TEXTURE_2D);
  glBindTexture(GL_TEXTURE_2D, t1);
  glBegin(GL_POLYGON);
  glTexCoord2d(0,0); glVertex2d(-15,-15);
  glTexCoord2d(0,1); glVertex2d(-15,15);
  glTexCoord2d(1,1); glVertex2d(15,15);
  glTexCoord2d(1,0); glVertex2d(15,-15);
  glEnd();
  ik++;
  glDisable(GL_TEXTURE_2D);
 }
 else p=0;
 }

 else if(ik<200)
 {
//////////////////////////////////////////////////////////////////////////////////////////////////
if(p==0 && kub[0].x>-15)
	{for(i=0;i<14;i++)
		{kub[i].x-=sk/2;
		 kuby[i].y-=sk/2;
		 kubz[i].z+=sk/2;
		}
	}
else if(kub[0].x<=-15 && p==0) p=1;
if(p==1 && kub[0].x<-3)
	{for(i=0;i<14;i++)
		{kub[i].x+=sk/2;
		 kuby[i].y+=sk/2;
		 kubz[i].z-=sk/2;
		}
	}
else if(kub[0].x>=-3 && p==1) p=2;
if(p==2 && kub[0].x<-1)
	{for(i=0;i<14;i++)
		{kub[i].x=kub[i].x*(9.8/10.0);
		 kuby[i].y=kuby[i].y*(9.8/10.0);
		 kubz[i].z=kubz[i].z*(9.8/10.0);
		}
	}
else if(kub[0].x>=-1 && p==2) p=3;
if(p==3 && kub[0].x>-3)
	{for(i=0;i<14;i++)

		{kub[i].x=kub[i].x*(10/9.8);
		 kuby[i].y=kuby[i].y*(10.0/9.8);
		 kubz[i].z=kubz[i].z*(10.0/9.8);
		 }
	}
else if(kub[0].x<=-3 && p==3) 
{
	p=4;
}
if(p==4 && kub[0].z>-10)
{for(i=0;i<14;i++)
	{kub[i].z-=sk/2;
	 kubz[i].z+=sk/2;
	}
}
else if(p==4 && kub[0].z<=10) p=5;
if(p==5 && kuby[0].x<-1.5)
{for(i=0;i<14;i++)
	{kuby[i].x=kuby[i].x*(9.8/10.0);
	 kuby[i].y=kuby[i].y*(9.8/10.0);
	 kuby[i].z=kuby[i].z*(9.8/10.0);
	}
 for(i=0;i<14;i++)
	{kub[i].x=kub[i].x*(9.8/10.0);
	 kub[i].y=kub[i].y*(9.8/10.0);
	 kub[i].z=kub[i].z*(9.8/10.0);
	}
 for(i=0;i<14;i++)
	{kubz[i].x=kubz[i].x*(9.8/10.0);
	 kubz[i].y=kubz[i].y*(9.8/10.0);
	 kubz[i].z=kubz[i].z*(9.8/10.0);
	}
}
else if(p==5 && kuby[0].x>=-1.5) p=6;
if(p==6 && kuby[0].x>-10)
{for(i=0;i<14;i++)
		{kuby[i].x-=sk/2;
		 kubz[i].z+=sk/2;
		}
}
if(p==6 && kuby[0].x<=-10) p=7;
if(p==7) {povorot(kuby); povoroty(kub); povorotz(kubz); ik++;}
//////////////////////////////////////////////////////////////////////////////////////////////////

 glLineWidth(2);
 glColor3d(0,1,0);
 viewkub(kub);
 
 glColor3d(1,0,0);
 viewkub(kuby);
 
 glColor3d(0,0,1);
 viewkub(kubz);
 }
 glPopMatrix();

 time++;

 auxSwapBuffers();
}

void main()
{
float ambient[4] = {1, 1, 1, 1};
int i=0;
float pos[4] = {3,3,3,1};
float dir[3] = {-1,-1,-1};


GLfloat mat_specular[] = {1,1,1,1};
auxInitPosition( 0, 0, 1015, 700);
    auxInitDisplayMode( AUX_RGB | AUX_DEPTH | AUX_DOUBLE );
    auxInitWindow( "Лаба №3");
    auxIdleFunc(display);
    auxReshapeFunc(resize);

    glLightModelfv(GL_LIGHT_MODEL_AMBIENT, ambient);

    glEnable(GL_DEPTH_TEST);

    glEnable(GL_COLOR_MATERIAL);

    glEnable(GL_LIGHTING);

    glLightfv(GL_LIGHT0, GL_POSITION, pos);
    glLightfv(GL_LIGHT0, GL_SPOT_DIRECTION, dir);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialf(GL_FRONT, GL_SHININESS, 128.0);

    auxMouseFunc(AUX_LEFTBUTTON, AUX_MOUSELOC, mouse);



    auxMainLoop(display);
}