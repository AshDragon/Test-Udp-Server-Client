using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;

namespace TestUDPServer
{

    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 5555);


            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newSocket.Bind(endpoint);

            Console.WriteLine(" Waiting for client connection ...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 5555);  
            EndPoint tmpRemote = (EndPoint)sender; 

            recv = newSocket.ReceiveFrom(data, ref tmpRemote);

            Console.Write("Message received from {0}: ", tmpRemote.ToString ());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));



            string welcom = "Welcome to my TestServer!";
            data = Encoding.ASCII.GetBytes(welcom);


            if (newSocket.Connected)
                newSocket.Send(data); 

            while(true)
            {
                if(newSocket.Connected)
                {
                    Console.WriteLine("Client Disconnected.");
                    break;
                }

                data = new byte[1024];
                recv = newSocket.ReceiveFrom(data, ref tmpRemote);

                if (recv == 0)
                {
                    break;
                }
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            }

            newSocket.Close();
            
        }
    }
}
    

