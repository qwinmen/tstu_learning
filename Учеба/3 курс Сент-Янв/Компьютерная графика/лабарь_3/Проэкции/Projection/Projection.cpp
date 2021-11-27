// Projection.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Projection.h"
#include <stdlib.h>
#include <winbase.h >
#include <stdio.h>
#include <string.h>
#include <math.h>
#include <fstream>

using namespace std;

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								
TCHAR szTitle[MAX_LOADSTRING];					
TCHAR szWindowClass[MAX_LOADSTRING];
const double pi = acos(-1.0);

int xc,yc; 
PVERGE hverge;
PVertex hv;
PSIDE hs;
PVT hsv;
stMatrix m[6], mcur; 
char str[200] = "in.txt";
int checked[2] = {IDC_RADIO1, IDC_RADIO5};

HWND hMainWnd;

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	Change(HWND, UINT, WPARAM, LPARAM);

void drawBody (HWND, HDC);
void drawSide (int n, int c, int * s);
void drawVerge (Point a, Point b, bool visible);
bool isVisible (PSIDE s);
Vect getVertex (int n);
void readData (char *);
void makeMatrix (void);
PVERGE isEqVerge (int vert1, int vert2);
void makeVerges (void);
void rotate(void);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_PROJECTION, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_PROJECTION));

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_PROJECTION));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(7);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_PROJECTION);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	RECT rect;
	PAINTSTRUCT ps;
	HDC hdc;
	switch (message)
	{
	case WM_CREATE:{
		
		readData(str);
		makeVerges();

		makeMatrix();

		GetClientRect(hWnd, &rect);
		xc = rect.right / 2;
		yc = rect.bottom / 2;
		//rotate();
				   
		break;
				   }
	case WM_SIZE:{
		GetClientRect(hWnd, &rect);
		xc = rect.right/2;
		yc = rect.bottom/2;
		break;
				 }
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case ID_HELP_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case ID_VIEW_CHANGE:
			hMainWnd = hWnd;
			DialogBox(hInst, MAKEINTRESOURCE(IDD_CHANGE), hWnd, Change);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:{
		hdc = BeginPaint(hWnd, &ps);
		drawBody(hWnd, hdc);
		EndPaint(hWnd, &ps);
		ReleaseDC(hWnd, hdc);
		break;
				  }
	case WM_DESTROY:{
		
		PostQuitMessage(0);
		break;
					}
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}


// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
INT_PTR CALLBACK Change(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		CheckRadioButton(hDlg,IDC_RADIO1, IDC_RADIO4,checked[0]);
		CheckRadioButton(hDlg,IDC_RADIO5, IDC_RADIO7,checked[1]);
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		switch (LOWORD(wParam)) {
			case IDCANCEL:
			{
				EndDialog(hDlg, LOWORD(wParam));
				return (INT_PTR)TRUE;
			}
			case IDC_RADIO1:
			case IDC_RADIO2:
			case IDC_RADIO3:
			case IDC_RADIO4:
				checked[0] = LOWORD(wParam);
				return (INT_PTR)TRUE;
			case IDC_RADIO5:
			case IDC_RADIO6:
			case IDC_RADIO7:
				checked[1] = LOWORD(wParam);
				return (INT_PTR)TRUE;

			case IDOK:
			{
				if(checked[0] == IDC_RADIO1) mcur = m[checked[1]-IDC_RADIO2];
				else mcur = m[checked[0]-IDC_RADIO2]*m[checked[1]-IDC_RADIO2];
				HDC hdc = GetDC(hMainWnd);
				drawBody(hMainWnd, hdc);
				ReleaseDC(hMainWnd, hdc);
				EndDialog(hDlg, LOWORD(wParam));
				return (INT_PTR)TRUE;
			}
		}
		break;
		
	}
	return (INT_PTR)FALSE;
}
void rotate () {

	Vect v1;
	PVertex cv;

	cv = hv;
	do {
		v1.VertexToVect(*cv);
		v1 = v1 * mcur;
		cv->x = v1.v[0];
		cv->y = v1.v[1];
		cv->z = v1.v[2];
		cv = cv->next;
	} while (cv);
}
Vect getVertex (int n) {

	int i;
	PVertex cv;
	Vect p;

	cv = hv;
	for (i = 1; i < n; i++) cv = cv->next;
	p.VertexToVect(*cv);
	return p;
}
bool isVisible (PSIDE side) {

	PVT csv;
	double ret;
	Vect a, b, c;

	csv = side->w;
	a = getVertex (csv->v); a = a * mcur;

	csv = csv->next;
	b = getVertex (csv->v); b = b * mcur;

	csv = csv->next;
	c = getVertex (csv->v); c = c * mcur;

	ret = (b.v[0] - a.v[0]) * (c.v[1] - a.v[1]) - (c.v[0] - a.v[0]) * (b.v[1] - a.v[1]);

	return (ret > 0);
}
void makeMatrix(){
	
	ifstream in;
	in.open("matrix.txt", ios::in);
	if(!in) return;
	
	for (int i=0; i < 6; i++) in >> m[i];
	in.close();
	mcur = m[3];
}
void drawBody (HWND hWnd, HDC hdc) {

	PVERGE pverge;
	Vect v1, v2;
	HPEN hOldPen, hPen;
	RECT rect;
    HBITMAP frame;
    HDC mem;
    GetClientRect(hWnd, &rect);
    mem=CreateCompatibleDC(hdc);
    frame=CreateCompatibleBitmap(hdc, rect.right-rect.left, rect.bottom-rect.top);
    SelectObject(mem, frame);

	HBRUSH hBrush = CreateSolidBrush(RGB(0,0,0));
	HBRUSH hOldBrush = (HBRUSH)SelectObject(mem, (HGDIOBJ)hBrush);
	
	Rectangle(mem,rect.left, rect.top, rect.right, rect.bottom);
	SelectObject(mem, hOldBrush);
	DeleteObject(hBrush);

	hPen = CreatePen(PS_SOLID, 1, RGB(0,127,0));		
	hOldPen = (HPEN)SelectObject(mem, (HGDIOBJ)hPen);
	pverge = hverge;
	while (pverge != NULL) {

        v1 = getVertex(pverge->v1);
		v2 = getVertex(pverge->v2);

		if (!isVisible(pverge->ps1) && !isVisible(pverge->ps2)) {
			v1 = v1 * mcur;v2 = v2 * mcur;
			MoveToEx(mem, int(xc + v1.v[0]), int(yc + v1.v[1]), NULL);
			LineTo(mem, int(xc + v2.v[0]), int(yc + v2.v[1]));
		}
		pverge = pverge->next;
	}
	SelectObject(mem, hOldPen);
	DeleteObject(hPen);

	hPen = CreatePen(PS_SOLID, 1, RGB(0,255,0));		
	hOldPen = (HPEN)SelectObject(mem, (HGDIOBJ)hPen);
	pverge = hverge;
	while (pverge != NULL) {

        v1 = getVertex(pverge->v1);
		v2 = getVertex(pverge->v2);

		if (isVisible(pverge->ps1) || isVisible(pverge->ps2)) {
			v1 = v1 * mcur;v2 = v2 * mcur;
			MoveToEx(mem, int(xc + v1.v[0]), int(yc + v1.v[1]), NULL);
			LineTo(mem, int(xc + v2.v[0]), int(yc + v2.v[1]));
		}
		pverge = pverge->next;
	}
	SelectObject(mem, hOldPen);
	DeleteObject(hPen);
	
	BitBlt(hdc, 0, 0, rect.right-rect.left, rect.bottom-rect.top, mem, 0, 0, SRCCOPY);
    DeleteDC(mem);
    DeleteObject(frame);
}

void readData ( char * str) {

	int i, j, k;

	PVertex cv, lv;
	PSIDE cs, ls;
	PVT csv, lsv;
	
	ifstream in;
	in.open(str, ios::in);
	if(!in) return;
	
	in >> k;

	cv = (PVertex)malloc (sizeof(Vertex));
	cv->next = NULL;

	hv = lv = cv;

	in >>(cv->x)>> (cv->y)>> (cv->z);

	for (i = 1; i < k; i++) {

		cv = (PVertex)malloc(sizeof(Vertex));

		in >> (cv->x)>> (cv->y)>> (cv->z);
		cv->next = NULL;
		lv->next = cv;
		lv = cv;
	}
	in>>k;

	cs = (PSIDE)malloc(sizeof(SIDE));
	cs->next = NULL;
	hs = ls = cs;
	
	in >>(cs->color)>> (cs->n);

	csv = (PVT)malloc(sizeof(VT));
	cs->w = csv;
	lsv = csv;
	csv->next = NULL;

	
	in >> (csv->v);
	for (j = 1; j < cs->n; j++) {

		csv = (PVT)malloc(sizeof(VT));
	
		in >> (csv->v);
		csv->next = NULL;
		lsv->next = csv;
		lsv = csv;
	}

	for (i = 1; i < k; i++) {

		cs = (PSIDE) malloc (sizeof(SIDE));
	
		in >> (cs->color)>> (cs->n);

		csv = (PVT)malloc(sizeof(VT));
		cs->w = csv;
		lsv = csv;
		csv->next = NULL;

		in >> (csv->v);

		for (j = 1; j < cs->n; j++) {

			csv = (PVT)malloc(sizeof(VT));
			lsv->next = csv;
			lsv = csv;
			csv->next = NULL;

			in >>(csv->v);
		}

		cs->next = NULL;
		ls->next = cs;
		ls = cs;
	}
	in.close();
	
}

PVERGE isEqVerge (int vert1, int vert2) {

	PVERGE t;

	t = hverge;
	while (t != NULL) {

		if (t->v1 == vert1 && t->v2 == vert2 || t->v1 == vert2 && t->v2 == vert1) return t;
		t = t->next;
	}
	return NULL;
}
void makeVerges (void) {

	PSIDE pside;
	PVT pvertex;
	PVERGE pverge, newverge, tempPVerge;
	int firstvx, n1, n2;

	pside = hs;

	while (pside != NULL)  {

		pvertex = pside->w;
		n1 = firstvx = pvertex->v;
		

		while (pvertex -> next != NULL) {

		       	n1 = pvertex->v;
			n2 = (pvertex->next)->v;
			pverge = isEqVerge (n1, n2);
			if (pverge != NULL) {
				pverge->ps2 = pside;
				
			}
			else {
				newverge = (PVERGE)malloc(sizeof(VERGE));
				newverge->v1 = n1;
				newverge->v2 = n2;
				newverge->ps1 = pside;
				newverge->next = NULL;
				if (hverge == NULL) hverge = newverge;
				else {

					tempPVerge = hverge;
					while (tempPVerge->next != NULL) tempPVerge = tempPVerge->next;
					tempPVerge ->next = newverge;
				}
			}
			pvertex = pvertex->next;
		}
		n2 = pvertex->v;
		n1 = firstvx;

		pverge = isEqVerge (n1, n2);
		if (pverge != NULL) {
			pverge->ps2 = pside;
			
		}
		else {
			newverge = (PVERGE)malloc(sizeof(VERGE));
			newverge->v1 = n1;
			newverge->v2 = n2;
			newverge->ps1 = pside;
			newverge->next = NULL;
			if (hverge == NULL) hverge = newverge;
			else {
				tempPVerge = hverge;
				while (tempPVerge->next != NULL) tempPVerge = tempPVerge->next;
				tempPVerge ->next = newverge;
			}
		}

		pside = pside -> next;
	}
}
