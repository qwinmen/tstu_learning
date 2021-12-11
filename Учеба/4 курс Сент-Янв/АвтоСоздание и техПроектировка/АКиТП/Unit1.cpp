//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Unit2.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------


void __fastcall TForm1::Edit1KeyPress(TObject *Sender, char &Key)
{
if(Key>='0'&&Key<='9')return;
if(Key==VK_BACK)return;
if(Key==VK_RETURN)
 {
  if(Edit1->Text.Length()==0){Edit1->SetFocus();return;}
  if(Edit2->Text.Length()==0){Edit2->SetFocus();return;}
  BitBtn1->SetFocus();
 }
Key=0;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::BitBtn1Click(TObject *Sender)
{
if(Edit1->Text.Length()>0)
 {
  if(Edit1->Text.ToInt()<100)Edit1->Text=100;
  if(Edit1->Text.ToInt()>800)Edit1->Text=800;
  Edit1->Text=IntToStr(Edit1->Text.ToInt()-Edit1->Text.ToInt()%10);
 }
if(Edit2->Text.Length()>0)
 {
  if(Edit2->Text.ToInt()<100)Edit2->Text=100;
  if(Edit2->Text.ToInt()>800)Edit2->Text=800;
  Edit2->Text=IntToStr(Edit2->Text.ToInt()-Edit2->Text.ToInt()%10);
 }
ShowMessage("Размеры: "+Edit1->Text+"x"+Edit2->Text+"мм");
Form2->Caption="АКиТП. Размеры: "+Edit1->Text+"x"+Edit2->Text+"мм";
Form2->ScrollBox1->VertScrollBar->Position=0;
Form2->ScrollBox1->HorzScrollBar->Position=0;
Form2->PaintBox1->Width=Edit1->Text.ToInt()+1;
Form2->PaintBox1->Height=Edit2->Text.ToInt()+1;

for(int i=1;i<Form2->StringGrid1->RowCount;i++)
 Form2->StringGrid1->Rows[i]->Clear();
Form2->StringGrid1->RowCount=1;

for(int i=1;i<Form2->StringGrid2->RowCount;i++)
 Form2->StringGrid2->Rows[i]->Clear();
Form2->StringGrid2->RowCount=1;

for(int i=1;i<Form2->StringGrid3->RowCount;i++)
 Form2->StringGrid3->Rows[i]->Clear();
Form2->StringGrid3->RowCount=1;

Form2->Edit1->Text=0;
Form2->UpDown1->Min=0;
Form2->UpDown1->Max=0;

Form2->Edit2->Text=0;
Form2->UpDown2->Min=0;
Form2->UpDown2->Max=0;

Form2->Edit3->Text=0;
Form2->UpDown3->Min=0;
Form2->UpDown3->Max=0;

Form2->Button1->Enabled=False;
Form2->Button2->Enabled=False;
Form2->Button3->Enabled=False;
Form2->Button4->Enabled=False;

Form2->ComboBox1->Enabled=False;
Form2->ComboBox2->Enabled=False;

Form2->ComboBox1->Text="Вход";
Form2->ComboBox2->Text="Выход";

Form2->Visible=True;
Form1->Visible=False;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::BitBtn2Click(TObject *Sender)
{
Form1->Close();
}
//---------------------------------------------------------------------------
