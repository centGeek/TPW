using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataEventArgsAPI : EventArgs
    {
        public PositionOfBall positionOfBall;
        public SpeedOfBall speedOfBall;
        public int radius;
        public long moveTime;

        public static DataEventArgsAPI CreateDataEventArgs(PositionOfBall positionOfBall, SpeedOfBall speedOfBall, int radius, long moveTime)
        {
            return new DataEventArgs(positionOfBall, speedOfBall, radius, moveTime);
        }
    }
}
