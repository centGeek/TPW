using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicEventArgsAPI
    {
        private LogicBallAPI ball;
        public static LogicEventArgsAPI CreateLogicEventArgs(LogicBallAPI ball)
        {
            return new LogicEventArgs(ball);
        }
    }
}