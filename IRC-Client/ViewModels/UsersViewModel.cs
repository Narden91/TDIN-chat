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

namespace IRC_Client.ViewModels
{
    class UsersViewModel : INotifyPropertyChanged
    {
        #region Singleton

        /* aims to ensure that one and only one instance is created 
         * for a given class, and to provide a global access point 
         * to that instance */

        private static UsersViewModel instance;

        public static UsersViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsersViewModel();
                return instance;
            }
        }

        private Models.Client Client;

        private UsersViewModel()
        {
            this.Client = Models.Client.Instance;
            this.Client.NewChatEvent += HandleChat;
            this.Client.NewGroupChatEvent += HandleGroupChat;
        }

        #endregion

        #region Accessors
        public Control Controller { get; set; }

        public string WelcomeText
        {
            get
            {
                return "WELCOME, " + this.Client.Nickname;
            }
        }

        public string Nickname
        {
            get
            {
                return this.Client.Nickname;
            }

            set
            {
                if (this.Client.Nickname != value)
                {
                    this.Client.Nickname = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(Nickname)));
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(WelcomeText)));
                }
            }
        }

        public string Password
        {
            get
            {
                return this.Client.Password;
            }

            set
            {
                if (this.Client.Password != value)
                {
                    this.Client.Password = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(Password)));
                }
            }
        }

        public string RealName
        {
            get
            {
                return this.Client.RealName;
            }

            set
            {
                if (this.Client.RealName != value)
                {
                    this.Client.RealName = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(RealName)));
                }
            }
        }

        private List<IClient> loggedUsers = new List<IClient>();

        public List<IClient> LoggedUsers
        {
            get
            {
                return this.loggedUsers;
            }

            set
            {
                if (this.loggedUsers != value)
                {
                    this.loggedUsers = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(LoggedUsers)));
                }
            }
        }

        #endregion

        #region Public Methods

        public void UpdateOnlineUsers()
        {
            this.LoggedUsers = this.Client.ServerConnection.Connection.LoggedUsers(this.Nickname);
        }

        public async void InviteClient(IClient client)
        {
            bool res = await Task.Run(() => Models.Client.Instance.InviteClient(client));
        }

        public async void InviteClients(List<IClient> clients)
        {
            bool res = await Task.Run(() => Models.Client.Instance.InviteClients(clients));
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

        #region Peer to Peer

        public void HandleChat(IClient sender)
        {
            Utils.ControlInvoke(this.Controller, () => ChatViewModel.Instance.StartChat(sender));
        }

        public void HandleGroupChat(string hash)
        {
            Utils.ControlInvoke(this.Controller, () => ChatViewModel.Instance.StartGroupChat(hash));
        }
        
        #endregion
    }
}
