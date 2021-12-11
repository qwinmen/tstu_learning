//---------------------------------------------------------------------------

#include <vcl.h>
#include <math.h>
#include <vector>
#include <algorithm>
#pragma hdrstop
using namespace std;


#include "Unit1.h"
#include "Unit2.h"
#include "Unit3.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm2 *Form2;
int flag_ok=0;

int new_obj=0;
int new_obj_x1;
int new_obj_y1;
int new_obj_x2;
int new_obj_y2;

int new_zon=0;
int new_zon_x1;
int new_zon_y1;
int new_zon_x2;
int new_zon_y2;


const int WALL=9999;
const int Trace=8888;
int N,M;
int **map;
vector<pair<int,int> >*Tracks;
//---------------------------------------------------------------------------
__fastcall TForm2::TForm2(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm2::FormClose(TObject *Sender, TCloseAction &Action)
{
Form1->Close();
}
//---------------------------------------------------------------------------
	void __fastcall TForm2::PaintAll()
	{
		Graphics::TBitmap*bmp1;
		bmp1=new Graphics::TBitmap();

		bmp1->Width=PaintBox1->Width;
		bmp1->Height=PaintBox1->Height;

		bmp1->Canvas->Pen->Color=clRed;
		bmp1->Canvas->Brush->Color=clWhite;
		bmp1->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

		bmp1->Canvas->Pen->Color=clSilver;

		for(int i=10;i<bmp1->Width;i+=10)
		 {
		  bmp1->Canvas->MoveTo(i,1);
		  bmp1->Canvas->LineTo(i,bmp1->Height-2);
		 }

		for(int i=10;i<bmp1->Height;i+=10)
		 {
		  bmp1->Canvas->MoveTo(1,i);
		  bmp1->Canvas->LineTo(bmp1->Width-2,i);
		 }
		if(N15->Checked)bmp1->Canvas->Pen->Width=2;
		for(int i=1;i<StringGrid1->RowCount;i++)
		{
		 int x1,x2,y1,y2;
		 if(StringGrid1->Cells[0][i].Length()==0)break;
		 x1=StringGrid1->Cells[2][i].ToInt();
		 y1=StringGrid1->Cells[3][i].ToInt();
		 x2=StringGrid1->Cells[4][i].ToInt();
		 y2=StringGrid1->Cells[5][i].ToInt();

		 bmp1->Canvas->Pen->Color=RGB(255,230,230);//clSilver;
		 bmp1->Canvas->Brush->Color=RGB(255,230,230);
		 if(N10->Checked)bmp1->Canvas->Rectangle(x1-10,y1-10,x2+10,y2+10);//акантовка запретной зоны

		 bmp1->Canvas->Pen->Color=clGreen;
		 bmp1->Canvas->Brush->Color=clWhite;
		 bmp1->Canvas->Rectangle(x1,y1,x2,y2);
		 int x,y;
		 if(x1<x2)x=x1;else x=x2;
		 if(y1<y2)y=y1;else y=y2;
		 if(N7->Checked)bmp1->Canvas->TextOutA(x+2,y+2,StringGrid1->Cells[0][i]);
		}

		if(N11->Checked==True)
		for(int i=1;i<StringGrid3->RowCount;i++)
		{
		 int x1,x2,y1,y2;
		 if(StringGrid3->Cells[0][i].Length()==0)break;
		 x1=StringGrid3->Cells[2][i].ToInt();
		 y1=StringGrid3->Cells[3][i].ToInt();
		 x2=StringGrid3->Cells[4][i].ToInt();
		 y2=StringGrid3->Cells[5][i].ToInt();

		 bmp1->Canvas->Pen->Color=RGB(230,230,255);//clSilver;
		 bmp1->Canvas->Brush->Color=RGB(230,230,255);
		 bmp1->Canvas->Rectangle(x1,y1,x2,y2);
		 //if(N12->Checked)bmp1->Canvas->TextOutA(x1+2,y1+2,StringGrid3->Cells[0][i]);
		}
		if(N11->Checked==True)
		for(int i=1;i<StringGrid3->RowCount;i++)
		{
		 int x1,x2,y1,y2;
		 if(StringGrid3->Cells[0][i].Length()==0)break;
		 x1=StringGrid3->Cells[2][i].ToInt();
		 y1=StringGrid3->Cells[3][i].ToInt();
		 x2=StringGrid3->Cells[4][i].ToInt();
		 y2=StringGrid3->Cells[5][i].ToInt();
		 if(N12->Checked)bmp1->Canvas->TextOutA(x1+2,y1+2,StringGrid3->Cells[0][i]);
		}


		if(new_obj==1)
		{
		 if(abs(new_obj_x1-new_obj_x2)==0||abs(new_obj_y1-new_obj_y2)==0)goto m1;

		 int x1,x2,y1,y2;
		 if(new_obj_x1>new_obj_x2){x1=new_obj_x2;x2=new_obj_x1;}else {x1=new_obj_x1;x2=new_obj_x2;}
		 if(new_obj_y1>new_obj_y2){y1=new_obj_y2;y2=new_obj_y1;}else {y1=new_obj_y1;y2=new_obj_y2;}

		 bmp1->Canvas->Pen->Color=RGB(255,230,230);//clSilver;
		 bmp1->Canvas->Brush->Color=RGB(255,230,230);
		 if(N10->Checked)bmp1->Canvas->Rectangle(x1-10,y1-10,x2+10,y2+10);

		 bmp1->Canvas->Pen->Color=clGreen;
		 bmp1->Canvas->Brush->Color=clWhite;
		 bmp1->Canvas->Rectangle(new_obj_x1,new_obj_y1,new_obj_x2,new_obj_y2);
		 int x,y;
		 if(new_obj_x1<new_obj_x2)x=new_obj_x1;else x=new_obj_x2;
		 if(new_obj_y1<new_obj_y2)y=new_obj_y1;else y=new_obj_y2;
		 if(N7->Checked)bmp1->Canvas->TextOutA(x+2,y+2,IntToStr(StringGrid1->RowCount));
		}
		m1:
			if(new_zon==1)
			{
			 if(abs(new_zon_x1-new_zon_x2)==0||abs(new_zon_y1-new_zon_y2)==0)goto m3;

			 int x1,x2,y1,y2;
			 if(new_zon_x1>new_zon_x2){x1=new_zon_x2;x2=new_zon_x1;}else {x1=new_zon_x1;x2=new_zon_x2;}
			 if(new_zon_y1>new_zon_y2){y1=new_zon_y2;y2=new_zon_y1;}else {y1=new_zon_y1;y2=new_zon_y2;}

			 bmp1->Canvas->Pen->Color=RGB(230,230,255);//clSilver;
			 bmp1->Canvas->Brush->Color=RGB(230,230,255);
			 if(N10->Checked)bmp1->Canvas->Rectangle(x1,y1,x2,y2);
			 if(N12->Checked&&N10->Checked)bmp1->Canvas->TextOutA(x1+2,y1+2,IntToStr(StringGrid3->RowCount));
			  for(int i=1;i<StringGrid3->RowCount;i++)
			  {
			   int x1,x2,y1,y2;
			   if(StringGrid3->Cells[0][i].Length()==0)break;
			   x1=StringGrid3->Cells[2][i].ToInt();
			   y1=StringGrid3->Cells[3][i].ToInt();
			   x2=StringGrid3->Cells[4][i].ToInt();
			   y2=StringGrid3->Cells[5][i].ToInt();
			   if(N12->Checked)bmp1->Canvas->TextOutA(x1+2,y1+2,StringGrid3->Cells[0][i]);
			  }
			}
		m3:
			bmp1->Canvas->Pen->Width=1;
			if(flag_ok==1)
			{
				bmp1->Canvas->Pen->Color=clBlue;
				if(N16->Checked)bmp1->Canvas->Pen->Width=2;
				int n=1;
				for(int num=1;num<StringGrid2->RowCount;num++)
				{
				 vector<pair<int,int> >::iterator i=Tracks[num-1].begin();
				 bmp1->Canvas->MoveTo(i->first*10,i->second*10);
				 for(vector<pair<int,int> >::iterator i=Tracks[num-1].begin();i!=Tracks[num-1].end();++i)
				  {
				   n++;
				   int nx=i->first;
				   int ny=i->second;
				   bmp1->Canvas->LineTo(nx*10,ny*10);
				  }
				}
			}

		TRect r1,r2;
		r1=Rect(0,0,bmp1->Width,bmp1->Height);
		r2=Rect(0,0,bmp1->Width,bmp1->Height);
		PaintBox1->Canvas->CopyRect(r1,bmp1->Canvas,r2);
		delete bmp1;

	}
//---------------------------------------------------------------------------

void __fastcall TForm2::N2Click(TObject *Sender)
{
Form1->Edit1->Text="500";
Form1->Edit2->Text="500";
Form1->Visible=True;
Form2->Visible=False;
}
//---------------------------------------------------------------------------
void __fastcall TForm2::PaintBox1Paint(TObject *Sender)
{
PaintAll();
}
//---------------------------------------------------------------------------
void __fastcall TForm2::PaintBox1MouseMove(TObject *Sender,
      TShiftState Shift, int X, int Y)
{
if(X%10!=0)X=X-X%10+10;
if(Y%10!=0)Y=Y-Y%10+10;
if(X<=10)X=10;
if(X>=PaintBox1->Width-11)X=PaintBox1->Width-11;
if(Y<=10)Y=10;
if(Y>=PaintBox1->Height-11)Y=PaintBox1->Height-11;

StatusBar1->Panels->Items[0]->Text="X="+IntToStr(X);
StatusBar1->Panels->Items[1]->Text="Y="+IntToStr(Y);

if(SpeedButton1->Down==True)return;

if(SpeedButton2->Down==True)
{
if(new_obj==0)return;
Graphics::TBitmap*bmp1,*bmp2;
bmp1=new Graphics::TBitmap();

bmp1->Width=PaintBox1->Width;
bmp1->Height=PaintBox1->Height;

bmp1->Canvas->Pen->Color=clWhite;
bmp1->Canvas->Brush->Color=clWhite;
bmp1->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

for(int i=1;i<StringGrid1->RowCount;i++)
{
 int x1,x2,y1,y2;
 if(StringGrid1->Cells[0][i].Length()==0)break;
 x1=StringGrid1->Cells[2][i].ToInt();
 y1=StringGrid1->Cells[3][i].ToInt();
 x2=StringGrid1->Cells[4][i].ToInt();
 y2=StringGrid1->Cells[5][i].ToInt();

 bmp1->Canvas->Pen->Color=clRed;
 bmp1->Canvas->Brush->Color=clRed;
 bmp1->Canvas->Rectangle(x1-10,y1-10,x2+11,y2+11);
}

for(int i=1;i<StringGrid3->RowCount;i++)
{
 int x1,x2,y1,y2;
 if(StringGrid3->Cells[0][i].Length()==0)break;
 x1=StringGrid3->Cells[2][i].ToInt();
 y1=StringGrid3->Cells[3][i].ToInt();
 x2=StringGrid3->Cells[4][i].ToInt();
 y2=StringGrid3->Cells[5][i].ToInt();

 bmp1->Canvas->Pen->Color=clRed;
 bmp1->Canvas->Brush->Color=clRed;
 bmp1->Canvas->Rectangle(x1-1,y1-1,x2+1,y2+1);
}


int flag=0;
int x1,x2,y1,y2;
if(X>new_obj_x1){x1=new_obj_x1;x2=X;}else {x2=new_obj_x1;x1=X;}
if(Y>new_obj_y1){y1=new_obj_y1;y2=Y;}else {y2=new_obj_y1;y1=Y;}
if(bmp1->Canvas->Pixels[x1][y1]==clRed)flag=1;
if(bmp1->Canvas->Pixels[x1][y2]==clRed)flag=1;
if(bmp1->Canvas->Pixels[x2][y1]==clRed)flag=1;
if(bmp1->Canvas->Pixels[x2][y2]==clRed)flag=1;
delete bmp1;

bmp2=new Graphics::TBitmap();

bmp2->Width=PaintBox1->Width;
bmp2->Height=PaintBox1->Height;

bmp2->Canvas->Pen->Color=clWhite;
bmp2->Canvas->Brush->Color=clWhite;
bmp2->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

bmp2->Canvas->Pen->Color=clRed;
bmp2->Canvas->Brush->Color=clRed;
bmp2->Canvas->Rectangle(x1-10,y1-10,x2+11,y2+11);

for(int i=1;i<StringGrid1->RowCount;i++)
{
 int X1,X2,Y1,Y2;
 if(StringGrid1->Cells[0][i].Length()==0)break;
 X1=StringGrid1->Cells[2][i].ToInt();
 Y1=StringGrid1->Cells[3][i].ToInt();
 X2=StringGrid1->Cells[4][i].ToInt();
 Y2=StringGrid1->Cells[5][i].ToInt();

 if(bmp2->Canvas->Pixels[X1][Y1]==clRed)flag=1;
 if(bmp2->Canvas->Pixels[X1][Y2]==clRed)flag=1;
 if(bmp2->Canvas->Pixels[X2][Y1]==clRed)flag=1;
 if(bmp2->Canvas->Pixels[X2][Y2]==clRed)flag=1;
}
delete bmp2;

if(new_obj==1&&flag==0)
{
 new_obj_x2=X;
 new_obj_y2=Y;
 PaintAll();
}
}

if(SpeedButton3->Down==True)
{
if(new_zon==0)return;
Graphics::TBitmap*bmp1,*bmp2;
bmp1=new Graphics::TBitmap();

bmp1->Width=PaintBox1->Width;
bmp1->Height=PaintBox1->Height;

bmp1->Canvas->Pen->Color=clWhite;
bmp1->Canvas->Brush->Color=clWhite;
bmp1->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

for(int i=1;i<StringGrid1->RowCount;i++)
{
 int x1,x2,y1,y2;
 if(StringGrid1->Cells[0][i].Length()==0)break;
 x1=StringGrid1->Cells[2][i].ToInt();
 y1=StringGrid1->Cells[3][i].ToInt();
 x2=StringGrid1->Cells[4][i].ToInt();
 y2=StringGrid1->Cells[5][i].ToInt();

 bmp1->Canvas->Pen->Color=clRed;
 bmp1->Canvas->Brush->Color=clRed;
 bmp1->Canvas->Rectangle(x1-10,y1-10,x2+1,y2+1);
}

int flag=0;
int x1,x2,y1,y2;
if(X>new_zon_x1){x1=new_zon_x1;x2=X;}else {x2=new_zon_x1;x1=X;}
if(Y>new_zon_y1){y1=new_zon_y1;y2=Y;}else {y2=new_zon_y1;y1=Y;}
if(bmp1->Canvas->Pixels[x1][y1]==clRed)flag=1;
if(bmp1->Canvas->Pixels[x1][y2]==clRed)flag=1;
if(bmp1->Canvas->Pixels[x2][y1]==clRed)flag=1;
if(bmp1->Canvas->Pixels[x2][y2]==clRed)flag=1;
delete bmp1;

bmp2=new Graphics::TBitmap();

bmp2->Width=PaintBox1->Width;
bmp2->Height=PaintBox1->Height;

bmp2->Canvas->Pen->Color=clWhite;
bmp2->Canvas->Brush->Color=clWhite;
bmp2->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

bmp2->Canvas->Pen->Color=clRed;
bmp2->Canvas->Brush->Color=clRed;
bmp2->Canvas->Rectangle(x1-1,y1-1,x2+1,y2+1);

for(int i=1;i<StringGrid1->RowCount;i++)
{
 int X1,X2,Y1,Y2;
 if(StringGrid1->Cells[0][i].Length()==0)break;
 X1=StringGrid1->Cells[2][i].ToInt();
 Y1=StringGrid1->Cells[3][i].ToInt();
 X2=StringGrid1->Cells[4][i].ToInt();
 Y2=StringGrid1->Cells[5][i].ToInt();

 if(bmp2->Canvas->Pixels[X1][Y1]==clRed)flag=1;
 if(bmp2->Canvas->Pixels[X1][Y2]==clRed)flag=1;
 if(bmp2->Canvas->Pixels[X2][Y1]==clRed)flag=1;
 if(bmp2->Canvas->Pixels[X2][Y2]==clRed)flag=1;
}
delete bmp2;

if(new_zon==1&&flag==0)
{
 new_zon_x2=X;
 new_zon_y2=Y;
 PaintAll();
}
}
}
//---------------------------------------------------------------------------
void __fastcall TForm2::PaintBox1MouseDown(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
if(SpeedButton1->Down==True)return;
if(SpeedButton2->Down==True)
{
Graphics::TBitmap*bmp1;
bmp1=new Graphics::TBitmap();

bmp1->Width=PaintBox1->Width;
bmp1->Height=PaintBox1->Height;

bmp1->Canvas->Pen->Color=clWhite;
bmp1->Canvas->Brush->Color=clWhite;
bmp1->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

for(int i=1;i<StringGrid1->RowCount;i++)
{
 int x1,x2,y1,y2;
 if(StringGrid1->Cells[0][i].Length()==0)break;
 x1=StringGrid1->Cells[2][i].ToInt();
 y1=StringGrid1->Cells[3][i].ToInt();
 x2=StringGrid1->Cells[4][i].ToInt();
 y2=StringGrid1->Cells[5][i].ToInt();

 bmp1->Canvas->Pen->Color=clRed;
 bmp1->Canvas->Brush->Color=clRed;
 bmp1->Canvas->Rectangle(x1-10,y1-10,x2+10,y2+10);
}


if(bmp1->Canvas->Pixels[X][Y]==clRed){delete bmp1;return;}
delete bmp1;

if(X%10!=0)X=X-X%10+10;
if(Y%10!=0)Y=Y-Y%10+10;
if(X<=10)X=10;
if(X>=PaintBox1->Width-11)X=PaintBox1->Width-11;
if(Y<=10)Y=10;
if(Y>=PaintBox1->Height-11)Y=PaintBox1->Height-11;


new_obj=1;
new_obj_x1=X;
new_obj_y1=Y;
new_obj_x2=X;
new_obj_y2=Y;
}

if(SpeedButton3->Down==True)
{
Graphics::TBitmap*bmp1;
bmp1=new Graphics::TBitmap();

bmp1->Width=PaintBox1->Width;
bmp1->Height=PaintBox1->Height;

bmp1->Canvas->Pen->Color=clWhite;
bmp1->Canvas->Brush->Color=clWhite;
bmp1->Canvas->Rectangle(0,0,bmp1->Width-1,bmp1->Height-1);

for(int i=1;i<StringGrid1->RowCount;i++)
{
 int x1,x2,y1,y2;
 if(StringGrid1->Cells[0][i].Length()==0)break;
 x1=StringGrid1->Cells[2][i].ToInt();
 y1=StringGrid1->Cells[3][i].ToInt();
 x2=StringGrid1->Cells[4][i].ToInt();
 y2=StringGrid1->Cells[5][i].ToInt();

 bmp1->Canvas->Pen->Color=clRed;
 bmp1->Canvas->Brush->Color=clRed;
 bmp1->Canvas->Rectangle(x1,y1,x2,y2);
}


if(bmp1->Canvas->Pixels[X][Y]==clRed){delete bmp1;return;}
delete bmp1;

if(X%10!=0)X=X-X%10+10;
if(Y%10!=0)Y=Y-Y%10+10;
if(X<=10)X=10;
if(X>=PaintBox1->Width-11)X=PaintBox1->Width-11;
if(Y<=10)Y=10;
if(Y>=PaintBox1->Height-11)Y=PaintBox1->Height-11;


new_zon_x1=X;
new_zon_y1=Y;
new_zon_x2=X;
new_zon_y2=Y;
new_zon=1;
}
}
//---------------------------------------------------------------------------
void __fastcall TForm2::PaintBox1MouseUp(TObject *Sender,
      TMouseButton Button, TShiftState Shift, int X, int Y)
{
 if(SpeedButton1->Down==True)return;
 if(SpeedButton2->Down==True)
 {
 if(new_obj==0)return;
 new_obj=0;
 if(abs(new_obj_x1-new_obj_x2)==0)return;
 if(abs(new_obj_y1-new_obj_y2)==0)return;

 StringGrid1->RowCount++;
 int n=StringGrid1->RowCount-1;
 StringGrid1->FixedCols=1;
 StringGrid1->FixedRows=1;

 if(new_obj_x1>new_obj_x2){int x=new_obj_x2;new_obj_x2=new_obj_x1;new_obj_x1=x;}
 if(new_obj_y1>new_obj_y2){int y=new_obj_y2;new_obj_y2=new_obj_y1;new_obj_y1=y;}

 StringGrid1->Cells[0][n]=IntToStr(n);
 StringGrid1->Cells[1][n]="Объект "+IntToStr(n);
 StringGrid1->Cells[2][n]=IntToStr(new_obj_x1);
 StringGrid1->Cells[3][n]=IntToStr(new_obj_y1);

 StringGrid1->Cells[4][n]=IntToStr(new_obj_x2);
 StringGrid1->Cells[5][n]=IntToStr(new_obj_y2);

 Form2->UpDown1->Min=0;
 Form2->UpDown1->Max=StringGrid1->RowCount-1;
 Form2->UpDown1->Enabled=True;
 Button1->Enabled=True;

 if(StringGrid1->RowCount>=3)ComboBox1->Enabled=True;
 else ComboBox1->Enabled=False;
 ComboBox1->Items->Clear();
 ComboBox1->Text="Вход";
 for(int i=1;i<StringGrid1->RowCount;i++)
  ComboBox1->Items->Add(StringGrid1->Cells[1][i]);
 }

 if(SpeedButton3->Down==True)
 {
 if(new_zon==0)return;
 new_zon=0;
 //Edit4->Text=new_zon_x1;
 //Edit5->Text=new_zon_x2;
 if(abs(new_zon_x1-new_zon_x2)==0)return;
 if(abs(new_zon_y1-new_zon_y2)==0)return;

 StringGrid3->RowCount++;
 int n=StringGrid3->RowCount-1;
 StringGrid3->FixedCols=1;
 StringGrid3->FixedRows=1;

 if(new_zon_x1>new_zon_x2){int x=new_zon_x2;new_zon_x2=new_zon_x1;new_zon_x1=x;}
 if(new_zon_y1>new_zon_y2){int y=new_zon_y2;new_zon_y2=new_zon_y1;new_zon_y1=y;}

 StringGrid3->Cells[0][n]=IntToStr(n);
 StringGrid3->Cells[1][n]="Зона "+IntToStr(n);
 StringGrid3->Cells[2][n]=IntToStr(new_zon_x1);
 StringGrid3->Cells[3][n]=IntToStr(new_zon_y1);

 StringGrid3->Cells[4][n]=IntToStr(new_zon_x2);
 StringGrid3->Cells[5][n]=IntToStr(new_zon_y2);

 Form2->UpDown3->Min=0;
 Form2->UpDown3->Max=StringGrid3->RowCount-1;
 Form2->UpDown3->Enabled=True;
 Button4->Enabled=True;
 }
}
//---------------------------------------------------------------------------
void __fastcall TForm2::N4Click(TObject *Sender)
{
Form1->Close();
}
//---------------------------------------------------------------------------
void __fastcall TForm2::N7Click(TObject *Sender)
{
N7->Checked=!N7->Checked;
PaintAll();
}
//---------------------------------------------------------------------------

void __fastcall TForm2::N10Click(TObject *Sender)
{
N10->Checked=!N10->Checked;
PaintAll();
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button1Click(TObject *Sender)         //удаление объекта
{
if(Edit1->Text=="0")return;
int n=Edit1->Text.ToInt();
for(int i=n;i<StringGrid1->RowCount-1;i++)
 {
  StringGrid1->Rows[i]=StringGrid1->Rows[i+1];
 }
StringGrid1->Rows[StringGrid1->RowCount-1]->Clear();
StringGrid1->RowCount--;
for(int i=1;i<StringGrid1->RowCount;i++)
 {
  StringGrid1->Cells[0][i]=IntToStr(i);
  StringGrid1->Cells[1][i]="Объект "+IntToStr(i);
 }
Form2->UpDown1->Max=StringGrid1->RowCount-1;
Form2->UpDown1->Position=0;
PaintAll();
if(StringGrid1->RowCount==1)Button1->Enabled=False;
if(StringGrid1->RowCount>=3)ComboBox1->Enabled=True;
else ComboBox1->Enabled=False;

ComboBox1->Items->Clear();
ComboBox1->Text="Вход";
for(int i=1;i<StringGrid1->RowCount;i++)
 ComboBox1->Items->Add(StringGrid1->Cells[1][i]);

for(int i=1;i<Form2->StringGrid2->RowCount;i++)
 Form2->StringGrid2->Rows[i]->Clear();
Form2->StringGrid2->RowCount=1;
UpDown2->Max=0;
Button2->Enabled=False;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::ComboBox1Change(TObject *Sender)
{
ComboBox2->Items->Clear();
ComboBox2->Text="Выход";
ComboBox2->Enabled=True;

for(int i=1;i<StringGrid1->RowCount;i++)
 {
  if(ComboBox1->Text==StringGrid1->Cells[1][i])continue;
 /* for(int j=1;j<StringGrid2->RowCount;j++)
   {
	   if(StringGrid1->Cells[1][i]==StringGrid2->Cells[2][j])goto m2;

   } */
  ComboBox2->Items->Add(StringGrid1->Cells[1][i]);
  m2:
 }
}
//---------------------------------------------------------------------------

void __fastcall TForm2::ComboBox2Change(TObject *Sender)
{
if(ComboBox2->ItemIndex!=-1)Button3->Enabled=True;
else Button3->Enabled=False;

}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button3Click(TObject *Sender)  // добавление связи
{
 int n=StringGrid2->RowCount;
 StringGrid2->RowCount++;
 StringGrid2->Cells[0][n]=IntToStr(n);
 StringGrid2->Cells[1][n]=ComboBox1->Text;
 StringGrid2->Cells[2][n]=ComboBox2->Text;

 StringGrid2->FixedCols=1;
 StringGrid2->FixedRows=1;

 //ComboBox1->Items->Delete(ComboBox1->ItemIndex);
 Button3->Enabled=False;
 ComboBox2->Enabled=False;
 ComboBox1->Text="Вход";
 ComboBox2->Text="Выход";
 UpDown2->Max=StringGrid2->RowCount-1;
 UpDown2->Position=0;
 Button2->Enabled=True;
 flag_ok=0;


}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button2Click(TObject *Sender)          //удаление связи
{
if(Edit2->Text=="0")return;
int n=Edit2->Text.ToInt();
for(int i=n;i<StringGrid2->RowCount-1;i++)
 {
  StringGrid2->Rows[i]=StringGrid2->Rows[i+1];
 }
StringGrid2->Rows[StringGrid2->RowCount-1]->Clear();
StringGrid2->RowCount--;
for(int i=1;i<StringGrid2->RowCount;i++)
 {
  StringGrid2->Cells[0][i]=IntToStr(i);
 }
Form2->UpDown2->Max=StringGrid1->RowCount-1;
Form2->UpDown2->Position=0;
if(StringGrid2->RowCount==1)Button2->Enabled=False;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::N11Click(TObject *Sender)
{
N11->Checked=!N11->Checked;
PaintAll();
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button4Click(TObject *Sender)           //удаление зоны
{
if(Edit3->Text=="0")return;
int n=Edit3->Text.ToInt();
for(int i=n;i<StringGrid3->RowCount-1;i++)
 {
  StringGrid3->Rows[i]=StringGrid3->Rows[i+1];
 }
StringGrid3->Rows[StringGrid3->RowCount-1]->Clear();
StringGrid3->RowCount--;
for(int i=1;i<StringGrid3->RowCount;i++)
 {
  StringGrid3->Cells[0][i]=IntToStr(i);
  StringGrid3->Cells[1][i]="Зона "+IntToStr(i);
 }
Form2->UpDown3->Max=StringGrid3->RowCount-1;
Form2->UpDown3->Position=0;
PaintAll();
if(StringGrid3->RowCount==1)Button4->Enabled=False;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::N12Click(TObject *Sender)
{
N12->Checked=!N12->Checked;
PaintAll();
}
//---------------------------------------------------------------------------
	void __fastcall TForm2::ALG(int num)
	{
		int i,j,k;
		int start_x,start_y;
		int stop_x,stop_y;
		AnsiString obj1,obj2;
		obj1=StringGrid2->Cells[1][num];
		obj2=StringGrid2->Cells[2][num];
		int i1,i2;
		for(i=1;i<StringGrid1->RowCount;i++)
		 {
		  if(StringGrid1->Cells[1][i]==obj1)
		   i1=i;
		   /*{
			int x1,x2,y1,y2;
			x1=StringGrid1->Cells[2][i].ToInt()/10;
			y1=StringGrid1->Cells[3][i].ToInt()/10;
			x2=StringGrid1->Cells[4][i].ToInt()/10;
			y2=StringGrid1->Cells[5][i].ToInt()/10;
			x2++;
			do
			{
			x2--;
			start_x=x2;//+abs(x2-x1)/2;
			start_y=y1;
			//ShowMessage(start_x);
			}while(map[start_x][start_y]==8888);

			//start_x=x1;//+abs(x2-x1)/2;
			//start_y=y2;
		   } */
		  if(StringGrid1->Cells[1][i]==obj2)
		   i2=i;
		   /*{
			int x1,x2,y1,y2;
			x1=StringGrid1->Cells[2][i].ToInt()/10;
			y1=StringGrid1->Cells[3][i].ToInt()/10;
			x2=StringGrid1->Cells[4][i].ToInt()/10;
			y2=StringGrid1->Cells[5][i].ToInt()/10;
			//stop_x=x1;//+abs(x2-x1)/2;
			//stop_y=y1;
			x1--;
			do
			{
			x1++;
			stop_x=x1;//+abs(x2-x1)/2;
			stop_y=y2;
			}while(map[stop_x][stop_y]==8888);

		   } */
		 }
		 int x1,x2,y1,y2,X1,X2,Y1,Y2;
         //переход от экранных точек к обычным
			x1=StringGrid1->Cells[2][i1].ToInt()/10;
			y1=StringGrid1->Cells[3][i1].ToInt()/10;
			x2=StringGrid1->Cells[4][i1].ToInt()/10;
			y2=StringGrid1->Cells[5][i1].ToInt()/10;

			X1=StringGrid1->Cells[2][i2].ToInt()/10;
			Y1=StringGrid1->Cells[3][i2].ToInt()/10;
			X2=StringGrid1->Cells[4][i2].ToInt()/10;
			Y2=StringGrid1->Cells[5][i2].ToInt()/10;

			if(x1<=X1)
			{
				x2++;
				do
				{
					x2--;
					start_x=x2;//+abs(x2-x1)/2;
					if(y1<=Y1)start_y=y2;
					else start_y=y1;
					//ShowMessage(start_x);
				}while(map[start_x][start_y]==8888);

				X1--;
				do
				{
					X1++;
					stop_x=X1;//+abs(x2-x1)/2;
					if(y1<=Y1)stop_y=Y1;
					else stop_y=Y2;
				}while(map[stop_x][stop_y]==8888);
			}
			else
			{
				x2--;
				do
				{
					x2++;
					start_x=x2;//+abs(x2-x1)/2;
					if(y1<=Y1)start_y=y2;
					else start_y=y1;
					//ShowMessage(start_x);
				}while(map[start_x][start_y]==8888);

				X1++;
				do
				{
					X1--;
					stop_x=X1;//+abs(x2-x1)/2;
					if(y1<=Y1)stop_y=Y1;
					else stop_y=Y2;
				}while(map[stop_x][stop_y]==8888);
			}
			//start_x=x1;//+abs(x2-x1)/2;
			//start_y=y2;
		vector<pair<int,int> > wave;
		vector<pair<int,int> > oldWave;
		int nstep=0;
		const int dx[]={1,-1,0,0};
		const int dy[]={0,0,1,-1};
		map[start_x][start_y]=nstep;
		map[stop_x][stop_y]=-1;

		oldWave.push_back(pair<int,int>(start_x,start_y));
		while(oldWave.size()>0)
		{
		 wave.clear();
		 ++nstep;
		 for(vector<pair<int,int> >::iterator i=oldWave.begin();i!=oldWave.end();++i)
		  {
		   for(int d=0;d<4;++d)
			{
			 int nx=i->first+dx[d];
			 int ny=i->second+dy[d];
			 if(map[nx][ny]==-1)
			  {
			   wave.push_back(pair<int,int>(nx,ny));
			   map[nx][ny]=nstep;
			   if(nx==stop_x&&ny==stop_y)goto done;
			  }
			}
		  }
		 oldWave=wave;
		}

	done:
		int x=stop_x;   //точка конца
		int y=stop_y;
		wave.clear();
		Tracks[num-1].clear();
		wave.push_back(pair<int,int>(x,y));
		Tracks[num-1].push_back(pair<int,int>(x,y)); //конец


		nstep=0;
		while(map[x][y]!=0)
		{
		 if(nstep==10000)
		 {ShowMessage("Связь "+IntToStr(num)+" не проложена.");goto done1;}
		  if(pow(map[x][y]-map[x+1][y+1],2)+pow(map[y][y]-map[y+1][y+1],2)>StrToFloat(Edit4->Text)*StrToFloat(Edit4->Text)*1000*2)
		  {ShowMessage("Связь "+IntToStr(num)+" не проложена.");goto done1;}


		 for(int d=0;d<4;d++)
		  {
		   int nx=x+dx[d];
		   int ny=y+dy[d];

		   nstep++;
		   if(map[x][y]-1==map[nx][ny])
			{
			 x=nx;
			 y=ny;
			 wave.push_back(pair<int,int>(x,y));
			 Tracks[num-1].push_back(pair<int,int>(x,y));//очередная точка маршрута
			 break;
			}
		  }
		}
		 for(vector<pair<int,int> >::iterator i=Tracks[num-1].begin();i!=Tracks[num-1].end();++i)
		  {
		   int nx=i->first;
		   int ny=i->second;
		   map[nx][ny]=WALL;
		  }
//		ShowMessage("Связь "+IntToStr(num)+" успешно проложена.");
		done1:
		 for(i=0;i<N;i++)
		  for(j=0;j<M;j++)
		   if(map[i][j]!=WALL&&map[i][j]!=8888)map[i][j]=-1;

		 map[start_x][start_y]=8888;
		 map[stop_x][stop_y]=8888;

		return;
	}

//---------------------------------------------------------------------------
//Кнопка Построить Связи
	void __fastcall TForm2::Button5Click(TObject *Sender)
	{
		int i,j,k;
		int x1,x2,y1,y2;
		N=Form1->Edit1->Text.ToInt()/10+1;
		M=Form1->Edit2->Text.ToInt()/10+1;
		map=(int**)malloc(N*sizeof(int*));
		for(i=0;i<N;i++)map[i]=(int*)malloc(M*sizeof(int));

		for(i=0;i<N;i++)
		 for(j=0;j<M;j++)
		  map[i][j]=-1;

		for(i=0;i<N;i++)
		 {
		  map[i][0]=WALL;
		  map[i][M-1]=WALL;
		 }
		for(i=0;i<M;i++)
		 {
		  map[0][i]=WALL;
		  map[N-1][i]=WALL;
		 }
		for(k=1;k<StringGrid1->RowCount;k++)
		 {
		  x1=StringGrid1->Cells[2][k].ToInt()/10;
		  y1=StringGrid1->Cells[3][k].ToInt()/10;
		  x2=StringGrid1->Cells[4][k].ToInt()/10;
		  y2=StringGrid1->Cells[5][k].ToInt()/10;
		  for(i=x1;i<=x2;i++)//{map[i][y1]=WALL;map[i][y2]=WALL;}
		   for(j=y1;j<=y2;j++)//{map[x1][i]=WALL;map[x2][i]=WALL;}
			map[i][j]=WALL;
		 }
		for(k=1;k<StringGrid3->RowCount;k++)
		 {
		  x1=StringGrid3->Cells[2][k].ToInt()/10;
		  y1=StringGrid3->Cells[3][k].ToInt()/10;
		  x2=StringGrid3->Cells[4][k].ToInt()/10;
		  y2=StringGrid3->Cells[5][k].ToInt()/10;
		  for(i=x1+1;i<x2;i++)//{map[i][y1]=WALL;map[i][y2]=WALL;}
		   for(j=y1+1;j<y2;j++)//{map[x1][i]=WALL;map[x2][i]=WALL;}
			map[i][j]=WALL;
		 }

		if(StringGrid2->RowCount==1)return;
		flag_ok=1;
		Tracks=new vector<pair <int,int> >[StringGrid2->RowCount-1];
		for(i=1;i<StringGrid2->RowCount;i++)
	        ALG(i);
		PaintAll();
	}
//---------------------------------------------------------------------------


void __fastcall TForm2::N15Click(TObject *Sender)
{
N15->Checked=!N15->Checked;
PaintAll();
}
//---------------------------------------------------------------------------

void __fastcall TForm2::N16Click(TObject *Sender)
{
N16->Checked=!N16->Checked;
PaintAll();
}
//---------------------------------------------------------------------------

void __fastcall TForm2::N8Click(TObject *Sender)
{
ShellExecute(Handle,NULL,"help.doc",NULL,NULL,SW_RESTORE);
}
//---------------------------------------------------------------------------
