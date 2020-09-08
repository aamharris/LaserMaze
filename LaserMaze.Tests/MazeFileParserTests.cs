using LaserMaze.Enums;
using System;
using System.Linq;
using Xunit;

namespace LaserMaze.Tests
{
    public class MazeFileParserTests
    {
        [Fact]
        public void GetFileContents_ReturnsContents_WithValidTextFile()
        {
            var contents = MazeFileParser.GetFileContents(new string[] { @"./Resources/mazeSettings.txt"});
            Assert.Equal("my\r\ntest\r\nfile", contents);
        }

        [Fact]
        public void GetFileContents_Throws_WhenFilePathEmpty()
        {
            var exception = Assert.Throws<Exception>(() => MazeFileParser.GetFileContents(new string[] { }));
            Assert.Equal("No file provided- add file path to args to continue", exception.Message);
        }

        [Fact]
        public void GetFileContents_Throws_WhenFileNotFoundAtPath()
        {
            var exception = Assert.Throws<Exception>(() => MazeFileParser.GetFileContents(new string[] { "nothinghere.txt" }));
            Assert.Equal("Error retrieving file.", exception.Message);
        }

        [Fact]
        public void GetFileContents_Throws_WhenFileIsNotTextFile()
        {
            var exception = Assert.Throws<Exception>(() => MazeFileParser.GetFileContents(new string[] { @"./Resources/dummy.pdf" }));
            Assert.Equal("Maze config file must be a text file", exception.Message);
        }

        [Fact]
        public void GetLaserMazeConfiguration_GetsGridSize_WithValidConfig()
        {
            var configuration = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2R" }));
            Assert.Equal(1, configuration.GridSize.X);
            Assert.Equal(2, configuration.GridSize.Y);
        }

        [Fact]
        public void GetLaserMazeConfiguration_GetsRightMirror_WhenConfigHasRightMirror()
        {
            var configuration = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2R" }));
            Assert.Single(configuration.Mirrors);
            var mirror = configuration.Mirrors.First();
            Assert.Equal(new GridCoordinates(1, 2), mirror.Coordinates);
            Assert.Equal(MirrorType.TwoWay, mirror.MirrorType);
            Assert.Equal(MirrorOrientation.Right, mirror.MirrorOrientation);
        }

        [Fact]
        public void GetLaserMazeConfiguration_GetsLeftMirror_WhenConfigHasLeftMirror()
        {
            var configuration = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2L" }));
            Assert.Single(configuration.Mirrors);
            var mirror = configuration.Mirrors.First();
            Assert.Equal(new GridCoordinates(1, 2), mirror.Coordinates);
            Assert.Equal(MirrorType.TwoWay, mirror.MirrorType);
            Assert.Equal(MirrorOrientation.Left, mirror.MirrorOrientation);
        }

        [Fact]
        public void GetLaserMazeConfiguration_GetsMirrors_WhenMultipleProvided()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2R", "0,0L" }));
            Assert.Equal(2, config.Mirrors.Count);
            var mirror1 = config.Mirrors.ElementAt(0);
            Assert.Equal(new GridCoordinates(1, 2), mirror1.Coordinates);
            Assert.Equal(MirrorOrientation.Right, mirror1.MirrorOrientation);

            var mirror2 = config.Mirrors.ElementAt(1);
            Assert.Equal(new GridCoordinates(0, 0), mirror2.Coordinates);
            Assert.Equal(MirrorOrientation.Left, mirror2.MirrorOrientation);
        }

        [Fact]
        public void GetLaserMazeConfiguration_GetsOneWayMirrors_WhenConfigHasOneWayRight()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2RR" }));
            Assert.Single(config.Mirrors);
            var mirror = config.Mirrors.First();
            Assert.Equal(new GridCoordinates(1, 2), mirror.Coordinates);
            Assert.Equal(MirrorType.OneWayReflectOnRight, mirror.MirrorType);
            Assert.Equal(MirrorOrientation.Right, mirror.MirrorOrientation);
        }

        [Fact]
        public void GetLaserMazeConfiguration_GetsOneWayMirrors_WhenConfigHasOneWayLeft()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2RL" }));
            Assert.Single(config.Mirrors);
            var mirror = config.Mirrors.First();
            Assert.Equal(new GridCoordinates(1, 2), mirror.Coordinates);
            Assert.Equal(MirrorType.OneWayReflectOnLeft, mirror.MirrorType);
            Assert.Equal(MirrorOrientation.Right, mirror.MirrorOrientation);
        }

        [Fact]
        public void GetLaserMazeConfiguration_SetsLaserRight_WhenStartingConfigurationIsOnLeftSide()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2RL" }, "0,0H"));
            Assert.Equal(LaserDirection.Right, config.LaserStartingPoint.Direction);
            Assert.Equal(new GridCoordinates(0,0), config.LaserStartingPoint.Coordinates);
        }

        [Fact]
        public void GetLaserMazeConfiguration_SetsLaserLeft_WhenStartingConfigurationIsOnRightSide()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2RL" }, "1,2H"));
            Assert.Equal(LaserDirection.Left, config.LaserStartingPoint.Direction);
            Assert.Equal(new GridCoordinates(1, 2), config.LaserStartingPoint.Coordinates);
        }

        [Fact]
        public void GetLaserMazeConfiguration_SetsLaserUp_WhenStartingConfigurationIsOnBottom()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2RL" }, "0,0V"));
            Assert.Equal(LaserDirection.Up, config.LaserStartingPoint.Direction);
            Assert.Equal(new GridCoordinates(0, 0), config.LaserStartingPoint.Coordinates);
        }

        [Fact]
        public void GetLaserMazeConfiguration_SetsLaserDown_WhenStartingConfigurationIsOnTop()
        {
            var config = MazeFileParser.GetLaserMazeConfiguration(buildMazeConfigFileContents("1,2", new string[] { "1,2RL" }, "1,2V"));
            Assert.Equal(LaserDirection.Down, config.LaserStartingPoint.Direction);
            Assert.Equal(new GridCoordinates(1, 2), config.LaserStartingPoint.Coordinates);
        }

        private string buildMazeConfigFileContents(string coordinates, string[] mirrors, string startingConfiguration = "0,0H")
        {
            return $"{coordinates}\r\n-1\r\n{string.Join("\r\n\"", mirrors)}\r\n-1\r\n{startingConfiguration}";
        }
    }
}
