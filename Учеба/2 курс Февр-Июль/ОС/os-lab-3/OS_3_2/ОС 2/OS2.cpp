//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "OS2.h"
#include "Tlhelp32.h"
#include "psAPI.h"
#include "String.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

int iglobal,MainRow=1;
PROCESSENTRY32 ArrayProcess[256];

DWORD GetProcessByExeName(char *ExeName)
{DWORD Pid;
 PROCESSENTRY32 pe32;
 pe32.dwSize = sizeof(PROCESSENTRY32);
 HANDLE hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPALL, NULL);
 if(hProcessSnap==INVALID_HANDLE_VALUE)
   {MessageBox(NULL,"Error=" + GetLastError(),"Error(GetProcessByExeName)",MB_OK|MB_ICONERROR);
    return false;
   }
 if(Process32First(hProcessSnap,&pe32))
   {do
      {if(strcmpi(pe32.szExeFile,ExeName)==0)
         {CloseHandle(hProcessSnap);
          return pe32.th32ProcessID;
         }
   } while(Process32Next(hProcessSnap,&pe32));
 }
 CloseHandle(hProcessSnap);
 return 0;
}

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{StringGrid1->ColCount=5;
 StringGrid1->Cells[0][0]="Name process";
 StringGrid1->Cells[1][0]="ID process";
 StringGrid1->Cells[2][0]="PID process";
 StringGrid1->Cells[3][0]="Uncarded-for thread";
 StringGrid1->Cells[4][0]="Priority";
 StringGrid2->Cells[0][0]="?";
 StringGrid2->Cells[1][0]="ID Thread";
 StringGrid2->Cells[2][0]="ID Process";
 StringGrid2->Cells[3][0]="Based Priority";
 StringGrid2->Cells[4][0]="Delta Priority";
}


//---------------------------------------------------------------------------
void __fastcall TForm1::Button1Click(TObject *Sender)
{int i=0,ID;
 HANDLE ListProcess,HandleProcess;
 PROCESSENTRY32 DataProcess;
 ListProcess=CreateToolhelp32Snapshot(TH32CS_SNAPALL,0);
 DataProcess.dwSize=sizeof(PROCESSENTRY32);
 if(Process32First(ListProcess,&DataProcess))
   {while(Process32Next(ListProcess,&DataProcess))
         {
          i++;
          StringGrid1->RowCount=i+1;
          StringGrid1->Cells[0][i]=DataProcess.szExeFile;
		  StringGrid1->Cells[1][i]=(DataProcess.th32ProcessID);                //IntToStr
		  StringGrid1->Cells[2][i]=(DataProcess.th32ParentProcessID);//IntToStr
		  StringGrid1->Cells[3][i]=(DataProcess.cntThreads);
		  StringGrid1->Cells[4][i]=(DataProcess.pcPriClassBase);
          ArrayProcess[i]=DataProcess;
          ID=DataProcess.th32ProcessID;
          }
   }
Label1->Caption="Number of Process:" + IntToStr(i);
iglobal=i;
CloseHandle(ListProcess);

}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
  DWORD PID = GetProcessByExeName(ArrayProcess[MainRow].szExeFile);
        if ( !PID ) ShowMessage("??????? ?? ??????");
        else
        {       HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, PID );
                if ( TerminateProcess(hProcess, 0) ) ShowMessage("??????? ????");
                else ShowMessage("?? ???? ????? ???????");        }
  return;

}
//---------------------------------------------------------------------------

void __fastcall TForm1::StringGrid1SelectCell(TObject *Sender, int ACol,
      int ARow, bool &CanSelect)
{
 if(ARow==0) MainRow=1;
 else MainRow=ARow;
 Label1->Caption=' ';
 HANDLE ListProcess;
 THREADENTRY32 ThreadProcess;
 int i,ID;
 char Name[255];
 for(i=0;i<255;i++) Name[i]=' ';
  ID=ArrayProcess[MainRow].th32ProcessID;
 ListProcess=CreateToolhelp32Snapshot(TH32CS_SNAPALL,0);
 ThreadProcess.dwSize=sizeof(THREADENTRY32);
 i=0;
 if(Thread32First(ListProcess,&ThreadProcess))
   {while(Thread32Next(ListProcess,&ThreadProcess))
         {if(ThreadProcess.th32OwnerProcessID==ID)
            {i++;
             StringGrid2->RowCount=i+1;
             StringGrid2->Cells[0][i]=IntToStr(i);
			 StringGrid2->Cells[1][i]=(ThreadProcess.th32ThreadID);
			 StringGrid2->Cells[2][i]=(ThreadProcess.th32OwnerProcessID);     //IntToStr
			 StringGrid2->Cells[3][i]=(ThreadProcess.tpBasePri);
			 StringGrid2->Cells[4][i]=(ThreadProcess.tpDeltaPri);
             }
     }
   }
 Label1->Caption=Label1->Caption + "All streams in process " + ArrayProcess[MainRow].szExeFile + ": " + IntToStr(i);


}
//---------------------------------------------------------------------------

