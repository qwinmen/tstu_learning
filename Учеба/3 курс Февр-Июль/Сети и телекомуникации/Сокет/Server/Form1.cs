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

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Connect()
        {

            // Устанавливаем для сокета локальную конечную точку 
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);
// Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
// Назначаем сокет локальной конечной точке и слушаем входящие сокеты 
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                // Начинаем слушать соединения 
                while (true)
                {
                    WriteLine("Ожидаем соединение через порт "+ ipEndPoint);
                    // Программа приостанавливается, ожидая входящее соединение 
                    Socket handler = sListener.Accept();
                    string data = null;
                    // Мы дождались клиента, пытающегося с нами соединиться 
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    // Показываем данные на консоли 
                    WriteLine("Полученный текст: " + data + "\n\n");
                    // Отправляем ответ клиенту 
                    string reply = "Спасибо за запрос в " + data.Length.ToString() + " символов";
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
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

        private void WriteLine(string msg)
        {
            textBox1.Text += msg + String.Concat(Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
        }
    }
}