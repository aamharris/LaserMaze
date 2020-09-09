using LaserMaze.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LaserMaze.Models
{
    public class LeftAngleMirrorRoom : BaseRoom, IRoom
    {
        private Mirror _mirror;

        public LeftAngleMirrorRoom(Mirror mirror)
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
                return Constants.LeftAngleReflectLeft.ContainsKey(currentDirection) ?
                    Constants.LeftAngleReflectLeft[currentDirection] : currentDirection;
            }
            if (_mirror.MirrorType == MirrorType.OneWayReflectOnRight) 
            {
                return Constants.LeftAngleReflectRight.ContainsKey(currentDirection) ?
                 Constants.LeftAngleReflectRight[currentDirection] : currentDirection;
            }

            return Constants.LeftAngleTwoWay[currentDirection];
        }
    }
}
