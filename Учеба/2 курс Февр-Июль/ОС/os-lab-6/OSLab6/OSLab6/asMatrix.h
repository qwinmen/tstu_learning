
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
	Matrix(int *matr, int row, int col);		// создает матрицу из одномерного массива целых чисел
	Matrix(const Matrix &matrix);				// создает копию указанной матрицы
	Matrix(const Matrix &matrix, int I, int J);	// создает матрицу, являющуюся минором I-й строки J-го столбца указанной матрицы
	~Matrix();									// освобождает память, занимаемую матрицей
	void Print();								// выводит содержимое матрицы на консоль
	int Get(int i, int j)						// получает элемент i-й строки j-го столбца
		{ return this->matr[i][j]; }
	void Set(int value, int i, int j)			// задает элемент i-й строки j-го столбца
		{ this->matr[i][j] = value; }
	int Rows()
		{ return row; }
	int Columns()
		{ return col; }
	void Mult(int value);						// умножает матрицу на число
	void Div(int value);						// целочисленно делит матрицу на число
	DetMatrixes *GetDetRow(int row);			// возвращает массив из матриц (размерностью Columns для строки row), помноженных на коэффициенты, используемых для вычисления детерминанта
	DetMatrixes *GetDetCol(int col);			// возвращает массив из матриц (размерностью Rows для столбца col), помноженных на коэффициенты, используемых для вычисления детерминанта
	DetMatrixes *GetDet(bool isRow = true, int rowcol = 0);
	int EvalDet(bool isRow = true, int rowcol = 0);
	LPVOID Write(LPVOID buffer);				// записывает содержимое матрицы в буфер памяти, возвращает текущую позицию в буфере
};

struct DetMatrixes								// результат выполнения методов GetDetRow и GetDetCol у класса Matrix
{
	Matrix **M;									// матрицы
	int *K;										// коэффициенты, на которые должны умножаться матрицы
	int N;										// число матриц и коэффициентов
	DetMatrixes(Matrix **m, int *k, int n):
		M(m), K(k), N(n) { }
	DetMatrixes(LPVOID &buffer);
	~DetMatrixes();
	LPVOID Write(LPVOID buffer);
};

void DeleteMatrixes(Matrix **matrixes, int num);		// удаляет массив матриц из памяти
int EvalMatrixDet(DetMatrixes *d, bool isRow = true);	// вычисляет детерминант для заданных параметров
Matrix *ReadMatrix(const char *filename);				// читает матрицу из заданного файла
Matrix *ReadMatrix(LPVOID &buffer, int n = 0);			// читает матрицу номер n из буфера buffer
