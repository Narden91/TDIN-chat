using IRC_Common;
using System;

namespace IRC_Client.Comunication
{
    public delegate void HandleMessage(IClient sender, string message);
    public delegate void HandleGroupMessage(IClient sender, string hash, string message);
    public delegate void HandleChat(IClient sender);
    public delegate void HandleGroupChat(string hash);
    public delegate void HandleEndCommunication(IClient sender);

    public class PeerCommunicator : MarshalByRefObject
    {
        public IClient MyClient { get; }

        public PeerCommunicator(IClient client)
        {
            MyClient = client;
        }

        public bool RequestChat(IClient requestingClient)
        {
            return MyClient.HandleInvite(requestingClient);
        }

        public bool RequestGroupChat(IClient requestingClient, string hash)
        {
            return MyClient.HandleGroupInvite(requestingClient, hash);
        }

        public void SendMessage(IClient sender, string message)
        {
            MyClient.ReceiveMessage(sender, message);
        }

        public void SendGroupMessage(IClient sender, string hash, string message)
        {
            MyClient.ReceiveGroupMessage(sender, hash, message);
        }

        public void CloseChat(IClient sender)
        {
            MyClient.EndCommunication(sender);
        }
    }
}
