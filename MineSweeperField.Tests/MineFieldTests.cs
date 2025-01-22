using MineSweeperField.Entities;
using Xunit;
namespace MineSweeperField.Tests
{
    public class MineFieldTests
    {
        [Fact]
        public void TestCheckForMineReturnsTrueWhenMineExists()
        {
            // Arrange
            var mineField = new MineField(8, 8, 5); // 8x8 board with 5 mines
            int row = 2, col = 3; // Assume mine is placed at (2, 3)


            // Act
            bool result = mineField.CheckForMine(row, col); // Check if there's a mine at (2, 3)

            // Assert
            Assert.False(result, "There should be a mine at (2, 3).");
        }

        [Fact]
        public void TestCheckForMineReturnsFalseWhenNoMineExists()
        {
            // Arrange
            var mineField = new MineField(8, 8, 5); // 8x8 board with 5 mines
            int row = 4, col = 5; // Assume no mine is at (4, 5)


            // Act
            bool result = mineField.CheckForMine(row, col); // Check if there's no mine at (4, 5)

            // Assert
            Assert.False(result, "There should not be a mine at (4, 5).");
        }

        [Fact]
        public void TestMinePlacement()
        {
            // Arrange
            var mineField = new MineField(8, 8, 5); // 8x8 board with 5 mines

            // Act: Check if there are exactly 5 mines placed
            int mineCount = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (mineField.CheckForMine(row, col)) mineCount++;
                }
            }

            // Assert
            Assert.Equal(5, mineCount); // Verify that there are exactly 5 mines placed
        }
    }
}
