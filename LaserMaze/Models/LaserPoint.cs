using LaserMaze.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaserMaze
{
    public class LaserPoint
    {
        public GridCoordinates Coordinates { get; set; }
        public LaserDirection Direction { get; set; }
    }
}
