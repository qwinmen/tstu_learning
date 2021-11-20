/*/QwinCor @ 2014
//#include "hShape.h"
*/#pragma once
#include "hArrayShape.h"

namespace Karaser {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

 // подключаем класс CppStudio
	
//#include "hArrayShape.h"

/*===========================================================================================*/
/*===========================================================================================
	public ref class Shape {
	public: Shape() {
			dx = 8;
			dy = 8;
			width = 2;
			color = Color::Black;
			}
	protected: ~Shape() {
			   
			   }
	public: Int32 Name;
	public: Int32 x0;
	public: Int32 y0;
	public: Int32 x;
	public: Int32 y;
	//public: Int32 xc;
	//public: Int32 yc;
	public: Int32 dx;
	public: Int32 dy;
	public: Int32 width;
	public: System::Drawing::Color color;
	public: Int32 Type;
	public: void Draw(Int32 TypeS, Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				Graphics^ gr1 = Graphics::FromImage(bitmap);
				Pen^ pen = gcnew Pen(color, width);
				Brush^ brush = gcnew SolidBrush(color);
				Pen^ pen2 = gcnew Pen(color, 1);
				Shape::Type = TypeS;
				switch(Shape::Type) {
				case 0: {														//Линия
						//gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, abs(x+x0)/2-(dx+width)/2, abs(y+y0)/2-(dx+width)/2, dx+width, dy+width);
						gr1->DrawLine(pen, x0, y0, x, y);
						}
				break;
				case 1: {														//Прямоугольник
						//gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->DrawRectangle(pen, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->DrawRectangle(pen, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->DrawRectangle(pen, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->DrawRectangle(pen, x, y0, x0-x, y-y0);
						
						}
				break;
				case 2: {														//Эллипс
						//gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->DrawEllipse(pen, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->DrawEllipse(pen, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->DrawEllipse(pen, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->DrawEllipse(pen, x, y0, x0-x, y-y0);
						}
				break;
				case 3: {														//Закрашенный прямоугольник
						//gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillRectangle(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillRectangle(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillRectangle(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillRectangle(brush, x, y0, x0-x, y-y0);
						}
				break;
				case 4: {														//Закрашенный эллипс
						//gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillEllipse(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillEllipse(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillEllipse(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillEllipse(brush, x, y0, x0-x, y-y0);
						}
				break;
				default: {
						 
						 }
				
				}
				MyPictureBox->Image = bitmap;
			}

	public: void Redraw(Int32 newX, Int32 newY, Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				Graphics^ gr1 = Graphics::FromImage(bitmap);
				switch(Shape::Type) {
				case 0: {														//Перерисовка линии
						if((newX>=(x0-dx))&&(newX<=(x0+dx))&&(newY>=(y0-dy))&&(newY<=(y0+dy))) {
						Pen^ pen = gcnew Pen(Color::White, width);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						//gr1->DrawEllipse(pen2, abs(x+x0)/2-(dx+width)/2, abs(y+y0)/2-(dx+width)/2, dx+width, dy+width);
						gr1->DrawLine(pen, x0, y0, x, y);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						MyPictureBox->Image = bitmap;
						delete(pen);
						delete(pen2);
						x0 = newX;
						y0 = newY;
						pen = gcnew Pen(color, width);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawLine(pen, x0, y0, x, y);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						}
						else
						if((newX>=(x-dx))&&(newX<=(x+dx))&&(newY>=(y-dy))&&(newY<=(y+dy))) {
						Pen^ pen = gcnew Pen(Color::White, width);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawLine(pen, x0, y0, x, y);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						MyPictureBox->Image = bitmap;
						delete(pen);
						delete(pen2);
						x = newX;
						y = newY;
						pen = gcnew Pen(color, width);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawLine(pen, x0, y0, x, y);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						}
						}
				break;
				case 1: {														//Перерисовка прямоугольника
						if((newX>=(x0-dx))&&(newX<=(x0+dx))&&(newY>=(y0-dy))&&(newY<=(y0+dy))) {
						Pen^ pen = gcnew Pen(Color::White, width);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->DrawRectangle(pen, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->DrawRectangle(pen, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->DrawRectangle(pen, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->DrawRectangle(pen, x, y0, x0-x, y-y0);
						MyPictureBox->Image = bitmap;
						delete(pen);
						delete(pen2);
						x0 = newX;
						y0 = newY;
						pen = gcnew Pen(color, width);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->DrawRectangle(pen, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->DrawRectangle(pen, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->DrawRectangle(pen, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->DrawRectangle(pen, x, y0, x0-x, y-y0);
						}
						else
						if((newX>=(x-dx))&&(newX<=(x+dx))&&(newY>=(y-dy))&&(newY<=(y+dy))) {
						Pen^ pen = gcnew Pen(Color::White, width);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->DrawRectangle(pen, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->DrawRectangle(pen, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->DrawRectangle(pen, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->DrawRectangle(pen, x, y0, x0-x, y-y0);
						MyPictureBox->Image = bitmap;
						delete(pen);
						delete(pen2);
						x = newX;
						y = newY;
						pen = gcnew Pen(color, width);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->DrawRectangle(pen, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->DrawRectangle(pen, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->DrawRectangle(pen, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->DrawRectangle(pen, x, y0, x0-x, y-y0);
						}
						}
				break;
				case 2: {														//Перерисовка эллипса
					if((newX>=(x0-dx))&&(newX<=(x0+dx))&&(newY>=(y0-dy))&&(newY<=(y0+dy))) {
						Pen^ pen = gcnew Pen(Color::White, width);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen, x0, y0, x-x0, y-y0);
						MyPictureBox->Image = bitmap;
						delete(pen);
						delete(pen2);
						x0 = newX;
						y0 = newY;
						pen = gcnew Pen(color, width);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen, x0, y0, x-x0, y-y0);
						}
					else
						if((newX>=(x-dx))&&(newX<=(x+dx))&&(newY>=(y-dy))&&(newY<=(y+dy))) {
						Pen^ pen = gcnew Pen(Color::White, width);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen, x0, y0, x-x0, y-y0);
						MyPictureBox->Image = bitmap;
						delete(pen);
						delete(pen2);
						x = newX;
						y = newY;
						pen = gcnew Pen(color, width);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen, x0, y0, x-x0, y-y0);
						}
						}
				break;
				case 3: {//														//Перерисовка закрашенного прямоугольника
						if((newX>=(x0-dx))&&(newX<=(x0+dx))&&(newY>=(y0-dy))&&(newY<=(y0+dy))) {
						Brush^ brush = gcnew SolidBrush(Color::White);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillRectangle(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillRectangle(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillRectangle(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillRectangle(brush, x, y0, x0-x, y-y0);
						MyPictureBox->Image = bitmap;
						delete(brush);
						delete(pen2);
						x0 = newX;
						y0 = newY;
						brush = gcnew SolidBrush(color);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillRectangle(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillRectangle(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillRectangle(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillRectangle(brush, x, y0, x0-x, y-y0);
						}
						else
						if((newX>=(x-dx))&&(newX<=(x+dx))&&(newY>=(y-dy))&&(newY<=(y+dy))) {
						Brush^ brush = gcnew SolidBrush(Color::White);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillRectangle(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillRectangle(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillRectangle(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillRectangle(brush, x, y0, x0-x, y-y0);
						MyPictureBox->Image = bitmap;
						delete(brush);
						delete(pen2);
						x = newX;
						y = newY;
						brush = gcnew SolidBrush(color);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillRectangle(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillRectangle(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillRectangle(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillRectangle(brush, x, y0, x0-x, y-y0);
						}
						}
				break;
				case 4: {
						if((newX>=(x0-dx))&&(newX<=(x0+dx))&&(newY>=(y0-dy))&&(newY<=(y0+dy))) {
						Brush^ brush = gcnew SolidBrush(Color::White);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillEllipse(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillEllipse(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillEllipse(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillEllipse(brush, x, y0, x0-x, y-y0);
						MyPictureBox->Image = bitmap;
						delete(brush);
						delete(pen2);
						x0 = newX;
						y0 = newY;
						brush = gcnew SolidBrush(color);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillEllipse(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillEllipse(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillEllipse(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillEllipse(brush, x, y0, x0-x, y-y0);
						}
						else
						if((newX>=(x-dx))&&(newX<=(x+dx))&&(newY>=(y-dy))&&(newY<=(y+dy))) {
						Brush^ brush = gcnew SolidBrush(Color::White);
						Pen^ pen2 = gcnew Pen(Color::White, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						gr1->FillEllipse(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillEllipse(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillEllipse(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillEllipse(brush, x, y0, x0-x, y-y0);
						MyPictureBox->Image = bitmap;
						delete(brush);
						delete(pen2);
						x = newX;
						y = newY;
						brush = gcnew SolidBrush(color);
						pen2 = gcnew Pen(Color::Gray, 1);
						gr1->DrawEllipse(pen2, x0-(dx+width)/2, y0-(dy+width)/2, dx+width, dy+width);
						gr1->DrawEllipse(pen2, x+(-dx-width)/2, y+(-dy-width)/2, dx+width, dy+width);
						if(x>=x0 && y>=y0)
						if(x>=x0 && y>=y0)
						gr1->FillEllipse(brush, x0, y0, x-x0, y-y0);
						if(x>=x0 && y<y0)
						gr1->FillEllipse(brush, x0, y, x-x0, y0-y);
						if(x<x0 && y<y0)
						gr1->FillEllipse(brush, x, y, x0-x, y0-y);
						if(x<x0 && y>=y0)
						gr1->FillEllipse(brush, x, y0, x0-x, y-y0);
						}
						}
				break;
				default: {
						 
						 }
				}
				MyPictureBox->Image = bitmap;
			}
	public: 
	};
/*===========================================================================================*/
/*===========================================================================================
		public ref class ArrayShape 
		{		
			protected: Int32 Counter, Size;

			public: ArrayShape() 
			{
				Size = 0;
				Counter = 0;
			}

			protected: ~ArrayShape() {   }

			public: array<Shape^>^ List;
			protected: array<Shape^>^ DopList;
			protected: Int32 Counter;
			public: Int32 lx0;
			public: Int32 ly0;
			public: Int32 lx;
			public: Int32 ly;
			public: FILE* ff;
			protected: void ChangeCounter(void) 
			{
			Counter++;
			}

		};//END CLASS ArrayShape





	------------------------------FORMA--------------------------------*/
	public ref class Form1 : public System::Windows::Forms::Form
	{
		#pragma region VOTONO
		public:
			Form1(void)
			{
				InitializeComponent();
				bitmap = gcnew Bitmap(800,800);//(pictureBox1->Width, pictureBox1->Height);
			}

		protected:
			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			~Form1()
			{
				if (components)
				{
					delete components;
				}
			}

		public: ArrayShape^ ArrS;
		public: Bitmap^ bitmap;//System::Drawing Bitmap

		private: System::Windows::Forms::Panel^  panel1;
		private: System::Windows::Forms::Panel^  panel2;
		private: System::Windows::Forms::Panel^  panel3;
		private: System::Windows::Forms::Panel^  panel4;
		private: System::Windows::Forms::Panel^  panel5;
		private: System::Windows::Forms::Panel^  panel6;
		private: System::Windows::Forms::Panel^  panel7;
		private: System::Windows::Forms::Panel^  panel8;
		private: System::Windows::Forms::TrackBar^  trackBar1;
		private: System::Windows::Forms::Panel^  panel9;
		private: System::Windows::Forms::Panel^  panel10;
		private: System::Windows::Forms::Panel^  panel11;
		private: System::Windows::Forms::Panel^  panel12;
		private: System::Windows::Forms::Panel^  panel13;
		private: System::Windows::Forms::Panel^  panel14;
		private: System::Windows::Forms::Panel^  panel15;
		private: System::Windows::Forms::Panel^  panel16;
		private: System::Windows::Forms::Label^  label1;
		private: System::Windows::Forms::Panel^  panel17;
		private: System::Windows::Forms::PictureBox^  pictureBox1;
	private: System::Windows::Forms::ToolTip^  toolTip1;
	private: System::Windows::Forms::Panel^  panel18;
	private: System::ComponentModel::IContainer^  components;
	protected: 
	#pragma endregion

		protected: 

		private:
			/// <summary>
			/// Required designer variable.
			/// </summary>


		#pragma region Windows Form Designer generated code
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			void InitializeComponent(void)
			{
				this->components = (gcnew System::ComponentModel::Container());
				System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
				this->panel1 = (gcnew System::Windows::Forms::Panel());
				this->panel2 = (gcnew System::Windows::Forms::Panel());
				this->panel3 = (gcnew System::Windows::Forms::Panel());
				this->panel4 = (gcnew System::Windows::Forms::Panel());
				this->panel5 = (gcnew System::Windows::Forms::Panel());
				this->panel6 = (gcnew System::Windows::Forms::Panel());
				this->panel7 = (gcnew System::Windows::Forms::Panel());
				this->panel8 = (gcnew System::Windows::Forms::Panel());
				this->trackBar1 = (gcnew System::Windows::Forms::TrackBar());
				this->panel9 = (gcnew System::Windows::Forms::Panel());
				this->panel10 = (gcnew System::Windows::Forms::Panel());
				this->panel11 = (gcnew System::Windows::Forms::Panel());
				this->panel12 = (gcnew System::Windows::Forms::Panel());
				this->panel13 = (gcnew System::Windows::Forms::Panel());
				this->panel14 = (gcnew System::Windows::Forms::Panel());
				this->panel15 = (gcnew System::Windows::Forms::Panel());
				this->panel16 = (gcnew System::Windows::Forms::Panel());
				this->label1 = (gcnew System::Windows::Forms::Label());
				this->panel17 = (gcnew System::Windows::Forms::Panel());
				this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
				this->toolTip1 = (gcnew System::Windows::Forms::ToolTip(this->components));
				this->panel18 = (gcnew System::Windows::Forms::Panel());
				(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->trackBar1))->BeginInit();
				(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->BeginInit();
				this->panel18->SuspendLayout();
				this->SuspendLayout();
				// 
				// panel1
				// 
				this->panel1->BackColor = System::Drawing::SystemColors::ButtonHighlight;
				this->panel1->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel1.BackgroundImage")));
				this->panel1->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel1->Location = System::Drawing::Point(22, 21);
				this->panel1->Name = L"panel1";
				this->panel1->Size = System::Drawing::Size(33, 33);
				this->panel1->TabIndex = 1;
				this->toolTip1->SetToolTip(this->panel1, L"Select");
				this->panel1->Click += gcnew System::EventHandler(this, &Form1::panel1_Click);
				// 
				// panel2
				// 
				this->panel2->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel2.BackgroundImage")));
				this->panel2->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel2->Location = System::Drawing::Point(80, 21);
				this->panel2->Name = L"panel2";
				this->panel2->Size = System::Drawing::Size(33, 33);
				this->panel2->TabIndex = 2;
				this->toolTip1->SetToolTip(this->panel2, L"DeSelect");
				this->panel2->Click += gcnew System::EventHandler(this, &Form1::panel2_Click);
				// 
				// panel3
				// 
				this->panel3->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel3.BackgroundImage")));
				this->panel3->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel3->Location = System::Drawing::Point(141, 21);
				this->panel3->Name = L"panel3";
				this->panel3->Size = System::Drawing::Size(33, 33);
				this->panel3->TabIndex = 2;
				this->toolTip1->SetToolTip(this->panel3, L"Ellips");
				this->panel3->Click += gcnew System::EventHandler(this, &Form1::panel3_Click);
				// 
				// panel4
				// 
				this->panel4->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel4.BackgroundImage")));
				this->panel4->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel4->Location = System::Drawing::Point(206, 21);
				this->panel4->Name = L"panel4";
				this->panel4->Size = System::Drawing::Size(33, 33);
				this->panel4->TabIndex = 3;
				this->toolTip1->SetToolTip(this->panel4, L"Rectangle");
				this->panel4->Click += gcnew System::EventHandler(this, &Form1::panel4_Click);
				// 
				// panel5
				// 
				this->panel5->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel5.BackgroundImage")));
				this->panel5->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel5->Location = System::Drawing::Point(22, 67);
				this->panel5->Name = L"panel5";
				this->panel5->Size = System::Drawing::Size(33, 33);
				this->panel5->TabIndex = 7;
				this->toolTip1->SetToolTip(this->panel5, L"CleanUP");
				this->panel5->Click += gcnew System::EventHandler(this, &Form1::panel5_Click);
				// 
				// panel6
				// 
				this->panel6->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel6.BackgroundImage")));
				this->panel6->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel6->Location = System::Drawing::Point(141, 67);
				this->panel6->Name = L"panel6";
				this->panel6->Size = System::Drawing::Size(33, 33);
				this->panel6->TabIndex = 6;
				this->toolTip1->SetToolTip(this->panel6, L"FillEllips");
				this->panel6->Click += gcnew System::EventHandler(this, &Form1::panel6_Click);
				// 
				// panel7
				// 
				this->panel7->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel7.BackgroundImage")));
				this->panel7->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel7->Location = System::Drawing::Point(80, 67);
				this->panel7->Name = L"panel7";
				this->panel7->Size = System::Drawing::Size(33, 33);
				this->panel7->TabIndex = 5;
				this->toolTip1->SetToolTip(this->panel7, L"Line");
				this->panel7->Click += gcnew System::EventHandler(this, &Form1::panel7_Click);
				// 
				// panel8
				// 
				this->panel8->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel8.BackgroundImage")));
				this->panel8->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel8->Location = System::Drawing::Point(206, 67);
				this->panel8->Name = L"panel8";
				this->panel8->Size = System::Drawing::Size(33, 33);
				this->panel8->TabIndex = 4;
				this->toolTip1->SetToolTip(this->panel8, L"FillRectangle");
				this->panel8->Click += gcnew System::EventHandler(this, &Form1::panel8_Click);
				// 
				// trackBar1
				// 
				this->trackBar1->LargeChange = 2;
				this->trackBar1->Location = System::Drawing::Point(22, 106);
				this->trackBar1->Minimum = 2;
				this->trackBar1->Name = L"trackBar1";
				this->trackBar1->Size = System::Drawing::Size(217, 45);
				this->trackBar1->TabIndex = 8;
				this->trackBar1->TickFrequency = 2;
				this->trackBar1->Value = 2;
				this->trackBar1->Scroll += gcnew System::EventHandler(this, &Form1::trackBar1_Scroll);
				// 
				// panel9
				// 
				this->panel9->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel9->BackColor = System::Drawing::Color::Purple;
				this->panel9->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel9->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel9->Location = System::Drawing::Point(206, 340);
				this->panel9->Name = L"panel9";
				this->panel9->Size = System::Drawing::Size(38, 27);
				this->panel9->TabIndex = 16;
				this->toolTip1->SetToolTip(this->panel9, L"Purple");
				this->panel9->Click += gcnew System::EventHandler(this, &Form1::panel9_Click);
				// 
				// panel10
				// 
				this->panel10->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel10->BackColor = System::Drawing::Color::Black;
				this->panel10->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel10->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel10->Location = System::Drawing::Point(141, 340);
				this->panel10->Name = L"panel10";
				this->panel10->Size = System::Drawing::Size(38, 27);
				this->panel10->TabIndex = 15;
				this->toolTip1->SetToolTip(this->panel10, L"Black");
				this->panel10->Click += gcnew System::EventHandler(this, &Form1::panel10_Click);
				// 
				// panel11
				// 
				this->panel11->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel11->BackColor = System::Drawing::Color::Blue;
				this->panel11->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel11->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel11->Location = System::Drawing::Point(80, 340);
				this->panel11->Name = L"panel11";
				this->panel11->Size = System::Drawing::Size(38, 27);
				this->panel11->TabIndex = 14;
				this->toolTip1->SetToolTip(this->panel11, L"Blue");
				this->panel11->Click += gcnew System::EventHandler(this, &Form1::panel11_Click);
				// 
				// panel12
				// 
				this->panel12->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel12->BackColor = System::Drawing::Color::White;
				this->panel12->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel12->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel12->Location = System::Drawing::Point(22, 340);
				this->panel12->Name = L"panel12";
				this->panel12->Size = System::Drawing::Size(38, 27);
				this->panel12->TabIndex = 13;
				this->toolTip1->SetToolTip(this->panel12, L"White");
				this->panel12->Click += gcnew System::EventHandler(this, &Form1::panel12_Click);
				// 
				// panel13
				// 
				this->panel13->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel13->BackColor = System::Drawing::Color::Green;
				this->panel13->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel13->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel13->Location = System::Drawing::Point(206, 294);
				this->panel13->Name = L"panel13";
				this->panel13->Size = System::Drawing::Size(38, 27);
				this->panel13->TabIndex = 12;
				this->toolTip1->SetToolTip(this->panel13, L"Green");
				this->panel13->Click += gcnew System::EventHandler(this, &Form1::panel13_Click);
				// 
				// panel14
				// 
				this->panel14->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel14->BackColor = System::Drawing::Color::Yellow;
				this->panel14->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel14->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel14->Location = System::Drawing::Point(141, 294);
				this->panel14->Name = L"panel14";
				this->panel14->Size = System::Drawing::Size(38, 27);
				this->panel14->TabIndex = 10;
				this->toolTip1->SetToolTip(this->panel14, L"Yellow");
				this->panel14->Click += gcnew System::EventHandler(this, &Form1::panel14_Click);
				// 
				// panel15
				// 
				this->panel15->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel15->BackColor = System::Drawing::Color::Red;
				this->panel15->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel15->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel15->Location = System::Drawing::Point(80, 294);
				this->panel15->Name = L"panel15";
				this->panel15->Size = System::Drawing::Size(38, 27);
				this->panel15->TabIndex = 11;
				this->toolTip1->SetToolTip(this->panel15, L"Red");
				this->panel15->Click += gcnew System::EventHandler(this, &Form1::panel15_Click);
				// 
				// panel16
				// 
				this->panel16->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel16->BackColor = System::Drawing::Color::Orange;
				this->panel16->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel16->Cursor = System::Windows::Forms::Cursors::Hand;
				this->panel16->Location = System::Drawing::Point(22, 294);
				this->panel16->Name = L"panel16";
				this->panel16->Size = System::Drawing::Size(38, 27);
				this->panel16->TabIndex = 9;
				this->toolTip1->SetToolTip(this->panel16, L"Orange");
				this->panel16->Click += gcnew System::EventHandler(this, &Form1::panel16_Click);
				// 
				// label1
				// 
				this->label1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->label1->AutoSize = true;
				this->label1->Location = System::Drawing::Point(28, 255);
				this->label1->Name = L"label1";
				this->label1->Size = System::Drawing::Size(32, 13);
				this->label1->TabIndex = 17;
				this->label1->Text = L"Цвет";
				// 
				// panel17
				// 
				this->panel17->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
				this->panel17->BackColor = System::Drawing::SystemColors::ButtonHighlight;
				this->panel17->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"panel17.BackgroundImage")));
				this->panel17->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
				this->panel17->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->panel17->CausesValidation = false;
				this->panel17->Location = System::Drawing::Point(80, 251);
				this->panel17->Name = L"panel17";
				this->panel17->Size = System::Drawing::Size(38, 27);
				this->panel17->TabIndex = 18;
				this->toolTip1->SetToolTip(this->panel17, L"button15");
				// 
				// pictureBox1
				// 
				this->pictureBox1->BackColor = System::Drawing::SystemColors::ButtonHighlight;
				this->pictureBox1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
				this->pictureBox1->Cursor = System::Windows::Forms::Cursors::Cross;
				this->pictureBox1->Dock = System::Windows::Forms::DockStyle::Right;
				this->pictureBox1->Location = System::Drawing::Point(256, 0);
				this->pictureBox1->Name = L"pictureBox1";
				this->pictureBox1->Size = System::Drawing::Size(436, 384);
				this->pictureBox1->TabIndex = 19;
				this->pictureBox1->TabStop = false;
				this->pictureBox1->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseMove);
				this->pictureBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseDown);
				this->pictureBox1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseUp);
				// 
				// panel18
				// 
				this->panel18->Controls->Add(this->pictureBox1);
				this->panel18->Controls->Add(this->trackBar1);
				this->panel18->Controls->Add(this->panel5);
				this->panel18->Controls->Add(this->panel8);
				this->panel18->Dock = System::Windows::Forms::DockStyle::Fill;
				this->panel18->Location = System::Drawing::Point(0, 0);
				this->panel18->Name = L"panel18";
				this->panel18->Size = System::Drawing::Size(692, 384);
				this->panel18->TabIndex = 20;
				// 
				// Form1
				// 
				this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
				this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
				this->ClientSize = System::Drawing::Size(692, 384);
				this->Controls->Add(this->panel1);
				this->Controls->Add(this->panel17);
				this->Controls->Add(this->label1);
				this->Controls->Add(this->panel9);
				this->Controls->Add(this->panel10);
				this->Controls->Add(this->panel11);
				this->Controls->Add(this->panel12);
				this->Controls->Add(this->panel13);
				this->Controls->Add(this->panel14);
				this->Controls->Add(this->panel15);
				this->Controls->Add(this->panel16);
				this->Controls->Add(this->panel6);
				this->Controls->Add(this->panel7);
				this->Controls->Add(this->panel4);
				this->Controls->Add(this->panel3);
				this->Controls->Add(this->panel2);
				this->Controls->Add(this->panel18);
				this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
				this->Name = L"Form1";
				this->Text = L"Рисоблудка";
				this->Resize += gcnew System::EventHandler(this, &Form1::Form1_Resize);
				(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->trackBar1))->EndInit();
				(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->EndInit();
				this->panel18->ResumeLayout(false);
				this->panel18->PerformLayout();
				this->ResumeLayout(false);
				this->PerformLayout();

			}
	#pragma endregion
		

		/*-------------------------------EVENTS-------------------------------*/
		
		bool controlKist;
		bool logKist;
		bool logLastik;
		bool logLine;
		bool logEllips;
		bool logRectangle;
		bool logFillEllips;
		bool logFillRectangle;


	private: System::Void pictureBox1_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
			 logKist = true;
				 this->ArrS->lx0 = e->X;
				 this->ArrS->ly0 = e->Y;
			 }


private: System::Void pictureBox1_MouseUp(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
		 logKist = false;
				 if(logLine == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(0, this->trackBar1->Value, this->panel17->BackColor, bitmap, pictureBox1);
				 }
				 if(logFillEllips) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(4, this->trackBar1->Value, this->panel17->BackColor, bitmap, pictureBox1);
				 }
				 if(logEllips == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(2, this->trackBar1->Value, this->panel17->BackColor, bitmap, pictureBox1);
				 }
				 if(logRectangle == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(1, this->trackBar1->Value, this->panel17->BackColor, bitmap, pictureBox1);
				 }
				 if(logFillRectangle == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(3, this->trackBar1->Value, this->panel17->BackColor, bitmap, pictureBox1);
				 }
		 }
private: System::Void pictureBox1_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
			 if(controlKist && logKist) {
				 this->ArrS->FoundShape(e->X, e->Y, bitmap, pictureBox1);
				 }
		 }
private: System::Void panel1_Click(System::Object^  sender, System::EventArgs^  e) {
			 controlKist = true;
				 logLastik = true;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->RedrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel2_Click(System::Object^  sender, System::EventArgs^  e) {
 controlKist = true;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel3_Click(System::Object^  sender, System::EventArgs^  e) {
			 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = true;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel4_Click(System::Object^  sender, System::EventArgs^  e) {
			 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = true;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel8_Click(System::Object^  sender, System::EventArgs^  e) {
			 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = true;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel7_Click(System::Object^  sender, System::EventArgs^  e) {
			 controlKist = false;
				 logLine = true;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel6_Click(System::Object^  sender, System::EventArgs^  e) {
			 controlKist = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = true;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
		 }
private: System::Void panel5_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->ArrS->DelAll(bitmap, pictureBox1);
		 }



private: System::Void panel16_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::Orange;
		 }
private: System::Void panel15_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::Red;
		 }
private: System::Void panel14_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::Yellow;
		 }
private: System::Void panel13_Click(System::Object^  sender, System::EventArgs^  e) {
			  this->panel17->BackColor = System::Drawing::Color::Green;
		 }
private: System::Void panel12_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::White;
		 }
private: System::Void panel11_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::Blue;
		 }
private: System::Void panel10_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::Black;
		 }
private: System::Void panel9_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->panel17->BackColor = System::Drawing::Color::Purple;
		 }

private: System::Void trackBar1_Scroll(System::Object^  sender, System::EventArgs^  e) {
			 Shape^ spe;
			 spe->width = trackBar1->Value;
			 //MessageBox::Show(trackBar1->Value.ToString());
		 }
private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
			 pictureBox1->Width = panel18->Width-265;
		 }
};//END CLASS FORMA

	/*----------------------------END-FORMA--------------------------------*/




}//END NAMESPACE

