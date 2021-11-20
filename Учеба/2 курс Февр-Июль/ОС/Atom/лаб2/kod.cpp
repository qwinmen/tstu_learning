#include <windows.h>
#include <stdio.h>
#include <ctype.h>
#include <locale.h>



int main()
{
	setlocale(LC_CTYPE,"Russian");

	HANDLE file = CreateFile("1.txt", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, 0); // ������� ����� ����������
	printf("���������� ������� FILE = %d\n", file);
	DWORD size = GetFileSize(file, NULL);// ������ �����

	HANDLE fileMapping = CreateFileMapping(file, NULL, PAGE_READWRITE, 0, 0, "fileMapping"); //����� ���������� ��������� �����������
	printf("���������� ������� ��� ����������� � ������ = %d\n", fileMapping);

	LPVOID fileMapView = MapViewOfFile(fileMapping, FILE_MAP_WRITE, 0, 0, 0); //������������ ������� ������ ��� �����������
	printf("����� ������ �������� ������ = %d\n", fileMapView);
	printf("\n");

	char *fileMemory = new char[size];
	CopyMemory(fileMemory, fileMapView, size); //�������� ������� ������ �� ��������� ����������� � ������ ��������
	 printf("��������� ���������� � ����� ");
	char *c = new char [size];
   // int a[5];
	//sort(a,a+5);

	for (int i = 0; i < size; i++)
	{
		c[i]=fileMemory[i];
		printf("%c", c[i]);
	}
	printf("\n");
	   printf("���������� ��������� ���������� � ���� ");
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
	// ����������� ��� �������� ����������� � �����������
   UnmapViewOfFile(fileMapView);
   CloseHandle(fileMapping);
   CloseHandle(file);
printf("\n");

   return 0;
}
