
#pragma once

#include <stdio.h>
#include <stdlib.h>


struct DetMatrixes;

class Matrix
{
private:
	int **matr;
	int row, col;
public:
	Matrix(int *matr, int row, int col);		// ������� ������� �� ����������� ������� ����� �����
	Matrix(const Matrix &matrix);				// ������� ����� ��������� �������
	Matrix(const Matrix &matrix, int I, int J);	// ������� �������, ���������� ������� I-� ������ J-�� ������� ��������� �������
	~Matrix();									// ����������� ������, ���������� ��������
	void Print();								// ������� ���������� ������� �� �������
	int Get(int i, int j)						// �������� ������� i-� ������ j-�� �������
		{ return this->matr[i][j]; }
	void Set(int value, int i, int j)			// ������ ������� i-� ������ j-�� �������
		{ this->matr[i][j] = value; }
	int Rows()
		{ return row; }
	int Columns()
		{ return col; }
	void Mult(int value);						// �������� ������� �� �����
	void Div(int value);						// ������������ ����� ������� �� �����
	DetMatrixes *GetDetRow(int row);			// ���������� ������ �� ������ (������������ Columns ��� ������ row), ����������� �� ������������, ������������ ��� ���������� ������������
	DetMatrixes *GetDetCol(int col);			// ���������� ������ �� ������ (������������ Rows ��� ������� col), ����������� �� ������������, ������������ ��� ���������� ������������
	DetMatrixes *GetDet(bool isRow = true, int rowcol = 0);
	int EvalDet(bool isRow = true, int rowcol = 0);
	LPVOID Write(LPVOID buffer);				// ���������� ���������� ������� � ����� ������, ���������� ������� ������� � ������
};

struct DetMatrixes								// ��������� ���������� ������� GetDetRow � GetDetCol � ������ Matrix
{
	Matrix **M;									// �������
	int *K;										// ������������, �� ������� ������ ���������� �������
	int N;										// ����� ������ � �������������
	DetMatrixes(Matrix **m, int *k, int n):
		M(m), K(k), N(n) { }
	DetMatrixes(LPVOID &buffer);
	~DetMatrixes();
	LPVOID Write(LPVOID buffer);
};

void DeleteMatrixes(Matrix **matrixes, int num);		// ������� ������ ������ �� ������
int EvalMatrixDet(DetMatrixes *d, bool isRow = true);	// ��������� ����������� ��� �������� ����������
Matrix *ReadMatrix(const char *filename);				// ������ ������� �� ��������� �����
Matrix *ReadMatrix(LPVOID &buffer, int n = 0);			// ������ ������� ����� n �� ������ buffer
