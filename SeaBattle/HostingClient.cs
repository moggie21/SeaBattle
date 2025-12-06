using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class HostingClient
    {
        private Form1 form;
        private TcpClient tcpClient;
        bool isConnected = true;

        public HostingClient(Form1 form, string address, int port)
        {
            this.tcpClient = new TcpClient(address, port);
            this.form = form;
        }

        public async Task ListenForMessagesAsync()
        {
            while (isConnected && tcpClient.Connected)
            {
                try
                {
                    NetworkStream stream = tcpClient.GetStream();

                    byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        NewLobbyAdded(message);
                    }
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine(ioEx.Message);
                    break;
                }
                catch (SocketException sockEx)
                {
                    Console.WriteLine(sockEx.Message);
                    break;
                }
            }
        }

        public async void Disconnect()
        {
            byte[] buffer = Encoding.UTF8.GetBytes("QUIT");
            isConnected = false;
            await tcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
            tcpClient.Close();
        }

        public void NewLobbyAdded(string JSON)
        {
            try
            {
                List<LobbyServer> users = JsonConvert.DeserializeObject<List<LobbyServer>>(JSON);
                //обновление списка лобби в форме
            }
            catch (Exception ex) { Console.WriteLine("Recieved messege is not UserList"); }
        }

        public async Task CreateNewLobby(string message)
        {
            //создание лобби. Открытие окна ожидания. 
            LobbyServer newLobby = new LobbyServer("name", "hashedIp", "port");
            //оповещение хостинга о новом лобби
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(newLobby));
            if (buffer != null)
                await tcpClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task Main(Form1 form, string serverIp, int serverPort)
        {
            // Подразумевается, что ip port сервера хостинга не меняются и известны заранее.
            HostingClient client = new HostingClient(form, serverIp, serverPort);
            await client.ListenForMessagesAsync();

            Console.WriteLine("Клиент завершил свою работу");
        }
    }
}