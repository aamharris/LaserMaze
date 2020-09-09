using LaserMaze.Enums;
using System.Collections.Generic;
using System.Linq;

namespace LaserMaze.Models
{
    public static class Constants
    {
        public static Dictionary<LaserDirection, LaserDirection> RightAngleReflectRight = new Dictionary<LaserDirection, LaserDirection>
        {
            { LaserDirection.Left, LaserDirection.Down },
            { LaserDirection.Up, LaserDirection.Right }
        };

        public static Dictionary<LaserDirection, LaserDirection> RightAngleReflectLeft = new Dictionary<LaserDirection, LaserDirection>
        {
            { LaserDirection.Down, LaserDirection.Left },
            { LaserDirection.Right, LaserDirection.Up },
        };

        public static Dictionary<LaserDirection, LaserDirection> RightAngleTwoWay = new Dictionary<LaserDirection, LaserDirection>()
          .Concat(RightAngleReflectLeft).Concat(RightAngleReflectRight).ToLookup(x => x.Key, x => x.Value)
              .ToDictionary(x => x.Key, g => g.First());

        public static Dictionary<LaserDirection, LaserDirection> LeftAngleReflectLeft = new Dictionary<LaserDirection, LaserDirection>
        {
            { LaserDirection.Right, LaserDirection.Down },
            { LaserDirection.Up, LaserDirection.Left },
        };

        public static Dictionary<LaserDirection, LaserDirection> LeftAngleReflectRight = new Dictionary<LaserDirection, LaserDirection>
        {
            { LaserDirection.Down, LaserDirection.Right },
            { LaserDirection.Left, LaserDirection.Up }
        };

        public static Dictionary<LaserDirection, LaserDirection> LeftAngleTwoWay = new Dictionary<LaserDirection, LaserDirection>()
            .Concat(LeftAngleReflectLeft).Concat(LeftAngleReflectRight).ToLookup(x => x.Key, x => x.Value)
                .ToDictionary(x => x.Key, g => g.First());
    }   
}

      