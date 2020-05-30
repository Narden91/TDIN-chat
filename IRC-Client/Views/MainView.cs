using IRC_Client.Models;
using IRC_Client.ViewModels;
using IRC_Common;
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
    public partial class MainView : MaterialForm
    {
        public MainView()
        {
            //Initialize the GUI object
            this.InitializeComponent();
            MainViewModel.Instance.Controller = this;
            this.MainViewBindingSource.Add(MainViewModel.Instance);

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color scheme for the GUI
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey600, Primary.DeepOrange300, Accent.Amber700, TextShade.WHITE);
        }

        private async void LoginButtonClick(object sender, EventArgs e)
        {
            LoginButton.Enabled = false;

            // Check Valid Login
            bool validLogin = await Task.Run<bool>(() => MainViewModel.Instance.Login());
            
            //If the Login is valid change to Online Users GUI
            if(validLogin)
            {
                Hide();
                new UsersView().ShowDialog();
                Show();
            }

            LoginButton.Enabled = true;
        }

        private async void RegisterButtonClick(object sender, EventArgs e)
        {
            RegisterButton.Enabled = false;

            // Registration Task
            await Task.Run<bool>(() => MainViewModel.Instance.Register());
            
            RegisterButton.Enabled = true;
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }
    }
}
