using IRC_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRC_Client.Models
{
    public class ServerConnection : Connection
    {
        #region Accessors
        private IServer connection;

        public IServer Connection
        {
            get
            {
                if(this.connection == null)
                {
                    this.connection = Connect("Server");
                }
                return this.connection;
            }
        }
        #endregion

        public IServer Connect(string endPoint)
        {
            return (IServer)Activator.GetObject(typeof(IServer),
                "tcp://" + this.Address + ":" + this.Port + "/IRC-Server/" + endPoint);
        }
    }
}
