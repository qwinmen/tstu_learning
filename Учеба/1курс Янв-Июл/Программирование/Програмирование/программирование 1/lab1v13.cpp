/*------------------------------Version 1.1-----------------------------------*/
/*----------------------------------------------------------------------------*/
/*           Тамбовский государственный технический университет               */
/*                                                               Кафедра САПР */
/*                 Лабораторная работа №1, вариант № 13.                      */
/*                                               Выполнил студент группы В-12 */
/*                                               Чепурнов Сергей Владимирович */
/*                                                                            */
/*                                               Проверил Романенко ...       */
/*                           Тамбов 2003 г.                                   */
/*Задание:                                                                    */
/*     Сортировать матрицу [n,n] по возростанию методом простых вставок.         */
/*     Осуществить обмен частей матрицы:                                      */
/*----------------------------------------------------------------------------*/
#include <conio.h>
#include <time.h>
#include <stdlib.h>
#include <stdio.h>
/*----------------------------------------------------------------------------*/
int **array_First, i, j, arraySize;
void OutputOfArray(int**, int);
void FillingOfArray(int**, int);
void SortingOfArray(int**, int);
void ModifyOfArray(int**, int);
/*----------------------------------------------------------------------------*/
main()
{
/*----------------------------------------------------------------------------*/
printf("Enter dimension of a matrix N x N: ");
scanf("%d", &arraySize);
array_First=(int**)malloc(arraySize*sizeof(int));
for(i=0; i<arraySize; i++) array_First[i]=(int*)malloc(arraySize*sizeof(int));
/*----------------------------------------------------------------------------*/
FillingOfArray(array_First, arraySize);
printf("\nInitial matrix:____________________\n");
OutputOfArray(array_First, arraySize);
SortingOfArray(array_First, arraySize);
printf("\nThe sorted matrix:_________________\n");
OutputOfArray(array_First, arraySize);
ModifyOfArray(array_First, arraySize);
printf("\nThe modified matrix:_______________\n");
OutputOfArray(array_First, arraySize);
/*----------------------------------------------------------------------------*/
while(!kbhit());
        for(j=0; j<arraySize; j++) free(array_First[j]);
        free(array_First);
return 0;
}
/*============================================================================*/
void OutputOfArray(int **a, const int ArraySize)
{ int i, j;
  printf("\n");
  for(i=0; i<ArraySize; i++)
   {
     for(j=0; j<ArraySize; j++) printf("%3d",a[i][j]);
      printf("\n");
   }
}
/*============================================================================*/

void FillingOfArray(int **a, const int ArraySize)
{
        int i, j;
  srand(time(NULL));
  for(i=0; i<ArraySize; i++)
   {
     for(j=0; j<ArraySize; j++)
      {
      array_First[i][j]=rand()%10;
      }
   }
}
/*============================================================================*/
void SortingOfArray(int **a, const int ArraySize)
{
        int i, j, d, m;
        int *array_A, *array_B;
        array_A=(int*)malloc(ArraySize*ArraySize*sizeof(int));
        array_B=(int*)malloc(ArraySize*ArraySize*sizeof(int));

        for(i=0, d=0; i<ArraySize; i++)
        {
             for(j=0; j<ArraySize; j++, d++) array_A[d]=a[i][j];
        }

        array_B[0]=array_A[0];
        for(i=1; i<ArraySize*ArraySize; i++)
           {
              for(j=0; j<i; j++)
               {
                 if(array_A[i]<array_B[j])
                 {
                    m=i;
                    while(m>j){array_B[m]=array_B[m-1]; m-=1;}
                    array_B[j]=array_A[i];
                    break;
                 }
                 else array_B[i]=array_A[i];
               }
           }

        for(i=0, d=0; i<ArraySize; i++)
           {
             for(j=0; j<ArraySize; j++, d++) a[i][j]=array_B[d];
           }

        free(array_A);
        free(array_B);
}
/*============================================================================*/
void ModifyOfArray(int **a, const int ArraySize)
{
        int i, j, temp;
        for(i=0; i<ArraySize/2; i++)
            {
               for(j=i+1; j<ArraySize-1-i; j++)
                {
                    temp=a[i][j];
                    a[i][j]=a[ArraySize-i-1][j];
                    a[ArraySize-i-1][j]=temp;
                    temp=a[j][i];
                    a[j][i]=a[j][ArraySize-i-1];
                    a[j][ArraySize-i-1]=temp;
                }
            }
}
/*............................................................................*/
