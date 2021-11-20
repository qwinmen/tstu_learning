#pragma once
#include<stdio.h>
#include<math.h>

namespace OOP2K {

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
	public:
		Form1(void) // Инициализируем компоненты
		{
			InitializeComponent();
			bitmap = gcnew Bitmap(pictureBox1->Width, pictureBox1->Height);
			kist = gcnew Kist();
			rect = gcnew Rectangle();
			frect = gcnew FillRectangle();
			ell = gcnew Ellipse();
			fell = gcnew FillEllipse();
			line = gcnew Line();
		}

		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
		// Объявляем компоненты
	public: Bitmap^ bitmap;
	private: Kist^ kist;
	private: Rectangle^ rect;
	private: Ellipse^ ell;
	private: FillRectangle^ frect;
	private: FillEllipse^ fell;
	private: Line^ line;
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
	private: System::Windows::Forms::ToolTip^  toolTip1;

	private: System::ComponentModel::IContainer^  components;


#pragma region Windows Form Designer generated code

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
			this->button1->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button1.Image")));
			this->button1->Location = System::Drawing::Point(56, 12);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(38, 25);
			this->button1->TabIndex = 0;
			this->button1->UseVisualStyleBackColor = false;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			this->button1->MouseLeave += gcnew System::EventHandler(this, &Form1::button1_MouseLeave);
			this->button1->MouseHover += gcnew System::EventHandler(this, &Form1::button1_MouseHover);
			// 
			// pictureBox1
			// 
			this->pictureBox1->BackColor = System::Drawing::SystemColors::Window;
			this->pictureBox1->Location = System::Drawing::Point(345, 193);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(416, 157);
			this->pictureBox1->TabIndex = 1;
			this->pictureBox1->TabStop = false;
			this->pictureBox1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseDown);
			this->pictureBox1->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseMove);
			this->pictureBox1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox1_MouseUp);
			// 
			// button2
			// 
			this->button2->BackColor = System::Drawing::Color::White;
			this->button2->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button2.Image")));
			this->button2->Location = System::Drawing::Point(56, 43);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(38, 25);
			this->button2->TabIndex = 2;
			this->button2->UseVisualStyleBackColor = false;
			this->button2->MouseClick += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::button2_MouseClick);
			this->button2->MouseLeave += gcnew System::EventHandler(this, &Form1::button2_MouseLeave);
			this->button2->MouseHover += gcnew System::EventHandler(this, &Form1::button2_MouseHover);
			// 
			// trackBar1
			// 
			this->trackBar1->BackColor = System::Drawing::SystemColors::Control;
			this->trackBar1->LargeChange = 1;
			this->trackBar1->Location = System::Drawing::Point(12, 104);
			this->trackBar1->Maximum = 12;
			this->trackBar1->Minimum = 2;
			this->trackBar1->Name = L"trackBar1";
			this->trackBar1->Size = System::Drawing::Size(170, 45);
			this->trackBar1->TabIndex = 3;
			this->trackBar1->Value = 2;
			this->trackBar1->MouseLeave += gcnew System::EventHandler(this, &Form1::trackBar1_MouseLeave);
			this->trackBar1->MouseHover += gcnew System::EventHandler(this, &Form1::trackBar1_MouseHover);
			// 
			// button3
			// 
			this->button3->BackColor = System::Drawing::Color::White;
			this->button3->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button3.Image")));
			this->button3->Location = System::Drawing::Point(100, 12);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(38, 25);
			this->button3->TabIndex = 4;
			this->button3->UseVisualStyleBackColor = false;
			this->button3->Click += gcnew System::EventHandler(this, &Form1::button3_Click);
			this->button3->MouseLeave += gcnew System::EventHandler(this, &Form1::button3_MouseLeave);
			this->button3->MouseHover += gcnew System::EventHandler(this, &Form1::button3_MouseHover);
			// 
			// button4
			// 
			this->button4->BackColor = System::Drawing::Color::White;
			this->button4->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button4.Image")));
			this->button4->Location = System::Drawing::Point(144, 12);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(38, 25);
			this->button4->TabIndex = 5;
			this->button4->UseVisualStyleBackColor = false;
			this->button4->Click += gcnew System::EventHandler(this, &Form1::button4_Click);
			this->button4->MouseLeave += gcnew System::EventHandler(this, &Form1::button4_MouseLeave);
			this->button4->MouseHover += gcnew System::EventHandler(this, &Form1::button4_MouseHover);
			// 
			// button5
			// 
			this->button5->BackColor = System::Drawing::Color::White;
			this->button5->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button5.Image")));
			this->button5->Location = System::Drawing::Point(100, 43);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(38, 25);
			this->button5->TabIndex = 6;
			this->button5->UseVisualStyleBackColor = false;
			this->button5->Click += gcnew System::EventHandler(this, &Form1::button5_Click);
			this->button5->MouseLeave += gcnew System::EventHandler(this, &Form1::button5_MouseLeave);
			this->button5->MouseHover += gcnew System::EventHandler(this, &Form1::button5_MouseHover);
			// 
			// button6
			// 
			this->button6->BackColor = System::Drawing::Color::White;
			this->button6->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button6.Image")));
			this->button6->Location = System::Drawing::Point(144, 43);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(38, 25);
			this->button6->TabIndex = 7;
			this->button6->UseVisualStyleBackColor = false;
			this->button6->Click += gcnew System::EventHandler(this, &Form1::button6_Click);
			this->button6->MouseLeave += gcnew System::EventHandler(this, &Form1::button6_MouseLeave);
			this->button6->MouseHover += gcnew System::EventHandler(this, &Form1::button6_MouseHover);
			// 
			// button7
			// 
			this->button7->BackColor = System::Drawing::Color::Black;
			this->button7->Location = System::Drawing::Point(83, 235);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(23, 20);
			this->button7->TabIndex = 8;
			this->button7->UseVisualStyleBackColor = false;
			this->button7->Click += gcnew System::EventHandler(this, &Form1::button7_Click);
			// 
			// button8
			// 
			this->button8->BackColor = System::Drawing::Color::Orange;
			this->button8->Location = System::Drawing::Point(54, 209);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(23, 20);
			this->button8->TabIndex = 8;
			this->button8->UseVisualStyleBackColor = false;
			this->button8->Click += gcnew System::EventHandler(this, &Form1::button8_Click);
			// 
			// button9
			// 
			this->button9->BackColor = System::Drawing::Color::Yellow;
			this->button9->Location = System::Drawing::Point(83, 209);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(23, 20);
			this->button9->TabIndex = 8;
			this->button9->UseVisualStyleBackColor = false;
			this->button9->Click += gcnew System::EventHandler(this, &Form1::button9_Click);
			// 
			// button10
			// 
			this->button10->BackColor = System::Drawing::Color::Green;
			this->button10->Location = System::Drawing::Point(112, 209);
			this->button10->Name = L"button10";
			this->button10->Size = System::Drawing::Size(23, 20);
			this->button10->TabIndex = 8;
			this->button10->UseVisualStyleBackColor = false;
			this->button10->Click += gcnew System::EventHandler(this, &Form1::button10_Click);
			// 
			// button11
			// 
			this->button11->BackColor = System::Drawing::Color::Red;
			this->button11->Location = System::Drawing::Point(25, 209);
			this->button11->Name = L"button11";
			this->button11->Size = System::Drawing::Size(23, 20);
			this->button11->TabIndex = 8;
			this->button11->UseVisualStyleBackColor = false;
			this->button11->Click += gcnew System::EventHandler(this, &Form1::button11_Click);
			// 
			// button12
			// 
			this->button12->BackColor = System::Drawing::Color::White;
			this->button12->Location = System::Drawing::Point(25, 235);
			this->button12->Name = L"button12";
			this->button12->Size = System::Drawing::Size(23, 20);
			this->button12->TabIndex = 8;
			this->button12->UseVisualStyleBackColor = false;
			this->button12->Click += gcnew System::EventHandler(this, &Form1::button12_Click);
			// 
			// button13
			// 
			this->button13->BackColor = System::Drawing::Color::Blue;
			this->button13->Location = System::Drawing::Point(54, 235);
			this->button13->Name = L"button13";
			this->button13->Size = System::Drawing::Size(23, 20);
			this->button13->TabIndex = 8;
			this->button13->UseVisualStyleBackColor = false;
			this->button13->Click += gcnew System::EventHandler(this, &Form1::button13_Click);
			// 
			// button14
			// 
			this->button14->BackColor = System::Drawing::Color::Purple;
			this->button14->Location = System::Drawing::Point(112, 235);
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
			this->textBox1->Location = System::Drawing::Point(22, 183);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(42, 13);
			this->textBox1->TabIndex = 9;
			this->textBox1->Text = L"Цвет: ";
			// 
			// button15
			// 
			this->button15->BackColor = System::Drawing::Color::Black;
			this->button15->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->button15->Location = System::Drawing::Point(83, 183);
			this->button15->Name = L"button15";
			this->button15->Size = System::Drawing::Size(23, 20);
			this->button15->TabIndex = 8;
			this->button15->UseVisualStyleBackColor = false;
			// 
			// button16
			// 
			this->button16->BackColor = System::Drawing::Color::White;
			this->button16->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"button16.Image")));
			this->button16->Location = System::Drawing::Point(12, 43);
			this->button16->Name = L"button16";
			this->button16->Size = System::Drawing::Size(38, 25);
			this->button16->TabIndex = 7;
			this->button16->UseVisualStyleBackColor = false;
			this->button16->Click += gcnew System::EventHandler(this, &Form1::button16_Click);
			this->button16->MouseLeave += gcnew System::EventHandler(this, &Form1::button16_MouseLeave);
			this->button16->MouseHover += gcnew System::EventHandler(this, &Form1::button16_MouseHover);
			// 
			// button17
			// 
			this->button17->BackColor = System::Drawing::Color::White;
			this->button17->Location = System::Drawing::Point(12, 12);
			this->button17->Name = L"button17";
			this->button17->Size = System::Drawing::Size(38, 25);
			this->button17->TabIndex = 7;
			this->button17->Text = L"New";
			this->button17->UseVisualStyleBackColor = false;
			this->button17->Click += gcnew System::EventHandler(this, &Form1::button17_Click);
			this->button17->MouseLeave += gcnew System::EventHandler(this, &Form1::button17_MouseLeave);
			this->button17->MouseHover += gcnew System::EventHandler(this, &Form1::button17_MouseHover);
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
			this->Text = L"Рисовалка";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->trackBar1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
// Флаги для переключения фигур
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
				// this->kist->x0 = e->X;
				// this->kist->y0 = e->Y;
				 this->rect->x0 = e->X; // Присваиваем фигуре координаты указателя мыши
				 this->rect->y0 = e->Y;
				 this->frect->x0 = e->X;
				 this->frect->y0 = e->Y;
				 this->ell->x0 = e->X;
				 this->ell->y0 = e->Y;
				 this->fell->x0 = e->X;
				 this->fell->y0 = e->Y;
				 this->line->x0 = e->X;
				 this->line->y0 = e->Y;
			 }
	private: System::Void pictureBox1_MouseUp(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
				 logKist = false;
				 if(logLine == true) {
				 this->line->x = e->X;
				 this->line->y = e->Y;
				 this->line->width = this->trackBar1->Value; // Ширине фигуры присаиваем значение 
				 this->line->color = this->button15->BackColor; // Присваиваем выбранный цвет
				 this->line->Draw(bitmap, pictureBox1); // Рисовать фигуру
				 }
				 if(logFillEllips) {
				 this->fell->x = e->X;
				 this->fell->y = e->Y;
				 this->fell->width = this->trackBar1->Value;
				 this->fell->color = this->button15->BackColor;
				 this->fell->Draw(bitmap, pictureBox1);
				 }
				 if(logEllips == true) {
				 this->ell->x = e->X;
				 this->ell->y = e->Y;
				 this->ell->width = this->trackBar1->Value;
				 this->ell->color = this->button15->BackColor;
				 this->ell->Draw(bitmap, pictureBox1);
				 }
				 if(logRectangle == true) {
				 this->rect->x = e->X;
				 this->rect->y = e->Y;
				 this->rect->width = this->trackBar1->Value;
				 this->rect->color = this->button15->BackColor;
				 this->rect->Draw(bitmap, pictureBox1);
				 }
				 if(logFillRectangle == true) {
				this->frect->x = e->X;
				 this->frect->y = e->Y;
				  this->frect->width = this->trackBar1->Value;
				 this->frect->color = this->button15->BackColor;
				 this->frect->Draw(bitmap, pictureBox1);
				 }
			 }
	private: System::Void pictureBox1_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
				// При движении мыши, если включен флаг кисти, будет 
				if(logLastik == false && controlKist == true) // Проверка переключение между ластиком и карандашом
				 if(logKist == true) { // Флаг кисти
				 this->kist->x0 = e->X;
				 this->kist->y0 = e->Y;
				 this->kist->width = this->trackBar1->Value;
				 this->kist->color = this->button15->BackColor;
				 this->kist->Draw(bitmap, pictureBox1);
				 }
				 if(logLastik == true && controlKist == true)
				 if(logKist == true) {
				 this->kist->x0 = e->X;
				 this->kist->y0 = e->Y;
				 this->kist->width = this->trackBar1->Value;
				 this->kist->color = Color::White;
				 this->kist->Draw(bitmap, pictureBox1);
				 }
				 
			 }
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) { // Выбрать ластик
				 controlKist = true;
				 logLastik = true;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
			 }
	private: System::Void button2_MouseClick(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) { // Выбрать карандаш
				 controlKist = true;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
			 }
			 private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) { // Выбрать эллипс
				 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = true;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
			 }
	private: System::Void button4_Click(System::Object^  sender, System::EventArgs^  e) { // Выбрать прямоуголник
				 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = true;
				 logFillEllips = false;
				 logFillRectangle = false;
			 }
	private: System::Void button6_Click(System::Object^  sender, System::EventArgs^  e) {// Закрашенный прямоуголник
				 controlKist = false;
				 logLastik = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = true;
			 }
	private: System::Void button16_Click(System::Object^  sender, System::EventArgs^  e) {// Выбрать линию
				 controlKist = false;
				 logLine = true;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = false;
				 logFillRectangle = false;
			 }

	private: System::Void button5_Click(System::Object^  sender, System::EventArgs^  e) {// Выбрать закрашенный эллипс
				 controlKist = false;
				 logLine = false;
				 logEllips = false;
				 logRectangle = false;
				 logFillEllips = true;
				 logFillRectangle = false;
			 }
	private: System::Void button17_Click(System::Object^  sender, System::EventArgs^  e) {// Очистить поле
				 Graphics^ gr = Graphics::FromImage(bitmap);
				 gr->Clear(SystemColors::Window);
				 pictureBox1->Image = bitmap;
			 }
				// Выбор цвета
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
			// Отображать название объекта
private: System::Void button17_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button17, "Очистить");
		 }
private: System::Void button17_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button1_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button1, "Ластик");
		 }
private: System::Void button1_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button3_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button3, "Эллипс");
		 }
private: System::Void button3_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button4_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button4, "Прямоугольник");
		 }
private: System::Void button4_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button16_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button16, "Отрезок");
		 }
private: System::Void button16_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button2_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button2, "Карандаш");
		 }
private: System::Void button2_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button5_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button5, "Закр. эллипс");
		 }
private: System::Void button5_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void button6_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->button6, "Закр. прямоугольник");
		 }
private: System::Void button6_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
private: System::Void trackBar1_MouseHover(System::Object^  sender, System::EventArgs^  e) {
			 this->toolTip1 = gcnew ToolTip();
			 this->toolTip1->SetToolTip(this->trackBar1, "Толщина кисти");
		 }
private: System::Void trackBar1_MouseLeave(System::Object^  sender, System::EventArgs^  e) {
			 delete(this->toolTip1);
		 }
};

	public ref class Shape {				// Класс Фигура
	public: Shape() {
			}
	protected: ~Shape() {
			}
	public: Int32 x0;					// Координаты
	public: Int32 y0;
	public: Int32 width;					// Толщина
	public: System::Drawing::Color color;			// Цвет
	};

	public ref class Kist : Shape {				// Карандаш
	public: Kist() {
			}
	protected: ~Kist() {
			   }
	public: void Draw(Bitmap^ bitmap, PictureBox^ MyPictureBox) { // Рисовать
			Graphics^ gr1 = Graphics::FromImage(bitmap);
			Pen^ pen = gcnew Pen(Kist::color, Kist::width); // Кисть(цвет, толщина)
			gr1->DrawEllipse(pen, Kist::x0, Kist::y0, Kist::width, Kist::width); // Рисовать эллипс: центр радиус по х и у
			MyPictureBox->Image = bitmap;
			}
	};

	public ref class Rectangle : public Shape{ // Класс прямоугольник, насследованный от класса "Фигура"
	public: Rectangle() {
			}
	protected: ~Rectangle() {
			}
	public: Int32 x; // Координаты
	public: Int32 y;
	public: void Draw(Bitmap^ bitmap, PictureBox^ MyPictureBox) { // Метод отрисовки прямоуголника
			Graphics^ gr1 = Graphics::FromImage(bitmap);
			Pen^ pen = gcnew Pen(Rectangle::color, Rectangle::width); // В зависимости от того как рисовать(сверху вниз или снизу вверх и т.п.)
			if(Rectangle::x>=Rectangle::x0 && Rectangle::y>=Rectangle::y0)
			gr1->DrawRectangle(pen, Rectangle::x0, Rectangle::y0, Rectangle::x-Rectangle::x0, Rectangle::y-Rectangle::y0);
			if(Rectangle::x>=Rectangle::x0 && Rectangle::y<Rectangle::y0)
			gr1->DrawRectangle(pen, Rectangle::x0, Rectangle::y, Rectangle::x-Rectangle::x0, Rectangle::y0-Rectangle::y);
			if(Rectangle::x<Rectangle::x0 && Rectangle::y<Rectangle::y0)
			gr1->DrawRectangle(pen, Rectangle::x, Rectangle::y, Rectangle::x0-Rectangle::x, Rectangle::y0-Rectangle::y);
			if(Rectangle::x<Rectangle::x0 && Rectangle::y>=Rectangle::y0)
			// Рисовать прямоугольник из т. (х, у0) длинной х0-х и шириной у-у0
			gr1->DrawRectangle(pen, Rectangle::x, Rectangle::y0, Rectangle::x0-Rectangle::x, Rectangle::y-Rectangle::y0);
			MyPictureBox->Image = bitmap;
			}
	};
	
	public ref class FillRectangle : public Shape { // Закрашенный прямоуголник
	public: FillRectangle() {
			}
	protected: ~FillRectangle() {
			}
	public: Int32 x;
	public: Int32 y;
	void Draw(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
		Graphics^ gr1 = Graphics::FromImage(bitmap);
			Brush^ brush = gcnew SolidBrush(FillRectangle::color); // Для заливки
			if(FillRectangle::x>=FillRectangle::x0 && FillRectangle::y>=FillRectangle::y0)
			gr1->FillRectangle(brush, FillRectangle::x0, FillRectangle::y0, FillRectangle::x-FillRectangle::x0, FillRectangle::y-FillRectangle::y0);
			if(FillRectangle::x>=FillRectangle::x0 && FillRectangle::y<FillRectangle::y0)
			gr1->FillRectangle(brush, FillRectangle::x0, FillRectangle::y, FillRectangle::x-FillRectangle::x0, FillRectangle::y0-FillRectangle::y);
			if(FillRectangle::x<FillRectangle::x0 && FillRectangle::y<FillRectangle::y0)
			gr1->FillRectangle(brush, FillRectangle::x, FillRectangle::y, FillRectangle::x0-FillRectangle::x, FillRectangle::y0-FillRectangle::y);
			if(FillRectangle::x<FillRectangle::x0 && FillRectangle::y>=FillRectangle::y0)
			gr1->FillRectangle(brush, FillRectangle::x, FillRectangle::y0, FillRectangle::x0-FillRectangle::x, FillRectangle::y-FillRectangle::y0);
			MyPictureBox->Image = bitmap;
		}
	};

	public ref class Ellipse : public Shape{ // Эллипсе
	public: Ellipse() {
			}
	protected: ~Ellipse() {
			}
	public: Int32 x;
	public: Int32 y;
	public: void Draw(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
			Graphics^ gr1 = Graphics::FromImage(bitmap);
			Pen^ pen = gcnew Pen(Ellipse::color, Ellipse::width);
			if(Ellipse::x>=Ellipse::x0 && Ellipse::y>=Ellipse::y0)
			gr1->DrawEllipse(pen, Ellipse::x0, Ellipse::y0, Ellipse::x-Ellipse::x0, Ellipse::y-Ellipse::y0);
			if(Ellipse::x>=Ellipse::x0 && Ellipse::y<Ellipse::y0)
			gr1->DrawEllipse(pen, Ellipse::x0, Ellipse::y, Ellipse::x-Ellipse::x0, Ellipse::y0-Ellipse::y);
			if(Ellipse::x<Ellipse::x0 && Ellipse::y<Ellipse::y0)
			gr1->DrawEllipse(pen, Ellipse::x, Ellipse::y, Ellipse::x0-Ellipse::x, Ellipse::y0-Ellipse::y);
			if(Ellipse::x<Ellipse::x0 && Ellipse::y>=Ellipse::y0)
			gr1->DrawEllipse(pen, Ellipse::x, Ellipse::y0, Ellipse::x0-Ellipse::x, Ellipse::y-Ellipse::y0);
			MyPictureBox->Image = bitmap;
			}
	};

	public ref class FillEllipse : public Shape { // Закрашенный эллипс
	public: FillEllipse() {
			}
	protected: ~FillEllipse() {
			}
	public: Int32 x;
	public: Int32 y;
	public: void Draw(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
			Graphics^ gr1 = Graphics::FromImage(bitmap);
			Brush^ brush = gcnew SolidBrush(FillEllipse::color);
			if(FillEllipse::x>=FillEllipse::x0 && FillEllipse::y>=FillEllipse::y0)
			gr1->FillEllipse(brush, FillEllipse::x0, FillEllipse::y0, FillEllipse::x-FillEllipse::x0, FillEllipse::y-FillEllipse::y0);
			if(FillEllipse::x>=FillEllipse::x0 && FillEllipse::y<FillEllipse::y0)
			gr1->FillEllipse(brush, FillEllipse::x0, FillEllipse::y, FillEllipse::x-FillEllipse::x0, FillEllipse::y0-FillEllipse::y);
			if(FillEllipse::x<FillEllipse::x0 && FillEllipse::y<FillEllipse::y0)
			gr1->FillEllipse(brush, FillEllipse::x, FillEllipse::y, FillEllipse::x0-FillEllipse::x, FillEllipse::y0-FillEllipse::y);
			if(FillEllipse::x<FillEllipse::x0 && FillEllipse::y>=FillEllipse::y0)
			gr1->FillEllipse(brush, FillEllipse::x, FillEllipse::y0, FillEllipse::x0-FillEllipse::x, FillEllipse::y-FillEllipse::y0);
			MyPictureBox->Image = bitmap;
			}
	};
	
	public ref class Line : public Shape{ // Линия
	public: Line() {
			}
	protected: ~Line() {
			}
	public: Int32 x;
	public: Int32 y;
	public: void Draw(Bitmap^ bitmap, PictureBox^ MyPictureBox) {
			Graphics^ gr1 = Graphics::FromImage(bitmap);
			Pen^ pen = gcnew Pen(Line::color, Line::width);
			gr1->DrawLine(pen, Line::x0, Line::y0, Line::x, Line::y);
			MyPictureBox->Image = bitmap;
			}
	};/**/

}

