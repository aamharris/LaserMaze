using LaserMaze.Enums;

namespace LaserMaze.Models
{
    public class EmptyRoom : BaseRoom, IRoom
    {
        public LaserPoint GetNextLaserPosition(LaserDirection currentDirection)
        {
            return GetNextCoordinates(currentDirection);
        }
    }
}
