using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

//Lab-1 получение инфы системы через WinApi
namespace S_Info
{
    class GetComName
    {//GetComputerName получает информацию об имени системы
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetComputerName(StringBuilder name, out int len);
    }

    class GetKeyBoardName
    {//GetKeyboardType получает информацию об используемой клавиатуре
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetKeyboardType(int value);
    }

    class GetUName
    {
        [DllImport("AdvApi32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetUserName(StringBuilder lpBuffer, out int value);
    }

    class GetSysDir
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetSystemDirectory(StringBuilder path, out int value);
    }

    class GetWinDir
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowsDirectory(StringBuilder path, out int value);
    }

    unsafe struct OSVERSIONINFO
    {
        public uint dwOSVersionInfoSize;
        public uint dwMajorVersion;
        public uint dwMinorVersion;
        public uint dwBuildNumber;
        public uint dwPlatformId;
        public fixed char szCSDVersion[128];
    }
    class GetVerInf
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern char GetVersion();

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetVersionEx(ref OSVERSIONINFO osversioninfo);
    }
    
    class GetSysMetr
    {//Получить системные метрики
        [DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetSystemMetrics(SystemMetric nIndex);
        public enum SystemMetric
        {//Параметры для опроса
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F

            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001
        }
    }

    class CheckBoxes
    {//Отображение\Скрытие CheckBoxов
        public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TV_FIRST = 0x1100;
        public const int TVM_SETITEM = TV_FIRST + 63;

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // struct used to set node properties
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }
    }

    class Rose
    {//Храним полученные подсказки из xml для treeViewMetrick
        public Rose(string name, int index)
        {
            this.Name = name;
            this.Index = index;
        }

        public string Name { get; set; }
        public int Index { get; set; }

        public void LoadFromFile(XmlTextReader xmlIn)
        {
            try
            {
                Name = xmlIn.GetAttribute("Name");
                Index = Convert.ToInt32(xmlIn.GetAttribute("Index"));
            }
            catch{throw new ArgumentException("Ошибка сохранения атрибутов при чтении xml");}
        }
    }

    class GetSysParamInfo
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]//Переопределен для получения значений при запросах GET
        public static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, ref int vParam, UInt32 winIni);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]//Переопределен для получения значений при запросах GET
        public static extern Int32 SystemParametersInfo(UInt32 action, UInt32 uParam, int vParam, UInt32 winIni);
        //Как установить обои на Рабочий Стол?
        //SystemParametrsInfo(SPI_SETDESKWALLPAPER,0,'обои.bmp',SPIF_UPDATEINIFILE); 
        /*Value__uint fWinIni_|_________Meaning
        SPIF_UPDATEINIFILE    |  Записывает новое значение параметра в общесистемный профиль пользователя.
        SPIF_SENDCHANGE       |  Передает сообщение WM_SETTINGCHANGE после обновления профиля пользователя.
        SPIF_SENDWININICHANGE |  Тоже что и SPIF_SENDCHANGE.*/
        public enum Action
        {
            SPI_GETBEEP = 1,
            SPI_SETBEEP = 2,
            SPI_GETMOUSE = 3,
            SPI_SETMOUSE = 4,
            SPI_GETBORDER = 5,
            SPI_SETBORDER = 6,
            SPI_GETKEYBOARDSPEED = 10,
            SPI_SETKEYBOARDSPEED = 11,
            SPI_LANGDRIVER = 12,
            SPI_ICONHORIZONTALSPACING = 13,
            SPI_GETSCREENSAVETIMEOUT = 14,
            SPI_SETSCREENSAVETIMEOUT = 15,
            SPI_GETSCREENSAVEACTIVE = 16,
            SPI_SETSCREENSAVEACTIVE = 17,
            SPI_GETGRIDGRANULARITY = 18,
            SPI_SETGRIDGRANULARITY = 19,
            SPI_SETDESKWALLPAPER = 20,
            SPI_SETDESKPATTERN = 21,
            SPI_GETKEYBOARDDELAY = 22,
            SPI_SETKEYBOARDDELAY = 23,
            SPI_ICONVERTICALSPACING = 24,
            SPI_GETICONTITLEWRAP = 25,
            SPI_SETICONTITLEWRAP = 26,
            SPI_GETMENUDROPALIGNMENT = 27,
            SPI_SETMENUDROPALIGNMENT = 28,
            SPI_SETDOUBLECLKWIDTH = 29,
            SPI_SETDOUBLECLKHEIGHT = 30,
            SPI_GETICONTITLELOGFONT = 31,
            SPI_SETDOUBLECLICKTIME = 32,
            SPI_SETMOUSEBUTTONSWAP = 33,
            SPI_SETICONTITLELOGFONT = 34,
            SPI_GETFASTTASKSWITCH = 35,
            SPI_SETFASTTASKSWITCH = 36,
            SPI_SETDRAGFULLWINDOWS = 37,
            SPI_GETDRAGFULLWINDOWS = 38,
            SPI_GETNONCLIENTMETRICS = 41,
            SPI_SETNONCLIENTMETRICS = 42,
            SPI_GETMINIMIZEDMETRICS = 43,
            SPI_SETMINIMIZEDMETRICS = 44,
            SPI_GETICONMETRICS = 45,
            SPI_SETICONMETRICS = 46,
            SPI_SETWORKAREA = 47,
            SPI_GETWORKAREA = 48,
            SPI_SETPENWINDOWS = 49,
            SPI_GETHIGHCONTRAST = 66,
            SPI_SETHIGHCONTRAST = 67,
            SPI_GETKEYBOARDPREF = 68,
            SPI_SETKEYBOARDPREF = 69,
            SPI_GETSCREENREADER = 70,
            SPI_SETSCREENREADER = 71,
            SPI_GETANIMATION = 72,
            SPI_SETANIMATION = 73,
            SPI_GETFONTSMOOTHING = 74,
            SPI_SETFONTSMOOTHING = 75,
            SPI_SETDRAGWIDTH = 76,
            SPI_SETDRAGHEIGHT = 77,
            SPI_SETHANDHELD = 78,
            SPI_GETLOWPOWERTIMEOUT = 79,
            SPI_GETPOWEROFFTIMEOUT = 80,
            SPI_SETLOWPOWERTIMEOUT = 81,
            SPI_SETPOWEROFFTIMEOUT = 82,
            SPI_GETLOWPOWERACTIVE = 83,
            SPI_GETPOWEROFFACTIVE = 84,
            SPI_SETLOWPOWERACTIVE = 85,
            SPI_SETPOWEROFFACTIVE = 86,
            SPI_SETCURSORS = 87,
            SPI_SETICONS = 88,
            SPI_GETDEFAULTINPUTLANG = 89,
            SPI_SETDEFAULTINPUTLANG = 90,
            SPI_SETLANGTOGGLE = 91,
            SPI_GETWINDOWSEXTENSION = 92,
            SPI_SETMOUSETRAILS = 93,
            SPI_GETMOUSETRAILS = 94,
            SPI_SETSCREENSAVERRUNNING = 97,
            SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,
            SPI_GETFILTERKEYS = 50,
            SPI_SETFILTERKEYS = 51,
            SPI_GETTOGGLEKEYS = 52,
            SPI_SETTOGGLEKEYS = 53,
            SPI_GETMOUSEKEYS = 54,
            SPI_SETMOUSEKEYS = 55,
            SPI_GETSHOWSOUNDS = 56,
            SPI_SETSHOWSOUNDS = 57,
            SPI_GETSTICKYKEYS = 58,
            SPI_SETSTICKYKEYS = 59,
            SPI_GETACCESSTIMEOUT = 60,
            SPI_SETACCESSTIMEOUT = 61,
            SPI_GETSERIALKEYS = 62,
            SPI_SETSERIALKEYS = 63,
            SPI_GETSOUNDSENTRY = 64,
            SPI_SETSOUNDSENTRY = 65,
            SPI_GETSNAPTODEFBUTTON = 95,
            SPI_SETSNAPTODEFBUTTON = 96,
            SPI_GETMOUSEHOVERWIDTH = 98,
            SPI_SETMOUSEHOVERWIDTH = 99,
            SPI_GETMOUSEHOVERHEIGHT = 100,
            SPI_SETMOUSEHOVERHEIGHT = 101,
            SPI_GETMOUSEHOVERTIME = 102,
            SPI_SETMOUSEHOVERTIME = 103,
            SPI_GETWHEELSCROLLLINES = 104,
            SPI_SETWHEELSCROLLLINES = 105,
            SPI_GETMENUSHOWDELAY = 106,
            SPI_SETMENUSHOWDELAY = 107,
            SPI_GETSHOWIMEUI = 110,
            SPI_SETSHOWIMEUI = 111,
            SPI_GETMOUSESPEED = 112,
            SPI_SETMOUSESPEED = 113,
            SPI_GETSCREENSAVERRUNNING = 114,
            SPI_GETDESKWALLPAPER = 115,
            SPI_GETACTIVEWINDOWTRACKING = 0x1000,
            SPI_SETACTIVEWINDOWTRACKING = 0x1001,
            SPI_GETMENUANIMATION = 0x1002,
            SPI_SETMENUANIMATION = 0x1003,
            SPI_GETCOMBOBOXANIMATION = 0x1004,
            SPI_SETCOMBOBOXANIMATION = 0x1005,
            SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,
            SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,
            SPI_GETGRADIENTCAPTIONS = 0x1008,
            SPI_SETGRADIENTCAPTIONS = 0x1009,
            SPI_GETKEYBOARDCUES = 0x100A,
            SPI_SETKEYBOARDCUES = 0x100B,
            SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,
            SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,
            SPI_GETACTIVEWNDTRKZORDER = 0x100C,
            SPI_SETACTIVEWNDTRKZORDER = 0x100D,
            SPI_GETHOTTRACKING = 0x100E,
            SPI_SETHOTTRACKING = 0x100F,
            SPI_GETMENUFADE = 0x1012,
            SPI_SETMENUFADE = 0x1013,
            SPI_GETSELECTIONFADE = 0x1014,
            SPI_SETSELECTIONFADE = 0x1015,
            SPI_GETTOOLTIPANIMATION = 0x1016,
            SPI_SETTOOLTIPANIMATION = 0x1017,
            SPI_GETTOOLTIPFADE = 0x1018,
            SPI_SETTOOLTIPFADE = 0x1019,
            SPI_GETCURSORSHADOW = 0x101A,
            SPI_SETCURSORSHADOW = 0x101B,
            SPI_GETUIEFFECTS = 0x103E,
            SPI_SETUIEFFECTS = 0x103F,
            SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,
            SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,
            SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,
            SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,
            SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,
            SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,
            SPI_GETCARETWIDTH = 0x2006,
            SPI_SETCARETWIDTH = 0x2007,
        }

        public enum Update
        {
            SPIF_UPDATEINIFILE = 0x1,
            SPIF_SENDCHANGE = 0x2,
            SPIF_SENDWININICHANGE = SPIF_SENDCHANGE,
        }
    }

    class GetSysColors
    {
        /*function GetSysColor(Index: Integer): Longint;
          Считывает текущий цвет отобpажаемого элемента Windows.
            Паpаметpы
             Index: Элемент отобpажения.
            Возвpащаемое значение
             Значение цвета RGB. 
        */
        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern int GetSysColor(COLOR nIndex);
        //Эти изменения будут работать только до перезагрузки
        [DllImport("User32.dll")]
        public static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

        public enum COLOR : int
        {//набор констант для GetSysColor(COLOR)
            SCROLLBAR = 0,
            BACKGROUND = 1,
            //DESKTOP = 1,
            ACTIVECAPTION = 2,
            INACTIVECAPTION = 3,
            MENU = 4,
            WINDOW = 5,
            WINDOWFRAME = 6,
            MENUTEXT = 7,
            WINDOWTEXT = 8,
            CAPTIONTEXT = 9,
            ACTIVEBORDER = 10,
            INACTIVEBORDER = 11,
            APPWORKSPACE = 12,
            HIGHLIGHT = 13,
            HIGHLIGHTTEXT = 14,
            BTNFACE = 15,
            //THREEDFACE = 15,
            BTNSHADOW = 16,
            //THREEDSHADOW = 16,
            GRAYTEXT = 17,
            BTNTEXT = 18,
            INACTIVECAPTIONTEXT = 19,
            BTNHIGHLIGHT = 20,
            //TREEDHIGHLIGHT = 20,
            //THREEDHILIGHT = 20,
            //BTNHILIGHT = 20,
            THREEDDKSHADOW = 21,
            THREEDLIGHT = 22,
            INFOTEXT = 23,
            INFOBK = 24
        }
    }

    class GetSysTimes
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void GetSystemTime(out SYSTEMTIME lpSystemTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;
        }
    }

    class GetCursPosit
    {
        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern bool GetCursorPos(out Point pt);

        internal struct Point
        {
            public int X;
            public int Y;
        }
    }

    class MovWindow
    {//переместить окно
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
    }
}
