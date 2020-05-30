using IRC_Client.Models;
using IRC_Client.Views;
using IRC_Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRC_Client
{
    class ClientLaunch
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("CLIENT: START");

            LaunchGUI();
        }

        private static void LaunchGUI()
        {
            int port;

            TcpChannel channelTcp;

            /* Provides the implementation for the server formatter channel sink 
             * provider that uses the BinaryFormatter */
            BinaryServerFormatterSinkProvider SinkProvider = new BinaryServerFormatterSinkProvider();
            
            SinkProvider.TypeFilterLevel = TypeFilterLevel.Full;

            // Represents a generic collection of key/value pairs
            IDictionary props = new Hashtable();
            
            port = Utils.GetFreeTcpPort();
            
            Models.Client.Instance.Port = port;
            
            props["port"] = port;

            /* Provides a channel implementation 
             * that uses the TCP protocol to transmit messages */
            channelTcp = new TcpChannel(props, null, SinkProvider);

            /* Provides static methods to aid with remoting channel registration,
             * resolution, and URL discovery */
            ChannelServices.RegisterChannel(channelTcp, false);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // START
            Application.Run(new MainView());
        }
    }
}
