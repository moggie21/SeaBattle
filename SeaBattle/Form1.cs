using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class Form1 : Form
    {
        public HostingClient hostingClient;
        public ClientPlayer clientPlayer;
        public HostPlayer hostPlayer;
        private GameManager gameManager;
        private GameManagerServer gameManagerServer;
        private GameState curState;
        private GameMode currentGameMode = GameMode.None;
        private Panel[,] playerCells = new Panel[10, 10];
        private Panel[,] enemyCells = new Panel[10, 10];

        // для расстановки
        private int? selectedShipLength = null;

        public Form1()
        {
            InitializeComponent();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            panelMainMenu.Visible = true;
            panelGame.Visible = false;
            panelLobby.Visible = false;
        }

        private void ShowGamePanel()
        {
            panelGame.Visible = true;
            panelMainMenu.Visible = false;
            panelLobby.Visible = false;

            buttonNewGame.Visible = currentGameMode == GameMode.Solo;
            buttonStartSolo.Visible = currentGameMode == GameMode.Solo;
        }

        private void ShowLobbyPanel()
        {
            panelLobby.Visible = true;
            panelMainMenu.Visible = false;
            panelGame.Visible = false;

            var testLobbies = new List<LobbyServer>
            {
                new LobbyServer("Ошибка подключения к серверу", "127.0.0.1", 8888, true),
                new LobbyServer("Попробуйте ещё раз", "192.168.1.10", 9999, true)
            };
            UpdateLobbyList(testLobbies);
        }

        private void btnAutoPlace_Click(object sender, EventArgs e)
        {
            if (curState == GameState.Placement)
            {
                if (currentGameMode == GameMode.Multiplayer) gameManagerServer.AutoPlaceShips(gameManagerServer.PlayerBoard);
                else gameManager.AutoPlaceShips(gameManager.PlayerBoard);
                selectedShipLength = null;
                btnShip4.BackColor = SystemColors.Control;
                btnShip3.BackColor = SystemColors.Control;
                btnShip2.BackColor = SystemColors.Control;
                btnShip1.BackColor = SystemColors.Control;
                btnAutoPlace.BackColor = SystemColors.Control;
                RenderPlayerBoard();
                UpdateStatus();
                UpdateShipButtons();
                if (currentGameMode == GameMode.Multiplayer)
                {
                    if (hostPlayer != null) hostPlayer.SendBoard();
                    else clientPlayer.SendBoard();
                }
            }
        }

        private void btnSolo_Click(object sender, EventArgs e)
        {
            currentGameMode = GameMode.Solo;
            InitializeGame();
            ShowGamePanel();
        }

        private async void btnMultiplayer_Click(object sender, EventArgs e)
        {
            currentGameMode = GameMode.Multiplayer;
            Console.WriteLine("Подключение к серверу хостинга;");
            _ = HostingClient.Main(this, "26.115.23.91", 9000);
            if (hostingClient == null || !hostingClient.isConnected)
            {
                MessageBox.Show("При подключении возьникла ошибка. Попробуйте зайти позже!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ShowLobbyPanel();
        }

        private void InitializeGame()
        {
            gameManager = new GameManager(this);

            CreateGrid(playerPanel, playerCells, isPlayer: true);
            CreateGrid(enemyPanel, enemyCells, isPlayer: false);
            UpdateStatus();
            UpdateShipButtons();
        }

        public GameManagerServer InitializeOnlineGame()
        {
            Console.WriteLine("Инициализация онлайн игры");
            gameManagerServer = new GameManagerServer(this);

            CreateGrid(playerPanel, playerCells, isPlayer: true);
            CreateGrid(enemyPanel, enemyCells, isPlayer: false);

            ShowGamePanel();

            RenderPlayerBoard();
            RenderEnemyBoard();
            UpdateStatus();
            UpdateShipButtons();
            return gameManagerServer;
        }

        public void UpdateCurState(GameState state)
        {
            curState = state;
            //if (state == GameState.GameOver && currentGameMode == GameMode.Multiplayer)
            //{
            //    if (hostPlayer != null) hostPlayer.StopListening();
            //    if (clientPlayer != null) clientPlayer.Disconnect();
            //}
            Invoke(new Action(() =>
            {
                UpdateStatus();
            }));
        }

        private void CreateGrid(TableLayoutPanel panel, Panel[,] cells, bool isPlayer)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    var cell = new Panel
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(1),
                        BackColor = Color.LightBlue,
                        Tag = (r, c, isPlayer)
                    };

                    cell.Click += Cell_Click;

                    if (isPlayer)
                    {
                        cell.MouseEnter += PlayerCell_MouseEnter;
                        cell.MouseLeave += PlayerCell_MouseLeave;
                    }

                    cells[r, c] = cell;
                    panel.Controls.Add(cell, c, r); // column = c, row = r
                }
            }
            panel.ResumeLayout();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (sender is not Panel panel || panel.Tag is not (int row, int col, bool isPlayer))
                return;

            var (r, c, isPlayerField) = ((int, int, bool))panel.Tag;

            if (curState == GameState.Placement)
            {
                if (isPlayerField && selectedShipLength.HasValue)
                {
                    GameBoard board;
                    if (currentGameMode == GameMode.Solo)
                        board = gameManager.PlayerBoard;
                    else
                        board = gameManagerServer.PlayerBoard;
                    bool isVertical = radioVertical.Checked;
                    if (board.PlaceShip(selectedShipLength.Value, r, c, isVertical))
                    {
                        selectedShipLength = null;
                        btnShip4.BackColor = SystemColors.Control;
                        btnShip3.BackColor = SystemColors.Control;
                        btnShip2.BackColor = SystemColors.Control;
                        btnShip1.BackColor = SystemColors.Control;
                        RenderPlayerBoard();
                        UpdateStatus();
                        UpdateShipButtons();
                        if(currentGameMode == GameMode.Multiplayer && board.HasAllShipsPlaced())
                        {
                            if (hostPlayer != null) hostPlayer.SendBoard();
                            else clientPlayer.SendBoard();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нельзя разместить корабль здесь!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (curState == GameState.MyTurn)
            {
                if (!isPlayerField)
                {
                    GameBoard board;
                    if (currentGameMode == GameMode.Solo)
                        board = gameManager.EnemyBoard;
                    else
                        board = gameManagerServer.EnemyBoard;
                    var state = board.Grid[r, c];
                    if (state == CellState.Miss || state == CellState.Hit || state == CellState.Sunk)
                    {
                        MessageBox.Show("Сюда уже стреляли!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // стреляет по противнику
                    bool hit;
                    if (currentGameMode == GameMode.Solo)
                        (hit, _) = gameManager.PlayerShoot(r, c);
                    else{
                        (hit, _) = gameManagerServer.ShootingController(r, c);
                        if (hostPlayer != null) hostPlayer.SendShootCoords(r, c);
                        else clientPlayer.SendShootCoords(r, c);
                    }
                    RenderEnemyBoard();
                    UpdateStatus();

                    if (curState == GameState.GameOver)
                    {
                        ShowGameOverMessage();
                        return;
                    }

                    // если промах, то ходит бот
                    if ((!hit || curState == GameState.EnemyTurn) && currentGameMode == GameMode.Solo)
                    {
                        ProcessEnemyTurn();
                    }
                }
            }
        }

        private void PlayerCell_MouseEnter(object sender, EventArgs e)
        {
            if (curState != GameState.Placement || !selectedShipLength.HasValue)
                return;

            if (sender is not Panel panel || panel.Tag is not (int r, int c, bool isPlayer) || !isPlayer)
                return;

            bool isVertical = radioVertical.Checked;
            int length = selectedShipLength.Value;

            // какие клетки занял бы корабль
            var previewCells = new List<(int, int)>();
            if (isVertical)
            {
                for (int i = 0; i < length; i++)
                    previewCells.Add((r + i, c));
            }
            else
            {
                for (int i = 0; i < length; i++)
                    previewCells.Add((r, c + i));
            }

            // помещается ли корабль в границы
            bool inBounds = previewCells.All(pos => pos.Item1 >= 0 && pos.Item1 < 10 && pos.Item2 >= 0 && pos.Item2 < 10);

            // можно ли разместить 
            GameBoard board;
            if (currentGameMode == GameMode.Solo)
                board = gameManager.PlayerBoard;
            else
                board = gameManagerServer.PlayerBoard;
            bool canPlace = inBounds && board.CanPlaceShip(length, r, c, isVertical);

            // подсветка клетки
            foreach (var (row, col) in previewCells)
            {
                if (row >= 0 && row < 10 && col >= 0 && col < 10)
                {
                    Color color = canPlace ? Color.LightGreen : Color.LightPink;
                    playerCells[row, col].BackColor = color;
                }
            }
        }

        private void PlayerCell_MouseLeave(object sender, EventArgs e)
        {
            if (curState != GameState.Placement)
                return;

            RenderPlayerBoard();
        }

        private void ProcessEnemyTurn()
        {
            if (curState != GameState.EnemyTurn) return;

            System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
            {
                var (hit, row, col, _) = gameManager.EnemyShoot();

                Invoke(new Action(() =>
                {
                    RenderPlayerBoard();
                    UpdateStatus();

                    if (curState == GameState.GameOver)
                    {
                        ShowGameOverMessage();
                        return;
                    }

                    if (curState == GameState.EnemyTurn)
                    {
                        ProcessEnemyTurn();
                    }
                }));
            });
        }

        public void RenderPlayerBoard()
        {
            GameBoard board;
            if (currentGameMode == GameMode.Solo)
                board = gameManager.PlayerBoard;
            else
                board = gameManagerServer.PlayerBoard;
            var grid = board.Grid;
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    playerCells[r, c].BackColor = grid[r, c] switch
                    {
                        CellState.Ship => Color.Gray,
                        CellState.Hit => Color.Red,
                        CellState.Sunk => Color.DarkRed,
                        CellState.Miss => Color.White,
                        _ => Color.LightBlue
                    };
                }
            }
        }

        public void RenderEnemyBoard()
        {
            GameBoard board;
            if (currentGameMode == GameMode.Solo)
                board = gameManager.EnemyBoard;
            else
                board = gameManagerServer.EnemyBoard;
            var grid = board.Grid;
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    enemyCells[r, c].BackColor = grid[r, c] switch
                    {
                        CellState.Hit => Color.Red,
                        CellState.Sunk => Color.DarkRed,
                        CellState.Miss => Color.White,
                        _ => Color.LightBlue
                    };
                }
            }
        }

        private void UpdateStatus()
        {
            string status = curState switch
            {
                GameState.Placement => "Расстановка кораблей. Выберите корабль и кликните на поле.",
                GameState.MyTurn => "Ваш ход",
                GameState.EnemyTurn => "Ход противника...",
                GameState.ServerWait => "Ожидание подключения оппонента.",
                GameState.GameOver => (currentGameMode == GameMode.Solo ? gameManager.EnemyBoard.AllShipsSunk() : gameManagerServer.EnemyBoard.AllShipsSunk())
                    ? "Победа! Все корабли противника уничтожены!"
                    : "Поражение! Ваши корабли уничтожены.",
                _ => "Игра"
            };

            labelStatus.Text = status;
        }

        private void btnShip4_Click(object sender, EventArgs e)
        {
            selectedShipLength = 4;
            btnShip4.BackColor = Color.LightBlue;
        }

        private void btnShip3_Click(object sender, EventArgs e)
        {
            selectedShipLength = 3;
            btnShip3.BackColor = Color.LightBlue;

        }

        private void btnShip2_Click(object sender, EventArgs e)
        {
            selectedShipLength = 2;
            btnShip2.BackColor = Color.LightBlue;
        }

        private void btnShip1_Click(object sender, EventArgs e)
        {
            selectedShipLength = 1;
            btnShip1.BackColor = Color.LightBlue;
        }

        private void UpdateShipButtons()
        {
            if (curState != GameState.Placement) return;

            GameBoard board;
            if (currentGameMode == GameMode.Solo)
                board = gameManager.PlayerBoard;
            else
                board = gameManagerServer.PlayerBoard;
            var required = GameBoard.RequiredShips;

            btnShip4.Enabled = board.GetShipCount(4) < required[4];
            btnShip3.Enabled = board.GetShipCount(3) < required[3];
            btnShip2.Enabled = board.GetShipCount(2) < required[2];
            btnShip1.Enabled = board.GetShipCount(1) < required[1];
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            selectedShipLength = null;
            radioVertical.Checked = true;

            InitializeGame();

            RenderPlayerBoard();
            RenderEnemyBoard();
            UpdateStatus();
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            if (hostingClient != null)
                hostingClient.Disconnect();
            ShowMainMenu();
            gameManager = null;
            gameManagerServer = null;
        }

        private void buttonStartSolo_Click(object sender, EventArgs e)
        {
            if (curState == GameState.Placement && currentGameMode == GameMode.Solo)
            {
                if (gameManager.TryFinishPlacement())
                {
                    RenderPlayerBoard();
                    RenderEnemyBoard();
                    UpdateStatus();
                }
                else
                {
                    MessageBox.Show("Расставьте все корабли!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonStartMultiplayer_Click(object sender, EventArgs e)
        {
            if (curState == GameState.Placement && currentGameMode == GameMode.Multiplayer)
            {
                if (gameManagerServer.TryFinishPlacement())
                {
                    RenderPlayerBoard();
                    RenderEnemyBoard();
                    UpdateStatus();
                }
                else
                {
                    MessageBox.Show("Ожидаем расстановки кораблей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ShowGameOverMessage()
        {
            bool win = (currentGameMode == GameMode.Solo ? gameManager.EnemyBoard.AllShipsSunk() : gameManagerServer.EnemyBoard.AllShipsSunk());
            if (win)
            {
                MessageBox.Show("Победа! Все корабли противника уничтожены!", "Морской бой",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Поражение! Ваши корабли уничтожены.", "Морской бой",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            ShowMainMenu();
            if (hostingClient  != null)
                hostingClient.Disconnect();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (hostingClient != null) hostingClient.Disconnect();
        }

        private void btnCreateLobby_Click(object sender, EventArgs e)
        {
            // проверка введен ли никнэйм
            if (string.IsNullOrWhiteSpace(textBoxNickname.Text))
            {
                MessageBox.Show("Введите ваш ник!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // создаём и показываем форму
            var createForm = new CreateLobbyForm();
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                // получаем данные из формы
                string lobbyName = createForm.LobbyName;
                bool isPrivate = createForm.IsPrivate;
                string password = createForm.Password;

                // здесь будет логика создания лобби (пока просто вывод)
                string hostName = Dns.GetHostName();
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                IPAddress localIpAddress = hostEntry.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                Console.WriteLine("Local Adress for Lobby is:", localIpAddress.ToString());

                TcpListener listener = new TcpListener(IPAddress.Any, 0);
                listener.Start();
                int freePort = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();

                Console.WriteLine("Создаём лобби на ", localIpAddress.ToString(), freePort);
                
                _ = hostingClient.CreateNewLobby(lobbyName, localIpAddress.ToString(), freePort, isPrivate, password);
                InitializeOnlineGame();

                Console.WriteLine("Переходим к игре, ожидаем подключения");
                hostPlayer = new HostPlayer(this, gameManagerServer, textBoxNickname.Text, freePort, localIpAddress.ToString());
            }
        }

        private Panel CreateLobbyItem(LobbyServer lobby)
        {
            // главная панель элемента
            var itemPanel = new Panel
            {
                Size = new Size(725, 60),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(0, 0, 64)
            };

            // название лобби
            var nameLabel = new Label
            {
                Text = lobby.Name,
                Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(192, 192, 255),
                AutoSize = true,
                Location = new Point(10, 12)
            };

            // открыто/закрыто
            var statusLabel = new Label
            {
                Text = lobby.IsPrivate ? "Закрытое" : "Открытое",
                Font = new Font("Bookman Old Style", 10F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = lobby.IsPrivate ? Color.FromArgb(255, 192, 192) : Color.FromArgb(192, 255, 192),
                AutoSize = true,
                Location = new Point(420, 15)
            };

            // кнопка "Подключиться"
            var joinButton = new Button
            {
                Text = "Подключиться",
                Font = new Font("Bookman Old Style", 10F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(192, 192, 255),
                BackColor = Color.FromArgb(0, 0, 64),
                Size = new Size(160, 35),
                Location = new Point(550, 10),
                Tag = lobby // сохраняем ссылку на лобби
            };
            joinButton.Click += JoinButton_Click; 

            // добавляем всё в панель
            itemPanel.Controls.Add(nameLabel);
            itemPanel.Controls.Add(statusLabel);
            itemPanel.Controls.Add(joinButton);

            return itemPanel;
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not LobbyServer lobby)
                return;

            // проверка на введеннй ник
            if (string.IsNullOrWhiteSpace(textBoxNickname.Text))
            {
                MessageBox.Show("Введите ваш ник!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lobby.IsPrivate)
            {
                // если закрытое то показываем форму ввода пароля
                var joinForm = new JoinLobbyForm();
                if (joinForm.ShowDialog() == DialogResult.OK)
                {
                    string password = joinForm.EnteredPassword;
                    _ = ClientPlayer.Main(this, textBoxNickname.Text, lobby.Host, lobby.Port, password);
                }
            }
            else
            {
                // открытое лобби — подключаемся сразу
                _ = ClientPlayer.Main(this, textBoxNickname.Text, lobby.Host, lobby.Port, "");
            }
        }

        public void CouldNotConnect()
        {
            MessageBox.Show($"Неверно введён пароль, или лобби уже не активно.",
                                            "Подключение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateLobbyList(List<LobbyServer> lobbies)
        {
            // очищаем список
            flowLayoutPanelLobbies.Controls.Clear();

            // добавляем каждый элемент
            if (lobbies != null)
            {
                foreach (var lobby in lobbies)
                {
                    var item = CreateLobbyItem(lobby);
                    flowLayoutPanelLobbies.Controls.Add(item);
                }
            }
        }
    }
}
