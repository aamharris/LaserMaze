using LaserMaze.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaserMaze.Models
{
    public class BaseRoom
    {
        public GridCoordinates Coordinates { get; set; }

        public LaserPoint GetNextCoordinates(LaserDirection laserDirection)
        {
            var nextCoordinates = new GridCoordinates(Coordinates.X, Coordinates.Y);

            switch (laserDirection)
            {
                case LaserDirection.Up:
                    nextCoordinates.Y += 1;
                    break;
                case LaserDirection.Down:
                    nextCoordinates.Y -= 1;
                    break;
                case LaserDirection.Left:
                    nextCoordinates.X -= 1;
                    break;
                case LaserDirection.Right:
                    nextCoordinates.X += 1;
                    break;
                default:
                    break;
            }

            return new LaserPoint { Coordinates = nextCoordinates, Direction = laserDirection };
        }
    }
}
