#include "MyClassesDeclarations.h"
#include <time.h>
#include <math.h>

void sleep( clock_t wait )
{
   clock_t goal;
   goal = wait + clock();
   while( goal > clock() )
      ;
}

CMyMainWnd::CMyMainWnd()
{
 Create(NULL,"КГ лабраб №3.",WS_OVERLAPPEDWINDOW,CRect(10,10,580,575),NULL,NULL); //
 m_wndMenu.LoadMenu(IDR_MENU1); //
 SetMenu(&m_wndMenu);      //

 Go = false;
 grad = 0;
 mouseDown = 0;
 iNumofline = 400;
 iSpace = 0;
}

BEGIN_MESSAGE_MAP(CMyMainWnd, CFrameWnd)
          ON_WM_MOUSEMOVE( )
          ON_WM_LBUTTONDOWN()
          ON_WM_LBUTTONUP()
          ON_WM_KEYDOWN()
    ON_WM_TIMER()
    ON_WM_PAINT()  
          ON_COMMAND(ID_HELP,MenuHelp)
          ON_COMMAND(ID_EXIT, MenuEXIT)
          ON_COMMAND(IDD_ChangeGrad, MenuChangeGrad)
END_MESSAGE_MAP()


void CMyMainWnd::MenuEXIT()
{
 DestroyWindow();
}
void CMyMainWnd::MenuHelp()
{
          CDialog about(IDD_DIALOG1);
    about.DoModal();
}
void CMyMainWnd::MenuChangeGrad()
{
   CMyDialog about(IDD_DialogChangeGrad,this);
   about.set_gns(grad, iNumofline, iSpace);
   about.DoModal();
   //about.CreateModelessDialog("SampleDialog");


   int t_grad, t_iNumofline, t_iSpace;

   t_grad = about.get_grad();
   t_iNumofline = about.get_numof();
   t_iSpace = about.get_space();

   if(t_grad>=0 && t_grad<90) grad=t_grad;
   if(t_iNumofline>=0) iNumofline=t_iNumofline;
   if(t_iSpace>=0)iSpace=t_iSpace;


   mouseDown = 1;
   InvalidateRect(CRect(10,0,600,575));
  // Invalidate(false);
}

afx_msg void  CMyMainWnd::OnMouseMove(UINT nFlags, CPoint point)
{
          
}
afx_msg void CMyMainWnd::OnLButtonDown(UINT nFlags, CPoint point)
{
 if(Go){ Go = false;
          InvalidateRect(CRect(10,0,600,575));
 }
 else { Go = true;
 Invalidate(false);
 }
mouseDown = 1;
}
afx_msg void CMyMainWnd::OnLButtonUp(UINT nFlags, CPoint point)
{
mouseDown = 0;
}
void CMyMainWnd::OnTimer( UINT uTime)
{
  
}
afx_msg void CMyMainWnd::OnKeyDown( UINT a, UINT b, UINT c)
{
          
}
void CMyMainWnd::OnPaint()
{
          double x1,x2,y1,y2,i,
                              lenght=100;
          const double ONE_GR = 0.017453293;
          char strText[10];
          clock_t a,b;

          CMyPaintDC dc(this);
          dc.DrawHead();

          x1 = 10;
          y1 = 50;

          x2 = x1 + lenght * cos(grad*ONE_GR);
          y2 = y1 + lenght * sin(grad*ONE_GR);

if((Go&&mouseDown)||(Go&&iNumofline<500))
{
          int end = iNumofline*(iSpace+1),
                    T=25,rx1,rx2;

		  rx1=x1;
		  rx2=x2;
          sleep(T);
          a=clock();
          for(i=0;i<end;i=i+1+iSpace)
          {
           dc.DrawLineMath(rx1,rx2,y1+i,y2+i);

          }b=clock();
          itoa((b-a),strText,10);
          dc.TextOut(50,485,strText);

		  rx1 = x1 + 110;
		  rx2 = x2 + 110;
          sleep(T);
          a=clock();
          for(i=0;i<end;i=i+1+iSpace)
          {
           dc.DrawLineRecur(rx1,rx2,y1+i,y2+i);

          }b=clock();
          itoa((b-a),strText,10);
          dc.TextOut(150,485,strText);

		  rx1=x1 + 220;
		  rx2=x2 + 220;
          sleep(T);
          a=clock();
          for(i=0;i<end;i=i+1+iSpace)
          {
           dc.DrawLineBrezen(rx1,rx2,y1+i,y2+i);

          }b=clock();
          itoa((b-a),strText,10);
          dc.TextOut(270,485,strText);

		  rx1=x1 + 330;
		  rx2=x2 + 330;
          sleep(T);
          a=clock();
          for(i=0;i<end;i=i+1+iSpace)
          {
           dc.MoveTo(rx1,y1+i);dc.LineTo(rx2,y2+i);

          }b=clock();
          itoa((b-a),strText,10);
          dc.TextOut(390,485,strText);          

		  rx1=x1 + 440;
		  rx2=x2 + 440;
          sleep(T);
          a=clock();
          for(i=0;i<end;i=i+1+iSpace)//iSpace=10
          {
             dc.DrawLineVu(rx1,rx2,y1+i,y2+i);//(450,548,50+0..2200,67+0..2200)

          }b=clock();
          itoa((b-a),strText,10);
          dc.TextOut(500,485,strText);

mouseDown = 0;
}
else{
          dc.TextOut(75,485,"    ");
          dc.TextOut(225,485,"    ");
          dc.TextOut(375,485,"    ");
          dc.TextOut(525,485,"    ");
}
}
