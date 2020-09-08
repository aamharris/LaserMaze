using LaserMaze.Enums;
using LaserMaze.Models;
using Xunit;

namespace LaserMaze.Tests
{

    public class TwoWayMirrorRoomTests
    {
        private TwoWayMirrorRoom GetMirrorRoom(MirrorOrientation mirrorOrientation)
        {
            var coords = new GridCoordinates(1, 1);
            var mirror = new Mirror
            {
                Coordinates = coords,
                MirrorOrientation = mirrorOrientation,
                MirrorType = MirrorType.TwoWay
            };
            return new TwoWayMirrorRoom(mirror);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsRight_WithRightAngleAndLaserFromBottom()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Right);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Up);
            Assert.Equal(LaserDirection.Right, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(2, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsUp_WithRightAngleAndLaserFromLeft()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Right);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Right);
            Assert.Equal(LaserDirection.Up, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 2), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsDown_WithRightAngleAndLaserFromRight()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Right);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Left);
            Assert.Equal(LaserDirection.Down, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 0), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsLeft_WithRightAngleAndLaserFromTop()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Right);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Down);
            Assert.Equal(LaserDirection.Left, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(0, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsLeft_WithLeftAngleAndLaserFromBottom()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Left);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Up);
            Assert.Equal(LaserDirection.Left, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(0, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsDown_WithLeftAngleAndLaserFromLeft()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Left);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Right);
            Assert.Equal(LaserDirection.Down, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 0), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsUp_WithLeftAngleAndLaserFromRight()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Left);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Left);
            Assert.Equal(LaserDirection.Up, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 2), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsRight_WithLeftAngleAndLaserFromTop()
        {
            var mirrorRoom = GetMirrorRoom(MirrorOrientation.Left);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Down);
            Assert.Equal(LaserDirection.Right, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(2, 1), nextPosition.Coordinates);
        }
    }
}
