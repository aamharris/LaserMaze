using System;
using Xunit;

namespace LaserMaze.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MazeFileParser_GetFileContents_WithValidTextFile()
        {
            var fileParser = new MazeFileParser();
            var contents = fileParser.GetFileContentsFromPath(@"./Resources/mazeSettings.txt");
            Assert.Equal("my\r\ntest\r\nfile", contents);
        }

        [Fact]
        public void MazeFileParser_Throws_WhenFilePathEmpty()
        {
            var fileParser = new MazeFileParser();
            var exception = Assert.Throws<Exception>(() => fileParser.GetFileContentsFromPath(""));
            Assert.Equal("No file provided- add file path to args to continue", exception.Message);
        }


        [Fact]
        public void MazeFileParser_Throws_WhenFileNotFoundAtPath()
        {
            var fileParser = new MazeFileParser();
            var exception = Assert.Throws<Exception>(() => fileParser.GetFileContentsFromPath("nothinghere.txt"));
            Assert.Equal("Error retrieving file.", exception.Message);
        }

        [Fact]
        public void MazeFileParser_Throws_WhenFileIsNotTextFile()
        {
            var fileParser = new MazeFileParser();
            var exception = Assert.Throws<Exception>(() => fileParser.GetFileContentsFromPath(@"./Resources/dummy.pdf"));
            Assert.Equal("Maze config file must be a text file", exception.Message);
        }

        [Fact]
        public void MazeFileParser_GetsGridSize_WithValidConfig()
        {
            var fileParser = new MazeFileParser();
            var testFileContents = "1,2";
            var configuration = fileParser.GetLaserMazeConfiguration(testFileContents);
            Assert.Equal(1, configuration.GridSize.X);
            Assert.Equal(2, configuration.GridSize.Y);
        }
    }
}
