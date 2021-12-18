#pragma once
#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <math.h>


namespace bz3 {

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
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::TextBox^  textBox2;
	private: System::Windows::Forms::TextBox^  textBox3;
	private: System::Windows::Forms::TextBox^  textBox4;
	private: System::Windows::Forms::TextBox^  textBox5;
	private: System::Windows::Forms::TextBox^  textBox6;
	private: System::Windows::Forms::TextBox^  textBox7;
	private: System::Windows::Forms::TextBox^  textBox8;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  label5;
	private: System::Windows::Forms::Label^  label6;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::Label^  label9;
	private: System::Windows::Forms::Label^  label10;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Splitter^  splitter1;
	private: System::Windows::Forms::Label^  label11;
	private: System::Windows::Forms::GroupBox^  groupBox1;

















	protected:

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
			this->chart1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->textBox3 = (gcnew System::Windows::Forms::TextBox());
			this->textBox4 = (gcnew System::Windows::Forms::TextBox());
			this->textBox5 = (gcnew System::Windows::Forms::TextBox());
			this->textBox6 = (gcnew System::Windows::Forms::TextBox());
			this->textBox7 = (gcnew System::Windows::Forms::TextBox());
			this->textBox8 = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->label7 = (gcnew System::Windows::Forms::Label());
			this->label8 = (gcnew System::Windows::Forms::Label());
			this->label9 = (gcnew System::Windows::Forms::Label());
			this->label10 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->splitter1 = (gcnew System::Windows::Forms::Splitter());
			this->label11 = (gcnew System::Windows::Forms::Label());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->BeginInit();
			this->groupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// chart1
			// 
			chartArea1->Name = L"ChartArea1";
			this->chart1->ChartAreas->Add(chartArea1);
			legend1->Name = L"Legend1";
			this->chart1->Legends->Add(legend1);
			this->chart1->Location = System::Drawing::Point(12, 12);
			this->chart1->Name = L"chart1";
			series1->ChartArea = L"ChartArea1";
			series1->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Spline;
			series1->Legend = L"Legend1";
			series1->Name = L"E";
			this->chart1->Series->Add(series1);
			this->chart1->Size = System::Drawing::Size(792, 173);
			this->chart1->TabIndex = 2;
			this->chart1->Text = L"chart1";
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(12, 227);
			this->textBox1->Multiline = true;
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(85, 118);
			this->textBox1->TabIndex = 3;
			// 
			// textBox2
			// 
			this->textBox2->Location = System::Drawing::Point(133, 227);
			this->textBox2->Multiline = true;
			this->textBox2->Name = L"textBox2";
			this->textBox2->Size = System::Drawing::Size(22, 118);
			this->textBox2->TabIndex = 4;
			// 
			// textBox3
			// 
			this->textBox3->Location = System::Drawing::Point(175, 227);
			this->textBox3->Multiline = true;
			this->textBox3->Name = L"textBox3";
			this->textBox3->Size = System::Drawing::Size(131, 118);
			this->textBox3->TabIndex = 5;
			// 
			// textBox4
			// 
			this->textBox4->Location = System::Drawing::Point(334, 227);
			this->textBox4->Multiline = true;
			this->textBox4->Name = L"textBox4";
			this->textBox4->Size = System::Drawing::Size(138, 118);
			this->textBox4->TabIndex = 6;
			this->textBox4->TextChanged += gcnew System::EventHandler(this, &MyForm::textBox4_TextChanged);
			// 
			// textBox5
			// 
			this->textBox5->Location = System::Drawing::Point(42, 19);
			this->textBox5->Name = L"textBox5";
			this->textBox5->Size = System::Drawing::Size(66, 20);
			this->textBox5->TabIndex = 7;
			// 
			// textBox6
			// 
			this->textBox6->Location = System::Drawing::Point(42, 46);
			this->textBox6->Name = L"textBox6";
			this->textBox6->Size = System::Drawing::Size(66, 20);
			this->textBox6->TabIndex = 8;
			// 
			// textBox7
			// 
			this->textBox7->Location = System::Drawing::Point(42, 72);
			this->textBox7->Name = L"textBox7";
			this->textBox7->Size = System::Drawing::Size(66, 20);
			this->textBox7->TabIndex = 9;
			// 
			// textBox8
			// 
			this->textBox8->Location = System::Drawing::Point(136, 46);
			this->textBox8->Name = L"textBox8";
			this->textBox8->Size = System::Drawing::Size(182, 20);
			this->textBox8->TabIndex = 10;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(13, 208);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(18, 13);
			this->label1->TabIndex = 11;
			this->label1->Text = L"x0";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(37, 208);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(18, 13);
			this->label2->TabIndex = 12;
			this->label2->Text = L"x1";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(55, 208);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(18, 13);
			this->label3->TabIndex = 13;
			this->label3->Text = L"x2";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(79, 208);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(18, 13);
			this->label4->TabIndex = 14;
			this->label4->Text = L"x3";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(130, 208);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(13, 13);
			this->label5->TabIndex = 15;
			this->label5->Text = L"d";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(227, 208);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(15, 13);
			this->label6->TabIndex = 16;
			this->label6->Text = L"w";
			// 
			// label7
			// 
			this->label7->AutoSize = true;
			this->label7->Location = System::Drawing::Point(400, 208);
			this->label7->Name = L"label7";
			this->label7->Size = System::Drawing::Size(15, 13);
			this->label7->TabIndex = 17;
			this->label7->Text = L"O";
			// 
			// label8
			// 
			this->label8->AutoSize = true;
			this->label8->Location = System::Drawing::Point(18, 19);
			this->label8->Name = L"label8";
			this->label8->Size = System::Drawing::Size(18, 13);
			this->label8->TabIndex = 18;
			this->label8->Text = L"x1";
			// 
			// label9
			// 
			this->label9->AutoSize = true;
			this->label9->Location = System::Drawing::Point(18, 46);
			this->label9->Name = L"label9";
			this->label9->Size = System::Drawing::Size(18, 13);
			this->label9->TabIndex = 19;
			this->label9->Text = L"x2";
			// 
			// label10
			// 
			this->label10->AutoSize = true;
			this->label10->Location = System::Drawing::Point(18, 75);
			this->label10->Name = L"label10";
			this->label10->Size = System::Drawing::Size(18, 13);
			this->label10->TabIndex = 20;
			this->label10->Text = L"x3";
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(33, 107);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 21;
			this->button1->Text = L"Расчитать";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click_1);
			// 
			// splitter1
			// 
			this->splitter1->Location = System::Drawing::Point(0, 0);
			this->splitter1->Name = L"splitter1";
			this->splitter1->Size = System::Drawing::Size(3, 373);
			this->splitter1->TabIndex = 24;
			this->splitter1->TabStop = false;
			// 
			// label11
			// 
			this->label11->AutoSize = true;
			this->label11->Location = System::Drawing::Point(114, 49);
			this->label11->Name = L"label11";
			this->label11->Size = System::Drawing::Size(13, 13);
			this->label11->TabIndex = 25;
			this->label11->Text = L"=";
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->textBox5);
			this->groupBox1->Controls->Add(this->label11);
			this->groupBox1->Controls->Add(this->textBox6);
			this->groupBox1->Controls->Add(this->textBox7);
			this->groupBox1->Controls->Add(this->button1);
			this->groupBox1->Controls->Add(this->textBox8);
			this->groupBox1->Controls->Add(this->label10);
			this->groupBox1->Controls->Add(this->label8);
			this->groupBox1->Controls->Add(this->label9);
			this->groupBox1->Location = System::Drawing::Point(510, 208);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(323, 137);
			this->groupBox1->TabIndex = 26;
			this->groupBox1->TabStop = false;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(845, 373);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->splitter1);
			this->Controls->Add(this->label7);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->textBox4);
			this->Controls->Add(this->textBox3);
			this->Controls->Add(this->textBox2);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->chart1);
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->chart1))->EndInit();
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion


		double F(double h)
		{
			return (double)2 / (double)(1 + exp(-h)) - 1;
		}
		double F_pr(double h)
		{
			return (double)(2 * exp(-h)) / ((double)pow(1 + exp(-h), 2));
		}


		double *w = new double [11];
		double *x1, *x2, *x3, x0 = 1, *d;
		

	private: System::Void MyForm_Load(System::Object^  sender, System::EventArgs^  e) {

		srand((unsigned)time(NULL));
		x1 = new double[8];
		x2 = new double[8];
		x3 = new double[8];
		d = new double[8];
		x1[0] = 0; x1[1] = 0; x1[2] = 0; x1[3] = 0; x1[4] = 1; x1[5] = 1; x1[6] = 1; x1[7] = 1;
		x2[0] = 0; x2[1] = 0; x2[2] = 1; x2[3] = 1; x2[4] = 0; x2[5] = 0; x2[6] = 1; x2[7] = 1;
		x3[0] = 0; x3[1] = 1; x3[2] = 0; x3[3] = 1; x3[4] = 0; x3[5] = 1; x3[6] = 0; x3[7] = 1;
		d[0] = 1; d[1] = 0; d[2] = 1; d[3] = 0; d[4] = 1; d[5] = 0; d[6] = 1; d[7] = 0;

		double O1, O2, O3;
		double ep = 0.01, E = 0.1, ep_rez[8], E_rez = 1;
		//	Random^ rng = gcnew Random();
		double h11, h12, h2, dw[11], g11, g12, g2;


		for (int i = 0; i < 11; i++)
		{
			int a = 0, b = 100;
			w[i] = (a + (b - a) * rand() / RAND_MAX)*0.001;

		}
		chart1->Series["E"]->Points->AddXY(0, 0);

		while (E_rez>E)
		{
			E_rez = 0;
			for (int k = 0; k < 8; k++)
			{

				O1 = x0*w[1] + x1[k] * w[2] + x2[k] * w[3] + x3[k] * w[4];
				O2 = x0*w[5] + x1[k] * w[6] + x2[k] * w[7] + x3[k] * w[8];
				O3 = x0*w[0] + O1*w[9] + O2*w[10];

				ep_rez[k] = pow((d[k] - O3), 2);

				while (ep_rez[k] > ep)
				{
					h11 = x0*w[1] + x1[k] * w[2] + x2[k] * w[3] + x3[k] * w[4];
					h12 = x0*w[5] + x1[k] * w[6] + x2[k] * w[7] + x3[k] * w[8];
					h2 = x0*w[0] + h11*w[9] + h12*w[10];
					g2 = 2 * (d[k] - F(h2))*F_pr(h2);
					g11 = F_pr(h11)*(g2*w[9]);
					g12 = F_pr(h12)*(g2*w[10]);
					dw[1] = g11*x0;
					dw[2] = g11*x1[k];
					dw[3] = g11*x2[k];
					dw[4] = g11*x3[k];
					dw[5] = g12*x0;
					dw[6] = g12*x1[k];
					dw[7] = g12*x2[k];
					dw[8] = g12*x3[k];
					O1 = F(h11);
					O2 = F(h12);
					dw[9] = g2*O1;
					dw[10] = g2*O2;
					dw[0] = g2*x0;
					for (int i = 0; i < 11; i++)
						w[i] += dw[i];
					h11 = x0*w[1] + x1[k] * w[2] + x2[k] * w[3] + x3[k] * w[4];
					h12 = x0*w[5] + x1[k] * w[6] + x2[k] * w[7] + x3[k] * w[8];
					h2 = x0*w[0] + h11*w[9] + h12*w[10];
					/*O1 = x0*w[1] + x1[k] * w[2] + x2[k] * w[3] + x3[k] * w[4];
					O2 = x0*w[5] + x1[k] * w[6] + x2[k] * w[7] + x3[k] * w[8];
					O3 = x0*w[0] + O1*w[9] + O2*w[10];
					*/
					O1 = F(h11);
					O2 = F(h12);
					O3 = F(h2);
					ep_rez[k] = pow((d[k] - O3), 2);
					//printf("k=%d ep=%f\n",k, ep_rez[k]);

					//	textBox1->Text += k.ToString() + " ep=" + ep_rez[k].ToString()+"\r\n";
				}


				E_rez += ep_rez[k];
				chart1->Series["E"]->Points->AddXY(k + 1, E_rez);
			}
			//textBox1->Text += O3.ToString() + "\r\n";


			//textBox1->Text += k.ToString() + " " + ep_rez[k].ToString();
			//	textBox1->Text += E_rez.ToString()+" ";
		}
		int l = 1;
		for (int k = 0; k < 8; k++)
		{
			O1 = x0*w[1] + x1[k] * w[2] + x2[k] * w[3] + x3[k] * w[4];
			O2 = x0*w[5] + x1[k] * w[6] + x2[k] * w[7] + x3[k] * w[8];
			O3 = x0*w[0] + O1*w[9] + O2*w[10];

			textBox1->Text += x0.ToString()+"     "+x1[k].ToString() + "     " + x2[k].ToString() + "     " + x3[k].ToString() + "\r\n";
			textBox2->Text += d[k].ToString() + "\r\n";
			textBox3->Text += w[k].ToString() + "\r\n";
			textBox4->Text += O3.ToString() + "\r\n";
		}
	
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

	}
private: System::Void dataGridView1_CellContentClick(System::Object^  sender, System::Windows::Forms::DataGridViewCellEventArgs^  e) {
}
private: System::Void textBox4_TextChanged(System::Object^  sender, System::EventArgs^  e) {
}
private: System::Void button1_Click_1(System::Object^  sender, System::EventArgs^  e) {

	double c1 = Convert::ToDouble(textBox5->Text);
	double c2 = Convert::ToDouble(textBox6->Text);
	double c3 = Convert::ToDouble(textBox7->Text);

	double O1, O2, O3;
	O1 = x0*w[1] + c1 * w[2] + c2 * w[3] + c3 * w[4];
	O2 = x0*w[5] + c1 * w[6] + c2 * w[7] + c3 * w[8];
	O3 = x0*w[0] + O1*w[9] + O2*w[10];
	textBox8->Text = O3.ToString();
}
};
}
