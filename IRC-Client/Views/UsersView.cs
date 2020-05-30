using IRC_Client.Comunication;
using IRC_Client.Models;
using IRC_Client.ViewModels;
using IRC_Common;
using IRC_Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Import the Material Skin
using MaterialSkin;
using MaterialSkin.Controls;

namespace IRC_Client.Views
{
    public partial class UsersView : MaterialForm
    {
        public UsersView()
        {
            this.InitializeComponent();
            UsersViewModel.Instance.Controller = this;
            this.MessagingViewBindingSource.Add(UsersViewModel.Instance);
            
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color scheme
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey600, Primary.DeepOrange300, Accent.Amber700, TextShade.WHITE);
        }

        private void MessagingViewLoad(object sender, EventArgs e)
        {
            RefreshUsers();
            Models.Client.Instance.SessionsEvent += new SessionUpdateHandler(HandleSession);
        }

        private void HandleSession(IClient info)
        {
            if (this.InvokeRequired)
            {
                Utils.ControlInvoke(this, () => HandleSession(info));
                return;
            }
            if (info.IsLogged)
            {
                IClient client = new LoggedClient(info.Nickname, info.RealName, info.Address, info.Port);
                UsersViewModel.Instance.LoggedUsers.Add(client);
                UserList.Items.Add(new ListViewItem(client.Nickname));
            }
            else
            {
                foreach (ListViewItem item in UserList.Items)
                {
                    if(item.Text.StartsWith(info.RealName))
                    {
                        UserList.Items.Remove(item);
                        break;
                    }
                }
            }
        }

        private void MessagingViewClosing(object sender, FormClosingEventArgs e)
        {
            if (ChatView.Exists)
            {
                ChatView.Instance.Terminate();
            }

            try
            {
                Models.Client.Instance.MaybeLogout();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void InviteButtonClick(object sender, EventArgs e)
        {
            if (UserList.SelectedIndices.Count == 0)
                return;

            if (UserList.SelectedIndices.Count > 1)
            {
                List<IClient> users = new List<IClient>();
                foreach (int index in UserList.SelectedIndices)
                {
                    users.Add(UsersViewModel.Instance.LoggedUsers[index]);
                }

                UsersViewModel.Instance.InviteClients(users);
            }
            else
            {
                int selectedUser = UserList.SelectedIndices[0];
                UsersViewModel.Instance.InviteClient(UsersViewModel.Instance.LoggedUsers[selectedUser]);
            }
        }

        private void RefreshUsers()
        {
            UsersViewModel.Instance.UpdateOnlineUsers();
            UserList.Items.Clear();
            foreach (IClient client in UsersViewModel.Instance.LoggedUsers)
            {
                ListViewItem item = new ListViewItem(client.Nickname);
                UserList.Items.Add(item);
            }
        }
    }
}
