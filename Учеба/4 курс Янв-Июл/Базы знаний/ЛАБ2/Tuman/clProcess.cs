using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

/*
14)ЕСЛИ Расход сырья=малый И Температура процесса=малая 
ИЛИ Расход сырья=малый И Температура процесса=средняя
ИЛИ Расход сырья=средний И Температура процесса=малая
ТО Аппарат=А;

ЕСЛИ Расход сырья=малый И Температура процесса=болыпая
ИЛИ Расход сырья=6ольшой И Температура процесса=малая 
ИЛИ Расход сырья=средний И Температура процесса=средняя 
ТО Аппарат=В; 

ЕСЛИ Расход сырья=средний И Температура процесса=большая 
ИЛИ Расход сырья=большой И Температура процесса=средняя
ИЛИ Расход сырья=большой И Температура процесса=большая 
ТО Аппарат=С;

ЕСЛИ Расход сырья=слегка большой И (Температура процесса=малая 
ИЛИ Температура процесса=средняя 
ИЛИ Температура процесса=большая)
ТО Аппарат=D.

 */
namespace Tuman
{
    class clProcess
    {
        public clProcess(){}

        /// <summary>
        /// Определить класс
        /// </summary>
        public string GetClass(double[] Tm, double[] Gm, int valT, int valG)
        {
            var resString = "T: ";
            var tmps = "G: ";
            //Tm[]=Tm(val)//Gm[]=Gm(val)
            for (int i = 0; i < Tm.Length; i++)
            {//NaN приравниваем к 0!!
                Tm[i] = double.IsNaN(Tm[i]) ? 0.0 : Tm[i];
                Gm[i] = double.IsNaN(Gm[i]) ? 0.0 : Gm[i];
                resString += string.Format("µ{2}({0})={1:0.00}; ", valT, Tm[i], i+1);//m1(15)=0.3
                tmps += string.Format("µ{2}({0})={1:0.00}; ", valG, Gm[i], i + 1);//m1(15)=0.3
            }resString += "\r\n" + tmps + "\r\n";
            //Обобщеные входные параметры
            var mw1 = Gm[0] & new d(Tm[0]) | new d(Gm[0] & new d(Tm[1])) | new d(Gm[1] & new d(Tm[0]));
            resString +=
                string.Format(
                    "µw1= if({0:0.00} && {1:0.00})||({0:0.00} && {2:0.00})||({3:0.00} && {1:0.00}) ={4:0.00}\r\n", 
                                Gm[0], Tm[0], Tm[1], Gm[1], mw1);
            var mw2 = Gm[0] & new d(Tm[2]) | new d(Gm[2] & new d(Tm[0])) | new d(Gm[1] & new d(Tm[1]));
            resString +=
                string.Format(
                    "µw2= if({0:0.00} && {1:0.00})||({2:0.00} && {3:0.00})||({4:0.00} && {5:0.00}) ={6:0.00}\r\n",
                                Gm[0], Tm[2], Gm[2], Tm[0], Gm[1], Tm[1], mw2);
            var mw3 = Gm[1] & new d(Tm[2]) | new d(Gm[2] & new d(Tm[1])) | new d(Gm[2] & new d(Tm[2]));
            resString +=
                string.Format(
                    "µw3= if({0:0.00} && {1:0.00})||({2:0.00} && {3:0.00})||({4:0.00} && {5:0.00}) ={6:0.00}\r\n",
                                Gm[1], Tm[2], Gm[2], Tm[1], Gm[2], Tm[2], mw3);
            var mw4 = Math.Pow(Gm[2], 0.5) & new d(Tm[2] | new d(Tm[1]) | new d(Tm[0]));
            resString +=
                string.Format(
                    "µw4= if({0:0.00}⁰ˑ⁵ && ({1:0.00}||{2:0.00}||{3:0.00})) ={4:0.00}\r\n",
                                Gm[2], Tm[2], Tm[1], Tm[0], mw4);
            //пройти по правилам modus ponus
            var mpString = "";
            var mm = ModusPonus(new List<double>() { mw1, mw2, mw3, mw4 }, out mpString);
            resString += "\r\n"+mpString;
            resString += string.Format("µmp1={0:0.00}; µmp2={1:0.00}; µmp3={2:0.00}; µmp4={3:0.00}; \r\n", mm[0], mm[1], mm[2], mm[3]);
            //выбрать max{mm[]}
            var max = mm[0] | new d(mm[1]) | new d(mm[2]) | new d(mm[3]);
            resString += string.Format("MAX(µmp)={0:0.00} \r\n", max);
            var index = 0;
            foreach (var d in mm)
            {
                if(d==max)
                {
                    switch (index)
                    {
                        case 0: resString += "Аппарат А; "; break;
                        case 1: resString += "Аппарат B; "; break;
                        case 2: resString += "Аппарат C; "; break;
                        case 3: resString += "Аппарат D; "; break;
                    }
                }
                index++;
            }
            resString += "\r\n--END--";

            return resString;
        }

        /// <summary>
        /// min{a;b}
        /// </summary>
        public static double operator &(double a, clProcess b)
        {
            return a <= ((d)b).Value ? a : ((d)b).Value;
        }

        /// <summary>
        /// max{a;b}
        /// </summary>
        public static double operator |(double a, clProcess b)
        {
            return a >= ((d)b).Value ? a : ((d)b).Value;
        }

        /// <summary>
        /// Cтепень истиности. Правило
        /// </summary>
        /// <param name="mw">mw[]</param>
        /// <returns>µmp[]</returns>
        private double[] ModusPonus(IList<double> mw, out string resStr)
        {
            resStr = "";
            var res = new double[4];
            res[0] = 1.0 & new d(1.0 - mw[0] + 1.0) & new d(1.0 - mw[1] + 0.0) & new d(1.0 - mw[2] + 0.0) & new d(1.0 - mw[3] + 0.0);
            resStr += string.Format("µmp1= 1 && (1-{0:0.00}+1) && (1-{1:0.00}+0) && (1-{2:0.00}+0) && (1-{3:0.00}+0) \r\n", mw[0], mw[1], mw[2], mw[3]);
            res[1] = 1.0 & new d(1.0 - mw[0] + 0.0) & new d(1.0 - mw[1] + 1.0) & new d(1.0 - mw[2] + 0.0) & new d(1.0 - mw[3] + 0.0);
            resStr += string.Format("µmp2= 1 && (1-{0:0.00}+0) && (1-{1:0.00}+1) && (1-{2:0.00}+0) && (1-{3:0.00}+0) \r\n", mw[0], mw[1], mw[2], mw[3]);
            res[2] = 1.0 & new d(1.0 - mw[0] + 0.0) & new d(1.0 - mw[1] + 0.0) & new d(1.0 - mw[2] + 1.0) & new d(1.0 - mw[3] + 0.0);
            resStr += string.Format("µmp3= 1 && (1-{0:0.00}+0) && (1-{1:0.00}+0) && (1-{2:0.00}+1) && (1-{3:0.00}+0) \r\n", mw[0], mw[1], mw[2], mw[3]);
            res[3] = 1.0 & new d(1.0 - mw[0] + 0.0) & new d(1.0 - mw[1] + 0.0) & new d(1.0 - mw[2] + 0.0) & new d(1.0 - mw[3] + 1.0);
            resStr += string.Format("µmp4= 1 && (1-{0:0.00}+0) && (1-{1:0.00}+0) && (1-{2:0.00}+0) && (1-{3:0.00}+1) \r\n", mw[0], mw[1], mw[2], mw[3]);
            return res;
        }

        /// <summary>
        /// Вернет число для одной позиции M
        /// </summary>
        /// <param name="lvl">1-2-3</param>
        /// <param name="isT">да\нет</param>
        /// <param name="value">число</param>
        /// <returns>расчет</returns>
        public double GetM(int lvl, bool isT, double value)
        {
            return M(lvl, isT, value);
        }

        /// <summary>
        /// Просчитать три формулы
        /// </summary>
        /// <returns></returns>
        public PointPairList PaintGraphik(bool isT, int lvl)
        {
            var tmpList = new PointPairList();
            if (isT)
            {//график для Т
                for (int i = 100; i < 150; i++)
                {
                    tmpList.Add(i, M(lvl, isT, i));
                }
                return tmpList;
            }
            //график для G
            for (int i = 70; i < 110; i++)
            {
                tmpList.Add(i, M(lvl, isT, i));
            }

            return tmpList;
        }

        /// <summary>
        /// Рассчитать мю
        /// </summary>
        /// <param name="lvl">1-2-3</param>
        /// <param name="isT">Для Т?</param>
        /// <returns></returns>
        private double M(int lvl, bool isT, double value)
        {
            switch (lvl)
            {
                case 1://малый
                    if(isT) return (.0001*Math.Pow((value - 200.0), 2));
                    return (Math.Pow(Math.Exp(-0.2 * Math.Log(10.0 * Math.Abs((value - 75.1)))), 2));
                case 2://средний
                    if (isT) return (1.0-.001 * Math.Pow((125.0 - value), 2));
                    return (Math.Pow(Math.Exp(-0.2 * Math.Log(10.0 * Math.Abs((value - 85.1)))), 2));
                case 3://большой
                    if (isT) return (.0001 * Math.Pow((value - 50.0), 2));
                    return (Math.Pow(Math.Exp(-0.2 * Math.Log(10.0 * Math.Abs((value - 100.1)))), 2));
            }

            return -1;
        }

    }

    internal class d:clProcess
    {
        public d(double val)
        {
            Value = val;
        }

        internal double Value { get; set; }
    }

}
