using IRC_Client.Comunication;
using IRC_Client.Models;
using IRC_Client.Views;
using IRC_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.TabControl;

namespace IRC_Client.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        #region Singleton

        /* aims to ensure that one and only one instance is created 
         * for a given class, and to provide a global access point 
         * to that instance */

        private static ChatViewModel instance;

        public static ChatViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChatViewModel();
                return instance;
            }
        }

        private ChatViewModel()
        {
        }

        #endregion

        #region Accessors
        public Control Controller { get; set; }
        public ChatView View { get; set; }
        public TabPageCollection Pages { get; set; }

        private string messageText;

        public string MessageText
        {
            get
            {
                return messageText;
            }

            set
            {
                if (messageText != value)
                {
                    messageText = value;

                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(MessageText)));
                }
            }
        }

        public int ActivePage { get; set; }

        #endregion

        #region Public Methods

        public void Start()
        {
            Models.Client.Instance.MessageEvent += HandleMessage;
            Models.Client.Instance.MessageGroupEvent += HandleGroupMessage;
            Models.Client.Instance.EndCommunicationEvent += HandleEndCommunication;
        }

        public void Finish()
        {
            Models.Client.Instance.MessageEvent -= HandleMessage;
            Models.Client.Instance.MessageGroupEvent -= HandleGroupMessage;
            Models.Client.Instance.EndCommunicationEvent -= HandleEndCommunication;
            foreach (TabPage page in Pages)
            {
                ((ChatTabPage)page).EndCommunication();
                page.Dispose();
                Pages.Remove(page);
            }
            instance = null;
        }

        public void HandleMessage(IClient sender, string message)
        {
            foreach (TabPage page in Pages)
            {
                if (((ChatTabPage)page).HandleMessage(sender, message))
                    return;
            }
        }

        public void HandleGroupMessage(IClient sender, string hash, string message)
        {
            foreach (TabPage page in Pages)
            {
                if (((ChatTabPage)page).HandleGroupMessage(sender, hash, message))
                    return;
            }
        }

        public void HandleEndCommunication(IClient sender)
        {
            foreach (TabPage page in Pages)
            {
                ((ChatTabPage)page).HandleEndCommunication(sender);
            }
        }

        public void StartChat(IClient client)
        {
            if (View == null)
            {
                View = ChatView.Instance;
            }
            PeerCommunicator pc = Utils.GetClientCommunicator(client);
            View.AddChat(client, pc);
            View.ShowChatView();
        }

        public void StartGroupChat(string hash)
        {
            if (View == null)
            {
                View = ChatView.Instance;
            }
            View.AddGroupChat(hash);
            View.ShowChatView();
        }

        public void SendMessage()
        {
            string text = MessageText;
            MessageText = "";
            
            if (text == null || text.Length == 0)
                return;

            ((ChatTabPage) Pages[ActivePage]).SendMessage(text);
        }

        #endregion

        #region Property Change

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
