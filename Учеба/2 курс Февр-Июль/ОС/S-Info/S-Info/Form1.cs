using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Timer = System.Timers.Timer;

namespace S_Info
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            InfoPC();
        }

        private string[] arrTypeKeyBoard_ziro = {
         "Ошибка чтения параметра",
         "83-клавишная клавиатура для IBM PC/XT -совместимых компьютеров",
         "102-клавишная клавиатура Olivetti",
         "IBM PC/AT -совместимая клавиатура (84клавиши)",
         "Расширенная IBM-клавиатура (101- или 102 клавиши) ",
         "Клавиатура Nokia 1050",
         "Клавиатура Nokia 9140",
         "Японская клавиатура" };

        private string[] arrTypeKeyBoard_uno = {"PC", "USB", "Wireless", "Unrecognized"};

        private string wallpaper;//путь для обоев по умолчанию для btnReset

        private int wall;//значение для кн rBtnResetMouseSpeed по умолчанию

        private void InfoPC()
        {
            ListViewItem str0 = new ListViewItem();

            #region GetComputerName
            int lena = 30;
            StringBuilder compName = new StringBuilder(lena);
            GetComName.GetComputerName(compName, out lena);
            AddStrList(str0,"Имя системы",compName.ToString());
            #endregion

            #region GetKeyBoardType
            int value = 0, index = 0;
            unsafe{GetKeyBoardName.GetKeyboardType(index);}
            try
            {
                for (index = 0; index < 3; index++)
                {
                    switch (index)
                    {
                        case 0://Тип клавы
                            value = GetKeyBoardName.GetKeyboardType(index);//4
                            AddStrList(str0,"Тип клавиатуры",arrTypeKeyBoard_ziro[value]);
                            break;
                        case 1://ПодТип клавы
                            value = GetKeyBoardName.GetKeyboardType(index);//0
                            AddStrList(str0, ">Подтип клавиатуры", arrTypeKeyBoard_uno[value]);
                            break;
                        case 2://Число ФункцКлавиш
                            value = GetKeyBoardName.GetKeyboardType(index);//12
                            AddStrList(str0, ">Число функциональных клавиш", value.ToString());
                            break;
                    }
                }
            }
            catch (EntryPointNotFoundException)
            {MessageBox.Show("Error Exception " + (value - 1)); }
            #endregion

            #region GetUserName
            value = 0;//заглушка
            StringBuilder userName = new StringBuilder(256);
            unsafe{GetUName.GetUserName(userName, out value);}
            try
            {
                GetUName.GetUserName(userName, out value);
                AddStrList(str0, "Имя пользователя", userName.ToString());
            }
            catch
            {AddStrList(str0, "Имя пользователя", "Ошибка чтения параметра"); }
            #endregion

            #region GetSystemDirectory
            StringBuilder sysPath=new StringBuilder(256);
            unsafe{GetSysDir.GetSystemDirectory(sysPath, out value);}
            try
            {
                GetSysDir.GetSystemDirectory(sysPath, out value);
                AddStrList(str0, "Системная папка", sysPath.ToString());
            }
            catch
            {AddStrList(str0, "Системная папка", "Ошибка чтения параметра"); }
            #endregion

            #region GetWindowsDirectory
            StringBuilder winPath = new StringBuilder(256);
            unsafe { GetWinDir.GetWindowsDirectory(winPath, out value); }
            try
            {
                GetWinDir.GetWindowsDirectory(winPath, out value);
                AddStrList(str0, "Папка Windows", winPath.ToString());
            }
            catch
            { AddStrList(str0, "Папка Windows", "Ошибка чтения параметра"); }
            #endregion

            #region GetVersion Ex
            unsafe
            {
                int stringBuilder = GetVerInf.GetVersion();
                AddStrList(str0, "Версия системы", stringBuilder.ToString());

                OSVERSIONINFO osversioninfo=new OSVERSIONINFO();
                osversioninfo.dwOSVersionInfoSize = (uint)sizeof(OSVERSIONINFO);
                GetVerInf.GetVersionEx(ref osversioninfo);
                string d = osversioninfo.dwMajorVersion + 
                     "." + osversioninfo.dwMinorVersion + 
                     "." + osversioninfo.dwBuildNumber;
                AddStrList(str0, ">Сборка системы", d);
                AddStrList(str0, ">Платформа системы", (Environment.OSVersion.Platform).ToString());
            }
            #endregion

            #region GetSystemMetrics
            unsafe
            {
                    foreach (int i in Enum.GetValues(typeof (GetSysMetr.SystemMetric)))
                    {
                        string x = Enum.GetName(typeof (GetSysMetr.SystemMetric), i);//имя
                        int u = GetSysMetr.GetSystemMetrics((GetSysMetr.SystemMetric) i);//значение
                        TreeNode childNode = treeViewMetrick.Nodes[0].Nodes.Add(x + "  " + u);
                        HideCheckBox(childNode);//убираем [0]&[etc] checkBoxсы
                        xmlStreamAnalizer();//Читаем файл подсказок
                    }
                    HideCheckBox(treeViewMetrick.Nodes[0].Nodes[0]);//убираем [1] checkBox
            }
            #endregion

            #region Default System Param for RESET
            //запоминаем фон поумолчанию для btnReset событие onClick
            uint MAX_PATH = 260;
            wallpaper = new string('\0', (int)MAX_PATH);
            GetSysParamInfo.SystemParametersInfo((UInt32) GetSysParamInfo.Action.SPI_GETDESKWALLPAPER, MAX_PATH,
                                                 wallpaper, 0);
            wallpaper = wallpaper.Substring(0, wallpaper.IndexOf('\0'));
            
            //получаем скорость указателя мыши по умолчанию
            wall = 0;//линкер
            unsafe
            {
                GetSysParamInfo.SystemParametersInfo((UInt32) GetSysParamInfo.Action.SPI_GETMOUSESPEED, 0, ref wall,
                                                     (UInt32) GetSysParamInfo.Update.SPIF_SENDCHANGE);
            }
            trackBarSpedMouse.Value = wall;//Устанавливаем ползунок в текущее положение
            
            #endregion

            #region GetSysColor
            //получаем системные цвета по константам COLOR
            for (GetSysColors.COLOR i = GetSysColors.COLOR.SCROLLBAR; i <= GetSysColors.COLOR.INFOBK; i++)
            {//перебор перечислений
                int der = GetSysColors.GetSysColor(i);
                Color derd = Color.FromArgb(der);//переводим в тип Color
                AddStrListGetSysColor(str0, i.ToString(), (int)i, derd);//добавим строку в listView
            }
            #endregion

            #region GetSysTime
            GetSysTimes.SYSTEMTIME systemTime;//линкер
            GetSysTimes.GetSystemTime(out systemTime);

            if (systemTime.DayOfWeek == (ushort)DateTime.UtcNow.DayOfWeek)
                lblForSysTime.Text = systemTime.Year + "." + systemTime.Month + "." + systemTime.Day + " " +
                                     DateTime.UtcNow.DayOfWeek + " " + systemTime.Hour + ":" + systemTime.Minute +
                                     " UTC";
            #endregion

        }

        void AddStrList(ListViewItem str, string groupName, string param)
        {//Добавить СТРоку в listViewData
            str = new ListViewItem(groupName);
            str.SubItems.Add(param);
            listViewData.Items.Add(str);
        }

        void AddStrListGetSysColor(ListViewItem str, string groupName, int param,Color color)
        {//Добавить СТРоку в listViewGetSysColor
            str = new ListViewItem(groupName);
            str.SubItems.Add(param.ToString());
            str.BackColor = color;
            str.ForeColor = Color.WhiteSmoke;
            listViewGetSysColor.Items.Add(str);
        }

        private void HideCheckBox(TreeNode node)
        {//Спрятать ChekBoxы входящего набора (TreeNode node)
            CheckBoxes.TVITEM tvi = new CheckBoxes.TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = CheckBoxes.TVIF_STATE;
            tvi.stateMask = CheckBoxes.TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
            Marshal.StructureToPtr(tvi, lparam, false);
            unsafe{CheckBoxes.SendMessage(treeViewMetrick.Handle, CheckBoxes.TVM_SETITEM, IntPtr.Zero, lparam); } 
        }

        private void treeViewMetrick_AfterSelect(object sender, TreeViewEventArgs e)
        {//Выделил ветку + подключить подсказку toolTrip1
                if (treeViewMetrick.Nodes[0].Checked & treeViewMetrick.SelectedNode != null)
                {//МетрикКорень отмечен && ВыделенаяВетка != пусто
                    toolTip1.SetToolTip(treeViewMetrick, treeViewMetrick.SelectedNode.Text);
                    int index = treeViewMetrick.SelectedNode.Index;//Получаем индекс с ветки дерева
                    MessageBox.Show(roses[index].Name);//Показать Хелпы к элементу
                }
        }

        List<Rose> roses = new List<Rose>();//масив роз + явный шаблон класса Rose
        void xmlStreamAnalizer()
        {//подключаемся к xml doc
            FileStream fs=null;
            try{fs = new FileStream("EnumSysMetrickTitle.xml", FileMode.Open);}
            catch{MessageBox.Show("Нет файла разметки EnumSysMetrickTitle.xml");}
            XmlTextReader xmlIn=new XmlTextReader(fs);
            xmlIn.WhitespaceHandling = WhitespaceHandling.None;//Откл обработку пробелов

            xmlIn.MoveToContent();//Переместиться в начало дока

            if(xmlIn.Name!="summary")//Проверим первый тег дока
                throw new ArgumentException("Тег открытия xml повреждён или изменён.");

            //цикл чтения документа
            do
            {
                if(!xmlIn.Read())
                    throw new ArgumentException("Ошибка чтения xml структуры файла.");

                if((xmlIn.NodeType== XmlNodeType.EndElement) & (xmlIn.Name=="summary"))
                    break;//Это конец Дока, элемент summary И завершающий_элемент

                if(xmlIn.NodeType==XmlNodeType.EndElement)
                    continue;//Если эт <конечный /> элемент, то не проверяем

                if(xmlIn.Name=="Rose")
                {//если это роза, то читаем ее параметры
                    Rose newItem = new Rose("", 0);
                    roses.Add(newItem);
                    newItem.LoadFromFile(xmlIn);
                }

            } while (!xmlIn.EOF);
            //закрываем потоки
            xmlIn.Close();
            fs.Close();
        }

        private void btnPic1_Click(object sender, EventArgs e)
        {//!!Один обработчик события для трех кнопок btnPic + btnReset и кнопки ResetMouseSpeed
            int k = Convert.ToInt32((sender as Button).TabIndex);
            switch (k)
            {
                case 0://btnPic1
                    GetSysParamInfo.SystemParametersInfo((UInt32) GetSysParamInfo.Action.SPI_SETDESKWALLPAPER, 0,
                                                         "A-корпус.jpg",
                                                         (UInt32) GetSysParamInfo.Update.SPIF_UPDATEINIFILE);
                    break;
                case 1://btnPic2
                    GetSysParamInfo.SystemParametersInfo((UInt32) GetSysParamInfo.Action.SPI_SETDESKWALLPAPER, 0,
                                                         "IMAG0195.jpg",
                                                         (UInt32) GetSysParamInfo.Update.SPIF_UPDATEINIFILE);
                    break;
                case 2://btnPic3
                    GetSysParamInfo.SystemParametersInfo((UInt32)GetSysParamInfo.Action.SPI_SETDESKWALLPAPER, 0,
                                                         "Рассвет.jpg",
                                                         (UInt32)GetSysParamInfo.Update.SPIF_UPDATEINIFILE);
                    break;
                case 3://rBtnReset
                    GetSysParamInfo.SystemParametersInfo((UInt32)GetSysParamInfo.Action.SPI_SETDESKWALLPAPER, 0,
                                                         wallpaper,
                                                         (UInt32)GetSysParamInfo.Update.SPIF_UPDATEINIFILE);
                    break;
                case 4://rBtnResetMouseSpeed
                    trackBarSpedMouse.Value = wall;
                    GetSysParamInfo.SystemParametersInfo((UInt32)GetSysParamInfo.Action.SPI_SETMOUSESPEED, 0,
                                                         wall,
                                                         (UInt32)GetSysParamInfo.Update.SPIF_UPDATEINIFILE);
                    break;
                default://страховка
                    return;
            }
        }

        private void trackBarSpedMouse_Scroll(object sender, EventArgs e)
        {//Перемещение ползунка и задание новой скорости SetMouseSpeed
            int val = trackBarSpedMouse.Value;
            GetSysParamInfo.SystemParametersInfo((UInt32)GetSysParamInfo.Action.SPI_SETMOUSESPEED, 0,
                                                         val,
                                                         (UInt32)GetSysParamInfo.Update.SPIF_UPDATEINIFILE);
        }

        private int count = 0;//счетчик для события
        private void colorSelector1_ForegroundColorChanged(object sender, EventArgs e)
        {//событие на выбор цвета
            Color color = colorSelector1.ForegroundColor;//получаем обьект типа Color
            int[] colors = { ColorTranslator.ToWin32(color) };//раскладываем спетктр RGB в масив
            int[] valChange=new int[1];
            for (GetSysColors.COLOR i = GetSysColors.COLOR.SCROLLBAR; i <= GetSysColors.COLOR.INFOBK; i++)
            {//пишим только при равенстве счетчика count и i-элемента
                if((int)i == count)
                 valChange[0] = (int)i;
            }
            count++;
                if (count > listViewGetSysColor.Items.Count)
                {
                    count = 0;//сброс
                    GetSysColors.SetSysColors(valChange.Length, valChange, colors);
                }
                else
                {GetSysColors.SetSysColors(valChange.Length, valChange, colors);}
        }

        private void CursorPosition(object source, ElapsedEventArgs e)
        {//получить координаты курсора
            GetCursPosit.Point tmp = new GetCursPosit.Point();
            GetCursPosit.GetCursorPos(out tmp);
            GetCursPosit.Point curPoint = new GetCursPosit.Point();
            GetCursPosit.GetCursorPos(out curPoint);
            lblCursorPos.Text = "X:"+curPoint.X + ":" + curPoint.Y+":Y";
            tmp = curPoint;
        }

        Timer myTimer = new Timer();
        private void checkBoxOnOffCursorPos_CheckedChanged(object sender, EventArgs e)
        {//Вкл-выкл таймера
            if (checkBoxOnOffCursorPos.Checked)
            {
                myTimer.Elapsed += new ElapsedEventHandler(CursorPosition);
                myTimer.Interval = 2000;
                myTimer.Start();
            }
            else
            {
                myTimer.Stop();
                lblCursorPos.Text = "X:--:--:Y";
            }
            
            
        }

        private void activePanel1_Click(object sender, EventArgs e)
        {//клик по панели QwinCor - сдвигаем в координату 1:2 всю форму
            MovWindow.MoveWindow(Handle, 1, 2, 500, 440, true);
        }
        
    }//end class fMain
}
