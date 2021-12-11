#-------------------------------------------------
#
# Project created by QtCreator 2012-02-16T21:06:24
#
#-------------------------------------------------

QT       += core gui

TARGET = gears
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    glwidget.cpp

HEADERS  += mainwindow.h \
    glwidget.h

QT += opengl
LIBS += glut32.lib
