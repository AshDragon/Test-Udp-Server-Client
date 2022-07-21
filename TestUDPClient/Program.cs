using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestUDPClient
{
    class Program
    {

        static void Main(string[] args)
        {
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
                       
                // Создаем UdpClient
                UdpClient udpClient = new UdpClient();

                // Соединяемся с удаленным хостом
                udpClient.Connect(serverIP, 5555);

                string message = "Hello Server";
                byte[] data = Encoding.UTF8.GetBytes(message);
                int numberOfSentBytes = udpClient.Send(data, data.Length);
                udpClient.Close();

                Console.ReadKey();
            }
    }
}