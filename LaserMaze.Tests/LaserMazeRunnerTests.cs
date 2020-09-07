using LaserMaze.Enums;
using System.Collections.Generic;
using Xunit;

namespace LaserMaze.Tests
{
    public class LaserMazeRunnerTests
    {
        [Fact]
        public void Initialize_BuildsRooms_WithGridSize()
        {
            var config = new LaserMazeConfiguration
            {
                GridSize = new GridCoordinates(1, 1)
            };
            var mazeRunner = new LaserMazeRunner(config);

            Assert.Equal(4, mazeRunner.Rooms.Count);
        }

        [Fact]
        public void GetLaserExitPoint_ReturnsLastRoom_AfterExitingTheMaze()
        {
            var config = new LaserMazeConfiguration
            {
                GridSize = new GridCoordinates(1, 1),
                LaserStartingPoint = new LaserPoint { Coordinates = new GridCoordinates(0, 0), Direction = LaserDirection.Up }
            };

            var mazeRunner = new LaserMazeRunner(config);

            var endingPoint = mazeRunner.GetLaserExitPoint();

            Assert.Equal(LaserDirection.Up, endingPoint.Direction);
            Assert.Equal(new GridCoordinates(0, 1), endingPoint.Coordinates);
        }

        [Fact]
        public void GetLaserExitPoint_ReturnsLastRoom_WhenTwoWayMirrorsExist()
        {
            var mirror = new Mirror { Coordinates = new GridCoordinates(0, 1), MirrorOrientation = MirrorOrientation.Right, MirrorType = MirrorType.TwoWay };
            var config = new LaserMazeConfiguration
            {
                GridSize = new GridCoordinates(1, 1),
                Mirrors = new List<Mirror> { mirror },
                LaserStartingPoint = new LaserPoint { Coordinates = new GridCoordinates(0, 0), Direction = LaserDirection.Up }
            };

            var mazeRunner = new LaserMazeRunner(config);

            var endingPoint = mazeRunner.GetLaserExitPoint();

            Assert.Equal(LaserDirection.Right, endingPoint.Direction);
            Assert.Equal(new GridCoordinates(1, 1), endingPoint.Coordinates);
        }
    }
}
