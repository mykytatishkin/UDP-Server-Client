using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 11000));
            try
            {
                while(true)
                {
                    Console.WriteLine("Waiting for client...");
                    EndPoint remoteEp = new IPEndPoint(IPAddress.Loopback, 0);
                    var buffer = new byte[4096];
                    int size = socket.ReceiveFrom(buffer, ref remoteEp);
                    Console.WriteLine($"Recived: {Encoding.UTF8.GetString(buffer)}");
                    socket.SendTo(Encoding.UTF8.GetBytes("Hi from Server. Message was recived"), remoteEp);
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}