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
        GameOver
    }

    public class GameManager
    {
        public GameBoard PlayerBoard { get; private set; }
        public GameBoard EnemyBoard { get; private set; }
        public GameState State { get; private set; }

        public GameManager()
        {
            PlayerBoard = new GameBoard();
            EnemyBoard = new GameBoard();
            State = GameState.Placement;
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
            return true;
        }

        // автоматическая расстановка кораблей
        private void AutoPlaceShips(GameBoard board)
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

            return (hit, result);
        }

        // бот стреляет
        public (bool hit, int row, int col, CellState result) EnemyShoot()
        {
            if (State != GameState.EnemyTurn || PlayerBoard.PlacementComplete == false)
                return (false, -1, -1, CellState.Empty);

            var available = new List<(int r, int c)>();
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    var state = PlayerBoard.Grid[r, c];
                    if (state != CellState.Miss && state != CellState.Hit && state != CellState.Sunk)
                        available.Add((r, c));
                }
            }

            if (available.Count == 0)
                return (false, -1, -1, CellState.Empty);

            var random = new Random();
            var (targetRow, targetCol) = available[random.Next(available.Count)];
            bool hit = PlayerBoard.Shoot(targetRow, targetCol, out var result);

            if (hit && !PlayerBoard.AllShipsSunk())
            {
                State = GameState.EnemyTurn;
            }
            else if (!PlayerBoard.AllShipsSunk())
            {
                State = GameState.MyTurn;
            }
            else
            {
                State = GameState.GameOver;
            }

            return (hit, targetRow, targetCol, result);
        }
    }
}
