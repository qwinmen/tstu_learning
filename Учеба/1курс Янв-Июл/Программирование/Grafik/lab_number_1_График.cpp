#include <iostream.h>
#include <conio.h>
#include <stdlib.h>
int main()
    {

	 int **a,i,n,m,j,t,k,e;
	 clrscr();
	 cout<<"n = "<<endl;
	 cin>>n;
	  cout<<"m = "<<endl;
	 cin>>m;
	 cout<<endl;
		a = (int**)malloc (n*sizeof(int*));
                  for (i = 0; i<n; i++)
                 a[i] = (int*)malloc (m*sizeof(int));
                 for (i = 0; i<n; i++)
                     {
                        for (j = 0; j<m; j++)
                           {
                                 cout<<" a ["<<i<<" , "<<j<<"] = "<<endl;
					   cin>>a[i][j];
                           }
                   cout<<endl;
                    }
                cout<<endl;
		int *b;
		b = (int*)malloc(sizeof(int)*n);
		for (i = 0; i<n; i++)
		   {
		       for (j = 0; j<m; j++)
			  {
			      b[j + i*m] = a[i][j];
			  }

		   }
		    for (i = 0; i<n*m; i++)
		      {
			 t = b[i];
			 j = i - 1;
			 while ( (j>=0) && (t<b[j]))
			     {
				 b[j + 1] = b[j];
				 j--;
			     }
			  b[j + 1] = t;
		      }
		   cout<<endl;
		   for (i = 0; i<n*m; i++)
		      cout<<b[i]<<"  ";
		      cout<<endl;
			i = j = k =0;
		   a[i][j] = b[k];
			 // последний рывок
		   while ( k<=(n*m - 2)   )
		   {
		   if (j< (m - 1)) {j++;} else {i++;}
		   k++;
		   a[i][j] = b[k];  // вправо или вниз
		   while ( (j>0) && (i<(n - 1))  ) {i++; j--; k++; a[i][j] = b[k];}// по диагонали вниз
		   if ( i<n-1 ) {i++;} else {j++;}
			      k++;
			      a[i][j] = b[k];
		   while ( (j<(m - 1)) && (i>0) ) {i--; j++; k++; a[i][j] = b[k];}
		   }
		    a[i][j] = b[k];
		    cout<<endl<<endl<<endl;

		    for (i = 0;i<n;i++)
			 {
			     for (j = 0;j<m;j++)
					   cout<<a[i][j]<<"\t";
					   cout<<endl;
			 }
for (i = 0; i<n; i++) free (a[i]);
  free (a);
for (i = 0; i<n; i++)
  free (b);
	  getch();
          return 0;
    }
