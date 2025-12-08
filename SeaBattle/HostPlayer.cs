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
        private GameManagerServer gms;
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

            Console.WriteLine("Начинаю ожидание подключений");
            enemyClient = await listener.AcceptTcpClientAsync();
            Console.WriteLine("Новый клиент подключился!");
            gms.PlayerConnected();
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
            }
            _ = HandleClient();

        }

        private async Task HandleClient()
        {
            Console.WriteLine("Ожидаем информацию о вражеской расстановке доски.");
            NetworkStream stream = enemyClient.GetStream();
            byte[] buffer = new byte[enemyClient.ReceiveBufferSize];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);//enemyboard
            gameManager.SetEnemyBoard(JsonConvert.DeserializeObject<GameBoard>(Encoding.UTF8.GetString(buffer, 0, bytesRead)));
            while (!gameManager.TryFinishPlacement()) { }
            while (inGame)
            {
                try
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
                        }
                        else
                        {
                            (int, int) shot = JsonConvert.DeserializeObject<(int, int)>(dataReceived);
                            gameManager.ShootingController(shot.Item1, shot.Item2, gameManager.PlayerBoard);
                        }
                    }
                }

                catch (IOException ex)
                {
                    Console.WriteLine("Исключение при приёме данных (Юзер отключен): " + ex.Message);

                    inGame = false;
                    //обработка действий при выходе противника
                    enemyClient.Close();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Общая ошибка при обработке клиента: {ex.Message}");

                    inGame = false;
                    //обработка действий при выходе противника
                    enemyClient.Close();
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
            byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((row,col)));
            _ = enemyClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }

        public void StopListening()
        {
            enemyClient.Close();
            listener?.Stop();
        }

        public HostPlayer(Form1 form, GameManagerServer gms, int port = 9000, string localAddr = "26.115.23.91")
        {
            this.form = form;
            Console.WriteLine("Запущен сервер на ", localAddr, port);
            this.StartListening(port, localAddr);
            this.gms = gms;
        }

    }
}