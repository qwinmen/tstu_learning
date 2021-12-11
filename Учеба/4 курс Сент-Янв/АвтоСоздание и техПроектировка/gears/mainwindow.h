#ifndef MAINWINDOW_H
 #define MAINWINDOW_H

 #include <QMainWindow>
 #include <QRadioButton>

 class QAction;
 class QLabel;
 class QMenu;
 class QScrollArea;
 class QSlider;
 class GLWidget;
 class QTextEdit;

 class MainWindow : public QMainWindow
 {
     Q_OBJECT

 public:
     MainWindow();

 public slots:

     void touch(bool value);

 private slots:

     void about();
     void value_trancleted(int value);
     void value_rotation(int value);

 private:

     void createActions();
     void createMenus();

     QRadioButton * automatically;
     QRadioButton * manually;

     QSlider * slider_rotation;
     QSlider * slider_trancleted;

     QScrollArea * glWidgetArea;

     GLWidget * glWidget;

     QTextEdit * m_textEdit;
     QTextEdit * slader_textEdit;

     QLabel * m_big;
     QLabel * m_trancleted;

     QMenu * fileMenu;
     QMenu * helpMenu;

     QAction * exitAct;
     QAction * aboutAct;

     int trancleted, rotat;

     bool contact;

 signals:

    void trancletedSignal(int value);
    void rotationSignal(int value);

 };

 #endif
