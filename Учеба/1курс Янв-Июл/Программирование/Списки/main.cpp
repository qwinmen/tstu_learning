#include <iostream> //���������� ���������� �����-������
#include <string.h> //���������� ��� ������ �� ��������
//#include <conio.h>
#include <math.h> //���������� �������������� �������� � �������
#include <float.h> //��� flt_max � flt_min

using namespace std; //���������� ������������ ���� std
struct List //���������� ������� ���������
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

/*
*	��������������� �������
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

int main() // ������� �������
{
	int t,key,q=11;
	float a,fnd_elem,tmp,a1,a2;
	int m=0,n,i;
	float result,result3=FLT_MAX,result4=-FLT_MAX;
	List *k, *head;
	/*
	* t - ����� �������� ����
	* key - ����, �� �������� ���������
	* q - ����, ��� ������� ����
	* a - ������� ������
	* fnd_elem - ������� ������� ������
	* tmp - ��������� ����������
	* a1, a2 - ���������� ��� ���������� ������� �������
	*/
	setlocale(LC_ALL, ""); //������������� ������� ���� ��� �������
	/*
	* ���������� �������� � ������������ ���������� link � ��� �������� NULL
	*/
	k=new List; 
	head=new List;
	k->link=NULL;
	head->link=NULL;
	ClearList(head); //������� ������ 
	while(1)
	{	
		/*
		* ���� � ����������� �����
		*/
		q=11;
		cout<<"����:
		\n1-���������� ������
		\n2-�������� ��������
		\n3-������ ��������
		\n4-�������
		\n5-����� ��������
		\n6-����� ������ �� �����
		\n7-������ � ����
		\n8-���������� �� �����
		\n10-������� ������� �� �������� �4
		\n0-�����\n";
		cin>>t;
		switch(t)
		{
		case 0:
			system("cls");
			return 0;
			break;
		case 1:
			system("cls");
			cout<<"������� n: "<<endl;
			cin>>n;
			for(i=1;i<=(2*n);i++)
			{
				cout<<"������� a["<<i<<"]: "<<endl;
				cin>>a;
				Filling(head,a);
			}
			break;
		case 2:
			system("cls");
			cout<<"������� ����: "<<endl;
			cin>>fnd_elem;
			Delete(head, fnd_elem);
			break;
		case 3:
			system("cls");
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
			system("cls");
			ClearList(head);
			cout<<"\n������� ���������\n"<<endl;
			break;
		case 5:
			system("cls");
			cout<<"������� ���������� ����� �������� ��� ������: ";
			cin>>key;
			if(key>2*n)
				cout<<"�������� �����"<<endl;
			else
				cout<<FindElem(head,key)<<endl;
			break;
		case 6:
			system("cls");
			cout<<"\n�������� ������: \n"<<endl;
			PrintList(head);
			break;
		case 7:
			system("cls");
			cout<<"\n��������� � ����\n"<<endl;
			SaveList(head);
			break;
		case 8:
			system("cls");
			ClearList(head);
			n=Filling_from_file(head);
			cout<<"\n���������, n= \n"<<n<<endl;
			break;
		case 10:
			while(q!=0) //�������� q �� ���������� 0
			{
		/*
		* ���� � ����������� �����, �����, ����� q=0
		*/
				cout<<"�������� �������:\n0)��������� �����\n1) (A1-A2n)(A3-A(n-2))(A5-A(2n-4))...(A(2n-1)-A2)\n2) A1A2n + A2A(2n-1) + ... AnA(n+1)\n3) min(A1+A(n+1), A2+A(2n+2), ..., (An+A2n)\n4) max(min(A1,A2n), min(A2, A(2n-1)), ..., min(An, A(n+1))"<<endl;
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
					cout<<"���������: "<<result<<endl;
					break;
				case 2:
					result=0;
					tmp=0;
					for(i=0;i<n;i++)
					{
						tmp=FindElem(head, i+1)*FindElem(head, (2*n-i));
						result=result+tmp;
					}
					cout<<"���������: "<<result<<endl;
					break;
				case 3:
					tmp=0;
					for(i=1;i<=n;i++)
					{
						tmp=FindElem(head,i)+FindElem(head,n+i); 
						result3=(result3<tmp?result3:tmp);   //��������� ��������                
					}
					cout<<"���������: "<<result3<<endl;
					break;
				case 4:
					tmp=0;
					for(i=1;i<=n;i++)
					{
						tmp=(FindElem(head,i)<FindElem(head,2*n-i)?FindElem(head,i):FindElem(head,2*n-i)); //���� �������
						result4=(result4>tmp?result4:tmp); //� ��� ��������
					}
					cout<<"���������: "<<result4<<endl;
					break;
				}
		}	}
	}
	return 0;
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
	int i=1;
	// currPtr ��������� �� ������, ������� � ������
	List *currPtr = head;
	while (currPtr != NULL)
	{
		
		if (i==el) 
		{
			return currPtr->data;
		}
		
		currPtr = currPtr->link; //������� � ����������
		i++;
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

void ReplaceElem(List *head, int index, float elem) //index - ����� ����������� �������� (� 0), elem -��, �� ��� ��������
{
	int i=1;
	// currPtr ��������� �� ������, ������� � ������
	List *currPtr = head;
	// ���� �� ����� ������, ���������� ������� � ��������
	while (currPtr != NULL)
	{
		if (i==index) 
		{
			currPtr->data=elem;
		}
		
		currPtr = currPtr->link; //������� � ����������
		i++;
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