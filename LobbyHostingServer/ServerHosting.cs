using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace LobbyHostingServer
{
    internal class ServerHosting
    {
        private TcpListener listener;
        private List<TcpClient> curActiveClients;
        private List<LobbyServer> curActiveLobbies;

        public void StartListening(int port, string localAddr)
        {
            listener = new TcpListener(IPAddress.Parse(localAddr), port);
            listener.Start();
            _ = AcceptClientsAsync();
        }

        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                //bool isOld = false;
                //foreach (var us in curActiveClients)
                //{
                //    if (us.tcpclient == client)
                //    {
                //        isOld = true;
                //        break;
                //    }
                //}
                //if (!isOld)
                {
                    Console.WriteLine("Новый клиент подключился!");
                    curActiveClients.Add(client);
                    byte[] buffer = null;
                    buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(curActiveLobbies));
                    _ = client.GetStream().WriteAsync(buffer, 0, buffer.Length);
                    _ = HandleClient(client);
                }
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        if (dataReceived == "QUIT")
                        {
                            curActiveClients.Remove(client);
                            client.Close();
                        }
                        else
                        {
                            try
                            {
                                LobbyServer new_lobby = JsonConvert.DeserializeObject<LobbyServer>(dataReceived);
                                curActiveLobbies.Add(new_lobby);
                                LobbyListUpdate();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Исключение при декодировании данных нового лобби: " + ex.Message);
                            }
                        }
                        await stream.WriteAsync(buffer, 0, buffer.Length);
                    }
                }

                catch (IOException ex)
                {
                    Console.WriteLine("Исключение при приёме данных (Юзер отключен): " + ex.Message);
                    curActiveClients.Remove(client);
                    client.Close();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Общая ошибка при обработке клиента: {ex.Message}");
                    curActiveClients.Remove(client);
                    client.Close();
                    break;
                }
            }
        }


        private async void LobbyListUpdate()
        {
            byte[] buffer = null;
            try
            {
                buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(curActiveLobbies));
                foreach (TcpClient actClient in curActiveClients)
                {
                    _ = actClient.GetStream().WriteAsync(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex) { Console.WriteLine("Не смог преобразовать curActiveLobbies в JSON: " + ex.Message); }
        }

        public void StopListening()
        {
            foreach (TcpClient actClient in curActiveClients)
            {
                actClient.Close();
            }
            listener?.Stop();
        }

        public ServerHosting(int port = 9000, string localAddr = "26.115.23.91")
        {
            this.StartListening(port, localAddr);
            curActiveClients = new List<TcpClient>();
        }

    }
}
