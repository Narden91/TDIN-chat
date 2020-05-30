using IRC_Common;
using IRC_Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace IRC_Server
{
    class DBController
    {

        // Create New User
        public static bool CreateUser(SQLiteConnection connection, string nickname, string realname, string password)
        {
            int result;
            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "INSERT INTO users (nickname, realname, password) VALUES (@nick, @name, @pw)";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = nickname;
            SQLiteParameter nameParameter = new SQLiteParameter("@name", DbType.String);
            nameParameter.Value = realname;
            SQLiteParameter passParameter = new SQLiteParameter("@pw", DbType.String);
            passParameter.Value = password;

            command.Parameters.Add(nickParameter);
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(passParameter);
            
            command.Prepare();
            connection.Open();
            result = command.ExecuteNonQuery();
            connection.Close();

            return result > 0;
        }

        // Check if User Exists
        public static bool UserExists(SQLiteConnection connection, string nickname)
        {
            int rows;
            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "SELECT COUNT(nickname) FROM users WHERE nickname = @nick";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = nickname;

            command.Parameters.Add(nickParameter);
            
            command.Prepare();
            connection.Open();
            rows = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return rows > 0;
        }

        // Password checking during login
        public static bool PasswordMatch(SQLiteConnection connection, string nickname, string password)
        {
            int rows;
            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "SELECT COUNT(nickname) FROM users WHERE nickname = @nick AND password = @pw";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = nickname;
            SQLiteParameter passParameter = new SQLiteParameter("@pw", DbType.String);
            passParameter.Value = password;

            command.Parameters.Add(nickParameter);
            command.Parameters.Add(passParameter);

            command.Prepare();
            connection.Open();
            rows = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return rows > 0;
        }

        // Create/Update Session table
        public static bool CreateUpdateSession(SQLiteConnection connection, string nickname, string ip, int port)
        {
            int result;
            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "INSERT OR REPLACE INTO sessions (nickname, ip, port) VALUES (@nick, @ip, @port)";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = nickname;
            SQLiteParameter ipParameter = new SQLiteParameter("@ip", DbType.String);
            ipParameter.Value = ip;
            SQLiteParameter portParameter = new SQLiteParameter("@port", DbType.Int32);
            portParameter.Value = port;

            command.Parameters.Add(nickParameter);
            command.Parameters.Add(ipParameter);
            command.Parameters.Add(portParameter);

            command.Prepare();
            connection.Open();
            result = command.ExecuteNonQuery();
            connection.Close();

            return result > 0;
        }

        // Delete the user from Session table when logout
        public static bool EndSession(SQLiteConnection connection, string nickname)
        {
            int result;
            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "DELETE FROM sessions WHERE nickname = @nick";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = nickname;

            command.Parameters.Add(nickParameter);

            command.Prepare();
            connection.Open();
            result = command.ExecuteNonQuery();
            connection.Close();

            return result > 0;
        }

        // List of the logged Users
        public static List<IClient> LoggedUsers(SQLiteConnection connection, string askingNickname)
        {
            List<IClient> result = new List<IClient>();

            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "SELECT sessions.nickname, users.realname, sessions.ip, sessions.port " +
                "FROM sessions INNER JOIN users ON sessions.nickname = users.nickname WHERE NOT sessions.nickname = @nick";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = askingNickname;

            command.Parameters.Add(nickParameter);

            command.Prepare();
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new LoggedClient(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                }

                reader.Close();
            }
            connection.Close();

            return result;
        }

        // QUERY: Get the Real Name of the User
        public static string GetUserRealName(SQLiteConnection connection, string nickname)
        {
            string result;
            SQLiteCommand command = new SQLiteCommand(null, connection);
            command.CommandText = "SELECT realname FROM users WHERE nickname = @nick";

            SQLiteParameter nickParameter = new SQLiteParameter("@nick", DbType.String);
            nickParameter.Value = nickname;

            command.Parameters.Add(nickParameter);

            result = null;
            command.Prepare();
            connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
            }
            connection.Close();

            return result;
        }

        // QUERY: Delete Session
        public static void TruncateSessions(SQLiteConnection connection)
        {
            SQLiteCommand command1 = new SQLiteCommand(null, connection);
            command1.CommandText = "DELETE FROM sessions";

            //"VACUUM" command: rebuilds the database file rto save disk space
            SQLiteCommand command2 = new SQLiteCommand(null, connection);
            command2.CommandText = "VACUUM";

            command1.Prepare();
            command2.Prepare();
            connection.Open();
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
        }
    }
}
