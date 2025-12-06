using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LobbyHostingServer
{
    public partial class Form1 : Form
    {
        ServerHosting serverHosting;
        public Form1()
        {
            InitializeComponent();
            serverHosting = new ServerHosting();
            Console.WriteLine("serverHosting started");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (serverHosting != null) serverHosting.StopListening();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
