#include <iostream>
#include <string.h>
#include <conio.h>
#include <math.h>

using namespace std;
struct List
{
       float data;
       List *link;
};

List *GetList(float item, List *nextPtr = NULL) 
{
	List *k;
	//выделение памяти при передаче item и NextPtr конструктору
	
	k = new List; 
	if (k == NULL)
	{
		cerr << "Ошибка выделения памяти!" << endl;
		exit(1); // завершение программы, если выделение памяти неудачно
	}
	k->data = item;
	k->link = nextPtr;
	return k;
}

void Filling(List* &head, float item);
void PrintList(List *head);
void ClearList(List * &head);
void Delete(List* & head, float key);
void InsertOrder(List * & head, float item);
void SaveList(List *head);
float FindElem(List *head, int el);
void ReplaceElem(List *head, int index, float elem);
int Filling_from_file(List* & head);

void main()
{
	int t,key;
	unsigned n,i;
	float a,fnd_elem;
	List *k, *head;
	setlocale(LC_ALL, "");
	k=new List;
	head=new List;
	k->link=NULL;
	head->link=NULL;
	ClearList(head);
	while(1)
	{
		cout<<"Меню:\n1-Заполнение списка\n2-Удаление элемента\n3-Замена элемента\n4-Очистка\n5-Поиск элемента\n6-Сортировка\n7-Вывод списка на экран\n8-Запись в файл\n9-Заполнение из файла\n10-Решение задания по варианту №4\n0-Выход\n";
		cin>>t;
		switch(t)
		{
		case 0:
			return;
			break;
		case 1:
			cout<<"Введите n: "<<endl;
			cin>>n;
			for(i=0;i<(2*n);i++)
			{
				cout<<"Введите a["<<i+1<<"]: "<<endl;
				cin>>a;
				Filling(head,a);
			}
			break;
		case 2:
			cout<<"Введите ключ: "<<endl;
			cin>>fnd_elem;
			Delete(head, fnd_elem);
			break;
		case 3:
			cout<<"Введите порядковый номер элемента для замены: "<<endl;
			cin>>key;
			cout<<"Введите значение элемента для замены: "<<endl;
			cin>>fnd_elem;
			if(key>2*n)
				cout<<"Неверный номер"<<endl;
			else
				ReplaceElem(head, key, fnd_elem);
			break;
		case 4:
			ClearList(head);
			cout<<"\nОчистка выполнена\n"<<endl;
			break;
		case 5:
			cout<<"Введите порядковый номер элемента для поиска: ";
			cin>>key;
			if(key>2*n)
				cout<<"Неверный номер"<<endl;
			else
				cout<<FindElem(head,key)<<endl;
			break;
		case 6:
			//для сортировки
			break;
		case 7:
			cout<<"\nЭлементы списка: \n"<<endl;
			PrintList(head);
			break;
		case 8:
			cout<<"\nСохранено в файл\n"<<endl;
			SaveList(head);
			break;
		case 9:
			ClearList(head);
			n=Filling_from_file(head);
			cout<<"\nЗаполнено, n= \n"<<n<<endl;
			break;
		case 10:
			float *matr,b;
			matr = new float [2*n-1];
			for(i=1;i<=(2*n-1);i++)
			{	
				a=FindElem(head,i);
				b=FindElem(head,fabs((float)(2*n-2*(i-1))));
				matr[i-1]=a-b;
			}
			ClearList(head);
			for(i=0;i<(2*n-1);i++)
				Filling(head,matr[i]);
			delete matr;
		}
	}
}
	
void Filling(List* & head, float item)
{
	List *k, *currPtr = head;
	// если список пуст, вставить item в начало
	if (currPtr == NULL)
		head = GetList(item,head); 
	else 
	{ 
		// найти узел с нулевым указателем
		while(currPtr->link != NULL)
			currPtr = currPtr->link;
		// создать узел и вставить в конец списка
		// (после currPtr)
		k = GetList(item);
		k->link = currPtr->link;
		currPtr->link = k;
	} 
}
// печать связанного списка
void PrintList(List *head)
{
	// currPtr пробегает по списку, начиная с головы
	List *currPtr = head;
	// пока не конец списка, печатать значение данных 
	// текущего узла 
	while(currPtr != NULL)
	{
		cout << currPtr->data << endl;
		// перейти к следующему узлу 
		currPtr = currPtr->link; 
	}
}

float FindElem(List *head, int el)
{
	int i=0;
	// currPtr пробегает по списку, начиная с головы
	List *currPtr = head;
	// пока не конец списка, печатать значение данных 
	// текущего узла 
	while (currPtr != NULL)
	{
		i++;
		if (i==el) 
		{
			return currPtr->data;
		}
		
		currPtr = currPtr->link; //переход к следующему
	}


}

// сохранение в файл связанного списка
void SaveList(List *head)
{	
	FILE *a;
	a=fopen("out.txt", "wt");
	// currPtr пробегает по списку, начиная с головы
	List *currPtr = head;
	// пока не конец списка, печатать значение данных 
	// текущего узла 
	while(currPtr != NULL)
	{
		fprintf(a,"%lf\n",currPtr->data);
		// перейти к следующему узлу 
		currPtr = currPtr->link; 
	}
	fclose(a);
}

// удаление всех узлов в связанном списке
void ClearList(List * &head)
{
	List *currPtr, *nextPtr;
	currPtr = head;
	while(currPtr != NULL)
	{
		// записать адрес следующего узла
		nextPtr = currPtr->link;
		// удалить текущий узел
		delete currPtr;
		currPtr = nextPtr;
	}
	// пометить как пустой
	head = NULL;
}

// удаление первого элемента, совпадающего с ключом
void Delete(List* & head, float key)
{
	List  *currPtr = head, *prevPtr = NULL;
	// завершить функцию, если список пустой
	if (currPtr == NULL) 
		return;
	// прохождение до совпадения с ключей или до конца
	while (currPtr != NULL && currPtr->data != key)
	{
		prevPtr = currPtr;
		currPtr = currPtr->link;
	}
	// если currPtr не равно NULL, ключ в currPtr
	if (currPtr != NULL)
	{
		// prevPtr == NULL означает совпадение в начале списка
		if(prevPtr == NULL)
			head = head->link;
		else
			// совпадение во втором или последующем узле
			// отсоединение этого узла
			prevPtr->link = currPtr->link;
		// удаление узла
		delete currPtr;
	}
}

// вставить item в упорядоченный список
void InsertOrder(List * & head, float item)
{
	// currPtr пробегает по списку
	List  *currPtr, *prevPtr, *newList;
	// prevPtr == NULL указывает на совпадение в начале списка
	prevPtr = NULL; currPtr = head;
	// цикл по списку и поиск точки вставки
	while (currPtr != NULL)
	{
		// точка вставки найдена, если item < текущего data 
		if (item < currPtr->data) 
			break;
		prevPtr = currPtr; 
		currPtr = currPtr->link;
	}
	// вставка
	if (prevPtr == NULL) 
	// если prevPtr == NULL, вставлять в начало
		Filling(head,item); 
	else 
	{
	// вставить новый узел после предыдущего
		newList = GetList(item); 
		newList->link = prevPtr->link;
		prevPtr->link = newList;
	}
}

void ReplaceElem(List *head, int index, float elem) //index - номер заменяемого элемента (с 1), elem -то, на что заменяем
{
	int i=0;
	// currPtr пробегает по списку, начиная с головы
	List *currPtr = head;
	// пока не конец списка, печатать значение данных 
	// текущего узла 
	while (currPtr != NULL)
	{
		i++;
		if (i==index) 
		{
			currPtr->data=elem;
		}
		
		currPtr = currPtr->link; //переход к следующему
	}
}

int Filling_from_file(List* & head) //заполнение из файла
{
	int n=0;
	FILE *a;
	float m;
	char str[1000], *p;
	a=fopen("in.txt", "rt");
	fgets(str,1000,a);
	p = strtok(str, " ");
	m=atof(p);
	Filling(head, m);
	n++;

	 do
	 {
      p = strtok('\0', " ");
	  if(p) 
	  {
		  m=atof(p);
		  Filling(head, m);
		  n++;
	  }
	 } while(p);
	fclose(a);
	return n;
}