#include <windows.h>
#include <stdio.h>
#include <ctype.h>


int main(int argc, char *argv[])
{
    // ������� ����� ���������� ����� "myfile.txt"
    HANDLE myFile = CreateFile("fCreateFile.txt", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, 0);
    printf("> File Handle = %d, LastError = %d", myFile, GetLastError());

    // �������� ������ ����� � ������
    DWORD myFileSize = GetFileSize(myFile, NULL);
    printf("\n> File Size = %d, LastError = %d", myFileSize, GetLastError());

    // �������� ����� ���������� ��������� ����������� ��� ������ ��������� ����������� myFile
    HANDLE myFileMapping = CreateFileMapping(myFile, NULL, PAGE_READWRITE, 0, 0, "myFileMapping");
    printf("\n> FileMapping Handle = %d, LastError = %d", myFileMapping, GetLastError());

    // �������� ������������ ������� ������ ��� ����������� ��������� ����������� myFileMapping
    LPVOID myFileMapView = MapViewOfFile(myFileMapping, FILE_MAP_WRITE, 0, 0, 0);
    printf("\n> ViewOfFile Pointer = %d, LastError = %d", myFileMapView, GetLastError());
    printf("\n");

    // �������� ������� ������ �� ��������� ����������� � ������ �������� myFileMemory,
    // �������� ������� �������� � �������� ������ �������
    printf("\n> ViewOfFile: char's register changing...");
    char *myFileMemory = new char[myFileSize];
    CopyMemory(myFileMemory, myFileMapView, myFileSize);
    FILE *f = fopen("CModuleTXT.txt", "w"); //��������� �������� ���������� ���� FILE.
    for (int i = 0; i < myFileSize; i++)
    {
        char c = myFileMemory[i];
        if (isupper(c))
           myFileMemory[i] = tolower(c);
        else if (islower(c))
           myFileMemory[i] = toupper(c);

    //-------------------SAVE-to_File----------------

    fprintf(f, "[File Handle] %d\n[File Size in Byte] %d\n[FileMapping Handle] %d\n[ViewOfFile Pointer] %d\n", myFile, myFileSize, myFileMapping, myFileMapView);

    //-----------------------------------------------
    }
    fclose(f); //��������� ����
    CopyMemory(myFileMapView, myFileMemory, myFileSize);
    printf(" DONE");
    printf("\n");

    // ����������� ��� �������� ����������� � �����������
    if (!UnmapViewOfFile(myFileMapView))
       printf("\n! Error while unmapping ViewOfFile!");
    else
       printf("\n> ViewOfFile was successfully unmapped.");

    if (!CloseHandle(myFileMapping))
       printf("\n! Error while closing FileMapping!");
    else
       printf("\n> FileMapping was successfully closed.");

    if (!CloseHandle(myFile))
       printf("\n! Error while closing file!");
    else
       printf("\n> File was successfully closed.");

    // ���� ������� �������...
    printf("\n\n");
    int stop;
    scanf("%d", &stop);
    system("PAUSE");
    return EXIT_SUCCESS;
}
