using System.Windows.Forms;

namespace SeaBattle
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;
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

        private void ShowMainMenu()
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
        }

        private void ShowLobbyPanel()
        {
            panelLobby.Visible = true;
            panelMainMenu.Visible = false;
            panelGame.Visible = false;

            var testLobbies = new List<TestLobbyServer>
            {
                new TestLobbyServer("Заход", "127.0.0.1", 8888, false),
                new TestLobbyServer("Секретная игра", "192.168.1.10", 9999, true, "12345")
            };
            UpdateLobbyList(testLobbies);
        }

        private void btnSolo_Click(object sender, EventArgs e)
        {
            currentGameMode = GameMode.Solo;
            InitializeGame();
            ShowGamePanel();
        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            currentGameMode = GameMode.Multiplayer;
            InitializeGame();
            ShowLobbyPanel();
        }

        private void InitializeGame()
        {
            gameManager = new GameManager();

            CreateGrid(playerPanel, playerCells, isPlayer: true);
            CreateGrid(enemyPanel, enemyCells, isPlayer: false);
            UpdateStatus();
            UpdateShipButtons();
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

            if (gameManager.State == GameState.Placement)
            {
                if (isPlayerField && selectedShipLength.HasValue)
                {
                    bool isVertical = radioVertical.Checked;
                    if (gameManager.PlayerBoard.PlaceShip(selectedShipLength.Value, r, c, isVertical))
                    {
                        selectedShipLength = null;
                        btnShip4.BackColor = SystemColors.Control;
                        btnShip3.BackColor = SystemColors.Control;
                        btnShip2.BackColor = SystemColors.Control;
                        btnShip1.BackColor = SystemColors.Control;
                        RenderPlayerBoard();
                        UpdateStatus();
                        UpdateShipButtons();
                    }
                    else
                    {
                        MessageBox.Show("Нельзя разместить корабль здесь!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (gameManager.State == GameState.MyTurn)
            {
                if (!isPlayerField)
                {
                    var state = gameManager.EnemyBoard.Grid[r, c];
                    if (state == CellState.Miss || state == CellState.Hit || state == CellState.Sunk)
                    {
                        MessageBox.Show("Сюда уже стреляли!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // стреляет по противнику
                    var (hit, result) = gameManager.PlayerShoot(r, c);
                    RenderEnemyBoard();
                    UpdateStatus();

                    if (gameManager.State == GameState.GameOver)
                    {
                        ShowGameOverMessage();
                        return;
                    }

                    // если промах, то ходит бот
                    if (!hit || gameManager.State == GameState.EnemyTurn)
                    {
                        ProcessEnemyTurn();
                    }
                }
            }
        }

        private void PlayerCell_MouseEnter(object sender, EventArgs e)
        {
            if (gameManager.State != GameState.Placement || !selectedShipLength.HasValue)
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
            bool canPlace = inBounds && gameManager.PlayerBoard.CanPlaceShip(length, r, c, isVertical);

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
            if (gameManager.State != GameState.Placement)
                return;

            RenderPlayerBoard();
        }

        private void ProcessEnemyTurn()
        {
            if (gameManager.State != GameState.EnemyTurn) return;

            System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
            {
                var (hit, row, col, _) = gameManager.EnemyShoot();

                Invoke(new Action(() =>
                {
                    RenderPlayerBoard();
                    UpdateStatus();

                    if (gameManager.State == GameState.GameOver)
                    {
                        ShowGameOverMessage();
                        return;
                    }

                    if (gameManager.State == GameState.GameOver)
                        return;


                    if (gameManager.State == GameState.EnemyTurn)
                    {
                        ProcessEnemyTurn();
                    }
                    else if (gameManager.State == GameState.MyTurn)
                    {
                        // Ход игрока
                    }
                }));
            });
        }

        private void RenderPlayerBoard()
        {
            var grid = gameManager.PlayerBoard.Grid;
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

        private void RenderEnemyBoard()
        {
            var grid = gameManager.EnemyBoard.Grid;
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
            string status = gameManager.State switch
            {
                GameState.Placement => "Расстановка кораблей. Выберите корабль и кликните на поле.",
                GameState.MyTurn => "Ваш ход",
                GameState.EnemyTurn => "Ход противника...",
                GameState.GameOver => gameManager.EnemyBoard.AllShipsSunk()
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
            if (gameManager.State != GameState.Placement) return;

            var board = gameManager.PlayerBoard;
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
            ShowMainMenu();
            gameManager = null;
        }

        private void buttonStartSolo_Click(object sender, EventArgs e)
        {
            if (gameManager.State == GameState.Placement)
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

        private void ShowGameOverMessage()
        {
            if (gameManager.EnemyBoard.AllShipsSunk())
            {
                MessageBox.Show("Победа! Все корабли противника уничтожены!", "Морской бой",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (gameManager.PlayerBoard.AllShipsSunk())
            {
                MessageBox.Show("Поражение! Ваши корабли уничтожены.", "Морской бой",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBackToMtnu_Click(object sender, EventArgs e)
        {
            ShowMainMenu();
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
                MessageBox.Show($"Создано лобби:\nИмя: {lobbyName}\nТип: {(isPrivate ? "Закрытое" : "Открытое")}",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Panel CreateLobbyItem(TestLobbyServer lobby)
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
            if (sender is not Button button || button.Tag is not TestLobbyServer lobby)
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

                    MessageBox.Show($"Подключаемся к закрытому лобби:\n{lobby.Name}",
                                    "Подключение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // открытое лобби — подключаемся сразу
                MessageBox.Show($"Подключаемся к открытому лобби:\n{lobby.Name}",
                                "Подключение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void UpdateLobbyList(List<TestLobbyServer> lobbies)
        {
            // очищаем список
            flowLayoutPanelLobbies.Controls.Clear();

            // добавляем каждый элемент
            foreach (var lobby in lobbies)
            {
                var item = CreateLobbyItem(lobby);
                flowLayoutPanelLobbies.Controls.Add(item);
            }
        }
    }
}
