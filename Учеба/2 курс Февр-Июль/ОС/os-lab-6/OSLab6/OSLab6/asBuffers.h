
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
	BOOL WorkComplete;					// ������ ���������
	DWORD ProcessId;					// ������������� �������� �������
	int N;								// ���������� �����
	int *Results;						// ���������� ������
	int *Matrixes;						// ������: ������ ������ � ������ ������
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
	BOOL WorkComplete;					// ������ ���������
	BOOL CanChange;						// ��������� ��������� ������ ��������
	DWORD ProcessId;					// ������������� �������� �������
	int N;								// ���������� ��������
	ClientBufferRecord **Clients;		// ������ ��������
	Matrix *M;							// �������� �������
	DetMatrixes *D;						// ������� ��� ���������� ������������
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

class ClientServerProcess		// �������, �������� ���� ������� ��� �������
{
private:
	void doClientTask();
	int doServerTask();
	ServerBufferRecord *readFromServer();
	void writeToServer(ServerBufferRecord *server, ClientBufferRecord *resultingRecord = NULL);
public:
	BOOL IsServerMode;			// TRUE, ���� ������� �������� ��������, ����� ��������
	HANDLE hServerBuffer;		// ���������� ��� ������ ������
	LPVOID lpServerBuffer;		// ��������� �� ����� ������
	HANDLE hServerMutex;		// ���������� �������� �� ������ � ������ ������
	HANDLE hWorkBegin;			// ���������� ������� ������ ���������� ��������
	HANDLE hWorkComplete;		// ���������� ������� ��������� ���� ���������� ��������
	DWORD processId;			// ������������� �������� ��������
	DWORD dwClientsNum;			// ���������� ��������, ����������� ������� ������� (����� ����� ������ ����� ������ Process ��� IsServerMode == TRUE)
	ClientServerProcess(Matrix *M = NULL, DetMatrixes *D = NULL,		// ������ ��� ������������� �������
						LPCSTR name = sServerListMapping,				// ��� ������ ������
						LPCSTR mutexName = sServerListMutex,			// ��� �������� ��� ������ � ������ ������
						LPCSTR workBeginName = sServerWorkBegin,		// ��� ������� �� ������ ������ ��������
						LPCSTR workCompleteName = sServerWorkComplete,	// ��� ������� �� ���������� ������ ��������
						DWORD bufferSize = dwMappingBufferSize);			// ������ ������
	~ClientServerProcess();		// �������� ���� �������� ������������
	void SetProcessId(DWORD id)
		{ this->processId = id; }
	int Process();				// ������ �������� ������� ��� ��������
};

HANDLE CreateBuffer(LPVOID &buffer, LPCSTR name, DWORD bufferSize = dwMappingBufferSize);
HANDLE OpenBuffer(LPVOID &buffer, LPCSTR name);
VOID CloseBuffer(HANDLE hBuffer, LPVOID buffer);

BOOL SDetectClientServer(LPCSTR name = sServerListMapping);
