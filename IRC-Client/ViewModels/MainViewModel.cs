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
    class MainViewModel : INotifyPropertyChanged
    {
        #region Singleton

        /* aims to ensure that one and only one instance is created 
         * for a given class, and to provide a global access point 
         * to that instance */

        private static MainViewModel instance;

        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainViewModel();
                return instance;
            }
        }

        private Models.Client Client;
        private Connection ServerConnection;

        private MainViewModel()
        {
            this.Client = Models.Client.Instance;
            this.ServerConnection = this.Client.ServerConnection;
        }

        #endregion

        #region Accessors
        public Control Controller { get; set; }

        public string Nickname
        {
            get
            {
                return this.Client.Nickname;
            }

            set
            {
                if(this.Client.Nickname != value)
                {
                    this.Client.Nickname = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(Nickname)));   
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

        public string ServerAddress
        {
            get
            {
                return this.ServerConnection.Address;
            }

            set
            {
                if (this.ServerConnection.Address != value)
                {
                    this.ServerConnection.Address = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(ServerAddress)));
                }
            }
        }

        public string ServerPort
        {
            get
            {
                return this.ServerConnection.Port;
            }

            set
            {
                if (this.ServerConnection.Port != value)
                {
                    this.ServerConnection.Port = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(ServerPort)));
                }
            }
        }

        public string Status
        {
            get
            {
                return this.ServerConnection.Status;
            }

            set
            {
                if (this.ServerConnection.Status != value)
                {
                    this.ServerConnection.Status = value;
                    Utils.ControlInvoke(this.Controller, () => this.NotifyPropertyChanged(nameof(Status)));
                }
            }
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

        #region Public Methods

        public bool Login()
        {
            try
            {
                bool validLogin = this.Client.Login(this.Nickname, this.Password);
                if (!validLogin)
                {
                    this.Status = "ERROR: LOGIN INCORRECT";
                }

                return validLogin;
            }
            catch (Exception ex)
            {
                this.Status = ex.Message;
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Register()
        {
            IServer connection = Models.Client.Instance.ServerConnection.Connection;

            try
            {
                int result = connection.Register(this.Nickname, this.RealName, this.Password);

                // Set the reason
                string reason;
                Utils.ErrorCodes.TryGetValue(result, out reason);
                this.Status = reason;

                return result == 0;
            }
            catch (Exception ex)
            {
                this.Status = ex.Message;
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        #endregion
    }
}
