using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperField.Entities
{
    public class Player : IPlayer
    {
        private int _row;
        private int _column;
        private int _maxRow;
        private int _maxColumn;
        private int _moveCount; // To track the number of moves


        public Player(int maxRow,int maxColumn)
        {
            _row = 0;
            _column = 0;
            _maxRow = maxRow;
            _maxColumn = maxColumn;
            _moveCount = 0;
        }

        public string GetPosition()
        {
            char columnChar = (char)('A' + _column);
            int rowNum = _row + 1;
            return $"{columnChar}{rowNum}";
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (_row > 0) _row--;
                    break;
                case Direction.Down:
                    if (_row < _maxRow) _row++;
                    break;
                case Direction.Left:
                    if (_column > 0) _column--;
                    break;
                case Direction.Right:
                    if (_column < _maxColumn) _column++;
                    break;
            }
            _moveCount++;
        }
        public int GetMoveCount() => _moveCount;
    }


}
