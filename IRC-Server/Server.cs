using IRC_Common;
using IRC_Common.Models;
using IRC_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace IRC_Server
{
    class Server : IServer
    {
        private SQLiteConnection connection;
        private List<ChatRoom> ChatRooms;

        public event SessionUpdateHandler MyHandler;
        public override event SessionUpdateHandler SessionUpdateEvent
        {
            add
            {
                Console.WriteLine("New SUBSCRIBER Added");
                Console.WriteLine("--------------------------");
                MyHandler += value;
            }

            remove
            {
                Console.WriteLine("SUBSCRIBER removed!");
                Console.WriteLine("--------------------------");
                MyHandler -= value;
            }
        }

        public Server()
        {
            this.connection = InitializeDatabase("data", "database.sqlite");
            this.ChatRooms = new List<ChatRoom>();
        }
                
        #region Login / Register

        public override int Register(string nickname, string realName, string password)
        {
            //Invalid Nickname inserted
            if (nickname.Length < 1)
            {
                return 1;
            }
            //Invalid Name inserted
            if (realName.Length < 1)
            {
                return 2;
            }
            //Invalid Password inserted
            if (password.Length < 1)
            {
                return 3;
            }
            //Nickname chosen already exists
            if (DBController.UserExists(connection, nickname))
            {
                return 4;
            }
            //Error during the connection with the database
            if (!DBController.CreateUser(connection, nickname, realName, password))
            {
                return -1;
            }
            //No error during the registration
            return 0;
        }

        public override bool Login(string nickname, string password, string ip, int port)
        {
            bool sessionCreated;

            // Password incorrect
            if (!DBController.PasswordMatch(connection, nickname, password))
            {
                return false;
            }

            sessionCreated = DBController.CreateUpdateSession(connection, nickname, ip, port);
            
            if (sessionCreated)
            {
                MyHandler?.Invoke(new LoggedClient(nickname, DBController.GetUserRealName(connection, nickname), ip, port));
            }

            return sessionCreated;
        }


        public override bool Logout(string nickname, string password)
        {

            IClient client;

            bool sessionEnded;

            // Password incorrect
            if (!DBController.PasswordMatch(connection, nickname, password))
            {
                return false;
            }

            client = new LoggedClient(nickname, DBController.GetUserRealName(connection, nickname), null, 0);
            
            MyHandler?.Invoke(client);
            
            sessionEnded = DBController.EndSession(connection, nickname);
            
            return sessionEnded;
        }

        //List of the Logged Users
        public override List<IClient> LoggedUsers(string nickname)
        {
            return DBController.LoggedUsers(connection, nickname);
        }

        public override string GetUserRealName(string nickname)
        {
            return DBController.GetUserRealName(connection, nickname);
        }

        #endregion

        #region ChatRoom
        public override string CreateChatRoom(IClient sender, List<IClient> users)
        {
            ChatRoom chatRoom = new ChatRoom(sender, users);

            chatRoom.InviteAllUsers();

            this.ChatRooms.Add(chatRoom);

            return chatRoom.Hash;
        }

        public override void SendMessageChatRoom(IClient sender, string hash, string message)
        {
            ChatRoom chatRoom = null;
            foreach(ChatRoom currentRoom in this.ChatRooms)
            {

                if (!currentRoom.Hash.Equals(hash))
                    continue;
                
                chatRoom = currentRoom;
                
                break;
            }

            if (chatRoom == null)
                
                return;

            chatRoom.SendMessage(sender, message);
        }
        #endregion

        #region Database

        private SQLiteConnection InitializeDatabase(string dbDir, string dbFile)
        {
            string dbPath = dbDir + "/" + dbFile;
            bool needsInitialization = false;

            // Create database if it is not already present
            if (!File.Exists(dbPath))
            {
                Console.WriteLine("CREATING DATABASE");
                Directory.CreateDirectory(dbDir);
                SQLiteConnection.CreateFile(dbPath);
                needsInitialization = true;
            }

            // Connection to database
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + dbPath + "; Version=3;");
            connection.Open();

            if (needsInitialization)
            {
                ConfigureDatabase(connection);
            }

            // Close the connection
            connection.Close();
            DBController.TruncateSessions(connection);
            
            return connection;
        }

        //In the db_init file there are the instruction to create the 2 tables needed 
        private void ConfigureDatabase(SQLiteConnection connection)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Init Database
            StreamReader textStreamReader = new StreamReader("resources/db_init.txt");

            // Read commands from resource file until the end of the character stream
            while (textStreamReader.Peek() != -1)
            {
                string line = textStreamReader.ReadLine();
                SQLiteCommand command = new SQLiteCommand(line, connection);
                command.ExecuteNonQuery();
            }

            textStreamReader.Close();
        }

        #endregion
    }
}
