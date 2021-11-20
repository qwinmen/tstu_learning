//QwinCor @ 2014
//Далее подключаем этот файл hShape.h к проекту 
#include "stdafx.h"
#include "hShape.h"
using namespace System::Drawing;
//Теперь наш заголовочный файл подключен к проекту

//В .cpp запихиваешь реализацию:
Shape::Shape()
{
    // constuructor implementation
			dx = 8;
			dy = 8;
			width = 2;
			color = System::Drawing::Color::Black;
}

Shape::~Shape()
{    /* Destructor*/	}

//Methods Classa ArrayShape

void Shape::Func()
{
    //return 0;// что-то сделать
}

void Shape::Draw(int TypeS, System::Drawing::Bitmap^ bitmap, System::Windows::Forms::PictureBox^ MyPictureBox)
{
	System::Drawing::Graphics^ gr1 = System::Drawing::Graphics::FromImage(bitmap);
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

void Shape::Redraw(int newX, int newY, Bitmap^ bitmap, PictureBox^ MyPictureBox)
{
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


;
