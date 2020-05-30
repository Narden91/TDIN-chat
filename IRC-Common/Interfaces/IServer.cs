using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRC_Common
{
    [Serializable]
    public delegate void SessionUpdateHandler(IClient info);

    public abstract class IServer : MarshalByRefObject
    {
        public abstract event SessionUpdateHandler SessionUpdateEvent;

        public abstract bool Login(string nickname, string password, string ip, int port);

        public abstract int Register(string nickname, string realName, string password);

        public abstract bool Logout(string nickname, string password);

        public abstract List<IClient> LoggedUsers(string nickname);

        public abstract string GetUserRealName(string nickname);

        public abstract string CreateChatRoom(IClient client, List<IClient> users);

        public abstract void SendMessageChatRoom(IClient sender, string hash, string message);
    }
}
