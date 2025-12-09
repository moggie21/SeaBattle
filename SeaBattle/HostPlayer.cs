using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class HostPlayer
    {
        private GameManagerServer gameManager;
        private TcpListener listener;
        private TcpClient enemyClient;
        private PlayerInfo enemyInfo;
        private PlayerInfo player;
        private Form1 form;
        bool inGame = true;

        public void StartListening(int port, string localAddr)
        {
            listener = new TcpListener(IPAddress.Parse(localAddr), port);
            listener.Start();
            Console.WriteLine("Listener Started! Waiting PlayerConnections");
            _ = AcceptClientsAsync();
        }

        private async Task AcceptClientsAsync()
        {
            //Обработка ожидание противника
            //MessageBox.Show("Начинаю ожидание подключений",
            //                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine("Начинаю ожидание подключений");
            enemyClient = await listener.AcceptTcpClientAsync();
            Console.WriteLine("Новый клиент подключился!");
            // передаём игформацию об игроке
            byte[] buffer = null;
            buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(player));
            _ = enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
            // ожидаем информацию о противнике
            buffer = new byte[enemyClient.ReceiveBufferSize];
            int bytesRead = await enemyClient.GetStream().ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                enemyInfo = JsonConvert.DeserializeObject<PlayerInfo>(message);
                //MessageBox.Show($"Получена информация о противнике {enemyInfo.username}", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            gameManager.PlayerConnected();
            _ = HandleClient();

        }

        private async Task HandleClient()
        {
            try
            {
                Console.WriteLine("Ожидаем информацию о вражеской расстановке доски.");
                NetworkStream stream = enemyClient.GetStream();
                byte[] buffer = new byte[enemyClient.ReceiveBufferSize];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);//enemyboard
                string dataRecieves = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                
                gameManager.EnemyBoard.ReplaceBoard(JsonConvert.DeserializeObject<(CellState[,], List<Ship>)>(dataRecieves));
                //MessageBox.Show($"{board.Grid.Length}\n{board.Ships.Count}\n{board.Ships[0].Length}", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!gameManager.TryFinishPlacement()){
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);//enemyboard
                    gameManager.TryFinishPlacement();
                }
                else
                    stream.WriteAsync(buffer, 0, buffer.Length);

                //MessageBox.Show("Переходим к игре",
                //                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (inGame)
                {
                    buffer = new byte[enemyClient.ReceiveBufferSize];
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        if (dataReceived == "QUIT")
                        {
                            inGame = false;
                            //обработка победы при выходе противника
                            enemyClient.Close();
                            MessageBox.Show($"Противник покинул игру", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form.ShowMainMenu();
                            form.hostingClient.Disconnect();
                            StopListening();
                        }
                        else
                        {
                            (int, int) shot = JsonConvert.DeserializeObject<(int, int)>(dataReceived);
                            //MessageBox.Show($"Got shot at {shot.Item1}, {shot.Item2}",
                            //    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            gameManager.ShootingController(shot.Item1, shot.Item2);
                        }
                    }
                }
            }

            catch (IOException ex)
            {
                Console.WriteLine("Исключение при приёме данных (Юзер отключен): " + ex.Message);

                inGame = false;
                //обработка действий при выходе противника
                enemyClient.Close();
                MessageBox.Show($"Противник покинул игру", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.ShowMainMenu();
                form.hostingClient.Disconnect();
                StopListening();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка при обработке клиента: {ex.Message}");

                inGame = false;
                //обработка действий при выходе противника
                enemyClient.Close();
                MessageBox.Show($"Противник покинул игру", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.ShowMainMenu();
                form.hostingClient.Disconnect();
                StopListening();
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

        public void StopListening()
        {
            enemyClient.Close();
            listener?.Stop();
        }

        public HostPlayer(Form1 form, GameManagerServer gms, string username, int port = 9000, string localAddr = "26.115.23.91")
        {
            this.form = form;
            player = new PlayerInfo(username);
            Console.WriteLine("Запущен сервер на ", localAddr, port);
            this.StartListening(port, localAddr);
            gameManager = gms;
        }

    }
}