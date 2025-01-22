using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperField.Entities
{
    public interface IPlayer
    {
        string GetPosition();
        void Move(Direction direction);

        int GetMoveCount();
    }
}
