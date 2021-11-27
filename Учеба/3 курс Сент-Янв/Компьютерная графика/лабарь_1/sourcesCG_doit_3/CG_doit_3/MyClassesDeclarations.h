#include <afxwin.h>
#include "resource.h"

//����� ��� ��������� 
class CMyPaintDC: public CPaintDC
{
public:
 CMyPaintDC(CWnd* pWnd);
 void DrawHead();
 void DrawLineMath(double x1,double x2,double y1,double y2);
 void DrawLineRecur(double x1,double x2,double y1,double y2);
 void DrawLineBrezen(int x1,int x2,int y1,int y2);
 void DrawLineVu(double x1,double x2,double y1,double y2);
};

//����� �������� ����
class CMyMainWnd : public CFrameWnd
{
CMenu m_wndMenu;
bool Go;
int mouseDown;

int grad;
int iNumofline;
int iSpace;
public:
CMyMainWnd(); // ����������� �� ��������
DECLARE_MESSAGE_MAP();
afx_msg void OnMouseMove(UINT nFlags, CPoint point);
afx_msg void OnLButtonDown( UINT, CPoint ); 
afx_msg void OnLButtonUp( UINT, CPoint );
afx_msg void OnKeyDown( UINT, UINT, UINT );
afx_msg void OnTimer( UINT );
//������� ����
void MenuEXIT();
void MenuHelp();
void MenuChangeGrad();
void MenuChangeNumof();

//���������
void OnPaint();
};

//����� �������
class CMyDialog : public CDialog
{
public:
	CMyDialog( UINT nIDTemplate,CWnd* pParentWnd = NULL);
	virtual BOOL OnInitDialog();
	virtual void OnOK();	
    afx_msg void edit_grad();
	afx_msg void edit_numof();
	afx_msg void edit_space();
	int get_grad();
	int get_numof();
	int get_space();
	void set_gns(int grad, int num, int space);

	void CreateModelessDialog(char *Name);

private:
	DECLARE_MESSAGE_MAP();
	char ch1[10];
    int grad;
	int numof;
	int space;
};
//����� ����������
class CMyApp : public CWinApp
{
public:
CMyApp(); // ����������� �� ���������
virtual BOOL InitInstance(); // ����������� �������������
};
