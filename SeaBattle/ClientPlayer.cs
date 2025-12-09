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
    public class ClientPlayer
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
            try
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
                // передаём информацию об игроке
                buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(player));
                _ = enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);

                gameManager.PlayerConnected();

                NetworkStream stream = enemyClient.GetStream();
                buffer = new byte[enemyClient.ReceiveBufferSize];

                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);//enemyboard
                string dataRecieves = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                gameManager.EnemyBoard.ReplaceBoard(JsonConvert.DeserializeObject<(CellState[,], List<Ship>)>(dataRecieves));
                if (!gameManager.TryFinishPlacement())
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);//enemyboard
                    gameManager.TryFinishPlacement();
                }
                else
                    stream.WriteAsync(buffer, 0, buffer.Length);
                
                while (isConnected && enemyClient.Connected)
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
                        //MessageBox.Show($"Got shot at {shot.Item1}, {shot.Item2}",
                        //    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gameManager.ShootingController(shot.Item1, shot.Item2);
                    }
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                MessageBox.Show($"Противник покинул игру", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.ShowMainMenu();
                isConnected = false;
                form.hostingClient.Disconnect();
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine(sockEx.Message);
                MessageBox.Show($"Противник покинул игру", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.ShowMainMenu();
                isConnected = false;
                form.hostingClient.Disconnect();
            }
        }

        public void SendBoard()
        {
            CellState[,] newcell = gameManager.PlayerBoard.Grid;
            List<Ship> ships = new List<Ship>();
            for (int i = 0; i < gameManager.PlayerBoard.Ships.Count; i++)
            {
                ships.Add(gameManager.PlayerBoard.Ships[i]);
            }
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((newcell, ships)));
            //MessageBox.Show($"{board.Grid.Length}\n{board.Ships.Count}", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public static async Task Main(Form1 form, string username, string serverIp, int serverPort, string password)
        {
            ClientPlayer client = new ClientPlayer(form, AESEncryptor.Decrypt(serverIp, password), serverPort);
            if (client.isConnected)
            {
                client.gameManager = form.InitializeOnlineGame();
                client.player = new PlayerInfo(username);
                form.clientPlayer = client;
                await client.ListenForMessagesAsync();
            }
            else
            {
                form.CouldNotConnect();
                client.Disconnect();
            }
            Console.WriteLine("Клиент завершил свою работу");
        }
    }
}