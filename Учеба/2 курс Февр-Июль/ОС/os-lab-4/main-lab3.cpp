#include <stdio.h>
#include <string.h>
#include <conio.h>
#include <windows.h>
#include <tlhelp32.h>

#define STRING_LENGTH 256

void PressKey();
void ShowParams(int argv, char **argc);
void ShowWork1(const char *name, const int bufferLength);
void ShowWork1Test(const char *filename);
void ShowWork2();
void ShowWork3();
void ShowProcesses();
void ShowThreads();
void ShowModules();
void Test(const char *filename);

const char *sExe1File = "OS Lab3.exe";
const char *sExe2File = "C:\\Windows\\System32\\kernel32.dll";
const char *sExe3File = "4194304";



int main(int argv, char **argc)
{
    ShowParams(argv, argc);
    if (argv < 2)
    {
       Test(argc[0]);
    }
    else
    {
       char *param1 = argc[1];
       if (*param1 != '/' && *param1 != '-')
       {
          printf("\nError in argument 1: %s", param1);
       }
       else
       {
          char param[STRING_LENGTH];
          strncpy(param, param1 + 1, STRING_LENGTH);
          strupr(param);
          if (!strcmp(param, "TEST"))
             Test(argc[0]);
          else if (!strcmp(param, "TASK1"))
          {
             if (argv < 3)
                ShowWork1Test(argc[0]);
             else
                ShowWork1(argc[2], STRING_LENGTH);
          }
          else if (!strcmp(param, "TASK2"))
             ShowWork2();
          else if (!strcmp(param, "TASK3"))
             ShowWork3();
          else if (!strcmp(param, "PROCESSES"))
             ShowProcesses();
          else if (!strcmp(param, "THREADS"))
             ShowThreads();
          else if (!strcmp(param, "MODULES"))
             ShowModules();
          else
             printf("\nInvalid command: %s\n", param);
       }
    }
    printf("\n");
    PressKey();
}


void PressKey()
{
     printf("Press any key...");
     while (kbhit()) getch();
     getch();
     while (kbhit()) getch();
}

void GetFileFullName(char *outFullName, const char *name, const int bufferLength)
{
     GetFullPathName(name, bufferLength, outFullName, NULL);
}

int GetFileName(char *outName, const char *fullName, const int bufferLength)
{
     char *name = strrchr(fullName, '\\');
     if (name == NULL)
     {
        strncpy(outName, fullName, bufferLength);
        return 0;
     }
     else
     {
        strncpy(outName, name + 1, bufferLength);
        return 1;
     }
}

int DoWork1(const char *name, char *shortName, char *longName,
    HMODULE *lpModule, const int bufferLength)
{
     char *endptr = NULL;
     unsigned long num = strtoul(name, &endptr, 0);
     if (*endptr == '\0')     // задан дескриптор
     {
        HMODULE hModule = (HMODULE)num;
        if (!GetModuleFileName(hModule, longName, bufferLength))
        {
           return 0;
        }
        GetFileName(shortName, longName, bufferLength);
        *lpModule = hModule;
        return 1;
     }
     else                    // задано что-то еще
     {
        char *buffer = new char[bufferLength];
        int result = GetFileName(buffer, name, bufferLength);
        if (result)          // задано полное имя файла
        {
           strncpy(longName, name, bufferLength);
           GetFileName(shortName, buffer, bufferLength);
        }
        else                 // задано короткое имя файла
        {
           strncpy(shortName, buffer, bufferLength);
           GetFileFullName(longName, buffer, bufferLength);
        }
        *lpModule = GetModuleHandle(longName);
        delete[] buffer;
        return 2;
     }
}

void ShowWork1(const char *name, const int bufferLength)
{     
    printf("\nArgument String = %s", name);
    char *shortName = new char[bufferLength];
    char *longName = new char[bufferLength];     
    HMODULE hModule;
    int result = DoWork1(name, shortName, longName, &hModule, bufferLength);
    if (!result)
    {
       printf("\nError in argument \"%s\"!", name);
    }
    else
    {
       printf("\nHandle = %d", hModule);
       printf("\nShort name = %s", shortName);
       printf("\nFull name = %s", longName);
    }
    delete[] longName;
    delete[] shortName;
    printf("\n");
}

void ShowWork1Test(const char *filename)
{
    printf("\n\n*** TASK #1 ***\n");
    const int bufferLength = STRING_LENGTH;
    ShowWork1(filename, bufferLength);
    ShowWork1(sExe1File, bufferLength);
    ShowWork1(sExe2File, bufferLength);
    ShowWork1(sExe3File, bufferLength);
}

void ShowWork2()
{
     printf("\n\n*** TASK #2 ***\n");
     DWORD dCurrentId = GetCurrentProcessId();
     HANDLE hCurrentPseudo = GetCurrentProcess();
     HANDLE hCurrentIdDup;
     DuplicateHandle(hCurrentPseudo, hCurrentPseudo, hCurrentPseudo,
        &hCurrentIdDup, 0, FALSE, DUPLICATE_SAME_ACCESS);        
     HANDLE hCurrentIdOpen = OpenProcess(PROCESS_DUP_HANDLE, TRUE, dCurrentId);
     BOOL fClosedDup = CloseHandle(hCurrentIdDup);
     BOOL fClosedOpen = CloseHandle(hCurrentIdOpen);
     printf("\nCurrent ID = %d", dCurrentId);
     printf("\nCurrent PseudoID = %d", hCurrentPseudo);
     printf("\nCurrent ID Duplicate = %d", hCurrentIdDup);
     printf("\nCurrent ID Opened = %d", hCurrentIdOpen);
     printf("\nDuplicate ID Closing: %d", fClosedDup);
     printf("\nOpened ID Closing: %d", fClosedOpen);
     printf("\n");
}

void ShowProcessEntry(PROCESSENTRY32 &entry)
{
     printf("\n\nth32ProcessID = %d", entry.th32ProcessID);
     printf("\nth32DefaultHeapID = %d", entry.th32DefaultHeapID);
     printf("\nth32ModuleID = %d", entry.th32ModuleID);
     printf("\nth32ParentProcessID = %d", entry.th32ParentProcessID);
     printf("\ncntUsage = %d", entry.cntUsage);
     printf("\ncntThreads = %d", entry.cntThreads);
     printf("\npcPriClassBase = %d", entry.pcPriClassBase);
     printf("\ndwFlags = %d", entry.dwFlags);
     printf("\nszExeFile = %s", entry.szExeFile);
}

void ShowThreadEntry(THREADENTRY32 &entry)
{
     printf("\n\nth32ThreadID = %d", entry.th32ThreadID);
     printf("\nth32OwnerProcessID = %d", entry.th32OwnerProcessID);
     printf("\ncntUsage = %d", entry.cntUsage);
     printf("\ntpBasePri = %d", entry.tpBasePri);
     printf("\ntpDeltaPri = %d", entry.tpDeltaPri);
     printf("\ndwFlags = %d", entry.dwFlags);
}

void ShowModuleEntry(MODULEENTRY32 &entry)
{
     printf("\n\nth32ModuleID = %d", entry.th32ModuleID);
     printf("\nth32ProcessID = %d", entry.th32ProcessID);
     printf("\nGlblcntUsage = %d", entry.GlblcntUsage);
     printf("\nProccntUsage = %d", entry.ProccntUsage);
     printf("\nmodBaseAddr = %p", entry.modBaseAddr);
     printf("\nmodBaseSize = %d", entry.modBaseSize);
     printf("\nhModule = %d", entry.hModule);
     printf("\nszModule = %s", entry.szModule);
     printf("\nszExePath = %s", entry.szExePath);
}

void ShowProcesses()
{
     printf("\n\n*** PROCESSES ***\n");
     HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
     printf("\nSnapshot ID = %d", hSnapshot);
     PROCESSENTRY32 entry;
     BOOL fRepeat = Process32First(hSnapshot, &entry);
     while (fRepeat)
     {
        ShowProcessEntry(entry);
        fRepeat = Process32Next(hSnapshot, &entry);
     }
     CloseHandle(hSnapshot);
     printf("\n\n*** END OF PROCESSES ***\n\n");
}

void ShowThreads()
{
     printf("\n\n*** THREADS ***\n");
     HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
     printf("\nSnapshot ID = %d", hSnapshot);
     THREADENTRY32 entry;
     BOOL fRepeat = Thread32First(hSnapshot, &entry);
     while (fRepeat)
     {
        ShowThreadEntry(entry);
        fRepeat = Thread32Next(hSnapshot, &entry);
     }
     CloseHandle(hSnapshot);
     printf("\n\n*** END OF THREADS ***\n\n");
}

void ShowModules()
{
     printf("\n\n*** MODULES ***\n");
     HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, 0);
     printf("\nSnapshot ID = %d", hSnapshot);
     MODULEENTRY32 entry;
     BOOL fRepeat = Module32First(hSnapshot, &entry);
     while (fRepeat)
     {
        ShowModuleEntry(entry);
        fRepeat = Module32Next(hSnapshot, &entry);
     }
     CloseHandle(hSnapshot);
     printf("\n\n*** END OF MODULES ***\n\n");
}

void ShowWork3()
{
     ShowProcesses();
     PressKey();
     ShowThreads();
     PressKey();
     ShowModules();
}

void ShowParams(int argv, char **argc)
{
    for (int i = 0; i < argv; i++)
        printf("\nParam #%d: %s", i, argc[i]);
    printf("\n");
}

void Test(const char *filename)
{
    ShowWork1Test(filename);
    printf("\n");
    PressKey();
    ShowWork2();
    printf("\n");
    PressKey();
    ShowWork3();
}
