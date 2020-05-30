using IRC_Client.Comunication;
using IRC_Client.Models;
using IRC_Client.ViewModels;
using IRC_Common;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.TabControl;

namespace IRC_Client.Views
{
    public partial class ChatView : MaterialForm
    {
        #region Singleton

        private static ChatView instance;

        public static ChatView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChatView();
                }

                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public ChatView()
        {
            InitializeComponent();
            ChatViewModel.Instance.Controller = this;
            ChatViewModelBindingSource.Add(ChatViewModel.Instance);
            ChatViewModel.Instance.View = this;
            ChatViewModel.Instance.Pages = ChatTabsControl.TabPages;
            
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey600, Primary.DeepOrange300, Accent.Amber700, TextShade.WHITE);

            ChatViewModel.Instance.Start();
        }

        #endregion

        #region Public methods

        public static bool Exists
        {
            get
            {
                return instance != null;
            }
        }

        public void ShowChatView()
        {
            if (instance.IsDisposed)
                instance = new ChatView();

            if (!instance.Visible)
                instance.Show();
        }

        public void AddChat(IClient client, PeerCommunicator pc)
        {
            ChatTabPage t = new ChatTabPage(client, pc, this);
            ChatTabsControl.TabPages.Add(t);
        }

        public void AddGroupChat(string hash)
        {
            ChatTabPage t = new ChatTabPage(hash, this);
            ChatTabsControl.TabPages.Add(t);
        }

        public void RemoveTab(ChatTabPage tab)
        {
            ChatTabsControl.TabPages.Remove(tab);
        }

        public void Terminate()
        {
            Dispose();
            instance = null;
        }

        #endregion

        #region Events

        private void SendButton_Click(object sender, EventArgs e)
        {
            ChatViewModel.Instance.SendMessage();
        }

        private void ChatView_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChatViewModel.Instance.Finish();
            Terminate();
        }

        private void ChatTabsControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatViewModel.Instance.ActivePage = ChatTabsControl.SelectedIndex;
        }

        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                ChatViewModel.Instance.MessageText = MessageInput.Text;
            }
        }

        #endregion
    }
}
