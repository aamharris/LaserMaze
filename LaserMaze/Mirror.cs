using LaserMaze.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaserMaze
{
    public class Mirror
    {
        public GridCoordinates Coordinates { get; set; }
        public MirrorType MirrorType { get; set; }
        public MirrorOrientation MirrorOrientation { get; set; }
    }
}
