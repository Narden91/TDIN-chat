using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRC_Common.Models
{
    public class LoggedClient : IClient
    {
        public LoggedClient(string nickname, string name, string address, int port) : base(nickname, name, address, port)
        {
        }

        public override bool HandleInvite(IClient requestingClient)
        {
            return false;
        }

        public override bool HandleGroupInvite(IClient requestingClient, string hash)
        {
            return false;
        }

        public override void ReceiveMessage(IClient sender, string message)
        {
        }

        public override void ReceiveGroupMessage(IClient sender, string hash, string message)
        {
        }

        public override void EndCommunication(IClient sender)
        {
        }
    }
}
