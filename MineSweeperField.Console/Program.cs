// See https://aka.ms/new-console-template for more information
using MineSweeperField.Entities;
using MineSweeperField.Entities.Interfaces;
using System.Numerics;

Console.WriteLine("Enter board width (e.g., 8): ");

int width = int.Parse(Console.ReadLine() ?? "8");

Console.WriteLine("Enter board height (e.g., 8): ");
int height = int.Parse(Console.ReadLine() ?? "8");

int numberOfMines = (width * height) / 5;


IPlayer player = new Player(width,height);
IMineField mineField = new MineField(width, height, numberOfMines);
IGame game = new Game(player, mineField);

game.StartGame();

