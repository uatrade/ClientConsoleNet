using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ClientConsole
{
    class Program
    {
        static int port = 777;

        static void Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 777);
            Socket listenSocet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listenSocet.Bind(iPEndPoint);
                listenSocet.Listen(13);
                Console.WriteLine("Сервер запущен ");
                while(true)
                {

                    Socket handle = listenSocet.Accept();
                    //Получаем сообщение
                    StringBuilder b = new StringBuilder();
                    byte[] data = new byte[1024]; //Буфер
                    int bytes=

                    do
                    {

                        b.Append(Encoding.Unicode.GetString(data));

                    } while (handle.Available>0);
                    Console.WriteLine(DateTime.Now.ToString()+":"+b.ToString());

                    string message = "Сообщение получено";
                    data = Encoding.Unicode.GetBytes(message);
                    handle.Send(data);
                    handle.Shutdown(SocketShutdown.Both);
                    handle.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
