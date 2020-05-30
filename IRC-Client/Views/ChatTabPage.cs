using IRC_Client.Comunication;
using IRC_Client.Models;
using IRC_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRC_Client.Views
{
    public class ChatTabPage : TabPage
    {
        private IClient user;
        private string GroupHash;
        private PeerCommunicator pc;
        private ChatUserControl control;
        private ChatView view;

        public ChatTabPage(IClient user, PeerCommunicator pc, ChatView view)
        {
            this.user = user;
            this.pc = pc;
            this.view = view;
            Initialize();
        }

        public ChatTabPage(string group, ChatView view)
        {
            this.GroupHash = group;
            this.view = view;
            Initialize();
        }

        private void Initialize()
        {
            if (this.GroupHash == null)
            {
                control = new ChatUserControl(user, pc);
                Text = user?.RealName;
            }
            else
            {
                control = new ChatUserControl(this.GroupHash);
                Text = this.GroupHash;
            }

            Controls.Add(control);
        }

        public async void SendMessage(string message)
        {
            if(GroupHash == null)
            {
                await Task.Run(() => pc.SendMessage(Models.Client.Instance, message));
            }
            else
            {
                ServerConnection serverConnection = Models.Client.Instance.ServerConnection;
                if (serverConnection == null)
                    return;

                IServer server = serverConnection.Connection;
                if (server == null)
                    return;

                await Task.Run(() => server.SendMessageChatRoom(Models.Client.Instance, GroupHash, message));
            }

            control.SendMessage(message);
        }

        public bool HandleMessage(IClient sender, string message)
        {
            if (user == null)
                return false;

            if(sender.Nickname != user.Nickname)
                return false;

            if(message == null || message.Length == 0)
            {
                MessageBox.Show(sender.Nickname + " HAS LEFT THE CONVERSATION", "USER DISCONNECTED", MessageBoxButtons.OK);
                Terminate();
            }

            control.ReceiveMessage(message);

            return true;
        }

        public bool HandleGroupMessage(IClient sender, string hash, string message)
        {
            if (this.GroupHash == null)
                return false;

            if (!hash.Equals(this.GroupHash))
                return false;

            if (message == null || message.Length == 0)
            {
                MessageBox.Show(sender.Nickname + " HAS LEFT THE CONVERSATION", "USER DISCONNECTED", MessageBoxButtons.OK);
                Terminate();
            }

            control.ReceiveGroupMessage(sender, message);

            return true;
        }

        public bool HandleEndCommunication(IClient sender)
        {
            if (sender.Nickname != user.Nickname)
                return false;

            Terminate();

            return true;
        }

        public void Terminate()
        {
            Utils.ControlInvoke(this, () =>
            {
                view.RemoveTab(this);
                this.Dispose();
            });
        }

        public async void EndCommunication()
        {
            if (GroupHash == null)
            {
                await Task.Run(() => pc.SendMessage(Models.Client.Instance, null));
            }
            else
            {
                ServerConnection serverConnection = Models.Client.Instance.ServerConnection;
                if (serverConnection == null)
                    return;

                IServer server = serverConnection.Connection;
                if (server == null)
                    return;

                await Task.Run(() => server.SendMessageChatRoom(Models.Client.Instance, GroupHash, null));
            }

            control.SendMessage(null);
        }
    }
}
