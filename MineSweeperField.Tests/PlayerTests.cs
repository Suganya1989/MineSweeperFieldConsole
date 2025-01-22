using MineSweeperField.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperField.Tests
{

    public class PlayerTests
    {
        [Fact]
        public void TestPlayerInitialPosition()
        {
            // Arrange
           // Assume it is 8*8 board
            var player = new Player(8,8);

            // Act
            string position = player.GetPosition();

            // Assert
            Assert.Equal("A1", position); // The player should start at "A1"
        }

        [Fact]
        public void TestPlayerMovesRight()
        {
            // Arrange
            var player = new Player(8,8);

            // Act
            player.Move(Direction.Right); // Move the player to "B1"

            // Assert
            Assert.Equal("B1", player.GetPosition());
        }

        [Fact]
        public void TestPlayerMovesDown()
        {
            // Arrange
            var player = new Player(8, 8);

            // Act
            player.Move(Direction.Down); // Move the player to "A2"

            // Assert
            Assert.Equal("A2", player.GetPosition());
        }

        [Fact]
        public void TestPlayerMovesLeft()
        {
            // Arrange
            var player = new Player(8,8);
            player.Move(Direction.Right); // Start at "A1", move to "B1"

            // Act
            player.Move(Direction.Left); // Move the player back to "A1"

            // Assert
            Assert.Equal("A1", player.GetPosition());
        }

        [Fact]
        public void TestPlayerMovesUp()
        {
            // Arrange
            var player = new Player(8, 8);
            player.Move(Direction.Down); // Start at "A1", move to "A2"

            // Act


        }
    }
}
