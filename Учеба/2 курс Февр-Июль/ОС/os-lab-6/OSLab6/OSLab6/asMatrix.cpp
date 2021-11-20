
#include "stdafx.h"
#include "asMatrix.h"

DetMatrixes::~DetMatrixes()
{
	DeleteMatrixes(this->M, this->N);
	delete[] K;
}

Matrix::Matrix(int *matr, int row, int col)
{
	this->row = row;
	this->col = col;
	this->matr = new int*[this->row];
	int **_thismatr = this->matr, *_matr = matr;
	for (int i = 0; i < this->row; i++)
	{
		*_thismatr = new int[this->col];
		int *__thismatr = *_thismatr++;
		for (int j = 0; j < this->col; j++)
		{
			*__thismatr++ = *_matr++;
		}
	}
}

Matrix::Matrix(const Matrix &matrix)
{
	this->row = matrix.row;
	this->col = matrix.col;
	this->matr = new int*[this->row];
	int **_thismatr = this->matr, **_matr = matrix.matr;
	for (int i = 0; i < this->row; i++)
	{
		*_thismatr = new int[this->col];
		int *__thismatr = *_thismatr++, *__matr = *_matr++;
		for (int j = 0; j < this->col; j++)
		{
			*__thismatr++ = *__matr++;
		}
	}
}

Matrix::Matrix(const Matrix &matrix, int I, int J)
{
	this->row = matrix.row - 1;
	this->col = matrix.col - 1;
	this->matr = new int*[this->row];
	int **_thismatr = this->matr, **_matr = matrix.matr;
	for (int i = 0; i < matrix.row; i++)
	{
		int *__matr = *_matr++;
		if (i != I)
		{
			*_thismatr = new int[this->col];
			int *__thismatr = *_thismatr++;
			for (int j = 0; j < matrix.col; j++)
			{
				if (j != J)
				{
					*__thismatr++ = *__matr;
				}
				__matr++;
			}
		}
	}
}

Matrix::~Matrix()
{
	int **_matr = this->matr;
	for (int i = 0; i < row; i++)
		delete[] *_matr++;
	delete[] this->matr;
}

void Matrix::Print()
{
	printf("Matrix %dx%d\r\n", this->row, this->col);
	for (int i = 0; i < this->row; i++)
	{
		for (int j = 0; j < this->col; j++)
		{
			printf("%d", this->matr[i][j]);
			if (j < this->col - 1)
				putchar(' ');
		}
		puts("");
	}
}

void Matrix::Mult(int value)
{
	int **_thismatr = this->matr;
	for (int i = 0; i < this->row; i++)
	{
		int *__thismatr = *_thismatr++;
		for (int j = 0; j < this->col; j++)
		{
			*__thismatr *= value;
			__thismatr++;
		}
	}
}

void Matrix::Div(int value)
{
	int **_thismatr = this->matr;
	for (int i = 0; i < this->row; i++)
	{
		int *__thismatr = *_thismatr++;
		for (int j = 0; j < this->col; j++)
		{
			*__thismatr /= value;
			__thismatr++;
		}
	}
}

DetMatrixes *Matrix::GetDetRow(int row)
{
	int n = this->col;
	int *k = new int[n];
	Matrix **matrixes = new Matrix*[n], **_matrixes = matrixes;
	for (int j = 0; j < n; j++, _matrixes++)
	{
		int m;
		if ((row + j) % 2)
			m = -1;
		else
			m = +1;
		m *= this->matr[row][j];
		k[j] = m;
		*_matrixes = new Matrix(*this, row, j);
	}
	return new DetMatrixes(matrixes, k, n);
}

DetMatrixes *Matrix::GetDetCol(int col)
{
	int n = this->row;
	int *k = new int[n];
	Matrix **matrixes = new Matrix*[n], **_matrixes = matrixes;
	for (int i = 0; i < n; i++, _matrixes++)
	{
		int m;
		if ((col + i) % 2)
			m = -1;
		else
			m = +1;
		m *= this->matr[i][col];
		k[i] = m;
		*_matrixes = new Matrix(*this, i, col);
	}
	return new DetMatrixes(matrixes, k, n);
}

DetMatrixes *Matrix::GetDet(bool isRow, int rowcol)
{
	DetMatrixes *d;
	if (isRow)
		d = this->GetDetRow(rowcol);
	else
		d = this->GetDetCol(rowcol);
	return d;
}

DetMatrixes::DetMatrixes(LPVOID &buffer)
{
	DWORD *_nBuffer = (DWORD*)buffer;
	this->N = *_nBuffer++;
	this->K = new int[this->N];
	this->M = new Matrix*[this->N];
	for (int i = 0; i < this->N; i++)
	{
		this->K[i] = *_nBuffer++;
		LPVOID lpBuffer = _nBuffer;
		this->M[i] = ReadMatrix(lpBuffer);
		_nBuffer = (DWORD*)lpBuffer;
	}
	buffer = _nBuffer;
}

LPVOID DetMatrixes::Write(LPVOID buffer)
{
	DWORD *_nBuffer = (DWORD*)buffer;
	*_nBuffer++ = this->N;
	for (int i = 0; i < this->N; i++)
	{
		*_nBuffer++ = this->K[i];
		_nBuffer = (DWORD*)this->M[i]->Write(_nBuffer);
	}
	return _nBuffer;
}

int Matrix::EvalDet(bool isRow, int rowcol)
{
	if (this->row != this->col)
		return 0;
	if (this->row == 1)
		return **this->matr;
	DetMatrixes *d = this->GetDet(isRow, rowcol);
	int sum = EvalMatrixDet(d, isRow);
	delete d;
	return sum;
}

LPVOID Matrix::Write(LPVOID buffer)
{
	int *_numbers = (int*)buffer;
	*_numbers++ = this->row;
	*_numbers++ = this->col;
	for (int i = 0; i < this->row; i++)
	{
		for (int j = 0; j < this->col; j++)
		{
			*_numbers++ = this->matr[i][j];
		}
	}
	return _numbers;
}

void DeleteMatrixes(Matrix **matrixes, int num)
{
	Matrix **_matrixes = matrixes;
	for (int i = 0; i < num; i++)
		delete *_matrixes++;
	delete[] matrixes;
}

int EvalMatrixDet(DetMatrixes *d, bool isRow)
{
	int sum = 0;
	for (int i = 0; i < d->N; i++)
	{
		sum += d->K[i] * d->M[i]->EvalDet(isRow, 0);
	}
	return sum;
}

Matrix *ReadMatrix(const char *filename)
{
	FILE *lpFile;
	if (fopen_s(&lpFile, filename, "r") != 0)
		return NULL;
	int rows, cols;
	if (fscanf_s(lpFile, "%d%d", &rows, &cols) != 2)
		return NULL;
	int num = rows * cols;
	int *A = new int[num];
	for (int i = 0; i < num; i++)
	{
		int a;
		if (fscanf_s(lpFile, "%d", &a) != 1)
		{
			fclose(lpFile);
			delete[] A;
			return NULL;
		}
		else
		{
			A[i] = a;
		}
	}
	fclose(lpFile);
	Matrix *matrix = new Matrix(A, rows, cols);
	delete[] A;
	return matrix;
}

Matrix *ReadMatrix(LPVOID &buffer, int n)
{
	int *_numbers = (int*)buffer;
	int rows, cols, num, *A;
	for (int i = 0; i <= n; i++)
	{
		rows = *_numbers++;
		cols = *_numbers++;
		num = rows * cols;
		if (i == n)
		{
			A = new int[num];
			for (int i = 0; i < num; i++)
			{
				A[i] = *_numbers++;
			}
		}
		else
		{
			for (int i = 0; i < num; i++)
				_numbers++;
		}
	}
	Matrix *matrix = new Matrix(A, rows, cols);
	delete[] A;
	buffer = _numbers;
	return matrix;
}
