#pragma once

#include<stdio.h>
#include"action.h"

namespace MM6 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// —водка дл€ Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// ќсвободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button^  button1;
	protected: 

	private:
		/// <summary>
		/// “ребуетс€ переменна€ конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// ќб€зательный метод дл€ поддержки конструктора - не измен€йте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(12, 24);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 0;
			this->button1->Text = L"button1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(292, 267);
			this->Controls->Add(this->button1);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				//double T[36][36];
				double b0 = -2.5;
				double b1 = 5;
				double a0 = 0;
				double a1 = 7.5;

			
				double T1;
				double T;
				FILE *f = fopen("log.txt", "w");
				T = T0(-2*u*(-tav/2));

				for(double B=-tav/2; B<0; B += db)
					for(double A=-B; A<tav+B; A +=da) {
						T = T +4*kt/(ct*p*D)*(TT-T)*da;
						fprintf(f, "%lf,%lf,%lf\n", A, B, T);
					}
				for(double B=0; B<(tMax-tav)/2; B += db)
					for(double A=B; A<tav+B; A +=da) {
						T = T +4*kt/(ct*p*D)*(TT-T)*da;
						fprintf(f, "%lf,%lf,%lf\n", A, B, T);
					}
				for(double B=(tMax-tav)/2; B<=tMax/2; B += db)
					for(double A=B; A<tMax-B; A +=da) {
						T = T +4*kt/(ct*p*D)*(TT-T)*da;
						fprintf(f, "%lf,%lf,%lf\n", A, B, T);
					}
				fclose(f);
			 }
	};
}

