using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class ClientPlayer
    {
        private PlayerInfo enemyInfo;
        private PlayerInfo player;
        private Form1 form;
        private TcpClient enemyClient;
        private GameManagerServer gameManager;
        public bool isConnected = true;

        public ClientPlayer(Form1 form, string address, int port)
        {
            this.enemyClient = new TcpClient(address, port);
            this.form = form;
            this.isConnected = this.enemyClient.Connected;
        }

        public async Task ListenForMessagesAsync()
        {
            byte[] buffer = null;
            // ожидаем информацию о противнике
            buffer = new byte[enemyClient.ReceiveBufferSize];
            int bytesRead = await enemyClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                enemyInfo = JsonConvert.DeserializeObject<PlayerInfo>(message);
            }
            // передаём игформацию об игроке
            buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(player));
            _ = enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);

            NetworkStream stream = enemyClient.GetStream();
            buffer = new byte[enemyClient.ReceiveBufferSize];
            bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);//enemyboard
            while (!gameManager.TryFinishPlacement()) { }
            while (isConnected && enemyClient.Connected)
            {
                try
                {

                    // обработка логики игры
                    // поочерёдные вызовы функции передачи информации о действии игроков в соответствии с gameManager


                    stream = enemyClient.GetStream();

                    buffer = new byte[enemyClient.ReceiveBufferSize];
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (bytesRead > 0)
                    {
                        (int, int) shot = JsonConvert.DeserializeObject<(int, int)>(dataReceived);
                        gameManager.ShootingController(shot.Item1, shot.Item2, gameManager.PlayerBoard);
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

        public void SendBoard()
        {
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(gameManager.PlayerBoard));
            _ = enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public void SendShootCoords(int row, int col)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((row, col)));
            _ = enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public async void Disconnect()
        {
            byte[] buffer = Encoding.UTF8.GetBytes("QUIT");
            isConnected = false;
            await enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
            enemyClient.Close();
        }

        public static async Task Main(Form1 form, string serverIp, int serverPort, string password = "")
        {
            ClientPlayer client = new ClientPlayer(form, AESEncryptor.Decrypt(serverIp, password), serverPort);
            if (client.isConnected)
            {
                //form.
                await client.ListenForMessagesAsync();
            }
            else
            {
                //ошибка при подключении либо неверно декодирован ip либо что-то ещё 
                form.CouldNotConnect();
            }
            Console.WriteLine("Клиент завершил свою работу");
        }
    }
}