#include <cstdlib>
#include <iostream>

using namespace std;

int replace(int s, bool q) 
{
   if ((q)&&(s>=192)&&(s<=223)) s=s+32;
   if ((q)&&(s==168)) s=184;
   if ((!q)&&(s>=224)&&(s<=255)) s=s-32;
   if ((!q)&&(s==184)) s=168;
   return s;
}

void editor()
{
    FILE *f;
    FILE *g;
    f=fopen("input.txt", "r");
    g=fopen("output.txt", "w");
    unsigned char s; unsigned char w; bool k0=true; bool point=false;  bool z;
    w=255;
    while(!feof(f))
    {
        fscanf(f,"%c", &s);
        s=replace(s, true);
        if ((s!=32)&&(k0))  
          {
              s=replace(s, false);
              k0=false;
         }
        if ((s==46)) {point=true; }
        if ((s!=32)&&(s!=46)&&(s!=10)&&(point==true)) 
           {s=replace(s, false); point=false;}
        fprintf(g,"%c", s);
    }
    fclose(f);
    fclose(g);
    
}

int main(int argc, char *argv[])
{
    FILE *f;
    f=fopen("input.txt", "r");
    if (f == NULL) 
    {
        printf("There is no file input.txt\n"); 
        f=fopen("input.txt", "w");   
        fclose(f);
    }
    else  {fclose(f); editor(); }  
    system("PAUSE");
    return EXIT_SUCCESS;
}
