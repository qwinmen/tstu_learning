#include "asWinAPI.h"
#include "stdafx.h"

pfErrorHandler Thread::ErrorHandler = ProcessErrorMessage;
pfErrorHandler GlobalErrorHandler = ProcessErrorMessage;

struct ThreadParameter
{
	BOOL isParamStart;
	pfThreadStart threadStart;
	pfParamThreadStart paramThreadStart;
	LPVOID lpParameter;

	ThreadParameter(pfThreadStart ThreadStart):
		isParamStart(FALSE), threadStart(ThreadStart), paramThreadStart(NULL), lpParameter(NULL)
		{ };
	ThreadParameter(pfParamThreadStart ThreadStart, LPVOID Parameter):
		isParamStart(TRUE), threadStart(NULL), paramThreadStart(ThreadStart), lpParameter(Parameter)
		{ };
};

DWORD WINAPI StartThreadRoutine(LPVOID lpThreadParameter)
{
	ThreadParameter *threadParameter = (ThreadParameter*)lpThreadParameter;
	if (threadParameter->isParamStart == FALSE)
		threadParameter->threadStart();
	else
		threadParameter->paramThreadStart(threadParameter->lpParameter);
	delete threadParameter;
	return 0;
}

VOID WINAPI PrintErrorMessage(LPCSTR lpFailedFunction, DWORD dwErrorCode, pfPrintMessage PrintMessage)
{
    LPVOID lpMsgBuf;
    LPVOID lpDisplayBuf;
	FormatMessageA(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM |
        FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL, dwErrorCode, NULL,
        (LPSTR) &lpMsgBuf, 0, NULL);
    LPSTR lpMsgBufStr = (LPSTR)lpMsgBuf;
	lpDisplayBuf = (LPVOID)LocalAlloc(LMEM_ZEROINIT, 
		(lstrlenA((LPCSTR)lpMsgBuf) + lstrlenA((LPCSTR)lpFailedFunction) + 40) * sizeof(CCHAR)); 
    StringCchPrintfA((LPSTR)lpDisplayBuf, 
        LocalSize(lpDisplayBuf) / sizeof(CCHAR),
        "%s failed with error %d: %s", 
        lpFailedFunction, dwErrorCode, lpMsgBuf);
	LPSTR lpDisplayBufStr = (LPSTR)lpDisplayBuf;
    PrintMessage((LPCSTR)lpDisplayBuf);
    LocalFree(lpMsgBuf);
    LocalFree(lpDisplayBuf);
}

VOID PrintMessage(LPCSTR lpDisplayMessage)
{
	printf("! %s", lpDisplayMessage);
}

VOID PrintErrorMessage(LPCSTR lpFailedFunction, DWORD dwErrorCode)
{
	PrintErrorMessage(lpFailedFunction, dwErrorCode, PrintMessage);
}

VOID ProcessErrorMessage(LPCSTR lpFailedFunction, DWORD dwErrorCode)
{
	PrintErrorMessage(lpFailedFunction, dwErrorCode);
	printf("\r\n");
	system("PAUSE");
	TerminateThread(GetCurrentThread(), dwErrorCode);
}

VOID setGlobalError(const char *sFuncFailed)
{
	if (GlobalErrorHandler != NULL)
		GlobalErrorHandler(sFuncFailed, GetLastError());
}

VOID WINAPI SWaitForSomeTime(DWORD time)
{
    HANDLE hTimer = CreateWaitableTimer(NULL, TRUE, NULL);
    if (hTimer == NULL)
	{
		setGlobalError("global:CreateWaitableTimer");
		return;
	}
	LARGE_INTEGER lTime;
    lTime.LowPart = time;
    lTime.HighPart = 0;
    lTime.QuadPart = -10000LL * time;
    if (SetWaitableTimer(hTimer, &lTime, 0, NULL, NULL, FALSE) == FALSE)
    {
		setGlobalError("global:SetWaitableTimer");
        return;
    }
    SSWaitForSingleObject(hTimer);
    SCloseHandle(hTimer);
    return;
}

HANDLE WINAPI SCreateMutex(BOOL bInitialOwner)
{
	HANDLE hMutex = CreateMutex(NULL, bInitialOwner, NULL);
	if (hMutex == NULL)
		setGlobalError("global:CreateMutexSafe");
	return hMutex;
}

VOID WINAPI SCloseHandle(HANDLE handle)
{
	if (CloseHandle(handle) == FALSE)
		setGlobalError("global:CloseHandleSafe");
}

BOOL WINAPI SWaitForSingleObject(HANDLE handle, DWORD time)
{
	DWORD result = WaitForSingleObject(handle, time);
	if (result == WAIT_ABANDONED)
		setGlobalError("global:WaitForSingleObject");
	return (result == WAIT_OBJECT_0);
}

VOID WINAPI SSWaitForSingleObject(HANDLE handle, DWORD time)
{
	if (SWaitForSingleObject(handle, time) == FALSE)
		setGlobalError("global:WaitForSingleObject");
}

VOID WINAPI SReleaseMutex(HANDLE hMutex)
{
	if (ReleaseMutex(hMutex) == FALSE)
		setGlobalError("global:ReleaseMutex");
}

HANDLE WINAPI SCreateEvent(LPCTSTR lpEventName)
{
	HANDLE hEvent = CreateEvent(NULL, TRUE, FALSE, lpEventName);
	if (hEvent == NULL)
		setGlobalError("global:CreateEvent");
	return hEvent;
}

VOID WINAPI SSetEvent(HANDLE hEvent)
{
	if (SetEvent(hEvent) == FALSE)
		setGlobalError("global:SetEvent");
}



void Thread::clearError()
{
	this->sFuncFailed = NULL;
	this->dwError = 0;
}

void Thread::setError(const char *sFuncFailed)
{
	this->sFuncFailed = sFuncFailed;
	this->dwError = GetLastError();
	if (Thread::ErrorHandler != NULL)
		Thread::ErrorHandler((LPCSTR)this->sFuncFailed, this->dwError);
}

void Thread::setStartedState()
{
	if (ResumeThread(this->hThread) == -1)
		setError("Thread:ResumeThread");
	else
	{
		this->isPaused = FALSE;
		this->isRunning = TRUE;
	}
}

void Thread::setStoppedState()
{
	this->clearError();
	this->isRunning = FALSE;
	this->isPaused = FALSE;
	this->hThread = NULL;
}

void Thread::closeThread()
{
	if (this->hThread == NULL)
		return;
	if (CloseHandle(this->hThread) == FALSE)
		this->setError("Thread:CloseHandle");
}

void Thread::setupPriority()
{
	if (this->priority != 0 && this->hThread != NULL)
	{
		if (SetThreadPriority(this->hThread, this->priority) == FALSE)
			this->setError("Thread:SetThreadPriority");
	}
}




Thread::Thread()
{
	this->isRunning = FALSE;
	this->isPaused = FALSE;
	this->hThread = NULL;
	this->priority = 0;
	this->clearError();
}

Thread::~Thread()
{
	if (this->hThread == NULL)
		return;
	this->Abort();
	this->closeThread();
}

void Thread::Abort()
{
	if (this->hThread == NULL)
		return;
	if (this->isRunning == TRUE)
	{
		if (TerminateThread(this->hThread, -1) == FALSE)
			this->setError("Thread.Abort:TerminateThread");
		else
			this->setStoppedState();
	}
}

void Thread::Join()
{
	if (this->hThread == NULL)
		return;
	if (this->isRunning == TRUE)
	{
		if (WaitForSingleObject(this->hThread, INFINITE) == 0)
			this->setError("Thread.Join:WaitForSingleObject");
		else
			this->setStoppedState();
	}
}

void Thread::Start(pfThreadStart threadStart)
{
	ThreadParameter *param = new ThreadParameter(threadStart);
	this->hThread = CreateThread(NULL, 0, &StartThreadRoutine, param, 0, NULL);
	this->setupPriority();
	if (hThread == NULL)
		this->setError("Thread.Start:CreateThread");
	else
		this->setStartedState();
}

void Thread::Start(pfParamThreadStart threadStart, LPVOID lpParameter)
{
	ThreadParameter param(threadStart, lpParameter);
	this->hThread = CreateThread(NULL, 0, &StartThreadRoutine, &param, 0, NULL);
	this->setupPriority();
	if (hThread == NULL)
		this->setError("Thread.Start:CreateThread");
	else
		this->setStartedState();
}

void Thread::Pause()
{
	if (this->hThread == NULL)
		return;
	if (this->isRunning == TRUE && this->isPaused == FALSE)
	{
		if (SuspendThread(this->hThread) == -1)
			this->setError("Thread.Pause:SuspendThread");
		else
			this->isPaused = TRUE;
	}
}

void Thread::Resume()
{
	if (this->hThread == NULL)
		return;
	if (this->isRunning == TRUE && this->isPaused == TRUE)
	{
		if (ResumeThread(this->hThread) == -1)
			this->setError("Thread.Pause:SuspendThread");
		else
			this->isPaused = FALSE;
	}
}



VOID WINAPI WaitForThread(Thread &thread, DWORD time)
{
	WaitForSingleObject(thread.Handle(), time);
}

VOID WINAPI WaitForThreads(Thread **threads, DWORD numThreads, DWORD time)
{
	DWORD num = numThreads;
	for (DWORD i = 0; i < numThreads; i++)
	{
		if (threads[i]->IsRunning() == FALSE)
			--num;
	}
	if (num <= 0)
		return;
	HANDLE *lpThreads = new HANDLE[num];
	for (DWORD i = 0; i < num; i++)
	{
		if (threads[i]->IsRunning() == TRUE)
			lpThreads[i] = threads[i]->Handle();
	}
	WaitForMultipleObjects(num, lpThreads, TRUE, time);
	delete[] lpThreads;
}

Thread **AllocThreads(const int num)
{
	Thread **threads = new Thread*[num];
	for (int i = 0; i < num; i++)
		threads[i] = new Thread();
	return threads;
}

void DisposeThreads(Thread** threads, const int num)
{
	Thread **_threads = threads;
	for (int i = 0; i < num; i++)
		delete *_threads++;
	delete[] threads;
}
