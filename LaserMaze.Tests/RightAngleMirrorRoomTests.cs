using LaserMaze.Enums;
using LaserMaze.Models;
using Xunit;

namespace LaserMaze.Tests
{

    public class RightAngleMirrorRoomTests
    {
        private RightAngleMirrorRoom GetMirrorRoom(MirrorType mirrorType)
        {
            var coords = new GridCoordinates(1, 1);
            var mirror = new Mirror
            {
                Coordinates = coords,
                MirrorOrientation = MirrorOrientation.Right,
                MirrorType = mirrorType
            };

            return new RightAngleMirrorRoom(mirror);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsRight_WithTwoWayAndLaserFromBottom()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.TwoWay);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Up);
            Assert.Equal(LaserDirection.Right, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(2, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsUp_WithTwoWayandLaserFromLeft()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.TwoWay);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Right);
            Assert.Equal(LaserDirection.Up, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 2), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsDown_WithTwoWayAndLaserFromRight()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.TwoWay);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Left);
            Assert.Equal(LaserDirection.Down, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 0), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsLeft_WithTwoWayAndLaserFromTop()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.TwoWay);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Down);
            Assert.Equal(LaserDirection.Left, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(0, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsDown_WithOneWayLeftAndLaserFromRight()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.OneWayReflectOnLeft);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Left);
            Assert.Equal(LaserDirection.Left, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(0, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsLeft_WithOneWayLeftAndLaserFromTop()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.OneWayReflectOnLeft);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Down);
            Assert.Equal(LaserDirection.Left, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(0, 1), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsUp_WithOneWayLeftAndLaserFromBottom()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.OneWayReflectOnLeft);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Up);
            Assert.Equal(LaserDirection.Up, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 2), nextPosition.Coordinates);
        }

        [Fact]
        public void GetNextLaserPosition_ReturnsUp_WithOneWayLeftAndLaserFromLeft()
        {
            var mirrorRoom = GetMirrorRoom(MirrorType.OneWayReflectOnLeft);

            var nextPosition = mirrorRoom.GetNextLaserPosition(LaserDirection.Right);
            Assert.Equal(LaserDirection.Up, nextPosition.Direction);
            Assert.Equal(new GridCoordinates(1, 2), nextPosition.Coordinates);
        }
    }
}
