#ifndef GLWIDGET_H
 #define GLWIDGET_H

 #include <QGLWidget>
 #include <QTimer>
 class GLWidget : public QGLWidget{
     Q_OBJECT

 public:
     GLWidget(QWidget *parent = 0);
     ~GLWidget();

     int xRotation() const { return xRot; }
     int yRotation() const { return yRot; }
     int zRotation() const { return zRot; }

 public slots:

     void setXRotation(int angle);
     void setYRotation(int angle);
     void setZRotation(int angle);
     void trancletedGL(int tvalue);
     void rotation(int tvalue);
     void touching(int trancleted);

 signals:

     void xRotationChanged(int angle);
     void yRotationChanged(int angle);
     void zRotationChanged(int angle);
     void touchingGears(bool tvalue);

 protected:

     void initializeGL();
     void paintGL();
     void resizeGL(int width, int height);
     void mousePressEvent(QMouseEvent *event);
     void mouseMoveEvent(QMouseEvent *event);

 private slots:

     void advanceGears();
     void automatical();
     void manual();

 private:

     GLuint makeGear(const GLfloat *reflectance, GLdouble innerRadius, GLdouble outerRadius, GLdouble thickness, GLdouble toothSize, GLint toothCount);
     void drawGear(GLuint gear, GLdouble dx, GLdouble dy, GLdouble dz, GLdouble angle);
     void normalizeAngle(int *angle);

     QTimer * timer_stop;
     QTimer * timer;

     GLuint gear1;
     GLuint gear2;
     GLuint gear3;

     int xRot;
     int yRot;
     int zRot;

     int gear1Rot;

     int trancleted;
     int rotat;

     GLdouble radiusBig;
     GLdouble radiuSmall;
     GLdouble toothsizeBig;
     GLdouble toothsizeSmall;
     GLdouble z;

     bool contact;
     QPoint lastPos;
 };

 #endif
