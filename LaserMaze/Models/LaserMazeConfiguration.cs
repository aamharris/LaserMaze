﻿using LaserMaze.Enums;
using System.Collections.Generic;

namespace LaserMaze
{
    public class LaserMazeConfiguration
    {
        public GridCoordinates GridSize { get; set; }
        public List<Mirror> Mirrors { get; set; } = new List<Mirror>();
        public LaserPoint LaserStartingPoint { get; set; }
    }
}
