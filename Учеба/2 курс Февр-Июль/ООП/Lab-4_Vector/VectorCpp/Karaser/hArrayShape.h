//QwinCor @ 2014
// заголовочный файл hArrayShape.h
//В данном файле будет содержаться прототип функции 
#include <iostream>
#include "hShape.h"
using namespace System::Windows::Forms;
using namespace System::Drawing;
//using namespace Karaser;
 
// объявление класса
long double fact(int N);

//В хидер запихиваешь декларацию класса
public ref class ArrayShape
{
	//variables:
	public: 
		static int Size, Counter;
	public: static array<Shape^>^ List;
	public: static array<Shape^>^ DopList;

	public: static int lx0, ly0, lx, ly;
	public: FILE* ff;
	
	//methods\func
private: void ChangeCounter();
public: void Add(int TypeShape, int WidhtLine, System::Drawing::Color colorS, System::Drawing::Bitmap^ bitmap, System::Windows::Forms::PictureBox^ MyPictureBox);
public: void DrawAll(Bitmap^ bitmap, PictureBox^ MyPictureBox);
public: void RedrawAll(Bitmap^ bitmap, PictureBox^ MyPictureBox);
public: void FoundShape(int nx, int ny, Bitmap^ bitmap, PictureBox^ MyPictureBox);
public: void DelAll(Bitmap^ bitmap, PictureBox^ MyPictureBox);

	//constructor\destructor:
	public:
	   ArrayShape();
	   virtual ~ArrayShape();
};


//-------------------------------------------------------------//