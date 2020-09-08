using LaserMaze.Enums;

namespace LaserMaze.Models
{
    public class OneWayMirrorRoom : BaseRoom, IRoom
    {
        private Mirror _mirror;

        public OneWayMirrorRoom(Mirror mirror)
        {
            Coordinates = mirror.Coordinates;
            _mirror = mirror;
        }

        public LaserPoint GetNextLaserPosition(LaserDirection currentDirection)
        {
            var newLaserDirection = SetLaserDirection(currentDirection);
            return GetNextCoordinates(newLaserDirection);
        }

        private LaserDirection SetLaserDirection(LaserDirection currentDirection)
        {
            if (_mirror.MirrorType == MirrorType.OneWayReflectOnLeft)
            {
                if (_mirror.MirrorOrientation == MirrorOrientation.Right)
                {
                    if (currentDirection == LaserDirection.Down)
                        return LaserDirection.Left;
                    if (currentDirection == LaserDirection.Left)
                        return LaserDirection.Up;
                } 
                else
                {
                    if (currentDirection == LaserDirection.Right)
                        return LaserDirection.Down;
                    if (currentDirection == LaserDirection.Up)
                        return LaserDirection.Left;
                }
            }

            if (_mirror.MirrorType == MirrorType.OneWayReflectOnRight) 
            {             
                if (_mirror.MirrorOrientation == MirrorOrientation.Right)
                {
                    if (currentDirection == LaserDirection.Up)
                        return LaserDirection.Right;
                    if (currentDirection == LaserDirection.Left)
                        return LaserDirection.Down;
                }
                else
                {
                    if (currentDirection == LaserDirection.Down)
                        return LaserDirection.Right;
                    if (currentDirection == LaserDirection.Left)
                        return LaserDirection.Up;
                }                
            }

            return currentDirection;
        }
    }
}
