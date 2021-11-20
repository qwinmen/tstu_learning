//QwinCor @ 2014
//Далее подключаем этот файл hArrayShape.h к проекту 
#include "stdafx.h"
#include "hArrayShape.h"
//#include "hShape.h" ошибка 'class' type redefinition
//Теперь наш заголовочный файл подключен к проекту


long double fact(int N)
{
    // если пользователь ввел отрицательное число
    if(N < 0)
        // возвращаем ноль
        return 0;
    // если пользователь ввел ноль
    if (N == 0)
        // возвращаем факториал нуля
        return 1;
    // Во всех остальных случаях
    else
        // делаем рекурсию
        return N * fact(N - 1);
}

//В .cpp запихиваешь реализацию:
ArrayShape::ArrayShape()
{
    // constuructor implementation
				Size = 0;
				Counter = 0;
}

ArrayShape::~ArrayShape()
{    /* Destructor*/	}

//Methods Classa ArrayShape

void ArrayShape::ChangeCounter()
{
    Counter++;
}

void ArrayShape::Add(int TypeShape, int WidhtLine, System::Drawing::Color colorS, System::Drawing::Bitmap^ bitmap, System::Windows::Forms::PictureBox^ MyPictureBox)
{
	if(Size == 0)
	{
		Size++;
		List = gcnew array<Shape^> (Size);
		List[0] = gcnew Shape();
		List[0]->Name = Counter;
		ChangeCounter();
		List[0]->Type = TypeShape;
		List[0]->width = WidhtLine;
		List[0]->color = colorS;
		List[0]->x0 = lx0;
		List[0]->y0 = ly0;
		List[0]->x = lx;
		List[0]->y = ly;
		List[0]->Draw(List[0]->Type, bitmap, MyPictureBox);;
	}
	else
	{
		DopList = gcnew array<Shape^> (Size);
		int i;
		for(i=0; i<Size; i++) {	DopList[i] = List[i];	}
		delete(List);
		Size++;
		List = gcnew array<Shape^> (Size);
		for(i=0; i<Size-1; i++) {	List[i] = DopList[i];	}
		delete(DopList);
		List[Size-1] = gcnew Shape();
		List[Size-1]->Name = Counter;
		ChangeCounter();
		List[Size-1]->Type = TypeShape;
		List[Size-1]->width = WidhtLine;
		List[Size-1]->color = colorS;
		List[Size-1]->x0 = lx0;
		List[Size-1]->y0 = ly0;
		List[Size-1]->x = lx;
		List[Size-1]->y = ly;
		List[Size-1]->Draw(List[Size-1]->Type, bitmap, MyPictureBox);
	}
}

void ArrayShape::DrawAll(Bitmap^ bitmap, PictureBox^ MyPictureBox)
{
	Graphics^ gr = Graphics::FromImage(bitmap);
	gr->Clear(Color::White);
	MyPictureBox->Image = bitmap;
	for(int i = 0; i<Size; i++) {	List[i]->Draw(List[i]->Type, bitmap, MyPictureBox);	}

}

void ArrayShape::RedrawAll(Bitmap^ bitmap, PictureBox^ MyPictureBox)
{
	Graphics^ gr = Graphics::FromImage(bitmap);
	gr->Clear(Color::White);
	MyPictureBox->Image = bitmap;
	//MessageBox::Show(Size.ToString());

	for(int i = 0; i<Size; i++) 	
	{
		Pen^ pen2 = gcnew Pen(/*List[i]->color*/Color::Gray, 1);
		Graphics^ gr = Graphics::FromImage(bitmap);
		List[i]->Draw(List[i]->Type, bitmap, MyPictureBox);
		gr->DrawEllipse(pen2, List[i]->x0-(List[i]->dx+List[i]->width)/2, List[i]->y0-(List[i]->dy+List[i]->width)/2, List[i]->dx+List[i]->width, List[i]->dy+List[i]->width);
		gr->DrawEllipse(pen2, List[i]->x+(-List[i]->dx-List[i]->width)/2, List[i]->y+(-List[i]->dy-List[i]->width)/2, List[i]->dx+List[i]->width, List[i]->dy+List[i]->width);
	}
}

void ArrayShape::FoundShape(int nx, int ny, Bitmap^ bitmap, PictureBox^ MyPictureBox)
{
	int i;
	for(i=Size-1; i>=0; i--) 
	{
		if((nx>=(List[i]->x0-List[i]->dx))&&(nx<=(List[i]->x0+List[i]->dx))&&(ny>=(List[i]->y0-List[i]->dy))&&(ny<=(List[i]->y0+List[i]->dy))) 
		{
			List[i]->Redraw(nx, ny, bitmap, MyPictureBox);
			break;
		}
		else if((nx>=(List[i]->x-List[i]->dx))&&(nx<=(List[i]->x+List[i]->dx))&&(ny>=(List[i]->y-List[i]->dy))&&(ny<=(List[i]->y+List[i]->dy))) 
		{
			List[i]->Redraw(nx, ny, bitmap, MyPictureBox);
			break;
		}
	}
	RedrawAll(bitmap, MyPictureBox);
}

void ArrayShape::DelAll(Bitmap^ bitmap, PictureBox^ MyPictureBox)
{
	Graphics^ gr = Graphics::FromImage(bitmap);
	gr->Clear(Color::White);
	MyPictureBox->Image = bitmap;
	Size = 0;
	delete(List);
}


;


