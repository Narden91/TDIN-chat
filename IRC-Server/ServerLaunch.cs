using IRC_Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace IRC_Server
{
    public class ServerLaunch
    {
        public static void Main(string[] args)
        {
            SetupServer();
        
            Console.WriteLine(" Press any key to terminate");
            Console.WriteLine("----------------------------");
            Console.ReadKey();
            Console.WriteLine("SERVER ENDED!");
        }

        private static void SetupServer()
        {
            int port;
            TcpChannel channel;

            /* Provides the implementation for the server formatter channel sink 
             * provider that uses the BinaryFormatter */
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            
            provider.TypeFilterLevel = TypeFilterLevel.Full;
            
            // Represents a generic collection of key/value pairs
            IDictionary props = new Hashtable();
            
            port = 35994;
            
            props["port"] = port;

            /* Provides a channel implementation 
             * that uses the TCP protocol to transmit messages */
            channel = new TcpChannel(props, null, provider);

            /* Provides static methods to aid with remoting channel registration,
             * resolution, and URL discovery */
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(new Server().GetType(),
                "IRC-Server/Server", WellKnownObjectMode.Singleton);

            Console.WriteLine("----------------------------");
            Console.WriteLine("------ SERVER STARTED ------");
            Console.WriteLine("IP:" + Utils.GetLocalIp() + " PORT:" + port);
            Console.WriteLine("----------------------------");
        }
    }
}
