using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public enum CellState
    {
        Empty,      // пустая клетка
        Ship,       // корабль
        Miss,       // промах
        Hit,        // попадание
        Sunk        // умерший корабль
    }
}
