// OSLab5.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "asWinAPI.h"

#define STRING_BUFFER_SIZE 80

int iNumThreads = 3;
const int minNumThreads = 2;
const int maxNumThreads = 10;
const char *sDatabaseFilename = "database.txt";
char lpSharedBuffer[STRING_BUFFER_SIZE];

CRITICAL_SECTION fibonnachiSession;
unsigned long num1;
unsigned long num2;
unsigned int n;
const int maxN = 70;

HANDLE ghMutex;
HANDLE ghWriteEvent;
BOOL bAbortThreads;



VOID FibonnachiThreadStart()
{
    while (bAbortThreads == FALSE)
	{
		EnterCriticalSection(&fibonnachiSession);
		if (n < maxN)
		{
			unsigned long nextNum = num1 + num2;
			num1 = num2;
			num2 = nextNum;
			++n;
		}
		LeaveCriticalSection(&fibonnachiSession);
	}
}

VOID PrintFibonnachiThreadStart()
{
    static long N = -1;
    while (bAbortThreads == FALSE)
	{
		EnterCriticalSection(&fibonnachiSession);
		if (N != n)
		{
			printf("> %d - %d\r\n", n, num2);
			N = n;
		}
		LeaveCriticalSection(&fibonnachiSession);
	}
}

VOID DatabaseWriteThreadStart()
{
	int i = 0;
	while (bAbortThreads == FALSE)
	{
		if (SWaitForSingleObject(ghMutex) == TRUE)
		{
			__try
			{
				++i;
				printf("> Thread %d writing to database...", GetCurrentThreadId());
				// TODO: write to database...
				FILE *fp;
				fopen_s(&fp, sDatabaseFilename, "a+");
				fprintf(fp, "Record #%d for thread %d\n", i, GetCurrentThreadId());
				printf(" #%d", i);
				fclose(fp);
				printf(" DONE\r\n");
			}
			__finally
			{
				SReleaseMutex(ghMutex);
			}
		}
	}
}

VOID ReadFromBufferThreadStart()
{
	SSWaitForSingleObject(ghWriteEvent);
	// TODO: Читаем из разделяемого буфера
	printf("> Thread %d is reading from buffer...\r\n", GetCurrentThreadId());
	char buffer[STRING_BUFFER_SIZE];
	strcpy_s(buffer, lpSharedBuffer);
	printf("> Thread %d: \'%s\'\r\n", GetCurrentThreadId(), buffer);
}

void WriteToBuffer(char *buffer)
{
	// TODO: Пишем в разделяемый буфер
	printf("> Writing to buffer...");
	strcpy_s(lpSharedBuffer, buffer);
	printf(" DONE\r\n");
	SSetEvent(ghWriteEvent);
}

void DoCriticalSectionTest()
{
	bAbortThreads = FALSE;
	num1 = 0L;
	num2 = 1L;
	n = 0;
	InitializeCriticalSection(&fibonnachiSession);
	Thread **threads = AllocThreads(iNumThreads);
	threads[0]->Priority(THREAD_PRIORITY_ABOVE_NORMAL);
	threads[0]->Start(PrintFibonnachiThreadStart);
	for (int i = 1; i < iNumThreads; i++)
	{
		threads[i]->Priority(THREAD_PRIORITY_BELOW_NORMAL);
		threads[i]->Start(FibonnachiThreadStart);
	}
	SWaitForSomeTime(1000);
	bAbortThreads = TRUE;
	WaitForThreads(threads, iNumThreads);
	DisposeThreads(threads, iNumThreads);
    DeleteCriticalSection(&fibonnachiSession);
}

void DoMutexTest()
{
	remove(sDatabaseFilename);
	ghMutex = SCreateMutex();
	bAbortThreads = FALSE;
	// создаем и запускаем потоки
	Thread **threads = AllocThreads(iNumThreads);
	// threads[0]->Priority(THREAD_PRIORITY_LOWEST);
	for (int i = 0; i < iNumThreads; i++)
		threads[i]->Start(DatabaseWriteThreadStart);
	// ждем
	SWaitForSomeTime(1000);
	// завершаем потоки
	bAbortThreads = TRUE;
	WaitForThreads(threads, iNumThreads);
	DisposeThreads(threads, iNumThreads);
	SCloseHandle(ghMutex);
}

void DoEventsTest()
{
	ghWriteEvent = SCreateEvent();
	Thread **threads = AllocThreads(iNumThreads);
	for (int i = 0; i < iNumThreads; i++)
		threads[i]->Start(ReadFromBufferThreadStart);
	char buffer[STRING_BUFFER_SIZE];
	printf("> Input buffer string: ");
	do gets_s(buffer); while (*buffer == '\0');
	WriteToBuffer(buffer);
	WaitForThreads(threads, iNumThreads);
	DisposeThreads(threads, iNumThreads);
	SCloseHandle(ghWriteEvent);
}

int ShowMainMenu()
{
	system("CLS");
	printf("*** Main Menu ***\r\n");
	printf("1 - Critical section test\r\n");
	printf("2 - Mutex test\r\n");
	printf("3 - Event test\r\n");
	printf("0 - Exit program\r\n");
	printf("\r\n> Your choice: ");
	char ch;
	do ch = getch(); while (ch != '1' && ch != '2' && ch != '3' && ch != '0');
	printf("%c\r\n", ch);
	switch (ch)
	{
		case '1':	return 1;
		case '2':	return 2;
		case '3':	return 3;
		default:	return 0;
	}
}

int GetNumThreads()
{
	printf("> Input number of threads [%d..%d]: ", minNumThreads, maxNumThreads);
	int num;
	do scanf("%d", &num); while (num < minNumThreads || num > maxNumThreads);
	return num;
}




int _tmain(int argc, _TCHAR* argv[])
{
	int choice;
	do
	{
		choice = ShowMainMenu();
		switch (choice)
		{
			case 1:		iNumThreads = GetNumThreads();
						DoCriticalSectionTest();
						break;
			case 2:		iNumThreads = GetNumThreads();
						DoMutexTest();
						break;
			case 3:		iNumThreads = GetNumThreads();
						DoEventsTest();
						break;
		}
		if (choice != 0)
		{
			printf("\r\n");
			system("PAUSE");
		}
	} while (choice != 0);
	return 0;
}
