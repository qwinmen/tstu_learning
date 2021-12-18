using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapTech;

namespace TestFile
{
    public partial class UCParametrs : UserControl
    {
        public UCParametrs()
        {
            InitializeComponent();
        }

        clDataBaseStatic _clDataBaseStatic = new clDataBaseStatic();

        private void radioButton7_Пескосушилка_CheckedChanged(object sender, EventArgs e)
        {
            var radComp = sender as RadioButton;
            if (radComp != null && radComp.Checked)
                switch (radComp.Tag.ToString())
                {
                    case "1"://Агломерат
                        if(Form1.fНазванияОборудованияПоСтоимости.Count!=0)
                            linkLabel1.Text = Form1.fНазванияОборудованияПоСтоимости[6];
                        SetFlovPnl(1);
                        break;
                    case "2"://Дробилка
                        if (Form1.fНазванияОборудованияПоСтоимости.Count != 0)
                            linkLabel1.Text = Form1.fНазванияОборудованияПоСтоимости[2];
                        SetFlovPnl(2);
                        break;
                    case "3": //Экструдер
                        if (Form1.fНазванияОборудованияПоСтоимости.Count != 0)
                            linkLabel1.Text = Form1.fНазванияОборудованияПоСтоимости[5];
                        SetFlovPnl(3);
                        break;
                    case "4": //Контейнер
                        if (Form1.fНазванияОборудованияПоСтоимости.Count != 0)
                            linkLabel1.Text = Form1.fНазванияОборудованияПоСтоимости[0];
                        SetFlovPnl(4);
                        break;
                    case "5": //Конвеер
                        if (Form1.fНазванияОборудованияПоСтоимости.Count != 0)
                            linkLabel1.Text = Form1.fНазванияОборудованияПоСтоимости[1];
                        SetFlovPnl(5);
                        break;
                    case "6": //Магнит
                        if (Form1.fНазванияОборудованияПоСтоимости.Count != 0)
                            linkLabel1.Text = Form1.fНазванияОборудованияПоСтоимости[4];
                        SetFlovPnl(6);
                        break;
                    case "7": //Пескосушилка
                        if (Form1.fНазванияОборудованияПоСтоимости.Count != 0)
                            linkLabel1.Text = clDataBaseStatic.peskosusArr[0]._имя;
                        SetFlovPnl(7);
                        break;
                }
        }

        private int bckIndx=-1;
        private void SetFlovPnl(int index)
        {
            if(index==bckIndx)return;
            bckIndx = index;
            this.flowLayoutPanel1.Controls.Clear();
            label1.Text = "null/..";
            switch (index)
            {
                case 1:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Производительность", BackColor = Color.Yellow };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
                case 2:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Производительность", BackColor = Color.Yellow };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
                case 3:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Производительность", BackColor = Color.Yellow };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
                case 4:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Обьем", BackColor = Color.FloralWhite };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
                case 5:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Скорость", BackColor = Color.Brown };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
                case 6:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Глубина", BackColor = Color.Indigo };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
                case 7:
                    {
                        var lbl = new Label() { Text = "Цена", BackColor = Color.Red };
                        lbl.Click += (LabelClick);
                        var lbl1 = new Label() { Text = "Производительность", BackColor = Color.Yellow };
                        lbl1.Click += (LabelClick);
                        this.flowLayoutPanel1.Controls.AddRange(new Control[] { lbl, lbl1 });
                        break;
                    }
            }
        }

        private void LabelClick(object sender, EventArgs e)
        {
            var sen = sender as Label;
            if (sen == null) return;
            var activRad = bckIndx == 1
                               ? "Агломераор"
                               : bckIndx == 2
                                     ? "Дробилка"
                                     : bckIndx == 3
                                           ? "Экструдер"
                                           : bckIndx == 4
                                                 ? "Контейнер"
                                                 : bckIndx == 5
                                                       ? "Конвеер"
                                                       : bckIndx == 6
                                                             ? "Магнит"
                                                             : bckIndx == 7 ? "Пескосушилка" : "null/..";
            label1.Text = "null/..";
            switch (sen.Text)
            {
                case "Цена":
                    label1.Text = string.Format("Следующий аппорат в категории {0} доступен по цене {1} руб", activRad,
                        bckIndx == 1
                               ? clDataBaseStatic.aglomsArr[0]._цена
                               : bckIndx == 2
                                     ? clDataBaseStatic.drobsArr[0]._цена
                                     : bckIndx == 3
                                           ? clDataBaseStatic.ekstrudsArr[0]._цена
                                           : bckIndx == 4
                                                 ? clDataBaseStatic.konteinersArr[0]._цена
                                                 : bckIndx == 5
                                                       ? clDataBaseStatic.konveersArr[0]._цена
                                                       : bckIndx == 6
                                                             ? clDataBaseStatic.magnitsArr[0]._цена
                                                             : bckIndx == 7 ? clDataBaseStatic.peskosusArr[0]._цена : "null/..");
                    break;
                case "Производительность":
                    label1.Text = string.Format("Можно увеличить производительность линии паралельным запуском агрегата {0} c показателем {1} кг/ч", activRad,
                        bckIndx == 1
                               ? clDataBaseStatic.aglomsArr[2]._производительнсть
                               : bckIndx == 2
                                     ? clDataBaseStatic.drobsArr[0]._производительность
                                     : bckIndx == 3
                                           ? clDataBaseStatic.ekstrudsArr[0]._производительность
                                           : bckIndx == 4
                                                 ? clDataBaseStatic.konteinersArr[0]._цена
                                                 : bckIndx == 5
                                                       ? clDataBaseStatic.konveersArr[0]._цена
                                                       : bckIndx == 6
                                                             ? clDataBaseStatic.magnitsArr[0]._цена
                                                             : bckIndx == 7 ? clDataBaseStatic.peskosusArr[0]._производительность : "null/..");
                    break;
                case "Обьем":
                    label1.Text = string.Format("Можно увеличить производительность линии паралельным использованием {0}а c показателем {1} л", activRad,
                        bckIndx == 1
                               ? clDataBaseStatic.aglomsArr[2]._производительнсть
                               : bckIndx == 2
                                     ? clDataBaseStatic.drobsArr[0]._производительность
                                     : bckIndx == 3
                                           ? clDataBaseStatic.ekstrudsArr[0]._производительность
                                           : bckIndx == 4
                                                 ? clDataBaseStatic.konteinersArr[2]._обьем
                                                 : bckIndx == 5
                                                       ? clDataBaseStatic.konveersArr[0]._цена
                                                       : bckIndx == 6
                                                             ? clDataBaseStatic.magnitsArr[0]._цена
                                                             : bckIndx == 7 ? clDataBaseStatic.peskosusArr[0]._производительность : "null/..");
                    break;
                case "Скорость":
                    label1.Text = string.Format("Можно увеличить производительность линии паралельным использованием {0}а c показателем {1} м/с", activRad,
                        bckIndx == 1
                               ? clDataBaseStatic.aglomsArr[2]._производительнсть
                               : bckIndx == 2
                                     ? clDataBaseStatic.drobsArr[0]._производительность
                                     : bckIndx == 3
                                           ? clDataBaseStatic.ekstrudsArr[0]._производительность
                                           : bckIndx == 4
                                                 ? clDataBaseStatic.konteinersArr[2]._обьем
                                                 : bckIndx == 5
                                                       ? clDataBaseStatic.konveersArr[2]._скорость
                                                       : bckIndx == 6
                                                             ? clDataBaseStatic.magnitsArr[0]._цена
                                                             : bckIndx == 7 ? clDataBaseStatic.peskosusArr[0]._производительность : "null/..");
                    break;
                case "Глубина":
                    label1.Text = string.Format("Можно увеличить производительность линии паралельным использованием {0}а c показателем глубины извлечения {1} мм", activRad,
                        bckIndx == 1
                               ? clDataBaseStatic.aglomsArr[2]._производительнсть
                               : bckIndx == 2
                                     ? clDataBaseStatic.drobsArr[0]._производительность
                                     : bckIndx == 3
                                           ? clDataBaseStatic.ekstrudsArr[0]._производительность
                                           : bckIndx == 4
                                                 ? clDataBaseStatic.konteinersArr[2]._обьем
                                                 : bckIndx == 5
                                                       ? clDataBaseStatic.konveersArr[0]._цена
                                                       : bckIndx == 6
                                                             ? clDataBaseStatic.magnitsArr[0]._глубина
                                                             : bckIndx == 7 ? clDataBaseStatic.peskosusArr[0]._производительность : "null/..");
                    break;
            }

        }
    }
}
