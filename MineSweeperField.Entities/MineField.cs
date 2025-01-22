using MineSweeperField.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperField.Entities
{
    public class MineField : IMineField
    {
        private int _width;
        private int _height;
        private int _numberOfMines;
        private string[,] _board;
        private Random _rand;

        public MineField(int width, int height, int numberOfMines)
        {
            _width = width;
            _height = height;
            _numberOfMines = numberOfMines;
            _board = new string[height, width];
            _rand = new Random();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    _board[row, col] = ".";
                }
            }

            int minesPlaced = 0;
            while (minesPlaced < _numberOfMines)
            {
                int row = _rand.Next(0, _height);
                int col = _rand.Next(0, _width);
                if (_board[row, col] == ".")
                {
                    _board[row, col] = "X";
                    minesPlaced++;
                }
            }
        }

        public void DisplayBoard(int playerRow, int playerColumn)
        {
            for (int row = 0; row < _height; row++)
            {
                for (int col = 0; col < _width; col++)
                {
                    if (row == playerRow && col == playerColumn)
                    {
                        Console.Write("P ");
                    }
                    else if (_board[row, col] == "X")
                    {
                        Console.Write(". ");
                    }
                    else
                    {
                        Console.Write(_board[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool CheckForMine(int row, int col)
        {
            return _board[row, col] == "X";
        }

        public bool IsWin(int playerRow, int playerColumn)
        {
            return playerRow == _height - 1 && playerColumn == _width - 1;
        }
    }

}
