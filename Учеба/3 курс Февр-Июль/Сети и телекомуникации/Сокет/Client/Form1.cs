using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets; 

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Connect()
        {
            try
            {
                SendMessageFromSocket(11000);
            }
            catch (Exception ex)
            {
                WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            } 


        }


        private void SendMessageFromSocket(int port)
        {
            // Буфер для входящих данных 
            byte[] bytes = new byte[1024];
            // Соединяемся с удаленным устройством 
            // Устанавливаем удаленную точку для сокета 
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Соединяем сокет с удаленной точкой 
            sender.Connect(ipEndPoint);
             WriteLine("Введите сообщение: ");
            string message = Console.ReadLine();
             WriteLine("Сокет соединяется с " + sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);
            // Отправляем данные через сокет 
            int bytesSent = sender.Send(msg);
            // Получаем ответ от сервера 
            int bytesRec = sender.Receive(bytes);
            WriteLine("\nОтвет от сервера: "+ Encoding.UTF8.GetString(bytes, 0, bytesRec));
            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
            if (message.IndexOf("<TheEnd>") == -1)
                SendMessageFromSocket(port);
            // Освобождаем сокет 
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
        }


        private void WriteLine(string msg)
        {
            textBox1.Text += msg + string.Concat(Environment.NewLine);

        }



    }
}
