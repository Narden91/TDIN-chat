using IRC_Client.Comunication;
using IRC_Client.Views;
using IRC_Common;
using IRC_Common.Communication;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRC_Client.Models
{
    public class Client : IClient
    {
        #region Singleton

        /* aims to ensure that one and only one instance is created 
         * for a given class, and to provide a global access point 
         * to that instance */

        private static Client instance;

        public static Client Instance
        {
            get
            {
                if (instance == null)
                    instance = new Client();
                return instance;
            }
        }
        #endregion

        #region Private Methods

        private Client() : base(null)
        {
            this.ServerConnection = new ServerConnection();
            this.SessionSessionEvent = new SessionSubscriber(this);
        }

        private async void GetName()
        {
            string res = await Task.Run(() => ServerConnection.Connection.GetUserRealName(Nickname));
            this.RealName = res;
        }

        #endregion

        #region Accessors

        public string Password { get; set; }

        public ServerConnection ServerConnection { get; set; }

        public Dictionary<string, IClient> LoggedClients { get; }

        #endregion

        #region Session Subscriber

        private SessionSubscriber SessionSessionEvent;

        public event SessionUpdateHandler SessionsEvent;

        public void HandleSession(IClient info)
        {
            if (SessionsEvent != null)
            {
                SessionsEvent(info);
            }
        }

        #endregion

        #region PeerToPeer

        /* Network in which the nodes are equivalent, 
         * while being able to act as client and server towards 
         * the other terminal nodes (hosts) of the network */

        private PeerCommunicator Communicator { get; set; }
        public event HandleMessage MessageEvent;
        public event HandleGroupMessage MessageGroupEvent;
        public event HandleChat NewChatEvent;
        public event HandleGroupChat NewGroupChatEvent;
        public event HandleEndCommunication EndCommunicationEvent;
        private Dictionary<string, PeerCommunicator> peers = new Dictionary<string, PeerCommunicator>();

        public bool InviteClient(IClient client)
        {
            if (client == null)
                return false;

            PeerCommunicator pc;

            // If communication already exists
            if (peers.TryGetValue(client.Nickname, out pc))
            {
                MessageBox.Show(client.Nickname +
                    " IS ALREADY CHATTING WITH YOU!", "INVITATION NOT ALLOWED",
                    MessageBoxButtons.OK);

                return false;
            }

            pc = Utils.GetClientCommunicator(client);
            
            bool result = pc.RequestChat(this);

            // Request for a new communication
            if (result)
            {
                peers.Add(client.Nickname, pc);
                NewChatEvent?.Invoke(client);
            }

            return result;
        }

        public bool InviteClients(List<IClient> clients)
        {

            ServerConnection serverConnection = Client.Instance.ServerConnection;
            
            if (serverConnection == null)
                return false;

            IServer server = serverConnection.Connection;
            
            if (server == null)
                return false;

            string chatRoomHash = server.CreateChatRoom(Client.Instance, clients);
            
            if (chatRoomHash != "")
            {
                NewGroupChatEvent?.Invoke(chatRoomHash);
            }
            
            return chatRoomHash != "";
        }

        public override bool HandleInvite(IClient requestingClient)
        {
            var confirmResult = MessageBox.Show(requestingClient.Nickname +
                " INVITED YOU TO CHAT. DO YOU ACCEPT?", "CHAT INVITE",
                MessageBoxButtons.YesNo);

            // Invitation accepted
            if (confirmResult == DialogResult.Yes)
            {
                peers.Add(requestingClient.Nickname, Utils.GetClientCommunicator(requestingClient));
                NewChatEvent?.Invoke(requestingClient);
                return true;
            }

            return false;
        }

        public override bool HandleGroupInvite(IClient requestingClient, string hash)
        {
            var confirmResult = MessageBox.Show(requestingClient.Nickname + 
                " INVITED YOU TO GROUP CHAT (" + hash + "). DO YOU ACCEPT?", "CHAT INVITE",
                MessageBoxButtons.YesNo);

            // Invitation accepted
            if (confirmResult == DialogResult.Yes)
            {
                NewGroupChatEvent?.Invoke(hash);
                return true;
            }

            return false;
        }

        public override void ReceiveMessage(IClient sender, string message)
        {
            MessageEvent?.Invoke(sender, message);
        }

        public override void ReceiveGroupMessage(IClient sender, string hash, string message)
        {
            MessageGroupEvent?.Invoke(sender, hash, message);
        }

        private void SetupPeerCommunicator()
        {
            this.Communicator = new PeerCommunicator(this);
           
            PeerCommunicatorContainer.Communicator = this.Communicator;
            
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PeerCommunicatorContainer),
                "IRC-Client/PeerCommunicator", WellKnownObjectMode.Singleton);
        }

        public override void EndCommunication(IClient sender)
        {
            EndCommunicationEvent?.Invoke(sender);
            peers.Remove(sender.Nickname);
        }

        #endregion

        #region Authentication Methods

        public bool Login(string nick, string password)
        {
            IServer connection = ServerConnection.Connection;
            
            if (connection == null)
                return false;
            
            string ip = Utils.GetLocalIp();

            bool result = connection.Login(nick, password, ip, Port);
            
            // Correct LOGIN
            if (result)
            {
                this.Nickname = nick;
                this.Address = ip;
                GetName();
                connection.SessionUpdateEvent += SessionSessionEvent.Handle;
                SetupPeerCommunicator();
            }

            return result;
        }

        public bool MaybeLogout()
        {
            if (ServerConnection == null)
                return false;

            IServer connection = ServerConnection.Connection;
            
            if (connection == null)
                return false;

            connection.SessionUpdateEvent -= SessionSessionEvent.Handle;

            return connection.Logout(this.Nickname, this.Password);
        }

        #endregion
}
}
