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
            var contents = MazeFileParser.GetFileContentsFromPath(@"./Resources/mazeSettings.txt");
            Assert.Equal("my\r\ntest\r\nfile", contents);
        }

        [Fact]
        public void GetFileContents_Throws_WhenFilePathEmpty()
        {
            var exception = Assert.Throws<Exception>(() => MazeFileParser.GetFileContentsFromPath(""));
            Assert.Equal("No file provided- add file path to args to continue", exception.Message);
        }

        [Fact]
        public void GetFileContents_Throws_WhenFileNotFoundAtPath()
        {
            var exception = Assert.Throws<Exception>(() => MazeFileParser.GetFileContentsFromPath("nothinghere.txt"));
            Assert.Equal("Error retrieving file.", exception.Message);
        }

        [Fact]
        public void GetFileContents_Throws_WhenFileIsNotTextFile()
        {
            var exception = Assert.Throws<Exception>(() => MazeFileParser.GetFileContentsFromPath(@"./Resources/dummy.pdf"));
            Assert.Equal("Maze config file must be a text file", exception.Message);
        }

        private string _validTestFileContents => "1,2\r\n-1\r\n1,2R";

        [Fact]
        public void GetLaserMazeConfiguration_GetsGridSize_WithValidConfig()
        {
            var configuration = MazeFileParser.GetLaserMazeConfiguration(_validTestFileContents);
            Assert.Equal(1, configuration.GridSize.X);
            Assert.Equal(2, configuration.GridSize.Y);
        }

        [Fact]
        public void MazeFileParser_GetsMirrors_WithValidConfig()
        {
            var configuration = MazeFileParser.GetLaserMazeConfiguration(_validTestFileContents);
            Assert.Single(configuration.Mirrors);
            var mirror = configuration.Mirrors.First();
            Assert.Equal(new GridCoordinates(1, 2), mirror.Coordinates);
            Assert.Equal(MirrorType.TwoWay, mirror.MirrorType);
            Assert.Equal(MirrorOrientation.Right, mirror.MirrorOrientation);
        }
    }
}
