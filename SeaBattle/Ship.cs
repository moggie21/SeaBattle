using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Ship
    {
        public int Length { get; private set; }
        public bool IsVertical { get; private set; }
        public (int Row, int Col) Start { get; private set; } // левая верхняя клетка
        public bool[] HitParts { get; private set; } // по одной bool на палубу

        public Ship(int length, (int Row, int Col) start, bool isVertical)
        {
            if (length < 1 || length > 4)
                throw new ArgumentException("Длина корабля должна быть от 1 до 4.");
            Length = length;
            Start = (start.Row, start.Col);
            IsVertical = isVertical;
            HitParts = new bool[length];
        }
        //public Ship(int length, int startRow, int startCol, bool isVertical)
        //{
        //    if (length < 1 || length > 4)
        //        throw new ArgumentException("Длина корабля должна быть от 1 до 4.");
        //    Length = length;
        //    Start = (startRow, startCol);
        //    IsVertical = isVertical;
        //    HitParts = new bool[length];
        //}
        

        // Получить все координаты корабля
        public List<(int Row, int Col)> GetCells()
        {
            var cells = new List<(int, int)>();
            for (int i = 0; i < Length; i++)
            {
                int row = IsVertical ? Start.Row + i : Start.Row;
                int col = IsVertical ? Start.Col : Start.Col + i;
                cells.Add((row, col));
            }
            return cells;
        }

        // Получить координаты ореола (все соседние + диагональные клетки)
        public List<(int Row, int Col)> GetSurrounding()
        {
            var surrounding = new HashSet<(int, int)>();
            var cells = GetCells();

            foreach (var (r, c) in cells)
            {
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int nr = r + dr;
                        int nc = c + dc;
                        if (nr >= 0 && nr < 10 && nc >= 0 && nc < 10)
                        {
                            // Не включаем саму клетку корабля
                            if (!cells.Contains((nr, nc)))
                            {
                                surrounding.Add((nr, nc));
                            }
                        }
                    }
                }
            }
            return new List<(int, int)>(surrounding);
        }

        // Получить количество подбитых палуб
        public int Hits => HitParts.Count(h => h);

        // Подбита ли вся палуба?
        public bool IsSunk => Hits == Length;

        // Обработать попадание по палубе с индексом
        public void RegisterHit(int index)
        {
            if (index >= 0 && index < Length)
                HitParts[index] = true;
        }
    }
}
