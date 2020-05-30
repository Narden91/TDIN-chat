using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRC_Client.Models
{
    public abstract class Connection
    {
        #region Accessors
        public string Address { get; set; } = "localhost";

        public string Port { get; set; } = "35994";

        public string Status { get; set; }
        #endregion
    }
}
