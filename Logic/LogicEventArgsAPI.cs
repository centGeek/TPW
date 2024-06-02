using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicEventArgsAPI : EventArgs
    {
        public float x;
        public float y;
        public float r;
        public static LogicEventArgsAPI CreateLogicEventArgs(float x, float y, float r)
        {
            return new LogicEventArgs(x, y, r);
        }
    }
}