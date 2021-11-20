#pragma once
#include<stdio.h>
#include<math.h>

namespace OOP42 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;



	
	/// <summary>
	/// Сводка для Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	

		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	public: Bitmap^ bitmap;
	public: ArrayShape^ ArrS;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::PictureBox^  pictureBox1;
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::TrackBar^  trackBar1;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::Button^  button4;
	private: System::Windows::Forms::Button^  button5;
	private: System::Windows::Forms::Button^  button6;
	private: System::Windows::Forms::Button^  button7;
	private: System::Windows::Forms::Button^  button8;
	private: System::Windows::Forms::Button^  button9;
	private: System::Windows::Forms::Button^  button10;
	private: System::Windows::Forms::Button^  button11;
	private: System::Windows::Forms::Button^  button12;
	private: System::Windows::Forms::Button^  button13;
	private: System::Windows::Forms::Button^  button14;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Button^  button15;
	private: System::Windows::Forms::Button^  button16;
	private: System::Windows::Forms::Button^  button17;

	private: System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
			 /*
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->trackBar1 = (gcnew System::Windows::Forms::TrackBar());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->button6 = (gcnew System::Windows::Forms::Button());
			this->button7 = (gcnew System::Windows::Forms::Button());
			this->button8 = (gcnew System::Windows::Forms::Button());
			this->button9 = (gcnew System::Windows::Forms::Button());
			this->button10 = (gcnew System::Windows::Forms::Button());
			this->button11 = (gcnew System::Windows::Forms::Button());
			this->button12 = (gcnew System::Windows::Forms::Button());
			this->button13 = (gcnew System::Windows::Forms::Button());
			this->button14 = (gcnew System::Windows::Forms::Button());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->button15 = (gcnew System::Windows::Forms::Button());
			this->button16 = (gcnew System::Windows::Forms::Button());
			this->button17 = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->trackBar1))->BeginInit();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->BackColor = System::Drawing::Color::White;
			this->button1->Location = System::Drawing::Point(12, 85);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(200, 25);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Изменить";
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// pictureBox1
			// 
			this->pictureBox1->BackColor = System::Drawing::SystemColors::Window;
			this->pictureBox1->Location = System::Drawing::Point(221, 29);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(551, 321);
			this->pictureBox1->TabIndex = 1;
			this->pictureBox1->TabStop = false;
			this->pictureBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseDown);
			this->pictureBox1->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseMove);
			this->pictureBox1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseUp);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(12, 134);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(200, 25);
			this->button2->TabIndex = 2;
			this->button2->Text = L"Пусто";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->MouseClick += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::button2_MouseClick);
			// 
			// trackBar1
			// 
			this->trackBar1->BackColor = System::Drawing::SystemColors::Control;
			this->trackBar1->LargeChange = 1;
			this->trackBar1->Location = System::Drawing::Point(12, 242);
			this->trackBar1->Maximum = 12;
			this->trackBar1->Minimum = 2;
			this->trackBar1->Name = L"trackBar1";
			this->trackBar1->Size = System::Drawing::Size(200, 45);
			this->trackBar1->TabIndex = 3;
			this->trackBar1->Value = 2;
			// 
			// button3
			// 
			this->button3->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button3.Image")));
			this->button3->Location = System::Drawing::Point(12, 12);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(38, 20);
			this->button3->TabIndex = 4;
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &Form1::button3_Click);
			// 
			// button4
			// 
			this->button4->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button4.BackgroundImage")));
			this->button4->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button4.Image")));
			this->button4->Location = System::Drawing::Point(56, 12);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(38, 20);
			this->button4->TabIndex = 5;
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &Form1::button4_Click);
			// 
			// button5
			// 
			this->button5->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button5.BackgroundImage")));
			this->button5->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button5.Image")));
			this->button5->Location = System::Drawing::Point(12, 38);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(38, 25);
			this->button5->TabIndex = 6;
			this->button5->UseVisualStyleBackColor = true;
			this->button5->Click += gcnew System::EventHandler(this, &Form1::button5_Click);
			// 
			// button6
			// 
			this->button6->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button6.BackgroundImage")));
			this->button6->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button6.Image")));
			this->button6->Location = System::Drawing::Point(56, 38);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(38, 25);
			this->button6->TabIndex = 7;
			this->button6->UseVisualStyleBackColor = true;
			this->button6->Click += gcnew System::EventHandler(this, &Form1::button6_Click);
			// 
			// button7
			// 
			this->button7->BackColor = System::Drawing::Color::Black;
			this->button7->Location = System::Drawing::Point(85, 335);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(23, 20);
			this->button7->TabIndex = 8;
			this->button7->UseVisualStyleBackColor = false;
			this->button7->Click += gcnew System::EventHandler(this, &Form1::button7_Click);
			// 
			// button8
			// 
			this->button8->BackColor = System::Drawing::Color::Orange;
			this->button8->Location = System::Drawing::Point(56, 309);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(23, 20);
			this->button8->TabIndex = 8;
			this->button8->UseVisualStyleBackColor = false;
			this->button8->Click += gcnew System::EventHandler(this, &Form1::button8_Click);
			// 
			// button9
			// 
			this->button9->BackColor = System::Drawing::Color::Yellow;
			this->button9->Location = System::Drawing::Point(85, 309);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(23, 20);
			this->button9->TabIndex = 8;
			this->button9->UseVisualStyleBackColor = false;
			this->button9->Click += gcnew System::EventHandler(this, &Form1::button9_Click);
			// 
			// button10
			// 
			this->button10->BackColor = System::Drawing::Color::Green;
			this->button10->Location = System::Drawing::Point(114, 309);
			this->button10->Name = L"button10";
			this->button10->Size = System::Drawing::Size(23, 20);
			this->button10->TabIndex = 8;
			this->button10->UseVisualStyleBackColor = false;
			this->button10->Click += gcnew System::EventHandler(this, &Form1::button10_Click);
			// 
			// button11
			// 
			this->button11->BackColor = System::Drawing::Color::Red;
			this->button11->Location = System::Drawing::Point(27, 309);
			this->button11->Name = L"button11";
			this->button11->Size = System::Drawing::Size(23, 20);
			this->button11->TabIndex = 8;
			this->button11->UseVisualStyleBackColor = false;
			this->button11->Click += gcnew System::EventHandler(this, &Form1::button11_Click);
			// 
			// button12
			// 
			this->button12->BackColor = System::Drawing::Color::White;
			this->button12->Location = System::Drawing::Point(27, 335);
			this->button12->Name = L"button12";
			this->button12->Size = System::Drawing::Size(23, 20);
			this->button12->TabIndex = 8;
			this->button12->UseVisualStyleBackColor = false;
			this->button12->Click += gcnew System::EventHandler(this, &Form1::button12_Click);
			// 
			// button13
			// 
			this->button13->BackColor = System::Drawing::Color::Blue;
			this->button13->Location = System::Drawing::Point(56, 335);
			this->button13->Name = L"button13";
			this->button13->Size = System::Drawing::Size(23, 20);
			this->button13->TabIndex = 8;
			this->button13->UseVisualStyleBackColor = false;
			this->button13->Click += gcnew System::EventHandler(this, &Form1::button13_Click);
			// 
			// button14
			// 
			this->button14->BackColor = System::Drawing::Color::Purple;
			this->button14->Location = System::Drawing::Point(114, 335);
			this->button14->Name = L"button14";
			this->button14->Size = System::Drawing::Size(23, 20);
			this->button14->TabIndex = 8;
			this->button14->UseVisualStyleBackColor = false;
			this->button14->Click += gcnew System::EventHandler(this, &Form1::button14_Click);
			// 
			// textBox1
			// 
			this->textBox1->BackColor = System::Drawing::SystemColors::Control;
			this->textBox1->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->textBox1->Location = System::Drawing::Point(24, 283);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(42, 13);
			this->textBox1->TabIndex = 9;
			this->textBox1->Text = L"Цвет: ";
			// 
			// button15
			// 
			this->button15->BackColor = System::Drawing::Color::Black;
			this->button15->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button15->Location = System::Drawing::Point(85, 283);
			this->button15->Name = L"button15";
			this->button15->Size = System::Drawing::Size(23, 20);
			this->button15->TabIndex = 8;
			this->button15->UseVisualStyleBackColor = false;
			// 
			// button16
			// 
			this->button16->BackgroundImage = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button16.BackgroundImage")));
			this->button16->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button16.Image")));
			this->button16->Location = System::Drawing::Point(100, 10);
			this->button16->Name = L"button16";
			this->button16->Size = System::Drawing::Size(38, 25);
			this->button16->TabIndex = 7;
			this->button16->UseVisualStyleBackColor = true;
			this->button16->Click += gcnew System::EventHandler(this, &Form1::button16_Click);
			// 
			// button17
			// 
			this->button17->Location = System::Drawing::Point(12, 180);
			this->button17->Name = L"button17";
			this->button17->Size = System::Drawing::Size(200, 25);
			this->button17->TabIndex = 7;
			this->button17->Text = L"Очистить";
			this->button17->UseVisualStyleBackColor = true;
			this->button17->Click += gcnew System::EventHandler(this, &Form1::button17_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(784, 362);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->button10);
			this->Controls->Add(this->button9);
			this->Controls->Add(this->button8);
			this->Controls->Add(this->button15);
			this->Controls->Add(this->button11);
			this->Controls->Add(this->button12);
			this->Controls->Add(this->button13);
			this->Controls->Add(this->button14);
			this->Controls->Add(this->button7);
			this->Controls->Add(this->button17);
			this->Controls->Add(this->button16);
			this->Controls->Add(this->button6);
			this->Controls->Add(this->button5);
			this->Controls->Add(this->button4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->trackBar1);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->button1);
			this->MaximumSize = System::Drawing::Size(800, 400);
			this->MinimumSize = System::Drawing::Size(800, 400);
			this->Name = L"Form1";
			this->Text = L"Векторная рисовалка";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->trackBar1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
		*/

public:
		Form1(void)
		{
			//InitializeComponent();
			bitmap = gcnew Bitmap(pictureBox1->Width, pictureBox1->Height);
			
		}


#pragma endregion
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
				 this->ArrS->Add(0, this->trackBar1->Value, this->button15->BackColor, bitmap, pictureBox1);
				 }
				 if(logFillEllips) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(4, this->trackBar1->Value, this->button15->BackColor, bitmap, pictureBox1);
				 }
				 if(logEllips == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(2, this->trackBar1->Value, this->button15->BackColor, bitmap, pictureBox1);
				 }
				 if(logRectangle == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(1, this->trackBar1->Value, this->button15->BackColor, bitmap, pictureBox1);
				 }
				 if(logFillRectangle == true) {
				 this->ArrS->lx = e->X;
				 this->ArrS->ly = e->Y;
				 this->ArrS->Add(3, this->trackBar1->Value, this->button15->BackColor, bitmap, pictureBox1);
				 }
			 }
	private: System::Void pictureBox1_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
				 if(controlKist && logKist) {
				 this->ArrS->FoundShape(e->X, e->Y, bitmap, pictureBox1);
				 }
			 }
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 controlKist = true;
				 logLastik = true;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->RedrawAll(bitmap, pictureBox1);
			 }
	private: System::Void button2_MouseClick(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
				 controlKist = true;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
			 }
			 private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {
				 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = true;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
			 }
	private: System::Void button4_Click(System::Object^  sender, System::EventArgs^  e) {
				 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = true;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
			 }
	private: System::Void button6_Click(System::Object^  sender, System::EventArgs^  e) {
				 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = true;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
			 }
	private: System::Void button16_Click(System::Object^  sender, System::EventArgs^  e) {
				 controlKist = false;
				 logLine = true;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
			 }

	private: System::Void button5_Click(System::Object^  sender, System::EventArgs^  e) {
				 controlKist = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = true;
				 logFillRectangle = false;
				 this->ArrS->DrawAll(bitmap, pictureBox1);
			 }
	private: System::Void button17_Click(System::Object^  sender, System::EventArgs^  e) {
				this->ArrS->DelAll(bitmap, pictureBox1);
			 }

private: System::Void button8_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Orange;
		 }
private: System::Void button11_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Red;
		 }
private: System::Void button9_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Yellow;
		 }
private: System::Void button10_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Green;
		 }
private: System::Void button12_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::White;
		 }
private: System::Void button13_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Blue;
		 }
private: System::Void button7_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Black;
		 }
private: System::Void button14_Click(System::Object^  sender, System::EventArgs^  e) {
			 this->button15->BackColor = System::Drawing::Color::Purple;
		 }

private: System::Void InitializeComponent() {
			 this->SuspendLayout();
			 // 
			 // Form1
			 // 
			 this->ClientSize = System::Drawing::Size(403, 262);
			 this->Name = L"Form1";
			 this->WindowState = System::Windows::Forms::FormWindowState::Maximized;
			 this->ResumeLayout(false);

}
};

//-------------------------------------------------------------//	
//-------------------------------------------------------------//
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
//-------------------------------------------------------------//
//-------------------------------------------------------------//	
	
	public ref class ArrayShape {
	public: ArrayShape() {
				Size = 0;
				Counter = 0;
			}
	protected: ~ArrayShape() {
			   }
	protected:Int32 Size;
	public: array<Shape^>^ List;
	protected: array<Shape^>^ DopList;
	protected: Int32 Counter;
	public: Int32 lx0;
	public: Int32 ly0;
	public: Int32 lx;
	public: Int32 ly;
	public: FILE* ff;
	protected: void ChangeCounter(void) {
			   Counter++;
			   }
	public: void Add(Int32 TypeShape, Int32 WidhtLine, Color colorS, Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				if(Size == 0) {
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
				else {
				DopList = gcnew array<Shape^> (Size);
				int i;
				for(i=0; i<Size; i++) {
				DopList[i] = List[i];
				}
				delete(List);
				Size++;
				List = gcnew array<Shape^> (Size);
				for(i=0; i<Size-1; i++) {
				List[i] = DopList[i];
				}
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
	public: void DrawAll(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				Graphics^ gr = Graphics::FromImage(bitmap);
				gr->Clear(Color::White);
				MyPictureBox->Image = bitmap;
				for(int i = 0; i<Size; i++) {
				List[i]->Draw(List[i]->Type, bitmap, MyPictureBox);
				}
			}
	public: void RedrawAll(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				Graphics^ gr = Graphics::FromImage(bitmap);
				gr->Clear(Color::White);
				MyPictureBox->Image = bitmap;
				for(int i = 0; i<Size; i++) {
					Pen^ pen2 = gcnew Pen(/*List[i]->color*/Color::Gray, 1);
					Graphics^ gr = Graphics::FromImage(bitmap);
					List[i]->Draw(List[i]->Type, bitmap, MyPictureBox);
					gr->DrawEllipse(pen2, List[i]->x0-(List[i]->dx+List[i]->width)/2, List[i]->y0-(List[i]->dy+List[i]->width)/2, List[i]->dx+List[i]->width, List[i]->dy+List[i]->width);
					gr->DrawEllipse(pen2, List[i]->x+(-List[i]->dx-List[i]->width)/2, List[i]->y+(-List[i]->dy-List[i]->width)/2, List[i]->dx+List[i]->width, List[i]->dy+List[i]->width);
				}
			}
	public: void FoundShape(Int32 nx, Int32 ny, Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				int i;
				for(i=Size-1; i>=0; i--) {
				if((nx>=(List[i]->x0-List[i]->dx))&&(nx<=(List[i]->x0+List[i]->dx))&&(ny>=(List[i]->y0-List[i]->dy))&&(ny<=(List[i]->y0+List[i]->dy))) {
				List[i]->Redraw(nx, ny, bitmap, MyPictureBox);
				break;
				}
				else
					if((nx>=(List[i]->x-List[i]->dx))&&(nx<=(List[i]->x+List[i]->dx))&&(ny>=(List[i]->y-List[i]->dy))&&(ny<=(List[i]->y+List[i]->dy))) {
				List[i]->Redraw(nx, ny, bitmap, MyPictureBox);
				break;
				}
				
				}
				RedrawAll(bitmap, MyPictureBox);
			}
	public: void DelAll(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
				Graphics^ gr = Graphics::FromImage(bitmap);
				gr->Clear(Color::White);
				MyPictureBox->Image = bitmap;
				Size = 0;
				delete(List);
			}
	};/**/
//-------------------------------------------------------------//
//-------------------------------------------------------------//

}

