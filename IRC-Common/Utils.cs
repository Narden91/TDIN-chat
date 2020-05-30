using IRC_Client.Comunication;
using IRC_Common.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRC_Common
{
    public class Utils
    {
        public static readonly Dictionary<int, string> ErrorCodes = new Dictionary<int, string>()
        {
            {-1,   "Database Error" },
            { 0,   "Success" },
            { 1,   "Invalid nickname" },
            { 2,   "Invalid real name" },
            { 3,   "Invalid password" },
            { 4,   "Username already exists" }
        };

        public static string GetLocalIp()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public static int GetFreeTcpPort()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0));
            
            int port = ((IPEndPoint)sock.LocalEndPoint).Port;
            
            sock.Close();
            
            return port;
        }

        public static void ControlInvoke(Control c, Action a)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate { a(); }));
            }
            else
            {
                a();
            }
        }

        public static PeerCommunicator GetClientCommunicator(IClient client)
        {
            return GetClientCommunicator(client.Address, client.Port);
        }

        private static PeerCommunicator GetClientCommunicator(string address, int port)
        {
            PeerCommunicatorContainer container = (PeerCommunicatorContainer)Activator.GetObject(
                typeof(PeerCommunicatorContainer), "tcp://" + address + ":" + port + "/IRC-Client/PeerCommunicator");
            return container.GetCommunicator();
        }
    }
}
