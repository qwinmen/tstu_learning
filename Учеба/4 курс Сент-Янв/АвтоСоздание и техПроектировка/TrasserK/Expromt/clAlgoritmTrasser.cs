using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Expromt
{
    /// <summary>
    /// Описана логика построения маршрута
    /// </summary>
    class clAlgoritmTrasser
    {
        public clAlgoritmTrasser()
        {
        }

        public clAlgoritmTrasser(int str, int stol)
        {
            if (str == _strCount && stol == _stolCount) return;//если ширина высота теже, то нафик
            //иначе надо изменить размеры поля, но не затронув уже расположенные обьекты

            _strCount = str > _strCount? str: _strCount;//если надо расширить то ОК, иначе небудем уменьшать!
            _stolCount = stol > _stolCount? stol : _stolCount;

            _strAllMarshruts = _strCount+1;//возможно +1
            _stolAllMarshruts = _stolCount+1;//возможно +1
            
            if (_pole == null)
            {//если первый раз то инициализируем
                _pole = new Pole[_strCount, _stolCount];
                _AllMarshruts = new int[_strAllMarshruts, _stolAllMarshruts];
            }
            else
            {//иначе расширить уже со3данный
                var tmp = new Pole[_strCount, _stolCount];//расширеный//в него скопировать из старого
                for (int i = 0; i < _stolCount; i++)
                {
                    for (int j = 0; j < _strCount; j++)
                    {
                        if (i < _pole.GetUpperBound(0) && j < _pole.GetUpperBound(1))
                            tmp[i, j] = _pole[i, j];
                    }
                }
                _pole = tmp;

                //Так как AllMarshruts немного шире и выше чем _pole[,] то выносим в отдельный цикл
                var tmpM = new int[_strAllMarshruts, _stolAllMarshruts];
                for (int i = 0; i < _stolAllMarshruts; i++)
                {
                    for (int j = 0; j < _strAllMarshruts; j++)
                    {
                        if (i < _AllMarshruts.GetUpperBound(0) && j < _AllMarshruts.GetUpperBound(1))
                            tmpM[i, j] = _AllMarshruts[i, j];
                    }
                }
                _AllMarshruts = tmpM;
            }
            
        }

        /// <summary>
        /// Поместить на поле компонент из тулбара
        /// </summary>
        /// <param name="location"></param>
        /// <param name="iter"></param>
        /// <param name="component"></param>
        public void PoleSetComponent(Point location, int iter, Pole component)
        {
            //Вычислить квадрат по локации
            int i = 0, j = 0;
            for (int strLoc = 0; i < 2000 ; i++, strLoc+=iter)//какой столбец?
                if (strLoc == location.X) break;
            for (int strLoc = 0; j < 2000 ; j++, strLoc += iter)//строка
                if (strLoc == location.Y) break;
            if(i==2000 && j==2000) return;//за пределы не обрабатывать
            //и установить туда компонент
            _pole[i, j] = component;
            _pole[i+1, j] = component;
            _pole[i, j+1] = component;
            _pole[i+1, j + 1] = component;
        }

        /// <summary>
        /// Полностью очистить поле
        /// </summary>
        public void PoleClear()
        {
            _pole = new Pole[_strCount,_stolCount];
            _AllMarshruts = new int[_strAllMarshruts, _stolAllMarshruts];
            PMarshrut = null;
        }
        /// <summary>
        /// Количество колонок
        /// </summary>
        private static int _strCount = 0;
        /// <summary>
        /// Количество строчек
        /// </summary>
        private static int _stolCount = 0;
        /// <summary>
        /// Количество колонок
        /// </summary>
        private static int _strAllMarshruts = 0;
        /// <summary>
        /// Количество строчек
        /// </summary>
        private static int _stolAllMarshruts = 0;
        /// <summary>
        /// 1 говорит о линии\\0 говорит об открытой трассе
        /// </summary>
        private static int[,] _AllMarshruts;
        //поле с количеством квадратов sCount*lCount
        /// <summary>
        /// _pole[столбцов, строк]
        /// </summary>
        private static Pole[,] _pole;
        /// <summary>
        /// Точка начала трассы panelA.location
        /// </summary>
        public Point PStart { get; private set; }
        /// <summary>
        /// Направления up\dw\lf\rf
        /// </summary>
        public string[] PMarshrut { get; private set; }

        /// <summary>
        /// Принимает два обьекта для построения маршрута
        /// </summary>
        /// <param name="comA">всегда - Начало</param>
        /// <param name="comB">Конец</param>
        public void Algoritm(ClassLibraryBevelLebel.BevelLebel comA, ClassLibraryBevelLebel.BevelLebel comB)
        {
            if(comA==null)return;
            //либо подсвечивать трассу по квадратам iter*iter, или рисовать линию по центру
            /*+Для построения нужна карта поля, 
             * +на которой нанесены расположеные обьекты, 
             * +на которой нанесены препятствия (обьекты или преобразовывать backgr-image панели в препятствия)
             * +на которой хранятся построеные маршруты [начало\направления] PMarshrut
             * +Метод Очистки карты полностью
             * Заполнить обьекты PStart\PMarshrut
            */

            /*
             Даша
1. создаешь переменную, минимальная длина.
2. от блока 1 идешь на один шаг вправо, а потом спускаешься вниз до переменной У блока 2. и от нее идешь до X блока 2, если встречаешь препятствие, обходишь сверху, и идешь дальше.
3. дошел первый раз, в минимальную длину сохраняешь, то сколько ты шел
4. делаешь все тоже самое, только препятсвие обходишь снизу, если минимальная длина в любой момент превышает ту, по которой ты сейчас идешь, то бросаешь это
5. аналогично делаешь, только вызодишь не из правого края, а с низу
6. потом слева
7. ну и сверху
             */

            PStart = comA.Location;
            var tmpM = new List<string>();
            var pointA = SearchElement(comA);//найти элемент 1
            var pointB = SearchElement(comB);//найти элемент 2

            //Заполнить командами//tmpM.Add("lf"); tmpM.Add("lf"); tmpM.Add("lf"); tmpM.Add("up");
            
            //Проверять открытость пути из двух источников:
            //_pole[,] - наличие\нет стенок и компонентов из тулбара
            //_AllMarshruts[,] - наличие\нет линий построеных маршрутов между компонентами
            var locTmpVar = new Point(0,0);//следим путь по ячейкам
            //2. от блока 1 идешь на один шаг вправо
            {
                tmpM.Add("rf"); tmpM.Add("rf");
                _AllMarshruts[pointA.X + 1, pointA.Y + 1] = 1;//Установлена точка старта PStart
                _AllMarshruts[pointA.X + 2, pointA.Y + 1] = 1;//вправо
                _AllMarshruts[pointA.X + 3, pointA.Y + 1] = 1;//вправо
                locTmpVar = new Point(pointA.X + 3, pointA.Y + 1);
            }

            //а потом спускаешься вниз до переменной У блока 2.
            {
                while (pointB.Y > pointA.Y)
                {//если блок 2 ниже чем 1
                    tmpM.Add("dw");
                    pointA.Y += 1; locTmpVar.Y += 1;
                    _AllMarshruts[locTmpVar.X, locTmpVar.Y] = 1;
                    locTmpVar = new Point(locTmpVar.X, locTmpVar.Y);
                }
                while (pointB.Y < pointA.Y)
                {//если блок 2 выше чем 1
                    tmpM.Add("up");
                    pointA.Y -= 1; locTmpVar.Y -= 1;
                    _AllMarshruts[locTmpVar.X, locTmpVar.Y] = 1;
                    locTmpVar = new Point(locTmpVar.X, locTmpVar.Y);
                }
                //если блок 2 на одном уровне с 1 или опустились\поднялись до уровня блока 2
            }

            // и от нее (locTmpVar) идешь до X блока 2, //если встречаешь препятствие, обходишь сверху, и идешь дальше.
            {
                while (pointB.X > locTmpVar.X)
                {//блок 2 расположен правее 1 по Х
                    if (StopHam(new Point(locTmpVar.X+1, locTmpVar.Y)) == false)//пробуем сделать шаг в право
                        locTmpVar.X += 1;
                    else
                    {//обходишь сверху//Пытаемся найти свободную клетку выше\справо
                        //1.выше можно? НЕТ - то закрыты направления ВЕРХ и ВПРАВО ||пробуем НИЗ и ВПРАВО
                        //2.ДА - подымаемтя
                        //3.вправо можно? НЕТ - подымаемся ПОКА(вправо можно ИЛИ достигли грани массива(то закрыты направления ВЕРХ и ВПРАВО))
                        //4.ДА - идем
                        var seredina = locTmpVar;//храним координату разветвления ВЕРХ/НИЗ
                        var flagSeredina = false;

                        if(Up(locTmpVar))//1.
                        {//2.
                            tmpM.Add("up");//клетка свободна, подымаемся
                            locTmpVar.Y -= 1;
                            flagSeredina = true;
                            while (!Right(locTmpVar))//3.
                            {
                                if (Up(locTmpVar))
                                {
                                    tmpM.Add("up");//клетка свободна, подымаемся
                                    locTmpVar.Y -= 1;
                                    flagSeredina = true;
                                }
                                else
                                {//за границей поля!Тогда лезем ВНИЗ
                                    //обходишь снизу//Пытаемся найти свободную клетку ниже\справо
                                    //5.ниже можно? НЕТ - то закрыты направления НИЗ и ВПРАВО ||пробуем //2. от блока 1 идешь на один шаг вниз
                                    //6.ДА - опускаемся
                                    //7.вправо можно? НЕТ - опускаемся ПОКА(вправо можно ИЛИ достигли грани массива(то закрыты направления ВНИЗ и ВПРАВО))
                                    //8.ДА - идем
                                    locTmpVar.Y = flagSeredina ? seredina.Y : locTmpVar.Y;
/*NOTE*/    if(Down(locTmpVar))//5.
                                    {//6.
                                        tmpM.Add("dw");//клетка свободна, опускаемся
                                        locTmpVar.Y += 1;
                                        flagSeredina = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show(
                                            "5.ниже можно? НЕТ - то закрыты направления НИЗ и ВПРАВО ||пробуем //2. от блока 1 идешь на один шаг вниз");
                                    }
                                }
                                
                            }
                            //4.ДА - идем//8.
                        }
                        else
                        {
                            Down(locTmpVar);
                        }
                        
                    }
                    tmpM.Add("rf");
                    _AllMarshruts[locTmpVar.X, locTmpVar.Y] = 1;
                    locTmpVar = new Point(locTmpVar.X, locTmpVar.Y);
                }

                while (pointB.X < locTmpVar.X)
                {//блок 2 расположен левее 1 по Х
                    if (StopHam(new Point(locTmpVar.X - 1, locTmpVar.Y)) == false)
                        locTmpVar.X -= 1;
                    else
                    {//обходишь сверху
                        locTmpVar.X -= 1;
                        
                    }
                    tmpM.Add("lf");
                    _AllMarshruts[locTmpVar.X, locTmpVar.Y] = 1;
                    locTmpVar = new Point(locTmpVar.X, locTmpVar.Y);
                }
                //если блок 2 расположен под 1 по Х

                
            }

            








            PMarshrut = new string[tmpM.Count];// { "up", "up", "lf", "lf", "lf", "lf", "dw", "lf", "lf", };
            var i = 0;
            foreach (var str in tmpM)
            {
                PMarshrut[i] = str;
                i++;
            }
        }

        /// <summary>
        /// Пробуем cпустится ниже
        /// true = можно спустится
        /// </summary>
        /// <returns>true = можно спустится</returns>
        private bool Down(Point locTmpVar)
        {
            if (StopHam(new Point(locTmpVar.X, locTmpVar.Y + 1)) == false)
            {
                return true;
            }
            else
            {//инач клетка ниже закрытa
                MessageBox.Show("Направление НИЗ закрыто");
                return false;
            }

        }

        /// <summary>
        /// Пробуем поднятся выше
        /// true = можно поднятся
        /// </summary>
        /// <returns>true = можно поднятся</returns>
        private bool Up(Point locTmpVar)
        {
            //пробуем поднятся
            if (StopHam(new Point(locTmpVar.X, locTmpVar.Y - 1)) == false)
            {
                return true;
            }
            else
            {//инач клетка выше закрытa
                MessageBox.Show("Направление ВЕРХ закрыто");
                return false;
            }

            return false;
        }

        /// <summary>
        /// Пробуем пойти вправо
        /// true = можно вправо
        /// </summary>
        /// <returns>true = можно вправо</returns>
        private bool Right(Point locTmpVar)
        {
            if (StopHam(new Point(locTmpVar.X + 1, locTmpVar.Y)) == false)//опять пробуем вправо
                return true;
            else return false;
        }

        /// <summary>
        /// Проверка текущего щага на преграды//или идем по своему же пути
        /// </summary>
        /// <param name="tekLocTmpVar">Координаты ячейки в которую будем совершать шаг</param>
        /// <returns>Вернет true если по координате tekLocTmpVar есть препятствие</returns>
        private bool StopHam(Point tekLocTmpVar)
        {
            if (_AllMarshruts[tekLocTmpVar.X, tekLocTmpVar.Y] != 0)
                return true;//наткнулись на линию ИЛИ уже ходили этим маршрутом
            if (_pole[tekLocTmpVar.X, tekLocTmpVar.Y] != null && _pole[tekLocTmpVar.X, tekLocTmpVar.Y - 1] != null)
                return true;//наткнулись на обьект//если оба дают true --> то ломимся посередине
            if (_pole[tekLocTmpVar.X, tekLocTmpVar.Y] != null)
                return true;//наткнулись на обьект//--> то ломимся снизу в край (его задеваем)
            if ((tekLocTmpVar.Y - 1) < 0)
                return true;//вышли за границы массива и поля//--> типо закрываем направление
            if (_pole[tekLocTmpVar.X, tekLocTmpVar.Y - 1] != null)
                return true;//наткнулись на обьект//--> то ломимся сверху в край (его задеваем)
          //  if ((tekLocTmpVar.Y - 2) >= 0)
    /*-->*/ //     if (_pole[tekLocTmpVar.X, tekLocTmpVar.Y - 2] != null)
              //  return true;//для Down()-->Right()
            

            return false;
        }

        /// <summary>
        /// Метод проверки, NOTE: можно удалить
        /// </summary>
        /// <returns></returns>
        public int[,] GetAllMarshrut()
        {
            return _AllMarshruts;
        }

        /// <summary>
        /// Выполнить поиск элемента etalon в массиве _pole[,]
        /// </summary>
        /// <param name="etalon">Что искать в массиве?</param>
        /// <returns>Вернуть индекс найденого элемента [верхний левый]</returns>
        private Point SearchElement(ClassLibraryBevelLebel.BevelLebel etalon)
        {
            var ij = new Point(-2, -2);

            for (int j = 0; j < _stolCount; j++)
            {
                for (int f = 0; f < _strCount; f++)
                {
                    try
                    {
                        if(_pole[f, j]==null) continue;
                        var res = _pole[f, j].GetComponent();
                        if (res.NumLabel == etalon.NumLabel)
                            return new Point(f, j);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Ошибка в методе SearchElement(): " + e.Message);
                    }
                    
                }
            }
            return ij;
        }



    }

    internal class Pole
    {
        public Pole(ClassLibraryBevelLebel.BevelLebel bevelLebel)
        {
            //выступает в роли отдельной ячейки//типо BevelLebel
            _obj = bevelLebel;
        }

        private ClassLibraryBevelLebel.BevelLebel _obj { get; set; }

        public ClassLibraryBevelLebel.BevelLebel GetComponent()
        {
            return _obj;
        }


    }

    
}
