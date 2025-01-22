using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperField.Entities.Interfaces
{
    public interface IMineField
    {
        void DisplayBoard(int playerRow, int playerColumn);
        bool CheckForMine(int row, int col);
        bool IsWin(int playerRow, int playerColumn);
    }
}
