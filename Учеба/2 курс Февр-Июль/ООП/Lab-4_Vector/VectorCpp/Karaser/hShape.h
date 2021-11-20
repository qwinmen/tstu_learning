//QwinCor @ 2014
// заголовочный файл hShape.h
//В данном файле будет содержаться прототип функции 
#include <iostream>
using namespace System::Windows::Forms;
using namespace System::Drawing;
// объявление класса

//В хидер запихиваешь декларацию класса
public ref class Shape
{
	//variables:
	public: int dx, dy, Name, x0, y0, x, y, Type;
	public: static int width;


	public: System::Drawing::Color color;

	//methods\func
	private:
	   void Func();

	public: void Draw(int TypeS, System::Drawing::Bitmap^ bitmap, System::Windows::Forms::PictureBox^ MyPictureBox);
	public: void Redraw(int newX, int newY, Bitmap^ bitmap, PictureBox^ MyPictureBox);

	//constructor\destructor:
	public:
	   Shape();
	   virtual ~Shape();
};
