using MineSweeperField.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperField.Entities
{
    public class Game : IGame
    {
        private IPlayer _player;
        private IMineField _mineField;
        private int _lives;
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        public Game(IPlayer player, IMineField mineField)
        {
            _player = player;
            _mineField = mineField;
            _lives = 3;
        }

        public void StartGame()
        {
            while (_lives > 0)
            {
                Console.Clear();
                _mineField.DisplayBoard(GetPlayerRow(), GetPlayerColumn());

                Console.WriteLine($"Current Position: {_player.GetPosition()}");
                Console.WriteLine($"Lives Left: {_lives}");
                Console.WriteLine($"Moves Taken: {_player.GetMoveCount()}");
                Console.WriteLine("Enter your move (up, down, left, right): ");
                string? move = Console.ReadLine()?.ToLower();
                Direction direction;

                if (Enum.TryParse(move, true, out direction))
                {
                    _player.Move(direction);

                    if (_mineField.CheckForMine(GetPlayerRow(), GetPlayerColumn()))
                    {
                        _lives--;
                        Console.WriteLine("Oops! You hit a mine!");
                    }

                    if (_mineField.IsWin(GetPlayerRow(), GetPlayerColumn()))
                    {
                        Console.Clear();
                        _mineField.DisplayBoard(GetPlayerRow(), GetPlayerColumn());
                        Console.WriteLine("Congratulations! You've won!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move! Try again.");
                }
            }

            if (_lives == 0)
            {
                Console.WriteLine("Game Over! You ran out of lives.");
            }
        }

        private int GetPlayerRow()
        {
            return (_player.GetPosition()[1] - '1'); // Map the position from A1 -> 0, B1 -> 1, etc.
        }

        private int GetPlayerColumn()
        {
            return _player.GetPosition()[0] - 'A'; // Map the position from A -> 0, B -> 1, etc.
        }
    }



}
