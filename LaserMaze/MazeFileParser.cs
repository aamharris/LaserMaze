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
            var mirrors = new List<Mirror>();

            var mirrorsText = mirrorText.Split("\r\n");
            foreach (var item in mirrorsText)
            {
                var mirrorProps = Regex.Match(item, @"(?<coords>\d+,\d+)(?<orientation>R|L)(?<oneway>R|L)?").Groups;
                var mirror = new Mirror();
                mirror.Coordinates = new GridCoordinates(mirrorProps["coords"].Value);
                mirror.MirrorOrientation = mirrorProps["orientation"].Value == "R" ? MirrorOrientation.Right : MirrorOrientation.Left;
                mirror.MirrorType = GetMirrorType(mirrorProps);
                mirrors.Add(mirror);
            }

            return mirrors;          
        }

        private static MirrorType GetMirrorType(GroupCollection mirrorProps)
        {
            if (string.IsNullOrWhiteSpace(mirrorProps["oneway"]?.Value))
            {
                return MirrorType.TwoWay;
            }
            return mirrorProps["oneway"].Value == "R" ? MirrorType.OneWayReflectOnRight : MirrorType.OneWayReflectOnLeft;
        }

        private static GridCoordinates GetGridSize(string coordText)
        {
            return new GridCoordinates(coordText);
        }
    }
}
