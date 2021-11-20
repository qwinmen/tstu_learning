// OSLab6.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "asMatrix.h"
#include "asBuffers.h"

const DWORD dwBufferLength = 80;
const char *sMatrixFileName = "matrix.txt";

BOOL bCanStartServer = TRUE;

int StartClient(bool bPauseOnError);
void ClientThreadStart();


int _tmain(int argc, _TCHAR* argv[])
{
	BOOL isServer = SDetectClientServer();
	if (isServer == TRUE)
	{	// режим сервера
		printf("> Server mode initiated.\r\n");
		char filename[dwBufferLength];
		Matrix *matrix;
		do
		{	// вводим имя файла и читаем матрицу, пока не добьемся успеха
			printf("> Input matrix filename: ");
			scanf_s("%s", &filename, dwBufferLength);
			if (filename[0]  == '\0')
			{
				printf("> Server mode canceled.\r\n");
				system("PAUSE");
				return 1;
			}
			matrix = ReadMatrix(filename);
			if (matrix == NULL)
			{
				printf("! Error while reading matrix from file \'%s\'!\r\n", filename);
			}
			else if (matrix->Columns() != matrix->Rows())
			{
				printf("! Error: matrix dimensions do not match.\r\n");
				delete matrix;
				matrix = NULL;
			}
		} while (matrix == NULL);
		printf("> Matrix successfully loaded.\r\n");
		matrix->Print();
		// пользователь выбирает режим разложения матрицы: по строке (Row) или по столбцу (Column)
		printf("> Choose evaluation mode [R=Row, C=Column]: ");
		char ch;
		do ch = toupper(_getch());
		while (ch != 'R' && ch != 'C');
		bool isRow = (ch == 'R');
		if (isRow)
		{
			printf("Row\r\n");
		}
		else
		{
			printf("Column\r\n");
		}
		int rowcol;
		do
		{	// пользователь вводит номер строки (столбца), по которой будет происходить разложение матрицы
			if (isRow)
			{
				printf("> Input row number for evaluation [1..%d]: ", matrix->Rows());
			}
			else
			{
				printf("> Input column number for evaluation [1..%d]: ", matrix->Columns());
			}
			scanf_s("%d", &rowcol);
			if (rowcol < 1 || rowcol > matrix->Rows())
			{
				printf("! Error: number do not match range. Try again.\r\n");
				rowcol = 0;
			}
		} while (rowcol == 0);
		--rowcol;
		// разлагаем матрицу NxN на матрицы (N-1)x(N-1) согласно желаниям пользователя
		DetMatrixes *D = matrix->GetDet(isRow, rowcol);
		if (D == NULL)
		{
			printf("! Error while performing task creation.\r\n");
			delete matrix;
			system("PAUSE");
			return 2;
		}
		printf("> Task creation completed.\r\n");
		// выводим полученные матрицы
		for (int i = 0; i < D->N; i++)
		{
			printf("Task %d: ", i + 1);
			D->M[i]->Print();
			if (i < D->N - 1)
			{
				printf("-----\r\n");
			}
		}
		printf("> Total %d tasks.\r\n", D->N);
		// ждем, пока пользователь не решит запустить сервер
		printf("> Press one of the following keys:\r\n");
		printf("  ENTER - start a server in this process\r\n");
		printf("  SPACE - start a server and a client in this process\r\n");
		printf("  ESC   - exit process without server creation\r\n");
		printf("Your choice: ");
		bool fRepeat, fLaunchClient = false;
		do
		{
			fRepeat = false;
			ch = _getch();
			switch (ch)
			{
			case char(13):
				printf("ENTER\r\n");
				fLaunchClient = false;
				break;
			case char(32):
				printf("SPACE\r\n");
				fLaunchClient = true;
				break;
			case char(27):
				printf("ESC\r\n");
				printf("> Server mode canceled.\r\n");
				delete D;
				delete matrix;
				system("PAUSE");
				return 1;
			default:
				fRepeat = true;
				break;
			}
		} while (fRepeat);
		// запускаем сервер и, если нужно, клиент
		printf("> Checking for another servers running...\r\n");
		isServer = SDetectClientServer();
		if (isServer != TRUE)
		{
			printf("! Error: another server has already been launched.");
			delete D;
			delete matrix;
			system("PAUSE");
			return 3;
		}
		printf("> Launching server...\r\n");
		ClientServerProcess *process = new ClientServerProcess(matrix, D);
		if (process->IsServerMode != TRUE)
		{
			printf("! Error: another server has already been launched.");
			delete process;
			system("PAUSE");
			return 3;
		}
		printf("> Server launched.\r\n");
		Thread *clientThread;
		if (fLaunchClient)
		{
			bCanStartServer = FALSE;
			clientThread = new Thread();
			clientThread->Start(ClientThreadStart);
			// ждем полсекунды, чтобы сообщения о запуске клиента выдавались раньше, чем приглашение нажать клавишу
			SWaitForSomeTime(500);
		}
		// с этого момента процессы-клиенты могут подключаться
		printf("> Connect clients and then press any key to start tasks...");
		// ждем, пока пользователь не решит запустить вычислительные задачи на исполнение
		_getch();
		// запускаем задачи на исполнение
		printf("\r\n> Starting tasks...\r\n");
		while (bCanStartServer == FALSE) ;
		int det = process->Process();
		// результат получен, можно завершить исполнение сервера (и, если нужно, клиента) и вывести его
		printf("> Server finished. Total clients connected: %d\r\n", process->dwClientsNum);
		if (fLaunchClient)
		{
			WaitForThread(*clientThread);
			delete clientThread;
		}
		printf("> Shutting down server...\r\n");
		delete process;
		printf("> Server was shutdown.\r\n");
		printf("> Matrix determinant = %d\r\n", det);
	}
	else
	{	// режим клиента
		printf("> Client mode initiated. Process ID = %d\r\n", GetCurrentProcessId());
		printf("> Press Esc to abort or any key to start client...");
		char ch = _getch();
		printf("\r\n");
		if (ch == char(27))
		{
			printf("> Client mode canceled.\r\n");
			system("PAUSE");
			return 1;
		}
		int result = StartClient(true);
		if (result != 0)
			return result;
	}
	system("PAUSE");
	return 0;
}

int StartClient(bool bPauseOnError)
{
	DWORD id = GetCurrentProcessId();
	printf("> Client %d: starting...\r\n", id);
	ClientServerProcess *process = new ClientServerProcess();
	bCanStartServer = TRUE;
	process->processId = id;
	if (process->IsServerMode != FALSE)
	{
		printf("! Client %d: server no longer available to connect.", id);
		delete process;
		if (bPauseOnError)
		{
			system("PAUSE");
		}
		return 3;
	}
	printf("> Client %d: connected to server.\r\n", id);
	printf("> Client %d: waiting for server to start...\r\n", id);
	process->Process();
	printf("> Client %d: work completed. Server has results for this client.\r\n", id);
	printf("> Client %d: shutting down...\r\n", id);
	delete process;
	printf("> Client %d: was shutdown.\r\n", id);
	return 0;
}

void ClientThreadStart()
{
	StartClient(false);
}
