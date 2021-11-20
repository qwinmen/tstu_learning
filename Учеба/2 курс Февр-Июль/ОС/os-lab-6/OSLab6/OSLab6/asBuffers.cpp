
#include "stdafx.h"
#include "asBuffers.h"


LPCSTR sServerListMutex = "Global\\OSLab6ServerListMutex";
LPCSTR sServerWorkComplete = "Global\\OSLab6ServerWorkComplete";
LPCSTR sServerWorkBegin = "Global\\OSLab6ServerWorkBegin";
LPCSTR sServerListMapping = "Global\\OSLab6ServerListObject";

ClientBufferRecord::ClientBufferRecord(LPVOID &buffer, int n)
{
	DWORD *_nBuffer = (DWORD*)buffer;
	for (int i = 0; i <= n; i++)
	{
		this->WorkComplete = *_nBuffer++;
		this->ProcessId = *_nBuffer++;
		this->N = *_nBuffer++;
		if (i == n)
		{
			this->Results = new int[this->N];
			this->Matrixes = new int[this->N];
			for (int j = 0; j < this->N; j++)
			{
				this->Results[j] = *_nBuffer++;
				this->Matrixes[j] = *_nBuffer++;
			}
		}
		else
		{
			_nBuffer += this->N;
		}
	}
	buffer = _nBuffer;
}

LPVOID ClientBufferRecord::Write(LPVOID buffer, BOOL writeResults, int n)
{
	DWORD *_nBuffer = (DWORD*)buffer;
	for (int i = 0; i < n; i++)
	{
		_nBuffer += 3;
		int N = *_nBuffer++;
		_nBuffer += N * 2;
	}
	if (writeResults == FALSE)
	{
		_nBuffer += 3;
		_nBuffer += this->N;
	}
	else
	{
		*_nBuffer++ = this->WorkComplete;
		*_nBuffer++ = this->ProcessId;
		*_nBuffer++ = this->N;
		for (int i = 0; i < this->N; i++)
		{
			if (this->Results != NULL)
			{
				*_nBuffer++ = this->Results[i];
			}
			else
			{
				*_nBuffer = 0;
			}
			if (this->Matrixes != NULL)
			{
				*_nBuffer++ = this->Matrixes[i];
			}
		}
	}
	return _nBuffer;
}

void ClientBufferRecord::AddMatrix(int matrix)
{
	if (this->Matrixes == NULL)
	{
		this->Matrixes = new int[1];
		this->Matrixes[0] = matrix;
		this->N = 1;
	}
	else
	{
		int *matrixes = new int[this->N + 1];
		for (int i = 0; i < this->N; i++)
		{
			matrixes[i] = this->Matrixes[i];
		}
		matrixes[this->N] = matrix;
		delete[] this->Matrixes;
		this->Matrixes = matrixes;
		this->N++;
	}
}

ClientBufferRecord::ClientBufferRecord(ClientBufferRecord &client)
{
	this->WorkComplete = client.WorkComplete;
	this->ProcessId = client.ProcessId;
	this->N = client.N;
	this->Results = new int[this->N];
	this->Matrixes = new int[this->N];
	for (int i = 0; i < this->N; i++)
	{
		this->Results[i] = client.Results[i];
		this->Matrixes[i] = client.Matrixes[i];
	}
}

ClientBufferRecord::~ClientBufferRecord()
{
	if (this->Results != NULL)
	{
		delete[] this->Results;
	}
	if (this->Matrixes != NULL)
	{
		delete[] this->Matrixes;
	}
}

ServerBufferRecord::ServerBufferRecord(LPVOID &buffer)
{
	DWORD *_nBuffer = (DWORD*)buffer;
	this->WorkComplete = *_nBuffer++;
	this->CanChange = *_nBuffer++;
	this->ProcessId = *_nBuffer++;
	this->N = *_nBuffer++;
	this->Clients = new ClientBufferRecord*[this->N];
	for (int i = 0; i < this->N; i++)
	{
		LPVOID lpBuffer = _nBuffer;
		this->Clients[i] = new ClientBufferRecord(lpBuffer);
		_nBuffer = (DWORD*)lpBuffer;
	}
	LPVOID lpBuffer = _nBuffer;
	this->M = ReadMatrix(lpBuffer);
	this->D = new DetMatrixes(lpBuffer);
	_nBuffer = (DWORD*)lpBuffer;
	buffer = _nBuffer;
}

ServerBufferRecord::~ServerBufferRecord()
{
	if (this->Clients == NULL)
		return;
	for (int i = 0; i < this->N; i++)
		delete this->Clients[i];
	delete[] this->Clients;
	delete this->M;
	delete this->D;
}

LPVOID ServerBufferRecord::Write(LPVOID buffer, ClientBufferRecord *resultingRecord)
{
	BOOL writeResults = (resultingRecord == NULL);
	DWORD *_nBuffer = (DWORD*)buffer;
	*_nBuffer++ = this->WorkComplete;
	*_nBuffer++ = this->CanChange;
	*_nBuffer++ = this->ProcessId;
	*_nBuffer++ = this->N;
	for (int i = 0; i < this->N; i++)
	{
		ClientBufferRecord *client = this->Clients[i];
		if (client == resultingRecord)
		{
			_nBuffer = (DWORD*)client->Write((LPVOID)_nBuffer);
		}
		else
		{
			_nBuffer = (DWORD*)client->Write((LPVOID)_nBuffer, writeResults);
		}
	}
	_nBuffer = (DWORD*)this->M->Write((LPVOID)_nBuffer);
	_nBuffer = (DWORD*)this->D->Write((LPVOID)_nBuffer);
	return _nBuffer;
}

void ServerBufferRecord::AddClient(ClientBufferRecord *client)
{
	if (this->CanChange == FALSE)
		return;
	if (this->Clients == NULL)
	{
		this->N = 1;
		this->Clients = new ClientBufferRecord*[this->N];
		this->Clients[0] = client;
	}
	else
	{
		ClientBufferRecord **clients = new ClientBufferRecord*[this->N + 1];
		for (int i = 0; i < this->N; i++)
		{
			clients[i] = this->Clients[i];
		}
		clients[this->N] = client;
		delete[] this->Clients;
		this->Clients = clients;
		this->N++;
	}
}

ClientBufferRecord *ServerBufferRecord::GetClient(DWORD processId)
{
	for (int i = 0; i < this->N; i++)
	{
		if (this->Clients[i]->ProcessId == processId)
		{
			return this->Clients[i];
		}
	}
	return NULL;
}

BOOL ServerBufferRecord::UpdateWorkComplete()
{
	for (int i = 0; i < this->N; i++)
	{
		if (this->Clients[i]->WorkComplete == FALSE)
		{
			this->WorkComplete = FALSE;
			return FALSE;
		}
	}
	this->WorkComplete = TRUE;
	return TRUE;
}


ClientServerProcess::ClientServerProcess(Matrix *M, DetMatrixes *D,
										 LPCSTR name, LPCSTR mutexName,
										 LPCSTR workBeginName, LPCSTR workCompleteName,
										 DWORD bufferSize): dwClientsNum(0)
{
	this->processId = GetCurrentProcessId();
 	this->hServerBuffer = OpenBuffer(this->lpServerBuffer, name);
	if (this->hServerBuffer == NULL)
	{	// режим сервера
		this->hServerBuffer = CreateBuffer(this->lpServerBuffer, name, bufferSize);
		if (this->hServerBuffer == NULL)
		{
			SetGlobalError("ClientServerProcess.Init:CreateBuffer");
			return;
		}
		this->hServerMutex = SCreateMutex(mutexName, TRUE);
		this->hWorkBegin = SCreateEvent(workBeginName);
		this->hWorkComplete = SCreateEvent(workCompleteName);
		ServerBufferRecord *server = new ServerBufferRecord(M, D);
		server->Write(this->lpServerBuffer);
		delete server;
		SReleaseMutex(this->hServerMutex);
		this->IsServerMode = TRUE;
	}
	else
	{	// режим клиента
		// this->hServerBuffer и this->lpServerBuffer уже заполнены
		this->hServerMutex = SOpenMutex(mutexName);
		this->hWorkBegin = SOpenEvent(workBeginName);
		this->hWorkComplete = SOpenEvent(workCompleteName);
		SSWaitForSingleObject(this->hServerMutex);
		LPVOID _lpServerBuffer = this->lpServerBuffer;
		ServerBufferRecord *server = new ServerBufferRecord(_lpServerBuffer);
		if (server->CanChange == FALSE)
		{
			SReleaseMutex(this->hServerMutex);
			delete server;
			SetGlobalError("ClientServerProcess.Init(Cannot change server configuration)");
		}
		else
		{
			server->AddClient(new ClientBufferRecord());
			server->Write(this->lpServerBuffer);
			SReleaseMutex(this->hServerMutex);
			delete server;
		}
		this->IsServerMode = FALSE;
	}
}

ClientServerProcess::~ClientServerProcess()
{
	const DWORD dwTimeoutInterval = 1000;
	//SSWaitForSingleObject(hServerMutex, dwTimeoutInterval);
	//SReleaseMutex(hServerMutex);
	SCloseHandle(hServerMutex);
	CloseBuffer(this->hServerBuffer, this->lpServerBuffer);
	//SSWaitForSingleObject(hWorkBegin, dwTimeoutInterval);
	SCloseHandle(hWorkBegin);
	//SSWaitForSingleObject(hWorkComplete, dwTimeoutInterval);
	SCloseHandle(hWorkComplete);
}

ServerBufferRecord *ClientServerProcess::readFromServer()
{
	// читаем данные из сервера
	SSWaitForSingleObject(this->hServerMutex);
	LPVOID _lpServerBuffer = this->lpServerBuffer;
	ServerBufferRecord *server = new ServerBufferRecord(_lpServerBuffer);
	SReleaseMutex(this->hServerMutex);
	return server;
}

void ClientServerProcess::writeToServer(ServerBufferRecord *server, ClientBufferRecord *resultingRecord)
{
	SSWaitForSingleObject(this->hServerMutex);
	if (resultingRecord != NULL)
	{
		LPVOID _lpServerBuffer = this->lpServerBuffer;
		ServerBufferRecord *otherServer = new ServerBufferRecord(_lpServerBuffer);
		// обновляем записи, которые могли быть заменены другими потоками до наложения мьютекса
		for (int i = 0; i < server->N; i++)
		{
			ClientBufferRecord *client = server->Clients[i];
			if (client != resultingRecord)
			{
				server->Clients[i] = new ClientBufferRecord(*otherServer->Clients[i]);
				delete client;
			}
		}
		delete otherServer;
	}
	server->UpdateWorkComplete();
	server->Write(this->lpServerBuffer);
	SReleaseMutex(this->hServerMutex);
}

void ClientServerProcess::doClientTask()
{
	// ждем команды от сервера на начало вычислений
	SSWaitForSingleObject(this->hWorkBegin);
	// читаем данные из сервера
	ServerBufferRecord *server = this->readFromServer();
	// вычисляем детерминант
	ClientBufferRecord *client = server->GetClient();
	if (client == NULL)
	{
		delete server;
		SetGlobalError("ClientServerProcess.Process:Client(Cannot find client in working server)");
	}
	else
	{
		for (int i = 0; i < client->N; i++)
		{
			int nMatrix = client->Matrixes[i];
			Matrix *matrix = server->D->M[nMatrix];
			int det = matrix->EvalDet();
			client->Results[i] = det;
		}
		client->WorkComplete = TRUE;
	}
	// записываем измененные данные на сервер
	this->writeToServer(server, client);
	BOOL isWorkComplete = server->WorkComplete;
	delete server; // клиент удаляется автоматически
	// если все клиенты выполнили расчеты - вызываем событие SSetEvent
	if (isWorkComplete == TRUE)
	{
		SSetEvent(this->hWorkComplete);
	}
}

int ClientServerProcess::doServerTask()
{
	// запрещаем добавление новых клиентов
	ServerBufferRecord *server = this->readFromServer();
	server->CanChange = FALSE;
	this->writeToServer(server);
	// распределяем задания между клиентами
	int numClients = server->N;
	this->dwClientsNum = numClients;
	if (numClients == 0)
	{
		SSetEvent(this->hWorkBegin);
		int det = EvalMatrixDet(server->D);
		delete server;
		SSetEvent(this->hWorkComplete);
		return det;
	}
	else
	{
		int numTasks = server->D->N;
		for (int iTask = 0, iClient = 0; iTask < numTasks; iTask++, iClient++)
		{
			if (iClient >= numClients)
			{
				iClient = 0;
			}
			server->Clients[iClient]->AddMatrix(iTask);
		}
		// сохраняем задания и оповещаем клиентов, что работа началась
		this->writeToServer(server);
		delete server;
		SSetEvent(this->hWorkBegin);
		// ждем, пока клиенты завершат работу
		SSWaitForSingleObject(this->hWorkComplete);
		// читаем результаты работы клиентов
		server = this->readFromServer();
		// вычисляем детерминант
		int *dets = new int[numTasks];
		for (int iClient = 0; iClient < numClients; iClient++)
		{
			ClientBufferRecord *client = server->Clients[iClient];
			for (int i = 0; i < client->N; i++)
			{
				dets[client->Matrixes[i]] = client->Results[i];
			}
		}
		int det = 0;
		for (int i = 0; i < numTasks; i++)
		{
			det += server->D->K[i] * dets[i];
		}
		delete server;
		return det;
	}
}

int ClientServerProcess::Process()
{
	if (this->IsServerMode == TRUE)
	{
		return this->doServerTask();
	}
	else
	{
		this->doClientTask();
		return 0;
	}
}

HANDLE CreateBuffer(LPVOID &buffer, LPCSTR name, DWORD bufferSize)
{
	HANDLE hMapFile = CreateFileMappingA(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, bufferSize, name);
	int error = GetLastError();
	if (hMapFile == NULL)
		return NULL;
	buffer = MapViewOfFile(hMapFile, FILE_MAP_ALL_ACCESS, 0, 0, 0);
	if (buffer == NULL)
	{
		SCloseHandle(hMapFile);
		return NULL;
	}
	return hMapFile;
}

HANDLE OpenBuffer(LPVOID &buffer, LPCSTR name)
{
	HANDLE hMapFile = OpenFileMappingA(FILE_MAP_ALL_ACCESS, FALSE, name);
	if (hMapFile == NULL)
		return NULL;
	buffer = MapViewOfFile(hMapFile, FILE_MAP_ALL_ACCESS, 0, 0, 0);
	if (buffer == NULL)
	{
		SCloseHandle(hMapFile);
		return NULL;
	}
	return hMapFile;
}

VOID CloseBuffer(HANDLE hBuffer, LPVOID buffer)
{
	UnmapViewOfFile(buffer);
	SCloseHandle(hBuffer);
}

BOOL SDetectClientServer(LPCSTR name)
{
	LPVOID lpServerBuffer;
	HANDLE hServerBuffer = OpenBuffer(lpServerBuffer, name);
	if (hServerBuffer == NULL)
	{
		return TRUE;
	}
	else
	{
		CloseBuffer(hServerBuffer, lpServerBuffer);
		return FALSE;
	}
}
