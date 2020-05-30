namespace IRC_Client.Views
{
    partial class ChatView
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
            this.MessageInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ChatViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SendButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ChatTabsControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ChatViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MessageInput
            // 
            this.MessageInput.AccessibleName = "";
            this.MessageInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ChatViewModelBindingSource, "MessageText", true));
            this.MessageInput.Depth = 0;
            this.MessageInput.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageInput.Hint = "Write your message here";
            this.MessageInput.Location = new System.Drawing.Point(45, 465);
            this.MessageInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MessageInput.MaxLength = 32767;
            this.MessageInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.MessageInput.Name = "MessageInput";
            this.MessageInput.PasswordChar = '\0';
            this.MessageInput.SelectedText = "";
            this.MessageInput.SelectionLength = 0;
            this.MessageInput.SelectionStart = 0;
            this.MessageInput.Size = new System.Drawing.Size(468, 28);
            this.MessageInput.TabIndex = 16;
            this.MessageInput.TabStop = false;
            this.MessageInput.UseSystemPasswordChar = false;
            this.MessageInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageInput_KeyDown);
            // 
            // ChatViewModelBindingSource
            // 
            this.ChatViewModelBindingSource.DataSource = typeof(IRC_Client.ViewModels.ChatViewModel);
            // 
            // SendButton
            // 
            this.SendButton.AutoSize = true;
            this.SendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SendButton.Depth = 0;
            this.SendButton.Icon = null;
            this.SendButton.Location = new System.Drawing.Point(548, 457);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SendButton.Name = "SendButton";
            this.SendButton.Primary = true;
            this.SendButton.Size = new System.Drawing.Size(66, 36);
            this.SendButton.TabIndex = 23;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ChatTabsControl
            // 
            this.ChatTabsControl.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatTabsControl.HotTrack = true;
            this.ChatTabsControl.Location = new System.Drawing.Point(45, 97);
            this.ChatTabsControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatTabsControl.Name = "ChatTabsControl";
            this.ChatTabsControl.SelectedIndex = 0;
            this.ChatTabsControl.Size = new System.Drawing.Size(569, 352);
            this.ChatTabsControl.TabIndex = 25;
            this.ChatTabsControl.SelectedIndexChanged += new System.EventHandler(this.ChatTabsControl_SelectedIndexChanged);
            // 
            // ChatView
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(663, 533);
            this.Controls.Add(this.ChatTabsControl);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageInput);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChatView";
            this.Sizable = false;
            this.Text = "Active Chats";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ChatViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField MessageInput;
        private MaterialSkin.Controls.MaterialRaisedButton SendButton;
        private System.Windows.Forms.TabControl ChatTabsControl;
        private System.Windows.Forms.BindingSource ChatViewModelBindingSource;
    }
}