
#pragma once

#include "asMatrix.h"
#include "asWinAPI.h"

extern LPCSTR sServerListMutex;
extern LPCSTR sServerWorkComplete;
extern LPCSTR sServerWorkBegin;
extern LPCSTR sServerListMapping;
const DWORD dwMappingBufferSize = 262144;

class ClientBufferRecord
{
public:
	BOOL WorkComplete;					// работа завершена
	DWORD ProcessId;					// идентификатор процесса клиента
	int N;								// количество задач
	int *Results;						// результаты работы
	int *Matrixes;						// задачи: номера матриц в буфере матриц
	ClientBufferRecord(LPVOID &buffer, int n = 0);
	ClientBufferRecord(DWORD processId, int n = 0, int *matrixNum = NULL):
		WorkComplete(FALSE), Results(new int[n]), ProcessId(processId), N(n), Matrixes(matrixNum) { }
	ClientBufferRecord(int n = 0, int *matrixNum = NULL):
		WorkComplete(FALSE), Results(new int[n]), ProcessId(GetCurrentProcessId()), N(n), Matrixes(matrixNum) { }
	ClientBufferRecord(ClientBufferRecord &client);
	~ClientBufferRecord();
	LPVOID Write(LPVOID buffer, BOOL writeResults = TRUE, int n = 0);
	void AddMatrix(int matrix);
};

class ServerBufferRecord
{
public:
	BOOL WorkComplete;					// работа завершена
	BOOL CanChange;						// разрешено добавлять записи клиентов
	DWORD ProcessId;					// идентификатор процесса сервера
	int N;								// количество клиентов
	ClientBufferRecord **Clients;		// записи клиентов
	Matrix *M;							// исходная матрица
	DetMatrixes *D;						// матрицы для вычисления детерминанта
	ServerBufferRecord(LPVOID &buffer);
	ServerBufferRecord(Matrix *m, DetMatrixes *d, DWORD processId, int n = 0, ClientBufferRecord **clients = NULL):
		WorkComplete(FALSE), CanChange(TRUE), ProcessId(processId), N(n), Clients(clients), M(m), D(d) { }
	ServerBufferRecord(Matrix *m, DetMatrixes *d, int n = 0, ClientBufferRecord **clients = NULL):
		WorkComplete(FALSE), CanChange(TRUE), ProcessId(GetCurrentProcessId()), N(n), Clients(clients), M(m), D(d) { }
	~ServerBufferRecord();
	LPVOID Write(LPVOID buffer, ClientBufferRecord *resultingRecord = NULL);
	void AddClient(ClientBufferRecord *client);
	ClientBufferRecord *GetClient(DWORD processId);
	ClientBufferRecord *GetClient()
		{ return this->GetClient(GetCurrentProcessId()); }
	BOOL UpdateWorkComplete();
};

class ClientServerProcess		// процесс, играющий роль клиента или сервера
{
private:
	void doClientTask();
	int doServerTask();
	ServerBufferRecord *readFromServer();
	void writeToServer(ServerBufferRecord *server, ClientBufferRecord *resultingRecord = NULL);
public:
	BOOL IsServerMode;			// TRUE, если процесс является сервером, иначе клиентом
	HANDLE hServerBuffer;		// дескриптор для буфера памяти
	LPVOID lpServerBuffer;		// указатель на буфер памяти
	HANDLE hServerMutex;		// дескриптор мьютекса на доступ к буферу памяти
	HANDLE hWorkBegin;			// дескриптор события начала вычисления клиентов
	HANDLE hWorkComplete;		// дескриптор события окончания всех вычислений клиентов
	DWORD processId;			// идентификатор текущего процесса
	DWORD dwClientsNum;			// количество клиентов, выполняющих задание сервера (имеет смысл только после вызова Process при IsServerMode == TRUE)
	ClientServerProcess(Matrix *M = NULL, DetMatrixes *D = NULL,		// данные для инициализации сервера
						LPCSTR name = sServerListMapping,				// имя буфера памяти
						LPCSTR mutexName = sServerListMutex,			// имя мьютекса для досупа к буферу памяти
						LPCSTR workBeginName = sServerWorkBegin,		// имя события на начало работы клиентов
						LPCSTR workCompleteName = sServerWorkComplete,	// имя события на завершение работы клиентов
						DWORD bufferSize = dwMappingBufferSize);			// размер буфера
	~ClientServerProcess();		// закрытие всех открытых дескрипторов
	void SetProcessId(DWORD id)
		{ this->processId = id; }
	int Process();				// запуск сценария сервера или процесса
};

HANDLE CreateBuffer(LPVOID &buffer, LPCSTR name, DWORD bufferSize = dwMappingBufferSize);
HANDLE OpenBuffer(LPVOID &buffer, LPCSTR name);
VOID CloseBuffer(HANDLE hBuffer, LPVOID buffer);

BOOL SDetectClientServer(LPCSTR name = sServerListMapping);
