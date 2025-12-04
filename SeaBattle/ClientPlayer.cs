using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class ClientPlayer
    {

        private Form1 form;
        private TcpClient tcpClient;
        public bool isConnected = true;

        public ClientPlayer(Form1 form, string address, int port)
        {
            this.tcpClient = new TcpClient(address, port);
            this.form = form;
            this.isConnected = this.tcpClient.Connected;
        }

        public async Task ListenForMessagesAsync()
        {
            while (isConnected && tcpClient.Connected)
            {
                try
                {

                    // обработка логики игры
                    // поочерёдные вызовы функции передачи информации о действии игроков в соответствии с gameManager


                    //NetworkStream stream = tcpClient.GetStream();

                    //byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    //int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    //if (bytesRead > 0)
                    //{
                    //    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    //}
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

        public static async Task Main(Form1 form, string serverIp, int serverPort)
        {
            ClientPlayer client = new ClientPlayer(form, serverIp, serverPort);
            if (client.isConnected)
            {
                await client.ListenForMessagesAsync();
            }
            else
            {
                //ошибка при подключении либо неверно декодирован ip либо что-то ещё 
            }

            Console.WriteLine("Клиент завершил свою работу");
        }
    }
}