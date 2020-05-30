using IRC_Client.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRC_Common.Communication
{
    public class PeerCommunicatorContainer : MarshalByRefObject
    {
        public static PeerCommunicator Communicator { get; set; }

        public PeerCommunicator GetCommunicator()
        {
            return Communicator;
        }
    }
}
