#include <QtGui>
#include <QtOpenGL>
#include "glwidget.h"
#include "mainwindow.h"
#include <math.h>
#include <QLabel>
#include <QTextEdit>
#include <QWidget>
#include <QHBoxLayout>
#include <QAction>
#include <QMenu>
#include <QMenuBar>
#include <QFileDialog>
#include <QPixmap>
#include <QImage>
#include <QGroupBox>
#include <QPushButton>
#include <QTextCodec>
#include <QSlider>

MainWindow::MainWindow(){

    QWidget *widget = new QWidget;
    setCentralWidget(widget);
    QTextCodec::setCodecForTr(QTextCodec::codecForName("Windows-1251"));

    setWindowTitle(tr("������� ����������� ������ ������� �������� ��� � �������� �� �������� "));
    resize(600, 600);

    trancleted = 0.0;
    rotat = 0.0;

    glWidget = new GLWidget;
    glWidgetArea = new QScrollArea;
    glWidgetArea->setWidget(glWidget);
    glWidgetArea->setWidgetResizable(true);
    glWidgetArea->setHorizontalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setVerticalScrollBarPolicy(Qt::ScrollBarAlwaysOff);
    glWidgetArea->setSizePolicy(QSizePolicy::Ignored, QSizePolicy::Ignored);
    glWidgetArea->setFixedSize(580, 580);

    connect(this , SIGNAL(trancletedSignal(int)), glWidget, SLOT(trancletedGL(int)) );
    connect( glWidget , SIGNAL(touchingGears(bool)), this, SLOT(touch(bool)) );

    createActions();
    createMenus();

    automatically = new QRadioButton (tr("���������"));
    connect(automatically, SIGNAL(clicked()), glWidget, SLOT(automatical()) );

    manually = new QRadioButton(tr("����������"));
    connect(manually, SIGNAL(clicked()), glWidget, SLOT(manual()) );

    m_textEdit = new QTextEdit();
    m_textEdit->setFixedSize(300, 400);

    slider_rotation = new QSlider();
    slider_rotation->setValue(rotat);
    slider_rotation->setFocusPolicy(Qt::StrongFocus);
    slider_rotation->setTickPosition(QSlider::TicksBothSides);
    slider_rotation->setMinimum(1);
    slider_rotation->setMaximum(720);
    slider_rotation->setTickInterval(30);
    slider_rotation->setSingleStep(1);
    slider_rotation->setOrientation(Qt::Horizontal);
    connect(this , SIGNAL(rotationSignal(int)), glWidget, SLOT(rotation(int)) );

    slider_trancleted = new QSlider();
    slider_trancleted->setValue(trancleted);
    slider_trancleted->setFocusPolicy(Qt::StrongFocus);
    slider_trancleted->setTickPosition(QSlider::TicksBothSides);
    slider_trancleted->setMinimum(-5);
    slider_trancleted->setMaximum(0);
    slider_trancleted->setTickInterval(1);
    slider_trancleted->setSingleStep(1);
    slider_trancleted->setOrientation(Qt::Horizontal);

    m_big = new QLabel(tr("�������� ����������"));

    m_trancleted = new QLabel(tr("����������� ������� ����������"));
    m_trancleted->setText(QString(tr("����������� ������� ����������: %1")).arg(trancleted));

    connect(slider_trancleted, SIGNAL(valueChanged(int)), this, SLOT(value_trancleted(int)));
    connect(slider_rotation, SIGNAL(valueChanged(int)), this, SLOT(value_rotation(int)));

    QVBoxLayout *radioLayout = new QVBoxLayout;
    radioLayout->addWidget(automatically);
    radioLayout->addWidget(manually);

    QVBoxLayout *sliderLayout = new QVBoxLayout;
    sliderLayout->addLayout(radioLayout);
    sliderLayout->addWidget(m_big);
    sliderLayout->addWidget(slider_rotation);
    sliderLayout->addWidget(m_trancleted);
    sliderLayout->addWidget(slider_trancleted);
    sliderLayout->addWidget(m_textEdit);
    sliderLayout->addStretch();

    QHBoxLayout *centralLayout = new QHBoxLayout;
    centralLayout->addWidget(glWidgetArea);
    centralLayout->addStretch(1);
    centralLayout->addLayout(sliderLayout);

    centralWidget()->setLayout( centralLayout);

}

void MainWindow::touch(bool value){
    m_textEdit->clear();
    contact = value;
    if (contact == true)
        m_textEdit->append(QString(tr("������� ���������� ����������")));
    else
        m_textEdit->append(QString(tr("������� ���������� �� ����������")));

}

void MainWindow::value_trancleted(int value){

    trancleted  = value;
    emit trancletedSignal(value);
    m_trancleted->setText(QString(tr("����������� ������� ����������: %1")).arg(trancleted));

}

void MainWindow::value_rotation(int value){

    rotat  = value;
    emit rotationSignal(value);

}

void MainWindow::about(){

    QMessageBox::about(this,tr("���������� ����������"), tr("��������� ������������� ��� ������� ����������� ������ ������� �������� ��� � �������� �� ��������,  �� ������� ����������.  ������������ ����� ����������� ������� � ���������� ����������, � ��� �� ������������� � ������ ��������� ������� ��������.  ����������� ������ ��������� �������� ��������� � �������."));

}

void MainWindow::createActions(){

    exitAct = new QAction(tr("&�����"), this);
    exitAct->setShortcuts(QKeySequence::Quit);
    connect(exitAct, SIGNAL(triggered()), this, SLOT(close()));

    aboutAct = new QAction(tr("&�������"), this);
    connect(aboutAct, SIGNAL(triggered()), this, SLOT(about()));

}

void MainWindow::createMenus(){

    fileMenu = menuBar()->addMenu(tr("&����"));
    fileMenu->addSeparator();
    fileMenu->addAction(exitAct);

    helpMenu = menuBar()->addMenu(tr("&�������"));
    helpMenu->addAction(aboutAct);

}


