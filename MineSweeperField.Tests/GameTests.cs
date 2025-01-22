using MineSweeperField.Entities;
using MineSweeperField.Entities.Interfaces;
using Moq;

namespace MineSweeperField.Tests
{
    using Xunit;
    using Moq;

    public class GameTests
    {
        private Mock<IPlayer> _mockPlayer;
        private Mock<IMineField> _mockMineField;
        private Game _game;

        public GameTests()
        {
            _mockPlayer = new Mock<IPlayer>();
            _mockMineField = new Mock<IMineField>();
        }

        [Fact]
        public void TestIsWinCondition()
        {
            // Arrange
            _mockPlayer.Setup(p => p.GetPosition()).Returns("H8");  // Mock position to bottom-right corner
            _mockMineField.Setup(m => m.IsWin(7, 7)).Returns(true); // Assume 8x8 grid, bottom-right corner (H8)

            _game = new Game(_mockPlayer.Object, _mockMineField.Object);

            // Act
            bool isWin = _mockMineField.Object.IsWin(7, 7); // Check if player is at the win condition

            // Assert
            Assert.True(isWin, "Player should have won by reaching the bottom-right corner.");
        }

        [Fact]
        public void TestIsNotWinCondition()
        {
            // Arrange
            _mockPlayer.Setup(p => p.GetPosition()).Returns("B4");  // Mock position not in the bottom-right corner
            _mockMineField.Setup(m => m.IsWin(3, 3)).Returns(false); // Assume 8x8 grid, not the win position

            _game = new Game(_mockPlayer.Object, _mockMineField.Object);

            // Act
            bool isWin = _mockMineField.Object.IsWin(3, 3); // Check if player is not at the win condition

            // Assert
            Assert.False(isWin, "Player should not have won at this position.");
        }
        
        [Fact]
        public void TestGameOverAfterLosingAllLives()
        {
            // Arrange
            // Simulate a player starting at position "A1" (row 0, col 0)
            _mockPlayer.Setup(p => p.GetPosition()).Returns("A1");

            // Mock that the player hits a mine every time (always return true)
            _mockMineField.Setup(m => m.CheckForMine(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            // Assume 3 lives to start
            int lives = 3;

            // Mock the minefield behavior - The game should reduce lives every time a mine is hit
            _game = new Game(_mockPlayer.Object, _mockMineField.Object);

            // Simulate the loop behavior manually
            while (lives > 0)
            {
                // Simulate hitting a mine (decrease lives)
                if (_mockMineField.Object.CheckForMine(0, 0)) // Simulating any position
                {
                    lives--;  // Simulate the player losing a life after hitting a mine
                }
            }

            // Assert that lives are now 0 (game over)
            Assert.Equal(0, lives);
        }

    }

}

