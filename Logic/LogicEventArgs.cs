using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    internal class LogicEventArgs : LogicEventArgsAPI
    {
        public LogicBallAPI ball;

        public LogicEventArgs(LogicBallAPI ball)
        {
            this.ball = ball;
        }
    }
}