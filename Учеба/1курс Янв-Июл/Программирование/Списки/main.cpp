#include <iostream> //библиотека потокового ввода-вывода
#include <string.h> //библиотека для работы со строками
//#include <conio.h>
#include <math.h> //библиотека математических констант и функций
#include <float.h> //для flt_max и flt_min

using namespace std; //подключаем пространство имен std
struct List //объявление главной структуры
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

/*
*	Предопределение функций
*/

void Filling(List* &head, float item);
void PrintList(List *head);
void ClearList(List * &head);
void Delete(List* & head, float key);
void InsertOrder(List * & head, float item);
void SaveList(List *head);
float FindElem(List *head, int el);
void ReplaceElem(List *head, int index, float elem);
int Filling_from_file(List* & head);

int main() // главная функция
{
	int t,key,q=11;
	float a,fnd_elem,tmp,a1,a2;
	int m=0,n,i;
	float result,result3=FLT_MAX,result4=-FLT_MAX;
	List *k, *head;
	/*
	* t - номер элемента меню
	* key - ключ, по которому удаляется
	* q - флаг, для второго меню
	* a - элемент списка
	* fnd_elem - искомый элемент списка
	* tmp - временная переменная
	* a1, a2 - переменные для вычисления первого задания
	*/
	setlocale(LC_ALL, ""); //устанавливаем русский язык для консоли
	/*
	* объявления структур и присваивание переменным link в них значения NULL
	*/
	k=new List; 
	head=new List;
	k->link=NULL;
	head->link=NULL;
	ClearList(head); //очистка списка 
	while(1)
	{	
		/*
		* меню в бесконечном цикле
		*/
		q=11;
		cout<<"Меню:
		\n1-Заполнение списка
		\n2-Удаление элемента
		\n3-Замена элемента
		\n4-Очистка
		\n5-Поиск элемента
		\n6-Вывод списка на экран
		\n7-Запись в файл
		\n8-Заполнение из файла
		\n10-Решение задания по варианту №4
		\n0-Выход\n";
		cin>>t;
		switch(t)
		{
		case 0:
			system("cls");
			return 0;
			break;
		case 1:
			system("cls");
			cout<<"Введите n: "<<endl;
			cin>>n;
			for(i=1;i<=(2*n);i++)
			{
				cout<<"Введите a["<<i<<"]: "<<endl;
				cin>>a;
				Filling(head,a);
			}
			break;
		case 2:
			system("cls");
			cout<<"Введите ключ: "<<endl;
			cin>>fnd_elem;
			Delete(head, fnd_elem);
			break;
		case 3:
			system("cls");
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
			system("cls");
			ClearList(head);
			cout<<"\nОчистка выполнена\n"<<endl;
			break;
		case 5:
			system("cls");
			cout<<"Введите порядковый номер элемента для поиска: ";
			cin>>key;
			if(key>2*n)
				cout<<"Неверный номер"<<endl;
			else
				cout<<FindElem(head,key)<<endl;
			break;
		case 6:
			system("cls");
			cout<<"\nЭлементы списка: \n"<<endl;
			PrintList(head);
			break;
		case 7:
			system("cls");
			cout<<"\nСохранено в файл\n"<<endl;
			SaveList(head);
			break;
		case 8:
			system("cls");
			ClearList(head);
			n=Filling_from_file(head);
			cout<<"\nЗаполнено, n= \n"<<n<<endl;
			break;
		case 10:
			while(q!=0) //проверка q на неравность 0
			{
		/*
		* меню в бесконечном цикле, выход, когда q=0
		*/
				cout<<"Выберите задание:\n0)Вернуться назад\n1) (A1-A2n)(A3-A(n-2))(A5-A(2n-4))...(A(2n-1)-A2)\n2) A1A2n + A2A(2n-1) + ... AnA(n+1)\n3) min(A1+A(n+1), A2+A(2n+2), ..., (An+A2n)\n4) max(min(A1,A2n), min(A2, A(2n-1)), ..., min(An, A(n+1))"<<endl;
				cin>>q;
				switch(q)
				{
				case 0:
					break;
				case 1:
					system("cls");
					tmp=0;
					a1=0;
					a2=0;
					result=1;
					for(i=0;i<n;i++)
					{
						a1=m+1;
						a2=2*n-m;
						tmp=FindElem(head, abs(a1))-FindElem(head, abs(a2));
						result=result*tmp;
						m=m+2;
					}
					cout<<"Результат: "<<result<<endl;
					break;
				case 2:
					result=0;
					tmp=0;
					for(i=0;i<n;i++)
					{
						tmp=FindElem(head, i+1)*FindElem(head, (2*n-i));
						result=result+tmp;
					}
					cout<<"Результат: "<<result<<endl;
					break;
				case 3:
					tmp=0;
					for(i=1;i<=n;i++)
					{
						tmp=FindElem(head,i)+FindElem(head,n+i); 
						result3=(result3<tmp?result3:tmp);   //тернарная операция                
					}
					cout<<"Результат: "<<result3<<endl;
					break;
				case 4:
					tmp=0;
					for(i=1;i<=n;i++)
					{
						tmp=(FindElem(head,i)<FindElem(head,2*n-i)?FindElem(head,i):FindElem(head,2*n-i)); //ищем минимум
						result4=(result4>tmp?result4:tmp); //а тут максимум
					}
					cout<<"Результат: "<<result4<<endl;
					break;
				}
		}	}
	}
	return 0;
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
	int i=1;
	// currPtr пробегает по списку, начиная с головы
	List *currPtr = head;
	while (currPtr != NULL)
	{
		
		if (i==el) 
		{
			return currPtr->data;
		}
		
		currPtr = currPtr->link; //переход к следующему
		i++;
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

void ReplaceElem(List *head, int index, float elem) //index - номер заменяемого элемента (с 0), elem -то, на что заменяем
{
	int i=1;
	// currPtr пробегает по списку, начиная с головы
	List *currPtr = head;
	// пока не конец списка, сравниваем индексы и заменяем
	while (currPtr != NULL)
	{
		if (i==index) 
		{
			currPtr->data=elem;
		}
		
		currPtr = currPtr->link; //переход к следующему
		i++;
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