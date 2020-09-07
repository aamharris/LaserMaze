using System;

namespace LaserMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laser Maze");
            var fileContents = MazeFileParser.GetFileContentsFromPath(args[0]);
            var config = MazeFileParser.GetLaserMazeConfiguration(fileContents);

            Console.WriteLine("Staring Configurations");
            Console.WriteLine($"Dimensions: {config.GridSize.X} x {config.GridSize.Y}");
            Console.WriteLine($"Laser Starting Point: ${config.LaserStartingPoint.Coordinates}");
            Console.WriteLine($"Laser Starting Orientation: ${config.LaserStartingPoint.Direction}");

            Console.WriteLine("Running Laser Through Maze");
            var exitPosition = new LaserMazeRunner(config).GetLaserExitPoint();

            Console.WriteLine("Exit Position");
            Console.WriteLine($"Laser Exit Point: ${exitPosition.Coordinates}");
            Console.WriteLine($"Laser Starting Orientation: ${exitPosition.Direction}");
        }
    }
}
