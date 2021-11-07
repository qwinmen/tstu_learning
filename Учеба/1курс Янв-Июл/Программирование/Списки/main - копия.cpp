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
	//��������� ������ ��� �������� item � NextPtr ������������
	
	k = new List; 
	if (k == NULL)
	{
		cerr << "������ ��������� ������!" << endl;
		exit(1); // ���������� ���������, ���� ��������� ������ ��������
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
		cout<<"����:\n1-���������� ������\n2-�������� ��������\n3-������ ��������\n4-�������\n5-����� ��������\n6-����������\n7-����� ������ �� �����\n8-������ � ����\n9-���������� �� �����\n10-������� ������� �� �������� �4\n0-�����\n";
		cin>>t;
		switch(t)
		{
		case 0:
			return;
			break;
		case 1:
			cout<<"������� n: "<<endl;
			cin>>n;
			for(i=0;i<(2*n);i++)
			{
				cout<<"������� a["<<i+1<<"]: "<<endl;
				cin>>a;
				Filling(head,a);
			}
			break;
		case 2:
			cout<<"������� ����: "<<endl;
			cin>>fnd_elem;
			Delete(head, fnd_elem);
			break;
		case 3:
			cout<<"������� ���������� ����� �������� ��� ������: "<<endl;
			cin>>key;
			cout<<"������� �������� �������� ��� ������: "<<endl;
			cin>>fnd_elem;
			if(key>2*n)
				cout<<"�������� �����"<<endl;
			else
				ReplaceElem(head, key, fnd_elem);
			break;
		case 4:
			ClearList(head);
			cout<<"\n������� ���������\n"<<endl;
			break;
		case 5:
			cout<<"������� ���������� ����� �������� ��� ������: ";
			cin>>key;
			if(key>2*n)
				cout<<"�������� �����"<<endl;
			else
				cout<<FindElem(head,key)<<endl;
			break;
		case 6:
			//��� ����������
			break;
		case 7:
			cout<<"\n�������� ������: \n"<<endl;
			PrintList(head);
			break;
		case 8:
			cout<<"\n��������� � ����\n"<<endl;
			SaveList(head);
			break;
		case 9:
			ClearList(head);
			n=Filling_from_file(head);
			cout<<"\n���������, n= \n"<<n<<endl;
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
	// ���� ������ ����, �������� item � ������
	if (currPtr == NULL)
		head = GetList(item,head); 
	else 
	{ 
		// ����� ���� � ������� ����������
		while(currPtr->link != NULL)
			currPtr = currPtr->link;
		// ������� ���� � �������� � ����� ������
		// (����� currPtr)
		k = GetList(item);
		k->link = currPtr->link;
		currPtr->link = k;
	} 
}
// ������ ���������� ������
void PrintList(List *head)
{
	// currPtr ��������� �� ������, ������� � ������
	List *currPtr = head;
	// ���� �� ����� ������, �������� �������� ������ 
	// �������� ���� 
	while(currPtr != NULL)
	{
		cout << currPtr->data << endl;
		// ������� � ���������� ���� 
		currPtr = currPtr->link; 
	}
}

float FindElem(List *head, int el)
{
	int i=0;
	// currPtr ��������� �� ������, ������� � ������
	List *currPtr = head;
	// ���� �� ����� ������, �������� �������� ������ 
	// �������� ���� 
	while (currPtr != NULL)
	{
		i++;
		if (i==el) 
		{
			return currPtr->data;
		}
		
		currPtr = currPtr->link; //������� � ����������
	}


}

// ���������� � ���� ���������� ������
void SaveList(List *head)
{	
	FILE *a;
	a=fopen("out.txt", "wt");
	// currPtr ��������� �� ������, ������� � ������
	List *currPtr = head;
	// ���� �� ����� ������, �������� �������� ������ 
	// �������� ���� 
	while(currPtr != NULL)
	{
		fprintf(a,"%lf\n",currPtr->data);
		// ������� � ���������� ���� 
		currPtr = currPtr->link; 
	}
	fclose(a);
}

// �������� ���� ����� � ��������� ������
void ClearList(List * &head)
{
	List *currPtr, *nextPtr;
	currPtr = head;
	while(currPtr != NULL)
	{
		// �������� ����� ���������� ����
		nextPtr = currPtr->link;
		// ������� ������� ����
		delete currPtr;
		currPtr = nextPtr;
	}
	// �������� ��� ������
	head = NULL;
}

// �������� ������� ��������, ������������ � ������
void Delete(List* & head, float key)
{
	List  *currPtr = head, *prevPtr = NULL;
	// ��������� �������, ���� ������ ������
	if (currPtr == NULL) 
		return;
	// ����������� �� ���������� � ������ ��� �� �����
	while (currPtr != NULL && currPtr->data != key)
	{
		prevPtr = currPtr;
		currPtr = currPtr->link;
	}
	// ���� currPtr �� ����� NULL, ���� � currPtr
	if (currPtr != NULL)
	{
		// prevPtr == NULL �������� ���������� � ������ ������
		if(prevPtr == NULL)
			head = head->link;
		else
			// ���������� �� ������ ��� ����������� ����
			// ������������ ����� ����
			prevPtr->link = currPtr->link;
		// �������� ����
		delete currPtr;
	}
}

// �������� item � ������������� ������
void InsertOrder(List * & head, float item)
{
	// currPtr ��������� �� ������
	List  *currPtr, *prevPtr, *newList;
	// prevPtr == NULL ��������� �� ���������� � ������ ������
	prevPtr = NULL; currPtr = head;
	// ���� �� ������ � ����� ����� �������
	while (currPtr != NULL)
	{
		// ����� ������� �������, ���� item < �������� data 
		if (item < currPtr->data) 
			break;
		prevPtr = currPtr; 
		currPtr = currPtr->link;
	}
	// �������
	if (prevPtr == NULL) 
	// ���� prevPtr == NULL, ��������� � ������
		Filling(head,item); 
	else 
	{
	// �������� ����� ���� ����� �����������
		newList = GetList(item); 
		newList->link = prevPtr->link;
		prevPtr->link = newList;
	}
}

void ReplaceElem(List *head, int index, float elem) //index - ����� ����������� �������� (� 1), elem -��, �� ��� ��������
{
	int i=0;
	// currPtr ��������� �� ������, ������� � ������
	List *currPtr = head;
	// ���� �� ����� ������, �������� �������� ������ 
	// �������� ���� 
	while (currPtr != NULL)
	{
		i++;
		if (i==index) 
		{
			currPtr->data=elem;
		}
		
		currPtr = currPtr->link; //������� � ����������
	}
}

int Filling_from_file(List* & head) //���������� �� �����
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