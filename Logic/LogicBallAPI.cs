using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicBallAPI
    {
        public abstract event EventHandler<LogicEventArgs>? changedPosition;
        public abstract float X { get; set; }
        public abstract float Y { get; set; }

        public static LogicBallAPI CreateBall(int xPosition, int yPosition)
        {
            return new LogicBall(xPosition, yPosition);
        }
    }
}
