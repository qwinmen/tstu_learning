  #include <stdio.h>
  #include <conio.h>
  #include <dos.h>
  #include <stdlib.h>

  void set13h(){
  _asm{
  mov Ax, 13h
  int 10h
  }
  }
  void progr1(){
  long i,j;
  unsigned char far *mem=(unsigned char far*)MK_FP (0xA000,0);
  clrscr();
  for(i=0;i<320;i++){
	for(j=0;j<200;j++){
	mem[320*j+i]=i;
	}
  }
  getch();
  }
  void progr2(){
  long i;
  unsigned char far *mem=(unsigned char far*)MK_FP (0xA000,0);
  for(i=0;i<30;i++){
  outport(0x3c8,15);
  outport(0x3c9,rand()%300);
  outport(0x3c9,rand()%300);
  outport(0x3c9,rand()%300);
  sleep(1);
  }
  }

  int main(){
  set13h();
  char c;
  do{
  clrscr();
  printf("1 - 256colors\n");
  printf("2 - Screen changing\n");
  printf("3 - Exit\n");
  printf("Enter your choise: ");
  c=getch();
  switch(c){
  case '1': {
  progr1();
  break;
  }
  case '2': {
  progr2();
  break;
  }
  }
  }
  while(c!='3');
  return 0;
  }