using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LaserMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public static class MazeFileParser
    {
        public static string GetFileContentsFromPath(string filePath)
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

        public static LaserMazeConfiguration GetLaserMazeConfiguration(string fileContents)
        {
            var settings = fileContents.Split("\r\n-1\r\n");
            var config = new LaserMazeConfiguration();

            config.GridSize = GetGridSize(settings[0]);
            config.Mirrors = GetMirrors(settings[1]);
            
            return config;
        }

        private static List<Mirror> GetMirrors(string mirrorText)
        {
            var mirrors = mirrorText.Split("\r\n");
            
            var mirrorProps = Regex.Match(mirrors[0], @"(\d+,\d+)(R|L)").Groups;
            var mirror = new Mirror();
            mirror.Coordinates = new GridCoordinates(mirrorProps[1].Value);
            mirror.MirrorType = MirrorType.TwoWay;
            mirror.MirrorOrientation = mirrorProps[2].Value == "R" ? MirrorOrientation.Right : MirrorOrientation.Left;
            return new List<Mirror> { mirror };
        }

        private static GridCoordinates GetGridSize(string coordText)
        {
            return new GridCoordinates(coordText);
        }
    }

    public class LaserMazeConfiguration
    {
        public GridCoordinates GridSize { get; set; }
        public List<Mirror> Mirrors { get; set; }
    }

    public enum MirrorType
    {
        TwoWay,
        OneWayReflectOnRight,
        OneWayReflectOnLeft
    }

    public enum MirrorOrientation
    {
        Left,
        Right
    }

    public class Mirror
    {
        public GridCoordinates Coordinates { get; set; }
        public MirrorType MirrorType { get; set; }
        public MirrorOrientation MirrorOrientation { get; set; }
    }

    public class GridCoordinates
    {
        public GridCoordinates(int x, int y) {
            X = x;
            Y = y;
        }
        
        public GridCoordinates(string coordText)
        {
            string[] xy = coordText.Split(",");
            X = int.Parse(xy[0]);
            Y = int.Parse(xy[1]);
        }

        public int X { get; set; }
        public int Y { get; set; }


        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                GridCoordinates coords = (GridCoordinates)obj;
                return (X == coords.X) && (Y == coords.Y);
            }
        }
    }
}
