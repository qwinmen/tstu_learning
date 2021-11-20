using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Collections;

namespace csMailSlot
{

  public partial class vMailslot : UserControl
  {
    private string[] _MessageQue = new string[4]; // Used to store previous messages to avoid duplicates
    private int seqNum = 0;                       // Used to generate the sequence number for use in the above
    private string _SlotName;                     // Name of the slot
    private IntPtr _ReadHandle;                   // Handle to the local slot
    private IntPtr _WriteHandle;                  // Handle to the remote slot
    private double _Rx, _Tx;                      // To store the bytes sent/received
    private Byte[] EncKey = new byte[] { 43, 12, 33, 56, 87, 65, 54, 43, 45, 56, 37, 23, 86 }; // Key used with RC4
    private Thread readThread;                    // Thread to run readSlot on
    private ArrayList fragQ = new ArrayList();    // For use in defragmenting large messages on receipt

    // Event declarations
    public delegate void SentTextHandler(string SentText);
    public event SentTextHandler SentText;  

    public delegate void BWUsageHandler(double Rx, double Tx);
    public event BWUsageHandler BWUsage;

    public delegate void ReceivedDataHandler(string User, string Command, string Text);
    public event ReceivedDataHandler OnReceivedData;         

    // P/Invoke signatures for required API imports
    #region DLL Imports
    [DllImport("kernel32.dll")]
    static extern IntPtr CreateMailslot(string lpName,
                                        uint nMaxMessageSize,
                                        uint lReadTimeout,
                                        IntPtr lpSecurityAttributes);

    [DllImport("kernel32.dll")]
    static extern bool GetMailslotInfo(IntPtr hMailslot,
                                       int lpMaxMessageSize,
                                       ref int lpNextSize,
                                       IntPtr lpMessageCount,
                                       IntPtr lpReadTimeout);

    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern IntPtr CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
        [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
        int securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        int flags,
        IntPtr template);

    [DllImport("kernel32.dll", SetLastError = true)]
    private unsafe static extern bool ReadFile(
        IntPtr hFile,                      // handle to file
        void* lpBuffer,                // data buffer
        int nNumberOfBytesToRead,       // number of bytes to read
        int* lpNumberOfBytesRead,    // number of bytes read
        int overlapped
        );

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool WriteFile(
      IntPtr hFile,
      byte[] lpBuffer,
      uint nNumberOfBytesToWrite,
      out uint lpNumberOfBytesWritten,
      [In] ref System.Threading.NativeOverlapped lpOverlapped);

    #endregion

    public vMailslot()
    {
      InitializeComponent();
      readThread = new Thread(new ThreadStart(ThreadReadSlot));
      readThread.Priority = ThreadPriority.Lowest; // Set to .Lowest to minimize cpu usage
    }

    public string SlotName // Read / Set the slotname
    {
      get { return _SlotName; }
      set { _SlotName = value; }
    }


    // Using byte* p requires unsafe code to be declared
    // Unsafe code must be allowed in the project build options or it will not compile
    unsafe public string ReadSlot()
    {
      int iMsgSize, iRead;
      byte[] Data = new byte[424];
      bool IsData;
      bool IsDupe = false;
      iMsgSize = 0;
      iRead = 0;
      byte[] RetValue;
      string sRetVal;

      GetMailslotInfo(_ReadHandle, 0, ref iMsgSize, IntPtr.Zero, IntPtr.Zero);
      //Read the current status of the mailslot, notably the size of any waiting messages

      IsData = (iMsgSize > 0);

      if (IsData)
      {
        fixed (byte* p = Data)
        {
          ReadFile(_ReadHandle, p, iMsgSize, &iRead, 0);  
          RetValue = new byte[iMsgSize];                  
          System.Array.Copy(Data, RetValue, iMsgSize);    
          RC4(ref RetValue, EncKey);                      
          _Rx += iMsgSize;                                
          if (BWUsage != null) BWUsage(_Rx, _Tx);         
        }

        sRetVal = System.Text.Encoding.Default.GetString(RetValue); 

        foreach (string prevLine in _MessageQue)
        {
          if (sRetVal == prevLine)
            IsDupe = true;
        }

        if (IsDupe == false)
        {
          _MessageQue[0] = _MessageQue[1];
          _MessageQue[1] = _MessageQue[2];
          _MessageQue[2] = _MessageQue[3];
          _MessageQue[3] = sRetVal;

          return sRetVal;
        }
          
      }

      return "";
    }

    public void Close()
    {
      readThread.Abort();
    }

    // To send a message to an entire domain or workgroup pass "*" as Scope
    // To send a message to a particular computer, pass the computer name instead
    // If a slot of the same name is not "connected" on the remote computer Windows will
    // automatically ignore any messages received.
    public bool Connect(string Scope)
    {
      if (_SlotName.Length > 0)
      {
        _ReadHandle = CreateMailslot("\\\\.\\mailslot\\" + _SlotName, 0, 0, IntPtr.Zero);
        _WriteHandle = CreateFile("\\\\" + Scope + "\\mailslot\\" + _SlotName, FileAccess.Write, FileShare.Read, 0, FileMode.Open, 0, IntPtr.Zero);
      }
      if ((_ReadHandle.ToInt32() * _WriteHandle.ToInt32()) > 0)
      {
        readThread.Start();
        return true;
      }

      return false;
    }

    // When using * for Scope, Windows limits the size of a single message to 424 bytes
    // Messages over this length must be broken up and sent in fragments
    // While this is not required when sending to a specific computer, this function
    // is always called
    public string[] sbSplit(string Username, string Command, string Text, int MaxLen)
    {
      int Index, txtLeft, txtLen, offS, Iteration;
      string tmpStr;
      string[] ReturnText = new string[1];

      txtLen = Text.Length;
      txtLeft = txtLen;
      offS = 0;
      Index = 0;
      Iteration = 0;
      while (txtLeft > 0)
      {
        Iteration++;
        if (ReturnText.Length <= Iteration)
          ReturnText = ResizeArray(ReturnText, Iteration + 1);
        if (txtLeft <= MaxLen)
        {
          tmpStr = Text.Substring(Text.Length - txtLeft, txtLeft);
          seqNum++;
          ReturnText[Iteration] = seqNum.ToString() + "§" + Username + "§" + "END" + "§" + Command + "§" + tmpStr;

          return ReturnText;
        }

        tmpStr = Text.Substring(offS, MaxLen);
        Index = tmpStr.Length - 1;
        while ((tmpStr[Index] != ' ') & (Index > 0))
        {
          Index--;
        }

        if (Index <= 0)
          Index = MaxLen;

        tmpStr = tmpStr.Substring(0, Index);
        txtLeft = txtLeft - tmpStr.Length;
        seqNum++;
        ReturnText[Iteration] = seqNum.ToString() + "§" + Username + "§" + "FRAG" + "§" + Command + "§" + tmpStr;

        offS += Index;
      }

      return null;
    }

    public static string[] ResizeArray(System.Array oldArray, int newSize)
    {
      int oldSize = oldArray.Length;
      System.Type elementType = oldArray.GetType().GetElementType();
      System.Array newArray = System.Array.CreateInstance(elementType, newSize);
      int preserveLength = System.Math.Min(oldSize, newSize);
      if (preserveLength > 0)
        System.Array.Copy(oldArray, newArray, preserveLength);
      return (string[])newArray;
    }

    public bool SendText(string Username, string Command, string Data)
    {
      uint bytesWritten = 0;
      int iCounter;
      string[] SplitData;
      string PreEncode;
      Byte[] EncVar;

      System.Threading.NativeOverlapped stnOverlap = new System.Threading.NativeOverlapped();

      Data = Data.Trim();
      if (Data.Length > 0)
      {
        SplitData = sbSplit(Username, Command, Data, 400 - Username.Length - Command.Length - seqNum.ToString().Length - 7);

        for (iCounter = 0; iCounter < SplitData.Length; iCounter++)
          if (SplitData[iCounter] != null)
          {
            EncVar = System.Text.Encoding.Default.GetBytes(SplitData[iCounter]);
            PreEncode = System.Text.Encoding.Default.GetString(EncVar);
            RC4(ref EncVar, EncKey);

            WriteFile(_WriteHandle, EncVar, (uint)EncVar.Length, out bytesWritten, ref stnOverlap);
            if (SentText != null)
              SentText(PreEncode);
          }
        if (bytesWritten > 0)
        {
          _Tx += bytesWritten;
          if (BWUsage != null) BWUsage(_Rx, _Tx);
          return true;
        }
      }
      return false;
    }

    public void RC4(ref Byte[] bytes, Byte[] key)
    {
      Byte[] s = new Byte[256];
      Byte[] k = new Byte[256];
      Byte temp;
      int i, j, t;
      int byteLen = bytes.GetLength(0);
      int keyLen = key.GetLength(0);

      for (i = 0; i < 256; i++)
      {
        s[i] = (Byte)i;
        k[i] = key[i % keyLen];
      }

      j = 0;
      for (i = 0; i < 256; i++)
      {
        j = (j + s[i] + k[i]) % 256;
        temp = s[i];
        s[i] = s[j];
        s[j] = temp;
      }

      i = j = 0;
      for (int x = 0; x < byteLen; x++)
      {
        i = (i + 1) % 256;
        j = (j + s[i]) % 256;
        temp = s[i];
        s[i] = s[j];
        s[j] = temp;
        t = ((int)s[i] + s[j]) % 256;
        bytes[x] ^= s[t];
      }
    }

    
    private void AddFrag(string User, string Command, string Text)
    {
      bool isNewFrag = true;

      foreach (UserFrag frag in fragQ)
      {
        if (frag.User == User)
        {
          frag.AddFrag(Text);
          isNewFrag = false;
        }
      }

      if (isNewFrag == true)
      {
        UserFrag newFrag = new UserFrag(User, Command, Text);
        fragQ.Add(newFrag);
      }
    }

    private string Defrag(string User, string Text)
    {
      string result = "";
      UserFrag rFrag = null;

      foreach (UserFrag frag in fragQ)
      {
        if (frag.User == User)
        {
          result = frag.Defrag(Text);
          rFrag = frag;
        }
      }
      if (result == "")
        result = Text;
      if (rFrag != null)
        fragQ.Remove(rFrag);
      return result;
    }

    private void ThreadReadSlot()
    {
      string readData = "";
      string[] parsedData = new string[5];

      while (true)
      {
        try
        {
          readData = this.ReadSlot();
          if (readData.Length > 0)
            if (OnReceivedData != null)
            {
              parsedData = readData.Split('§');
              if (parsedData[2] == "FRAG")
              {
                AddFrag(parsedData[1], parsedData[3], parsedData[4]);
              }
              else
                OnReceivedData(parsedData[1], parsedData[3], Defrag(parsedData[1], parsedData[4]));
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message + "\r\n" + ex.Source + "\r\n" + ex.StackTrace); }
        Thread.Sleep(200);
      }
    }

    private class UserFrag
    {
      private string _UserName;
      private string _Command;
      private string _Text;

      public string User
      {
        get { return _UserName; }
      }

      public string Defrag(string Text)
      {
        return _Text + Text;
      }

      public UserFrag(string Username, string Command, string Text)
      {
        _UserName = Username;
        _Command = Command;
        _Text = Text;
      }

      public void AddFrag(string Text)
      {
        _Text += Text;
      }
    }
  }
}
