using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    internal class LogicEventArgs : LogicEventArgsAPI
    {
        public LogicEventArgs(float _x, float _y, float _r)
        {
            x = _x;
            y = _y;
            r = _r;
        }
    }
}