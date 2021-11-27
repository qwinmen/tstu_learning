#include "MyClassesDeclarations.h"

CMyApp::CMyApp() // конструктор главного класса приложени€
{}

BOOL CMyApp::InitInstance() // стандартна€ инициализаци€
{ 
m_pMainWnd=new CMyMainWnd();
ASSERT(m_pMainWnd);
m_pMainWnd->ShowWindow(SW_SHOW); // ѕоказать окно
m_pMainWnd->UpdateWindow(); // ќбновить окно
return TRUE; // ¬ернуть что все нормально 
};

CMyApp theApp; // запуск приложени€