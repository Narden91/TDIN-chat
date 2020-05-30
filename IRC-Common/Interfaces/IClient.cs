using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRC_Common
{
    public abstract class IClient : MarshalByRefObject
    {
        public string Nickname { get; set; }

        public string RealName { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public bool IsLogged
        {
            get
            {
                return Port != 0;
            }
        }

        public IClient(string nickname, string name, string address, int port) {
            this.Nickname = nickname;
            this.RealName = name;
            this.Address = address;
            this.Port = port;
        }

        public IClient(string nickname) : this(nickname, null, null, 0) { }

        public abstract bool HandleInvite(IClient requestingClient);

        public abstract bool HandleGroupInvite(IClient requestingClient, string hash);

        public abstract void ReceiveMessage(IClient sender, string message);

        public abstract void ReceiveGroupMessage(IClient sender, string hash, string message);

        public abstract void EndCommunication(IClient sender);
    }
}
