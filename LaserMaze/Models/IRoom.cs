using LaserMaze.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaserMaze.Models
{
    public interface IRoom
    {
        GridCoordinates Coordinates { get; set; }
        LaserPoint GetNextLaserPosition(LaserDirection currentDirection);        
    }
}

