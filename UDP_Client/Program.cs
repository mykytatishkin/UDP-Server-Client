using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            try
            {
                Console.WriteLine("Enter message");
                var msg = Console.ReadLine();
                var serverEp = new IPEndPoint(IPAddress.Loopback, 11000);
                socket.SendTo(Encoding.UTF8.GetBytes(msg), serverEp);

                var buffer = new byte[1024];
                EndPoint remoteEp = new IPEndPoint(IPAddress.Loopback, 0);
                int size = socket.ReceiveFrom(buffer, ref remoteEp);
                Console.WriteLine($"From Server: {Encoding.UTF8.GetString(buffer)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}