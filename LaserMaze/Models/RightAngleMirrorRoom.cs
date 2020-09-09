using LaserMaze.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LaserMaze.Models
{
    public class RightAngleMirrorRoom : BaseRoom, IRoom
    {
        private Mirror _mirror;

        public RightAngleMirrorRoom(Mirror mirror)
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
                return Constants.RightAngleReflectLeft.ContainsKey(currentDirection) ?
                    Constants.RightAngleReflectLeft[currentDirection] : currentDirection;
            }
            if (_mirror.MirrorType == MirrorType.OneWayReflectOnRight) 
            {
                return Constants.RightAngleReflectRight.ContainsKey(currentDirection) ?
                 Constants.RightAngleReflectLeft[currentDirection] : currentDirection;
            }

            return Constants.RightAngleTwoWay[currentDirection];
        }
    }
}
