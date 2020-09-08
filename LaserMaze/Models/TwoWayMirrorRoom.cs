using LaserMaze.Enums;

namespace LaserMaze.Models
{
    public class TwoWayMirrorRoom : BaseRoom, IRoom
    {
        private Mirror _mirror { get; set; }
        public TwoWayMirrorRoom(Mirror mirror)
        {
            _mirror = mirror;
            Coordinates = mirror.Coordinates;
        }
       
        public LaserPoint GetNextLaserPosition(LaserDirection currentDirection)
        {
            var newLaserDirection = SetLaserDirection(currentDirection);
            return GetNextCoordinates(newLaserDirection);           
        }

        private LaserDirection SetLaserDirection(LaserDirection currentDirection)
        {
            switch (currentDirection)
            {
                case LaserDirection.Up:
                    return _mirror.MirrorOrientation == MirrorOrientation.Left ? LaserDirection.Left : LaserDirection.Right;
                case LaserDirection.Down:
                    return _mirror.MirrorOrientation == MirrorOrientation.Left ? LaserDirection.Right : LaserDirection.Left;
                case LaserDirection.Left:
                    return _mirror.MirrorOrientation == MirrorOrientation.Left ? LaserDirection.Up : LaserDirection.Down;
                default:
                    return _mirror.MirrorOrientation == MirrorOrientation.Left ? LaserDirection.Down : LaserDirection.Up;
            }           
        }
    }
}
