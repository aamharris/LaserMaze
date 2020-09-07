using LaserMaze.Enums;
using LaserMaze.Models;
using System.Collections.Generic;
using System.Linq;

namespace LaserMaze
{
    public class LaserMazeRunner
    {
        public List<Room> Rooms { get; set; }

        private GridCoordinates _gridSize;

        private LaserPoint _startingLaserPoint;
        private LaserPoint _previousLaserPoint;
        private bool hasExited;

        public LaserMazeRunner(LaserMazeConfiguration config)
        {
            _startingLaserPoint = config.LaserStartingPoint;
            _gridSize = config.GridSize;
            Rooms = BuildRooms(_gridSize);
        }       

        public LaserPoint GetLaserExitPoint()
        {
            _previousLaserPoint = _startingLaserPoint;

            while (!hasExited)
            {
                var nextPoint = GetNextLaserPoint(_previousLaserPoint);
                if (nextPoint == null)
                {
                    hasExited = true;
                }
            }

            return _previousLaserPoint;
        }

        private LaserPoint GetNextLaserPoint(LaserPoint _currentLaserPoint)
        {
            var currentRoom = Rooms.Where(a => a.Coordinates.X == _currentLaserPoint.Coordinates.X && a.Coordinates.Y == _currentLaserPoint.Coordinates.Y).FirstOrDefault();
            if (currentRoom == null)
            {
                return null;
            }
            else
            {
                _previousLaserPoint = _currentLaserPoint;
                var nextPoint = currentRoom.GetNextLaserPosition(_currentLaserPoint.Direction);
                return GetNextLaserPoint(nextPoint);
            }
        }




        private List<Room> BuildRooms(GridCoordinates gridSize)
        {
            var rooms = new List<Room>();
            for (int y = 0; y <= gridSize.Y; y++)
            {
                for (int x = 0; x <= gridSize.X; x++)
                {
                    rooms.Add(new Room { Coordinates = new GridCoordinates(x, y) });
                }
            }
            return rooms;
        }        
    }
}
