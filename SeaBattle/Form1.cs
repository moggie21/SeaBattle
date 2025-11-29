namespace SeaBattle
{
    public partial class Form1 : Form
    {
        private GameManager gameManager;
        private Panel[,] playerCells = new Panel[10, 10];
        private Panel[,] enemyCells = new Panel[10, 10];

        // для расстановки
        private int? selectedShipLength = null;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
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

                    cells[r, c] = cell;
                    panel.Controls.Add(cell, c, r); // column = c, row = r
                }
            }
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
                    // стреляет по противнику
                    var (hit, result) = gameManager.PlayerShoot(r, c);
                    RenderEnemyBoard();
                    UpdateStatus();

                    // если промах, то ходит бот
                    if (!hit || gameManager.State == GameState.EnemyTurn)
                    {
                        ProcessEnemyTurn();
                    }
                }
            }
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

        private void btnShip4_Click(object sender, EventArgs e)
        {
            selectedShipLength = 4;
        }

        private void btnShip3_Click(object sender, EventArgs e)
        {
            selectedShipLength = 3;
        }

        private void btnShip2_Click(object sender, EventArgs e)
        {
            selectedShipLength = 2;
        }

        private void btnShip1_Click(object sender, EventArgs e)
        {
            selectedShipLength = 1;
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
    }
}
