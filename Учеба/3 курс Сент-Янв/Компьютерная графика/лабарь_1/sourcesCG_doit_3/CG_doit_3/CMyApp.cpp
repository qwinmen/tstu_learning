#include "MyClassesDeclarations.h"

CMyApp::CMyApp() // ����������� �������� ������ ����������
{}

BOOL CMyApp::InitInstance() // ����������� �������������
{ 
m_pMainWnd=new CMyMainWnd();
ASSERT(m_pMainWnd);
m_pMainWnd->ShowWindow(SW_SHOW); // �������� ����
m_pMainWnd->UpdateWindow(); // �������� ����
return TRUE; // ������� ��� ��� ��������� 
};

CMyApp theApp; // ������ ����������