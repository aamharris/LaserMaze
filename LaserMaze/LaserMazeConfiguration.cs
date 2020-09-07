using System;
using System.Collections.Generic;
using System.Text;

namespace LaserMaze
{
    public class LaserMazeConfiguration
    {
        public GridCoordinates GridSize { get; set; }
        public List<Mirror> Mirrors { get; set; }
    }
}
