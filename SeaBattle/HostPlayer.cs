using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class HostPlayer
    {
        private TcpListener listener;
        private TcpClient enemyClient;
        private PlayerInfo enemyInfo;
        private PlayerInfo player;
        bool inGame = true;

        public void StartListening(int port, string localAddr)
        {
            listener = new TcpListener(IPAddress.Parse(localAddr), port);
            listener.Start();
            _ = AcceptClientsAsync();
        }

        private async Task AcceptClientsAsync()
        {
            //Обработка ожидание противника

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
            }
            _ = HandleClient();

        }

        private async Task HandleClient()
        {
            while (inGame)
            {
                try
                {
                    // обработка логики игры
                    // поочерёдные вызовы функции передачи информации о действии игроков в соответствии с gameManager


                    //NetworkStream stream = enemyClient.GetStream();

                    //byte[] buffer = new byte[enemyClient.ReceiveBufferSize];
                    //int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    //if (bytesRead > 0)
                    //{
                    //    string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    //    if (dataReceived == "QUIT")
                    //    {
                    //        inGame = false;
                    //        //обработка победы при выходе противника
                    //        enemyClient.Close();
                    //    }
                    //}
                }

                catch (IOException ex)
                {
                    Console.WriteLine("Исключение при приёме данных (Юзер отключен): " + ex.Message);

                    inGame = false;
                    //обработка победы при выходе противника
                    enemyClient.Close();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Общая ошибка при обработке клиента: {ex.Message}");

                    inGame = false;
                    //обработка победы при выходе противника
                    enemyClient.Close();
                    break;
                }
            }
        }


        public void StopListening()
        {
            enemyClient.Close();
            listener?.Stop();
        }

        public HostPlayer(int port = 9000, string localAddr = "26.115.23.91")
        {
            //определение ip и свободного порта

            this.StartListening(port, localAddr);
        }

    }
}