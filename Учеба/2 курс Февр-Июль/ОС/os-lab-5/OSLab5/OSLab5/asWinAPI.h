
#pragma once

#include <windows.h>
#include <stdio.h>
#include <strsafe.h>

typedef VOID (*pfErrorHandler)(LPCSTR lpFailedFunction, DWORD dwErrorCode);
typedef VOID (*pfThreadStart)();
typedef VOID (*pfParamThreadStart)(LPVOID lpParameter);
typedef VOID (*pfPrintMessage)(LPCSTR lpDisplayMessage);

extern pfErrorHandler GlobalErrorHandler;

VOID WINAPI PrintErrorMessage(LPCSTR lpFailedFunction, DWORD dwErrorCode, pfPrintMessage PrintMessage);
VOID PrintErrorMessage(LPCSTR lpFailedFunction, DWORD dwErrorCode);
VOID ProcessErrorMessage(LPCSTR lpFailedFunction, DWORD dwErrorCode);
VOID PrintMessage(LPCSTR lpDisplayMessage);

VOID WINAPI SWaitForSomeTime(DWORD time);
HANDLE WINAPI SCreateMutex(BOOL bInitialOwner = FALSE);
VOID WINAPI SCloseHandle(HANDLE handle);
BOOL WINAPI SWaitForSingleObject(HANDLE handle, DWORD time = INFINITE);
VOID WINAPI SSWaitForSingleObject(HANDLE handle, DWORD time = INFINITE);
VOID WINAPI SReleaseMutex(HANDLE hMutex);
HANDLE WINAPI SCreateEvent(LPCTSTR lpEventName = NULL);
VOID WINAPI SSetEvent(HANDLE hEvent);


class Thread
{
private:
	HANDLE hThread;
	DWORD dwError;
	BOOL isRunning;
	BOOL isPaused;
	DWORD priority;
	const char *sFuncFailed;
	void clearError();
	void setError(const char *sFuncFailed);
	void setStartedState();
	void setStoppedState();
	void closeThread();
	void setupPriority();
public:
	static pfErrorHandler ErrorHandler;
	Thread();
	~Thread();
	void Abort();
	void Join();
	void Start(pfThreadStart threadStart);
	void Start(pfParamThreadStart threadStart, LPVOID lpParameter);
	void Pause();
	void Resume();
	BOOL IsRunning() { return this->isRunning; }
	BOOL IsPaused() { return this->isPaused; }
	HANDLE Handle() { return this->hThread; }
	DWORD Priority() { return this->priority; }
	void Priority(DWORD priority) { this->priority = priority; }
};


VOID WINAPI WaitForThread(Thread &thread, DWORD time = INFINITE);
VOID WINAPI WaitForThreads(Thread **threads, DWORD numThreads, DWORD time = INFINITE);

Thread **AllocThreads(const int num);
void DisposeThreads(Thread** threads, const int num);
