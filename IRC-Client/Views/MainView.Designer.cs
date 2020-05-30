namespace IRC_Client.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabMenu = new MaterialSkin.Controls.MaterialTabControl();
            this.LoginTab = new System.Windows.Forms.TabPage();
            this.LoginButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ServerAddressInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ServerPortInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ServerPortLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ServerAddressLabel = new MaterialSkin.Controls.MaterialLabel();
            this.RegisterTab = new System.Windows.Forms.TabPage();
            this.RealNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.RegisterButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.RealNameInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.NicknameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.NicknameInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PasswordInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.TabMenuSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.MainViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabMenu.SuspendLayout();
            this.LoginTab.SuspendLayout();
            this.RegisterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMenu
            // 
            this.TabMenu.Controls.Add(this.LoginTab);
            this.TabMenu.Controls.Add(this.RegisterTab);
            this.TabMenu.Depth = 0;
            this.TabMenu.Location = new System.Drawing.Point(12, 278);
            this.TabMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.SelectedIndex = 0;
            this.TabMenu.Size = new System.Drawing.Size(556, 242);
            this.TabMenu.TabIndex = 25;
            // 
            // LoginTab
            // 
            this.LoginTab.BackColor = System.Drawing.Color.White;
            this.LoginTab.Controls.Add(this.materialLabel1);
            this.LoginTab.Controls.Add(this.LoginButton);
            this.LoginTab.Controls.Add(this.ServerAddressInput);
            this.LoginTab.Controls.Add(this.ServerPortInput);
            this.LoginTab.Controls.Add(this.ServerPortLabel);
            this.LoginTab.Controls.Add(this.ServerAddressLabel);
            this.LoginTab.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoginTab.Location = new System.Drawing.Point(4, 22);
            this.LoginTab.Name = "LoginTab";
            this.LoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginTab.Size = new System.Drawing.Size(548, 216);
            this.LoginTab.TabIndex = 0;
            this.LoginTab.Text = "Login";
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSize = true;
            this.LoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginButton.Depth = 0;
            this.LoginButton.Icon = null;
            this.LoginButton.Location = new System.Drawing.Point(213, 162);
            this.LoginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Primary = true;
            this.LoginButton.Size = new System.Drawing.Size(61, 36);
            this.LoginButton.TabIndex = 22;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.MouseCaptureChanged += new System.EventHandler(this.LoginButtonClick);
            // 
            // ServerAddressInput
            // 
            this.ServerAddressInput.AccessibleName = "";
            this.ServerAddressInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MainViewBindingSource, "ServerAddress", true));
            this.ServerAddressInput.Depth = 0;
            this.ServerAddressInput.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerAddressInput.Hint = "Server Address";
            this.ServerAddressInput.Location = new System.Drawing.Point(213, 73);
            this.ServerAddressInput.MaxLength = 32767;
            this.ServerAddressInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.ServerAddressInput.Name = "ServerAddressInput";
            this.ServerAddressInput.PasswordChar = '\0';
            this.ServerAddressInput.SelectedText = "";
            this.ServerAddressInput.SelectionLength = 0;
            this.ServerAddressInput.SelectionStart = 0;
            this.ServerAddressInput.Size = new System.Drawing.Size(305, 23);
            this.ServerAddressInput.TabIndex = 15;
            this.ServerAddressInput.TabStop = false;
            this.ServerAddressInput.UseSystemPasswordChar = false;
            // 
            // ServerPortInput
            // 
            this.ServerPortInput.AccessibleName = "";
            this.ServerPortInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MainViewBindingSource, "ServerPort", true));
            this.ServerPortInput.Depth = 0;
            this.ServerPortInput.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerPortInput.Hint = "Server Port";
            this.ServerPortInput.Location = new System.Drawing.Point(213, 117);
            this.ServerPortInput.MaxLength = 32767;
            this.ServerPortInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.ServerPortInput.Name = "ServerPortInput";
            this.ServerPortInput.PasswordChar = '\0';
            this.ServerPortInput.SelectedText = "";
            this.ServerPortInput.SelectionLength = 0;
            this.ServerPortInput.SelectionStart = 0;
            this.ServerPortInput.Size = new System.Drawing.Size(305, 23);
            this.ServerPortInput.TabIndex = 17;
            this.ServerPortInput.TabStop = false;
            this.ServerPortInput.UseSystemPasswordChar = false;
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Depth = 0;
            this.ServerPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ServerPortLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ServerPortLabel.Location = new System.Drawing.Point(49, 117);
            this.ServerPortLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(115, 18);
            this.ServerPortLabel.TabIndex = 18;
            this.ServerPortLabel.Text = "SERVER PORT";
            this.ServerPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerAddressLabel
            // 
            this.ServerAddressLabel.AutoSize = true;
            this.ServerAddressLabel.Depth = 0;
            this.ServerAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ServerAddressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ServerAddressLabel.Location = new System.Drawing.Point(49, 73);
            this.ServerAddressLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ServerAddressLabel.Name = "ServerAddressLabel";
            this.ServerAddressLabel.Size = new System.Drawing.Size(145, 18);
            this.ServerAddressLabel.TabIndex = 16;
            this.ServerAddressLabel.Text = "SERVER ADDRESS";
            this.ServerAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegisterTab
            // 
            this.RegisterTab.BackColor = System.Drawing.Color.White;
            this.RegisterTab.Controls.Add(this.RealNameLabel);
            this.RegisterTab.Controls.Add(this.RegisterButton);
            this.RegisterTab.Controls.Add(this.RealNameInput);
            this.RegisterTab.Location = new System.Drawing.Point(4, 22);
            this.RegisterTab.Name = "RegisterTab";
            this.RegisterTab.Padding = new System.Windows.Forms.Padding(3);
            this.RegisterTab.Size = new System.Drawing.Size(548, 216);
            this.RegisterTab.TabIndex = 1;
            this.RegisterTab.Text = "Register";
            // 
            // RealNameLabel
            // 
            this.RealNameLabel.AutoSize = true;
            this.RealNameLabel.Depth = 0;
            this.RealNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.RealNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RealNameLabel.Location = new System.Drawing.Point(53, 22);
            this.RealNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.RealNameLabel.Name = "RealNameLabel";
            this.RealNameLabel.Size = new System.Drawing.Size(93, 18);
            this.RealNameLabel.TabIndex = 28;
            this.RealNameLabel.Text = "REAL NAME";
            this.RealNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegisterButton
            // 
            this.RegisterButton.AutoSize = true;
            this.RegisterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RegisterButton.Depth = 0;
            this.RegisterButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Icon = null;
            this.RegisterButton.Location = new System.Drawing.Point(217, 109);
            this.RegisterButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Primary = true;
            this.RegisterButton.Size = new System.Drawing.Size(83, 36);
            this.RegisterButton.TabIndex = 25;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.MouseCaptureChanged += new System.EventHandler(this.RegisterButtonClick);
            // 
            // RealNameInput
            // 
            this.RealNameInput.AccessibleName = "";
            this.RealNameInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MainViewBindingSource, "RealName", true));
            this.RealNameInput.Depth = 0;
            this.RealNameInput.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealNameInput.Hint = "Real Name";
            this.RealNameInput.Location = new System.Drawing.Point(217, 22);
            this.RealNameInput.MaxLength = 32767;
            this.RealNameInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.RealNameInput.Name = "RealNameInput";
            this.RealNameInput.PasswordChar = '\0';
            this.RealNameInput.SelectedText = "";
            this.RealNameInput.SelectionLength = 0;
            this.RealNameInput.SelectionStart = 0;
            this.RealNameInput.Size = new System.Drawing.Size(305, 23);
            this.RealNameInput.TabIndex = 27;
            this.RealNameInput.TabStop = false;
            this.RealNameInput.UseSystemPasswordChar = false;
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Depth = 0;
            this.NicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.NicknameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NicknameLabel.Location = new System.Drawing.Point(65, 202);
            this.NicknameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(86, 18);
            this.NicknameLabel.TabIndex = 12;
            this.NicknameLabel.Text = "NICKNAME";
            this.NicknameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Depth = 0;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PasswordLabel.Location = new System.Drawing.Point(65, 249);
            this.PasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(96, 18);
            this.PasswordLabel.TabIndex = 14;
            this.PasswordLabel.Text = "PASSWORD";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NicknameInput
            // 
            this.NicknameInput.AccessibleName = "";
            this.NicknameInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MainViewBindingSource, "Nickname", true));
            this.NicknameInput.Depth = 0;
            this.NicknameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NicknameInput.Hint = "Nickname";
            this.NicknameInput.Location = new System.Drawing.Point(229, 202);
            this.NicknameInput.MaxLength = 32767;
            this.NicknameInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.NicknameInput.Name = "NicknameInput";
            this.NicknameInput.PasswordChar = '\0';
            this.NicknameInput.SelectedText = "";
            this.NicknameInput.SelectionLength = 0;
            this.NicknameInput.SelectionStart = 0;
            this.NicknameInput.Size = new System.Drawing.Size(305, 23);
            this.NicknameInput.TabIndex = 11;
            this.NicknameInput.TabStop = false;
            this.NicknameInput.UseSystemPasswordChar = false;
            // 
            // PasswordInput
            // 
            this.PasswordInput.AccessibleName = "";
            this.PasswordInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MainViewBindingSource, "Password", true));
            this.PasswordInput.Depth = 0;
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Hint = "Password";
            this.PasswordInput.Location = new System.Drawing.Point(229, 249);
            this.PasswordInput.MaxLength = 32767;
            this.PasswordInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.SelectedText = "";
            this.PasswordInput.SelectionLength = 0;
            this.PasswordInput.SelectionStart = 0;
            this.PasswordInput.Size = new System.Drawing.Size(305, 23);
            this.PasswordInput.TabIndex = 13;
            this.PasswordInput.TabStop = false;
            this.PasswordInput.UseSystemPasswordChar = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MainViewBindingSource, "Status", true));
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StatusLabel.Location = new System.Drawing.Point(13, 521);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(85, 18);
            this.StatusLabel.TabIndex = 24;
            this.StatusLabel.Text = "StatusLabel";
            // 
            // TabMenuSelector
            // 
            this.TabMenuSelector.BaseTabControl = this.TabMenu;
            this.TabMenuSelector.Depth = 0;
            this.TabMenuSelector.Location = new System.Drawing.Point(-14, 50);
            this.TabMenuSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabMenuSelector.Name = "TabMenuSelector";
            this.TabMenuSelector.Size = new System.Drawing.Size(625, 36);
            this.TabMenuSelector.TabIndex = 26;
            this.TabMenuSelector.Text = "TabMenuSelector";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IRC_Client.Properties.Resources.iconfinder_user_male4_1726283;
            this.pictureBox1.Location = new System.Drawing.Point(229, 91);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(48, 26);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(299, 24);
            this.materialLabel1.TabIndex = 28;
            this.materialLabel1.Text = "CONNECTION PARAMETERS:";
            // 
            // MainViewBindingSource
            // 
            this.MainViewBindingSource.DataSource = typeof(IRC_Client.ViewModels.MainViewModel);
            // 
            // MainView
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 548);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NicknameLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TabMenuSelector);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.TabMenu);
            this.Controls.Add(this.NicknameInput);
            this.Controls.Add(this.PasswordInput);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Internet Relay Chat";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.TabMenu.ResumeLayout(false);
            this.LoginTab.ResumeLayout(false);
            this.LoginTab.PerformLayout();
            this.RegisterTab.ResumeLayout(false);
            this.RegisterTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource MainViewBindingSource;
        private MaterialSkin.Controls.MaterialTabControl TabMenu;
        private System.Windows.Forms.TabPage RegisterTab;
        private System.Windows.Forms.TabPage LoginTab;
        private System.Windows.Forms.Label StatusLabel;
        private MaterialSkin.Controls.MaterialLabel NicknameLabel;
        private MaterialSkin.Controls.MaterialRaisedButton LoginButton;
        private MaterialSkin.Controls.MaterialLabel PasswordLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField NicknameInput;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordInput;
        private MaterialSkin.Controls.MaterialSingleLineTextField ServerAddressInput;
        private MaterialSkin.Controls.MaterialSingleLineTextField ServerPortInput;
        private MaterialSkin.Controls.MaterialLabel ServerPortLabel;
        private MaterialSkin.Controls.MaterialLabel ServerAddressLabel;
        private MaterialSkin.Controls.MaterialTabSelector TabMenuSelector;
        private MaterialSkin.Controls.MaterialRaisedButton RegisterButton;
        private MaterialSkin.Controls.MaterialLabel RealNameLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField RealNameInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
    }
}