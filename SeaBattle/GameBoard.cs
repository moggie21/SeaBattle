using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class GameBoard
    {
        public CellState[,] Grid { get; private set; } = new CellState[10, 10];
        public List<Ship> Ships { get; private set; } = new List<Ship>();
        public bool PlacementComplete { get; private set; }

        // подсчет кораблей
        private Dictionary<int, int> shipCounts = new()
        {
            {4, 0}, // 4-палубных
            {3, 0}, // 3-палубных
            {2, 0}, // 2-палубных
            {1, 0}  // 1-палубных
        };

        public void ReplaceBoard((CellState[,] grid, List<Ship> ships) a)
        {
            Grid = a.grid;
            Ships = new List<Ship>();
            for (int i = 0; i < a.ships.Count; i++)
            {
                Ships.Add(a.ships[i]);
            }
        }

        public int GetShipCount(int length)
        {
            return shipCounts.TryGetValue(length, out int count) ? count : 0;
        }

        public GameBoard()
        {
            // изначально всё пусто
            for (int r = 0; r < 10; r++)
                for (int c = 0; c < 10; c++)
                    Grid[r, c] = CellState.Empty;
        }

        // проверка, можно ли разместить корабль
        public bool CanPlaceShip(int length, int startRow, int startCol, bool isVertical)
        {
            // проверка выхода за границы
            if (isVertical && startRow + length > 10) return false;
            if (!isVertical && startCol + length > 10) return false;

            var ship = new Ship(length, (startRow, startCol), isVertical);
            var cells = ship.GetCells();
            var surrounding = ship.GetSurrounding();

            // проверка занята ли клетка
            foreach (var (r, c) in cells)
            {
                if (Grid[r, c] != CellState.Empty) return false;
            }

            // проверка на наличие кораблей рядом
            foreach (var (r, c) in surrounding)
            {
                if (Grid[r, c] == CellState.Ship) return false;
            }

            return true;
        }

        // разместить корабль
        public bool PlaceShip(int length, int startRow, int startCol, bool isVertical)
        {
            if (!CanPlaceShip(length, startRow, startCol, isVertical))
                return false;

            if (shipCounts.TryGetValue(length, out int count) && count >= GameBoard.RequiredShips[length])
            {
                return false;
            }

            var ship = new Ship(length, (startRow, startCol), isVertical);
            var cells = ship.GetCells();

            foreach (var (r, c) in cells)
            {
                Grid[r, c] = CellState.Ship;
            }

            Ships.Add(ship);
            shipCounts[length]++;

            return true;
        }

        // завершить расстановку
        public void FinishPlacement()
        {
            PlacementComplete = true;
        }

        // обработка выстрела
        // возвращает: true — попадание, false — промах
        public bool Shoot(int row, int col, out CellState resultState)
        {
            if (row < 0 || row >= 10 || col < 0 || col >= 10)
            {
                resultState = CellState.Empty;
                return false;
            }

            if (Grid[row, col] == CellState.Miss || Grid[row, col] == CellState.Hit || Grid[row, col] == CellState.Sunk)
            {
                // уже стреляли сюда
                resultState = Grid[row, col];
                return Grid[row, col] == CellState.Hit || Grid[row, col] == CellState.Sunk;
            }

            if (Grid[row, col] == CellState.Ship)
            {
                // найти корабль и отметить попадание
                foreach (var ship in Ships)
                {
                    var shipCells = ship.GetCells();
                    for (int i = 0; i < shipCells.Count; i++)
                    {
                        if (shipCells[i].Row == row && shipCells[i].Col == col)
                        {
                            ship.RegisterHit(i);
                            Grid[row, col] = CellState.Hit;

                            if (ship.IsSunk)
                            {
                                // обводим ореолом
                                foreach (var (r, c) in ship.GetSurrounding())
                                {
                                    if (Grid[r, c] == CellState.Empty)
                                        Grid[r, c] = CellState.Miss;
                                }
                                foreach (var (r, c) in shipCells)
                                    Grid[r, c] = CellState.Sunk;
                            }

                            resultState = ship.IsSunk ? CellState.Sunk : CellState.Hit;
                            return true;
                        }
                    }
                }
            }

            // промах
            Grid[row, col] = CellState.Miss;
            resultState = CellState.Miss;
            return false;
        }

        // проверка победы
        public bool AllShipsSunk()
        {
            return Ships.All(s => s.IsSunk);
        }


        // получить требуемый набор кораблей
        public static Dictionary<int, int> RequiredShips => new()
        {
            {4, 1}, // один 4-палубный
            {3, 2}, // два 3-палубных
            {2, 3}, // три 2-палубных
            {1, 4}  // четыре 1-палубных
        };

        // проверка, расставлены ли все корабли
        public bool HasAllShipsPlaced()
        {
            var shipCounts = new Dictionary<int, int>();
            foreach (var ship in Ships)
            {
                if (!shipCounts.ContainsKey(ship.Length))
                    shipCounts[ship.Length] = 0;
                shipCounts[ship.Length]++;
            }

            foreach (var (length, count) in RequiredShips)
            {
                if (!shipCounts.TryGetValue(length, out int placed) || placed != count)
                    return false;
            }
            return true;
        }
    }
}
