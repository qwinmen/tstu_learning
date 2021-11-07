#include <stdio.h>
#include <stdlib.h> 
#include <ctype.h> 
#include <conio.h>
#include <dos.h>


/* размер массива структур */
#define BUFF_SIZE 20
/* максимальная длина текста в структуре */
#define TEXT_LEN 40

typedef union
{
	struct {char day; char month; int year;}dmy;
	long date;
}DATE, *LPDATE;

/* типы полей структуры */
typedef enum{
	FT_F,
	FT_I,
	FT_O,
	FT_ACCOUNT,
	FT_SUMMA,
	FT_DATE,
}FIELDTYPE, *LPFIELDTYPE;

/* структура элемента массива */
typedef struct
{
	char F [TEXT_LEN];	/* фамилия */
	char I [TEXT_LEN];	/* имя */
	char O [TEXT_LEN];	/* отчество */
	int account;		/* номер счета */
	double summa;		/* сумма на счете */
	DATE date;			/* дата  */
}ITEM, *LPITEM;

/* структура списка (можно создать несколько переменных типа LIST)*/
typedef struct
{
	ITEM	Items[BUFF_SIZE]; /* массив структур */
	int Count; /* количество используемых элементов */
}LIST, *LPLIST;



/*-------------------------------------------------------------*/
/* прототипы функций */
/*-------------------------------------------------------------*/
/* ввод числа с проверкой корректности */
int check_input_int(char* msg);
/* ввод вещественного числа с проверкой корректности */
double check_input_float(char* str);
/* очистка структуры */
void item_clear(LPITEM lpItem);
/* очистка списка структур */
void list_clear(LPLIST lpList);
/* поиск минимального значения по полю ft*/
LPITEM item_find_min(LPITEM Items, int Count, FIELDTYPE ft);
/* разделитель */
void separator();
/* вывод заголовка таблицы */
void table_head();
/* вывод структуры на экран */
void item_out(LPITEM Item);
/* ввод данных в структуру */
void item_in(LPITEM Item);
/* редактирование элемента */
void item_edit(LPITEM Item);
/* поиск наиболее близкого значения поля ft */
LPITEM item_find(LPITEM Items, int Count, FIELDTYPE ft, void* value);
/* возвращает индекс элемента */
int list_index_of(LPLIST lpList, LPITEM lpItem);
/* удаление элемента из списка */
void list_delete(LPLIST lpList, LPITEM lpItem);
/* поиск наиболее близкого значения поля ft */
LPITEM list_find(LPLIST lpList, FIELDTYPE ft, void* value);
/* поиск пустой переменной в списке */
LPITEM list_find_empty(LPLIST lpList);
/* сортировки списка структур по полю ft*/
void list_sort(LPLIST lpList, FIELDTYPE ft);
/* удаление из списка элемента с индексом Index */
void list_delete_index(LPLIST lpList, int Index);
/* общая сумма */
double total_sum(LPLIST lpList);
/* вывод всех не пустых элементов списка */
void list_out(LPLIST lpList);
/* режим сортировки */
void sort_mode(LPLIST lpList);
/* поиск значения по выбранному полю */
int find_mode(LPLIST lpList);
/* редактор списка структур */
void list_edit(LPLIST lpList);
/* генератор случайного текста */
void text_generate(char* str, int MaxLen);
/* инициализация списка случайными значениями */
void init_list(LPLIST lpList);
/*-------------------------------------------------------------*/



/* ввод целого числа с проверкой корректности */
int check_input_int(char* msg)
{
	char str[TEXT_LEN]; /* строка ввода */
	int i, sz;
	do
	{
		printf("%s", msg);	/* выводим сообщение */
		scanf("%s", str);		/* получаем строку */
		sz = strlen(str);		/* размер строки */
			i = 0; /* проверяем все ли символы цифровые (0..9) */
			while (i < sz && isdigit(str[i])) i++;
	}while (i < sz); /* если есть не число, то повторяем ввод */
	return atoi(str); /* возвращаем результат */
}



/* ввод вещественного числа с проверкой корректности */
double check_input_float(char* msg)
{
	char str[TEXT_LEN]; /* строка ввода */
	int i, sz;
	do
	{
		printf("%s", msg);	/* выводим сообщение */
		scanf("%s", str);		/* получаем строку */
		sz = strlen(str);		/* размер строки */
			i = 0; /* проверяем все ли символы цифровые (0..9) */
			while (i < sz && !isalpha(str[i])) i++;
	}while (i < sz); 
	return atof(str); /* возвращаем результат */
}



/* очистка структуры */
void item_clear(LPITEM lpItem)
{
	lpItem->F[0]		= 0;
	lpItem->I[0]		= 0;
	lpItem->O[0]		= 0;
	lpItem->summa		= 0;
	lpItem->account		= 0;
	lpItem->date.date	= 0;
}



/* очистка списка структур */
void list_clear(LPLIST lpList)
{
	int i;
	for (i = 0; i < lpList->Count; i++)
		item_clear(&lpList->Items[i]);
	lpList->Count = 0;
}



/* поиск минимального значения по полю ft*/
LPITEM item_find_min(LPITEM Items, int Count, FIELDTYPE ft)
{
	int i = 1;
	int m = 0; /* индекс минимального объекта */
	
	switch (ft)
	{
		case FT_F:
			for (; i < Count; i++)
				if (strcmp(Items[m].F, Items[i].F) > 0)
					m = i;
		break;	
		case FT_I:
			for (; i < Count; i++)
				if (strcmp(Items[m].I, Items[i].I) > 0)
					m = i;
		break;	
		case FT_O:
			for (; i < Count; i++)
				if (strcmp(Items[m].O, Items[i].O) > 0)
					m = i;
		break;	
		case FT_ACCOUNT:
			for (; i < Count; i++)
				if (Items[m].account > Items[i].account)
					m = i;
		break;
		case FT_SUMMA:
			for (; i < Count; i++)
				if (Items[m].summa > Items[i].summa)
					m = i;
		break;
		case FT_DATE:
			for (; i < Count; i++)
				if (Items[m].date.date > Items[i].date.date)
					m = i;
		break;	
		default: /* если тип поля неизвестен */
			return 0;
	}
	
	/* возвращаем указатель на минимальный элемент */
	return &Items[m];
}



/* разделитель */
void separator()
{
	printf("-------------------------------------------------------------------------------\n");
}



/* вывод заголовка таблицы */
void table_head()
{
	separator();
	printf("account\tsumma\tdate\t\tF.I.O.\n");
	separator();
}



/* вывод структуры на экран */
void item_out(LPITEM Item)
{
	printf("%5.d\t", Item->account);
	printf("%4.2lf\t", Item->summa);
	printf("%2.d.%2.d.%4.d\t", Item->date.dmy.day, Item->date.dmy.month, Item->date.dmy.year);
	printf("%s  %s  %s\n", Item->F, Item->I, Item->O);
}



/* ввод данных в структуру */
void item_in(LPITEM Item)
{
	struct date d;
	int i;

	printf("familia[%d]\t= ", TEXT_LEN); scanf("%s", Item->F);
	printf("name[%d]\t= ", TEXT_LEN); scanf("%s", Item->I);
	printf("otchestvo[%d]\t= ", TEXT_LEN); scanf("%s", Item->O);
	
	
	do{i = check_input_int("account\t= "); }while(i <= 0); Item->account = i;
	Item->summa = check_input_float("summa\t= ");	
	
	getdate(&d);
	Item->date.dmy.day		= d.da_day;
	Item->date.dmy.month	= d.da_mon;
	Item->date.dmy.year		= d.da_year;
}



/* редактирование элемента */
void item_edit(LPITEM Item)
{
	clrscr();
	printf("Edit Item:\n");
	table_head(); /* заголовок таблицы */
	item_out(Item); /* вывод элемента */
	separator();
	printf("\ninput new values:\n");
	separator();
	item_in(Item); /* ввод новых данных */
}



/* поиск наиболее близкого значения поля ft */
LPITEM item_find(LPITEM Items, int Count, FIELDTYPE ft, void* value)
{
	LPDATE d;
	int l = 0;	
	int i = 1;
	int r = 0;
	long d1, d2, d3;
	switch (ft)
	{
		case FT_F:
			l = strlen((char*)value);
			for (;i < Count; i++)
				if (abs(strncmp(Items[i].F, (char*)value, l)) <= 
					abs(strncmp(Items[r].F, (char*)value, l)))
					r = i;
		break;
		case FT_I:
			l = strlen((char*)value);
			for (;i < Count; i++)
				if (abs(strncmp(Items[i].I, (char*)value, l)) <= 
					abs(strncmp(Items[r].I, (char*)value, l)))
					r = i;
		break;
		case FT_O:
			l = strlen((char*)value);
			for (;i < Count; i++)
				if (abs(strncmp(Items[i].O, (char*)value, l)) <= 
					abs(strncmp(Items[r].O, (char*)value, l)))
					r = i;
		break;
		case FT_ACCOUNT:
			for (;i < Count; i++)
				if (abs(Items[i].account - (int)value) < 
					abs(Items[r].account - (int)value))
					r = i;
		break;
		case FT_SUMMA:
			for (;i < Count; i++)
				if (abs(Items[i].account - *((double*)value)) <= 
					abs(Items[r].account - *((double*)value)))
					r = i;
		break;
		case FT_DATE:
			d = ((LPDATE)value);
			for (;i < Count; i++)
				if (abs(Items[i].date.date - d->date) < 
					abs(Items[r].date.date - d->date))
					r = i;	
			
		break;
		default: /* если тип поля неизвестен */
			return 0;
	}			
	
	/* если нашли, то возвращаем указатель на элемент, иначе 0 */
	return r < Count ? &Items[r] : 0;
}



/* возвращает индекс элемента */
int list_index_of(LPLIST lpList, LPITEM lpItem)
{
	int i = 0;
	/* ищем указатель lpItem в списке lpList */
	while (i < lpList->Count && &lpList->Items[i] != lpItem) i++;
	/* если нашли, то возвращаем индекс, иначе -1 */
	return i < lpList->Count ? i : -1;
}



/* удаление элемента из списка */
void list_delete(LPLIST lpList, LPITEM lpItem)
{
	int i = list_index_of(lpList, lpItem);
	if (i >= 0)
		list_delete_index(lpList, i);
}



/* поиск наиболее близкого значения поля ft */
LPITEM list_find(LPLIST lpList, FIELDTYPE ft, void* value)
{
	return item_find(lpList->Items, lpList->Count, ft, value);
}



/* поиск пустой переменной в списке */
LPITEM list_find_empty(LPLIST lpList)
{
	/* если в списке есть свободные элементы, то */
	/* возвращаем указатель на первых пустой элемент, иначе 0*/
	return (lpList->Count < BUFF_SIZE) ? &lpList->Items[lpList->Count] : 0;
}



/* сортировки списка структур по полю ft*/
void list_sort(LPLIST lpList, FIELDTYPE ft)
{
	int i;
	ITEM tmp; /* для обмена */
	LPITEM m; /* указатель на минимальный элемент */
	/* цикл сортировки */
	for (i = 0; i < lpList->Count-1; i++)
	{
		/* поиск минимального по полю ft */
		m = item_find_min(lpList->Items + i, lpList->Count - i, ft);
		/* обмен */
		tmp = lpList->Items[i];
		lpList->Items[i] = *m;
		*m = tmp;	
	}
}



/* удаление из списка элемента с индексом Index */
void list_delete_index(LPLIST lpList, int Index)
{
	lpList->Count--;
	lpList->Items[Index] = lpList->Items[lpList->Count-1];
}



/* общая сумма */
double total_sum(LPLIST lpList)
{
	double sum = 0;
	int i;
	for (i = 0; i < lpList->Count; i++)
		sum += lpList->Items[i].summa;
	return sum;
}



/* вывод всех не пустых элементов списка */
void list_out(LPLIST lpList)
{
	int i;
	clrscr();
	table_head();
	for (i = 0; i < lpList->Count; i++)
		item_out(&lpList->Items[i]);
	separator();
	printf("\t%4.2lf\n", total_sum(lpList));
	separator();
	printf("\nelement count = %d", lpList->Count);
}



/* режим сортировки */
void sort_mode(LPLIST lpList)
{
	printf("select field sortered\n");
	printf("f - familia\nn - name\no - otchestvo\na - account\ns - summa\nd - date\n");
	switch (getch())
	{
		case 'f':
			list_sort(lpList, FT_F);
		break;
		case 'n':
			list_sort(lpList, FT_I);
		break;
		case 'o':
			list_sort(lpList, FT_O);
		break;
		case 'a':
			list_sort(lpList, FT_ACCOUNT);
		break;
		case 's':
			list_sort(lpList, FT_SUMMA);
		break;
		case 'd':
			list_sort(lpList, FT_DATE);
		break;					
	}
}



/* поиск значения по выбранному полю */
int find_mode(LPLIST lpList)
{
	static double summa;
	static char a[TEXT_LEN];
	static DATE dt;
	int d, res = -1;	
	
	printf("select field find\n");
	printf("f - familia\nn - name\no - otchestvo\na - account\ns - summa\nd - date\n");
	switch (getch())
	{
		case 'f': /* фамилия */
			printf("familia = ");
			scanf("%s", a);
			res = list_index_of(lpList, list_find(lpList, FT_F, a));						
		break;
		case 'n': /* имя */
			printf("name = ");
			scanf("%s", a);
			res = list_index_of(lpList, list_find(lpList, FT_I, a));
		break;
		case 'o': /* отчество */
			printf("otchestvo = ");
			scanf("%s", a);
			res = list_index_of(lpList, list_find(lpList, FT_O, a));
		break;
		case 'a': /* номер счета */
			printf("account = ");
			scanf("%d", &d);
			res = list_index_of(lpList, list_find(lpList, FT_ACCOUNT, (void*)d));
		break;
		case 's': /* сумма на счете */
			summa = check_input_float("summa = ");
			res = list_index_of(lpList, list_find(lpList, FT_SUMMA, &summa));
		break;
		case 'd': /* дата изменения */
			printf("input date: dd mm yyyy \n");
			do {d = check_input_int("day\t= "); }while (d < 1 || d > 31); dt.dmy.day = d;
			do {d = check_input_int("month\t= "); }while (d < 1 || d > 12); dt.dmy.month = d;
			do {d = check_input_int("year\t= "); }while (d < 1970 || d > 16000); dt.dmy.year = d;
			res = list_index_of(lpList, list_find(lpList, FT_DATE, (void*)&dt));
		break;
	}
	return res;
}



/*-----------------------------------------------------------------------------*/
/* редактор списка структур */
void list_edit(LPLIST lpList)
{
	int ItemIndex = -1; /* текущий индекс элемента */
	LPITEM lpItem = 0; /* выбранный элемент */

	
	if (lpList->Count > 0)
		ItemIndex = 0;
		
	/* цикл  */
	while (1)
	{
		clrscr();
		/* заголовок */
		printf("Edit List [Count = %d] [Max Count = %d] ", lpList->Count, BUFF_SIZE);
		if (ItemIndex < 0)
			printf("[no selected]\n");
		else
			printf("[Current elem = %d]\n", ItemIndex);
		separator();
		
		/* клавиши управления */
		printf("q - exit\n");
		printf("a - add\n");
		printf("d - delete\n");
		printf("e - edit\n");
		printf("l - print list\n");
		printf("s = sorter\n");
		printf("c - clear list\n");
		printf("f - find item\n");
		printf("b - back elem\tn - next elem\n\n");
		
		if (ItemIndex >= 0)
		{
			table_head();
			item_out(&lpList->Items[ItemIndex]);
		}
		separator();
		/* обработка клавиш */
		switch (getch())
		{
			case 'c': /* очистка списка */
				list_clear(lpList);
				ItemIndex = -1;
			break;
			case 'b': /* переход на предыдущий элемент */
				if (ItemIndex > 0)
					ItemIndex--;
			break;
			case 'n': /* переход на следующий элемент */
				if (ItemIndex < lpList->Count -1)
					ItemIndex++;
			break;
			case 's':
				sort_mode(lpList);
				list_out(lpList);
				printf("\npress any key to back menu");
				getch();
			break;
			case 'f':
				ItemIndex = find_mode(lpList);
			break;
			case 'd':
				if (ItemIndex >= 0)
				{
					list_delete_index(lpList, ItemIndex);
					if (ItemIndex >= lpList->Count)
						ItemIndex = lpList->Count -1;
				}
			break;
			case 'e':
				if (ItemIndex >= 0)
				{
					item_edit(&lpList->Items[ItemIndex]);
				}
			break;
			case 'a': /* добавление элемента в список */
				lpItem = list_find_empty(lpList); /* поиск пустой структуры в списке */
				if (lpItem)
				{
					lpList->Count++;
					item_in(lpItem);
					ItemIndex = list_index_of(lpList, lpItem);
				}
				else
					printf("no empty element!");
			break;
			case 'l': /* отображаем список в виде таблицы */
				list_out(lpList);
				printf("\npress any key to back menu");
				getch();
			break;
			case 'q': /* выход из программы */
				exit(1);
			break;
		}
	}
}



/* генератор случайного текста */
void text_generate(char* str, int MaxLen)
{
	int i;
	for (i = 0; i < 3 + (rand() % (MaxLen-3)); i++)
		str[i] = 'a' + (rand() % ('z' - 'a'));
}



/* инициализация списка случайными значениями */
void init_list(LPLIST lpList)
{
	int i;
	lpList->Count = 10;
	for (i = 0; i < lpList->Count; i++)
	{
		lpList->Items[i].date.dmy.day   = rand() % 30;
		lpList->Items[i].date.dmy.month = rand() % 12 + 1;
		lpList->Items[i].date.dmy.year  = rand() % 10 + 2000;
		lpList->Items[i].account	= rand() % 10000;
		lpList->Items[i].summa		= (rand() % 100) + ((double)(rand() % 1000) / 1000);
		text_generate(lpList->Items[i].F, TEXT_LEN);
		text_generate(lpList->Items[i].I, TEXT_LEN);
		text_generate(lpList->Items[i].O, TEXT_LEN);
	}
}



/* главная функция программы */
void main()
{
	LIST List;		/* список (массив) структур */
	srand(ctime());	/* рандомизация */
	init_list(&List);	/* инициализация списка случайными значениями */
	list_edit(&List);	/* редактируем список */
}
