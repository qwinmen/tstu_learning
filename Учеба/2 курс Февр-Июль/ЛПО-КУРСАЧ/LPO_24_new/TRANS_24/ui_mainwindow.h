/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created: Thu 22. May 00:04:30 2014
**      by: Qt User Interface Compiler version 4.6.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QMainWindow>
#include <QtGui/QMenuBar>
#include <QtGui/QPlainTextEdit>
#include <QtGui/QPushButton>
#include <QtGui/QStatusBar>
#include <QtGui/QToolBar>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QPlainTextEdit *codeWindow;
    QLabel *label;
    QPlainTextEdit *resultWindow;
    QLabel *label_2;
    QPlainTextEdit *plainTextEdit_2;
    QPushButton *pushButton;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(709, 537);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        codeWindow = new QPlainTextEdit(centralWidget);
        codeWindow->setObjectName(QString::fromUtf8("codeWindow"));
        codeWindow->setGeometry(QRect(10, 30, 281, 291));
        label = new QLabel(centralWidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(10, 10, 201, 16));
        resultWindow = new QPlainTextEdit(centralWidget);
        resultWindow->setObjectName(QString::fromUtf8("resultWindow"));
        resultWindow->setGeometry(QRect(390, 30, 281, 291));
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(390, 10, 101, 16));
        plainTextEdit_2 = new QPlainTextEdit(centralWidget);
        plainTextEdit_2->setObjectName(QString::fromUtf8("plainTextEdit_2"));
        plainTextEdit_2->setEnabled(true);
        plainTextEdit_2->setGeometry(QRect(10, 330, 661, 151));
        QFont font;
        font.setPointSize(8);
        plainTextEdit_2->setFont(font);
        pushButton = new QPushButton(centralWidget);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(300, 300, 81, 22));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QString::fromUtf8("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 709, 19));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QString::fromUtf8("statusBar"));
        MainWindow->setStatusBar(statusBar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", 0, QApplication::UnicodeUTF8));
        codeWindow->setPlainText(QApplication::translate("MainWindow", "\320\277\321\200\320\276\320\263\321\200\320\260\320\274\320\274\320\260 \320\220;\n"
"    \320\277\320\265\321\200\320\265\320\274\320\265\320\275\320\275\321\213\320\265 k:\321\206\320\265\320\273\321\213\320\265;\n"
"    t, eps, sx, s:\320\262\320\265\321\211\320\265\321\201\321\202\320\262\320\265\320\275\320\275\321\213\320\265;\n"
"\320\275\320\260\321\207\320\260\320\273\320\276\n"
"\321\207\320\270\321\202\320\260\321\202\321\214(eps, sx);\n"
"s=0; k=1; t=1;\n"
"\320\277\320\276\320\272\320\260 |t| > eps \320\262\321\213\320\277\320\276\320\273\320\275\321\217\321\202\321\214\n"
"{\n"
"k:=k+2;\n"
"t:=-t*sx/(k*(k-1));\n"
"s:=s+t };\n"
"\320\262\321\213\320\262\320\265\321\201\321\202\320\270(k)\n"
"\320\272\320\276\320\275\320\265\321\206.\n"
"", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("MainWindow", "\320\230\321\201\321\205\320\276\320\264\320\275\321\213\320\271 \320\272\320\276\320\264", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("MainWindow", "\320\240\320\265\320\267\321\203\320\273\321\214\321\202\320\260\321\202", 0, QApplication::UnicodeUTF8));
        pushButton->setText(QApplication::translate("MainWindow", "\320\237\321\203\321\201\320\272", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
