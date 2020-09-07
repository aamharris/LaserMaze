using LaserMaze.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LaserMaze
{
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
}
