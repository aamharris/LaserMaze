using System;
using System.IO;

namespace LaserMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MazeFileParser
    {
        public string GetFileContentsFromPath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new Exception("No file provided- add file path to args to continue");
            }

            if (Path.GetExtension(filePath) != ".txt")
            {
                throw new Exception("Maze config file must be a text file");
            }

            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                throw new Exception("Error retrieving file.");
            }
        }

        public LaserMazeConfiguration GetLaserMazeConfiguration(string fileContents)
        {
            var settings = fileContents.Split("\r\n-1");
            var config = new LaserMazeConfiguration();

            config.GridSize = GetGridSize(settings[0]);
            
            return config;
        }

        public GridCoordinates GetGridSize(string grid)
        {
            var coords = grid.Split(",");
            var x = int.Parse(coords[0]);
            var y = int.Parse(coords[1]);
            return new GridCoordinates(x, y);
        }
    }

    public class LaserMazeConfiguration
    {
        public GridCoordinates GridSize { get; set; } = new GridCoordinates();
    }

    public class GridCoordinates
    {
        public GridCoordinates() {}
        
        public GridCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
