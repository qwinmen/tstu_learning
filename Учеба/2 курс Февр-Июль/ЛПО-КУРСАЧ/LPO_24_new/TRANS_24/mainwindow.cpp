#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "lexer.h"
#include "syntax.h"
#include <QDebug>
#include <QScrollBar>
#include <QRegExp>

QString generate_code()
{

}

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->plainTextEdit_2->setCenterOnScroll(true);

}

MainWindow::~MainWindow()
{
    delete ui;
}


// Генерация кода

void MainWindow::on_pushButton_clicked()
{
    QString code = ui->codeWindow->toPlainText();
    QString out = "";
    QString newcode = "";
    int result = compile(code, &out, &newcode);


    ui->plainTextEdit_2->setPlainText(out);
    ui->plainTextEdit_2->moveCursor(QTextCursor::End);
    ui->plainTextEdit_2->ensureCursorVisible();
    if(result >= 0){

        ui->resultWindow->setPlainText(newcode);

    }
    else
        ui->resultWindow->setPlainText(QString(""));
}
