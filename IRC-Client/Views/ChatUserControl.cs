using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRC_Common;
using IRC_Client.Comunication;

namespace IRC_Client.Views
{
    public partial class ChatUserControl : UserControl
    {
        private static Color myUserColor = Color.Blue;
        private static Color peerColor = Color.DarkGreen;
        private static Color neutralColor = Color.Black;

        private IClient user;
        private PeerCommunicator pc;

        public ChatUserControl(IClient user, PeerCommunicator pc)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.user = user;
            this.pc = pc;
            Enabled = false;
            AddCenterText("WELCOME IN THE ROOM CHAT WITH " + user.Nickname, neutralColor);
            AddCenterText(System.Environment.NewLine, neutralColor);
        }

        public ChatUserControl(string hash)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Enabled = false;

            AddCenterText("WELCOME IN THE GROUP CHAT WITH " + hash, neutralColor);
            AddCenterText(System.Environment.NewLine, neutralColor);
        }

        public void SendMessage(string message)
        {
            if (message == null)
                return;
            Utils.ControlInvoke(this, () => AddRightText(message + System.Environment.NewLine, myUserColor));
        }

        public void ReceiveMessage(string message)
        {
            if (message == null)
                return;
            Utils.ControlInvoke(this, () => AddLeftText(user.Nickname + " : " + message + System.Environment.NewLine, peerColor));
        }

        public void ReceiveGroupMessage(IClient client, string message)
        {
            if (message == null)
                return;
            Utils.ControlInvoke(this, () => AddLeftText(client.Nickname + " : " + message + System.Environment.NewLine, peerColor));
        }

        private void AddCenterText(string text, Color color)
        {
            AddText(text, color, HorizontalAlignment.Center);
        }

        private void AddRightText(string text, Color color)
        {
            AddText(text, color, HorizontalAlignment.Right);
        }

        private void AddLeftText(string text, Color color)
        {
            AddText(text, color, HorizontalAlignment.Left);
        }

        private void AddText(string text, Color color, HorizontalAlignment alignment)
        {
            chatText.SelectionStart = chatText.TextLength;
            chatText.SelectionLength = 0;

            // Font Chat Text
            chatText.Font = new Font("Microsoft Sans Serif", 10f);

            chatText.SelectionColor = color;
            chatText.SelectionAlignment = alignment;
            chatText.AppendText(text);
            chatText.SelectionColor = chatText.ForeColor;

            
        }
    }
}
