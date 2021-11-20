#include <windows.h>
#include <stdio.h>
#include <ctype.h>
#include <locale.h>



int main()
{
	setlocale(LC_CTYPE,"Russian");

	HANDLE file = CreateFile("1.txt", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, 0); // создали новый дескриптор
	printf("дескриптор объекта FILE = %d\n", file);
	DWORD size = GetFileSize(file, NULL);// размер файла

	HANDLE fileMapping = CreateFileMapping(file, NULL, PAGE_READWRITE, 0, 0, "fileMapping"); //новый дескриптор файлового отображения
	printf("дескриптор объекта для отображения в пямяти = %d\n", fileMapping);

	LPVOID fileMapView = MapViewOfFile(fileMapping, FILE_MAP_WRITE, 0, 0, 0); //отображенная область памяти для дескриптора
	printf("адрес начала выденной памяти = %d\n", fileMapView);
	printf("\n");

	char *fileMemory = new char[size];
	CopyMemory(fileMemory, fileMapView, size); //копируем область памяти из файлового отображения в массив символов
	 printf("начальная информация в файле ");
	char *c = new char [size];
   // int a[5];
	//sort(a,a+5);

	for (int i = 0; i < size; i++)
	{
		c[i]=fileMemory[i];
		printf("%c", c[i]);
	}
	printf("\n");
	   printf("изменненая инфрмация записанная в файл ");
	   int dop;
	   for(int j=0; j<size; j++)
	   for(int i=0; i<size-1; i++)
	   {
		   if(c[i]<c[i+1])
		   {
			   dop=c[i];
			   c[i]=c[i+1];
			   c[i+1]=dop;
		   }
	   }
   for (int i = 0; i<size; i++)
	{
		fileMemory[i]=c[i];
		   printf("%c",fileMemory[i]);
	}
	//sort(c, c+size);
	CopyMemory(fileMapView, fileMemory, size);
	// освобождаем все активные дескрипторы и отображения
   UnmapViewOfFile(fileMapView);
   CloseHandle(fileMapping);
   CloseHandle(file);
printf("\n");

   return 0;
}
