using LaserMaze.Enums;

namespace LaserMaze.Models
{
    public class Room : BaseRoom, IRoom
    {
        public LaserPoint GetNextLaserPosition(LaserDirection currentDirection)
        {
            return GetNextCoordinates(currentDirection);
        }
    }
}
