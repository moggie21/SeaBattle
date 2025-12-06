using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyHostingServer
{
    internal class LobbyServer
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsPrivate { get; set; }

        public LobbyServer(string name, string host, int port, bool isPrivate)
        {
            Name = name;
            Host = host;
            Port = port;
            IsPrivate = isPrivate;
        }
    }
}
