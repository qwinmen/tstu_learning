#include <windows.h>
#include <stdio.h>
#include <ctype.h>


int main(int argc, char *argv[])
{
    // создаем новый дескриптор файла "myfile.txt"
    HANDLE myFile = CreateFile("fCreateFile.txt", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, 0);
    printf("> File Handle = %d, LastError = %d", myFile, GetLastError());

    // получаем размер файла в байтах
    DWORD myFileSize = GetFileSize(myFile, NULL);
    printf("\n> File Size = %d, LastError = %d", myFileSize, GetLastError());

    // получаем новый дескриптор файлового отображени€ дл€ нашего файлового дескриптора myFile
    HANDLE myFileMapping = CreateFileMapping(myFile, NULL, PAGE_READWRITE, 0, 0, "myFileMapping");
    printf("\n> FileMapping Handle = %d, LastError = %d", myFileMapping, GetLastError());

    // получаем отображенную область пам€ти дл€ дескриптора файлового отображени€ myFileMapping
    LPVOID myFileMapView = MapViewOfFile(myFileMapping, FILE_MAP_WRITE, 0, 0, 0);
    printf("\n> ViewOfFile Pointer = %d, LastError = %d", myFileMapView, GetLastError());
    printf("\n");

    // копируем область пам€ти из файлового отображени€ в массив символов myFileMemory,
    // измен€ем регистр символов и копируем пам€ть обратно
    printf("\n> ViewOfFile: char's register changing...");
    char *myFileMemory = new char[myFileSize];
    CopyMemory(myFileMemory, myFileMapView, myFileSize);
    FILE *f = fopen("CModuleTXT.txt", "w"); //объ€вл€ем файловую переменную типа FILE.
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
    fclose(f); //закрываем файл
    CopyMemory(myFileMapView, myFileMemory, myFileSize);
    printf(" DONE");
    printf("\n");

    // освобождаем все активные дескрипторы и отображени€
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

    // ждем нажати€ клавиши...
    printf("\n\n");
    int stop;
    scanf("%d", &stop);
    system("PAUSE");
    return EXIT_SUCCESS;
}
