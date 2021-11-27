using System;
using System.Collections.Generic;
using System.Drawing;

namespace Шахматы
{
    class clNewGame
    {
        private clFigure[,] figure = new clFigure[8,8];
        
        public clNewGame()
        {
            Restart();
        }

        /*
        __0_1_2_3_4_5_6_7__
        0|1 2 3 5 4 3 2 1|8
        1|0 0 0 0 0 0 0 0|7
        2|				 |6
        3|				 |5
        4|				 |4
        5|				 |3
        6|0 0 0 0 0 0 0 0|2
        7|1 2 3 5 4 3 2 1|1
        __a_b_c_d_e_f_g_h__
        */
        /// <summary>
        /// Сбросить на начальные позиции фигуры в МАССИВЕ
        /// </summary>
        private void Restart()
        {//СТРОКА\\СТОЛБЕЦ
            var WP10 = new clFigure("БЕЛ_ПЕШКА_A7"); var WP11 = new clFigure("БЕЛ_ПЕШКА_B7");
            var WP12 = new clFigure("БЕЛ_ПЕШКА_C7"); var WP13 = new clFigure("БЕЛ_ПЕШКА_D7");
            var WP14 = new clFigure("БЕЛ_ПЕШКА_E7"); var WP15 = new clFigure("БЕЛ_ПЕШКА_F7");
            var WP16 = new clFigure("БЕЛ_ПЕШКА_G7"); var WP17 = new clFigure("БЕЛ_ПЕШКА_H7");

            var WL00 = new clFigure("БЕЛ_ЛАДЬЯ_A8"); var WL07 = new clFigure("БЕЛ_ЛАДЬЯ_H8");
            var WK01 = new clFigure("БЕЛ_КОНЬ_B8");  var WK06 = new clFigure("БЕЛ_КОНЬ_G8");
            var WS02 = new clFigure("БЕЛ_СЛОН_C8");  var WS05 = new clFigure("БЕЛ_СЛОН_F8");
            var WW03 = new clFigure("БЕЛ_КАРОЛЬ_D8");var WF04 = new clFigure("БЕЛ_ФЕРЗЬ_E8");

            var BP60 = new clFigure("ЧЕР_ПЕШКА_A2"); var BP61 = new clFigure("ЧЕР_ПЕШКА_B2");
            var BP62 = new clFigure("ЧЕР_ПЕШКА_C2"); var BP63 = new clFigure("ЧЕР_ПЕШКА_D2");
            var BP64 = new clFigure("ЧЕР_ПЕШКА_E2"); var BP65 = new clFigure("ЧЕР_ПЕШКА_F2");
            var BP66 = new clFigure("ЧЕР_ПЕШКА_G2"); var BP67 = new clFigure("ЧЕР_ПЕШКА_H2");

            var BL70 = new clFigure("ЧЕР_ЛАДЬЯ_A1"); var BL77 = new clFigure("ЧЕР_ЛАДЬЯ_H1");
            var BK71 = new clFigure("ЧЕР_КОНЬ_B1");  var BK76 = new clFigure("ЧЕР_КОНЬ_G1");
            var BS72 = new clFigure("ЧЕР_СЛОН_C1");  var BS75 = new clFigure("ЧЕР_СЛОН_F1");
            var BW73 = new clFigure("ЧЕР_КАРОЛЬ_D1");var BF74 = new clFigure("ЧЕР_ФЕРЗЬ_E1");

            figure[0, 0] = WL00; figure[0, 1] = WK01; figure[0, 2] = WS02; figure[0, 3] = WW03;
            figure[0, 7] = WL07; figure[0, 6] = WK06; figure[0, 5] = WS05; figure[0, 4] = WF04;
            //пешки
            figure[1, 0] = WP10; figure[1, 1] = WP11; figure[1, 2] = WP12; figure[1, 3] = WP13;
            figure[1, 4] = WP14; figure[1, 5] = WP15; figure[1, 6] = WP16; figure[1, 7] = WP17;

            //пешки
            figure[6, 0] = BP60; figure[6, 1] = BP61; figure[6, 2] = BP62; figure[6, 3] = BP63;
            figure[6, 4] = BP64; figure[6, 5] = BP65; figure[6, 6] = BP66; figure[6, 7] = BP67;

            figure[7, 0] = BL70; figure[7, 1] = BK71; figure[7, 2] = BS72; figure[7, 3] = BW73;
            figure[7, 7] = BL77; figure[7, 6] = BK76; figure[7, 5] = BS75; figure[7, 4] = BF74;
            
        }

        /// <summary>
        /// Какая фигура\нет по адресу [0,A]
        /// </summary>
        public string ShowFigName(int str, int stolb)
        {
            //MessageBox.Show(BtnClik);
            var obj = figure[str, stolb];
            
            return obj.Name;
        }

        /// <summary>
        /// Какая фигура\нет по тегу панели [40]
        /// </summary>
        public string ShowFigName(string nn)
        {
            if (nn == "" || nn.Contains("-")) return "null";
            string str = nn.Substring(0, 1);
            string stolb = nn.Substring(1, 1);
            int sr = Convert.ToInt32(str);
            int sb = Convert.ToInt32(stolb);
            
            var obj = figure[sr, sb];
            if(obj!=null)return obj.Name;
            return "null";
        }

        /// <summary>
        /// Перегнать строкy "40" в цифры Point[4, 0]
        /// </summary>
        internal Point coordinate(string pnl)
        {
            if(pnl.Contains("-"))return new Point(-1,-1);
            string str = pnl.Substring(0, 1);
            string stolb = pnl.Substring(1, 1);
            return new Point(Convert.ToInt32(str), Convert.ToInt32(stolb));
        }

        /// <summary>
        /// Перенести фигуру с ячейки [btn] в [panel]
        /// </summary>
        public void PerestanovkaVMassive(string btnStartTag, string panelEndTag)
        {
            Point end = coordinate(panelEndTag);
            //взять из ячейки
            for (int i = 0; i < 8; i++)//проход по строке
            {
                for (int j = 0; j < 8; j++ )//проход по ячейкам строки
                    if (figure[i, j] != null && figure[i, j].Name == btnStartTag)
                    {
                        var tmp = figure[i, j];
                        //если фигура ПЕШКА то можно разок сходить на два++
                        if(btnStartTag.Contains("ПЕШКА")) tmp.OneGo = true;
                        //затереть ячейку старта
                        figure[i, j] = null;
                        //положить в новую ячейку
                        figure[end.X, end.Y] = tmp;

                        break;
                    }
            }
            
        }

        /// <summary>
        /// Удалить обьект в массиве
        /// </summary>
        public void DeliteFigure(string btnTagOld, string btnTagNew)
        {
            var temp = new clFigure("");
            for (int i = 0; i < 8; i++)//проход по строке
            {
                for (int j = 0; j < 8; j++)//проход по ячейкам строки
                    if (figure[i, j] != null && figure[i, j].Name == btnTagNew)
                    {
                        temp = figure[i, j];
                        //затереть ячейку старта
                        figure[i, j] = null;
                        break;
                    }
            }

            for (int i = 0; i < 8; i++)//проход по строке
            {
                for (int j = 0; j < 8; j++)//проход по ячейкам строки
                    if (figure[i, j] != null && figure[i, j].Name == btnTagOld)
                    {
                        figure[i, j] = temp;
                        break;
                    }
            }

        }

        /// <summary>
        /// Найти обьект-кнопку в массиве по известному полю Tag
        /// Вернет индекс обьекта
        /// </summary>
        public Point PoiskVMassive(string btnStartTag)
        {
            //взять из ячейки
            for (var i = 0; i < 8; i++)//проход по строке
            {
                for (var j = 0; j < 8; j++)//проход по ячейкам строки
                    if (figure[i, j] != null && figure[i, j].Name == btnStartTag)
                    {
                        return new Point(i, j);
                    }
            }
            return new Point(-1, -1);
        }

        /// <summary>
        /// Изменить поле Имя у обьекта ПЕШКА в массиве
        /// </summary>
        public void TransformPawn(string figOld, string figNew, Point indexPanel)
        {
            //внести новый обьект transformPawn
            figure[indexPanel.X, indexPanel.Y] = new clFigure(figNew);
            //занулить старый обьект ПЕШКА
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(figure[i,j] != null && figure[i,j].Name==figOld)
                    {
                        figure[i, j] = null;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Кто как может пойти.
        /// Заряжаю btnTag кнопки "ЧЕР_КАРОЛЬ_A2", panelEndTag "40"
        /// </summary>
        /// <param name="pawnBatle">true - пешка бьет</param>
        public string VariantXoda(string btnTag, string panelEndTag, bool pawnBatle)
        {
            //если кнопке xod.XodStartFigureTag разрешен переход на панель bvl.Tag:
            //если на панели есть фигура, то бить ИЛИ (это своя, туда нельзя)
            //FALSE если на панели фигура_своих, если панель под кнопкой
            //TRUE если на панели нет_фигур, если на панели фигура противника

            //цвет фигуры
            //bool white = btnTag.Contains("БЕЛ");
            bool black = btnTag.Contains("ЧЕР");

            //определить - чё за кнопка?//тип фигуры
            int scase = -1;
            if (btnTag.Contains("ПЕШКА")) scase = 0;
            else if (btnTag.Contains("ЛАДЬЯ") || btnTag.Contains("ILaden")) scase = 1;
            else if (btnTag.Contains("КОНЬ") || btnTag.Contains("IKoni")) scase = 2;
            else if (btnTag.Contains("СЛОН") || btnTag.Contains("ISlon")) scase = 3;
            else if (btnTag.Contains("КАРОЛЬ")) scase = 4;
            else if (btnTag.Contains("ФЕРЗЬ") || btnTag.Contains("IFerz")) scase = 5;
            
            //индексы Фигура-->Клетка
            Point end = coordinate(panelEndTag);//"40"->[4,0]

            if (end.X < 0 || end.Y < 0) return "Error";

            Point start = PoiskVMassive(btnTag);//"ЧЕР_КАРОЛЬ_A2"->[1,0]

            //Разные методики хода:
            switch (scase)
            {
                case 0://пешка
                    {
                        //Могу ли 'пешка' дойти до панели end
                        //И нет ли фигур на всем пути исключая саму панель
                        string result = GoPawn(start, end, black ? true : false, pawnBatle);
                        if (result == "help" || result == "Путь перекрыт" || result == "err" || result == "OK")
                            return result;
                    }
                    break;
                case 1://Ладья
                    {
                        string result = GoLaden(start, end, black ? true : false);
                        if (result == "help" || result == "Путь перекрыт" || result == "err" || result == "OK")
                            return result;
                    }
                    break;
                case 2://Конь
                    {
                        string result = GoKoni(start, end, black ? true : false);
                        if (result == "help" || result == "Путь перекрыт" || result == "err" || result == "OK")
                            return result;
                    }
                    break;
                case 3://Слон
                    {
                        string result = GoSlon(start, end, black ? true : false, true);
                        if (result == "help" || result == "Путь перекрыт" || result == "err" || result == "OK")
                            return result;
                    }
                    break;
                case 4://Кароль
                    {
                        string result = GoKarol(start, end, black ? true : false);
                        if (result == "help" || result == "Путь перекрыт" || result == "err" || result == "OK")
                            return result;
                    }
                    break;
                case 5://Ферзь
                    {
                        string resultS = GoSlon(start, end, black ? true : false, false);
                        string resultL = GoLaden(start, end, black ? true : false);
                        if ((resultL == "help" && resultS == "help"))
                            return resultL;
                        if ((resultL == "Путь перекрыт" && resultS == "Путь перекрыт"))
                            return resultL;

                        if ((resultL == "Путь перекрыт" && resultS == "help"))
                            return resultL;
                        if ((resultL == "help" && resultS == "Путь перекрыт"))
                            return resultS;

                        if ((resultL == "help" && resultS == "OK"))
                            return resultS;
                        if ((resultL == "OK" && resultS == "help"))
                            return resultL;

                        if ((resultL == "OK" && resultS == "OK"))
                        {/*-->"Есть ли обьект на панели?"	*/
                            //MessageBox.Show("Че на самой панели?");
                            return resultL;
                        }
                        
                    }
                    break;
            }

            return "";
        }

        /// <summary>
        /// Для короля методика хода.
        /// Могу ли королем дойти до панели end?
        /// Контролировать расстояние в 1 клетку
        /// </summary>
        private string GoKarol(Point indexStart, Point end, bool black)
        {
            //набор тестов на равенство:
            //а) середина И (лево ИЛИ право)
            //б) выше И (лево ИЛИ право ИЛИ центр)
            //в) ниже И (лево ИЛИ право ИЛИ центр)
            if (indexStart.X == end.X && (indexStart.Y - 1 == end.Y || indexStart.Y + 1 == end.Y))
                return "OK";
            if (indexStart.X - 1 == end.X && (indexStart.Y - 1 == end.Y || indexStart.Y + 1 == end.Y || indexStart.Y == end.Y))
                return "OK";
            if (indexStart.X + 1 == end.X && (indexStart.Y - 1 == end.Y || indexStart.Y + 1 == end.Y || indexStart.Y == end.Y))
                return "OK";

            return "help";
        }

        /// <summary>
        /// Для слона методика хода.
        /// Могу ли сланом дойти до панели end?
        /// И нет ли фигур на всем пути исключая саму панель.
        /// </summary>
        private string GoSlon(Point indexStart, Point end, bool black, bool goSlon)
        {
            bool onDiagonal = false;
            //если это слон а не ферзь:
            if (goSlon && (indexStart.X == end.X || indexStart.Y == end.Y)) return "help";

            //панель выше?
            if (indexStart.X > end.X)
            {//панель левее?
                if(indexStart.Y > end.Y)
                {//идти диагонально по 1 клетке //подтвердить что панель лежит на диагонали
                    for (int str = indexStart.X-1, stolb = indexStart.Y-1; str >= end.X; str--, stolb--)
                        if (str == end.X && stolb == end.Y) { onDiagonal = true; break; }
                    //на диагонали
                    if (onDiagonal)
                    {//дойти до панели диагональю
                        for (int str = indexStart.X-1, stolb = indexStart.Y-1; str > end.X; str--, stolb--)
                        {//искать другие фигуры на пути
                            if (figure[str, stolb] != null) return "Путь перекрыт";
                        } return "OK";
                    } return "help";
                }
                //правее//идти диагонально по 1 клетке //подтвердить что панель лежит на диагонали
                for (int str = indexStart.X - 1, stolb = indexStart.Y + 1; str >= end.X; str--, stolb++)
                    if (str == end.X && stolb == end.Y) { onDiagonal = true; break; }
                //на диагонали
                if (onDiagonal)
                {//дойти до панели диагональю
                    for (int str = indexStart.X - 1, stolb = indexStart.Y + 1; str > end.X; str--, stolb++)
                    {//искать другие фигуры на пути
                        if (figure[str, stolb] != null) return "Путь перекрыт";
                    } return "OK";
                } return "help";
            }

            //ниже //панель левее?
            if (indexStart.Y > end.Y)
            {//идти диагонально по 1 клетке //подтвердить что панель лежит на диагонали
                for (int str = indexStart.X + 1, stolb = indexStart.Y - 1; str <= end.X; str++, stolb--)
                    if (str == end.X && stolb == end.Y) { onDiagonal = true; break; }
                //на диагонали
                if (onDiagonal)
                {//дойти до панели диагональю
                    for (int str = indexStart.X + 1, stolb = indexStart.Y - 1; str < end.X; str++, stolb--)
                    {//искать другие фигуры на пути
                        if (figure[str, stolb] != null) return "Путь перекрыт";
                    } return "OK";
                } return "help";
            }
            //правее//идти диагонально по 1 клетке //подтвердить что панель лежит на диагонали
            for (int str = indexStart.X + 1, stolb = indexStart.Y + 1; str <= end.X; str++, stolb++)
                if (str == end.X && stolb == end.Y) { onDiagonal = true; break; }
            //на диагонали
            if (onDiagonal)
            {//дойти до панели диагональю
                for (int str = indexStart.X + 1, stolb = indexStart.Y + 1; str < end.X; str++, stolb++)
                {//искать другие фигуры на пути
                    if (figure[str, stolb] != null) return "Путь перекрыт";
                } return "OK";
            } return "help";

        }

        /// <summary>
        /// Для коня методика хода.
        /// Конечная панель выбрана верно?
        /// Т.к. фигура перескакивает через другие.
        /// </summary>
        private string GoKoni(Point indexStart, Point end, bool black)
        {
            //панель выше?
            if(indexStart.X > end.X)
            {//панель левее\правее на один фигуры?
                if (indexStart.Y - 1 == end.Y || indexStart.Y + 1 == end.Y)
                    if (indexStart.X - 2 == end.X) return "OK";
                //панель левее\правее на два фигуры?
                if (indexStart.Y - 2 == end.Y || indexStart.Y + 2 == end.Y)
                    if (indexStart.X - 1 == end.X) return "OK";
            }
            else//панель ниже
            {//панель левее\правее на один фигуры?
                if (indexStart.Y - 1 == end.Y || indexStart.Y + 1 == end.Y)
                    if (indexStart.X + 2 == end.X) return "OK";
                //панель левее\правее на два фигуры?
                if (indexStart.Y - 2 == end.Y || indexStart.Y + 2 == end.Y)
                    if (indexStart.X + 1 == end.X) return "OK";
            }

            return "help";
        }

        /// <summary>
        /// Для ладьи методика хода.
        /// Могу ли ладьей дойти до панели end?
        /// И нет ли фигур на всем пути исключая саму панель.
        /// </summary>
        private string GoLaden(Point indexStart, Point end, bool black)
        {
            //определить уровень
            if(indexStart.X == end.X)
            {//лево право
                //перейти надо в лево?
                if(indexStart.Y > end.Y)
                {//идти от фигуры до панели по 1 клетке
                    for (int i = indexStart.Y-1; i > end.Y; i--)
                    {//если клетка не пуста, то
                        if (figure[indexStart.X, i] != null) return "Путь перекрыт";
                    } return "OK";
                }
                //в право
                for (int i = indexStart.Y + 1; i < end.Y; i++)
                {//если клетка не пуста, то
                    if (figure[indexStart.X, i] != null) return "Путь перекрыт";
                } return "OK";
            }

            if(indexStart.Y == end.Y)
            {//верх низ
                //перейти надо в верх?
                if (indexStart.X > end.X)
                {//идти от фигуры до панели по 1 клетке
                    for (int i = indexStart.X - 1; i > end.X; i--)
                    {//если клетка не пуста, то
                        if (figure[i, indexStart.Y] != null) return "Путь перекрыт";
                    }return "OK";
                }
                //в низ
                for (int i = indexStart.X + 1; i < end.X; i++)
                {//если клетка не пуста, то
                    if (figure[i, indexStart.Y] != null) return "Путь перекрыт";
                } return "OK";
            }
            return "help";
        }

        /// <summary>
        /// Для пешек методика хода.
        /// Могу ли пешкой дойти до панели end.
        /// И нет ли фигур на всем пути исключая саму панель.
        /// </summary>
        private string GoPawn(Point indexStart, Point end, bool black, bool pawnBatle)
        {
            //если pawnBatle == true то анализируем диагонали лево 1 И право 1
            
            if(!pawnBatle)
            {//если pawnBatle == false то анализируем верх 1 И низ 1
                if (indexStart.Y == end.Y)//в одну линию
                {
                    if (black && indexStart.X > end.X)
                    {
                        //черные и фигура ниже панели
                        if ((indexStart.X - end.X) <= 1)
                            /*От фигуры до панели одна клетка
                            *То переходим к шагу просмотра
                            *-->"Есть ли обьект на панели?"	*/
                            return "OK";
                        if ((indexStart.X - end.X) == 2 && !figure[indexStart.X, indexStart.Y].OneGo)
                            /*От фигуры до панели 2 клетки и фигура без запрета хода на две клетки 
                            *Проверить клетку перед фигурой и до панели:*/
                            if (figure[indexStart.X - 1, indexStart.Y] == null)
                                //клетка пуста
                                return "OK";
                            //то переходим к шагу просмотра
                            /*-->"Есть ли обьект на панели?"*/
                            else return "Путь перекрыт";
                        //от фигуры до панели долековато:
                        return "help";
                    }
                    if (!black && indexStart.X < end.X)
                    {
                        //белые и фигура ниже панели
                        if ((end.X - indexStart.X) <= 1)
                            return "OK";
                        if ((end.X - indexStart.X) == 2 && !figure[indexStart.X, indexStart.Y].OneGo)
                            if (figure[indexStart.X + 1, indexStart.Y] == null)
                                return "OK";
                            else return "Путь перекрыт";

                        return "help";
                    }
                }else return "help";
            }
            else
            {//диагонали:
                if(black)
                {//верхние направление
                    //панель выше фигуры
                    if(end.X < indexStart.X)
                    {
                        if (indexStart.X - 1 == end.X && indexStart.Y - 1 == end.Y) return "OK";
                        if (indexStart.X - 1 == end.X && indexStart.Y + 1 == end.Y) return "OK";
                        return "help";
                    }
                    return "err";
                }
                if(!black)
                {//нижнее направление
                    //панель ниже фигуры
                    if (end.X > indexStart.X)
                    {
                        if (indexStart.X + 1 == end.X && indexStart.Y - 1 == end.Y) return "OK";
                        if (indexStart.X + 1 == end.X && indexStart.Y + 1 == end.Y) return "OK";
                        return "help";
                    } 
                    return "err";
                }
            }

            return "help";
        }

        /// <summary>
        /// Глянуть по индексам в массиве поле OneGo фигуры
        /// </summary>
        public bool OneGoFigure(Point start)
        {
            return figure[start.X, start.Y].OneGo;
        }

        /// <summary>
        /// Скопировать массив в лист
        /// </summary>
        internal IEnumerable<string> CopyFiguresDataToList()
        {
            List<string> list = new List<string>();
            foreach (clFigure clFigure in figure)
            {
                if (clFigure != null)
                    list.Add(clFigure.Name + " " + clFigure.OneGo);
                else list.Add("null");
            }
            return list;
        }

        /// <summary>
        /// Переписать лист в массив
        /// </summary>
        internal void PastDataListToFiguresArr(IEnumerable<string> dataList)
        {
            int i = 0, j = -1;
            foreach (string str in dataList)
            {
                j++;

                if(j < 8)
                {
                    if (str == "null")
                    {
                        figure[i, j] = null;
                    }
                    else
                    {
                        string[] words = str.Split(' ');
                        if (figure[i, j] == null) figure[i, j] = new clFigure(words[0]);
                        else figure[i, j] = new clFigure(words[0]);
                        //figure[i, j].Name = words[0];
                        //поставить поле два шага для пешек
                        figure[i, j].OneGo = !str.Contains("False");
                    }
                }
                else
                {
                    j = 0; i++;
                    if (str == "null")
                    {
                        figure[i, j] = null;
                    }
                    else
                    {
                        string[] words = str.Split(' ');
                        if (figure[i, j] == null) figure[i, j] = new clFigure(words[0]);
                        else figure[i, j] = new clFigure(words[0]);
                        //поставить поле два шага для пешек
                        figure[i, j].OneGo = !str.Contains("False");
                    }
                    
                }
                
            }
        }

        /// <summary>
        /// Переписать лист в массив
        /// </summary>
        internal void PastDataListToFiguresArr(IEnumerable<clFigure> dataList)
        {
            int i = 0, j = -1;
            foreach (var listFig in dataList)
            {
                j++;

                if (j < 8)
                {
                    if (listFig == null)
                    {
                        figure[i, j] = null;
                    }
                    else
                    {
                        if (figure[i, j] == null) figure[i, j] = new clFigure(listFig.Name);
                        else
                        {
                            figure[i, j] = listFig;
                            //поставить поле два шага для пешек
                            figure[i, j].OneGo = listFig.OneGo;
                        }
                        
                    }
                }
                else
                {
                    j = 0; i++;
                    if (listFig == null)
                    {
                        figure[i, j] = null;
                    }
                    else
                    {
                        if (figure[i, j] == null) figure[i, j] = new clFigure(listFig.Name);
                        else
                        {
                            figure[i, j] = listFig;

                            //поставить поле два шага для пешек
                            figure[i, j].OneGo = listFig.OneGo;
                        }
                        
                    }
                }
            }
        }

        /// <summary>
        /// Вернуть текущее состояние массива
        /// </summary>
        internal IEnumerable<clFigure> FigureObjArrState()
        {
            var fig = new List<clFigure>();
            foreach (var clFigure in figure)
                fig.Add(clFigure);
            return fig;
        }

    }
}
