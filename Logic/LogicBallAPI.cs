using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicBallAPI
    {
        public abstract event EventHandler<LogicEventArgsAPI>? changedPosition;
        public abstract float X { get; }
        public abstract float Y { get; }
        public abstract float R { get; }

        public static LogicBallAPI CreateBall(int xPosition, int yPosition, int r)
        {
            return new LogicBall(xPosition, yPosition, r);
        }
    }
}
