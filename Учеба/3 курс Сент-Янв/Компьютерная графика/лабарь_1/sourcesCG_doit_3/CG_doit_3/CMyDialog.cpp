#include "MyClassesDeclarations.h"


//--------------------------------------------------------------------------
BEGIN_MESSAGE_MAP(CMyDialog , CDialog)
	ON_EN_CHANGE(IDC_EDIT_GRAD,edit_grad)
	ON_EN_CHANGE(IDC_EDIT_NUMOF,edit_numof)
	ON_EN_CHANGE(IDC_EDIT_SPACE,edit_space)
END_MESSAGE_MAP()
//--------------------------------------------------------------------------
int CMyDialog::get_grad()
{
	return grad;
}
//--------------------------------------------------------------------------
int CMyDialog::get_numof()
{
	return numof;
}
//--------------------------------------------------------------------------
int CMyDialog::get_space()
{
	return space;
}
//--------------------------------------------------------------------------
void CMyDialog::set_gns(int ngrad, int nnum, int nspace)
{
	grad	= ngrad;
	numof	= nnum;
	space	= nspace;

	
}
//--------------------------------------------------------------------------
void CMyDialog::edit_grad()
{
 CWnd* pWnd = GetDlgItem(IDC_EDIT_GRAD);
 pWnd->GetWindowText(ch1,10);
 grad = atoi(ch1);

}
//--------------------------------------------------------------------------
void CMyDialog::edit_numof()
{
 CWnd* pWnd = GetDlgItem(IDC_EDIT_NUMOF);
 pWnd->GetWindowText(ch1,10);
 numof = atoi(ch1);

}
//--------------------------------------------------------------------------
void CMyDialog::edit_space()
{
 CWnd* pWnd = GetDlgItem(IDC_EDIT_SPACE);
 pWnd->GetWindowText(ch1,10);
 space = atoi(ch1);

}
//--------------------------------------------------------------------------
void CMyDialog::OnOK()
{
  CDialog::OnOK();
}

//------------------------------------------------------------------------
CMyDialog::CMyDialog( UINT nIDTemplate, CWnd* pParentWnd)
           :CDialog(nIDTemplate,pParentWnd)
{

 grad=-5;
 numof=-5;
 space=-5;
 ch1[1]='\0';
 
}
//--------------------------------------------------------------------------
BOOL CMyDialog::OnInitDialog()
{
  CDialog::OnInitDialog();
  CenterWindow();

	CWnd* pWnd = GetDlgItem(IDC_EDIT_GRAD);
	itoa(grad,ch1,10);
    pWnd->SetWindowText(ch1);

	CWnd* pWnd1 = GetDlgItem(IDC_EDIT_NUMOF);
	itoa(numof,ch1,10);
    pWnd1->SetWindowText(ch1);

	CWnd* pWnd2 = GetDlgItem(IDC_EDIT_SPACE);
	itoa(space,ch1,10);
    pWnd2->SetWindowText(ch1);

  return TRUE;
}
//--------------------------------------------------------------------------
void CMyDialog::CreateModelessDialog(char *Name)
{
	CDialog::Create(Name);
    InvalidateRect(NULL,TRUE);
}