#include <conio.h>
#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int main(){
int **Mass, i, n, m, j, k, v, z;
printf("Quantity of columns:");
scanf("%d", &n);
printf("Quantity of lines:");
scanf("%d", &m);
srand(time(0));

Mass=(int**)malloc(m*sizeof(int));

printf ("Press '1' for random or '2' for hand typing\n");
scanf ("%d", &v);
if (v==1){
for(i=0;i<m;i++){
Mass[i]=(int*)malloc(n*sizeof(int));
for(j=0;j<n;j++){
Mass[i][j]=rand()%100;
printf("%d\t", Mass[i][j]);
}
printf("\n");
}
}
else{
printf("\nVvodite znachenia massiva.");
for(i=0;i<m;i++){
Mass[i]=(int*)malloc(n*sizeof(int));
for(j=0;j<n;j++){
printf("\na[%d][%d]=",i,j);
scanf("%d",&Mass[i][j]);
}
}
}

//printf("\n\n\n");
for (j=0;j<n;j++){
for(i=1;i<m;i++){
if(Mass[i][j]<Mass[i-1][j]){
k=Mass[i-1][j];
Mass[i-1][j]=Mass[i][j];
Mass[i][j]=k;
i=0;
}
else{}
}
}

printf("\n Massiv posle 1st sortirovki.\n");

for(i=0;i<m;i++){
for(j=0;j<n;j++){
printf("%d ",Mass[i][j]);
}
printf("\n");
}
z=0;
for(j=1;j<n;j++){
if(Mass[z][j]==Mass[z][j-1])
z++;
if(Mass[z][j]>Mass[z][j-1]){
for(i=0;i<m;i++){
k=Mass[i][j-1];
Mass[i][j-1]=Mass[i][j];
Mass[i][j]=k;
}
j=0;
}
z=0;
}

printf("\n Massiv posle 2nd sortirovki.\n");

for(i=0;i<m;i++){
for(j=0;j<n;j++){
printf("%d ",Mass[i][j]);
}
printf("\n");
}

for(i=0;i<m;i++) 
free(Mass[i]);
free(Mass);
getch();
return 0;
}