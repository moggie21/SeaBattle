using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class TestLobbyServer
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsPrivate { get; set; }
        public string? Password { get; set; }

        public TestLobbyServer(string name, string host, int port, bool isPrivate, string? password = null)
        {
            Name = name;
            Host = host;
            Port = port;
            IsPrivate = isPrivate;
            Password = password;
        }
    }
}
