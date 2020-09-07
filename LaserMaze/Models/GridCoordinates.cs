using System;
using System.Collections.Generic;
using System.Text;

namespace LaserMaze
{
    public class GridCoordinates
    {
        public GridCoordinates(int x, int y)
        {
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

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public override bool Equals(Object obj)
        {
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
