#pragma once
#include <conio.h>
#include <stdio.h>
#include <math.h>



namespace ммкурсовая {

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
		Form1(void)
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
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::DataVisualization::Charting::Chart^  chart1;
	protected: 
	private: System::Windows::Forms::DataVisualization::Charting::Chart^  chart2;

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
			System::Windows::Forms::DataVisualization::Charting::ChartArea^  chartArea2 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^  legend2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^  series2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			this->chart1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->chart2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->chart1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->chart2))->BeginInit();
			this->SuspendLayout();
			// 
			// chart1
			// 
			chartArea1->Name = L"ChartArea1";
			this->chart1->ChartAreas->Add(chartArea1);
			legend1->Name = L"Legend1";
			this->chart1->Legends->Add(legend1);
			this->chart1->Location = System::Drawing::Point(207, 12);
			this->chart1->Name = L"chart1";
			series1->ChartArea = L"ChartArea1";
			series1->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series1->Legend = L"Legend1";
			series1->Name = L"Z";
			this->chart1->Series->Add(series1);
			this->chart1->Size = System::Drawing::Size(995, 300);
			this->chart1->TabIndex = 0;
			this->chart1->Text = L"chart1";
			// 
			// chart2
			// 
			chartArea2->Name = L"ChartArea1";
			this->chart2->ChartAreas->Add(chartArea2);
			legend2->Name = L"Legend1";
			this->chart2->Legends->Add(legend2);
			this->chart2->Location = System::Drawing::Point(207, 339);
			this->chart2->Name = L"chart2";
			series2->ChartArea = L"ChartArea1";
			series2->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series2->Legend = L"Legend1";
			series2->Name = L"C3_ang";
			this->chart2->Series->Add(series2);
			this->chart2->Size = System::Drawing::Size(1029, 300);
			this->chart2->TabIndex = 1;
			this->chart2->Text = L"chart2";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1315, 651);
			this->Controls->Add(this->chart2);
			this->Controls->Add(this->chart1);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->chart1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->chart2))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion

		
double generator(int &x)
{
    const int m=1000000,a=8,inc=65;
    x=((a*x)+inc)%m;
    return(x/double(m));
}
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {


				// #include <iostream>

//using namespace std;



    double x[500];
    int x0=500;
    for(int i=0; i<500;i++)
    {
        x[i]=generator(x0)-0.5;
        //printf("%f \n",x[i]);
    }

double M, sum = 0;
		for (int i = 0; i<500; i++)
		{
			sum += x[i];
			//printf("%f", sum);
		}

		M = 1 / 500 * sum;
		//printf("!!!\n");
		//printf("M=%f, \n", M);
		double gam, w;
		double sun = 0;
		//int sun;
		for (int i = 0; i<500; i++)
		{
			w = pow((x[i] - M), 2);
			// printf("%f\n", w);

		}
		sun += w;
		//printf("%f\n", sun);
		gam = 1 / 500 * sun;
	//	printf("gam=%f \n", gam);


		double z[490];
		double k = 1, v, j;
		double constanta;
		double gam0 = 100, gamx = 1.36, alf0 = 0.071, M0 = 1, A1 = 1, A2 = 1, e = 2.71828, N = 10;
		constanta = 0.4;//pow((gam0 / gamx / alf0), (double)1 / (double)2);

		for (int i = 0; i<490; i++)
		{
			for (int j = i; j<i + 10; j++)
			{
				v += x[j] * constanta*exp(-alf0*(j - i));
			}
			z[i] = (1 / N*v + M0);
			v = 0;
		}
		//printf("!!!!!!");
		for (int i = 0; i<490; i++){
			//printf("%f \n", z[i]);
			chart1->Series["Z"]->Points->AddXY(i, z[i]);

		}

		///
		  double  E1=72600,E3=87000,a1=200, a2=4000,a3=300000, E2=77000,  T=650;
    double u=0.1, ro=1.4,dt=0.5;
    double R=8.31;



    double C1;
    double C2;
    double C3;
    C2=8.75, C3=0;


    double l=2.8;


		double zz[1000];
       double tay[1000];
       int count=0;
       double tav=l/u;
       double tMax=40;
       double ab=0.01;
       //printf("tav=%f",tav);
      double k1=a1*exp(-E1/(R*T));
      double k2=a2*exp(-E2/(R*T));
	  double k3 = a3*exp(-E3 / (R*T));
      double da=0.001;
      double C3_ans[1000]={0};


       for(double B=0;B<(tMax-tav)/2;B+=ab){
       C1=z[count];
       C2=8.75;
       C3=0;

       for(double A=B;A<tav+B;A+=da)
       {
           C1=C1+((-2*k1*C1*C2)-(k2*C1*C2))*da;
           C2=C2+(-9.0*k1*C1*C2-12.0*k2*C1*C2-9.0*k3*C3*C2)*da;
           C3=C3+(-k3*C3*C2+k1*C1*C2)*da;
            tay[count]=A+B;
            zz[count]=u*(A-B);
			
       }

	   C3_ans[count] = C3;
       
      // printf("%f ",C3_ans[count]);
      count++;


       }
      //
       for(double B=(tMax-tav)/2;B<tMax/2;B+=ab){
       C1=z[count];
       C2=8.75;
       C3=0;


       for(double A=B;A<tMax-B;A+=da)
       {
		   C1 = C1 + ((-2 * k1*C1*C2) - (k2*C1*C2))*da;
		   C2 = C2 + (-9.0*k1*C1*C2 - 12.0*k2*C1*C2 - 9.0*k3*C3*C2)*da;
		   C3 = C3 + (-k3*C3*C2 + k1*C1*C2)*da;
            tay[count]=A+B;
            zz[count]=u*(A-B);
        //    printf("%f ",C3);
       }

	  

}

	    int kk=0;
       for(int i=0;i<490;i++)
       {
           if(2.40<zz[i]&&zz[i]<3.95)
           {
              // printf("%i",i);
              // printf("C3=%f \n",C3_ans[i]);
			   	chart2->Series["C3_ang"]->Points->AddXY(i, C3_ans[i]);

           }
       }

	   }
	};
}

