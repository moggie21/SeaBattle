using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public enum GameState
    {
        Placement,      // расстановка кораблей
        MyTurn,         // мой ход
        EnemyTurn,      // ход противника (бота)
        GameOver,
        ServerWait
    }

    public class GameManager
    {
        private (int row, int col)? lastHit = null;          // последнее попадание
        private List<(int row, int col)> potentialTargets = new(); // направления для добивания
        private (int, int)? hitDirection = null;             // направление корабля (если известно)
        public GameBoard PlayerBoard { get; private set; }
        public GameBoard EnemyBoard { get; private set; }
        public GameState State { get; private set; }
        private Form1 form;

        public GameManager(Form1 f)
        {
            PlayerBoard = new GameBoard();
            EnemyBoard = new GameBoard();
            State = GameState.Placement;
            form = f;
            form.UpdateCurState(State);
        }

        // проверка на то, все ли игроки закончили с растоновкой
        public bool TryFinishPlacement()
        {
            if (!PlayerBoard.HasAllShipsPlaced())
                return false;

            PlayerBoard.FinishPlacement();
            // бот расставляет свои корабли автоматически
            AutoPlaceShips(EnemyBoard);
            EnemyBoard.FinishPlacement();

            State = GameState.MyTurn;
            form.UpdateCurState(State);
            return true;
        }

        // автоматическая расстановка кораблей
        public void AutoPlaceShips(GameBoard board)
        {
            var required = GameBoard.RequiredShips;
            var random = new Random();

            foreach (var (length, count) in required)
            {
                for (int i = 0; i < count; i++)
                {
                    bool placed = false;
                    while (!placed)
                    {
                        int r = random.Next(0, 10);
                        int c = random.Next(0, 10);
                        bool vertical = random.Next(2) == 1;

                        if (board.CanPlaceShip(length, r, c, vertical))
                        {
                            board.PlaceShip(length, r, c, vertical);
                            placed = true;
                        }
                    }
                }
            }
        }

        // игрок стреляет по полю противника
        public (bool hit, CellState result) PlayerShoot(int row, int col)
        {
            if (State != GameState.MyTurn || EnemyBoard.PlacementComplete == false)
                return (false, CellState.Empty);

            bool hit = EnemyBoard.Shoot(row, col, out var result);

            if (hit && !EnemyBoard.AllShipsSunk())
            {
                // повторный ход, если подбил или уничтожил корабль
                State = GameState.MyTurn;
            }
            else if (!EnemyBoard.AllShipsSunk())
            {
                State = GameState.EnemyTurn;
            }
            else
            {
                State = GameState.GameOver;
            }

            form.UpdateCurState(State);
            return (hit, result);
        }

        // бот стреляет
        public (bool hit, int row, int col, CellState result) EnemyShoot()
        {
            if (State != GameState.EnemyTurn || PlayerBoard.PlacementComplete == false)
                return (false, -1, -1, CellState.Empty);

            int targetRow = -1, targetCol = -1;

            if (hitDirection != null)
            {
                var (dr, dc) = hitDirection.Value;
                var (startR, startC) = lastHit.Value;

                targetRow = startR + dr;
                targetCol = startC + dc;

                if (!IsValidTarget(targetRow, targetCol))
                {
                    hitDirection = null;
                    lastHit = null;
                    potentialTargets.Clear();
                    return EnemyShoot();
                }
            }
            else if (potentialTargets.Count > 0)
            {
                var next = potentialTargets[0];
                potentialTargets.RemoveAt(0);
                targetRow = next.row;
                targetCol = next.col;

                if (!IsValidTarget(targetRow, targetCol))
                {
                    return EnemyShoot();
                }
            }
            else
            {
                var available = new List<(int r, int c)>();
                for (int r = 0; r < 10; r++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        if (IsValidTarget(r, c))
                            available.Add((r, c));
                    }
                }

                if (available.Count == 0)
                    return (false, -1, -1, CellState.Empty);

                var random = new Random();
                (targetRow, targetCol) = available[random.Next(available.Count)];
            }

            bool hit = PlayerBoard.Shoot(targetRow, targetCol, out var result);

            if (hit)
            {
                if (result == CellState.Sunk)
                {
                    lastHit = null;
                    hitDirection = null;
                    potentialTargets.Clear();
                }
                else
                {
                    if (lastHit == null)
                    {
                        lastHit = (targetRow, targetCol);
                        AddSurroundingTargets(targetRow, targetCol);
                    }
                    else if (hitDirection == null)
                    {
                        var (prevR, prevC) = lastHit.Value;
                        int dr = targetRow - prevR;
                        int dc = targetCol - prevC;

                        if (dr != 0) dr = Math.Sign(dr);
                        if (dc != 0) dc = Math.Sign(dc);

                        hitDirection = (dr, dc);
                        lastHit = (targetRow, targetCol);
                    }
                    else
                    {
                        lastHit = (targetRow, targetCol);
                    }

                    State = GameState.EnemyTurn;
                }
            }
            else
            {
                if (hitDirection != null)
                {
                    hitDirection = null;
                    lastHit = null;
                    potentialTargets.Clear();
                }
                State = GameState.MyTurn;
            }

            if (PlayerBoard.AllShipsSunk())
                State = GameState.GameOver;

            form.UpdateCurState(State);
            return (hit, targetRow, targetCol, result);
        }

        private bool IsValidTarget(int r, int c)
        {
            if (r < 0 || r >= 10 || c < 0 || c >= 10)
                return false;
            var state = PlayerBoard.Grid[r, c];
            return state != CellState.Miss && state != CellState.Hit && state != CellState.Sunk;
        }

        private void AddSurroundingTargets(int r, int c)
        {
            var directions = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            foreach (var (dr, dc) in directions)
            {
                int nr = r + dr;
                int nc = c + dc;
                if (IsValidTarget(nr, nc))
                {
                    potentialTargets.Add((nr, nc));
                }
            }
        }
    }
}
