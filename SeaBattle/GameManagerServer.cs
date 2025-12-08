using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public class GameManagerServer
    {
        public GameBoard PlayerBoard { get; private set; }
        public GameBoard EnemyBoard { get; private set; }
        public GameState State { get; private set; }
        private Form1 form;

        public GameManagerServer(Form1 form)
        {
            PlayerBoard = new GameBoard();
            EnemyBoard = new GameBoard();
            State = GameState.ServerWait;
            this.form = form;
        }

        public void PlayerConnected()
        {
            State = GameState.Placement;
            form.UpdateCurState(State);
        }
        public void SetEnemyBoard(GameBoard neb)
        {
            EnemyBoard = neb;
        }

        // проверка на то, все ли игроки закончили с растоновкой
        public bool TryFinishPlacement()
        {
            if (!PlayerBoard.HasAllShipsPlaced())
                return false;
            PlayerBoard.FinishPlacement();
            if (!EnemyBoard.HasAllShipsPlaced())
                return false;
            EnemyBoard.FinishPlacement();
            State = GameState.MyTurn;
            form.UpdateCurState(State);
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

        public (bool hit, CellState result) ShootingController(int row, int col, GameBoard board)
        {
            if (State != GameState.MyTurn || board.PlacementComplete == false)
                return (false, CellState.Empty);

            bool hit = board.Shoot(row, col, out var result);

            
            if (!board.AllShipsSunk())
            {
                if (!hit){
                    if (State == GameState.EnemyTurn)
                    {
                        State = GameState.MyTurn;
                    }
                        State = GameState.EnemyTurn;
                }
            }
            else
            {
                State = GameState.GameOver;
            }

            form.UpdateCurState(State);
            return (hit, result);
        }

        private bool IsValidTarget(int r, int c)
        {
            if (r < 0 || r >= 10 || c < 0 || c >= 10)
                return false;
            var state = PlayerBoard.Grid[r, c];
            return state != CellState.Miss && state != CellState.Hit && state != CellState.Sunk;
        }
    }
}
