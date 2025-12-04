using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class LobbyServer
    {
        private string _name;
        public string name { get { return _name; } }
        private string _hashedIp;
        public string hashedIp { get { return _hashedIp; } }
        private string _port;
        public string port { get { return _port; } }
        private bool _show;
        public bool show { get { return _show; } set { _show = value; } }

        public LobbyServer(string name, string hashedIp, string port)
        {
            _name = name;
            _hashedIp = hashedIp;
            _port = port;
            _show = true;
        }
    }
}

