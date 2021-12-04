#pragma once

#include <cmath>

namespace Мо3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::DataVisualization::Charting::Chart^  chart1;
	protected:
	private: System::Windows::Forms::DataVisualization::Charting::Chart^  chart2;
	private: System::Windows::Forms::Button^  button1;

	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			System::Windows::Forms::DataVisualization::Charting::ChartArea^  chartArea1 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^  legend1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^  series1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^  series2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^  series3 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::ChartArea^  chartArea2 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^  legend2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^  series4 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^  series5 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::Series^  series6 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			this->chart1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->chart2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->button1 = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart2))->BeginInit();
			this->SuspendLayout();
			// 
			// chart1
			// 
			chartArea1->Name = L"ChartArea1";
			this->chart1->ChartAreas->Add(chartArea1);
			legend1->Name = L"Legend1";
			this->chart1->Legends->Add(legend1);
			this->chart1->Location = System::Drawing::Point(23, 12);
			this->chart1->Name = L"chart1";
			series1->ChartArea = L"ChartArea1";
			series1->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series1->Legend = L"Legend1";
			series1->Name = L"С1";
			series2->ChartArea = L"ChartArea1";
			series2->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series2->Legend = L"Legend1";
			series2->Name = L"С2";
			series3->ChartArea = L"ChartArea1";
			series3->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series3->Legend = L"Legend1";
			series3->Name = L"С3";
			this->chart1->Series->Add(series1);
			this->chart1->Series->Add(series2);
			this->chart1->Series->Add(series3);
			this->chart1->Size = System::Drawing::Size(300, 300);
			this->chart1->TabIndex = 0;
			this->chart1->Text = L"chart1";
			// 
			// chart2
			// 
			chartArea2->Name = L"ChartArea1";
			this->chart2->ChartAreas->Add(chartArea2);
			legend2->Name = L"Legend1";
			this->chart2->Legends->Add(legend2);
			this->chart2->Location = System::Drawing::Point(367, 12);
			this->chart2->Name = L"chart2";
			series4->ChartArea = L"ChartArea1";
			series4->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series4->Legend = L"Legend1";
			series4->Name = L"С1";
			series5->ChartArea = L"ChartArea1";
			series5->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series5->Legend = L"Legend1";
			series5->Name = L"С2";
			series6->ChartArea = L"ChartArea1";
			series6->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series6->Legend = L"Legend1";
			series6->Name = L"С3";
			this->chart2->Series->Add(series4);
			this->chart2->Series->Add(series5);
			this->chart2->Series->Add(series6);
			this->chart2->Size = System::Drawing::Size(300, 300);
			this->chart2->TabIndex = 1;
			this->chart2->Text = L"chart2";
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(728, 37);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 2;
			this->button1->Text = L"button1";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(848, 343);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->chart2);
			this->Controls->Add(this->chart1);
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart2))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
		
		double h = 0.5, x, y, z, y_prev, z_prev, x_begin = 0, x_end = 80,
			koef1, koef2, koef3, C_in_proc = 20, C_in;
		//общее:
		double  R = 8.31, E1 = 251000, E2 = 297000, PI = 3.14159265,
			A1 = 2E11,/*надеюсь, он поймет такие числа*/ A2 = 8E12, ro = 1.4, D = 0.1;
		//5 вариант:
		double m = 1, T = 1360;

		//C_in - изменяется от 3-% до 4-% в 5 варианте
		C_in = C_in_proc*ro / (28.05 * 100) * 1000;

		koef1 = -A1*pow(2.71828, -E1 / (R*T))*PI*D*D*ro / (4 * m);
		koef2 = -koef1;
		koef3 = -A2*pow(2.71828, -E2 / (R*T))*PI*D*D*ro / (4 * m);

		

		x = x_begin;
		y_prev = C_in;
		z_prev = 0;


		/*
		//Эйлер
		for (int i = 0; i <=(x_end - x_begin)/h + h/2; i++)
		//for (int i = 0; i <=50 ; i++)
		{
		y = y_prev + h*koef1*y_prev;
		z = z_prev + h*(koef2*y_prev + koef3*z_prev);
		x = x_begin + i*h;
		y_prev = y;
		z_prev = z;
		printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
		//printf("x = %lf, y = %lf\n", x, y);
		}

		*/

		//рунге-кутта
		double k1y, k2y, k3y, k4y, k1z, k2z, k3z, k4z;
		// for (int i = 0; i <=(x_end - x_begin)/h + h/2; i++)
		//for (int i = 0; i <=50 ; i++)
		for (int i = 0; i <(x_end - x_begin); i++)

		{
			//        y = y_prev + h*koef1*y_prev;
			k1y = koef1*y_prev;
			k2y = koef1*(y_prev + h*k1y / 2);
			k3y = koef1*(y_prev + h*k2y / 2);
			k4y = koef1*(y_prev + h*k3y);
			y = y_prev + h*(k1y + 2 * k2y + 2 * k3y + k4y) / 6;

			//        z = z_prev + h*(koef2*y_prev + koef3*z_prev);
			k1z = koef2*y_prev + koef3*z_prev;
			k2z = koef2*y_prev + koef3*(z_prev + h*k1z / 2);
			k3z = koef2*y_prev + koef3*(z_prev + h*k2z / 2);
			k4z = koef2*y_prev + koef3*(z_prev + h*k3z);
			z = z_prev + h*(k1z + 2 * k2z + 2 * k3z + k4z) / 6;

			x = x++;
			y_prev = y;
			z_prev = z;
			this->chart1->Series["С1"]->Points->AddXY(x, y);
			this->chart2->Series["С1"]->Points->AddXY(x, z);
			//printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
			//printf("x = %lf, y = %lf\n", x, y);
		}

		C_in_proc = 25;
		C_in = C_in_proc*ro / (28.05 * 100) * 1000;
		x = x_begin;
		y_prev = C_in;
		z_prev = 0;
		for (int i = 0; i <(x_end - x_begin); i++)

		{
			//        y = y_prev + h*koef1*y_prev;
			k1y = koef1*y_prev;
			k2y = koef1*(y_prev + h*k1y / 2);
			k3y = koef1*(y_prev + h*k2y / 2);
			k4y = koef1*(y_prev + h*k3y);
			y = y_prev + h*(k1y + 2 * k2y + 2 * k3y + k4y) / 6;

			//        z = z_prev + h*(koef2*y_prev + koef3*z_prev);
			k1z = koef2*y_prev + koef3*z_prev;
			k2z = koef2*y_prev + koef3*(z_prev + h*k1z / 2);
			k3z = koef2*y_prev + koef3*(z_prev + h*k2z / 2);
			k4z = koef2*y_prev + koef3*(z_prev + h*k3z);
			z = z_prev + h*(k1z + 2 * k2z + 2 * k3z + k4z) / 6;

			x = x++;
			y_prev = y;
			z_prev = z;
			this->chart1->Series["С2"]->Points->AddXY(x, y);
			this->chart2->Series["С2"]->Points->AddXY(x, z);
			//printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
			//printf("x = %lf, y = %lf\n", x, y);
		}
		C_in_proc = 30;
		C_in = C_in_proc*ro / (28.05 * 100) * 1000;
		x = x_begin;
		y_prev = C_in;
		z_prev = 0;
		for (int i = 0; i <(x_end - x_begin); i++)

		{
			//        y = y_prev + h*koef1*y_prev;
			k1y = koef1*y_prev;
			k2y = koef1*(y_prev + h*k1y / 2);
			k3y = koef1*(y_prev + h*k2y / 2);
			k4y = koef1*(y_prev + h*k3y);
			y = y_prev + h*(k1y + 2 * k2y + 2 * k3y + k4y) / 6;

			//        z = z_prev + h*(koef2*y_prev + koef3*z_prev);
			k1z = koef2*y_prev + koef3*z_prev;
			k2z = koef2*y_prev + koef3*(z_prev + h*k1z / 2);
			k3z = koef2*y_prev + koef3*(z_prev + h*k2z / 2);
			k4z = koef2*y_prev + koef3*(z_prev + h*k3z);
			z = z_prev + h*(k1z + 2 * k2z + 2 * k3z + k4z) / 6;

			x = x++;
			y_prev = y;
			z_prev = z;
			this->chart1->Series["С3"]->Points->AddXY(x, y);
			this->chart2->Series["С3"]->Points->AddXY(x, z);
			//printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
			//printf("x = %lf, y = %lf\n", x, y);
		}


	}
};
}
