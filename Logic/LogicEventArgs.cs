using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LogicEventArgs
    {
        public LogicBallAPI ball;
        public LogicEventArgs(LogicBallAPI ball)
        {
            this.ball = ball;
        }
    }
}
