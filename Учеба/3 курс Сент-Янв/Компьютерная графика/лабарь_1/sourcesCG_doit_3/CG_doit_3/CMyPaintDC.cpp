#include "MyClassesDeclarations.h"
#include <math.h>

#define fpart(x)  (x-floor(x))
#define round(x) floor(x + 0.5)
#define ipart(x)  floor(x)

CMyPaintDC::CMyPaintDC(CWnd* pWnd):CPaintDC(pWnd)           
{
}
void CMyPaintDC::DrawHead()
{
    SetTextColor(RGB(250,0,0));
	TextOut(5,5, "Математический"  );
    SetTextColor(RGB(0,200,0));
	TextOut(125,5, "Рекуретный"	  );
    SetTextColor(RGB(134,77,159));
	TextOut(220,5,"Брезенхеймский"  );
    SetTextColor(RGB(0,0,0));
	TextOut(350,5, "Встроенный");
	SetTextColor(RGB(0,0,250));
	TextOut(480,5, "Ву");

	SetTextColor(RGB(0,0,0));
	
}
 void CMyPaintDC::DrawLineMath(double x1,double x2,double y1,double y2)
 {
	double x,m,a;
	//int value;

	m = (y1 - y2)/(x1 - x2);
	a = y1 - m*x1;
	for(x = x1; x<x2; x++){
		SetPixel(round(x),round(a + m*x),RGB(200,0,0));
	}

 }
 void CMyPaintDC::DrawLineRecur(double x1,double x2,double y1,double y2)
 {
  double x,y,dy,dx,m,dm;

  if(x1!=x2)
  {dy = y2 - y1;
   dx = x2 - x1;
   m = dy/dx;

   if(m<=1)
   {
	y = y1;
	for(x = x1;x < x2; x++)
	{
	   SetPixel(int(x),int(y),RGB(0,250,0));
	   y = y + m;
	}
   }
   else
   {
	x = x1;
	dm = 1/m;
	for(y = y1;y < y2; y++)
	{
	   SetPixel(int(x),int(y),RGB(0,250,0));
	   x = x + dm;
	}
   }
  }
  else if(y1 == y2)
  {
	  SetPixel(int(x1),int(y1),RGB(0,250,0));
  }
  else return;
 }
 void CMyPaintDC::DrawLineBrezen(int x1,int x2,int y1,int y2)
 {
  int dx, dy, d, incr1, incr2, x, y, Xend;

  dx = abs(x2 - x1);
  dy = abs(y2 - y1);

 if(dx>=dy)
 {
  d = 2*dy - dx;
  incr1 = 2*dy;
  incr2 = 2*(dy - dx);
  if(x1>x2)
  {x = x2;
   y = y2;
   Xend = x1;
  }
  else
  {x = x1;
   y = y1;
   Xend = x2;
  }
  SetPixel(x1,y1,RGB(134,77,159));
  while(x<Xend)
  {
	  x++;
	  if(d<0) d = d + incr1;
	  else{
		  y++;
		  d = d + incr2;
	  }
	  SetPixel(x,y,RGB(134,77,159));
  }
 }

 else
{
  d = 2*dx - dy;
  incr1 = 2*dx;
  incr2 = 2*(dx - dy);
  if(y1>y2)
  {x = x2;
   y = y2;
   Xend = y1;
  }
  else
  {x = x1;
   y = y1;
   Xend = y2;
  }
  SetPixel(x1,y1,RGB(134,77,159));
  while(y<Xend)
  {
	  y++;
	  if(d<0) d = d + incr1;
	  else{
		  x++;
		  d = d + incr2;
	  }
	  SetPixel(x,y,RGB(134,77,159));
  }
}
 }

void CMyPaintDC::DrawLineVu(double x1,double x2,double y1,double y2)
{
float t;
	if(x2<x1){
		t = x1;x1=x2;x2=t;
		t = y1;y1=y2;y2=t;
	}
	double dx = x2-x1,
		dy = y2-y1;
	double gradient = dy/dx;  

   // обработать первую точку
   double xend = round(x1); 
   double yend = y1 + gradient*(xend - x1);
   double xgap = 1 - fpart(x1 + 0.5);
   double xpxl1 = xend;  // будет использоваться в основном цикле
   double ypxl1 = ipart(yend);
   SetPixel(xpxl1,ypxl1,RGB(250*(fpart(yend)*xgap),250*(fpart(yend)*xgap),250));//draw_point(xpxl1, ypxl1, 1 - fpart(yend) × xgap)
   SetPixel(xpxl1,ypxl1 + 1, RGB(250* (1 - (fpart(yend) * xgap)),250 * (1-(fpart(yend) * xgap)),250));// draw_point(xpxl1, ypxl1 + 1, fpart(yend) × xgap)
   double intery = yend + gradient; // первое y-пересечение для основоного цикла
        
   // обработать вторую точку
   xend = round(x2);
   yend = y2 + gradient * (xend - x2);
   xgap = fpart(x2 + 0.5);
   double xpxl2 = xend;  // будет использоваться в основном цикле
   double ypxl2 = ipart(yend);
   //SetPixel(xpxl2, ypxl2, RGB(250 *( fpart(yend) * xgap),250 *(fpart(yend) * xgap),250));
   //SetPixel(xpxl2, ypxl2 + 1, RGB(250 *(1- (fpart(yend) * xgap)),250 *(1-(fpart(yend) * xgap)),250));
    
   // основной цикл
   int x;
   for(x = xpxl1 + 1;x<xpxl2 - 1;x++)
   {
           SetPixel(x, ipart(intery),		RGB(250 *( fpart(intery)),250 *( fpart(intery)),250));
           SetPixel(x, ipart(intery) + 1,	RGB(250 * (1-fpart(intery)), 250 *(1- fpart(intery)),250));
           intery = intery + gradient;
   }


}